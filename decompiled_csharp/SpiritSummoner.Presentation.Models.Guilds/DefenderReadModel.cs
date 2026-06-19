using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using SpiritSummoner.Domain.Enums.Guilds;

namespace SpiritSummoner.Presentation.Models.Guilds;

public class DefenderReadModel
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string PlayerId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	} = string.Empty;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string PlayerName
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	} = string.Empty;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public GuildRole Role
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int Level
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int Trophies
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public List<string> DefenseSquadIds
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	} = new List<string>();


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public DateTimeOffset? DefenseExpiresAt
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool IsMainDefender
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	public bool IsDefenseActive => DefenseExpiresAt.HasValue && DefenseExpiresAt.Value > DateTimeOffset.UtcNow;

	public TimeSpan TimeUntilExpiry => DefenseExpiresAt.HasValue ? (DefenseExpiresAt.Value - DateTimeOffset.UtcNow) : TimeSpan.Zero;

	public string TimeUntilExpiryText
	{
		get
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			if (!IsDefenseActive)
			{
				return "Expired";
			}
			TimeSpan timeUntilExpiry = TimeUntilExpiry;
			if (!(((TimeSpan)(ref timeUntilExpiry)).TotalHours >= 1.0))
			{
				return $"{((TimeSpan)(ref timeUntilExpiry)).Minutes}m";
			}
			return $"{(int)((TimeSpan)(ref timeUntilExpiry)).TotalHours}h {((TimeSpan)(ref timeUntilExpiry)).Minutes}m";
		}
	}

	public string DefenseStatusText => IsDefenseActive ? ("Active (" + TimeUntilExpiryText + ")") : "Expired";

	public double ExpiryProgress
	{
		get
		{
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			double result;
			if (!IsDefenseActive || !DefenseExpiresAt.HasValue)
			{
				result = 0.0;
			}
			else
			{
				TimeSpan timeUntilExpiry = TimeUntilExpiry;
				result = 1.0 - ((TimeSpan)(ref timeUntilExpiry)).TotalHours / 30.0;
			}
			return result;
		}
	}
}
