using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.Auth;

public record StarterSpiritData(string Name, string Image, string Description, int Level, string Type1, string Type2)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(StarterSpiritData);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("StarterSpiritData");
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
		builder.Append("Name = ");
		builder.Append((object)Name);
		builder.Append(", Image = ");
		builder.Append((object)Image);
		builder.Append(", Description = ");
		builder.Append((object)Description);
		builder.Append(", Level = ");
		builder.Append(((object)Level).ToString());
		builder.Append(", Type1 = ");
		builder.Append((object)Type1);
		builder.Append(", Type2 = ");
		builder.Append((object)Type2);
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(StarterSpiritData? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(Name, other.Name) && EqualityComparer<string>.Default.Equals(Image, other.Image) && EqualityComparer<string>.Default.Equals(Description, other.Description) && EqualityComparer<int>.Default.Equals(Level, other.Level) && EqualityComparer<string>.Default.Equals(Type1, other.Type1) && EqualityComparer<string>.Default.Equals(Type2, other.Type2));
	}
}
