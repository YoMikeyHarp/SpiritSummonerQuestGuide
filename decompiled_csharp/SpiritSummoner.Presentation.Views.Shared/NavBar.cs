using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.ViewModels.Shared;

namespace SpiritSummoner.Presentation.Views.Shared;

[XamlFilePath("Presentation\\Views\\Shared\\NavBar.xaml")]
public class NavBar : ContentView
{
	[CompilerGenerated]
	private sealed class _003COnNavItemTapped_003Ed__1 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public object sender;

		public EventArgs e;

		public NavBar _003C_003E4__this;

		private Image _003Cimage_003E5__1;

		private NavItem _003CnavItem_003E5__2;

		private NavBarViewModel _003Cvm_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0164: Unknown result type (might be due to invalid IL or missing references)
			//IL_0169: Unknown result type (might be due to invalid IL or missing references)
			//IL_0171: Unknown result type (might be due to invalid IL or missing references)
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			//IL_012f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0144: Unknown result type (might be due to invalid IL or missing references)
			//IL_0146: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
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
				TaskAwaiter awaiter2;
				if (num == 1)
				{
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0180;
				}
				ref Image reference = ref _003Cimage_003E5__1;
				object obj = sender;
				reference = (Image)((obj is Image) ? obj : null);
				if (_003Cimage_003E5__1 != null)
				{
					object bindingContext = ((BindableObject)_003Cimage_003E5__1).BindingContext;
					_003CnavItem_003E5__2 = bindingContext as NavItem;
					if ((object)_003CnavItem_003E5__2 != null)
					{
						bindingContext = ((BindableObject)_003C_003E4__this).BindingContext;
						_003Cvm_003E5__3 = bindingContext as NavBarViewModel;
						if (_003Cvm_003E5__3 != null)
						{
							if (_003CnavItem_003E5__2.Route == "//hub")
							{
								awaiter = _003Cvm_003E5__3.HubSheetCommand.ExecuteAsync((object)null).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter;
									_003COnNavItemTapped_003Ed__1 _003COnNavItemTapped_003Ed__ = this;
									((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnNavItemTapped_003Ed__1>(ref awaiter, ref _003COnNavItemTapped_003Ed__);
									return;
								}
								goto IL_0103;
							}
							awaiter2 = _003Cvm_003E5__3.NavigateToCommand.ExecuteAsync(_003CnavItem_003E5__2.Route).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__1 = awaiter2;
								_003COnNavItemTapped_003Ed__1 _003COnNavItemTapped_003Ed__ = this;
								((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnNavItemTapped_003Ed__1>(ref awaiter2, ref _003COnNavItemTapped_003Ed__);
								return;
							}
							goto IL_0180;
						}
					}
				}
				goto end_IL_0007;
				IL_0180:
				((TaskAwaiter)(ref awaiter2)).GetResult();
				goto end_IL_0007;
				IL_0103:
				((TaskAwaiter)(ref awaiter)).GetResult();
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cimage_003E5__1 = null;
				_003CnavItem_003E5__2 = null;
				_003Cvm_003E5__3 = null;
				((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cimage_003E5__1 = null;
			_003CnavItem_003E5__2 = null;
			_003Cvm_003E5__3 = null;
			((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private ContentView RootNavBar;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private FlexLayout NavFlexLayout;

	public NavBar()
	{
		InitializeComponent();
	}

	[AsyncStateMachine(typeof(_003COnNavItemTapped_003Ed__1))]
	[DebuggerStepThrough]
	private void OnNavItemTapped(object sender, EventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003COnNavItemTapped_003Ed__1 _003COnNavItemTapped_003Ed__ = new _003COnNavItemTapped_003Ed__1();
		_003COnNavItemTapped_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003COnNavItemTapped_003Ed__._003C_003E4__this = this;
		_003COnNavItemTapped_003Ed__.sender = sender;
		_003COnNavItemTapped_003Ed__.e = e;
		_003COnNavItemTapped_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003COnNavItemTapped_003Ed__._003C_003Et__builder)).Start<_003COnNavItemTapped_003Ed__1>(ref _003COnNavItemTapped_003Ed__);
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	[MemberNotNull("RootNavBar")]
	[MemberNotNull("NavFlexLayout")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<NavBar>(this, typeof(NavBar));
		RootNavBar = NameScopeExtensions.FindByName<ContentView>((Element)(object)this, "RootNavBar");
		NavFlexLayout = NameScopeExtensions.FindByName<FlexLayout>((Element)(object)this, "NavFlexLayout");
	}
}
