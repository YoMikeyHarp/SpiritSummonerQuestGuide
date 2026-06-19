using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Plugin.Firebase.Firestore;
using SpiritSummoner.Domain.Entities.Guilds;
using SpiritSummoner.Infrastructure.Diagnostics;
using SpiritSummoner.Infrastructure.Persistence.DTOs.Guilds;
using SpiritSummoner.Infrastructure.Persistence.Mapping;

namespace SpiritSummoner.Infrastructure.FirebaseListeners;

public class GuildListenerService : IGuildListenerService
{
	private const string GuildCollection = "guilds";

	private const string MembersSubcollection = "members";

	private readonly IFirebaseFirestore _firestore;

	private global::System.IDisposable? _guildListener;

	private global::System.IDisposable? _membersListener;

	private string? _currentGuildId;

	[CompilerGenerated]
	[DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	private EventHandler<GuildUpdatedEventArgs>? m_GuildDocumentUpdated;

	[CompilerGenerated]
	[DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	private EventHandler<GuildMembersUpdatedEventArgs>? m_GuildMembersUpdated;

	public bool IsListening => _guildListener != null;

	public event EventHandler<GuildUpdatedEventArgs>? GuildDocumentUpdated
	{
		[CompilerGenerated]
		add
		{
			EventHandler<GuildUpdatedEventArgs> val = this.m_GuildDocumentUpdated;
			EventHandler<GuildUpdatedEventArgs> val2;
			do
			{
				val2 = val;
				EventHandler<GuildUpdatedEventArgs> val3 = (EventHandler<GuildUpdatedEventArgs>)(object)global::System.Delegate.Combine((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler<GuildUpdatedEventArgs>>(ref this.m_GuildDocumentUpdated, val3, val2);
			}
			while (val != val2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<GuildUpdatedEventArgs> val = this.m_GuildDocumentUpdated;
			EventHandler<GuildUpdatedEventArgs> val2;
			do
			{
				val2 = val;
				EventHandler<GuildUpdatedEventArgs> val3 = (EventHandler<GuildUpdatedEventArgs>)(object)global::System.Delegate.Remove((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler<GuildUpdatedEventArgs>>(ref this.m_GuildDocumentUpdated, val3, val2);
			}
			while (val != val2);
		}
	}

	public event EventHandler<GuildMembersUpdatedEventArgs>? GuildMembersUpdated
	{
		[CompilerGenerated]
		add
		{
			EventHandler<GuildMembersUpdatedEventArgs> val = this.m_GuildMembersUpdated;
			EventHandler<GuildMembersUpdatedEventArgs> val2;
			do
			{
				val2 = val;
				EventHandler<GuildMembersUpdatedEventArgs> val3 = (EventHandler<GuildMembersUpdatedEventArgs>)(object)global::System.Delegate.Combine((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler<GuildMembersUpdatedEventArgs>>(ref this.m_GuildMembersUpdated, val3, val2);
			}
			while (val != val2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<GuildMembersUpdatedEventArgs> val = this.m_GuildMembersUpdated;
			EventHandler<GuildMembersUpdatedEventArgs> val2;
			do
			{
				val2 = val;
				EventHandler<GuildMembersUpdatedEventArgs> val3 = (EventHandler<GuildMembersUpdatedEventArgs>)(object)global::System.Delegate.Remove((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler<GuildMembersUpdatedEventArgs>>(ref this.m_GuildMembersUpdated, val3, val2);
			}
			while (val != val2);
		}
	}

	public GuildListenerService(IFirebaseFirestore firestore)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		_firestore = firestore ?? throw new ArgumentNullException("firestore");
	}

	public void StartListeners(string guildId)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrWhiteSpace(guildId))
		{
			throw new ArgumentException("Guild ID cannot be null or empty", "guildId");
		}
		StopListeners();
		_currentGuildId = guildId;
		try
		{
			_guildListener = _firestore.GetCollection("guilds").GetDocument(guildId).AddSnapshotListener<FirestoreGuildDTO>((Action<IDocumentSnapshot<FirestoreGuildDTO>>)OnGuildSnapshot, (Action<global::System.Exception>)OnGuildError, false);
			_membersListener = ((IQuery)_firestore.GetCollection("guilds").GetDocument(guildId).GetCollection("members")).AddSnapshotListener<FirestoreGuildMemberDTO>((Action<IQuerySnapshot<FirestoreGuildMemberDTO>>)OnMembersSnapshot, (Action<global::System.Exception>)OnMembersError, false);
			Console.WriteLine("Started guild + members listeners for guild: " + guildId);
		}
		catch (global::System.Exception ex)
		{
			Console.WriteLine("StartListeners error for guild " + guildId + ": " + ex.Message);
		}
	}

	public void StopListeners()
	{
		try
		{
			_guildListener?.Dispose();
			_guildListener = null;
			_membersListener?.Dispose();
			_membersListener = null;
			if (!string.IsNullOrWhiteSpace(_currentGuildId))
			{
				Console.WriteLine("Stopped guild listeners for guild: " + _currentGuildId);
			}
			_currentGuildId = null;
		}
		catch (global::System.Exception ex)
		{
			Console.WriteLine("StopListeners error: " + ex.Message);
		}
	}

	private void OnGuildSnapshot(IDocumentSnapshot<FirestoreGuildDTO>? snapshot)
	{
		if (snapshot == null || snapshot.Data == null)
		{
			Console.WriteLine("Guild document does not exist or snapshot is null: " + _currentGuildId);
			return;
		}
		FirestoreReadCounter.Track("guilds [doc listener]");
		try
		{
			FirestoreGuildDTO data = snapshot.Data;
			if (data == null)
			{
				Console.WriteLine("Guild DTO is null for guild: " + _currentGuildId);
				return;
			}
			Guild guild = GuildEntityMapper.ToEntity(data);
			if (guild == null)
			{
				Console.WriteLine("Failed to map guild DTO to entity for guild: " + _currentGuildId);
				return;
			}
			this.GuildDocumentUpdated?.Invoke((object)this, new GuildUpdatedEventArgs(guild, _currentGuildId ?? string.Empty));
			Console.WriteLine($"Guild updated via listener: {guild.Name} (ID: {guild.ID})");
		}
		catch (global::System.Exception ex)
		{
			Console.WriteLine("OnGuildSnapshot error for guild " + _currentGuildId + ": " + ex.Message);
			Console.WriteLine("Stack trace: " + ex.StackTrace);
		}
	}

	private void OnGuildError(global::System.Exception? error)
	{
		if (error == null)
		{
			return;
		}
		Console.WriteLine("Guild listener error for guild " + _currentGuildId + ": " + error.Message);
		global::System.Threading.Tasks.Task.Delay(5000).ContinueWith((Action<global::System.Threading.Tasks.Task>)([CompilerGenerated] (global::System.Threading.Tasks.Task _) =>
		{
			if (!IsListening && !string.IsNullOrWhiteSpace(_currentGuildId))
			{
				Console.WriteLine("Retrying guild listener for guild: " + _currentGuildId);
				StartListeners(_currentGuildId);
			}
		}));
	}

	private void OnMembersSnapshot(IQuerySnapshot<FirestoreGuildMemberDTO>? snapshot)
	{
		if (snapshot?.Documents == null)
		{
			return;
		}
		string currentGuildId = _currentGuildId;
		if (string.IsNullOrWhiteSpace(currentGuildId))
		{
			return;
		}
		try
		{
			FirestoreReadCounter.Track("GetGuildMembers [listener]", Enumerable.Count<IDocumentSnapshot<FirestoreGuildMemberDTO>>(snapshot.Documents));
			Dictionary<string, GuildMember> val = new Dictionary<string, GuildMember>();
			global::System.Collections.Generic.IEnumerator<IDocumentSnapshot<FirestoreGuildMemberDTO>> enumerator = snapshot.Documents.GetEnumerator();
			try
			{
				while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
				{
					IDocumentSnapshot<FirestoreGuildMemberDTO> current = enumerator.Current;
					if (current.Data != null)
					{
						string text = current.Data.PlayerId ?? current.Reference.Id;
						val[text] = GuildMemberEntityMapper.ToEntity(current.Data);
					}
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator)?.Dispose();
			}
			this.GuildMembersUpdated?.Invoke((object)this, new GuildMembersUpdatedEventArgs(val, currentGuildId));
		}
		catch (global::System.Exception ex)
		{
			Console.WriteLine("OnMembersSnapshot error for guild " + currentGuildId + ": " + ex.Message);
		}
	}

	private void OnMembersError(global::System.Exception? error)
	{
		if (error != null)
		{
			Console.WriteLine("Members listener error for guild " + _currentGuildId + ": " + error.Message);
		}
	}
}
