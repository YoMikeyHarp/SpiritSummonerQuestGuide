using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Application.State;
using SpiritSummoner.Infrastructure.Diagnostics;
using SpiritSummoner.Presentation.ViewModels.Shared;

namespace SpiritSummoner.Presentation.Views;

[XamlFilePath("Presentation\\Views\\MasterPage.xaml")]
public class MasterPage : ContentPage
{
	[CompilerGenerated]
	private sealed class _003COnAppearing_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public MasterPage _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00d6;
				}
				_003C_003E4__this._003C_003En__0();
				Console.WriteLine("MasterPage OnAppearing called");
				FirestoreReadCounter.LogSummary();
				if (_003C_003E4__this._viewModel.CurrentPage == null && _003C_003E4__this._playerState.GetCurrentPlayer() != null)
				{
					Console.WriteLine("Setting CurrentPage to //main");
					awaiter = _003C_003E4__this._viewModel.NavigateToCommand.ExecuteAsync("//main").GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003COnAppearing_003Ed__3 _003COnAppearing_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnAppearing_003Ed__3>(ref awaiter, ref _003COnAppearing_003Ed__);
						return;
					}
					goto IL_00d6;
				}
				ContentView? currentPage = _003C_003E4__this._viewModel.CurrentPage;
				object obj;
				if (currentPage == null)
				{
					obj = null;
				}
				else
				{
					global::System.Type type = ((object)currentPage).GetType();
					obj = ((type != null) ? ((MemberInfo)type).Name : null);
				}
				Console.WriteLine("CurrentPage: " + (string)obj + ", CurrentPlayer: " + _003C_003E4__this._playerState.GetCurrentPlayer()?.Playername);
				goto end_IL_0007;
				IL_00d6:
				((TaskAwaiter)(ref awaiter)).GetResult();
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

	private readonly NavBarViewModel _viewModel;

	private readonly IPlayerStateService _playerState;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private Grid masterGrid;

	public MasterPage(NavBarViewModel viewModel, IPlayerStateService playerState)
	{
		InitializeComponent();
		_viewModel = viewModel;
		_playerState = playerState;
		((BindableObject)this).BindingContext = _viewModel;
		Page.SetUseSafeArea(((Page)this).On<iOS>(), true);
	}

	[AsyncStateMachine(typeof(_003COnAppearing_003Ed__3))]
	[DebuggerStepThrough]
	protected override void OnAppearing()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003COnAppearing_003Ed__3 _003COnAppearing_003Ed__ = new _003COnAppearing_003Ed__3();
		_003COnAppearing_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003COnAppearing_003Ed__._003C_003E4__this = this;
		_003COnAppearing_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003COnAppearing_003Ed__._003C_003Et__builder)).Start<_003COnAppearing_003Ed__3>(ref _003COnAppearing_003Ed__);
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	[MemberNotNull("masterGrid")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<MasterPage>(this, typeof(MasterPage));
		masterGrid = NameScopeExtensions.FindByName<Grid>((Element)(object)this, "masterGrid");
	}

	[CompilerGenerated]
	[DebuggerHidden]
	private void _003C_003En__0()
	{
		((Page)this).OnAppearing();
	}
}
