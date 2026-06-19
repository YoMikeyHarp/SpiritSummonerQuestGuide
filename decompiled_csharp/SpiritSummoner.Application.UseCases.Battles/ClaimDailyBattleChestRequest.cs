using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Battles;

public record ClaimDailyBattleChestRequest
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(ClaimDailyBattleChestRequest);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("ClaimDailyBattleChestRequest");
		val.Append(" { ");
		if (PrintMembers(val))
		{
			val.Append(' ');
		}
		val.Append('}');
		return ((object)val).ToString();
	}

	[CompilerGenerated]
	public virtual bool Equals(ClaimDailyBattleChestRequest? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract);
	}
}
