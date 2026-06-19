using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using SpiritSummoner.Domain.Enums.Spirits;

namespace SpiritSummoner.Presentation.Models;

public record MoveStateReadModel(string MoveName, bool IsUnlocked, bool IsActive, SpiritType Type, MoveType MoveType, int Power)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(MoveStateReadModel);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("MoveStateReadModel");
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
		builder.Append(", IsUnlocked = ");
		builder.Append(((object)IsUnlocked).ToString());
		builder.Append(", IsActive = ");
		builder.Append(((object)IsActive).ToString());
		builder.Append(", Type = ");
		builder.Append(((object)Type).ToString());
		builder.Append(", MoveType = ");
		builder.Append(((object)MoveType).ToString());
		builder.Append(", Power = ");
		builder.Append(((object)Power).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(MoveStateReadModel? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(MoveName, other.MoveName) && EqualityComparer<bool>.Default.Equals(IsUnlocked, other.IsUnlocked) && EqualityComparer<bool>.Default.Equals(IsActive, other.IsActive) && EqualityComparer<SpiritType>.Default.Equals(Type, other.Type) && EqualityComparer<MoveType>.Default.Equals(MoveType, other.MoveType) && EqualityComparer<int>.Default.Equals(Power, other.Power));
	}
}
