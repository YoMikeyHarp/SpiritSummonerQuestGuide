using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.Maui.ApplicationModel;
using Plugin.Firebase.Firestore;

namespace SpiritSummoner.Infrastructure.FirebaseListeners;

public class AppVersionListenerService : IAppVersionListenerService
{
	private sealed class AppVersionDTO : IFirestoreObject
	{
		[FirestoreProperty("minBuildNumber")]
		[field: CompilerGenerated]
		[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
		public int MinBuildNumber
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}
	}

	private readonly IFirebaseFirestore _firestore;

	private global::System.IDisposable? _listener;

	private bool _initialSnapshotReceived;

	[CompilerGenerated]
	[DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	private EventHandler? m_UpdateRequired;

	public event EventHandler UpdateRequired
	{
		[CompilerGenerated]
		add
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			EventHandler val = this.m_UpdateRequired;
			EventHandler val2;
			do
			{
				val2 = val;
				EventHandler val3 = (EventHandler)global::System.Delegate.Combine((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler>(ref this.m_UpdateRequired, val3, val2);
			}
			while (val != val2);
		}
		[CompilerGenerated]
		remove
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			EventHandler val = this.m_UpdateRequired;
			EventHandler val2;
			do
			{
				val2 = val;
				EventHandler val3 = (EventHandler)global::System.Delegate.Remove((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler>(ref this.m_UpdateRequired, val3, val2);
			}
			while (val != val2);
		}
	}

	public AppVersionListenerService(IFirebaseFirestore firestore)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		_firestore = firestore ?? throw new ArgumentNullException("firestore");
	}

	public void StartListening()
	{
		StopListening();
		_initialSnapshotReceived = false;
		try
		{
			_listener = _firestore.GetDocument("config/appVersion").AddSnapshotListener<AppVersionDTO>((Action<IDocumentSnapshot<AppVersionDTO>>)OnSnapshot, (Action<global::System.Exception>)delegate(global::System.Exception ex)
			{
				Console.WriteLine("AppVersionListenerService: listener error: " + ex?.Message);
			}, false);
			Console.WriteLine("AppVersionListenerService: started listening");
		}
		catch (global::System.Exception ex2)
		{
			Console.WriteLine("AppVersionListenerService: failed to start listener: " + ex2.Message);
		}
	}

	public void StopListening()
	{
		_listener?.Dispose();
		_listener = null;
		_initialSnapshotReceived = false;
	}

	private void OnSnapshot(IDocumentSnapshot<AppVersionDTO>? snapshot)
	{
		if (snapshot?.Data == null)
		{
			return;
		}
		if (!_initialSnapshotReceived)
		{
			_initialSnapshotReceived = true;
			return;
		}
		try
		{
			int minBuildNumber = snapshot.Data.MinBuildNumber;
			int num = default(int);
			if (minBuildNumber > 0 && int.TryParse(AppInfo.BuildString, ref num) && num < minBuildNumber)
			{
				Console.WriteLine($"AppVersionListenerService: client build {num} < min {minBuildNumber}, firing UpdateRequired");
				EventHandler? updateRequired = this.UpdateRequired;
				if (updateRequired != null)
				{
					updateRequired.Invoke((object)this, EventArgs.Empty);
				}
			}
		}
		catch (global::System.Exception ex)
		{
			Console.WriteLine("AppVersionListenerService: OnSnapshot error: " + ex.Message);
		}
	}
}
