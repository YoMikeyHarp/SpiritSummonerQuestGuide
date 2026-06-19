using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Application.UseCases.Guilds;
using SpiritSummoner.Application.UseCases.Players;
using SpiritSummoner.Domain.Entities.Guilds;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Enums.Guilds;
using SpiritSummoner.Presentation.Navigation;

namespace SpiritSummoner.Presentation.ViewModels.Popups;

public class InvitePlayerPopupViewModel : ObservableObject
{
	[CompilerGenerated]
	private sealed class _003CAcceptJoinRequest_003Ed__20 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildJoinRequest joinRequest;

		public InvitePlayerPopupViewModel _003C_003E4__this;

		private Player _003CcurrentPlayer_003E5__1;

		private GuildInvitationRequest _003Crequest_003E5__2;

		private Result<GuildInvitationResult> _003Cresult_003E5__3;

		private Result<GuildInvitationResult> _003C_003Es__4;

		private bool _003CconfirmationResult_003E5__5;

		private bool _003C_003Es__6;

		private global::System.Exception _003Cex_003E5__7;

		private TaskAwaiter<Result<GuildInvitationResult>> _003C_003Eu__1;

		private TaskAwaiter<bool> _003C_003Eu__2;

		private TaskAwaiter _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0102: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_024f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0254: Unknown result type (might be due to invalid IL or missing references)
			//IL_025c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_018b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0215: Unknown result type (might be due to invalid IL or missing references)
			//IL_021a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_022f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0231: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 2u || (joinRequest != null && !string.IsNullOrEmpty(_003C_003E4__this.GuildId)))
				{
					try
					{
						TaskAwaiter<Result<GuildInvitationResult>> awaiter3;
						TaskAwaiter<bool> awaiter2;
						TaskAwaiter awaiter;
						switch (num)
						{
						default:
							_003CcurrentPlayer_003E5__1 = _003C_003E4__this._playerStateService.GetCurrentPlayer();
							if (_003CcurrentPlayer_003E5__1 != null)
							{
								_003Crequest_003E5__2 = new GuildInvitationRequest(_003C_003E4__this.GuildId, _003CcurrentPlayer_003E5__1.PlayerID, InvitationAction.ApproveJoinRequest, null, joinRequest.ID);
								awaiter3 = _003C_003E4__this._manageInvitationsUseCase.ExecuteAsync(_003Crequest_003E5__2).GetAwaiter();
								if (!awaiter3.IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter3;
									_003CAcceptJoinRequest_003Ed__20 _003CAcceptJoinRequest_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<GuildInvitationResult>>, _003CAcceptJoinRequest_003Ed__20>(ref awaiter3, ref _003CAcceptJoinRequest_003Ed__);
									return;
								}
								goto IL_0118;
							}
							goto end_IL_0035;
						case 0:
							awaiter3 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<Result<GuildInvitationResult>>);
							num = (_003C_003E1__state = -1);
							goto IL_0118;
						case 1:
							awaiter2 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<bool>);
							num = (_003C_003E1__state = -1);
							goto IL_01dc;
						case 2:
							{
								awaiter = _003C_003Eu__3;
								_003C_003Eu__3 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_026b;
							}
							IL_01dc:
							_003C_003Es__6 = awaiter2.GetResult();
							_003CconfirmationResult_003E5__5 = _003C_003Es__6;
							if (!_003CconfirmationResult_003E5__5)
							{
								awaiter = _003C_003E4__this.Close(true).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
								{
									num = (_003C_003E1__state = 2);
									_003C_003Eu__3 = awaiter;
									_003CAcceptJoinRequest_003Ed__20 _003CAcceptJoinRequest_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CAcceptJoinRequest_003Ed__20>(ref awaiter, ref _003CAcceptJoinRequest_003Ed__);
									return;
								}
								goto IL_026b;
							}
							break;
							IL_026b:
							((TaskAwaiter)(ref awaiter)).GetResult();
							break;
							IL_0118:
							_003C_003Es__4 = awaiter3.GetResult();
							_003Cresult_003E5__3 = _003C_003Es__4;
							_003C_003Es__4 = null;
							if (_003Cresult_003E5__3.Success)
							{
								awaiter2 = _003C_003E4__this._navigationService.ShowConfirmationAsync("Success! " + joinRequest.PlayerName + " added to your guild!", "Do you wish to continue?").GetAwaiter();
								if (!awaiter2.IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__2 = awaiter2;
									_003CAcceptJoinRequest_003Ed__20 _003CAcceptJoinRequest_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CAcceptJoinRequest_003Ed__20>(ref awaiter2, ref _003CAcceptJoinRequest_003Ed__);
									return;
								}
								goto IL_01dc;
							}
							_003C_003E4__this.ErrorMessage = _003Cresult_003E5__3.ErrorMessage ?? "Failed to approve join request.";
							break;
						}
						_003CcurrentPlayer_003E5__1 = null;
						_003Crequest_003E5__2 = null;
						_003Cresult_003E5__3 = null;
						end_IL_0035:;
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__7 = ex;
						_003C_003E4__this.ErrorMessage = _003Cex_003E5__7.Message;
						Console.WriteLine(_003Cex_003E5__7.StackTrace);
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
	private sealed class _003CClose_003Ed__23 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public bool? result;

