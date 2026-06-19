using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Presentation.Services;

public class BottomSheetService : IBottomSheetService
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass1_0<TResult> where TResult : notnull
	{
		public BottomSheet sheet;

		public TaskCompletionSource<TResult> tcs;

		public BottomSheetService _003C_003E4__this;

		public string sheetId;
	}

	[CompilerGenerated]
	private sealed class _003CDismissAsync_003Ed__4 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BottomSheet sheet;

		public BottomSheetService _003C_003E4__this;

		private global::System.Exception _003Cex_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num == 0 || sheet != null)
				{
					try
					{
						TaskAwaiter awaiter;
						if (num != 0)
						{
							awaiter = sheet.DismissAsync(false).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CDismissAsync_003Ed__4 _003CDismissAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CDismissAsync_003Ed__4>(ref awaiter, ref _003CDismissAsync_003Ed__);
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
						Console.WriteLine("Error dismissing sheet: " + _003Cex_003E5__1.Message);
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
	private sealed class _003CShowSheetAsync_003Ed__1<TResult> : IAsyncStateMachine where TResult : notnull
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<TResult> _003C_003Et__builder;

		public BottomSheet sheet;

		public string sheetId;

		public BottomSheetService _003C_003E4__this;

		private _003C_003Ec__DisplayClass1_0<TResult> _003C_003E8__1;

		private TResult _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<TResult> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_0134: Unknown result type (might be due to invalid IL or missing references)
			//IL_0139: Unknown result type (might be due to invalid IL or missing references)
			//IL_0140: Unknown result type (might be due to invalid IL or missing references)
			//IL_0167: Unknown result type (might be due to invalid IL or missing references)
			//IL_016c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0183: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			TResult result;
			try
			{
				if ((uint)num > 1u)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass1_0<TResult>();
					_003C_003E8__1.sheet = sheet;
					_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
					_003C_003E8__1.sheetId = sheetId;
					if (_003C_003E8__1.sheetId == null)
					{
						_003C_003Ec__DisplayClass1_0<TResult> _003C_003Ec__DisplayClass1_ = _003C_003E8__1;
						Guid val = Guid.NewGuid();
						_003C_003Ec__DisplayClass1_.sheetId = ((object)(Guid)(ref val)).ToString();
					}
					_003C_003E8__1.tcs = new TaskCompletionSource<TResult>();
					_003C_003E4__this._activeSheets[_003C_003E8__1.sheetId] = _003C_003E8__1.tcs;
					_003C_003E8__1.sheet.Dismissed += OnDismissed;
				}
				try
				{
					TaskAwaiter<TResult> awaiter;
					TaskAwaiter awaiter2;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<TResult>);
							num = (_003C_003E1__state = -1);
							goto IL_01bd;
						}
						awaiter2 = _003C_003E8__1.sheet.ShowAsync(true, true).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CShowSheetAsync_003Ed__1<TResult> _003CShowSheetAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CShowSheetAsync_003Ed__1<TResult>>(ref awaiter2, ref _003CShowSheetAsync_003Ed__);
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
					awaiter = _003C_003E8__1.tcs.Task.GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter;
						_003CShowSheetAsync_003Ed__1<TResult> _003CShowSheetAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<TResult>, _003CShowSheetAsync_003Ed__1<TResult>>(ref awaiter, ref _003CShowSheetAsync_003Ed__);
						return;
					}
					goto IL_01bd;
					IL_01bd:
					_003C_003Es__2 = awaiter.GetResult();
					result = _003C_003Es__2;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine("Error showing sheet: " + _003Cex_003E5__3.Message);
					_003C_003E4__this._activeSheets.Remove(_003C_003E8__1.sheetId);
					throw;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003C_003Et__builder.SetResult(result);
			void OnDismissed(object? sender, DismissOrigin e)
			{
				((_003C_003Ec__DisplayClass1_0<TResult>)this).sheet.Dismissed -= OnDismissed;
				if (!((global::System.Threading.Tasks.Task)((_003C_003Ec__DisplayClass1_0<TResult>)this).tcs.Task).IsCompleted)
				{
					((_003C_003Ec__DisplayClass1_0<TResult>)this).tcs.TrySetResult(default(TResult));
				}
				((_003C_003Ec__DisplayClass1_0<TResult>)this)._003C_003E4__this._activeSheets.Remove(((_003C_003Ec__DisplayClass1_0<TResult>)this).sheetId);
			}
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CShowSheetAsync_003Ed__2 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BottomSheet sheet;

		public BottomSheetService _003C_003E4__this;

		private global::System.Exception _003Cex_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
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
						awaiter = sheet.ShowAsync(true, true).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CShowSheetAsync_003Ed__2 _003CShowSheetAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CShowSheetAsync_003Ed__2>(ref awaiter, ref _003CShowSheetAsync_003Ed__);
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
					Console.WriteLine("Error showing sheet: " + _003Cex_003E5__1.Message);
					throw;
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

	private readonly Dictionary<string, object> _activeSheets = new Dictionary<string, object>();

	[AsyncStateMachine(typeof(_003CShowSheetAsync_003Ed__1<>))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<TResult> ShowSheetAsync<TResult>(BottomSheet sheet, string? sheetId = null)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		BottomSheet sheet2 = sheet;
		string sheetId2 = sheetId;
		if (sheetId2 == null)
		{
			Guid val = Guid.NewGuid();
			sheetId2 = ((object)(Guid)(ref val)).ToString();
		}
		TaskCompletionSource<TResult> tcs = new TaskCompletionSource<TResult>();
		_activeSheets[sheetId2] = tcs;
		sheet2.Dismissed += OnDismissed;
		try
		{
			await sheet2.ShowAsync(true, true);
			return await tcs.Task;
		}
		catch (global::System.Exception ex)
		{
			Console.WriteLine("Error showing sheet: " + ex.Message);
			_activeSheets.Remove(sheetId2);
			throw;
		}
		void OnDismissed(object? sender, DismissOrigin e)
		{
			sheet2.Dismissed -= OnDismissed;
			if (!((global::System.Threading.Tasks.Task)tcs.Task).IsCompleted)
			{
				tcs.TrySetResult(default(TResult));
			}
			_activeSheets.Remove(sheetId2);
		}
	}

	[AsyncStateMachine(typeof(_003CShowSheetAsync_003Ed__2))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task ShowSheetAsync(BottomSheet sheet)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CShowSheetAsync_003Ed__2 _003CShowSheetAsync_003Ed__ = new _003CShowSheetAsync_003Ed__2();
		_003CShowSheetAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CShowSheetAsync_003Ed__._003C_003E4__this = this;
		_003CShowSheetAsync_003Ed__.sheet = sheet;
		_003CShowSheetAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CShowSheetAsync_003Ed__._003C_003Et__builder)).Start<_003CShowSheetAsync_003Ed__2>(ref _003CShowSheetAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CShowSheetAsync_003Ed__._003C_003Et__builder)).Task;
	}

	public void SetResult<TResult>(string sheetId, TResult result)
	{
		object obj = default(object);
		if (_activeSheets.TryGetValue(sheetId, ref obj) && obj is TaskCompletionSource<TResult> val)
		{
			val.TrySetResult(result);
		}
	}

	[AsyncStateMachine(typeof(_003CDismissAsync_003Ed__4))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task DismissAsync(BottomSheet sheet)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CDismissAsync_003Ed__4 _003CDismissAsync_003Ed__ = new _003CDismissAsync_003Ed__4();
		_003CDismissAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CDismissAsync_003Ed__._003C_003E4__this = this;
		_003CDismissAsync_003Ed__.sheet = sheet;
		_003CDismissAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CDismissAsync_003Ed__._003C_003Et__builder)).Start<_003CDismissAsync_003Ed__4>(ref _003CDismissAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CDismissAsync_003Ed__._003C_003Et__builder)).Task;
	}
}
