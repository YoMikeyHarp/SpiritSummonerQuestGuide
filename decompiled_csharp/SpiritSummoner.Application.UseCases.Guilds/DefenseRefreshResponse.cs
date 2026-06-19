using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Guilds;

public record DefenseRefreshResponse
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(DefenseRefreshResponse);
		}
	}

	public bool Success
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	public DateTimeOffset NewExpiryTime
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	public TimeSpan TimeRemaining
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("DefenseRefreshResponse");
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
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		RuntimeHelpers.EnsureSufficientExecutionStack();
		builder.Append("Success = ");
		builder.Append(((object)Success).ToString());
		builder.Append(", NewExpiryTime = ");
		DateTimeOffset newExpiryTime = NewExpiryTime;
		builder.Append(((object)(DateTimeOffset)(ref newExpiryTime)).ToString());
		builder.Append(", TimeRemaining = ");
		TimeSpan timeRemaining = TimeRemaining;
		builder.Append(((object)(TimeSpan)(ref timeRemaining)).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(DefenseRefreshResponse? other)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<bool>.Default.Equals(Success, other.Success) && EqualityComparer<DateTimeOffset>.Default.Equals(NewExpiryTime, other.NewExpiryTime) && EqualityComparer<TimeSpan>.Default.Equals(TimeRemaining, other.TimeRemaining));
	}
}
