using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Configuration.Guilds;
using SpiritSummoner.Domain.Entities.Guilds;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Repositories;

namespace SpiritSummoner.Application.UseCases.Guilds;

public class ActivateGuildPerkUseCase : IUseCase<ActivateGuildPerkRequest, ActivateGuildPerkResponse>
{
	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__4 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<ActivateGuildPerkResponse>> _003C_003Et__builder;

		public ActivateGuildPerkRequest request;

		public ActivateGuildPerkUseCase _003C_003E4__this;

		private Guild _003Cguild_003E5__1;

		private Player _003Cplayer_003E5__2;

		private GuildPerkDefinition _003Cdef_003E5__3;

		private GuildActivePerk _003CactivePerk_003E5__4;

		private int _003CcurrentTier_003E5__5;

		private GuildPerkTierDefinition _003CnextTierDef_003E5__6;

		private int _003CnextTier_003E5__7;

		private DateTimeOffset _003CactivatedAt_003E5__8;

		private string _003CperkKey_003E5__9;

		private bool _003Csuccess_003E5__10;

		private bool _003C_003Es__11;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0223: Unknown result type (might be due to invalid IL or missing references)
			//IL_0228: Unknown result type (might be due to invalid IL or missing references)
			//IL_0270: Unknown result type (might be due to invalid IL or missing references)
			//IL_0299: Unknown result type (might be due to invalid IL or missing references)
			//IL_029e: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b5: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<ActivateGuildPerkResponse> result;
			try
			{
				TaskAwaiter<bool> awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
					goto IL_02ef;
				}
				_003Cguild_003E5__1 = _003C_003E4__this._guildState.GetCurrentGuild();
				if (_003Cguild_003E5__1 == null || string.IsNullOrEmpty(_003Cguild_003E5__1.ID))
				{
					result = Result<ActivateGuildPerkResponse>.FailureResult("Not in a guild");
				}
				else if (string.IsNullOrEmpty(_003Cguild_003E5__1.CurrentWarId))
				{
					result = Result<ActivateGuildPerkResponse>.FailureResult("Not in active war season currently.");
				}
				else
				{
					_003Cplayer_003E5__2 = _003C_003E4__this._playerState.GetCurrentPlayer();
					if (_003Cplayer_003E5__2 == null)
					{
						result = Result<ActivateGuildPerkResponse>.FailureResult("Player not found");
					}
					else if (_003Cguild_003E5__1.LeaderPlayerId != _003Cplayer_003E5__2.PlayerID)
					{
						result = Result<ActivateGuildPerkResponse>.FailureResult("Only the guild leader can activate perks");
					}
					else
					{
						_003Cdef_003E5__3 = GuildPerkDefinitions.GetByType(request.PerkType);
						if (_003Cdef_003E5__3 == null)
						{
							result = Result<ActivateGuildPerkResponse>.FailureResult("Unknown perk type");
						}
						else
						{
							_003CactivePerk_003E5__4 = _003Cguild_003E5__1.GetActivePerk(request.PerkType);
							_003CcurrentTier_003E5__5 = _003CactivePerk_003E5__4?.Tier ?? 0;
							if (_003CcurrentTier_003E5__5 >= ((global::System.Collections.Generic.IReadOnlyCollection<GuildPerkTierDefinition>)_003Cdef_003E5__3.Tiers).Count)
							{
								result = Result<ActivateGuildPerkResponse>.FailureResult("Perk is already at max tier");
							}
							else
							{
								_003CnextTierDef_003E5__6 = _003Cdef_003E5__3.Tiers[_003CcurrentTier_003E5__5];
								_003CnextTier_003E5__7 = _003CcurrentTier_003E5__5 + 1;
								if (_003Cguild_003E5__1.Crystals >= _003CnextTierDef_003E5__6.CrystalCost)
								{
									_003CactivatedAt_003E5__8 = DateTimeOffset.UtcNow;
									_003CperkKey_003E5__9 = ((object)request.PerkType).ToString();
									awaiter = _003C_003E4__this._guildRepository.ApplyGuildPerkAsync(_003Cguild_003E5__1.ID, _003CperkKey_003E5__9, _003CnextTier_003E5__7, _003CactivatedAt_003E5__8, _003Cplayer_003E5__2.PlayerID ?? string.Empty, _003CnextTierDef_003E5__6.CrystalCost).GetAwaiter();
									if (!awaiter.IsCompleted)
									{
										num = (_003C_003E1__state = 0);
										_003C_003Eu__1 = awaiter;
										_003CExecuteAsync_003Ed__4 _003CExecuteAsync_003Ed__ = this;
										_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CExecuteAsync_003Ed__4>(ref awaiter, ref _003CExecuteAsync_003Ed__);
										return;
									}
									goto IL_02ef;
								}
								result = Result<ActivateGuildPerkResponse>.FailureResult($"Insufficient crystals. Need {_003CnextTierDef_003E5__6.CrystalCost}, have {_003Cguild_003E5__1.Crystals}");
							}
						}
					}
				}
				goto end_IL_0007;
				IL_02ef:
				_003C_003Es__11 = awaiter.GetResult();
				_003Csuccess_003E5__10 = _003C_003Es__11;
				if (!_003Csuccess_003E5__10)
				{
					result = Result<ActivateGuildPerkResponse>.FailureResult("Failed to apply perk — please try again");
				}
				else
				{
					_003Cguild_003E5__1.Crystals -= _003CnextTierDef_003E5__6.CrystalCost;
					_003Cguild_003E5__1.ActivePerks[_003CperkKey_003E5__9] = GuildActivePerk.Create(request.PerkType, _003CnextTier_003E5__7, _003Cplayer_003E5__2.PlayerID ?? string.Empty);
					result = Result<ActivateGuildPerkResponse>.SuccessResult(new ActivateGuildPerkResponse(request.PerkType, _003CnextTier_003E5__7, _003CnextTierDef_003E5__6.EffectDescription));
				}
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cguild_003E5__1 = null;
				_003Cplayer_003E5__2 = null;
				_003Cdef_003E5__3 = null;
				_003CactivePerk_003E5__4 = null;
				_003CnextTierDef_003E5__6 = null;
				_003CperkKey_003E5__9 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cguild_003E5__1 = null;
			_003Cplayer_003E5__2 = null;
			_003Cdef_003E5__3 = null;
			_003CactivePerk_003E5__4 = null;
			_003CnextTierDef_003E5__6 = null;
			_003CperkKey_003E5__9 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IGuildStateService _guildState;

