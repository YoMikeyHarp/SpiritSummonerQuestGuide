using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using SpiritSummoner.Application.Enums;

namespace SpiritSummoner.Application.Auth;

public record RegistrationResumeResult
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(RegistrationResumeResult);
		}
	}

	public bool ShouldResume
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	public RegistrationState State
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	public string? PendingUserId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	public static RegistrationResumeResult NoResume()
	{
		return new RegistrationResumeResult
		{
			ShouldResume = false,
			State = RegistrationState.NotStarted
		};
	}

	public static RegistrationResumeResult Resume(string userId, RegistrationState state)
	{
		return new RegistrationResumeResult
		{
			ShouldResume = true,
			State = state,
			PendingUserId = userId
		};
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("RegistrationResumeResult");
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
		builder.Append("ShouldResume = ");
		builder.Append(((object)ShouldResume).ToString());
		builder.Append(", State = ");
		builder.Append(((object)State).ToString());
		builder.Append(", PendingUserId = ");
		builder.Append((object)PendingUserId);
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(RegistrationResumeResult? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<bool>.Default.Equals(ShouldResume, other.ShouldResume) && EqualityComparer<RegistrationState>.Default.Equals(State, other.State) && EqualityComparer<string>.Default.Equals(PendingUserId, other.PendingUserId));
	}
}
