using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SpiritSummoner.Presentation.Services;

public class SpiritCardCacheConfig
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int MaxCachedCards
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = 50;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public TimeSpan CacheExpiration
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = TimeSpan.FromMinutes(5L);


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool EnableLRU
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = true;

}
