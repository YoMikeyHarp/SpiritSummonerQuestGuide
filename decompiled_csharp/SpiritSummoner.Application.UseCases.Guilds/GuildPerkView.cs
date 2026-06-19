using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using SpiritSummoner.Domain.Enums.Guilds;

namespace SpiritSummoner.Application.UseCases.Guilds;

public record GuildPerkView(GuildPerkType PerkType, GuildPerkCategory Category, string Title, string Description, int CurrentTier, int MaxTier, bool IsActive, bool IsMaxTier, string? ActiveEffectDescription, string? NextEffectDescription, int NextTierCrystalCost, bool CanAffordUpgrade, string? ActivatedByPlayerId)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(GuildPerkView);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("GuildPerkView");
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
		builder.Append("PerkType = ");
		builder.Append(((object)PerkType).ToString());
		builder.Append(", Category = ");
		builder.Append(((object)Category).ToString());
		builder.Append(", Title = ");
		builder.Append((object)Title);
		builder.Append(", Description = ");
		builder.Append((object)Description);
		builder.Append(", CurrentTier = ");
		builder.Append(((object)CurrentTier).ToString());
		builder.Append(", MaxTier = ");
		builder.Append(((object)MaxTier).ToString());
		builder.Append(", IsActive = ");
		builder.Append(((object)IsActive).ToString());
		builder.Append(", IsMaxTier = ");
		builder.Append(((object)IsMaxTier).ToString());
		builder.Append(", ActiveEffectDescription = ");
		builder.Append((object)ActiveEffectDescription);
		builder.Append(", NextEffectDescription = ");
		builder.Append((object)NextEffectDescription);
		builder.Append(", NextTierCrystalCost = ");
		builder.Append(((object)NextTierCrystalCost).ToString());
		builder.Append(", CanAffordUpgrade = ");
		builder.Append(((object)CanAffordUpgrade).ToString());
		builder.Append(", ActivatedByPlayerId = ");
		builder.Append((object)ActivatedByPlayerId);
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(GuildPerkView? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<GuildPerkType>.Default.Equals(PerkType, other.PerkType) && EqualityComparer<GuildPerkCategory>.Default.Equals(Category, other.Category) && EqualityComparer<string>.Default.Equals(Title, other.Title) && EqualityComparer<string>.Default.Equals(Description, other.Description) && EqualityComparer<int>.Default.Equals(CurrentTier, other.CurrentTier) && EqualityComparer<int>.Default.Equals(MaxTier, other.MaxTier) && EqualityComparer<bool>.Default.Equals(IsActive, other.IsActive) && EqualityComparer<bool>.Default.Equals(IsMaxTier, other.IsMaxTier) && EqualityComparer<string>.Default.Equals(ActiveEffectDescription, other.ActiveEffectDescription) && EqualityComparer<string>.Default.Equals(NextEffectDescription, other.NextEffectDescription) && EqualityComparer<int>.Default.Equals(NextTierCrystalCost, other.NextTierCrystalCost) && EqualityComparer<bool>.Default.Equals(CanAffordUpgrade, other.CanAffordUpgrade) && EqualityComparer<string>.Default.Equals(ActivatedByPlayerId, other.ActivatedByPlayerId));
	}
}
