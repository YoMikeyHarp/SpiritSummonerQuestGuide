using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Plugin.Firebase.Analytics;
using Plugin.Firebase.Auth;
using Plugin.Firebase.Core.Exceptions;
using Plugin.Firebase.Crashlytics;
using SpiritSummoner.Infrastructure.Contracts;

namespace SpiritSummoner.Infrastructure.Services;

public class AuthService : IAuthService
{
	[CompilerGenerated]
	private sealed class _003CCreateUserWithEmailAndPasswordAsync_003Ed__19 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<IFirebaseUser> _003C_003Et__builder;

		public string email;

		public string password;

		public AuthService _003C_003E4__this;

		private IFirebaseUser _003Cuser_003E5__1;

		private IFirebaseUser _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter<IFirebaseUser> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			IFirebaseUser result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<IFirebaseUser> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this._firebaseAuth.CreateUserAsync(email, password).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CCreateUserWithEmailAndPasswordAsync_003Ed__19 _003CCreateUserWithEmailAndPasswordAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IFirebaseUser>, _003CCreateUserWithEmailAndPasswordAsync_003Ed__19>(ref awaiter, ref _003CCreateUserWithEmailAndPasswordAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IFirebaseUser>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Cuser_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					_003C_003E4__this.CurrentUser = _003Cuser_003E5__1;
					_003C_003E4__this.UserChanged?.Invoke((object)_003C_003E4__this, _003Cuser_003E5__1);
					result = _003Cuser_003E5__1;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine($"User creation failed: {_003Cex_003E5__3}");
					_003C_003E4__this.CurrentUser = null;
					throw;
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
	private sealed class _003CDeleteUserAsync_003Ed__13 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string password;

		public AuthService _003C_003E4__this;

		private TaskAwaiter<IFirebaseUser> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_011f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0124: Unknown result type (might be due to invalid IL or missing references)
			//IL_0159: Unknown result type (might be due to invalid IL or missing references)
			//IL_015e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0166: Unknown result type (might be due to invalid IL or missing references)
			//IL_0139: Unknown result type (might be due to invalid IL or missing references)
			//IL_013b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				TaskAwaiter<IFirebaseUser> awaiter2;
				if (num != 0)
				{
					if (num == 1)
					{
						awaiter = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0175;
					}
					if (_003C_003E4__this.CurrentUser == null)
					{
						throw new InvalidOperationException("No authenticated user to delete");
					}
					if (_003C_003E4__this.CurrentUser.IsAnonymous || string.IsNullOrEmpty(_003C_003E4__this.CurrentUser.Email))
					{
						goto IL_010f;
					}
					if (string.IsNullOrEmpty(password))
					{
						throw new ArgumentException("Password required for non-anonymous account deletion");
					}
					awaiter2 = _003C_003E4__this._firebaseAuth.SignInWithEmailAndPasswordAsync(_003C_003E4__this.CurrentUser.Email, password, true).GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter2;
						_003CDeleteUserAsync_003Ed__13 _003CDeleteUserAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<IFirebaseUser>, _003CDeleteUserAsync_003Ed__13>(ref awaiter2, ref _003CDeleteUserAsync_003Ed__);
						return;
					}
				}
				else
				{
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<IFirebaseUser>);
					num = (_003C_003E1__state = -1);
				}
				awaiter2.GetResult();
				goto IL_010f;
				IL_0175:
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003C_003E4__this.CurrentUser = null;
				_003C_003E4__this.UserChanged?.Invoke((object)_003C_003E4__this, (IFirebaseUser)null);
				goto end_IL_0007;
				IL_010f:
				awaiter = _003C_003E4__this.CurrentUser.DeleteAsync().GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__2 = awaiter;
					_003CDeleteUserAsync_003Ed__13 _003CDeleteUserAsync_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CDeleteUserAsync_003Ed__13>(ref awaiter, ref _003CDeleteUserAsync_003Ed__);
					return;
				}
				goto IL_0175;
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
	private sealed class _003CLinkWithAppleAsync_003Ed__23 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<IFirebaseUser> _003C_003Et__builder;

		public AuthService _003C_003E4__this;

		private void MoveNext()
		{
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				throw new NotImplementedException("Apple account linking not yet implemented");
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(exception);
			}
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CLinkWithEmailAndPasswordAsync_003Ed__21 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<IFirebaseUser> _003C_003Et__builder;

		public string email;

		public string password;

		public AuthService _003C_003E4__this;

		private IFirebaseUser _003Cuser_003E5__1;

		private IFirebaseUser _003C_003Es__2;

		private FirebaseAuthException _003Cex_003E5__3;

		private global::System.Exception _003Cex_003E5__4;

		private TaskAwaiter<IFirebaseUser> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_019f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			IFirebaseUser result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<IFirebaseUser> awaiter;
					if (num != 0)
					{
						if (_003C_003E4__this.CurrentUser == null)
						{
							throw new InvalidOperationException("No authenticated user to link");
						}
						if (!_003C_003E4__this.CurrentUser.IsAnonymous)
						{
							throw new InvalidOperationException("Current user is not anonymous - cannot link credentials");
						}
						awaiter = _003C_003E4__this._firebaseAuth.LinkWithEmailAndPasswordAsync(email, password).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CLinkWithEmailAndPasswordAsync_003Ed__21 _003CLinkWithEmailAndPasswordAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IFirebaseUser>, _003CLinkWithEmailAndPasswordAsync_003Ed__21>(ref awaiter, ref _003CLinkWithEmailAndPasswordAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IFirebaseUser>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Cuser_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					_003C_003E4__this.CurrentUser = _003Cuser_003E5__1;
					_003C_003E4__this.UserChanged?.Invoke((object)_003C_003E4__this, _003Cuser_003E5__1);
					Console.WriteLine("Successfully linked email to anonymous account: " + email);
					result = _003Cuser_003E5__1;
				}
				catch (object obj) when (((Func<bool>)delegate
				{
					// Could not convert BlockContainer to single expression
					object obj2 = ((obj is FirebaseAuthException) ? obj : null);
					global::System.Runtime.CompilerServices.Unsafe.SkipInit(out int result2);
					if (obj2 == null)
					{
						result2 = 0;
					}
					else
					{
						_003Cex_003E5__3 = (FirebaseAuthException)obj2;
						result2 = (((global::System.Exception)(object)_003Cex_003E5__3).Message.Contains("credential-already-in-use") ? 1 : 0);
					}
					return (byte)result2 != 0;
				}).Invoke())
				{
					Console.WriteLine("Link failed - credential already in use: " + ((global::System.Exception)(object)_003Cex_003E5__3).Message);
					throw new InvalidOperationException("This email is already associated with another account. Please sign in with that account instead.", (global::System.Exception)(object)_003Cex_003E5__3);
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__4 = ex;
					Console.WriteLine("Link with email failed: " + _003Cex_003E5__4.Message);
					throw;
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
	private sealed class _003CLinkWithGoogleAsync_003Ed__22 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<IFirebaseUser> _003C_003Et__builder;

		public AuthService _003C_003E4__this;

		private void MoveNext()
		{
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				throw new NotImplementedException("Google account linking not yet implemented");
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(exception);
			}
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CSignInAnonymouslyAsync_003Ed__14 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public AuthService _003C_003E4__this;

		private global::System.Exception _003Cex_003E5__1;

		private TaskAwaiter<IFirebaseUser> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<IFirebaseUser> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this._firebaseAuth.SignInAnonymouslyAsync().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CSignInAnonymouslyAsync_003Ed__14 _003CSignInAnonymouslyAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<IFirebaseUser>, _003CSignInAnonymouslyAsync_003Ed__14>(ref awaiter, ref _003CSignInAnonymouslyAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IFirebaseUser>);
						num = (_003C_003E1__state = -1);
					}
					awaiter.GetResult();
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__1 = ex;
					Console.WriteLine($"Anonymous login failed: {_003Cex_003E5__1}");
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

	[CompilerGenerated]
	private sealed class _003CSignInWithApple_003Ed__17 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<IFirebaseUser> _003C_003Et__builder;

		public AuthService _003C_003E4__this;

		private global::System.Exception _003Cex_003E5__1;

		private void MoveNext()
		{
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				try
				{
					throw new NotImplementedException();
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__1 = ex;
					Console.WriteLine(_003Cex_003E5__1.Message);
					_003C_003E4__this.CurrentUser = null;
					throw;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
			}
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CSignInWithEmailAndPasswordAsync_003Ed__15 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<IFirebaseUser> _003C_003Et__builder;

		public string email;

		public string password;

		public AuthService _003C_003E4__this;

		private IFirebaseUser _003Cuser_003E5__1;

		private IFirebaseUser _003C_003Es__2;

		private TaskAwaiter<IFirebaseUser> _003C_003Eu__1;

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
			IFirebaseUser result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<IFirebaseUser> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this._firebaseAuth.SignInWithEmailAndPasswordAsync(email, password, false).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CSignInWithEmailAndPasswordAsync_003Ed__15 _003CSignInWithEmailAndPasswordAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IFirebaseUser>, _003CSignInWithEmailAndPasswordAsync_003Ed__15>(ref awaiter, ref _003CSignInWithEmailAndPasswordAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IFirebaseUser>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Cuser_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					_003C_003E4__this.CurrentUser = _003Cuser_003E5__1;
					_003C_003E4__this.UserChanged?.Invoke((object)_003C_003E4__this, _003Cuser_003E5__1);
					result = _003Cuser_003E5__1;
				}
				catch
				{
					_003C_003E4__this.CurrentUser = null;
					throw;
				}
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(exception);
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
	private sealed class _003CSignInWithFacebook_003Ed__18 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<IFirebaseUser> _003C_003Et__builder;

		public AuthService _003C_003E4__this;

		private global::System.Exception _003Cex_003E5__1;

		private void MoveNext()
		{
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				try
				{
					throw new NotImplementedException();
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__1 = ex;
					Console.WriteLine(_003Cex_003E5__1.Message);
					_003C_003E4__this.CurrentUser = null;
					throw;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
			}
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CSignInWithGoogle_003Ed__16 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<IFirebaseUser> _003C_003Et__builder;

		public AuthService _003C_003E4__this;

		private FirebaseAuthException _003Cex_003E5__1;

		private global::System.Exception _003Cex_003E5__2;

		private void MoveNext()
		{
			//IL_0010: Expected O, but got Unknown
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				try
				{
					throw new NotImplementedException();
				}
				catch (FirebaseAuthException val)
				{
					FirebaseAuthException val2 = val;
					_003Cex_003E5__1 = val2;
					Console.WriteLine(((global::System.Exception)(object)_003Cex_003E5__1).Message);
					_003C_003E4__this.CurrentUser = null;
					throw;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__2 = ex;
					Console.WriteLine(_003Cex_003E5__2.Message);
					_003C_003E4__this.CurrentUser = null;
					throw;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
			}
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CSignOutAsync_003Ed__20 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public AuthService _003C_003E4__this;

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
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						global::System.Threading.Tasks.Task task = _003C_003E4__this._firebaseAuth.SignOutAsync();
						awaiter = global::System.Threading.Tasks.Task.WhenAll(new global::System.ReadOnlySpan<global::System.Threading.Tasks.Task>(ref task)).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CSignOutAsync_003Ed__20 _003CSignOutAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSignOutAsync_003Ed__20>(ref awaiter, ref _003CSignOutAsync_003Ed__);
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
					_003C_003E4__this.CurrentUser = null;
					_003C_003E4__this.UserChanged?.Invoke((object)_003C_003E4__this, (IFirebaseUser)null);
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__1 = ex;
					Console.WriteLine("Signout failed: " + _003Cex_003E5__1.Message);
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

	private readonly IFirebaseAuth _firebaseAuth;

	private readonly IFirebaseCrashlytics _crashlytics;

	private readonly IFirebaseAnalytics _analytics;

	[CompilerGenerated]
	[DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	private EventHandler<IFirebaseUser>? m_UserChanged;

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public IFirebaseUser CurrentUser
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	public bool IsCurrentUserAnonymous
	{
		get
		{
			IFirebaseUser currentUser = CurrentUser;
			return currentUser != null && currentUser.IsAnonymous;
		}
	}

	public event EventHandler<IFirebaseUser>? UserChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler<IFirebaseUser> val = this.m_UserChanged;
			EventHandler<IFirebaseUser> val2;
			do
			{
				val2 = val;
				EventHandler<IFirebaseUser> val3 = (EventHandler<IFirebaseUser>)(object)global::System.Delegate.Combine((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler<IFirebaseUser>>(ref this.m_UserChanged, val3, val2);
			}
			while (val != val2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<IFirebaseUser> val = this.m_UserChanged;
			EventHandler<IFirebaseUser> val2;
			do
			{
				val2 = val;
				EventHandler<IFirebaseUser> val3 = (EventHandler<IFirebaseUser>)(object)global::System.Delegate.Remove((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler<IFirebaseUser>>(ref this.m_UserChanged, val3, val2);
			}
			while (val != val2);
		}
	}

	public AuthService(IFirebaseAuth firebaseAuth, IFirebaseCrashlytics crashlytics, IFirebaseAnalytics analytics)
	{
		_firebaseAuth = firebaseAuth;
		_crashlytics = crashlytics;
		_analytics = analytics;
		CurrentUser = _firebaseAuth.CurrentUser;
		_firebaseAuth.AddAuthStateListener((Action<IFirebaseAuth>)([CompilerGenerated] (IFirebaseAuth auth) =>
		{
			CurrentUser = auth.CurrentUser;
			IFirebaseUser currentUser = auth.CurrentUser;
			string userId = ((currentUser != null) ? currentUser.Uid : null) ?? string.Empty;
			_crashlytics.SetUserId(userId);
			_analytics.SetUserId(userId);
			this.UserChanged?.Invoke((object)this, CurrentUser);
		}));
	}

	[AsyncStateMachine(typeof(_003CDeleteUserAsync_003Ed__13))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task DeleteUserAsync(string? password = null)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CDeleteUserAsync_003Ed__13 _003CDeleteUserAsync_003Ed__ = new _003CDeleteUserAsync_003Ed__13();
		_003CDeleteUserAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CDeleteUserAsync_003Ed__._003C_003E4__this = this;
		_003CDeleteUserAsync_003Ed__.password = password;
		_003CDeleteUserAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CDeleteUserAsync_003Ed__._003C_003Et__builder)).Start<_003CDeleteUserAsync_003Ed__13>(ref _003CDeleteUserAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CDeleteUserAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CSignInAnonymouslyAsync_003Ed__14))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task SignInAnonymouslyAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CSignInAnonymouslyAsync_003Ed__14 _003CSignInAnonymouslyAsync_003Ed__ = new _003CSignInAnonymouslyAsync_003Ed__14();
		_003CSignInAnonymouslyAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CSignInAnonymouslyAsync_003Ed__._003C_003E4__this = this;
		_003CSignInAnonymouslyAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CSignInAnonymouslyAsync_003Ed__._003C_003Et__builder)).Start<_003CSignInAnonymouslyAsync_003Ed__14>(ref _003CSignInAnonymouslyAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CSignInAnonymouslyAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CSignInWithEmailAndPasswordAsync_003Ed__15))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<IFirebaseUser> SignInWithEmailAndPasswordAsync(string email, string password)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			IFirebaseUser user = (CurrentUser = await _firebaseAuth.SignInWithEmailAndPasswordAsync(email, password, false));
			this.UserChanged?.Invoke((object)this, user);
			return user;
		}
		catch
		{
			CurrentUser = null;
			throw;
		}
	}

	[AsyncStateMachine(typeof(_003CSignInWithGoogle_003Ed__16))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<IFirebaseUser> SignInWithGoogle()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			throw new NotImplementedException();
		}
		catch (FirebaseAuthException val)
		{
			FirebaseAuthException val2 = val;
			FirebaseAuthException ex2 = val2;
			Console.WriteLine(((global::System.Exception)(object)ex2).Message);
			CurrentUser = null;
			throw;
		}
		catch (global::System.Exception ex3)
		{
			global::System.Exception ex = ex3;
			Console.WriteLine(ex.Message);
			CurrentUser = null;
			throw;
		}
	}

	[AsyncStateMachine(typeof(_003CSignInWithApple_003Ed__17))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<IFirebaseUser> SignInWithApple()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			throw new NotImplementedException();
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine(ex.Message);
			CurrentUser = null;
			throw;
		}
	}

	[AsyncStateMachine(typeof(_003CSignInWithFacebook_003Ed__18))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<IFirebaseUser> SignInWithFacebook()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			throw new NotImplementedException();
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine(ex.Message);
			CurrentUser = null;
			throw;
		}
	}

	[AsyncStateMachine(typeof(_003CCreateUserWithEmailAndPasswordAsync_003Ed__19))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<IFirebaseUser> CreateUserWithEmailAndPasswordAsync(string email, string password)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			IFirebaseUser user = (CurrentUser = await _firebaseAuth.CreateUserAsync(email, password));
			this.UserChanged?.Invoke((object)this, user);
			return user;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine($"User creation failed: {ex}");
			CurrentUser = null;
			throw;
		}
	}

	[AsyncStateMachine(typeof(_003CSignOutAsync_003Ed__20))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task SignOutAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CSignOutAsync_003Ed__20 _003CSignOutAsync_003Ed__ = new _003CSignOutAsync_003Ed__20();
		_003CSignOutAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CSignOutAsync_003Ed__._003C_003E4__this = this;
		_003CSignOutAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CSignOutAsync_003Ed__._003C_003Et__builder)).Start<_003CSignOutAsync_003Ed__20>(ref _003CSignOutAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CSignOutAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CLinkWithEmailAndPasswordAsync_003Ed__21))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<IFirebaseUser> LinkWithEmailAndPasswordAsync(string email, string password)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		FirebaseAuthException ex2 = default(FirebaseAuthException);
		try
		{
			if (CurrentUser == null)
			{
				throw new InvalidOperationException("No authenticated user to link");
			}
			if (!CurrentUser.IsAnonymous)
			{
				throw new InvalidOperationException("Current user is not anonymous - cannot link credentials");
			}
			IFirebaseUser user = (CurrentUser = await _firebaseAuth.LinkWithEmailAndPasswordAsync(email, password));
			this.UserChanged?.Invoke((object)this, user);
			Console.WriteLine("Successfully linked email to anonymous account: " + email);
			return user;
		}
		catch (object obj) when (((Func<bool>)delegate
		{
			// Could not convert BlockContainer to single expression
			object obj2 = ((obj is FirebaseAuthException) ? obj : null);
			global::System.Runtime.CompilerServices.Unsafe.SkipInit(out int result);
			if (obj2 == null)
			{
				result = 0;
			}
			else
			{
				ex2 = (FirebaseAuthException)obj2;
				result = (((global::System.Exception)(object)ex2).Message.Contains("credential-already-in-use") ? 1 : 0);
			}
			return (byte)result != 0;
		}).Invoke())
		{
			Console.WriteLine("Link failed - credential already in use: " + ((global::System.Exception)(object)ex2).Message);
			throw new InvalidOperationException("This email is already associated with another account. Please sign in with that account instead.", (global::System.Exception)(object)ex2);
		}
		catch (global::System.Exception ex3)
		{
			global::System.Exception ex = ex3;
			Console.WriteLine("Link with email failed: " + ex.Message);
			throw;
		}
	}

	[AsyncStateMachine(typeof(_003CLinkWithGoogleAsync_003Ed__22))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<IFirebaseUser> LinkWithGoogleAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		throw new NotImplementedException("Google account linking not yet implemented");
	}

	[AsyncStateMachine(typeof(_003CLinkWithAppleAsync_003Ed__23))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<IFirebaseUser> LinkWithAppleAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		throw new NotImplementedException("Apple account linking not yet implemented");
	}
}
