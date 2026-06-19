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
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using SpiritSummoner.Application.Enums;
using SpiritSummoner.Application.Events;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Application.UseCases.Quests;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Entities.Quests;
using SpiritSummoner.Domain.Enums.Quests;
using SpiritSummoner.Infrastructure.Cache;
using SpiritSummoner.Presentation.Navigation;

namespace SpiritSummoner.Presentation.ViewModels.Quests;

public class QuestViewModel : ObservableObject, ILoadableViewModel, global::System.IDisposable
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass29_0
	{
		public QuestType questType;

		internal bool _003CLoadQuestData_003Eb__0(Quest q)
		{
			return q.Id == ((object)questType).ToString().ToLowerInvariant();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass38_0
	{
		private sealed class _003C_003CPrefetchAreaTasksAsync_003Eb__1_003Ed : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public Area a;

			public _003C_003Ec__DisplayClass38_0 _003C_003E4__this;

			private Result<GetQuestTasksResult> _003Cresult_003E5__1;

			private Result<GetQuestTasksResult> _003C_003Es__2;

			private TaskAwaiter<Result<GetQuestTasksResult>> _003C_003Eu__1;

			private void MoveNext()
			{
				//IL_0081: Unknown result type (might be due to invalid IL or missing references)
				//IL_0086: Unknown result type (might be due to invalid IL or missing references)
				//IL_008d: Unknown result type (might be due to invalid IL or missing references)
				//IL_004a: Unknown result type (might be due to invalid IL or missing references)
				//IL_004f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0063: Unknown result type (might be due to invalid IL or missing references)
				//IL_0064: Unknown result type (might be due to invalid IL or missing references)
				//IL_0104: Unknown result type (might be due to invalid IL or missing references)
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<Result<GetQuestTasksResult>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this._003C_003E4__this._getQuestTasksForAreaUseCase.ExecuteAsync(new GetQuestTasksRequest(((object)_003C_003E4__this.questType).ToString(), a.Id)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003C_003CPrefetchAreaTasksAsync_003Eb__1_003Ed _003C_003CPrefetchAreaTasksAsync_003Eb__1_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<GetQuestTasksResult>>, _003C_003CPrefetchAreaTasksAsync_003Eb__1_003Ed>(ref awaiter, ref _003C_003CPrefetchAreaTasksAsync_003Eb__1_003Ed);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Result<GetQuestTasksResult>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Cresult_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Cresult_003E5__1.Success && _003Cresult_003E5__1.Data != null)
					{
						_003C_003E4__this._003C_003E4__this._areaTasksCache[new ValueTuple<QuestType, string>(_003C_003E4__this.questType, a.Id)] = _003Cresult_003E5__1.Data.QuestTasks;
					}
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

		public QuestViewModel _003C_003E4__this;

		public QuestType questType;

		internal bool _003CPrefetchAreaTasksAsync_003Eb__0(Area a)
		{
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			return !string.IsNullOrEmpty(a.Id) && !_003C_003E4__this._areaTasksCache.ContainsKey(new ValueTuple<QuestType, string>(questType, a.Id));
		}

		[AsyncStateMachine(typeof(_003C_003CPrefetchAreaTasksAsync_003Eb__1_003Ed))]
		[DebuggerStepThrough]
		internal global::System.Threading.Tasks.Task _003CPrefetchAreaTasksAsync_003Eb__1(Area a)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003CPrefetchAreaTasksAsync_003Eb__1_003Ed _003C_003CPrefetchAreaTasksAsync_003Eb__1_003Ed = new _003C_003CPrefetchAreaTasksAsync_003Eb__1_003Ed
			{
				_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
				_003C_003E4__this = this,
				a = a,
				_003C_003E1__state = -1
			};
			((AsyncTaskMethodBuilder)(ref _003C_003CPrefetchAreaTasksAsync_003Eb__1_003Ed._003C_003Et__builder)).Start<_003C_003CPrefetchAreaTasksAsync_003Eb__1_003Ed>(ref _003C_003CPrefetchAreaTasksAsync_003Eb__1_003Ed);
			return ((AsyncTaskMethodBuilder)(ref _003C_003CPrefetchAreaTasksAsync_003Eb__1_003Ed._003C_003Et__builder)).Task;
		}
	}

	[CompilerGenerated]
	private sealed class _003CGoToFullCollection_003Ed__32 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public QuestViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			//IL_011a: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0136: Unknown result type (might be due to invalid IL or missing references)
			//IL_013b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0143: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
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
						goto IL_0152;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter awaiter2;
					if (num != 0)
					{
						awaiter2 = _003C_003E4__this._navigationService.NavigateToAsync(_003C_003E4__this._stateService.CurrentRoute + "/collection").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CGoToFullCollection_003Ed__32 _003CGoToFullCollection_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoToFullCollection_003Ed__32>(ref awaiter2, ref _003CGoToFullCollection_003Ed__);
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
					goto IL_0175;
				}
				_003Cex_003E5__3 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to open collection.").GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = awaiter;
					_003CGoToFullCollection_003Ed__32 _003CGoToFullCollection_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoToFullCollection_003Ed__32>(ref awaiter, ref _003CGoToFullCollection_003Ed__);
					return;
				}
				goto IL_0152;
				IL_0152:
				((TaskAwaiter)(ref awaiter)).GetResult();
				Console.WriteLine(_003Cex_003E5__3.Message);
				_003Cex_003E5__3 = null;
				goto IL_0175;
				IL_0175:
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
	private sealed class _003CLoadAreaData_003Ed__33 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string selectedQuest;

		public bool playerLevelUp;

		public QuestViewModel _003C_003E4__this;

		private QuestType _003CquestType_003E5__1;

		private ObservableCollection<Area> _003CcachedAreas_003E5__2;

		private Player _003Cplayer_003E5__3;

		private List<string> _003CcompletedTaskKeys_003E5__4;

		private GetQuestAreasRequest _003Crequest_003E5__5;

		private Result<List<Area>> _003Cresult_003E5__6;

		private Result<List<Area>> _003C_003Es__7;

		private ObservableCollection<Area> _003Careas_003E5__8;

		private QuestType _003CquestTypeForCache_003E5__9;

		private global::System.Exception _003Cex_003E5__10;

		private TaskAwaiter<Result<List<Area>>> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_015c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0161: Unknown result type (might be due to invalid IL or missing references)
			//IL_0168: Unknown result type (might be due to invalid IL or missing references)
			//IL_025d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0262: Unknown result type (might be due to invalid IL or missing references)
			//IL_026a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0224: Unknown result type (might be due to invalid IL or missing references)
			//IL_0229: Unknown result type (might be due to invalid IL or missing references)
			//IL_023e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0240: Unknown result type (might be due to invalid IL or missing references)
			//IL_0125: Unknown result type (might be due to invalid IL or missing references)
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			//IL_013e: Unknown result type (might be due to invalid IL or missing references)
			//IL_013f: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num > 1u)
				{
				}
				try
				{
					TaskAwaiter<Result<List<Area>>> awaiter;
					if (num == 0)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Result<List<Area>>>);
						num = (_003C_003E1__state = -1);
						goto IL_0177;
					}
					TaskAwaiter awaiter2;
					if (num == 1)
					{
						awaiter2 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0279;
					}
					_003C_003E4__this.IsLoading = true;
					_003C_003E4__this.ErrorMessage = string.Empty;
					if (!global::System.Enum.TryParse<QuestType>(selectedQuest, ref _003CquestType_003E5__1) || !_003C_003E4__this._areaCache.TryGetValue(_003CquestType_003E5__1, ref _003CcachedAreas_003E5__2) || playerLevelUp)
					{
						_003Cplayer_003E5__3 = _003C_003E4__this._stateService.GetCurrentPlayer();
						_003CcompletedTaskKeys_003E5__4 = (List<string>)((_003Cplayer_003E5__3 != null) ? ((object)GetAllCompletedTaskKeys(_003Cplayer_003E5__3)) : ((object)new List<string>()));
						_003Crequest_003E5__5 = new GetQuestAreasRequest(selectedQuest, _003Cplayer_003E5__3?.PlayerLevel ?? 1, (global::System.Collections.Generic.IReadOnlyList<string>)_003CcompletedTaskKeys_003E5__4);
						awaiter = _003C_003E4__this._getQuestAreasUseCase.ExecuteAsync(_003Crequest_003E5__5).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CLoadAreaData_003Ed__33 _003CLoadAreaData_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<List<Area>>>, _003CLoadAreaData_003Ed__33>(ref awaiter, ref _003CLoadAreaData_003Ed__);
							return;
						}
						goto IL_0177;
					}
					_003C_003E4__this.Areas = _003CcachedAreas_003E5__2;
					_003C_003E4__this.RecomputeAreaQuestFlags((global::System.Collections.Generic.IEnumerable<Area>)_003CcachedAreas_003E5__2);
					goto end_IL_0011;
					IL_0282:
					_003C_003E4__this.Areas = _003Careas_003E5__8;
					_003C_003E4__this.RecomputeAreaQuestFlags((global::System.Collections.Generic.IEnumerable<Area>)_003Careas_003E5__8);
					_003Careas_003E5__8 = null;
					goto IL_02e3;
					IL_02e3:
					_003CcachedAreas_003E5__2 = null;
					_003Cplayer_003E5__3 = null;
					_003CcompletedTaskKeys_003E5__4 = null;
					_003Crequest_003E5__5 = null;
					_003Cresult_003E5__6 = null;
					goto end_IL_0011;
					IL_0279:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					goto IL_0282;
					IL_0177:
					_003C_003Es__7 = awaiter.GetResult();
					_003Cresult_003E5__6 = _003C_003Es__7;
					_003C_003Es__7 = null;
					if (_003Cresult_003E5__6.Success && _003Cresult_003E5__6.Data != null)
					{
						_003Careas_003E5__8 = new ObservableCollection<Area>(_003Cresult_003E5__6.Data);
						if (global::System.Enum.TryParse<QuestType>(selectedQuest, ref _003CquestTypeForCache_003E5__9))
						{
							_003C_003E4__this._areaCache[_003CquestTypeForCache_003E5__9] = _003Careas_003E5__8;
							awaiter2 = _003C_003E4__this.PrefetchAreaTasksAsync(_003CquestTypeForCache_003E5__9, (global::System.Collections.Generic.IEnumerable<Area>)_003Careas_003E5__8).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__2 = awaiter2;
								_003CLoadAreaData_003Ed__33 _003CLoadAreaData_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadAreaData_003Ed__33>(ref awaiter2, ref _003CLoadAreaData_003Ed__);
								return;
							}
							goto IL_0279;
						}
						goto IL_0282;
					}
					_003C_003E4__this.ErrorMessage = _003Cresult_003E5__6.ErrorMessage ?? "Failed to load areas";
					_003C_003E4__this.Areas = new ObservableCollection<Area>();
					goto IL_02e3;
					end_IL_0011:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__10 = ex;
					_003C_003E4__this.ErrorMessage = "Error loading area data: " + _003Cex_003E5__10.Message;
					Console.WriteLine(_003Cex_003E5__10.StackTrace);
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
	private sealed class _003CLoadDataAsync_003Ed__30 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public object param;

		public QuestViewModel _003C_003E4__this;

		private Player _003Cplayer_003E5__1;

		private object _003C_003Es__2;

		private int _003C_003Es__3;

		private global::System.Exception _003Cex_003E5__4;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00c2;
				}
				if (num == 1)
				{
					goto IL_00d0;
				}
				if (!_003C_003E4__this._isCached)
				{
					_003Cplayer_003E5__1 = _003C_003E4__this._stateService.GetCurrentPlayer();
					if (_003Cplayer_003E5__1 == null)
					{
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "No player data available.").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CLoadDataAsync_003Ed__30 _003CLoadDataAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__30>(ref awaiter, ref _003CLoadDataAsync_003Ed__);
							return;
						}
						goto IL_00c2;
					}
					goto IL_00d0;
				}
				goto end_IL_0007;
				IL_00c2:
				((TaskAwaiter)(ref awaiter)).GetResult();
				goto end_IL_0007;
				IL_00d0:
				try
				{
					TaskAwaiter awaiter2;
					if (num != 1)
					{
						_003C_003Es__3 = 0;
						try
						{
							_003C_003E4__this.IsLoading = true;
							_003C_003E4__this.ErrorMessage = string.Empty;
							_003C_003E4__this.LoadQuestData(_003C_003E4__this.CurrentQuestType);
							_003C_003E4__this.OnCurrentQuestTypeChanged(_003C_003E4__this.CurrentQuestType);
							_003C_003E4__this._isCached = true;
						}
						catch (global::System.Exception ex)
						{
							_003C_003Es__2 = ex;
							_003C_003Es__3 = 1;
						}
						int num2 = _003C_003Es__3;
						if (num2 != 1)
						{
							goto IL_022f;
						}
						_003Cex_003E5__4 = (global::System.Exception)_003C_003Es__2;
						_003C_003E4__this.ErrorMessage = "Failed to load quests: " + _003Cex_003E5__4.Message;
						awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", _003C_003E4__this.ErrorMessage).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter2;
							_003CLoadDataAsync_003Ed__30 _003CLoadDataAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__30>(ref awaiter2, ref _003CLoadDataAsync_003Ed__);
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
					Console.WriteLine(_003Cex_003E5__4.StackTrace);
					_003Cex_003E5__4 = null;
					goto IL_022f;
					IL_022f:
					_003C_003Es__2 = null;
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
	private sealed class _003CLoadQuestData_003Ed__29 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public QuestType questType;

		public QuestViewModel _003C_003E4__this;

		private _003C_003Ec__DisplayClass29_0 _003C_003E8__1;

		private Quest _003CcachedQuest_003E5__2;

		private Player _003Cplayer_003E5__3;

		private GetQuestsRequest _003Crequest_003E5__4;

		private Result<List<Quest>> _003Cresult_003E5__5;

		private Result<List<Quest>> _003C_003Es__6;

		private TaskAwaiter<Result<List<Quest>>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter<Result<List<Quest>>> awaiter;
				if (num != 0)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass29_0();
					_003C_003E8__1.questType = questType;
					if (_003C_003E4__this._questCache.TryGetValue(_003C_003E8__1.questType, ref _003CcachedQuest_003E5__2))
					{
						goto IL_01ac;
					}
					_003Cplayer_003E5__3 = _003C_003E4__this._stateService.GetCurrentPlayer();
					_003Crequest_003E5__4 = new GetQuestsRequest(_003Cplayer_003E5__3?.PlayerLevel ?? 1);
					awaiter = _003C_003E4__this._getQuestsUseCase.ExecuteAsync(_003Crequest_003E5__4).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CLoadQuestData_003Ed__29 _003CLoadQuestData_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<List<Quest>>>, _003CLoadQuestData_003Ed__29>(ref awaiter, ref _003CLoadQuestData_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Result<List<Quest>>>);
					num = (_003C_003E1__state = -1);
				}
				_003C_003Es__6 = awaiter.GetResult();
				_003Cresult_003E5__5 = _003C_003Es__6;
				_003C_003Es__6 = null;
				if (_003Cresult_003E5__5.Success && _003Cresult_003E5__5.Data != null)
				{
					_003CcachedQuest_003E5__2 = Enumerable.FirstOrDefault<Quest>((global::System.Collections.Generic.IEnumerable<Quest>)_003Cresult_003E5__5.Data, (Func<Quest, bool>)((Quest q) => q.Id == ((object)_003C_003E8__1.questType).ToString().ToLowerInvariant()));
					if (_003CcachedQuest_003E5__2 != null)
					{
						_003C_003E4__this._questCache[_003C_003E8__1.questType] = _003CcachedQuest_003E5__2;
					}
				}
				_003Cplayer_003E5__3 = null;
				_003Crequest_003E5__4 = null;
				_003Cresult_003E5__5 = null;
				goto IL_01ac;
				IL_01ac:
				_003C_003E4__this.CurrentQuest = _003CcachedQuest_003E5__2;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003CcachedQuest_003E5__2 = null;
				((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003CcachedQuest_003E5__2 = null;
			((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CPrefetchAreaTasksAsync_003Ed__38 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public QuestType questType;

		public global::System.Collections.Generic.IEnumerable<Area> areas;

		public QuestViewModel _003C_003E4__this;

		private _003C_003Ec__DisplayClass38_0 _003C_003E8__1;

		private global::System.Collections.Generic.IEnumerable<global::System.Threading.Tasks.Task> _003Cfetches_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass38_0();
					_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
					_003C_003E8__1.questType = questType;
					_003Cfetches_003E5__2 = Enumerable.Select<Area, global::System.Threading.Tasks.Task>(Enumerable.Where<Area>(areas, (Func<Area, bool>)((Area a) => !string.IsNullOrEmpty(a.Id) && !_003C_003E8__1._003C_003E4__this._areaTasksCache.ContainsKey(new ValueTuple<QuestType, string>(_003C_003E8__1.questType, a.Id)))), (Func<Area, global::System.Threading.Tasks.Task>)([AsyncStateMachine(typeof(_003C_003Ec__DisplayClass38_0._003C_003CPrefetchAreaTasksAsync_003Eb__1_003Ed))] [DebuggerStepThrough] (Area a) =>
					{
						//IL_0007: Unknown result type (might be due to invalid IL or missing references)
						//IL_000c: Unknown result type (might be due to invalid IL or missing references)
						_003C_003Ec__DisplayClass38_0._003C_003CPrefetchAreaTasksAsync_003Eb__1_003Ed _003C_003CPrefetchAreaTasksAsync_003Eb__1_003Ed = new _003C_003Ec__DisplayClass38_0._003C_003CPrefetchAreaTasksAsync_003Eb__1_003Ed
						{
							_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
							_003C_003E4__this = _003C_003E8__1,
							a = a,
							_003C_003E1__state = -1
						};
						((AsyncTaskMethodBuilder)(ref _003C_003CPrefetchAreaTasksAsync_003Eb__1_003Ed._003C_003Et__builder)).Start<_003C_003Ec__DisplayClass38_0._003C_003CPrefetchAreaTasksAsync_003Eb__1_003Ed>(ref _003C_003CPrefetchAreaTasksAsync_003Eb__1_003Ed);
						return ((AsyncTaskMethodBuilder)(ref _003C_003CPrefetchAreaTasksAsync_003Eb__1_003Ed._003C_003Et__builder)).Task;
					}));
					awaiter = global::System.Threading.Tasks.Task.WhenAll(_003Cfetches_003E5__2).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CPrefetchAreaTasksAsync_003Ed__38 _003CPrefetchAreaTasksAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CPrefetchAreaTasksAsync_003Ed__38>(ref awaiter, ref _003CPrefetchAreaTasksAsync_003Ed__);
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
				_003C_003E4__this.RecomputeAreaQuestFlags(areas);
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003Cfetches_003E5__2 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003Cfetches_003E5__2 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CRefreshAfterQuestUpdate_003Ed__43 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public QuestViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					_003C_003E4__this.ClearCache();
					_003C_003E4__this.UpdateQuestKeysForCurrentType();
					awaiter = _003C_003E4__this.LoadDataAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CRefreshAfterQuestUpdate_003Ed__43 _003CRefreshAfterQuestUpdate_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRefreshAfterQuestUpdate_003Ed__43>(ref awaiter, ref _003CRefreshAfterQuestUpdate_003Ed__);
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
	private sealed class _003CSelectArea_003Ed__34 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string selectedAreaId;

		public QuestViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_030b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0310: Unknown result type (might be due to invalid IL or missing references)
			//IL_0325: Unknown result type (might be due to invalid IL or missing references)
			//IL_0327: Unknown result type (might be due to invalid IL or missing references)
			//IL_0344: Unknown result type (might be due to invalid IL or missing references)
			//IL_0349: Unknown result type (might be due to invalid IL or missing references)
			//IL_0351: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_0144: Unknown result type (might be due to invalid IL or missing references)
			//IL_0149: Unknown result type (might be due to invalid IL or missing references)
			//IL_0151: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01da: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_026c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0271: Unknown result type (might be due to invalid IL or missing references)
			//IL_0279: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_0233: Unknown result type (might be due to invalid IL or missing references)
			//IL_0238: Unknown result type (might be due to invalid IL or missing references)
			//IL_019c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0125: Unknown result type (might be due to invalid IL or missing references)
			//IL_0127: Unknown result type (might be due to invalid IL or missing references)
			//IL_024d: Unknown result type (might be due to invalid IL or missing references)
			//IL_024f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if ((uint)num > 3u)
				{
					if (num == 4)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0360;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter awaiter5;
					TaskAwaiter awaiter4;
					TaskAwaiter awaiter3;
					TaskAwaiter awaiter2;
					switch (num)
					{
					default:
						if (string.IsNullOrEmpty(selectedAreaId))
						{
							awaiter5 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Invalid area selection.").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter5)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter5;
								_003CSelectArea_003Ed__34 _003CSelectArea_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSelectArea_003Ed__34>(ref awaiter5, ref _003CSelectArea_003Ed__);
								return;
							}
							goto IL_00c9;
						}
						if (!_003C_003E4__this.IsAreaUnlocked(selectedAreaId))
						{
							awaiter4 = _003C_003E4__this._navigationService.ShowAlertAsync("Area Locked", "Complete previous quests to unlock this area.").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__1 = awaiter4;
								_003CSelectArea_003Ed__34 _003CSelectArea_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSelectArea_003Ed__34>(ref awaiter4, ref _003CSelectArea_003Ed__);
								return;
							}
							goto IL_0160;
						}
						if (_003C_003E4__this.CurrentQuest == null)
						{
							awaiter3 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Quest data not available.").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__1 = awaiter3;
								_003CSelectArea_003Ed__34 _003CSelectArea_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSelectArea_003Ed__34>(ref awaiter3, ref _003CSelectArea_003Ed__);
								return;
							}
							goto IL_01f1;
						}
						awaiter2 = _003C_003E4__this._navigationService.NavigateToAsync("//questtasks/" + _003C_003E4__this.CurrentQuest.Id + "/" + selectedAreaId).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 3);
							_003C_003Eu__1 = awaiter2;
							_003CSelectArea_003Ed__34 _003CSelectArea_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSelectArea_003Ed__34>(ref awaiter2, ref _003CSelectArea_003Ed__);
							return;
						}
						break;
					case 0:
						awaiter5 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_00c9;
					case 1:
						awaiter4 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0160;
					case 2:
						awaiter3 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_01f1;
					case 3:
						{
							awaiter2 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							break;
						}
						IL_0160:
						((TaskAwaiter)(ref awaiter4)).GetResult();
						goto end_IL_0007;
						IL_01f1:
						((TaskAwaiter)(ref awaiter3)).GetResult();
						goto end_IL_0007;
						IL_00c9:
						((TaskAwaiter)(ref awaiter5)).GetResult();
						goto end_IL_0007;
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
					goto IL_0394;
				}
				_003Cex_003E5__3 = (global::System.Exception)_003C_003Es__1;
				_003C_003E4__this.ErrorMessage = "Error selecting area: " + _003Cex_003E5__3.Message;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error selecting area", _003C_003E4__this.ErrorMessage).GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 4);
					_003C_003Eu__1 = awaiter;
					_003CSelectArea_003Ed__34 _003CSelectArea_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSelectArea_003Ed__34>(ref awaiter, ref _003CSelectArea_003Ed__);
					return;
				}
				goto IL_0360;
				IL_0360:
				((TaskAwaiter)(ref awaiter)).GetResult();
				Console.WriteLine(_003Cex_003E5__3.Message);
				Console.WriteLine(_003Cex_003E5__3.StackTrace);
				_003Cex_003E5__3 = null;
				goto IL_0394;
				IL_0394:
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
	private sealed class _003CSelectQuestType_003Ed__31 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string questType;

		public QuestViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private QuestType _003CparsedQuestType_003E5__3;

		private global::System.Exception _003Cex_003E5__4;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_017f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0184: Unknown result type (might be due to invalid IL or missing references)
			//IL_0199: Unknown result type (might be due to invalid IL or missing references)
			//IL_019b: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
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
						goto IL_01d1;
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
						goto IL_00fb;
					}
					if (!global::System.Enum.TryParse<QuestType>(questType, ref _003CparsedQuestType_003E5__3))
					{
						_003C_003E4__this.ErrorMessage = "Invalid quest type: " + questType;
						awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", _003C_003E4__this.ErrorMessage).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CSelectQuestType_003Ed__31 _003CSelectQuestType_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSelectQuestType_003Ed__31>(ref awaiter2, ref _003CSelectQuestType_003Ed__);
							return;
						}
						goto IL_00fb;
					}
					_003C_003E4__this.CurrentQuestType = _003CparsedQuestType_003E5__3;
					_003C_003E4__this.ErrorMessage = string.Empty;
					goto end_IL_0022;
					IL_00fb:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					end_IL_0022:;
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
				}
				int num2 = _003C_003Es__2;
				if (num2 != 1)
				{
					goto IL_01e3;
				}
				_003Cex_003E5__4 = (global::System.Exception)_003C_003Es__1;
				_003C_003E4__this.ErrorMessage = "Error selecting quest type: " + _003Cex_003E5__4.Message;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", _003C_003E4__this.ErrorMessage).GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = awaiter;
					_003CSelectQuestType_003Ed__31 _003CSelectQuestType_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSelectQuestType_003Ed__31>(ref awaiter, ref _003CSelectQuestType_003Ed__);
					return;
				}
				goto IL_01d1;
				IL_01d1:
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003Cex_003E5__4 = null;
				goto IL_01e3;
				IL_01e3:
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

	private readonly INavigationService _navigationService;

	private readonly IPlayerStateService _stateService;

	private readonly GetQuestsUseCase _getQuestsUseCase;

	private readonly GetQuestAreasUseCase _getQuestAreasUseCase;

	private readonly GetQuestTasksForAreaUseCase _getQuestTasksForAreaUseCase;

	private bool _isCached;

	private bool _disposed;

	private readonly Dictionary<QuestType, ObservableCollection<Area>> _areaCache = new Dictionary<QuestType, ObservableCollection<Area>>();

	private readonly Dictionary<QuestType, Quest> _questCache = new Dictionary<QuestType, Quest>();

	private readonly Dictionary<ValueTuple<QuestType, string>, List<QuestTask>> _areaTasksCache = new Dictionary<ValueTuple<QuestType, string>, List<QuestTask>>();

	[ObservableProperty]
	private QuestType _currentQuestType = QuestType.story;

	[ObservableProperty]
	private ObservableCollection<Area>? _areas = new ObservableCollection<Area>();

	[ObservableProperty]
	private Quest? _currentQuest;

	[ObservableProperty]
	private bool _isLoading;

	[ObservableProperty]
	private string _errorMessage = string.Empty;

	[ObservableProperty]
	[NotifyPropertyChangedFor("HasAvailableQuests")]
	[NotifyPropertyChangedFor("QuestProgressSummary")]
	private List<string> _questKeys = new List<string>();

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<object?>? loadDataCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<string>? selectQuestTypeCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? goToFullCollectionCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<string>? selectAreaCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? refreshQuestDataCommand;

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string VmID
	{
		[CompilerGenerated]
		get;
	} = "quest";


	public bool HasAvailableQuests
	{
		get
		{
			List<string> questKeys = QuestKeys;
			return questKeys != null && Enumerable.Any<string>((global::System.Collections.Generic.IEnumerable<string>)questKeys);
		}
	}

	public string QuestProgressSummary => GetCompletedTasksCount().ToString();

	public int PlayerLevel => _stateService.GetCurrentPlayer()?.PlayerLevel ?? 0;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public QuestType CurrentQuestType
	{
		get
		{
			return _currentQuestType;
		}
		set
		{
			if (!EqualityComparer<QuestType>.Default.Equals(_currentQuestType, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CurrentQuestType);
				_currentQuestType = value;
				OnCurrentQuestTypeChanged(value);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CurrentQuestType);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ObservableCollection<Area>? Areas
	{
		get
		{
			return _areas;
		}
		set
		{
			if (!EqualityComparer<ObservableCollection<Area>>.Default.Equals(_areas, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Areas);
				_areas = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Areas);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public Quest? CurrentQuest
	{
		get
		{
			return _currentQuest;
		}
		set
		{
			if (!EqualityComparer<Quest>.Default.Equals(_currentQuest, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CurrentQuest);
				_currentQuest = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CurrentQuest);
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
	public List<string> QuestKeys
	{
		get
		{
			return _questKeys;
		}
		[MemberNotNull("_questKeys")]
		set
		{
			if (!EqualityComparer<List<string>>.Default.Equals(_questKeys, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.QuestKeys);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HasAvailableQuests);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.QuestProgressSummary);
				_questKeys = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.QuestKeys);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HasAvailableQuests);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.QuestProgressSummary);
			}
		}
	}

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
	public IAsyncRelayCommand<string> SelectQuestTypeCommand => (IAsyncRelayCommand<string>)(object)(selectQuestTypeCommand ?? (selectQuestTypeCommand = new AsyncRelayCommand<string>((Func<string, global::System.Threading.Tasks.Task>)SelectQuestType)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand GoToFullCollectionCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = goToFullCollectionCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)GoToFullCollection);
				AsyncRelayCommand val2 = val;
				goToFullCollectionCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<string> SelectAreaCommand => (IAsyncRelayCommand<string>)(object)(selectAreaCommand ?? (selectAreaCommand = new AsyncRelayCommand<string>((Func<string, global::System.Threading.Tasks.Task>)SelectArea)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand RefreshQuestDataCommand
	{
		get
		{
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Expected O, but got Unknown
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			RelayCommand obj = refreshQuestDataCommand;
			if (obj == null)
			{
				RelayCommand val = new RelayCommand(new Action(RefreshQuestData));
				RelayCommand val2 = val;
				refreshQuestDataCommand = val;
				obj = val2;
			}
			return (IRelayCommand)(object)obj;
		}
	}

	public QuestViewModel(INavigationService navigationService, IPlayerStateService stateService, GetQuestsUseCase getQuestsUseCase, GetQuestAreasUseCase getQuestAreasUseCase, GetQuestTasksForAreaUseCase getQuestTasksForAreaUseCase)
	{
		_navigationService = navigationService;
		_stateService = stateService;
		_getQuestsUseCase = getQuestsUseCase;
		_getQuestAreasUseCase = getQuestAreasUseCase;
		_getQuestTasksForAreaUseCase = getQuestTasksForAreaUseCase;
		_stateService.StateChanged += OnStateChanged;
	}

	private void OnStateChanged(object? sender, StateChangedEventArgs e)
	{
		switch (e.Scope)
		{
		case StateChangeScope.Quest:
			UpdateQuestKeysForCurrentType();
			((ObservableObject)this).OnPropertyChanged("HasAvailableQuests");
			((ObservableObject)this).OnPropertyChanged("QuestProgressSummary");
			LoadAreaData(((object)CurrentQuestType).ToString(), playerLevelUp: true);
			break;
		case StateChangeScope.Player:
			if (e.ChangeType == "LevelUp")
			{
				LoadAreaData(((object)CurrentQuestType).ToString(), playerLevelUp: true);
				((ObservableObject)this).OnPropertyChanged("PlayerLevel");
			}
			break;
		}
	}

	private int GetCompletedTasksCount()
	{
		Player currentPlayer = _stateService.GetCurrentPlayer();
		if (currentPlayer?.PlayerQuests == null)
		{
			return 0;
		}
		string text = ((object)CurrentQuestType).ToString();
		PlayerQuest playerQuest = default(PlayerQuest);
		if (!currentPlayer.PlayerQuests.TryGetValue(text, ref playerQuest))
		{
			return 0;
		}
		Dictionary<string, TaskProgress> tasks = playerQuest.Tasks;
		return (tasks != null) ? Enumerable.Count<KeyValuePair<string, TaskProgress>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, TaskProgress>>)tasks, (Func<KeyValuePair<string, TaskProgress>, bool>)((KeyValuePair<string, TaskProgress> t) => t.Value.IsCompleted)) : 0;
	}

	private void UpdateQuestKeysForCurrentType()
	{
		Player currentPlayer = _stateService.GetCurrentPlayer();
		if (currentPlayer?.PlayerQuests == null)
		{
			QuestKeys = new List<string>();
			return;
		}
		string text = ((object)CurrentQuestType).ToString();
		PlayerQuest playerQuest = default(PlayerQuest);
		if (currentPlayer.PlayerQuests.TryGetValue(text, ref playerQuest))
		{
			QuestKeys = Enumerable.ToList<string>((global::System.Collections.Generic.IEnumerable<string>)playerQuest.Tasks.Keys);
		}
		else
		{
			QuestKeys = new List<string>();
		}
	}

	[AsyncStateMachine(typeof(_003CLoadQuestData_003Ed__29))]
	[DebuggerStepThrough]
	private void LoadQuestData(QuestType questType)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadQuestData_003Ed__29 _003CLoadQuestData_003Ed__ = new _003CLoadQuestData_003Ed__29();
		_003CLoadQuestData_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003CLoadQuestData_003Ed__._003C_003E4__this = this;
		_003CLoadQuestData_003Ed__.questType = questType;
		_003CLoadQuestData_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003CLoadQuestData_003Ed__._003C_003Et__builder)).Start<_003CLoadQuestData_003Ed__29>(ref _003CLoadQuestData_003Ed__);
	}

	[AsyncStateMachine(typeof(_003CLoadDataAsync_003Ed__30))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task LoadDataAsync(object? param = null)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadDataAsync_003Ed__30 _003CLoadDataAsync_003Ed__ = new _003CLoadDataAsync_003Ed__30();
		_003CLoadDataAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadDataAsync_003Ed__._003C_003E4__this = this;
		_003CLoadDataAsync_003Ed__.param = param;
		_003CLoadDataAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadDataAsync_003Ed__30>(ref _003CLoadDataAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CSelectQuestType_003Ed__31))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task SelectQuestType(string questType)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CSelectQuestType_003Ed__31 _003CSelectQuestType_003Ed__ = new _003CSelectQuestType_003Ed__31();
		_003CSelectQuestType_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CSelectQuestType_003Ed__._003C_003E4__this = this;
		_003CSelectQuestType_003Ed__.questType = questType;
		_003CSelectQuestType_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CSelectQuestType_003Ed__._003C_003Et__builder)).Start<_003CSelectQuestType_003Ed__31>(ref _003CSelectQuestType_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CSelectQuestType_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CGoToFullCollection_003Ed__32))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task GoToFullCollection()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CGoToFullCollection_003Ed__32 _003CGoToFullCollection_003Ed__ = new _003CGoToFullCollection_003Ed__32();
		_003CGoToFullCollection_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CGoToFullCollection_003Ed__._003C_003E4__this = this;
		_003CGoToFullCollection_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CGoToFullCollection_003Ed__._003C_003Et__builder)).Start<_003CGoToFullCollection_003Ed__32>(ref _003CGoToFullCollection_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CGoToFullCollection_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CLoadAreaData_003Ed__33))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task LoadAreaData(string selectedQuest = "story", bool playerLevelUp = false)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadAreaData_003Ed__33 _003CLoadAreaData_003Ed__ = new _003CLoadAreaData_003Ed__33();
		_003CLoadAreaData_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadAreaData_003Ed__._003C_003E4__this = this;
		_003CLoadAreaData_003Ed__.selectedQuest = selectedQuest;
		_003CLoadAreaData_003Ed__.playerLevelUp = playerLevelUp;
		_003CLoadAreaData_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadAreaData_003Ed__._003C_003Et__builder)).Start<_003CLoadAreaData_003Ed__33>(ref _003CLoadAreaData_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadAreaData_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CSelectArea_003Ed__34))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task SelectArea(string selectedAreaId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CSelectArea_003Ed__34 _003CSelectArea_003Ed__ = new _003CSelectArea_003Ed__34();
		_003CSelectArea_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CSelectArea_003Ed__._003C_003E4__this = this;
		_003CSelectArea_003Ed__.selectedAreaId = selectedAreaId;
		_003CSelectArea_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CSelectArea_003Ed__._003C_003Et__builder)).Start<_003CSelectArea_003Ed__34>(ref _003CSelectArea_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CSelectArea_003Ed__._003C_003Et__builder)).Task;
	}

	public bool IsAreaUnlockedForDisplay(string areaId)
	{
		string areaId2 = areaId;
		Player currentPlayer = _stateService.GetCurrentPlayer();
		if (currentPlayer == null)
		{
			return false;
		}
		ObservableCollection<Area> val = default(ObservableCollection<Area>);
		if (!_areaCache.TryGetValue(CurrentQuestType, ref val))
		{
			return false;
		}
		Area area = Enumerable.FirstOrDefault<Area>((global::System.Collections.Generic.IEnumerable<Area>)val, (Func<Area, bool>)((Area a) => a.Id == areaId2));
		if (area == null)
		{
			return false;
		}
		if (currentPlayer.PlayerLevel < area.LevelRequired)
		{
			return false;
		}
		if (!string.IsNullOrEmpty(area.TaskRequired))
		{
			List<string> allCompletedTaskKeys = GetAllCompletedTaskKeys(currentPlayer);
			if (!allCompletedTaskKeys.Contains(area.TaskRequired))
			{
				return false;
			}
		}
		return true;
	}

	private bool IsAreaUnlocked(string areaId)
	{
		return IsAreaUnlockedForDisplay(areaId);
	}

	public bool HasAvailableTasksForArea(string areaId)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		Player currentPlayer = _stateService.GetCurrentPlayer();
		if (currentPlayer == null)
		{
			return false;
		}
		List<QuestTask> val = default(List<QuestTask>);
		if (!_areaTasksCache.TryGetValue(new ValueTuple<QuestType, string>(CurrentQuestType, areaId), ref val) || val.Count == 0)
		{
			return true;
		}
		IReadOnlyDictionary<string, PlayerQuest> playerQuests = currentPlayer.PlayerQuests;
		Dictionary<string, TaskProgress> progress = ((playerQuests != null) ? CollectionExtensions.GetValueOrDefault<string, PlayerQuest>(playerQuests, ((object)CurrentQuestType).ToString()) : null)?.Tasks;
		return Enumerable.Any<QuestTask>((global::System.Collections.Generic.IEnumerable<QuestTask>)val, (Func<QuestTask, bool>)delegate(QuestTask t)
		{
			string id = t.Id;
			if (string.IsNullOrEmpty(id))
			{
				return false;
			}
			TaskProgress taskProgress = default(TaskProgress);
			return progress == null || !progress.TryGetValue(id, ref taskProgress) || (!taskProgress.IsCompleted && !t.IsRepeatable);
		});
	}

	[AsyncStateMachine(typeof(_003CPrefetchAreaTasksAsync_003Ed__38))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task PrefetchAreaTasksAsync(QuestType questType, global::System.Collections.Generic.IEnumerable<Area> areas)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CPrefetchAreaTasksAsync_003Ed__38 _003CPrefetchAreaTasksAsync_003Ed__ = new _003CPrefetchAreaTasksAsync_003Ed__38();
		_003CPrefetchAreaTasksAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CPrefetchAreaTasksAsync_003Ed__._003C_003E4__this = this;
		_003CPrefetchAreaTasksAsync_003Ed__.questType = questType;
		_003CPrefetchAreaTasksAsync_003Ed__.areas = areas;
		_003CPrefetchAreaTasksAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CPrefetchAreaTasksAsync_003Ed__._003C_003Et__builder)).Start<_003CPrefetchAreaTasksAsync_003Ed__38>(ref _003CPrefetchAreaTasksAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CPrefetchAreaTasksAsync_003Ed__._003C_003Et__builder)).Task;
	}

	private void RecomputeAreaQuestFlags(global::System.Collections.Generic.IEnumerable<Area> areas)
	{
		global::System.Collections.Generic.IEnumerator<Area> enumerator = areas.GetEnumerator();
		try
		{
			while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
			{
				Area current = enumerator.Current;
				if (!string.IsNullOrEmpty(current.Id))
				{
					current.HasUnclaimedQuest = HasAvailableTasksForArea(current.Id);
				}
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator)?.Dispose();
		}
	}

	private static List<string> GetAllCompletedTaskKeys(Player player)
	{
		if (player.PlayerQuests == null)
		{
			return new List<string>();
		}
		return Enumerable.ToList<string>(Enumerable.SelectMany<KeyValuePair<string, PlayerQuest>, string>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, PlayerQuest>>)player.PlayerQuests, (Func<KeyValuePair<string, PlayerQuest>, global::System.Collections.Generic.IEnumerable<string>>)((KeyValuePair<string, PlayerQuest> kvp) => Enumerable.Select<KeyValuePair<string, TaskProgress>, string>(Enumerable.Where<KeyValuePair<string, TaskProgress>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, TaskProgress>>)kvp.Value.Tasks, (Func<KeyValuePair<string, TaskProgress>, bool>)((KeyValuePair<string, TaskProgress> t) => t.Value.IsCompleted)), (Func<KeyValuePair<string, TaskProgress>, string>)((KeyValuePair<string, TaskProgress> t) => t.Key)))));
	}

	[RelayCommand]
	private void RefreshQuestData()
	{
		ClearCache();
		LoadDataAsync();
	}

	public void ClearCache()
	{
		_areaCache.Clear();
		_questCache.Clear();
		_areaTasksCache.Clear();
	}

	[AsyncStateMachine(typeof(_003CRefreshAfterQuestUpdate_003Ed__43))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task RefreshAfterQuestUpdate()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CRefreshAfterQuestUpdate_003Ed__43 _003CRefreshAfterQuestUpdate_003Ed__ = new _003CRefreshAfterQuestUpdate_003Ed__43();
		_003CRefreshAfterQuestUpdate_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CRefreshAfterQuestUpdate_003Ed__._003C_003E4__this = this;
		_003CRefreshAfterQuestUpdate_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CRefreshAfterQuestUpdate_003Ed__._003C_003Et__builder)).Start<_003CRefreshAfterQuestUpdate_003Ed__43>(ref _003CRefreshAfterQuestUpdate_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CRefreshAfterQuestUpdate_003Ed__._003C_003Et__builder)).Task;
	}

	public void Dispose()
	{
		if (!_disposed)
		{
			_stateService.StateChanged -= OnStateChanged;
			ClearCache();
			_disposed = true;
			GC.SuppressFinalize((object)this);
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnCurrentQuestTypeChanged(QuestType value)
	{
		UpdateQuestKeysForCurrentType();
		LoadQuestData(value);
		LoadAreaData(((object)value).ToString());
	}
}
