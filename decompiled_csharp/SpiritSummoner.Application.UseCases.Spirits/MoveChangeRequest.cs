using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Spirits;

public record MoveChangeRequest(string MoveName, bool IsNewlyUnlocked, bool WasAlreadyUnlocked, bool IsActive)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(MoveChangeRequest);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("MoveChangeRequest");
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
		builder.Append("MoveName = ");
		builder.Append((object)MoveName);
		builder.Append(", IsNewlyUnlocked = ");
		builder.Append(((object)IsNewlyUnlocked).ToString());
		builder.Append(", WasAlreadyUnlocked = ");
		builder.Append(((object)WasAlreadyUnlocked).ToString());
		builder.Append(", IsActive = ");
		builder.Append(((object)IsActive).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(MoveChangeRequest? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(MoveName, other.MoveName) && EqualityComparer<bool>.Default.Equals(IsNewlyUnlocked, other.IsNewlyUnlocked) && EqualityComparer<bool>.Default.Equals(WasAlreadyUnlocked, other.WasAlreadyUnlocked) && EqualityComparer<bool>.Default.Equals(IsActive, other.IsActive));
	}
}
