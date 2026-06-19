using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Guilds;

public record CancelDisbandGuildResult
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(CancelDisbandGuildResult);
		}
	}

	public bool Success
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	public string Message
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	} = string.Empty;


	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("CancelDisbandGuildResult");
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
		builder.Append("Success = ");
		builder.Append(((object)Success).ToString());
		builder.Append(", Message = ");
		builder.Append((object)Message);
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(CancelDisbandGuildResult? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<bool>.Default.Equals(Success, other.Success) && EqualityComparer<string>.Default.Equals(Message, other.Message));
	}
}
