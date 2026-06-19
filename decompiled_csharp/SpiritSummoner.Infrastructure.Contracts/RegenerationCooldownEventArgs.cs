using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SpiritSummoner.Infrastructure.Contracts;

public class RegenerationCooldownEventArgs : EventArgs
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string EpCooldown
	{
		[CompilerGenerated]
		get;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string SpCooldown
	{
		[CompilerGenerated]
		get;
	}

	public RegenerationCooldownEventArgs(string epCooldown, string spCooldown)
	{
		EpCooldown = epCooldown;
		SpCooldown = spCooldown;
	}
}
