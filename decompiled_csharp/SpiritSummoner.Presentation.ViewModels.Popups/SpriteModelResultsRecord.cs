using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Presentation.ViewModels.Popups;

public record SpriteModelResultsRecord(string image, string imageOutcome, double opacity)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(SpriteModelResultsRecord);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("SpriteModelResultsRecord");
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
		builder.Append("image = ");
		builder.Append((object)image);
		builder.Append(", imageOutcome = ");
		builder.Append((object)imageOutcome);
		builder.Append(", opacity = ");
		builder.Append(((object)opacity).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(SpriteModelResultsRecord? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(image, other.image) && EqualityComparer<string>.Default.Equals(imageOutcome, other.imageOutcome) && EqualityComparer<double>.Default.Equals(opacity, other.opacity));
	}
}
