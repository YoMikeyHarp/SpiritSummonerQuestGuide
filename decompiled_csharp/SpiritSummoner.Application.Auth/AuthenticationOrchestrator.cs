using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.Enums;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Auth;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Repositories;
using SpiritSummoner.Infrastructure.Contracts;

namespace SpiritSummoner.Application.Auth;

public class AuthenticationOrchestrator : IAuthenticationOrchestrator
{
	[CompilerGenerated]
	private sealed class _003CHandleAuthStateChangeAsync_003Ed__9 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<AuthenticationResult> _003C_003Et__builder;

		public string userId;

		public AuthenticationOrchestrator _003C_003E4__this;

		private RegistrationResumeResult _003CresumeResult_003E5__1;

		private bool _003CuserExists_003E5__2;

		private AuthenticationResult _003C_003Es__3;

		private RegistrationResumeResult _003C_003Es__4;

		private bool _003C_003Es__5;

		private global::System.Exception _003Cex_003E5__6;

		private AuthenticationResult _003C_003Es__7;

		private AuthenticationResult _003C_003Es__8;

		private TaskAwaiter<AuthenticationResult> _003C_003Eu__1;

		private TaskAwaiter<RegistrationResumeResult> _003C_003Eu__2;

		private TaskAwaiter<bool> _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_033c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0341: Unknown result type (might be due to invalid IL or missing references)
			//IL_0349: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_03be: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_026b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0270: Unknown result type (might be due to invalid IL or missing references)
			//IL_0278: Unknown result type (might be due to invalid IL or missing references)
			//IL_0231: Unknown result type (might be due to invalid IL or missing references)
			//IL_0236: Unknown result type (might be due to invalid IL or missing references)
			//IL_024b: Unknown result type (might be due to invalid IL or missing references)
			//IL_024d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0382: Unknown result type (might be due to invalid IL or missing references)
			//IL_0387: Unknown result type (might be due to invalid IL or missing references)
			//IL_0302: Unknown result type (might be due to invalid IL or missing references)
			//IL_0307: Unknown result type (might be due to invalid IL or missing references)
			//IL_039c: Unknown result type (might be due to invalid IL or missing references)
			//IL_039e: Unknown result type (might be due to invalid IL or missing references)
			//IL_031c: Unknown result type (might be due to invalid IL or missing references)
			//IL_031e: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			AuthenticationResult result;
			try
			{
				TaskAwaiter<AuthenticationResult> awaiter4;
				TaskAwaiter<RegistrationResumeResult> awaiter3;
				TaskAwaiter<AuthenticationResult> awaiter2;
				TaskAwaiter<AuthenticationResult> awaiter;
				switch (num)
				{
				default:
					if (string.IsNullOrEmpty(userId))
					{
						awaiter4 = _003C_003E4__this.HandleSignOutAsync().GetAwaiter();
						if (!awaiter4.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter4;
							_003CHandleAuthStateChangeAsync_003Ed__9 _003CHandleAuthStateChangeAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<AuthenticationResult>, _003CHandleAuthStateChangeAsync_003Ed__9>(ref awaiter4, ref _003CHandleAuthStateChangeAsync_003Ed__);
							return;
						}
						goto IL_00a8;
					}
					awaiter3 = _003C_003E4__this._registrationOrchestrator.CheckAndResumeRegistrationAsync(userId).GetAwaiter();
					if (!awaiter3.IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter3;
						_003CHandleAuthStateChangeAsync_003Ed__9 _003CHandleAuthStateChangeAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<RegistrationResumeResult>, _003CHandleAuthStateChangeAsync_003Ed__9>(ref awaiter3, ref _003CHandleAuthStateChangeAsync_003Ed__);
						return;
					}
					goto IL_012d;
				case 0:
					awaiter4 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<AuthenticationResult>);
					num = (_003C_003E1__state = -1);
					goto IL_00a8;
				case 1:
					awaiter3 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter<RegistrationResumeResult>);
					num = (_003C_003E1__state = -1);
					goto IL_012d;
				case 2:
					try
					{
						TaskAwaiter<bool> awaiter5;
						if (num != 2)
						{
							awaiter5 = _003C_003E4__this._playerService.GetUserByIdAsync(userId).GetAwaiter();
							if (!awaiter5.IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__3 = awaiter5;
								_003CHandleAuthStateChangeAsync_003Ed__9 _003CHandleAuthStateChangeAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CHandleAuthStateChangeAsync_003Ed__9>(ref awaiter5, ref _003CHandleAuthStateChangeAsync_003Ed__);
								return;
							}
						}
						else
						{
							awaiter5 = _003C_003Eu__3;
							_003C_003Eu__3 = default(TaskAwaiter<bool>);
							num = (_003C_003E1__state = -1);
						}
						_003C_003Es__5 = awaiter5.GetResult();
						_003CuserExists_003E5__2 = _003C_003Es__5;
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__6 = ex;
						Console.WriteLine("Failed to check user existence (App Check or network error): " + _003Cex_003E5__6.Message);
						result = AuthenticationResult.CreateError("Unable to connect. Please check your connection and try again.", NavigationRoute.Welcome);
						goto end_IL_0007;
					}
					if (!_003CuserExists_003E5__2)
					{
						awaiter2 = _003C_003E4__this.HandleNewUserAsync(userId).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 3);
							_003C_003Eu__1 = awaiter2;
							_003CHandleAuthStateChangeAsync_003Ed__9 _003CHandleAuthStateChangeAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<AuthenticationResult>, _003CHandleAuthStateChangeAsync_003Ed__9>(ref awaiter2, ref _003CHandleAuthStateChangeAsync_003Ed__);
							return;
						}
						goto IL_0358;
					}
					awaiter = _003C_003E4__this.HandleExistingUserAsync(userId).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 4);
						_003C_003Eu__1 = awaiter;
						_003CHandleAuthStateChangeAsync_003Ed__9 _003CHandleAuthStateChangeAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<AuthenticationResult>, _003CHandleAuthStateChangeAsync_003Ed__9>(ref awaiter, ref _003CHandleAuthStateChangeAsync_003Ed__);
						return;
					}
					break;
				case 3:
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<AuthenticationResult>);
					num = (_003C_003E1__state = -1);
					goto IL_0358;
				case 4:
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<AuthenticationResult>);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_0358:
					_003C_003Es__7 = awaiter2.GetResult();
					result = _003C_003Es__7;
					goto end_IL_0007;
					IL_00a8:
					_003C_003Es__3 = awaiter4.GetResult();
					result = _003C_003Es__3;
					goto end_IL_0007;
					IL_012d:
					_003C_003Es__4 = awaiter3.GetResult();
					_003CresumeResult_003E5__1 = _003C_003Es__4;
					_003C_003Es__4 = null;
					if (_003CresumeResult_003E5__1.ShouldResume)
					{
						result = _003C_003E4__this.HandleResumeRegistration(_003CresumeResult_003E5__1);
					}
					else
					{
						if (!_003C_003E4__this.IsInActiveRegistrationFlow())
						{
							_003C_003E4__this.CurrentState = AuthenticationState.CheckingUserExists;
							goto case 2;
						}
						Console.WriteLine($"User in active registration flow (State: {_003C_003E4__this._registrationOrchestrator.CurrentState}) - staying on current page");
						_003C_003E4__this.CurrentState = _003C_003E4__this.GetAuthStateFromRegistrationState();
						result = AuthenticationResult.CreateSuccess(NavigationRoute.Stay, _003C_003E4__this.CurrentState);
					}
					goto end_IL_0007;
				}
				_003C_003Es__8 = awaiter.GetResult();
				result = _003C_003Es__8;
				end_IL_0007:;
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003CresumeResult_003E5__1 = null;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003CresumeResult_003E5__1 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CHandleExistingUserAsync_003Ed__16 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<AuthenticationResult> _003C_003Et__builder;

		public string userId;

		public AuthenticationOrchestrator _003C_003E4__this;

		private Result<Player> _003CsessionResult_003E5__1;

		private Result<Player> _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter<Result<Player>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			AuthenticationResult result;
			try
			{
				if (num != 0)
				{
					Console.WriteLine("Existing user detected - loading session for " + userId);
					_003C_003E4__this.CurrentState = AuthenticationState.LoadingSession;
				}
				try
				{
					TaskAwaiter<Result<Player>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this._sessionOrchestrator.InitializeSessionAsync(userId).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CHandleExistingUserAsync_003Ed__16 _003CHandleExistingUserAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Result<Player>>, _003CHandleExistingUserAsync_003Ed__16>(ref awaiter, ref _003CHandleExistingUserAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Result<Player>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003CsessionResult_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (!_003CsessionResult_003E5__1.Success || _003CsessionResult_003E5__1.Data == null)
					{
						Console.WriteLine("Failed to initialize session: " + _003CsessionResult_003E5__1.ErrorMessage);
						result = AuthenticationResult.CreateError(_003CsessionResult_003E5__1.ErrorMessage ?? "Failed to load player data", NavigationRoute.Login);
					}
					else if (!_003C_003E4__this._sessionOrchestrator.IsSessionValid())
					{
						Console.WriteLine("Session validation failed after loading");
						result = AuthenticationResult.CreateError("Invalid session after loading", NavigationRoute.Login);
					}
					else
					{
						_003C_003E4__this.CurrentState = AuthenticationState.Ready;
						result = AuthenticationResult.CreateSuccess(NavigationRoute.Loading, _003C_003E4__this.CurrentState, showOverlay: true);
					}
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine("Error loading existing user: " + _003Cex_003E5__3.Message);
					result = AuthenticationResult.CreateError("Error loading player data: " + _003Cex_003E5__3.Message, NavigationRoute.Login);
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
	private sealed class _003CHandleNewUserAsync_003Ed__15 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<AuthenticationResult> _003C_003Et__builder;

		public string userId;

		public AuthenticationOrchestrator _003C_003E4__this;

		private bool _003CisAnonymous_003E5__1;

		private Result<bool> _003CstartResult_003E5__2;

		private Result<bool> _003C_003Es__3;

		private TaskAwaiter<Result<bool>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			AuthenticationResult result;
			try
			{
				TaskAwaiter<Result<bool>> awaiter;
				if (num != 0)
				{
					_003CisAnonymous_003E5__1 = _003C_003E4__this._authService.IsCurrentUserAnonymous;
					Console.WriteLine($"New user detected (anonymous: {_003CisAnonymous_003E5__1}) - no Firestore user document for {userId}");
					awaiter = _003C_003E4__this._registrationOrchestrator.StartRegistrationAsync(userId, _003CisAnonymous_003E5__1).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CHandleNewUserAsync_003Ed__15 _003CHandleNewUserAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Result<bool>>, _003CHandleNewUserAsync_003Ed__15>(ref awaiter, ref _003CHandleNewUserAsync_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Result<bool>>);
					num = (_003C_003E1__state = -1);
				}
				_003C_003Es__3 = awaiter.GetResult();
				_003CstartResult_003E5__2 = _003C_003Es__3;
				_003C_003Es__3 = null;
				if (!_003CstartResult_003E5__2.Success)
				{
					result = AuthenticationResult.CreateError(_003CstartResult_003E5__2.ErrorMessage ?? "Failed to start registration", NavigationRoute.Welcome);
				}
				else
				{
					_003C_003E4__this.CurrentState = AuthenticationState.Onboarding;
					result = AuthenticationResult.CreateSuccess(NavigationRoute.OnboardingDialogue, _003C_003E4__this.CurrentState);
				}
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003CstartResult_003E5__2 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CstartResult_003E5__2 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CHandleSignOutAsync_003Ed__13 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<AuthenticationResult> _003C_003Et__builder;

		public AuthenticationOrchestrator _003C_003E4__this;

		private void MoveNext()
		{
			int num = _003C_003E1__state;
			AuthenticationResult result;
			try
			{
				Console.WriteLine("User signed out - navigating to welcome");
				_003C_003E4__this.CurrentState = AuthenticationState.Unauthenticated;
				_003C_003E4__this._registrationOrchestrator.Reset();
				_003C_003E4__this._sessionOrchestrator.ClearSession();
				result = AuthenticationResult.CreateSuccess(NavigationRoute.Welcome, _003C_003E4__this.CurrentState);
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

	private readonly IRegistrationOrchestrator _registrationOrchestrator;

	private readonly ISessionInitializationOrchestrator _sessionOrchestrator;

	private readonly IPlayerRepository _playerService;

	private readonly IAuthService _authService;

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public AuthenticationState CurrentState
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	} = AuthenticationState.Unauthenticated;


	public AuthenticationOrchestrator(IRegistrationOrchestrator registrationOrchestrator, ISessionInitializationOrchestrator sessionOrchestrator, IPlayerRepository playerService, IAuthService authService)
	{
		_registrationOrchestrator = registrationOrchestrator;
		_sessionOrchestrator = sessionOrchestrator;
		_playerService = playerService;
		_authService = authService;
	}

	[AsyncStateMachine(typeof(_003CHandleAuthStateChangeAsync_003Ed__9))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<AuthenticationResult> HandleAuthStateChangeAsync(string? userId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrEmpty(userId))
		{
			return await HandleSignOutAsync();
		}
		RegistrationResumeResult resumeResult = await _registrationOrchestrator.CheckAndResumeRegistrationAsync(userId);
		if (resumeResult.ShouldResume)
		{
			return HandleResumeRegistration(resumeResult);
		}
		if (IsInActiveRegistrationFlow())
		{
			Console.WriteLine($"User in active registration flow (State: {_registrationOrchestrator.CurrentState}) - staying on current page");
			CurrentState = GetAuthStateFromRegistrationState();
			return AuthenticationResult.CreateSuccess(NavigationRoute.Stay, CurrentState);
		}
		CurrentState = AuthenticationState.CheckingUserExists;
		bool userExists;
		try
		{
			userExists = await _playerService.GetUserByIdAsync(userId);
		}
		catch (global::System.Exception ex)
		{
			Console.WriteLine("Failed to check user existence (App Check or network error): " + ex.Message);
			return AuthenticationResult.CreateError("Unable to connect. Please check your connection and try again.", NavigationRoute.Welcome);
		}
		if (!userExists)
		{
			return await HandleNewUserAsync(userId);
		}
		return await HandleExistingUserAsync(userId);
	}

	private bool IsInActiveRegistrationFlow()
	{
		RegistrationState currentState = _registrationOrchestrator.CurrentState;
		if ((uint)(currentState - 3) <= 1u || (uint)(currentState - 6) <= 1u)
		{
			return true;
		}
		return false;
	}

	private AuthenticationState GetAuthStateFromRegistrationState()
	{
		RegistrationState currentState = _registrationOrchestrator.CurrentState;
		if (1 == 0)
		{
		}
		AuthenticationState result = currentState switch
		{
			RegistrationState.OnboardingPreUsername => AuthenticationState.Onboarding, 
			RegistrationState.AwaitingUsername => AuthenticationState.AwaitingUsername, 
			RegistrationState.CreatingPlayer => AuthenticationState.AwaitingUsername, 
			RegistrationState.OnboardingPostUsername => AuthenticationState.Onboarding, 
			_ => AuthenticationState.Unauthenticated, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public void Reset()
	{
		CurrentState = AuthenticationState.Unauthenticated;
		_registrationOrchestrator.Reset();
		_sessionOrchestrator.ClearSession();
	}

	[AsyncStateMachine(typeof(_003CHandleSignOutAsync_003Ed__13))]
	[DebuggerStepThrough]
	private async global::System.Threading.Tasks.Task<AuthenticationResult> HandleSignOutAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		Console.WriteLine("User signed out - navigating to welcome");
		CurrentState = AuthenticationState.Unauthenticated;
		_registrationOrchestrator.Reset();
		_sessionOrchestrator.ClearSession();
		return AuthenticationResult.CreateSuccess(NavigationRoute.Welcome, CurrentState);
	}

	private AuthenticationResult HandleResumeRegistration(RegistrationResumeResult resumeResult)
	{
		Console.WriteLine($"Resuming incomplete registration from previous session. State: {resumeResult.State}");
		RegistrationState state = resumeResult.State;
		if (1 == 0)
		{
		}
		NavigationRoute navigationRoute = state switch
		{
			RegistrationState.OnboardingPreUsername => NavigationRoute.OnboardingDialogue, 
			RegistrationState.OnboardingPostUsername => (_registrationOrchestrator.CurrentOnboardingStep == OnboardingStep.FirstSpiritsCard) ? NavigationRoute.OnboardingSpirits : NavigationRoute.OnboardingDialogue, 
			RegistrationState.AwaitingUsername => NavigationRoute.Login, 
			_ => NavigationRoute.Login, 
		};
		if (1 == 0)
		{
		}
		NavigationRoute route = navigationRoute;
		CurrentState = GetAuthStateFromRegistrationState();
		return AuthenticationResult.CreateSuccess(route, CurrentState);
	}

	[AsyncStateMachine(typeof(_003CHandleNewUserAsync_003Ed__15))]
	[DebuggerStepThrough]
	private async global::System.Threading.Tasks.Task<AuthenticationResult> HandleNewUserAsync(string userId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		bool isAnonymous = _authService.IsCurrentUserAnonymous;
		Console.WriteLine($"New user detected (anonymous: {isAnonymous}) - no Firestore user document for {userId}");
		Result<bool> startResult = await _registrationOrchestrator.StartRegistrationAsync(userId, isAnonymous);
		if (!startResult.Success)
		{
			return AuthenticationResult.CreateError(startResult.ErrorMessage ?? "Failed to start registration", NavigationRoute.Welcome);
		}
		CurrentState = AuthenticationState.Onboarding;
		return AuthenticationResult.CreateSuccess(NavigationRoute.OnboardingDialogue, CurrentState);
	}

	[AsyncStateMachine(typeof(_003CHandleExistingUserAsync_003Ed__16))]
	[DebuggerStepThrough]
	private async global::System.Threading.Tasks.Task<AuthenticationResult> HandleExistingUserAsync(string userId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		Console.WriteLine("Existing user detected - loading session for " + userId);
		CurrentState = AuthenticationState.LoadingSession;
		try
		{
			Result<Player> sessionResult = await _sessionOrchestrator.InitializeSessionAsync(userId);
			if (!sessionResult.Success || sessionResult.Data == null)
			{
				Console.WriteLine("Failed to initialize session: " + sessionResult.ErrorMessage);
				return AuthenticationResult.CreateError(sessionResult.ErrorMessage ?? "Failed to load player data", NavigationRoute.Login);
			}
			if (!_sessionOrchestrator.IsSessionValid())
			{
				Console.WriteLine("Session validation failed after loading");
				return AuthenticationResult.CreateError("Invalid session after loading", NavigationRoute.Login);
			}
			CurrentState = AuthenticationState.Ready;
			return AuthenticationResult.CreateSuccess(NavigationRoute.Loading, CurrentState, showOverlay: true);
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("Error loading existing user: " + ex.Message);
			return AuthenticationResult.CreateError("Error loading player data: " + ex.Message, NavigationRoute.Login);
		}
	}
}