		public InvitePlayerPopupViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = _003C_003E4__this._popupService.ClosePopupAsync((object)result).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CClose_003Ed__23 _003CClose_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CClose_003Ed__23>(ref awaiter, ref _003CClose_003Ed__);
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
	private sealed class _003CDeclineJoinRequest_003Ed__21 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildJoinRequest joinRequest;

		public InvitePlayerPopupViewModel _003C_003E4__this;

		private Player _003CcurrentPlayer_003E5__1;

		private GuildInvitationRequest _003Crequest_003E5__2;

		private Result<GuildInvitationResult> _003Cresult_003E5__3;

		private Result<GuildInvitationResult> _003C_003Es__4;

		private bool _003CconfirmationResult_003E5__5;

		private bool _003C_003Es__6;

		private global::System.Exception _003Cex_003E5__7;

		private TaskAwaiter<Result<GuildInvitationResult>> _003C_003Eu__1;

		private TaskAwaiter<bool> _003C_003Eu__2;

		private TaskAwaiter _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0102: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_024a: Unknown result type (might be due to invalid IL or missing references)
			//IL_024f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0257: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0210: Unknown result type (might be due to invalid IL or missing references)
			//IL_0215: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_019b: Unknown result type (might be due to invalid IL or missing references)
			//IL_019d: Unknown result type (might be due to invalid IL or missing references)
			//IL_022a: Unknown result type (might be due to invalid IL or missing references)
			//IL_022c: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 2u || (joinRequest != null && !string.IsNullOrEmpty(_003C_003E4__this.GuildId)))
				{
					try
					{
						TaskAwaiter<Result<GuildInvitationResult>> awaiter3;
						TaskAwaiter<bool> awaiter2;
						TaskAwaiter awaiter;
						switch (num)
						{
						default:
							_003CcurrentPlayer_003E5__1 = _003C_003E4__this._playerStateService.GetCurrentPlayer();
							if (_003CcurrentPlayer_003E5__1 != null)
							{
								_003Crequest_003E5__2 = new GuildInvitationRequest(_003C_003E4__this.GuildId, _003CcurrentPlayer_003E5__1.PlayerID, InvitationAction.RejectJoinRequest, null, joinRequest.ID);
								awaiter3 = _003C_003E4__this._manageInvitationsUseCase.ExecuteAsync(_003Crequest_003E5__2).GetAwaiter();
								if (!awaiter3.IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter3;
									_003CDeclineJoinRequest_003Ed__21 _003CDeclineJoinRequest_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<GuildInvitationResult>>, _003CDeclineJoinRequest_003Ed__21>(ref awaiter3, ref _003CDeclineJoinRequest_003Ed__);
									return;
								}
								goto IL_0118;
							}
							goto end_IL_0035;
						case 0:
							awaiter3 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<Result<GuildInvitationResult>>);
							num = (_003C_003E1__state = -1);
							goto IL_0118;
						case 1:
							awaiter2 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<bool>);
							num = (_003C_003E1__state = -1);
							goto IL_01d7;
						case 2:
							{
								awaiter = _003C_003Eu__3;
								_003C_003Eu__3 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_0266;
							}
							IL_01d7:
							_003C_003Es__6 = awaiter2.GetResult();
							_003CconfirmationResult_003E5__5 = _003C_003Es__6;
							if (!_003CconfirmationResult_003E5__5)
							{
								awaiter = _003C_003E4__this.Close(true).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
								{
									num = (_003C_003E1__state = 2);
									_003C_003Eu__3 = awaiter;
									_003CDeclineJoinRequest_003Ed__21 _003CDeclineJoinRequest_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CDeclineJoinRequest_003Ed__21>(ref awaiter, ref _003CDeclineJoinRequest_003Ed__);
									return;
								}
								goto IL_0266;
							}
							break;
							IL_0266:
							((TaskAwaiter)(ref awaiter)).GetResult();
							break;
							IL_0118:
							_003C_003Es__4 = awaiter3.GetResult();
							_003Cresult_003E5__3 = _003C_003Es__4;
							_003C_003Es__4 = null;
							if (_003Cresult_003E5__3.Success)
							{
								awaiter2 = _003C_003E4__this._navigationService.ShowConfirmationAsync(joinRequest.PlayerName + " join request was rejected!", "Do you wish to continue?").GetAwaiter();
								if (!awaiter2.IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__2 = awaiter2;
									_003CDeclineJoinRequest_003Ed__21 _003CDeclineJoinRequest_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CDeclineJoinRequest_003Ed__21>(ref awaiter2, ref _003CDeclineJoinRequest_003Ed__);
									return;
								}
								goto IL_01d7;
							}
							_003C_003E4__this.ErrorMessage = _003Cresult_003E5__3.ErrorMessage ?? "Failed to reject join request.";
							break;
						}
						_003CcurrentPlayer_003E5__1 = null;
						_003Crequest_003E5__2 = null;
						_003Cresult_003E5__3 = null;
						end_IL_0035:;
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__7 = ex;
						_003C_003E4__this.ErrorMessage = _003Cex_003E5__7.Message;
						Console.WriteLine(_003Cex_003E5__7.StackTrace);
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
	private sealed class _003CLoadJoinRequests_003Ed__17 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public bool isInviteMode;

