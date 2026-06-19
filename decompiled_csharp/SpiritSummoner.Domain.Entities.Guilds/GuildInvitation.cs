using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using SpiritSummoner.Domain.Enums.Guilds;

namespace SpiritSummoner.Domain.Entities.Guilds;

public class GuildInvitation
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string ID
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = string.Empty;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string GuildId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = string.Empty;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string GuildName
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = string.Empty;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string InvitedPlayerId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = string.Empty;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string InvitedByPlayerId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = string.Empty;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string InvitedByPlayerName
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = string.Empty;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public InvitationStatus Status
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public DateTimeOffset CreatedAt
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public DateTimeOffset ExpiresAt
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public bool IsExpired => DateTimeOffset.UtcNow > ExpiresAt;

	public bool IsPending => Status == InvitationStatus.Pending && !IsExpired;

	public TimeSpan TimeUntilExpiry => ExpiresAt - DateTimeOffset.UtcNow;

	public string ExpiryDisplay
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			if (IsExpired)
			{
				return "Expired";
			}
			TimeSpan timeUntilExpiry = TimeUntilExpiry;
			int num = (int)((TimeSpan)(ref timeUntilExpiry)).TotalHours;
			if (num < 1)
			{
				return "Expires soon";
			}
			if (num >= 24)
			{
				timeUntilExpiry = TimeUntilExpiry;
				int num2 = (int)((TimeSpan)(ref timeUntilExpiry)).TotalDays;
				return $"Expires in {num2}d";
			}
			return $"Expires in {num}h";
		}
	}
}
