using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Entities.Quests;

namespace SpiritSummoner.Application.UseCases.Quests;

public class GetQuestTasksResult
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public List<QuestTask> QuestTasks
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	} = new List<QuestTask>();


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public PlayerQuest? PlayerQuest
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string QuestId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	} = string.Empty;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string AreaName
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	} = string.Empty;

}
