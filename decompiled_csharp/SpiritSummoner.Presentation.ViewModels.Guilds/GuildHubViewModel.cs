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
using Microsoft.Maui.Controls;
using Microsoft.Maui.Dispatching;
using SpiritSummoner.Application.Enums;
using SpiritSummoner.Application.Events;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Application.UseCases.Guilds;
using SpiritSummoner.Domain.Entities.Guilds;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Enums.Guilds;
using SpiritSummoner.Infrastructure.Cache;
using SpiritSummoner.Presentation.Models.Guilds;
using SpiritSummoner.Presentation.Navigation;
using SpiritSummoner.Presentation.ViewModels.Popups;

namespace SpiritSummoner.Presentation.ViewModels.Guilds;

public class GuildHubViewModel : ObservableObject, ILoadableViewModel, global::System.IDisposable
{
	[CompilerGenerated]
	private sealed class _003CCancelDisbandGuild_003Ed__92 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildHubViewModel _003C_003E4__this;

		private bool _003Cconfirmed_003E5__1;

		private bool _003C_003Es__2;

		private object _003C_003Es__3;

		private int _003C_003Es__4;

		private string _003CplayerId_003E5__5;

		private string _003CguildId_003E5__6;

		private CancelDisbandGuildRequest _003Crequest_003E5__7;

		private Result<CancelDisbandGuildResult> _003Cresult_003E5__8;

		private Result<CancelDisbandGuildResult> _003C_003Es__9;

