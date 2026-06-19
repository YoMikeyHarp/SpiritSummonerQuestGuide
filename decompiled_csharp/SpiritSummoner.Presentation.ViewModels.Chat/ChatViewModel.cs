using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using SpiritSummoner.Application.DTOs.Battles;
using SpiritSummoner.Application.DTOs.Session;
using SpiritSummoner.Application.Events;
using SpiritSummoner.Application.Services;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Battles;
using SpiritSummoner.Application.UseCases.Chat;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Application.UseCases.Players;
using SpiritSummoner.Domain.Entities.Chat;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Enums.Common;
using SpiritSummoner.Domain.Repositories;
using SpiritSummoner.Infrastructure.Cache;
using SpiritSummoner.Infrastructure.FirebaseListeners;
using SpiritSummoner.Presentation.Models;
using SpiritSummoner.Presentation.Navigation;
using SpiritSummoner.Presentation.Services;
using SpiritSummoner.Presentation.ViewModels.Battles;
using SpiritSummoner.Presentation.ViewModels.BottomSheet;
using SpiritSummoner.Presentation.ViewModels.Popups;
using SpiritSummoner.Presentation.ViewModels.Shared;
using SpiritSummoner.Presentation.ViewModels.Spirits;
using SpiritSummoner.Presentation.Views.BottomSheets.ChatSheets;
using SpiritSummoner.Presentation.Views.BottomSheets.SpiritSheets;
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Presentation.ViewModels.Chat;

