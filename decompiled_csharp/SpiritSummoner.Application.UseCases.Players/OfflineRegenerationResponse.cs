using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Players;

public record OfflineRegenerationResponse(int EPGained, int SPGained, DateTimeOffset NextEpTick, DateTimeOffset NextSpTick, int CurrentEP, int CurrentSP, int MaxEP, int MaxSP)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(OfflineRegenerationResponse);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("OfflineRegenerationResponse");
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
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		RuntimeHelpers.EnsureSufficientExecutionStack();
		builder.Append("EPGained = ");
		builder.Append(((object)EPGained).ToString());
		builder.Append(", SPGained = ");
		builder.Append(((object)SPGained).ToString());
		builder.Append(", NextEpTick = ");
		DateTimeOffset val = NextEpTick;
		builder.Append(((object)(DateTimeOffset)(ref val)).ToString());
		builder.Append(", NextSpTick = ");
		val = NextSpTick;
		builder.Append(((object)(DateTimeOffset)(ref val)).ToString());
		builder.Append(", CurrentEP = ");
		builder.Append(((object)CurrentEP).ToString());
		builder.Append(", CurrentSP = ");
		builder.Append(((object)CurrentSP).ToString());
		builder.Append(", MaxEP = ");
		builder.Append(((object)MaxEP).ToString());
		builder.Append(", MaxSP = ");
		builder.Append(((object)MaxSP).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(OfflineRegenerationResponse? other)
	{
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<int>.Default.Equals(EPGained, other.EPGained) && EqualityComparer<int>.Default.Equals(SPGained, other.SPGained) && EqualityComparer<DateTimeOffset>.Default.Equals(NextEpTick, other.NextEpTick) && EqualityComparer<DateTimeOffset>.Default.Equals(NextSpTick, other.NextSpTick) && EqualityComparer<int>.Default.Equals(CurrentEP, other.CurrentEP) && EqualityComparer<int>.Default.Equals(CurrentSP, other.CurrentSP) && EqualityComparer<int>.Default.Equals(MaxEP, other.MaxEP) && EqualityComparer<int>.Default.Equals(MaxSP, other.MaxSP));
	}
}
