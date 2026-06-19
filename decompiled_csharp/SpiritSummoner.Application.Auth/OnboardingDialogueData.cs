using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.Auth;

public record OnboardingDialogueData(string SpeakerName, string Text, string Image1, string? Image2)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(OnboardingDialogueData);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("OnboardingDialogueData");
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
		builder.Append("SpeakerName = ");
		builder.Append((object)SpeakerName);
		builder.Append(", Text = ");
		builder.Append((object)Text);
		builder.Append(", Image1 = ");
		builder.Append((object)Image1);
		builder.Append(", Image2 = ");
		builder.Append((object)Image2);
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(OnboardingDialogueData? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(SpeakerName, other.SpeakerName) && EqualityComparer<string>.Default.Equals(Text, other.Text) && EqualityComparer<string>.Default.Equals(Image1, other.Image1) && EqualityComparer<string>.Default.Equals(Image2, other.Image2));
	}
}
