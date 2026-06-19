using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Configuration.Guilds;
using SpiritSummoner.Domain.Entities.Guilds;
using SpiritSummoner.Domain.Entities.Players;

namespace SpiritSummoner.Application.UseCases.Guilds;

public class GetGuildPerksUseCase : IUseCase<GetGuildPerksRequest, GetGuildPerksResponse>
{
	private readonly IGuildStateService _guildState;

	private readonly IPlayerStateService _playerState;

	public GetGuildPerksUseCase(IGuildStateService guildState, IPlayerStateService playerState)
	{
		_guildState = guildState;
		_playerState = playerState;
	}

	public global::System.Threading.Tasks.Task<Result<GetGuildPerksResponse>> ExecuteAsync(GetGuildPerksRequest request)
	{
		Guild guild = _guildState.GetCurrentGuild();
		if (guild == null)
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<GetGuildPerksResponse>>(Result<GetGuildPerksResponse>.FailureResult("Not in a guild"));
		}
		Player currentPlayer = _playerState.GetCurrentPlayer();
		bool isLeader = currentPlayer != null && guild.LeaderPlayerId == currentPlayer.PlayerID;
		List<GuildPerkView> perks = Enumerable.ToList<GuildPerkView>(Enumerable.Select<GuildPerkDefinition, GuildPerkView>((global::System.Collections.Generic.IEnumerable<GuildPerkDefinition>)GuildPerkDefinitions.All, (Func<GuildPerkDefinition, GuildPerkView>)delegate(GuildPerkDefinition def)
		{
			string text = ((object)def.Type).ToString();
			GuildActivePerk activePerk = guild.GetActivePerk(def.Type);
			int num = activePerk?.Tier ?? 0;
			GuildPerkTierDefinition guildPerkTierDefinition = activePerk?.GetNextTierDefinition() ?? ((num == 0) ? def.Tiers[0] : null);
			int num2 = guildPerkTierDefinition?.CrystalCost ?? 0;
			bool flag = activePerk?.IsMaxTier() ?? false;
			bool canAffordUpgrade = !flag && guild.Crystals >= num2;
			return new GuildPerkView(def.Type, def.Category, def.Title, def.Description, num, ((global::System.Collections.Generic.IReadOnlyCollection<GuildPerkTierDefinition>)def.Tiers).Count, num > 0, flag, (activePerk != null && num > 0) ? def.Tiers[num - 1].EffectDescription : null, guildPerkTierDefinition?.EffectDescription, num2, canAffordUpgrade, activePerk?.ActivatedByPlayerId);
		}));
		GetGuildPerksResponse data = new GetGuildPerksResponse((global::System.Collections.Generic.IReadOnlyList<GuildPerkView>)perks, guild.Crystals, isLeader);
		return global::System.Threading.Tasks.Task.FromResult<Result<GetGuildPerksResponse>>(Result<GetGuildPerksResponse>.SuccessResult(data));
	}
}
