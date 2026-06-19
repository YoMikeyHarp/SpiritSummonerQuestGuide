using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.DTOs;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Entities.Spirits;
using SpiritSummoner.Domain.Interfaces.Services;
using SpiritSummoner.Domain.Repositories;

namespace SpiritSummoner.Application.UseCases.Shop;

public class GetSpiritPreviewUseCase : IUseCase<GetSpiritPreviewRequest, GetSpiritPreviewResponse>
{
	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__5 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<GetSpiritPreviewResponse>> _003C_003Et__builder;

		public GetSpiritPreviewRequest request;

		public GetSpiritPreviewUseCase _003C_003E4__this;

		private Spirit _003CbaseSpirit_003E5__1;

		private string _003CcurrencyType_003E5__2;

		private int _003CcurrencyAmount_003E5__3;

		private string _003CorbName_003E5__4;

		private int _003CorbAmount_003E5__5;

		private Player _003Cplayer_003E5__6;

		private int _003CspiritLevel_003E5__7;

		private SpiritPreviewDTO _003CpreviewDto_003E5__8;

		private Spirit _003C_003Es__9;

		private TaskAwaiter<Spirit?> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0207: Unknown result type (might be due to invalid IL or missing references)
			//IL_020c: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<GetSpiritPreviewResponse> result;
			try
			{
				TaskAwaiter<Spirit> awaiter;
				if (num != 0)
				{
					awaiter = _003C_003E4__this._spiritRepository.GetByIdAsync(request.BaseSpiritId).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CExecuteAsync_003Ed__5 _003CExecuteAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Spirit>, _003CExecuteAsync_003Ed__5>(ref awaiter, ref _003CExecuteAsync_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Spirit>);
					num = (_003C_003E1__state = -1);
				}
				_003C_003Es__9 = awaiter.GetResult();
				_003CbaseSpirit_003E5__1 = _003C_003Es__9;
				_003C_003Es__9 = null;
				if (_003CbaseSpirit_003E5__1 == null)
				{
					result = Result<GetSpiritPreviewResponse>.FailureResult("Spirit not found");
				}
				else
				{
					_003CcurrencyType_003E5__2 = _003CbaseSpirit_003E5__1.Requirements?.CurrencyCost?.Type ?? "gold";
					_003CcurrencyAmount_003E5__3 = (_003CbaseSpirit_003E5__1.Requirements?.CurrencyCost?.Amount).GetValueOrDefault();
					_003CorbName_003E5__4 = _003CbaseSpirit_003E5__1.Requirements?.ItemRequirement?.ItemType ?? string.Empty;
					_003CorbAmount_003E5__5 = (_003CbaseSpirit_003E5__1.Requirements?.ItemRequirement?.Amount).GetValueOrDefault(1);
					_003Cplayer_003E5__6 = _003C_003E4__this._playerStateService.GetCurrentPlayer();
					if (_003Cplayer_003E5__6 == null)
					{
						result = Result<GetSpiritPreviewResponse>.FailureResult("No active session");
					}
					else
					{
						_003CspiritLevel_003E5__7 = Math.Max(1, _003Cplayer_003E5__6.PlayerLevel / 3);
						SpiritPreviewDTO spiritPreviewDTO = new SpiritPreviewDTO();
						Guid val = Guid.NewGuid();
						spiritPreviewDTO.PreviewId = ((object)(Guid)(ref val)).ToString();
						spiritPreviewDTO.BaseSpiritId = int.Parse(_003CbaseSpirit_003E5__1.ID);
						spiritPreviewDTO.Name = _003CbaseSpirit_003E5__1.Name ?? string.Empty;
						spiritPreviewDTO.Type1 = ((object)_003CbaseSpirit_003E5__1.Type1).ToString();
						spiritPreviewDTO.Type2 = ((object)_003CbaseSpirit_003E5__1.Type2).ToString() ?? string.Empty;
						spiritPreviewDTO.Image = _003CbaseSpirit_003E5__1.Image ?? string.Empty;
						spiritPreviewDTO.Category = _003CbaseSpirit_003E5__1.Category ?? string.Empty;
						spiritPreviewDTO.Level = _003CspiritLevel_003E5__7;
						spiritPreviewDTO.HP = _003C_003E4__this._playerSpiritFactory.CalculateInitialHP(_003CbaseSpirit_003E5__1, _003CspiritLevel_003E5__7);
						spiritPreviewDTO.TrainingPoints = _003C_003E4__this._playerSpiritFactory.CalculateInitialTrainingPoints(_003CspiritLevel_003E5__7);
						spiritPreviewDTO.BaseHP = _003CbaseSpirit_003E5__1.BaseStats.HP;
						spiritPreviewDTO.BaseATK = _003CbaseSpirit_003E5__1.BaseStats.ATK;
						spiritPreviewDTO.BaseDEF = _003CbaseSpirit_003E5__1.BaseStats.DEF;
						spiritPreviewDTO.BaseSATK = _003CbaseSpirit_003E5__1.BaseStats.SATK;
						spiritPreviewDTO.BaseSDEF = _003CbaseSpirit_003E5__1.BaseStats.SDEF;
						spiritPreviewDTO.BaseSPD = _003CbaseSpirit_003E5__1.BaseStats.SPD;
						spiritPreviewDTO.BaseINT = _003CbaseSpirit_003E5__1.BaseStats.INT;
						spiritPreviewDTO.BonusATK = _003CbaseSpirit_003E5__1.BonusAttributes?.ATK ?? 1.0;
						spiritPreviewDTO.BonusDEF = _003CbaseSpirit_003E5__1.BonusAttributes?.DEF ?? 1.0;
						spiritPreviewDTO.BonusSATK = _003CbaseSpirit_003E5__1.BonusAttributes?.SATK ?? 1.0;
						spiritPreviewDTO.BonusSDEF = _003CbaseSpirit_003E5__1.BonusAttributes?.SDEF ?? 1.0;
						spiritPreviewDTO.BonusSPD = _003CbaseSpirit_003E5__1.BonusAttributes?.SPD ?? 1.0;
						spiritPreviewDTO.BonusINT = _003CbaseSpirit_003E5__1.BonusAttributes?.INT ?? 1.0;
						spiritPreviewDTO.LearnableMoves = Enumerable.ToList<ValueTuple<string, int, string, string>>(Enumerable.Select<Move, ValueTuple<string, int, string, string>>((global::System.Collections.Generic.IEnumerable<Move>)_003CbaseSpirit_003E5__1.LearnableMoves, (Func<Move, ValueTuple<string, int, string, string>>)((Move x) => new ValueTuple<string, int, string, string>(x.Name, x.Power, ((object)x.Type).ToString(), ((object)x.MoveType).ToString()))));
						_003CpreviewDto_003E5__8 = spiritPreviewDTO;
						result = Result<GetSpiritPreviewResponse>.SuccessResult(new GetSpiritPreviewResponse(_003CpreviewDto_003E5__8, _003CcurrencyType_003E5__2, _003CcurrencyAmount_003E5__3, _003CorbName_003E5__4, _003CorbAmount_003E5__5));
					}
				}
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003CbaseSpirit_003E5__1 = null;
				_003CcurrencyType_003E5__2 = null;
				_003CorbName_003E5__4 = null;
				_003Cplayer_003E5__6 = null;
				_003CpreviewDto_003E5__8 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CbaseSpirit_003E5__1 = null;
			_003CcurrencyType_003E5__2 = null;
			_003CorbName_003E5__4 = null;
			_003Cplayer_003E5__6 = null;
			_003CpreviewDto_003E5__8 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private const int LEVEL_DIVISOR = 3;

	private readonly ISpiritRepository _spiritRepository;

	private readonly IPlayerStateService _playerStateService;

	private readonly IPlayerSpiritFactory _playerSpiritFactory;

	public GetSpiritPreviewUseCase(ISpiritRepository spiritRepository, IPlayerStateService playerStateService, IPlayerSpiritFactory playerSpiritFactory)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		_spiritRepository = spiritRepository ?? throw new ArgumentNullException("spiritRepository");
		_playerStateService = playerStateService ?? throw new ArgumentNullException("playerStateService");
		_playerSpiritFactory = playerSpiritFactory ?? throw new ArgumentNullException("playerSpiritFactory");
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__5))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<GetSpiritPreviewResponse>> ExecuteAsync(GetSpiritPreviewRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		Spirit baseSpirit = await _spiritRepository.GetByIdAsync(request.BaseSpiritId);
		if (baseSpirit == null)
		{
			return Result<GetSpiritPreviewResponse>.FailureResult("Spirit not found");
		}
		string currencyType = baseSpirit.Requirements?.CurrencyCost?.Type ?? "gold";
		int currencyAmount = (baseSpirit.Requirements?.CurrencyCost?.Amount).GetValueOrDefault();
		string orbName = baseSpirit.Requirements?.ItemRequirement?.ItemType ?? string.Empty;
		int orbAmount = (baseSpirit.Requirements?.ItemRequirement?.Amount).GetValueOrDefault(1);
		Player player = _playerStateService.GetCurrentPlayer();
		if (player == null)
		{
			return Result<GetSpiritPreviewResponse>.FailureResult("No active session");
		}
		int spiritLevel = Math.Max(1, player.PlayerLevel / 3);
		SpiritPreviewDTO spiritPreviewDTO = new SpiritPreviewDTO();
		Guid val = Guid.NewGuid();
		spiritPreviewDTO.PreviewId = ((object)(Guid)(ref val)).ToString();
		spiritPreviewDTO.BaseSpiritId = int.Parse(baseSpirit.ID);
		spiritPreviewDTO.Name = baseSpirit.Name ?? string.Empty;
		spiritPreviewDTO.Type1 = ((object)baseSpirit.Type1).ToString();
		spiritPreviewDTO.Type2 = ((object)baseSpirit.Type2).ToString() ?? string.Empty;
		spiritPreviewDTO.Image = baseSpirit.Image ?? string.Empty;
		spiritPreviewDTO.Category = baseSpirit.Category ?? string.Empty;
		spiritPreviewDTO.Level = spiritLevel;
		spiritPreviewDTO.HP = _playerSpiritFactory.CalculateInitialHP(baseSpirit, spiritLevel);
		spiritPreviewDTO.TrainingPoints = _playerSpiritFactory.CalculateInitialTrainingPoints(spiritLevel);
		spiritPreviewDTO.BaseHP = baseSpirit.BaseStats.HP;
		spiritPreviewDTO.BaseATK = baseSpirit.BaseStats.ATK;
		spiritPreviewDTO.BaseDEF = baseSpirit.BaseStats.DEF;
		spiritPreviewDTO.BaseSATK = baseSpirit.BaseStats.SATK;
		spiritPreviewDTO.BaseSDEF = baseSpirit.BaseStats.SDEF;
		spiritPreviewDTO.BaseSPD = baseSpirit.BaseStats.SPD;
		spiritPreviewDTO.BaseINT = baseSpirit.BaseStats.INT;
		spiritPreviewDTO.BonusATK = baseSpirit.BonusAttributes?.ATK ?? 1.0;
		spiritPreviewDTO.BonusDEF = baseSpirit.BonusAttributes?.DEF ?? 1.0;
		spiritPreviewDTO.BonusSATK = baseSpirit.BonusAttributes?.SATK ?? 1.0;
		spiritPreviewDTO.BonusSDEF = baseSpirit.BonusAttributes?.SDEF ?? 1.0;
		spiritPreviewDTO.BonusSPD = baseSpirit.BonusAttributes?.SPD ?? 1.0;
		spiritPreviewDTO.BonusINT = baseSpirit.BonusAttributes?.INT ?? 1.0;
		spiritPreviewDTO.LearnableMoves = Enumerable.ToList<ValueTuple<string, int, string, string>>(Enumerable.Select<Move, ValueTuple<string, int, string, string>>((global::System.Collections.Generic.IEnumerable<Move>)baseSpirit.LearnableMoves, (Func<Move, ValueTuple<string, int, string, string>>)((Move x) => new ValueTuple<string, int, string, string>(x.Name, x.Power, ((object)x.Type).ToString(), ((object)x.MoveType).ToString()))));
		SpiritPreviewDTO previewDto = spiritPreviewDTO;
		return Result<GetSpiritPreviewResponse>.SuccessResult(new GetSpiritPreviewResponse(previewDto, currencyType, currencyAmount, orbName, orbAmount));
	}
}
