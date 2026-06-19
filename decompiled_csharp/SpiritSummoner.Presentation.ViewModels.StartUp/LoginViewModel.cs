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
using Microsoft.Extensions.DependencyInjection;
using Plugin.Firebase.Auth;
using SpiritSummoner.Application.Auth;
using SpiritSummoner.Application.Enums;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Auth;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Repositories;
using SpiritSummoner.Infrastructure.Cache;
using SpiritSummoner.Infrastructure.Contracts;
using SpiritSummoner.Presentation.Navigation;
using SpiritSummoner.Presentation.Services;
using SpiritSummoner.Presentation.Views.BottomSheets;
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Presentation.ViewModels.StartUp;

public class LoginViewModel : ObservableObject, ILoadableViewModel
{
	[CompilerGenerated]
	private sealed class _003CCancelRegistration_003Ed__22 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public LoginViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				TaskAwaiter awaiter2;
				if (num != 0)
				{
					if (num == 1)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_00e4;
					}
					awaiter2 = _003C_003E4__this._authService.DeleteUserAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter2;
						_003CCancelRegistration_003Ed__22 _003CCancelRegistration_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CCancelRegistration_003Ed__22>(ref awaiter2, ref _003CCancelRegistration_003Ed__);
						return;
					}
				}
				else
				{
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
				}
				((TaskAwaiter)(ref awaiter2)).GetResult();
				awaiter = _003C_003E4__this._registrationOrchestrator.CancelRegistrationAsync().GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = awaiter;
					_003CCancelRegistration_003Ed__22 _003CCancelRegistration_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CCancelRegistration_003Ed__22>(ref awaiter, ref _003CCancelRegistration_003Ed__);
					return;
				}
				goto IL_00e4;
				IL_00e4:
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003C_003E4__this.IsUsernameSelectionMode = false;
				_003C_003E4__this.ClearFields();
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
	private sealed class _003CConfirmUsername_003Ed__20 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public LoginViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private ConfirmUserNameSheet _003Csheet_003E5__3;

		private bool _003CconfirmUsername_003E5__4;

		private LinkAccountSheet _003ClinkSheet_003E5__5;

		private bool _003CisAccountLinked_003E5__6;

		private RegisterTermsSheet _003CtermsSheet_003E5__7;

		private bool _003CtermsAccepted_003E5__8;

		private Result<Player> _003Cresult_003E5__9;

		private bool _003C_003Es__10;

		private bool _003C_003Es__11;

		private bool _003C_003Es__12;

		private Result<Player> _003C_003Es__13;

		private NavigationRoute _003Croute_003E5__14;

		private string _003CerrorMsg_003E5__15;

		private global::System.Exception _003Cex_003E5__16;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<bool> _003C_003Eu__2;

		private TaskAwaiter<Result<Player>> _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_094f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0954: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0162: Unknown result type (might be due to invalid IL or missing references)
			//IL_0167: Unknown result type (might be due to invalid IL or missing references)
			//IL_016f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0989: Unknown result type (might be due to invalid IL or missing references)
			//IL_098e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0996: Unknown result type (might be due to invalid IL or missing references)
			//IL_096a: Unknown result type (might be due to invalid IL or missing references)
			//IL_096c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_0385: Unknown result type (might be due to invalid IL or missing references)
			//IL_038a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0392: Unknown result type (might be due to invalid IL or missing references)
			//IL_046c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0471: Unknown result type (might be due to invalid IL or missing references)
			//IL_0479: Unknown result type (might be due to invalid IL or missing references)
			//IL_04fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0507: Unknown result type (might be due to invalid IL or missing references)
			//IL_057d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0582: Unknown result type (might be due to invalid IL or missing references)
			//IL_058a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0643: Unknown result type (might be due to invalid IL or missing references)
			//IL_0648: Unknown result type (might be due to invalid IL or missing references)
			//IL_0650: Unknown result type (might be due to invalid IL or missing references)
			//IL_06e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_06e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_06ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_082f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0834: Unknown result type (might be due to invalid IL or missing references)
			//IL_083c: Unknown result type (might be due to invalid IL or missing references)
			//IL_08a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_08a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_08af: Unknown result type (might be due to invalid IL or missing references)
			//IL_0236: Unknown result type (might be due to invalid IL or missing references)
			//IL_0240: Expected O, but got Unknown
			//IL_0268: Unknown result type (might be due to invalid IL or missing references)
			//IL_026d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0868: Unknown result type (might be due to invalid IL or missing references)
			//IL_086d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0282: Unknown result type (might be due to invalid IL or missing references)
			//IL_0284: Unknown result type (might be due to invalid IL or missing references)
			//IL_0129: Unknown result type (might be due to invalid IL or missing references)
			//IL_012e: Unknown result type (might be due to invalid IL or missing references)
			//IL_031a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0324: Expected O, but got Unknown
			//IL_034c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0351: Unknown result type (might be due to invalid IL or missing references)
			//IL_0544: Unknown result type (might be due to invalid IL or missing references)
			//IL_0549: Unknown result type (might be due to invalid IL or missing references)
			//IL_04c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_04c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_060a: Unknown result type (might be due to invalid IL or missing references)
			//IL_060f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0883: Unknown result type (might be due to invalid IL or missing references)
			//IL_0885: Unknown result type (might be due to invalid IL or missing references)
			//IL_0143: Unknown result type (might be due to invalid IL or missing references)
			//IL_0145: Unknown result type (might be due to invalid IL or missing references)
			//IL_0366: Unknown result type (might be due to invalid IL or missing references)
			//IL_0368: Unknown result type (might be due to invalid IL or missing references)
			//IL_0401: Unknown result type (might be due to invalid IL or missing references)
			//IL_040b: Expected O, but got Unknown
			//IL_0433: Unknown result type (might be due to invalid IL or missing references)
			//IL_0438: Unknown result type (might be due to invalid IL or missing references)
			//IL_055e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0560: Unknown result type (might be due to invalid IL or missing references)
			//IL_04db: Unknown result type (might be due to invalid IL or missing references)
			//IL_04dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_06a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_06ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_0624: Unknown result type (might be due to invalid IL or missing references)
			//IL_0626: Unknown result type (might be due to invalid IL or missing references)
			//IL_044d: Unknown result type (might be due to invalid IL or missing references)
			//IL_044f: Unknown result type (might be due to invalid IL or missing references)
			//IL_06c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_06c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_07f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_07fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0810: Unknown result type (might be due to invalid IL or missing references)
			//IL_0812: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter3;
				TaskAwaiter awaiter2;
				TaskAwaiter awaiter;
				int num2;
				switch (num)
				{
				default:
					if (_003C_003E4__this.Username != _003C_003E4__this.VerifyUsername)
					{
						awaiter3 = _003C_003E4__this.ShowAlert("Validation Error", "Usernames don't match").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter3;
							_003CConfirmUsername_003Ed__20 _003CConfirmUsername_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CConfirmUsername_003Ed__20>(ref awaiter3, ref _003CConfirmUsername_003Ed__);
							return;
						}
						goto IL_00d8;
					}
					if (string.IsNullOrWhiteSpace(_003C_003E4__this.Username) || _003C_003E4__this.Username.Length < 3)
					{
						awaiter2 = _003C_003E4__this.ShowAlert("Validation Error", "Username must be at least 3 characters").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter2;
							_003CConfirmUsername_003Ed__20 _003CConfirmUsername_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CConfirmUsername_003Ed__20>(ref awaiter2, ref _003CConfirmUsername_003Ed__);
							return;
						}
						goto IL_017e;
					}
					_003C_003Es__2 = 0;
					goto case 2;
				case 0:
					awaiter3 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00d8;
				case 1:
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_017e;
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
				case 7:
				case 8:
				case 9:
				case 10:
					try
					{
						TaskAwaiter<bool> awaiter12;
						TaskAwaiter<bool> awaiter11;
						TaskAwaiter<bool> awaiter10;
						TaskAwaiter awaiter9;
						TaskAwaiter<Result<Player>> awaiter8;
						TaskAwaiter awaiter7;
						TaskAwaiter awaiter6;
						TaskAwaiter awaiter5;
						TaskAwaiter awaiter4;
						RegisterTermsSheet registerTermsSheet;
						List<Detent> obj3;
						switch (num)
						{
						default:
						{
							_003C_003E4__this.IsLoading = true;
							_003Csheet_003E5__3 = ServiceProviderServiceExtensions.GetRequiredService<ConfirmUserNameSheet>(_003C_003E4__this._serviceProvider);
							_003Csheet_003E5__3.Initialize(_003C_003E4__this.Username);
							ConfirmUserNameSheet confirmUserNameSheet = _003Csheet_003E5__3;
							List<Detent> obj = new List<Detent>(1);
							obj.Add((Detent)new FullscreenDetent());
							((BottomSheet)confirmUserNameSheet).Detents = (global::System.Collections.Generic.IList<Detent>)obj;
							awaiter12 = _003C_003E4__this._bottomSheetService.ShowSheetAsync<bool>((BottomSheet)(object)_003Csheet_003E5__3, _003Csheet_003E5__3.SheetId).GetAwaiter();
							if (!awaiter12.IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__2 = awaiter12;
								_003CConfirmUsername_003Ed__20 _003CConfirmUsername_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CConfirmUsername_003Ed__20>(ref awaiter12, ref _003CConfirmUsername_003Ed__);
								return;
							}
							goto IL_02bd;
						}
						case 2:
							awaiter12 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<bool>);
							num = (_003C_003E1__state = -1);
							goto IL_02bd;
						case 3:
							awaiter11 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<bool>);
							num = (_003C_003E1__state = -1);
							goto IL_03a1;
						case 4:
							awaiter10 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<bool>);
							num = (_003C_003E1__state = -1);
							goto IL_0488;
						case 5:
							awaiter9 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0516;
						case 6:
							awaiter8 = _003C_003Eu__3;
							_003C_003Eu__3 = default(TaskAwaiter<Result<Player>>);
							num = (_003C_003E1__state = -1);
							goto IL_0599;
						case 7:
							awaiter7 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_065f;
						case 8:
							awaiter6 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_06fe;
						case 9:
							awaiter5 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_084b;
						case 10:
							{
								awaiter4 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_08be;
							}
							IL_0488:
							_003C_003Es__12 = awaiter10.GetResult();
							_003CtermsAccepted_003E5__8 = _003C_003Es__12;
							if (!_003CtermsAccepted_003E5__8)
							{
								awaiter9 = _003C_003E4__this._registrationOrchestrator.CancelRegistrationAsync().GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter9)).IsCompleted)
								{
									num = (_003C_003E1__state = 5);
									_003C_003Eu__1 = awaiter9;
									_003CConfirmUsername_003Ed__20 _003CConfirmUsername_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CConfirmUsername_003Ed__20>(ref awaiter9, ref _003CConfirmUsername_003Ed__);
									return;
								}
								goto IL_0516;
							}
							awaiter8 = _003C_003E4__this._registrationOrchestrator.CompleteRegistrationAsync(_003C_003E4__this.Username, _003CisAccountLinked_003E5__6).GetAwaiter();
							if (!awaiter8.IsCompleted)
							{
								num = (_003C_003E1__state = 6);
								_003C_003Eu__3 = awaiter8;
								_003CConfirmUsername_003Ed__20 _003CConfirmUsername_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<Player>>, _003CConfirmUsername_003Ed__20>(ref awaiter8, ref _003CConfirmUsername_003Ed__);
								return;
							}
							goto IL_0599;
							IL_02bd:
							_003C_003Es__10 = awaiter12.GetResult();
							_003CconfirmUsername_003E5__4 = _003C_003Es__10;
							if (_003CconfirmUsername_003E5__4)
							{
								_003ClinkSheet_003E5__5 = ServiceProviderServiceExtensions.GetRequiredService<LinkAccountSheet>(_003C_003E4__this._serviceProvider);
								_003ClinkSheet_003E5__5.SetRegistrationMode(isRegistrationFlow: true);
								LinkAccountSheet linkAccountSheet = _003ClinkSheet_003E5__5;
								List<Detent> obj2 = new List<Detent>(1);
								obj2.Add((Detent)new FullscreenDetent());
								((BottomSheet)linkAccountSheet).Detents = (global::System.Collections.Generic.IList<Detent>)obj2;
								awaiter11 = _003C_003E4__this._bottomSheetService.ShowSheetAsync<bool>((BottomSheet)(object)_003ClinkSheet_003E5__5, _003ClinkSheet_003E5__5.SheetId).GetAwaiter();
								if (!awaiter11.IsCompleted)
								{
									num = (_003C_003E1__state = 3);
									_003C_003Eu__2 = awaiter11;
									_003CConfirmUsername_003Ed__20 _003CConfirmUsername_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CConfirmUsername_003Ed__20>(ref awaiter11, ref _003CConfirmUsername_003Ed__);
									return;
								}
								goto IL_03a1;
							}
							goto end_IL_0193;
							IL_08be:
							((TaskAwaiter)(ref awaiter4)).GetResult();
							_003C_003E4__this.IsUsernameSelectionMode = false;
							_003C_003E4__this.ClearFields();
							_003CerrorMsg_003E5__15 = null;
							break;
							IL_065f:
							((TaskAwaiter)(ref awaiter7)).GetResult();
							_003Croute_003E5__14 = null;
							break;
							IL_03a1:
							_003C_003Es__11 = awaiter11.GetResult();
							_003CisAccountLinked_003E5__6 = _003C_003Es__11;
							Console.WriteLine("Account linking result: " + (_003CisAccountLinked_003E5__6 ? "Linked" : "Guest"));
							_003CtermsSheet_003E5__7 = ServiceProviderServiceExtensions.GetRequiredService<RegisterTermsSheet>(_003C_003E4__this._serviceProvider);
							registerTermsSheet = _003CtermsSheet_003E5__7;
							obj3 = new List<Detent>(1);
							obj3.Add((Detent)new FullscreenDetent());
							((BottomSheet)registerTermsSheet).Detents = (global::System.Collections.Generic.IList<Detent>)obj3;
							awaiter10 = _003C_003E4__this._bottomSheetService.ShowSheetAsync<bool>((BottomSheet)(object)_003CtermsSheet_003E5__7, _003CtermsSheet_003E5__7.SheetId).GetAwaiter();
							if (!awaiter10.IsCompleted)
							{
								num = (_003C_003E1__state = 4);
								_003C_003Eu__2 = awaiter10;
								_003CConfirmUsername_003Ed__20 _003CConfirmUsername_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CConfirmUsername_003Ed__20>(ref awaiter10, ref _003CConfirmUsername_003Ed__);
								return;
							}
							goto IL_0488;
							IL_06fe:
							((TaskAwaiter)(ref awaiter6)).GetResult();
							_003C_003E4__this.Username = string.Empty;
							_003C_003E4__this.VerifyUsername = string.Empty;
							_003C_003E4__this.IsUsernameSelectionMode = _003C_003E4__this._registrationOrchestrator.CurrentState == RegistrationState.AwaitingUsername;
							Console.WriteLine($"Username retry mode. State: {_003C_003E4__this._registrationOrchestrator.CurrentState}, IsUsernameMode: {_003C_003E4__this.IsUsernameSelectionMode}");
							break;
							IL_084b:
							((TaskAwaiter)(ref awaiter5)).GetResult();
							awaiter4 = _003C_003E4__this._navigationService.NavigateToAsync("//welcome").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
							{
								num = (_003C_003E1__state = 10);
								_003C_003Eu__1 = awaiter4;
								_003CConfirmUsername_003Ed__20 _003CConfirmUsername_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CConfirmUsername_003Ed__20>(ref awaiter4, ref _003CConfirmUsername_003Ed__);
								return;
							}
							goto IL_08be;
							IL_0516:
							((TaskAwaiter)(ref awaiter9)).GetResult();
							goto end_IL_0193;
							IL_0599:
							_003C_003Es__13 = awaiter8.GetResult();
							_003Cresult_003E5__9 = _003C_003Es__13;
							_003C_003Es__13 = null;
							if (_003Cresult_003E5__9.Success)
							{
								_003Croute_003E5__14 = _003C_003E4__this._registrationOrchestrator.StartPostUsernameOnboarding(_003C_003E4__this.Username);
								awaiter7 = _003C_003E4__this._navigationService.NavigateToAsync(_003Croute_003E5__14.Route).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter7)).IsCompleted)
								{
									num = (_003C_003E1__state = 7);
									_003C_003Eu__1 = awaiter7;
									_003CConfirmUsername_003Ed__20 _003CConfirmUsername_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CConfirmUsername_003Ed__20>(ref awaiter7, ref _003CConfirmUsername_003Ed__);
									return;
								}
								goto IL_065f;
							}
							if (_003Cresult_003E5__9.ErrorMessage == "Username already exists")
							{
								awaiter6 = _003C_003E4__this.ShowAlert("Username Taken", "This username is already in use. Please choose a different username.").GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter6)).IsCompleted)
								{
									num = (_003C_003E1__state = 8);
									_003C_003Eu__1 = awaiter6;
									_003CConfirmUsername_003Ed__20 _003CConfirmUsername_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CConfirmUsername_003Ed__20>(ref awaiter6, ref _003CConfirmUsername_003Ed__);
									return;
								}
								goto IL_06fe;
							}
							_003CerrorMsg_003E5__15 = ((_003C_003E4__this._registrationOrchestrator.CurrentState == RegistrationState.Failed) ? "Registration failed. Please try signing in again." : (_003Cresult_003E5__9.ErrorMessage ?? "An unexpected error occurred during registration."));
							awaiter5 = _003C_003E4__this.ShowAlert("Registration Failed", _003CerrorMsg_003E5__15).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter5)).IsCompleted)
							{
								num = (_003C_003E1__state = 9);
								_003C_003Eu__1 = awaiter5;
								_003CConfirmUsername_003Ed__20 _003CConfirmUsername_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CConfirmUsername_003Ed__20>(ref awaiter5, ref _003CConfirmUsername_003Ed__);
								return;
							}
							goto IL_084b;
						}
						_003Csheet_003E5__3 = null;
						_003ClinkSheet_003E5__5 = null;
						_003CtermsSheet_003E5__7 = null;
						_003Cresult_003E5__9 = null;
						goto IL_091a;
						end_IL_0193:;
					}
					catch (global::System.Exception ex)
					{
						_003C_003Es__1 = ex;
						_003C_003Es__2 = 1;
						goto IL_091a;
					}
					goto end_IL_0007;
				case 11:
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_09a5;
					}
					IL_09a5:
					((TaskAwaiter)(ref awaiter)).GetResult();
					_003C_003E4__this.IsUsernameSelectionMode = _003C_003E4__this._registrationOrchestrator.CurrentState == RegistrationState.AwaitingUsername;
					if (!_003C_003E4__this.IsUsernameSelectionMode)
					{
						_003C_003E4__this.ClearFields();
					}
					_003C_003E4__this.IsLoading = false;
					_003Cex_003E5__16 = null;
					break;
					IL_091a:
					num2 = _003C_003Es__2;
					if (num2 != 1)
					{
						break;
					}
					_003Cex_003E5__16 = (global::System.Exception)_003C_003Es__1;
					awaiter = _003C_003E4__this.HandleError(_003Cex_003E5__16).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 11);
						_003C_003Eu__1 = awaiter;
						_003CConfirmUsername_003Ed__20 _003CConfirmUsername_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CConfirmUsername_003Ed__20>(ref awaiter, ref _003CConfirmUsername_003Ed__);
						return;
					}
					goto IL_09a5;
					IL_00d8:
					((TaskAwaiter)(ref awaiter3)).GetResult();
					goto end_IL_0007;
					IL_017e:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					goto end_IL_0007;
				}
				_003C_003Es__1 = null;
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
	private sealed class _003CGoBackToWelcome_003Ed__21 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public LoginViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0124: Unknown result type (might be due to invalid IL or missing references)
			//IL_0129: Unknown result type (might be due to invalid IL or missing references)
			//IL_0131: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					if (num == 1)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0140;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter awaiter2;
					if (num != 0)
					{
						awaiter2 = _003C_003E4__this._navigationService.NavigateToAsync("//welcome").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CGoBackToWelcome_003Ed__21 _003CGoBackToWelcome_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoBackToWelcome_003Ed__21>(ref awaiter2, ref _003CGoBackToWelcome_003Ed__);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
					}
					((TaskAwaiter)(ref awaiter2)).GetResult();
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
				}
				int num2 = _003C_003Es__2;
				if (num2 != 1)
				{
					goto IL_0174;
				}
				_003Cex_003E5__3 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Something went wrong, please try again or try restart the app").GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = awaiter;
					_003CGoBackToWelcome_003Ed__21 _003CGoBackToWelcome_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoBackToWelcome_003Ed__21>(ref awaiter, ref _003CGoBackToWelcome_003Ed__);
					return;
				}
				goto IL_0140;
				IL_0140:
				((TaskAwaiter)(ref awaiter)).GetResult();
				Console.WriteLine(_003Cex_003E5__3.Message);
				Console.WriteLine(_003Cex_003E5__3.StackTrace);
				_003Cex_003E5__3 = null;
				goto IL_0174;
				IL_0174:
				_003C_003Es__1 = null;
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
	private sealed class _003CHandleError_003Ed__25 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public global::System.Exception ex;

		public LoginViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = _003C_003E4__this.ShowAlert("Error", "An error occurred: " + ex.Message).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CHandleError_003Ed__25 _003CHandleError_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CHandleError_003Ed__25>(ref awaiter, ref _003CHandleError_003Ed__);
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
				Console.WriteLine("Error: " + ex.Message + "\nStacktrace: " + ex.StackTrace);
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
	private sealed class _003CLoadDataAsync_003Ed__14 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public object parameter;

		public LoginViewModel _003C_003E4__this;

		private bool _003CisAwaitingUsername_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					_003CisAwaitingUsername_003E5__1 = _003C_003E4__this._registrationOrchestrator.CurrentState == RegistrationState.AwaitingUsername;
					_003C_003E4__this.IsUsernameSelectionMode = _003CisAwaitingUsername_003E5__1;
					if (_003C_003E4__this.IsUsernameSelectionMode)
					{
						Console.WriteLine("LoginViewModel: Showing username selection mode");
						_003C_003E4__this.IsSignedIn = false;
					}
					else
					{
						_003C_003E4__this.IsSignedIn = _003C_003E4__this._registrationOrchestrator.CurrentState != RegistrationState.NotStarted;
					}
					awaiter = global::System.Threading.Tasks.Task.CompletedTask.GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CLoadDataAsync_003Ed__14 _003CLoadDataAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__14>(ref awaiter, ref _003CLoadDataAsync_003Ed__);
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
	private sealed class _003CSignIn_003Ed__16 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public LoginViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private string _003Cinput_003E5__3;

		private IFirebaseUser _003Cuser_003E5__4;

		private string _003Cemail_003E5__5;

		private string _003C_003Es__6;

		private IFirebaseUser _003C_003Es__7;

		private global::System.Exception _003Cex_003E5__8;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<string> _003C_003Eu__2;

		private TaskAwaiter<IFirebaseUser> _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_03e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_03fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_0419: Unknown result type (might be due to invalid IL or missing references)
			//IL_041e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0426: Unknown result type (might be due to invalid IL or missing references)
			//IL_0198: Unknown result type (might be due to invalid IL or missing references)
			//IL_019d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0234: Unknown result type (might be due to invalid IL or missing references)
			//IL_0239: Unknown result type (might be due to invalid IL or missing references)
			//IL_0241: Unknown result type (might be due to invalid IL or missing references)
			//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0365: Unknown result type (might be due to invalid IL or missing references)
			//IL_036a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0372: Unknown result type (might be due to invalid IL or missing references)
			//IL_0292: Unknown result type (might be due to invalid IL or missing references)
			//IL_0297: Unknown result type (might be due to invalid IL or missing references)
			//IL_015f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0164: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0200: Unknown result type (might be due to invalid IL or missing references)
			//IL_032c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0331: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_0179: Unknown result type (might be due to invalid IL or missing references)
			//IL_017b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0215: Unknown result type (might be due to invalid IL or missing references)
			//IL_0217: Unknown result type (might be due to invalid IL or missing references)
			//IL_0346: Unknown result type (might be due to invalid IL or missing references)
			//IL_0348: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00ad;
				}
				if ((uint)(num - 1) > 4u && (string.IsNullOrWhiteSpace(_003C_003E4__this.Username) || string.IsNullOrWhiteSpace(_003C_003E4__this.Password)))
				{
					awaiter = _003C_003E4__this.ShowAlert("Validation Error", "Please enter username and password").GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CSignIn_003Ed__16 _003CSignIn_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSignIn_003Ed__16>(ref awaiter, ref _003CSignIn_003Ed__);
						return;
					}
					goto IL_00ad;
				}
				try
				{
					TaskAwaiter awaiter2;
					if ((uint)(num - 1) > 3u)
					{
						if (num == 5)
						{
							awaiter2 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0435;
						}
						_003C_003Es__2 = 0;
					}
					try
					{
						TaskAwaiter<string> awaiter6;
						TaskAwaiter awaiter5;
						TaskAwaiter<IFirebaseUser> awaiter4;
						TaskAwaiter awaiter3;
						switch (num)
						{
						default:
							_003C_003E4__this.IsLoading = true;
							_003Cinput_003E5__3 = _003C_003E4__this.Username;
							if (!_003C_003E4__this.Username.Contains('@'))
							{
								awaiter6 = _003C_003E4__this._playerRepository.GetEmailByUserAsync(_003C_003E4__this.Username).GetAwaiter();
								if (!awaiter6.IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__2 = awaiter6;
									_003CSignIn_003Ed__16 _003CSignIn_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<string>, _003CSignIn_003Ed__16>(ref awaiter6, ref _003CSignIn_003Ed__);
									return;
								}
								goto IL_01b4;
							}
							goto IL_0271;
						case 1:
							awaiter6 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<string>);
							num = (_003C_003E1__state = -1);
							goto IL_01b4;
						case 2:
							awaiter5 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0250;
						case 3:
							awaiter4 = _003C_003Eu__3;
							_003C_003Eu__3 = default(TaskAwaiter<IFirebaseUser>);
							num = (_003C_003E1__state = -1);
							goto IL_02e7;
						case 4:
							{
								awaiter3 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_0381;
							}
							IL_0250:
							((TaskAwaiter)(ref awaiter5)).GetResult();
							goto end_IL_00bb;
							IL_0381:
							((TaskAwaiter)(ref awaiter3)).GetResult();
							break;
							IL_01b4:
							_003C_003Es__6 = awaiter6.GetResult();
							_003Cemail_003E5__5 = _003C_003Es__6;
							_003C_003Es__6 = null;
							if (string.IsNullOrEmpty(_003Cemail_003E5__5))
							{
								awaiter5 = _003C_003E4__this.ShowAlert("Error", "Username not found").GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter5)).IsCompleted)
								{
									num = (_003C_003E1__state = 2);
									_003C_003Eu__1 = awaiter5;
									_003CSignIn_003Ed__16 _003CSignIn_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSignIn_003Ed__16>(ref awaiter5, ref _003CSignIn_003Ed__);
									return;
								}
								goto IL_0250;
							}
							_003Cinput_003E5__3 = _003Cemail_003E5__5;
							_003Cemail_003E5__5 = null;
							goto IL_0271;
							IL_0271:
							awaiter4 = _003C_003E4__this._authService.SignInWithEmailAndPasswordAsync(_003Cinput_003E5__3, _003C_003E4__this.Password).GetAwaiter();
							if (!awaiter4.IsCompleted)
							{
								num = (_003C_003E1__state = 3);
								_003C_003Eu__3 = awaiter4;
								_003CSignIn_003Ed__16 _003CSignIn_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<IFirebaseUser>, _003CSignIn_003Ed__16>(ref awaiter4, ref _003CSignIn_003Ed__);
								return;
							}
							goto IL_02e7;
							IL_02e7:
							_003C_003Es__7 = awaiter4.GetResult();
							_003Cuser_003E5__4 = _003C_003Es__7;
							_003C_003Es__7 = null;
							if (_003Cuser_003E5__4 != null)
							{
								break;
							}
							awaiter3 = _003C_003E4__this.ShowAlert("Login Failed", "Invalid credentials").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 4);
								_003C_003Eu__1 = awaiter3;
								_003CSignIn_003Ed__16 _003CSignIn_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSignIn_003Ed__16>(ref awaiter3, ref _003CSignIn_003Ed__);
								return;
							}
							goto IL_0381;
						}
						_003Cinput_003E5__3 = null;
						_003Cuser_003E5__4 = null;
					}
					catch (global::System.Exception ex)
					{
						_003C_003Es__1 = ex;
						_003C_003Es__2 = 1;
					}
					int num2 = _003C_003Es__2;
					if (num2 != 1)
					{
						goto IL_0447;
					}
					_003Cex_003E5__8 = (global::System.Exception)_003C_003Es__1;
					awaiter2 = _003C_003E4__this.HandleError(_003Cex_003E5__8).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 5);
						_003C_003Eu__1 = awaiter2;
						_003CSignIn_003Ed__16 _003CSignIn_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSignIn_003Ed__16>(ref awaiter2, ref _003CSignIn_003Ed__);
						return;
					}
					goto IL_0435;
					IL_0435:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					_003Cex_003E5__8 = null;
					goto IL_0447;
					IL_0447:
					_003C_003Es__1 = null;
					end_IL_00bb:;
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this.IsLoading = false;
					}
				}
				goto end_IL_0007;
				IL_00ad:
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

	[CompilerGenerated]
	private sealed class _003CSignInWithApple_003Ed__18 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public LoginViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private IFirebaseUser _003Cuser_003E5__3;

		private IFirebaseUser _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter<IFirebaseUser> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0142: Unknown result type (might be due to invalid IL or missing references)
			//IL_0147: Unknown result type (might be due to invalid IL or missing references)
			//IL_015c: Unknown result type (might be due to invalid IL or missing references)
			//IL_015e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0178: Unknown result type (might be due to invalid IL or missing references)
			//IL_017d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0185: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num > 1u)
				{
				}
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0194;
						}
						_003C_003Es__2 = 0;
					}
					try
					{
						TaskAwaiter<IFirebaseUser> awaiter2;
						if (num != 0)
						{
							_003C_003E4__this.IsLoading = true;
							awaiter2 = _003C_003E4__this._authService.SignInWithApple().GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter2;
								_003CSignInWithApple_003Ed__18 _003CSignInWithApple_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<IFirebaseUser>, _003CSignInWithApple_003Ed__18>(ref awaiter2, ref _003CSignInWithApple_003Ed__);
								return;
							}
						}
						else
						{
							awaiter2 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<IFirebaseUser>);
							num = (_003C_003E1__state = -1);
						}
						_003C_003Es__4 = awaiter2.GetResult();
						_003Cuser_003E5__3 = _003C_003Es__4;
						_003C_003Es__4 = null;
						if (_003Cuser_003E5__3 != null)
						{
							_003C_003E4__this.IsUsernameSelectionMode = _003C_003E4__this._registrationOrchestrator.CurrentState == RegistrationState.AwaitingUsername;
						}
						_003Cuser_003E5__3 = null;
					}
					catch (global::System.Exception ex)
					{
						_003C_003Es__1 = ex;
						_003C_003Es__2 = 1;
					}
					int num2 = _003C_003Es__2;
					if (num2 != 1)
					{
						goto IL_01a6;
					}
					_003Cex_003E5__5 = (global::System.Exception)_003C_003Es__1;
					awaiter = _003C_003E4__this.HandleError(_003Cex_003E5__5).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter;
						_003CSignInWithApple_003Ed__18 _003CSignInWithApple_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSignInWithApple_003Ed__18>(ref awaiter, ref _003CSignInWithApple_003Ed__);
						return;
					}
					goto IL_0194;
					IL_0194:
					((TaskAwaiter)(ref awaiter)).GetResult();
					_003Cex_003E5__5 = null;
					goto IL_01a6;
					IL_01a6:
					_003C_003Es__1 = null;
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this.IsLoading = false;
					}
				}
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
	private sealed class _003CSignInWithFacebook_003Ed__19 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public LoginViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private IFirebaseUser _003Cuser_003E5__3;

		private IFirebaseUser _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter<IFirebaseUser> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0142: Unknown result type (might be due to invalid IL or missing references)
			//IL_0147: Unknown result type (might be due to invalid IL or missing references)
			//IL_015c: Unknown result type (might be due to invalid IL or missing references)
			//IL_015e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0178: Unknown result type (might be due to invalid IL or missing references)
			//IL_017d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0185: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num > 1u)
				{
				}
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0194;
						}
						_003C_003Es__2 = 0;
					}
					try
					{
						TaskAwaiter<IFirebaseUser> awaiter2;
						if (num != 0)
						{
							_003C_003E4__this.IsLoading = true;
							awaiter2 = _003C_003E4__this._authService.SignInWithFacebook().GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter2;
								_003CSignInWithFacebook_003Ed__19 _003CSignInWithFacebook_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<IFirebaseUser>, _003CSignInWithFacebook_003Ed__19>(ref awaiter2, ref _003CSignInWithFacebook_003Ed__);
								return;
							}
						}
						else
						{
							awaiter2 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<IFirebaseUser>);
							num = (_003C_003E1__state = -1);
						}
						_003C_003Es__4 = awaiter2.GetResult();
						_003Cuser_003E5__3 = _003C_003Es__4;
						_003C_003Es__4 = null;
						if (_003Cuser_003E5__3 != null)
						{
							_003C_003E4__this.IsUsernameSelectionMode = _003C_003E4__this._registrationOrchestrator.CurrentState == RegistrationState.AwaitingUsername;
						}
						_003Cuser_003E5__3 = null;
					}
					catch (global::System.Exception ex)
					{
						_003C_003Es__1 = ex;
						_003C_003Es__2 = 1;
					}
					int num2 = _003C_003Es__2;
					if (num2 != 1)
					{
						goto IL_01a6;
					}
					_003Cex_003E5__5 = (global::System.Exception)_003C_003Es__1;
					awaiter = _003C_003E4__this.HandleError(_003Cex_003E5__5).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter;
						_003CSignInWithFacebook_003Ed__19 _003CSignInWithFacebook_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSignInWithFacebook_003Ed__19>(ref awaiter, ref _003CSignInWithFacebook_003Ed__);
						return;
					}
					goto IL_0194;
					IL_0194:
					((TaskAwaiter)(ref awaiter)).GetResult();
					_003Cex_003E5__5 = null;
					goto IL_01a6;
					IL_01a6:
					_003C_003Es__1 = null;
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this.IsLoading = false;
					}
				}
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
	private sealed class _003CSignInWithGoogle_003Ed__17 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public LoginViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private IFirebaseUser _003Cuser_003E5__3;

		private IFirebaseUser _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter<IFirebaseUser> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0142: Unknown result type (might be due to invalid IL or missing references)
			//IL_0147: Unknown result type (might be due to invalid IL or missing references)
			//IL_015c: Unknown result type (might be due to invalid IL or missing references)
			//IL_015e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0178: Unknown result type (might be due to invalid IL or missing references)
			//IL_017d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0185: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num > 1u)
				{
				}
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0194;
						}
						_003C_003Es__2 = 0;
					}
					try
					{
						TaskAwaiter<IFirebaseUser> awaiter2;
						if (num != 0)
						{
							_003C_003E4__this.IsLoading = true;
							awaiter2 = _003C_003E4__this._authService.SignInWithGoogle().GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter2;
								_003CSignInWithGoogle_003Ed__17 _003CSignInWithGoogle_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<IFirebaseUser>, _003CSignInWithGoogle_003Ed__17>(ref awaiter2, ref _003CSignInWithGoogle_003Ed__);
								return;
							}
						}
						else
						{
							awaiter2 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<IFirebaseUser>);
							num = (_003C_003E1__state = -1);
						}
						_003C_003Es__4 = awaiter2.GetResult();
						_003Cuser_003E5__3 = _003C_003Es__4;
						_003C_003Es__4 = null;
						if (_003Cuser_003E5__3 != null)
						{
							_003C_003E4__this.IsUsernameSelectionMode = _003C_003E4__this._registrationOrchestrator.CurrentState == RegistrationState.AwaitingUsername;
						}
						_003Cuser_003E5__3 = null;
					}
					catch (global::System.Exception ex)
					{
						_003C_003Es__1 = ex;
						_003C_003Es__2 = 1;
					}
					int num2 = _003C_003Es__2;
					if (num2 != 1)
					{
						goto IL_01a6;
					}
					_003Cex_003E5__5 = (global::System.Exception)_003C_003Es__1;
					awaiter = _003C_003E4__this.HandleError(_003Cex_003E5__5).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter;
						_003CSignInWithGoogle_003Ed__17 _003CSignInWithGoogle_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSignInWithGoogle_003Ed__17>(ref awaiter, ref _003CSignInWithGoogle_003Ed__);
						return;
					}
					goto IL_0194;
					IL_0194:
					((TaskAwaiter)(ref awaiter)).GetResult();
					_003Cex_003E5__5 = null;
					goto IL_01a6;
					IL_01a6:
					_003C_003Es__1 = null;
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this.IsLoading = false;
					}
				}
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

	private readonly INavigationService _navigationService;

	private readonly IAuthService _authService;

	private readonly IRegistrationOrchestrator _registrationOrchestrator;

	private readonly IPlayerRepository _playerRepository;

	private readonly IServiceProvider _serviceProvider;

	private readonly IBottomSheetService _bottomSheetService;

	[ObservableProperty]
	private string _username = string.Empty;

	[ObservableProperty]
	private string _verifyUsername = string.Empty;

	[ObservableProperty]
	private string _password = string.Empty;

	[ObservableProperty]
	private bool _isLoading;

	[ObservableProperty]
	private bool _isUsernameSelectionMode;

	[ObservableProperty]
	private bool _isPasswordVisible = true;

	[ObservableProperty]
	private bool _isSignedIn = true;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? togglePasswordVisibilityCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? signInCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? signInWithGoogleCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? signInWithAppleCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? signInWithFacebookCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? confirmUsernameCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? goBackToWelcomeCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? cancelRegistrationCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string Username
	{
		get
		{
			return _username;
		}
		[MemberNotNull("_username")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_username, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Username);
				_username = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Username);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string VerifyUsername
	{
		get
		{
			return _verifyUsername;
		}
		[MemberNotNull("_verifyUsername")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_verifyUsername, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.VerifyUsername);
				_verifyUsername = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.VerifyUsername);
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
	public bool IsUsernameSelectionMode
	{
		get
		{
			return _isUsernameSelectionMode;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isUsernameSelectionMode, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsUsernameSelectionMode);
				_isUsernameSelectionMode = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsUsernameSelectionMode);
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
	public bool IsSignedIn
	{
		get
		{
			return _isSignedIn;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isSignedIn, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsSignedIn);
				_isSignedIn = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsSignedIn);
			}
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
	public IAsyncRelayCommand SignInCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = signInCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)SignIn);
				AsyncRelayCommand val2 = val;
				signInCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand SignInWithGoogleCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = signInWithGoogleCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)SignInWithGoogle);
				AsyncRelayCommand val2 = val;
				signInWithGoogleCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand SignInWithAppleCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = signInWithAppleCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)SignInWithApple);
				AsyncRelayCommand val2 = val;
				signInWithAppleCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand SignInWithFacebookCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = signInWithFacebookCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)SignInWithFacebook);
				AsyncRelayCommand val2 = val;
				signInWithFacebookCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand ConfirmUsernameCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = confirmUsernameCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)ConfirmUsername);
				AsyncRelayCommand val2 = val;
				confirmUsernameCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand GoBackToWelcomeCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = goBackToWelcomeCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)GoBackToWelcome);
				AsyncRelayCommand val2 = val;
				goBackToWelcomeCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand CancelRegistrationCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = cancelRegistrationCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)CancelRegistration);
				AsyncRelayCommand val2 = val;
				cancelRegistrationCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	public LoginViewModel(INavigationService navigationService, IAuthService authService, IRegistrationOrchestrator registrationOrchestrator, IPlayerRepository playerRepository, IServiceProvider serviceProvider, IBottomSheetService bottomSheetService)
	{
		_navigationService = navigationService;
		_authService = authService;
		_registrationOrchestrator = registrationOrchestrator;
		_playerRepository = playerRepository;
		_serviceProvider = serviceProvider;
		_bottomSheetService = bottomSheetService;
	}

	[AsyncStateMachine(typeof(_003CLoadDataAsync_003Ed__14))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task LoadDataAsync(object? parameter = null)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadDataAsync_003Ed__14 _003CLoadDataAsync_003Ed__ = new _003CLoadDataAsync_003Ed__14();
		_003CLoadDataAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadDataAsync_003Ed__._003C_003E4__this = this;
		_003CLoadDataAsync_003Ed__.parameter = parameter;
		_003CLoadDataAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadDataAsync_003Ed__14>(ref _003CLoadDataAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[RelayCommand]
	private void TogglePasswordVisibility()
	{
		IsPasswordVisible = !IsPasswordVisible;
	}

	[AsyncStateMachine(typeof(_003CSignIn_003Ed__16))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task SignIn()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CSignIn_003Ed__16 _003CSignIn_003Ed__ = new _003CSignIn_003Ed__16();
		_003CSignIn_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CSignIn_003Ed__._003C_003E4__this = this;
		_003CSignIn_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CSignIn_003Ed__._003C_003Et__builder)).Start<_003CSignIn_003Ed__16>(ref _003CSignIn_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CSignIn_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CSignInWithGoogle_003Ed__17))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task SignInWithGoogle()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CSignInWithGoogle_003Ed__17 _003CSignInWithGoogle_003Ed__ = new _003CSignInWithGoogle_003Ed__17();
		_003CSignInWithGoogle_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CSignInWithGoogle_003Ed__._003C_003E4__this = this;
		_003CSignInWithGoogle_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CSignInWithGoogle_003Ed__._003C_003Et__builder)).Start<_003CSignInWithGoogle_003Ed__17>(ref _003CSignInWithGoogle_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CSignInWithGoogle_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CSignInWithApple_003Ed__18))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task SignInWithApple()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CSignInWithApple_003Ed__18 _003CSignInWithApple_003Ed__ = new _003CSignInWithApple_003Ed__18();
		_003CSignInWithApple_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CSignInWithApple_003Ed__._003C_003E4__this = this;
		_003CSignInWithApple_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CSignInWithApple_003Ed__._003C_003Et__builder)).Start<_003CSignInWithApple_003Ed__18>(ref _003CSignInWithApple_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CSignInWithApple_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CSignInWithFacebook_003Ed__19))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task SignInWithFacebook()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CSignInWithFacebook_003Ed__19 _003CSignInWithFacebook_003Ed__ = new _003CSignInWithFacebook_003Ed__19();
		_003CSignInWithFacebook_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CSignInWithFacebook_003Ed__._003C_003E4__this = this;
		_003CSignInWithFacebook_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CSignInWithFacebook_003Ed__._003C_003Et__builder)).Start<_003CSignInWithFacebook_003Ed__19>(ref _003CSignInWithFacebook_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CSignInWithFacebook_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CConfirmUsername_003Ed__20))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task ConfirmUsername()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CConfirmUsername_003Ed__20 _003CConfirmUsername_003Ed__ = new _003CConfirmUsername_003Ed__20();
		_003CConfirmUsername_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CConfirmUsername_003Ed__._003C_003E4__this = this;
		_003CConfirmUsername_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CConfirmUsername_003Ed__._003C_003Et__builder)).Start<_003CConfirmUsername_003Ed__20>(ref _003CConfirmUsername_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CConfirmUsername_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CGoBackToWelcome_003Ed__21))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task GoBackToWelcome()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CGoBackToWelcome_003Ed__21 _003CGoBackToWelcome_003Ed__ = new _003CGoBackToWelcome_003Ed__21();
		_003CGoBackToWelcome_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CGoBackToWelcome_003Ed__._003C_003E4__this = this;
		_003CGoBackToWelcome_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CGoBackToWelcome_003Ed__._003C_003Et__builder)).Start<_003CGoBackToWelcome_003Ed__21>(ref _003CGoBackToWelcome_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CGoBackToWelcome_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CCancelRegistration_003Ed__22))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task CancelRegistration()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CCancelRegistration_003Ed__22 _003CCancelRegistration_003Ed__ = new _003CCancelRegistration_003Ed__22();
		_003CCancelRegistration_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CCancelRegistration_003Ed__._003C_003E4__this = this;
		_003CCancelRegistration_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CCancelRegistration_003Ed__._003C_003Et__builder)).Start<_003CCancelRegistration_003Ed__22>(ref _003CCancelRegistration_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CCancelRegistration_003Ed__._003C_003Et__builder)).Task;
	}

	private void ClearFields()
	{
		Username = string.Empty;
		VerifyUsername = string.Empty;
		Password = string.Empty;
	}

	private global::System.Threading.Tasks.Task ShowAlert(string title, string message)
	{
		return _navigationService.ShowAlertAsync(title, message);
	}

	[AsyncStateMachine(typeof(_003CHandleError_003Ed__25))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task HandleError(global::System.Exception ex)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CHandleError_003Ed__25 _003CHandleError_003Ed__ = new _003CHandleError_003Ed__25();
		_003CHandleError_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CHandleError_003Ed__._003C_003E4__this = this;
		_003CHandleError_003Ed__.ex = ex;
		_003CHandleError_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CHandleError_003Ed__._003C_003Et__builder)).Start<_003CHandleError_003Ed__25>(ref _003CHandleError_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CHandleError_003Ed__._003C_003Et__builder)).Task;
	}
}
