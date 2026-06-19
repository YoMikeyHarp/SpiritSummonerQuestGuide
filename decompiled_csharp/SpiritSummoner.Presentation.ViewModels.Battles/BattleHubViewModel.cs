using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Dispatching;
using SpiritSummoner.Application.DTOs.Guildmasterboard;
using SpiritSummoner.Application.Enums;
using SpiritSummoner.Application.Events;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Application.UseCases.Guildmasterboard;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Infrastructure.Cache;
using SpiritSummoner.Infrastructure.Contracts;
using SpiritSummoner.Presentation.Models;
using SpiritSummoner.Presentation.Navigation;
using SpiritSummoner.Presentation.ViewModels.Shared;
using SpiritSummoner.Presentation.ViewModels.Squads;

namespace SpiritSummoner.Presentation.ViewModels.Battles;

public class BattleHubViewModel : ObservableObject, ILoadableViewModel, IPageLifecycleAware, global::System.IDisposable
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass59_0
	{
		public LeaderboardEntryDTO entry;

		internal bool _003CLoadLeaderboardDataAsync_003Eb__0(LeaderboardPlayerModel tp)
		{
			return tp.PlayerId == entry.PlayerId;
		}
	}

	[CompilerGenerated]
	private sealed class _003CGoToBattles_003Ed__51 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleHubViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_010d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0127: Unknown result type (might be due to invalid IL or missing references)
			//IL_012c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0134: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
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
						goto IL_0143;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter awaiter2;
					if (num != 0)
					{
						awaiter2 = _003C_003E4__this._navigationService.NavigateToAsync("//battlehub/battlelist").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CGoToBattles_003Ed__51 _003CGoToBattles_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoToBattles_003Ed__51>(ref awaiter2, ref _003CGoToBattles_003Ed__);
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
					goto IL_0166;
				}
				_003Cex_003E5__3 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Navigation Error", _003Cex_003E5__3.Message).GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = awaiter;
					_003CGoToBattles_003Ed__51 _003CGoToBattles_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoToBattles_003Ed__51>(ref awaiter, ref _003CGoToBattles_003Ed__);
					return;
				}
				goto IL_0143;
				IL_0143:
				((TaskAwaiter)(ref awaiter)).GetResult();
				Console.WriteLine(_003Cex_003E5__3.StackTrace);
				_003Cex_003E5__3 = null;
				goto IL_0166;
				IL_0166:
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
	private sealed class _003CGoToGuild_003Ed__52 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleHubViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private NavBarViewModel _003Cnavbar_003E5__3;

		private global::System.Exception _003Cex_003E5__4;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0108: Unknown result type (might be due to invalid IL or missing references)
			//IL_010d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0122: Unknown result type (might be due to invalid IL or missing references)
			//IL_0124: Unknown result type (might be due to invalid IL or missing references)
			//IL_0141: Unknown result type (might be due to invalid IL or missing references)
			//IL_0146: Unknown result type (might be due to invalid IL or missing references)
			//IL_014e: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
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
						goto IL_015d;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter awaiter2;
					if (num != 0)
					{
						_003Cnavbar_003E5__3 = ServiceProviderServiceExtensions.GetRequiredService<NavBarViewModel>(_003C_003E4__this._serviceProvider);
						awaiter2 = _003Cnavbar_003E5__3.NavigateToCommand.ExecuteAsync("//guild").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CGoToGuild_003Ed__52 _003CGoToGuild_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoToGuild_003Ed__52>(ref awaiter2, ref _003CGoToGuild_003Ed__);
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
					_003Cnavbar_003E5__3 = null;
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
				}
				int num2 = _003C_003Es__2;
				if (num2 != 1)
				{
					goto IL_01a1;
				}
				_003Cex_003E5__4 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Navigation Error", "Failed to open guild.").GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = awaiter;
					_003CGoToGuild_003Ed__52 _003CGoToGuild_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoToGuild_003Ed__52>(ref awaiter, ref _003CGoToGuild_003Ed__);
					return;
				}
				goto IL_015d;
				IL_015d:
				((TaskAwaiter)(ref awaiter)).GetResult();
				Console.WriteLine($"NavigateToGuild error: {_003Cex_003E5__4}");
				_003Cex_003E5__4 = null;
				goto IL_01a1;
				IL_01a1:
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
	private sealed class _003CLoadActiveSquadAsync_003Ed__50 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleHubViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					_003C_003Es__2 = 0;
					try
					{
						_003C_003E4__this.ActiveSquad?.Dispose();
						_003C_003E4__this.ActiveSquad = ActivatorUtilities.CreateInstance<SpiritSquadViewModel>(_003C_003E4__this._serviceProvider, global::System.Array.Empty<object>());
					}
					catch (global::System.Exception ex)
					{
						_003C_003Es__1 = ex;
						_003C_003Es__2 = 1;
					}
					int num2 = _003C_003Es__2;
					if (num2 != 1)
					{
						goto IL_0136;
					}
					_003Cex_003E5__3 = (global::System.Exception)_003C_003Es__1;
					awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error loading active squad", "Error fetching squad data. please try again later.").GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CLoadActiveSquadAsync_003Ed__50 _003CLoadActiveSquadAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadActiveSquadAsync_003Ed__50>(ref awaiter, ref _003CLoadActiveSquadAsync_003Ed__);
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
				Console.WriteLine(_003Cex_003E5__3.Message);
				Console.WriteLine(_003Cex_003E5__3.StackTrace);
				_003C_003E4__this.ActiveSquad = null;
				_003Cex_003E5__3 = null;
				goto IL_0136;
				IL_0136:
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
	private sealed class _003CLoadDataAsync_003Ed__49 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public object param;

		public BattleHubViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_02de: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_02fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0302: Unknown result type (might be due to invalid IL or missing references)
			//IL_030a: Unknown result type (might be due to invalid IL or missing references)
			//IL_017f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0184: Unknown result type (might be due to invalid IL or missing references)
			//IL_018c: Unknown result type (might be due to invalid IL or missing references)
			//IL_020c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0211: Unknown result type (might be due to invalid IL or missing references)
			//IL_0219: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0146: Unknown result type (might be due to invalid IL or missing references)
			//IL_014b: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_0160: Unknown result type (might be due to invalid IL or missing references)
			//IL_0162: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00c9;
				}
				if ((uint)(num - 1) > 2u)
				{
					((ObservableObject)_003C_003E4__this).OnPropertyChanged("CurrentPlayer");
					if (_003C_003E4__this._playerInfo == null)
					{
						_003C_003E4__this.ErrorMessage = "No player data available";
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", _003C_003E4__this.ErrorMessage).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CLoadDataAsync_003Ed__49 _003CLoadDataAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__49>(ref awaiter, ref _003CLoadDataAsync_003Ed__);
							return;
						}
						goto IL_00c9;
					}
				}
				try
				{
					TaskAwaiter awaiter2;
					if ((uint)(num - 1) > 1u)
					{
						if (num == 3)
						{
							awaiter2 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0319;
						}
						_003C_003Es__2 = 0;
					}
					try
					{
						TaskAwaiter awaiter3;
						TaskAwaiter awaiter4;
						if (num != 1)
						{
							if (num == 2)
							{
								awaiter3 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_0228;
							}
							_003C_003E4__this.IsLoading = true;
							_003C_003E4__this.ErrorMessage = string.Empty;
							if (_003C_003E4__this._isCached)
							{
								goto IL_01b0;
							}
							awaiter4 = _003C_003E4__this.LoadActiveSquadAsync().GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__1 = awaiter4;
								_003CLoadDataAsync_003Ed__49 _003CLoadDataAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__49>(ref awaiter4, ref _003CLoadDataAsync_003Ed__);
								return;
							}
						}
						else
						{
							awaiter4 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
						}
						((TaskAwaiter)(ref awaiter4)).GetResult();
						_003C_003E4__this._isCached = true;
						goto IL_01b0;
						IL_0228:
						((TaskAwaiter)(ref awaiter3)).GetResult();
						_003C_003E4__this._leaderboardLoaded = true;
						_003C_003E4__this.StartLeaderboardTimer();
						goto end_IL_00f4;
						IL_01b0:
						if (!_003C_003E4__this._leaderboardLoaded)
						{
							awaiter3 = _003C_003E4__this.LoadLeaderboardDataAsync().GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__1 = awaiter3;
								_003CLoadDataAsync_003Ed__49 _003CLoadDataAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__49>(ref awaiter3, ref _003CLoadDataAsync_003Ed__);
								return;
							}
							goto IL_0228;
						}
						end_IL_00f4:;
					}
					catch (global::System.Exception ex)
					{
						_003C_003Es__1 = ex;
						_003C_003Es__2 = 1;
					}
					int num2 = _003C_003Es__2;
					if (num2 != 1)
					{
						goto IL_033c;
					}
					_003Cex_003E5__3 = (global::System.Exception)_003C_003Es__1;
					_003C_003E4__this.ErrorMessage = "Error loading battle hub: " + _003Cex_003E5__3.Message;
					awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Error loading BattleHub", _003Cex_003E5__3.Message).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 3);
						_003C_003Eu__1 = awaiter2;
						_003CLoadDataAsync_003Ed__49 _003CLoadDataAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__49>(ref awaiter2, ref _003CLoadDataAsync_003Ed__);
						return;
					}
					goto IL_0319;
					IL_0319:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					Console.WriteLine(_003Cex_003E5__3.StackTrace);
					_003Cex_003E5__3 = null;
					goto IL_033c;
					IL_033c:
					_003C_003Es__1 = null;
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this.IsLoading = false;
					}
				}
				goto end_IL_0007;
				IL_00c9:
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
	private sealed class _003CLoadLeaderboardDataAsync_003Ed__59 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleHubViewModel _003C_003E4__this;

		private string _003CplayerId_003E5__1;

		private GetLeaderboardRequest _003Crequest_003E5__2;

		private Result<LeaderboardDataDTO> _003Cresult_003E5__3;

		private LeaderboardDataDTO _003Cdata_003E5__4;

		private Result<LeaderboardDataDTO> _003C_003Es__5;

		private Enumerator<LeaderboardEntryDTO> _003C_003Es__6;

		private LeaderboardEntryDTO _003Centry_003E5__7;

		private Enumerator<LeaderboardEntryDTO> _003C_003Es__8;

		private _003C_003Ec__DisplayClass59_0 _003C_003E8__9;

		private global::System.Exception _003Cex_003E5__10;

		private TaskAwaiter<Result<LeaderboardDataDTO>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0187: Unknown result type (might be due to invalid IL or missing references)
			//IL_018c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0297: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0434: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<Result<LeaderboardDataDTO>> awaiter;
					if (num == 0)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Result<LeaderboardDataDTO>>);
						num = (_003C_003E1__state = -1);
						goto IL_00ee;
					}
					_003C_003E4__this.IsLoadingLeaderboard = true;
					_003C_003E4__this.LeaderboardError = string.Empty;
					_003CplayerId_003E5__1 = _003C_003E4__this._stateService.CurrentPlayerId;
					if (!string.IsNullOrEmpty(_003CplayerId_003E5__1))
					{
						_003Crequest_003E5__2 = new GetLeaderboardRequest(_003CplayerId_003E5__1);
						awaiter = _003C_003E4__this._getLeaderboardUseCase.ExecuteAsync(_003Crequest_003E5__2).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CLoadLeaderboardDataAsync_003Ed__59 _003CLoadLeaderboardDataAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<LeaderboardDataDTO>>, _003CLoadLeaderboardDataAsync_003Ed__59>(ref awaiter, ref _003CLoadLeaderboardDataAsync_003Ed__);
							return;
						}
						goto IL_00ee;
					}
					_003C_003E4__this.LeaderboardError = "Player not found";
					goto end_IL_0010;
					IL_00ee:
					_003C_003Es__5 = awaiter.GetResult();
					_003Cresult_003E5__3 = _003C_003Es__5;
					_003C_003Es__5 = null;
					if (!_003Cresult_003E5__3.Success || _003Cresult_003E5__3.Data == null)
					{
						_003C_003E4__this.LeaderboardError = _003Cresult_003E5__3.ErrorMessage ?? "Failed to load leaderboard";
					}
					else
					{
						_003Cdata_003E5__4 = _003Cresult_003E5__3.Data;
						((Collection<LeaderboardPlayerModel>)(object)_003C_003E4__this.TopPlayers).Clear();
						_003C_003Es__6 = _003Cdata_003E5__4.TopPlayers.GetEnumerator();
						try
						{
							while (_003C_003Es__6.MoveNext())
							{
								_003Centry_003E5__7 = _003C_003Es__6.Current;
								((Collection<LeaderboardPlayerModel>)(object)_003C_003E4__this.TopPlayers).Add(new LeaderboardPlayerModel
								{
									PlayerId = _003Centry_003E5__7.PlayerId,
									PlayerName = _003Centry_003E5__7.PlayerName,
									PlayerLevel = _003Centry_003E5__7.PlayerLevel,
									Score = _003Centry_003E5__7.Score,
									Rank = _003Centry_003E5__7.Rank,
									Title = _003Centry_003E5__7.Title,
									Wins = _003Centry_003E5__7.Wins,
									Losses = _003Centry_003E5__7.Losses,
									IsCurrentPlayer = _003Centry_003E5__7.IsCurrentPlayer
								});
								_003Centry_003E5__7 = null;
							}
						}
						finally
						{
							if (num < 0)
							{
								((global::System.IDisposable)_003C_003Es__6).Dispose();
							}
						}
						_003C_003Es__6 = default(Enumerator<LeaderboardEntryDTO>);
						((Collection<LeaderboardPlayerModel>)(object)_003C_003E4__this.NearbyPlayers).Clear();
						_003C_003Es__8 = _003Cdata_003E5__4.NearbyPlayers.GetEnumerator();
						try
						{
							while (_003C_003Es__8.MoveNext())
							{
								_003C_003E8__9 = new _003C_003Ec__DisplayClass59_0();
								_003C_003E8__9.entry = _003C_003Es__8.Current;
								if (!Enumerable.Any<LeaderboardPlayerModel>((global::System.Collections.Generic.IEnumerable<LeaderboardPlayerModel>)_003C_003E4__this.TopPlayers, (Func<LeaderboardPlayerModel, bool>)((LeaderboardPlayerModel tp) => tp.PlayerId == _003C_003E8__9.entry.PlayerId)))
								{
									((Collection<LeaderboardPlayerModel>)(object)_003C_003E4__this.NearbyPlayers).Add(new LeaderboardPlayerModel
									{
										PlayerId = _003C_003E8__9.entry.PlayerId,
										PlayerName = _003C_003E8__9.entry.PlayerName,
										PlayerLevel = _003C_003E8__9.entry.PlayerLevel,
										Score = _003C_003E8__9.entry.Score,
										Rank = _003C_003E8__9.entry.Rank,
										Title = _003C_003E8__9.entry.Title,
										Wins = _003C_003E8__9.entry.Wins,
										Losses = _003C_003E8__9.entry.Losses,
										IsCurrentPlayer = _003C_003E8__9.entry.IsCurrentPlayer
									});
									_003C_003E8__9 = null;
								}
							}
						}
						finally
						{
							if (num < 0)
							{
								((global::System.IDisposable)_003C_003Es__8).Dispose();
							}
						}
						_003C_003Es__8 = default(Enumerator<LeaderboardEntryDTO>);
						if (_003Cdata_003E5__4.CurrentPlayer != null)
						{
							_003C_003E4__this.CurrentPlayerStats = new LeaderboardPlayerModel
							{
								PlayerId = _003Cdata_003E5__4.CurrentPlayer.PlayerId,
								PlayerName = _003Cdata_003E5__4.CurrentPlayer.PlayerName,
								PlayerLevel = _003Cdata_003E5__4.CurrentPlayer.PlayerLevel,
								Score = _003Cdata_003E5__4.CurrentPlayer.Score,
								Rank = _003Cdata_003E5__4.CurrentPlayer.Rank,
								Title = _003Cdata_003E5__4.CurrentPlayer.Title,
								Wins = _003Cdata_003E5__4.CurrentPlayer.Wins,
								Losses = _003Cdata_003E5__4.CurrentPlayer.Losses,
								IsCurrentPlayer = true
							};
						}
						_003CplayerId_003E5__1 = null;
						_003Crequest_003E5__2 = null;
						_003Cresult_003E5__3 = null;
						_003Cdata_003E5__4 = null;
					}
					end_IL_0010:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__10 = ex;
					_003C_003E4__this.LeaderboardError = "Failed to load leaderboard";
					Console.WriteLine("LoadLeaderboardDataAsync error: " + _003Cex_003E5__10.Message);
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this.IsLoadingLeaderboard = false;
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
	private sealed class _003CRefreshData_003Ed__53 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleHubViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = _003C_003E4__this.LoadDataAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CRefreshData_003Ed__53 _003CRefreshData_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRefreshData_003Ed__53>(ref awaiter, ref _003CRefreshData_003Ed__);
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
	private sealed class _003CRefreshLeaderboard_003Ed__60 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleHubViewModel _003C_003E4__this;

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
					awaiter = _003C_003E4__this.LoadLeaderboardDataAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CRefreshLeaderboard_003Ed__60 _003CRefreshLeaderboard_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRefreshLeaderboard_003Ed__60>(ref awaiter, ref _003CRefreshLeaderboard_003Ed__);
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
	private sealed class _003CSwitchTab_003Ed__48 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string tab;

		public BattleHubViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0140: Unknown result type (might be due to invalid IL or missing references)
			//IL_0145: Unknown result type (might be due to invalid IL or missing references)
			//IL_014d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_0106: Unknown result type (might be due to invalid IL or missing references)
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_018f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0194: Unknown result type (might be due to invalid IL or missing references)
			//IL_0120: Unknown result type (might be due to invalid IL or missing references)
			//IL_0122: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter3;
				TaskAwaiter awaiter2;
				TaskAwaiter awaiter;
				switch (num)
				{
				default:
					if (!(_003C_003E4__this.ActiveTab == tab))
					{
						_003C_003E4__this.ActiveTab = tab;
						if (tab == "Tasks")
						{
							awaiter3 = _003C_003E4__this.TasksViewModel.LoadAsync().GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter3;
								_003CSwitchTab_003Ed__48 _003CSwitchTab_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSwitchTab_003Ed__48>(ref awaiter3, ref _003CSwitchTab_003Ed__);
								return;
							}
							goto IL_00d3;
						}
						if (tab == "Rewards")
						{
							awaiter2 = _003C_003E4__this.RewardsViewModel.LoadAsync().GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__1 = awaiter2;
								_003CSwitchTab_003Ed__48 _003CSwitchTab_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSwitchTab_003Ed__48>(ref awaiter2, ref _003CSwitchTab_003Ed__);
								return;
							}
							goto IL_015c;
						}
						if (tab == "Perks")
						{
							awaiter = _003C_003E4__this.PerksViewModel.LoadAsync().GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__1 = awaiter;
								_003CSwitchTab_003Ed__48 _003CSwitchTab_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSwitchTab_003Ed__48>(ref awaiter, ref _003CSwitchTab_003Ed__);
								return;
							}
							break;
						}
					}
					goto end_IL_0007;
				case 0:
					awaiter3 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00d3;
				case 1:
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_015c;
				case 2:
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_015c:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					goto end_IL_0007;
					IL_00d3:
					((TaskAwaiter)(ref awaiter3)).GetResult();
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

	private readonly INavigationService _navigationService;

	private readonly PlayerInfoModel _playerInfo;

	private readonly IServiceProvider _serviceProvider;

	private readonly GetLeaderboardUseCase _getLeaderboardUseCase;

	private readonly IPlayerStateService _stateService;

	private readonly IServerTimeProvider _serverTimeProvider;

	private bool _disposed;

	private bool _isCached;

	private bool _leaderboardLoaded;

	private IDispatcherTimer? _leaderboardTimer;

	private IDispatcherTimer? _leaderboardCountdownTimer;

	private const int LEADERBOARD_REFRESH_MINUTES = 5;

	private DateTimeOffset _lastLeaderboardFetch;

	[ObservableProperty]
	private SpiritSquadViewModel? _activeSquad;

	[ObservableProperty]
	private object _staticResourceTasks = (object)(Brush)Application.Current.Resources["GradientTasks"];

	[ObservableProperty]
	private object _staticResourceRewards = (object)(Brush)Application.Current.Resources["GradientRewards"];

	[ObservableProperty]
	private object _staticResourcePerks = (object)(Brush)Application.Current.Resources["GradientPerks"];

	[ObservableProperty]
	private string _errorMessage = string.Empty;

	[ObservableProperty]
	[NotifyPropertyChangedFor("HasValidSquad")]
	private bool _isLoading = true;

	[ObservableProperty]
	private ObservableCollection<LeaderboardPlayerModel> _topPlayers = new ObservableCollection<LeaderboardPlayerModel>();

	[ObservableProperty]
	private ObservableCollection<LeaderboardPlayerModel> _nearbyPlayers = new ObservableCollection<LeaderboardPlayerModel>();

	[ObservableProperty]
	private LeaderboardPlayerModel? _currentPlayerStats;

	[ObservableProperty]
	private bool _isLoadingLeaderboard;

	[ObservableProperty]
	private string _leaderboardError = string.Empty;

	[ObservableProperty]
	private string _leaderboardCountdownText = string.Empty;

	[ObservableProperty]
	[NotifyPropertyChangedFor("IsTasksTabActive")]
	[NotifyPropertyChangedFor("IsRewardsTabActive")]
	[NotifyPropertyChangedFor("IsPerksTabActive")]
	private string _activeTab = "Tasks";

	private BattleTasksViewModel? _tasksViewModel;

	private BattleRewardsViewModel? _rewardsViewModel;

	private GuildPerksViewModel? _perksViewModel;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<string>? switchTabCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<object?>? loadDataCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? goToBattlesCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? goToGuildCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? refreshDataCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? refreshLeaderboardCommand;

	public Player? CurrentPlayer => _stateService?.GetCurrentPlayer();

	public bool HasValidSquad => ActiveSquad != null;

	public bool IsTasksTabActive => ActiveTab == "Tasks";

	public bool IsRewardsTabActive => ActiveTab == "Rewards";

	public bool IsPerksTabActive => ActiveTab == "Perks";

	public BattleTasksViewModel TasksViewModel => _tasksViewModel ?? (_tasksViewModel = ActivatorUtilities.CreateInstance<BattleTasksViewModel>(_serviceProvider, global::System.Array.Empty<object>()));

	public BattleRewardsViewModel RewardsViewModel => _rewardsViewModel ?? (_rewardsViewModel = ActivatorUtilities.CreateInstance<BattleRewardsViewModel>(_serviceProvider, global::System.Array.Empty<object>()));

	public GuildPerksViewModel PerksViewModel => _perksViewModel ?? (_perksViewModel = ActivatorUtilities.CreateInstance<GuildPerksViewModel>(_serviceProvider, global::System.Array.Empty<object>()));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public SpiritSquadViewModel? ActiveSquad
	{
		get
		{
			return _activeSquad;
		}
		set
		{
			if (!EqualityComparer<SpiritSquadViewModel>.Default.Equals(_activeSquad, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ActiveSquad);
				_activeSquad = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ActiveSquad);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public object StaticResourceTasks
	{
		get
		{
			return _staticResourceTasks;
		}
		[MemberNotNull("_staticResourceTasks")]
		set
		{
			if (!EqualityComparer<object>.Default.Equals(_staticResourceTasks, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.StaticResourceTasks);
				_staticResourceTasks = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.StaticResourceTasks);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public object StaticResourceRewards
	{
		get
		{
			return _staticResourceRewards;
		}
		[MemberNotNull("_staticResourceRewards")]
		set
		{
			if (!EqualityComparer<object>.Default.Equals(_staticResourceRewards, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.StaticResourceRewards);
				_staticResourceRewards = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.StaticResourceRewards);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public object StaticResourcePerks
	{
		get
		{
			return _staticResourcePerks;
		}
		[MemberNotNull("_staticResourcePerks")]
		set
		{
			if (!EqualityComparer<object>.Default.Equals(_staticResourcePerks, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.StaticResourcePerks);
				_staticResourcePerks = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.StaticResourcePerks);
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
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HasValidSquad);
				_isLoading = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsLoading);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HasValidSquad);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ObservableCollection<LeaderboardPlayerModel> TopPlayers
	{
		get
		{
			return _topPlayers;
		}
		[MemberNotNull("_topPlayers")]
		set
		{
			if (!EqualityComparer<ObservableCollection<LeaderboardPlayerModel>>.Default.Equals(_topPlayers, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.TopPlayers);
				_topPlayers = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.TopPlayers);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ObservableCollection<LeaderboardPlayerModel> NearbyPlayers
	{
		get
		{
			return _nearbyPlayers;
		}
		[MemberNotNull("_nearbyPlayers")]
		set
		{
			if (!EqualityComparer<ObservableCollection<LeaderboardPlayerModel>>.Default.Equals(_nearbyPlayers, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.NearbyPlayers);
				_nearbyPlayers = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.NearbyPlayers);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public LeaderboardPlayerModel? CurrentPlayerStats
	{
		get
		{
			return _currentPlayerStats;
		}
		set
		{
			if (!EqualityComparer<LeaderboardPlayerModel>.Default.Equals(_currentPlayerStats, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CurrentPlayerStats);
				_currentPlayerStats = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CurrentPlayerStats);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsLoadingLeaderboard
	{
		get
		{
			return _isLoadingLeaderboard;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isLoadingLeaderboard, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsLoadingLeaderboard);
				_isLoadingLeaderboard = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsLoadingLeaderboard);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string LeaderboardError
	{
		get
		{
			return _leaderboardError;
		}
		[MemberNotNull("_leaderboardError")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_leaderboardError, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.LeaderboardError);
				_leaderboardError = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.LeaderboardError);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string LeaderboardCountdownText
	{
		get
		{
			return _leaderboardCountdownText;
		}
		[MemberNotNull("_leaderboardCountdownText")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_leaderboardCountdownText, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.LeaderboardCountdownText);
				_leaderboardCountdownText = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.LeaderboardCountdownText);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string ActiveTab
	{
		get
		{
			return _activeTab;
		}
		[MemberNotNull("_activeTab")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_activeTab, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ActiveTab);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsTasksTabActive);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsRewardsTabActive);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsPerksTabActive);
				_activeTab = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ActiveTab);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsTasksTabActive);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsRewardsTabActive);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsPerksTabActive);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<string> SwitchTabCommand => (IAsyncRelayCommand<string>)(object)(switchTabCommand ?? (switchTabCommand = new AsyncRelayCommand<string>((Func<string, global::System.Threading.Tasks.Task>)SwitchTab)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<object?> LoadDataCommand
	{
		get
		{
			AsyncRelayCommand<object?>? obj = loadDataCommand;
			if (obj == null)
			{
				obj = (loadDataCommand = new AsyncRelayCommand<object>((Func<object, global::System.Threading.Tasks.Task>)LoadDataAsync));
			}
			return (IAsyncRelayCommand<object?>)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand GoToBattlesCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = goToBattlesCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)GoToBattles);
				AsyncRelayCommand val2 = val;
				goToBattlesCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand GoToGuildCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = goToGuildCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)GoToGuild);
				AsyncRelayCommand val2 = val;
				goToGuildCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand RefreshDataCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = refreshDataCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)RefreshData);
				AsyncRelayCommand val2 = val;
				refreshDataCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand RefreshLeaderboardCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = refreshLeaderboardCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)RefreshLeaderboard);
				AsyncRelayCommand val2 = val;
				refreshLeaderboardCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	public BattleHubViewModel(INavigationService navigationService, IServiceProvider serviceProvider, PlayerInfoModel playerInfo, GetLeaderboardUseCase getLeaderboardUseCase, IPlayerStateService stateService, IServerTimeProvider serverTimeProvider)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		_navigationService = navigationService;
		_serviceProvider = serviceProvider;
		_playerInfo = playerInfo;
		_getLeaderboardUseCase = getLeaderboardUseCase;
		_stateService = stateService;
		_serverTimeProvider = serverTimeProvider;
		_stateService.StateChanged += OnPlayerStateChanged;
	}

	private void OnPlayerStateChanged(object? sender, StateChangedEventArgs e)
	{
		if (e.Scope == StateChangeScope.Player && !(e.ChangeType != "BattleStats"))
		{
			UpdateLeaderboardOptimistically();
		}
	}

	private void UpdateLeaderboardOptimistically()
	{
		Player currentPlayer = _stateService.GetCurrentPlayer();
		if (currentPlayer != null && CurrentPlayerStats != null)
		{
			CurrentPlayerStats.Score = currentPlayer.BattleStats.Score;
			CurrentPlayerStats.Wins = currentPlayer.BattleStats.Wins;
			CurrentPlayerStats.Losses = currentPlayer.BattleStats.Losses;
			CurrentPlayerStats.Title = currentPlayer.BattleStats.Title;
		}
	}

	[AsyncStateMachine(typeof(_003CSwitchTab_003Ed__48))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task SwitchTab(string tab)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CSwitchTab_003Ed__48 _003CSwitchTab_003Ed__ = new _003CSwitchTab_003Ed__48();
		_003CSwitchTab_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CSwitchTab_003Ed__._003C_003E4__this = this;
		_003CSwitchTab_003Ed__.tab = tab;
		_003CSwitchTab_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CSwitchTab_003Ed__._003C_003Et__builder)).Start<_003CSwitchTab_003Ed__48>(ref _003CSwitchTab_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CSwitchTab_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CLoadDataAsync_003Ed__49))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task LoadDataAsync(object? param = null)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadDataAsync_003Ed__49 _003CLoadDataAsync_003Ed__ = new _003CLoadDataAsync_003Ed__49();
		_003CLoadDataAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadDataAsync_003Ed__._003C_003E4__this = this;
		_003CLoadDataAsync_003Ed__.param = param;
		_003CLoadDataAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadDataAsync_003Ed__49>(ref _003CLoadDataAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CLoadActiveSquadAsync_003Ed__50))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task LoadActiveSquadAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadActiveSquadAsync_003Ed__50 _003CLoadActiveSquadAsync_003Ed__ = new _003CLoadActiveSquadAsync_003Ed__50();
		_003CLoadActiveSquadAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadActiveSquadAsync_003Ed__._003C_003E4__this = this;
		_003CLoadActiveSquadAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadActiveSquadAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadActiveSquadAsync_003Ed__50>(ref _003CLoadActiveSquadAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadActiveSquadAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CGoToBattles_003Ed__51))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task GoToBattles()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CGoToBattles_003Ed__51 _003CGoToBattles_003Ed__ = new _003CGoToBattles_003Ed__51();
		_003CGoToBattles_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CGoToBattles_003Ed__._003C_003E4__this = this;
		_003CGoToBattles_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CGoToBattles_003Ed__._003C_003Et__builder)).Start<_003CGoToBattles_003Ed__51>(ref _003CGoToBattles_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CGoToBattles_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CGoToGuild_003Ed__52))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task GoToGuild()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CGoToGuild_003Ed__52 _003CGoToGuild_003Ed__ = new _003CGoToGuild_003Ed__52();
		_003CGoToGuild_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CGoToGuild_003Ed__._003C_003E4__this = this;
		_003CGoToGuild_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CGoToGuild_003Ed__._003C_003Et__builder)).Start<_003CGoToGuild_003Ed__52>(ref _003CGoToGuild_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CGoToGuild_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CRefreshData_003Ed__53))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task RefreshData()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CRefreshData_003Ed__53 _003CRefreshData_003Ed__ = new _003CRefreshData_003Ed__53();
		_003CRefreshData_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CRefreshData_003Ed__._003C_003E4__this = this;
		_003CRefreshData_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CRefreshData_003Ed__._003C_003Et__builder)).Start<_003CRefreshData_003Ed__53>(ref _003CRefreshData_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CRefreshData_003Ed__._003C_003Et__builder)).Task;
	}

	private void StartLeaderboardTimer()
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Expected O, but got Unknown
		StopLeaderboardTimer();
		_lastLeaderboardFetch = _serverTimeProvider.GetCurrentServerTime();
		Application current = Application.Current;
		_leaderboardTimer = ((current != null) ? ((BindableObject)current).Dispatcher.CreateTimer() : null);
		if (_leaderboardTimer != null)
		{
			_leaderboardTimer.Interval = TimeSpan.FromMinutes(5L);
			_leaderboardTimer.Tick += new EventHandler(OnLeaderboardTimerTick);
			_leaderboardTimer.Start();
			Application current2 = Application.Current;
			_leaderboardCountdownTimer = ((current2 != null) ? ((BindableObject)current2).Dispatcher.CreateTimer() : null);
			if (_leaderboardCountdownTimer != null)
			{
				_leaderboardCountdownTimer.Interval = TimeSpan.FromSeconds(1L);
				_leaderboardCountdownTimer.Tick += new EventHandler(OnCountdownTick);
				UpdateCountdownText();
				_leaderboardCountdownTimer.Start();
			}
		}
	}

	private void OnLeaderboardTimerTick(object? sender, EventArgs e)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		_lastLeaderboardFetch = _serverTimeProvider.GetCurrentServerTime();
		LoadLeaderboardDataAsync();
	}

	private void OnCountdownTick(object? sender, EventArgs e)
	{
		UpdateCountdownText();
	}

	private void UpdateCountdownText()
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		TimeSpan val = TimeSpan.FromMinutes(5L) - (_serverTimeProvider.GetCurrentServerTime() - _lastLeaderboardFetch);
		LeaderboardCountdownText = ((val > TimeSpan.Zero) ? $"Updates in: {((TimeSpan)(ref val)).Minutes}:{((TimeSpan)(ref val)).Seconds:D2}" : "Updating...");
	}

	private void StopLeaderboardTimer()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected O, but got Unknown
		if (_leaderboardTimer != null)
		{
			_leaderboardTimer.Stop();
			_leaderboardTimer.Tick -= new EventHandler(OnLeaderboardTimerTick);
			_leaderboardTimer = null;
		}
		if (_leaderboardCountdownTimer != null)
		{
			_leaderboardCountdownTimer.Stop();
			_leaderboardCountdownTimer.Tick -= new EventHandler(OnCountdownTick);
			_leaderboardCountdownTimer = null;
		}
	}

	[AsyncStateMachine(typeof(_003CLoadLeaderboardDataAsync_003Ed__59))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task LoadLeaderboardDataAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadLeaderboardDataAsync_003Ed__59 _003CLoadLeaderboardDataAsync_003Ed__ = new _003CLoadLeaderboardDataAsync_003Ed__59();
		_003CLoadLeaderboardDataAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadLeaderboardDataAsync_003Ed__._003C_003E4__this = this;
		_003CLoadLeaderboardDataAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadLeaderboardDataAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadLeaderboardDataAsync_003Ed__59>(ref _003CLoadLeaderboardDataAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadLeaderboardDataAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CRefreshLeaderboard_003Ed__60))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task RefreshLeaderboard()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CRefreshLeaderboard_003Ed__60 _003CRefreshLeaderboard_003Ed__ = new _003CRefreshLeaderboard_003Ed__60();
		_003CRefreshLeaderboard_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CRefreshLeaderboard_003Ed__._003C_003E4__this = this;
		_003CRefreshLeaderboard_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CRefreshLeaderboard_003Ed__._003C_003Et__builder)).Start<_003CRefreshLeaderboard_003Ed__60>(ref _003CRefreshLeaderboard_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CRefreshLeaderboard_003Ed__._003C_003Et__builder)).Task;
	}

	public void OnPageAppearing()
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		if (_leaderboardLoaded)
		{
			TimeSpan val = _serverTimeProvider.GetCurrentServerTime() - _lastLeaderboardFetch;
			if (val >= TimeSpan.FromMinutes(5L))
			{
				LoadLeaderboardDataAsync();
			}
			StartLeaderboardTimer();
		}
	}

	public void OnPageDisappearing()
	{
		StopLeaderboardTimer();
	}

	public void Dispose()
	{
		if (!_disposed)
		{
			_stateService.StateChanged -= OnPlayerStateChanged;
			StopLeaderboardTimer();
			ActiveSquad?.Dispose();
			_tasksViewModel?.Dispose();
			_rewardsViewModel?.Dispose();
			_perksViewModel?.Dispose();
			_disposed = true;
			GC.SuppressFinalize((object)this);
		}
	}
}
