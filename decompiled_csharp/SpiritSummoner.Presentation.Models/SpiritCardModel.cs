using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Microsoft.Maui.Graphics;
using SpiritSummoner.Application.Enums;
using SpiritSummoner.Application.Events;
using SpiritSummoner.Application.State;
using SpiritSummoner.Domain.Entities.Items;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Entities.Spirits;
using SpiritSummoner.Domain.Enums.Spirits;
using SpiritSummoner.Domain.Interfaces.Services;
using SpiritSummoner.Presentation.Utilities;

namespace SpiritSummoner.Presentation.Models;

public class SpiritCardModel : ObservableObject, global::System.IDisposable
{
	[CompilerGenerated]
	private sealed class _003CInitializeAsync_003Ed__54 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public SpiritCardModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					_003C_003E4__this.UpdateFromState();
					_003C_003E4__this._stateService.StateChanged += _003C_003E4__this.OnStateChanged;
					awaiter = global::System.Threading.Tasks.Task.CompletedTask.GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CInitializeAsync_003Ed__54 _003CInitializeAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CInitializeAsync_003Ed__54>(ref awaiter, ref _003CInitializeAsync_003Ed__);
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

	private readonly IPlayerStateService _stateService;

	private readonly ISpiritMoveResolver _moveResolver;

	private readonly string _playerSpiritId;

	private DateTimeOffset _dateOwned;

	private bool _disposed;

	private global::System.Collections.Generic.IReadOnlyList<ItemEffect?> _itemEffects = global::System.Array.Empty<ItemEffect>();

	[ObservableProperty]
	private int _baseSpiritId;

	[ObservableProperty]
	private string _name = string.Empty;

	[ObservableProperty]
	private string? _nickname;

	[ObservableProperty]
	private int _level;

	[ObservableProperty]
	private int _hP;

	[ObservableProperty]
	private SpiritType _type1;

	[ObservableProperty]
	private SpiritType _type2;

	[ObservableProperty]
	private string _image = string.Empty;

	[ObservableProperty]
	private bool _isFavorite;

	[ObservableProperty]
	private int _trainingPoints;

	[ObservableProperty]
	private string? _heldItemId;

	[ObservableProperty]
	private string? _talentId;

	[ObservableProperty]
	private string? _gearId;

	[ObservableProperty]
	private string? _class;

	[ObservableProperty]
	[NotifyPropertyChangedFor("HasClass2")]
	[NotifyPropertyChangedFor("TwoClasses")]
	private string? _class2;

	[ObservableProperty]
	private bool _isUnique;

	[ObservableProperty]
	private bool _hasEvolution;

	private bool _hasHPBuff;

	private bool _hasHPDebuff;

	[ObservableProperty]
	private ItemModel? _heldItem;

	public global::System.Collections.Generic.IReadOnlyList<ItemEffect?> ItemEffects => _itemEffects;

	public bool HasType2 => Type2 != SpiritType.None;

	public bool HasHPBuff
	{
		get
		{
			return _hasHPBuff;
		}
		private set
		{
			if (((ObservableObject)this).SetProperty<bool>(ref _hasHPBuff, value, "HasHPBuff"))
			{
				((ObservableObject)this).OnPropertyChanged("HPStrokeColor");
			}
		}
	}

	public bool HasHPDebuff
	{
		get
		{
			return _hasHPDebuff;
		}
		private set
		{
			if (((ObservableObject)this).SetProperty<bool>(ref _hasHPDebuff, value, "HasHPDebuff"))
			{
				((ObservableObject)this).OnPropertyChanged("HPStrokeColor");
			}
		}
	}

	public Color HPStrokeColor => HasHPDebuff ? Color.FromArgb("#E53F37") : (HasHPBuff ? Color.FromArgb("#4CAF50") : Colors.Black);

	public bool HasClass2 => !string.IsNullOrEmpty(Class2);

