using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using SpiritSummoner.Application.DTOs;
using SpiritSummoner.Application.State;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Enums.Shops;
using SpiritSummoner.Domain.Enums.Spirits;
using SpiritSummoner.Presentation.Models;
using SpiritSummoner.Presentation.Services;
using SpiritSummoner.Presentation.Utilities;
using SpiritSummoner.Presentation.ViewModels.Spirits;
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Presentation.ViewModels.BottomSheet;

public class ShopSpiritSheetViewModel : ObservableObject
{
	[CompilerGenerated]
	private sealed class _003CBuyShopSpirit_003Ed__14 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public ShopSpiritSheetViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private Player _003Cplayer_003E5__3;

		private global::System.Exception _003Cex_003E5__4;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_025f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0264: Unknown result type (might be due to invalid IL or missing references)
			//IL_0279: Unknown result type (might be due to invalid IL or missing references)
			//IL_027b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0295: Unknown result type (might be due to invalid IL or missing references)
			//IL_029a: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_017f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0184: Unknown result type (might be due to invalid IL or missing references)
			//IL_018c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0146: Unknown result type (might be due to invalid IL or missing references)
			//IL_014b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0160: Unknown result type (might be due to invalid IL or missing references)
			//IL_0162: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if ((uint)num > 1u)
				{
					if (num == 2)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_02b1;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter awaiter2;
					if (num == 0)
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0101;
					}
					TaskAwaiter awaiter3;
					if (num != 1)
					{
						_003Cplayer_003E5__3 = _003C_003E4__this._playerStateService.GetCurrentPlayer();
						if (_003Cplayer_003E5__3 == null)
						{
							_003C_003E4__this.Result = ShopResult.Canceled;
							_003C_003E4__this._bottomSheetService.SetResult(_003C_003E4__this._sheetId, _003C_003E4__this.Result);
							awaiter2 = _003C_003E4__this._bottomSheetService.DismissAsync(_003C_003E4__this._sheet).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter2;
								_003CBuyShopSpirit_003Ed__14 _003CBuyShopSpirit_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CBuyShopSpirit_003Ed__14>(ref awaiter2, ref _003CBuyShopSpirit_003Ed__);
								return;
							}
							goto IL_0101;
						}
						_003C_003E4__this._bottomSheetService.SetResult(_003C_003E4__this._sheetId, ShopResult.Success);
						awaiter3 = _003C_003E4__this._bottomSheetService.DismissAsync(_003C_003E4__this._sheet).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter3;
							_003CBuyShopSpirit_003Ed__14 _003CBuyShopSpirit_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CBuyShopSpirit_003Ed__14>(ref awaiter3, ref _003CBuyShopSpirit_003Ed__);
							return;
						}
					}
					else
					{
						awaiter3 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
					}
					((TaskAwaiter)(ref awaiter3)).GetResult();
					_003Cplayer_003E5__3 = null;
					goto end_IL_0023;
					IL_0101:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					goto end_IL_0007;
					end_IL_0023:;
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
				}
				int num2 = _003C_003Es__2;
				if (num2 != 1)
				{
					goto IL_02c3;
				}
				_003Cex_003E5__4 = (global::System.Exception)_003C_003Es__1;
				Console.WriteLine("BuyShopSpirit error: " + _003Cex_003E5__4.Message);
				Console.WriteLine(_003Cex_003E5__4.StackTrace);
				_003C_003E4__this.Result = ShopResult.Canceled;
				_003C_003E4__this._bottomSheetService.SetResult(_003C_003E4__this._sheetId, _003C_003E4__this.Result);
				awaiter = _003C_003E4__this._bottomSheetService.DismissAsync(_003C_003E4__this._sheet).GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 2);
					_003C_003Eu__1 = awaiter;
					_003CBuyShopSpirit_003Ed__14 _003CBuyShopSpirit_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CBuyShopSpirit_003Ed__14>(ref awaiter, ref _003CBuyShopSpirit_003Ed__);
					return;
				}
				goto IL_02b1;
				IL_02b1:
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003Cex_003E5__4 = null;
				goto IL_02c3;
				IL_02c3:
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

	private readonly IBottomSheetService _bottomSheetService;

	private readonly IPlayerStateService _playerStateService;

	private readonly string _sheetId;

	private BottomSheet? _sheet;

	[ObservableProperty]
	private SpiritPreviewDTO _spiritPreview;

	[ObservableProperty]
	private ShopResult _result = ShopResult.Canceled;

	[ObservableProperty]
	private List<AttributeProgressModel> _attributes = new List<AttributeProgressModel>();

	[ObservableProperty]
	private List<MoveStateReadModel> _moves = new List<MoveStateReadModel>();

	[ObservableProperty]
	private List<RequirementChip> _requirements = new List<RequirementChip>();

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? buyShopSpiritCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public SpiritPreviewDTO SpiritPreview
	{
		get
		{
			return _spiritPreview;
		}
		[MemberNotNull("_spiritPreview")]
		set
		{
			if (!EqualityComparer<SpiritPreviewDTO>.Default.Equals(_spiritPreview, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.SpiritPreview);
				_spiritPreview = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SpiritPreview);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ShopResult Result
	{
		get
		{
			return _result;
		}
		set
		{
			if (!EqualityComparer<ShopResult>.Default.Equals(_result, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Result);
				_result = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Result);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public List<AttributeProgressModel> Attributes
	{
		get
		{
			return _attributes;
		}
		[MemberNotNull("_attributes")]
		set
		{
			if (!EqualityComparer<List<AttributeProgressModel>>.Default.Equals(_attributes, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Attributes);
				_attributes = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Attributes);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public List<MoveStateReadModel> Moves
	{
		get
		{
			return _moves;
		}
		[MemberNotNull("_moves")]
		set
		{
			if (!EqualityComparer<List<MoveStateReadModel>>.Default.Equals(_moves, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Moves);
				_moves = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Moves);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public List<RequirementChip> Requirements
	{
		get
		{
			return _requirements;
		}
		[MemberNotNull("_requirements")]
		set
		{
			if (!EqualityComparer<List<RequirementChip>>.Default.Equals(_requirements, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Requirements);
				_requirements = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Requirements);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand BuyShopSpiritCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = buyShopSpiritCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)BuyShopSpirit);
				AsyncRelayCommand val2 = val;
				buyShopSpiritCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	public void SetSheet(BottomSheet sheet)
	{
		_sheet = sheet;
	}

	public ShopSpiritSheetViewModel(SpiritPreviewDTO spiritPreview, string currencyType, int currencyAmount, string orbName, int orbAmount, IBottomSheetService bottomSheetService, IPlayerStateService playerStateService, string sheetId)
	{
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		_bottomSheetService = bottomSheetService;
		_playerStateService = playerStateService;
		_spiritPreview = spiritPreview;
		_sheetId = sheetId;
		global::System.Collections.Generic.IReadOnlyList<AttributeProgressModel> readOnlyList = AttributeProgressCalculator.Calculate(spiritPreview);
		global::System.Collections.Generic.IEnumerator<AttributeProgressModel> enumerator = ((global::System.Collections.Generic.IEnumerable<AttributeProgressModel>)readOnlyList).GetEnumerator();
		try
		{
			while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
			{
				AttributeProgressModel current = enumerator.Current;
				Attributes.Add(current);
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator)?.Dispose();
		}
		if (spiritPreview.LearnableMoves != null)
		{
			Enumerator<ValueTuple<string, int, string, string>> enumerator2 = spiritPreview.LearnableMoves.GetEnumerator();
			try
			{
				SpiritType spiritType = default(SpiritType);
				MoveType moveType = default(MoveType);
				while (enumerator2.MoveNext())
				{
					ValueTuple<string, int, string, string> current2 = enumerator2.Current;
					string item = current2.Item1;
					int item2 = current2.Item2;
					string item3 = current2.Item3;
					string item4 = current2.Item4;
					Moves.Add(new MoveStateReadModel(item, IsUnlocked: true, IsActive: true, global::System.Enum.TryParse<SpiritType>(item3, ref spiritType) ? spiritType : SpiritType.None, global::System.Enum.TryParse<MoveType>(item4, ref moveType) ? moveType : MoveType.None, item2));
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator2).Dispose();
			}
			Moves = Enumerable.ToList<MoveStateReadModel>((global::System.Collections.Generic.IEnumerable<MoveStateReadModel>)Enumerable.ToList<MoveStateReadModel>((global::System.Collections.Generic.IEnumerable<MoveStateReadModel>)Enumerable.OrderBy<MoveStateReadModel, int>((global::System.Collections.Generic.IEnumerable<MoveStateReadModel>)Moves, (Func<MoveStateReadModel, int>)((MoveStateReadModel m) => m.Power))));
		}
		BuildRequirements(spiritPreview, currencyType, currencyAmount, orbName, orbAmount);
	}

	private void BuildRequirements(SpiritPreviewDTO spiritPreview, string currencyType, int currencyAmount, string orbName, int orbAmount)
	{
		if (string.IsNullOrEmpty(currencyType))
		{
			currencyType = "gold";
		}
		if (currencyType == "clancredits")
		{
			currencyType = "guildCoins";
		}
		if (currencyAmount == 0)
		{
			currencyAmount = 5000;
		}
		if (orbAmount == 0)
		{
			orbAmount = 1;
		}
		Player currentPlayer = _playerStateService.GetCurrentPlayer();
		long num = ((currentPlayer != null) ? CollectionExtensions.GetValueOrDefault<string, long>(currentPlayer.Currencies, currencyType, 0L) : 0);
		Requirements.Add(new RequirementChip
		{
			Icon = CurrencyIcon(currencyType),
			Label = CurrencyLabel(currencyType),
			Required = SpiritDetailsViewModel.ToCompactNumber(currencyAmount),
			Have = SpiritDetailsViewModel.ToCompactNumber(num),
			IsMet = (num >= currencyAmount)
		});
		string text = $"{spiritPreview.Name} Orb #{spiritPreview.BaseSpiritId}";
		Inventory inventory = default(Inventory);
		int num2 = ((currentPlayer != null && currentPlayer.Inventory.TryGetValue(text, ref inventory)) ? inventory.Amount : 0);
		Requirements.Add(new RequirementChip
		{
			Icon = "core_icon.png",
			Label = "ORBS",
			Required = orbAmount.ToString(),
			Have = num2.ToString(),
			IsMet = (num2 >= orbAmount)
		});
		if (!string.IsNullOrEmpty(orbName) && orbName != text)
		{
			Inventory inventory2 = default(Inventory);
			int num3 = ((currentPlayer != null && currentPlayer.Inventory.TryGetValue(orbName, ref inventory2)) ? inventory2.Amount : 0);
			Requirements.Add(new RequirementChip
			{
				Icon = "icon_" + orbName.ToLower() + ".png",
				Label = orbName.ToUpperInvariant(),
				Required = orbAmount.ToString(),
				Have = num3.ToString(),
				IsMet = (num3 >= orbAmount)
			});
		}
	}

	private static string CurrencyLabel(string currencyType)
	{
		if (1 == 0)
		{
		}
		string result = ((!(currencyType == "crystal") && !(currencyType == "crystals") && !(currencyType == "gems")) ? ((!(currencyType == "clancredits") && !(currencyType == "guildCoins")) ? "GOLD" : "GUILD COINS") : "CRYSTAL");
		if (1 == 0)
		{
		}
		return result;
	}

	private static string CurrencyIcon(string currencyType)
	{
		if (1 == 0)
		{
		}
		string result = ((!(currencyType == "crystal") && !(currencyType == "crystals") && !(currencyType == "gems")) ? ((!(currencyType == "clancredits") && !(currencyType == "guildCoins")) ? "icon_gold.png" : "icon_guild.png") : "icon_crystal.png");
		if (1 == 0)
		{
		}
		return result;
	}

	[AsyncStateMachine(typeof(_003CBuyShopSpirit_003Ed__14))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task BuyShopSpirit()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CBuyShopSpirit_003Ed__14 _003CBuyShopSpirit_003Ed__ = new _003CBuyShopSpirit_003Ed__14();
		_003CBuyShopSpirit_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CBuyShopSpirit_003Ed__._003C_003E4__this = this;
		_003CBuyShopSpirit_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CBuyShopSpirit_003Ed__._003C_003Et__builder)).Start<_003CBuyShopSpirit_003Ed__14>(ref _003CBuyShopSpirit_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CBuyShopSpirit_003Ed__._003C_003Et__builder)).Task;
	}

	public void SetResultGesture()
	{
		_bottomSheetService.SetResult(_sheetId, Result);
	}
}
