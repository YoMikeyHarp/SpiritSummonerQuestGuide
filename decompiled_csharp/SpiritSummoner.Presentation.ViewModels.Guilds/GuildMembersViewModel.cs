using System;
using System.CodeDom.Compiler;
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
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Application.UseCases.Guilds;
using SpiritSummoner.Domain.Entities.Guilds;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Enums.Guilds;
using SpiritSummoner.Infrastructure.Cache;
using SpiritSummoner.Presentation.Navigation;
using SpiritSummoner.Presentation.ViewModels.Popups;

namespace SpiritSummoner.Presentation.ViewModels.Guilds;

public class GuildMembersViewModel : ObservableObject, ILoadableViewModel, global::System.IDisposable
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass39_0
	{
		public GuildMembersViewModel _003C_003E4__this;

		public string parameter;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass39_1
	{
		private sealed class _003C_003COpenInvitePlayer_003Eb__0_003Ed : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public InvitePlayerPopupViewModel vm;

			public _003C_003Ec__DisplayClass39_1 _003C_003E4__this;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
				//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
				//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
				//IL_00da: Unknown result type (might be due to invalid IL or missing references)
				//IL_009a: Unknown result type (might be due to invalid IL or missing references)
				//IL_009f: Unknown result type (might be due to invalid IL or missing references)
				//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
				//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						vm.GuildId = _003C_003E4__this.CS_0024_003C_003E8__locals1._003C_003E4__this.GuildId;
						vm.GuildName = _003C_003E4__this.guild.Name;
						vm.IsInviteMode = _003C_003E4__this.CS_0024_003C_003E8__locals1.parameter == "send";
						awaiter = vm.LoadJoinRequests(_003C_003E4__this.CS_0024_003C_003E8__locals1.parameter == "send").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003C_003COpenInvitePlayer_003Eb__0_003Ed _003C_003COpenInvitePlayer_003Eb__0_003Ed = this;
							((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003C_003COpenInvitePlayer_003Eb__0_003Ed>(ref awaiter, ref _003C_003COpenInvitePlayer_003Eb__0_003Ed);
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

		public Guild guild;

		public _003C_003Ec__DisplayClass39_0 CS_0024_003C_003E8__locals1;

		[AsyncStateMachine(typeof(_003C_003COpenInvitePlayer_003Eb__0_003Ed))]
		[DebuggerStepThrough]
		internal void _003COpenInvitePlayer_003Eb__0(InvitePlayerPopupViewModel vm)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003COpenInvitePlayer_003Eb__0_003Ed _003C_003COpenInvitePlayer_003Eb__0_003Ed = new _003C_003COpenInvitePlayer_003Eb__0_003Ed
			{
				_003C_003Et__builder = AsyncVoidMethodBuilder.Create(),
				_003C_003E4__this = this,
				vm = vm,
				_003C_003E1__state = -1
			};
			((AsyncVoidMethodBuilder)(ref _003C_003COpenInvitePlayer_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003COpenInvitePlayer_003Eb__0_003Ed>(ref _003C_003COpenInvitePlayer_003Eb__0_003Ed);
		}
	}

	[CompilerGenerated]
	private sealed class _003CDemoteMember_003Ed__41 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildMember member;

		public GuildMembersViewModel _003C_003E4__this;

		private Player _003Cplayer_003E5__1;

		private object _003C_003Es__2;

		private int _003C_003Es__3;

		private bool _003Cconfirmed_003E5__4;

		private ManageGuildMembersRequest _003Crequest_003E5__5;

		private Result<Guild> _003Cresult_003E5__6;

		private bool _003C_003Es__7;

		private Result<Guild> _003C_003Es__8;

		private global::System.Exception _003Cex_003E5__9;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<bool> _003C_003Eu__2;

		private TaskAwaiter<Result<Guild>> _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_0524: Unknown result type (might be due to invalid IL or missing references)
			//IL_0529: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_010f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_053e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0540: Unknown result type (might be due to invalid IL or missing references)
			//IL_055e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0563: Unknown result type (might be due to invalid IL or missing references)
			//IL_056b: Unknown result type (might be due to invalid IL or missing references)
			//IL_029f: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_035a: Unknown result type (might be due to invalid IL or missing references)
			//IL_035f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0367: Unknown result type (might be due to invalid IL or missing references)
			//IL_040f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0414: Unknown result type (might be due to invalid IL or missing references)
			//IL_041c: Unknown result type (might be due to invalid IL or missing references)
			//IL_049d: Unknown result type (might be due to invalid IL or missing references)
			//IL_04a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_04aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0265: Unknown result type (might be due to invalid IL or missing references)
			//IL_026a: Unknown result type (might be due to invalid IL or missing references)
			//IL_027f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0281: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0320: Unknown result type (might be due to invalid IL or missing references)
			//IL_0325: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_03da: Unknown result type (might be due to invalid IL or missing references)
			//IL_016f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0174: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_033a: Unknown result type (might be due to invalid IL or missing references)
			//IL_033c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0463: Unknown result type (might be due to invalid IL or missing references)
			//IL_0468: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0189: Unknown result type (might be due to invalid IL or missing references)
			//IL_018b: Unknown result type (might be due to invalid IL or missing references)
			//IL_047d: Unknown result type (might be due to invalid IL or missing references)
			//IL_047f: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter2;
				TaskAwaiter awaiter;
				switch (num)
				{
				default:
					if (member != null && _003C_003E4__this.CanPromoteMembers)
					{
						_003Cplayer_003E5__1 = _003C_003E4__this._playerStateService.GetCurrentPlayer();
						if (_003Cplayer_003E5__1 != null)
						{
							if (member.Role == GuildRole.Guildmaster && _003Cplayer_003E5__1.PlayerID != member.PlayerId)
							{
								awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Cannot demote!", "Only the Leader can demote self").GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter2;
									_003CDemoteMember_003Ed__41 _003CDemoteMember_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CDemoteMember_003Ed__41>(ref awaiter2, ref _003CDemoteMember_003Ed__);
									return;
								}
								goto IL_0126;
							}
							if (!(member.PlayerId == _003Cplayer_003E5__1.PlayerID))
							{
								break;
							}
							awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Cannot demote!", "You are the leader, promote other member to a leader to proceed.").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__1 = awaiter;
								_003CDemoteMember_003Ed__41 _003CDemoteMember_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CDemoteMember_003Ed__41>(ref awaiter, ref _003CDemoteMember_003Ed__);
								return;
							}
							goto IL_01c5;
						}
					}
					goto end_IL_0007;
				case 0:
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0126;
				case 1:
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_01c5;
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
					break;
					IL_01c5:
					((TaskAwaiter)(ref awaiter)).GetResult();
					goto end_IL_0007;
					IL_0126:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					goto end_IL_0007;
				}
				try
				{
					TaskAwaiter awaiter3;
					if ((uint)(num - 2) > 3u)
					{
						if (num == 6)
						{
							awaiter3 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_057a;
						}
						_003C_003Es__3 = 0;
					}
					try
					{
						TaskAwaiter<bool> awaiter7;
						TaskAwaiter<Result<Guild>> awaiter6;
						TaskAwaiter awaiter5;
						TaskAwaiter awaiter4;
						switch (num)
						{
						default:
							_003C_003E4__this.IsLoading = true;
							awaiter7 = _003C_003E4__this._navigationService.ShowConfirmationAsync("Demote Member", "Demote " + member.PlayerName + "?").GetAwaiter();
							if (!awaiter7.IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__2 = awaiter7;
								_003CDemoteMember_003Ed__41 _003CDemoteMember_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CDemoteMember_003Ed__41>(ref awaiter7, ref _003CDemoteMember_003Ed__);
								return;
							}
							goto IL_02bb;
						case 2:
							awaiter7 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<bool>);
							num = (_003C_003E1__state = -1);
							goto IL_02bb;
						case 3:
							awaiter6 = _003C_003Eu__3;
							_003C_003Eu__3 = default(TaskAwaiter<Result<Guild>>);
							num = (_003C_003E1__state = -1);
							goto IL_0376;
						case 4:
							awaiter5 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_042b;
						case 5:
							{
								awaiter4 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_04b9;
							}
							IL_0376:
							_003C_003Es__8 = awaiter6.GetResult();
							_003Cresult_003E5__6 = _003C_003Es__8;
							_003C_003Es__8 = null;
							if (_003Cresult_003E5__6.Success)
							{
								awaiter5 = _003C_003E4__this._navigationService.ShowAlertAsync("Member Demoted", member.PlayerName + " has been demoted.").GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter5)).IsCompleted)
								{
									num = (_003C_003E1__state = 4);
									_003C_003Eu__1 = awaiter5;
									_003CDemoteMember_003Ed__41 _003CDemoteMember_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CDemoteMember_003Ed__41>(ref awaiter5, ref _003CDemoteMember_003Ed__);
									return;
								}
								goto IL_042b;
							}
							awaiter4 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", _003Cresult_003E5__6.ErrorMessage ?? "Failed to demote member.").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
							{
								num = (_003C_003E1__state = 5);
								_003C_003Eu__1 = awaiter4;
								_003CDemoteMember_003Ed__41 _003CDemoteMember_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CDemoteMember_003Ed__41>(ref awaiter4, ref _003CDemoteMember_003Ed__);
								return;
							}
							goto IL_04b9;
							IL_02bb:
							_003C_003Es__7 = awaiter7.GetResult();
							_003Cconfirmed_003E5__4 = _003C_003Es__7;
							if (_003Cconfirmed_003E5__4)
							{
								_003Crequest_003E5__5 = new ManageGuildMembersRequest(_003C_003E4__this.GuildId, member.PlayerId, GuildMemberAction.Demote);
								awaiter6 = _003C_003E4__this._manageGuildMembersUseCase.ExecuteAsync(_003Crequest_003E5__5).GetAwaiter();
								if (!awaiter6.IsCompleted)
								{
									num = (_003C_003E1__state = 3);
									_003C_003Eu__3 = awaiter6;
									_003CDemoteMember_003Ed__41 _003CDemoteMember_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<Guild>>, _003CDemoteMember_003Ed__41>(ref awaiter6, ref _003CDemoteMember_003Ed__);
									return;
								}
								goto IL_0376;
							}
							goto end_IL_01f0;
							IL_042b:
							((TaskAwaiter)(ref awaiter5)).GetResult();
							break;
							IL_04b9:
							((TaskAwaiter)(ref awaiter4)).GetResult();
							break;
						}
						_003Crequest_003E5__5 = null;
						_003Cresult_003E5__6 = null;
						goto IL_04e6;
						end_IL_01f0:;
					}
					catch (global::System.Exception ex)
					{
						_003C_003Es__2 = ex;
						_003C_003Es__3 = 1;
						goto IL_04e6;
					}
					goto end_IL_01d3;
					IL_04e6:
					int num2 = _003C_003Es__3;
					if (num2 != 1)
					{
						goto IL_05be;
					}
					_003Cex_003E5__9 = (global::System.Exception)_003C_003Es__2;
					awaiter3 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "An error occurred while demoting the member.").GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
					{
						num = (_003C_003E1__state = 6);
						_003C_003Eu__1 = awaiter3;
						_003CDemoteMember_003Ed__41 _003CDemoteMember_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CDemoteMember_003Ed__41>(ref awaiter3, ref _003CDemoteMember_003Ed__);
						return;
					}
					goto IL_057a;
					IL_057a:
					((TaskAwaiter)(ref awaiter3)).GetResult();
					Console.WriteLine($"DemoteMember error: {_003Cex_003E5__9}");
					_003Cex_003E5__9 = null;
					goto IL_05be;
					IL_05be:
					_003C_003Es__2 = null;
					end_IL_01d3:;
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this.IsLoading = false;
					}
				}
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
	private sealed class _003CGoBack_003Ed__38 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildMembersViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = _003C_003E4__this._navigationService.GoBackAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CGoBack_003Ed__38 _003CGoBack_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoBack_003Ed__38>(ref awaiter, ref _003CGoBack_003Ed__);
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
	private sealed class _003CKickMember_003Ed__42 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildMember member;

		public GuildMembersViewModel _003C_003E4__this;

		private Player _003Cplayer_003E5__1;

		private object _003C_003Es__2;

		private int _003C_003Es__3;

		private bool _003Cconfirmed_003E5__4;

		private ManageGuildMembersRequest _003Crequest_003E5__5;

		private Result<Guild> _003Cresult_003E5__6;

		private bool _003C_003Es__7;

		private Result<Guild> _003C_003Es__8;

		private global::System.Exception _003Cex_003E5__9;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<bool> _003C_003Eu__2;

		private TaskAwaiter<Result<Guild>> _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_0506: Unknown result type (might be due to invalid IL or missing references)
			//IL_050b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_018b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0190: Unknown result type (might be due to invalid IL or missing references)
			//IL_0198: Unknown result type (might be due to invalid IL or missing references)
			//IL_0520: Unknown result type (might be due to invalid IL or missing references)
			//IL_0522: Unknown result type (might be due to invalid IL or missing references)
			//IL_0540: Unknown result type (might be due to invalid IL or missing references)
			//IL_0545: Unknown result type (might be due to invalid IL or missing references)
			//IL_054d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0281: Unknown result type (might be due to invalid IL or missing references)
			//IL_0286: Unknown result type (might be due to invalid IL or missing references)
			//IL_028e: Unknown result type (might be due to invalid IL or missing references)
			//IL_033c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0341: Unknown result type (might be due to invalid IL or missing references)
			//IL_0349: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_03fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_047f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0484: Unknown result type (might be due to invalid IL or missing references)
			//IL_048c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0247: Unknown result type (might be due to invalid IL or missing references)
			//IL_024c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0151: Unknown result type (might be due to invalid IL or missing references)
			//IL_0156: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_0261: Unknown result type (might be due to invalid IL or missing references)
			//IL_0263: Unknown result type (might be due to invalid IL or missing references)
			//IL_016b: Unknown result type (might be due to invalid IL or missing references)
			//IL_016d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0302: Unknown result type (might be due to invalid IL or missing references)
			//IL_0307: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_03bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_031c: Unknown result type (might be due to invalid IL or missing references)
			//IL_031e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0445: Unknown result type (might be due to invalid IL or missing references)
			//IL_044a: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_045f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0461: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter2;
				TaskAwaiter awaiter;
				switch (num)
				{
				default:
					if (member != null && _003C_003E4__this.IsPlayerOfficer)
					{
						_003Cplayer_003E5__1 = _003C_003E4__this._playerStateService.GetCurrentPlayer();
						if (_003Cplayer_003E5__1 != null)
						{
							if (member.Role == GuildRole.Guildmaster)
							{
								awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Cannot Remove", "Cannot remove the guild leader.").GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter2;
									_003CKickMember_003Ed__42 _003CKickMember_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CKickMember_003Ed__42>(ref awaiter2, ref _003CKickMember_003Ed__);
									return;
								}
								goto IL_0108;
							}
							if (!(member.PlayerId == _003Cplayer_003E5__1.PlayerID))
							{
								break;
							}
							awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Cannot Remove", "You cannot remove yourself. Use the Leave Guild option instead.").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__1 = awaiter;
								_003CKickMember_003Ed__42 _003CKickMember_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CKickMember_003Ed__42>(ref awaiter, ref _003CKickMember_003Ed__);
								return;
							}
							goto IL_01a7;
						}
					}
					goto end_IL_0007;
				case 0:
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0108;
				case 1:
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_01a7;
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
					break;
					IL_01a7:
					((TaskAwaiter)(ref awaiter)).GetResult();
					goto end_IL_0007;
					IL_0108:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					goto end_IL_0007;
				}
				try
				{
					TaskAwaiter awaiter3;
					if ((uint)(num - 2) > 3u)
					{
						if (num == 6)
						{
							awaiter3 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_055c;
						}
						_003C_003Es__3 = 0;
					}
					try
					{
						TaskAwaiter<bool> awaiter7;
						TaskAwaiter<Result<Guild>> awaiter6;
						TaskAwaiter awaiter5;
						TaskAwaiter awaiter4;
						switch (num)
						{
						default:
							_003C_003E4__this.IsLoading = true;
							awaiter7 = _003C_003E4__this._navigationService.ShowConfirmationAsync("Remove Member", "Are you sure you want to remove " + member.PlayerName + " from the guild?").GetAwaiter();
							if (!awaiter7.IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__2 = awaiter7;
								_003CKickMember_003Ed__42 _003CKickMember_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CKickMember_003Ed__42>(ref awaiter7, ref _003CKickMember_003Ed__);
								return;
							}
							goto IL_029d;
						case 2:
							awaiter7 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<bool>);
							num = (_003C_003E1__state = -1);
							goto IL_029d;
						case 3:
							awaiter6 = _003C_003Eu__3;
							_003C_003Eu__3 = default(TaskAwaiter<Result<Guild>>);
							num = (_003C_003E1__state = -1);
							goto IL_0358;
						case 4:
							awaiter5 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_040d;
						case 5:
							{
								awaiter4 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_049b;
							}
							IL_0358:
							_003C_003Es__8 = awaiter6.GetResult();
							_003Cresult_003E5__6 = _003C_003Es__8;
							_003C_003Es__8 = null;
							if (_003Cresult_003E5__6.Success)
							{
								awaiter5 = _003C_003E4__this._navigationService.ShowAlertAsync("Member Removed", member.PlayerName + " has been removed from the guild.").GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter5)).IsCompleted)
								{
									num = (_003C_003E1__state = 4);
									_003C_003Eu__1 = awaiter5;
									_003CKickMember_003Ed__42 _003CKickMember_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CKickMember_003Ed__42>(ref awaiter5, ref _003CKickMember_003Ed__);
									return;
								}
								goto IL_040d;
							}
							awaiter4 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", _003Cresult_003E5__6.ErrorMessage ?? "Failed to remove member.").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
							{
								num = (_003C_003E1__state = 5);
								_003C_003Eu__1 = awaiter4;
								_003CKickMember_003Ed__42 _003CKickMember_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CKickMember_003Ed__42>(ref awaiter4, ref _003CKickMember_003Ed__);
								return;
							}
							goto IL_049b;
							IL_029d:
							_003C_003Es__7 = awaiter7.GetResult();
							_003Cconfirmed_003E5__4 = _003C_003Es__7;
							if (_003Cconfirmed_003E5__4)
							{
								_003Crequest_003E5__5 = new ManageGuildMembersRequest(_003C_003E4__this.GuildId, member.PlayerId, GuildMemberAction.Kick);
								awaiter6 = _003C_003E4__this._manageGuildMembersUseCase.ExecuteAsync(_003Crequest_003E5__5).GetAwaiter();
								if (!awaiter6.IsCompleted)
								{
									num = (_003C_003E1__state = 3);
									_003C_003Eu__3 = awaiter6;
									_003CKickMember_003Ed__42 _003CKickMember_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<Guild>>, _003CKickMember_003Ed__42>(ref awaiter6, ref _003CKickMember_003Ed__);
									return;
								}
								goto IL_0358;
							}
							goto end_IL_01d2;
							IL_040d:
							((TaskAwaiter)(ref awaiter5)).GetResult();
							break;
							IL_049b:
							((TaskAwaiter)(ref awaiter4)).GetResult();
							break;
						}
						_003Crequest_003E5__5 = null;
						_003Cresult_003E5__6 = null;
						goto IL_04c8;
						end_IL_01d2:;
					}
					catch (global::System.Exception ex)
					{
						_003C_003Es__2 = ex;
						_003C_003Es__3 = 1;
						goto IL_04c8;
					}
					goto end_IL_01b5;
					IL_04c8:
					int num2 = _003C_003Es__3;
					if (num2 != 1)
					{
						goto IL_05a0;
					}
					_003Cex_003E5__9 = (global::System.Exception)_003C_003Es__2;
					awaiter3 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "An error occurred while removing the member.").GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
					{
						num = (_003C_003E1__state = 6);
						_003C_003Eu__1 = awaiter3;
						_003CKickMember_003Ed__42 _003CKickMember_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CKickMember_003Ed__42>(ref awaiter3, ref _003CKickMember_003Ed__);
						return;
					}
					goto IL_055c;
					IL_055c:
					((TaskAwaiter)(ref awaiter3)).GetResult();
					Console.WriteLine($"KickMember error: {_003Cex_003E5__9}");
					_003Cex_003E5__9 = null;
					goto IL_05a0;
					IL_05a0:
					_003C_003Es__2 = null;
					end_IL_01b5:;
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this.IsLoading = false;
					}
				}
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
	private sealed class _003CLoadDataAsync_003Ed__30 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public object parameter;

		public GuildMembersViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private string _003CguildId_003E5__3;

		private global::System.Exception _003Cex_003E5__4;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0198: Unknown result type (might be due to invalid IL or missing references)
			//IL_019d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01df: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_010c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0114: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 1u || !_003C_003E4__this.IsLoading)
				{
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
								goto IL_01ee;
							}
							_003C_003Es__2 = 0;
						}
						try
						{
							TaskAwaiter awaiter2;
							if (num == 0)
							{
								awaiter2 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_0123;
							}
							_003C_003E4__this.IsLoading = true;
							_003C_003E4__this.ErrorMessage = string.Empty;
							_003CguildId_003E5__3 = parameter as string;
							if (_003CguildId_003E5__3 == null)
							{
								goto IL_012c;
							}
							if (!string.IsNullOrEmpty(_003CguildId_003E5__3))
							{
								_003C_003E4__this.GuildId = _003CguildId_003E5__3;
								awaiter2 = _003C_003E4__this.LoadMembers().GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter2;
									_003CLoadDataAsync_003Ed__30 _003CLoadDataAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__30>(ref awaiter2, ref _003CLoadDataAsync_003Ed__);
									return;
								}
								goto IL_0123;
							}
							_003C_003E4__this.ErrorMessage = "No guild ID provided";
							goto end_IL_0025;
							IL_012c:
							_003CguildId_003E5__3 = null;
							goto end_IL_003f;
							IL_0123:
							((TaskAwaiter)(ref awaiter2)).GetResult();
							goto IL_012c;
							end_IL_003f:;
						}
						catch (global::System.Exception ex)
						{
							_003C_003Es__1 = ex;
							_003C_003Es__2 = 1;
						}
						int num2 = _003C_003Es__2;
						if (num2 != 1)
						{
							goto IL_0232;
						}
						_003Cex_003E5__4 = (global::System.Exception)_003C_003Es__1;
						_003C_003E4__this.ErrorMessage = "Failed to load members";
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to load guild members. Please try again.").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter;
							_003CLoadDataAsync_003Ed__30 _003CLoadDataAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__30>(ref awaiter, ref _003CLoadDataAsync_003Ed__);
							return;
						}
						goto IL_01ee;
						IL_01ee:
						((TaskAwaiter)(ref awaiter)).GetResult();
						Console.WriteLine($"GuildMembersViewModel.LoadDataAsync: {_003Cex_003E5__4}");
						_003Cex_003E5__4 = null;
						goto IL_0232;
						IL_0232:
						_003C_003Es__1 = null;
						end_IL_0025:;
					}
					finally
					{
						if (num < 0)
						{
							_003C_003E4__this.IsLoading = false;
						}
					}
				}
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
	private sealed class _003CLoadMembers_003Ed__31 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildMembersViewModel _003C_003E4__this;

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
					_003C_003E4__this.LoadMembersFromStateService();
					awaiter = global::System.Threading.Tasks.Task.CompletedTask.GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CLoadMembers_003Ed__31 _003CLoadMembers_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadMembers_003Ed__31>(ref awaiter, ref _003CLoadMembers_003Ed__);
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
	private sealed class _003COpenInvitePlayer_003Ed__39 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string parameter;

		public GuildMembersViewModel _003C_003E4__this;

		private _003C_003Ec__DisplayClass39_0 _003C_003E8__1;

		private object _003C_003Es__2;

		private int _003C_003Es__3;

		private _003C_003Ec__DisplayClass39_1 _003C_003E8__4;

		private object _003Cresult_003E5__5;

		private bool _003Cupdate_003E5__6;

		private object _003C_003Es__7;

		private global::System.Exception _003Cex_003E5__8;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<object?> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_02fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0314: Unknown result type (might be due to invalid IL or missing references)
			//IL_0316: Unknown result type (might be due to invalid IL or missing references)
			//IL_0334: Unknown result type (might be due to invalid IL or missing references)
			//IL_0339: Unknown result type (might be due to invalid IL or missing references)
			//IL_0341: Unknown result type (might be due to invalid IL or missing references)
			//IL_0127: Unknown result type (might be due to invalid IL or missing references)
			//IL_012c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0264: Unknown result type (might be due to invalid IL or missing references)
			//IL_0269: Unknown result type (might be due to invalid IL or missing references)
			//IL_0271: Unknown result type (might be due to invalid IL or missing references)
			//IL_016d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0173: Unknown result type (might be due to invalid IL or missing references)
			//IL_017a: Unknown result type (might be due to invalid IL or missing references)
			//IL_017f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0194: Unknown result type (might be due to invalid IL or missing references)
			//IL_0196: Unknown result type (might be due to invalid IL or missing references)
			//IL_0108: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_022a: Unknown result type (might be due to invalid IL or missing references)
			//IL_022f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0244: Unknown result type (might be due to invalid IL or missing references)
			//IL_0246: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 2u)
				{
					goto IL_0067;
				}
				TaskAwaiter awaiter;
				if (num == 3)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0350;
				}
				_003C_003E8__1 = new _003C_003Ec__DisplayClass39_0();
				_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
				_003C_003E8__1.parameter = parameter;
				if (_003C_003E4__this.CanInvitePlayers)
				{
					_003C_003Es__3 = 0;
					goto IL_0067;
				}
				goto end_IL_0007;
				IL_0394:
				_003C_003Es__2 = null;
				goto end_IL_0007;
				IL_0350:
				((TaskAwaiter)(ref awaiter)).GetResult();
				Console.WriteLine($"OpenInvitePlayer error: {_003Cex_003E5__8}");
				_003Cex_003E5__8 = null;
				goto IL_0394;
				IL_0067:
				try
				{
					TaskAwaiter awaiter4;
					TaskAwaiter<object> awaiter3;
					TaskAwaiter awaiter2;
					int num2;
					switch (num)
					{
					default:
						_003C_003E8__4 = new _003C_003Ec__DisplayClass39_1();
						_003C_003E8__4.CS_0024_003C_003E8__locals1 = _003C_003E8__1;
						_003C_003E8__4.guild = _003C_003E4__this._guildStateService.GetCurrentGuild();
						if (_003C_003E8__4.guild == null)
						{
							awaiter4 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Guild not found").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter4;
								_003COpenInvitePlayer_003Ed__39 _003COpenInvitePlayer_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COpenInvitePlayer_003Ed__39>(ref awaiter4, ref _003COpenInvitePlayer_003Ed__);
								return;
							}
							goto IL_0142;
						}
						awaiter3 = _003C_003E4__this._popupService.ShowPopupAsync<InvitePlayerPopupViewModel>((Action<InvitePlayerPopupViewModel>)([AsyncStateMachine(typeof(_003C_003Ec__DisplayClass39_1._003C_003COpenInvitePlayer_003Eb__0_003Ed))] [DebuggerStepThrough] (InvitePlayerPopupViewModel vm) =>
						{
							//IL_0007: Unknown result type (might be due to invalid IL or missing references)
							//IL_000c: Unknown result type (might be due to invalid IL or missing references)
							_003C_003Ec__DisplayClass39_1._003C_003COpenInvitePlayer_003Eb__0_003Ed _003C_003COpenInvitePlayer_003Eb__0_003Ed = new _003C_003Ec__DisplayClass39_1._003C_003COpenInvitePlayer_003Eb__0_003Ed
							{
								_003C_003Et__builder = AsyncVoidMethodBuilder.Create(),
								_003C_003E4__this = _003C_003E8__4,
								vm = vm,
								_003C_003E1__state = -1
							};
							((AsyncVoidMethodBuilder)(ref _003C_003COpenInvitePlayer_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003Ec__DisplayClass39_1._003C_003COpenInvitePlayer_003Eb__0_003Ed>(ref _003C_003COpenInvitePlayer_003Eb__0_003Ed);
						}), default(CancellationToken)).GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter3;
							_003COpenInvitePlayer_003Ed__39 _003COpenInvitePlayer_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<object>, _003COpenInvitePlayer_003Ed__39>(ref awaiter3, ref _003COpenInvitePlayer_003Ed__);
							return;
						}
						goto IL_01d0;
					case 0:
						awaiter4 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0142;
					case 1:
						awaiter3 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<object>);
						num = (_003C_003E1__state = -1);
						goto IL_01d0;
					case 2:
						{
							awaiter2 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0280;
						}
						IL_0280:
						((TaskAwaiter)(ref awaiter2)).GetResult();
						break;
						IL_01d0:
						_003C_003Es__7 = awaiter3.GetResult();
						_003Cresult_003E5__5 = _003C_003Es__7;
						_003C_003Es__7 = null;
						if (_003Cresult_003E5__5 is bool)
						{
							_003Cupdate_003E5__6 = (bool)_003Cresult_003E5__5;
							num2 = 1;
						}
						else
						{
							num2 = 0;
						}
						if (((uint)num2 & (_003Cupdate_003E5__6 ? 1u : 0u)) == 0)
						{
							break;
						}
						awaiter2 = _003C_003E4__this.LoadMembers().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__1 = awaiter2;
							_003COpenInvitePlayer_003Ed__39 _003COpenInvitePlayer_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COpenInvitePlayer_003Ed__39>(ref awaiter2, ref _003COpenInvitePlayer_003Ed__);
							return;
						}
						goto IL_0280;
						IL_0142:
						((TaskAwaiter)(ref awaiter4)).GetResult();
						goto end_IL_0007;
					}
					_003C_003E8__4 = null;
					_003Cresult_003E5__5 = null;
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__2 = ex;
					_003C_003Es__3 = 1;
				}
				int num3 = _003C_003Es__3;
				if (num3 != 1)
				{
					goto IL_0394;
				}
				_003Cex_003E5__8 = (global::System.Exception)_003C_003Es__2;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to open invite player popup" + _003Cex_003E5__8.Message).GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 3);
					_003C_003Eu__1 = awaiter;
					_003COpenInvitePlayer_003Ed__39 _003COpenInvitePlayer_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COpenInvitePlayer_003Ed__39>(ref awaiter, ref _003COpenInvitePlayer_003Ed__);
					return;
				}
				goto IL_0350;
				end_IL_0007:;
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
	private sealed class _003CPromoteMember_003Ed__40 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildMember member;

		public GuildMembersViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private GuildRole _003CnewRole_003E5__3;

		private bool _003Cconfirmed_003E5__4;

		private ManageGuildMembersRequest _003Crequest_003E5__5;

		private Result<Guild> _003Cresult_003E5__6;

		private GuildRole _003C_003Es__7;

		private bool _003C_003Es__8;

		private Result<Guild> _003C_003Es__9;

		private global::System.Exception _003Cex_003E5__10;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<bool> _003C_003Eu__2;

		private TaskAwaiter<Result<Guild>> _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_059b: Unknown result type (might be due to invalid IL or missing references)
			//IL_05a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_05b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_05b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_05d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_05da: Unknown result type (might be due to invalid IL or missing references)
			//IL_05e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_0204: Unknown result type (might be due to invalid IL or missing references)
			//IL_0209: Unknown result type (might be due to invalid IL or missing references)
			//IL_0211: Unknown result type (might be due to invalid IL or missing references)
			//IL_02df: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_039a: Unknown result type (might be due to invalid IL or missing references)
			//IL_039f: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0486: Unknown result type (might be due to invalid IL or missing references)
			//IL_048b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0493: Unknown result type (might be due to invalid IL or missing references)
			//IL_0514: Unknown result type (might be due to invalid IL or missing references)
			//IL_0519: Unknown result type (might be due to invalid IL or missing references)
			//IL_0521: Unknown result type (might be due to invalid IL or missing references)
			//IL_0360: Unknown result type (might be due to invalid IL or missing references)
			//IL_0365: Unknown result type (might be due to invalid IL or missing references)
			//IL_044c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0451: Unknown result type (might be due to invalid IL or missing references)
			//IL_037a: Unknown result type (might be due to invalid IL or missing references)
			//IL_037c: Unknown result type (might be due to invalid IL or missing references)
			//IL_04da: Unknown result type (might be due to invalid IL or missing references)
			//IL_04df: Unknown result type (might be due to invalid IL or missing references)
			//IL_0466: Unknown result type (might be due to invalid IL or missing references)
			//IL_0468: Unknown result type (might be due to invalid IL or missing references)
			//IL_04f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_04f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00c1;
				}
				if ((uint)(num - 1) <= 5u)
				{
					goto IL_00cf;
				}
				if (member != null && _003C_003E4__this.CanPromoteMembers)
				{
					if (member.Role == GuildRole.Guildmaster)
					{
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Cannot Promote", "This member is already the leader.").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CPromoteMember_003Ed__40 _003CPromoteMember_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CPromoteMember_003Ed__40>(ref awaiter, ref _003CPromoteMember_003Ed__);
							return;
						}
						goto IL_00c1;
					}
					goto IL_00cf;
				}
				goto end_IL_0007;
				IL_00cf:
				try
				{
					TaskAwaiter awaiter2;
					if ((uint)(num - 1) > 4u)
					{
						if (num == 6)
						{
							awaiter2 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_05f1;
						}
						_003C_003Es__2 = 0;
					}
					try
					{
						TaskAwaiter awaiter7;
						TaskAwaiter<bool> awaiter6;
						TaskAwaiter<Result<Guild>> awaiter5;
						TaskAwaiter awaiter4;
						TaskAwaiter awaiter3;
						switch (num)
						{
						default:
						{
							_003C_003E4__this.IsLoading = true;
							_003C_003Es__7 = member.Role;
							if (1 == 0)
							{
							}
							GuildRole guildRole = _003C_003Es__7 switch
							{
								GuildRole.Member => GuildRole.Officer, 
								GuildRole.Officer => GuildRole.Vice_Guildmaster, 
								GuildRole.Vice_Guildmaster => GuildRole.Guildmaster, 
								_ => member.Role, 
							};
							if (1 == 0)
							{
							}
							_003CnewRole_003E5__3 = guildRole;
							if (_003CnewRole_003E5__3 == GuildRole.Guildmaster && !_003C_003E4__this.IsPlayerLeader)
							{
								awaiter7 = _003C_003E4__this._navigationService.ShowAlertAsync("Insufficient Permissions", "Only the guild leader can promote to leader.").GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter7)).IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__1 = awaiter7;
									_003CPromoteMember_003Ed__40 _003CPromoteMember_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CPromoteMember_003Ed__40>(ref awaiter7, ref _003CPromoteMember_003Ed__);
									return;
								}
								goto IL_0220;
							}
							awaiter6 = _003C_003E4__this._navigationService.ShowConfirmationAsync("Promote Member", $"Promote {member.PlayerName} to {_003CnewRole_003E5__3}?").GetAwaiter();
							if (!awaiter6.IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__2 = awaiter6;
								_003CPromoteMember_003Ed__40 _003CPromoteMember_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CPromoteMember_003Ed__40>(ref awaiter6, ref _003CPromoteMember_003Ed__);
								return;
							}
							goto IL_02fb;
						}
						case 1:
							awaiter7 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0220;
						case 2:
							awaiter6 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<bool>);
							num = (_003C_003E1__state = -1);
							goto IL_02fb;
						case 3:
							awaiter5 = _003C_003Eu__3;
							_003C_003Eu__3 = default(TaskAwaiter<Result<Guild>>);
							num = (_003C_003E1__state = -1);
							goto IL_03b6;
						case 4:
							awaiter4 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_04a2;
						case 5:
							{
								awaiter3 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_0530;
							}
							IL_0530:
							((TaskAwaiter)(ref awaiter3)).GetResult();
							break;
							IL_0220:
							((TaskAwaiter)(ref awaiter7)).GetResult();
							goto end_IL_00ec;
							IL_03b6:
							_003C_003Es__9 = awaiter5.GetResult();
							_003Cresult_003E5__6 = _003C_003Es__9;
							_003C_003Es__9 = null;
							if (_003Cresult_003E5__6.Success)
							{
								awaiter4 = _003C_003E4__this._navigationService.ShowAlertAsync("Member Promoted", $"{member.PlayerName} has been promoted to {_003CnewRole_003E5__3}!").GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
								{
									num = (_003C_003E1__state = 4);
									_003C_003Eu__1 = awaiter4;
									_003CPromoteMember_003Ed__40 _003CPromoteMember_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CPromoteMember_003Ed__40>(ref awaiter4, ref _003CPromoteMember_003Ed__);
									return;
								}
								goto IL_04a2;
							}
							awaiter3 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", _003Cresult_003E5__6.ErrorMessage ?? "Failed to promote member.").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 5);
								_003C_003Eu__1 = awaiter3;
								_003CPromoteMember_003Ed__40 _003CPromoteMember_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CPromoteMember_003Ed__40>(ref awaiter3, ref _003CPromoteMember_003Ed__);
								return;
							}
							goto IL_0530;
							IL_02fb:
							_003C_003Es__8 = awaiter6.GetResult();
							_003Cconfirmed_003E5__4 = _003C_003Es__8;
							if (_003Cconfirmed_003E5__4)
							{
								_003Crequest_003E5__5 = new ManageGuildMembersRequest(_003C_003E4__this.GuildId, member.PlayerId, GuildMemberAction.Promote);
								awaiter5 = _003C_003E4__this._manageGuildMembersUseCase.ExecuteAsync(_003Crequest_003E5__5).GetAwaiter();
								if (!awaiter5.IsCompleted)
								{
									num = (_003C_003E1__state = 3);
									_003C_003Eu__3 = awaiter5;
									_003CPromoteMember_003Ed__40 _003CPromoteMember_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<Guild>>, _003CPromoteMember_003Ed__40>(ref awaiter5, ref _003CPromoteMember_003Ed__);
									return;
								}
								goto IL_03b6;
							}
							goto end_IL_00ec;
							IL_04a2:
							((TaskAwaiter)(ref awaiter4)).GetResult();
							break;
						}
						_003Crequest_003E5__5 = null;
						_003Cresult_003E5__6 = null;
						goto IL_055d;
						end_IL_00ec:;
					}
					catch (global::System.Exception ex)
					{
						_003C_003Es__1 = ex;
						_003C_003Es__2 = 1;
						goto IL_055d;
					}
					goto end_IL_00cf;
					IL_055d:
					int num2 = _003C_003Es__2;
					if (num2 != 1)
					{
						goto IL_0635;
					}
					_003Cex_003E5__10 = (global::System.Exception)_003C_003Es__1;
					awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "An error occurred while promoting the member.").GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 6);
						_003C_003Eu__1 = awaiter2;
						_003CPromoteMember_003Ed__40 _003CPromoteMember_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CPromoteMember_003Ed__40>(ref awaiter2, ref _003CPromoteMember_003Ed__);
						return;
					}
					goto IL_05f1;
					IL_05f1:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					Console.WriteLine($"PromoteMember error: {_003Cex_003E5__10}");
					_003Cex_003E5__10 = null;
					goto IL_0635;
					IL_0635:
					_003C_003Es__1 = null;
					end_IL_00cf:;
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this.IsLoading = false;
					}
				}
				goto end_IL_0007;
				IL_00c1:
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

	private readonly IGuildStateService _guildStateService;

	private readonly IPlayerStateService _playerStateService;

	private readonly INavigationService _navigationService;

	private readonly IPopupService _popupService;

	private readonly ManageGuildMembersUseCase _manageGuildMembersUseCase;

	private bool _disposed;

	private bool _isSubscribed;

	private List<GuildMember> _allMembers = new List<GuildMember>();

	[ObservableProperty]
	private string? _guildId;

	[ObservableProperty]
	private ObservableCollection<GuildMember> _members = new ObservableCollection<GuildMember>();

	[ObservableProperty]
	private string _searchText = string.Empty;

	[ObservableProperty]
	private string _sortBy = "contribution";

	[ObservableProperty]
	private GuildMember? _selectedMember;

	[ObservableProperty]
	private bool _isLoading;

	[ObservableProperty]
	private string _errorMessage = string.Empty;

	[ObservableProperty]
	[NotifyPropertyChangedFor("MemberCountText")]
	private int _memberCount;

	[ObservableProperty]
	private int _maxMembers = 50;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<string>? changeSortByCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? clearSearchCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<GuildMember>? selectMemberCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? closeDetailsCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? goBackCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<string>? openInvitePlayerCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<GuildMember>? promoteMemberCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<GuildMember>? demoteMemberCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<GuildMember>? kickMemberCommand;

	public string MemberCountText => $"{MemberCount} of {MaxMembers} members";

	public bool IsPlayerLeader
	{
		get
		{
			Player? currentPlayer = _playerStateService.GetCurrentPlayer();
			return currentPlayer != null && currentPlayer.GuildRole == GuildRole.Guildmaster;
		}
	}

	public bool IsPlayerOfficer
	{
		get
		{
			Player? currentPlayer = _playerStateService.GetCurrentPlayer();
			return (currentPlayer != null && currentPlayer.GuildRole == GuildRole.Officer) || IsPlayerLeader;
		}
	}

	public bool CanPromoteMembers => IsPlayerOfficer;

	public bool CanInvitePlayers => IsPlayerOfficer;

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
	public ObservableCollection<GuildMember> Members
	{
		get
		{
			return _members;
		}
		[MemberNotNull("_members")]
		set
		{
			if (!EqualityComparer<ObservableCollection<GuildMember>>.Default.Equals(_members, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Members);
				_members = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Members);
			}
		}
	}

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
	public GuildMember? SelectedMember
	{
		get
		{
			return _selectedMember;
		}
		set
		{
			if (!EqualityComparer<GuildMember>.Default.Equals(_selectedMember, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.SelectedMember);
				_selectedMember = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SelectedMember);
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
	public int MemberCount
	{
		get
		{
			return _memberCount;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_memberCount, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.MemberCount);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.MemberCountText);
				_memberCount = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.MemberCount);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.MemberCountText);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int MaxMembers
	{
		get
		{
			return _maxMembers;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_maxMembers, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.MaxMembers);
				_maxMembers = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.MaxMembers);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<string> ChangeSortByCommand => (IRelayCommand<string>)(object)(changeSortByCommand ?? (changeSortByCommand = new RelayCommand<string>((Action<string>)ChangeSortBy)));

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
	public IRelayCommand<GuildMember> SelectMemberCommand => (IRelayCommand<GuildMember>)(object)(selectMemberCommand ?? (selectMemberCommand = new RelayCommand<GuildMember>((Action<GuildMember>)SelectMember)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand CloseDetailsCommand
	{
		get
		{
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Expected O, but got Unknown
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			RelayCommand obj = closeDetailsCommand;
			if (obj == null)
			{
				RelayCommand val = new RelayCommand(new Action(CloseDetails));
				RelayCommand val2 = val;
				closeDetailsCommand = val;
				obj = val2;
			}
			return (IRelayCommand)(object)obj;
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
	public IAsyncRelayCommand<string> OpenInvitePlayerCommand => (IAsyncRelayCommand<string>)(object)(openInvitePlayerCommand ?? (openInvitePlayerCommand = new AsyncRelayCommand<string>((Func<string, global::System.Threading.Tasks.Task>)OpenInvitePlayer)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<GuildMember> PromoteMemberCommand => (IAsyncRelayCommand<GuildMember>)(object)(promoteMemberCommand ?? (promoteMemberCommand = new AsyncRelayCommand<GuildMember>((Func<GuildMember, global::System.Threading.Tasks.Task>)PromoteMember)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<GuildMember> DemoteMemberCommand => (IAsyncRelayCommand<GuildMember>)(object)(demoteMemberCommand ?? (demoteMemberCommand = new AsyncRelayCommand<GuildMember>((Func<GuildMember, global::System.Threading.Tasks.Task>)DemoteMember)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<GuildMember> KickMemberCommand => (IAsyncRelayCommand<GuildMember>)(object)(kickMemberCommand ?? (kickMemberCommand = new AsyncRelayCommand<GuildMember>((Func<GuildMember, global::System.Threading.Tasks.Task>)KickMember)));

	public GuildMembersViewModel(IGuildStateService guildStateService, IPlayerStateService playerStateService, INavigationService navigationService, IPopupService popupService, ManageGuildMembersUseCase manageGuildMembersUseCase)
	{
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		_guildStateService = guildStateService ?? throw new ArgumentNullException("guildStateService");
		_playerStateService = playerStateService ?? throw new ArgumentNullException("playerStateService");
		_navigationService = navigationService ?? throw new ArgumentNullException("navigationService");
		_popupService = popupService ?? throw new ArgumentNullException("popupService");
		_manageGuildMembersUseCase = manageGuildMembersUseCase ?? throw new ArgumentNullException("manageGuildMembersUseCase");
		SubscribeToStateChanges();
	}

	private void SubscribeToStateChanges()
	{
		if (!_isSubscribed)
		{
			_guildStateService.GuildStateChanged += OnGuildStateChanged;
			_isSubscribed = true;
		}
	}

	private void OnGuildStateChanged(object? sender, GuildStateChangedEventArgs e)
	{
		if (e.ChangeType == GuildChangeType.Members || e.ChangeType == GuildChangeType.MemberStats)
		{
			LoadMembersFromStateService();
		}
	}

	[AsyncStateMachine(typeof(_003CLoadDataAsync_003Ed__30))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task LoadDataAsync(object? parameter)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadDataAsync_003Ed__30 _003CLoadDataAsync_003Ed__ = new _003CLoadDataAsync_003Ed__30();
		_003CLoadDataAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadDataAsync_003Ed__._003C_003E4__this = this;
		_003CLoadDataAsync_003Ed__.parameter = parameter;
		_003CLoadDataAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadDataAsync_003Ed__30>(ref _003CLoadDataAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CLoadMembers_003Ed__31))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task LoadMembers()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadMembers_003Ed__31 _003CLoadMembers_003Ed__ = new _003CLoadMembers_003Ed__31();
		_003CLoadMembers_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadMembers_003Ed__._003C_003E4__this = this;
		_003CLoadMembers_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadMembers_003Ed__._003C_003Et__builder)).Start<_003CLoadMembers_003Ed__31>(ref _003CLoadMembers_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadMembers_003Ed__._003C_003Et__builder)).Task;
	}

	private void LoadMembersFromStateService()
	{
		try
		{
			global::System.Collections.Generic.IReadOnlyList<GuildMember> members = _guildStateService.GetMembers();
			_allMembers = Enumerable.ToList<GuildMember>((global::System.Collections.Generic.IEnumerable<GuildMember>)members);
			MemberCount = ((global::System.Collections.Generic.IReadOnlyCollection<GuildMember>)members).Count;
			Guild currentGuild = _guildStateService.GetCurrentGuild();
			if (currentGuild != null)
			{
				MaxMembers = currentGuild.MaxMembers;
			}
			if (SelectedMember != null)
			{
				SelectedMember = Enumerable.FirstOrDefault<GuildMember>((global::System.Collections.Generic.IEnumerable<GuildMember>)members, (Func<GuildMember, bool>)([CompilerGenerated] (GuildMember sm) => sm.PlayerId == SelectedMember.PlayerId));
			}
			ApplyFilterAndSort();
		}
		catch (global::System.Exception ex)
		{
			Console.WriteLine($"LoadMembersFromStateService error: {ex}");
		}
	}

	[RelayCommand]
	private void ChangeSortBy(string sortType)
	{
		SortBy = sortType;
		ApplyFilterAndSort();
	}

	private void ApplyFilterAndSort()
	{
		global::System.Collections.Generic.IEnumerable<GuildMember> enumerable = Enumerable.AsEnumerable<GuildMember>((global::System.Collections.Generic.IEnumerable<GuildMember>)_allMembers);
		if (!string.IsNullOrWhiteSpace(SearchText))
		{
			enumerable = Enumerable.Where<GuildMember>(enumerable, (Func<GuildMember, bool>)([CompilerGenerated] (GuildMember m) => m.PlayerName.Contains(SearchText, (StringComparison)5)));
		}
		string sortBy = SortBy;
		if (1 == 0)
		{
		}
		IOrderedEnumerable<GuildMember> val = ((sortBy == "contribution") ? Enumerable.OrderByDescending<GuildMember, int>(enumerable, (Func<GuildMember, int>)((GuildMember m) => m.Contribution)) : ((sortBy == "reputation") ? Enumerable.OrderByDescending<GuildMember, int>(enumerable, (Func<GuildMember, int>)((GuildMember m) => m.Trophies)) : ((!(sortBy == "level")) ? Enumerable.OrderByDescending<GuildMember, GuildRole>(Enumerable.Where<GuildMember>(enumerable, (Func<GuildMember, bool>)((GuildMember m) => m.Role != GuildRole.None)), (Func<GuildMember, GuildRole>)((GuildMember m) => m.Role)) : Enumerable.OrderByDescending<GuildMember, int>(enumerable, (Func<GuildMember, int>)((GuildMember m) => m.Level)))));
		if (1 == 0)
		{
		}
		enumerable = (global::System.Collections.Generic.IEnumerable<GuildMember>)val;
		Members = new ObservableCollection<GuildMember>(enumerable);
	}

	[RelayCommand]
	private void ClearSearch()
	{
		SearchText = string.Empty;
	}

	[RelayCommand]
	private void SelectMember(GuildMember member)
	{
		SelectedMember = member;
	}

	[RelayCommand]
	private void CloseDetails()
	{
		SelectedMember = null;
	}

	[AsyncStateMachine(typeof(_003CGoBack_003Ed__38))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task GoBack()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CGoBack_003Ed__38 _003CGoBack_003Ed__ = new _003CGoBack_003Ed__38();
		_003CGoBack_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CGoBack_003Ed__._003C_003E4__this = this;
		_003CGoBack_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CGoBack_003Ed__._003C_003Et__builder)).Start<_003CGoBack_003Ed__38>(ref _003CGoBack_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CGoBack_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003COpenInvitePlayer_003Ed__39))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task OpenInvitePlayer(string parameter)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003COpenInvitePlayer_003Ed__39 _003COpenInvitePlayer_003Ed__ = new _003COpenInvitePlayer_003Ed__39();
		_003COpenInvitePlayer_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003COpenInvitePlayer_003Ed__._003C_003E4__this = this;
		_003COpenInvitePlayer_003Ed__.parameter = parameter;
		_003COpenInvitePlayer_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003COpenInvitePlayer_003Ed__._003C_003Et__builder)).Start<_003COpenInvitePlayer_003Ed__39>(ref _003COpenInvitePlayer_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003COpenInvitePlayer_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CPromoteMember_003Ed__40))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task PromoteMember(GuildMember member)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CPromoteMember_003Ed__40 _003CPromoteMember_003Ed__ = new _003CPromoteMember_003Ed__40();
		_003CPromoteMember_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CPromoteMember_003Ed__._003C_003E4__this = this;
		_003CPromoteMember_003Ed__.member = member;
		_003CPromoteMember_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CPromoteMember_003Ed__._003C_003Et__builder)).Start<_003CPromoteMember_003Ed__40>(ref _003CPromoteMember_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CPromoteMember_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CDemoteMember_003Ed__41))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task DemoteMember(GuildMember member)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CDemoteMember_003Ed__41 _003CDemoteMember_003Ed__ = new _003CDemoteMember_003Ed__41();
		_003CDemoteMember_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CDemoteMember_003Ed__._003C_003E4__this = this;
		_003CDemoteMember_003Ed__.member = member;
		_003CDemoteMember_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CDemoteMember_003Ed__._003C_003Et__builder)).Start<_003CDemoteMember_003Ed__41>(ref _003CDemoteMember_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CDemoteMember_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CKickMember_003Ed__42))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task KickMember(GuildMember member)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CKickMember_003Ed__42 _003CKickMember_003Ed__ = new _003CKickMember_003Ed__42();
		_003CKickMember_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CKickMember_003Ed__._003C_003E4__this = this;
		_003CKickMember_003Ed__.member = member;
		_003CKickMember_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CKickMember_003Ed__._003C_003Et__builder)).Start<_003CKickMember_003Ed__42>(ref _003CKickMember_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CKickMember_003Ed__._003C_003Et__builder)).Task;
	}

	public void Dispose()
	{
		if (!_disposed)
		{
			if (_isSubscribed)
			{
				_guildStateService.GuildStateChanged -= OnGuildStateChanged;
				_isSubscribed = false;
			}
			_disposed = true;
			GC.SuppressFinalize((object)this);
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnSearchTextChanged(string value)
	{
		ApplyFilterAndSort();
	}
}
