using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Plugin.Firebase.Auth;
using SpiritSummoner.Application.Enums;
using SpiritSummoner.Application.Services;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Auth;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Entities.Spirits;
using SpiritSummoner.Domain.Interfaces.Services;
using SpiritSummoner.Domain.Repositories;
using SpiritSummoner.Infrastructure.Contracts;
using SpiritSummoner.Infrastructure.Persistence.DTOs.Players;

namespace SpiritSummoner.Application.Auth;

public class RegistrationOrchestrator : IRegistrationOrchestrator
{
	[CompilerGenerated]
	private sealed class _003CCancelRegistrationAsync_003Ed__54 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public RegistrationOrchestrator _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = _003C_003E4__this.RollbackRegistrationAsync(RollbackReason.UserCanceled, "User canceled", null, null, userDocumentCreated: false).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CCancelRegistrationAsync_003Ed__54 _003CCancelRegistrationAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CCancelRegistrationAsync_003Ed__54>(ref awaiter, ref _003CCancelRegistrationAsync_003Ed__);
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
	private sealed class _003CCheckAndResumeRegistrationAsync_003Ed__53 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<RegistrationResumeResult> _003C_003Et__builder;

		public string userId;

		public RegistrationOrchestrator _003C_003E4__this;

		private bool _003CisInProgress_003E5__1;

		private string _003CsavedUserId_003E5__2;

		private int _003CsavedState_003E5__3;

		private int _003CsavedStep_003E5__4;

