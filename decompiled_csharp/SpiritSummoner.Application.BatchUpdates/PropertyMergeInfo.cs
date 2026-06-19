using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.BatchUpdates;

internal record PropertyMergeInfo(PropertyInfo Property, MergeType Strategy)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(PropertyMergeInfo);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("PropertyMergeInfo");
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
		builder.Append("Property = ");
		builder.Append((object)Property);
		builder.Append(", Strategy = ");
		builder.Append(((object)Strategy).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(PropertyMergeInfo? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<PropertyInfo>.Default.Equals(Property, other.Property) && EqualityComparer<MergeType>.Default.Equals(Strategy, other.Strategy));
	}
}
