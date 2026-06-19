using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using CommunityToolkit.Maui.Core;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.ViewModels.Spirits;

namespace SpiritSummoner.Presentation.Views.Spirits;

[XamlFilePath("Presentation\\Views\\Spirits\\SpiritDetailsView.xaml")]
public class SpiritDetailsView : ContentPage
{
	[CompilerGenerated]
	private sealed class _003CTouchBehaviorAttributes_TouchGestureCompleted_003Ed__4 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public object sender;

		public TouchGestureCompletedEventArgs e;

		public SpiritDetailsView _003C_003E4__this;

		private object _003Ccontext_003E5__1;

		private SpiritDetailsViewModel _003CvmContext_003E5__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter awaiter;
					if (num == 0)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_00d5;
					}
					_003Ccontext_003E5__1 = ((BindableObject)_003C_003E4__this).BindingContext;
					if (_003Ccontext_003E5__1 != null)
					{
						_003CvmContext_003E5__2 = _003Ccontext_003E5__1 as SpiritDetailsViewModel;
						if (_003CvmContext_003E5__2 != null)
						{
							awaiter = (_003CvmContext_003E5__2?.SpiritCardModel?.EditAttributes()).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CTouchBehaviorAttributes_TouchGestureCompleted_003Ed__4 _003CTouchBehaviorAttributes_TouchGestureCompleted_003Ed__ = this;
								((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CTouchBehaviorAttributes_TouchGestureCompleted_003Ed__4>(ref awaiter, ref _003CTouchBehaviorAttributes_TouchGestureCompleted_003Ed__);
								return;
							}
							goto IL_00d5;
						}
					}
					goto end_IL_0010;
					IL_00d5:
					((TaskAwaiter)(ref awaiter)).GetResult();
					_003Ccontext_003E5__1 = null;
					_003CvmContext_003E5__2 = null;
					end_IL_0010:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine(_003Cex_003E5__3.Message);
					Console.WriteLine(_003Cex_003E5__3.StackTrace);
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetException(ex);
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

	[CompilerGenerated]
	private sealed class _003CTouchBehaviorGear_TouchGestureCompleted_003Ed__5 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public object sender;

		public TouchGestureCompletedEventArgs e;

		public SpiritDetailsView _003C_003E4__this;

		private object _003Ccontext_003E5__1;

		private SpiritDetailsViewModel _003CvmContext_003E5__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter awaiter;
					if (num == 0)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_00d5;
					}
					_003Ccontext_003E5__1 = ((BindableObject)_003C_003E4__this).BindingContext;
					if (_003Ccontext_003E5__1 != null)
					{
						_003CvmContext_003E5__2 = _003Ccontext_003E5__1 as SpiritDetailsViewModel;
						if (_003CvmContext_003E5__2 != null)
						{
							awaiter = (_003CvmContext_003E5__2?.SpiritCardModel?.EditGear()).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CTouchBehaviorGear_TouchGestureCompleted_003Ed__5 _003CTouchBehaviorGear_TouchGestureCompleted_003Ed__ = this;
								((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CTouchBehaviorGear_TouchGestureCompleted_003Ed__5>(ref awaiter, ref _003CTouchBehaviorGear_TouchGestureCompleted_003Ed__);
								return;
							}
							goto IL_00d5;
						}
					}
					goto end_IL_0010;
					IL_00d5:
					((TaskAwaiter)(ref awaiter)).GetResult();
					_003Ccontext_003E5__1 = null;
					_003CvmContext_003E5__2 = null;
					end_IL_0010:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine(_003Cex_003E5__3.Message);
					Console.WriteLine(_003Cex_003E5__3.StackTrace);
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetException(ex);
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

	[CompilerGenerated]
	private sealed class _003CTouchBehaviorHeldItem_TouchGestureCompleted_003Ed__9 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public object sender;

		public TouchGestureCompletedEventArgs e;

		public SpiritDetailsView _003C_003E4__this;

		private object _003Ccontext_003E5__1;

		private SpiritDetailsViewModel _003CvmContext_003E5__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter awaiter;
					if (num == 0)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_00cd;
					}
					_003Ccontext_003E5__1 = ((BindableObject)_003C_003E4__this).BindingContext;
					if (_003Ccontext_003E5__1 != null)
					{
						_003CvmContext_003E5__2 = _003Ccontext_003E5__1 as SpiritDetailsViewModel;
						if (_003CvmContext_003E5__2 != null)
						{
							awaiter = _003CvmContext_003E5__2.OpenItemSelectionCommand.ExecuteAsync((object)false).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CTouchBehaviorHeldItem_TouchGestureCompleted_003Ed__9 _003CTouchBehaviorHeldItem_TouchGestureCompleted_003Ed__ = this;
								((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CTouchBehaviorHeldItem_TouchGestureCompleted_003Ed__9>(ref awaiter, ref _003CTouchBehaviorHeldItem_TouchGestureCompleted_003Ed__);
								return;
							}
							goto IL_00cd;
						}
					}
					goto end_IL_0010;
					IL_00cd:
					((TaskAwaiter)(ref awaiter)).GetResult();
					_003Ccontext_003E5__1 = null;
					_003CvmContext_003E5__2 = null;
					end_IL_0010:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine("Moves sheet failed: " + _003Cex_003E5__3.Message);
					Console.WriteLine(_003Cex_003E5__3.StackTrace ?? string.Empty);
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetException(ex);
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

	[CompilerGenerated]
	private sealed class _003CTouchBehaviorLevelUp_TouchGestureCompleted_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public object sender;

		public TouchGestureCompletedEventArgs e;

		public SpiritDetailsView _003C_003E4__this;

		private object _003Ccontext_003E5__1;

		private SpiritDetailsViewModel _003CvmContext_003E5__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter awaiter;
					if (num == 0)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_00cd;
					}
					_003Ccontext_003E5__1 = ((BindableObject)_003C_003E4__this).BindingContext;
					if (_003Ccontext_003E5__1 != null)
					{
						_003CvmContext_003E5__2 = _003Ccontext_003E5__1 as SpiritDetailsViewModel;
						if (_003CvmContext_003E5__2 != null)
						{
							awaiter = _003CvmContext_003E5__2.LevelUpCommand.ExecuteAsync((object)false).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CTouchBehaviorLevelUp_TouchGestureCompleted_003Ed__3 _003CTouchBehaviorLevelUp_TouchGestureCompleted_003Ed__ = this;
								((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CTouchBehaviorLevelUp_TouchGestureCompleted_003Ed__3>(ref awaiter, ref _003CTouchBehaviorLevelUp_TouchGestureCompleted_003Ed__);
								return;
							}
							goto IL_00cd;
						}
					}
					goto end_IL_0010;
					IL_00cd:
					((TaskAwaiter)(ref awaiter)).GetResult();
					_003Ccontext_003E5__1 = null;
					_003CvmContext_003E5__2 = null;
					end_IL_0010:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.Write("Level up sheet failed: " + _003Cex_003E5__3.Message);
					Console.Write(_003Cex_003E5__3.StackTrace ?? string.Empty);
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetException(ex);
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

	[CompilerGenerated]
	private sealed class _003CTouchBehaviorMoves_TouchGestureCompleted_003Ed__8 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public object sender;

		public TouchGestureCompletedEventArgs e;

		public SpiritDetailsView _003C_003E4__this;

		private object _003Ccontext_003E5__1;

		private SpiritDetailsViewModel _003CvmContext_003E5__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter awaiter;
					if (num == 0)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_00cd;
					}
					_003Ccontext_003E5__1 = ((BindableObject)_003C_003E4__this).BindingContext;
					if (_003Ccontext_003E5__1 != null)
					{
						_003CvmContext_003E5__2 = _003Ccontext_003E5__1 as SpiritDetailsViewModel;
						if (_003CvmContext_003E5__2 != null)
						{
							awaiter = _003CvmContext_003E5__2.EditMovesCommand.ExecuteAsync((object)false).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CTouchBehaviorMoves_TouchGestureCompleted_003Ed__8 _003CTouchBehaviorMoves_TouchGestureCompleted_003Ed__ = this;
								((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CTouchBehaviorMoves_TouchGestureCompleted_003Ed__8>(ref awaiter, ref _003CTouchBehaviorMoves_TouchGestureCompleted_003Ed__);
								return;
							}
							goto IL_00cd;
						}
					}
					goto end_IL_0010;
					IL_00cd:
					((TaskAwaiter)(ref awaiter)).GetResult();
					_003Ccontext_003E5__1 = null;
					_003CvmContext_003E5__2 = null;
					end_IL_0010:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine("Moves sheet failed: " + _003Cex_003E5__3.Message);
					Console.WriteLine(_003Cex_003E5__3.StackTrace ?? string.Empty);
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetException(ex);
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

	[CompilerGenerated]
	private sealed class _003CTouchBehaviorSetParnter_TouchGestureCompleted_003Ed__7 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public object sender;

		public TouchGestureCompletedEventArgs e;

		public SpiritDetailsView _003C_003E4__this;

		private SpiritDetailsViewModel _003Cvm_003E5__1;

		private global::System.Exception _003Cex_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
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
						object bindingContext = ((BindableObject)_003C_003E4__this).BindingContext;
						_003Cvm_003E5__1 = bindingContext as SpiritDetailsViewModel;
						if (_003Cvm_003E5__1 == null)
						{
							goto IL_00b7;
						}
						SpiritCardViewModel? spiritCardModel = _003Cvm_003E5__1.SpiritCardModel;
						awaiter = ((spiritCardModel != null) ? spiritCardModel.SetAsPartnerCommand.ExecuteAsync((object)null) : null).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CTouchBehaviorSetParnter_TouchGestureCompleted_003Ed__7 _003CTouchBehaviorSetParnter_TouchGestureCompleted_003Ed__ = this;
							((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CTouchBehaviorSetParnter_TouchGestureCompleted_003Ed__7>(ref awaiter, ref _003CTouchBehaviorSetParnter_TouchGestureCompleted_003Ed__);
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
					goto IL_00b7;
					IL_00b7:
					_003Cvm_003E5__1 = null;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__2 = ex;
					Console.WriteLine(_003Cex_003E5__2.Message);
					Console.WriteLine(_003Cex_003E5__2.StackTrace);
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetException(ex);
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

	[CompilerGenerated]
	private sealed class _003CTouchBehaviorTalent_TouchGestureCompleted_003Ed__6 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public object sender;

		public TouchGestureCompletedEventArgs e;

		public SpiritDetailsView _003C_003E4__this;

		private object _003Ccontext_003E5__1;

		private SpiritDetailsViewModel _003CvmContext_003E5__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter awaiter;
					if (num == 0)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_00d5;
					}
					_003Ccontext_003E5__1 = ((BindableObject)_003C_003E4__this).BindingContext;
					if (_003Ccontext_003E5__1 != null)
					{
						_003CvmContext_003E5__2 = _003Ccontext_003E5__1 as SpiritDetailsViewModel;
						if (_003CvmContext_003E5__2 != null)
						{
							awaiter = (_003CvmContext_003E5__2?.SpiritCardModel?.EditTalent()).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CTouchBehaviorTalent_TouchGestureCompleted_003Ed__6 _003CTouchBehaviorTalent_TouchGestureCompleted_003Ed__ = this;
								((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CTouchBehaviorTalent_TouchGestureCompleted_003Ed__6>(ref awaiter, ref _003CTouchBehaviorTalent_TouchGestureCompleted_003Ed__);
								return;
							}
							goto IL_00d5;
						}
					}
					goto end_IL_0010;
					IL_00d5:
					((TaskAwaiter)(ref awaiter)).GetResult();
					_003Ccontext_003E5__1 = null;
					_003CvmContext_003E5__2 = null;
					end_IL_0010:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine(_003Cex_003E5__3.Message);
					Console.WriteLine(_003Cex_003E5__3.StackTrace);
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetException(ex);
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

	[CompilerGenerated]
	private sealed class _003CTouchBehaviorTransform_TouchGestureCompleted_003Ed__10 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public object sender;

		public TouchGestureCompletedEventArgs e;

		public SpiritDetailsView _003C_003E4__this;

		private object _003Ccontext_003E5__1;

		private SpiritDetailsViewModel _003CvmContext_003E5__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter awaiter;
					if (num == 0)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_00cd;
					}
					_003Ccontext_003E5__1 = ((BindableObject)_003C_003E4__this).BindingContext;
					if (_003Ccontext_003E5__1 != null)
					{
						_003CvmContext_003E5__2 = _003Ccontext_003E5__1 as SpiritDetailsViewModel;
						if (_003CvmContext_003E5__2 != null)
						{
							awaiter = _003CvmContext_003E5__2.TransformCommand.ExecuteAsync((object)false).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CTouchBehaviorTransform_TouchGestureCompleted_003Ed__10 _003CTouchBehaviorTransform_TouchGestureCompleted_003Ed__ = this;
								((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CTouchBehaviorTransform_TouchGestureCompleted_003Ed__10>(ref awaiter, ref _003CTouchBehaviorTransform_TouchGestureCompleted_003Ed__);
								return;
							}
							goto IL_00cd;
						}
					}
					goto end_IL_0010;
					IL_00cd:
					((TaskAwaiter)(ref awaiter)).GetResult();
					_003Ccontext_003E5__1 = null;
					_003CvmContext_003E5__2 = null;
					end_IL_0010:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine("Moves sheet failed: " + _003Cex_003E5__3.Message);
					Console.WriteLine(_003Cex_003E5__3.StackTrace ?? string.Empty);
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetException(ex);
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

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private Border TalentBorder;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private Border GearBorder;

	public SpiritDetailsView(SpiritDetailsViewModel viewModel)
	{
		InitializeComponent();
		((BindableObject)this).BindingContext = viewModel;
	}

	protected override void OnAppearing()
	{
		((Page)this).OnAppearing();
	}

	protected override bool OnBackButtonPressed()
	{
		if (((BindableObject)this).BindingContext is SpiritDetailsViewModel spiritDetailsViewModel)
		{
			spiritDetailsViewModel.CloseCommand.ExecuteAsync((object)null);
		}
		return true;
	}

	[AsyncStateMachine(typeof(_003CTouchBehaviorLevelUp_TouchGestureCompleted_003Ed__3))]
	[DebuggerStepThrough]
	private void TouchBehaviorLevelUp_TouchGestureCompleted(object sender, TouchGestureCompletedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CTouchBehaviorLevelUp_TouchGestureCompleted_003Ed__3 _003CTouchBehaviorLevelUp_TouchGestureCompleted_003Ed__ = new _003CTouchBehaviorLevelUp_TouchGestureCompleted_003Ed__3();
		_003CTouchBehaviorLevelUp_TouchGestureCompleted_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003CTouchBehaviorLevelUp_TouchGestureCompleted_003Ed__._003C_003E4__this = this;
		_003CTouchBehaviorLevelUp_TouchGestureCompleted_003Ed__.sender = sender;
		_003CTouchBehaviorLevelUp_TouchGestureCompleted_003Ed__.e = e;
		_003CTouchBehaviorLevelUp_TouchGestureCompleted_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003CTouchBehaviorLevelUp_TouchGestureCompleted_003Ed__._003C_003Et__builder)).Start<_003CTouchBehaviorLevelUp_TouchGestureCompleted_003Ed__3>(ref _003CTouchBehaviorLevelUp_TouchGestureCompleted_003Ed__);
	}

	[AsyncStateMachine(typeof(_003CTouchBehaviorAttributes_TouchGestureCompleted_003Ed__4))]
	[DebuggerStepThrough]
	private void TouchBehaviorAttributes_TouchGestureCompleted(object sender, TouchGestureCompletedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CTouchBehaviorAttributes_TouchGestureCompleted_003Ed__4 _003CTouchBehaviorAttributes_TouchGestureCompleted_003Ed__ = new _003CTouchBehaviorAttributes_TouchGestureCompleted_003Ed__4();
		_003CTouchBehaviorAttributes_TouchGestureCompleted_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003CTouchBehaviorAttributes_TouchGestureCompleted_003Ed__._003C_003E4__this = this;
		_003CTouchBehaviorAttributes_TouchGestureCompleted_003Ed__.sender = sender;
		_003CTouchBehaviorAttributes_TouchGestureCompleted_003Ed__.e = e;
		_003CTouchBehaviorAttributes_TouchGestureCompleted_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003CTouchBehaviorAttributes_TouchGestureCompleted_003Ed__._003C_003Et__builder)).Start<_003CTouchBehaviorAttributes_TouchGestureCompleted_003Ed__4>(ref _003CTouchBehaviorAttributes_TouchGestureCompleted_003Ed__);
	}

	[AsyncStateMachine(typeof(_003CTouchBehaviorGear_TouchGestureCompleted_003Ed__5))]
	[DebuggerStepThrough]
	private void TouchBehaviorGear_TouchGestureCompleted(object sender, TouchGestureCompletedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CTouchBehaviorGear_TouchGestureCompleted_003Ed__5 _003CTouchBehaviorGear_TouchGestureCompleted_003Ed__ = new _003CTouchBehaviorGear_TouchGestureCompleted_003Ed__5();
		_003CTouchBehaviorGear_TouchGestureCompleted_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003CTouchBehaviorGear_TouchGestureCompleted_003Ed__._003C_003E4__this = this;
		_003CTouchBehaviorGear_TouchGestureCompleted_003Ed__.sender = sender;
		_003CTouchBehaviorGear_TouchGestureCompleted_003Ed__.e = e;
		_003CTouchBehaviorGear_TouchGestureCompleted_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003CTouchBehaviorGear_TouchGestureCompleted_003Ed__._003C_003Et__builder)).Start<_003CTouchBehaviorGear_TouchGestureCompleted_003Ed__5>(ref _003CTouchBehaviorGear_TouchGestureCompleted_003Ed__);
	}

	[AsyncStateMachine(typeof(_003CTouchBehaviorTalent_TouchGestureCompleted_003Ed__6))]
	[DebuggerStepThrough]
	private void TouchBehaviorTalent_TouchGestureCompleted(object sender, TouchGestureCompletedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CTouchBehaviorTalent_TouchGestureCompleted_003Ed__6 _003CTouchBehaviorTalent_TouchGestureCompleted_003Ed__ = new _003CTouchBehaviorTalent_TouchGestureCompleted_003Ed__6();
		_003CTouchBehaviorTalent_TouchGestureCompleted_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003CTouchBehaviorTalent_TouchGestureCompleted_003Ed__._003C_003E4__this = this;
		_003CTouchBehaviorTalent_TouchGestureCompleted_003Ed__.sender = sender;
		_003CTouchBehaviorTalent_TouchGestureCompleted_003Ed__.e = e;
		_003CTouchBehaviorTalent_TouchGestureCompleted_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003CTouchBehaviorTalent_TouchGestureCompleted_003Ed__._003C_003Et__builder)).Start<_003CTouchBehaviorTalent_TouchGestureCompleted_003Ed__6>(ref _003CTouchBehaviorTalent_TouchGestureCompleted_003Ed__);
	}

	[AsyncStateMachine(typeof(_003CTouchBehaviorSetParnter_TouchGestureCompleted_003Ed__7))]
	[DebuggerStepThrough]
	private void TouchBehaviorSetParnter_TouchGestureCompleted(object sender, TouchGestureCompletedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CTouchBehaviorSetParnter_TouchGestureCompleted_003Ed__7 _003CTouchBehaviorSetParnter_TouchGestureCompleted_003Ed__ = new _003CTouchBehaviorSetParnter_TouchGestureCompleted_003Ed__7();
		_003CTouchBehaviorSetParnter_TouchGestureCompleted_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003CTouchBehaviorSetParnter_TouchGestureCompleted_003Ed__._003C_003E4__this = this;
		_003CTouchBehaviorSetParnter_TouchGestureCompleted_003Ed__.sender = sender;
		_003CTouchBehaviorSetParnter_TouchGestureCompleted_003Ed__.e = e;
		_003CTouchBehaviorSetParnter_TouchGestureCompleted_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003CTouchBehaviorSetParnter_TouchGestureCompleted_003Ed__._003C_003Et__builder)).Start<_003CTouchBehaviorSetParnter_TouchGestureCompleted_003Ed__7>(ref _003CTouchBehaviorSetParnter_TouchGestureCompleted_003Ed__);
	}

	[AsyncStateMachine(typeof(_003CTouchBehaviorMoves_TouchGestureCompleted_003Ed__8))]
	[DebuggerStepThrough]
	private void TouchBehaviorMoves_TouchGestureCompleted(object sender, TouchGestureCompletedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CTouchBehaviorMoves_TouchGestureCompleted_003Ed__8 _003CTouchBehaviorMoves_TouchGestureCompleted_003Ed__ = new _003CTouchBehaviorMoves_TouchGestureCompleted_003Ed__8();
		_003CTouchBehaviorMoves_TouchGestureCompleted_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003CTouchBehaviorMoves_TouchGestureCompleted_003Ed__._003C_003E4__this = this;
		_003CTouchBehaviorMoves_TouchGestureCompleted_003Ed__.sender = sender;
		_003CTouchBehaviorMoves_TouchGestureCompleted_003Ed__.e = e;
		_003CTouchBehaviorMoves_TouchGestureCompleted_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003CTouchBehaviorMoves_TouchGestureCompleted_003Ed__._003C_003Et__builder)).Start<_003CTouchBehaviorMoves_TouchGestureCompleted_003Ed__8>(ref _003CTouchBehaviorMoves_TouchGestureCompleted_003Ed__);
	}

	[AsyncStateMachine(typeof(_003CTouchBehaviorHeldItem_TouchGestureCompleted_003Ed__9))]
	[DebuggerStepThrough]
	private void TouchBehaviorHeldItem_TouchGestureCompleted(object sender, TouchGestureCompletedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CTouchBehaviorHeldItem_TouchGestureCompleted_003Ed__9 _003CTouchBehaviorHeldItem_TouchGestureCompleted_003Ed__ = new _003CTouchBehaviorHeldItem_TouchGestureCompleted_003Ed__9();
		_003CTouchBehaviorHeldItem_TouchGestureCompleted_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003CTouchBehaviorHeldItem_TouchGestureCompleted_003Ed__._003C_003E4__this = this;
		_003CTouchBehaviorHeldItem_TouchGestureCompleted_003Ed__.sender = sender;
		_003CTouchBehaviorHeldItem_TouchGestureCompleted_003Ed__.e = e;
		_003CTouchBehaviorHeldItem_TouchGestureCompleted_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003CTouchBehaviorHeldItem_TouchGestureCompleted_003Ed__._003C_003Et__builder)).Start<_003CTouchBehaviorHeldItem_TouchGestureCompleted_003Ed__9>(ref _003CTouchBehaviorHeldItem_TouchGestureCompleted_003Ed__);
	}

	[AsyncStateMachine(typeof(_003CTouchBehaviorTransform_TouchGestureCompleted_003Ed__10))]
	[DebuggerStepThrough]
	private void TouchBehaviorTransform_TouchGestureCompleted(object sender, TouchGestureCompletedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CTouchBehaviorTransform_TouchGestureCompleted_003Ed__10 _003CTouchBehaviorTransform_TouchGestureCompleted_003Ed__ = new _003CTouchBehaviorTransform_TouchGestureCompleted_003Ed__10();
		_003CTouchBehaviorTransform_TouchGestureCompleted_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003CTouchBehaviorTransform_TouchGestureCompleted_003Ed__._003C_003E4__this = this;
		_003CTouchBehaviorTransform_TouchGestureCompleted_003Ed__.sender = sender;
		_003CTouchBehaviorTransform_TouchGestureCompleted_003Ed__.e = e;
		_003CTouchBehaviorTransform_TouchGestureCompleted_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003CTouchBehaviorTransform_TouchGestureCompleted_003Ed__._003C_003Et__builder)).Start<_003CTouchBehaviorTransform_TouchGestureCompleted_003Ed__10>(ref _003CTouchBehaviorTransform_TouchGestureCompleted_003Ed__);
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	[MemberNotNull("TalentBorder")]
	[MemberNotNull("GearBorder")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<SpiritDetailsView>(this, typeof(SpiritDetailsView));
		TalentBorder = NameScopeExtensions.FindByName<Border>((Element)(object)this, "TalentBorder");
		GearBorder = NameScopeExtensions.FindByName<Border>((Element)(object)this, "GearBorder");
	}
}
