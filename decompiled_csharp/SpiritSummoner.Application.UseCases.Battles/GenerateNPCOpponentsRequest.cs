using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Battles;

public record GenerateNPCOpponentsRequest(int PlayerLevel, int Count = 10)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(GenerateNPCOpponentsRequest);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("GenerateNPCOpponentsRequest");
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
		builder.Append("PlayerLevel = ");
		builder.Append(((object)PlayerLevel).ToString());
		builder.Append(", Count = ");
		builder.Append(((object)Count).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(GenerateNPCOpponentsRequest? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<int>.Default.Equals(PlayerLevel, other.PlayerLevel) && EqualityComparer<int>.Default.Equals(Count, other.Count));
	}
}
