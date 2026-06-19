using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.Data.Sqlite;
using Microsoft.Maui.Networking;
using Microsoft.Maui.Storage;
using SpiritSummoner.Application.BatchUpdates;
using SpiritSummoner.Application.Interfaces;
using SpiritSummoner.Domain.Repositories;
using SpiritSummoner.Infrastructure.Diagnostics;

namespace SpiritSummoner.Infrastructure.Services;

public class PersistentBatchQueueService : IBatchQueueService, global::System.IDisposable
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass34_0
	{
		private sealed class _003C_003CQueueUpdate_003Eb__0_003Ed : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public _003C_003Ec__DisplayClass34_0 _003C_003E4__this;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
				//IL_005d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0062: Unknown result type (might be due to invalid IL or missing references)
				//IL_0069: Unknown result type (might be due to invalid IL or missing references)
				//IL_0029: Unknown result type (might be due to invalid IL or missing references)
				//IL_002e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0042: Unknown result type (might be due to invalid IL or missing references)
				//IL_0043: Unknown result type (might be due to invalid IL or missing references)
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this._003C_003E4__this.QueueUpdateInternal(_003C_003E4__this.update).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003C_003CQueueUpdate_003Eb__0_003Ed _003C_003CQueueUpdate_003Eb__0_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003C_003CQueueUpdate_003Eb__0_003Ed>(ref awaiter, ref _003C_003CQueueUpdate_003Eb__0_003Ed);
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

		public PersistentBatchQueueService _003C_003E4__this;

		public PlayerBatchUpdate update;

		[AsyncStateMachine(typeof(_003C_003CQueueUpdate_003Eb__0_003Ed))]
		[DebuggerStepThrough]
		internal global::System.Threading.Tasks.Task? _003CQueueUpdate_003Eb__0()
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003CQueueUpdate_003Eb__0_003Ed _003C_003CQueueUpdate_003Eb__0_003Ed = new _003C_003CQueueUpdate_003Eb__0_003Ed
			{
				_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
				_003C_003E4__this = this,
				_003C_003E1__state = -1
			};
			((AsyncTaskMethodBuilder)(ref _003C_003CQueueUpdate_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003CQueueUpdate_003Eb__0_003Ed>(ref _003C_003CQueueUpdate_003Eb__0_003Ed);
			return ((AsyncTaskMethodBuilder)(ref _003C_003CQueueUpdate_003Eb__0_003Ed._003C_003Et__builder)).Task;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass34_1
	{
		private sealed class _003C_003CQueueUpdate_003Eb__1_003Ed : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public _003C_003Ec__DisplayClass34_1 _003C_003E4__this;

			private BatchUpdateOutcome _003Coutcome_003E5__1;

			private Enumerator<string> _003C_003Es__2;

			private string _003Cid_003E5__3;

			private BatchUpdateOutcome _003C_003Es__4;

			private TaskAwaiter _003C_003Eu__1;

			private TaskAwaiter<BatchUpdateOutcome> _003C_003Eu__2;

			private void MoveNext()
			{
				//IL_0177: Unknown result type (might be due to invalid IL or missing references)
				//IL_017c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0183: Unknown result type (might be due to invalid IL or missing references)
				//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
				//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
				//IL_0200: Unknown result type (might be due to invalid IL or missing references)
				//IL_0299: Unknown result type (might be due to invalid IL or missing references)
				//IL_029e: Unknown result type (might be due to invalid IL or missing references)
				//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
				//IL_0334: Unknown result type (might be due to invalid IL or missing references)
				//IL_0339: Unknown result type (might be due to invalid IL or missing references)
				//IL_0341: Unknown result type (might be due to invalid IL or missing references)
				//IL_0047: Unknown result type (might be due to invalid IL or missing references)
				//IL_004c: Unknown result type (might be due to invalid IL or missing references)
				//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
				//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
				//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
				//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
				//IL_0260: Unknown result type (might be due to invalid IL or missing references)
				//IL_0265: Unknown result type (might be due to invalid IL or missing references)
				//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
				//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
				//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
				//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
				//IL_0300: Unknown result type (might be due to invalid IL or missing references)
				//IL_027a: Unknown result type (might be due to invalid IL or missing references)
				//IL_027c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0315: Unknown result type (might be due to invalid IL or missing references)
				//IL_0317: Unknown result type (might be due to invalid IL or missing references)
				//IL_008a: Unknown result type (might be due to invalid IL or missing references)
				//IL_008f: Unknown result type (might be due to invalid IL or missing references)
				//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
				//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
				//IL_011a: Unknown result type (might be due to invalid IL or missing references)
				//IL_0140: Unknown result type (might be due to invalid IL or missing references)
				//IL_0145: Unknown result type (might be due to invalid IL or missing references)
				//IL_0159: Unknown result type (might be due to invalid IL or missing references)
				//IL_015a: Unknown result type (might be due to invalid IL or missing references)
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter awaiter4;
					TaskAwaiter<BatchUpdateOutcome> awaiter3;
					TaskAwaiter awaiter2;
					TaskAwaiter awaiter;
					switch (num)
					{
					default:
						_003C_003Es__2 = _003C_003E4__this.capturedAbsorbedIds.GetEnumerator();
						goto case 0;
					case 0:
						try
						{
							if (num != 0)
							{
								goto IL_00eb;
							}
							TaskAwaiter awaiter5 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_00dc;
							IL_00dc:
							((TaskAwaiter)(ref awaiter5)).GetResult();
							_003Cid_003E5__3 = null;
							goto IL_00eb;
							IL_00eb:
							if (_003C_003Es__2.MoveNext())
							{
								_003Cid_003E5__3 = _003C_003Es__2.Current;
								awaiter5 = _003C_003E4__this.CS_0024_003C_003E8__locals1._003C_003E4__this.RemovePendingUpdateAsync(_003Cid_003E5__3).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter5)).IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter5;
									_003C_003CQueueUpdate_003Eb__1_003Ed _003C_003CQueueUpdate_003Eb__1_003Ed = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003C_003CQueueUpdate_003Eb__1_003Ed>(ref awaiter5, ref _003C_003CQueueUpdate_003Eb__1_003Ed);
									return;
								}
								goto IL_00dc;
							}
						}
						finally
						{
							if (num < 0)
							{
								((global::System.IDisposable)_003C_003Es__2).Dispose();
							}
						}
						_003C_003Es__2 = default(Enumerator<string>);
						awaiter4 = _003C_003E4__this.CS_0024_003C_003E8__locals1._003C_003E4__this.StorePendingUpdateAsync(_003C_003E4__this.pendingUpdate).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter4;
							_003C_003CQueueUpdate_003Eb__1_003Ed _003C_003CQueueUpdate_003Eb__1_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003C_003CQueueUpdate_003Eb__1_003Ed>(ref awaiter4, ref _003C_003CQueueUpdate_003Eb__1_003Ed);
							return;
						}
						goto IL_0192;
					case 1:
						awaiter4 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0192;
					case 2:
						awaiter3 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<BatchUpdateOutcome>);
						num = (_003C_003E1__state = -1);
						goto IL_020f;
					case 3:
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_02b5;
					case 4:
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0350;
						}
						IL_020f:
						_003C_003Es__4 = awaiter3.GetResult();
						_003Coutcome_003E5__1 = _003C_003Es__4;
						if (_003Coutcome_003E5__1 == BatchUpdateOutcome.Success)
						{
							awaiter2 = _003C_003E4__this.CS_0024_003C_003E8__locals1._003C_003E4__this.RemovePendingUpdateAsync(_003C_003E4__this.pendingUpdate.Id).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
							{
								num = (_003C_003E1__state = 3);
								_003C_003Eu__1 = awaiter2;
								_003C_003CQueueUpdate_003Eb__1_003Ed _003C_003CQueueUpdate_003Eb__1_003Ed = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003C_003CQueueUpdate_003Eb__1_003Ed>(ref awaiter2, ref _003C_003CQueueUpdate_003Eb__1_003Ed);
								return;
							}
							goto IL_02b5;
						}
						if (_003Coutcome_003E5__1 == BatchUpdateOutcome.PermanentFailure)
						{
							awaiter = _003C_003E4__this.CS_0024_003C_003E8__locals1._003C_003E4__this.MarkUpdateAsFailedAsync(_003C_003E4__this.pendingUpdate.Id).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 4);
								_003C_003Eu__1 = awaiter;
								_003C_003CQueueUpdate_003Eb__1_003Ed _003C_003CQueueUpdate_003Eb__1_003Ed = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003C_003CQueueUpdate_003Eb__1_003Ed>(ref awaiter, ref _003C_003CQueueUpdate_003Eb__1_003Ed);
								return;
							}
							goto IL_0350;
						}
						_003C_003E4__this.CS_0024_003C_003E8__locals1._003C_003E4__this._memoryQueue.Enqueue(_003C_003E4__this.pendingUpdate);
						_003C_003E4__this.CS_0024_003C_003E8__locals1._003C_003E4__this.PendingUpdatesChanged?.Invoke((object)_003C_003E4__this.CS_0024_003C_003E8__locals1._003C_003E4__this, _003C_003E4__this.CS_0024_003C_003E8__locals1._003C_003E4__this._memoryQueue.Count);
						break;
						IL_02b5:
						((TaskAwaiter)(ref awaiter2)).GetResult();
						break;
						IL_0192:
						((TaskAwaiter)(ref awaiter4)).GetResult();
						awaiter3 = _003C_003E4__this.CS_0024_003C_003E8__locals1._003C_003E4__this.ExecuteBatchUpdateWithRetryAsync(_003C_003E4__this.capturedUpdate).GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__2 = awaiter3;
							_003C_003CQueueUpdate_003Eb__1_003Ed _003C_003CQueueUpdate_003Eb__1_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<BatchUpdateOutcome>, _003C_003CQueueUpdate_003Eb__1_003Ed>(ref awaiter3, ref _003C_003CQueueUpdate_003Eb__1_003Ed);
							return;
						}
						goto IL_020f;
						IL_0350:
						((TaskAwaiter)(ref awaiter)).GetResult();
						_003C_003E4__this.CS_0024_003C_003E8__locals1._003C_003E4__this.ReconciliationRequired?.Invoke((object)_003C_003E4__this.CS_0024_003C_003E8__locals1._003C_003E4__this, _003C_003E4__this.capturedUpdate.PlayerId);
						break;
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

		public List<string> capturedAbsorbedIds;

		public PendingUpdate pendingUpdate;

		public PlayerBatchUpdate capturedUpdate;

		public _003C_003Ec__DisplayClass34_0 CS_0024_003C_003E8__locals1;

		[AsyncStateMachine(typeof(_003C_003CQueueUpdate_003Eb__1_003Ed))]
		[DebuggerStepThrough]
		internal global::System.Threading.Tasks.Task? _003CQueueUpdate_003Eb__1()
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003CQueueUpdate_003Eb__1_003Ed _003C_003CQueueUpdate_003Eb__1_003Ed = new _003C_003CQueueUpdate_003Eb__1_003Ed
			{
				_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
				_003C_003E4__this = this,
				_003C_003E1__state = -1
			};
			((AsyncTaskMethodBuilder)(ref _003C_003CQueueUpdate_003Eb__1_003Ed._003C_003Et__builder)).Start<_003C_003CQueueUpdate_003Eb__1_003Ed>(ref _003C_003CQueueUpdate_003Eb__1_003Ed);
			return ((AsyncTaskMethodBuilder)(ref _003C_003CQueueUpdate_003Eb__1_003Ed._003C_003Et__builder)).Task;
		}
	}

	[CompilerGenerated]
	private sealed class _003CExecuteBatchUpdateWithRetryAsync_003Ed__39 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<BatchUpdateOutcome> _003C_003Et__builder;

		public PlayerBatchUpdate update;

		public PersistentBatchQueueService _003C_003E4__this;

		private BatchUpdateOutcome _003C_003Es__1;

		private global::System.Exception _003Cex_003E5__2;

		private TaskAwaiter<BatchUpdateOutcome> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			BatchUpdateOutcome result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<BatchUpdateOutcome> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this._playerRepository.BatchUpdatePlayerAsync(update).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CExecuteBatchUpdateWithRetryAsync_003Ed__39 _003CExecuteBatchUpdateWithRetryAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<BatchUpdateOutcome>, _003CExecuteBatchUpdateWithRetryAsync_003Ed__39>(ref awaiter, ref _003CExecuteBatchUpdateWithRetryAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<BatchUpdateOutcome>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__1 = awaiter.GetResult();
					result = _003C_003Es__1;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__2 = ex;
					Console.WriteLine("Error executing batch update: " + _003Cex_003E5__2.Message);
					result = BatchUpdateOutcome.TransientFailure;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CFlushOnlineActionAsync_003Ed__36 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public PersistentBatchQueueService _003C_003E4__this;

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
					awaiter = _003C_003E4__this.FlushQueueAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CFlushOnlineActionAsync_003Ed__36 _003CFlushOnlineActionAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CFlushOnlineActionAsync_003Ed__36>(ref awaiter, ref _003CFlushOnlineActionAsync_003Ed__);
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
	private sealed class _003CFlushQueueAsync_003Ed__37 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public PersistentBatchQueueService _003C_003E4__this;

		private string _003CreconcilePlayerId_003E5__1;

		private bool _003C_003Es__2;

		private bool _003C_003Es__3;

		private bool _003C_003Es__4;

		private int _003CprocessedCount_003E5__5;

		private int _003CbatchSize_003E5__6;

		private List<PendingUpdate> _003Cbatch_003E5__7;

		private int _003Ci_003E5__8;

		private PendingUpdate _003Cupdate_003E5__9;

		private string _003C_003Es__10;

		private string _003C_003Es__11;

		private string _003C_003Es__12;

		private global::System.Exception _003Cex_003E5__13;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private TaskAwaiter<string?> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_0256: Unknown result type (might be due to invalid IL or missing references)
			//IL_025b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0263: Unknown result type (might be due to invalid IL or missing references)
			//IL_011a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0120: Invalid comparison between Unknown and I4
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_021d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0222: Unknown result type (might be due to invalid IL or missing references)
			//IL_0237: Unknown result type (might be due to invalid IL or missing references)
			//IL_0239: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter<bool> awaiter;
				if (num != 0)
				{
					if (num == 1)
					{
						goto IL_00f1;
					}
					_003C_003Es__2 = !_003C_003E4__this._initialized || _003C_003E4__this._memoryQueue.IsEmpty;
					_003C_003Es__3 = _003C_003Es__2;
					if (_003C_003Es__3)
					{
						goto IL_00da;
					}
					awaiter = _003C_003E4__this._flushSemaphore.WaitAsync(100).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CFlushQueueAsync_003Ed__37 _003CFlushQueueAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CFlushQueueAsync_003Ed__37>(ref awaiter, ref _003CFlushQueueAsync_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
				}
				_003C_003Es__4 = awaiter.GetResult();
				_003C_003Es__3 = !_003C_003Es__4;
				goto IL_00da;
				IL_00f1:
				try
				{
					TaskAwaiter<string> awaiter2;
					if (num == 1)
					{
						awaiter2 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<string>);
						num = (_003C_003E1__state = -1);
						goto IL_0272;
					}
					_003C_003E4__this.UpdateSyncStatus(SyncStatus.Syncing);
					if ((int)_003C_003E4__this._connectivity.NetworkAccess == 4)
					{
						_003CprocessedCount_003E5__5 = 0;
						_003CbatchSize_003E5__6 = 10;
						goto IL_02bb;
					}
					_003C_003E4__this.UpdateSyncStatus(SyncStatus.Offline);
					goto end_IL_0007;
					IL_029d:
					_ = _003C_003Es__11;
					_003C_003Es__10 = null;
					_003C_003Es__11 = null;
					goto IL_02b3;
					IL_02b3:
					_003Cbatch_003E5__7 = null;
					goto IL_02bb;
					IL_0272:
					_003C_003Es__12 = awaiter2.GetResult();
					_003C_003Es__11 = (_003CreconcilePlayerId_003E5__1 = _003C_003Es__12);
					_003C_003Es__12 = null;
					goto IL_029d;
					IL_02bb:
					if (!_003C_003E4__this._memoryQueue.IsEmpty && _003CprocessedCount_003E5__5 < _003CbatchSize_003E5__6)
					{
						_003Cbatch_003E5__7 = new List<PendingUpdate>();
						_003Ci_003E5__8 = 0;
						while (_003Ci_003E5__8 < _003CbatchSize_003E5__6 && _003C_003E4__this._memoryQueue.TryDequeue(ref _003Cupdate_003E5__9))
						{
							_003Cbatch_003E5__7.Add(_003Cupdate_003E5__9);
							_003CprocessedCount_003E5__5++;
							_003Ci_003E5__8++;
						}
						if (_003Cbatch_003E5__7.Count > 0)
						{
							_003C_003Es__10 = _003CreconcilePlayerId_003E5__1;
							_003C_003Es__11 = _003C_003Es__10;
							if (_003C_003Es__11 == null)
							{
								awaiter2 = _003C_003E4__this.ProcessBatchAsync(_003Cbatch_003E5__7).GetAwaiter();
								if (!awaiter2.IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__2 = awaiter2;
									_003CFlushQueueAsync_003Ed__37 _003CFlushQueueAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<string>, _003CFlushQueueAsync_003Ed__37>(ref awaiter2, ref _003CFlushQueueAsync_003Ed__);
									return;
								}
								goto IL_0272;
							}
							goto IL_029d;
						}
						goto IL_02b3;
					}
					_003C_003E4__this.PendingUpdatesChanged?.Invoke((object)_003C_003E4__this, _003C_003E4__this._memoryQueue.Count);
					_003C_003E4__this.UpdateSyncStatus();
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__13 = ex;
					Console.WriteLine("Failed to flush batch queue: " + _003Cex_003E5__13.Message);
					_003C_003E4__this.UpdateSyncStatus(SyncStatus.Failed);
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this._flushSemaphore.Release();
					}
				}
				if (_003CreconcilePlayerId_003E5__1 != null)
				{
					_003C_003E4__this.ReconciliationRequired?.Invoke((object)_003C_003E4__this, _003CreconcilePlayerId_003E5__1);
				}
				goto end_IL_0007;
				IL_00da:
				if (!_003C_003Es__3)
				{
					_003CreconcilePlayerId_003E5__1 = null;
					goto IL_00f1;
				}
				end_IL_0007:;
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003CreconcilePlayerId_003E5__1 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003CreconcilePlayerId_003E5__1 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CInitializeAsync_003Ed__32 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public PersistentBatchQueueService _003C_003E4__this;

		private global::System.Exception _003Cex_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 1u || !_003C_003E4__this._initialized)
				{
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
								goto IL_00fd;
							}
							awaiter2 = _003C_003E4__this.InitializeDatabaseAsync().GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter2;
								_003CInitializeAsync_003Ed__32 _003CInitializeAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CInitializeAsync_003Ed__32>(ref awaiter2, ref _003CInitializeAsync_003Ed__);
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
						awaiter = _003C_003E4__this.LoadPendingUpdatesAsync().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter;
							_003CInitializeAsync_003Ed__32 _003CInitializeAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CInitializeAsync_003Ed__32>(ref awaiter, ref _003CInitializeAsync_003Ed__);
							return;
						}
						goto IL_00fd;
						IL_00fd:
						((TaskAwaiter)(ref awaiter)).GetResult();
						_003C_003E4__this._flushTimer.Start();
						_003C_003E4__this._initialized = true;
						_003C_003E4__this._initTcs.TrySetResult();
						Console.WriteLine($"BatchQueue initialized. Found {_003C_003E4__this._memoryQueue.Count} pending updates.");
						_003C_003E4__this.UpdateSyncStatus();
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__1 = ex;
						Console.WriteLine("Failed to initialize batch queue: " + _003Cex_003E5__1.Message);
						throw;
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
	private sealed class _003CInitializeDatabaseAsync_003Ed__42 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public PersistentBatchQueueService _003C_003E4__this;

		private SqliteConnection _003Cconnection_003E5__1;

		private SqliteCommand _003CcreateTableCommand_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<int> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Expected O, but got Unknown
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_015a: Unknown result type (might be due to invalid IL or missing references)
			//IL_016f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0171: Unknown result type (might be due to invalid IL or missing references)
			//IL_018e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0193: Unknown result type (might be due to invalid IL or missing references)
			//IL_019b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					if ((uint)(num - 1) <= 1u)
					{
						goto IL_0084;
					}
					awaiter = _003C_003E4__this._dbSemaphore.WaitAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CInitializeDatabaseAsync_003Ed__42 _003CInitializeDatabaseAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CInitializeDatabaseAsync_003Ed__42>(ref awaiter, ref _003CInitializeDatabaseAsync_003Ed__);
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
				goto IL_0084;
				IL_0084:
				try
				{
					if ((uint)(num - 1) > 1u)
					{
						_003Cconnection_003E5__1 = new SqliteConnection("Data Source=" + _003C_003E4__this._dbPath);
					}
					try
					{
						TaskAwaiter<int> awaiter2;
						TaskAwaiter awaiter3;
						if (num != 1)
						{
							if (num == 2)
							{
								awaiter2 = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter<int>);
								num = (_003C_003E1__state = -1);
								goto IL_01aa;
							}
							awaiter3 = ((DbConnection)_003Cconnection_003E5__1).OpenAsync().GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__1 = awaiter3;
								_003CInitializeDatabaseAsync_003Ed__42 _003CInitializeDatabaseAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CInitializeDatabaseAsync_003Ed__42>(ref awaiter3, ref _003CInitializeDatabaseAsync_003Ed__);
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
						_003CcreateTableCommand_003E5__2 = _003Cconnection_003E5__1.CreateCommand();
						((DbCommand)_003CcreateTableCommand_003E5__2).CommandText = "\r\n                CREATE TABLE IF NOT EXISTS PendingUpdates (\r\n                    Id TEXT PRIMARY KEY,\r\n                    PlayerBatchUpdateJson TEXT NOT NULL,\r\n                    CreatedAt TEXT NOT NULL,\r\n                    RetryCount INTEGER NOT NULL DEFAULT 0,\r\n                    Failed INTEGER NOT NULL DEFAULT 0\r\n                )";
						awaiter2 = ((DbCommand)_003CcreateTableCommand_003E5__2).ExecuteNonQueryAsync().GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__2 = awaiter2;
							_003CInitializeDatabaseAsync_003Ed__42 _003CInitializeDatabaseAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<int>, _003CInitializeDatabaseAsync_003Ed__42>(ref awaiter2, ref _003CInitializeDatabaseAsync_003Ed__);
							return;
						}
						goto IL_01aa;
						IL_01aa:
						awaiter2.GetResult();
					}
					finally
					{
						if (num < 0 && _003Cconnection_003E5__1 != null)
						{
							((global::System.IDisposable)_003Cconnection_003E5__1).Dispose();
						}
					}
					_003Cconnection_003E5__1 = null;
					_003CcreateTableCommand_003E5__2 = null;
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this._dbSemaphore.Release();
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
	private sealed class _003CLoadPendingUpdatesAsync_003Ed__43 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public PersistentBatchQueueService _003C_003E4__this;

		private SqliteConnection _003Cconnection_003E5__1;

		private SqliteCommand _003Ccommand_003E5__2;

		private SqliteDataReader _003Creader_003E5__3;

		private SqliteDataReader _003C_003Es__4;

		private PendingUpdate _003CpendingUpdate_003E5__5;

		private global::System.Exception _003Cex_003E5__6;

		private bool _003C_003Es__7;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<SqliteDataReader> _003C_003Eu__2;

		private TaskAwaiter<bool> _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Expected O, but got Unknown
			//IL_0114: Unknown result type (might be due to invalid IL or missing references)
			//IL_0119: Unknown result type (might be due to invalid IL or missing references)
			//IL_0120: Unknown result type (might be due to invalid IL or missing references)
			//IL_019d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0164: Unknown result type (might be due to invalid IL or missing references)
			//IL_0169: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_017e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0180: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02fa: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					if ((uint)(num - 1) <= 2u)
					{
						goto IL_0084;
					}
					awaiter = _003C_003E4__this._dbSemaphore.WaitAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CLoadPendingUpdatesAsync_003Ed__43 _003CLoadPendingUpdatesAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadPendingUpdatesAsync_003Ed__43>(ref awaiter, ref _003CLoadPendingUpdatesAsync_003Ed__);
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
				goto IL_0084;
				IL_0084:
				try
				{
					if ((uint)(num - 1) > 2u)
					{
						_003Cconnection_003E5__1 = new SqliteConnection("Data Source=" + _003C_003E4__this._dbPath);
					}
					try
					{
						TaskAwaiter awaiter3;
						TaskAwaiter<SqliteDataReader> awaiter2;
						switch (num)
						{
						default:
							awaiter3 = ((DbConnection)_003Cconnection_003E5__1).OpenAsync().GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__1 = awaiter3;
								_003CLoadPendingUpdatesAsync_003Ed__43 _003CLoadPendingUpdatesAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadPendingUpdatesAsync_003Ed__43>(ref awaiter3, ref _003CLoadPendingUpdatesAsync_003Ed__);
								return;
							}
							goto IL_012f;
						case 1:
							awaiter3 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_012f;
						case 2:
							awaiter2 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<SqliteDataReader>);
							num = (_003C_003E1__state = -1);
							goto IL_01b9;
						case 3:
							break;
							IL_01b9:
							_003C_003Es__4 = awaiter2.GetResult();
							_003Creader_003E5__3 = _003C_003Es__4;
							_003C_003Es__4 = null;
							break;
							IL_012f:
							((TaskAwaiter)(ref awaiter3)).GetResult();
							_003Ccommand_003E5__2 = _003Cconnection_003E5__1.CreateCommand();
							((DbCommand)_003Ccommand_003E5__2).CommandText = "SELECT Id, PlayerBatchUpdateJson, CreatedAt, RetryCount FROM PendingUpdates WHERE Failed = 0 ORDER BY CreatedAt";
							awaiter2 = _003Ccommand_003E5__2.ExecuteReaderAsync().GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__2 = awaiter2;
								_003CLoadPendingUpdatesAsync_003Ed__43 _003CLoadPendingUpdatesAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<SqliteDataReader>, _003CLoadPendingUpdatesAsync_003Ed__43>(ref awaiter2, ref _003CLoadPendingUpdatesAsync_003Ed__);
								return;
							}
							goto IL_01b9;
						}
						try
						{
							if (num != 3)
							{
								goto IL_02a9;
							}
							TaskAwaiter<bool> awaiter4 = _003C_003Eu__3;
							_003C_003Eu__3 = default(TaskAwaiter<bool>);
							num = (_003C_003E1__state = -1);
							goto IL_0309;
							IL_0309:
							_003C_003Es__7 = awaiter4.GetResult();
							if (_003C_003Es__7)
							{
								try
								{
									_003CpendingUpdate_003E5__5 = new PendingUpdate
									{
										Id = DataReaderExtensions.GetString((DbDataReader)(object)_003Creader_003E5__3, "Id"),
										PlayerBatchUpdate = JsonSerializer.Deserialize<PlayerBatchUpdate>(DataReaderExtensions.GetString((DbDataReader)(object)_003Creader_003E5__3, "PlayerBatchUpdateJson"), (JsonSerializerOptions)null),
										CreatedAt = global::System.DateTime.Parse(DataReaderExtensions.GetString((DbDataReader)(object)_003Creader_003E5__3, "CreatedAt")),
										RetryCount = DataReaderExtensions.GetInt32((DbDataReader)(object)_003Creader_003E5__3, "RetryCount")
									};
									_003C_003E4__this._memoryQueue.Enqueue(_003CpendingUpdate_003E5__5);
									_003CpendingUpdate_003E5__5 = null;
								}
								catch (global::System.Exception ex)
								{
									_003Cex_003E5__6 = ex;
									Console.WriteLine("Failed to deserialize pending update: " + _003Cex_003E5__6.Message);
								}
								goto IL_02a9;
							}
							goto end_IL_01da;
							IL_02a9:
							awaiter4 = ((DbDataReader)_003Creader_003E5__3).ReadAsync().GetAwaiter();
							if (!awaiter4.IsCompleted)
							{
								num = (_003C_003E1__state = 3);
								_003C_003Eu__3 = awaiter4;
								_003CLoadPendingUpdatesAsync_003Ed__43 _003CLoadPendingUpdatesAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CLoadPendingUpdatesAsync_003Ed__43>(ref awaiter4, ref _003CLoadPendingUpdatesAsync_003Ed__);
								return;
							}
							goto IL_0309;
							end_IL_01da:;
						}
						finally
						{
							if (num < 0 && _003Creader_003E5__3 != null)
							{
								((global::System.IDisposable)_003Creader_003E5__3).Dispose();
							}
						}
					}
					finally
					{
						if (num < 0 && _003Cconnection_003E5__1 != null)
						{
							((global::System.IDisposable)_003Cconnection_003E5__1).Dispose();
						}
					}
					_003Cconnection_003E5__1 = null;
					_003Ccommand_003E5__2 = null;
					_003Creader_003E5__3 = null;
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this._dbSemaphore.Release();
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
	private sealed class _003CMarkUpdateAsFailedAsync_003Ed__47 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string id;

		public PersistentBatchQueueService _003C_003E4__this;

		private SqliteConnection _003Cconnection_003E5__1;

		private SqliteCommand _003Ccommand_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<int> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Expected O, but got Unknown
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0171: Unknown result type (might be due to invalid IL or missing references)
			//IL_0176: Unknown result type (might be due to invalid IL or missing references)
			//IL_018b: Unknown result type (might be due to invalid IL or missing references)
			//IL_018d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_01af: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					if ((uint)(num - 1) <= 1u)
					{
						goto IL_0084;
					}
					awaiter = _003C_003E4__this._dbSemaphore.WaitAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CMarkUpdateAsFailedAsync_003Ed__47 _003CMarkUpdateAsFailedAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CMarkUpdateAsFailedAsync_003Ed__47>(ref awaiter, ref _003CMarkUpdateAsFailedAsync_003Ed__);
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
				goto IL_0084;
				IL_0084:
				try
				{
					if ((uint)(num - 1) > 1u)
					{
						_003Cconnection_003E5__1 = new SqliteConnection("Data Source=" + _003C_003E4__this._dbPath);
					}
					try
					{
						TaskAwaiter<int> awaiter2;
						TaskAwaiter awaiter3;
						if (num != 1)
						{
							if (num == 2)
							{
								awaiter2 = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter<int>);
								num = (_003C_003E1__state = -1);
								goto IL_01c6;
							}
							awaiter3 = ((DbConnection)_003Cconnection_003E5__1).OpenAsync().GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__1 = awaiter3;
								_003CMarkUpdateAsFailedAsync_003Ed__47 _003CMarkUpdateAsFailedAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CMarkUpdateAsFailedAsync_003Ed__47>(ref awaiter3, ref _003CMarkUpdateAsFailedAsync_003Ed__);
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
						_003Ccommand_003E5__2 = _003Cconnection_003E5__1.CreateCommand();
						((DbCommand)_003Ccommand_003E5__2).CommandText = "UPDATE PendingUpdates SET Failed = 1 WHERE Id = $id";
						_003Ccommand_003E5__2.Parameters.AddWithValue("$id", (object)id);
						awaiter2 = ((DbCommand)_003Ccommand_003E5__2).ExecuteNonQueryAsync().GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__2 = awaiter2;
							_003CMarkUpdateAsFailedAsync_003Ed__47 _003CMarkUpdateAsFailedAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<int>, _003CMarkUpdateAsFailedAsync_003Ed__47>(ref awaiter2, ref _003CMarkUpdateAsFailedAsync_003Ed__);
							return;
						}
						goto IL_01c6;
						IL_01c6:
						awaiter2.GetResult();
					}
					finally
					{
						if (num < 0 && _003Cconnection_003E5__1 != null)
						{
							((global::System.IDisposable)_003Cconnection_003E5__1).Dispose();
						}
					}
					_003Cconnection_003E5__1 = null;
					_003Ccommand_003E5__2 = null;
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this._dbSemaphore.Release();
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
	private sealed class _003CProcessBatchAsync_003Ed__38 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

		public List<PendingUpdate> batch;

		public PersistentBatchQueueService _003C_003E4__this;

		private string _003CreconcilePlayerId_003E5__1;

		private global::System.Collections.Generic.IEnumerable<IGrouping<string, PendingUpdate>> _003CplayerGroups_003E5__2;

		private global::System.Collections.Generic.IEnumerator<IGrouping<string, PendingUpdate>> _003C_003Es__3;

		private IGrouping<string, PendingUpdate> _003CplayerGroup_003E5__4;

		private PlayerBatchUpdate _003CmergedUpdate_003E5__5;

		private List<PendingUpdate> _003CpendingUpdates_003E5__6;

		private BatchUpdateOutcome _003Coutcome_003E5__7;

		private BatchUpdateOutcome _003C_003Es__8;

		private Enumerator<PendingUpdate> _003C_003Es__9;

		private PendingUpdate _003Cupdate_003E5__10;

		private Enumerator<PendingUpdate> _003C_003Es__11;

		private PendingUpdate _003Cupdate_003E5__12;

		private Enumerator<PendingUpdate> _003C_003Es__13;

		private PendingUpdate _003Cupdate_003E5__14;

		private TaskAwaiter<BatchUpdateOutcome> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_013a: Unknown result type (might be due to invalid IL or missing references)
			//IL_013f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0146: Unknown result type (might be due to invalid IL or missing references)
			//IL_0189: Unknown result type (might be due to invalid IL or missing references)
			//IL_018e: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_0282: Unknown result type (might be due to invalid IL or missing references)
			//IL_0287: Unknown result type (might be due to invalid IL or missing references)
			//IL_0201: Unknown result type (might be due to invalid IL or missing references)
			//IL_0206: Unknown result type (might be due to invalid IL or missing references)
			//IL_020e: Unknown result type (might be due to invalid IL or missing references)
			//IL_031e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0323: Unknown result type (might be due to invalid IL or missing references)
			//IL_032b: Unknown result type (might be due to invalid IL or missing references)
			//IL_048a: Unknown result type (might be due to invalid IL or missing references)
			//IL_048f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0497: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Unknown result type (might be due to invalid IL or missing references)
			//IL_0108: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Unknown result type (might be due to invalid IL or missing references)
			//IL_011d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_0568: Unknown result type (might be due to invalid IL or missing references)
			//IL_056d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0575: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_025b: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0301: Unknown result type (might be due to invalid IL or missing references)
			//IL_0379: Unknown result type (might be due to invalid IL or missing references)
			//IL_052f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0534: Unknown result type (might be due to invalid IL or missing references)
			//IL_0451: Unknown result type (might be due to invalid IL or missing references)
			//IL_0456: Unknown result type (might be due to invalid IL or missing references)
			//IL_05c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0549: Unknown result type (might be due to invalid IL or missing references)
			//IL_054b: Unknown result type (might be due to invalid IL or missing references)
			//IL_046b: Unknown result type (might be due to invalid IL or missing references)
			//IL_046d: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			string result;
			try
			{
				if ((uint)num > 4u)
				{
					_003CreconcilePlayerId_003E5__1 = null;
					_003CplayerGroups_003E5__2 = Enumerable.GroupBy<PendingUpdate, string>((global::System.Collections.Generic.IEnumerable<PendingUpdate>)batch, (Func<PendingUpdate, string>)((PendingUpdate u) => u.PlayerBatchUpdate.PlayerId));
					_003C_003Es__3 = _003CplayerGroups_003E5__2.GetEnumerator();
				}
				try
				{
					TaskAwaiter<BatchUpdateOutcome> awaiter;
					switch (num)
					{
					case 0:
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<BatchUpdateOutcome>);
						num = (_003C_003E1__state = -1);
						goto IL_0155;
					case 1:
						try
						{
							if (num != 1)
							{
								goto IL_022c;
							}
							TaskAwaiter awaiter3 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_021d;
							IL_021d:
							((TaskAwaiter)(ref awaiter3)).GetResult();
							_003Cupdate_003E5__10 = null;
							goto IL_022c;
							IL_022c:
							if (_003C_003Es__9.MoveNext())
							{
								_003Cupdate_003E5__10 = _003C_003Es__9.Current;
								awaiter3 = _003C_003E4__this.RemovePendingUpdateAsync(_003Cupdate_003E5__10.Id).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__2 = awaiter3;
									_003CProcessBatchAsync_003Ed__38 _003CProcessBatchAsync_003Ed__ = this;
									_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CProcessBatchAsync_003Ed__38>(ref awaiter3, ref _003CProcessBatchAsync_003Ed__);
									return;
								}
								goto IL_021d;
							}
						}
						finally
						{
							if (num < 0)
							{
								((global::System.IDisposable)_003C_003Es__9).Dispose();
							}
						}
						_003C_003Es__9 = default(Enumerator<PendingUpdate>);
						goto IL_05cb;
					case 2:
						try
						{
							if (num != 2)
							{
								goto IL_034a;
							}
							TaskAwaiter awaiter2 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_033a;
							IL_033a:
							((TaskAwaiter)(ref awaiter2)).GetResult();
							_003Cupdate_003E5__12 = null;
							goto IL_034a;
							IL_034a:
							if (_003C_003Es__11.MoveNext())
							{
								_003Cupdate_003E5__12 = _003C_003Es__11.Current;
								Console.WriteLine("Update " + _003Cupdate_003E5__12.Id + " permanently rejected. Marking failed.");
								awaiter2 = _003C_003E4__this.MarkUpdateAsFailedAsync(_003Cupdate_003E5__12.Id).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
								{
									num = (_003C_003E1__state = 2);
									_003C_003Eu__2 = awaiter2;
									_003CProcessBatchAsync_003Ed__38 _003CProcessBatchAsync_003Ed__ = this;
									_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CProcessBatchAsync_003Ed__38>(ref awaiter2, ref _003CProcessBatchAsync_003Ed__);
									return;
								}
								goto IL_033a;
							}
						}
						finally
						{
							if (num < 0)
							{
								((global::System.IDisposable)_003C_003Es__11).Dispose();
							}
						}
						_003C_003Es__11 = default(Enumerator<PendingUpdate>);
						if (_003CreconcilePlayerId_003E5__1 == null)
						{
							_003CreconcilePlayerId_003E5__1 = _003CmergedUpdate_003E5__5.PlayerId;
						}
						goto IL_05cb;
					case 3:
					case 4:
						try
						{
							TaskAwaiter awaiter4;
							if (num != 3)
							{
								if (num != 4)
								{
									goto IL_0595;
								}
								awaiter4 = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_0584;
							}
							TaskAwaiter awaiter5 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_04a6;
							IL_04a6:
							((TaskAwaiter)(ref awaiter5)).GetResult();
							goto IL_058d;
							IL_058d:
							_003Cupdate_003E5__14 = null;
							goto IL_0595;
							IL_0584:
							((TaskAwaiter)(ref awaiter4)).GetResult();
							goto IL_058d;
							IL_0595:
							if (_003C_003Es__13.MoveNext())
							{
								_003Cupdate_003E5__14 = _003C_003Es__13.Current;
								_003Cupdate_003E5__14.RetryCount++;
								if (_003Cupdate_003E5__14.RetryCount < _003C_003E4__this._maxRetries)
								{
									_003C_003E4__this._memoryQueue.Enqueue(_003Cupdate_003E5__14);
									awaiter5 = _003C_003E4__this.UpdatePendingUpdateRetryCountAsync(_003Cupdate_003E5__14.Id, _003Cupdate_003E5__14.RetryCount).GetAwaiter();
									if (!((TaskAwaiter)(ref awaiter5)).IsCompleted)
									{
										num = (_003C_003E1__state = 3);
										_003C_003Eu__2 = awaiter5;
										_003CProcessBatchAsync_003Ed__38 _003CProcessBatchAsync_003Ed__ = this;
										_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CProcessBatchAsync_003Ed__38>(ref awaiter5, ref _003CProcessBatchAsync_003Ed__);
										return;
									}
									goto IL_04a6;
								}
								Console.WriteLine($"Update {_003Cupdate_003E5__14.Id} failed after {_003C_003E4__this._maxRetries} retries. Giving up.");
								awaiter4 = _003C_003E4__this.MarkUpdateAsFailedAsync(_003Cupdate_003E5__14.Id).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
								{
									num = (_003C_003E1__state = 4);
									_003C_003Eu__2 = awaiter4;
									_003CProcessBatchAsync_003Ed__38 _003CProcessBatchAsync_003Ed__ = this;
									_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CProcessBatchAsync_003Ed__38>(ref awaiter4, ref _003CProcessBatchAsync_003Ed__);
									return;
								}
								goto IL_0584;
							}
						}
						finally
						{
							if (num < 0)
							{
								((global::System.IDisposable)_003C_003Es__13).Dispose();
							}
						}
						_003C_003Es__13 = default(Enumerator<PendingUpdate>);
						goto IL_05cb;
					default:
						{
							if (((global::System.Collections.IEnumerator)_003C_003Es__3).MoveNext())
							{
								_003CplayerGroup_003E5__4 = _003C_003Es__3.Current;
								_003CmergedUpdate_003E5__5 = _003C_003E4__this._merger.Merge(Enumerable.Select<PendingUpdate, PlayerBatchUpdate>((global::System.Collections.Generic.IEnumerable<PendingUpdate>)_003CplayerGroup_003E5__4, (Func<PendingUpdate, PlayerBatchUpdate>)((PendingUpdate p) => p.PlayerBatchUpdate)));
								_003CpendingUpdates_003E5__6 = Enumerable.ToList<PendingUpdate>((global::System.Collections.Generic.IEnumerable<PendingUpdate>)_003CplayerGroup_003E5__4);
								awaiter = _003C_003E4__this.ExecuteBatchUpdateWithRetryAsync(_003CmergedUpdate_003E5__5).GetAwaiter();
								if (!awaiter.IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter;
									_003CProcessBatchAsync_003Ed__38 _003CProcessBatchAsync_003Ed__ = this;
									_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<BatchUpdateOutcome>, _003CProcessBatchAsync_003Ed__38>(ref awaiter, ref _003CProcessBatchAsync_003Ed__);
									return;
								}
								goto IL_0155;
							}
							break;
						}
						IL_0155:
						_003C_003Es__8 = awaiter.GetResult();
						_003Coutcome_003E5__7 = _003C_003Es__8;
						if (_003Coutcome_003E5__7 == BatchUpdateOutcome.Success)
						{
							_003C_003Es__9 = _003CpendingUpdates_003E5__6.GetEnumerator();
							goto case 1;
						}
						if (_003Coutcome_003E5__7 == BatchUpdateOutcome.PermanentFailure)
						{
							_003C_003Es__11 = _003CpendingUpdates_003E5__6.GetEnumerator();
							goto case 2;
						}
						_003C_003Es__13 = _003CpendingUpdates_003E5__6.GetEnumerator();
						goto case 3;
						IL_05cb:
						_003CmergedUpdate_003E5__5 = null;
						_003CpendingUpdates_003E5__6 = null;
						_003CplayerGroup_003E5__4 = null;
						goto default;
					}
				}
				finally
				{
					if (num < 0 && _003C_003Es__3 != null)
					{
						((global::System.IDisposable)_003C_003Es__3).Dispose();
					}
				}
				_003C_003Es__3 = null;
				result = _003CreconcilePlayerId_003E5__1;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003CreconcilePlayerId_003E5__1 = null;
				_003CplayerGroups_003E5__2 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CreconcilePlayerId_003E5__1 = null;
			_003CplayerGroups_003E5__2 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CQueueUpdateInternal_003Ed__35 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public PlayerBatchUpdate update;

		public PersistentBatchQueueService _003C_003E4__this;

		private PendingUpdate _003CpendingUpdate_003E5__1;

		private int _003CqueueSize_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					PendingUpdate pendingUpdate = new PendingUpdate();
					Guid val = Guid.NewGuid();
					pendingUpdate.Id = ((object)(Guid)(ref val)).ToString();
					pendingUpdate.PlayerBatchUpdate = update;
					pendingUpdate.CreatedAt = global::System.DateTime.UtcNow;
					pendingUpdate.RetryCount = 0;
					_003CpendingUpdate_003E5__1 = pendingUpdate;
					awaiter = _003C_003E4__this.StorePendingUpdateAsync(_003CpendingUpdate_003E5__1).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CQueueUpdateInternal_003Ed__35 _003CQueueUpdateInternal_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CQueueUpdateInternal_003Ed__35>(ref awaiter, ref _003CQueueUpdateInternal_003Ed__);
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
				_003C_003E4__this._memoryQueue.Enqueue(_003CpendingUpdate_003E5__1);
				_003CqueueSize_003E5__2 = _003C_003E4__this._memoryQueue.Count;
				_003C_003E4__this.PendingUpdatesChanged?.Invoke((object)_003C_003E4__this, _003CqueueSize_003E5__2);
				_003C_003E4__this.UpdateSyncStatus();
				if (_003CqueueSize_003E5__2 >= _003C_003E4__this._maxQueueSize)
				{
					PersistentBatchQueueService persistentBatchQueueService = _003C_003E4__this;
					global::System.Threading.Tasks.Task.Run((Func<global::System.Threading.Tasks.Task>)persistentBatchQueueService.FlushQueueAsync);
				}
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003CpendingUpdate_003E5__1 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CpendingUpdate_003E5__1 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CRemovePendingUpdateAsync_003Ed__45 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string id;

		public PersistentBatchQueueService _003C_003E4__this;

		private SqliteConnection _003Cconnection_003E5__1;

		private SqliteCommand _003Ccommand_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<int> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Expected O, but got Unknown
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0171: Unknown result type (might be due to invalid IL or missing references)
			//IL_0176: Unknown result type (might be due to invalid IL or missing references)
			//IL_018b: Unknown result type (might be due to invalid IL or missing references)
			//IL_018d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_01af: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					if ((uint)(num - 1) <= 1u)
					{
						goto IL_0084;
					}
					awaiter = _003C_003E4__this._dbSemaphore.WaitAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CRemovePendingUpdateAsync_003Ed__45 _003CRemovePendingUpdateAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRemovePendingUpdateAsync_003Ed__45>(ref awaiter, ref _003CRemovePendingUpdateAsync_003Ed__);
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
				goto IL_0084;
				IL_0084:
				try
				{
					if ((uint)(num - 1) > 1u)
					{
						_003Cconnection_003E5__1 = new SqliteConnection("Data Source=" + _003C_003E4__this._dbPath);
					}
					try
					{
						TaskAwaiter<int> awaiter2;
						TaskAwaiter awaiter3;
						if (num != 1)
						{
							if (num == 2)
							{
								awaiter2 = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter<int>);
								num = (_003C_003E1__state = -1);
								goto IL_01c6;
							}
							awaiter3 = ((DbConnection)_003Cconnection_003E5__1).OpenAsync().GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__1 = awaiter3;
								_003CRemovePendingUpdateAsync_003Ed__45 _003CRemovePendingUpdateAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRemovePendingUpdateAsync_003Ed__45>(ref awaiter3, ref _003CRemovePendingUpdateAsync_003Ed__);
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
						_003Ccommand_003E5__2 = _003Cconnection_003E5__1.CreateCommand();
						((DbCommand)_003Ccommand_003E5__2).CommandText = "DELETE FROM PendingUpdates WHERE Id = $id";
						_003Ccommand_003E5__2.Parameters.AddWithValue("$id", (object)id);
						awaiter2 = ((DbCommand)_003Ccommand_003E5__2).ExecuteNonQueryAsync().GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__2 = awaiter2;
							_003CRemovePendingUpdateAsync_003Ed__45 _003CRemovePendingUpdateAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<int>, _003CRemovePendingUpdateAsync_003Ed__45>(ref awaiter2, ref _003CRemovePendingUpdateAsync_003Ed__);
							return;
						}
						goto IL_01c6;
						IL_01c6:
						awaiter2.GetResult();
					}
					finally
					{
						if (num < 0 && _003Cconnection_003E5__1 != null)
						{
							((global::System.IDisposable)_003Cconnection_003E5__1).Dispose();
						}
					}
					_003Cconnection_003E5__1 = null;
					_003Ccommand_003E5__2 = null;
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this._dbSemaphore.Release();
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
	private sealed class _003CStorePendingUpdateAsync_003Ed__44 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public PendingUpdate update;

		public PersistentBatchQueueService _003C_003E4__this;

		private SqliteConnection _003Cconnection_003E5__1;

		private SqliteCommand _003Ccommand_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<int> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Expected O, but got Unknown
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_020c: Unknown result type (might be due to invalid IL or missing references)
			//IL_020e: Unknown result type (might be due to invalid IL or missing references)
			//IL_022b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0230: Unknown result type (might be due to invalid IL or missing references)
			//IL_0238: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					if ((uint)(num - 1) <= 1u)
					{
						goto IL_0084;
					}
					awaiter = _003C_003E4__this._dbSemaphore.WaitAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CStorePendingUpdateAsync_003Ed__44 _003CStorePendingUpdateAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CStorePendingUpdateAsync_003Ed__44>(ref awaiter, ref _003CStorePendingUpdateAsync_003Ed__);
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
				goto IL_0084;
				IL_0084:
				try
				{
					if ((uint)(num - 1) > 1u)
					{
						_003Cconnection_003E5__1 = new SqliteConnection("Data Source=" + _003C_003E4__this._dbPath);
					}
					try
					{
						TaskAwaiter<int> awaiter2;
						TaskAwaiter awaiter3;
						if (num != 1)
						{
							if (num == 2)
							{
								awaiter2 = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter<int>);
								num = (_003C_003E1__state = -1);
								goto IL_0247;
							}
							awaiter3 = ((DbConnection)_003Cconnection_003E5__1).OpenAsync().GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__1 = awaiter3;
								_003CStorePendingUpdateAsync_003Ed__44 _003CStorePendingUpdateAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CStorePendingUpdateAsync_003Ed__44>(ref awaiter3, ref _003CStorePendingUpdateAsync_003Ed__);
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
						_003Ccommand_003E5__2 = _003Cconnection_003E5__1.CreateCommand();
						((DbCommand)_003Ccommand_003E5__2).CommandText = "\r\n                INSERT INTO PendingUpdates (Id, PlayerBatchUpdateJson, CreatedAt, RetryCount) \r\n                VALUES ($id, $json, $createdAt, $retryCount)";
						_003Ccommand_003E5__2.Parameters.AddWithValue("$id", (object)update.Id);
						_003Ccommand_003E5__2.Parameters.AddWithValue("$json", (object)JsonSerializer.Serialize<PlayerBatchUpdate>(update.PlayerBatchUpdate, (JsonSerializerOptions)null));
						_003Ccommand_003E5__2.Parameters.AddWithValue("$createdAt", (object)update.CreatedAt.ToString("O"));
						_003Ccommand_003E5__2.Parameters.AddWithValue("$retryCount", (object)update.RetryCount);
						awaiter2 = ((DbCommand)_003Ccommand_003E5__2).ExecuteNonQueryAsync().GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__2 = awaiter2;
							_003CStorePendingUpdateAsync_003Ed__44 _003CStorePendingUpdateAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<int>, _003CStorePendingUpdateAsync_003Ed__44>(ref awaiter2, ref _003CStorePendingUpdateAsync_003Ed__);
							return;
						}
						goto IL_0247;
						IL_0247:
						awaiter2.GetResult();
					}
					finally
					{
						if (num < 0 && _003Cconnection_003E5__1 != null)
						{
							((global::System.IDisposable)_003Cconnection_003E5__1).Dispose();
						}
					}
					_003Cconnection_003E5__1 = null;
					_003Ccommand_003E5__2 = null;
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this._dbSemaphore.Release();
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
	private sealed class _003CUpdatePendingUpdateRetryCountAsync_003Ed__46 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string id;

		public int retryCount;

		public PersistentBatchQueueService _003C_003E4__this;

		private SqliteConnection _003Cconnection_003E5__1;

		private SqliteCommand _003Ccommand_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<int> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Expected O, but got Unknown
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0192: Unknown result type (might be due to invalid IL or missing references)
			//IL_0197: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					if ((uint)(num - 1) <= 1u)
					{
						goto IL_0084;
					}
					awaiter = _003C_003E4__this._dbSemaphore.WaitAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CUpdatePendingUpdateRetryCountAsync_003Ed__46 _003CUpdatePendingUpdateRetryCountAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CUpdatePendingUpdateRetryCountAsync_003Ed__46>(ref awaiter, ref _003CUpdatePendingUpdateRetryCountAsync_003Ed__);
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
				goto IL_0084;
				IL_0084:
				try
				{
					if ((uint)(num - 1) > 1u)
					{
						_003Cconnection_003E5__1 = new SqliteConnection("Data Source=" + _003C_003E4__this._dbPath);
					}
					try
					{
						TaskAwaiter<int> awaiter2;
						TaskAwaiter awaiter3;
						if (num != 1)
						{
							if (num == 2)
							{
								awaiter2 = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter<int>);
								num = (_003C_003E1__state = -1);
								goto IL_01e7;
							}
							awaiter3 = ((DbConnection)_003Cconnection_003E5__1).OpenAsync().GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__1 = awaiter3;
								_003CUpdatePendingUpdateRetryCountAsync_003Ed__46 _003CUpdatePendingUpdateRetryCountAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CUpdatePendingUpdateRetryCountAsync_003Ed__46>(ref awaiter3, ref _003CUpdatePendingUpdateRetryCountAsync_003Ed__);
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
						_003Ccommand_003E5__2 = _003Cconnection_003E5__1.CreateCommand();
						((DbCommand)_003Ccommand_003E5__2).CommandText = "UPDATE PendingUpdates SET RetryCount = $retryCount WHERE Id = $id";
						_003Ccommand_003E5__2.Parameters.AddWithValue("$retryCount", (object)retryCount);
						_003Ccommand_003E5__2.Parameters.AddWithValue("$id", (object)id);
						awaiter2 = ((DbCommand)_003Ccommand_003E5__2).ExecuteNonQueryAsync().GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__2 = awaiter2;
							_003CUpdatePendingUpdateRetryCountAsync_003Ed__46 _003CUpdatePendingUpdateRetryCountAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<int>, _003CUpdatePendingUpdateRetryCountAsync_003Ed__46>(ref awaiter2, ref _003CUpdatePendingUpdateRetryCountAsync_003Ed__);
							return;
						}
						goto IL_01e7;
						IL_01e7:
						awaiter2.GetResult();
					}
					finally
					{
						if (num < 0 && _003Cconnection_003E5__1 != null)
						{
							((global::System.IDisposable)_003Cconnection_003E5__1).Dispose();
						}
					}
					_003Cconnection_003E5__1 = null;
					_003Ccommand_003E5__2 = null;
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this._dbSemaphore.Release();
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

	private readonly IPlayerRepository _playerRepository;

	private readonly IConnectivity _connectivity;

	private readonly IUpdatePriorityDeterminer _priorityDeterminer;

	private readonly BatchUpdateMerger _merger;

	private readonly ConcurrentQueue<PendingUpdate> _memoryQueue = new ConcurrentQueue<PendingUpdate>();

	private readonly Timer _flushTimer;

	private readonly SemaphoreSlim _flushSemaphore = new SemaphoreSlim(1, 1);

	private readonly SemaphoreSlim _dbSemaphore = new SemaphoreSlim(1, 1);

	private string _dbPath;

	private bool _disposed = false;

	private bool _initialized = false;

	private readonly TaskCompletionSource _initTcs = new TaskCompletionSource();

	private global::System.DateTime _lastReadCounterLog = global::System.DateTime.MinValue;

	private readonly TimeSpan _flushInterval = TimeSpan.FromSeconds(45L);

	private readonly int _maxQueueSize = 50;

	private readonly int _maxRetries = 3;

	[CompilerGenerated]
	[DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	private EventHandler<int>? m_PendingUpdatesChanged;

	[CompilerGenerated]
	[DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	private EventHandler<SyncStatus>? m_SyncStatusChanged;

	[CompilerGenerated]
	[DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	private EventHandler<string>? m_ReconciliationRequired;

	public bool HasPendingUpdates => !_memoryQueue.IsEmpty;

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public SyncStatus CurrentSyncStatus
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	} = SyncStatus.Synced;


	public event EventHandler<int>? PendingUpdatesChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler<int> val = this.m_PendingUpdatesChanged;
			EventHandler<int> val2;
			do
			{
				val2 = val;
				EventHandler<int> val3 = (EventHandler<int>)(object)global::System.Delegate.Combine((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler<int>>(ref this.m_PendingUpdatesChanged, val3, val2);
			}
			while (val != val2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<int> val = this.m_PendingUpdatesChanged;
			EventHandler<int> val2;
			do
			{
				val2 = val;
				EventHandler<int> val3 = (EventHandler<int>)(object)global::System.Delegate.Remove((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler<int>>(ref this.m_PendingUpdatesChanged, val3, val2);
			}
			while (val != val2);
		}
	}

	public event EventHandler<SyncStatus>? SyncStatusChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler<SyncStatus> val = this.m_SyncStatusChanged;
			EventHandler<SyncStatus> val2;
			do
			{
				val2 = val;
				EventHandler<SyncStatus> val3 = (EventHandler<SyncStatus>)(object)global::System.Delegate.Combine((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler<SyncStatus>>(ref this.m_SyncStatusChanged, val3, val2);
			}
			while (val != val2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<SyncStatus> val = this.m_SyncStatusChanged;
			EventHandler<SyncStatus> val2;
			do
			{
				val2 = val;
				EventHandler<SyncStatus> val3 = (EventHandler<SyncStatus>)(object)global::System.Delegate.Remove((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler<SyncStatus>>(ref this.m_SyncStatusChanged, val3, val2);
			}
			while (val != val2);
		}
	}

	public event EventHandler<string>? ReconciliationRequired
	{
		[CompilerGenerated]
		add
		{
			EventHandler<string> val = this.m_ReconciliationRequired;
			EventHandler<string> val2;
			do
			{
				val2 = val;
				EventHandler<string> val3 = (EventHandler<string>)(object)global::System.Delegate.Combine((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler<string>>(ref this.m_ReconciliationRequired, val3, val2);
			}
			while (val != val2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<string> val = this.m_ReconciliationRequired;
			EventHandler<string> val2;
			do
			{
				val2 = val;
				EventHandler<string> val3 = (EventHandler<string>)(object)global::System.Delegate.Remove((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler<string>>(ref this.m_ReconciliationRequired, val3, val2);
			}
			while (val != val2);
		}
	}

	public PersistentBatchQueueService(IPlayerRepository playerRepository, IConnectivity connectivity, IUpdatePriorityDeterminer priorityDeterminer, BatchUpdateMerger merger)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected O, but got Unknown
		_playerRepository = playerRepository;
		_connectivity = connectivity;
		_priorityDeterminer = priorityDeterminer;
		_merger = merger;
		_dbPath = Path.Combine(FileSystem.AppDataDirectory, "pending_updates.db");
		_flushTimer = new Timer(((TimeSpan)(ref _flushInterval)).TotalMilliseconds);
		_flushTimer.Elapsed += new ElapsedEventHandler(OnTimerElapsed);
		_flushTimer.AutoReset = true;
	}

	[AsyncStateMachine(typeof(_003CInitializeAsync_003Ed__32))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task InitializeAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CInitializeAsync_003Ed__32 _003CInitializeAsync_003Ed__ = new _003CInitializeAsync_003Ed__32();
		_003CInitializeAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CInitializeAsync_003Ed__._003C_003E4__this = this;
		_003CInitializeAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CInitializeAsync_003Ed__._003C_003Et__builder)).Start<_003CInitializeAsync_003Ed__32>(ref _003CInitializeAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CInitializeAsync_003Ed__._003C_003Et__builder)).Task;
	}

	public global::System.Threading.Tasks.Task WaitUntilInitializedAsync()
	{
		return _initTcs.Task;
	}

	public void QueueUpdate(PlayerBatchUpdate update, bool forceSyncNow = false)
	{
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass34_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass34_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		CS_0024_003C_003E8__locals0.update = update;
		if (!_initialized)
		{
			Console.WriteLine("BatchQueue not initialized. Cannot queue update.");
		}
		else if (forceSyncNow || _priorityDeterminer.IsCriticalUpdate(CS_0024_003C_003E8__locals0.update))
		{
			_003C_003Ec__DisplayClass34_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass34_1();
			CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
			List<string> val = new List<string>();
			if (CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.update.UpdateLevel && !_memoryQueue.IsEmpty)
			{
				List<PlayerBatchUpdate> val2 = new List<PlayerBatchUpdate>();
				List<PendingUpdate> val3 = new List<PendingUpdate>();
				PendingUpdate pendingUpdate = default(PendingUpdate);
				while (_memoryQueue.TryDequeue(ref pendingUpdate))
				{
					if (pendingUpdate.PlayerBatchUpdate.PlayerId == CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.update.PlayerId)
					{
						val2.Add(pendingUpdate.PlayerBatchUpdate);
						val.Add(pendingUpdate.Id);
					}
					else
					{
						val3.Add(pendingUpdate);
					}
				}
				Enumerator<PendingUpdate> enumerator = val3.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						PendingUpdate current = enumerator.Current;
						_memoryQueue.Enqueue(current);
					}
				}
				finally
				{
					((global::System.IDisposable)enumerator).Dispose();
				}
				if (val2.Count > 0)
				{
					val2.Add(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.update);
					CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.update = _merger.Merge((global::System.Collections.Generic.IEnumerable<PlayerBatchUpdate>)val2);
				}
			}
			CS_0024_003C_003E8__locals1.capturedUpdate = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.update;
			CS_0024_003C_003E8__locals1.capturedAbsorbedIds = val;
			PendingUpdate pendingUpdate2 = new PendingUpdate();
			Guid val4 = Guid.NewGuid();
			pendingUpdate2.Id = ((object)(Guid)(ref val4)).ToString();
			pendingUpdate2.PlayerBatchUpdate = CS_0024_003C_003E8__locals1.capturedUpdate;
			pendingUpdate2.CreatedAt = global::System.DateTime.UtcNow;
			pendingUpdate2.RetryCount = 0;
			CS_0024_003C_003E8__locals1.pendingUpdate = pendingUpdate2;
			global::System.Threading.Tasks.Task.Run((Func<global::System.Threading.Tasks.Task>)([AsyncStateMachine(typeof(_003C_003Ec__DisplayClass34_1._003C_003CQueueUpdate_003Eb__1_003Ed))] [DebuggerStepThrough] () =>
			{
				//IL_0007: Unknown result type (might be due to invalid IL or missing references)
				//IL_000c: Unknown result type (might be due to invalid IL or missing references)
				_003C_003Ec__DisplayClass34_1._003C_003CQueueUpdate_003Eb__1_003Ed _003C_003CQueueUpdate_003Eb__1_003Ed = new _003C_003Ec__DisplayClass34_1._003C_003CQueueUpdate_003Eb__1_003Ed
				{
					_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
					_003C_003E4__this = CS_0024_003C_003E8__locals1,
					_003C_003E1__state = -1
				};
				((AsyncTaskMethodBuilder)(ref _003C_003CQueueUpdate_003Eb__1_003Ed._003C_003Et__builder)).Start<_003C_003Ec__DisplayClass34_1._003C_003CQueueUpdate_003Eb__1_003Ed>(ref _003C_003CQueueUpdate_003Eb__1_003Ed);
				return ((AsyncTaskMethodBuilder)(ref _003C_003CQueueUpdate_003Eb__1_003Ed._003C_003Et__builder)).Task;
			}));
		}
		else
		{
			global::System.Threading.Tasks.Task.Run((Func<global::System.Threading.Tasks.Task>)([AsyncStateMachine(typeof(_003C_003Ec__DisplayClass34_0._003C_003CQueueUpdate_003Eb__0_003Ed))] [DebuggerStepThrough] () =>
			{
				//IL_0007: Unknown result type (might be due to invalid IL or missing references)
				//IL_000c: Unknown result type (might be due to invalid IL or missing references)
				_003C_003Ec__DisplayClass34_0._003C_003CQueueUpdate_003Eb__0_003Ed _003C_003CQueueUpdate_003Eb__0_003Ed = new _003C_003Ec__DisplayClass34_0._003C_003CQueueUpdate_003Eb__0_003Ed
				{
					_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
					_003C_003E4__this = CS_0024_003C_003E8__locals0,
					_003C_003E1__state = -1
				};
				((AsyncTaskMethodBuilder)(ref _003C_003CQueueUpdate_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003Ec__DisplayClass34_0._003C_003CQueueUpdate_003Eb__0_003Ed>(ref _003C_003CQueueUpdate_003Eb__0_003Ed);
				return ((AsyncTaskMethodBuilder)(ref _003C_003CQueueUpdate_003Eb__0_003Ed._003C_003Et__builder)).Task;
			}));
		}
	}

	[AsyncStateMachine(typeof(_003CQueueUpdateInternal_003Ed__35))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task QueueUpdateInternal(PlayerBatchUpdate update)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CQueueUpdateInternal_003Ed__35 _003CQueueUpdateInternal_003Ed__ = new _003CQueueUpdateInternal_003Ed__35();
		_003CQueueUpdateInternal_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CQueueUpdateInternal_003Ed__._003C_003E4__this = this;
		_003CQueueUpdateInternal_003Ed__.update = update;
		_003CQueueUpdateInternal_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CQueueUpdateInternal_003Ed__._003C_003Et__builder)).Start<_003CQueueUpdateInternal_003Ed__35>(ref _003CQueueUpdateInternal_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CQueueUpdateInternal_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CFlushOnlineActionAsync_003Ed__36))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task FlushOnlineActionAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CFlushOnlineActionAsync_003Ed__36 _003CFlushOnlineActionAsync_003Ed__ = new _003CFlushOnlineActionAsync_003Ed__36();
		_003CFlushOnlineActionAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CFlushOnlineActionAsync_003Ed__._003C_003E4__this = this;
		_003CFlushOnlineActionAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CFlushOnlineActionAsync_003Ed__._003C_003Et__builder)).Start<_003CFlushOnlineActionAsync_003Ed__36>(ref _003CFlushOnlineActionAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CFlushOnlineActionAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CFlushQueueAsync_003Ed__37))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task FlushQueueAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CFlushQueueAsync_003Ed__37 _003CFlushQueueAsync_003Ed__ = new _003CFlushQueueAsync_003Ed__37();
		_003CFlushQueueAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CFlushQueueAsync_003Ed__._003C_003E4__this = this;
		_003CFlushQueueAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CFlushQueueAsync_003Ed__._003C_003Et__builder)).Start<_003CFlushQueueAsync_003Ed__37>(ref _003CFlushQueueAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CFlushQueueAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CProcessBatchAsync_003Ed__38))]
	[DebuggerStepThrough]
	private async global::System.Threading.Tasks.Task<string?> ProcessBatchAsync(List<PendingUpdate> batch)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		string reconcilePlayerId = null;
		global::System.Collections.Generic.IEnumerable<IGrouping<string, PendingUpdate>> playerGroups = Enumerable.GroupBy<PendingUpdate, string>((global::System.Collections.Generic.IEnumerable<PendingUpdate>)batch, (Func<PendingUpdate, string>)((PendingUpdate u) => u.PlayerBatchUpdate.PlayerId));
		global::System.Collections.Generic.IEnumerator<IGrouping<string, PendingUpdate>> enumerator = playerGroups.GetEnumerator();
		try
		{
			while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
			{
				IGrouping<string, PendingUpdate> playerGroup = enumerator.Current;
				PlayerBatchUpdate mergedUpdate = _merger.Merge(Enumerable.Select<PendingUpdate, PlayerBatchUpdate>((global::System.Collections.Generic.IEnumerable<PendingUpdate>)playerGroup, (Func<PendingUpdate, PlayerBatchUpdate>)((PendingUpdate p) => p.PlayerBatchUpdate)));
				List<PendingUpdate> pendingUpdates = Enumerable.ToList<PendingUpdate>((global::System.Collections.Generic.IEnumerable<PendingUpdate>)playerGroup);
				switch (await ExecuteBatchUpdateWithRetryAsync(mergedUpdate))
				{
				case BatchUpdateOutcome.Success:
				{
					Enumerator<PendingUpdate> enumerator3 = pendingUpdates.GetEnumerator();
					try
					{
						while (enumerator3.MoveNext())
						{
							PendingUpdate update = enumerator3.Current;
							await RemovePendingUpdateAsync(update.Id);
						}
					}
					finally
					{
						((global::System.IDisposable)enumerator3).Dispose();
					}
					continue;
				}
				case BatchUpdateOutcome.PermanentFailure:
				{
					Enumerator<PendingUpdate> enumerator2 = pendingUpdates.GetEnumerator();
					try
					{
						while (enumerator2.MoveNext())
						{
							PendingUpdate update2 = enumerator2.Current;
							Console.WriteLine("Update " + update2.Id + " permanently rejected. Marking failed.");
							await MarkUpdateAsFailedAsync(update2.Id);
						}
					}
					finally
					{
						((global::System.IDisposable)enumerator2).Dispose();
					}
					if (reconcilePlayerId == null)
					{
						reconcilePlayerId = mergedUpdate.PlayerId;
					}
					continue;
				}
				}
				Enumerator<PendingUpdate> enumerator4 = pendingUpdates.GetEnumerator();
				try
				{
					while (enumerator4.MoveNext())
					{
						PendingUpdate update3 = enumerator4.Current;
						update3.RetryCount++;
						if (update3.RetryCount < _maxRetries)
						{
							_memoryQueue.Enqueue(update3);
							await UpdatePendingUpdateRetryCountAsync(update3.Id, update3.RetryCount);
							continue;
						}
						Console.WriteLine($"Update {update3.Id} failed after {_maxRetries} retries. Giving up.");
						await MarkUpdateAsFailedAsync(update3.Id);
					}
				}
				finally
				{
					((global::System.IDisposable)enumerator4).Dispose();
				}
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator)?.Dispose();
		}
		return reconcilePlayerId;
	}

	[AsyncStateMachine(typeof(_003CExecuteBatchUpdateWithRetryAsync_003Ed__39))]
	[DebuggerStepThrough]
	private async global::System.Threading.Tasks.Task<BatchUpdateOutcome> ExecuteBatchUpdateWithRetryAsync(PlayerBatchUpdate update)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			return await _playerRepository.BatchUpdatePlayerAsync(update);
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("Error executing batch update: " + ex.Message);
			return BatchUpdateOutcome.TransientFailure;
		}
	}

	private void UpdateSyncStatus(SyncStatus? status = null)
	{
		SyncStatus syncStatus = (SyncStatus)(((int?)status) ?? ((!_memoryQueue.IsEmpty) ? 1 : 0));
		if (CurrentSyncStatus != syncStatus)
		{
			CurrentSyncStatus = syncStatus;
			this.SyncStatusChanged?.Invoke((object)this, syncStatus);
		}
	}

	private void OnTimerElapsed(object sender, ElapsedEventArgs e)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		global::System.Threading.Tasks.Task.Run((Func<global::System.Threading.Tasks.Task>)FlushQueueAsync);
		TimeSpan val = global::System.DateTime.UtcNow - _lastReadCounterLog;
		if (((TimeSpan)(ref val)).TotalMinutes >= 5.0)
		{
			_lastReadCounterLog = global::System.DateTime.UtcNow;
			FirestoreReadCounter.LogSummary();
		}
	}

	[AsyncStateMachine(typeof(_003CInitializeDatabaseAsync_003Ed__42))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task InitializeDatabaseAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CInitializeDatabaseAsync_003Ed__42 _003CInitializeDatabaseAsync_003Ed__ = new _003CInitializeDatabaseAsync_003Ed__42();
		_003CInitializeDatabaseAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CInitializeDatabaseAsync_003Ed__._003C_003E4__this = this;
		_003CInitializeDatabaseAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CInitializeDatabaseAsync_003Ed__._003C_003Et__builder)).Start<_003CInitializeDatabaseAsync_003Ed__42>(ref _003CInitializeDatabaseAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CInitializeDatabaseAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CLoadPendingUpdatesAsync_003Ed__43))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task LoadPendingUpdatesAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadPendingUpdatesAsync_003Ed__43 _003CLoadPendingUpdatesAsync_003Ed__ = new _003CLoadPendingUpdatesAsync_003Ed__43();
		_003CLoadPendingUpdatesAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadPendingUpdatesAsync_003Ed__._003C_003E4__this = this;
		_003CLoadPendingUpdatesAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadPendingUpdatesAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadPendingUpdatesAsync_003Ed__43>(ref _003CLoadPendingUpdatesAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadPendingUpdatesAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CStorePendingUpdateAsync_003Ed__44))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task StorePendingUpdateAsync(PendingUpdate update)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CStorePendingUpdateAsync_003Ed__44 _003CStorePendingUpdateAsync_003Ed__ = new _003CStorePendingUpdateAsync_003Ed__44();
		_003CStorePendingUpdateAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CStorePendingUpdateAsync_003Ed__._003C_003E4__this = this;
		_003CStorePendingUpdateAsync_003Ed__.update = update;
		_003CStorePendingUpdateAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CStorePendingUpdateAsync_003Ed__._003C_003Et__builder)).Start<_003CStorePendingUpdateAsync_003Ed__44>(ref _003CStorePendingUpdateAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CStorePendingUpdateAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CRemovePendingUpdateAsync_003Ed__45))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task RemovePendingUpdateAsync(string id)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CRemovePendingUpdateAsync_003Ed__45 _003CRemovePendingUpdateAsync_003Ed__ = new _003CRemovePendingUpdateAsync_003Ed__45();
		_003CRemovePendingUpdateAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CRemovePendingUpdateAsync_003Ed__._003C_003E4__this = this;
		_003CRemovePendingUpdateAsync_003Ed__.id = id;
		_003CRemovePendingUpdateAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CRemovePendingUpdateAsync_003Ed__._003C_003Et__builder)).Start<_003CRemovePendingUpdateAsync_003Ed__45>(ref _003CRemovePendingUpdateAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CRemovePendingUpdateAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CUpdatePendingUpdateRetryCountAsync_003Ed__46))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task UpdatePendingUpdateRetryCountAsync(string id, int retryCount)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CUpdatePendingUpdateRetryCountAsync_003Ed__46 _003CUpdatePendingUpdateRetryCountAsync_003Ed__ = new _003CUpdatePendingUpdateRetryCountAsync_003Ed__46();
		_003CUpdatePendingUpdateRetryCountAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CUpdatePendingUpdateRetryCountAsync_003Ed__._003C_003E4__this = this;
		_003CUpdatePendingUpdateRetryCountAsync_003Ed__.id = id;
		_003CUpdatePendingUpdateRetryCountAsync_003Ed__.retryCount = retryCount;
		_003CUpdatePendingUpdateRetryCountAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CUpdatePendingUpdateRetryCountAsync_003Ed__._003C_003Et__builder)).Start<_003CUpdatePendingUpdateRetryCountAsync_003Ed__46>(ref _003CUpdatePendingUpdateRetryCountAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CUpdatePendingUpdateRetryCountAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CMarkUpdateAsFailedAsync_003Ed__47))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task MarkUpdateAsFailedAsync(string id)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CMarkUpdateAsFailedAsync_003Ed__47 _003CMarkUpdateAsFailedAsync_003Ed__ = new _003CMarkUpdateAsFailedAsync_003Ed__47();
		_003CMarkUpdateAsFailedAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CMarkUpdateAsFailedAsync_003Ed__._003C_003E4__this = this;
		_003CMarkUpdateAsFailedAsync_003Ed__.id = id;
		_003CMarkUpdateAsFailedAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CMarkUpdateAsFailedAsync_003Ed__._003C_003Et__builder)).Start<_003CMarkUpdateAsFailedAsync_003Ed__47>(ref _003CMarkUpdateAsFailedAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CMarkUpdateAsFailedAsync_003Ed__._003C_003Et__builder)).Task;
	}

	public void Dispose()
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		if (!_disposed)
		{
			Timer flushTimer = _flushTimer;
			if (flushTimer != null)
			{
				flushTimer.Stop();
			}
			Timer flushTimer2 = _flushTimer;
			if (flushTimer2 != null)
			{
				((Component)flushTimer2).Dispose();
			}
			try
			{
				TaskAwaiter awaiter = FlushQueueAsync().GetAwaiter();
				((TaskAwaiter)(ref awaiter)).GetResult();
			}
			catch (global::System.Exception ex)
			{
				Console.WriteLine("Error during final flush: " + ex.Message);
			}
			SemaphoreSlim flushSemaphore = _flushSemaphore;
			if (flushSemaphore != null)
			{
				flushSemaphore.Dispose();
			}
			SemaphoreSlim dbSemaphore = _dbSemaphore;
			if (dbSemaphore != null)
			{
				dbSemaphore.Dispose();
			}
			_disposed = true;
		}
	}
}
