using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using SpiritSummoner.Domain.Enums.Spirits;

namespace SpiritSummoner.Domain.ValueObjects.Battle;

public class TurnBasedEffectTracker
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int MomentumStacks
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = 0;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int PatienceTurns
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = 0;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int SnowballStacks
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = 0;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int ComebackStacks
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = 0;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool HasUsedRevive
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = false;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Dictionary<SpiritType, float> AdaptationResistances
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<SpiritType, float>();


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public SpiritType? LastReceivedAttackType
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = null;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public List<ActiveStatusEffect> ActiveStatusEffects
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new List<ActiveStatusEffect>();


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Dictionary<string, float> SquadSynergyBonuses
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<string, float>();


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool MonotypeMasteryActive
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = false;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public SpiritType? MonotypeSharedType
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = null;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool HasUsedFirstMove
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = false;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool VengeanceTriggered
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = false;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int CorrosiveDebuffStacks
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = 0;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int BrainFogTurnsRemaining
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = 0;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int OriginalIntBeforeBrainFog
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = 0;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? LastMoveUsedAgainstMe
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = null;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int StubbornWillDamageTurns
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = 0;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool StubbornWillDealtDamageThisTurn
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = false;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool StubbornWillTookDamageThisTurn
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = false;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool StubbornWillForceSlot4
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = false;

}