		public InvitePlayerPopupViewModel _003C_003E4__this;

		private Player _003Cplayer_003E5__1;

		private GetPendingJoinRequestsRequest _003Crequest_003E5__2;

		private Result<List<GuildJoinRequest>> _003Cresult_003E5__3;

		private Result<List<GuildJoinRequest>> _003C_003Es__4;

		private TaskAwaiter<Result<List<GuildJoinRequest>>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter<Result<List<GuildJoinRequest>>> awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Result<List<GuildJoinRequest>>>);
					num = (_003C_003E1__state = -1);
					goto IL_00da;
				}
				if (!isInviteMode)
				{
					_003Cplayer_003E5__1 = _003C_003E4__this._playerStateService.GetCurrentPlayer();
					if (_003Cplayer_003E5__1 != null && !string.IsNullOrEmpty(_003Cplayer_003E5__1.GuildId))
					{
						_003Crequest_003E5__2 = new GetPendingJoinRequestsRequest(_003Cplayer_003E5__1.GuildId);
						awaiter = _003C_003E4__this._getPendingJoinRequestsUseCase.ExecuteAsync(_003Crequest_003E5__2).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CLoadJoinRequests_003Ed__17 _003CLoadJoinRequests_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<List<GuildJoinRequest>>>, _003CLoadJoinRequests_003Ed__17>(ref awaiter, ref _003CLoadJoinRequests_003Ed__);
							return;
						}
						goto IL_00da;
					}
				}
				goto end_IL_0007;
				IL_00da:
				_003C_003Es__4 = awaiter.GetResult();
				_003Cresult_003E5__3 = _003C_003Es__4;
				_003C_003Es__4 = null;
				if (_003Cresult_003E5__3.Success)
				{
					_003C_003E4__this.SearchResults = new ObservableCollection<GuildJoinRequest>(_003Cresult_003E5__3.Data ?? new List<GuildJoinRequest>());
					_003C_003E4__this.HasSearched = true;
					_003C_003E4__this.HasResults = ((Collection<GuildJoinRequest>)(object)_003C_003E4__this.SearchResults).Count > 0;
					if (!_003C_003E4__this.HasResults)
					{
						_003C_003E4__this.ErrorMessage = "No pending join requests";
					}
				}
				else
				{
					_003C_003E4__this.ErrorMessage = _003Cresult_003E5__3.ErrorMessage ?? "Failed to load join requests";
					_003C_003E4__this.HasSearched = true;
					_003C_003E4__this.HasResults = false;
				}
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cplayer_003E5__1 = null;
				_003Crequest_003E5__2 = null;
				_003Cresult_003E5__3 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cplayer_003E5__1 = null;
			_003Crequest_003E5__2 = null;
			_003Cresult_003E5__3 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CSearchPlayers_003Ed__18 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public InvitePlayerPopupViewModel _003C_003E4__this;

		private Player _003CcurrentPlayer_003E5__1;

		private SearchPlayersRequest _003Crequest_003E5__2;

		private Result<List<PlayerSearchResultModel>> _003Cresult_003E5__3;

		private Result<List<PlayerSearchResultModel>> _003C_003Es__4;

		private List<GuildJoinRequest> _003CjoinRequests_003E5__5;

		private global::System.Exception _003Cex_003E5__6;

		private TaskAwaiter<Result<List<PlayerSearchResultModel>>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0147: Unknown result type (might be due to invalid IL or missing references)
			//IL_014c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			//IL_010d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0112: Unknown result type (might be due to invalid IL or missing references)
			//IL_0127: Unknown result type (might be due to invalid IL or missing references)
			//IL_0129: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num != 0 && (string.IsNullOrWhiteSpace(_003C_003E4__this.SearchText) || _003C_003E4__this.SearchText.Length < 2))
				{
					_003C_003E4__this.ErrorMessage = "Please enter at least 2 characters to search";
				}
				else
				{
					try
					{
						TaskAwaiter<Result<List<PlayerSearchResultModel>>> awaiter;
						if (num == 0)
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<Result<List<PlayerSearchResultModel>>>);
							num = (_003C_003E1__state = -1);
							goto IL_0163;
						}
						_003C_003E4__this.IsSearching = true;
						_003C_003E4__this.ErrorMessage = string.Empty;
						if (!_003C_003E4__this.IsInviteMode)
						{
							goto IL_0249;
						}
						_003CcurrentPlayer_003E5__1 = _003C_003E4__this._playerStateService.GetCurrentPlayer();
						if (_003CcurrentPlayer_003E5__1 != null)
						{
							_003Crequest_003E5__2 = new SearchPlayersRequest(_003C_003E4__this.SearchText, _003C_003E4__this.GuildId, _003CcurrentPlayer_003E5__1.PlayerID);
							awaiter = _003C_003E4__this._searchPlayersUseCase.ExecuteAsync(_003Crequest_003E5__2).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CSearchPlayers_003Ed__18 _003CSearchPlayers_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<List<PlayerSearchResultModel>>>, _003CSearchPlayers_003Ed__18>(ref awaiter, ref _003CSearchPlayers_003Ed__);
								return;
							}
							goto IL_0163;
						}
						_003C_003E4__this.ErrorMessage = "Player not found";
						goto end_IL_0053;
						IL_0249:
						_003C_003E4__this.HasSearched = true;
						_003C_003E4__this.HasResults = ((Collection<GuildJoinRequest>)(object)_003C_003E4__this.SearchResults).Count > 0;
						if (!_003C_003E4__this.HasResults && string.IsNullOrEmpty(_003C_003E4__this.ErrorMessage))
						{
							_003C_003E4__this.ErrorMessage = "No players found matching your search";
						}
						goto end_IL_0053;
						IL_0163:
						_003C_003Es__4 = awaiter.GetResult();
						_003Cresult_003E5__3 = _003C_003Es__4;
						_003C_003Es__4 = null;
						if (_003Cresult_003E5__3.Success)
						{
							List<PlayerSearchResultModel>? data = _003Cresult_003E5__3.Data;
							_003CjoinRequests_003E5__5 = ((data != null) ? Enumerable.ToList<GuildJoinRequest>(Enumerable.Select<PlayerSearchResultModel, GuildJoinRequest>((global::System.Collections.Generic.IEnumerable<PlayerSearchResultModel>)data, (Func<PlayerSearchResultModel, GuildJoinRequest>)((PlayerSearchResultModel p) => new GuildJoinRequest
							{
								PlayerId = p.PlayerId,
								PlayerName = p.PlayerName,
								PlayerLevel = p.Level,
								PlayerTrophies = p.Trophies,
								Message = string.Empty,
								Status = JoinRequestStatus.Pending,
								CreatedAt = null,
								ReviewedByPlayerId = string.Empty,
								ReviewedAt = null
							}))) : null) ?? new List<GuildJoinRequest>();
							_003C_003E4__this.SearchResults = new ObservableCollection<GuildJoinRequest>(_003CjoinRequests_003E5__5);
							_003CjoinRequests_003E5__5 = null;
						}
						else
						{
							_003C_003E4__this.ErrorMessage = _003Cresult_003E5__3.ErrorMessage ?? "Failed to search players";
							((Collection<GuildJoinRequest>)(object)_003C_003E4__this.SearchResults).Clear();
						}
						_003CcurrentPlayer_003E5__1 = null;
						_003Crequest_003E5__2 = null;
						_003Cresult_003E5__3 = null;
						goto IL_0249;
						end_IL_0053:;
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__6 = ex;
						_003C_003E4__this.ErrorMessage = "Failed to search players";
						Console.WriteLine($"SearchPlayers error: {_003Cex_003E5__6}");
					}
					finally
					{
						if (num < 0)
						{
							_003C_003E4__this.IsSearching = false;
						}
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
	private sealed class _003CSendInvitation_003Ed__19 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildJoinRequest player;

		public InvitePlayerPopupViewModel _003C_003E4__this;

		private Player _003CcurrentPlayer_003E5__1;

		private GuildInvitationRequest _003Crequest_003E5__2;

		private Result<GuildInvitationResult> _003Cresult_003E5__3;

		private Result<GuildInvitationResult> _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter<Result<GuildInvitationResult>> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0102: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0275: Unknown result type (might be due to invalid IL or missing references)
			//IL_027a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0282: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_017c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_023b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0240: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_0196: Unknown result type (might be due to invalid IL or missing references)
			//IL_0198: Unknown result type (might be due to invalid IL or missing references)
			//IL_0255: Unknown result type (might be due to invalid IL or missing references)
			//IL_0257: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 2u || (player != null && !string.IsNullOrEmpty(_003C_003E4__this.GuildId)))
				{
					try
					{
						TaskAwaiter<Result<GuildInvitationResult>> awaiter3;
						TaskAwaiter awaiter2;
						TaskAwaiter awaiter;
						switch (num)
						{
						default:
							_003CcurrentPlayer_003E5__1 = _003C_003E4__this._playerStateService.GetCurrentPlayer();
							if (_003CcurrentPlayer_003E5__1 != null)
							{
								_003Crequest_003E5__2 = new GuildInvitationRequest(_003C_003E4__this.GuildId, _003CcurrentPlayer_003E5__1.PlayerID, InvitationAction.SendInvitation, player.PlayerId);
								awaiter3 = _003C_003E4__this._manageInvitationsUseCase.ExecuteAsync(_003Crequest_003E5__2).GetAwaiter();
								if (!awaiter3.IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter3;
									_003CSendInvitation_003Ed__19 _003CSendInvitation_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<GuildInvitationResult>>, _003CSendInvitation_003Ed__19>(ref awaiter3, ref _003CSendInvitation_003Ed__);
									return;
								}
								goto IL_0118;
							}
							goto end_IL_0035;
						case 0:
							awaiter3 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<Result<GuildInvitationResult>>);
							num = (_003C_003E1__state = -1);
							goto IL_0118;
						case 1:
							awaiter2 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_01d2;
						case 2:
							{
								awaiter = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_0291;
							}
							IL_01d2:
							((TaskAwaiter)(ref awaiter2)).GetResult();
							((Collection<GuildJoinRequest>)(object)_003C_003E4__this.SearchResults).Remove(player);
							_003C_003E4__this.HasResults = ((Collection<GuildJoinRequest>)(object)_003C_003E4__this.SearchResults).Count > 0;
							if (!_003C_003E4__this.HasResults)
							{
								awaiter = _003C_003E4__this._popupService.ClosePopupAsync((object)true).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
								{
									num = (_003C_003E1__state = 2);
									_003C_003Eu__2 = awaiter;
									_003CSendInvitation_003Ed__19 _003CSendInvitation_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSendInvitation_003Ed__19>(ref awaiter, ref _003CSendInvitation_003Ed__);
									return;
								}
								goto IL_0291;
							}
							break;
							IL_0291:
							((TaskAwaiter)(ref awaiter)).GetResult();
							break;
							IL_0118:
							_003C_003Es__4 = awaiter3.GetResult();
							_003Cresult_003E5__3 = _003C_003Es__4;
							_003C_003Es__4 = null;
							if (_003Cresult_003E5__3.Success)
							{
								awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Invitation Sent", "Guild invitation sent to " + player.PlayerName + "!").GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__2 = awaiter2;
									_003CSendInvitation_003Ed__19 _003CSendInvitation_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSendInvitation_003Ed__19>(ref awaiter2, ref _003CSendInvitation_003Ed__);
									return;
								}
								goto IL_01d2;
							}
							_003C_003E4__this.ErrorMessage = _003Cresult_003E5__3.ErrorMessage ?? "Failed to send invitation.";
							break;
						}
						_003CcurrentPlayer_003E5__1 = null;
						_003Crequest_003E5__2 = null;
						_003Cresult_003E5__3 = null;
						end_IL_0035:;
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__5 = ex;
						_003C_003E4__this.ErrorMessage = "An error occurred while sending the invitation";
						Console.WriteLine($"SendInvitation error: {_003Cex_003E5__5}");
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

	private readonly IGuildStateService _guildStateService;

	private readonly IPlayerStateService _playerStateService;

	private readonly IPopupService _popupService;

	private readonly INavigationService _navigationService;

	private readonly ManageGuildInvitationsUseCase _manageInvitationsUseCase;

	private readonly GetPendingJoinRequestsUseCase _getPendingJoinRequestsUseCase;

	private readonly SearchPlayersUseCase _searchPlayersUseCase;

	[ObservableProperty]
	private string _searchText = string.Empty;

	[ObservableProperty]
	private ObservableCollection<GuildJoinRequest> _searchResults = new ObservableCollection<GuildJoinRequest>();

	[ObservableProperty]
	private bool _isSearching;

	[ObservableProperty]
	private bool _hasSearched;

	[ObservableProperty]
	private bool _hasResults;

	[ObservableProperty]
	private string _errorMessage = string.Empty;

	[ObservableProperty]
	private string? _guildId;

	[ObservableProperty]
	private string? _guildName;

	[ObservableProperty]
	private bool _isInviteMode;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? searchPlayersCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<GuildJoinRequest>? sendInvitationCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<GuildJoinRequest>? acceptJoinRequestCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<GuildJoinRequest>? declineJoinRequestCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? clearSearchCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<bool?>? closeCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string SearchText
	{
		get
		{
			return _searchText;
		}
		[MemberNotNull("_searchText")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_searchText, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.SearchText);
				_searchText = value;
				OnSearchTextChanged(value);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SearchText);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ObservableCollection<GuildJoinRequest> SearchResults
	{
		get
		{
			return _searchResults;
		}
		[MemberNotNull("_searchResults")]
		set
		{
			if (!EqualityComparer<ObservableCollection<GuildJoinRequest>>.Default.Equals(_searchResults, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.SearchResults);
				_searchResults = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SearchResults);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsSearching
	{
		get
		{
			return _isSearching;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isSearching, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsSearching);
				_isSearching = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsSearching);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool HasSearched
	{
		get
		{
			return _hasSearched;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_hasSearched, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HasSearched);
				_hasSearched = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HasSearched);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool HasResults
	{
		get
		{
			return _hasResults;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_hasResults, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HasResults);
				_hasResults = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HasResults);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string ErrorMessage
	{
		get
		{
			return _errorMessage;
		}
		[MemberNotNull("_errorMessage")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_errorMessage, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ErrorMessage);
				_errorMessage = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ErrorMessage);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string? GuildId
	{
		get
		{
			return _guildId;
		}
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_guildId, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.GuildId);
				_guildId = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.GuildId);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string? GuildName
	{
		get
		{
			return _guildName;
		}
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_guildName, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.GuildName);
				_guildName = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.GuildName);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsInviteMode
	{
		get
		{
			return _isInviteMode;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isInviteMode, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsInviteMode);
				_isInviteMode = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsInviteMode);
			}
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
	public IAsyncRelayCommand<GuildJoinRequest> SendInvitationCommand => (IAsyncRelayCommand<GuildJoinRequest>)(object)(sendInvitationCommand ?? (sendInvitationCommand = new AsyncRelayCommand<GuildJoinRequest>((Func<GuildJoinRequest, global::System.Threading.Tasks.Task>)SendInvitation)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<GuildJoinRequest> AcceptJoinRequestCommand => (IAsyncRelayCommand<GuildJoinRequest>)(object)(acceptJoinRequestCommand ?? (acceptJoinRequestCommand = new AsyncRelayCommand<GuildJoinRequest>((Func<GuildJoinRequest, global::System.Threading.Tasks.Task>)AcceptJoinRequest)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<GuildJoinRequest> DeclineJoinRequestCommand => (IAsyncRelayCommand<GuildJoinRequest>)(object)(declineJoinRequestCommand ?? (declineJoinRequestCommand = new AsyncRelayCommand<GuildJoinRequest>((Func<GuildJoinRequest, global::System.Threading.Tasks.Task>)DeclineJoinRequest)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand ClearSearchCommand
	{
		get
		{
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Expected O, but got Unknown
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			RelayCommand obj = clearSearchCommand;
			if (obj == null)
			{
				RelayCommand val = new RelayCommand(new Action(ClearSearch));
				RelayCommand val2 = val;
				clearSearchCommand = val;
				obj = val2;
			}
			return (IRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<bool?> CloseCommand => (IAsyncRelayCommand<bool?>)(object)(closeCommand ?? (closeCommand = new AsyncRelayCommand<bool?>((Func<bool?, global::System.Threading.Tasks.Task>)Close)));

	public InvitePlayerPopupViewModel(IGuildStateService guildStateService, IPlayerStateService playerStateService, IPopupService popupService, INavigationService navigationService, ManageGuildInvitationsUseCase manageInvitationsUseCase, GetPendingJoinRequestsUseCase getPendingJoinRequestsUseCase, SearchPlayersUseCase searchPlayersUseCase)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		_guildStateService = guildStateService ?? throw new ArgumentNullException("guildStateService");
		_playerStateService = playerStateService ?? throw new ArgumentNullException("playerStateService");
		_popupService = popupService ?? throw new ArgumentNullException("popupService");
		_navigationService = navigationService ?? throw new ArgumentNullException("navigationService");
		_manageInvitationsUseCase = manageInvitationsUseCase ?? throw new ArgumentNullException("manageInvitationsUseCase");
		_getPendingJoinRequestsUseCase = getPendingJoinRequestsUseCase ?? throw new ArgumentNullException("getPendingJoinRequestsUseCase");
		_searchPlayersUseCase = searchPlayersUseCase ?? throw new ArgumentNullException("searchPlayersUseCase");
	}

	[AsyncStateMachine(typeof(_003CLoadJoinRequests_003Ed__17))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task LoadJoinRequests(bool isInviteMode)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadJoinRequests_003Ed__17 _003CLoadJoinRequests_003Ed__ = new _003CLoadJoinRequests_003Ed__17();
		_003CLoadJoinRequests_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadJoinRequests_003Ed__._003C_003E4__this = this;
		_003CLoadJoinRequests_003Ed__.isInviteMode = isInviteMode;
		_003CLoadJoinRequests_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadJoinRequests_003Ed__._003C_003Et__builder)).Start<_003CLoadJoinRequests_003Ed__17>(ref _003CLoadJoinRequests_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadJoinRequests_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CSearchPlayers_003Ed__18))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task SearchPlayers()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CSearchPlayers_003Ed__18 _003CSearchPlayers_003Ed__ = new _003CSearchPlayers_003Ed__18();
		_003CSearchPlayers_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CSearchPlayers_003Ed__._003C_003E4__this = this;
		_003CSearchPlayers_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CSearchPlayers_003Ed__._003C_003Et__builder)).Start<_003CSearchPlayers_003Ed__18>(ref _003CSearchPlayers_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CSearchPlayers_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CSendInvitation_003Ed__19))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task SendInvitation(GuildJoinRequest player)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CSendInvitation_003Ed__19 _003CSendInvitation_003Ed__ = new _003CSendInvitation_003Ed__19();
		_003CSendInvitation_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CSendInvitation_003Ed__._003C_003E4__this = this;
		_003CSendInvitation_003Ed__.player = player;
		_003CSendInvitation_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CSendInvitation_003Ed__._003C_003Et__builder)).Start<_003CSendInvitation_003Ed__19>(ref _003CSendInvitation_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CSendInvitation_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CAcceptJoinRequest_003Ed__20))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task AcceptJoinRequest(GuildJoinRequest joinRequest)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CAcceptJoinRequest_003Ed__20 _003CAcceptJoinRequest_003Ed__ = new _003CAcceptJoinRequest_003Ed__20();
		_003CAcceptJoinRequest_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CAcceptJoinRequest_003Ed__._003C_003E4__this = this;
		_003CAcceptJoinRequest_003Ed__.joinRequest = joinRequest;
		_003CAcceptJoinRequest_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CAcceptJoinRequest_003Ed__._003C_003Et__builder)).Start<_003CAcceptJoinRequest_003Ed__20>(ref _003CAcceptJoinRequest_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CAcceptJoinRequest_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CDeclineJoinRequest_003Ed__21))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task DeclineJoinRequest(GuildJoinRequest joinRequest)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CDeclineJoinRequest_003Ed__21 _003CDeclineJoinRequest_003Ed__ = new _003CDeclineJoinRequest_003Ed__21();
		_003CDeclineJoinRequest_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CDeclineJoinRequest_003Ed__._003C_003E4__this = this;
		_003CDeclineJoinRequest_003Ed__.joinRequest = joinRequest;
		_003CDeclineJoinRequest_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CDeclineJoinRequest_003Ed__._003C_003Et__builder)).Start<_003CDeclineJoinRequest_003Ed__21>(ref _003CDeclineJoinRequest_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CDeclineJoinRequest_003Ed__._003C_003Et__builder)).Task;
	}

	[RelayCommand]
	private void ClearSearch()
	{
		SearchText = string.Empty;
		((Collection<GuildJoinRequest>)(object)SearchResults).Clear();
		HasSearched = false;
		HasResults = false;
		ErrorMessage = string.Empty;
	}

	[AsyncStateMachine(typeof(_003CClose_003Ed__23))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task Close(bool? result = null)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CClose_003Ed__23 _003CClose_003Ed__ = new _003CClose_003Ed__23();
		_003CClose_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CClose_003Ed__._003C_003E4__this = this;
		_003CClose_003Ed__.result = result;
		_003CClose_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CClose_003Ed__._003C_003Et__builder)).Start<_003CClose_003Ed__23>(ref _003CClose_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CClose_003Ed__._003C_003Et__builder)).Task;
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnSearchTextChanged(string value)
	{
		if (!string.IsNullOrEmpty(ErrorMessage))
		{
			ErrorMessage = string.Empty;
		}
		if (value.Length < 2)
		{
		}
	}
}
