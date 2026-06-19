using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SpiritSummoner.Domain.Exceptions;

public class RaidCooldownException : GuildWarException
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public TimeSpan RemainingCooldown
	{
		[CompilerGenerated]
		get;
	}

	public RaidCooldownException(string guildId, string opponentGuildId, TimeSpan remainingCooldown)
		: base($"Raid on cooldown for {((TimeSpan)(ref remainingCooldown)).TotalMinutes:F0} more minutes", guildId, opponentGuildId)
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		RemainingCooldown = remainingCooldown;
	}
}
