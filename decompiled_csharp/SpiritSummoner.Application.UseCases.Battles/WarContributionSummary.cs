using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Battles;

public record WarContributionSummary(string PlayerId, int AttackCount, int RaidCount, int CrystalsFromAttacks, int CrystalsFromRaids, double DefenseScore, double EstimatedWarScore, long EstimatedGuildCoins, bool IsWarActive)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(WarContributionSummary);
		}
	}

	public int TotalCrystals => CrystalsFromAttacks + CrystalsFromRaids;

	public int TotalActions => AttackCount + RaidCount;

	public static WarContributionSummary NotInWar()
	{
		return new WarContributionSummary(string.Empty, 0, 0, 0, 0, 0.0, 0.0, 0L, IsWarActive: false);
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("WarContributionSummary");
		val.Append(" { ");
		if (PrintMembers(val))
		{
			val.Append(' ');
		}
		val.Append('}');
		return ((object)val).ToString();
	}

	[CompilerGenerated]
	protected virtual bool PrintMembers(StringBuilder builder)
	{
		RuntimeHelpers.EnsureSufficientExecutionStack();
		builder.Append("PlayerId = ");
		builder.Append((object)PlayerId);
		builder.Append(", AttackCount = ");
		builder.Append(((object)AttackCount).ToString());
		builder.Append(", RaidCount = ");
		builder.Append(((object)RaidCount).ToString());
		builder.Append(", CrystalsFromAttacks = ");
		builder.Append(((object)CrystalsFromAttacks).ToString());
		builder.Append(", CrystalsFromRaids = ");
		builder.Append(((object)CrystalsFromRaids).ToString());
		builder.Append(", DefenseScore = ");
		builder.Append(((object)DefenseScore).ToString());
		builder.Append(", EstimatedWarScore = ");
		builder.Append(((object)EstimatedWarScore).ToString());
		builder.Append(", EstimatedGuildCoins = ");
		builder.Append(((object)EstimatedGuildCoins).ToString());
		builder.Append(", IsWarActive = ");
		builder.Append(((object)IsWarActive).ToString());
		builder.Append(", TotalCrystals = ");
		builder.Append(((object)TotalCrystals).ToString());
		builder.Append(", TotalActions = ");
		builder.Append(((object)TotalActions).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(WarContributionSummary? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(PlayerId, other.PlayerId) && EqualityComparer<int>.Default.Equals(AttackCount, other.AttackCount) && EqualityComparer<int>.Default.Equals(RaidCount, other.RaidCount) && EqualityComparer<int>.Default.Equals(CrystalsFromAttacks, other.CrystalsFromAttacks) && EqualityComparer<int>.Default.Equals(CrystalsFromRaids, other.CrystalsFromRaids) && EqualityComparer<double>.Default.Equals(DefenseScore, other.DefenseScore) && EqualityComparer<double>.Default.Equals(EstimatedWarScore, other.EstimatedWarScore) && EqualityComparer<long>.Default.Equals(EstimatedGuildCoins, other.EstimatedGuildCoins) && EqualityComparer<bool>.Default.Equals(IsWarActive, other.IsWarActive));
	}
}