		private void MoveNext()
		{
			int num = _003C_003E1__state;
			RegistrationResumeResult result;
			try
			{
				_003CisInProgress_003E5__1 = _003C_003E4__this._preferencesService.Get("RegistrationInProgress", defaultValue: false);
				_003CsavedUserId_003E5__2 = _003C_003E4__this._preferencesService.Get("RegistrationUserId", string.Empty);
				if (!_003CisInProgress_003E5__1 || string.IsNullOrEmpty(_003CsavedUserId_003E5__2))
				{
					result = RegistrationResumeResult.NoResume();
				}
				else if (_003CsavedUserId_003E5__2 != userId)
				{
					_003C_003E4__this.ClearPersistedState();
					result = RegistrationResumeResult.NoResume();
				}
				else
				{
					_003C_003E4__this.PendingUserId = _003CsavedUserId_003E5__2;
					_003CsavedState_003E5__3 = _003C_003E4__this._preferencesService.Get("RegistrationState", 0);
					_003C_003E4__this.CurrentState = (RegistrationState)_003CsavedState_003E5__3;
					_003CsavedStep_003E5__4 = _003C_003E4__this._preferencesService.Get("OnboardingStep", 0);
					_003C_003E4__this.CurrentOnboardingStep = (OnboardingStep)_003CsavedStep_003E5__4;
					_003C_003E4__this.IsAnonymousRegistration = _003C_003E4__this._preferencesService.Get("IsAnonymousRegistration", defaultValue: false);
					if (_003C_003E4__this.CurrentOnboardingStep != 0)
					{
						_003C_003E4__this.UpdateDialogueData();
					}
					Console.WriteLine($"Resuming registration for user: {userId}, State: {_003C_003E4__this.CurrentState}, Step: {_003C_003E4__this.CurrentOnboardingStep}");
					result = RegistrationResumeResult.Resume(userId, _003C_003E4__this.CurrentState);
				}
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003CsavedUserId_003E5__2 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CsavedUserId_003E5__2 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCompleteRegistrationAsync_003Ed__51 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<Player>> _003C_003Et__builder;

		public string username;

		public bool isAccountLinked;

		public RegistrationOrchestrator _003C_003E4__this;

		private bool _003CaccountLinked_003E5__1;

		private Player _003CcreatedPlayer_003E5__2;

		private List<PlayerSpirit> _003CcreatedSpirits_003E5__3;

		private bool _003CuserDocumentCreated_003E5__4;

		private object _003C_003Es__5;

		private int _003C_003Es__6;

		private bool _003CusernameExists_003E5__7;

		private bool _003CcreatePlayerResult_003E5__8;

		private FirestoreUserDTO _003CuserDTO_003E5__9;

		private bool _003C_003Es__10;

		private Random _003Crandom_003E5__11;

		private double _003Croll_003E5__12;

		private int _003Cchange_003E5__13;

		private Spirit _003C_003Es__14;

		private Enumerator<PlayerSpirit> _003C_003Es__15;

		private PlayerSpirit _003Cspirit_003E5__16;

		private bool _003C_003Es__17;

		private global::System.Exception _003Cex_003E5__18;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private TaskAwaiter<Spirit?> _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_079d: Unknown result type (might be due to invalid IL or missing references)
			//IL_07a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_07d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_07dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_07e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_07b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_07b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0130: Unknown result type (might be due to invalid IL or missing references)
			//IL_0135: Unknown result type (might be due to invalid IL or missing references)
			//IL_013c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_02de: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0385: Unknown result type (might be due to invalid IL or missing references)
			//IL_038a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0392: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0504: Unknown result type (might be due to invalid IL or missing references)
			//IL_050c: Unknown result type (might be due to invalid IL or missing references)
			//IL_05a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_05aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_05b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_067f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0684: Unknown result type (might be due to invalid IL or missing references)
			//IL_068c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0112: Unknown result type (might be due to invalid IL or missing references)
			//IL_0188: Unknown result type (might be due to invalid IL or missing references)
			//IL_018d: Unknown result type (might be due to invalid IL or missing references)
			//IL_034b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0350: Unknown result type (might be due to invalid IL or missing references)
			//IL_056b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0570: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0447: Unknown result type (might be due to invalid IL or missing references)
			//IL_044c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0365: Unknown result type (might be due to invalid IL or missing references)
			//IL_0367: Unknown result type (might be due to invalid IL or missing references)
			//IL_0585: Unknown result type (might be due to invalid IL or missing references)
			//IL_0587: Unknown result type (might be due to invalid IL or missing references)
			//IL_0224: Unknown result type (might be due to invalid IL or missing references)
			//IL_022e: Expected O, but got Unknown
			//IL_0645: Unknown result type (might be due to invalid IL or missing references)
			//IL_064a: Unknown result type (might be due to invalid IL or missing references)
			//IL_065f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0661: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_04a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_04c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_02be: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_04df: Unknown result type (might be due to invalid IL or missing references)
			//IL_04e1: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<Player> result;
			try
			{
				if ((uint)num <= 6u)
				{
					goto IL_009d;
				}
				TaskAwaiter awaiter;
				if (num == 7)
				{
					awaiter = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_07f3;
				}
				if (_003C_003E4__this.CurrentState == RegistrationState.AwaitingUsername && !string.IsNullOrEmpty(_003C_003E4__this.PendingUserId))
				{
					_003C_003E4__this.CurrentState = RegistrationState.CreatingPlayer;
					_003CaccountLinked_003E5__1 = isAccountLinked || !_003C_003E4__this.IsAnonymousRegistration;
					_003CcreatedPlayer_003E5__2 = null;
					_003CcreatedSpirits_003E5__3 = null;
					_003CuserDocumentCreated_003E5__4 = false;
					_003C_003Es__6 = 0;
					goto IL_009d;
				}
				result = Result<Player>.FailureResult("Registration not in correct state");
				goto end_IL_0007;
				IL_070d:
				int num2 = _003C_003Es__6;
				if (num2 == 1)
				{
					_003Cex_003E5__18 = (global::System.Exception)_003C_003Es__5;
					Console.WriteLine("Registration failed: " + _003Cex_003E5__18.Message);
					Console.WriteLine(_003Cex_003E5__18.StackTrace);
					awaiter = _003C_003E4__this.RollbackRegistrationAsync(RollbackReason.SystemError, "Registration error: " + _003Cex_003E5__18.Message, _003CcreatedPlayer_003E5__2, _003CcreatedSpirits_003E5__3?[0], _003CuserDocumentCreated_003E5__4).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 7);
						_003C_003Eu__2 = awaiter;
						_003CCompleteRegistrationAsync_003Ed__51 _003CCompleteRegistrationAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CCompleteRegistrationAsync_003Ed__51>(ref awaiter, ref _003CCompleteRegistrationAsync_003Ed__);
						return;
					}
					goto IL_07f3;
				}
				_003C_003Es__5 = null;
				_003CcreatedPlayer_003E5__2 = null;
				_003CcreatedSpirits_003E5__3 = null;
				throw null;
				IL_07f3:
				((TaskAwaiter)(ref awaiter)).GetResult();
				result = Result<Player>.FailureResult("Registration error: " + _003Cex_003E5__18.Message);
				goto end_IL_0007;
				IL_009d:
				try
				{
					TaskAwaiter<bool> awaiter8;
					TaskAwaiter awaiter7;
					TaskAwaiter<Spirit> awaiter6;
					TaskAwaiter awaiter5;
					TaskAwaiter<bool> awaiter4;
					TaskAwaiter awaiter3;
					TaskAwaiter awaiter2;
					List<PlayerSpirit> obj;
					FirestoreUserDTO firestoreUserDTO;
					IFirebaseUser currentUser;
					switch (num)
					{
					default:
						awaiter8 = _003C_003E4__this._playerRepository.CheckUsernameExistsAsync(username).GetAwaiter();
						if (!awaiter8.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter8;
							_003CCompleteRegistrationAsync_003Ed__51 _003CCompleteRegistrationAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CCompleteRegistrationAsync_003Ed__51>(ref awaiter8, ref _003CCompleteRegistrationAsync_003Ed__);
							return;
						}
						goto IL_014b;
					case 0:
						awaiter8 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
						goto IL_014b;
					case 1:
						awaiter7 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_01de;
					case 2:
						awaiter6 = _003C_003Eu__3;
						_003C_003Eu__3 = default(TaskAwaiter<Spirit>);
						num = (_003C_003E1__state = -1);
						goto IL_02fa;
					case 3:
						awaiter5 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_03a1;
					case 4:
						awaiter4 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
						goto IL_051b;
					case 5:
						awaiter3 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_05c1;
					case 6:
						{
							awaiter2 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							break;
						}
						IL_03c1:
						obj = new List<PlayerSpirit>(1);
						obj.Add(_003C_003E4__this._playerSpiritFactory.CreateStarterSpirit(username, _003C_003E4__this.starterSpiritTemplate));
						_003CcreatedSpirits_003E5__3 = obj;
						_003CcreatedPlayer_003E5__2 = _003C_003E4__this._playerFactory.CreateNewPlayer(_003C_003E4__this.PendingUserId, username, _003CcreatedSpirits_003E5__3[0].PlayerSpiritID);
						_003CcreatedPlayer_003E5__2.SetAccountLinked(_003CaccountLinked_003E5__1);
						_003C_003Es__15 = _003CcreatedSpirits_003E5__3.GetEnumerator();
						try
						{
							while (_003C_003Es__15.MoveNext())
							{
								_003Cspirit_003E5__16 = _003C_003Es__15.Current;
								_003CcreatedPlayer_003E5__2.AddSpirit(_003Cspirit_003E5__16);
								_003Cspirit_003E5__16 = null;
							}
						}
						finally
						{
							if (num < 0)
							{
								((global::System.IDisposable)_003C_003Es__15).Dispose();
							}
						}
						_003C_003Es__15 = default(Enumerator<PlayerSpirit>);
						awaiter4 = _003C_003E4__this._playerRepository.CreatePlayerAsync(_003CcreatedPlayer_003E5__2).GetAwaiter();
						if (!awaiter4.IsCompleted)
						{
							num = (_003C_003E1__state = 4);
							_003C_003Eu__1 = awaiter4;
							_003CCompleteRegistrationAsync_003Ed__51 _003CCompleteRegistrationAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CCompleteRegistrationAsync_003Ed__51>(ref awaiter4, ref _003CCompleteRegistrationAsync_003Ed__);
							return;
						}
						goto IL_051b;
						IL_014b:
						_003C_003Es__10 = awaiter8.GetResult();
						_003CusernameExists_003E5__7 = _003C_003Es__10;
						if (_003CusernameExists_003E5__7)
						{
							awaiter7 = _003C_003E4__this.RollbackRegistrationAsync(RollbackReason.UsernameConflict, "Username already exists", null, null, userDocumentCreated: false).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter7)).IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__2 = awaiter7;
								_003CCompleteRegistrationAsync_003Ed__51 _003CCompleteRegistrationAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CCompleteRegistrationAsync_003Ed__51>(ref awaiter7, ref _003CCompleteRegistrationAsync_003Ed__);
								return;
							}
							goto IL_01de;
						}
						if (string.IsNullOrEmpty(_003C_003E4__this.finalSpiritId) || _003C_003E4__this.starterSpiritTemplate != null)
						{
							_003Crandom_003E5__11 = new Random();
							_003Croll_003E5__12 = _003Crandom_003E5__11.NextDouble();
							_003Cchange_003E5__13 = ((!(_003Croll_003E5__12 < 0.495)) ? ((_003Croll_003E5__12 < 0.99) ? 1 : 2) : 0);
							_003C_003E4__this.finalSpiritId = StarterSpiritId[_003Cchange_003E5__13];
							awaiter6 = _003C_003E4__this._spiritRepository.GetByIdAsync(_003C_003E4__this.finalSpiritId).GetAwaiter();
							if (!awaiter6.IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__3 = awaiter6;
								_003CCompleteRegistrationAsync_003Ed__51 _003CCompleteRegistrationAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Spirit>, _003CCompleteRegistrationAsync_003Ed__51>(ref awaiter6, ref _003CCompleteRegistrationAsync_003Ed__);
								return;
							}
							goto IL_02fa;
						}
						goto IL_03c1;
						IL_02fa:
						_003C_003Es__14 = awaiter6.GetResult();
						_003C_003E4__this.starterSpiritTemplate = _003C_003Es__14;
						_003C_003Es__14 = null;
						if (_003C_003E4__this.starterSpiritTemplate == null)
						{
							awaiter5 = _003C_003E4__this.RollbackRegistrationAsync(RollbackReason.SystemError, "Starter spirit template not found", null, null, userDocumentCreated: false).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter5)).IsCompleted)
							{
								num = (_003C_003E1__state = 3);
								_003C_003Eu__2 = awaiter5;
								_003CCompleteRegistrationAsync_003Ed__51 _003CCompleteRegistrationAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CCompleteRegistrationAsync_003Ed__51>(ref awaiter5, ref _003CCompleteRegistrationAsync_003Ed__);
								return;
							}
							goto IL_03a1;
						}
						_003Crandom_003E5__11 = null;
						goto IL_03c1;
						IL_03a1:
						((TaskAwaiter)(ref awaiter5)).GetResult();
						result = Result<Player>.FailureResult("Failed to load starter spirit");
						goto end_IL_009d;
						IL_01de:
						((TaskAwaiter)(ref awaiter7)).GetResult();
						result = Result<Player>.FailureResult("Username already exists");
						goto end_IL_009d;
						IL_05c1:
						((TaskAwaiter)(ref awaiter3)).GetResult();
						result = Result<Player>.FailureResult("Failed to create player document");
						goto end_IL_009d;
						IL_051b:
						_003C_003Es__17 = awaiter4.GetResult();
						_003CcreatePlayerResult_003E5__8 = _003C_003Es__17;
						if (!_003CcreatePlayerResult_003E5__8)
						{
							awaiter3 = _003C_003E4__this.RollbackRegistrationAsync(RollbackReason.SystemError, "Failed to persist player", _003CcreatedPlayer_003E5__2, _003CcreatedSpirits_003E5__3[0], userDocumentCreated: false).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 5);
								_003C_003Eu__2 = awaiter3;
								_003CCompleteRegistrationAsync_003Ed__51 _003CCompleteRegistrationAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CCompleteRegistrationAsync_003Ed__51>(ref awaiter3, ref _003CCompleteRegistrationAsync_003Ed__);
								return;
							}
							goto IL_05c1;
						}
						firestoreUserDTO = new FirestoreUserDTO();
						currentUser = _003C_003E4__this._authService.CurrentUser;
						firestoreUserDTO.Email = ((currentUser != null) ? currentUser.Email : null) ?? string.Empty;
						firestoreUserDTO.UserID = _003C_003E4__this.PendingUserId;
						firestoreUserDTO.Username = username;
						_003CuserDTO_003E5__9 = firestoreUserDTO;
						awaiter2 = _003C_003E4__this._playerRepository.CreateUserAsync(_003CuserDTO_003E5__9).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 6);
							_003C_003Eu__2 = awaiter2;
							_003CCompleteRegistrationAsync_003Ed__51 _003CCompleteRegistrationAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CCompleteRegistrationAsync_003Ed__51>(ref awaiter2, ref _003CCompleteRegistrationAsync_003Ed__);
							return;
						}
						break;
					}
					((TaskAwaiter)(ref awaiter2)).GetResult();
					_003CuserDocumentCreated_003E5__4 = true;
					_003C_003E4__this._playerStateService.SetCurrentSession(_003CcreatedPlayer_003E5__2);
					_003C_003E4__this.Username = username;
					Console.WriteLine("Player created successfully: " + username);
					result = Result<Player>.SuccessResult(_003CcreatedPlayer_003E5__2);
					end_IL_009d:;
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__5 = ex;
					_003C_003Es__6 = 1;
					goto IL_070d;
				}
				end_IL_0007:;
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
	private sealed class _003CLoadStarterSpiritsAsync_003Ed__52 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public RegistrationOrchestrator _003C_003E4__this;

		private Random _003Crandom_003E5__1;

		private double _003Croll_003E5__2;

		private int _003Cchange_003E5__3;

		private Spirit _003C_003Es__4;

		private StarterSpiritData _003Cspirit_003E5__5;

		private TaskAwaiter<Spirit?> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Expected O, but got Unknown
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter<Spirit> awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Spirit>);
					num = (_003C_003E1__state = -1);
					goto IL_0126;
				}
				if (_003C_003E4__this.starterSpiritTemplate == null || !(_003C_003E4__this.StarterSpirit != null))
				{
					if (_003C_003E4__this.starterSpiritTemplate == null)
					{
						_003Crandom_003E5__1 = new Random();
						_003Croll_003E5__2 = _003Crandom_003E5__1.NextDouble();
						_003Cchange_003E5__3 = ((!(_003Croll_003E5__2 < 0.495)) ? ((_003Croll_003E5__2 < 0.99) ? 1 : 2) : 0);
						_003C_003E4__this.finalSpiritId = StarterSpiritId[_003Cchange_003E5__3];
						awaiter = _003C_003E4__this._spiritRepository.GetByIdAsync(_003C_003E4__this.finalSpiritId).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CLoadStarterSpiritsAsync_003Ed__52 _003CLoadStarterSpiritsAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Spirit>, _003CLoadStarterSpiritsAsync_003Ed__52>(ref awaiter, ref _003CLoadStarterSpiritsAsync_003Ed__);
							return;
						}
						goto IL_0126;
					}
					goto IL_0153;
				}
				goto end_IL_0007;
				IL_0126:
				_003C_003Es__4 = awaiter.GetResult();
				_003C_003E4__this.starterSpiritTemplate = _003C_003Es__4;
				_003C_003Es__4 = null;
				_003Crandom_003E5__1 = null;
				goto IL_0153;
				IL_0153:
				if (_003C_003E4__this.starterSpiritTemplate != null)
				{
					_003Cspirit_003E5__5 = new StarterSpiritData(_003C_003E4__this.starterSpiritTemplate.Name ?? "Unknown", _003C_003E4__this.starterSpiritTemplate.Image ?? "placeholder.png", GetSpiritDescription(_003C_003E4__this.starterSpiritTemplate.Name), 1, ((object)_003C_003E4__this.starterSpiritTemplate.Type1).ToString(), ((object)_003C_003E4__this.starterSpiritTemplate.Type2).ToString());
					_003C_003E4__this.StarterSpirit = _003Cspirit_003E5__5;
					_003Cspirit_003E5__5 = null;
				}
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
	private sealed class _003CRollbackRegistrationAsync_003Ed__61 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public RollbackReason reason;

		public string errorMessage;

		public Player createdPlayer;

		public PlayerSpirit createdSpirit;

		public bool userDocumentCreated;

		public RegistrationOrchestrator _003C_003E4__this;

		private bool _003CshouldDeleteAuth_003E5__1;

		private FirestoreUserDTO _003CuserDTO_003E5__2;

		private global::System.Exception _003Cex_003E5__3;

		private global::System.Exception _003Cex_003E5__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<bool> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			//IL_010c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01af: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num != 0)
				{
					if (num == 1)
					{
						goto IL_018b;
					}
					Console.WriteLine($"Rolling back registration. Reason: {reason}, Message: {errorMessage}");
					if (!userDocumentCreated || string.IsNullOrEmpty(_003C_003E4__this.PendingUserId))
					{
						goto IL_0162;
					}
				}
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						_003CuserDTO_003E5__2 = new FirestoreUserDTO
						{
							UserID = _003C_003E4__this.PendingUserId
						};
						awaiter = _003C_003E4__this._playerRepository.DeleteUserAsync(_003CuserDTO_003E5__2).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CRollbackRegistrationAsync_003Ed__61 _003CRollbackRegistrationAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRollbackRegistrationAsync_003Ed__61>(ref awaiter, ref _003CRollbackRegistrationAsync_003Ed__);
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
					Console.WriteLine("Deleted user document during rollback");
					_003CuserDTO_003E5__2 = null;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine("Failed to delete user document: " + _003Cex_003E5__3.Message);
				}
				goto IL_0162;
				IL_0162:
				if (createdPlayer != null && !string.IsNullOrEmpty(createdPlayer.PlayerID))
				{
					goto IL_018b;
				}
				goto IL_0245;
				IL_0245:
				_003CshouldDeleteAuth_003E5__1 = reason == RollbackReason.UserCanceled || reason == RollbackReason.SystemError;
				if (_003CshouldDeleteAuth_003E5__1)
				{
					try
					{
						if (_003C_003E4__this._authService.CurrentUser != null)
						{
							Console.WriteLine($"Deleted Firebase auth user during rollback (reason: {reason})");
						}
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__5 = ex;
						Console.WriteLine("Failed to delete auth user: " + _003Cex_003E5__5.Message);
					}
					_003C_003E4__this.CurrentState = RegistrationState.Failed;
					_003C_003E4__this.Reset();
				}
				else if (reason == RollbackReason.UsernameConflict)
				{
					Console.WriteLine("Username conflict - keeping Firebase auth user for retry");
					_003C_003E4__this.CurrentState = RegistrationState.AwaitingUsername;
					Console.WriteLine($"Ready for retry. PendingUserId: {_003C_003E4__this.PendingUserId}, State: {_003C_003E4__this.CurrentState}");
				}
				goto end_IL_0007;
				IL_018b:
				try
				{
					TaskAwaiter<bool> awaiter2;
					if (num != 1)
					{
						awaiter2 = _003C_003E4__this._playerRepository.DeletePlayerAsync(createdPlayer.PlayerID).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter2;
							_003CRollbackRegistrationAsync_003Ed__61 _003CRollbackRegistrationAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CRollbackRegistrationAsync_003Ed__61>(ref awaiter2, ref _003CRollbackRegistrationAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
					}
					awaiter2.GetResult();
					Console.WriteLine("Deleted player document during rollback");
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__4 = ex;
					Console.WriteLine("Failed to delete player document: " + _003Cex_003E5__4.Message);
				}
				goto IL_0245;
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

	private readonly IPlayerFactory _playerFactory;

	private readonly IPlayerSpiritFactory _playerSpiritFactory;

	private readonly IPlayerRepository _playerRepository;

	private readonly ISpiritRepository _spiritRepository;

	private readonly IPlayerStateService _playerStateService;

	private readonly IPreferencesService _preferencesService;

	private readonly IAuthService _authService;

	private const string RegistrationInProgressKey = "RegistrationInProgress";

	private const string RegistrationUserIdKey = "RegistrationUserId";

	private const string RegistrationStateKey = "RegistrationState";

	private const string OnboardingStepKey = "OnboardingStep";

	private const string IsAnonymousRegistrationKey = "IsAnonymousRegistration";

	private static readonly List<string> StarterSpiritId;

	private string finalSpiritId = string.Empty;

	private Spirit? starterSpiritTemplate;

	private static readonly Dictionary<OnboardingStep, ValueTuple<string, string, string, string?>> DialogueContent;

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public RegistrationState CurrentState
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	} = RegistrationState.NotStarted;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public OnboardingStep CurrentOnboardingStep
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	} = OnboardingStep.None;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? PendingUserId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? Username
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public OnboardingDialogueData? CurrentDialogueData
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public StarterSpiritData? StarterSpirit
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool IsAnonymousRegistration
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	} = false;


	public bool IsInOnboarding
	{
		get
		{
			RegistrationState currentState = CurrentState;
			if (currentState == RegistrationState.OnboardingPreUsername || currentState == RegistrationState.OnboardingPostUsername)
			{
				return true;
			}
			return false;
		}
	}

	public RegistrationOrchestrator(IPlayerFactory playerFactory, IPlayerSpiritFactory playerSpiritFactory, IPlayerRepository playerRepository, ISpiritRepository spiritRepository, IPlayerStateService playerStateService, IPreferencesService preferencesService, IAuthService authService)
	{
		_playerFactory = playerFactory;
		_playerSpiritFactory = playerSpiritFactory;
		_playerRepository = playerRepository;
		_spiritRepository = spiritRepository;
		_playerStateService = playerStateService;
		_preferencesService = preferencesService;
		_authService = authService;
	}

	public global::System.Threading.Tasks.Task<Result<bool>> StartRegistrationAsync(string userId, bool isAnonymous = false)
	{
		PendingUserId = userId;
		IsAnonymousRegistration = isAnonymous;
		CurrentState = RegistrationState.OnboardingPreUsername;
		CurrentOnboardingStep = OnboardingStep.IntroDialogue1;
		UpdateDialogueData();
		Console.WriteLine($"Registration started for user: {userId} (anonymous: {isAnonymous}), starting pre-username onboarding");
		PersistState();
		return global::System.Threading.Tasks.Task.FromResult<Result<bool>>(Result<bool>.SuccessResult(data: true));
	}

	public NavigationRoute AcceptTermsAndStartOnboarding()
	{
		if (CurrentState != RegistrationState.AwaitingTermsAcceptance)
		{
			Console.WriteLine($"Warning: AcceptTermsAndStartOnboarding called in invalid state: {CurrentState}");
			return NavigationRoute.Login;
		}
		CurrentState = RegistrationState.OnboardingPreUsername;
		CurrentOnboardingStep = OnboardingStep.IntroDialogue1;
		UpdateDialogueData();
		PersistState();
		Console.WriteLine($"Terms accepted, starting pre-username onboarding: {CurrentOnboardingStep}");
		return NavigationRoute.OnboardingDialogue;
	}

	public OnboardingNavigationResult AdvanceOnboarding()
	{
		OnboardingStep nextOnboardingStep = GetNextOnboardingStep();
		if (nextOnboardingStep == OnboardingStep.None)
		{
			if (CurrentState == RegistrationState.OnboardingPreUsername)
			{
				CurrentState = RegistrationState.AwaitingUsername;
				CurrentOnboardingStep = OnboardingStep.None;
				PersistState();
				Console.WriteLine("Pre-username onboarding complete, navigating to username selection");
				return OnboardingNavigationResult.ToUsernameSelection();
			}
			if (CurrentState == RegistrationState.OnboardingPostUsername)
			{
				CurrentState = RegistrationState.Complete;
				CurrentOnboardingStep = OnboardingStep.None;
				ClearPersistedState();
				Console.WriteLine("Onboarding complete, registration finished");
				return OnboardingNavigationResult.Complete();
			}
		}
		CurrentOnboardingStep = nextOnboardingStep;
		UpdateDialogueData();
		PersistState();
		NavigationRoute route = ((CurrentOnboardingStep == OnboardingStep.FirstSpiritsCard) ? NavigationRoute.OnboardingSpirits : NavigationRoute.OnboardingDialogue);
		Console.WriteLine($"Advancing onboarding to: {CurrentOnboardingStep}");
		return OnboardingNavigationResult.Navigate(route);
	}

	public NavigationRoute StartPostUsernameOnboarding(string username)
	{
		Username = username;
		CurrentState = RegistrationState.OnboardingPostUsername;
		CurrentOnboardingStep = OnboardingStep.YourSummonerIdDialogue;
		UpdateDialogueData();
		PersistState();
		Console.WriteLine("Starting post-username onboarding for: " + username);
		return NavigationRoute.OnboardingDialogue;
	}

	[AsyncStateMachine(typeof(_003CCompleteRegistrationAsync_003Ed__51))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<Player>> CompleteRegistrationAsync(string username, bool isAccountLinked = true)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (CurrentState != RegistrationState.AwaitingUsername || string.IsNullOrEmpty(PendingUserId))
		{
			return Result<Player>.FailureResult("Registration not in correct state");
		}
		CurrentState = RegistrationState.CreatingPlayer;
		bool accountLinked = isAccountLinked || !IsAnonymousRegistration;
		Player createdPlayer = null;
		List<PlayerSpirit> createdSpirits = null;
		bool userDocumentCreated = false;
		try
		{
			if (await _playerRepository.CheckUsernameExistsAsync(username))
			{
				await RollbackRegistrationAsync(RollbackReason.UsernameConflict, "Username already exists", null, null, userDocumentCreated: false);
				return Result<Player>.FailureResult("Username already exists");
			}
			if (string.IsNullOrEmpty(finalSpiritId) || starterSpiritTemplate != null)
			{
				Random random = new Random();
				double roll = random.NextDouble();
				int change = ((!(roll < 0.495)) ? ((roll < 0.99) ? 1 : 2) : 0);
				finalSpiritId = StarterSpiritId[change];
				starterSpiritTemplate = await _spiritRepository.GetByIdAsync(finalSpiritId);
				if (starterSpiritTemplate == null)
				{
					await RollbackRegistrationAsync(RollbackReason.SystemError, "Starter spirit template not found", null, null, userDocumentCreated: false);
					return Result<Player>.FailureResult("Failed to load starter spirit");
				}
			}
			List<PlayerSpirit> obj = new List<PlayerSpirit>(1);
			obj.Add(_playerSpiritFactory.CreateStarterSpirit(username, starterSpiritTemplate));
			createdSpirits = obj;
			createdPlayer = _playerFactory.CreateNewPlayer(PendingUserId, username, createdSpirits[0].PlayerSpiritID);
			createdPlayer.SetAccountLinked(accountLinked);
			Enumerator<PlayerSpirit> enumerator = createdSpirits.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					PlayerSpirit spirit = enumerator.Current;
					createdPlayer.AddSpirit(spirit);
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator).Dispose();
			}
			if (!(await _playerRepository.CreatePlayerAsync(createdPlayer)))
			{
				await RollbackRegistrationAsync(RollbackReason.SystemError, "Failed to persist player", createdPlayer, createdSpirits[0], userDocumentCreated: false);
				return Result<Player>.FailureResult("Failed to create player document");
			}
			FirestoreUserDTO firestoreUserDTO = new FirestoreUserDTO();
			IFirebaseUser currentUser = _authService.CurrentUser;
			firestoreUserDTO.Email = ((currentUser != null) ? currentUser.Email : null) ?? string.Empty;
			firestoreUserDTO.UserID = PendingUserId;
			firestoreUserDTO.Username = username;
			FirestoreUserDTO userDTO = firestoreUserDTO;
			await _playerRepository.CreateUserAsync(userDTO);
			userDocumentCreated = true;
			_playerStateService.SetCurrentSession(createdPlayer);
			Username = username;
			Console.WriteLine("Player created successfully: " + username);
			return Result<Player>.SuccessResult(createdPlayer);
		}
		catch (global::System.Exception ex)
		{
			Console.WriteLine("Registration failed: " + ex.Message);
			Console.WriteLine(ex.StackTrace);
			await RollbackRegistrationAsync(RollbackReason.SystemError, "Registration error: " + ex.Message, createdPlayer, createdSpirits?[0], userDocumentCreated);
			return Result<Player>.FailureResult("Registration error: " + ex.Message);
		}
	}

	[AsyncStateMachine(typeof(_003CLoadStarterSpiritsAsync_003Ed__52))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task LoadStarterSpiritsAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadStarterSpiritsAsync_003Ed__52 _003CLoadStarterSpiritsAsync_003Ed__ = new _003CLoadStarterSpiritsAsync_003Ed__52();
		_003CLoadStarterSpiritsAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadStarterSpiritsAsync_003Ed__._003C_003E4__this = this;
		_003CLoadStarterSpiritsAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadStarterSpiritsAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadStarterSpiritsAsync_003Ed__52>(ref _003CLoadStarterSpiritsAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadStarterSpiritsAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CCheckAndResumeRegistrationAsync_003Ed__53))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<RegistrationResumeResult> CheckAndResumeRegistrationAsync(string userId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		bool isInProgress = _preferencesService.Get("RegistrationInProgress", defaultValue: false);
		string savedUserId = _preferencesService.Get("RegistrationUserId", string.Empty);
		if (!isInProgress || string.IsNullOrEmpty(savedUserId))
		{
			return RegistrationResumeResult.NoResume();
		}
		if (savedUserId != userId)
		{
			ClearPersistedState();
			return RegistrationResumeResult.NoResume();
		}
		PendingUserId = savedUserId;
		int savedState = _preferencesService.Get("RegistrationState", 0);
		CurrentState = (RegistrationState)savedState;
		int savedStep = _preferencesService.Get("OnboardingStep", 0);
		CurrentOnboardingStep = (OnboardingStep)savedStep;
		IsAnonymousRegistration = _preferencesService.Get("IsAnonymousRegistration", defaultValue: false);
		if (CurrentOnboardingStep != 0)
		{
			UpdateDialogueData();
		}
		Console.WriteLine($"Resuming registration for user: {userId}, State: {CurrentState}, Step: {CurrentOnboardingStep}");
		return RegistrationResumeResult.Resume(userId, CurrentState);
	}

	[AsyncStateMachine(typeof(_003CCancelRegistrationAsync_003Ed__54))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task CancelRegistrationAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CCancelRegistrationAsync_003Ed__54 _003CCancelRegistrationAsync_003Ed__ = new _003CCancelRegistrationAsync_003Ed__54();
		_003CCancelRegistrationAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CCancelRegistrationAsync_003Ed__._003C_003E4__this = this;
		_003CCancelRegistrationAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CCancelRegistrationAsync_003Ed__._003C_003Et__builder)).Start<_003CCancelRegistrationAsync_003Ed__54>(ref _003CCancelRegistrationAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CCancelRegistrationAsync_003Ed__._003C_003Et__builder)).Task;
	}

	public void Reset()
	{
		PendingUserId = null;
		Username = null;
		CurrentState = RegistrationState.NotStarted;
		CurrentOnboardingStep = OnboardingStep.None;
		CurrentDialogueData = null;
		StarterSpirit = null;
		IsAnonymousRegistration = false;
		ClearPersistedState();
		Console.WriteLine("Registration reset");
	}

	private OnboardingStep GetNextOnboardingStep()
	{
		OnboardingStep currentOnboardingStep = CurrentOnboardingStep;
		if (1 == 0)
		{
		}
		OnboardingStep result = currentOnboardingStep switch
		{
			OnboardingStep.IntroDialogue1 => OnboardingStep.IntroDialogue2, 
			OnboardingStep.IntroDialogue2 => OnboardingStep.None, 
			OnboardingStep.YourSummonerIdDialogue => OnboardingStep.FirstSpiritsCard, 
			OnboardingStep.FirstSpiritsCard => OnboardingStep.StoryDialogue1, 
			OnboardingStep.StoryDialogue1 => OnboardingStep.StoryDialogue2, 
			OnboardingStep.StoryDialogue2 => OnboardingStep.StoryDialogue3, 
			OnboardingStep.StoryDialogue3 => OnboardingStep.None, 
			_ => OnboardingStep.None, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	private void UpdateDialogueData()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		ValueTuple<string, string, string, string> val = default(ValueTuple<string, string, string, string>);
		if (DialogueContent.TryGetValue(CurrentOnboardingStep, ref val))
		{
			string text = val.Item2.Replace("{Username}", Username ?? "Summoner");
			CurrentDialogueData = new OnboardingDialogueData(val.Item1, text, val.Item3, val.Item4);
		}
		else
		{
			CurrentDialogueData = null;
		}
	}

	private void PersistState()
	{
		_preferencesService.Set("RegistrationInProgress", value: true);
		_preferencesService.Set("RegistrationUserId", PendingUserId ?? string.Empty);
		_preferencesService.Set("RegistrationState", (int)CurrentState);
		_preferencesService.Set("OnboardingStep", (int)CurrentOnboardingStep);
		_preferencesService.Set("IsAnonymousRegistration", IsAnonymousRegistration);
	}

	private void ClearPersistedState()
	{
		_preferencesService.Remove("RegistrationInProgress");
		_preferencesService.Remove("RegistrationUserId");
		_preferencesService.Remove("RegistrationState");
		_preferencesService.Remove("OnboardingStep");
		_preferencesService.Remove("IsAnonymousRegistration");
	}

	private static string GetSpiritDescription(string? name)
	{
		string text = name?.ToLower();
		if (1 == 0)
		{
		}
		string result = ((text == "dogi") ? "The loyal dog spirit" : ((text == "miki") ? "The cheeky mouse spirit" : ((!(text == "chicki")) ? "A mysterious spirit" : "The speedy bird spirit")));
		if (1 == 0)
		{
		}
		return result;
	}

	[AsyncStateMachine(typeof(_003CRollbackRegistrationAsync_003Ed__61))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task RollbackRegistrationAsync(RollbackReason reason, string? errorMessage, Player? createdPlayer, PlayerSpirit? createdSpirit, bool userDocumentCreated)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CRollbackRegistrationAsync_003Ed__61 _003CRollbackRegistrationAsync_003Ed__ = new _003CRollbackRegistrationAsync_003Ed__61();
		_003CRollbackRegistrationAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CRollbackRegistrationAsync_003Ed__._003C_003E4__this = this;
		_003CRollbackRegistrationAsync_003Ed__.reason = reason;
		_003CRollbackRegistrationAsync_003Ed__.errorMessage = errorMessage;
		_003CRollbackRegistrationAsync_003Ed__.createdPlayer = createdPlayer;
		_003CRollbackRegistrationAsync_003Ed__.createdSpirit = createdSpirit;
		_003CRollbackRegistrationAsync_003Ed__.userDocumentCreated = userDocumentCreated;
		_003CRollbackRegistrationAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CRollbackRegistrationAsync_003Ed__._003C_003Et__builder)).Start<_003CRollbackRegistrationAsync_003Ed__61>(ref _003CRollbackRegistrationAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CRollbackRegistrationAsync_003Ed__._003C_003Et__builder)).Task;
	}

	static RegistrationOrchestrator()
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		int num = 3;
		List<string> obj = new List<string>(num);
		CollectionsMarshal.SetCount<string>(obj, num);
		global::System.Span<string> span = CollectionsMarshal.AsSpan<string>(obj);
		span[0] = "1";
		span[1] = "5";
		span[2] = "4";
		StarterSpiritId = obj;
		DialogueContent = new Dictionary<OnboardingStep, ValueTuple<string, string, string, string>>
		{
			[OnboardingStep.IntroDialogue1] = new ValueTuple<string, string, string, string>("Warden Bryn", "Welcome to Spirit Summoner! This world is full of elemental monsters for you to battle and collect.' Search far and wide for rare, powerful spirits to add to your collection!", "summonerbro.png", "bryn_onboarding.png"),
			[OnboardingStep.IntroDialogue2] = new ValueTuple<string, string, string, string>("Warden Bryn", "To begin, the Summoner Council will collect some basic information from you to fill out your Summoner ID. ", "summonerbro.png", "bryn_onboarding.png"),
			[OnboardingStep.YourSummonerIdDialogue] = new ValueTuple<string, string, string, string>("Warden Bryn", "Excellent choice, {Username}! Now that you have your Summoner ID, you are able to start your adventure, collect spirits, and join guilds. Let's get you started with your first 3 spirits.", "summonerbro.png", "bryn_onboarding.png"),
			[OnboardingStep.StoryDialogue1] = new ValueTuple<string, string, string, string>("Warden Bryn", "Team battles will all be 3-on-3 with summoners curating teams known as Squadrons! Mix and match spirits to make unique and powerful squads. ", "summonerbro.png", "bryn_onboarding.png"),
			[OnboardingStep.StoryDialogue2] = new ValueTuple<string, string, string, string>("Warden Bryn", "I look forward to seeing how you progress as a summoner - good luck!", "summonerbro.png", "bryn_onboarding.png"),
			[OnboardingStep.StoryDialogue3] = new ValueTuple<string, string, string, string>("Warden Bryn", "Now it is your turn, {Username}. Train your spirits, explore the lands, and perhaps one day you will become a legend yourself. Good luck, summoner!", "summonerbro.png", "bryn_onboarding.png")
		};
	}
}
