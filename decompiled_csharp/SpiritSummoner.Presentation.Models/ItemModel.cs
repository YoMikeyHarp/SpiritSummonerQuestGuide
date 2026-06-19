using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.RegularExpressions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using SpiritSummoner.Domain.Entities.Items;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Entities.Spirits;

namespace SpiritSummoner.Presentation.Models;

public class ItemModel : ObservableObject
{
	[ObservableProperty]
	private string _id = string.Empty;

	[ObservableProperty]
	private string _name = string.Empty;

	[ObservableProperty]
	private string _type = string.Empty;

	[ObservableProperty]
	[NotifyPropertyChangedFor("RarityColor")]
	private string _rarity = string.Empty;

	[ObservableProperty]
	private int _quantity = 0;

	[ObservableProperty]
	private string _cost;

	[ObservableProperty]
	private string _icon = string.Empty;

	[ObservableProperty]
	private string _description = string.Empty;

	[ObservableProperty]
	private bool _descriptionVisible = false;

	[ObservableProperty]
	private bool _isNew = false;

	[ObservableProperty]
	private string _currencyType = "gold";

	[ObservableProperty]
	private bool _isSelected = false;

	[ObservableProperty]
	private bool _isSpirit = false;

	[ObservableProperty]
	private string _spiritImage = "";

	[ObservableProperty]
	private string _spiritId = string.Empty;

	[ObservableProperty]
	private string _class = string.Empty;

	[ObservableProperty]
	private string _class2 = string.Empty;

	[ObservableProperty]
	private string _spiritType = string.Empty;

	[ObservableProperty]
	private int _guildShopLevel = 0;

	public string CurrencyIcon
	{
		get
		{
			string currencyType = CurrencyType;
			if (1 == 0)
			{
			}
			string result = ((currencyType == "crystal") ? "icon_crystal.png" : ((currencyType == "crystals") ? "icon_crystal.png" : ((currencyType == "gems") ? "icon_crystal.png" : ((currencyType == "clancredits") ? "icon_guild.png" : ((!(currencyType == "guildCoins")) ? "icon_gold_reward.png" : "icon_guild.png")))));
			if (1 == 0)
			{
			}
			return result;
		}
	}

	public Color RarityColor
	{
		get
		{
			string rarity = Rarity;
			if (1 == 0)
			{
			}
			Color result = ((rarity == "legendary") ? Color.FromArgb("#FBBF24") : ((rarity == "epic") ? Color.FromArgb("#A855F7") : ((rarity == "rare") ? Color.FromArgb("#3B82F6") : ((rarity == "uncommon") ? Color.FromArgb("#10B981") : ((!(rarity == "common")) ? Color.FromArgb("#9CA3AF") : Color.FromArgb("#9CA3AF"))))));
			if (1 == 0)
			{
			}
			return result;
		}
	}

	public Brush RarityBrush
	{
		get
		{
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Expected O, but got Unknown
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Expected O, but got Unknown
			//IL_0088: Expected O, but got Unknown
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Expected O, but got Unknown
			//IL_00b1: Expected O, but got Unknown
			//IL_00b7: Expected O, but got Unknown
			//IL_00b9: Expected O, but got Unknown
			if (Rarity == "legendary")
			{
				LinearGradientBrush val = new LinearGradientBrush
				{
					StartPoint = new Point(0.0, 0.0),
					EndPoint = new Point(1.0, 0.0)
				};
				GradientStopCollection val2 = new GradientStopCollection();
				((Collection<GradientStop>)val2).Add(new GradientStop
				{
					Color = Color.FromArgb("#FBBF24"),
					Offset = 0f
				});
				((Collection<GradientStop>)val2).Add(new GradientStop
				{
					Color = Color.FromArgb("#F97316"),
					Offset = 1f
				});
				((GradientBrush)val).GradientStops = val2;
				return (Brush)val;
			}
			return (Brush)new SolidColorBrush(RarityColor);
		}
	}

