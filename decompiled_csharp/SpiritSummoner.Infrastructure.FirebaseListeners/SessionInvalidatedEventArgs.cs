using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SpiritSummoner.Infrastructure.FirebaseListeners;

public class SessionInvalidatedEventArgs : EventArgs
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


	public SessionInvalidatedEventArgs(string playerId)
	{
		PlayerId = playerId;
	}
}