public class ChatViewModel : ObservableObject, ILoadableViewModel, global::System.IDisposable
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass71_0
	{
		public string playerId;

		public Func<string, bool> _003C_003E9__6;

		internal _003C_003Ef__AnonymousType22<string, Conversation> _003CLoadDMThreadsAsync_003Eb__1(Conversation c)
		{
			return new
			{
				FriendId = Enumerable.FirstOrDefault<string>((global::System.Collections.Generic.IEnumerable<string>)c.ParticipantIds, (Func<string, bool>)((string id) => id != playerId)),
				Conv = c
			};
		}

		internal bool _003CLoadDMThreadsAsync_003Eb__6(string id)
		{
			return id != playerId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass71_1
	{
		public string friendId;

		internal bool _003CLoadDMThreadsAsync_003Eb__7(ChatPlayerModel f)
		{
			return f.PlayerId == friendId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass72_0
	{
		private sealed class _003C_003COnNotificationReceived_003Eb__1_003Ed : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public _003C_003Ec__DisplayClass72_0 _003C_003E4__this;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
				//IL_0052: Unknown result type (might be due to invalid IL or missing references)
				//IL_0057: Unknown result type (might be due to invalid IL or missing references)
				//IL_005e: Unknown result type (might be due to invalid IL or missing references)
				//IL_001e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0023: Unknown result type (might be due to invalid IL or missing references)
				//IL_0037: Unknown result type (might be due to invalid IL or missing references)
				//IL_0038: Unknown result type (might be due to invalid IL or missing references)
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this._003C_003E4__this.LoadInboxAsync().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003C_003COnNotificationReceived_003Eb__1_003Ed _003C_003COnNotificationReceived_003Eb__1_003Ed = this;
							((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003C_003COnNotificationReceived_003Eb__1_003Ed>(ref awaiter, ref _003C_003COnNotificationReceived_003Eb__1_003Ed);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
					}
					((TaskAwaiter)(ref awaiter)).GetResult();
				}
				catch (global::System.Exception exception)
				{
					_003C_003E1__state = -2;
					((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetResult();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}
		}

		public NotificationReceivedEventArgs args;

		public ChatViewModel _003C_003E4__this;

		internal void _003COnNotificationReceived_003Eb__0()
		{
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			object obj = default(object);
			FriendRequestModel friendRequestModel = new FriendRequestModel
			{
				NotificationId = args.Notification.Id,
				SenderId = ((CollectionExtensions.GetValueOrDefault<string, object>((IReadOnlyDictionary<string, object>)(object)args.Notification.Data, "senderId") as string) ?? string.Empty),
				SenderName = ((CollectionExtensions.GetValueOrDefault<string, object>((IReadOnlyDictionary<string, object>)(object)args.Notification.Data, "senderName") as string) ?? "Unknown"),
				SenderLevel = ((args.Notification.Data.TryGetValue("senderLevel", ref obj) && obj is int num) ? num : 0),
				ReceivedAt = args.Notification.CreatedAt
			};
			((Collection<FriendRequestModel>)(object)_003C_003E4__this.FriendRequests).Insert(0, friendRequestModel);
			_003C_003E4__this.HasFriendRequests = true;
			_003C_003E4__this._chatUnreadService.SetFriendRequestCount(((Collection<FriendRequestModel>)(object)_003C_003E4__this.FriendRequests).Count);
		}

		[AsyncStateMachine(typeof(_003C_003COnNotificationReceived_003Eb__1_003Ed))]
		[DebuggerStepThrough]
		internal void _003COnNotificationReceived_003Eb__1()
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003COnNotificationReceived_003Eb__1_003Ed _003C_003COnNotificationReceived_003Eb__1_003Ed = new _003C_003COnNotificationReceived_003Eb__1_003Ed
			{
				_003C_003Et__builder = AsyncVoidMethodBuilder.Create(),
				_003C_003E4__this = this,
				_003C_003E1__state = -1
			};
			((AsyncVoidMethodBuilder)(ref _003C_003COnNotificationReceived_003Eb__1_003Ed._003C_003Et__builder)).Start<_003C_003COnNotificationReceived_003Eb__1_003Ed>(ref _003C_003COnNotificationReceived_003Eb__1_003Ed);
		}

		internal void _003COnNotificationReceived_003Eb__2()
		{
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			PlayerNotificationModel playerNotificationModel = new PlayerNotificationModel
			{
				Id = args.Notification.Id,
				Type = args.Notification.Type,
				Icon = NotificationFormatter.GetIcon(args.Notification.Type),
				Title = NotificationFormatter.GetTitle(args.Notification.Type),
				Body = NotificationFormatter.GetBody(args.Notification.Type, args.Notification.Data),
				CreatedAt = args.Notification.CreatedAt,
				IsRead = false
			};
			NotificationGroup notificationGroup = Enumerable.FirstOrDefault<NotificationGroup>((global::System.Collections.Generic.IEnumerable<NotificationGroup>)_003C_003E4__this.NotificationGroups, (Func<NotificationGroup, bool>)((NotificationGroup g) => g.GroupLabel == "Today"));
			if (notificationGroup != null)
			{
				((Collection<PlayerNotificationModel>)(object)notificationGroup).Insert(0, playerNotificationModel);
			}
			else
			{
				((Collection<NotificationGroup>)(object)_003C_003E4__this.NotificationGroups).Insert(0, new NotificationGroup("Today", new _003C_003Ez__ReadOnlySingleElementList<PlayerNotificationModel>(playerNotificationModel)));
			}
			_003C_003E4__this.HasNotifications = true;
			int unreadNotificationCount = _003C_003E4__this.UnreadNotificationCount;
			_003C_003E4__this.UnreadNotificationCount = unreadNotificationCount + 1;
			_003C_003E4__this._chatUnreadService.SetUnreadNotificationCount(_003C_003E4__this.UnreadNotificationCount);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass79_0
	{
		public global::System.DateTime today;

		public global::System.DateTime yesterday;

		internal string _003CLoadNotificationsAsync_003Eb__1(PlayerNotificationModel m)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000a: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			DateTimeOffset val = m.CreatedAt;
			val = ((DateTimeOffset)(ref val)).ToLocalTime();
			global::System.DateTime date = ((DateTimeOffset)(ref val)).Date;
			if (date == today)
			{
				return "Today";
			}
			if (date == yesterday)
			{
				return "Yesterday";
			}
			return "Older";
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass88_0
	{
		private sealed class _003C_003CNewMessage_003Eb__1_003Ed : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public _003C_003Ec__DisplayClass88_0 _003C_003E4__this;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
				//IL_0087: Unknown result type (might be due to invalid IL or missing references)
				//IL_008c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0093: Unknown result type (might be due to invalid IL or missing references)
				//IL_0053: Unknown result type (might be due to invalid IL or missing references)
				//IL_0058: Unknown result type (might be due to invalid IL or missing references)
				//IL_006c: Unknown result type (might be due to invalid IL or missing references)
				//IL_006d: Unknown result type (might be due to invalid IL or missing references)
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this._003C_003E4__this._navigationService.NavigateToAsync("//chat/dm?friendId=" + _003C_003E4__this.friend.PlayerId + "|" + _003C_003E4__this.friend.PlayerName).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003C_003CNewMessage_003Eb__1_003Ed _003C_003CNewMessage_003Eb__1_003Ed = this;
							((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003C_003CNewMessage_003Eb__1_003Ed>(ref awaiter, ref _003C_003CNewMessage_003Eb__1_003Ed);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
					}
					((TaskAwaiter)(ref awaiter)).GetResult();
				}
				catch (global::System.Exception exception)
				{
					_003C_003E1__state = -2;
					((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetResult();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}
		}

		public ChatPlayerModel friend;

		public ChatViewModel _003C_003E4__this;

		[AsyncStateMachine(typeof(_003C_003CNewMessage_003Eb__1_003Ed))]
		[DebuggerStepThrough]
		internal void _003CNewMessage_003Eb__1()
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003CNewMessage_003Eb__1_003Ed _003C_003CNewMessage_003Eb__1_003Ed = new _003C_003CNewMessage_003Eb__1_003Ed
			{
				_003C_003Et__builder = AsyncVoidMethodBuilder.Create(),
				_003C_003E4__this = this,
				_003C_003E1__state = -1
			};
			((AsyncVoidMethodBuilder)(ref _003C_003CNewMessage_003Eb__1_003Ed._003C_003Et__builder)).Start<_003C_003CNewMessage_003Eb__1_003Ed>(ref _003C_003CNewMessage_003Eb__1_003Ed);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass95_0
	{
		public BattleResultDTO battleResult;

		public ChatViewModel _003C_003E4__this;

		public ChatPlayerModel opponent;

		internal void _003CShowBattleSummary_003Eb__0(BattleSummaryPopupViewModel vm)
		{
			//IL_018f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0174: Unknown result type (might be due to invalid IL or missing references)
			//IL_0199: Expected O, but got Unknown
			vm.PlayerSpirits = Enumerable.ToList<SpriteModelResultsRecord>(Enumerable.Select<SpiritBattleResult, SpriteModelResultsRecord>((global::System.Collections.Generic.IEnumerable<SpiritBattleResult>)battleResult.PlayerSpirits, (Func<SpiritBattleResult, SpriteModelResultsRecord>)((SpiritBattleResult spirit) => new SpriteModelResultsRecord(spirit.Image, spirit.Fainted ? "x.png" : "check.png", spirit.Fainted ? 0.3 : 1.0))));
			vm.EnemySpirits = Enumerable.ToList<SpriteModelResultsRecord>(Enumerable.Select<SpiritBattleResult, SpriteModelResultsRecord>((global::System.Collections.Generic.IEnumerable<SpiritBattleResult>)battleResult.EnemySpirits, (Func<SpiritBattleResult, SpriteModelResultsRecord>)((SpiritBattleResult spirit) => new SpriteModelResultsRecord(spirit.Image, spirit.Fainted ? "x.png" : "check.png", spirit.Fainted ? 0.3 : 1.0))));
			vm.OutcomeImagePlayer = (battleResult.Victory ? "staricon.png" : "x.png");
			vm.OutcomeImageEnemy = ((!battleResult.Victory) ? "staricon.png" : "x.png");
			vm.OutcomeText = (battleResult.Victory ? "VICTORY!" : "DEFEAT");
			vm.HasRewards = false;
			vm.PlayerName = _003C_003E4__this._playerState.GetCurrentPlayer()?.Playername ?? "";
			vm.EnemyName = opponent.PlayerName;
			vm.EnemyRank = battleResult.OpponentLevel;
			vm.PlayerRank = _003C_003E4__this._playerState.GetCurrentPlayer()?.PlayerLevel ?? 1;
			vm.BackGround = (battleResult.Victory ? ((Brush)Application.Current.Resources["GradientWinSummary"]) : ((Brush)Application.Current.Resources["GradientLossSummary"]));
			vm.TextColor = (battleResult.Victory ? Color.FromArgb("#027242") : Color.FromArgb("#721502"));
		}
	}

	[CompilerGenerated]
	private sealed class _003CAcceptFriendRequest_003Ed__89 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public FriendRequestModel request;

		public ChatViewModel _003C_003E4__this;

		private Result<bool> _003Cresult_003E5__1;

		private Result<bool> _003C_003Es__2;

		private TaskAwaiter<Result<bool>> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0150: Unknown result type (might be due to invalid IL or missing references)
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0189: Unknown result type (might be due to invalid IL or missing references)
			//IL_018e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0196: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_016a: Unknown result type (might be due to invalid IL or missing references)
			//IL_016c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter<Result<bool>> awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Result<bool>>);
					num = (_003C_003E1__state = -1);
					goto IL_00a9;
				}
				TaskAwaiter awaiter2;
				if (num == 1)
				{
					awaiter2 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_01a5;
				}
				if (request != null)
				{
					awaiter = _003C_003E4__this._acceptFriendRequestUseCase.ExecuteAsync(new AcceptFriendRequestRequest(request.SenderId, request.SenderName)).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CAcceptFriendRequest_003Ed__89 _003CAcceptFriendRequest_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<bool>>, _003CAcceptFriendRequest_003Ed__89>(ref awaiter, ref _003CAcceptFriendRequest_003Ed__);
						return;
					}
					goto IL_00a9;
				}
				goto end_IL_0007;
				IL_01a5:
				((TaskAwaiter)(ref awaiter2)).GetResult();
				((Collection<ChatPlayerModel>)(object)_003C_003E4__this.Friends).Add(new ChatPlayerModel
				{
					PlayerId = request.SenderId,
					PlayerName = request.SenderName,
					AddedAt = DateTimeOffset.UtcNow
				});
				_003C_003E4__this.HasFriends = true;
				goto end_IL_0007;
				IL_00a9:
				_003C_003Es__2 = awaiter.GetResult();
				_003Cresult_003E5__1 = _003C_003Es__2;
				_003C_003Es__2 = null;
				if (_003Cresult_003E5__1.Success)
				{
					((Collection<FriendRequestModel>)(object)_003C_003E4__this.FriendRequests).Remove(request);
					_003C_003E4__this.HasFriendRequests = ((Collection<FriendRequestModel>)(object)_003C_003E4__this.FriendRequests).Count > 0;
					_003C_003E4__this._chatUnreadService.SetFriendRequestCount(((Collection<FriendRequestModel>)(object)_003C_003E4__this.FriendRequests).Count);
					awaiter2 = _003C_003E4__this._notificationListener.MarkAsAnswearedAsync(request.NotificationId).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter2;
						_003CAcceptFriendRequest_003Ed__89 _003CAcceptFriendRequest_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CAcceptFriendRequest_003Ed__89>(ref awaiter2, ref _003CAcceptFriendRequest_003Ed__);
						return;
					}
					goto IL_01a5;
				}
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cresult_003E5__1 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cresult_003E5__1 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CDeclineFriendRequest_003Ed__90 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public FriendRequestModel request;

		public ChatViewModel _003C_003E4__this;

		private Result<bool> _003Cresult_003E5__1;

		private Result<bool> _003C_003Es__2;

		private TaskAwaiter<Result<bool>> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0145: Unknown result type (might be due to invalid IL or missing references)
			//IL_014a: Unknown result type (might be due to invalid IL or missing references)
			//IL_017b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0180: Unknown result type (might be due to invalid IL or missing references)
			//IL_0188: Unknown result type (might be due to invalid IL or missing references)
			//IL_015f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0161: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter<Result<bool>> awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Result<bool>>);
					num = (_003C_003E1__state = -1);
					goto IL_009e;
				}
				TaskAwaiter awaiter2;
				if (num == 1)
				{
					awaiter2 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0197;
				}
				if (request != null)
				{
					awaiter = _003C_003E4__this._declineFriendRequestUseCase.ExecuteAsync(new DeclineFriendRequestRequest(request.NotificationId)).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CDeclineFriendRequest_003Ed__90 _003CDeclineFriendRequest_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<bool>>, _003CDeclineFriendRequest_003Ed__90>(ref awaiter, ref _003CDeclineFriendRequest_003Ed__);
						return;
					}
					goto IL_009e;
				}
				goto end_IL_0007;
				IL_0197:
				((TaskAwaiter)(ref awaiter2)).GetResult();
				goto end_IL_0007;
				IL_009e:
				_003C_003Es__2 = awaiter.GetResult();
				_003Cresult_003E5__1 = _003C_003Es__2;
				_003C_003Es__2 = null;
				if (_003Cresult_003E5__1.Success)
				{
					((Collection<FriendRequestModel>)(object)_003C_003E4__this.FriendRequests).Remove(request);
					_003C_003E4__this.HasFriendRequests = ((Collection<FriendRequestModel>)(object)_003C_003E4__this.FriendRequests).Count > 0;
					_003C_003E4__this._chatUnreadService.SetFriendRequestCount(((Collection<FriendRequestModel>)(object)_003C_003E4__this.FriendRequests).Count);
					awaiter2 = _003C_003E4__this._notificationListener.MarkAsAnswearedAsync(request.NotificationId).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter2;
						_003CDeclineFriendRequest_003Ed__90 _003CDeclineFriendRequest_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CDeclineFriendRequest_003Ed__90>(ref awaiter2, ref _003CDeclineFriendRequest_003Ed__);
						return;
					}
					goto IL_0197;
				}
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cresult_003E5__1 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cresult_003E5__1 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CFight_003Ed__93 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public ChatPlayerModel player;

		public ChatViewModel _003C_003E4__this;

		private bool _003Cis3v3_003E5__1;

		private ValueTuple<bool, string> _003CvalidationResult_003E5__2;

		private Result<BattleLaunchRequest> _003CbattleRequest_003E5__3;

		private BattleResultDTO _003CbattleResult_003E5__4;

		private bool _003C_003Es__5;

		private Result<BattleLaunchRequest> _003C_003Es__6;

		private BattleResultDTO _003C_003Es__7;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private TaskAwaiter<Result<BattleLaunchRequest>> _003C_003Eu__3;

		private TaskAwaiter<BattleResultDTO> _003C_003Eu__4;

		private void MoveNext()
		{
			//IL_0528: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_019b: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_020d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0212: Unknown result type (might be due to invalid IL or missing references)
			//IL_021a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0290: Unknown result type (might be due to invalid IL or missing references)
			//IL_0295: Unknown result type (might be due to invalid IL or missing references)
			//IL_029d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0356: Unknown result type (might be due to invalid IL or missing references)
			//IL_035b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0363: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0401: Unknown result type (might be due to invalid IL or missing references)
			//IL_0466: Unknown result type (might be due to invalid IL or missing references)
			//IL_046b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0473: Unknown result type (might be due to invalid IL or missing references)
			//IL_04f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_04f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0120: Unknown result type (might be due to invalid IL or missing references)
			//IL_0125: Unknown result type (might be due to invalid IL or missing references)
			//IL_0257: Unknown result type (might be due to invalid IL or missing references)
			//IL_025c: Unknown result type (might be due to invalid IL or missing references)
			//IL_042d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0432: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_04be: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0162: Unknown result type (might be due to invalid IL or missing references)
			//IL_0167: Unknown result type (might be due to invalid IL or missing references)
			//IL_055a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0271: Unknown result type (might be due to invalid IL or missing references)
			//IL_0273: Unknown result type (might be due to invalid IL or missing references)
			//IL_0447: Unknown result type (might be due to invalid IL or missing references)
			//IL_0449: Unknown result type (might be due to invalid IL or missing references)
			//IL_04d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_04d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_017c: Unknown result type (might be due to invalid IL or missing references)
			//IL_017e: Unknown result type (might be due to invalid IL or missing references)
			//IL_031d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0322: Unknown result type (might be due to invalid IL or missing references)
			//IL_03bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0337: Unknown result type (might be due to invalid IL or missing references)
			//IL_0339: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d7: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter<bool> awaiter8;
				TaskAwaiter awaiter7;
				TaskAwaiter awaiter6;
				TaskAwaiter<Result<BattleLaunchRequest>> awaiter5;
				TaskAwaiter awaiter4;
				TaskAwaiter awaiter3;
				TaskAwaiter<BattleResultDTO> awaiter2;
				TaskAwaiter awaiter;
				switch (num)
				{
				default:
					if (_003C_003E4__this._navigationService.CanNavigate())
					{
						awaiter8 = _003C_003E4__this._navigationService.ShowConfirmationAsync("Friend Battle " + player.PlayerName, "Please select which mode!", "3v3", "1v1").GetAwaiter();
						if (!awaiter8.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter8;
							_003CFight_003Ed__93 _003CFight_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CFight_003Ed__93>(ref awaiter8, ref _003CFight_003Ed__);
							return;
						}
						goto IL_00fa;
					}
					goto end_IL_0007;
				case 0:
					awaiter8 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
					goto IL_00fa;
				case 1:
					awaiter7 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_01b7;
				case 2:
					awaiter6 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0229;
				case 3:
					awaiter5 = _003C_003Eu__3;
					_003C_003Eu__3 = default(TaskAwaiter<Result<BattleLaunchRequest>>);
					num = (_003C_003E1__state = -1);
					goto IL_02ac;
				case 4:
					awaiter4 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0372;
				case 5:
					awaiter3 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0410;
				case 6:
					awaiter2 = _003C_003Eu__4;
					_003C_003Eu__4 = default(TaskAwaiter<BattleResultDTO>);
					num = (_003C_003E1__state = -1);
					goto IL_0482;
				case 7:
					{
						awaiter = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_0372:
					((TaskAwaiter)(ref awaiter4)).GetResult();
					goto end_IL_0007;
					IL_0229:
					((TaskAwaiter)(ref awaiter6)).GetResult();
					awaiter5 = _003C_003E4__this._startFriendBattle.ExecuteAsync(new StartFriendBattleRequest(player.PlayerId, _003Cis3v3_003E5__1)).GetAwaiter();
					if (!awaiter5.IsCompleted)
					{
						num = (_003C_003E1__state = 3);
						_003C_003Eu__3 = awaiter5;
						_003CFight_003Ed__93 _003CFight_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<BattleLaunchRequest>>, _003CFight_003Ed__93>(ref awaiter5, ref _003CFight_003Ed__);
						return;
					}
					goto IL_02ac;
					IL_00fa:
					_003C_003Es__5 = awaiter8.GetResult();
					_003Cis3v3_003E5__1 = _003C_003Es__5;
					_003CvalidationResult_003E5__2 = _003C_003E4__this.ValidateBattlePreconditions(_003Cis3v3_003E5__1);
					if (!_003CvalidationResult_003E5__2.Item1)
					{
						awaiter7 = _003C_003E4__this._navigationService.ShowAlertAsync("Cannot Start Battle", _003CvalidationResult_003E5__2.Item2).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter7)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter7;
							_003CFight_003Ed__93 _003CFight_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CFight_003Ed__93>(ref awaiter7, ref _003CFight_003Ed__);
							return;
						}
						goto IL_01b7;
					}
					awaiter6 = _003C_003E4__this._playerState.EnsureSyncedAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter6)).IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__2 = awaiter6;
						_003CFight_003Ed__93 _003CFight_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CFight_003Ed__93>(ref awaiter6, ref _003CFight_003Ed__);
						return;
					}
					goto IL_0229;
					IL_0482:
					_003C_003Es__7 = awaiter2.GetResult();
					_003CbattleResult_003E5__4 = _003C_003Es__7;
					_003C_003Es__7 = null;
					awaiter = _003C_003E4__this.ProcessBattleResults(_003CbattleResult_003E5__4, player).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 7);
						_003C_003Eu__2 = awaiter;
						_003CFight_003Ed__93 _003CFight_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CFight_003Ed__93>(ref awaiter, ref _003CFight_003Ed__);
						return;
					}
					break;
					IL_0410:
					((TaskAwaiter)(ref awaiter3)).GetResult();
					awaiter2 = _003CbattleRequest_003E5__3.Data.CompletionSource.Task.GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						num = (_003C_003E1__state = 6);
						_003C_003Eu__4 = awaiter2;
						_003CFight_003Ed__93 _003CFight_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<BattleResultDTO>, _003CFight_003Ed__93>(ref awaiter2, ref _003CFight_003Ed__);
						return;
					}
					goto IL_0482;
					IL_01b7:
					((TaskAwaiter)(ref awaiter7)).GetResult();
					goto end_IL_0007;
					IL_02ac:
					_003C_003Es__6 = awaiter5.GetResult();
					_003CbattleRequest_003E5__3 = _003C_003Es__6;
					_003C_003Es__6 = null;
					if (!_003CbattleRequest_003E5__3.Success || _003CbattleRequest_003E5__3.Data == null)
					{
						awaiter4 = _003C_003E4__this._navigationService.ShowAlertAsync("Could not start friend battle", _003CbattleRequest_003E5__3.ErrorMessage ?? "").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
						{
							num = (_003C_003E1__state = 4);
							_003C_003Eu__2 = awaiter4;
							_003CFight_003Ed__93 _003CFight_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CFight_003Ed__93>(ref awaiter4, ref _003CFight_003Ed__);
							return;
						}
						goto IL_0372;
					}
					awaiter3 = _003C_003E4__this._navigationService.NavigateToBattleViewAsync(_003C_003E4__this._playerState?.CurrentRoute + "/battleground", _003CbattleRequest_003E5__3.Data).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
					{
						num = (_003C_003E1__state = 5);
						_003C_003Eu__2 = awaiter3;
						_003CFight_003Ed__93 _003CFight_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CFight_003Ed__93>(ref awaiter3, ref _003CFight_003Ed__);
						return;
					}
					goto IL_0410;
				}
				((TaskAwaiter)(ref awaiter)).GetResult();
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003CvalidationResult_003E5__2 = default(ValueTuple<bool, string>);
				_003CbattleRequest_003E5__3 = null;
				_003CbattleResult_003E5__4 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CvalidationResult_003E5__2 = default(ValueTuple<bool, string>);
			_003CbattleRequest_003E5__3 = null;
			_003CbattleResult_003E5__4 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGoBack_003Ed__98 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public ChatViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0106: Unknown result type (might be due to invalid IL or missing references)
			//IL_0108: Unknown result type (might be due to invalid IL or missing references)
			//IL_0122: Unknown result type (might be due to invalid IL or missing references)
			//IL_0127: Unknown result type (might be due to invalid IL or missing references)
			//IL_012f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					if (num == 1)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_013e;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter awaiter2;
					if (num != 0)
					{
						awaiter2 = _003C_003E4__this._navigationService.GoBackAsync().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CGoBack_003Ed__98 _003CGoBack_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoBack_003Ed__98>(ref awaiter2, ref _003CGoBack_003Ed__);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
					}
					((TaskAwaiter)(ref awaiter2)).GetResult();
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
				}
				int num2 = _003C_003Es__2;
				if (num2 != 1)
				{
					goto IL_0150;
				}
				_003Cex_003E5__3 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Navigation error", _003Cex_003E5__3.Message).GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = awaiter;
					_003CGoBack_003Ed__98 _003CGoBack_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoBack_003Ed__98>(ref awaiter, ref _003CGoBack_003Ed__);
					return;
				}
				goto IL_013e;
				IL_013e:
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003Cex_003E5__3 = null;
				goto IL_0150;
				IL_0150:
				_003C_003Es__1 = null;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
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

	[CompilerGenerated]
	private sealed class _003CLoadDMThreadsAsync_003Ed__71 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string playerId;

		public ChatViewModel _003C_003E4__this;

		private _003C_003Ec__DisplayClass71_0 _003C_003E8__1;

		private List<Conversation> _003Cconversations_003E5__2;

		private Dictionary<string, Conversation> _003CconvByFriend_003E5__3;

		private int _003CtotalUnread_003E5__4;

		private List<DMThreadModel> _003Cthreads_003E5__5;

		private List<Conversation> _003C_003Es__6;

		private Enumerator<string, Conversation> _003C_003Es__7;

		private _003C_003Ec__DisplayClass71_1 _003C_003E8__8;

		private Conversation _003Cconv_003E5__9;

		private ChatPlayerModel _003Cfriend_003E5__10;

		private global::System.DateTime _003ClastViewed_003E5__11;

		private DateTimeOffset _003ClastViewedOffset_003E5__12;

		private bool _003ChasUnread_003E5__13;

		private global::System.Exception _003Cex_003E5__14;

		private TaskAwaiter<List<Conversation>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_0188: Unknown result type (might be due to invalid IL or missing references)
			//IL_018d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_024c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0240: Unknown result type (might be due to invalid IL or missing references)
			//IL_0245: Unknown result type (might be due to invalid IL or missing references)
			//IL_03fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0251: Unknown result type (might be due to invalid IL or missing references)
			//IL_025d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0263: Unknown result type (might be due to invalid IL or missing references)
			//IL_0292: Unknown result type (might be due to invalid IL or missing references)
			//IL_0297: Unknown result type (might be due to invalid IL or missing references)
			//IL_0373: Unknown result type (might be due to invalid IL or missing references)
			//IL_036c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0397: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num != 0)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass71_0();
					_003C_003E8__1.playerId = playerId;
				}
				try
				{
					TaskAwaiter<List<Conversation>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this._chatRepository.GetPlayerConversationsAsync(_003C_003E8__1.playerId).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CLoadDMThreadsAsync_003Ed__71 _003CLoadDMThreadsAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<List<Conversation>>, _003CLoadDMThreadsAsync_003Ed__71>(ref awaiter, ref _003CLoadDMThreadsAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<List<Conversation>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__6 = awaiter.GetResult();
					_003Cconversations_003E5__2 = _003C_003Es__6;
					_003C_003Es__6 = null;
					_003CconvByFriend_003E5__3 = Enumerable.ToDictionary(Enumerable.Where(Enumerable.Select(Enumerable.Where<Conversation>((global::System.Collections.Generic.IEnumerable<Conversation>)_003Cconversations_003E5__2, (Func<Conversation, bool>)((Conversation c) => c.Type == "dm")), (Conversation c) => new
					{
						FriendId = Enumerable.FirstOrDefault<string>((global::System.Collections.Generic.IEnumerable<string>)c.ParticipantIds, (Func<string, bool>)((string id) => id != _003C_003E8__1.playerId)),
						Conv = c
					}), x => x.FriendId != null), x => x.FriendId, x => x.Conv);
					_003CtotalUnread_003E5__4 = 0;
					_003Cthreads_003E5__5 = new List<DMThreadModel>();
					_003C_003Es__7 = _003CconvByFriend_003E5__3.GetEnumerator();
					try
					{
						string friendId = default(string);
						Conversation conversation = default(Conversation);
						while (_003C_003Es__7.MoveNext())
						{
							_003C_003E8__8 = new _003C_003Ec__DisplayClass71_1();
							_003C_003Es__7.Current.Deconstruct(ref friendId, ref conversation);
							_003C_003E8__8.friendId = friendId;
							_003Cconv_003E5__9 = conversation;
							_003Cfriend_003E5__10 = Enumerable.FirstOrDefault<ChatPlayerModel>((global::System.Collections.Generic.IEnumerable<ChatPlayerModel>)_003C_003E4__this.Friends, (Func<ChatPlayerModel, bool>)((ChatPlayerModel f) => f.PlayerId == _003C_003E8__8.friendId));
							_003ClastViewed_003E5__11 = _003C_003E4__this._preferences.Get("lastDMViewed_" + _003Cconv_003E5__9.Id, global::System.DateTime.MinValue);
							_003ClastViewedOffset_003E5__12 = (DateTimeOffset)((_003ClastViewed_003E5__11 == global::System.DateTime.MinValue) ? DateTimeOffset.MinValue : new DateTimeOffset(_003ClastViewed_003E5__11, TimeSpan.Zero));
							_003ChasUnread_003E5__13 = _003Cconv_003E5__9.LastMessageAt > _003ClastViewedOffset_003E5__12 && _003Cconv_003E5__9.LastMessageSenderId != _003C_003E8__1.playerId && _003Cconv_003E5__9.LastMessageAt > DateTimeOffset.MinValue;
							if (_003ChasUnread_003E5__13)
							{
								_003CtotalUnread_003E5__4++;
							}
							if (_003Cfriend_003E5__10 != null)
							{
								_003Cfriend_003E5__10.UnreadCount = (_003ChasUnread_003E5__13 ? 1 : 0);
							}
							_003Cthreads_003E5__5.Add(new DMThreadModel
							{
								ConversationId = _003Cconv_003E5__9.Id,
								PlayerId = _003C_003E8__8.friendId,
								PlayerName = (_003Cfriend_003E5__10?.PlayerName ?? "Unknown"),
								Icon = (_003Cfriend_003E5__10?.PlayerIcon ?? string.Empty),
								LastOnlineAt = (_003Cfriend_003E5__10?.LastOnlineAt ?? DateTimeOffset.MinValue),
								LastMessagePreviewText = _003Cconv_003E5__9.LastMessageText,
								LastMessageAt = _003Cconv_003E5__9.LastMessageAt,
								IsRead = !_003ChasUnread_003E5__13
							});
							_003Cfriend_003E5__10 = null;
							_003C_003E8__8 = null;
							_003Cconv_003E5__9 = null;
						}
					}
					finally
					{
						if (num < 0)
						{
							((global::System.IDisposable)_003C_003Es__7).Dispose();
						}
					}
					_003C_003Es__7 = default(Enumerator<string, Conversation>);
					_003C_003E4__this.DMThreads = new ObservableCollection<DMThreadModel>((global::System.Collections.Generic.IEnumerable<DMThreadModel>)Enumerable.OrderByDescending<DMThreadModel, DateTimeOffset>((global::System.Collections.Generic.IEnumerable<DMThreadModel>)_003Cthreads_003E5__5, (Func<DMThreadModel, DateTimeOffset>)((DMThreadModel t) => t.LastMessageAt)));
					_003C_003E4__this.HasDMs = ((Collection<DMThreadModel>)(object)_003C_003E4__this.DMThreads).Count > 0;
					_003C_003E4__this._chatUnreadService.SetUnreadDMCount(_003CtotalUnread_003E5__4);
					_003Cconversations_003E5__2 = null;
					_003CconvByFriend_003E5__3 = null;
					_003Cthreads_003E5__5 = null;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__14 = ex;
					Console.WriteLine("LoadDMThreadsAsync error: " + _003Cex_003E5__14.Message);
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CLoadDataAsync_003Ed__68 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public object parameter;

		public ChatViewModel _003C_003E4__this;

		private global::System.Exception _003Cex_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num > 1u)
				{
				}
				try
				{
					TaskAwaiter awaiter;
					TaskAwaiter awaiter2;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0108;
						}
						_003C_003E4__this.IsLoading = true;
						awaiter2 = _003C_003E4__this.LoadInboxAsync().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CLoadDataAsync_003Ed__68 _003CLoadDataAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__68>(ref awaiter2, ref _003CLoadDataAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
					}
					((TaskAwaiter)(ref awaiter2)).GetResult();
					if (!_003C_003E4__this._isCached)
					{
						awaiter = _003C_003E4__this.LoadPartnerSpirit().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter;
							_003CLoadDataAsync_003Ed__68 _003CLoadDataAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__68>(ref awaiter, ref _003CLoadDataAsync_003Ed__);
							return;
						}
						goto IL_0108;
					}
					goto end_IL_0011;
					IL_0108:
					((TaskAwaiter)(ref awaiter)).GetResult();
					end_IL_0011:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__1 = ex;
					Console.WriteLine("Error loading chat data: " + _003Cex_003E5__1.Message);
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this.IsLoading = false;
					}
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

	[CompilerGenerated]
	private sealed class _003CLoadGuildThreadsAsync_003Ed__73 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public ChatViewModel _003C_003E4__this;

		private Player _003CcurrentPlayer_003E5__1;

		private string _003CguildId_003E5__2;

		private List<Conversation> _003Ccached_003E5__3;

		private List<Conversation> _003Cthreads_003E5__4;

		private List<Conversation> _003C_003Es__5;

		private global::System.Exception _003Cex_003E5__6;

		private TaskAwaiter<List<Conversation>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0146: Unknown result type (might be due to invalid IL or missing references)
			//IL_014b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0152: Unknown result type (might be due to invalid IL or missing references)
			//IL_010e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0113: Unknown result type (might be due to invalid IL or missing references)
			//IL_0127: Unknown result type (might be due to invalid IL or missing references)
			//IL_0128: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num == 0)
				{
					goto IL_00ee;
				}
				_003CcurrentPlayer_003E5__1 = _003C_003E4__this._playerState.GetCurrentPlayer();
				_003C_003E4__this.HasGuild = _003CcurrentPlayer_003E5__1 != null && !string.IsNullOrEmpty(_003CcurrentPlayer_003E5__1.GuildId);
				if (_003C_003E4__this.HasGuild)
				{
					_003CguildId_003E5__2 = _003CcurrentPlayer_003E5__1.GuildId;
					_003Ccached_003E5__3 = _003C_003E4__this._guildChatCache.GetThreadList(_003CguildId_003E5__2);
					if (_003Ccached_003E5__3 == null)
					{
						_003C_003E4__this.IsLoadingGuildThreads = true;
						goto IL_00ee;
					}
					_003C_003E4__this.GuildThreads = new ObservableCollection<GuildThreadModel>(Enumerable.Select<Conversation, GuildThreadModel>((global::System.Collections.Generic.IEnumerable<Conversation>)_003Ccached_003E5__3, (Func<Conversation, GuildThreadModel>)MapToThreadModel));
				}
				goto end_IL_0007;
				IL_00ee:
				try
				{
					TaskAwaiter<List<Conversation>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this._chatRepository.GetGuildThreadsAsync(_003CguildId_003E5__2).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CLoadGuildThreadsAsync_003Ed__73 _003CLoadGuildThreadsAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<List<Conversation>>, _003CLoadGuildThreadsAsync_003Ed__73>(ref awaiter, ref _003CLoadGuildThreadsAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<List<Conversation>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__5 = awaiter.GetResult();
					_003Cthreads_003E5__4 = _003C_003Es__5;
					_003C_003Es__5 = null;
					_003C_003E4__this._guildChatCache.SetThreadList(_003CguildId_003E5__2, _003Cthreads_003E5__4);
					_003C_003E4__this.GuildThreads = new ObservableCollection<GuildThreadModel>(Enumerable.Select<Conversation, GuildThreadModel>((global::System.Collections.Generic.IEnumerable<Conversation>)_003Cthreads_003E5__4, (Func<Conversation, GuildThreadModel>)MapToThreadModel));
					_003Cthreads_003E5__4 = null;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__6 = ex;
					Console.WriteLine("LoadGuildThreadsAsync error: " + _003Cex_003E5__6.Message);
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this.IsLoadingGuildThreads = false;
					}
				}
				end_IL_0007:;
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003CcurrentPlayer_003E5__1 = null;
				_003CguildId_003E5__2 = null;
				_003Ccached_003E5__3 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003CcurrentPlayer_003E5__1 = null;
			_003CguildId_003E5__2 = null;
			_003Ccached_003E5__3 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CLoadInboxAsync_003Ed__70 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public ChatViewModel _003C_003E4__this;

		private Result<List<Friend>> _003CfriendsResult_003E5__1;

		private string _003CplayerId_003E5__2;

		private Result<List<Friend>> _003C_003Es__3;

		private Dictionary<string, ValueTuple<DateTimeOffset?, string?>> _003Cpresences_003E5__4;

		private Dictionary<string, ValueTuple<DateTimeOffset?, string?>> _003C_003Es__5;

		private global::System.Collections.Generic.IEnumerator<ChatPlayerModel> _003C_003Es__6;

		private ChatPlayerModel _003Cfriend_003E5__7;

		private ValueTuple<DateTimeOffset?, string?> _003Cdata_003E5__8;

		private List<PlayerNotificationDTO> _003Cnotifications_003E5__9;

		private List<FriendRequestModel> _003Crequests_003E5__10;

		private List<PlayerNotificationDTO> _003C_003Es__11;

		private global::System.Exception _003Cex_003E5__12;

		private TaskAwaiter<Result<List<Friend>>> _003C_003Eu__1;

		private TaskAwaiter<Dictionary<string, ValueTuple<DateTimeOffset?, string?>>> _003C_003Eu__2;

		private TaskAwaiter<List<PlayerNotificationDTO>> _003C_003Eu__3;

		private TaskAwaiter _003C_003Eu__4;

		private void MoveNext()
		{
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_039f: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_04be: Unknown result type (might be due to invalid IL or missing references)
			//IL_04c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_0480: Unknown result type (might be due to invalid IL or missing references)
			//IL_0485: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_049a: Unknown result type (might be due to invalid IL or missing references)
			//IL_049c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0366: Unknown result type (might be due to invalid IL or missing references)
			//IL_036b: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_0296: Unknown result type (might be due to invalid IL or missing references)
			//IL_0380: Unknown result type (might be due to invalid IL or missing references)
			//IL_0382: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num > 3u)
				{
					_003C_003E4__this.IsLoading = true;
				}
				try
				{
					TaskAwaiter<Result<List<Friend>>> awaiter4;
					TaskAwaiter<Dictionary<string, ValueTuple<DateTimeOffset?, string>>> awaiter3;
					TaskAwaiter<List<PlayerNotificationDTO>> awaiter2;
					TaskAwaiter awaiter;
					object obj = default(object);
					switch (num)
					{
					default:
						awaiter4 = _003C_003E4__this._getFriendsUseCase.ExecuteAsync().GetAwaiter();
						if (!awaiter4.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter4;
							_003CLoadInboxAsync_003Ed__70 _003CLoadInboxAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<List<Friend>>>, _003CLoadInboxAsync_003Ed__70>(ref awaiter4, ref _003CLoadInboxAsync_003Ed__);
							return;
						}
						goto IL_00aa;
					case 0:
						awaiter4 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Result<List<Friend>>>);
						num = (_003C_003E1__state = -1);
						goto IL_00aa;
					case 1:
						awaiter3 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<Dictionary<string, ValueTuple<DateTimeOffset?, string>>>);
						num = (_003C_003E1__state = -1);
						goto IL_01fe;
					case 2:
						awaiter2 = _003C_003Eu__3;
						_003C_003Eu__3 = default(TaskAwaiter<List<PlayerNotificationDTO>>);
						num = (_003C_003E1__state = -1);
						goto IL_03bb;
					case 3:
						{
							awaiter = _003C_003Eu__4;
							_003C_003Eu__4 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_04d5;
						}
						IL_04d5:
						((TaskAwaiter)(ref awaiter)).GetResult();
						_003Cnotifications_003E5__9 = null;
						_003Crequests_003E5__10 = null;
						break;
						IL_00aa:
						_003C_003Es__3 = awaiter4.GetResult();
						_003CfriendsResult_003E5__1 = _003C_003Es__3;
						_003C_003Es__3 = null;
						if (_003CfriendsResult_003E5__1.Success && _003CfriendsResult_003E5__1.Data != null)
						{
							_003C_003E4__this.Friends = new ObservableCollection<ChatPlayerModel>(Enumerable.Select<Friend, ChatPlayerModel>((global::System.Collections.Generic.IEnumerable<Friend>)_003CfriendsResult_003E5__1.Data, (Func<Friend, ChatPlayerModel>)((Friend f) => new ChatPlayerModel
							{
								PlayerId = f.FriendId,
								PlayerName = f.FriendName,
								AddedAt = f.AddedAt
							})));
						}
						_003C_003E4__this.HasFriends = ((Collection<ChatPlayerModel>)(object)_003C_003E4__this.Friends).Count > 0;
						if (((Collection<ChatPlayerModel>)(object)_003C_003E4__this.Friends).Count > 0)
						{
							awaiter3 = _003C_003E4__this._playerRepository.GetFriendPresencesAsync(Enumerable.Select<ChatPlayerModel, string>((global::System.Collections.Generic.IEnumerable<ChatPlayerModel>)_003C_003E4__this.Friends, (Func<ChatPlayerModel, string>)((ChatPlayerModel f) => f.PlayerId))).GetAwaiter();
							if (!awaiter3.IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__2 = awaiter3;
								_003CLoadInboxAsync_003Ed__70 _003CLoadInboxAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Dictionary<string, ValueTuple<DateTimeOffset?, string>>>, _003CLoadInboxAsync_003Ed__70>(ref awaiter3, ref _003CLoadInboxAsync_003Ed__);
								return;
							}
							goto IL_01fe;
						}
						goto IL_0320;
						IL_01fe:
						_003C_003Es__5 = awaiter3.GetResult();
						_003Cpresences_003E5__4 = _003C_003Es__5;
						_003C_003Es__5 = null;
						_003C_003Es__6 = ((Collection<ChatPlayerModel>)(object)_003C_003E4__this.Friends).GetEnumerator();
						try
						{
							while (((global::System.Collections.IEnumerator)_003C_003Es__6).MoveNext())
							{
								_003Cfriend_003E5__7 = _003C_003Es__6.Current;
								if (_003Cpresences_003E5__4.TryGetValue(_003Cfriend_003E5__7.PlayerId, ref _003Cdata_003E5__8))
								{
									if (_003Cdata_003E5__8.Item1.HasValue)
									{
										_003Cfriend_003E5__7.LastOnlineAt = _003Cdata_003E5__8.Item1.Value;
									}
									if (!string.IsNullOrEmpty(_003Cdata_003E5__8.Item2))
									{
										_003Cfriend_003E5__7.PlayerIcon = _003Cdata_003E5__8.Item2;
									}
								}
								_003Cdata_003E5__8 = default(ValueTuple<DateTimeOffset?, string>);
								_003Cfriend_003E5__7 = null;
							}
						}
						finally
						{
							if (num < 0 && _003C_003Es__6 != null)
							{
								((global::System.IDisposable)_003C_003Es__6).Dispose();
							}
						}
						_003C_003Es__6 = null;
						_003Cpresences_003E5__4 = null;
						goto IL_0320;
						IL_0320:
						_003CplayerId_003E5__2 = _003C_003E4__this._playerState.CurrentPlayerId;
						if (string.IsNullOrEmpty(_003CplayerId_003E5__2))
						{
							break;
						}
						awaiter2 = _003C_003E4__this._notificationListener.GetUnAnswearedNotificationsAsync(_003CplayerId_003E5__2).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__3 = awaiter2;
							_003CLoadInboxAsync_003Ed__70 _003CLoadInboxAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<List<PlayerNotificationDTO>>, _003CLoadInboxAsync_003Ed__70>(ref awaiter2, ref _003CLoadInboxAsync_003Ed__);
							return;
						}
						goto IL_03bb;
						IL_03bb:
						_003C_003Es__11 = awaiter2.GetResult();
						_003Cnotifications_003E5__9 = _003C_003Es__11;
						_003C_003Es__11 = null;
						_003Crequests_003E5__10 = Enumerable.ToList<FriendRequestModel>(Enumerable.Select<PlayerNotificationDTO, FriendRequestModel>(Enumerable.Where<PlayerNotificationDTO>((global::System.Collections.Generic.IEnumerable<PlayerNotificationDTO>)_003Cnotifications_003E5__9, (Func<PlayerNotificationDTO, bool>)((PlayerNotificationDTO n) => n.Type == NotificationType.FriendRequest)), (Func<PlayerNotificationDTO, FriendRequestModel>)((PlayerNotificationDTO n) => new FriendRequestModel
						{
							NotificationId = n.Id,
							SenderId = ((CollectionExtensions.GetValueOrDefault<string, object>((IReadOnlyDictionary<string, object>)(object)n.Data, "senderId") as string) ?? string.Empty),
							SenderName = ((CollectionExtensions.GetValueOrDefault<string, object>((IReadOnlyDictionary<string, object>)(object)n.Data, "senderName") as string) ?? "Unknown"),
							SenderLevel = ((n.Data.TryGetValue("senderLevel", ref obj) && obj is int num2) ? num2 : 0),
							ReceivedAt = n.CreatedAt
						})));
						_003C_003E4__this.FriendRequests = new ObservableCollection<FriendRequestModel>(Enumerable.DistinctBy<FriendRequestModel, string>((global::System.Collections.Generic.IEnumerable<FriendRequestModel>)_003Crequests_003E5__10, (Func<FriendRequestModel, string>)((FriendRequestModel n) => n.SenderName)));
						awaiter = _003C_003E4__this.LoadDMThreadsAsync(_003CplayerId_003E5__2).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 3);
							_003C_003Eu__4 = awaiter;
							_003CLoadInboxAsync_003Ed__70 _003CLoadInboxAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadInboxAsync_003Ed__70>(ref awaiter, ref _003CLoadInboxAsync_003Ed__);
							return;
						}
						goto IL_04d5;
					}
					_003C_003E4__this.HasFriendRequests = ((Collection<FriendRequestModel>)(object)_003C_003E4__this.FriendRequests).Count > 0;
					_003C_003E4__this._chatUnreadService.SetFriendRequestCount(((Collection<FriendRequestModel>)(object)_003C_003E4__this.FriendRequests).Count);
					_003CfriendsResult_003E5__1 = null;
					_003CplayerId_003E5__2 = null;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__12 = ex;
					Console.WriteLine("LoadInboxAsync error: " + _003Cex_003E5__12.Message);
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this.IsLoading = false;
					}
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

	[CompilerGenerated]
	private sealed class _003CLoadNotificationsAsync_003Ed__79 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public ChatViewModel _003C_003E4__this;

		private _003C_003Ec__DisplayClass79_0 _003C_003E8__1;

		private string _003CplayerId_003E5__2;

		private List<PlayerNotificationDTO> _003Cdtos_003E5__3;

		private List<PlayerNotificationModel> _003Cmodels_003E5__4;

		private List<NotificationGroup> _003Cgroups_003E5__5;

		private List<PlayerNotificationDTO> _003C_003Es__6;

		private global::System.Exception _003Cex_003E5__7;

		private TaskAwaiter<List<PlayerNotificationDTO>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0137: Unknown result type (might be due to invalid IL or missing references)
			//IL_013c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num == 0)
				{
					goto IL_0031;
				}
				if (!_003C_003E4__this._notificationsLoaded)
				{
					_003C_003E4__this.IsNotificationsLoading = true;
					goto IL_0031;
				}
				goto end_IL_0007;
				IL_0031:
				try
				{
					TaskAwaiter<List<PlayerNotificationDTO>> awaiter;
					if (num == 0)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<List<PlayerNotificationDTO>>);
						num = (_003C_003E1__state = -1);
						goto IL_00dc;
					}
					_003C_003E8__1 = new _003C_003Ec__DisplayClass79_0();
					_003CplayerId_003E5__2 = _003C_003E4__this._playerState.CurrentPlayerId;
					if (!string.IsNullOrEmpty(_003CplayerId_003E5__2))
					{
						awaiter = _003C_003E4__this._notificationListener.GetNotificationHistoryAsync(_003CplayerId_003E5__2).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CLoadNotificationsAsync_003Ed__79 _003CLoadNotificationsAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<List<PlayerNotificationDTO>>, _003CLoadNotificationsAsync_003Ed__79>(ref awaiter, ref _003CLoadNotificationsAsync_003Ed__);
							return;
						}
						goto IL_00dc;
					}
					goto end_IL_0031;
					IL_00dc:
					_003C_003Es__6 = awaiter.GetResult();
					_003Cdtos_003E5__3 = _003C_003Es__6;
					_003C_003Es__6 = null;
					_003Cmodels_003E5__4 = Enumerable.ToList<PlayerNotificationModel>(Enumerable.Select<PlayerNotificationDTO, PlayerNotificationModel>((global::System.Collections.Generic.IEnumerable<PlayerNotificationDTO>)_003Cdtos_003E5__3, (Func<PlayerNotificationDTO, PlayerNotificationModel>)((PlayerNotificationDTO n) => new PlayerNotificationModel
					{
						Id = n.Id,
						Type = n.Type,
						Icon = NotificationFormatter.GetIcon(n.Type),
						Title = NotificationFormatter.GetTitle(n.Type),
						Body = NotificationFormatter.GetBody(n.Type, n.Data),
						CreatedAt = n.CreatedAt,
						IsRead = n.Read
					})));
					_003C_003Ec__DisplayClass79_0 _003C_003Ec__DisplayClass79_ = _003C_003E8__1;
					DateTimeOffset now = DateTimeOffset.Now;
					_003C_003Ec__DisplayClass79_.today = ((DateTimeOffset)(ref now)).Date;
					_003C_003E8__1.yesterday = _003C_003E8__1.today.AddDays(-1.0);
					_003Cgroups_003E5__5 = Enumerable.ToList<NotificationGroup>(Enumerable.Select<IGrouping<string, PlayerNotificationModel>, NotificationGroup>((global::System.Collections.Generic.IEnumerable<IGrouping<string, PlayerNotificationModel>>)Enumerable.OrderBy<IGrouping<string, PlayerNotificationModel>, int>(Enumerable.GroupBy<PlayerNotificationModel, string>((global::System.Collections.Generic.IEnumerable<PlayerNotificationModel>)_003Cmodels_003E5__4, (Func<PlayerNotificationModel, string>)delegate(PlayerNotificationModel m)
					{
						//IL_0002: Unknown result type (might be due to invalid IL or missing references)
						//IL_0007: Unknown result type (might be due to invalid IL or missing references)
						//IL_000a: Unknown result type (might be due to invalid IL or missing references)
						//IL_000f: Unknown result type (might be due to invalid IL or missing references)
						DateTimeOffset val = m.CreatedAt;
						val = ((DateTimeOffset)(ref val)).ToLocalTime();
						global::System.DateTime date = ((DateTimeOffset)(ref val)).Date;
						if (date == _003C_003E8__1.today)
						{
							return "Today";
						}
						return (date == _003C_003E8__1.yesterday) ? "Yesterday" : "Older";
					}), (Func<IGrouping<string, PlayerNotificationModel>, int>)((IGrouping<string, PlayerNotificationModel> g) => (!(g.Key == "Today")) ? ((g.Key == "Yesterday") ? 1 : 2) : 0)), (Func<IGrouping<string, PlayerNotificationModel>, NotificationGroup>)((IGrouping<string, PlayerNotificationModel> g) => new NotificationGroup(g.Key, (global::System.Collections.Generic.IEnumerable<PlayerNotificationModel>)g))));
					_003C_003E4__this.NotificationGroups = new ObservableCollection<NotificationGroup>(_003Cgroups_003E5__5);
					_003C_003E4__this.HasNotifications = _003Cmodels_003E5__4.Count > 0;
					_003C_003E4__this._notificationsLoaded = true;
					_003C_003E4__this.UnreadNotificationCount = Enumerable.Count<PlayerNotificationModel>((global::System.Collections.Generic.IEnumerable<PlayerNotificationModel>)_003Cmodels_003E5__4, (Func<PlayerNotificationModel, bool>)((PlayerNotificationModel m) => !m.IsRead));
					_003C_003E4__this._chatUnreadService.SetUnreadNotificationCount(_003C_003E4__this.UnreadNotificationCount);
					_003C_003E8__1 = null;
					_003CplayerId_003E5__2 = null;
					_003Cdtos_003E5__3 = null;
					_003Cmodels_003E5__4 = null;
					_003Cgroups_003E5__5 = null;
					end_IL_0031:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__7 = ex;
					Console.WriteLine("LoadNotificationsAsync error: " + _003Cex_003E5__7.Message);
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this.IsNotificationsLoading = false;
					}
				}
				end_IL_0007:;
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

	[CompilerGenerated]
	private sealed class _003CLoadPartnerSpirit_003Ed__69 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public ChatViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private string _003CpartnerSpiritId_003E5__3;

		private SpiritCardModel _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter<SpiritCardModel> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					if (num == 1)
					{
						awaiter = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0206;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter<SpiritCardModel> awaiter2;
					if (num == 0)
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<SpiritCardModel>);
						num = (_003C_003E1__state = -1);
						goto IL_00fa;
					}
					_003CpartnerSpiritId_003E5__3 = _003C_003E4__this._playerInfoModel?.PartnerSpiritId;
					if (!string.IsNullOrEmpty(_003CpartnerSpiritId_003E5__3))
					{
						if (!string.IsNullOrEmpty(_003C_003E4__this._acquiredPartnerSpiritId))
						{
							_003C_003E4__this._spiritCardModelFactory.ReleaseModel(_003C_003E4__this._acquiredPartnerSpiritId);
						}
						awaiter2 = _003C_003E4__this._spiritCardModelFactory.CreateModelAsync(_003CpartnerSpiritId_003E5__3).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CLoadPartnerSpirit_003Ed__69 _003CLoadPartnerSpirit_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<SpiritCardModel>, _003CLoadPartnerSpirit_003Ed__69>(ref awaiter2, ref _003CLoadPartnerSpirit_003Ed__);
							return;
						}
						goto IL_00fa;
					}
					goto end_IL_0022;
					IL_00fa:
					_003C_003Es__4 = awaiter2.GetResult();
					_003C_003E4__this.PartnerSpiritModel = _003C_003Es__4;
					_003C_003Es__4 = null;
					_003C_003E4__this._acquiredPartnerSpiritId = _003CpartnerSpiritId_003E5__3;
					_003C_003E4__this._isCached = true;
					_003CpartnerSpiritId_003E5__3 = null;
					goto IL_015a;
					end_IL_0022:;
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
					goto IL_015a;
				}
				goto end_IL_0007;
				IL_015a:
				int num2 = _003C_003Es__2;
				if (num2 != 1)
				{
					goto IL_0224;
				}
				_003Cex_003E5__5 = (global::System.Exception)_003C_003Es__1;
				Console.WriteLine("Error loading partner spirit: " + _003Cex_003E5__5.Message);
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error loading partner spirit", "Failed to load partner spirit data.").GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__2 = awaiter;
					_003CLoadPartnerSpirit_003Ed__69 _003CLoadPartnerSpirit_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadPartnerSpirit_003Ed__69>(ref awaiter, ref _003CLoadPartnerSpirit_003Ed__);
					return;
				}
				goto IL_0206;
				IL_0206:
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003C_003E4__this._isCached = false;
				_003Cex_003E5__5 = null;
				goto IL_0224;
				IL_0224:
				_003C_003Es__1 = null;
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
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

	[CompilerGenerated]
	private sealed class _003CNavigateToBattle_003Ed__96 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public ChatViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0169: Unknown result type (might be due to invalid IL or missing references)
			//IL_016e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0183: Unknown result type (might be due to invalid IL or missing references)
			//IL_0185: Unknown result type (might be due to invalid IL or missing references)
			//IL_019f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if ((uint)num > 1u)
				{
					if (num == 2)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_01bb;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter awaiter2;
					TaskAwaiter awaiter3;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter2 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0107;
						}
						awaiter3 = _003C_003E4__this.GoBack().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter3;
							_003CNavigateToBattle_003Ed__96 _003CNavigateToBattle_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToBattle_003Ed__96>(ref awaiter3, ref _003CNavigateToBattle_003Ed__);
							return;
						}
					}
					else
					{
						awaiter3 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
					}
					((TaskAwaiter)(ref awaiter3)).GetResult();
					awaiter2 = _003C_003E4__this._navbarViewModel.NavigateToCommand.ExecuteAsync("//battlehub").GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = awaiter2;
						_003CNavigateToBattle_003Ed__96 _003CNavigateToBattle_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToBattle_003Ed__96>(ref awaiter2, ref _003CNavigateToBattle_003Ed__);
						return;
					}
					goto IL_0107;
					IL_0107:
					((TaskAwaiter)(ref awaiter2)).GetResult();
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
				}
				int num2 = _003C_003Es__2;
				if (num2 != 1)
				{
					goto IL_01cd;
				}
				_003Cex_003E5__3 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Navigation error", _003Cex_003E5__3.Message).GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 2);
					_003C_003Eu__1 = awaiter;
					_003CNavigateToBattle_003Ed__96 _003CNavigateToBattle_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToBattle_003Ed__96>(ref awaiter, ref _003CNavigateToBattle_003Ed__);
					return;
				}
				goto IL_01bb;
				IL_01bb:
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003Cex_003E5__3 = null;
				goto IL_01cd;
				IL_01cd:
				_003C_003Es__1 = null;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
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

	[CompilerGenerated]
	private sealed class _003CNavigateToQuest_003Ed__97 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public ChatViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0169: Unknown result type (might be due to invalid IL or missing references)
			//IL_016e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0183: Unknown result type (might be due to invalid IL or missing references)
			//IL_0185: Unknown result type (might be due to invalid IL or missing references)
			//IL_019f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if ((uint)num > 1u)
				{
					if (num == 2)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_01bb;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter awaiter2;
					TaskAwaiter awaiter3;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter2 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0107;
						}
						awaiter3 = _003C_003E4__this.GoBack().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter3;
							_003CNavigateToQuest_003Ed__97 _003CNavigateToQuest_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToQuest_003Ed__97>(ref awaiter3, ref _003CNavigateToQuest_003Ed__);
							return;
						}
					}
					else
					{
						awaiter3 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
					}
					((TaskAwaiter)(ref awaiter3)).GetResult();
					awaiter2 = _003C_003E4__this._navbarViewModel.NavigateToCommand.ExecuteAsync("//quest").GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = awaiter2;
						_003CNavigateToQuest_003Ed__97 _003CNavigateToQuest_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToQuest_003Ed__97>(ref awaiter2, ref _003CNavigateToQuest_003Ed__);
						return;
					}
					goto IL_0107;
					IL_0107:
					((TaskAwaiter)(ref awaiter2)).GetResult();
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
				}
				int num2 = _003C_003Es__2;
				if (num2 != 1)
				{
					goto IL_01cd;
				}
				_003Cex_003E5__3 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Navigation error", _003Cex_003E5__3.Message).GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 2);
					_003C_003Eu__1 = awaiter;
					_003CNavigateToQuest_003Ed__97 _003CNavigateToQuest_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToQuest_003Ed__97>(ref awaiter, ref _003CNavigateToQuest_003Ed__);
					return;
				}
				goto IL_01bb;
				IL_01bb:
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003Cex_003E5__3 = null;
				goto IL_01cd;
				IL_01cd:
				_003C_003Es__1 = null;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
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

	[CompilerGenerated]
	private sealed class _003CNavigateToSpiritDetails_003Ed__99 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string id;

		public ChatViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_010c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0126: Unknown result type (might be due to invalid IL or missing references)
			//IL_0128: Unknown result type (might be due to invalid IL or missing references)
			//IL_0142: Unknown result type (might be due to invalid IL or missing references)
			//IL_0147: Unknown result type (might be due to invalid IL or missing references)
			//IL_014f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					if (num == 1)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_015e;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter awaiter2;
					if (num != 0)
					{
						awaiter2 = _003C_003E4__this._navigationService.NavigateToAsync(_003C_003E4__this._playerState.CurrentRoute + "/spiritdetails?spiritId=" + id).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CNavigateToSpiritDetails_003Ed__99 _003CNavigateToSpiritDetails_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToSpiritDetails_003Ed__99>(ref awaiter2, ref _003CNavigateToSpiritDetails_003Ed__);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
					}
					((TaskAwaiter)(ref awaiter2)).GetResult();
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
				}
				int num2 = _003C_003Es__2;
				if (num2 != 1)
				{
					goto IL_0170;
				}
				_003Cex_003E5__3 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error navigating to spiritpage", _003Cex_003E5__3.Message).GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = awaiter;
					_003CNavigateToSpiritDetails_003Ed__99 _003CNavigateToSpiritDetails_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToSpiritDetails_003Ed__99>(ref awaiter, ref _003CNavigateToSpiritDetails_003Ed__);
					return;
				}
				goto IL_015e;
				IL_015e:
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003Cex_003E5__3 = null;
				goto IL_0170;
				IL_0170:
				_003C_003Es__1 = null;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
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

	[CompilerGenerated]
	private sealed class _003CNewMessage_003Ed__88 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public ChatViewModel _003C_003E4__this;

		private SelectFriendBottomSheet _003Csheet_003E5__1;

		private SelectFriendSheetViewModel _003Cvm_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0182: Unknown result type (might be due to invalid IL or missing references)
			//IL_0187: Unknown result type (might be due to invalid IL or missing references)
			//IL_018f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0108: Unknown result type (might be due to invalid IL or missing references)
			//IL_0112: Expected O, but got Unknown
			//IL_014c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0151: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			//IL_0166: Unknown result type (might be due to invalid IL or missing references)
			//IL_0168: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_009e;
				}
				TaskAwaiter awaiter2;
				if (num != 1)
				{
					if (((Collection<ChatPlayerModel>)(object)_003C_003E4__this.Friends).Count == 0)
					{
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("No Friends", "Add some friends first to start a conversation!").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CNewMessage_003Ed__88 _003CNewMessage_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNewMessage_003Ed__88>(ref awaiter, ref _003CNewMessage_003Ed__);
							return;
						}
						goto IL_009e;
					}
					_003Csheet_003E5__1 = new SelectFriendBottomSheet();
					_003Cvm_003E5__2 = new SelectFriendSheetViewModel(_003C_003E4__this.Friends, _003C_003E4__this._bottomSheetService);
					((BindableObject)_003Csheet_003E5__1).BindingContext = _003Cvm_003E5__2;
					_003Cvm_003E5__2.SetSheet((BottomSheet)(object)_003Csheet_003E5__1);
					SelectFriendBottomSheet selectFriendBottomSheet = _003Csheet_003E5__1;
					List<Detent> obj = new List<Detent>(1);
					obj.Add((Detent)new FullscreenDetent());
					((BottomSheet)selectFriendBottomSheet).Detents = (global::System.Collections.Generic.IList<Detent>)obj;
					_003Cvm_003E5__2.OnFriendSelected = [CompilerGenerated] (ChatPlayerModel friend) =>
					{
						//IL_001c: Unknown result type (might be due to invalid IL or missing references)
						//IL_0026: Expected O, but got Unknown
						MainThread.BeginInvokeOnMainThread(new Action(new _003C_003Ec__DisplayClass88_0
						{
							_003C_003E4__this = _003C_003E4__this,
							friend = friend
						}._003CNewMessage_003Eb__1));
					};
					awaiter2 = _003C_003E4__this._bottomSheetService.ShowSheetAsync((BottomSheet)(object)_003Csheet_003E5__1).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = awaiter2;
						_003CNewMessage_003Ed__88 _003CNewMessage_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNewMessage_003Ed__88>(ref awaiter2, ref _003CNewMessage_003Ed__);
						return;
					}
				}
				else
				{
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
				}
				((TaskAwaiter)(ref awaiter2)).GetResult();
				goto end_IL_0007;
				IL_009e:
				((TaskAwaiter)(ref awaiter)).GetResult();
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Csheet_003E5__1 = null;
				_003Cvm_003E5__2 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Csheet_003E5__1 = null;
			_003Cvm_003E5__2 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003COpenDM_003Ed__91 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public ChatPlayerModel player;

		public ChatViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00b5;
				}
				if (player != null)
				{
					player.UnreadCount = 0;
					awaiter = _003C_003E4__this._navigationService.NavigateToAsync("//chat/dm?friendId=" + player.PlayerId + "|" + player.PlayerName).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003COpenDM_003Ed__91 _003COpenDM_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COpenDM_003Ed__91>(ref awaiter, ref _003COpenDM_003Ed__);
						return;
					}
					goto IL_00b5;
				}
				goto end_IL_0007;
				IL_00b5:
				((TaskAwaiter)(ref awaiter)).GetResult();
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
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

	[CompilerGenerated]
	private sealed class _003COpenDMThread_003Ed__87 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public DMThreadModel thread;

		public ChatViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00b5;
				}
				if (thread != null)
				{
					thread.IsRead = true;
					awaiter = _003C_003E4__this._navigationService.NavigateToAsync("//chat/dm?friendId=" + thread.PlayerId + "|" + thread.PlayerName).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003COpenDMThread_003Ed__87 _003COpenDMThread_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COpenDMThread_003Ed__87>(ref awaiter, ref _003COpenDMThread_003Ed__);
						return;
					}
					goto IL_00b5;
				}
				goto end_IL_0007;
				IL_00b5:
				((TaskAwaiter)(ref awaiter)).GetResult();
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
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

	[CompilerGenerated]
	private sealed class _003COpenNewThreadSheet_003Ed__75 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public ChatViewModel _003C_003E4__this;

		private NewGuildThreadBottomSheet _003Csheet_003E5__1;

		private NewGuildThreadSheetViewModel _003Cvm_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Expected O, but got Unknown
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					_003Csheet_003E5__1 = new NewGuildThreadBottomSheet();
					_003Cvm_003E5__2 = new NewGuildThreadSheetViewModel(_003C_003E4__this._createGuildThreadUseCase, _003C_003E4__this._playerState, _003C_003E4__this._bottomSheetService);
					((BindableObject)_003Csheet_003E5__1).BindingContext = _003Cvm_003E5__2;
					_003Cvm_003E5__2.SetSheet((BottomSheet)(object)_003Csheet_003E5__1);
					NewGuildThreadBottomSheet newGuildThreadBottomSheet = _003Csheet_003E5__1;
					List<Detent> obj = new List<Detent>(1);
					obj.Add((Detent)new FullscreenDetent());
					((BottomSheet)newGuildThreadBottomSheet).Detents = (global::System.Collections.Generic.IList<Detent>)obj;
					_003Cvm_003E5__2.OnThreadCreated = _003C_003E4__this.OnGuildThreadCreated;
					awaiter = _003C_003E4__this._bottomSheetService.ShowSheetAsync((BottomSheet)(object)_003Csheet_003E5__1).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003COpenNewThreadSheet_003Ed__75 _003COpenNewThreadSheet_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COpenNewThreadSheet_003Ed__75>(ref awaiter, ref _003COpenNewThreadSheet_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
				}
				((TaskAwaiter)(ref awaiter)).GetResult();
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Csheet_003E5__1 = null;
				_003Cvm_003E5__2 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Csheet_003E5__1 = null;
			_003Cvm_003E5__2 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003COpenSpiritsHoldNavigation_003Ed__100 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public ChatViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private BottomSheet _003Csheet_003E5__3;

		private BottomSheet _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter<BottomSheet> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0188: Unknown result type (might be due to invalid IL or missing references)
			//IL_018d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01be: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_010f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if ((uint)num > 1u)
				{
					if (num == 2)
					{
						awaiter = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_01da;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter awaiter2;
					TaskAwaiter<BottomSheet> awaiter3;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter2 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0125;
						}
						awaiter3 = _003C_003E4__this._navigationService.GetFullSheet<SpiritHoldNavigationSheet, SpiritsHoldNavigationSheetViewModel>("spiritholdnav").GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter3;
							_003COpenSpiritsHoldNavigation_003Ed__100 _003COpenSpiritsHoldNavigation_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<BottomSheet>, _003COpenSpiritsHoldNavigation_003Ed__100>(ref awaiter3, ref _003COpenSpiritsHoldNavigation_003Ed__);
							return;
						}
					}
					else
					{
						awaiter3 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<BottomSheet>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__4 = awaiter3.GetResult();
					_003Csheet_003E5__3 = _003C_003Es__4;
					_003C_003Es__4 = null;
					awaiter2 = _003C_003E4__this._bottomSheetService.ShowSheetAsync(_003Csheet_003E5__3).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter2;
						_003COpenSpiritsHoldNavigation_003Ed__100 _003COpenSpiritsHoldNavigation_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COpenSpiritsHoldNavigation_003Ed__100>(ref awaiter2, ref _003COpenSpiritsHoldNavigation_003Ed__);
						return;
					}
					goto IL_0125;
					IL_0125:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					_003Csheet_003E5__3 = null;
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
				}
				int num2 = _003C_003Es__2;
				if (num2 != 1)
				{
					goto IL_01fd;
				}
				_003Cex_003E5__5 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Navigation Error", "Failed to navigate to opponent profile.").GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 2);
					_003C_003Eu__2 = awaiter;
					_003COpenSpiritsHoldNavigation_003Ed__100 _003COpenSpiritsHoldNavigation_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COpenSpiritsHoldNavigation_003Ed__100>(ref awaiter, ref _003COpenSpiritsHoldNavigation_003Ed__);
					return;
				}
				goto IL_01da;
				IL_01da:
				((TaskAwaiter)(ref awaiter)).GetResult();
				Console.WriteLine(_003Cex_003E5__5.Message);
				_003Cex_003E5__5 = null;
				goto IL_01fd;
				IL_01fd:
				_003C_003Es__1 = null;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
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

	[CompilerGenerated]
	private sealed class _003COpenThread_003Ed__74 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildThreadModel thread;

		public ChatViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00a5;
				}
				if (thread != null)
				{
					awaiter = _003C_003E4__this._navigationService.NavigateToAsync("//chat/guildthread?threadId=" + thread.ConversationId + "|" + thread.Subject).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003COpenThread_003Ed__74 _003COpenThread_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COpenThread_003Ed__74>(ref awaiter, ref _003COpenThread_003Ed__);
						return;
					}
					goto IL_00a5;
				}
				goto end_IL_0007;
				IL_00a5:
				((TaskAwaiter)(ref awaiter)).GetResult();
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
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

	[CompilerGenerated]
	private sealed class _003CProcessBattleResults_003Ed__94 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleResultDTO battleResult;

		public ChatPlayerModel opponent;

		public ChatViewModel _003C_003E4__this;

		private global::System.Exception _003Cex_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this.ShowBattleSummary(battleResult, opponent).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CProcessBattleResults_003Ed__94 _003CProcessBattleResults_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CProcessBattleResults_003Ed__94>(ref awaiter, ref _003CProcessBattleResults_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
					}
					((TaskAwaiter)(ref awaiter)).GetResult();
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__1 = ex;
					Console.WriteLine($"Error processing battle results: {_003Cex_003E5__1}");
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

	[CompilerGenerated]
	private sealed class _003CRefresh_003Ed__82 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public ChatViewModel _003C_003E4__this;

		private string _003CguildId_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0170: Unknown result type (might be due to invalid IL or missing references)
			//IL_0175: Unknown result type (might be due to invalid IL or missing references)
			//IL_017d: Unknown result type (might be due to invalid IL or missing references)
			//IL_020a: Unknown result type (might be due to invalid IL or missing references)
			//IL_020f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0217: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0137: Unknown result type (might be due to invalid IL or missing references)
			//IL_013c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0151: Unknown result type (might be due to invalid IL or missing references)
			//IL_0153: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter3;
				TaskAwaiter awaiter2;
				TaskAwaiter awaiter;
				switch (num)
				{
				default:
					if (_003C_003E4__this.CurrentChatTab == "inbox" || _003C_003E4__this.CurrentChatTab == "dm")
					{
						awaiter3 = _003C_003E4__this.LoadInboxAsync().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter3;
							_003CRefresh_003Ed__82 _003CRefresh_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRefresh_003Ed__82>(ref awaiter3, ref _003CRefresh_003Ed__);
							return;
						}
						goto IL_00b8;
					}
					if (_003C_003E4__this.CurrentChatTab == "guild")
					{
						_003CguildId_003E5__1 = _003C_003E4__this._playerState.GetCurrentPlayer()?.GuildId;
						if (_003CguildId_003E5__1 != null)
						{
							_003C_003E4__this._guildChatCache.InvalidateThreadList(_003CguildId_003E5__1);
						}
						awaiter2 = _003C_003E4__this.LoadGuildThreadsAsync().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter2;
							_003CRefresh_003Ed__82 _003CRefresh_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRefresh_003Ed__82>(ref awaiter2, ref _003CRefresh_003Ed__);
							return;
						}
						goto IL_018c;
					}
					if (_003C_003E4__this.CurrentChatTab == "notifications")
					{
						_003C_003E4__this._notificationsLoaded = false;
						awaiter = _003C_003E4__this.LoadNotificationsAsync().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__1 = awaiter;
							_003CRefresh_003Ed__82 _003CRefresh_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRefresh_003Ed__82>(ref awaiter, ref _003CRefresh_003Ed__);
							return;
						}
						break;
					}
					goto end_IL_0007;
				case 0:
					awaiter3 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00b8;
				case 1:
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_018c;
				case 2:
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_00b8:
					((TaskAwaiter)(ref awaiter3)).GetResult();
					goto end_IL_0007;
					IL_018c:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					_003CguildId_003E5__1 = null;
					goto end_IL_0007;
				}
				((TaskAwaiter)(ref awaiter)).GetResult();
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
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

	[CompilerGenerated]
	private sealed class _003CSearchPlayers_003Ed__83 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public ChatViewModel _003C_003E4__this;

		private TaskAwaiter<object?> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter<object> awaiter;
				if (num != 0)
				{
					awaiter = _003C_003E4__this._popupService.ShowPopupAsync<SearchPlayersPopupViewModel>(default(CancellationToken)).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CSearchPlayers_003Ed__83 _003CSearchPlayers_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<object>, _003CSearchPlayers_003Ed__83>(ref awaiter, ref _003CSearchPlayers_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<object>);
					num = (_003C_003E1__state = -1);
				}
				awaiter.GetResult();
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
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

	[CompilerGenerated]
	private sealed class _003CSelectChatTab_003Ed__81 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string tab;

		public ChatViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0122: Unknown result type (might be due to invalid IL or missing references)
			//IL_0127: Unknown result type (might be due to invalid IL or missing references)
			//IL_012f: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00c0;
				}
				TaskAwaiter awaiter2;
				if (num == 1)
				{
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_013e;
				}
				if (!(_003C_003E4__this.CurrentChatTab == tab))
				{
					_003C_003E4__this.CurrentChatTab = tab;
					if (tab == "guild")
					{
						awaiter = _003C_003E4__this.LoadGuildThreadsAsync().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CSelectChatTab_003Ed__81 _003CSelectChatTab_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSelectChatTab_003Ed__81>(ref awaiter, ref _003CSelectChatTab_003Ed__);
							return;
						}
						goto IL_00c0;
					}
					if (tab == "notifications")
					{
						awaiter2 = _003C_003E4__this.LoadNotificationsAsync().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter2;
							_003CSelectChatTab_003Ed__81 _003CSelectChatTab_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSelectChatTab_003Ed__81>(ref awaiter2, ref _003CSelectChatTab_003Ed__);
							return;
						}
						goto IL_013e;
					}
				}
				goto end_IL_0007;
				IL_00c0:
				((TaskAwaiter)(ref awaiter)).GetResult();
				goto end_IL_0007;
				IL_013e:
				((TaskAwaiter)(ref awaiter2)).GetResult();
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
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

	[CompilerGenerated]
	private sealed class _003CShowBattleSummary_003Ed__95 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleResultDTO battleResult;

		public ChatPlayerModel opponent;

		public ChatViewModel _003C_003E4__this;

		private _003C_003Ec__DisplayClass95_0 _003C_003E8__1;

		private TaskAwaiter<object?> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter<object> awaiter;
				if (num != 0)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass95_0();
					_003C_003E8__1.battleResult = battleResult;
					_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
					_003C_003E8__1.opponent = opponent;
					awaiter = _003C_003E4__this._popupService.ShowPopupAsync<BattleSummaryPopupViewModel>((Action<BattleSummaryPopupViewModel>)delegate(BattleSummaryPopupViewModel vm)
					{
						//IL_018f: Unknown result type (might be due to invalid IL or missing references)
						//IL_0174: Unknown result type (might be due to invalid IL or missing references)
						//IL_0199: Expected O, but got Unknown
						vm.PlayerSpirits = Enumerable.ToList<SpriteModelResultsRecord>(Enumerable.Select<SpiritBattleResult, SpriteModelResultsRecord>((global::System.Collections.Generic.IEnumerable<SpiritBattleResult>)_003C_003E8__1.battleResult.PlayerSpirits, (Func<SpiritBattleResult, SpriteModelResultsRecord>)((SpiritBattleResult spirit) => new SpriteModelResultsRecord(spirit.Image, spirit.Fainted ? "x.png" : "check.png", spirit.Fainted ? 0.3 : 1.0))));
						vm.EnemySpirits = Enumerable.ToList<SpriteModelResultsRecord>(Enumerable.Select<SpiritBattleResult, SpriteModelResultsRecord>((global::System.Collections.Generic.IEnumerable<SpiritBattleResult>)_003C_003E8__1.battleResult.EnemySpirits, (Func<SpiritBattleResult, SpriteModelResultsRecord>)((SpiritBattleResult spirit) => new SpriteModelResultsRecord(spirit.Image, spirit.Fainted ? "x.png" : "check.png", spirit.Fainted ? 0.3 : 1.0))));
						vm.OutcomeImagePlayer = (_003C_003E8__1.battleResult.Victory ? "staricon.png" : "x.png");
						vm.OutcomeImageEnemy = ((!_003C_003E8__1.battleResult.Victory) ? "staricon.png" : "x.png");
						vm.OutcomeText = (_003C_003E8__1.battleResult.Victory ? "VICTORY!" : "DEFEAT");
						vm.HasRewards = false;
						vm.PlayerName = _003C_003E8__1._003C_003E4__this._playerState.GetCurrentPlayer()?.Playername ?? "";
						vm.EnemyName = _003C_003E8__1.opponent.PlayerName;
						vm.EnemyRank = _003C_003E8__1.battleResult.OpponentLevel;
						vm.PlayerRank = _003C_003E8__1._003C_003E4__this._playerState.GetCurrentPlayer()?.PlayerLevel ?? 1;
						vm.BackGround = (_003C_003E8__1.battleResult.Victory ? ((Brush)Application.Current.Resources["GradientWinSummary"]) : ((Brush)Application.Current.Resources["GradientLossSummary"]));
						vm.TextColor = (_003C_003E8__1.battleResult.Victory ? Color.FromArgb("#027242") : Color.FromArgb("#721502"));
					}, default(CancellationToken)).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CShowBattleSummary_003Ed__95 _003CShowBattleSummary_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<object>, _003CShowBattleSummary_003Ed__95>(ref awaiter, ref _003CShowBattleSummary_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<object>);
					num = (_003C_003E1__state = -1);
				}
				awaiter.GetResult();
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CShowGuildInvitations_003Ed__86 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public ChatViewModel _003C_003E4__this;

		private TaskAwaiter<object?> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter<object> awaiter;
				if (num != 0)
				{
					awaiter = _003C_003E4__this._popupService.ShowPopupAsync<GuildInvitationsPopupViewModel>(default(CancellationToken)).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CShowGuildInvitations_003Ed__86 _003CShowGuildInvitations_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<object>, _003CShowGuildInvitations_003Ed__86>(ref awaiter, ref _003CShowGuildInvitations_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<object>);
					num = (_003C_003E1__state = -1);
				}
				awaiter.GetResult();
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
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

	[CompilerGenerated]
	private sealed class _003CShowGuildMembers_003Ed__85 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public ChatViewModel _003C_003E4__this;

		private string _003CguildId_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00b7;
				}
				_003CguildId_003E5__1 = _003C_003E4__this._playerState.GetCurrentPlayer()?.GuildId;
				if (!string.IsNullOrEmpty(_003CguildId_003E5__1))
				{
					awaiter = _003C_003E4__this._navigationService.NavigateToAsync("//guild/members?guildId=" + _003CguildId_003E5__1).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CShowGuildMembers_003Ed__85 _003CShowGuildMembers_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CShowGuildMembers_003Ed__85>(ref awaiter, ref _003CShowGuildMembers_003Ed__);
						return;
					}
					goto IL_00b7;
				}
				goto end_IL_0007;
				IL_00b7:
				((TaskAwaiter)(ref awaiter)).GetResult();
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003CguildId_003E5__1 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CguildId_003E5__1 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CTapNotification_003Ed__80 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public PlayerNotificationModel notification;

		public ChatViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00e3;
				}
				if (notification != null && !notification.IsRead)
				{
					notification.IsRead = true;
					_003C_003E4__this.UnreadNotificationCount = Math.Max(0, _003C_003E4__this.UnreadNotificationCount - 1);
					_003C_003E4__this._chatUnreadService.SetUnreadNotificationCount(_003C_003E4__this.UnreadNotificationCount);
					awaiter = _003C_003E4__this._notificationListener.MarkAsReadAsync(notification.Id).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CTapNotification_003Ed__80 _003CTapNotification_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CTapNotification_003Ed__80>(ref awaiter, ref _003CTapNotification_003Ed__);
						return;
					}
					goto IL_00e3;
				}
				goto end_IL_0007;
				IL_00e3:
				((TaskAwaiter)(ref awaiter)).GetResult();
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
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

	private readonly GetFriendsUseCase _getFriendsUseCase;

	private readonly AcceptFriendRequestUseCase _acceptFriendRequestUseCase;

	private readonly DeclineFriendRequestUseCase _declineFriendRequestUseCase;

	private readonly IPlayerNotificationListenerService _notificationListener;

	private readonly IPlayerStateService _playerState;

	private readonly IPopupService _popupService;

	private readonly StartFriendBattleUseCase _startFriendBattle;

	private readonly SpiritCardModelFactory _spiritCardModelFactory;

	private readonly IChatRepository _chatRepository;

	private readonly IGuildStateService _guildState;

	private readonly IGuildChatCacheService _guildChatCache;

	private readonly CreateGuildThreadUseCase _createGuildThreadUseCase;

	private readonly IBottomSheetService _bottomSheetService;

	private readonly INavigationService _navigationService;

	private readonly IPlayerRepository _playerRepository;

	private readonly IChatUnreadService _chatUnreadService;

	private readonly IPreferencesService _preferences;

	private PlayerInfoModel _playerInfoModel;

	private NavBarViewModel _navbarViewModel;

	private string _acquiredPartnerSpiritId;

	[ObservableProperty]
	private SpiritCardModel _partnerSpiritModel;

	[ObservableProperty]
	[NotifyPropertyChangedFor("FriendListToggleLabel")]
	[NotifyPropertyChangedFor("IsInboxTab")]
	private string _currentChatTab = "inbox";

	[ObservableProperty]
	private ObservableCollection<ChatPlayerModel> _friends = new ObservableCollection<ChatPlayerModel>();

	[ObservableProperty]
	private ObservableCollection<FriendRequestModel> _friendRequests = new ObservableCollection<FriendRequestModel>();

	[ObservableProperty]
	private bool _isLoading;

	[ObservableProperty]
	private bool _hasFriends;

	[ObservableProperty]
	private bool _hasFriendRequests;

	[ObservableProperty]
	private ObservableCollection<DMThreadModel> _dMThreads = new ObservableCollection<DMThreadModel>();

	[ObservableProperty]
	private bool _hasDMs;

	[ObservableProperty]
	private string _sortBy = "Default";

	[ObservableProperty]
	private ObservableCollection<GuildThreadModel> _guildThreads = new ObservableCollection<GuildThreadModel>();

	[ObservableProperty]
	private bool _hasGuild;

	[ObservableProperty]
	private bool _isLoadingGuildThreads;

	private bool _isCached = false;

	private ObservableCollection<NotificationGroup> _notificationGroups = new ObservableCollection<NotificationGroup>();

	private bool _isNotificationsLoading;

	private bool _hasNotifications;

	private int _unreadNotificationCount;

	private bool _notificationsLoaded;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<GuildThreadModel>? openThreadCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? openNewThreadSheetCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<PlayerNotificationModel>? tapNotificationCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<string>? selectChatTabCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? refreshCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? searchPlayersCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? toggleFriendListCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? showGuildMembersCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? showGuildInvitationsCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<DMThreadModel>? openDMThreadCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? newMessageCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<FriendRequestModel>? acceptFriendRequestCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<FriendRequestModel>? declineFriendRequestCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<ChatPlayerModel>? openDMCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<ChatPlayerModel>? fightCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? navigateToBattleCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? navigateToQuestCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? goBackCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<string>? navigateToSpiritDetailsCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? openSpiritsHoldNavigationCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<ChatPlayerModel>? moreOptionsCommand;

	public PlayerInfoModel? PlayerInfoModel
	{
		get
		{
			return _playerInfoModel;
		}
		set
		{
			((ObservableObject)this).SetProperty<PlayerInfoModel>(ref _playerInfoModel, value, "PlayerInfoModel");
		}
	}

	public ObservableCollection<NotificationGroup> NotificationGroups
	{
		get
		{
			return _notificationGroups;
		}
		set
		{
			((ObservableObject)this).SetProperty<ObservableCollection<NotificationGroup>>(ref _notificationGroups, value, "NotificationGroups");
		}
	}

	public bool IsNotificationsLoading
	{
		get
		{
			return _isNotificationsLoading;
		}
		set
		{
			((ObservableObject)this).SetProperty<bool>(ref _isNotificationsLoading, value, "IsNotificationsLoading");
		}
	}

	public bool HasNotifications
	{
		get
		{
			return _hasNotifications;
		}
		set
		{
			((ObservableObject)this).SetProperty<bool>(ref _hasNotifications, value, "HasNotifications");
		}
	}

	public int UnreadNotificationCount
	{
		get
		{
			return _unreadNotificationCount;
		}
		set
		{
			if (((ObservableObject)this).SetProperty<int>(ref _unreadNotificationCount, value, "UnreadNotificationCount"))
			{
				((ObservableObject)this).OnPropertyChanged("HasUnreadNotifications");
			}
		}
	}

	public bool HasUnreadNotifications => _unreadNotificationCount > 0;

	public bool HasValidSquad
	{
		get
		{
			IPlayerStateService playerState = _playerState;
			int result;
			if (playerState == null)
			{
				result = 0;
			}
			else
			{
				Player? currentPlayer = playerState.GetCurrentPlayer();
				result = (((currentPlayer != null) ? new bool?(Enumerable.All<string>((global::System.Collections.Generic.IEnumerable<string>)currentPlayer.Squads[_playerState.GetCurrentPlayer()?.ActiveSquadSlot.ToString() ?? "1"], (Func<string, bool>)((string l) => !string.IsNullOrEmpty(l)))) : null).GetValueOrDefault() ? 1 : 0);
			}
			return (byte)result != 0;
		}
	}

	public bool HasEnoughSP
	{
		get
		{
			IPlayerStateService playerState = _playerState;
			return playerState != null && playerState.GetCurrentPlayer()?.SP >= 1;
		}
	}

	public bool IsAccountLinked => (_playerState?.GetCurrentPlayer()?.IsAccountLinked).GetValueOrDefault();

	public string FriendListToggleLabel => (CurrentChatTab == "dm") ? "Messages List" : "Friend List";

	public bool IsInboxTab => CurrentChatTab == "inbox" || CurrentChatTab == "dm";

	public string PartnerSpiritImage => _playerState?.GetSpiritTemplate(_playerState.GetPartnerSpirit()?.BaseSpiritID ?? 0)?.Image ?? "";

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public SpiritCardModel PartnerSpiritModel
	{
		get
		{
			return _partnerSpiritModel;
		}
		[MemberNotNull("_partnerSpiritModel")]
		set
		{
			if (!EqualityComparer<SpiritCardModel>.Default.Equals(_partnerSpiritModel, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.PartnerSpiritModel);
				_partnerSpiritModel = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.PartnerSpiritModel);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string CurrentChatTab
	{
		get
		{
			return _currentChatTab;
		}
		[MemberNotNull("_currentChatTab")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_currentChatTab, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CurrentChatTab);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.FriendListToggleLabel);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsInboxTab);
				_currentChatTab = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CurrentChatTab);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.FriendListToggleLabel);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsInboxTab);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ObservableCollection<ChatPlayerModel> Friends
	{
		get
		{
			return _friends;
		}
		[MemberNotNull("_friends")]
		set
		{
			if (!EqualityComparer<ObservableCollection<ChatPlayerModel>>.Default.Equals(_friends, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Friends);
				_friends = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Friends);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ObservableCollection<FriendRequestModel> FriendRequests
	{
		get
		{
			return _friendRequests;
		}
		[MemberNotNull("_friendRequests")]
		set
		{
			if (!EqualityComparer<ObservableCollection<FriendRequestModel>>.Default.Equals(_friendRequests, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.FriendRequests);
				_friendRequests = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.FriendRequests);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsLoading
	{
		get
		{
			return _isLoading;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isLoading, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsLoading);
				_isLoading = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsLoading);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool HasFriends
	{
		get
		{
			return _hasFriends;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_hasFriends, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HasFriends);
				_hasFriends = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HasFriends);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool HasFriendRequests
	{
		get
		{
			return _hasFriendRequests;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_hasFriendRequests, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HasFriendRequests);
				_hasFriendRequests = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HasFriendRequests);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ObservableCollection<DMThreadModel> DMThreads
	{
		get
		{
			return _dMThreads;
		}
		[MemberNotNull("_dMThreads")]
		set
		{
			if (!EqualityComparer<ObservableCollection<DMThreadModel>>.Default.Equals(_dMThreads, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.DMThreads);
				_dMThreads = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.DMThreads);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool HasDMs
	{
		get
		{
			return _hasDMs;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_hasDMs, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HasDMs);
				_hasDMs = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HasDMs);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string SortBy
	{
		get
		{
			return _sortBy;
		}
		[MemberNotNull("_sortBy")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_sortBy, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.SortBy);
				_sortBy = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SortBy);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ObservableCollection<GuildThreadModel> GuildThreads
	{
		get
		{
			return _guildThreads;
		}
		[MemberNotNull("_guildThreads")]
		set
		{
			if (!EqualityComparer<ObservableCollection<GuildThreadModel>>.Default.Equals(_guildThreads, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.GuildThreads);
				_guildThreads = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.GuildThreads);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool HasGuild
	{
		get
		{
			return _hasGuild;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_hasGuild, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HasGuild);
				_hasGuild = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HasGuild);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsLoadingGuildThreads
	{
		get
		{
			return _isLoadingGuildThreads;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isLoadingGuildThreads, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsLoadingGuildThreads);
				_isLoadingGuildThreads = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsLoadingGuildThreads);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<GuildThreadModel> OpenThreadCommand => (IAsyncRelayCommand<GuildThreadModel>)(object)(openThreadCommand ?? (openThreadCommand = new AsyncRelayCommand<GuildThreadModel>((Func<GuildThreadModel, global::System.Threading.Tasks.Task>)OpenThread)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand OpenNewThreadSheetCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = openNewThreadSheetCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)OpenNewThreadSheet);
				AsyncRelayCommand val2 = val;
				openNewThreadSheetCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<PlayerNotificationModel> TapNotificationCommand => (IAsyncRelayCommand<PlayerNotificationModel>)(object)(tapNotificationCommand ?? (tapNotificationCommand = new AsyncRelayCommand<PlayerNotificationModel>((Func<PlayerNotificationModel, global::System.Threading.Tasks.Task>)TapNotification)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<string> SelectChatTabCommand => (IAsyncRelayCommand<string>)(object)(selectChatTabCommand ?? (selectChatTabCommand = new AsyncRelayCommand<string>((Func<string, global::System.Threading.Tasks.Task>)SelectChatTab)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand RefreshCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = refreshCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)Refresh);
				AsyncRelayCommand val2 = val;
				refreshCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand SearchPlayersCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = searchPlayersCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)SearchPlayers);
				AsyncRelayCommand val2 = val;
				searchPlayersCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand ToggleFriendListCommand
	{
		get
		{
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Expected O, but got Unknown
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			RelayCommand obj = toggleFriendListCommand;
			if (obj == null)
			{
				RelayCommand val = new RelayCommand(new Action(ToggleFriendList));
				RelayCommand val2 = val;
				toggleFriendListCommand = val;
				obj = val2;
			}
			return (IRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand ShowGuildMembersCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = showGuildMembersCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)ShowGuildMembers);
				AsyncRelayCommand val2 = val;
				showGuildMembersCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand ShowGuildInvitationsCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = showGuildInvitationsCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)ShowGuildInvitations);
				AsyncRelayCommand val2 = val;
				showGuildInvitationsCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<DMThreadModel> OpenDMThreadCommand => (IAsyncRelayCommand<DMThreadModel>)(object)(openDMThreadCommand ?? (openDMThreadCommand = new AsyncRelayCommand<DMThreadModel>((Func<DMThreadModel, global::System.Threading.Tasks.Task>)OpenDMThread)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand NewMessageCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = newMessageCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)NewMessage);
				AsyncRelayCommand val2 = val;
				newMessageCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<FriendRequestModel> AcceptFriendRequestCommand => (IAsyncRelayCommand<FriendRequestModel>)(object)(acceptFriendRequestCommand ?? (acceptFriendRequestCommand = new AsyncRelayCommand<FriendRequestModel>((Func<FriendRequestModel, global::System.Threading.Tasks.Task>)AcceptFriendRequest)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<FriendRequestModel> DeclineFriendRequestCommand => (IAsyncRelayCommand<FriendRequestModel>)(object)(declineFriendRequestCommand ?? (declineFriendRequestCommand = new AsyncRelayCommand<FriendRequestModel>((Func<FriendRequestModel, global::System.Threading.Tasks.Task>)DeclineFriendRequest)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<ChatPlayerModel> OpenDMCommand => (IAsyncRelayCommand<ChatPlayerModel>)(object)(openDMCommand ?? (openDMCommand = new AsyncRelayCommand<ChatPlayerModel>((Func<ChatPlayerModel, global::System.Threading.Tasks.Task>)OpenDM)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<ChatPlayerModel> FightCommand => (IAsyncRelayCommand<ChatPlayerModel>)(object)(fightCommand ?? (fightCommand = new AsyncRelayCommand<ChatPlayerModel>((Func<ChatPlayerModel, global::System.Threading.Tasks.Task>)Fight)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand NavigateToBattleCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = navigateToBattleCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)NavigateToBattle);
				AsyncRelayCommand val2 = val;
				navigateToBattleCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand NavigateToQuestCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = navigateToQuestCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)NavigateToQuest);
				AsyncRelayCommand val2 = val;
				navigateToQuestCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand GoBackCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = goBackCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)GoBack);
				AsyncRelayCommand val2 = val;
				goBackCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<string> NavigateToSpiritDetailsCommand => (IAsyncRelayCommand<string>)(object)(navigateToSpiritDetailsCommand ?? (navigateToSpiritDetailsCommand = new AsyncRelayCommand<string>((Func<string, global::System.Threading.Tasks.Task>)NavigateToSpiritDetails)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand OpenSpiritsHoldNavigationCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = openSpiritsHoldNavigationCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)OpenSpiritsHoldNavigation);
				AsyncRelayCommand val2 = val;
				openSpiritsHoldNavigationCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<ChatPlayerModel> MoreOptionsCommand => (IRelayCommand<ChatPlayerModel>)(object)(moreOptionsCommand ?? (moreOptionsCommand = new RelayCommand<ChatPlayerModel>((Action<ChatPlayerModel>)MoreOptions)));

	public ChatViewModel(GetFriendsUseCase getFriendsUseCase, AcceptFriendRequestUseCase acceptFriendRequestUseCase, DeclineFriendRequestUseCase declineFriendRequestUseCase, IPlayerNotificationListenerService notificationListener, IPlayerStateService playerState, IPopupService popupService, IChatRepository chatRepository, IGuildStateService guildState, IGuildChatCacheService guildChatCache, CreateGuildThreadUseCase createGuildThreadUseCase, IBottomSheetService bottomSheetService, INavigationService navigationService, IChatUnreadService chatUnreadService, IPreferencesService preferences, StartFriendBattleUseCase startFriendBattleUseCase, IPlayerRepository playerRepository, SpiritCardModelFactory spiritCardModelFactory, PlayerInfoModel playerInfoModel, NavBarViewModel navBarViewModel)
	{
		_getFriendsUseCase = getFriendsUseCase;
		_acceptFriendRequestUseCase = acceptFriendRequestUseCase;
		_declineFriendRequestUseCase = declineFriendRequestUseCase;
		_notificationListener = notificationListener;
		_playerState = playerState;
		_popupService = popupService;
		_chatRepository = chatRepository;
		_guildState = guildState;
		_guildChatCache = guildChatCache;
		_createGuildThreadUseCase = createGuildThreadUseCase;
		_bottomSheetService = bottomSheetService;
		_navigationService = navigationService;
		_chatUnreadService = chatUnreadService;
		_preferences = preferences;
		_startFriendBattle = startFriendBattleUseCase;
		_playerRepository = playerRepository;
		_spiritCardModelFactory = spiritCardModelFactory;
		_playerInfoModel = playerInfoModel;
		_navbarViewModel = navBarViewModel;
		_notificationListener.NotificationReceived += OnNotificationReceived;
	}

	[AsyncStateMachine(typeof(_003CLoadDataAsync_003Ed__68))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task LoadDataAsync(object? parameter)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadDataAsync_003Ed__68 _003CLoadDataAsync_003Ed__ = new _003CLoadDataAsync_003Ed__68();
		_003CLoadDataAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadDataAsync_003Ed__._003C_003E4__this = this;
		_003CLoadDataAsync_003Ed__.parameter = parameter;
		_003CLoadDataAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadDataAsync_003Ed__68>(ref _003CLoadDataAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CLoadPartnerSpirit_003Ed__69))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task LoadPartnerSpirit()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadPartnerSpirit_003Ed__69 _003CLoadPartnerSpirit_003Ed__ = new _003CLoadPartnerSpirit_003Ed__69();
		_003CLoadPartnerSpirit_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadPartnerSpirit_003Ed__._003C_003E4__this = this;
		_003CLoadPartnerSpirit_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadPartnerSpirit_003Ed__._003C_003Et__builder)).Start<_003CLoadPartnerSpirit_003Ed__69>(ref _003CLoadPartnerSpirit_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadPartnerSpirit_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CLoadInboxAsync_003Ed__70))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task LoadInboxAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadInboxAsync_003Ed__70 _003CLoadInboxAsync_003Ed__ = new _003CLoadInboxAsync_003Ed__70();
		_003CLoadInboxAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadInboxAsync_003Ed__._003C_003E4__this = this;
		_003CLoadInboxAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadInboxAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadInboxAsync_003Ed__70>(ref _003CLoadInboxAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadInboxAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CLoadDMThreadsAsync_003Ed__71))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task LoadDMThreadsAsync(string playerId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadDMThreadsAsync_003Ed__71 _003CLoadDMThreadsAsync_003Ed__ = new _003CLoadDMThreadsAsync_003Ed__71();
		_003CLoadDMThreadsAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadDMThreadsAsync_003Ed__._003C_003E4__this = this;
		_003CLoadDMThreadsAsync_003Ed__.playerId = playerId;
		_003CLoadDMThreadsAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadDMThreadsAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadDMThreadsAsync_003Ed__71>(ref _003CLoadDMThreadsAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadDMThreadsAsync_003Ed__._003C_003Et__builder)).Task;
	}

	private void OnNotificationReceived(object? sender, NotificationReceivedEventArgs args)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		_003C_003Ec__DisplayClass72_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass72_0();
		CS_0024_003C_003E8__locals0.args = args;
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		if (CS_0024_003C_003E8__locals0.args.Notification.Type == NotificationType.FriendRequest)
		{
			MainThread.BeginInvokeOnMainThread((Action)delegate
			{
				//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
				object obj = default(object);
				FriendRequestModel friendRequestModel = new FriendRequestModel
				{
					NotificationId = CS_0024_003C_003E8__locals0.args.Notification.Id,
					SenderId = ((CollectionExtensions.GetValueOrDefault<string, object>((IReadOnlyDictionary<string, object>)(object)CS_0024_003C_003E8__locals0.args.Notification.Data, "senderId") as string) ?? string.Empty),
					SenderName = ((CollectionExtensions.GetValueOrDefault<string, object>((IReadOnlyDictionary<string, object>)(object)CS_0024_003C_003E8__locals0.args.Notification.Data, "senderName") as string) ?? "Unknown"),
					SenderLevel = ((CS_0024_003C_003E8__locals0.args.Notification.Data.TryGetValue("senderLevel", ref obj) && obj is int num) ? num : 0),
					ReceivedAt = CS_0024_003C_003E8__locals0.args.Notification.CreatedAt
				};
				((Collection<FriendRequestModel>)(object)CS_0024_003C_003E8__locals0._003C_003E4__this.FriendRequests).Insert(0, friendRequestModel);
				CS_0024_003C_003E8__locals0._003C_003E4__this.HasFriendRequests = true;
				CS_0024_003C_003E8__locals0._003C_003E4__this._chatUnreadService.SetFriendRequestCount(((Collection<FriendRequestModel>)(object)CS_0024_003C_003E8__locals0._003C_003E4__this.FriendRequests).Count);
			});
		}
		else if (CS_0024_003C_003E8__locals0.args.Notification.Type == NotificationType.FriendRequestAccepted)
		{
			MainThread.BeginInvokeOnMainThread((Action)([AsyncStateMachine(typeof(_003C_003Ec__DisplayClass72_0._003C_003COnNotificationReceived_003Eb__1_003Ed))] [DebuggerStepThrough] () =>
			{
				//IL_0007: Unknown result type (might be due to invalid IL or missing references)
				//IL_000c: Unknown result type (might be due to invalid IL or missing references)
				_003C_003Ec__DisplayClass72_0._003C_003COnNotificationReceived_003Eb__1_003Ed _003C_003COnNotificationReceived_003Eb__1_003Ed = new _003C_003Ec__DisplayClass72_0._003C_003COnNotificationReceived_003Eb__1_003Ed
				{
					_003C_003Et__builder = AsyncVoidMethodBuilder.Create(),
					_003C_003E4__this = CS_0024_003C_003E8__locals0,
					_003C_003E1__state = -1
				};
				((AsyncVoidMethodBuilder)(ref _003C_003COnNotificationReceived_003Eb__1_003Ed._003C_003Et__builder)).Start<_003C_003Ec__DisplayClass72_0._003C_003COnNotificationReceived_003Eb__1_003Ed>(ref _003C_003COnNotificationReceived_003Eb__1_003Ed);
			}));
		}
		if (!_notificationsLoaded)
		{
			return;
		}
		MainThread.BeginInvokeOnMainThread((Action)delegate
		{
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			PlayerNotificationModel playerNotificationModel = new PlayerNotificationModel
			{
				Id = CS_0024_003C_003E8__locals0.args.Notification.Id,
				Type = CS_0024_003C_003E8__locals0.args.Notification.Type,
				Icon = NotificationFormatter.GetIcon(CS_0024_003C_003E8__locals0.args.Notification.Type),
				Title = NotificationFormatter.GetTitle(CS_0024_003C_003E8__locals0.args.Notification.Type),
				Body = NotificationFormatter.GetBody(CS_0024_003C_003E8__locals0.args.Notification.Type, CS_0024_003C_003E8__locals0.args.Notification.Data),
				CreatedAt = CS_0024_003C_003E8__locals0.args.Notification.CreatedAt,
				IsRead = false
			};
			NotificationGroup notificationGroup = Enumerable.FirstOrDefault<NotificationGroup>((global::System.Collections.Generic.IEnumerable<NotificationGroup>)CS_0024_003C_003E8__locals0._003C_003E4__this.NotificationGroups, (Func<NotificationGroup, bool>)((NotificationGroup g) => g.GroupLabel == "Today"));
			if (notificationGroup != null)
			{
				((Collection<PlayerNotificationModel>)(object)notificationGroup).Insert(0, playerNotificationModel);
			}
			else
			{
				((Collection<NotificationGroup>)(object)CS_0024_003C_003E8__locals0._003C_003E4__this.NotificationGroups).Insert(0, new NotificationGroup("Today", new _003C_003Ez__ReadOnlySingleElementList<PlayerNotificationModel>(playerNotificationModel)));
			}
			CS_0024_003C_003E8__locals0._003C_003E4__this.HasNotifications = true;
			int unreadNotificationCount = CS_0024_003C_003E8__locals0._003C_003E4__this.UnreadNotificationCount;
			CS_0024_003C_003E8__locals0._003C_003E4__this.UnreadNotificationCount = unreadNotificationCount + 1;
			CS_0024_003C_003E8__locals0._003C_003E4__this._chatUnreadService.SetUnreadNotificationCount(CS_0024_003C_003E8__locals0._003C_003E4__this.UnreadNotificationCount);
		});
	}

	[AsyncStateMachine(typeof(_003CLoadGuildThreadsAsync_003Ed__73))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task LoadGuildThreadsAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadGuildThreadsAsync_003Ed__73 _003CLoadGuildThreadsAsync_003Ed__ = new _003CLoadGuildThreadsAsync_003Ed__73();
		_003CLoadGuildThreadsAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadGuildThreadsAsync_003Ed__._003C_003E4__this = this;
		_003CLoadGuildThreadsAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadGuildThreadsAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadGuildThreadsAsync_003Ed__73>(ref _003CLoadGuildThreadsAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadGuildThreadsAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003COpenThread_003Ed__74))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task OpenThread(GuildThreadModel thread)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003COpenThread_003Ed__74 _003COpenThread_003Ed__ = new _003COpenThread_003Ed__74();
		_003COpenThread_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003COpenThread_003Ed__._003C_003E4__this = this;
		_003COpenThread_003Ed__.thread = thread;
		_003COpenThread_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003COpenThread_003Ed__._003C_003Et__builder)).Start<_003COpenThread_003Ed__74>(ref _003COpenThread_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003COpenThread_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003COpenNewThreadSheet_003Ed__75))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task OpenNewThreadSheet()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003COpenNewThreadSheet_003Ed__75 _003COpenNewThreadSheet_003Ed__ = new _003COpenNewThreadSheet_003Ed__75();
		_003COpenNewThreadSheet_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003COpenNewThreadSheet_003Ed__._003C_003E4__this = this;
		_003COpenNewThreadSheet_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003COpenNewThreadSheet_003Ed__._003C_003Et__builder)).Start<_003COpenNewThreadSheet_003Ed__75>(ref _003COpenNewThreadSheet_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003COpenNewThreadSheet_003Ed__._003C_003Et__builder)).Task;
	}

	private void OnGuildThreadCreated(Conversation newThread)
	{
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		Conversation newThread2 = newThread;
		Player currentPlayer = _playerState.GetCurrentPlayer();
		if (currentPlayer?.GuildId != null)
		{
			_guildChatCache.PrependThread(currentPlayer.GuildId, newThread2);
			MainThread.BeginInvokeOnMainThread((Action)delegate
			{
				((Collection<GuildThreadModel>)(object)GuildThreads).Insert(0, MapToThreadModel(newThread2));
			});
		}
	}

	private static GuildThreadModel MapToThreadModel(Conversation c)
	{
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		return new GuildThreadModel
		{
			ConversationId = c.Id,
			Subject = (c.Subject ?? string.Empty),
			Icon = (string.IsNullOrEmpty(c.Icon) ? "\ud83d\udcac" : c.Icon),
			LastMessageText = c.LastMessageText,
			LastMessageAt = c.LastMessageAt
		};
	}

	[AsyncStateMachine(typeof(_003CLoadNotificationsAsync_003Ed__79))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task LoadNotificationsAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadNotificationsAsync_003Ed__79 _003CLoadNotificationsAsync_003Ed__ = new _003CLoadNotificationsAsync_003Ed__79();
		_003CLoadNotificationsAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadNotificationsAsync_003Ed__._003C_003E4__this = this;
		_003CLoadNotificationsAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadNotificationsAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadNotificationsAsync_003Ed__79>(ref _003CLoadNotificationsAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadNotificationsAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CTapNotification_003Ed__80))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task TapNotification(PlayerNotificationModel notification)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CTapNotification_003Ed__80 _003CTapNotification_003Ed__ = new _003CTapNotification_003Ed__80();
		_003CTapNotification_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CTapNotification_003Ed__._003C_003E4__this = this;
		_003CTapNotification_003Ed__.notification = notification;
		_003CTapNotification_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CTapNotification_003Ed__._003C_003Et__builder)).Start<_003CTapNotification_003Ed__80>(ref _003CTapNotification_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CTapNotification_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CSelectChatTab_003Ed__81))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task SelectChatTab(string tab)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CSelectChatTab_003Ed__81 _003CSelectChatTab_003Ed__ = new _003CSelectChatTab_003Ed__81();
		_003CSelectChatTab_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CSelectChatTab_003Ed__._003C_003E4__this = this;
		_003CSelectChatTab_003Ed__.tab = tab;
		_003CSelectChatTab_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CSelectChatTab_003Ed__._003C_003Et__builder)).Start<_003CSelectChatTab_003Ed__81>(ref _003CSelectChatTab_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CSelectChatTab_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CRefresh_003Ed__82))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task Refresh()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CRefresh_003Ed__82 _003CRefresh_003Ed__ = new _003CRefresh_003Ed__82();
		_003CRefresh_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CRefresh_003Ed__._003C_003E4__this = this;
		_003CRefresh_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CRefresh_003Ed__._003C_003Et__builder)).Start<_003CRefresh_003Ed__82>(ref _003CRefresh_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CRefresh_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CSearchPlayers_003Ed__83))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task SearchPlayers()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CSearchPlayers_003Ed__83 _003CSearchPlayers_003Ed__ = new _003CSearchPlayers_003Ed__83();
		_003CSearchPlayers_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CSearchPlayers_003Ed__._003C_003E4__this = this;
		_003CSearchPlayers_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CSearchPlayers_003Ed__._003C_003Et__builder)).Start<_003CSearchPlayers_003Ed__83>(ref _003CSearchPlayers_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CSearchPlayers_003Ed__._003C_003Et__builder)).Task;
	}

	[RelayCommand]
	private void ToggleFriendList()
	{
		CurrentChatTab = ((CurrentChatTab == "dm") ? "inbox" : "dm");
	}

	[AsyncStateMachine(typeof(_003CShowGuildMembers_003Ed__85))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task ShowGuildMembers()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CShowGuildMembers_003Ed__85 _003CShowGuildMembers_003Ed__ = new _003CShowGuildMembers_003Ed__85();
		_003CShowGuildMembers_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CShowGuildMembers_003Ed__._003C_003E4__this = this;
		_003CShowGuildMembers_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CShowGuildMembers_003Ed__._003C_003Et__builder)).Start<_003CShowGuildMembers_003Ed__85>(ref _003CShowGuildMembers_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CShowGuildMembers_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CShowGuildInvitations_003Ed__86))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task ShowGuildInvitations()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CShowGuildInvitations_003Ed__86 _003CShowGuildInvitations_003Ed__ = new _003CShowGuildInvitations_003Ed__86();
		_003CShowGuildInvitations_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CShowGuildInvitations_003Ed__._003C_003E4__this = this;
		_003CShowGuildInvitations_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CShowGuildInvitations_003Ed__._003C_003Et__builder)).Start<_003CShowGuildInvitations_003Ed__86>(ref _003CShowGuildInvitations_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CShowGuildInvitations_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003COpenDMThread_003Ed__87))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task OpenDMThread(DMThreadModel thread)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003COpenDMThread_003Ed__87 _003COpenDMThread_003Ed__ = new _003COpenDMThread_003Ed__87();
		_003COpenDMThread_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003COpenDMThread_003Ed__._003C_003E4__this = this;
		_003COpenDMThread_003Ed__.thread = thread;
		_003COpenDMThread_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003COpenDMThread_003Ed__._003C_003Et__builder)).Start<_003COpenDMThread_003Ed__87>(ref _003COpenDMThread_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003COpenDMThread_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CNewMessage_003Ed__88))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task NewMessage()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CNewMessage_003Ed__88 _003CNewMessage_003Ed__ = new _003CNewMessage_003Ed__88();
		_003CNewMessage_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CNewMessage_003Ed__._003C_003E4__this = this;
		_003CNewMessage_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CNewMessage_003Ed__._003C_003Et__builder)).Start<_003CNewMessage_003Ed__88>(ref _003CNewMessage_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CNewMessage_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CAcceptFriendRequest_003Ed__89))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task AcceptFriendRequest(FriendRequestModel request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CAcceptFriendRequest_003Ed__89 _003CAcceptFriendRequest_003Ed__ = new _003CAcceptFriendRequest_003Ed__89();
		_003CAcceptFriendRequest_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CAcceptFriendRequest_003Ed__._003C_003E4__this = this;
		_003CAcceptFriendRequest_003Ed__.request = request;
		_003CAcceptFriendRequest_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CAcceptFriendRequest_003Ed__._003C_003Et__builder)).Start<_003CAcceptFriendRequest_003Ed__89>(ref _003CAcceptFriendRequest_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CAcceptFriendRequest_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CDeclineFriendRequest_003Ed__90))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task DeclineFriendRequest(FriendRequestModel request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CDeclineFriendRequest_003Ed__90 _003CDeclineFriendRequest_003Ed__ = new _003CDeclineFriendRequest_003Ed__90();
		_003CDeclineFriendRequest_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CDeclineFriendRequest_003Ed__._003C_003E4__this = this;
		_003CDeclineFriendRequest_003Ed__.request = request;
		_003CDeclineFriendRequest_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CDeclineFriendRequest_003Ed__._003C_003Et__builder)).Start<_003CDeclineFriendRequest_003Ed__90>(ref _003CDeclineFriendRequest_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CDeclineFriendRequest_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003COpenDM_003Ed__91))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task OpenDM(ChatPlayerModel player)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003COpenDM_003Ed__91 _003COpenDM_003Ed__ = new _003COpenDM_003Ed__91();
		_003COpenDM_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003COpenDM_003Ed__._003C_003E4__this = this;
		_003COpenDM_003Ed__.player = player;
		_003COpenDM_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003COpenDM_003Ed__._003C_003Et__builder)).Start<_003COpenDM_003Ed__91>(ref _003COpenDM_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003COpenDM_003Ed__._003C_003Et__builder)).Task;
	}

	private ValueTuple<bool, string> ValidateBattlePreconditions(bool is3v3)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		IPlayerStateService playerState = _playerState;
		if (new Func<Player>(playerState.GetCurrentPlayer) == null)
		{
			return new ValueTuple<bool, string>(false, "Player data not available");
		}
		if ((is3v3 && !HasValidSquad) || (!is3v3 && string.IsNullOrEmpty(_playerState.GetPartnerSpirit()?.PlayerSpiritID)))
		{
			return new ValueTuple<bool, string>(false, "Invalid squad! Check your collection!");
		}
		if (!HasEnoughSP)
		{
			return new ValueTuple<bool, string>(false, "Not enough SP! SP amount too low!");
		}
		return new ValueTuple<bool, string>(true, string.Empty);
	}

	[AsyncStateMachine(typeof(_003CFight_003Ed__93))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task Fight(ChatPlayerModel player)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CFight_003Ed__93 _003CFight_003Ed__ = new _003CFight_003Ed__93();
		_003CFight_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CFight_003Ed__._003C_003E4__this = this;
		_003CFight_003Ed__.player = player;
		_003CFight_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CFight_003Ed__._003C_003Et__builder)).Start<_003CFight_003Ed__93>(ref _003CFight_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CFight_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CProcessBattleResults_003Ed__94))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task ProcessBattleResults(BattleResultDTO battleResult, ChatPlayerModel opponent)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CProcessBattleResults_003Ed__94 _003CProcessBattleResults_003Ed__ = new _003CProcessBattleResults_003Ed__94();
		_003CProcessBattleResults_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CProcessBattleResults_003Ed__._003C_003E4__this = this;
		_003CProcessBattleResults_003Ed__.battleResult = battleResult;
		_003CProcessBattleResults_003Ed__.opponent = opponent;
		_003CProcessBattleResults_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CProcessBattleResults_003Ed__._003C_003Et__builder)).Start<_003CProcessBattleResults_003Ed__94>(ref _003CProcessBattleResults_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CProcessBattleResults_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CShowBattleSummary_003Ed__95))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task ShowBattleSummary(BattleResultDTO battleResult, ChatPlayerModel opponent)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CShowBattleSummary_003Ed__95 _003CShowBattleSummary_003Ed__ = new _003CShowBattleSummary_003Ed__95();
		_003CShowBattleSummary_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CShowBattleSummary_003Ed__._003C_003E4__this = this;
		_003CShowBattleSummary_003Ed__.battleResult = battleResult;
		_003CShowBattleSummary_003Ed__.opponent = opponent;
		_003CShowBattleSummary_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CShowBattleSummary_003Ed__._003C_003Et__builder)).Start<_003CShowBattleSummary_003Ed__95>(ref _003CShowBattleSummary_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CShowBattleSummary_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CNavigateToBattle_003Ed__96))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task NavigateToBattle()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CNavigateToBattle_003Ed__96 _003CNavigateToBattle_003Ed__ = new _003CNavigateToBattle_003Ed__96();
		_003CNavigateToBattle_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CNavigateToBattle_003Ed__._003C_003E4__this = this;
		_003CNavigateToBattle_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CNavigateToBattle_003Ed__._003C_003Et__builder)).Start<_003CNavigateToBattle_003Ed__96>(ref _003CNavigateToBattle_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CNavigateToBattle_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CNavigateToQuest_003Ed__97))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task NavigateToQuest()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CNavigateToQuest_003Ed__97 _003CNavigateToQuest_003Ed__ = new _003CNavigateToQuest_003Ed__97();
		_003CNavigateToQuest_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CNavigateToQuest_003Ed__._003C_003E4__this = this;
		_003CNavigateToQuest_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CNavigateToQuest_003Ed__._003C_003Et__builder)).Start<_003CNavigateToQuest_003Ed__97>(ref _003CNavigateToQuest_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CNavigateToQuest_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CGoBack_003Ed__98))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task GoBack()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CGoBack_003Ed__98 _003CGoBack_003Ed__ = new _003CGoBack_003Ed__98();
		_003CGoBack_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CGoBack_003Ed__._003C_003E4__this = this;
		_003CGoBack_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CGoBack_003Ed__._003C_003Et__builder)).Start<_003CGoBack_003Ed__98>(ref _003CGoBack_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CGoBack_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CNavigateToSpiritDetails_003Ed__99))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task NavigateToSpiritDetails(string id)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CNavigateToSpiritDetails_003Ed__99 _003CNavigateToSpiritDetails_003Ed__ = new _003CNavigateToSpiritDetails_003Ed__99();
		_003CNavigateToSpiritDetails_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CNavigateToSpiritDetails_003Ed__._003C_003E4__this = this;
		_003CNavigateToSpiritDetails_003Ed__.id = id;
		_003CNavigateToSpiritDetails_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CNavigateToSpiritDetails_003Ed__._003C_003Et__builder)).Start<_003CNavigateToSpiritDetails_003Ed__99>(ref _003CNavigateToSpiritDetails_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CNavigateToSpiritDetails_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003COpenSpiritsHoldNavigation_003Ed__100))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task OpenSpiritsHoldNavigation()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003COpenSpiritsHoldNavigation_003Ed__100 _003COpenSpiritsHoldNavigation_003Ed__ = new _003COpenSpiritsHoldNavigation_003Ed__100();
		_003COpenSpiritsHoldNavigation_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003COpenSpiritsHoldNavigation_003Ed__._003C_003E4__this = this;
		_003COpenSpiritsHoldNavigation_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003COpenSpiritsHoldNavigation_003Ed__._003C_003Et__builder)).Start<_003COpenSpiritsHoldNavigation_003Ed__100>(ref _003COpenSpiritsHoldNavigation_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003COpenSpiritsHoldNavigation_003Ed__._003C_003Et__builder)).Task;
	}

	[RelayCommand]
	private void MoreOptions(ChatPlayerModel player)
	{
	}

	public void Dispose()
	{
		_notificationListener.NotificationReceived -= OnNotificationReceived;
		GC.SuppressFinalize((object)this);
	}
}
