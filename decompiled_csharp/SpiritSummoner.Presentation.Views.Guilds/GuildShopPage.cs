using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using CommunityToolkit.Maui.Core;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.Models;
using SpiritSummoner.Presentation.ViewModels.Guilds;

namespace SpiritSummoner.Presentation.Views.Guilds;

[XamlFilePath("Presentation\\Views\\Guilds\\GuildShopPage.xaml")]
public class GuildShopPage : ContentPage
{
	[CompilerGenerated]
	private sealed class _003CTouchBehavior_TouchGestureCompleted_003Ed__1 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public object sender;

		public TouchGestureCompletedEventArgs e;

		public GuildShopPage _003C_003E4__this;

		private GuildShopViewModel _003Cvm_003E5__1;

		private VisualElement _003Celement_003E5__2;

		private ItemModel _003Citem_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00e8;
				}
				object bindingContext = ((BindableObject)_003C_003E4__this).BindingContext;
				_003Cvm_003E5__1 = bindingContext as GuildShopViewModel;
				if (_003Cvm_003E5__1 != null)
				{
					ref VisualElement reference = ref _003Celement_003E5__2;
					object obj = sender;
					reference = (VisualElement)((obj is VisualElement) ? obj : null);
					while (_003Celement_003E5__2 != null)
					{
						bindingContext = ((BindableObject)_003Celement_003E5__2).BindingContext;
						_003Citem_003E5__3 = bindingContext as ItemModel;
						if (_003Citem_003E5__3 != null)
						{
							awaiter = _003Cvm_003E5__1.ShowItemPopupCommand.ExecuteAsync(_003Citem_003E5__3).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CTouchBehavior_TouchGestureCompleted_003Ed__1 _003CTouchBehavior_TouchGestureCompleted_003Ed__ = this;
								((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CTouchBehavior_TouchGestureCompleted_003Ed__1>(ref awaiter, ref _003CTouchBehavior_TouchGestureCompleted_003Ed__);
								return;
							}
							goto IL_00e8;
						}
						ref VisualElement reference2 = ref _003Celement_003E5__2;
						Element parent = ((Element)_003Celement_003E5__2).Parent;
						reference2 = (VisualElement)(object)((parent is VisualElement) ? parent : null);
						_003Citem_003E5__3 = null;
					}
				}
				goto end_IL_0007;
				IL_00e8:
				((TaskAwaiter)(ref awaiter)).GetResult();
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cvm_003E5__1 = null;
				_003Celement_003E5__2 = null;
				((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cvm_003E5__1 = null;
			_003Celement_003E5__2 = null;
			((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	public GuildShopPage(GuildShopViewModel vm)
	{
		InitializeComponent();
		((BindableObject)this).BindingContext = vm;
	}

	[AsyncStateMachine(typeof(_003CTouchBehavior_TouchGestureCompleted_003Ed__1))]
	[DebuggerStepThrough]
	private void TouchBehavior_TouchGestureCompleted(object? sender, TouchGestureCompletedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CTouchBehavior_TouchGestureCompleted_003Ed__1 _003CTouchBehavior_TouchGestureCompleted_003Ed__ = new _003CTouchBehavior_TouchGestureCompleted_003Ed__1();
		_003CTouchBehavior_TouchGestureCompleted_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003CTouchBehavior_TouchGestureCompleted_003Ed__._003C_003E4__this = this;
		_003CTouchBehavior_TouchGestureCompleted_003Ed__.sender = sender;
		_003CTouchBehavior_TouchGestureCompleted_003Ed__.e = e;
		_003CTouchBehavior_TouchGestureCompleted_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003CTouchBehavior_TouchGestureCompleted_003Ed__._003C_003Et__builder)).Start<_003CTouchBehavior_TouchGestureCompleted_003Ed__1>(ref _003CTouchBehavior_TouchGestureCompleted_003Ed__);
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<GuildShopPage>(this, typeof(GuildShopPage));
	}
}
