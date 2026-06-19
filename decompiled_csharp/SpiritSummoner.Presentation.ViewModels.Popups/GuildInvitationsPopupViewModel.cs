using System;
using System.CodeDom.Compiler;
using System.Collections;
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
using SpiritSummoner.Domain.Entities.Guilds;
using SpiritSummoner.Presentation.Navigation;

namespace SpiritSummoner.Presentation.ViewModels.Popups;

public class GuildInvitationsPopupViewModel : ObservableObject
{
	[CompilerGenerated]
	private sealed class _003CAcceptInvitation_003Ed__13 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildInvitation invitation;

		public GuildInvitationsPopupViewModel _003C_003E4__this;

		private string _003CplayerId_003E5__1;

		private Result<bool> _003Cresult_003E5__2;

		private Result<bool> _003C_003Es__3;

		private global::System.Exception _003Cex_003E5__4;

		private TaskAwaiter<Result<bool>> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_023d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0242: Unknown result type (might be due to invalid IL or missing references)
			//IL_024a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0203: Unknown result type (might be due to invalid IL or missing references)
			//IL_0208: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_018f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0194: Unknown result type (might be due to invalid IL or missing references)
			//IL_021d: Unknown result type (might be due to invalid IL or missing references)
			//IL_021f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 2u || invitation != null)
				{
					try
					{
						TaskAwaiter<Result<bool>> awaiter3;
						TaskAwaiter awaiter2;
						TaskAwaiter awaiter;
						switch (num)
						{
						default:
							_003CplayerId_003E5__1 = _003C_003E4__this._playerState.CurrentPlayerId;
							if (!string.IsNullOrEmpty(_003CplayerId_003E5__1))
							{
								awaiter3 = _003C_003E4__this._acceptInvitationUseCase.ExecuteAsync(new AcceptInvitationRequest(invitation.ID, invitation.GuildId, _003CplayerId_003E5__1)).GetAwaiter();
								if (!awaiter3.IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter3;
									_003CAcceptInvitation_003Ed__13 _003CAcceptInvitation_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<bool>>, _003CAcceptInvitation_003Ed__13>(ref awaiter3, ref _003CAcceptInvitation_003Ed__);
									return;
								}
								goto IL_00f5;
							}
							goto end_IL_0023;
						case 0:
							awaiter3 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<Result<bool>>);
							num = (_003C_003E1__state = -1);
							goto IL_00f5;
						case 1:
							awaiter2 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_01e5;
						case 2:
							{
								awaiter = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_0259;
							}
							IL_01e5:
							((TaskAwaiter)(ref awaiter2)).GetResult();
							awaiter = _003C_003E4__this._popupService.ClosePopupAsync((object)true).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__2 = awaiter;
								_003CAcceptInvitation_003Ed__13 _003CAcceptInvitation_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CAcceptInvitation_003Ed__13>(ref awaiter, ref _003CAcceptInvitation_003Ed__);
								return;
							}
							goto IL_0259;
							IL_0259:
							((TaskAwaiter)(ref awaiter)).GetResult();
							break;
							IL_00f5:
							_003C_003Es__3 = awaiter3.GetResult();
							_003Cresult_003E5__2 = _003C_003Es__3;
							_003C_003Es__3 = null;
							if (_003Cresult_003E5__2.Success)
							{
								((Collection<GuildInvitation>)(object)_003C_003E4__this.Invitations).Remove(invitation);
								_003C_003E4__this.HasInvitations = ((Collection<GuildInvitation>)(object)_003C_003E4__this.Invitations).Count > 0;
								awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Sucess!", "You just joined the guild " + invitation.GuildName + "!").GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__2 = awaiter2;
									_003CAcceptInvitation_003Ed__13 _003CAcceptInvitation_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CAcceptInvitation_003Ed__13>(ref awaiter2, ref _003CAcceptInvitation_003Ed__);
									return;
								}
								goto IL_01e5;
							}
							_003C_003E4__this.ErrorMessage = _003Cresult_003E5__2.ErrorMessage ?? "Failed to accept invitation. It may have expired.";
							break;
						}
						_003CplayerId_003E5__1 = null;
						_003Cresult_003E5__2 = null;
						end_IL_0023:;
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__4 = ex;
						_003C_003E4__this.ErrorMessage = "An error occurred while accepting the invitation";
						Console.WriteLine($"AcceptInvitation error: {_003Cex_003E5__4}");
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
	private sealed class _003CClose_003Ed__15 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildInvitationsPopupViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = _003C_003E4__this._popupService.ClosePopupAsync((object)null).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CClose_003Ed__15 _003CClose_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CClose_003Ed__15>(ref awaiter, ref _003CClose_003Ed__);
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
	private sealed class _003CDeclineInvitation_003Ed__14 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildInvitation invitation;

		public GuildInvitationsPopupViewModel _003C_003E4__this;

		private string _003CplayerId_003E5__1;

		private bool _003Cconfirmed_003E5__2;

		private Result<bool> _003Cresult_003E5__3;

		private bool _003C_003Es__4;

		private Result<bool> _003C_003Es__5;

		private global::System.Exception _003Cex_003E5__6;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private TaskAwaiter<Result<bool>> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0142: Unknown result type (might be due to invalid IL or missing references)
			//IL_0147: Unknown result type (might be due to invalid IL or missing references)
			//IL_017c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0189: Unknown result type (might be due to invalid IL or missing references)
			//IL_015c: Unknown result type (might be due to invalid IL or missing references)
			//IL_015e: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 1u || invitation != null)
				{
					try
					{
						TaskAwaiter<bool> awaiter;
						if (num == 0)
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<bool>);
							num = (_003C_003E1__state = -1);
							goto IL_00ef;
						}
						TaskAwaiter<Result<bool>> awaiter2;
						if (num == 1)
						{
							awaiter2 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<Result<bool>>);
							num = (_003C_003E1__state = -1);
							goto IL_0198;
						}
						_003CplayerId_003E5__1 = _003C_003E4__this._playerState.CurrentPlayerId;
						if (!string.IsNullOrEmpty(_003CplayerId_003E5__1))
						{
							awaiter = _003C_003E4__this._navigationService.ShowConfirmationAsync("Decline Invitation", "Are you sure you want to decline the invitation from " + invitation.GuildName + "?").GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CDeclineInvitation_003Ed__14 _003CDeclineInvitation_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CDeclineInvitation_003Ed__14>(ref awaiter, ref _003CDeclineInvitation_003Ed__);
								return;
							}
							goto IL_00ef;
						}
						goto end_IL_0023;
						IL_0198:
						_003C_003Es__5 = awaiter2.GetResult();
						_003Cresult_003E5__3 = _003C_003Es__5;
						_003C_003Es__5 = null;
						if (_003Cresult_003E5__3.Success)
						{
							((Collection<GuildInvitation>)(object)_003C_003E4__this.Invitations).Remove(invitation);
							_003C_003E4__this.HasInvitations = ((Collection<GuildInvitation>)(object)_003C_003E4__this.Invitations).Count > 0;
						}
						else
						{
							_003C_003E4__this.ErrorMessage = _003Cresult_003E5__3.ErrorMessage ?? "Failed to decline invitation";
						}
						_003CplayerId_003E5__1 = null;
						_003Cresult_003E5__3 = null;
						goto end_IL_0023;
						IL_00ef:
						_003C_003Es__4 = awaiter.GetResult();
						_003Cconfirmed_003E5__2 = _003C_003Es__4;
						if (_003Cconfirmed_003E5__2)
						{
							awaiter2 = _003C_003E4__this._declineInvitationUseCase.ExecuteAsync(new DeclineInvitationRequest(invitation.ID, _003CplayerId_003E5__1)).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__2 = awaiter2;
								_003CDeclineInvitation_003Ed__14 _003CDeclineInvitation_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<bool>>, _003CDeclineInvitation_003Ed__14>(ref awaiter2, ref _003CDeclineInvitation_003Ed__);
								return;
							}
							goto IL_0198;
						}
						end_IL_0023:;
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__6 = ex;
						_003C_003E4__this.ErrorMessage = "An error occurred while declining the invitation";
						Console.WriteLine($"DeclineInvitation error: {_003Cex_003E5__6}");
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
	private sealed class _003CInitializeAsync_003Ed__11 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildInvitationsPopupViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = _003C_003E4__this.LoadInvitationsAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CInitializeAsync_003Ed__11 _003CInitializeAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CInitializeAsync_003Ed__11>(ref awaiter, ref _003CInitializeAsync_003Ed__);
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
	private sealed class _003CLoadInvitationsAsync_003Ed__12 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildInvitationsPopupViewModel _003C_003E4__this;

		private string _003CplayerId_003E5__1;

		private Result<List<GuildInvitation>> _003Cresult_003E5__2;

		private Result<List<GuildInvitation>> _003C_003Es__3;

		private global::System.Collections.Generic.IEnumerator<GuildInvitation> _003C_003Es__4;

		private GuildInvitation _003Cinvitation_003E5__5;

		private global::System.Exception _003Cex_003E5__6;

		private TaskAwaiter<Result<List<GuildInvitation>>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<Result<List<GuildInvitation>>> awaiter;
					if (num == 0)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Result<List<GuildInvitation>>>);
						num = (_003C_003E1__state = -1);
						goto IL_00e2;
					}
					_003C_003E4__this.IsLoading = true;
					_003C_003E4__this.ErrorMessage = string.Empty;
					_003CplayerId_003E5__1 = _003C_003E4__this._playerState.CurrentPlayerId;
					if (!string.IsNullOrEmpty(_003CplayerId_003E5__1))
					{
						awaiter = _003C_003E4__this._getPlayerInvitationsUseCase.ExecuteAsync(new GetPlayerInvitationsRequest(_003CplayerId_003E5__1)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CLoadInvitationsAsync_003Ed__12 _003CLoadInvitationsAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<List<GuildInvitation>>>, _003CLoadInvitationsAsync_003Ed__12>(ref awaiter, ref _003CLoadInvitationsAsync_003Ed__);
							return;
						}
						goto IL_00e2;
					}
					_003C_003E4__this.ErrorMessage = "Player not found";
					goto end_IL_0010;
					IL_00e2:
					_003C_003Es__3 = awaiter.GetResult();
					_003Cresult_003E5__2 = _003C_003Es__3;
					_003C_003Es__3 = null;
					if (!_003Cresult_003E5__2.Success)
					{
						_003C_003E4__this.ErrorMessage = _003Cresult_003E5__2.ErrorMessage ?? "Failed to load invitations";
					}
					else
					{
						((Collection<GuildInvitation>)(object)_003C_003E4__this.Invitations).Clear();
						_003C_003Es__4 = ((global::System.Collections.Generic.IEnumerable<GuildInvitation>)Enumerable.OrderByDescending<GuildInvitation, DateTimeOffset>((global::System.Collections.Generic.IEnumerable<GuildInvitation>)(_003Cresult_003E5__2.Data ?? new List<GuildInvitation>()), (Func<GuildInvitation, DateTimeOffset>)((GuildInvitation i) => i.CreatedAt))).GetEnumerator();
						try
						{
							while (((global::System.Collections.IEnumerator)_003C_003Es__4).MoveNext())
							{
								_003Cinvitation_003E5__5 = _003C_003Es__4.Current;
								((Collection<GuildInvitation>)(object)_003C_003E4__this.Invitations).Add(_003Cinvitation_003E5__5);
								_003Cinvitation_003E5__5 = null;
							}
						}
						finally
						{
							if (num < 0 && _003C_003Es__4 != null)
							{
								((global::System.IDisposable)_003C_003Es__4).Dispose();
							}
						}
						_003C_003Es__4 = null;
						_003C_003E4__this.HasInvitations = ((Collection<GuildInvitation>)(object)_003C_003E4__this.Invitations).Count > 0;
						_003CplayerId_003E5__1 = null;
						_003Cresult_003E5__2 = null;
					}
					end_IL_0010:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__6 = ex;
					_003C_003E4__this.ErrorMessage = "Failed to load invitations";
					Console.WriteLine($"LoadInvitations error: {_003Cex_003E5__6}");
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

	private readonly GetPlayerInvitationsUseCase _getPlayerInvitationsUseCase;

	private readonly AcceptInvitationUseCase _acceptInvitationUseCase;

	private readonly DeclineInvitationUseCase _declineInvitationUseCase;

	private readonly IPlayerStateService _playerState;

	private readonly IPopupService _popupService;

	private readonly INavigationService _navigationService;

	[ObservableProperty]
	private ObservableCollection<GuildInvitation> _invitations = new ObservableCollection<GuildInvitation>();

	[ObservableProperty]
	private bool _isLoading;

	[ObservableProperty]
	private bool _hasInvitations;

	[ObservableProperty]
	private string _errorMessage = string.Empty;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? loadInvitationsCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<GuildInvitation>? acceptInvitationCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<GuildInvitation>? declineInvitationCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? closeCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ObservableCollection<GuildInvitation> Invitations
	{
		get
		{
			return _invitations;
		}
		[MemberNotNull("_invitations")]
		set
		{
			if (!EqualityComparer<ObservableCollection<GuildInvitation>>.Default.Equals(_invitations, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Invitations);
				_invitations = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Invitations);
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
	public bool HasInvitations
	{
		get
		{
			return _hasInvitations;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_hasInvitations, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HasInvitations);
				_hasInvitations = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HasInvitations);
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

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand LoadInvitationsCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = loadInvitationsCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)LoadInvitationsAsync);
				AsyncRelayCommand val2 = val;
				loadInvitationsCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<GuildInvitation> AcceptInvitationCommand => (IAsyncRelayCommand<GuildInvitation>)(object)(acceptInvitationCommand ?? (acceptInvitationCommand = new AsyncRelayCommand<GuildInvitation>((Func<GuildInvitation, global::System.Threading.Tasks.Task>)AcceptInvitation)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<GuildInvitation> DeclineInvitationCommand => (IAsyncRelayCommand<GuildInvitation>)(object)(declineInvitationCommand ?? (declineInvitationCommand = new AsyncRelayCommand<GuildInvitation>((Func<GuildInvitation, global::System.Threading.Tasks.Task>)DeclineInvitation)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand CloseCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = closeCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)Close);
				AsyncRelayCommand val2 = val;
				closeCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	public GuildInvitationsPopupViewModel(GetPlayerInvitationsUseCase getPlayerInvitationsUseCase, AcceptInvitationUseCase acceptInvitationUseCase, DeclineInvitationUseCase declineInvitationUseCase, IPlayerStateService playerStateService, IPopupService popupService, INavigationService navigationService)
	{
		_getPlayerInvitationsUseCase = getPlayerInvitationsUseCase;
		_acceptInvitationUseCase = acceptInvitationUseCase;
		_declineInvitationUseCase = declineInvitationUseCase;
		_playerState = playerStateService;
		_popupService = popupService;
		_navigationService = navigationService;
	}

	[AsyncStateMachine(typeof(_003CInitializeAsync_003Ed__11))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task InitializeAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CInitializeAsync_003Ed__11 _003CInitializeAsync_003Ed__ = new _003CInitializeAsync_003Ed__11();
		_003CInitializeAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CInitializeAsync_003Ed__._003C_003E4__this = this;
		_003CInitializeAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CInitializeAsync_003Ed__._003C_003Et__builder)).Start<_003CInitializeAsync_003Ed__11>(ref _003CInitializeAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CInitializeAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CLoadInvitationsAsync_003Ed__12))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task LoadInvitationsAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadInvitationsAsync_003Ed__12 _003CLoadInvitationsAsync_003Ed__ = new _003CLoadInvitationsAsync_003Ed__12();
		_003CLoadInvitationsAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadInvitationsAsync_003Ed__._003C_003E4__this = this;
		_003CLoadInvitationsAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadInvitationsAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadInvitationsAsync_003Ed__12>(ref _003CLoadInvitationsAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadInvitationsAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CAcceptInvitation_003Ed__13))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task AcceptInvitation(GuildInvitation invitation)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CAcceptInvitation_003Ed__13 _003CAcceptInvitation_003Ed__ = new _003CAcceptInvitation_003Ed__13();
		_003CAcceptInvitation_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CAcceptInvitation_003Ed__._003C_003E4__this = this;
		_003CAcceptInvitation_003Ed__.invitation = invitation;
		_003CAcceptInvitation_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CAcceptInvitation_003Ed__._003C_003Et__builder)).Start<_003CAcceptInvitation_003Ed__13>(ref _003CAcceptInvitation_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CAcceptInvitation_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CDeclineInvitation_003Ed__14))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task DeclineInvitation(GuildInvitation invitation)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CDeclineInvitation_003Ed__14 _003CDeclineInvitation_003Ed__ = new _003CDeclineInvitation_003Ed__14();
		_003CDeclineInvitation_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CDeclineInvitation_003Ed__._003C_003E4__this = this;
		_003CDeclineInvitation_003Ed__.invitation = invitation;
		_003CDeclineInvitation_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CDeclineInvitation_003Ed__._003C_003Et__builder)).Start<_003CDeclineInvitation_003Ed__14>(ref _003CDeclineInvitation_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CDeclineInvitation_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CClose_003Ed__15))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task Close()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CClose_003Ed__15 _003CClose_003Ed__ = new _003CClose_003Ed__15();
		_003CClose_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CClose_003Ed__._003C_003E4__this = this;
		_003CClose_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CClose_003Ed__._003C_003Et__builder)).Start<_003CClose_003Ed__15>(ref _003CClose_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CClose_003Ed__._003C_003Et__builder)).Task;
	}
}
