using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Application.UseCases.Guilds;
using SpiritSummoner.Domain.Entities.Guilds;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Presentation.Navigation;

namespace SpiritSummoner.Presentation.ViewModels.Popups;

public class CreateGuildPopupViewModel : ObservableObject
{
	[CompilerGenerated]
	private sealed class _003CCreateGuild_003Ed__32 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public CreateGuildPopupViewModel _003C_003E4__this;

		private CheckGuildNameRequest _003CnameCheckRequest_003E5__1;

		private Result<bool> _003CnameCheckResult_003E5__2;

		private CreateGuildRequest _003Crequest_003E5__3;

		private Result<Guild> _003Cresult_003E5__4;

		private Result<bool> _003C_003Es__5;

		private Result<Guild> _003C_003Es__6;

		private global::System.Exception _003Cex_003E5__7;

		private TaskAwaiter<Result<bool>> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private TaskAwaiter<Result<Guild>> _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_028b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0290: Unknown result type (might be due to invalid IL or missing references)
			//IL_0298: Unknown result type (might be due to invalid IL or missing references)
			//IL_0358: Unknown result type (might be due to invalid IL or missing references)
			//IL_035d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0365: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_031f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0324: Unknown result type (might be due to invalid IL or missing references)
			//IL_0252: Unknown result type (might be due to invalid IL or missing references)
			//IL_0257: Unknown result type (might be due to invalid IL or missing references)
			//IL_0175: Unknown result type (might be due to invalid IL or missing references)
			//IL_017a: Unknown result type (might be due to invalid IL or missing references)
			//IL_03cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_03cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0339: Unknown result type (might be due to invalid IL or missing references)
			//IL_033b: Unknown result type (might be due to invalid IL or missing references)
			//IL_026c: Unknown result type (might be due to invalid IL or missing references)
			//IL_026e: Unknown result type (might be due to invalid IL or missing references)
			//IL_018f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0191: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 4u || _003C_003E4__this.CanCreate)
				{
					try
					{
						TaskAwaiter<Result<bool>> awaiter5;
						TaskAwaiter awaiter4;
						TaskAwaiter<Result<Guild>> awaiter3;
						TaskAwaiter awaiter2;
						TaskAwaiter awaiter;
						switch (num)
						{
						default:
							_003C_003E4__this.IsCreating = true;
							_003C_003E4__this.ErrorMessage = string.Empty;
							_003CnameCheckRequest_003E5__1 = new CheckGuildNameRequest(_003C_003E4__this.GuildName.Trim());
							awaiter5 = _003C_003E4__this._checkNameAvailabilityUseCase.ExecuteAsync(_003CnameCheckRequest_003E5__1).GetAwaiter();
							if (!awaiter5.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter5;
								_003CCreateGuild_003Ed__32 _003CCreateGuild_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<bool>>, _003CCreateGuild_003Ed__32>(ref awaiter5, ref _003CCreateGuild_003Ed__);
								return;
							}
							goto IL_00ff;
						case 0:
							awaiter5 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<Result<bool>>);
							num = (_003C_003E1__state = -1);
							goto IL_00ff;
						case 1:
							awaiter4 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_01ca;
						case 2:
							awaiter3 = _003C_003Eu__3;
							_003C_003Eu__3 = default(TaskAwaiter<Result<Guild>>);
							num = (_003C_003E1__state = -1);
							goto IL_02a7;
						case 3:
							awaiter2 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0374;
						case 4:
							{
								awaiter = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_0406;
							}
							IL_01ca:
							((TaskAwaiter)(ref awaiter4)).GetResult();
							goto end_IL_0028;
							IL_00ff:
							_003C_003Es__5 = awaiter5.GetResult();
							_003CnameCheckResult_003E5__2 = _003C_003Es__5;
							_003C_003Es__5 = null;
							if (_003CnameCheckResult_003E5__2.Success && _003CnameCheckResult_003E5__2.Data)
							{
								_003C_003E4__this.ErrorMessage = "This guild name is already taken. Please choose another.";
								awaiter4 = _003C_003E4__this._navigationService.ShowAlertAsync("Error creating guild", _003C_003E4__this.ErrorMessage).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__2 = awaiter4;
									_003CCreateGuild_003Ed__32 _003CCreateGuild_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CCreateGuild_003Ed__32>(ref awaiter4, ref _003CCreateGuild_003Ed__);
									return;
								}
								goto IL_01ca;
							}
							_003Crequest_003E5__3 = new CreateGuildRequest(_003C_003E4__this.GuildName.Trim(), _003C_003E4__this.Description.Trim(), _003C_003E4__this.SelectedEmblem, _003C_003E4__this.IsPublic, !_003C_003E4__this.InstantJoin, _003C_003E4__this.MinLevelRequired, _003C_003E4__this.MinTrophiesRequired);
							awaiter3 = _003C_003E4__this._createGuildUseCase.ExecuteAsync(_003Crequest_003E5__3).GetAwaiter();
							if (!awaiter3.IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__3 = awaiter3;
								_003CCreateGuild_003Ed__32 _003CCreateGuild_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<Guild>>, _003CCreateGuild_003Ed__32>(ref awaiter3, ref _003CCreateGuild_003Ed__);
								return;
							}
							goto IL_02a7;
							IL_0406:
							((TaskAwaiter)(ref awaiter)).GetResult();
							break;
							IL_02a7:
							_003C_003Es__6 = awaiter3.GetResult();
							_003Cresult_003E5__4 = _003C_003Es__6;
							_003C_003Es__6 = null;
							if (!_003Cresult_003E5__4.Success)
							{
								_003C_003E4__this.ErrorMessage = _003Cresult_003E5__4.ErrorMessage ?? "Failed to create guild. Please try again.";
								awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Error creating guild", _003C_003E4__this.ErrorMessage).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
								{
									num = (_003C_003E1__state = 3);
									_003C_003Eu__2 = awaiter2;
									_003CCreateGuild_003Ed__32 _003CCreateGuild_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CCreateGuild_003Ed__32>(ref awaiter2, ref _003CCreateGuild_003Ed__);
									return;
								}
								goto IL_0374;
							}
							if (_003Cresult_003E5__4.Data != null)
							{
								awaiter = _003C_003E4__this._popupService.ClosePopupAsync((object)_003Cresult_003E5__4.Data).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
								{
									num = (_003C_003E1__state = 4);
									_003C_003Eu__2 = awaiter;
									_003CCreateGuild_003Ed__32 _003CCreateGuild_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CCreateGuild_003Ed__32>(ref awaiter, ref _003CCreateGuild_003Ed__);
									return;
								}
								goto IL_0406;
							}
							_003C_003E4__this.ErrorMessage = "Failed to create guild. Please try again.";
							break;
							IL_0374:
							((TaskAwaiter)(ref awaiter2)).GetResult();
							goto end_IL_0028;
						}
						_003CnameCheckRequest_003E5__1 = null;
						_003CnameCheckResult_003E5__2 = null;
						_003Crequest_003E5__3 = null;
						_003Cresult_003E5__4 = null;
						end_IL_0028:;
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__7 = ex;
						_003C_003E4__this.ErrorMessage = "An error occurred while creating the guild.";
						Console.WriteLine($"CreateGuild error: {_003Cex_003E5__7}");
					}
					finally
					{
						if (num < 0)
						{
							_003C_003E4__this.IsCreating = false;
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
	private sealed class _003CEditGuild_003Ed__33 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public CreateGuildPopupViewModel _003C_003E4__this;

		private Player _003Cplayer_003E5__1;

		private UpdateGuildRequest _003Crequest_003E5__2;

		private Result<Guild> _003Cresult_003E5__3;

		private CheckGuildNameRequest _003CnameCheckRequest_003E5__4;

		private Result<bool> _003CnameCheckResult_003E5__5;

		private Result<bool> _003C_003Es__6;

		private Result<Guild> _003C_003Es__7;

		private global::System.Exception _003Cex_003E5__8;

		private TaskAwaiter<Result<bool>> _003C_003Eu__1;

		private TaskAwaiter<Result<Guild>> _003C_003Eu__2;

		private TaskAwaiter _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_0132: Unknown result type (might be due to invalid IL or missing references)
			//IL_0137: Unknown result type (might be due to invalid IL or missing references)
			//IL_013f: Unknown result type (might be due to invalid IL or missing references)
			//IL_028b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0290: Unknown result type (might be due to invalid IL or missing references)
			//IL_0298: Unknown result type (might be due to invalid IL or missing references)
			//IL_0366: Unknown result type (might be due to invalid IL or missing references)
			//IL_036b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0373: Unknown result type (might be due to invalid IL or missing references)
			//IL_0251: Unknown result type (might be due to invalid IL or missing references)
			//IL_0256: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_032c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0331: Unknown result type (might be due to invalid IL or missing references)
			//IL_026b: Unknown result type (might be due to invalid IL or missing references)
			//IL_026d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0112: Unknown result type (might be due to invalid IL or missing references)
			//IL_0114: Unknown result type (might be due to invalid IL or missing references)
			//IL_0346: Unknown result type (might be due to invalid IL or missing references)
			//IL_0348: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 2u || _003C_003E4__this.CanEdit)
				{
					try
					{
						TaskAwaiter<Result<bool>> awaiter3;
						TaskAwaiter<Result<Guild>> awaiter2;
						TaskAwaiter awaiter;
						switch (num)
						{
						default:
							_003C_003E4__this.IsCreating = true;
							_003C_003E4__this.ErrorMessage = string.Empty;
							_003Cplayer_003E5__1 = _003C_003E4__this._playerStateService.GetCurrentPlayer();
							if (_003Cplayer_003E5__1 != null)
							{
								if (_003C_003E4__this._originalGuildName != _003C_003E4__this.GuildName)
								{
									_003CnameCheckRequest_003E5__4 = new CheckGuildNameRequest(_003C_003E4__this.GuildName.Trim());
									awaiter3 = _003C_003E4__this._checkNameAvailabilityUseCase.ExecuteAsync(_003CnameCheckRequest_003E5__4).GetAwaiter();
									if (!awaiter3.IsCompleted)
									{
										num = (_003C_003E1__state = 0);
										_003C_003Eu__1 = awaiter3;
										_003CEditGuild_003Ed__33 _003CEditGuild_003Ed__ = this;
										((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<bool>>, _003CEditGuild_003Ed__33>(ref awaiter3, ref _003CEditGuild_003Ed__);
										return;
									}
									goto IL_014e;
								}
								goto IL_01b5;
							}
							_003C_003E4__this.ErrorMessage = "Player information not available.";
							goto end_IL_0028;
						case 0:
							awaiter3 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<Result<bool>>);
							num = (_003C_003E1__state = -1);
							goto IL_014e;
						case 1:
							awaiter2 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<Result<Guild>>);
							num = (_003C_003E1__state = -1);
							goto IL_02a7;
						case 2:
							{
								awaiter = _003C_003Eu__3;
								_003C_003Eu__3 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_0382;
							}
							IL_014e:
							_003C_003Es__6 = awaiter3.GetResult();
							_003CnameCheckResult_003E5__5 = _003C_003Es__6;
							_003C_003Es__6 = null;
							if (!_003CnameCheckResult_003E5__5.Success || !_003CnameCheckResult_003E5__5.Data)
							{
								_003CnameCheckRequest_003E5__4 = null;
								_003CnameCheckResult_003E5__5 = null;
								goto IL_01b5;
							}
							_003C_003E4__this.ErrorMessage = "This guild name is already taken. Please choose another.";
							goto end_IL_0028;
							IL_0382:
							((TaskAwaiter)(ref awaiter)).GetResult();
							break;
							IL_02a7:
							_003C_003Es__7 = awaiter2.GetResult();
							_003Cresult_003E5__3 = _003C_003Es__7;
							_003C_003Es__7 = null;
							if (_003Cresult_003E5__3.Success)
							{
								if (_003Cresult_003E5__3.Data != null)
								{
									awaiter = _003C_003E4__this._popupService.ClosePopupAsync((object)true).GetAwaiter();
									if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
									{
										num = (_003C_003E1__state = 2);
										_003C_003Eu__3 = awaiter;
										_003CEditGuild_003Ed__33 _003CEditGuild_003Ed__ = this;
										((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CEditGuild_003Ed__33>(ref awaiter, ref _003CEditGuild_003Ed__);
										return;
									}
									goto IL_0382;
								}
								_003C_003E4__this.ErrorMessage = "Failed to update guild. Please try again.";
								break;
							}
							_003C_003E4__this.ErrorMessage = _003Cresult_003E5__3.ErrorMessage ?? "Failed to update guild. Please try again.";
							goto end_IL_0028;
							IL_01b5:
							_003Crequest_003E5__2 = new UpdateGuildRequest(_003C_003E4__this.GuildToUpdateId, _003Cplayer_003E5__1.PlayerID, _003C_003E4__this.PlayerName, _003C_003E4__this.GuildName.Trim(), _003C_003E4__this.Description.Trim(), _003C_003E4__this.SelectedEmblem, _003C_003E4__this.IsPublic, !_003C_003E4__this.InstantJoin, _003C_003E4__this.MinLevelRequired, _003C_003E4__this.MinTrophiesRequired);
							awaiter2 = _003C_003E4__this._updateGuildUseCase.ExecuteAsync(_003Crequest_003E5__2).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__2 = awaiter2;
								_003CEditGuild_003Ed__33 _003CEditGuild_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<Guild>>, _003CEditGuild_003Ed__33>(ref awaiter2, ref _003CEditGuild_003Ed__);
								return;
							}
							goto IL_02a7;
						}
						_003Cplayer_003E5__1 = null;
						_003Crequest_003E5__2 = null;
						_003Cresult_003E5__3 = null;
						end_IL_0028:;
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__8 = ex;
						_003C_003E4__this.ErrorMessage = "An error occurred while updating the guild.";
						Console.WriteLine($"EditGuild error: {_003Cex_003E5__8}");
					}
					finally
					{
						if (num < 0)
						{
							_003C_003E4__this.IsCreating = false;
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

	private readonly CreateGuildUseCase _createGuildUseCase;

	private readonly UpdateGuildUseCase _updateGuildUseCase;

	private readonly CheckGuildNameAvailabilityUseCase _checkNameAvailabilityUseCase;

	private readonly IPlayerStateService _playerStateService;

	private readonly IGuildStateService _guildStateService;

	private readonly IPopupService _popupService;

	private readonly INavigationService _navigationService;

	[ObservableProperty]
	private string _playerName = string.Empty;

	[ObservableProperty]
	private string _guildName = string.Empty;

	[ObservableProperty]
	private string _description = string.Empty;

	[ObservableProperty]
	private string _selectedEmblem = "\ud83d\udc51";

	[ObservableProperty]
	private bool _isPublic = true;

	[ObservableProperty]
	private bool _instantJoin = false;

	[ObservableProperty]
	private int _minLevelRequired = 1;

	[ObservableProperty]
	private int _minTrophiesRequired = 0;

	[ObservableProperty]
	private bool _isCreating;

	[ObservableProperty]
	private string _errorMessage = string.Empty;

	[ObservableProperty]
	private bool _isEditingMode = false;

	private string _originalGuildName = string.Empty;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? createGuildCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? editGuildCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<string>? selectEmblemCommand;

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string GuildToUpdateId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = string.Empty;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public ObservableCollection<string> AvailableEmblems
	{
		[CompilerGenerated]
		get;
	}

	public bool CanCreate => !string.IsNullOrWhiteSpace(GuildName) && GuildName.Length >= 3 && GuildName.Length <= 20 && !IsCreating && !IsEditingMode;

	public bool CanEdit => !string.IsNullOrWhiteSpace(GuildName) && GuildName.Length >= 3 && GuildName.Length <= 20 && !IsCreating && IsEditingMode;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string PlayerName
	{
		get
		{
			return _playerName;
		}
		[MemberNotNull("_playerName")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_playerName, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.PlayerName);
				_playerName = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.PlayerName);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string GuildName
	{
		get
		{
			return _guildName;
		}
		[MemberNotNull("_guildName")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_guildName, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.GuildName);
				_guildName = value;
				OnGuildNameChanged(value);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.GuildName);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string Description
	{
		get
		{
			return _description;
		}
		[MemberNotNull("_description")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_description, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Description);
				_description = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Description);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string SelectedEmblem
	{
		get
		{
			return _selectedEmblem;
		}
		[MemberNotNull("_selectedEmblem")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_selectedEmblem, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.SelectedEmblem);
				_selectedEmblem = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SelectedEmblem);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsPublic
	{
		get
		{
			return _isPublic;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isPublic, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsPublic);
				_isPublic = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsPublic);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool InstantJoin
	{
		get
		{
			return _instantJoin;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_instantJoin, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.InstantJoin);
				_instantJoin = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.InstantJoin);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int MinLevelRequired
	{
		get
		{
			return _minLevelRequired;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_minLevelRequired, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.MinLevelRequired);
				_minLevelRequired = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.MinLevelRequired);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int MinTrophiesRequired
	{
		get
		{
			return _minTrophiesRequired;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_minTrophiesRequired, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.MinTrophiesRequired);
				_minTrophiesRequired = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.MinTrophiesRequired);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsCreating
	{
		get
		{
			return _isCreating;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isCreating, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsCreating);
				_isCreating = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsCreating);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string ErrorMessage
	{
		get
		{
			return _errorMessage;
		}
		[MemberNotNull("_errorMessage")]
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
	public bool IsEditingMode
	{
		get
		{
			return _isEditingMode;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isEditingMode, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsEditingMode);
				_isEditingMode = value;
				OnIsEditingModeChanged(value);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsEditingMode);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand CreateGuildCommand
	{
		get
		{
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Expected O, but got Unknown
			//IL_002f: Expected O, but got Unknown
			AsyncRelayCommand obj = createGuildCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)CreateGuild, (Func<bool>)([CompilerGenerated] () => CanCreate));
				AsyncRelayCommand val2 = val;
				createGuildCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand EditGuildCommand
	{
		get
		{
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Expected O, but got Unknown
			//IL_002f: Expected O, but got Unknown
			AsyncRelayCommand obj = editGuildCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)EditGuild, (Func<bool>)([CompilerGenerated] () => CanEdit));
				AsyncRelayCommand val2 = val;
				editGuildCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<string> SelectEmblemCommand => (IRelayCommand<string>)(object)(selectEmblemCommand ?? (selectEmblemCommand = new RelayCommand<string>((Action<string>)SelectEmblem)));

	public CreateGuildPopupViewModel(CreateGuildUseCase createGuildUseCase, UpdateGuildUseCase updateGuildUseCase, CheckGuildNameAvailabilityUseCase checkNameAvailabilityUseCase, IPlayerStateService playerStateService, IGuildStateService guildStateService, IPopupService popupService, INavigationService navigationService)
	{
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		ObservableCollection<string> obj = new ObservableCollection<string>();
		((Collection<string>)(object)obj).Add("\ud83d\udc51");
		((Collection<string>)(object)obj).Add("\ud83d\udee1\ufe0f");
		((Collection<string>)(object)obj).Add("⚔\ufe0f");
		((Collection<string>)(object)obj).Add("\ud83d\udd25");
		((Collection<string>)(object)obj).Add("⚡");
		((Collection<string>)(object)obj).Add("\ud83d\udc8e");
		((Collection<string>)(object)obj).Add("\ud83c\udf1f");
		((Collection<string>)(object)obj).Add("\ud83e\udd81");
		((Collection<string>)(object)obj).Add("\ud83d\udc09");
		((Collection<string>)(object)obj).Add("\ud83e\udd85");
		((Collection<string>)(object)obj).Add("\ud83d\udc3a");
		((Collection<string>)(object)obj).Add("\ud83d\udc2f");
		((Collection<string>)(object)obj).Add("\ud83c\udf19");
		((Collection<string>)(object)obj).Add("☀\ufe0f");
		((Collection<string>)(object)obj).Add("\ud83c\udf0a");
		((Collection<string>)(object)obj).Add("\ud83c\udff0");
		AvailableEmblems = obj;
		((ObservableObject)this)._002Ector();
		_createGuildUseCase = createGuildUseCase ?? throw new ArgumentNullException("createGuildUseCase");
		_updateGuildUseCase = updateGuildUseCase ?? throw new ArgumentNullException("updateGuildUseCase");
		_checkNameAvailabilityUseCase = checkNameAvailabilityUseCase ?? throw new ArgumentNullException("checkNameAvailabilityUseCase");
		_playerStateService = playerStateService ?? throw new ArgumentNullException("playerStateService");
		_guildStateService = guildStateService ?? throw new ArgumentNullException("guildStateService");
		_popupService = popupService ?? throw new ArgumentNullException("popupService");
		_navigationService = navigationService ?? throw new ArgumentNullException("navigationService");
	}

	public void InitializeForEdit(Guild guild)
	{
		IsEditingMode = true;
		GuildToUpdateId = guild.ID;
		_originalGuildName = guild.Name;
		GuildName = guild.Name;
		Description = guild.Description ?? string.Empty;
		SelectedEmblem = guild.Emblem;
		IsPublic = guild.IsPublic;
		InstantJoin = !guild.RequiresApproval;
		MinLevelRequired = guild.MinLevelRequired;
		MinTrophiesRequired = guild.MinTrophiesRequired;
	}

	[AsyncStateMachine(typeof(_003CCreateGuild_003Ed__32))]
	[DebuggerStepThrough]
	[RelayCommand(CanExecute = "CanCreate")]
	public global::System.Threading.Tasks.Task CreateGuild()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CCreateGuild_003Ed__32 _003CCreateGuild_003Ed__ = new _003CCreateGuild_003Ed__32();
		_003CCreateGuild_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CCreateGuild_003Ed__._003C_003E4__this = this;
		_003CCreateGuild_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CCreateGuild_003Ed__._003C_003Et__builder)).Start<_003CCreateGuild_003Ed__32>(ref _003CCreateGuild_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CCreateGuild_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CEditGuild_003Ed__33))]
	[DebuggerStepThrough]
	[RelayCommand(CanExecute = "CanEdit")]
	public global::System.Threading.Tasks.Task EditGuild()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CEditGuild_003Ed__33 _003CEditGuild_003Ed__ = new _003CEditGuild_003Ed__33();
		_003CEditGuild_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CEditGuild_003Ed__._003C_003E4__this = this;
		_003CEditGuild_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CEditGuild_003Ed__._003C_003Et__builder)).Start<_003CEditGuild_003Ed__33>(ref _003CEditGuild_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CEditGuild_003Ed__._003C_003Et__builder)).Task;
	}

	[RelayCommand]
	public void SelectEmblem(string emblem)
	{
		SelectedEmblem = emblem;
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnGuildNameChanged(string value)
	{
		if (!string.IsNullOrEmpty(ErrorMessage))
		{
			ErrorMessage = string.Empty;
		}
		((IRelayCommand)CreateGuildCommand).NotifyCanExecuteChanged();
		((IRelayCommand)EditGuildCommand).NotifyCanExecuteChanged();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnIsEditingModeChanged(bool value)
	{
		((IRelayCommand)CreateGuildCommand).NotifyCanExecuteChanged();
		((IRelayCommand)EditGuildCommand).NotifyCanExecuteChanged();
	}
}
