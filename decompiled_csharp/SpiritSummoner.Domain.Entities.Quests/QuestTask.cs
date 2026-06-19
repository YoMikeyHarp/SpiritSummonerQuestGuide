using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using SpiritSummoner.Domain.ValueObjects.Quests;

namespace SpiritSummoner.Domain.Entities.Quests;

public class QuestTask
{
	private readonly List<QuestOpponent> _questOpponents = new List<QuestOpponent>();

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? Id
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? Name
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? Description
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool Battle
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int Energy
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? Action
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int Order
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? OrderRequirement
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int TotalSteps
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool IsRepeatable
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	} = true;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int LevelRequirement
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	} = 1;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? OpponentImage
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? OpponentBackgroundImage
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? OpponentName
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? OpponentGuild
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Rewards? Rewards
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public List<QuestParagraph> Paragraph
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	} = new List<QuestParagraph>();


	public global::System.Collections.Generic.IReadOnlyList<QuestOpponent> QuestOpponents => (global::System.Collections.Generic.IReadOnlyList<QuestOpponent>)_questOpponents.AsReadOnly();

	public static QuestTask Rehydrate(string id, string name, string description, bool battle, int energy, string action, int order, string orderRequirement, int totalSteps, Rewards rewards, List<QuestOpponent> questOpponents, List<QuestParagraph> paragraph, bool isRepeatable = true, int levelRequirement = 1, string? opponentImage = null, string? opponentBackgroundImage = null, string? opponentName = null, string? opponentGuild = null)
	{
		QuestTask questTask = new QuestTask();
		questTask.Id = id;
		questTask.Name = name;
		questTask.Description = description;
		questTask.Battle = battle;
		questTask.Energy = energy;
		questTask.Action = action;
		questTask.Order = order;
		questTask.OrderRequirement = orderRequirement;
		questTask.TotalSteps = totalSteps;
		questTask.Rewards = rewards;
		questTask.Paragraph = paragraph;
		questTask.IsRepeatable = isRepeatable;
		questTask.OpponentImage = opponentImage;
		questTask.OpponentBackgroundImage = opponentBackgroundImage;
		questTask.OpponentName = opponentName;
		questTask.OpponentGuild = opponentGuild;
		questTask.LevelRequirement = levelRequirement;
		if (questOpponents != null)
		{
			questTask._questOpponents.Clear();
			questTask._questOpponents.AddRange((global::System.Collections.Generic.IEnumerable<QuestOpponent>)questOpponents);
		}
		return questTask;
	}

	internal void SetId(string? id)
	{
		Id = id;
	}

	internal void SetName(string? name)
	{
		Name = name;
	}

	internal void SetDescription(string? description)
	{
		Description = description;
	}

	internal void SetBattle(bool battle)
	{
		Battle = battle;
	}

	internal void SetEnergy(int energy)
	{
		Energy = Math.Max(0, energy);
	}

	internal void SetAction(string? action)
	{
		Action = action;
	}

	internal void SetOrder(int order)
	{
		Order = order;
	}

	internal void SetOrderRequirement(string? orderRequirement)
	{
		OrderRequirement = orderRequirement;
	}

	internal void SetTotalSteps(int totalSteps)
	{
		TotalSteps = Math.Max(1, totalSteps);
	}

	internal void SetRewards(Rewards? rewards)
	{
		Rewards = rewards;
	}

	internal void SetParagraph(List<QuestParagraph> paragraph)
	{
		Paragraph = paragraph ?? new List<QuestParagraph>();
	}

	internal void SetIsRepeatable(bool isRepeatable)
	{
		IsRepeatable = isRepeatable;
	}

	internal void SetOpponentImage(string? opponentImage)
	{
		OpponentImage = opponentImage;
	}

	internal void SetQuestOpponents(List<QuestOpponent> opponents)
	{
		ArgumentNullException.ThrowIfNull((object)opponents, "opponents");
		_questOpponents.Clear();
		_questOpponents.AddRange((global::System.Collections.Generic.IEnumerable<QuestOpponent>)opponents);
	}

	internal void AddQuestOpponent(QuestOpponent opponent)
	{
		ArgumentNullException.ThrowIfNull((object)opponent, "opponent");
		_questOpponents.Add(opponent);
	}

	internal void RemoveQuestOpponent(QuestOpponent opponent)
	{
		ArgumentNullException.ThrowIfNull((object)opponent, "opponent");
		_questOpponents.Remove(opponent);
	}

	internal void ClearQuestOpponents()
	{
		_questOpponents.Clear();
	}
}
