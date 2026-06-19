using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Players;

public record UpdatePlayerIconResponse(string IconFile)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(UpdatePlayerIconResponse);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("UpdatePlayerIconResponse");
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
		builder.Append("IconFile = ");
		builder.Append((object)IconFile);
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(UpdatePlayerIconResponse? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(IconFile, other.IconFile));
	}
}
