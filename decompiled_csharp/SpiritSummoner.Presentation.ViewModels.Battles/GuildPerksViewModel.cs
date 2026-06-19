using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Application.UseCases.Guilds;
using SpiritSummoner.Domain.Enums.Guilds;
using SpiritSummoner.Presentation.Navigation;

namespace SpiritSummoner.Presentation.ViewModels.Battles;

public class GuildPerksViewModel : ObservableObject, global::System.IDisposable
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public GetGuildPerksResponse data;

		public GuildPerksViewModel _003C_003E4__this;

		public Func<GuildPerkView, GuildPerkItemViewModel> _003C_003E9__3;

		internal GuildPerkCategoryGroup _003CRefreshAsync_003Eb__2(IGrouping<GuildPerkCategory, GuildPerkView> g)
		{
			GuildPerkCategory key = g.Key;
			GuildPerkCategory key2 = g.Key;
			if (1 == 0)
			{
			}
			string label = key2 switch
			{
				GuildPerkCategory.General => "General", 
				GuildPerkCategory.PvP => "PvP", 
				GuildPerkCategory.GuildWar => "Guild War", 
				_ => ((object)g.Key).ToString(), 
			};
			if (1 == 0)
			{
			}
			return new GuildPerkCategoryGroup(key, label, (global::System.Collections.Generic.IReadOnlyList<GuildPerkItemViewModel>)Enumerable.ToList<GuildPerkItemViewModel>(Enumerable.Select<GuildPerkView, GuildPerkItemViewModel>((global::System.Collections.Generic.IEnumerable<GuildPerkView>)g, (Func<GuildPerkView, GuildPerkItemViewModel>)((GuildPerkView p) => new GuildPerkItemViewModel(p, _003C_003E4__this.IsLeader, data.GuildCrystals, _003C_003E4__this.ActivatePerk)))));
		}

		internal GuildPerkItemViewModel _003CRefreshAsync_003Eb__3(GuildPerkView p)
		{
			return new GuildPerkItemViewModel(p, _003C_003E4__this.IsLeader, data.GuildCrystals, _003C_003E4__this.ActivatePerk);
		}
	}

	[CompilerGenerated]
	private sealed class _003CActivatePerk_003Ed__15 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildPerkType perkType;

		public GuildPerksViewModel _003C_003E4__this;

		private Result<ActivateGuildPerkResponse> _003Cresult_003E5__1;

		private Result<ActivateGuildPerkResponse> _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter<Result<ActivateGuildPerkResponse>> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_0199: Unknown result type (might be due to invalid IL or missing references)
			//IL_019e: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_020d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0212: Unknown result type (might be due to invalid IL or missing references)
			//IL_021a: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0160: Unknown result type (might be due to invalid IL or missing references)
			//IL_0165: Unknown result type (might be due to invalid IL or missing references)
			//IL_026d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0272: Unknown result type (might be due to invalid IL or missing references)
			//IL_017a: Unknown result type (might be due to invalid IL or missing references)
			//IL_017c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0287: Unknown result type (might be due to invalid IL or missing references)
			//IL_0289: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num > 3u)
				{
				}
				try
				{
					TaskAwaiter<Result<ActivateGuildPerkResponse>> awaiter4;
					TaskAwaiter awaiter3;
					TaskAwaiter awaiter2;
					TaskAwaiter awaiter;
					switch (num)
					{
					default:
						awaiter4 = _003C_003E4__this._activatePerkUseCase.ExecuteAsync(new ActivateGuildPerkRequest(perkType)).GetAwaiter();
						if (!awaiter4.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter4;
							_003CActivatePerk_003Ed__15 _003CActivatePerk_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<ActivateGuildPerkResponse>>, _003CActivatePerk_003Ed__15>(ref awaiter4, ref _003CActivatePerk_003Ed__);
							return;
						}
						goto IL_00a8;
					case 0:
						awaiter4 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Result<ActivateGuildPerkResponse>>);
						num = (_003C_003E1__state = -1);
						goto IL_00a8;
					case 1:
						awaiter3 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_01b5;
					case 2:
						awaiter2 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0229;
					case 3:
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_02c2;
						}
						IL_01b5:
						((TaskAwaiter)(ref awaiter3)).GetResult();
						_003C_003E4__this._hasLoaded = false;
						awaiter2 = _003C_003E4__this.RefreshAsync().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__2 = awaiter2;
							_003CActivatePerk_003Ed__15 _003CActivatePerk_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CActivatePerk_003Ed__15>(ref awaiter2, ref _003CActivatePerk_003Ed__);
							return;
						}
						goto IL_0229;
						IL_00a8:
						_003C_003Es__2 = awaiter4.GetResult();
						_003Cresult_003E5__1 = _003C_003Es__2;
						_003C_003Es__2 = null;
						if (_003Cresult_003E5__1.Success && _003Cresult_003E5__1.Data != null)
						{
							awaiter3 = _003C_003E4__this._navigationService.ShowAlertAsync("Perk Activated!", $"Tier {_003Cresult_003E5__1.Data.NewTier}: {_003Cresult_003E5__1.Data.EffectDescription}").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__2 = awaiter3;
								_003CActivatePerk_003Ed__15 _003CActivatePerk_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CActivatePerk_003Ed__15>(ref awaiter3, ref _003CActivatePerk_003Ed__);
								return;
							}
							goto IL_01b5;
						}
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Failed", _003Cresult_003E5__1.ErrorMessage ?? "Could not activate perk").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 3);
							_003C_003Eu__2 = awaiter;
							_003CActivatePerk_003Ed__15 _003CActivatePerk_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CActivatePerk_003Ed__15>(ref awaiter, ref _003CActivatePerk_003Ed__);
							return;
						}
						goto IL_02c2;
						IL_02c2:
						((TaskAwaiter)(ref awaiter)).GetResult();
						break;
						IL_0229:
						((TaskAwaiter)(ref awaiter2)).GetResult();
						_003C_003E4__this._hasLoaded = true;
						break;
					}
					_003Cresult_003E5__1 = null;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine($"ActivatePerk error: {_003Cex_003E5__3}");
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
	private sealed class _003CLoadAsync_003Ed__12 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildPerksViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_007d;
				}
				if (!_003C_003E4__this._hasLoaded)
				{
					awaiter = _003C_003E4__this.RefreshAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CLoadAsync_003Ed__12 _003CLoadAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadAsync_003Ed__12>(ref awaiter, ref _003CLoadAsync_003Ed__);
						return;
					}
					goto IL_007d;
				}
				goto end_IL_0007;
				IL_007d:
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003C_003E4__this._hasLoaded = true;
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
	private sealed class _003CRefresh_003Ed__13 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildPerksViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = _003C_003E4__this.RefreshAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CRefresh_003Ed__13 _003CRefresh_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRefresh_003Ed__13>(ref awaiter, ref _003CRefresh_003Ed__);
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
	private sealed class _003CRefreshAsync_003Ed__14 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildPerksViewModel _003C_003E4__this;

		private _003C_003Ec__DisplayClass14_0 _003C_003E8__1;

		private Result<GetGuildPerksResponse> _003Cresult_003E5__2;

		private List<GuildPerkCategoryGroup> _003Cgroups_003E5__3;

		private Result<GetGuildPerksResponse> _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter<Result<GetGuildPerksResponse>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<Result<GetGuildPerksResponse>> awaiter;
					if (num != 0)
					{
						_003C_003E8__1 = new _003C_003Ec__DisplayClass14_0();
						_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
						_003C_003E4__this.IsLoading = true;
						_003C_003E4__this.ErrorMessage = string.Empty;
						_003C_003E4__this.IsNotInGuild = false;
						awaiter = _003C_003E4__this._getPerksUseCase.ExecuteAsync(new GetGuildPerksRequest()).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CRefreshAsync_003Ed__14 _003CRefreshAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<GetGuildPerksResponse>>, _003CRefreshAsync_003Ed__14>(ref awaiter, ref _003CRefreshAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Result<GetGuildPerksResponse>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__4 = awaiter.GetResult();
					_003Cresult_003E5__2 = _003C_003Es__4;
					_003C_003Es__4 = null;
					if (!_003Cresult_003E5__2.Success || _003Cresult_003E5__2.Data == null)
					{
						_003C_003E4__this.IsNotInGuild = true;
					}
					else
					{
						_003C_003E8__1.data = _003Cresult_003E5__2.Data;
						_003C_003E4__this.GuildCrystals = _003C_003E8__1.data.GuildCrystals;
						_003C_003E4__this.IsLeader = _003C_003E8__1.data.IsLeader;
						_003Cgroups_003E5__3 = Enumerable.ToList<GuildPerkCategoryGroup>(Enumerable.Select<IGrouping<GuildPerkCategory, GuildPerkView>, GuildPerkCategoryGroup>((global::System.Collections.Generic.IEnumerable<IGrouping<GuildPerkCategory, GuildPerkView>>)Enumerable.OrderBy<IGrouping<GuildPerkCategory, GuildPerkView>, GuildPerkCategory>(Enumerable.GroupBy<GuildPerkView, GuildPerkCategory>((global::System.Collections.Generic.IEnumerable<GuildPerkView>)_003C_003E8__1.data.Perks, (Func<GuildPerkView, GuildPerkCategory>)((GuildPerkView p) => p.Category)), (Func<IGrouping<GuildPerkCategory, GuildPerkView>, GuildPerkCategory>)((IGrouping<GuildPerkCategory, GuildPerkView> g) => g.Key)), (Func<IGrouping<GuildPerkCategory, GuildPerkView>, GuildPerkCategoryGroup>)delegate(IGrouping<GuildPerkCategory, GuildPerkView> g)
						{
							GuildPerkCategory key = g.Key;
							GuildPerkCategory key2 = g.Key;
							if (1 == 0)
							{
							}
							string label = key2 switch
							{
								GuildPerkCategory.General => "General", 
								GuildPerkCategory.PvP => "PvP", 
								GuildPerkCategory.GuildWar => "Guild War", 
								_ => ((object)g.Key).ToString(), 
							};
							if (1 == 0)
							{
							}
							return new GuildPerkCategoryGroup(key, label, (global::System.Collections.Generic.IReadOnlyList<GuildPerkItemViewModel>)Enumerable.ToList<GuildPerkItemViewModel>(Enumerable.Select<GuildPerkView, GuildPerkItemViewModel>((global::System.Collections.Generic.IEnumerable<GuildPerkView>)g, (Func<GuildPerkView, GuildPerkItemViewModel>)((GuildPerkView p) => new GuildPerkItemViewModel(p, _003C_003E8__1._003C_003E4__this.IsLeader, _003C_003E8__1.data.GuildCrystals, _003C_003E8__1._003C_003E4__this.ActivatePerk)))));
						}));
						_003C_003E4__this.Categories = new ObservableCollection<GuildPerkCategoryGroup>(_003Cgroups_003E5__3);
						_003C_003E8__1 = null;
						_003Cresult_003E5__2 = null;
						_003Cgroups_003E5__3 = null;
					}
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__5 = ex;
					_003C_003E4__this.ErrorMessage = "Failed to load perks";
					Console.WriteLine($"GuildPerksViewModel.RefreshAsync error: {_003Cex_003E5__5}");
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this.IsLoading = false;
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

	private readonly GetGuildPerksUseCase _getPerksUseCase;

	private readonly ActivateGuildPerkUseCase _activatePerkUseCase;

	private readonly INavigationService _navigationService;

	private bool _disposed;

	private bool _hasLoaded;

	[ObservableProperty]
	private ObservableCollection<GuildPerkCategoryGroup> _categories = new ObservableCollection<GuildPerkCategoryGroup>();

	[ObservableProperty]
	private int _guildCrystals;

	[ObservableProperty]
	private bool _isLeader;

	[ObservableProperty]
	private bool _isLoading;

	[ObservableProperty]
	private string _errorMessage = string.Empty;

	[ObservableProperty]
	private bool _isNotInGuild;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? refreshCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ObservableCollection<GuildPerkCategoryGroup> Categories
	{
		get
		{
			return _categories;
		}
		[MemberNotNull("_categories")]
		set
		{
			if (!EqualityComparer<ObservableCollection<GuildPerkCategoryGroup>>.Default.Equals(_categories, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Categories);
				_categories = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Categories);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int GuildCrystals
	{
		get
		{
			return _guildCrystals;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_guildCrystals, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.GuildCrystals);
				_guildCrystals = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.GuildCrystals);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsLeader
	{
		get
		{
			return _isLeader;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isLeader, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsLeader);
				_isLeader = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsLeader);
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
	public bool IsNotInGuild
	{
		get
		{
			return _isNotInGuild;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isNotInGuild, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsNotInGuild);
				_isNotInGuild = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsNotInGuild);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand RefreshCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = refreshCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)Refresh);
				AsyncRelayCommand val2 = val;
				refreshCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	public GuildPerksViewModel(GetGuildPerksUseCase getPerksUseCase, ActivateGuildPerkUseCase activatePerkUseCase, INavigationService navigationService)
	{
		_getPerksUseCase = getPerksUseCase;
		_activatePerkUseCase = activatePerkUseCase;
		_navigationService = navigationService;
	}

	[AsyncStateMachine(typeof(_003CLoadAsync_003Ed__12))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task LoadAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadAsync_003Ed__12 _003CLoadAsync_003Ed__ = new _003CLoadAsync_003Ed__12();
		_003CLoadAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadAsync_003Ed__._003C_003E4__this = this;
		_003CLoadAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadAsync_003Ed__12>(ref _003CLoadAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CRefresh_003Ed__13))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task Refresh()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CRefresh_003Ed__13 _003CRefresh_003Ed__ = new _003CRefresh_003Ed__13();
		_003CRefresh_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CRefresh_003Ed__._003C_003E4__this = this;
		_003CRefresh_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CRefresh_003Ed__._003C_003Et__builder)).Start<_003CRefresh_003Ed__13>(ref _003CRefresh_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CRefresh_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CRefreshAsync_003Ed__14))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task RefreshAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CRefreshAsync_003Ed__14 _003CRefreshAsync_003Ed__ = new _003CRefreshAsync_003Ed__14();
		_003CRefreshAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CRefreshAsync_003Ed__._003C_003E4__this = this;
		_003CRefreshAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CRefreshAsync_003Ed__._003C_003Et__builder)).Start<_003CRefreshAsync_003Ed__14>(ref _003CRefreshAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CRefreshAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CActivatePerk_003Ed__15))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task ActivatePerk(GuildPerkType perkType)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CActivatePerk_003Ed__15 _003CActivatePerk_003Ed__ = new _003CActivatePerk_003Ed__15();
		_003CActivatePerk_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CActivatePerk_003Ed__._003C_003E4__this = this;
		_003CActivatePerk_003Ed__.perkType = perkType;
		_003CActivatePerk_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CActivatePerk_003Ed__._003C_003Et__builder)).Start<_003CActivatePerk_003Ed__15>(ref _003CActivatePerk_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CActivatePerk_003Ed__._003C_003Et__builder)).Task;
	}

	public void Dispose()
	{
		if (!_disposed)
		{
			_disposed = true;
			GC.SuppressFinalize((object)this);
		}
	}
}
