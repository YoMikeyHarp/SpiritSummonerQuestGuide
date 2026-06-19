using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Plugin.Firebase.Auth;
using SpiritSummoner.Application.UseCases.Auth;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Infrastructure.Contracts;
using SpiritSummoner.Presentation.Navigation;
using SpiritSummoner.Presentation.Services;
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Presentation.ViewModels.BottomSheets;

public class LinkAccountSheetViewModel : ObservableObject
{
	[CompilerGenerated]
	private sealed class _003CContinueAsGuestAsync_003Ed__23 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public LinkAccountSheetViewModel _003C_003E4__this;

		private bool _003Cconfirmation_003E5__1;

		private bool _003C_003Es__2;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_011f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0124: Unknown result type (might be due to invalid IL or missing references)
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_015a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0162: Unknown result type (might be due to invalid IL or missing references)
			//IL_0139: Unknown result type (might be due to invalid IL or missing references)
			//IL_013b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter<bool> awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
					goto IL_00ba;
				}
				TaskAwaiter awaiter2;
				if (num == 1)
				{
					awaiter2 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0171;
				}
				if (_003C_003E4__this._sheet != null && _003C_003E4__this._sheetId != null)
				{
					awaiter = _003C_003E4__this._navigationService.ShowConfirmationAsync("Are you sure?", "Not linking your account comes with the risk of losing all your progress, it is highly recommended to link your account at start!").GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CContinueAsGuestAsync_003Ed__23 _003CContinueAsGuestAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CContinueAsGuestAsync_003Ed__23>(ref awaiter, ref _003CContinueAsGuestAsync_003Ed__);
						return;
					}
					goto IL_00ba;
				}
				goto end_IL_0007;
				IL_00ba:
				_003C_003Es__2 = awaiter.GetResult();
				_003Cconfirmation_003E5__1 = _003C_003Es__2;
				if (_003Cconfirmation_003E5__1)
				{
					_003C_003E4__this._bottomSheetService.SetResult(_003C_003E4__this._sheetId, result: false);
					awaiter2 = _003C_003E4__this._bottomSheetService.DismissAsync(_003C_003E4__this._sheet).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter2;
						_003CContinueAsGuestAsync_003Ed__23 _003CContinueAsGuestAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CContinueAsGuestAsync_003Ed__23>(ref awaiter2, ref _003CContinueAsGuestAsync_003Ed__);
						return;
					}
					goto IL_0171;
				}
				goto end_IL_0007;
				IL_0171:
				((TaskAwaiter)(ref awaiter2)).GetResult();
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
	private sealed class _003CLinkWithAppleAsync_003Ed__22 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public LinkAccountSheetViewModel _003C_003E4__this;

		private IFirebaseUser _003ClinkedUser_003E5__1;

		private Result<bool> _003Cresult_003E5__2;

		private IFirebaseUser _003C_003Es__3;

		private Result<bool> _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter<IFirebaseUser> _003C_003Eu__1;

		private TaskAwaiter<Result<bool>> _003C_003Eu__2;

		private TaskAwaiter _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0182: Unknown result type (might be due to invalid IL or missing references)
			//IL_0187: Unknown result type (might be due to invalid IL or missing references)
			//IL_018f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0260: Unknown result type (might be due to invalid IL or missing references)
			//IL_0265: Unknown result type (might be due to invalid IL or missing references)
			//IL_026d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0227: Unknown result type (might be due to invalid IL or missing references)
			//IL_022c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0241: Unknown result type (might be due to invalid IL or missing references)
			//IL_0243: Unknown result type (might be due to invalid IL or missing references)
			//IL_0149: Unknown result type (might be due to invalid IL or missing references)
			//IL_014e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0165: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 2u || (_003C_003E4__this._sheet != null && _003C_003E4__this._sheetId != null))
				{
					try
					{
						TaskAwaiter<IFirebaseUser> awaiter3;
						TaskAwaiter<Result<bool>> awaiter2;
						TaskAwaiter awaiter;
						switch (num)
						{
						default:
							_003C_003E4__this.IsLoading = true;
							_003C_003E4__this.ErrorMessage = null;
							awaiter3 = _003C_003E4__this._authService.LinkWithAppleAsync().GetAwaiter();
							if (!awaiter3.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter3;
								_003CLinkWithAppleAsync_003Ed__22 _003CLinkWithAppleAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<IFirebaseUser>, _003CLinkWithAppleAsync_003Ed__22>(ref awaiter3, ref _003CLinkWithAppleAsync_003Ed__);
								return;
							}
							goto IL_00d5;
						case 0:
							awaiter3 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<IFirebaseUser>);
							num = (_003C_003E1__state = -1);
							goto IL_00d5;
						case 1:
							awaiter2 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<Result<bool>>);
							num = (_003C_003E1__state = -1);
							goto IL_019e;
						case 2:
							{
								awaiter = _003C_003Eu__3;
								_003C_003Eu__3 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								break;
							}
							IL_019e:
							_003C_003Es__4 = awaiter2.GetResult();
							_003Cresult_003E5__2 = _003C_003Es__4;
							_003C_003Es__4 = null;
							if (_003Cresult_003E5__2.Success)
							{
								_003C_003E4__this._bottomSheetService.SetResult(_003C_003E4__this._sheetId, result: true);
								awaiter = _003C_003E4__this._bottomSheetService.DismissAsync(_003C_003E4__this._sheet).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
								{
									num = (_003C_003E1__state = 2);
									_003C_003Eu__3 = awaiter;
									_003CLinkWithAppleAsync_003Ed__22 _003CLinkWithAppleAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLinkWithAppleAsync_003Ed__22>(ref awaiter, ref _003CLinkWithAppleAsync_003Ed__);
									return;
								}
								break;
							}
							_003C_003E4__this.ErrorMessage = _003Cresult_003E5__2.ErrorMessage;
							goto end_IL_0038;
							IL_00d5:
							_003C_003Es__3 = awaiter3.GetResult();
							_003ClinkedUser_003E5__1 = _003C_003Es__3;
							_003C_003Es__3 = null;
							if (_003ClinkedUser_003E5__1 != null && !_003ClinkedUser_003E5__1.IsAnonymous)
							{
								awaiter2 = _003C_003E4__this._linkAccountUseCase.Execute(new LinkAccountRequest
								{
									Email = string.Empty
								}).GetAwaiter();
								if (!awaiter2.IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__2 = awaiter2;
									_003CLinkWithAppleAsync_003Ed__22 _003CLinkWithAppleAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<bool>>, _003CLinkWithAppleAsync_003Ed__22>(ref awaiter2, ref _003CLinkWithAppleAsync_003Ed__);
									return;
								}
								goto IL_019e;
							}
							_003C_003E4__this.ErrorMessage = "Account linking failed. Please try again.";
							goto end_IL_0038;
						}
						((TaskAwaiter)(ref awaiter)).GetResult();
						_003ClinkedUser_003E5__1 = null;
						_003Cresult_003E5__2 = null;
						end_IL_0038:;
					}
					catch (NotImplementedException)
					{
						_003C_003E4__this.ErrorMessage = "Apple sign-in is not yet available";
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__5 = ex;
						_003C_003E4__this.ErrorMessage = "Failed to link with Apple: " + _003Cex_003E5__5.Message;
						Console.WriteLine($"Link with Apple error: {_003Cex_003E5__5}");
					}
					finally
					{
						if (num < 0)
						{
							_003C_003E4__this.IsLoading = false;
						}
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
	private sealed class _003CLinkWithEmailAsync_003Ed__20 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public LinkAccountSheetViewModel _003C_003E4__this;

		private IFirebaseUser _003ClinkedUser_003E5__1;

		private Result<bool> _003Cresult_003E5__2;

		private Result<bool> _003C_003Es__3;

		private IFirebaseUser _003C_003Es__4;

		private Result<bool> _003Cresult_003E5__5;

		private Result<bool> _003C_003Es__6;

		private InvalidOperationException _003Cex_003E5__7;

		private global::System.Exception _003Cex_003E5__8;

		private TaskAwaiter<Result<bool>> _003C_003Eu__1;

		private TaskAwaiter<IFirebaseUser> _003C_003Eu__2;

		private TaskAwaiter _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_0202: Unknown result type (might be due to invalid IL or missing references)
			//IL_0207: Unknown result type (might be due to invalid IL or missing references)
			//IL_020f: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_03bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_04a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_04a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_029d: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0469: Unknown result type (might be due to invalid IL or missing references)
			//IL_046e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0483: Unknown result type (might be due to invalid IL or missing references)
			//IL_0485: Unknown result type (might be due to invalid IL or missing references)
			//IL_037d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0382: Unknown result type (might be due to invalid IL or missing references)
			//IL_0397: Unknown result type (might be due to invalid IL or missing references)
			//IL_0399: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 3u)
				{
					goto IL_0142;
				}
				if (_003C_003E4__this._sheet != null && _003C_003E4__this._sheetId != null)
				{
					if (string.IsNullOrWhiteSpace(_003C_003E4__this.Email))
					{
						_003C_003E4__this.ErrorMessage = "Please enter an email address";
					}
					else if (!_003C_003E4__this.Email.Contains('@') || !_003C_003E4__this.Email.Contains('.'))
					{
						_003C_003E4__this.ErrorMessage = "Please enter a valid email address";
					}
					else if (string.IsNullOrWhiteSpace(_003C_003E4__this.Password))
					{
						_003C_003E4__this.ErrorMessage = "Please enter a password";
					}
					else if (_003C_003E4__this.Password.Length < 6)
					{
						_003C_003E4__this.ErrorMessage = "Password must be at least 6 characters";
					}
					else
					{
						if (!(_003C_003E4__this.Password != _003C_003E4__this.ConfirmPassword))
						{
							goto IL_0142;
						}
						_003C_003E4__this.ErrorMessage = "Passwords do not match";
					}
				}
				goto end_IL_0007;
				IL_0142:
				try
				{
					TaskAwaiter<Result<bool>> awaiter4;
					TaskAwaiter<IFirebaseUser> awaiter3;
					TaskAwaiter<Result<bool>> awaiter2;
					TaskAwaiter awaiter;
					switch (num)
					{
					default:
						_003C_003E4__this.IsLoading = true;
						_003C_003E4__this.ErrorMessage = null;
						if (!_003C_003E4__this._isRegistrationFlow)
						{
							awaiter4 = _003C_003E4__this._linkAccountUseCase.Execute(new LinkAccountRequest
							{
								Email = _003C_003E4__this.Email
							}).GetAwaiter();
							if (!awaiter4.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter4;
								_003CLinkWithEmailAsync_003Ed__20 _003CLinkWithEmailAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<bool>>, _003CLinkWithEmailAsync_003Ed__20>(ref awaiter4, ref _003CLinkWithEmailAsync_003Ed__);
								return;
							}
							goto IL_021e;
						}
						goto IL_0277;
					case 0:
						awaiter4 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Result<bool>>);
						num = (_003C_003E1__state = -1);
						goto IL_021e;
					case 1:
						awaiter3 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<IFirebaseUser>);
						num = (_003C_003E1__state = -1);
						goto IL_02f3;
					case 2:
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Result<bool>>);
						num = (_003C_003E1__state = -1);
						goto IL_03d3;
					case 3:
						{
							awaiter = _003C_003Eu__3;
							_003C_003Eu__3 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							break;
						}
						IL_02f3:
						_003C_003Es__4 = awaiter3.GetResult();
						_003ClinkedUser_003E5__1 = _003C_003Es__4;
						_003C_003Es__4 = null;
						if (_003ClinkedUser_003E5__1 != null && !_003ClinkedUser_003E5__1.IsAnonymous)
						{
							_003C_003E4__this._bottomSheetService.SetResult(_003C_003E4__this._sheetId, result: true);
							awaiter = _003C_003E4__this._bottomSheetService.DismissAsync(_003C_003E4__this._sheet).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 3);
								_003C_003Eu__3 = awaiter;
								_003CLinkWithEmailAsync_003Ed__20 _003CLinkWithEmailAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLinkWithEmailAsync_003Ed__20>(ref awaiter, ref _003CLinkWithEmailAsync_003Ed__);
								return;
							}
							break;
						}
						_003C_003E4__this.ErrorMessage = "Account linking failed. Please try again.";
						if (!_003C_003E4__this._isRegistrationFlow)
						{
							awaiter2 = _003C_003E4__this._linkAccountUseCase.Execute(new LinkAccountRequest
							{
								Email = string.Empty
							}).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__1 = awaiter2;
								_003CLinkWithEmailAsync_003Ed__20 _003CLinkWithEmailAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<bool>>, _003CLinkWithEmailAsync_003Ed__20>(ref awaiter2, ref _003CLinkWithEmailAsync_003Ed__);
								return;
							}
							goto IL_03d3;
						}
						goto end_IL_0142;
						IL_0277:
						awaiter3 = _003C_003E4__this._authService.LinkWithEmailAndPasswordAsync(_003C_003E4__this.Email, _003C_003E4__this.Password).GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter3;
							_003CLinkWithEmailAsync_003Ed__20 _003CLinkWithEmailAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<IFirebaseUser>, _003CLinkWithEmailAsync_003Ed__20>(ref awaiter3, ref _003CLinkWithEmailAsync_003Ed__);
							return;
						}
						goto IL_02f3;
						IL_021e:
						_003C_003Es__3 = awaiter4.GetResult();
						_003Cresult_003E5__2 = _003C_003Es__3;
						_003C_003Es__3 = null;
						if (_003Cresult_003E5__2.Success)
						{
							_003Cresult_003E5__2 = null;
							goto IL_0277;
						}
						_003C_003E4__this.ErrorMessage = _003Cresult_003E5__2.ErrorMessage;
						goto end_IL_0142;
						IL_03d3:
						_003C_003Es__6 = awaiter2.GetResult();
						_003Cresult_003E5__5 = _003C_003Es__6;
						_003C_003Es__6 = null;
						if (!_003Cresult_003E5__5.Success)
						{
							_003C_003E4__this.ErrorMessage = _003Cresult_003E5__5.ErrorMessage;
						}
						else
						{
							_003Cresult_003E5__5 = null;
						}
						goto end_IL_0142;
					}
					((TaskAwaiter)(ref awaiter)).GetResult();
					_003ClinkedUser_003E5__1 = null;
					end_IL_0142:;
				}
				catch (object obj) when (((Func<bool>)delegate
				{
					// Could not convert BlockContainer to single expression
					object obj2 = ((obj is InvalidOperationException) ? obj : null);
					global::System.Runtime.CompilerServices.Unsafe.SkipInit(out int result);
					if (obj2 == null)
					{
						result = 0;
					}
					else
					{
						_003Cex_003E5__7 = (InvalidOperationException)obj2;
						result = (((global::System.Exception)(object)_003Cex_003E5__7).Message.Contains("already associated") ? 1 : 0);
					}
					return (byte)result != 0;
				}).Invoke())
				{
					_003C_003E4__this.ErrorMessage = "This email is already in use. Please use a different email.";
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__8 = ex;
					_003C_003E4__this.ErrorMessage = "Failed to link account: " + _003Cex_003E5__8.Message;
					Console.WriteLine($"Link account error: {_003Cex_003E5__8}");
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
	private sealed class _003CLinkWithGoogleAsync_003Ed__21 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public LinkAccountSheetViewModel _003C_003E4__this;

		private IFirebaseUser _003ClinkedUser_003E5__1;

		private Result<bool> _003Cresult_003E5__2;

		private IFirebaseUser _003C_003Es__3;

		private Result<bool> _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter<IFirebaseUser> _003C_003Eu__1;

		private TaskAwaiter<Result<bool>> _003C_003Eu__2;

		private TaskAwaiter _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0182: Unknown result type (might be due to invalid IL or missing references)
			//IL_0187: Unknown result type (might be due to invalid IL or missing references)
			//IL_018f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0260: Unknown result type (might be due to invalid IL or missing references)
			//IL_0265: Unknown result type (might be due to invalid IL or missing references)
			//IL_026d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0227: Unknown result type (might be due to invalid IL or missing references)
			//IL_022c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0241: Unknown result type (might be due to invalid IL or missing references)
			//IL_0243: Unknown result type (might be due to invalid IL or missing references)
			//IL_0149: Unknown result type (might be due to invalid IL or missing references)
			//IL_014e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0165: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 2u || (_003C_003E4__this._sheet != null && _003C_003E4__this._sheetId != null))
				{
					try
					{
						TaskAwaiter<IFirebaseUser> awaiter3;
						TaskAwaiter<Result<bool>> awaiter2;
						TaskAwaiter awaiter;
						switch (num)
						{
						default:
							_003C_003E4__this.IsLoading = true;
							_003C_003E4__this.ErrorMessage = null;
							awaiter3 = _003C_003E4__this._authService.LinkWithGoogleAsync().GetAwaiter();
							if (!awaiter3.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter3;
								_003CLinkWithGoogleAsync_003Ed__21 _003CLinkWithGoogleAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<IFirebaseUser>, _003CLinkWithGoogleAsync_003Ed__21>(ref awaiter3, ref _003CLinkWithGoogleAsync_003Ed__);
								return;
							}
							goto IL_00d5;
						case 0:
							awaiter3 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<IFirebaseUser>);
							num = (_003C_003E1__state = -1);
							goto IL_00d5;
						case 1:
							awaiter2 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<Result<bool>>);
							num = (_003C_003E1__state = -1);
							goto IL_019e;
						case 2:
							{
								awaiter = _003C_003Eu__3;
								_003C_003Eu__3 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								break;
							}
							IL_019e:
							_003C_003Es__4 = awaiter2.GetResult();
							_003Cresult_003E5__2 = _003C_003Es__4;
							_003C_003Es__4 = null;
							if (_003Cresult_003E5__2.Success)
							{
								_003C_003E4__this._bottomSheetService.SetResult(_003C_003E4__this._sheetId, result: true);
								awaiter = _003C_003E4__this._bottomSheetService.DismissAsync(_003C_003E4__this._sheet).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
								{
									num = (_003C_003E1__state = 2);
									_003C_003Eu__3 = awaiter;
									_003CLinkWithGoogleAsync_003Ed__21 _003CLinkWithGoogleAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLinkWithGoogleAsync_003Ed__21>(ref awaiter, ref _003CLinkWithGoogleAsync_003Ed__);
									return;
								}
								break;
							}
							_003C_003E4__this.ErrorMessage = _003Cresult_003E5__2.ErrorMessage;
							goto end_IL_0038;
							IL_00d5:
							_003C_003Es__3 = awaiter3.GetResult();
							_003ClinkedUser_003E5__1 = _003C_003Es__3;
							_003C_003Es__3 = null;
							if (_003ClinkedUser_003E5__1 != null && !_003ClinkedUser_003E5__1.IsAnonymous)
							{
								awaiter2 = _003C_003E4__this._linkAccountUseCase.Execute(new LinkAccountRequest
								{
									Email = string.Empty
								}).GetAwaiter();
								if (!awaiter2.IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__2 = awaiter2;
									_003CLinkWithGoogleAsync_003Ed__21 _003CLinkWithGoogleAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<bool>>, _003CLinkWithGoogleAsync_003Ed__21>(ref awaiter2, ref _003CLinkWithGoogleAsync_003Ed__);
									return;
								}
								goto IL_019e;
							}
							_003C_003E4__this.ErrorMessage = "Account linking failed. Please try again.";
							goto end_IL_0038;
						}
						((TaskAwaiter)(ref awaiter)).GetResult();
						_003ClinkedUser_003E5__1 = null;
						_003Cresult_003E5__2 = null;
						end_IL_0038:;
					}
					catch (NotImplementedException)
					{
						_003C_003E4__this.ErrorMessage = "Google sign-in is not yet available";
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__5 = ex;
						_003C_003E4__this.ErrorMessage = "Failed to link with Google: " + _003Cex_003E5__5.Message;
						Console.WriteLine($"Link with Google error: {_003Cex_003E5__5}");
					}
					finally
					{
						if (num < 0)
						{
							_003C_003E4__this.IsLoading = false;
						}
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

	private readonly IBottomSheetService _bottomSheetService;

	private readonly IAuthService _authService;

	private readonly LinkAccountUseCase _linkAccountUseCase;

	private readonly INavigationService _navigationService;

	private BottomSheet? _sheet;

	private string? _sheetId;

	private bool _isRegistrationFlow;

	[ObservableProperty]
	private string _email = string.Empty;

	[ObservableProperty]
	private string _password = string.Empty;

	[ObservableProperty]
	private string _confirmPassword = string.Empty;

	[ObservableProperty]
	private bool _isLoading;

	[ObservableProperty]
	private bool _isPasswordVisible;

	[ObservableProperty]
	private string? _errorMessage;

	[ObservableProperty]
	private bool _showEmailForm;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? showEmailLinkingCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? hideEmailLinkingCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? togglePasswordVisibilityCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? linkWithEmailCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? linkWithGoogleCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? linkWithAppleCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? continueAsGuestCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string Email
	{
		get
		{
			return _email;
		}
		[MemberNotNull("_email")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_email, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Email);
				_email = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Email);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string Password
	{
		get
		{
			return _password;
		}
		[MemberNotNull("_password")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_password, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Password);
				_password = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Password);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string ConfirmPassword
	{
		get
		{
			return _confirmPassword;
		}
		[MemberNotNull("_confirmPassword")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_confirmPassword, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ConfirmPassword);
				_confirmPassword = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ConfirmPassword);
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
	public bool IsPasswordVisible
	{
		get
		{
			return _isPasswordVisible;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isPasswordVisible, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsPasswordVisible);
				_isPasswordVisible = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsPasswordVisible);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string? ErrorMessage
	{
		get
		{
			return _errorMessage;
		}
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
	public bool ShowEmailForm
	{
		get
		{
			return _showEmailForm;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_showEmailForm, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ShowEmailForm);
				_showEmailForm = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ShowEmailForm);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand ShowEmailLinkingCommand
	{
		get
		{
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Expected O, but got Unknown
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			RelayCommand obj = showEmailLinkingCommand;
			if (obj == null)
			{
				RelayCommand val = new RelayCommand(new Action(ShowEmailLinking));
				RelayCommand val2 = val;
				showEmailLinkingCommand = val;
				obj = val2;
			}
			return (IRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand HideEmailLinkingCommand
	{
		get
		{
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Expected O, but got Unknown
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			RelayCommand obj = hideEmailLinkingCommand;
			if (obj == null)
			{
				RelayCommand val = new RelayCommand(new Action(HideEmailLinking));
				RelayCommand val2 = val;
				hideEmailLinkingCommand = val;
				obj = val2;
			}
			return (IRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand TogglePasswordVisibilityCommand
	{
		get
		{
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Expected O, but got Unknown
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			RelayCommand obj = togglePasswordVisibilityCommand;
			if (obj == null)
			{
				RelayCommand val = new RelayCommand(new Action(TogglePasswordVisibility));
				RelayCommand val2 = val;
				togglePasswordVisibilityCommand = val;
				obj = val2;
			}
			return (IRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand LinkWithEmailCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = linkWithEmailCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)LinkWithEmailAsync);
				AsyncRelayCommand val2 = val;
				linkWithEmailCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand LinkWithGoogleCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = linkWithGoogleCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)LinkWithGoogleAsync);
				AsyncRelayCommand val2 = val;
				linkWithGoogleCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand LinkWithAppleCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = linkWithAppleCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)LinkWithAppleAsync);
				AsyncRelayCommand val2 = val;
				linkWithAppleCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand ContinueAsGuestCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = continueAsGuestCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)ContinueAsGuestAsync);
				AsyncRelayCommand val2 = val;
				continueAsGuestCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	public LinkAccountSheetViewModel(IBottomSheetService bottomSheetService, IAuthService authService, LinkAccountUseCase linkAccountUseCase, INavigationService navigationService)
	{
		_bottomSheetService = bottomSheetService;
		_authService = authService;
		_linkAccountUseCase = linkAccountUseCase;
		_navigationService = navigationService;
	}

	public void Initialize(BottomSheet sheet, string sheetId)
	{
		_sheet = sheet;
		_sheetId = sheetId;
		Email = string.Empty;
		Password = string.Empty;
		ConfirmPassword = string.Empty;
		ErrorMessage = null;
		ShowEmailForm = false;
		IsLoading = false;
		_isRegistrationFlow = false;
	}

	public void SetRegistrationMode(bool isRegistrationFlow)
	{
		_isRegistrationFlow = isRegistrationFlow;
	}

	[RelayCommand]
	private void ShowEmailLinking()
	{
		ShowEmailForm = true;
		ErrorMessage = null;
	}

	[RelayCommand]
	private void HideEmailLinking()
	{
		ShowEmailForm = false;
		Email = string.Empty;
		Password = string.Empty;
		ConfirmPassword = string.Empty;
		ErrorMessage = null;
	}

	[RelayCommand]
	private void TogglePasswordVisibility()
	{
		IsPasswordVisible = !IsPasswordVisible;
	}

	[AsyncStateMachine(typeof(_003CLinkWithEmailAsync_003Ed__20))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task LinkWithEmailAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLinkWithEmailAsync_003Ed__20 _003CLinkWithEmailAsync_003Ed__ = new _003CLinkWithEmailAsync_003Ed__20();
		_003CLinkWithEmailAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLinkWithEmailAsync_003Ed__._003C_003E4__this = this;
		_003CLinkWithEmailAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLinkWithEmailAsync_003Ed__._003C_003Et__builder)).Start<_003CLinkWithEmailAsync_003Ed__20>(ref _003CLinkWithEmailAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLinkWithEmailAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CLinkWithGoogleAsync_003Ed__21))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task LinkWithGoogleAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLinkWithGoogleAsync_003Ed__21 _003CLinkWithGoogleAsync_003Ed__ = new _003CLinkWithGoogleAsync_003Ed__21();
		_003CLinkWithGoogleAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLinkWithGoogleAsync_003Ed__._003C_003E4__this = this;
		_003CLinkWithGoogleAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLinkWithGoogleAsync_003Ed__._003C_003Et__builder)).Start<_003CLinkWithGoogleAsync_003Ed__21>(ref _003CLinkWithGoogleAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLinkWithGoogleAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CLinkWithAppleAsync_003Ed__22))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task LinkWithAppleAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLinkWithAppleAsync_003Ed__22 _003CLinkWithAppleAsync_003Ed__ = new _003CLinkWithAppleAsync_003Ed__22();
		_003CLinkWithAppleAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLinkWithAppleAsync_003Ed__._003C_003E4__this = this;
		_003CLinkWithAppleAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLinkWithAppleAsync_003Ed__._003C_003Et__builder)).Start<_003CLinkWithAppleAsync_003Ed__22>(ref _003CLinkWithAppleAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLinkWithAppleAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CContinueAsGuestAsync_003Ed__23))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task ContinueAsGuestAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CContinueAsGuestAsync_003Ed__23 _003CContinueAsGuestAsync_003Ed__ = new _003CContinueAsGuestAsync_003Ed__23();
		_003CContinueAsGuestAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CContinueAsGuestAsync_003Ed__._003C_003E4__this = this;
		_003CContinueAsGuestAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CContinueAsGuestAsync_003Ed__._003C_003Et__builder)).Start<_003CContinueAsGuestAsync_003Ed__23>(ref _003CContinueAsGuestAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CContinueAsGuestAsync_003Ed__._003C_003Et__builder)).Task;
	}
}