	private readonly IPlayerStateService _playerState;

	private readonly IGuildRepository _guildRepository;

	public ActivateGuildPerkUseCase(IGuildStateService guildState, IPlayerStateService playerState, IGuildRepository guildRepository)
	{
		_guildState = guildState;
		_playerState = playerState;
		_guildRepository = guildRepository;
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__4))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<ActivateGuildPerkResponse>> ExecuteAsync(ActivateGuildPerkRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		Guild guild = _guildState.GetCurrentGuild();
		if (guild == null || string.IsNullOrEmpty(guild.ID))
		{
			return Result<ActivateGuildPerkResponse>.FailureResult("Not in a guild");
		}
		if (string.IsNullOrEmpty(guild.CurrentWarId))
		{
			return Result<ActivateGuildPerkResponse>.FailureResult("Not in active war season currently.");
		}
		Player player = _playerState.GetCurrentPlayer();
		if (player == null)
		{
			return Result<ActivateGuildPerkResponse>.FailureResult("Player not found");
		}
		if (guild.LeaderPlayerId != player.PlayerID)
		{
			return Result<ActivateGuildPerkResponse>.FailureResult("Only the guild leader can activate perks");
		}
		GuildPerkDefinition def = GuildPerkDefinitions.GetByType(request.PerkType);
		if (def == null)
		{
			return Result<ActivateGuildPerkResponse>.FailureResult("Unknown perk type");
		}
		int currentTier = guild.GetActivePerk(request.PerkType)?.Tier ?? 0;
		if (currentTier >= ((global::System.Collections.Generic.IReadOnlyCollection<GuildPerkTierDefinition>)def.Tiers).Count)
		{
			return Result<ActivateGuildPerkResponse>.FailureResult("Perk is already at max tier");
		}
		GuildPerkTierDefinition nextTierDef = def.Tiers[currentTier];
		int nextTier = currentTier + 1;
		if (guild.Crystals < nextTierDef.CrystalCost)
		{
			return Result<ActivateGuildPerkResponse>.FailureResult($"Insufficient crystals. Need {nextTierDef.CrystalCost}, have {guild.Crystals}");
		}
		DateTimeOffset activatedAt = DateTimeOffset.UtcNow;
		string perkKey = ((object)request.PerkType).ToString();
		if (!(await _guildRepository.ApplyGuildPerkAsync(guild.ID, perkKey, nextTier, activatedAt, player.PlayerID ?? string.Empty, nextTierDef.CrystalCost)))
		{
			return Result<ActivateGuildPerkResponse>.FailureResult("Failed to apply perk — please try again");
		}
		guild.Crystals -= nextTierDef.CrystalCost;
		guild.ActivePerks[perkKey] = GuildActivePerk.Create(request.PerkType, nextTier, player.PlayerID ?? string.Empty);
		return Result<ActivateGuildPerkResponse>.SuccessResult(new ActivateGuildPerkResponse(request.PerkType, nextTier, nextTierDef.EffectDescription));
	}
}
