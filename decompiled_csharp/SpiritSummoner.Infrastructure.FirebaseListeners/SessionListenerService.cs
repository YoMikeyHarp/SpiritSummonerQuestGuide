using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Plugin.Firebase.Firestore;
using SpiritSummoner.Infrastructure.Diagnostics;
using SpiritSummoner.Infrastructure.Persistence.DTOs.Players;

namespace SpiritSummoner.Infrastructure.FirebaseListeners;

public class SessionListenerService : ISessionListenerService
{
	private readonly IFirebaseFirestore _firestore;

	private global::System.IDisposable? _listener;

	private string? _currentPlayerId;

	private string? _localSessionId;

	private bool _initialSnapshotReceived;

	[CompilerGenerated]
	[DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	private EventHandler<SessionInvalidatedEventArgs>? m_SessionInvalidated;

	public bool IsListening => _listener != null;

	public event EventHandler<SessionInvalidatedEventArgs>? SessionInvalidated
	{
		[CompilerGenerated]
		add
		{
			EventHandler<SessionInvalidatedEventArgs> val = this.m_SessionInvalidated;
			EventHandler<SessionInvalidatedEventArgs> val2;
			do
			{
				val2 = val;
				EventHandler<SessionInvalidatedEventArgs> val3 = (EventHandler<SessionInvalidatedEventArgs>)(object)global::System.Delegate.Combine((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler<SessionInvalidatedEventArgs>>(ref this.m_SessionInvalidated, val3, val2);
			}
			while (val != val2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<SessionInvalidatedEventArgs> val = this.m_SessionInvalidated;
			EventHandler<SessionInvalidatedEventArgs> val2;
			do
			{
				val2 = val;
				EventHandler<SessionInvalidatedEventArgs> val3 = (EventHandler<SessionInvalidatedEventArgs>)(object)global::System.Delegate.Remove((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler<SessionInvalidatedEventArgs>>(ref this.m_SessionInvalidated, val3, val2);
			}
			while (val != val2);
		}
	}

	public SessionListenerService(IFirebaseFirestore firestore)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		_firestore = firestore ?? throw new ArgumentNullException("firestore");
	}

	public void StartListening(string playerId, string localSessionId)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrWhiteSpace(playerId))
		{
			throw new ArgumentException("Player ID cannot be null or empty", "playerId");
		}
		if (string.IsNullOrWhiteSpace(localSessionId))
		{
			throw new ArgumentException("Local session ID cannot be null or empty", "localSessionId");
		}
		StopListening();
		_currentPlayerId = playerId;
		_localSessionId = localSessionId;
		_initialSnapshotReceived = false;
		try
		{
			_listener = _firestore.GetCollection("players").GetDocument(playerId).GetCollection("sessions")
				.GetDocument("active")
				.AddSnapshotListener<FirestoreActiveSessionDTO>((Action<IDocumentSnapshot<FirestoreActiveSessionDTO>>)OnSessionSnapshot, (Action<global::System.Exception>)OnPlayerError, false);
			Console.WriteLine("SessionListenerService: Started listening for session changes (player: " + playerId + ")");
		}
		catch (global::System.Exception ex)
		{
			Console.WriteLine("SessionListenerService: Failed to start listener: " + ex.Message);
		}
	}

	public void StopListening()
	{
		try
		{
			_listener?.Dispose();
			_listener = null;
			if (!string.IsNullOrWhiteSpace(_currentPlayerId))
			{
				Console.WriteLine("SessionListenerService: Stopped listening (player: " + _currentPlayerId + ")");
			}
			_currentPlayerId = null;
			_localSessionId = null;
			_initialSnapshotReceived = false;
		}
		catch (global::System.Exception ex)
		{
			Console.WriteLine("SessionListenerService: StopListening error: " + ex.Message);
		}
	}

	private void OnSessionSnapshot(IDocumentSnapshot<FirestoreActiveSessionDTO>? snapshot)
	{
		if (snapshot?.Data == null || _localSessionId == null)
		{
			return;
		}
		FirestoreReadCounter.Track("players/*/sessions/active");
		if (!_initialSnapshotReceived)
		{
			_initialSnapshotReceived = true;
			return;
		}
		try
		{
			string sessionId = snapshot.Data.SessionId;
			if (!string.IsNullOrEmpty(sessionId) && sessionId != _localSessionId)
			{
				Console.WriteLine("SessionListenerService: Session invalidated — remote: " + sessionId + ", local: " + _localSessionId);
				this.SessionInvalidated?.Invoke((object)this, new SessionInvalidatedEventArgs(_currentPlayerId ?? string.Empty));
			}
		}
		catch (global::System.Exception ex)
		{
			Console.WriteLine("SessionListenerService: OnPlayerSnapshot error: " + ex.Message);
		}
	}

	private void OnPlayerError(global::System.Exception? error)
	{
		if (error != null)
		{
			Console.WriteLine("SessionListenerService: Listener error: " + error.Message);
		}
	}
}