	public string TwoClasses => Class + "/" + Class2;

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public ObservableCollection<AttributeProgressModel> Attributes
	{
		[CompilerGenerated]
		get;
	} = new ObservableCollection<AttributeProgressModel>();


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public ObservableCollection<MoveEditableState> SpiritMoves
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	} = new ObservableCollection<MoveEditableState>();


	public string PlayerSpiritId => _playerSpiritId;

	public DateTimeOffset DateOwned => _dateOwned;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int BaseSpiritId
	{
		get
		{
			return _baseSpiritId;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_baseSpiritId, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.BaseSpiritId);
				_baseSpiritId = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.BaseSpiritId);
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
	public string? Nickname
	{
		get
		{
			return _nickname;
		}
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_nickname, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Nickname);
				_nickname = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Nickname);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int Level
	{
		get
		{
			return _level;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_level, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Level);
				_level = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Level);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int HP
	{
		get
		{
			return _hP;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_hP, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HP);
				_hP = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HP);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public SpiritType Type1
	{
		get
		{
			return _type1;
		}
		set
		{
			if (!EqualityComparer<SpiritType>.Default.Equals(_type1, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Type1);
				_type1 = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Type1);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public SpiritType Type2
	{
		get
		{
			return _type2;
		}
		set
		{
			if (!EqualityComparer<SpiritType>.Default.Equals(_type2, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Type2);
				_type2 = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Type2);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string Image
	{
		get
		{
			return _image;
		}
		[MemberNotNull("_image")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_image, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Image);
				_image = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Image);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsFavorite
	{
		get
		{
			return _isFavorite;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isFavorite, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsFavorite);
				_isFavorite = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsFavorite);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int TrainingPoints
	{
		get
		{
			return _trainingPoints;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_trainingPoints, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.TrainingPoints);
				_trainingPoints = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.TrainingPoints);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string? HeldItemId
	{
		get
		{
			return _heldItemId;
		}
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_heldItemId, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HeldItemId);
				_heldItemId = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HeldItemId);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string? TalentId
	{
		get
		{
			return _talentId;
		}
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_talentId, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.TalentId);
				_talentId = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.TalentId);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string? GearId
	{
		get
		{
			return _gearId;
		}
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_gearId, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.GearId);
				_gearId = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.GearId);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string? Class
	{
		get
		{
			return _class;
		}
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
	public string? Class2
	{
		get
		{
			return _class2;
		}
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_class2, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Class2);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HasClass2);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.TwoClasses);
				_class2 = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Class2);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HasClass2);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.TwoClasses);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsUnique
	{
		get
		{
			return _isUnique;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isUnique, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsUnique);
				_isUnique = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsUnique);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool HasEvolution
	{
		get
		{
			return _hasEvolution;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_hasEvolution, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HasEvolution);
				_hasEvolution = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HasEvolution);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ItemModel? HeldItem
	{
		get
		{
			return _heldItem;
		}
		set
		{
			if (!EqualityComparer<ItemModel>.Default.Equals(_heldItem, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HeldItem);
				_heldItem = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HeldItem);
			}
		}
	}

	public SpiritCardModel(string playerSpiritId, IPlayerStateService stateService, ISpiritMoveResolver moveResolver)
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		_playerSpiritId = playerSpiritId ?? throw new ArgumentNullException("playerSpiritId");
		_stateService = stateService ?? throw new ArgumentNullException("stateService");
		_moveResolver = moveResolver ?? throw new ArgumentNullException("moveResolver");
	}

	[AsyncStateMachine(typeof(_003CInitializeAsync_003Ed__54))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task InitializeAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CInitializeAsync_003Ed__54 _003CInitializeAsync_003Ed__ = new _003CInitializeAsync_003Ed__54();
		_003CInitializeAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CInitializeAsync_003Ed__._003C_003E4__this = this;
		_003CInitializeAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CInitializeAsync_003Ed__._003C_003Et__builder)).Start<_003CInitializeAsync_003Ed__54>(ref _003CInitializeAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CInitializeAsync_003Ed__._003C_003Et__builder)).Task;
	}

	private void UpdateFromState()
	{
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		PlayerSpirit playerSpirit = _stateService.GetPlayerSpirit(_playerSpiritId);
		if (playerSpirit == null)
		{
			return;
		}
		Spirit baseSpirit = _stateService.GetSpiritTemplate(playerSpirit.BaseSpiritID);
		if (baseSpirit == null)
		{
			return;
		}
		Name = baseSpirit.Name ?? string.Empty;
		Nickname = playerSpirit.Nickname;
		Level = playerSpirit.Level;
		Type1 = baseSpirit.Type1;
		Type2 = baseSpirit.Type2;
		Image = baseSpirit.Image ?? string.Empty;
		IsFavorite = playerSpirit.IsFavorite;
		TrainingPoints = playerSpirit.TrainingPoints;
		HeldItemId = playerSpirit.HeldItemID;
		TalentId = playerSpirit.TalentID;
		GearId = playerSpirit.GearID;
		Class = baseSpirit.Category;
		if (!string.IsNullOrEmpty(baseSpirit.Category2))
		{
			Class2 = baseSpirit.Category2;
		}
		IsUnique = baseSpirit.IsUnique;
		BaseSpiritId = playerSpirit.BaseSpiritID;
		_dateOwned = playerSpirit.DateOwned;
		HasEvolution = baseSpirit.Evolution > 0;
		ApplyItemEffectsToStats(playerSpirit, baseSpirit);
		((Collection<MoveEditableState>)(object)SpiritMoves).Clear();
		if (playerSpirit.Moves == null)
		{
			return;
		}
		IOrderedEnumerable<MoveEditableState> val = Enumerable.ThenBy<MoveEditableState, int>(Enumerable.OrderBy<MoveEditableState, bool>(Enumerable.Where<MoveEditableState>(Enumerable.Select<KeyValuePair<string, MoveState>, MoveEditableState>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, MoveState>>)playerSpirit.Moves, (Func<KeyValuePair<string, MoveState>, MoveEditableState>)delegate(KeyValuePair<string, MoveState> kvp)
		{
			Move move = _moveResolver.FindMoveTemplate(kvp.Key, baseSpirit);
			return new MoveEditableState(kvp.Key, kvp.Value.IsUnlocked, kvp.Value.IsActiveMove, move?.Type ?? SpiritType.None, move?.MoveType ?? MoveType.None, move?.Power ?? 0);
		}), (Func<MoveEditableState, bool>)((MoveEditableState m) => m.MoveType != MoveType.None)), (Func<MoveEditableState, bool>)((MoveEditableState m) => !m.IsActive)), (Func<MoveEditableState, int>)((MoveEditableState m) => m.Power));
		global::System.Collections.Generic.IEnumerator<MoveEditableState> enumerator = ((global::System.Collections.Generic.IEnumerable<MoveEditableState>)val).GetEnumerator();
		try
		{
			while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
			{
				MoveEditableState current = enumerator.Current;
				((Collection<MoveEditableState>)(object)SpiritMoves).Add(current);
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator)?.Dispose();
		}
	}

	private void OnStateChanged(object? sender, StateChangedEventArgs e)
	{
		if (e.Scope != StateChangeScope.Spirit || e.EntityId != _playerSpiritId)
		{
			return;
		}
		string changeType = e.ChangeType;
		string text = changeType;
		switch (_003CPrivateImplementationDetails_003E.ComputeStringHash(text))
		{
		case 3801025005u:
			if (text == "Nickname")
			{
				Nickname = _stateService.GetPlayerSpirit(_playerSpiritId)?.Nickname;
			}
			break;
		case 1096112509u:
			if (!(text == "Level"))
			{
				break;
			}
			goto IL_01e0;
		case 2974723220u:
			if (!(text == "StatPoints"))
			{
				break;
			}
			goto IL_01e0;
		case 3067266288u:
			if (text == "Evolve")
			{
				UpdateFromState();
			}
			break;
		case 2087459309u:
			if (text == "Favorite")
			{
				IsFavorite = _stateService.GetPlayerSpirit(_playerSpiritId)?.IsFavorite ?? false;
			}
			break;
		case 4181705213u:
			if (text == "HeldItem")
			{
				HeldItemId = _stateService.GetPlayerSpirit(_playerSpiritId)?.HeldItemID;
			}
			break;
		case 4184099403u:
			if (text == "Talent")
			{
				TalentId = _stateService.GetPlayerSpirit(_playerSpiritId)?.TalentID;
			}
			break;
		case 4214442830u:
			if (text == "Gear")
			{
				GearId = _stateService.GetPlayerSpirit(_playerSpiritId)?.GearID;
			}
			break;
		case 2038861253u:
		{
			if (!(text == "Moves"))
			{
				break;
			}
			PlayerSpirit playerSpirit = _stateService.GetPlayerSpirit(_playerSpiritId);
			if (playerSpirit == null)
			{
				break;
			}
			Spirit baseSpirit = _stateService.GetSpiritTemplate(playerSpirit.BaseSpiritID);
			if (baseSpirit?.LearnableMoves == null)
			{
				break;
			}
			((Collection<MoveEditableState>)(object)SpiritMoves).Clear();
			IOrderedEnumerable<MoveEditableState> val = Enumerable.ThenBy<MoveEditableState, int>(Enumerable.OrderBy<MoveEditableState, bool>(Enumerable.Where<MoveEditableState>(Enumerable.Select<KeyValuePair<string, MoveState>, MoveEditableState>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, MoveState>>)playerSpirit.Moves, (Func<KeyValuePair<string, MoveState>, MoveEditableState>)delegate(KeyValuePair<string, MoveState> kvp)
			{
				Move move = _moveResolver.FindMoveTemplate(kvp.Key, baseSpirit);
				return new MoveEditableState(kvp.Key, kvp.Value.IsUnlocked, kvp.Value.IsActiveMove, move?.Type ?? SpiritType.None, move?.MoveType ?? MoveType.None, move?.Power ?? 0);
			}), (Func<MoveEditableState, bool>)((MoveEditableState m) => m.MoveType != MoveType.None)), (Func<MoveEditableState, bool>)((MoveEditableState m) => !m.IsActive)), (Func<MoveEditableState, int>)((MoveEditableState m) => m.Power));
			global::System.Collections.Generic.IEnumerator<MoveEditableState> enumerator = ((global::System.Collections.Generic.IEnumerable<MoveEditableState>)val).GetEnumerator();
			try
			{
				while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
				{
					MoveEditableState current = enumerator.Current;
					((Collection<MoveEditableState>)(object)SpiritMoves).Add(current);
				}
				break;
			}
			finally
			{
				((global::System.IDisposable)enumerator)?.Dispose();
			}
		}
		case 1974461284u:
			{
				if (text == "All")
				{
					UpdateFromState();
				}
				break;
			}
			IL_01e0:
			UpdateFromState();
			break;
		}
	}

	public void SetItemEffects(global::System.Collections.Generic.IEnumerable<ItemEffect?> effects)
	{
		_itemEffects = (global::System.Collections.Generic.IReadOnlyList<ItemEffect?>)Enumerable.ToList<ItemEffect>(effects);
		PlayerSpirit playerSpirit = _stateService.GetPlayerSpirit(_playerSpiritId);
		if (playerSpirit != null)
		{
			Spirit spiritTemplate = _stateService.GetSpiritTemplate(playerSpirit.BaseSpiritID);
			if (spiritTemplate != null)
			{
				ApplyItemEffectsToStats(playerSpirit, spiritTemplate);
			}
		}
	}

	private void ApplyItemEffectsToStats(PlayerSpirit playerSpirit, Spirit baseSpirit)
	{
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		Dictionary<string, float> val = new Dictionary<string, float>((IEqualityComparer<string>)(object)StringComparer.OrdinalIgnoreCase);
		Dictionary<string, double> val2 = new Dictionary<string, double>((IEqualityComparer<string>)(object)StringComparer.OrdinalIgnoreCase);
		global::System.Collections.Generic.IEnumerator<ItemEffect> enumerator = ((global::System.Collections.Generic.IEnumerable<ItemEffect>)_itemEffects).GetEnumerator();
		try
		{
			string text = default(string);
			float num = default(float);
			float num3 = default(float);
			double num4 = default(double);
			double num6 = default(double);
			while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
			{
				ItemEffect current = enumerator.Current;
				if (current == null)
				{
					continue;
				}
				if (current.FlatStatChanges != null)
				{
					Enumerator<string, float> enumerator2 = current.FlatStatChanges.GetEnumerator();
					try
					{
						while (enumerator2.MoveNext())
						{
							enumerator2.Current.Deconstruct(ref text, ref num);
							string text2 = text;
							float num2 = num;
							val.TryGetValue(text2, ref num3);
							val[text2] = num3 + num2;
						}
					}
					finally
					{
						((global::System.IDisposable)enumerator2).Dispose();
					}
				}
				if (current.StatMultipliers == null)
				{
					continue;
				}
				Enumerator<string, double> enumerator3 = current.StatMultipliers.GetEnumerator();
				try
				{
					while (enumerator3.MoveNext())
					{
						enumerator3.Current.Deconstruct(ref text, ref num4);
						string text3 = text;
						double num5 = num4;
						val2.TryGetValue(text3, ref num6);
						val2[text3] = ((num6 == 0.0) ? 1.0 : num6) * num5;
					}
				}
				finally
				{
					((global::System.IDisposable)enumerator3).Dispose();
				}
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator)?.Dispose();
		}
		float valueOrDefault = CollectionExtensions.GetValueOrDefault<string, float>((IReadOnlyDictionary<string, float>)(object)val, "HP", 0f);
		double num7 = CollectionExtensions.GetValueOrDefault<string, double>((IReadOnlyDictionary<string, double>)(object)val2, "HP", 1.0);
		if (num7 == 0.0)
		{
			num7 = 1.0;
		}
		int num8 = (int)((double)((float)playerSpirit.HP + valueOrDefault) * num7);
		HasHPBuff = num8 > playerSpirit.HP;
		HasHPDebuff = num8 < playerSpirit.HP;
		HP = num8;
		((Collection<AttributeProgressModel>)(object)Attributes).Clear();
		global::System.Collections.Generic.IReadOnlyList<AttributeProgressModel> readOnlyList = AttributeProgressCalculator.Calculate(playerSpirit, baseSpirit, (global::System.Collections.Generic.IEnumerable<ItemEffect?>?)_itemEffects);
		global::System.Collections.Generic.IEnumerator<AttributeProgressModel> enumerator4 = ((global::System.Collections.Generic.IEnumerable<AttributeProgressModel>)readOnlyList).GetEnumerator();
		try
		{
			while (((global::System.Collections.IEnumerator)enumerator4).MoveNext())
			{
				AttributeProgressModel current2 = enumerator4.Current;
				((Collection<AttributeProgressModel>)(object)Attributes).Add(current2);
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator4)?.Dispose();
		}
	}

	public void Dispose()
	{
		if (!_disposed)
		{
			_stateService.StateChanged -= OnStateChanged;
			_disposed = true;
			GC.SuppressFinalize((object)this);
		}
	}

	~SpiritCardModel()
	{
		try
		{
			if (!_disposed)
			{
				Debug.WriteLine("⚠\ufe0f MEMORY LEAK: SpiritCardModel for spirit '" + _playerSpiritId + "' was not disposed! This will leak event subscriptions. Ensure ViewModels call Dispose() or use 'using' statements.");
				Dispose();
			}
		}
		finally
		{
			((object)this).Finalize();
		}
	}
}
