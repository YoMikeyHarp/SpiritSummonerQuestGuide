using System;
using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SpiritSummoner.Presentation.Services;
using SpiritSummoner.Presentation.ViewModels.Chat;
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Presentation.ViewModels.BottomSheet;

public class SelectFriendSheetViewModel : ObservableObject
{
	[CompilerGenerated]
	private sealed class _003CSelectFriend_003Ed__11 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public ChatPlayerModel friend;

		public SelectFriendSheetViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00be;
				}
				if (friend != null)
				{
					_003C_003E4__this.OnFriendSelected?.Invoke(friend);
					if (_003C_003E4__this._sheet != null)
					{
						awaiter = _003C_003E4__this._bottomSheetService.DismissAsync(_003C_003E4__this._sheet).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CSelectFriend_003Ed__11 _003CSelectFriend_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSelectFriend_003Ed__11>(ref awaiter, ref _003CSelectFriend_003Ed__);
							return;
						}
						goto IL_00be;
					}
				}
				goto end_IL_0007;
				IL_00be:
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

	private readonly IBottomSheetService _bottomSheetService;

	private BottomSheet? _sheet;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<ChatPlayerModel>? selectFriendCommand;

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public ObservableCollection<ChatPlayerModel> Friends
	{
		[CompilerGenerated]
		get;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Action<ChatPlayerModel>? OnFriendSelected
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<ChatPlayerModel> SelectFriendCommand => (IAsyncRelayCommand<ChatPlayerModel>)(object)(selectFriendCommand ?? (selectFriendCommand = new AsyncRelayCommand<ChatPlayerModel>((Func<ChatPlayerModel, global::System.Threading.Tasks.Task>)SelectFriend)));

	public void SetSheet(BottomSheet sheet)
	{
		_sheet = sheet;
	}

	public SelectFriendSheetViewModel(ObservableCollection<ChatPlayerModel> friends, IBottomSheetService bottomSheetService)
	{
		Friends = friends;
		_bottomSheetService = bottomSheetService;
	}

	[AsyncStateMachine(typeof(_003CSelectFriend_003Ed__11))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task SelectFriend(ChatPlayerModel friend)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CSelectFriend_003Ed__11 _003CSelectFriend_003Ed__ = new _003CSelectFriend_003Ed__11();
		_003CSelectFriend_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CSelectFriend_003Ed__._003C_003E4__this = this;
		_003CSelectFriend_003Ed__.friend = friend;
		_003CSelectFriend_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CSelectFriend_003Ed__._003C_003Et__builder)).Start<_003CSelectFriend_003Ed__11>(ref _003CSelectFriend_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CSelectFriend_003Ed__._003C_003Et__builder)).Task;
	}
}
