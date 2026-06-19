using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using SpiritSummoner.Domain.Enums.Battles;
using SpiritSummoner.Domain.ValueObjects.Quests;

namespace SpiritSummoner.Application.UseCases.Battles;

public record StartQuestBattleRequest(List<string> PlayerSquad, global::System.Collections.Generic.IReadOnlyList<QuestOpponent> OpponentSquad, BattleMode BattleMode, string? QuestTaskId = null, int CurrentQuestStep = 0, string? EnemyGuildName = null, string? ChallengerName = null, string? ChallengerGuildname = null, string? ChallengerBackgroundImage = null)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(StartQuestBattleRequest);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("StartQuestBattleRequest");
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
		RuntimeHelpers.EnsureSufficientExecutionStack();
		builder.Append("PlayerSquad = ");
		builder.Append((object)PlayerSquad);
		builder.Append(", OpponentSquad = ");
		builder.Append((object)OpponentSquad);
		builder.Append(", BattleMode = ");
		builder.Append(((object)BattleMode).ToString());
		builder.Append(", QuestTaskId = ");
		builder.Append((object)QuestTaskId);
		builder.Append(", CurrentQuestStep = ");
		builder.Append(((object)CurrentQuestStep).ToString());
		builder.Append(", EnemyGuildName = ");
		builder.Append((object)EnemyGuildName);
		builder.Append(", ChallengerName = ");
		builder.Append((object)ChallengerName);
		builder.Append(", ChallengerGuildname = ");
		builder.Append((object)ChallengerGuildname);
		builder.Append(", ChallengerBackgroundImage = ");
		builder.Append((object)ChallengerBackgroundImage);
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(StartQuestBattleRequest? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<List<string>>.Default.Equals(PlayerSquad, other.PlayerSquad) && EqualityComparer<global::System.Collections.Generic.IReadOnlyList<QuestOpponent>>.Default.Equals(OpponentSquad, other.OpponentSquad) && EqualityComparer<BattleMode>.Default.Equals(BattleMode, other.BattleMode) && EqualityComparer<string>.Default.Equals(QuestTaskId, other.QuestTaskId) && EqualityComparer<int>.Default.Equals(CurrentQuestStep, other.CurrentQuestStep) && EqualityComparer<string>.Default.Equals(EnemyGuildName, other.EnemyGuildName) && EqualityComparer<string>.Default.Equals(ChallengerName, other.ChallengerName) && EqualityComparer<string>.Default.Equals(ChallengerGuildname, other.ChallengerGuildname) && EqualityComparer<string>.Default.Equals(ChallengerBackgroundImage, other.ChallengerBackgroundImage));
	}
}
