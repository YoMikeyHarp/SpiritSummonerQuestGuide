using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.ViewModels.Popups;

namespace SpiritSummoner.Presentation.Views.Popups.GuildPopups;

[XamlFilePath("Presentation\\Views\\Popups\\GuildPopups\\GuildInvitationsPopup.xaml")]
public class GuildInvitationsPopup : Popup
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass0_0
	{
		private sealed class _003C_003C_002Dctor_003Eb__0_003Ed : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object s;

			public PopupOpenedEventArgs e;

			public _003C_003Ec__DisplayClass0_0 _003C_003E4__this;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
				//IL_0052: Unknown result type (might be due to invalid IL or missing references)
				//IL_0057: Unknown result type (might be due to invalid IL or missing references)
				//IL_005e: Unknown result type (might be due to invalid IL or missing references)
				//IL_001e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0023: Unknown result type (might be due to invalid IL or missing references)
				//IL_0037: Unknown result type (might be due to invalid IL or missing references)
				//IL_0038: Unknown result type (might be due to invalid IL or missing references)
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this.viewModel.InitializeAsync().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003C_003C_002Dctor_003Eb__0_003Ed _003C_003C_002Dctor_003Eb__0_003Ed = this;
							((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003C_003C_002Dctor_003Eb__0_003Ed>(ref awaiter, ref _003C_003C_002Dctor_003Eb__0_003Ed);
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

		public GuildInvitationsPopupViewModel viewModel;

		[AsyncStateMachine(typeof(_003C_003C_002Dctor_003Eb__0_003Ed))]
		[DebuggerStepThrough]
		internal void _003C_002Ector_003Eb__0(object? s, PopupOpenedEventArgs e)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003C_002Dctor_003Eb__0_003Ed _003C_003C_002Dctor_003Eb__0_003Ed = new _003C_003C_002Dctor_003Eb__0_003Ed
			{
				_003C_003Et__builder = AsyncVoidMethodBuilder.Create(),
				_003C_003E4__this = this,
				s = s,
				e = e,
				_003C_003E1__state = -1
			};
			((AsyncVoidMethodBuilder)(ref _003C_003C_002Dctor_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003C_002Dctor_003Eb__0_003Ed>(ref _003C_003C_002Dctor_003Eb__0_003Ed);
		}
	}

	public GuildInvitationsPopup(GuildInvitationsPopupViewModel viewModel)
	{
		_003C_003Ec__DisplayClass0_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass0_0();
		CS_0024_003C_003E8__locals0.viewModel = viewModel;
		((Popup)this)._002Ector();
		InitializeComponent();
		((BindableObject)this).BindingContext = CS_0024_003C_003E8__locals0.viewModel;
		((Popup)this).Opened += [AsyncStateMachine(typeof(_003C_003Ec__DisplayClass0_0._003C_003C_002Dctor_003Eb__0_003Ed))] [DebuggerStepThrough] (object? s, PopupOpenedEventArgs e) =>
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003Ec__DisplayClass0_0._003C_003C_002Dctor_003Eb__0_003Ed _003C_003C_002Dctor_003Eb__0_003Ed = new _003C_003Ec__DisplayClass0_0._003C_003C_002Dctor_003Eb__0_003Ed
			{
				_003C_003Et__builder = AsyncVoidMethodBuilder.Create(),
				_003C_003E4__this = CS_0024_003C_003E8__locals0,
				s = s,
				e = e,
				_003C_003E1__state = -1
			};
			((AsyncVoidMethodBuilder)(ref _003C_003C_002Dctor_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003Ec__DisplayClass0_0._003C_003C_002Dctor_003Eb__0_003Ed>(ref _003C_003C_002Dctor_003Eb__0_003Ed);
		};
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<GuildInvitationsPopup>(this, typeof(GuildInvitationsPopup));
	}
}
