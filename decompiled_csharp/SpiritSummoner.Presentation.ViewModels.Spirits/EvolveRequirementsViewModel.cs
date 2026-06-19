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
using CommunityToolkit.Mvvm.Input;
using SpiritSummoner.Application.DTOs;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Application.UseCases.Shop;
using SpiritSummoner.Application.UseCases.Spirits;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Entities.Requirements;
using SpiritSummoner.Domain.Entities.Spirits;
using SpiritSummoner.Domain.Enums.Spirits;
using SpiritSummoner.Infrastructure.Cache;
using SpiritSummoner.Presentation.Models;
using SpiritSummoner.Presentation.Navigation;
using SpiritSummoner.Presentation.Utilities;

namespace SpiritSummoner.Presentation.ViewModels.Spirits;

public class EvolveRequirementsViewModel : ObservableObject, ILoadableViewModel
{
	[CompilerGenerated]
	private sealed class _003CClose_003Ed__32 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public EvolveRequirementsViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = _003C_003E4__this._navigationService.GoBackAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CClose_003Ed__32 _003CClose_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CClose_003Ed__32>(ref awaiter, ref _003CClose_003Ed__);
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
	private sealed class _003CLoadDataAsync_003Ed__28 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public object id;

		public EvolveRequirementsViewModel _003C_003E4__this;

		private string _003CspiritId_003E5__1;

		private PlayerSpirit _003Cspirit_003E5__2;

		private Spirit _003Ctemplate_003E5__3;

		private Player _003Cplayer_003E5__4;

		private Result<GetSpiritPreviewResponse> _003CpreviewResult_003E5__5;

		private Result<GetSpiritPreviewResponse> _003C_003Es__6;

		private SpiritPreviewDTO _003Cpreview_003E5__7;

		private global::System.Collections.Generic.IEnumerator<AttributeProgressModel> _003C_003Es__8;

		private AttributeProgressModel _003Cattr_003E5__9;

		private global::System.Collections.Generic.IEnumerator<ValueTuple<string, int, string, string>> _003C_003Es__10;

		private string _003CmoveName_003E5__11;

		private int _003CmovePower_003E5__12;

		private string _003Ctype_003E5__13;

		private string _003CmoveType_003E5__14;

		private SpiritType _003CparsedType_003E5__15;

		private MoveType _003CparsedMoveType_003E5__16;