	public Brush IconBackground
	{
		get
		{
			string rarity = Rarity;
			if (1 == 0)
			{
			}
			Brush result = ((rarity == "legendary") ? CreateGradient("#A855F7", "#EC4899") : ((rarity == "epic") ? CreateGradient("#22D3EE", "#2563EB") : ((rarity == "rare") ? CreateGradient("#60A5FA", "#2563EB") : ((!(rarity == "uncommon")) ? CreateGradient("#F87171", "#DC2626") : CreateGradient("#4ADE80", "#16A34A")))));
			if (1 == 0)
			{
			}
			return result;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string Id
	{
		get
		{
			return _id;
		}
		[MemberNotNull("_id")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_id, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Id);
				_id = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Id);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string Name
	{
		get
		{
			return _name;
		}
		[MemberNotNull("_name")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_name, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Name);
				_name = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Name);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string Type
	{
		get
		{
			return _type;
		}
		[MemberNotNull("_type")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_type, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Type);
				_type = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Type);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string Rarity
	{
		get
		{
			return _rarity;
		}
		[MemberNotNull("_rarity")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_rarity, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Rarity);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.RarityColor);
				_rarity = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Rarity);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.RarityColor);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int Quantity
	{
		get
		{
			return _quantity;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_quantity, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Quantity);
				_quantity = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Quantity);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string Cost
	{
		get
		{
			return _cost;
		}
		[MemberNotNull("_cost")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_cost, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Cost);
				_cost = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Cost);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string Icon
	{
		get
		{
			return _icon;
		}
		[MemberNotNull("_icon")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_icon, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Icon);
				_icon = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Icon);
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
	public bool DescriptionVisible
	{
		get
		{
			return _descriptionVisible;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_descriptionVisible, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.DescriptionVisible);
				_descriptionVisible = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.DescriptionVisible);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsNew
	{
		get
		{
			return _isNew;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isNew, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsNew);
				_isNew = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsNew);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string CurrencyType
	{
		get
		{
			return _currencyType;
		}
		[MemberNotNull("_currencyType")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_currencyType, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CurrencyType);
				_currencyType = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CurrencyType);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsSelected
	{
		get
		{
			return _isSelected;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isSelected, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsSelected);
				_isSelected = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsSelected);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsSpirit
	{
		get
		{
			return _isSpirit;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isSpirit, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsSpirit);
				_isSpirit = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsSpirit);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string SpiritImage
	{
		get
		{
			return _spiritImage;
		}
		[MemberNotNull("_spiritImage")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_spiritImage, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.SpiritImage);
				_spiritImage = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SpiritImage);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string SpiritId
	{
		get
		{
			return _spiritId;
		}
		[MemberNotNull("_spiritId")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_spiritId, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.SpiritId);
				_spiritId = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SpiritId);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string Class
	{
		get
		{
			return _class;
		}
		[MemberNotNull("_class")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_class, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Class);
				_class = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Class);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string Class2
	{
		get
		{
			return _class2;
		}
		[MemberNotNull("_class2")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_class2, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Class2);
				_class2 = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Class2);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string SpiritType
	{
		get
		{
			return _spiritType;
		}
		[MemberNotNull("_spiritType")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_spiritType, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.SpiritType);
				_spiritType = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SpiritType);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int GuildShopLevel
	{
		get
		{
			return _guildShopLevel;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_guildShopLevel, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.GuildShopLevel);
				_guildShopLevel = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.GuildShopLevel);
			}
		}
	}

	public ItemModel(Item itemTemplate, Inventory playerInventory)
	{
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		if (itemTemplate == null)
		{
			throw new ArgumentNullException("itemTemplate");
		}
		if (playerInventory == null)
		{
			throw new ArgumentNullException("playerInventory");
		}
		_id = itemTemplate.ID ?? string.Empty;
		_name = itemTemplate.Name ?? string.Empty;
		_type = ((object)itemTemplate.ItemType).ToString().ToLower();
		_quantity = playerInventory.Amount;
		_icon = itemTemplate.Image ?? string.Empty;
		_description = itemTemplate.Description ?? string.Empty;
		_rarity = DetermineRarity((itemTemplate.Requirements?.CurrencyCost?.Amount).GetValueOrDefault());
		_currencyType = itemTemplate.Requirements?.CurrencyCost?.Type ?? "gold";
	}

	public ItemModel(Item itemTemplate, bool isNew = false)
	{
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		if (itemTemplate == null)
		{
			throw new ArgumentNullException("itemTemplate");
		}
		_id = itemTemplate.ID ?? string.Empty;
		_name = itemTemplate.Name ?? string.Empty;
		_type = ((object)itemTemplate.ItemType).ToString().ToLower();
		_cost = ToCompactNumber(itemTemplate.Requirements?.CurrencyCost?.Amount) ?? "0";
		_icon = itemTemplate.Image ?? string.Empty;
		_description = itemTemplate.Description ?? string.Empty;
		_rarity = DetermineRarity((itemTemplate.Requirements?.CurrencyCost?.Amount).GetValueOrDefault());
		_isNew = isNew;
		_currencyType = itemTemplate.Requirements?.CurrencyCost?.Type ?? "gold";
		_guildShopLevel = (itemTemplate.Requirements?.LevelRequirement?.GuildRankRequired).GetValueOrDefault();
	}

	public ItemModel(string id, string name, string type, int quantity, string icon, string description, int cost)
	{
		_id = id;
		_name = name;
		_type = type;
		_quantity = quantity;
		_icon = icon;
		_description = description;
		_rarity = DetermineRarity(cost);
	}

	public ItemModel(Inventory playerInventory)
	{
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		if (playerInventory == null)
		{
			throw new ArgumentNullException("playerInventory");
		}
		_id = playerInventory.Name ?? string.Empty;
		_name = FormatItemName(playerInventory.Name ?? string.Empty);
		_type = "material";
		_quantity = playerInventory.Amount;
		_icon = "\ud83d\udce6";
		_description = "A mysterious item";
		_rarity = "common";
	}

	public ItemModel(Spirit spirit, bool isNew, string currencyType, int cost, int guildShopLevel = 0)
	{
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		if (spirit == null)
		{
			throw new ArgumentNullException("spirit");
		}
		_id = spirit.ID ?? string.Empty;
		_name = spirit.Name?.ToUpper() + " ORB";
		_type = "spirits";
		if (cost == 0)
		{
			_cost = ToCompactNumber(5000);
		}
		else
		{
			_cost = ToCompactNumber(cost);
		}
		_icon = "core_icon.png";
		_spiritImage = spirit.Image ?? string.Empty;
		_description = "A spirit orb containing the spirit essence of " + spirit.Name + ". [1 Spirit Per Orb]";
		_rarity = DetermineRarity(cost);
		_isNew = isNew;
		_currencyType = currencyType;
		_isSpirit = true;
		_spiritId = spirit.ID ?? string.Empty;
		_spiritType = ((object)spirit.Type1).ToString().ToLower();
		_class = ((object)spirit.Category)?.ToString().ToLower() ?? string.Empty;
		_class2 = ((object)spirit.Category2)?.ToString().ToLower() ?? string.Empty;
		_guildShopLevel = guildShopLevel;
	}

	public ItemModel(Item itemTemplate)
	{
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		if (itemTemplate == null)
		{
			throw new ArgumentNullException("itemTemplate");
		}
		_id = itemTemplate.ID ?? string.Empty;
		_name = itemTemplate.Name ?? string.Empty;
		_type = ((object)itemTemplate.ItemType).ToString().ToLower();
		_cost = ToCompactNumber((itemTemplate.Requirements?.ItemRequirement?.Amount).GetValueOrDefault());
		_icon = itemTemplate.Image ?? string.Empty;
		_description = itemTemplate.Description ?? string.Empty;
		_rarity = DetermineRarity((itemTemplate.Requirements?.CurrencyCost?.Amount).GetValueOrDefault());
		_currencyType = itemTemplate.Requirements?.CurrencyCost?.Type ?? "gold";
		_guildShopLevel = (itemTemplate.Requirements?.LevelRequirement?.GuildRankRequired).GetValueOrDefault();
	}

	public ItemModel(Item itemTemplate, string isCrafting = "tru")
	{
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		if (itemTemplate == null)
		{
			throw new ArgumentNullException("itemTemplate");
		}
		_id = itemTemplate.ID ?? string.Empty;
		_name = itemTemplate.Name ?? string.Empty;
		_type = ((object)itemTemplate.ItemType).ToString().ToLower();
		_cost = ToCompactNumber((itemTemplate.Requirements?.ItemRequirement?.Amount).GetValueOrDefault());
		_icon = itemTemplate.Image ?? string.Empty;
		_description = itemTemplate.Description ?? string.Empty;
		_rarity = DetermineRarity((itemTemplate.Requirements?.CurrencyCost?.Amount).GetValueOrDefault());
		_currencyType = itemTemplate.Requirements?.ItemRequirement?.ItemType ?? "gold";
		_guildShopLevel = (itemTemplate.Requirements?.LevelRequirement?.GuildRankRequired).GetValueOrDefault();
	}

	public ItemModel(Spirit spirit, int cost, int quantity)
	{
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		if (spirit == null)
		{
			throw new ArgumentNullException("spirit");
		}
		_id = spirit.Name?.ToUpper() + " ORB";
		_name = spirit.Name?.ToUpper() + " ORB";
		_type = "orb";
		if (cost == 0)
		{
			_cost = ToCompactNumber(2000);
		}
		else
		{
			_cost = ToCompactNumber(cost);
		}
		_icon = "core_icon.png";
		_description = "A spirit orb containing the spirit essence of " + spirit.Name + ". [1 Spirit Per Orb]";
		_rarity = DetermineRarity(cost);
		_quantity = quantity;
	}

	public ItemModel()
	{
	}

	private string DetermineRarity(int cost)
	{
		if (cost >= 2000)
		{
			return "legendary";
		}
		if (cost > 1000)
		{
			return "epic";
		}
		if (cost > 500)
		{
			return "rare";
		}
		if (cost > 100)
		{
			return "uncommon";
		}
		return "common";
	}

	private Brush CreateGradient(string startColor, string endColor)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected O, but got Unknown
		//IL_006c: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		//IL_0091: Expected O, but got Unknown
		//IL_0097: Expected O, but got Unknown
		//IL_0099: Expected O, but got Unknown
		LinearGradientBrush val = new LinearGradientBrush
		{
			StartPoint = new Point(0.0, 0.0),
			EndPoint = new Point(1.0, 1.0)
		};
		GradientStopCollection val2 = new GradientStopCollection();
		((Collection<GradientStop>)val2).Add(new GradientStop
		{
			Color = Color.FromArgb(startColor),
			Offset = 0f
		});
		((Collection<GradientStop>)val2).Add(new GradientStop
		{
			Color = Color.FromArgb(endColor),
			Offset = 1f
		});
		((GradientBrush)val).GradientStops = val2;
		return (Brush)val;
	}

	private string FormatItemName(string name)
	{
		if (string.IsNullOrWhiteSpace(name))
		{
			return "Unknown";
		}
		if (name.Contains('_'))
		{
			return string.Join(" ", Enumerable.Select<string, string>((global::System.Collections.Generic.IEnumerable<string>)name.Split('_', (StringSplitOptions)0), (Func<string, string>)delegate(string word)
			{
				object result;
				if (word.Length <= 0)
				{
					result = "";
				}
				else
				{
					char c = char.ToUpper(word[0]);
					result = string.Concat(new global::System.ReadOnlySpan<char>(ref c), string.op_Implicit(word.Substring(1)));
				}
				return (string)result;
			}));
		}
		return Regex.Replace(name, "([a-z])([A-Z])", "$1 $2");
	}

	public static string ToCompactNumber(int? number)
	{
		string[] array = new string[5] { "", "K", "M", "B", "T" };
		double num = number.GetValueOrDefault();
		int num2 = 0;
		while (num >= 1000.0 && num2 < array.Length - 1)
		{
			num /= 1000.0;
			num2++;
		}
		return (num % 1.0 == 0.0) ? $"{num:0}{array[num2]}" : $"{num:0.#}{array[num2]}";
	}
}
