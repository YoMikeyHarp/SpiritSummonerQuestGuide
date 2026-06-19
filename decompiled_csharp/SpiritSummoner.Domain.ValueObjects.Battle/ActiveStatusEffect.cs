using System.Diagnostics;
using System.Runtime.CompilerServices;
using SpiritSummoner.Domain.Enums.Battles;

namespace SpiritSummoner.Domain.ValueObjects.Battle;

public class ActiveStatusEffect
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public StatusEffectType Type
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int TurnsRemaining
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public float Magnitude
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public ActiveStatusEffect(StatusEffectType type, int turnsRemaining, float magnitude)
	{
		Type = type;
		TurnsRemaining = turnsRemaining;
		Magnitude = magnitude;
	}
}