		private global::System.Exception _003Cex_003E5__10;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private TaskAwaiter<Result<CancelDisbandGuildResult>> _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_04b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_04e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_04f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_04cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_04cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0276: Unknown result type (might be due to invalid IL or missing references)
			//IL_027b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0283: Unknown result type (might be due to invalid IL or missing references)
			//IL_032c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0331: Unknown result type (might be due to invalid IL or missing references)
			//IL_0339: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_03fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_030d: Unknown result type (might be due to invalid IL or missing references)
			//IL_030f: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_023d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0242: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0257: Unknown result type (might be due to invalid IL or missing references)
			//IL_0259: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter<bool> awaiter2;
				TaskAwaiter awaiter;
				int num2;
				switch (num)
				{
				default:
					if (_003C_003E4__this._playerState.GetCurrentPlayer() != null && _003C_003E4__this.CurrentGuild != null)
					{
						awaiter2 = _003C_003E4__this._navigationService.ShowConfirmationAsync("Cancel Disbanding?", "Are you sure you want to cancel the guild disbanding?").GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CCancelDisbandGuild_003Ed__92 _003CCancelDisbandGuild_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CCancelDisbandGuild_003Ed__92>(ref awaiter2, ref _003CCancelDisbandGuild_003Ed__);
							return;
						}
						goto IL_00da;
					}
					goto end_IL_0007;
				case 0:
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
					goto IL_00da;
				case 1:
				case 2:
				case 3:
				case 4:
					try
					{
						TaskAwaiter awaiter6;
						TaskAwaiter<Result<CancelDisbandGuildResult>> awaiter5;
						TaskAwaiter awaiter4;
						TaskAwaiter awaiter3;
						switch (num)
						{
						default:
							_003CplayerId_003E5__5 = _003C_003E4__this._playerState.CurrentPlayerId;
							_003CguildId_003E5__6 = _003C_003E4__this.CurrentGuild?.ID;
							if (string.IsNullOrEmpty(_003CplayerId_003E5__5) || string.IsNullOrEmpty(_003CguildId_003E5__6))
							{
								awaiter6 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Unable to cancel disbanding. Missing player or guild information.").GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter6)).IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__2 = awaiter6;
									_003CCancelDisbandGuild_003Ed__92 _003CCancelDisbandGuild_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CCancelDisbandGuild_003Ed__92>(ref awaiter6, ref _003CCancelDisbandGuild_003Ed__);
									return;
								}
								goto IL_0203;
							}
							_003Crequest_003E5__7 = new CancelDisbandGuildRequest(_003CplayerId_003E5__5, _003CguildId_003E5__6);
							awaiter5 = _003C_003E4__this._cancelDisbandGuildUseCase.ExecuteAsync(_003Crequest_003E5__7).GetAwaiter();
							if (!awaiter5.IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__3 = awaiter5;
								_003CCancelDisbandGuild_003Ed__92 _003CCancelDisbandGuild_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<CancelDisbandGuildResult>>, _003CCancelDisbandGuild_003Ed__92>(ref awaiter5, ref _003CCancelDisbandGuild_003Ed__);
								return;
							}
							goto IL_0292;
						case 1:
							awaiter6 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0203;
						case 2:
							awaiter5 = _003C_003Eu__3;
							_003C_003Eu__3 = default(TaskAwaiter<Result<CancelDisbandGuildResult>>);
							num = (_003C_003E1__state = -1);
							goto IL_0292;
						case 3:
							awaiter4 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0348;
						case 4:
							{
								awaiter3 = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								break;
							}
							IL_0203:
							((TaskAwaiter)(ref awaiter6)).GetResult();
							goto end_IL_0110;
							IL_0292:
							_003C_003Es__9 = awaiter5.GetResult();
							_003Cresult_003E5__8 = _003C_003Es__9;
							_003C_003Es__9 = null;
							if (!_003Cresult_003E5__8.Success)
							{
								awaiter4 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", _003Cresult_003E5__8.ErrorMessage ?? "Failed to cancel guild disbanding").GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
								{
									num = (_003C_003E1__state = 3);
									_003C_003Eu__2 = awaiter4;
									_003CCancelDisbandGuild_003Ed__92 _003CCancelDisbandGuild_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CCancelDisbandGuild_003Ed__92>(ref awaiter4, ref _003CCancelDisbandGuild_003Ed__);
									return;
								}
								goto IL_0348;
							}
							_003C_003E4__this.IsDisbanding = false;
							_003C_003E4__this.DisbandTimeRemaining = string.Empty;
							_003C_003E4__this.StopDisbandTimer();
							awaiter3 = _003C_003E4__this._navigationService.ShowAlertAsync("Cancelled", _003Cresult_003E5__8.Data?.Message ?? "Guild disbanding has been cancelled.").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 4);
								_003C_003Eu__2 = awaiter3;
								_003CCancelDisbandGuild_003Ed__92 _003CCancelDisbandGuild_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CCancelDisbandGuild_003Ed__92>(ref awaiter3, ref _003CCancelDisbandGuild_003Ed__);
								return;
							}
							break;
							IL_0348:
							((TaskAwaiter)(ref awaiter4)).GetResult();
							goto end_IL_0110;
						}
						((TaskAwaiter)(ref awaiter3)).GetResult();
						_003CplayerId_003E5__5 = null;
						_003CguildId_003E5__6 = null;
						_003Crequest_003E5__7 = null;
						_003Cresult_003E5__8 = null;
						goto IL_0443;
						end_IL_0110:;
					}
					catch (global::System.Exception ex)
					{
						_003C_003Es__3 = ex;
						_003C_003Es__4 = 1;
						goto IL_0443;
					}
					goto end_IL_0007;
				case 5:
					{
						awaiter = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0505;
					}
					IL_0505:
					((TaskAwaiter)(ref awaiter)).GetResult();
					_003Cex_003E5__10 = null;
					break;
					IL_0443:
					num2 = _003C_003Es__4;
					if (num2 != 1)
					{
						break;
					}
					_003Cex_003E5__10 = (global::System.Exception)_003C_003Es__3;
					Console.WriteLine($"CancelDisbandGuild error: {_003Cex_003E5__10}");
					awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to cancel disbanding. Please try again.").GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 5);
						_003C_003Eu__2 = awaiter;
						_003CCancelDisbandGuild_003Ed__92 _003CCancelDisbandGuild_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CCancelDisbandGuild_003Ed__92>(ref awaiter, ref _003CCancelDisbandGuild_003Ed__);
						return;
					}
					goto IL_0505;
					IL_00da:
					_003C_003Es__2 = awaiter2.GetResult();
					_003Cconfirmed_003E5__1 = _003C_003Es__2;
					if (_003Cconfirmed_003E5__1)
					{
						_003C_003Es__4 = 0;
						goto case 1;
					}
					goto end_IL_0007;
				}
				_003C_003Es__3 = null;
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
	private sealed class _003CCheckGuildMembership_003Ed__80 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildHubViewModel _003C_003E4__this;

		private string _003CplayerGuildId_003E5__1;

		private bool _003CplayerHasGuild_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0135: Unknown result type (might be due to invalid IL or missing references)
			//IL_013a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0141: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01be: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0182: Unknown result type (might be due to invalid IL or missing references)
			//IL_0187: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0102: Unknown result type (might be due to invalid IL or missing references)
			//IL_019c: Unknown result type (might be due to invalid IL or missing references)
			//IL_019e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0150;
				}
				TaskAwaiter awaiter2;
				if (num != 1)
				{
					_003CplayerGuildId_003E5__1 = _003C_003E4__this._playerState?.GetCurrentPlayer()?.GuildId;
					_003CplayerHasGuild_003E5__2 = !string.IsNullOrEmpty(_003CplayerGuildId_003E5__1);
					_003C_003E4__this.HasGuild = _003CplayerHasGuild_003E5__2;
					_003C_003E4__this._currentGuildId = _003CplayerGuildId_003E5__1;
					Console.WriteLine($"CheckGuildMembership - HasGuild: {_003C_003E4__this.HasGuild}, GuildId: {_003C_003E4__this._currentGuildId}");
					if (_003C_003E4__this.HasGuild)
					{
						awaiter = _003C_003E4__this.LoadInitialGuildData("CheckGuildMembership", "C:\\Users\\lfgam\\source\\repos\\Abugu100\\SpiritSummoner\\SpiritSummoner\\Presentation\\ViewModels\\Guilds\\GuildHubViewModel.cs", 416).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CCheckGuildMembership_003Ed__80 _003CCheckGuildMembership_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CCheckGuildMembership_003Ed__80>(ref awaiter, ref _003CCheckGuildMembership_003Ed__);
							return;
						}
						goto IL_0150;
					}
					_003C_003E4__this.ClearGuildContent();
					_003C_003E4__this.UpdateVisibilityState();
					awaiter2 = _003C_003E4__this.LoadPendingInvitationCountAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = awaiter2;
						_003CCheckGuildMembership_003Ed__80 _003CCheckGuildMembership_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CCheckGuildMembership_003Ed__80>(ref awaiter2, ref _003CCheckGuildMembership_003Ed__);
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
				IL_0150:
				((TaskAwaiter)(ref awaiter)).GetResult();
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003CplayerGuildId_003E5__1 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CplayerGuildId_003E5__1 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CDisbandGuild_003Ed__91 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildHubViewModel _003C_003E4__this;

		private bool _003Cconfirmed_003E5__1;

		private bool _003C_003Es__2;

		private object _003C_003Es__3;

		private int _003C_003Es__4;

		private string _003CplayerId_003E5__5;

		private string _003CguildId_003E5__6;

		private DisbandGuildRequest _003Crequest_003E5__7;

		private Result<DisbandGuildResult> _003Cresult_003E5__8;

		private Result<DisbandGuildResult> _003C_003Es__9;

		private global::System.Exception _003Cex_003E5__10;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<bool> _003C_003Eu__2;

		private TaskAwaiter<Result<DisbandGuildResult>> _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_0574: Unknown result type (might be due to invalid IL or missing references)
			//IL_0579: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_015d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0162: Unknown result type (might be due to invalid IL or missing references)
			//IL_016a: Unknown result type (might be due to invalid IL or missing references)
			//IL_058e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0590: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_0128: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_05ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_05b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_05b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_013d: Unknown result type (might be due to invalid IL or missing references)
			//IL_013f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_02af: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_033a: Unknown result type (might be due to invalid IL or missing references)
			//IL_033f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0347: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_03fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_04bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_03bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0474: Unknown result type (might be due to invalid IL or missing references)
			//IL_0479: Unknown result type (might be due to invalid IL or missing references)
			//IL_0300: Unknown result type (might be due to invalid IL or missing references)
			//IL_0305: Unknown result type (might be due to invalid IL or missing references)
			//IL_0270: Unknown result type (might be due to invalid IL or missing references)
			//IL_0275: Unknown result type (might be due to invalid IL or missing references)
			//IL_048e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0490: Unknown result type (might be due to invalid IL or missing references)
			//IL_031a: Unknown result type (might be due to invalid IL or missing references)
			//IL_031c: Unknown result type (might be due to invalid IL or missing references)
			//IL_028a: Unknown result type (might be due to invalid IL or missing references)
			//IL_028c: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter2;
				TaskAwaiter<bool> awaiter;
				switch (num)
				{
				default:
					if (_003C_003E4__this._playerState.GetCurrentPlayer() != null && _003C_003E4__this.CurrentGuild != null)
					{
						if (!string.IsNullOrEmpty(_003C_003E4__this.CurrentGuild.CurrentWarId))
						{
							awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Error disbanding guild", "You are in active war season, you must wait for war season to end to be able to disband the guild!").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter2;
								_003CDisbandGuild_003Ed__91 _003CDisbandGuild_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CDisbandGuild_003Ed__91>(ref awaiter2, ref _003CDisbandGuild_003Ed__);
								return;
							}
							goto IL_00f2;
						}
						awaiter = _003C_003E4__this._navigationService.ShowConfirmationAsync("Disband Guild?", "This will start a 24-hour countdown. After 24 hours, the guild will be permanently deleted and all members will be removed. You can cancel this during the countdown period.").GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter;
							_003CDisbandGuild_003Ed__91 _003CDisbandGuild_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CDisbandGuild_003Ed__91>(ref awaiter, ref _003CDisbandGuild_003Ed__);
							return;
						}
						goto IL_0179;
					}
					goto end_IL_0007;
				case 0:
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00f2;
				case 1:
					awaiter = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
					goto IL_0179;
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
					break;
					IL_00f2:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					goto end_IL_0007;
					IL_0179:
					_003C_003Es__2 = awaiter.GetResult();
					_003Cconfirmed_003E5__1 = _003C_003Es__2;
					if (_003Cconfirmed_003E5__1)
					{
						break;
					}
					_003C_003E4__this.HideOptions = true;
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
							goto IL_05c7;
						}
						_003C_003Es__4 = 0;
					}
					try
					{
						TaskAwaiter awaiter7;
						TaskAwaiter<Result<DisbandGuildResult>> awaiter6;
						TaskAwaiter awaiter5;
						TaskAwaiter awaiter4;
						switch (num)
						{
						default:
							_003CplayerId_003E5__5 = _003C_003E4__this._playerState.CurrentPlayerId;
							_003CguildId_003E5__6 = _003C_003E4__this.CurrentGuild?.ID;
							if (string.IsNullOrEmpty(_003CplayerId_003E5__5) || string.IsNullOrEmpty(_003CguildId_003E5__6))
							{
								awaiter7 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Unable to disband guild. Missing player or guild information.").GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter7)).IsCompleted)
								{
									num = (_003C_003E1__state = 2);
									_003C_003Eu__1 = awaiter7;
									_003CDisbandGuild_003Ed__91 _003CDisbandGuild_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CDisbandGuild_003Ed__91>(ref awaiter7, ref _003CDisbandGuild_003Ed__);
									return;
								}
								goto IL_02c6;
							}
							_003Crequest_003E5__7 = new DisbandGuildRequest(_003CplayerId_003E5__5, _003CguildId_003E5__6);
							awaiter6 = _003C_003E4__this._disbandGuildUseCase.ExecuteAsync(_003Crequest_003E5__7).GetAwaiter();
							if (!awaiter6.IsCompleted)
							{
								num = (_003C_003E1__state = 3);
								_003C_003Eu__3 = awaiter6;
								_003CDisbandGuild_003Ed__91 _003CDisbandGuild_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<DisbandGuildResult>>, _003CDisbandGuild_003Ed__91>(ref awaiter6, ref _003CDisbandGuild_003Ed__);
								return;
							}
							goto IL_0356;
						case 2:
							awaiter7 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_02c6;
						case 3:
							awaiter6 = _003C_003Eu__3;
							_003C_003Eu__3 = default(TaskAwaiter<Result<DisbandGuildResult>>);
							num = (_003C_003E1__state = -1);
							goto IL_0356;
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
								break;
							}
							IL_02c6:
							((TaskAwaiter)(ref awaiter7)).GetResult();
							goto end_IL_01d2;
							IL_0356:
							_003C_003Es__9 = awaiter6.GetResult();
							_003Cresult_003E5__8 = _003C_003Es__9;
							_003C_003Es__9 = null;
							if (!_003Cresult_003E5__8.Success)
							{
								awaiter5 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", _003Cresult_003E5__8.ErrorMessage ?? "Failed to initiate guild disbanding").GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter5)).IsCompleted)
								{
									num = (_003C_003E1__state = 4);
									_003C_003Eu__1 = awaiter5;
									_003CDisbandGuild_003Ed__91 _003CDisbandGuild_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CDisbandGuild_003Ed__91>(ref awaiter5, ref _003CDisbandGuild_003Ed__);
									return;
								}
								goto IL_040d;
							}
							_003C_003E4__this.IsDisbanding = true;
							_003C_003E4__this.UpdateDisbandTimeRemaining();
							_003C_003E4__this.StartDisbandTimer();
							awaiter4 = _003C_003E4__this._navigationService.ShowAlertAsync("Guild Disbanding", _003Cresult_003E5__8.Data?.Message ?? "Guild disbanding has been initiated.").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
							{
								num = (_003C_003E1__state = 5);
								_003C_003Eu__1 = awaiter4;
								_003CDisbandGuild_003Ed__91 _003CDisbandGuild_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CDisbandGuild_003Ed__91>(ref awaiter4, ref _003CDisbandGuild_003Ed__);
								return;
							}
							break;
							IL_040d:
							((TaskAwaiter)(ref awaiter5)).GetResult();
							goto end_IL_01d2;
						}
						((TaskAwaiter)(ref awaiter4)).GetResult();
						_003CplayerId_003E5__5 = null;
						_003CguildId_003E5__6 = null;
						_003Crequest_003E5__7 = null;
						_003Cresult_003E5__8 = null;
						goto IL_0504;
						end_IL_01d2:;
					}
					catch (global::System.Exception ex)
					{
						_003C_003Es__3 = ex;
						_003C_003Es__4 = 1;
						goto IL_0504;
					}
					goto end_IL_01b5;
					IL_0504:
					int num2 = _003C_003Es__4;
					if (num2 != 1)
					{
						goto IL_05d9;
					}
					_003Cex_003E5__10 = (global::System.Exception)_003C_003Es__3;
					Console.WriteLine($"DisbandGuild error: {_003Cex_003E5__10}");
					awaiter3 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to disband guild. Please try again.").GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
					{
						num = (_003C_003E1__state = 6);
						_003C_003Eu__1 = awaiter3;
						_003CDisbandGuild_003Ed__91 _003CDisbandGuild_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CDisbandGuild_003Ed__91>(ref awaiter3, ref _003CDisbandGuild_003Ed__);
						return;
					}
					goto IL_05c7;
					IL_05c7:
					((TaskAwaiter)(ref awaiter3)).GetResult();
					_003Cex_003E5__10 = null;
					goto IL_05d9;
					IL_05d9:
					_003C_003Es__3 = null;
					end_IL_01b5:;
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this.HideOptions = true;
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
	private sealed class _003CEditGuild_003Ed__89 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildHubViewModel _003C_003E4__this;

		private object _003Cresult_003E5__1;

		private bool _003CsuccessfullUpdate_003E5__2;

		private object _003C_003Es__3;

		private global::System.Exception _003Cex_003E5__4;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<object?> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0136: Unknown result type (might be due to invalid IL or missing references)
			//IL_013b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0143: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0205: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0102: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_0119: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01db: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00b0;
				}
				if ((uint)(num - 1) > 1u && (_003C_003E4__this.CurrentGuild == null || _003C_003E4__this._playerState.GetCurrentPlayer() == null))
				{
					awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Guild information not available.").GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CEditGuild_003Ed__89 _003CEditGuild_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CEditGuild_003Ed__89>(ref awaiter, ref _003CEditGuild_003Ed__);
						return;
					}
					goto IL_00b0;
				}
				try
				{
					TaskAwaiter awaiter2;
					TaskAwaiter<object> awaiter3;
					if (num != 1)
					{
						if (num == 2)
						{
							awaiter2 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0214;
						}
						awaiter3 = _003C_003E4__this._popupService.ShowPopupAsync<CreateGuildPopupViewModel>((Action<CreateGuildPopupViewModel>)([CompilerGenerated] (CreateGuildPopupViewModel vm) =>
						{
							vm.PlayerName = _003C_003E4__this._playerState.GetCurrentPlayer()?.Playername ?? "";
							vm.InitializeForEdit(_003C_003E4__this.CurrentGuild);
						}), default(CancellationToken)).GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter3;
							_003CEditGuild_003Ed__89 _003CEditGuild_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<object>, _003CEditGuild_003Ed__89>(ref awaiter3, ref _003CEditGuild_003Ed__);
							return;
						}
					}
					else
					{
						awaiter3 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<object>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__3 = awaiter3.GetResult();
					_003Cresult_003E5__1 = _003C_003Es__3;
					_003C_003Es__3 = null;
					int num2;
					if (_003Cresult_003E5__1 is bool)
					{
						_003CsuccessfullUpdate_003E5__2 = (bool)_003Cresult_003E5__1;
						num2 = 1;
					}
					else
					{
						num2 = 0;
					}
					if (((uint)num2 & (_003CsuccessfullUpdate_003E5__2 ? 1u : 0u)) != 0)
					{
						awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Success", "The guild has successfully been updated").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__1 = awaiter2;
							_003CEditGuild_003Ed__89 _003CEditGuild_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CEditGuild_003Ed__89>(ref awaiter2, ref _003CEditGuild_003Ed__);
							return;
						}
						goto IL_0214;
					}
					goto IL_0229;
					IL_0214:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					_003C_003E4__this.UpdateVisibilityState();
					goto IL_0229;
					IL_0229:
					_003Cresult_003E5__1 = null;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__4 = ex;
					Console.WriteLine($"EditGuild error: {_003Cex_003E5__4}");
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this.HideOptions = true;
					}
				}
				goto end_IL_0007;
				IL_00b0:
				((TaskAwaiter)(ref awaiter)).GetResult();
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
	private sealed class _003CJoinGuildAsync_003Ed__101 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string guildId;

		public GuildHubViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private Player _003Cplayer_003E5__3;

		private JoinGuildRequest _003Crequest_003E5__4;

		private Player _003Cplayercurrencies_003E5__5;

		private Result<JoinGuildResult> _003Cresult_003E5__6;

		private Result<JoinGuildResult> _003C_003Es__7;

		private global::System.Exception _003Cex_003E5__8;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<Result<JoinGuildResult>> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0607: Unknown result type (might be due to invalid IL or missing references)
			//IL_060c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0621: Unknown result type (might be due to invalid IL or missing references)
			//IL_0623: Unknown result type (might be due to invalid IL or missing references)
			//IL_0641: Unknown result type (might be due to invalid IL or missing references)
			//IL_0646: Unknown result type (might be due to invalid IL or missing references)
			//IL_064e: Unknown result type (might be due to invalid IL or missing references)
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0203: Unknown result type (might be due to invalid IL or missing references)
			//IL_020b: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0357: Unknown result type (might be due to invalid IL or missing references)
			//IL_035c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0364: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_03fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_04f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_04fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0503: Unknown result type (might be due to invalid IL or missing references)
			//IL_0572: Unknown result type (might be due to invalid IL or missing references)
			//IL_0577: Unknown result type (might be due to invalid IL or missing references)
			//IL_057f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0538: Unknown result type (might be due to invalid IL or missing references)
			//IL_053d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_031d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0322: Unknown result type (might be due to invalid IL or missing references)
			//IL_027b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0280: Unknown result type (might be due to invalid IL or missing references)
			//IL_0552: Unknown result type (might be due to invalid IL or missing references)
			//IL_0554: Unknown result type (might be due to invalid IL or missing references)
			//IL_04bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_04c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0337: Unknown result type (might be due to invalid IL or missing references)
			//IL_0339: Unknown result type (might be due to invalid IL or missing references)
			//IL_0295: Unknown result type (might be due to invalid IL or missing references)
			//IL_0297: Unknown result type (might be due to invalid IL or missing references)
			//IL_04d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_04d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01de: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 7u || !string.IsNullOrEmpty(guildId))
				{
					try
					{
						TaskAwaiter awaiter;
						if ((uint)num > 6u)
						{
							if (num == 7)
							{
								awaiter = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_065d;
							}
							_003C_003Es__2 = 0;
						}
						try
						{
							TaskAwaiter awaiter8;
							TaskAwaiter<Result<JoinGuildResult>> awaiter7;
							TaskAwaiter awaiter6;
							TaskAwaiter awaiter5;
							TaskAwaiter awaiter4;
							TaskAwaiter awaiter3;
							TaskAwaiter awaiter2;
							switch (num)
							{
							default:
							{
								_003C_003E4__this.IsLoading = true;
								_003Cplayer_003E5__3 = _003C_003E4__this._playerState.GetCurrentPlayer();
								if (_003Cplayer_003E5__3 == null)
								{
									awaiter8 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Player information not available.").GetAwaiter();
									if (!((TaskAwaiter)(ref awaiter8)).IsCompleted)
									{
										num = (_003C_003E1__state = 0);
										_003C_003Eu__1 = awaiter8;
										_003CJoinGuildAsync_003Ed__101 _003CJoinGuildAsync_003Ed__ = this;
										((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CJoinGuildAsync_003Ed__101>(ref awaiter8, ref _003CJoinGuildAsync_003Ed__);
										return;
									}
									goto IL_0126;
								}
								string? playerId = _003Cplayer_003E5__3.PlayerID ?? "";
								string? playerName = _003Cplayer_003E5__3.Playername ?? "";
								string text = guildId;
								int playerLevel = _003Cplayer_003E5__3.PlayerLevel;
								_003Cplayercurrencies_003E5__5 = _003C_003E4__this._playerState.GetCurrentPlayer();
								_003Crequest_003E5__4 = new JoinGuildRequest(playerId, playerName, text, playerLevel, (_003Cplayercurrencies_003E5__5 != null) ? _003Cplayercurrencies_003E5__5.Currencies["reputation"] : 1);
								awaiter7 = _003C_003E4__this._joinGuildUseCase.ExecuteAsync(_003Crequest_003E5__4).GetAwaiter();
								if (!awaiter7.IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__2 = awaiter7;
									_003CJoinGuildAsync_003Ed__101 _003CJoinGuildAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<JoinGuildResult>>, _003CJoinGuildAsync_003Ed__101>(ref awaiter7, ref _003CJoinGuildAsync_003Ed__);
									return;
								}
								goto IL_021a;
							}
							case 0:
								awaiter8 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_0126;
							case 1:
								awaiter7 = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter<Result<JoinGuildResult>>);
								num = (_003C_003E1__state = -1);
								goto IL_021a;
							case 2:
								awaiter6 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_02d1;
							case 3:
								awaiter5 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_0373;
							case 4:
								awaiter4 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_040a;
							case 5:
								awaiter3 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_0512;
							case 6:
								{
									awaiter2 = _003C_003Eu__1;
									_003C_003Eu__1 = default(TaskAwaiter);
									num = (_003C_003E1__state = -1);
									goto IL_058e;
								}
								IL_021a:
								_003C_003Es__7 = awaiter7.GetResult();
								_003Cresult_003E5__6 = _003C_003Es__7;
								_003C_003Es__7 = null;
								if (!_003Cresult_003E5__6.Success)
								{
									awaiter6 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", _003Cresult_003E5__6.ErrorMessage ?? "Failed to join guild").GetAwaiter();
									if (!((TaskAwaiter)(ref awaiter6)).IsCompleted)
									{
										num = (_003C_003E1__state = 2);
										_003C_003Eu__1 = awaiter6;
										_003CJoinGuildAsync_003Ed__101 _003CJoinGuildAsync_003Ed__ = this;
										((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CJoinGuildAsync_003Ed__101>(ref awaiter6, ref _003CJoinGuildAsync_003Ed__);
										return;
									}
									goto IL_02d1;
								}
								if (_003Cresult_003E5__6.Data.RequiresApproval)
								{
									awaiter5 = _003C_003E4__this._navigationService.ShowAlertAsync("Request Sent", _003Cresult_003E5__6.Data.Message).GetAwaiter();
									if (!((TaskAwaiter)(ref awaiter5)).IsCompleted)
									{
										num = (_003C_003E1__state = 3);
										_003C_003Eu__1 = awaiter5;
										_003CJoinGuildAsync_003Ed__101 _003CJoinGuildAsync_003Ed__ = this;
										((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CJoinGuildAsync_003Ed__101>(ref awaiter5, ref _003CJoinGuildAsync_003Ed__);
										return;
									}
									goto IL_0373;
								}
								_003C_003E4__this.HasGuild = true;
								_003C_003E4__this._currentGuildId = guildId;
								awaiter4 = _003C_003E4__this._guildStateService.SetCurrentGuildAsync(guildId).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
								{
									num = (_003C_003E1__state = 4);
									_003C_003Eu__1 = awaiter4;
									_003CJoinGuildAsync_003Ed__101 _003CJoinGuildAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CJoinGuildAsync_003Ed__101>(ref awaiter4, ref _003CJoinGuildAsync_003Ed__);
									return;
								}
								goto IL_040a;
								IL_040a:
								((TaskAwaiter)(ref awaiter4)).GetResult();
								_003C_003E4__this.CurrentGuild = _003C_003E4__this._guildStateService.GetCurrentGuild();
								if (_003C_003E4__this.CurrentGuild != null)
								{
									_003C_003E4__this.PopulateGuildContent(_003C_003E4__this.CurrentGuild);
									_003C_003E4__this.UpdateVisibilityState();
									if (_003C_003E4__this._isPageActive)
									{
										_003C_003E4__this.StartGuildListeners();
									}
									awaiter3 = _003C_003E4__this._navigationService.ShowAlertAsync("Success", "Welcome to '" + _003C_003E4__this.CurrentGuild.Name + "'!").GetAwaiter();
									if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
									{
										num = (_003C_003E1__state = 5);
										_003C_003Eu__1 = awaiter3;
										_003CJoinGuildAsync_003Ed__101 _003CJoinGuildAsync_003Ed__ = this;
										((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CJoinGuildAsync_003Ed__101>(ref awaiter3, ref _003CJoinGuildAsync_003Ed__);
										return;
									}
									goto IL_0512;
								}
								awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to join guild. It may be full.").GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
								{
									num = (_003C_003E1__state = 6);
									_003C_003Eu__1 = awaiter2;
									_003CJoinGuildAsync_003Ed__101 _003CJoinGuildAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CJoinGuildAsync_003Ed__101>(ref awaiter2, ref _003CJoinGuildAsync_003Ed__);
									return;
								}
								goto IL_058e;
								IL_0126:
								((TaskAwaiter)(ref awaiter8)).GetResult();
								goto end_IL_0025;
								IL_0512:
								((TaskAwaiter)(ref awaiter3)).GetResult();
								break;
								IL_02d1:
								((TaskAwaiter)(ref awaiter6)).GetResult();
								goto end_IL_0025;
								IL_0373:
								((TaskAwaiter)(ref awaiter5)).GetResult();
								goto end_IL_0025;
								IL_058e:
								((TaskAwaiter)(ref awaiter2)).GetResult();
								break;
							}
							_003Cplayer_003E5__3 = null;
							_003Crequest_003E5__4 = null;
							_003Cplayercurrencies_003E5__5 = null;
							_003Cresult_003E5__6 = null;
						}
						catch (global::System.Exception ex)
						{
							_003C_003Es__1 = ex;
							_003C_003Es__2 = 1;
						}
						int num2 = _003C_003Es__2;
						if (num2 != 1)
						{
							goto IL_06a1;
						}
						_003Cex_003E5__8 = (global::System.Exception)_003C_003Es__1;
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to join guild.").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 7);
							_003C_003Eu__1 = awaiter;
							_003CJoinGuildAsync_003Ed__101 _003CJoinGuildAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CJoinGuildAsync_003Ed__101>(ref awaiter, ref _003CJoinGuildAsync_003Ed__);
							return;
						}
						goto IL_065d;
						IL_065d:
						((TaskAwaiter)(ref awaiter)).GetResult();
						Console.WriteLine($"JoinGuildAsync error: {_003Cex_003E5__8}");
						_003Cex_003E5__8 = null;
						goto IL_06a1;
						IL_06a1:
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
	private sealed class _003CLeaveGuild_003Ed__90 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildHubViewModel _003C_003E4__this;

		private global::System.Collections.Generic.IReadOnlyList<GuildMember> _003Cmembers_003E5__1;

		private bool _003CdeleteGuild_003E5__2;

		private bool _003CshouldLeave_003E5__3;

		private bool _003C_003Es__4;

		private bool _003C_003Es__5;

		private object _003C_003Es__6;

		private int _003C_003Es__7;

		private string _003CplayerId_003E5__8;

		private string _003CguildId_003E5__9;

		private LeaveGuildRequest _003Crequest_003E5__10;

		private Result<LeaveGuildResult> _003Cresult_003E5__11;

		private Result<LeaveGuildResult> _003C_003Es__12;

		private global::System.Exception _003Cex_003E5__13;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<bool> _003C_003Eu__2;

		private TaskAwaiter<Result<LeaveGuildResult>> _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_06b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_06ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_0283: Unknown result type (might be due to invalid IL or missing references)
			//IL_0288: Unknown result type (might be due to invalid IL or missing references)
			//IL_0290: Unknown result type (might be due to invalid IL or missing references)
			//IL_06cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_06d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_06ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_06f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_06f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0460: Unknown result type (might be due to invalid IL or missing references)
			//IL_0465: Unknown result type (might be due to invalid IL or missing references)
			//IL_046d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0517: Unknown result type (might be due to invalid IL or missing references)
			//IL_051c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0524: Unknown result type (might be due to invalid IL or missing references)
			//IL_05ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_05f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_05fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_05b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_05ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_05cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_05d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_04dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_04e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_04f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_04f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0426: Unknown result type (might be due to invalid IL or missing references)
			//IL_042b: Unknown result type (might be due to invalid IL or missing references)
			//IL_038a: Unknown result type (might be due to invalid IL or missing references)
			//IL_038f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0249: Unknown result type (might be due to invalid IL or missing references)
			//IL_024e: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0440: Unknown result type (might be due to invalid IL or missing references)
			//IL_0442: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0263: Unknown result type (might be due to invalid IL or missing references)
			//IL_0265: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter3;
				TaskAwaiter<bool> awaiter2;
				TaskAwaiter<bool> awaiter;
				switch (num)
				{
				default:
					if (_003C_003E4__this._playerState.GetCurrentPlayer() != null && _003C_003E4__this.CurrentGuild != null)
					{
						_003Cmembers_003E5__1 = _003C_003E4__this._guildStateService.GetMembers();
						Player? currentPlayer = _003C_003E4__this._playerState.GetCurrentPlayer();
						if (currentPlayer != null && currentPlayer.GuildRole == GuildRole.Guildmaster && ((global::System.Collections.Generic.IReadOnlyCollection<GuildMember>)_003Cmembers_003E5__1).Count > 1)
						{
							awaiter3 = _003C_003E4__this._navigationService.ShowAlertAsync("Error leaving guild!", "You are the leader, change leadership or demote yourself before leaving guild.").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter3;
								_003CLeaveGuild_003Ed__90 _003CLeaveGuild_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLeaveGuild_003Ed__90>(ref awaiter3, ref _003CLeaveGuild_003Ed__);
								return;
							}
							goto IL_012b;
						}
						_003CdeleteGuild_003E5__2 = false;
						if (((global::System.Collections.Generic.IReadOnlyCollection<GuildMember>)_003Cmembers_003E5__1).Count == 1 && Enumerable.First<GuildMember>((global::System.Collections.Generic.IEnumerable<GuildMember>)_003Cmembers_003E5__1).PlayerId == _003C_003E4__this._playerState.CurrentPlayerId)
						{
							awaiter2 = _003C_003E4__this._navigationService.ShowConfirmationAsync("You are the only member!", "Leaving guild will delete this guild forever. Do you want to proceed?").GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__2 = awaiter2;
								_003CLeaveGuild_003Ed__90 _003CLeaveGuild_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CLeaveGuild_003Ed__90>(ref awaiter2, ref _003CLeaveGuild_003Ed__);
								return;
							}
							goto IL_01f9;
						}
						awaiter = _003C_003E4__this._navigationService.ShowConfirmationAsync("Leave Guild?", "Are you sure you want to leave this guild?").GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__2 = awaiter;
							_003CLeaveGuild_003Ed__90 _003CLeaveGuild_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CLeaveGuild_003Ed__90>(ref awaiter, ref _003CLeaveGuild_003Ed__);
							return;
						}
						goto IL_029f;
					}
					goto end_IL_0007;
				case 0:
					awaiter3 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_012b;
				case 1:
					awaiter2 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
					goto IL_01f9;
				case 2:
					awaiter = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
					goto IL_029f;
				case 3:
				case 4:
				case 5:
				case 6:
				case 7:
					break;
					IL_02b9:
					if (_003CshouldLeave_003E5__3)
					{
						break;
					}
					goto end_IL_0007;
					IL_029f:
					_003C_003Es__5 = awaiter.GetResult();
					_003CshouldLeave_003E5__3 = _003C_003Es__5;
					goto IL_02b9;
					IL_012b:
					((TaskAwaiter)(ref awaiter3)).GetResult();
					goto end_IL_0007;
					IL_01f9:
					_003C_003Es__4 = awaiter2.GetResult();
					_003CshouldLeave_003E5__3 = _003C_003Es__4;
					_003CdeleteGuild_003E5__2 = _003CshouldLeave_003E5__3;
					goto IL_02b9;
				}
				try
				{
					TaskAwaiter awaiter4;
					if ((uint)(num - 3) > 3u)
					{
						if (num == 7)
						{
							awaiter4 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0708;
						}
						_003C_003Es__7 = 0;
					}
					try
					{
						TaskAwaiter awaiter8;
						TaskAwaiter<Result<LeaveGuildResult>> awaiter7;
						TaskAwaiter awaiter6;
						TaskAwaiter awaiter5;
						switch (num)
						{
						default:
							_003CplayerId_003E5__8 = _003C_003E4__this._playerState.CurrentPlayerId;
							_003CguildId_003E5__9 = _003C_003E4__this.CurrentGuild?.ID;
							if (string.IsNullOrEmpty(_003CplayerId_003E5__8) || string.IsNullOrEmpty(_003CguildId_003E5__9))
							{
								awaiter8 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Unable to leave guild. Missing player or guild information.").GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter8)).IsCompleted)
								{
									num = (_003C_003E1__state = 3);
									_003C_003Eu__1 = awaiter8;
									_003CLeaveGuild_003Ed__90 _003CLeaveGuild_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLeaveGuild_003Ed__90>(ref awaiter8, ref _003CLeaveGuild_003Ed__);
									return;
								}
								goto IL_03e0;
							}
							_003C_003E4__this.StopGuildListeners();
							_003Crequest_003E5__10 = new LeaveGuildRequest(_003CplayerId_003E5__8, _003CguildId_003E5__9);
							awaiter7 = _003C_003E4__this._leaveGuildUseCase.ExecuteAsync(_003Crequest_003E5__10).GetAwaiter();
							if (!awaiter7.IsCompleted)
							{
								num = (_003C_003E1__state = 4);
								_003C_003Eu__3 = awaiter7;
								_003CLeaveGuild_003Ed__90 _003CLeaveGuild_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<LeaveGuildResult>>, _003CLeaveGuild_003Ed__90>(ref awaiter7, ref _003CLeaveGuild_003Ed__);
								return;
							}
							goto IL_047c;
						case 3:
							awaiter8 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_03e0;
						case 4:
							awaiter7 = _003C_003Eu__3;
							_003C_003Eu__3 = default(TaskAwaiter<Result<LeaveGuildResult>>);
							num = (_003C_003E1__state = -1);
							goto IL_047c;
						case 5:
							awaiter6 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0533;
						case 6:
							{
								awaiter5 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								break;
							}
							IL_047c:
							_003C_003Es__12 = awaiter7.GetResult();
							_003Cresult_003E5__11 = _003C_003Es__12;
							_003C_003Es__12 = null;
							if (!_003Cresult_003E5__11.Success)
							{
								awaiter6 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", _003Cresult_003E5__11.ErrorMessage ?? "Failed to leave guild").GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter6)).IsCompleted)
								{
									num = (_003C_003E1__state = 5);
									_003C_003Eu__1 = awaiter6;
									_003CLeaveGuild_003Ed__90 _003CLeaveGuild_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLeaveGuild_003Ed__90>(ref awaiter6, ref _003CLeaveGuild_003Ed__);
									return;
								}
								goto IL_0533;
							}
							_003C_003E4__this._guildStateService.ClearCurrentGuild();
							_003C_003E4__this.HasGuild = false;
							_003C_003E4__this._currentGuildId = null;
							_003C_003E4__this.CurrentGuild = null;
							_003C_003E4__this.ClearGuildContent();
							_003C_003E4__this.UpdateVisibilityState();
							awaiter5 = _003C_003E4__this._navigationService.ShowAlertAsync("Left Guild", "You have successfully left the guild.").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter5)).IsCompleted)
							{
								num = (_003C_003E1__state = 6);
								_003C_003Eu__1 = awaiter5;
								_003CLeaveGuild_003Ed__90 _003CLeaveGuild_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLeaveGuild_003Ed__90>(ref awaiter5, ref _003CLeaveGuild_003Ed__);
								return;
							}
							break;
							IL_03e0:
							((TaskAwaiter)(ref awaiter8)).GetResult();
							goto end_IL_02ec;
							IL_0533:
							((TaskAwaiter)(ref awaiter6)).GetResult();
							_003C_003E4__this.StartGuildListeners();
							goto end_IL_02ec;
						}
						((TaskAwaiter)(ref awaiter5)).GetResult();
						_003CplayerId_003E5__8 = null;
						_003CguildId_003E5__9 = null;
						_003Crequest_003E5__10 = null;
						_003Cresult_003E5__11 = null;
						goto IL_0645;
						end_IL_02ec:;
					}
					catch (global::System.Exception ex)
					{
						_003C_003Es__6 = ex;
						_003C_003Es__7 = 1;
						goto IL_0645;
					}
					goto end_IL_02cf;
					IL_0645:
					int num2 = _003C_003Es__7;
					if (num2 != 1)
					{
						goto IL_071a;
					}
					_003Cex_003E5__13 = (global::System.Exception)_003C_003Es__6;
					Console.WriteLine($"LeaveGuild error: {_003Cex_003E5__13}");
					awaiter4 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to leave guild. Please try again.").GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
					{
						num = (_003C_003E1__state = 7);
						_003C_003Eu__1 = awaiter4;
						_003CLeaveGuild_003Ed__90 _003CLeaveGuild_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLeaveGuild_003Ed__90>(ref awaiter4, ref _003CLeaveGuild_003Ed__);
						return;
					}
					goto IL_0708;
					IL_0708:
					((TaskAwaiter)(ref awaiter4)).GetResult();
					_003Cex_003E5__13 = null;
					goto IL_071a;
					IL_071a:
					_003C_003Es__6 = null;
					end_IL_02cf:;
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this.HideOptions = true;
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
	private sealed class _003CLoadDataAsync_003Ed__79 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public object parameter;

		public GuildHubViewModel _003C_003E4__this;

		private string _003CplayerGuildId_003E5__1;

		private bool _003CplayerHasGuild_003E5__2;

		private bool _003CmembershipChanged_003E5__3;

		private global::System.Exception _003Cex_003E5__4;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_024d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0252: Unknown result type (might be due to invalid IL or missing references)
			//IL_025a: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_028c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0291: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0213: Unknown result type (might be due to invalid IL or missing references)
			//IL_0218: Unknown result type (might be due to invalid IL or missing references)
			//IL_022d: Unknown result type (might be due to invalid IL or missing references)
			//IL_022f: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 1u || !_003C_003E4__this.IsLoading)
				{
					try
					{
						TaskAwaiter awaiter;
						if (num == 0)
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0269;
						}
						TaskAwaiter awaiter2;
						if (num == 1)
						{
							awaiter2 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_02e2;
						}
						_003C_003E4__this.IsLoading = true;
						_003C_003E4__this.IsInitialized = false;
						_003C_003E4__this.ErrorMessage = string.Empty;
						Console.WriteLine("GuildHubViewModel.LoadDataAsync: Starting initialization...");
						if (_003C_003E4__this._playerState?.GetCurrentPlayer() != null)
						{
							_003CplayerGuildId_003E5__1 = _003C_003E4__this._playerState?.GetCurrentPlayer()?.GuildId;
							_003CplayerHasGuild_003E5__2 = !string.IsNullOrEmpty(_003CplayerGuildId_003E5__1);
							_003CmembershipChanged_003E5__3 = _003C_003E4__this.HasGuild != _003CplayerHasGuild_003E5__2 || _003C_003E4__this._currentGuildId != _003CplayerGuildId_003E5__1;
							_003C_003E4__this.HasGuild = _003CplayerHasGuild_003E5__2;
							_003C_003E4__this._currentGuildId = _003CplayerGuildId_003E5__1;
							Console.WriteLine($"GuildHubViewModel.LoadDataAsync: HasGuild={_003C_003E4__this.HasGuild}, GuildId={_003C_003E4__this._currentGuildId}, MembershipChanged={_003CmembershipChanged_003E5__3}");
							if (_003C_003E4__this.HasGuild)
							{
								if (_003CmembershipChanged_003E5__3)
								{
									_003C_003E4__this.CurrentGuild = null;
								}
								awaiter = _003C_003E4__this.LoadInitialGuildData("LoadDataAsync", "C:\\Users\\lfgam\\source\\repos\\Abugu100\\SpiritSummoner\\SpiritSummoner\\Presentation\\ViewModels\\Guilds\\GuildHubViewModel.cs", 366).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter;
									_003CLoadDataAsync_003Ed__79 _003CLoadDataAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__79>(ref awaiter, ref _003CLoadDataAsync_003Ed__);
									return;
								}
								goto IL_0269;
							}
							_003C_003E4__this.ClearGuildContent();
							awaiter2 = _003C_003E4__this.LoadPendingInvitationCountAsync().GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__1 = awaiter2;
								_003CLoadDataAsync_003Ed__79 _003CLoadDataAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__79>(ref awaiter2, ref _003CLoadDataAsync_003Ed__);
								return;
							}
							goto IL_02e2;
						}
						Console.WriteLine("GuildHubViewModel.LoadDataAsync: Player data not yet available");
						_003C_003E4__this.HasGuild = false;
						_003C_003E4__this.UpdateVisibilityState();
						_003C_003E4__this.IsInitialized = true;
						goto end_IL_0025;
						IL_0269:
						((TaskAwaiter)(ref awaiter)).GetResult();
						goto IL_02eb;
						IL_02e2:
						((TaskAwaiter)(ref awaiter2)).GetResult();
						goto IL_02eb;
						IL_02eb:
						_003C_003E4__this.IsInitialized = true;
						_003C_003E4__this.UpdateVisibilityState();
						Console.WriteLine($"GuildHubViewModel.LoadDataAsync: Initialization complete. ShowGuildContent={_003C_003E4__this.ShowGuildContent}, ShowNoGuildContent={_003C_003E4__this.ShowNoGuildContent}");
						_003CplayerGuildId_003E5__1 = null;
						end_IL_0025:;
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__4 = ex;
						Console.WriteLine($"GuildHubViewModel.LoadDataAsync error: {_003Cex_003E5__4}");
						_003C_003E4__this.ErrorMessage = "Failed to load guild data";
						_003C_003E4__this.IsInitialized = true;
						_003C_003E4__this.HasGuild = false;
						_003C_003E4__this.UpdateVisibilityState();
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
	private sealed class _003CLoadInitialGuildData_003Ed__82 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string memberName;

		public string sourceFilePath;

		public int sourceLineNumber;

		public GuildHubViewModel _003C_003E4__this;

		private Guild _003CcachedGuild_003E5__1;

		private GetGuildDetailsRequest _003Crequest_003E5__2;

		private Result<Guild> _003Cresult_003E5__3;

		private Result<Guild> _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter<Result<Guild>> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0153: Unknown result type (might be due to invalid IL or missing references)
			//IL_0158: Unknown result type (might be due to invalid IL or missing references)
			//IL_015f: Unknown result type (might be due to invalid IL or missing references)
			//IL_020a: Unknown result type (might be due to invalid IL or missing references)
			//IL_020f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0217: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0121: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0135: Unknown result type (might be due to invalid IL or missing references)
			//IL_0136: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num > 2u)
				{
				}
				try
				{
					TaskAwaiter<Result<Guild>> awaiter3;
					TaskAwaiter awaiter2;
					TaskAwaiter awaiter;
					switch (num)
					{
					default:
						Trace.WriteLine("Checking caller to loadinitial guild data");
						Trace.WriteLine("member name: " + memberName);
						Trace.WriteLine("source file path: " + sourceFilePath);
						Trace.WriteLine("source line number: " + sourceLineNumber);
						_003CcachedGuild_003E5__1 = _003C_003E4__this._guildStateService.GetCurrentGuild();
						if (!_003C_003E4__this.HasGuild || _003CcachedGuild_003E5__1 == null)
						{
							_003Crequest_003E5__2 = new GetGuildDetailsRequest(_003C_003E4__this._currentGuildId);
							awaiter3 = _003C_003E4__this._getGuildDetailsUseCase.ExecuteAsync(_003Crequest_003E5__2).GetAwaiter();
							if (!awaiter3.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter3;
								_003CLoadInitialGuildData_003Ed__82 _003CLoadInitialGuildData_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<Guild>>, _003CLoadInitialGuildData_003Ed__82>(ref awaiter3, ref _003CLoadInitialGuildData_003Ed__);
								return;
							}
							goto IL_016e;
						}
						_003C_003E4__this.CurrentGuild = _003CcachedGuild_003E5__1;
						_003C_003E4__this.PopulateGuildContent(_003CcachedGuild_003E5__1);
						_003C_003E4__this.UpdateVisibilityState();
						goto end_IL_0011;
					case 0:
						awaiter3 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Result<Guild>>);
						num = (_003C_003E1__state = -1);
						goto IL_016e;
					case 1:
						awaiter2 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0226;
					case 2:
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0306;
						}
						IL_016e:
						_003C_003Es__4 = awaiter3.GetResult();
						_003Cresult_003E5__3 = _003C_003Es__4;
						_003C_003Es__4 = null;
						if (_003Cresult_003E5__3.Success && _003Cresult_003E5__3.Data != null)
						{
							awaiter2 = _003C_003E4__this._guildStateService.SetCurrentGuildAsync(_003C_003E4__this._currentGuildId).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__2 = awaiter2;
								_003CLoadInitialGuildData_003Ed__82 _003CLoadInitialGuildData_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadInitialGuildData_003Ed__82>(ref awaiter2, ref _003CLoadInitialGuildData_003Ed__);
								return;
							}
							goto IL_0226;
						}
						_003C_003E4__this.HasGuild = false;
						_003C_003E4__this.UpdateVisibilityState();
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Guild Not Found", _003Cresult_003E5__3.ErrorMessage ?? "Your guild could not be found. You may have been removed.").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__2 = awaiter;
							_003CLoadInitialGuildData_003Ed__82 _003CLoadInitialGuildData_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadInitialGuildData_003Ed__82>(ref awaiter, ref _003CLoadInitialGuildData_003Ed__);
							return;
						}
						goto IL_0306;
						IL_0226:
						((TaskAwaiter)(ref awaiter2)).GetResult();
						_003C_003E4__this.CurrentGuild = _003Cresult_003E5__3.Data;
						_003C_003E4__this.PopulateGuildContent(_003Cresult_003E5__3.Data);
						_003C_003E4__this.UpdateVisibilityState();
						break;
						IL_0306:
						((TaskAwaiter)(ref awaiter)).GetResult();
						break;
					}
					_003CcachedGuild_003E5__1 = null;
					_003Crequest_003E5__2 = null;
					_003Cresult_003E5__3 = null;
					end_IL_0011:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__5 = ex;
					Console.WriteLine($"LoadInitialGuildData error: {_003Cex_003E5__5}");
					_003C_003E4__this.HasGuild = false;
					_003C_003E4__this.UpdateVisibilityState();
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
	private sealed class _003CLoadPendingInvitationCountAsync_003Ed__108 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildHubViewModel _003C_003E4__this;

		private string _003CplayerId_003E5__1;

		private GetPlayerInvitationsRequest _003Crequest_003E5__2;

		private Result<List<GuildInvitation>> _003Cresult_003E5__3;

		private Result<List<GuildInvitation>> _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter<Result<List<GuildInvitation>>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
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
						goto IL_00d8;
					}
					_003CplayerId_003E5__1 = _003C_003E4__this._playerState.GetCurrentPlayer()?.PlayerID;
					if (!string.IsNullOrEmpty(_003CplayerId_003E5__1))
					{
						_003Crequest_003E5__2 = new GetPlayerInvitationsRequest(_003CplayerId_003E5__1);
						awaiter = _003C_003E4__this._getPlayerInvitationsUseCase.ExecuteAsync(_003Crequest_003E5__2).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CLoadPendingInvitationCountAsync_003Ed__108 _003CLoadPendingInvitationCountAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<List<GuildInvitation>>>, _003CLoadPendingInvitationCountAsync_003Ed__108>(ref awaiter, ref _003CLoadPendingInvitationCountAsync_003Ed__);
							return;
						}
						goto IL_00d8;
					}
					_003C_003E4__this.PendingInvitationCount = 0;
					goto end_IL_0010;
					IL_00d8:
					_003C_003Es__4 = awaiter.GetResult();
					_003Cresult_003E5__3 = _003C_003Es__4;
					_003C_003Es__4 = null;
					if (_003Cresult_003E5__3.Success && _003Cresult_003E5__3.Data != null)
					{
						_003C_003E4__this.PendingInvitationCount = _003Cresult_003E5__3.Data.Count;
					}
					else
					{
						_003C_003E4__this.PendingInvitationCount = 0;
					}
					Console.WriteLine($"LoadPendingInvitationCount - Count: {_003C_003E4__this.PendingInvitationCount}");
					_003CplayerId_003E5__1 = null;
					_003Crequest_003E5__2 = null;
					_003Cresult_003E5__3 = null;
					end_IL_0010:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__5 = ex;
					Console.WriteLine($"LoadPendingInvitationCount error: {_003Cex_003E5__5}");
					_003C_003E4__this.PendingInvitationCount = 0;
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
	private sealed class _003CNavigateToMembers_003Ed__104 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildHubViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0120: Unknown result type (might be due to invalid IL or missing references)
			//IL_0125: Unknown result type (might be due to invalid IL or missing references)
			//IL_013a: Unknown result type (might be due to invalid IL or missing references)
			//IL_013c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0159: Unknown result type (might be due to invalid IL or missing references)
			//IL_015e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0166: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num == 0)
				{
					goto IL_0039;
				}
				TaskAwaiter awaiter;
				if (num == 1)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0175;
				}
				if (_003C_003E4__this.HasGuild)
				{
					_003C_003Es__2 = 0;
					goto IL_0039;
				}
				goto end_IL_0007;
				IL_01b9:
				_003C_003Es__1 = null;
				goto end_IL_0007;
				IL_0175:
				((TaskAwaiter)(ref awaiter)).GetResult();
				Console.WriteLine($"NavigateToMembers error: {_003Cex_003E5__3}");
				_003Cex_003E5__3 = null;
				goto IL_01b9;
				IL_0039:
				try
				{
					TaskAwaiter awaiter2;
					if (num != 0)
					{
						awaiter2 = _003C_003E4__this._navigationService.NavigateToAsync("//guild/members?guildId=" + _003C_003E4__this.CurrentGuild?.ID).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CNavigateToMembers_003Ed__104 _003CNavigateToMembers_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToMembers_003Ed__104>(ref awaiter2, ref _003CNavigateToMembers_003Ed__);
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
					goto IL_01b9;
				}
				_003Cex_003E5__3 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Navigation Error", "Failed to open members page.").GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = awaiter;
					_003CNavigateToMembers_003Ed__104 _003CNavigateToMembers_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToMembers_003Ed__104>(ref awaiter, ref _003CNavigateToMembers_003Ed__);
					return;
				}
				goto IL_0175;
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
	private sealed class _003CNavigateToShop_003Ed__106 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildHubViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0120: Unknown result type (might be due to invalid IL or missing references)
			//IL_0125: Unknown result type (might be due to invalid IL or missing references)
			//IL_013a: Unknown result type (might be due to invalid IL or missing references)
			//IL_013c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0159: Unknown result type (might be due to invalid IL or missing references)
			//IL_015e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0166: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num == 0)
				{
					goto IL_0039;
				}
				TaskAwaiter awaiter;
				if (num == 1)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0175;
				}
				if (_003C_003E4__this.HasGuild)
				{
					_003C_003Es__2 = 0;
					goto IL_0039;
				}
				goto end_IL_0007;
				IL_01b9:
				_003C_003Es__1 = null;
				goto end_IL_0007;
				IL_0175:
				((TaskAwaiter)(ref awaiter)).GetResult();
				Console.WriteLine($"NavigateToShop error: {_003Cex_003E5__3}");
				_003Cex_003E5__3 = null;
				goto IL_01b9;
				IL_0039:
				try
				{
					TaskAwaiter awaiter2;
					if (num != 0)
					{
						awaiter2 = _003C_003E4__this._navigationService.NavigateToAsync("//guild/shop?guildId=" + _003C_003E4__this.CurrentGuild?.ID).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CNavigateToShop_003Ed__106 _003CNavigateToShop_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToShop_003Ed__106>(ref awaiter2, ref _003CNavigateToShop_003Ed__);
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
					goto IL_01b9;
				}
				_003Cex_003E5__3 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Navigation Error", "Failed to open guild shop.").GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = awaiter;
					_003CNavigateToShop_003Ed__106 _003CNavigateToShop_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToShop_003Ed__106>(ref awaiter, ref _003CNavigateToShop_003Ed__);
					return;
				}
				goto IL_0175;
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
	private sealed class _003CNavigateToWars_003Ed__105 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildHubViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0120: Unknown result type (might be due to invalid IL or missing references)
			//IL_0125: Unknown result type (might be due to invalid IL or missing references)
			//IL_013a: Unknown result type (might be due to invalid IL or missing references)
			//IL_013c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0159: Unknown result type (might be due to invalid IL or missing references)
			//IL_015e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0166: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num == 0)
				{
					goto IL_0039;
				}
				TaskAwaiter awaiter;
				if (num == 1)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0175;
				}
				if (_003C_003E4__this.HasGuild)
				{
					_003C_003Es__2 = 0;
					goto IL_0039;
				}
				goto end_IL_0007;
				IL_01b9:
				_003C_003Es__1 = null;
				goto end_IL_0007;
				IL_0175:
				((TaskAwaiter)(ref awaiter)).GetResult();
				Console.WriteLine($"NavigateToWars error: {_003Cex_003E5__3}");
				_003Cex_003E5__3 = null;
				goto IL_01b9;
				IL_0039:
				try
				{
					TaskAwaiter awaiter2;
					if (num != 0)
					{
						awaiter2 = _003C_003E4__this._navigationService.NavigateToAsync("//guild/wars?guildId=" + _003C_003E4__this.CurrentGuild?.ID).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CNavigateToWars_003Ed__105 _003CNavigateToWars_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToWars_003Ed__105>(ref awaiter2, ref _003CNavigateToWars_003Ed__);
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
					goto IL_01b9;
				}
				_003Cex_003E5__3 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Navigation Error", "Failed to open guild wars.").GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = awaiter;
					_003CNavigateToWars_003Ed__105 _003CNavigateToWars_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToWars_003Ed__105>(ref awaiter, ref _003CNavigateToWars_003Ed__);
					return;
				}
				goto IL_0175;
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
	private sealed class _003COnGuildMembershipChanged_003Ed__81 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildHubViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					_003C_003E4__this.StopGuildListeners();
					awaiter = _003C_003E4__this.CheckGuildMembership().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003COnGuildMembershipChanged_003Ed__81 _003COnGuildMembershipChanged_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnGuildMembershipChanged_003Ed__81>(ref awaiter, ref _003COnGuildMembershipChanged_003Ed__);
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
				if (_003C_003E4__this.HasGuild && _003C_003E4__this._isPageActive && !string.IsNullOrEmpty(_003C_003E4__this._currentGuildId))
				{
					_003C_003E4__this.StartGuildListeners();
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
	private sealed class _003COnPageAppearingAsync_003Ed__77 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildHubViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0103;
				}
				_003C_003E4__this._isPageActive = true;
				Console.WriteLine("OnPageAppearingAsync: Page became active");
				if (_003C_003E4__this.HasGuild && !string.IsNullOrEmpty(_003C_003E4__this._currentGuildId))
				{
					_003C_003E4__this.StartGuildListeners();
				}
				else
				{
					Console.WriteLine("OnPageAppearingAsync: No guild, skipping listeners");
				}
				if (!_003C_003E4__this.IsInitialized && _003C_003E4__this._playerState?.GetCurrentPlayer() != null)
				{
					Console.WriteLine("OnPageAppearingAsync: Late initialization detected, reloading data");
					awaiter = _003C_003E4__this.LoadDataAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003COnPageAppearingAsync_003Ed__77 _003COnPageAppearingAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnPageAppearingAsync_003Ed__77>(ref awaiter, ref _003COnPageAppearingAsync_003Ed__);
						return;
					}
					goto IL_0103;
				}
				goto end_IL_0007;
				IL_0103:
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
	private sealed class _003COnPlayerUpdatedSelective_003Ed__76 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public object sender;

		public StateChangedEventArgs e;

		public GuildHubViewModel _003C_003E4__this;

		private string _003C_003Es__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Unknown result type (might be due to invalid IL or missing references)
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_011a;
				}
				if (e.Scope == StateChangeScope.Player)
				{
					string changeType = e.ChangeType;
					_003C_003Es__1 = changeType;
					string text = _003C_003Es__1;
					if (!(text == "Currencies"))
					{
						if (!(text == "Guild"))
						{
							if (text == "AccountLinked")
							{
								Console.WriteLine("GuildHubViewModel: Account linked event received");
								if (_003C_003E4__this._isPageActive && _003C_003E4__this.HasGuild && !string.IsNullOrEmpty(_003C_003E4__this._currentGuildId))
								{
									_003C_003E4__this.StartGuildListeners();
								}
								((ObservableObject)_003C_003E4__this).OnPropertyChanged("IsAccountLinked");
							}
						}
						else if ((string)CollectionExtensions.GetValueOrDefault<string, object>(e.ChangedValues, "guildId") != _003C_003E4__this._currentGuildId)
						{
							awaiter = _003C_003E4__this.OnGuildMembershipChanged().GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003COnPlayerUpdatedSelective_003Ed__76 _003COnPlayerUpdatedSelective_003Ed__ = this;
								((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnPlayerUpdatedSelective_003Ed__76>(ref awaiter, ref _003COnPlayerUpdatedSelective_003Ed__);
								return;
							}
							goto IL_011a;
						}
					}
					else
					{
						((ObservableObject)_003C_003E4__this).OnPropertyChanged("CurrentPlayerGuildCoins");
					}
					goto IL_0187;
				}
				goto end_IL_0007;
				IL_011a:
				((TaskAwaiter)(ref awaiter)).GetResult();
				goto IL_0187;
				IL_0187:
				_003C_003Es__1 = null;
				end_IL_0007:;
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

	[CompilerGenerated]
	private sealed class _003COpenInvitations_003Ed__107 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildHubViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private object _003Cresult_003E5__3;

		private bool _003Caccepted_003E5__4;

		private object _003C_003Es__5;

		private global::System.Exception _003Cex_003E5__6;

		private TaskAwaiter<object?> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0240: Unknown result type (might be due to invalid IL or missing references)
			//IL_0245: Unknown result type (might be due to invalid IL or missing references)
			//IL_0279: Unknown result type (might be due to invalid IL or missing references)
			//IL_027e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0286: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0303: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_025a: Unknown result type (might be due to invalid IL or missing references)
			//IL_025c: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0158: Unknown result type (might be due to invalid IL or missing references)
			//IL_015d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0165: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0188: Unknown result type (might be due to invalid IL or missing references)
			//IL_018d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_011f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0124: Unknown result type (might be due to invalid IL or missing references)
			//IL_0139: Unknown result type (might be due to invalid IL or missing references)
			//IL_013b: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter2;
				TaskAwaiter awaiter;
				switch (num)
				{
				default:
					_003C_003Es__2 = 0;
					goto case 0;
				case 0:
				case 1:
				case 2:
				{
					try
					{
						TaskAwaiter<object> awaiter5;
						TaskAwaiter awaiter4;
						TaskAwaiter awaiter3;
						int num2;
						switch (num)
						{
						default:
							awaiter5 = _003C_003E4__this._popupService.ShowPopupAsync<GuildInvitationsPopupViewModel>(default(CancellationToken)).GetAwaiter();
							if (!awaiter5.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter5;
								_003COpenInvitations_003Ed__107 _003COpenInvitations_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<object>, _003COpenInvitations_003Ed__107>(ref awaiter5, ref _003COpenInvitations_003Ed__);
								return;
							}
							goto IL_00c4;
						case 0:
							awaiter5 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<object>);
							num = (_003C_003E1__state = -1);
							goto IL_00c4;
						case 1:
							awaiter4 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0174;
						case 2:
							{
								awaiter3 = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								break;
							}
							IL_017d:
							awaiter3 = _003C_003E4__this.LoadPendingInvitationCountAsync().GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__2 = awaiter3;
								_003COpenInvitations_003Ed__107 _003COpenInvitations_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COpenInvitations_003Ed__107>(ref awaiter3, ref _003COpenInvitations_003Ed__);
								return;
							}
							break;
							IL_00c4:
							_003C_003Es__5 = awaiter5.GetResult();
							_003Cresult_003E5__3 = _003C_003Es__5;
							_003C_003Es__5 = null;
							if (_003Cresult_003E5__3 is bool)
							{
								_003Caccepted_003E5__4 = (bool)_003Cresult_003E5__3;
								num2 = 1;
							}
							else
							{
								num2 = 0;
							}
							if (((uint)num2 & (_003Caccepted_003E5__4 ? 1u : 0u)) != 0)
							{
								awaiter4 = _003C_003E4__this.CheckGuildMembership().GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__2 = awaiter4;
									_003COpenInvitations_003Ed__107 _003COpenInvitations_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COpenInvitations_003Ed__107>(ref awaiter4, ref _003COpenInvitations_003Ed__);
									return;
								}
								goto IL_0174;
							}
							goto IL_017d;
							IL_0174:
							((TaskAwaiter)(ref awaiter4)).GetResult();
							goto IL_017d;
						}
						((TaskAwaiter)(ref awaiter3)).GetResult();
						_003Cresult_003E5__3 = null;
					}
					catch (global::System.Exception ex)
					{
						_003C_003Es__1 = ex;
						_003C_003Es__2 = 1;
					}
					int num3 = _003C_003Es__2;
					if (num3 != 1)
					{
						break;
					}
					_003Cex_003E5__6 = (global::System.Exception)_003C_003Es__1;
					awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to open invitations.").GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 3);
						_003C_003Eu__2 = awaiter2;
						_003COpenInvitations_003Ed__107 _003COpenInvitations_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COpenInvitations_003Ed__107>(ref awaiter2, ref _003COpenInvitations_003Ed__);
						return;
					}
					goto IL_0295;
				}
				case 3:
					awaiter2 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0295;
				case 4:
					{
						awaiter = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0312;
					}
					IL_0312:
					((TaskAwaiter)(ref awaiter)).GetResult();
					Console.WriteLine($"OpenInvitations error: {_003Cex_003E5__6}");
					_003Cex_003E5__6 = null;
					break;
					IL_0295:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", _003Cex_003E5__6.Message).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 4);
						_003C_003Eu__2 = awaiter;
						_003COpenInvitations_003Ed__107 _003COpenInvitations_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COpenInvitations_003Ed__107>(ref awaiter, ref _003COpenInvitations_003Ed__);
						return;
					}
					goto IL_0312;
				}
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
	private sealed class _003CSearchGuildsAsync_003Ed__98 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildHubViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private SearchGuildsRequest _003Crequest_003E5__3;

		private Player _003Cplayer_003E5__4;

		private Player _003Cplayercurrencies_003E5__5;

		private Result<List<GuildSearchResultModel>> _003Cresult_003E5__6;

		private Result<List<GuildSearchResultModel>> _003C_003Es__7;

		private List<GuildSearchResult> _003CviewModelResults_003E5__8;

		private global::System.Exception _003Cex_003E5__9;

		private TaskAwaiter<Result<List<GuildSearchResultModel>>> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0333: Unknown result type (might be due to invalid IL or missing references)
			//IL_0338: Unknown result type (might be due to invalid IL or missing references)
			//IL_034d: Unknown result type (might be due to invalid IL or missing references)
			//IL_034f: Unknown result type (might be due to invalid IL or missing references)
			//IL_036c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0371: Unknown result type (might be due to invalid IL or missing references)
			//IL_0379: Unknown result type (might be due to invalid IL or missing references)
			//IL_0136: Unknown result type (might be due to invalid IL or missing references)
			//IL_013b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0142: Unknown result type (might be due to invalid IL or missing references)
			//IL_029d: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0264: Unknown result type (might be due to invalid IL or missing references)
			//IL_0269: Unknown result type (might be due to invalid IL or missing references)
			//IL_027e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0280: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0104: Unknown result type (might be due to invalid IL or missing references)
			//IL_0118: Unknown result type (might be due to invalid IL or missing references)
			//IL_0119: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 2u || !_003C_003E4__this.IsSearching)
				{
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
								goto IL_0388;
							}
							_003C_003Es__2 = 0;
						}
						try
						{
							TaskAwaiter awaiter2;
							TaskAwaiter<Result<List<GuildSearchResultModel>>> awaiter3;
							if (num != 0)
							{
								if (num == 1)
								{
									awaiter2 = _003C_003Eu__2;
									_003C_003Eu__2 = default(TaskAwaiter);
									num = (_003C_003E1__state = -1);
									goto IL_02b9;
								}
								_003C_003E4__this.IsSearching = true;
								string searchText = _003C_003E4__this.SearchText;
								GuildSearchFilters currentFilters = _003C_003E4__this.CurrentFilters;
								_003Cplayer_003E5__4 = _003C_003E4__this._playerState.GetCurrentPlayer();
								int playerLevel = ((_003Cplayer_003E5__4 == null) ? 1 : _003Cplayer_003E5__4.PlayerLevel);
								_003Cplayercurrencies_003E5__5 = _003C_003E4__this._playerState.GetCurrentPlayer();
								_003Crequest_003E5__3 = new SearchGuildsRequest(searchText, currentFilters, playerLevel, (_003Cplayercurrencies_003E5__5 != null) ? _003Cplayercurrencies_003E5__5.Currencies["reputation"] : 1);
								awaiter3 = _003C_003E4__this._searchGuildsUseCase.ExecuteAsync(_003Crequest_003E5__3).GetAwaiter();
								if (!awaiter3.IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter3;
									_003CSearchGuildsAsync_003Ed__98 _003CSearchGuildsAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<List<GuildSearchResultModel>>>, _003CSearchGuildsAsync_003Ed__98>(ref awaiter3, ref _003CSearchGuildsAsync_003Ed__);
									return;
								}
							}
							else
							{
								awaiter3 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter<Result<List<GuildSearchResultModel>>>);
								num = (_003C_003E1__state = -1);
							}
							_003C_003Es__7 = awaiter3.GetResult();
							_003Cresult_003E5__6 = _003C_003Es__7;
							_003C_003Es__7 = null;
							if (_003Cresult_003E5__6.Success && _003Cresult_003E5__6.Data != null)
							{
								_003CviewModelResults_003E5__8 = Enumerable.ToList<GuildSearchResult>(Enumerable.Select<GuildSearchResultModel, GuildSearchResult>((global::System.Collections.Generic.IEnumerable<GuildSearchResultModel>)_003Cresult_003E5__6.Data, (Func<GuildSearchResultModel, GuildSearchResult>)((GuildSearchResultModel model) => new GuildSearchResult
								{
									GuildId = model.Id,
									Name = model.Name,
									Emblem = model.Emblem,
									Level = model.Level,
									Rank = model.Rank,
									MemberCount = model.MemberCount,
									MaxMembers = model.MaxMembers,
									Trophies = model.Trophies,
									IsPublic = model.IsPublic,
									RequiresApproval = model.RequiresApproval,
									MinLevelRequired = model.MinLevelRequired,
									MinTrophiesRequired = model.MinTrophiesRequired,
									CanJoin = model.IsEligible
								})));
								_003C_003E4__this.AvailableGuilds = new ObservableCollection<GuildSearchResult>(_003CviewModelResults_003E5__8);
								_003C_003E4__this.SearchResultsCount = _003CviewModelResults_003E5__8.Count;
								_003CviewModelResults_003E5__8 = null;
							}
							else
							{
								_003C_003E4__this.AvailableGuilds = new ObservableCollection<GuildSearchResult>();
								_003C_003E4__this.SearchResultsCount = 0;
								if (!string.IsNullOrEmpty(_003Cresult_003E5__6.ErrorMessage))
								{
									awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Search Failed", _003Cresult_003E5__6.ErrorMessage).GetAwaiter();
									if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
									{
										num = (_003C_003E1__state = 1);
										_003C_003Eu__2 = awaiter2;
										_003CSearchGuildsAsync_003Ed__98 _003CSearchGuildsAsync_003Ed__ = this;
										((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSearchGuildsAsync_003Ed__98>(ref awaiter2, ref _003CSearchGuildsAsync_003Ed__);
										return;
									}
									goto IL_02b9;
								}
							}
							goto IL_02c3;
							IL_02b9:
							((TaskAwaiter)(ref awaiter2)).GetResult();
							goto IL_02c3;
							IL_02c3:
							_003Crequest_003E5__3 = null;
							_003Cplayer_003E5__4 = null;
							_003Cplayercurrencies_003E5__5 = null;
							_003Cresult_003E5__6 = null;
						}
						catch (global::System.Exception ex)
						{
							_003C_003Es__1 = ex;
							_003C_003Es__2 = 1;
						}
						int num2 = _003C_003Es__2;
						if (num2 != 1)
						{
							goto IL_03cc;
						}
						_003Cex_003E5__9 = (global::System.Exception)_003C_003Es__1;
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Search Error", "Failed to search guilds.").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__2 = awaiter;
							_003CSearchGuildsAsync_003Ed__98 _003CSearchGuildsAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSearchGuildsAsync_003Ed__98>(ref awaiter, ref _003CSearchGuildsAsync_003Ed__);
							return;
						}
						goto IL_0388;
						IL_0388:
						((TaskAwaiter)(ref awaiter)).GetResult();
						Console.WriteLine($"SearchGuildsAsync error: {_003Cex_003E5__9}");
						_003Cex_003E5__9 = null;
						goto IL_03cc;
						IL_03cc:
						_003C_003Es__1 = null;
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
	private sealed class _003CShowCreateGuildPopup_003Ed__100 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildHubViewModel _003C_003E4__this;

		private object _003Cresult_003E5__1;

		private Guild _003CnewGuild_003E5__2;

		private object _003C_003Es__3;

		private global::System.Exception _003Cex_003E5__4;

		private TaskAwaiter<object?> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_01be: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0185: Unknown result type (might be due to invalid IL or missing references)
			//IL_018a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_019f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num > 1u)
				{
				}
				try
				{
					TaskAwaiter awaiter;
					TaskAwaiter<object> awaiter2;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_01da;
						}
						awaiter2 = _003C_003E4__this._popupService.ShowPopupAsync<CreateGuildPopupViewModel>((Action<CreateGuildPopupViewModel>)([CompilerGenerated] (CreateGuildPopupViewModel vm) =>
						{
							vm.PlayerName = _003C_003E4__this._playerState.GetCurrentPlayer()?.Playername ?? "";
						}), default(CancellationToken)).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CShowCreateGuildPopup_003Ed__100 _003CShowCreateGuildPopup_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<object>, _003CShowCreateGuildPopup_003Ed__100>(ref awaiter2, ref _003CShowCreateGuildPopup_003Ed__);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<object>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__3 = awaiter2.GetResult();
					_003Cresult_003E5__1 = _003C_003Es__3;
					_003C_003Es__3 = null;
					_003CnewGuild_003E5__2 = _003Cresult_003E5__1 as Guild;
					if (_003CnewGuild_003E5__2 != null)
					{
						_003C_003E4__this.HasGuild = true;
						_003C_003E4__this._currentGuildId = _003CnewGuild_003E5__2.ID;
						_003C_003E4__this.CurrentGuild = _003CnewGuild_003E5__2;
						_003C_003E4__this.PopulateGuildContent(_003CnewGuild_003E5__2);
						_003C_003E4__this.UpdateVisibilityState();
						if (_003C_003E4__this._isPageActive)
						{
							_003C_003E4__this.StartGuildListeners();
						}
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Success", "Guild '" + _003CnewGuild_003E5__2.Name + "' created!").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter;
							_003CShowCreateGuildPopup_003Ed__100 _003CShowCreateGuildPopup_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CShowCreateGuildPopup_003Ed__100>(ref awaiter, ref _003CShowCreateGuildPopup_003Ed__);
							return;
						}
						goto IL_01da;
					}
					goto IL_01e3;
					IL_01e3:
					_003Cresult_003E5__1 = null;
					_003CnewGuild_003E5__2 = null;
					goto end_IL_0011;
					IL_01da:
					((TaskAwaiter)(ref awaiter)).GetResult();
					goto IL_01e3;
					end_IL_0011:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__4 = ex;
					Console.WriteLine($"ShowCreateGuildPopup error: {_003Cex_003E5__4}");
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
	private sealed class _003CShowFilterPopup_003Ed__99 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildHubViewModel _003C_003E4__this;

		private object _003Cresult_003E5__1;

		private GuildSearchFilters _003Cfilters_003E5__2;

		private object _003C_003Es__3;

		private global::System.Exception _003Cex_003E5__4;

		private TaskAwaiter<object?> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Unknown result type (might be due to invalid IL or missing references)
			//IL_0137: Unknown result type (might be due to invalid IL or missing references)
			//IL_013c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0144: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0118: Unknown result type (might be due to invalid IL or missing references)
			//IL_011a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num > 1u)
				{
				}
				try
				{
					TaskAwaiter awaiter;
					TaskAwaiter<object> awaiter2;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0153;
						}
						awaiter2 = _003C_003E4__this._popupService.ShowPopupAsync<GuildSearchFilterPopupViewModel>((Action<GuildSearchFilterPopupViewModel>)([CompilerGenerated] (GuildSearchFilterPopupViewModel vm) =>
						{
							vm.LoadFilters(_003C_003E4__this.CurrentFilters);
						}), default(CancellationToken)).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CShowFilterPopup_003Ed__99 _003CShowFilterPopup_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<object>, _003CShowFilterPopup_003Ed__99>(ref awaiter2, ref _003CShowFilterPopup_003Ed__);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<object>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__3 = awaiter2.GetResult();
					_003Cresult_003E5__1 = _003C_003Es__3;
					_003C_003Es__3 = null;
					_003Cfilters_003E5__2 = _003Cresult_003E5__1 as GuildSearchFilters;
					if (_003Cfilters_003E5__2 != null)
					{
						_003C_003E4__this.CurrentFilters = _003Cfilters_003E5__2;
						awaiter = _003C_003E4__this.SearchGuildsAsync().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter;
							_003CShowFilterPopup_003Ed__99 _003CShowFilterPopup_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CShowFilterPopup_003Ed__99>(ref awaiter, ref _003CShowFilterPopup_003Ed__);
							return;
						}
						goto IL_0153;
					}
					goto IL_015c;
					IL_0153:
					((TaskAwaiter)(ref awaiter)).GetResult();
					goto IL_015c;
					IL_015c:
					_003Cresult_003E5__1 = null;
					_003Cfilters_003E5__2 = null;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__4 = ex;
					Console.WriteLine($"ShowFilterPopup error: {_003Cex_003E5__4}");
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
	private sealed class _003CShowGuildListAsync_003Ed__96 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildHubViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					_003C_003E4__this.ShowGuildList = true;
					awaiter = _003C_003E4__this.SearchGuildsAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CShowGuildListAsync_003Ed__96 _003CShowGuildListAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CShowGuildListAsync_003Ed__96>(ref awaiter, ref _003CShowGuildListAsync_003Ed__);
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

	private readonly IGuildStateService _guildStateService;

	private readonly GetGuildDetailsUseCase _getGuildDetailsUseCase;

	private readonly SearchGuildsUseCase _searchGuildsUseCase;

	private readonly JoinGuildUseCase _joinGuildUseCase;

	private readonly LeaveGuildUseCase _leaveGuildUseCase;

	private readonly GetPlayerInvitationsUseCase _getPlayerInvitationsUseCase;

	private readonly DisbandGuildUseCase _disbandGuildUseCase;

	private readonly CancelDisbandGuildUseCase _cancelDisbandGuildUseCase;

	private readonly IPlayerStateService _playerState;

	private readonly INavigationService _navigationService;

	private readonly IPopupService _popupService;

	private bool _disposed;

	private bool _isPageActive;

	private string? _currentGuildId;

	private bool _listenersActive;

	private IDispatcherTimer? _disbandTimer;

	[ObservableProperty]
	private bool _hasGuild;

	[ObservableProperty]
	[NotifyPropertyChangedFor("MemberCountText")]
	[NotifyPropertyChangedFor("CurrentLevelText")]
	[NotifyPropertyChangedFor("MembersSubtitleText")]
	private Guild? _currentGuild;

	[ObservableProperty]
	private bool _isLoading;

	[ObservableProperty]
	private string _errorMessage = string.Empty;

	[ObservableProperty]
	private bool _isInitialized = false;

	[ObservableProperty]
	private bool _showGuildContent;

	[ObservableProperty]
	private bool _showNoGuildContent;

	[ObservableProperty]
	private bool _showGuildList = false;

	[ObservableProperty]
	private string _searchText = string.Empty;

	[ObservableProperty]
	private ObservableCollection<GuildSearchResult> _availableGuilds = new ObservableCollection<GuildSearchResult>();

	[ObservableProperty]
	private GuildSearchFilters _currentFilters = new GuildSearchFilters();

	[ObservableProperty]
	private bool _isSearching;

	[ObservableProperty]
	private int _searchResultsCount;

	[ObservableProperty]
	private string _guildName = string.Empty;

	[ObservableProperty]
	private string _guildEmblem = "\ud83d\udc51";

	[ObservableProperty]
	private int _guildRank;

	[ObservableProperty]
	private int _guildLevel;

	[ObservableProperty]
	private int _maxMembers = 50;

	[ObservableProperty]
	private int _trophies;

	[ObservableProperty]
	private int _wins;

	[ObservableProperty]
	private int _currentXP;

	[ObservableProperty]
	private int _xPForNextLevel;

	[ObservableProperty]
	private int _nextLevel;

	[ObservableProperty]
	private double _xpProgressWidth;

	[ObservableProperty]
	private bool _showWarsNewBadge = true;

	[ObservableProperty]
	private int _newItemsCount;

	[ObservableProperty]
	private int _unreadMessagesCount;

	[ObservableProperty]
	private bool _hideOptions = true;

	[ObservableProperty]
	[NotifyPropertyChangedFor("HasPendingInvitations")]
	private int _pendingInvitationCount;

	[ObservableProperty]
	private bool _isDisbanding;

	[ObservableProperty]
	private string _disbandTimeRemaining = string.Empty;

	[ObservableProperty]
	private int _memberCount;

	[ObservableProperty]
	private ObservableCollection<GuildMember> _members = new ObservableCollection<GuildMember>();

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? showGuildOptionsCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? editGuildCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? leaveGuildCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? disbandGuildCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? cancelDisbandGuildCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? showGuildListCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? hideGuildListCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? searchGuildsCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? showFilterPopupCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? showCreateGuildPopupCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<string>? joinGuildCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? clearSearchCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? navigateToMembersCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? navigateToWarsCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? navigateToShopCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? openInvitationsCommand;

	public bool IsAccountLinked => (_playerState?.GetCurrentPlayer()?.IsAccountLinked).GetValueOrDefault();

	public string MemberCountText => $"{MemberCount}/{MaxMembers}";

	public string MembersSubtitleText => $"View all {MemberCount}";

	public string CurrentLevelText => $"Level {GuildLevel}";

	public string XPProgressText => $"EXP {CurrentXP:N0} / {XPForNextLevel:N0}";

	public float XPProgress => (XPForNextLevel > 0) ? ((float)CurrentXP / (float)XPForNextLevel) : 0f;

	public string? LeaderPlayerName => Enumerable.FirstOrDefault<GuildMember>((global::System.Collections.Generic.IEnumerable<GuildMember>)_guildStateService.GetMembers(), (Func<GuildMember, bool>)((GuildMember m) => m.Role == GuildRole.Guildmaster))?.PlayerName ?? "Leader";

	public int LeaderPlayerLevel => Enumerable.FirstOrDefault<GuildMember>((global::System.Collections.Generic.IEnumerable<GuildMember>)_guildStateService.GetMembers(), (Func<GuildMember, bool>)((GuildMember m) => m.Role == GuildRole.Guildmaster))?.Level ?? 1;

	public bool IsLeader => _playerState.CurrentPlayerId == CurrentGuild?.LeaderPlayerId;

	public bool ShowOptions
	{
		get
		{
			int result;
			if (HideOptions)
			{
				Player? currentPlayer = _playerState.GetCurrentPlayer();
				result = ((currentPlayer != null && currentPlayer.GuildRole == GuildRole.Guildmaster) ? 1 : 0);
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}
	}

	public bool HasPendingInvitations => PendingInvitationCount > 0;

	public long CurrentPlayerGuildCoins
	{
		get
		{
			Player? currentPlayer = _playerState.GetCurrentPlayer();
			return (currentPlayer != null) ? CollectionExtensions.GetValueOrDefault<string, long>(currentPlayer.Currencies, "clancredits", 0L) : 0;
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
	public Guild? CurrentGuild
	{
		get
		{
			return _currentGuild;
		}
		set
		{
			if (!EqualityComparer<Guild>.Default.Equals(_currentGuild, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CurrentGuild);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.MemberCountText);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CurrentLevelText);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.MembersSubtitleText);
				_currentGuild = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CurrentGuild);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.MemberCountText);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CurrentLevelText);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.MembersSubtitleText);
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
	public bool IsInitialized
	{
		get
		{
			return _isInitialized;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isInitialized, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsInitialized);
				_isInitialized = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsInitialized);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool ShowGuildContent
	{
		get
		{
			return _showGuildContent;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_showGuildContent, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ShowGuildContent);
				_showGuildContent = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ShowGuildContent);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool ShowNoGuildContent
	{
		get
		{
			return _showNoGuildContent;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_showNoGuildContent, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ShowNoGuildContent);
				_showNoGuildContent = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ShowNoGuildContent);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool ShowGuildList
	{
		get
		{
			return _showGuildList;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_showGuildList, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ShowGuildList);
				_showGuildList = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ShowGuildList);
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
	public ObservableCollection<GuildSearchResult> AvailableGuilds
	{
		get
		{
			return _availableGuilds;
		}
		[MemberNotNull("_availableGuilds")]
		set
		{
			if (!EqualityComparer<ObservableCollection<GuildSearchResult>>.Default.Equals(_availableGuilds, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.AvailableGuilds);
				_availableGuilds = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.AvailableGuilds);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public GuildSearchFilters CurrentFilters
	{
		get
		{
			return _currentFilters;
		}
		[MemberNotNull("_currentFilters")]
		set
		{
			if (!EqualityComparer<GuildSearchFilters>.Default.Equals(_currentFilters, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CurrentFilters);
				_currentFilters = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CurrentFilters);
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
	public int SearchResultsCount
	{
		get
		{
			return _searchResultsCount;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_searchResultsCount, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.SearchResultsCount);
				_searchResultsCount = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SearchResultsCount);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string GuildName
	{
		get
		{
			return _guildName;
		}
		[MemberNotNull("_guildName")]
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
	public string GuildEmblem
	{
		get
		{
			return _guildEmblem;
		}
		[MemberNotNull("_guildEmblem")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_guildEmblem, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.GuildEmblem);
				_guildEmblem = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.GuildEmblem);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int GuildRank
	{
		get
		{
			return _guildRank;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_guildRank, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.GuildRank);
				_guildRank = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.GuildRank);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int GuildLevel
	{
		get
		{
			return _guildLevel;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_guildLevel, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.GuildLevel);
				_guildLevel = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.GuildLevel);
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

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int Trophies
	{
		get
		{
			return _trophies;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_trophies, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Trophies);
				_trophies = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Trophies);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int Wins
	{
		get
		{
			return _wins;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_wins, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Wins);
				_wins = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Wins);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int CurrentXP
	{
		get
		{
			return _currentXP;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_currentXP, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CurrentXP);
				_currentXP = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CurrentXP);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int XPForNextLevel
	{
		get
		{
			return _xPForNextLevel;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_xPForNextLevel, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.XPForNextLevel);
				_xPForNextLevel = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.XPForNextLevel);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int NextLevel
	{
		get
		{
			return _nextLevel;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_nextLevel, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.NextLevel);
				_nextLevel = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.NextLevel);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public double XpProgressWidth
	{
		get
		{
			return _xpProgressWidth;
		}
		set
		{
			if (!EqualityComparer<double>.Default.Equals(_xpProgressWidth, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.XpProgressWidth);
				_xpProgressWidth = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.XpProgressWidth);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool ShowWarsNewBadge
	{
		get
		{
			return _showWarsNewBadge;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_showWarsNewBadge, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ShowWarsNewBadge);
				_showWarsNewBadge = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ShowWarsNewBadge);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int NewItemsCount
	{
		get
		{
			return _newItemsCount;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_newItemsCount, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.NewItemsCount);
				_newItemsCount = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.NewItemsCount);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int UnreadMessagesCount
	{
		get
		{
			return _unreadMessagesCount;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_unreadMessagesCount, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.UnreadMessagesCount);
				_unreadMessagesCount = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.UnreadMessagesCount);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool HideOptions
	{
		get
		{
			return _hideOptions;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_hideOptions, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HideOptions);
				_hideOptions = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HideOptions);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int PendingInvitationCount
	{
		get
		{
			return _pendingInvitationCount;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_pendingInvitationCount, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.PendingInvitationCount);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HasPendingInvitations);
				_pendingInvitationCount = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.PendingInvitationCount);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HasPendingInvitations);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsDisbanding
	{
		get
		{
			return _isDisbanding;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isDisbanding, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsDisbanding);
				_isDisbanding = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsDisbanding);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string DisbandTimeRemaining
	{
		get
		{
			return _disbandTimeRemaining;
		}
		[MemberNotNull("_disbandTimeRemaining")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_disbandTimeRemaining, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.DisbandTimeRemaining);
				_disbandTimeRemaining = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.DisbandTimeRemaining);
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
				_memberCount = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.MemberCount);
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

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand ShowGuildOptionsCommand
	{
		get
		{
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Expected O, but got Unknown
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			RelayCommand obj = showGuildOptionsCommand;
			if (obj == null)
			{
				RelayCommand val = new RelayCommand(new Action(ShowGuildOptions));
				RelayCommand val2 = val;
				showGuildOptionsCommand = val;
				obj = val2;
			}
			return (IRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand EditGuildCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = editGuildCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)EditGuild);
				AsyncRelayCommand val2 = val;
				editGuildCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand LeaveGuildCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = leaveGuildCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)LeaveGuild);
				AsyncRelayCommand val2 = val;
				leaveGuildCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand DisbandGuildCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = disbandGuildCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)DisbandGuild);
				AsyncRelayCommand val2 = val;
				disbandGuildCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand CancelDisbandGuildCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = cancelDisbandGuildCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)CancelDisbandGuild);
				AsyncRelayCommand val2 = val;
				cancelDisbandGuildCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand ShowGuildListCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = showGuildListCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)ShowGuildListAsync);
				AsyncRelayCommand val2 = val;
				showGuildListCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand HideGuildListCommand
	{
		get
		{
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Expected O, but got Unknown
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			RelayCommand obj = hideGuildListCommand;
			if (obj == null)
			{
				RelayCommand val = new RelayCommand(new Action(HideGuildList));
				RelayCommand val2 = val;
				hideGuildListCommand = val;
				obj = val2;
			}
			return (IRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand SearchGuildsCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = searchGuildsCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)SearchGuildsAsync);
				AsyncRelayCommand val2 = val;
				searchGuildsCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand ShowFilterPopupCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = showFilterPopupCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)ShowFilterPopup);
				AsyncRelayCommand val2 = val;
				showFilterPopupCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand ShowCreateGuildPopupCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = showCreateGuildPopupCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)ShowCreateGuildPopup);
				AsyncRelayCommand val2 = val;
				showCreateGuildPopupCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<string> JoinGuildCommand => (IAsyncRelayCommand<string>)(object)(joinGuildCommand ?? (joinGuildCommand = new AsyncRelayCommand<string>((Func<string, global::System.Threading.Tasks.Task>)JoinGuildAsync)));

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
	public IAsyncRelayCommand NavigateToMembersCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = navigateToMembersCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)NavigateToMembers);
				AsyncRelayCommand val2 = val;
				navigateToMembersCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand NavigateToWarsCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = navigateToWarsCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)NavigateToWars);
				AsyncRelayCommand val2 = val;
				navigateToWarsCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand NavigateToShopCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = navigateToShopCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)NavigateToShop);
				AsyncRelayCommand val2 = val;
				navigateToShopCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand OpenInvitationsCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = openInvitationsCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)OpenInvitations);
				AsyncRelayCommand val2 = val;
				openInvitationsCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	public GuildHubViewModel(IGuildStateService guildStateService, GetGuildDetailsUseCase getGuildDetailsUseCase, SearchGuildsUseCase searchGuildsUseCase, JoinGuildUseCase joinGuildUseCase, LeaveGuildUseCase leaveGuildUseCase, GetPlayerInvitationsUseCase getPlayerInvitationsUseCase, DisbandGuildUseCase disbandGuildUseCase, CancelDisbandGuildUseCase cancelDisbandGuildUseCase, IPlayerStateService playerStateService, INavigationService navigationService, IPopupService popupService)
	{
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		_guildStateService = guildStateService ?? throw new ArgumentNullException("guildStateService");
		_getGuildDetailsUseCase = getGuildDetailsUseCase ?? throw new ArgumentNullException("getGuildDetailsUseCase");
		_searchGuildsUseCase = searchGuildsUseCase ?? throw new ArgumentNullException("searchGuildsUseCase");
		_joinGuildUseCase = joinGuildUseCase ?? throw new ArgumentNullException("joinGuildUseCase");
		_leaveGuildUseCase = leaveGuildUseCase ?? throw new ArgumentNullException("leaveGuildUseCase");
		_getPlayerInvitationsUseCase = getPlayerInvitationsUseCase ?? throw new ArgumentNullException("getPlayerInvitationsUseCase");
		_disbandGuildUseCase = disbandGuildUseCase ?? throw new ArgumentNullException("disbandGuildUseCase");
		_cancelDisbandGuildUseCase = cancelDisbandGuildUseCase ?? throw new ArgumentNullException("cancelDisbandGuildUseCase");
		_playerState = playerStateService ?? throw new ArgumentNullException("playerStateService");
		_navigationService = navigationService ?? throw new ArgumentNullException("navigationService");
		_popupService = popupService ?? throw new ArgumentNullException("popupService");
		SubscribeToEvents();
		Console.WriteLine("GuildHubViewModel: Constructor completed (no data initialization)");
	}

	private void SubscribeToEvents()
	{
		_playerState.StateChanged += OnPlayerUpdatedSelective;
	}

	private void UpdateVisibilityState()
	{
		bool showGuildContent = IsInitialized && HasGuild && CurrentGuild != null;
		ShowGuildContent = showGuildContent;
		ShowNoGuildContent = IsInitialized && !HasGuild;
		Console.WriteLine($"UpdateVisibilityState - IsInitialized: {IsInitialized}, HasGuild: {HasGuild}, CurrentGuild: {CurrentGuild?.Name ?? "null"}, ShowGuildContent: {ShowGuildContent}, ShowNoGuildContent: {ShowNoGuildContent}");
	}

	[AsyncStateMachine(typeof(_003COnPlayerUpdatedSelective_003Ed__76))]
	[DebuggerStepThrough]
	private void OnPlayerUpdatedSelective(object? sender, StateChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003COnPlayerUpdatedSelective_003Ed__76 _003COnPlayerUpdatedSelective_003Ed__ = new _003COnPlayerUpdatedSelective_003Ed__76();
		_003COnPlayerUpdatedSelective_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003COnPlayerUpdatedSelective_003Ed__._003C_003E4__this = this;
		_003COnPlayerUpdatedSelective_003Ed__.sender = sender;
		_003COnPlayerUpdatedSelective_003Ed__.e = e;
		_003COnPlayerUpdatedSelective_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003COnPlayerUpdatedSelective_003Ed__._003C_003Et__builder)).Start<_003COnPlayerUpdatedSelective_003Ed__76>(ref _003COnPlayerUpdatedSelective_003Ed__);
	}

	[AsyncStateMachine(typeof(_003COnPageAppearingAsync_003Ed__77))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task OnPageAppearingAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003COnPageAppearingAsync_003Ed__77 _003COnPageAppearingAsync_003Ed__ = new _003COnPageAppearingAsync_003Ed__77();
		_003COnPageAppearingAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003COnPageAppearingAsync_003Ed__._003C_003E4__this = this;
		_003COnPageAppearingAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003COnPageAppearingAsync_003Ed__._003C_003Et__builder)).Start<_003COnPageAppearingAsync_003Ed__77>(ref _003COnPageAppearingAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003COnPageAppearingAsync_003Ed__._003C_003Et__builder)).Task;
	}

	public void OnPageDisappearing()
	{
		_isPageActive = false;
		StopGuildListeners();
		StopDisbandTimer();
		Console.WriteLine("OnPageDisappearing: Page became inactive, listeners stopped");
	}

	[AsyncStateMachine(typeof(_003CLoadDataAsync_003Ed__79))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task LoadDataAsync(object? parameter = null)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadDataAsync_003Ed__79 _003CLoadDataAsync_003Ed__ = new _003CLoadDataAsync_003Ed__79();
		_003CLoadDataAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadDataAsync_003Ed__._003C_003E4__this = this;
		_003CLoadDataAsync_003Ed__.parameter = parameter;
		_003CLoadDataAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadDataAsync_003Ed__79>(ref _003CLoadDataAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CCheckGuildMembership_003Ed__80))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task CheckGuildMembership()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CCheckGuildMembership_003Ed__80 _003CCheckGuildMembership_003Ed__ = new _003CCheckGuildMembership_003Ed__80();
		_003CCheckGuildMembership_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CCheckGuildMembership_003Ed__._003C_003E4__this = this;
		_003CCheckGuildMembership_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CCheckGuildMembership_003Ed__._003C_003Et__builder)).Start<_003CCheckGuildMembership_003Ed__80>(ref _003CCheckGuildMembership_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CCheckGuildMembership_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003COnGuildMembershipChanged_003Ed__81))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task OnGuildMembershipChanged()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003COnGuildMembershipChanged_003Ed__81 _003COnGuildMembershipChanged_003Ed__ = new _003COnGuildMembershipChanged_003Ed__81();
		_003COnGuildMembershipChanged_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003COnGuildMembershipChanged_003Ed__._003C_003E4__this = this;
		_003COnGuildMembershipChanged_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003COnGuildMembershipChanged_003Ed__._003C_003Et__builder)).Start<_003COnGuildMembershipChanged_003Ed__81>(ref _003COnGuildMembershipChanged_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003COnGuildMembershipChanged_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CLoadInitialGuildData_003Ed__82))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task LoadInitialGuildData([CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadInitialGuildData_003Ed__82 _003CLoadInitialGuildData_003Ed__ = new _003CLoadInitialGuildData_003Ed__82();
		_003CLoadInitialGuildData_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadInitialGuildData_003Ed__._003C_003E4__this = this;
		_003CLoadInitialGuildData_003Ed__.memberName = memberName;
		_003CLoadInitialGuildData_003Ed__.sourceFilePath = sourceFilePath;
		_003CLoadInitialGuildData_003Ed__.sourceLineNumber = sourceLineNumber;
		_003CLoadInitialGuildData_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadInitialGuildData_003Ed__._003C_003Et__builder)).Start<_003CLoadInitialGuildData_003Ed__82>(ref _003CLoadInitialGuildData_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadInitialGuildData_003Ed__._003C_003Et__builder)).Task;
	}

	private void StartGuildListeners()
	{
		Player currentPlayer = _playerState.GetCurrentPlayer();
		if (currentPlayer == null || !currentPlayer.IsAccountLinked)
		{
			Console.WriteLine("Cannot start listeners: Account not linked");
			return;
		}
		if (string.IsNullOrEmpty(_currentGuildId))
		{
			Console.WriteLine("Cannot start listeners: No guild ID");
			return;
		}
		if (_listenersActive)
		{
			Console.WriteLine("Listeners already active, skipping start");
			return;
		}
		try
		{
			_guildStateService.GuildStateChanged += OnGuildStateChanged;
			_guildStateService.StartRealtimeSync();
			_listenersActive = true;
			Console.WriteLine("Subscribed to guild state changes for: " + _currentGuildId);
		}
		catch (global::System.Exception ex)
		{
			Console.WriteLine($"StartGuildListeners error: {ex}");
		}
	}

	private void StopGuildListeners()
	{
		if (!_listenersActive)
		{
			Console.WriteLine("Listeners not active, skipping stop");
			return;
		}
		try
		{
			_guildStateService.GuildStateChanged -= OnGuildStateChanged;
			_listenersActive = false;
			Console.WriteLine("Unsubscribed from guild state changes");
		}
		catch (global::System.Exception ex)
		{
			Console.WriteLine($"StopGuildListeners error: {ex}");
		}
	}

	private void OnGuildStateChanged(object? sender, GuildStateChangedEventArgs e)
	{
		Guild currentGuild = _guildStateService.GetCurrentGuild();
		if (currentGuild != null)
		{
			CurrentGuild = currentGuild;
			PopulateGuildContent(currentGuild);
			UpdateVisibilityState();
			Console.WriteLine($"Guild updated in real-time: {currentGuild.Name} (ChangeType: {e.ChangeType})");
		}
	}

	private void PopulateGuildContent(Guild guild)
	{
		GuildName = guild.Name ?? "";
		GuildEmblem = guild.Emblem;
		GuildRank = guild.Rank;
		GuildLevel = guild.Level;
		MaxMembers = guild.MaxMembers;
		Trophies = guild.Trophies;
		Wins = guild.TotalWins;
		global::System.Collections.Generic.IReadOnlyList<GuildMember> members = _guildStateService.GetMembers();
		MemberCount = ((global::System.Collections.Generic.IReadOnlyCollection<GuildMember>)members).Count;
		Members = new ObservableCollection<GuildMember>(Enumerable.Take<GuildMember>((global::System.Collections.Generic.IEnumerable<GuildMember>)members, 8));
		CurrentXP = guild.CurrentXP;
		XPForNextLevel = guild.XPForNextLevel;
		NextLevel = guild.Level + 1;
		((ObservableObject)this).OnPropertyChanged("XPProgress");
		((ObservableObject)this).OnPropertyChanged("XPProgressText");
		((ObservableObject)this).OnPropertyChanged("CurrentLevelText");
		((ObservableObject)this).OnPropertyChanged("LeaderPlayerLevel");
		((ObservableObject)this).OnPropertyChanged("LeaderPlayerName");
		((ObservableObject)this).OnPropertyChanged("MemberCountText");
		IsDisbanding = guild.IsDisbanding;
		if (IsDisbanding)
		{
			UpdateDisbandTimeRemaining();
			if (_isPageActive)
			{
				StartDisbandTimer();
			}
		}
		else
		{
			DisbandTimeRemaining = string.Empty;
			StopDisbandTimer();
		}
	}

	private void ClearGuildContent()
	{
		GuildName = string.Empty;
		GuildEmblem = "\ud83d\udc51";
		GuildRank = 0;
		GuildLevel = 0;
		Trophies = 0;
		Wins = 0;
		CurrentXP = 0;
		XPForNextLevel = 0;
	}

	[RelayCommand]
	public void ShowGuildOptions()
	{
		HideOptions = !HideOptions;
	}

	[AsyncStateMachine(typeof(_003CEditGuild_003Ed__89))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task EditGuild()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CEditGuild_003Ed__89 _003CEditGuild_003Ed__ = new _003CEditGuild_003Ed__89();
		_003CEditGuild_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CEditGuild_003Ed__._003C_003E4__this = this;
		_003CEditGuild_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CEditGuild_003Ed__._003C_003Et__builder)).Start<_003CEditGuild_003Ed__89>(ref _003CEditGuild_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CEditGuild_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CLeaveGuild_003Ed__90))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task LeaveGuild()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLeaveGuild_003Ed__90 _003CLeaveGuild_003Ed__ = new _003CLeaveGuild_003Ed__90();
		_003CLeaveGuild_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLeaveGuild_003Ed__._003C_003E4__this = this;
		_003CLeaveGuild_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLeaveGuild_003Ed__._003C_003Et__builder)).Start<_003CLeaveGuild_003Ed__90>(ref _003CLeaveGuild_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLeaveGuild_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CDisbandGuild_003Ed__91))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task DisbandGuild()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CDisbandGuild_003Ed__91 _003CDisbandGuild_003Ed__ = new _003CDisbandGuild_003Ed__91();
		_003CDisbandGuild_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CDisbandGuild_003Ed__._003C_003E4__this = this;
		_003CDisbandGuild_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CDisbandGuild_003Ed__._003C_003Et__builder)).Start<_003CDisbandGuild_003Ed__91>(ref _003CDisbandGuild_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CDisbandGuild_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CCancelDisbandGuild_003Ed__92))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task CancelDisbandGuild()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CCancelDisbandGuild_003Ed__92 _003CCancelDisbandGuild_003Ed__ = new _003CCancelDisbandGuild_003Ed__92();
		_003CCancelDisbandGuild_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CCancelDisbandGuild_003Ed__._003C_003E4__this = this;
		_003CCancelDisbandGuild_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CCancelDisbandGuild_003Ed__._003C_003Et__builder)).Start<_003CCancelDisbandGuild_003Ed__92>(ref _003CCancelDisbandGuild_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CCancelDisbandGuild_003Ed__._003C_003Et__builder)).Task;
	}

	private void StartDisbandTimer()
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		StopDisbandTimer();
		Application current = Application.Current;
		_disbandTimer = ((current != null) ? ((BindableObject)current).Dispatcher.CreateTimer() : null);
		if (_disbandTimer != null)
		{
			_disbandTimer.Interval = TimeSpan.FromSeconds(30L);
			_disbandTimer.Tick += (EventHandler)([CompilerGenerated] (object? s, EventArgs e) =>
			{
				UpdateDisbandTimeRemaining();
			});
			_disbandTimer.Start();
		}
	}

	private void StopDisbandTimer()
	{
		IDispatcherTimer? disbandTimer = _disbandTimer;
		if (disbandTimer != null)
		{
			disbandTimer.Stop();
		}
		_disbandTimer = null;
	}

	private void UpdateDisbandTimeRemaining()
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		TimeSpan? val = CurrentGuild?.TimeUntilDisband;
		if (val.HasValue)
		{
			TimeSpan valueOrDefault = val.GetValueOrDefault();
			if (true)
			{
				if (((TimeSpan)(ref valueOrDefault)).TotalHours >= 1.0)
				{
					DisbandTimeRemaining = $"{(int)((TimeSpan)(ref valueOrDefault)).TotalHours}h {((TimeSpan)(ref valueOrDefault)).Minutes}m";
				}
				else if (((TimeSpan)(ref valueOrDefault)).TotalMinutes >= 1.0)
				{
					DisbandTimeRemaining = $"{(int)((TimeSpan)(ref valueOrDefault)).TotalMinutes}m";
				}
				else
				{
					DisbandTimeRemaining = "Less than 1 minute";
				}
				return;
			}
		}
		DisbandTimeRemaining = string.Empty;
	}

	[AsyncStateMachine(typeof(_003CShowGuildListAsync_003Ed__96))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task ShowGuildListAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CShowGuildListAsync_003Ed__96 _003CShowGuildListAsync_003Ed__ = new _003CShowGuildListAsync_003Ed__96();
		_003CShowGuildListAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CShowGuildListAsync_003Ed__._003C_003E4__this = this;
		_003CShowGuildListAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CShowGuildListAsync_003Ed__._003C_003Et__builder)).Start<_003CShowGuildListAsync_003Ed__96>(ref _003CShowGuildListAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CShowGuildListAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[RelayCommand]
	public void HideGuildList()
	{
		ShowGuildList = false;
	}

	[AsyncStateMachine(typeof(_003CSearchGuildsAsync_003Ed__98))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task SearchGuildsAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CSearchGuildsAsync_003Ed__98 _003CSearchGuildsAsync_003Ed__ = new _003CSearchGuildsAsync_003Ed__98();
		_003CSearchGuildsAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CSearchGuildsAsync_003Ed__._003C_003E4__this = this;
		_003CSearchGuildsAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CSearchGuildsAsync_003Ed__._003C_003Et__builder)).Start<_003CSearchGuildsAsync_003Ed__98>(ref _003CSearchGuildsAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CSearchGuildsAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CShowFilterPopup_003Ed__99))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task ShowFilterPopup()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CShowFilterPopup_003Ed__99 _003CShowFilterPopup_003Ed__ = new _003CShowFilterPopup_003Ed__99();
		_003CShowFilterPopup_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CShowFilterPopup_003Ed__._003C_003E4__this = this;
		_003CShowFilterPopup_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CShowFilterPopup_003Ed__._003C_003Et__builder)).Start<_003CShowFilterPopup_003Ed__99>(ref _003CShowFilterPopup_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CShowFilterPopup_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CShowCreateGuildPopup_003Ed__100))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task ShowCreateGuildPopup()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CShowCreateGuildPopup_003Ed__100 _003CShowCreateGuildPopup_003Ed__ = new _003CShowCreateGuildPopup_003Ed__100();
		_003CShowCreateGuildPopup_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CShowCreateGuildPopup_003Ed__._003C_003E4__this = this;
		_003CShowCreateGuildPopup_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CShowCreateGuildPopup_003Ed__._003C_003Et__builder)).Start<_003CShowCreateGuildPopup_003Ed__100>(ref _003CShowCreateGuildPopup_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CShowCreateGuildPopup_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CJoinGuildAsync_003Ed__101))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task JoinGuildAsync(string guildId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CJoinGuildAsync_003Ed__101 _003CJoinGuildAsync_003Ed__ = new _003CJoinGuildAsync_003Ed__101();
		_003CJoinGuildAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CJoinGuildAsync_003Ed__._003C_003E4__this = this;
		_003CJoinGuildAsync_003Ed__.guildId = guildId;
		_003CJoinGuildAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CJoinGuildAsync_003Ed__._003C_003Et__builder)).Start<_003CJoinGuildAsync_003Ed__101>(ref _003CJoinGuildAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CJoinGuildAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[RelayCommand]
	public void ClearSearch()
	{
		SearchText = string.Empty;
	}

	private string GetTimeAgo(DateTimeOffset timestamp)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		TimeSpan val = DateTimeOffset.UtcNow - timestamp;
		if (((TimeSpan)(ref val)).TotalMinutes < 1.0)
		{
			return "Just now";
		}
		if (((TimeSpan)(ref val)).TotalMinutes < 60.0)
		{
			return $"{(int)((TimeSpan)(ref val)).TotalMinutes}m ago";
		}
		if (((TimeSpan)(ref val)).TotalHours < 24.0)
		{
			return $"{(int)((TimeSpan)(ref val)).TotalHours}h ago";
		}
		if (((TimeSpan)(ref val)).TotalDays < 7.0)
		{
			return $"{(int)((TimeSpan)(ref val)).TotalDays}d ago";
		}
		return ((DateTimeOffset)(ref timestamp)).ToString("MMM dd");
	}

	[AsyncStateMachine(typeof(_003CNavigateToMembers_003Ed__104))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task NavigateToMembers()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CNavigateToMembers_003Ed__104 _003CNavigateToMembers_003Ed__ = new _003CNavigateToMembers_003Ed__104();
		_003CNavigateToMembers_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CNavigateToMembers_003Ed__._003C_003E4__this = this;
		_003CNavigateToMembers_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CNavigateToMembers_003Ed__._003C_003Et__builder)).Start<_003CNavigateToMembers_003Ed__104>(ref _003CNavigateToMembers_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CNavigateToMembers_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CNavigateToWars_003Ed__105))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task NavigateToWars()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CNavigateToWars_003Ed__105 _003CNavigateToWars_003Ed__ = new _003CNavigateToWars_003Ed__105();
		_003CNavigateToWars_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CNavigateToWars_003Ed__._003C_003E4__this = this;
		_003CNavigateToWars_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CNavigateToWars_003Ed__._003C_003Et__builder)).Start<_003CNavigateToWars_003Ed__105>(ref _003CNavigateToWars_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CNavigateToWars_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CNavigateToShop_003Ed__106))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task NavigateToShop()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CNavigateToShop_003Ed__106 _003CNavigateToShop_003Ed__ = new _003CNavigateToShop_003Ed__106();
		_003CNavigateToShop_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CNavigateToShop_003Ed__._003C_003E4__this = this;
		_003CNavigateToShop_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CNavigateToShop_003Ed__._003C_003Et__builder)).Start<_003CNavigateToShop_003Ed__106>(ref _003CNavigateToShop_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CNavigateToShop_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003COpenInvitations_003Ed__107))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task OpenInvitations()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003COpenInvitations_003Ed__107 _003COpenInvitations_003Ed__ = new _003COpenInvitations_003Ed__107();
		_003COpenInvitations_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003COpenInvitations_003Ed__._003C_003E4__this = this;
		_003COpenInvitations_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003COpenInvitations_003Ed__._003C_003Et__builder)).Start<_003COpenInvitations_003Ed__107>(ref _003COpenInvitations_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003COpenInvitations_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CLoadPendingInvitationCountAsync_003Ed__108))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task LoadPendingInvitationCountAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadPendingInvitationCountAsync_003Ed__108 _003CLoadPendingInvitationCountAsync_003Ed__ = new _003CLoadPendingInvitationCountAsync_003Ed__108();
		_003CLoadPendingInvitationCountAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadPendingInvitationCountAsync_003Ed__._003C_003E4__this = this;
		_003CLoadPendingInvitationCountAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadPendingInvitationCountAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadPendingInvitationCountAsync_003Ed__108>(ref _003CLoadPendingInvitationCountAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadPendingInvitationCountAsync_003Ed__._003C_003Et__builder)).Task;
	}

	public void Dispose()
	{
		if (!_disposed)
		{
			StopGuildListeners();
			StopDisbandTimer();
			_playerState.StateChanged -= OnPlayerUpdatedSelective;
			_disposed = true;
			GC.SuppressFinalize((object)this);
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnSearchTextChanged(string value)
	{
		SearchGuildsAsync();
	}
}
