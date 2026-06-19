using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SpiritSummoner.Presentation.Models;

namespace SpiritSummoner.Presentation.ViewModels.Spirits;

public static class SpiritCardViewModelHelper
{
	[CompilerGenerated]
	private sealed class _003CCreateCollectionAsync_003Ed__2 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<ObservableCollection<SpiritCardViewModel>> _003C_003Et__builder;

		public IServiceProvider services;

		public SpiritCardModelFactory modelFactory;

		public global::System.Collections.Generic.IEnumerable<string> playerSpiritIds;

		private ObservableCollection<SpiritCardViewModel> _003Cvms_003E5__1;

		private ValueTuple<ObservableCollection<SpiritCardViewModel>, List<string>> _003C_003Es__2;

		private ValueTuple<ObservableCollection<SpiritCardViewModel>, List<string>> _003C_003Es__3;

		private TaskAwaiter<ValueTuple<ObservableCollection<SpiritCardViewModel>, List<string>>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			ObservableCollection<SpiritCardViewModel> result;
			try
			{
				TaskAwaiter<ValueTuple<ObservableCollection<SpiritCardViewModel>, List<string>>> awaiter;
				if (num != 0)
				{
					awaiter = CreateCollectionWithTrackingAsync(services, modelFactory, playerSpiritIds).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CCreateCollectionAsync_003Ed__2 _003CCreateCollectionAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<ValueTuple<ObservableCollection<SpiritCardViewModel>, List<string>>>, _003CCreateCollectionAsync_003Ed__2>(ref awaiter, ref _003CCreateCollectionAsync_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<ValueTuple<ObservableCollection<SpiritCardViewModel>, List<string>>>);
					num = (_003C_003E1__state = -1);
				}
				_003C_003Es__2 = awaiter.GetResult();
				_003C_003Es__3 = _003C_003Es__2;
				_003Cvms_003E5__1 = _003C_003Es__3.Item1;
				_003C_003Es__2 = default(ValueTuple<ObservableCollection<SpiritCardViewModel>, List<string>>);
				_003C_003Es__3 = default(ValueTuple<ObservableCollection<SpiritCardViewModel>, List<string>>);
				result = _003Cvms_003E5__1;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cvms_003E5__1 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cvms_003E5__1 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCreateCollectionWithTrackingAsync_003Ed__1 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<ValueTuple<ObservableCollection<SpiritCardViewModel>, List<string>>> _003C_003Et__builder;

		public IServiceProvider services;

		public SpiritCardModelFactory modelFactory;

		public global::System.Collections.Generic.IEnumerable<string> playerSpiritIds;

		private ObservableCollection<SpiritCardViewModel> _003Cvms_003E5__1;

		private List<string> _003CacquiredIds_003E5__2;

		private global::System.Collections.Generic.IEnumerator<string> _003C_003Es__3;

		private string _003Cid_003E5__4;

		private SpiritCardModel _003Cmodel_003E5__5;

		private SpiritCardViewModel _003Cvm_003E5__6;

		private SpiritCardModel _003C_003Es__7;

		private TaskAwaiter<SpiritCardModel> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_018c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0191: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			ValueTuple<ObservableCollection<SpiritCardViewModel>, List<string>> result;
			try
			{
				if (num != 0)
				{
					_003Cvms_003E5__1 = new ObservableCollection<SpiritCardViewModel>();
					_003CacquiredIds_003E5__2 = new List<string>();
					_003C_003Es__3 = Enumerable.Where<string>(playerSpiritIds, (Func<string, bool>)((string id) => !string.IsNullOrEmpty(id))).GetEnumerator();
				}
				try
				{
					if (num != 0)
					{
						goto IL_014e;
					}
					TaskAwaiter<SpiritCardModel> awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<SpiritCardModel>);
					num = (_003C_003E1__state = -1);
					goto IL_00dd;
					IL_00dd:
					_003C_003Es__7 = awaiter.GetResult();
					_003Cmodel_003E5__5 = _003C_003Es__7;
					_003C_003Es__7 = null;
					_003CacquiredIds_003E5__2.Add(_003Cid_003E5__4);
					_003Cvm_003E5__6 = CreateViewModel(services, _003Cmodel_003E5__5);
					((Collection<SpiritCardViewModel>)(object)_003Cvms_003E5__1).Add(_003Cvm_003E5__6);
					_003Cmodel_003E5__5 = null;
					_003Cvm_003E5__6 = null;
					_003Cid_003E5__4 = null;
					goto IL_014e;
					IL_014e:
					if (((global::System.Collections.IEnumerator)_003C_003Es__3).MoveNext())
					{
						_003Cid_003E5__4 = _003C_003Es__3.Current;
						awaiter = modelFactory.CreateModelAsync(_003Cid_003E5__4).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CCreateCollectionWithTrackingAsync_003Ed__1 _003CCreateCollectionWithTrackingAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<SpiritCardModel>, _003CCreateCollectionWithTrackingAsync_003Ed__1>(ref awaiter, ref _003CCreateCollectionWithTrackingAsync_003Ed__);
							return;
						}
						goto IL_00dd;
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
				result = new ValueTuple<ObservableCollection<SpiritCardViewModel>, List<string>>(_003Cvms_003E5__1, _003CacquiredIds_003E5__2);
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cvms_003E5__1 = null;
				_003CacquiredIds_003E5__2 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cvms_003E5__1 = null;
			_003CacquiredIds_003E5__2 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCreateViewModelAsync_003Ed__4 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<SpiritCardViewModel> _003C_003Et__builder;

		public IServiceProvider services;

		public SpiritCardModelFactory modelFactory;

		public string playerSpiritId;

		private SpiritCardViewModel _003Cvm_003E5__1;

		private ValueTuple<SpiritCardViewModel, string> _003C_003Es__2;

		private ValueTuple<SpiritCardViewModel, string> _003C_003Es__3;

		private TaskAwaiter<ValueTuple<SpiritCardViewModel, string>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			SpiritCardViewModel result;
			try
			{
				TaskAwaiter<ValueTuple<SpiritCardViewModel, string>> awaiter;
				if (num != 0)
				{
					awaiter = CreateViewModelWithTrackingAsync(services, modelFactory, playerSpiritId).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CCreateViewModelAsync_003Ed__4 _003CCreateViewModelAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<ValueTuple<SpiritCardViewModel, string>>, _003CCreateViewModelAsync_003Ed__4>(ref awaiter, ref _003CCreateViewModelAsync_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<ValueTuple<SpiritCardViewModel, string>>);
					num = (_003C_003E1__state = -1);
				}
				_003C_003Es__2 = awaiter.GetResult();
				_003C_003Es__3 = _003C_003Es__2;
				_003Cvm_003E5__1 = _003C_003Es__3.Item1;
				_003C_003Es__2 = default(ValueTuple<SpiritCardViewModel, string>);
				_003C_003Es__3 = default(ValueTuple<SpiritCardViewModel, string>);
				result = _003Cvm_003E5__1;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cvm_003E5__1 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cvm_003E5__1 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCreateViewModelWithTrackingAsync_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<ValueTuple<SpiritCardViewModel, string>> _003C_003Et__builder;

		public IServiceProvider services;

		public SpiritCardModelFactory modelFactory;

		public string playerSpiritId;

		private SpiritCardModel _003Cmodel_003E5__1;

		private SpiritCardViewModel _003Cvm_003E5__2;

		private SpiritCardModel _003C_003Es__3;

		private TaskAwaiter<SpiritCardModel> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			ValueTuple<SpiritCardViewModel, string> result;
			try
			{
				TaskAwaiter<SpiritCardModel> awaiter;
				if (num != 0)
				{
					awaiter = modelFactory.CreateModelAsync(playerSpiritId).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CCreateViewModelWithTrackingAsync_003Ed__3 _003CCreateViewModelWithTrackingAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<SpiritCardModel>, _003CCreateViewModelWithTrackingAsync_003Ed__3>(ref awaiter, ref _003CCreateViewModelWithTrackingAsync_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<SpiritCardModel>);
					num = (_003C_003E1__state = -1);
				}
				_003C_003Es__3 = awaiter.GetResult();
				_003Cmodel_003E5__1 = _003C_003Es__3;
				_003C_003Es__3 = null;
				_003Cvm_003E5__2 = CreateViewModel(services, _003Cmodel_003E5__1);
				result = new ValueTuple<SpiritCardViewModel, string>(_003Cvm_003E5__2, playerSpiritId);
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cmodel_003E5__1 = null;
				_003Cvm_003E5__2 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cmodel_003E5__1 = null;
			_003Cvm_003E5__2 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	public static SpiritCardViewModel CreateViewModel(IServiceProvider services, SpiritCardModel model)
	{
		SpiritCardViewModel requiredService = ServiceProviderServiceExtensions.GetRequiredService<SpiritCardViewModel>(services);
		requiredService.SetModel(model);
		return requiredService;
	}

	[AsyncStateMachine(typeof(_003CCreateCollectionWithTrackingAsync_003Ed__1))]
	[DebuggerStepThrough]
	public static async global::System.Threading.Tasks.Task<ValueTuple<ObservableCollection<SpiritCardViewModel>, List<string>>> CreateCollectionWithTrackingAsync(IServiceProvider services, SpiritCardModelFactory modelFactory, global::System.Collections.Generic.IEnumerable<string> playerSpiritIds)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		ObservableCollection<SpiritCardViewModel> vms = new ObservableCollection<SpiritCardViewModel>();
		List<string> acquiredIds = new List<string>();
		global::System.Collections.Generic.IEnumerator<string> enumerator = Enumerable.Where<string>(playerSpiritIds, (Func<string, bool>)((string id) => !string.IsNullOrEmpty(id))).GetEnumerator();
		try
		{
			while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
			{
				string id2 = enumerator.Current;
				SpiritCardModel model = await modelFactory.CreateModelAsync(id2);
				acquiredIds.Add(id2);
				SpiritCardViewModel vm = CreateViewModel(services, model);
				((Collection<SpiritCardViewModel>)(object)vms).Add(vm);
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator)?.Dispose();
		}
		return new ValueTuple<ObservableCollection<SpiritCardViewModel>, List<string>>(vms, acquiredIds);
	}

	[AsyncStateMachine(typeof(_003CCreateCollectionAsync_003Ed__2))]
	[DebuggerStepThrough]
	public static async global::System.Threading.Tasks.Task<ObservableCollection<SpiritCardViewModel>> CreateCollectionAsync(IServiceProvider services, SpiritCardModelFactory modelFactory, global::System.Collections.Generic.IEnumerable<string> playerSpiritIds)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		return (await CreateCollectionWithTrackingAsync(services, modelFactory, playerSpiritIds)).Item1;
	}

	[AsyncStateMachine(typeof(_003CCreateViewModelWithTrackingAsync_003Ed__3))]
	[DebuggerStepThrough]
	public static async global::System.Threading.Tasks.Task<ValueTuple<SpiritCardViewModel, string>> CreateViewModelWithTrackingAsync(IServiceProvider services, SpiritCardModelFactory modelFactory, string playerSpiritId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		SpiritCardViewModel vm = CreateViewModel(services, await modelFactory.CreateModelAsync(playerSpiritId));
		return new ValueTuple<SpiritCardViewModel, string>(vm, playerSpiritId);
	}

	[AsyncStateMachine(typeof(_003CCreateViewModelAsync_003Ed__4))]
	[DebuggerStepThrough]
	public static async global::System.Threading.Tasks.Task<SpiritCardViewModel> CreateViewModelAsync(IServiceProvider services, SpiritCardModelFactory modelFactory, string playerSpiritId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		return (await CreateViewModelWithTrackingAsync(services, modelFactory, playerSpiritId)).Item1;
	}

	public static void ReleaseModel(SpiritCardModelFactory modelFactory, string acquiredId)
	{
		if (acquiredId != null)
		{
			modelFactory.ReleaseModel(acquiredId);
		}
	}

	public static void ReleaseAll(SpiritCardModelFactory modelFactory, global::System.Collections.Generic.IEnumerable<string>? acquiredIds)
	{
		if (acquiredIds == null)
		{
			return;
		}
		global::System.Collections.Generic.IEnumerator<string> enumerator = Enumerable.Where<string>(acquiredIds, (Func<string, bool>)((string id) => !string.IsNullOrEmpty(id))).GetEnumerator();
		try
		{
			while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
			{
				string current = enumerator.Current;
				modelFactory.ReleaseModel(current);
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator)?.Dispose();
		}
	}
}
