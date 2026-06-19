using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.BatchUpdates;
using SpiritSummoner.Application.DTOs.Session;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Enums.Common;
using SpiritSummoner.Domain.Enums.Guilds;

namespace SpiritSummoner.Infrastructure.Services;

public class NotificationProcessorService : INotificationProcessorService
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public string playerId;

		public string currentGuildId;

		public string newRole;

		public string guildId;

		internal ValidationResult _003CHandleGuildRoleChangeAsync_003Eb__0(Player player)
		{
			if (player.PlayerID != playerId)
			{
				return ValidationResult.Failure("Player not found");
			}
			if (player.GuildId != currentGuildId)
			{
				return ValidationResult.Failure("Guild not found");
			}
			return ValidationResult.Success();
		}

		internal _003C_003Ef__AnonymousType19<string, GuildRole> _003CHandleGuildRoleChangeAsync_003Eb__1(Player player)
		{
			GuildRole guildRole = default(GuildRole);
			GuildRole role = ((!global::System.Enum.TryParse<GuildRole>(newRole, ref guildRole)) ? GuildRole.Member : guildRole);
			player.SetGuildInfo(guildId, role);
			return new { player.GuildId, player.GuildRole };
		}

		internal PlayerBatchUpdate _003CHandleGuildRoleChangeAsync_003Eb__2(Player player, _003C_003Ef__AnonymousType19<string, GuildRole> updateResult)
		{
			return new PlayerBatchUpdate
			{
				PlayerId = playerId,
				GuildUpdates = new PlayerGuildUpdate
				{
					TargetPlayerId = playerId,
					GuildId = player.GuildId,
					GuildRole = ((object)updateResult.GuildRole).ToString()
				}
			};
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public string playerId;

		internal ValidationResult _003CHandleGuildRemovalAsync_003Eb__0(Player player)
		{
			if (player.PlayerID != playerId)
			{
				return ValidationResult.Failure("Player not found");
			}
			return ValidationResult.Success();
		}

		internal PlayerBatchUpdate _003CHandleGuildRemovalAsync_003Eb__2(Player player, _003C_003Ef__AnonymousType20 updateResult)
		{
			return new PlayerBatchUpdate
			{
				PlayerId = playerId,
				GuildUpdates = new PlayerGuildUpdate
				{
					TargetPlayerId = playerId,
					GuildId = player.GuildId,
					GuildRole = ((object)player.GuildRole).ToString(),
					GuildJoinedAt = null
				}
			};
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public string playerId;

		public string guildRole;

		public string guildId;

		public DateTimeOffset? joinedAt;

		internal ValidationResult _003CHandleGuildJoinedAsync_003Eb__0(Player player)
		{
			if (player.PlayerID != playerId)
			{
				return ValidationResult.Failure("Player not found");
			}
			return ValidationResult.Success();
		}

		internal _003C_003Ef__AnonymousType20 _003CHandleGuildJoinedAsync_003Eb__1(Player player)
		{
			GuildRole guildRole = default(GuildRole);
			GuildRole role = ((!global::System.Enum.TryParse<GuildRole>(this.guildRole, ref guildRole)) ? GuildRole.Member : guildRole);
			player.SetGuildInfo(guildId, role, joinedAt);
			return new { };
		}

		internal PlayerBatchUpdate _003CHandleGuildJoinedAsync_003Eb__2(Player player, _003C_003Ef__AnonymousType20 updateResult)
		{
			return new PlayerBatchUpdate
			{
				PlayerId = playerId,
				GuildUpdates = new PlayerGuildUpdate
				{
					TargetPlayerId = playerId,
					GuildId = player.GuildId,
					GuildRole = ((object)player.GuildRole).ToString(),
					GuildJoinedAt = player.GuildJoinedAt
				}
			};
		}
	}

	[CompilerGenerated]
	private sealed class _003CHandleGuildJoinedAsync_003Ed__5 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public PlayerNotificationDTO notification;

		public string playerId;

		public NotificationProcessorService _003C_003E4__this;

		private _003C_003Ec__DisplayClass5_0 _003C_003E8__1;

		private object _003CjoinedAtObj_003E5__2;

		private DateTimeOffset _003Cdto_003E5__3;

		private Result<_003C_003Ef__AnonymousType20> _003Cresult_003E5__4;

		private void MoveNext()
		{
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				_003C_003E8__1 = new _003C_003Ec__DisplayClass5_0();
				_003C_003E8__1.playerId = playerId;
				_003C_003E8__1.guildId = CollectionExtensions.GetValueOrDefault<string, object>((IReadOnlyDictionary<string, object>)(object)notification.Data, "guildId") as string;
				_003C_003E8__1.guildRole = (CollectionExtensions.GetValueOrDefault<string, object>((IReadOnlyDictionary<string, object>)(object)notification.Data, "guildRole") as string) ?? "member";
				if (string.IsNullOrEmpty(_003C_003E8__1.guildId))
				{
					Console.WriteLine("GuildJoined notification missing guildId");
				}
				else
				{
					_003C_003E8__1.joinedAt = null;
					if (notification.Data.TryGetValue("guildJoinedAt", ref _003CjoinedAtObj_003E5__2) && _003CjoinedAtObj_003E5__2 is DateTimeOffset)
					{
						_003Cdto_003E5__3 = (DateTimeOffset)_003CjoinedAtObj_003E5__2;
						if (true)
						{
							_003C_003E8__1.joinedAt = _003Cdto_003E5__3;
						}
					}
					_003Cresult_003E5__4 = _003C_003E4__this._playerState.ExecuteUpdate((Player player) => (player.PlayerID != _003C_003E8__1.playerId) ? ValidationResult.Failure("Player not found") : ValidationResult.Success(), delegate(Player player)
					{
						GuildRole guildRole = default(GuildRole);
						GuildRole role = ((!global::System.Enum.TryParse<GuildRole>(_003C_003E8__1.guildRole, ref guildRole)) ? GuildRole.Member : guildRole);
						player.SetGuildInfo(_003C_003E8__1.guildId, role, _003C_003E8__1.joinedAt);
						return new { };
					}, (Player player, updateResult) => new PlayerBatchUpdate
					{
						PlayerId = _003C_003E8__1.playerId,
						GuildUpdates = new PlayerGuildUpdate
						{
							TargetPlayerId = _003C_003E8__1.playerId,
							GuildId = player.GuildId,
							GuildRole = ((object)player.GuildRole).ToString(),
							GuildJoinedAt = player.GuildJoinedAt
						}
					});
					if (!_003Cresult_003E5__4.Success)
					{
						Console.WriteLine("Notificationprocessor: Guild joined failed");
					}
					else
					{
						Console.WriteLine("Player joined guild: " + _003C_003E8__1.guildId);
					}
				}
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003CjoinedAtObj_003E5__2 = null;
				_003Cresult_003E5__4 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003CjoinedAtObj_003E5__2 = null;
			_003Cresult_003E5__4 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CHandleGuildRemovalAsync_003Ed__4 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string playerId;

		public NotificationProcessorService _003C_003E4__this;

		private _003C_003Ec__DisplayClass4_0 _003C_003E8__1;

		private Result<_003C_003Ef__AnonymousType20> _003Cresult_003E5__2;

		private void MoveNext()
		{
			int num = _003C_003E1__state;
			try
			{
				_003C_003E8__1 = new _003C_003Ec__DisplayClass4_0();
				_003C_003E8__1.playerId = playerId;
				_003Cresult_003E5__2 = _003C_003E4__this._playerState.ExecuteUpdate((Player player) => (player.PlayerID != _003C_003E8__1.playerId) ? ValidationResult.Failure("Player not found") : ValidationResult.Success(), delegate(Player player)
				{
					player.SetGuildInfo(string.Empty, GuildRole.None, null);
					return new { };
				}, (Player player, updateResult) => new PlayerBatchUpdate
				{
					PlayerId = _003C_003E8__1.playerId,
					GuildUpdates = new PlayerGuildUpdate
					{
						TargetPlayerId = _003C_003E8__1.playerId,
						GuildId = player.GuildId,
						GuildRole = ((object)player.GuildRole).ToString(),
						GuildJoinedAt = null
					}
				});
				if (!_003Cresult_003E5__2.Success)
				{
					Console.WriteLine("Notificationprocessor: Guild removal failed");
				}
				else
				{
					Console.WriteLine("Applied guild removal");
				}
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003Cresult_003E5__2 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003Cresult_003E5__2 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CHandleGuildRoleChangeAsync_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public PlayerNotificationDTO notification;

		public string playerId;

		public string currentGuildId;

		public NotificationProcessorService _003C_003E4__this;

		private _003C_003Ec__DisplayClass3_0 _003C_003E8__1;

		private Result<_003C_003Ef__AnonymousType19<string, GuildRole>> _003Cresult_003E5__2;

		private void MoveNext()
		{
			int num = _003C_003E1__state;
			try
			{
				_003C_003E8__1 = new _003C_003Ec__DisplayClass3_0();
				_003C_003E8__1.playerId = playerId;
				_003C_003E8__1.currentGuildId = currentGuildId;
				_003C_003E8__1.newRole = CollectionExtensions.GetValueOrDefault<string, object>((IReadOnlyDictionary<string, object>)(object)notification.Data, "newRole") as string;
				if (string.IsNullOrEmpty(_003C_003E8__1.newRole))
				{
					Console.WriteLine("GuildRoleChange notification missing newRole");
				}
				else
				{
					_003C_003E8__1.guildId = (CollectionExtensions.GetValueOrDefault<string, object>((IReadOnlyDictionary<string, object>)(object)notification.Data, "guildId") as string) ?? _003C_003E8__1.currentGuildId;
					_003Cresult_003E5__2 = _003C_003E4__this._playerState.ExecuteUpdate(delegate(Player player)
					{
						if (player.PlayerID != _003C_003E8__1.playerId)
						{
							return ValidationResult.Failure("Player not found");
						}
						return (player.GuildId != _003C_003E8__1.currentGuildId) ? ValidationResult.Failure("Guild not found") : ValidationResult.Success();
					}, delegate(Player player)
					{
						GuildRole guildRole = default(GuildRole);
						GuildRole role = ((!global::System.Enum.TryParse<GuildRole>(_003C_003E8__1.newRole, ref guildRole)) ? GuildRole.Member : guildRole);
						player.SetGuildInfo(_003C_003E8__1.guildId, role);
						return new { player.GuildId, player.GuildRole };
					}, (Player player, updateResult) => new PlayerBatchUpdate
					{
						PlayerId = _003C_003E8__1.playerId,
						GuildUpdates = new PlayerGuildUpdate
						{
							TargetPlayerId = _003C_003E8__1.playerId,
							GuildId = player.GuildId,
							GuildRole = ((object)updateResult.GuildRole).ToString()
						}
					});
					if (!_003Cresult_003E5__2.Success)
					{
						Console.WriteLine("Notificationprocessor: Guild role change failed");
					}
					else
					{
						Console.WriteLine("Applied guild role change: " + _003C_003E8__1.newRole);
					}
				}
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003Cresult_003E5__2 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003Cresult_003E5__2 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CProcessNotificationAsync_003Ed__2 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public PlayerNotificationDTO notification;

		public NotificationProcessorService _003C_003E4__this;

		private Player _003Cplayer_003E5__1;

		private NotificationType _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0153: Unknown result type (might be due to invalid IL or missing references)
			//IL_0158: Unknown result type (might be due to invalid IL or missing references)
			//IL_0160: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01da: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_025d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0262: Unknown result type (might be due to invalid IL or missing references)
			//IL_026a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0223: Unknown result type (might be due to invalid IL or missing references)
			//IL_0228: Unknown result type (might be due to invalid IL or missing references)
			//IL_019b: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_023d: Unknown result type (might be due to invalid IL or missing references)
			//IL_023f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0119: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0135: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num > 2u)
				{
				}
				try
				{
					TaskAwaiter awaiter3;
					TaskAwaiter awaiter2;
					TaskAwaiter awaiter;
					switch (num)
					{
					default:
						_003Cplayer_003E5__1 = _003C_003E4__this._playerState.GetCurrentPlayer();
						if (_003Cplayer_003E5__1 != null)
						{
							NotificationType type = notification.Type;
							_003C_003Es__2 = type;
							switch (_003C_003Es__2)
							{
							case NotificationType.GuildPromoted:
							case NotificationType.GuildDemoted:
								break;
							case NotificationType.GuildLeft:
							case NotificationType.GuildKicked:
							case NotificationType.GuildDisbanded:
								goto IL_017c;
							case NotificationType.GuildJoined:
								goto IL_01fe;
							case NotificationType.FriendRequest:
								Console.WriteLine($"Friend request from {CollectionExtensions.GetValueOrDefault<string, object>((IReadOnlyDictionary<string, object>)(object)notification.Data, "senderName")}");
								goto end_IL_0012;
							case NotificationType.FriendRequestAccepted:
								Console.WriteLine($"Friend request accepted by {CollectionExtensions.GetValueOrDefault<string, object>((IReadOnlyDictionary<string, object>)(object)notification.Data, "accepterName")}");
								goto end_IL_0012;
							case NotificationType.FriendRequestDeclined:
								Console.WriteLine("Friend request declined");
								goto end_IL_0012;
							case NotificationType.GuildWarStarted:
							case NotificationType.GuildWarEnrollmentReminder:
							case NotificationType.GuildWarMatchFound:
							case NotificationType.GuildWarRegistrationClosing:
							case NotificationType.GuildWarDefenderManagement:
							case NotificationType.GuildWarDefenderExpiring:
							case NotificationType.GuildWarEnded:
								Console.WriteLine($"[GuildWar] Notification received: {notification.Type}");
								goto end_IL_0012;
							default:
								goto end_IL_0012;
							}
							awaiter3 = _003C_003E4__this.HandleGuildRoleChangeAsync(notification, _003Cplayer_003E5__1.PlayerID ?? "", _003Cplayer_003E5__1.GuildId ?? string.Empty).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter3;
								_003CProcessNotificationAsync_003Ed__2 _003CProcessNotificationAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CProcessNotificationAsync_003Ed__2>(ref awaiter3, ref _003CProcessNotificationAsync_003Ed__);
								return;
							}
							goto IL_016f;
						}
						Console.WriteLine("Cannot process notification: No active player session");
						goto end_IL_0011;
					case 0:
						awaiter3 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_016f;
					case 1:
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_01f1;
					case 2:
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0279;
						}
						IL_01f1:
						((TaskAwaiter)(ref awaiter2)).GetResult();
						break;
						IL_0279:
						((TaskAwaiter)(ref awaiter)).GetResult();
						break;
						IL_01fe:
						awaiter = _003C_003E4__this.HandleGuildJoinedAsync(notification, _003Cplayer_003E5__1.PlayerID ?? "").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__1 = awaiter;
							_003CProcessNotificationAsync_003Ed__2 _003CProcessNotificationAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CProcessNotificationAsync_003Ed__2>(ref awaiter, ref _003CProcessNotificationAsync_003Ed__);
							return;
						}
						goto IL_0279;
						IL_017c:
						awaiter2 = _003C_003E4__this.HandleGuildRemovalAsync(_003Cplayer_003E5__1.PlayerID ?? "").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter2;
							_003CProcessNotificationAsync_003Ed__2 _003CProcessNotificationAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CProcessNotificationAsync_003Ed__2>(ref awaiter2, ref _003CProcessNotificationAsync_003Ed__);
							return;
						}
						goto IL_01f1;
						IL_016f:
						((TaskAwaiter)(ref awaiter3)).GetResult();
						break;
						end_IL_0012:
						break;
					}
					_003Cplayer_003E5__1 = null;
					end_IL_0011:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine("ProcessNotificationAsync error: " + _003Cex_003E5__3.Message);
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IPlayerStateService _playerState;

	public NotificationProcessorService(IPlayerStateService playerState)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		_playerState = playerState ?? throw new ArgumentNullException("playerState");
	}

	[AsyncStateMachine(typeof(_003CProcessNotificationAsync_003Ed__2))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task ProcessNotificationAsync(PlayerNotificationDTO notification)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CProcessNotificationAsync_003Ed__2 _003CProcessNotificationAsync_003Ed__ = new _003CProcessNotificationAsync_003Ed__2();
		_003CProcessNotificationAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CProcessNotificationAsync_003Ed__._003C_003E4__this = this;
		_003CProcessNotificationAsync_003Ed__.notification = notification;
		_003CProcessNotificationAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CProcessNotificationAsync_003Ed__._003C_003Et__builder)).Start<_003CProcessNotificationAsync_003Ed__2>(ref _003CProcessNotificationAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CProcessNotificationAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CHandleGuildRoleChangeAsync_003Ed__3))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task HandleGuildRoleChangeAsync(PlayerNotificationDTO notification, string playerId, string currentGuildId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CHandleGuildRoleChangeAsync_003Ed__3 _003CHandleGuildRoleChangeAsync_003Ed__ = new _003CHandleGuildRoleChangeAsync_003Ed__3();
		_003CHandleGuildRoleChangeAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CHandleGuildRoleChangeAsync_003Ed__._003C_003E4__this = this;
		_003CHandleGuildRoleChangeAsync_003Ed__.notification = notification;
		_003CHandleGuildRoleChangeAsync_003Ed__.playerId = playerId;
		_003CHandleGuildRoleChangeAsync_003Ed__.currentGuildId = currentGuildId;
		_003CHandleGuildRoleChangeAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CHandleGuildRoleChangeAsync_003Ed__._003C_003Et__builder)).Start<_003CHandleGuildRoleChangeAsync_003Ed__3>(ref _003CHandleGuildRoleChangeAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CHandleGuildRoleChangeAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CHandleGuildRemovalAsync_003Ed__4))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task HandleGuildRemovalAsync(string playerId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CHandleGuildRemovalAsync_003Ed__4 _003CHandleGuildRemovalAsync_003Ed__ = new _003CHandleGuildRemovalAsync_003Ed__4();
		_003CHandleGuildRemovalAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CHandleGuildRemovalAsync_003Ed__._003C_003E4__this = this;
		_003CHandleGuildRemovalAsync_003Ed__.playerId = playerId;
		_003CHandleGuildRemovalAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CHandleGuildRemovalAsync_003Ed__._003C_003Et__builder)).Start<_003CHandleGuildRemovalAsync_003Ed__4>(ref _003CHandleGuildRemovalAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CHandleGuildRemovalAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CHandleGuildJoinedAsync_003Ed__5))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task HandleGuildJoinedAsync(PlayerNotificationDTO notification, string playerId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CHandleGuildJoinedAsync_003Ed__5 _003CHandleGuildJoinedAsync_003Ed__ = new _003CHandleGuildJoinedAsync_003Ed__5();
		_003CHandleGuildJoinedAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CHandleGuildJoinedAsync_003Ed__._003C_003E4__this = this;
		_003CHandleGuildJoinedAsync_003Ed__.notification = notification;
		_003CHandleGuildJoinedAsync_003Ed__.playerId = playerId;
		_003CHandleGuildJoinedAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CHandleGuildJoinedAsync_003Ed__._003C_003Et__builder)).Start<_003CHandleGuildJoinedAsync_003Ed__5>(ref _003CHandleGuildJoinedAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CHandleGuildJoinedAsync_003Ed__._003C_003Et__builder)).Task;
	}
}
