using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Players;

public record RegenerateEnergyResponse(string EnergyType, int NewValue, int MaxValue, bool AtMax)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(RegenerateEnergyResponse);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("RegenerateEnergyResponse");
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
		builder.Append("EnergyType = ");
		builder.Append((object)EnergyType);
		builder.Append(", NewValue = ");
		builder.Append(((object)NewValue).ToString());
		builder.Append(", MaxValue = ");
		builder.Append(((object)MaxValue).ToString());
		builder.Append(", AtMax = ");
		builder.Append(((object)AtMax).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(RegenerateEnergyResponse? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(EnergyType, other.EnergyType) && EqualityComparer<int>.Default.Equals(NewValue, other.NewValue) && EqualityComparer<int>.Default.Equals(MaxValue, other.MaxValue) && EqualityComparer<bool>.Default.Equals(AtMax, other.AtMax));
	}
}