		private TaskAwaiter<Result<GetSpiritPreviewResponse>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01de: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_019f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_03af: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_03de: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter<Result<GetSpiritPreviewResponse>> awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Result<GetSpiritPreviewResponse>>);
					num = (_003C_003E1__state = -1);
					goto IL_01f5;
				}
				_003CspiritId_003E5__1 = id as string;
				if (_003CspiritId_003E5__1 != null && !string.IsNullOrEmpty(_003CspiritId_003E5__1))
				{
					_003C_003E4__this._spiritId = _003CspiritId_003E5__1;
					_003Cspirit_003E5__2 = _003C_003E4__this._playerStateService.GetPlayerSpirit(_003CspiritId_003E5__1);
					if (_003Cspirit_003E5__2 != null)
					{
						_003Ctemplate_003E5__3 = _003C_003E4__this._playerStateService.GetSpiritTemplate(_003Cspirit_003E5__2.BaseSpiritID);
						if (_003Ctemplate_003E5__3 != null && _003Ctemplate_003E5__3.Evolution != 0)
						{
							_003Cplayer_003E5__4 = _003C_003E4__this._playerStateService.GetCurrentPlayer();
							if (_003Cplayer_003E5__4 != null)
							{
								_003C_003E4__this.PreEvoName = _003Ctemplate_003E5__3.Name ?? string.Empty;
								_003C_003E4__this.PreEvoImage = _003Ctemplate_003E5__3.Image ?? string.Empty;
								_003C_003E4__this.PreEvoType1 = ((object)_003Ctemplate_003E5__3.Type1).ToString();
								((Collection<AttributeProgressModel>)(object)_003C_003E4__this.Attributes).Clear();
								((Collection<MoveStateReadModel>)(object)_003C_003E4__this.Moves).Clear();
								awaiter = _003C_003E4__this._getSpiritPreviewUseCase.ExecuteAsync(new GetSpiritPreviewRequest(_003Ctemplate_003E5__3.Evolution.ToString())).GetAwaiter();
								if (!awaiter.IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter;
									_003CLoadDataAsync_003Ed__28 _003CLoadDataAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<GetSpiritPreviewResponse>>, _003CLoadDataAsync_003Ed__28>(ref awaiter, ref _003CLoadDataAsync_003Ed__);
									return;
								}
								goto IL_01f5;
							}
						}
					}
				}
				goto end_IL_0007;
				IL_01f5:
				_003C_003Es__6 = awaiter.GetResult();
				_003CpreviewResult_003E5__5 = _003C_003Es__6;
				_003C_003Es__6 = null;
				if (_003CpreviewResult_003E5__5.Success && _003CpreviewResult_003E5__5.Data != null)
				{
					_003Cpreview_003E5__7 = _003CpreviewResult_003E5__5.Data.SpiritPreview;
					_003C_003E4__this.SpiritPreview = _003Cpreview_003E5__7;
					_003C_003E4__this.EvolvedName = _003Cpreview_003E5__7.Name;
					_003C_003E4__this.EvolvedClass = _003Cpreview_003E5__7.Category;
					_003C_003E4__this.EvolvedImage = _003Cpreview_003E5__7.Image;
					_003C_003E4__this.Type1 = _003Cpreview_003E5__7.Type1;
					_003C_003E4__this.Type2 = _003Cpreview_003E5__7.Type2;
					_003C_003E4__this.EvolvedHP = _003Cpreview_003E5__7.HP;
					_003C_003Es__8 = ((global::System.Collections.Generic.IEnumerable<AttributeProgressModel>)AttributeProgressCalculator.Calculate(_003Cpreview_003E5__7)).GetEnumerator();
					try
					{
						while (((global::System.Collections.IEnumerator)_003C_003Es__8).MoveNext())
						{
							_003Cattr_003E5__9 = _003C_003Es__8.Current;
							((Collection<AttributeProgressModel>)(object)_003C_003E4__this.Attributes).Add(_003Cattr_003E5__9);
							_003Cattr_003E5__9 = null;
						}
					}
					finally
					{
						if (num < 0 && _003C_003Es__8 != null)
						{
							((global::System.IDisposable)_003C_003Es__8).Dispose();
						}
					}
					_003C_003Es__8 = null;
					_003C_003Es__10 = ((global::System.Collections.Generic.IEnumerable<ValueTuple<string, int, string, string>>)Enumerable.OrderBy<ValueTuple<string, int, string, string>, int>((global::System.Collections.Generic.IEnumerable<ValueTuple<string, int, string, string>>)_003Cpreview_003E5__7.LearnableMoves, (Func<ValueTuple<string, int, string, string>, int>)((ValueTuple<string, int, string, string> m) => m.Item2))).GetEnumerator();
					try
					{
						while (((global::System.Collections.IEnumerator)_003C_003Es__10).MoveNext())
						{
							ValueTuple<string, int, string, string> current = _003C_003Es__10.Current;
							_003CmoveName_003E5__11 = current.Item1;
							_003CmovePower_003E5__12 = current.Item2;
							_003Ctype_003E5__13 = current.Item3;
							_003CmoveType_003E5__14 = current.Item4;
							((Collection<MoveStateReadModel>)(object)_003C_003E4__this.Moves).Add(new MoveStateReadModel(_003CmoveName_003E5__11, IsUnlocked: true, IsActive: true, global::System.Enum.TryParse<SpiritType>(_003Ctype_003E5__13, ref _003CparsedType_003E5__15) ? _003CparsedType_003E5__15 : SpiritType.None, global::System.Enum.TryParse<MoveType>(_003CmoveType_003E5__14, ref _003CparsedMoveType_003E5__16) ? _003CparsedMoveType_003E5__16 : MoveType.None, _003CmovePower_003E5__12));
							_003CmoveName_003E5__11 = null;
							_003Ctype_003E5__13 = null;
							_003CmoveType_003E5__14 = null;
						}
					}
					finally
					{
						if (num < 0 && _003C_003Es__10 != null)
						{
							((global::System.IDisposable)_003C_003Es__10).Dispose();
						}
					}
					_003C_003Es__10 = null;
					_003Cpreview_003E5__7 = null;
				}
				_003C_003E4__this.BuildRequirements(_003Ctemplate_003E5__3, _003Cspirit_003E5__2.Level, _003Cplayer_003E5__4);
				_003C_003E4__this.IsLoaded = true;
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003CspiritId_003E5__1 = null;
				_003Cspirit_003E5__2 = null;
				_003Ctemplate_003E5__3 = null;
				_003Cplayer_003E5__4 = null;
				_003CpreviewResult_003E5__5 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CspiritId_003E5__1 = null;
			_003Cspirit_003E5__2 = null;
			_003Ctemplate_003E5__3 = null;
			_003Cplayer_003E5__4 = null;
			_003CpreviewResult_003E5__5 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CTransform_003Ed__31 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public EvolveRequirementsViewModel _003C_003E4__this;

		private string _003CcurrentRoute_003E5__1;

		private int _003Cidx_003E5__2;

		private string _003CparentRoute_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00fb;
				}
				if (!string.IsNullOrEmpty(_003C_003E4__this._spiritId))
				{
					_003CcurrentRoute_003E5__1 = _003C_003E4__this._playerStateService.CurrentRoute;
					_003Cidx_003E5__2 = _003CcurrentRoute_003E5__1.IndexOf("/evolverequirements", (StringComparison)4);
					_003CparentRoute_003E5__3 = ((_003Cidx_003E5__2 >= 0) ? _003CcurrentRoute_003E5__1.Substring(0, _003Cidx_003E5__2) : _003CcurrentRoute_003E5__1);
					awaiter = _003C_003E4__this._navigationService.NavigateToAsync(_003CparentRoute_003E5__3 + "/evolve?spiritID=" + _003C_003E4__this._spiritId).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CTransform_003Ed__31 _003CTransform_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CTransform_003Ed__31>(ref awaiter, ref _003CTransform_003Ed__);
						return;
					}
					goto IL_00fb;
				}
				goto end_IL_0007;
				IL_00fb:
				((TaskAwaiter)(ref awaiter)).GetResult();
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003CcurrentRoute_003E5__1 = null;
				_003CparentRoute_003E5__3 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CcurrentRoute_003E5__1 = null;
			_003CparentRoute_003E5__3 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly INavigationService _navigationService;

	private readonly IPlayerStateService _playerStateService;

	private readonly GetSpiritPreviewUseCase _getSpiritPreviewUseCase;

	private string? _spiritId;

	[ObservableProperty]
	private bool _isLoaded;

	[ObservableProperty]
	private SpiritPreviewDTO? _spiritPreview;

	[ObservableProperty]
	private string _evolvedName = string.Empty;

	[ObservableProperty]
	private string _evolvedClass = string.Empty;

	[ObservableProperty]
	private string _evolvedImage = string.Empty;

	[ObservableProperty]
	private string _type1 = string.Empty;

	[ObservableProperty]
	private string _type2 = string.Empty;

	[ObservableProperty]
	private int _evolvedHP;

	[ObservableProperty]
	private string _preEvoName = string.Empty;

	[ObservableProperty]
	private string _preEvoImage = string.Empty;

	[ObservableProperty]
	private string _preEvoType1 = string.Empty;

	[ObservableProperty]
	private string _requiredLevelText = string.Empty;

	[ObservableProperty]
	private bool _requiredLevelMet = true;

	[ObservableProperty]
	[NotifyCanExecuteChangedFor("TransformCommand")]
	private bool _canTransform;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? transformCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? closeCommand;

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public ObservableCollection<AttributeProgressModel> Attributes
	{
		[CompilerGenerated]
		get;
	} = new ObservableCollection<AttributeProgressModel>();


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public ObservableCollection<MoveStateReadModel> Moves
	{
		[CompilerGenerated]
		get;
	} = new ObservableCollection<MoveStateReadModel>();


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public ObservableCollection<RequirementChip> Requirements
	{
		[CompilerGenerated]
		get;
	} = new ObservableCollection<RequirementChip>();


	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsLoaded
	{
		get
		{
			return _isLoaded;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isLoaded, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsLoaded);
				_isLoaded = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsLoaded);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public SpiritPreviewDTO? SpiritPreview
	{
		get
		{
			return _spiritPreview;
		}
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
	public string EvolvedName
	{
		get
		{
			return _evolvedName;
		}
		[MemberNotNull("_evolvedName")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_evolvedName, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.EvolvedName);
				_evolvedName = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.EvolvedName);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string EvolvedClass
	{
		get
		{
			return _evolvedClass;
		}
		[MemberNotNull("_evolvedClass")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_evolvedClass, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.EvolvedClass);
				_evolvedClass = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.EvolvedClass);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string EvolvedImage
	{
		get
		{
			return _evolvedImage;
		}
		[MemberNotNull("_evolvedImage")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_evolvedImage, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.EvolvedImage);
				_evolvedImage = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.EvolvedImage);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string Type1
	{
		get
		{
			return _type1;
		}
		[MemberNotNull("_type1")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_type1, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Type1);
				_type1 = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Type1);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string Type2
	{
		get
		{
			return _type2;
		}
		[MemberNotNull("_type2")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_type2, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Type2);
				_type2 = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Type2);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int EvolvedHP
	{
		get
		{
			return _evolvedHP;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_evolvedHP, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.EvolvedHP);
				_evolvedHP = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.EvolvedHP);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string PreEvoName
	{
		get
		{
			return _preEvoName;
		}
		[MemberNotNull("_preEvoName")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_preEvoName, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.PreEvoName);
				_preEvoName = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.PreEvoName);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string PreEvoImage
	{
		get
		{
			return _preEvoImage;
		}
		[MemberNotNull("_preEvoImage")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_preEvoImage, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.PreEvoImage);
				_preEvoImage = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.PreEvoImage);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string PreEvoType1
	{
		get
		{
			return _preEvoType1;
		}
		[MemberNotNull("_preEvoType1")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_preEvoType1, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.PreEvoType1);
				_preEvoType1 = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.PreEvoType1);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string RequiredLevelText
	{
		get
		{
			return _requiredLevelText;
		}
		[MemberNotNull("_requiredLevelText")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_requiredLevelText, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.RequiredLevelText);
				_requiredLevelText = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.RequiredLevelText);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool RequiredLevelMet
	{
		get
		{
			return _requiredLevelMet;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_requiredLevelMet, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.RequiredLevelMet);
				_requiredLevelMet = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.RequiredLevelMet);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool CanTransform
	{
		get
		{
			return _canTransform;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_canTransform, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CanTransform);
				_canTransform = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CanTransform);
				((IRelayCommand)TransformCommand).NotifyCanExecuteChanged();
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand TransformCommand
	{
		get
		{
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Expected O, but got Unknown
			//IL_002f: Expected O, but got Unknown
			AsyncRelayCommand obj = transformCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)Transform, (Func<bool>)CanExecuteTransform);
				AsyncRelayCommand val2 = val;
				transformCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand CloseCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = closeCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)Close);
				AsyncRelayCommand val2 = val;
				closeCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	public EvolveRequirementsViewModel(INavigationService navigationService, IPlayerStateService playerStateService, GetSpiritPreviewUseCase getSpiritPreviewUseCase)
	{
		_navigationService = navigationService;
		_playerStateService = playerStateService;
		_getSpiritPreviewUseCase = getSpiritPreviewUseCase;
	}

	[AsyncStateMachine(typeof(_003CLoadDataAsync_003Ed__28))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task LoadDataAsync(object? id)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadDataAsync_003Ed__28 _003CLoadDataAsync_003Ed__ = new _003CLoadDataAsync_003Ed__28();
		_003CLoadDataAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadDataAsync_003Ed__._003C_003E4__this = this;
		_003CLoadDataAsync_003Ed__.id = id;
		_003CLoadDataAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadDataAsync_003Ed__28>(ref _003CLoadDataAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Task;
	}

	private void BuildRequirements(Spirit template, int spiritLevel, Player player)
	{
		((Collection<RequirementChip>)(object)Requirements).Clear();
		EvolveRequirement evolveRequirement = template.Requirements?.EvolveRequirements;
		string text = evolveRequirement?.ItemRequired;
		int num = evolveRequirement?.Amount ?? 1;
		int num2 = evolveRequirement?.LevelRequired ?? 0;
		int num3 = evolveRequirement?.CoresRequired ?? 10;
		bool flag = !string.IsNullOrEmpty(text) && (string.Equals(text, "gold", (StringComparison)5) || text.Contains("Orb", (StringComparison)1));
		bool flag2 = text?.Contains("Orb", (StringComparison)1) ?? false;
		string text2 = ((!flag2) ? (template.Name + " Orb #" + template.ID) : (text ?? string.Empty));
		string text3 = evolveRequirement?.Special ?? string.Empty;
		if (string.IsNullOrEmpty(text3))
		{
			text3 = EvolveSpiritUseCase.GetEvoItemRequired(template.Type1);
		}
		bool flag3 = true;
		if (num2 > 0)
		{
			RequiredLevelMet = spiritLevel >= num2;
			flag3 &= RequiredLevelMet;
			RequiredLevelText = $"Required Level: {num2}";
		}
		else
		{
			RequiredLevelMet = true;
			RequiredLevelText = string.Empty;
		}
		if (!string.IsNullOrEmpty(text) && num > 0)
		{
			if (flag)
			{
				long valueOrDefault = CollectionExtensions.GetValueOrDefault<string, long>(player.Currencies, "gold", 0L);
				bool flag4 = valueOrDefault >= num;
				flag3 = flag3 && flag4;
				((Collection<RequirementChip>)(object)Requirements).Add(new RequirementChip
				{
					Icon = "icon_gold.png",
					Label = "GOLD",
					Required = SpiritDetailsViewModel.ToCompactNumber(num),
					Have = SpiritDetailsViewModel.ToCompactNumber(valueOrDefault),
					IsMet = flag4
				});
			}
			else if (!flag2)
			{
				Inventory inventory = default(Inventory);
				int num4 = (player.Inventory.TryGetValue(text, ref inventory) ? inventory.Amount : 0);
				bool flag5 = num4 >= num;
				flag3 = flag3 && flag5;
				((Collection<RequirementChip>)(object)Requirements).Add(new RequirementChip
				{
					Icon = "icon_" + text + ".png",
					Label = text.ToUpperInvariant(),
					Required = num.ToString(),
					Have = num4.ToString(),
					IsMet = flag5
				});
			}
		}
		if (num3 > 0 && !string.IsNullOrEmpty(text2))
		{
			Inventory inventory2 = default(Inventory);
			int num5 = (player.Inventory.TryGetValue(text2, ref inventory2) ? inventory2.Amount : 0);
			bool flag6 = num5 >= num3;
			flag3 = flag3 && flag6;
			((Collection<RequirementChip>)(object)Requirements).Add(new RequirementChip
			{
				Icon = "core_icon.png",
				Label = "ORBS",
				Required = num3.ToString(),
				Have = num5.ToString(),
				IsMet = flag6
			});
		}
		if (!string.IsNullOrEmpty(text3))
		{
			Inventory inventory3 = default(Inventory);
			int num6 = (player.Inventory.TryGetValue(text3, ref inventory3) ? inventory3.Amount : 0);
			bool flag7 = num6 >= 1;
			flag3 = flag3 && flag7;
			((Collection<RequirementChip>)(object)Requirements).Add(new RequirementChip
			{
				Icon = "icon_" + text3 + ".png",
				Label = text3.ToUpperInvariant(),
				Required = "1",
				Have = num6.ToString(),
				IsMet = flag7
			});
		}
		CanTransform = flag3;
	}

	private bool CanExecuteTransform()
	{
		return CanTransform;
	}

	[AsyncStateMachine(typeof(_003CTransform_003Ed__31))]
	[DebuggerStepThrough]
	[RelayCommand(CanExecute = "CanExecuteTransform")]
	private global::System.Threading.Tasks.Task Transform()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CTransform_003Ed__31 _003CTransform_003Ed__ = new _003CTransform_003Ed__31();
		_003CTransform_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CTransform_003Ed__._003C_003E4__this = this;
		_003CTransform_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CTransform_003Ed__._003C_003Et__builder)).Start<_003CTransform_003Ed__31>(ref _003CTransform_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CTransform_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CClose_003Ed__32))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task Close()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CClose_003Ed__32 _003CClose_003Ed__ = new _003CClose_003Ed__32();
		_003CClose_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CClose_003Ed__._003C_003E4__this = this;
		_003CClose_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CClose_003Ed__._003C_003Et__builder)).Start<_003CClose_003Ed__32>(ref _003CClose_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CClose_003Ed__._003C_003Et__builder)).Task;
	}
}
