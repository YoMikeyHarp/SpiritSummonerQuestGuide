using System;
using System.Collections.Generic;
using System.Linq;
using SpiritSummoner.Domain.Entities.Quests;
using SpiritSummoner.Domain.ValueObjects.Quests;
using SpiritSummoner.Infrastructure.Persistence.DTOs.Quests;

namespace SpiritSummoner.Infrastructure.Persistence.Mapping;

public static class QuestEntityMapper
{
	public static Quest ToEntity(FirestoreQuestDTO dto)
	{
		ArgumentNullException.ThrowIfNull((object)dto, "dto");
		return Quest.Rehydrate(dto.Id ?? string.Empty, dto.Name ?? string.Empty, dto.Order, dto.Image ?? string.Empty, dto.LevelRequired, dto.IsActive, dto.Event);
	}

	public static Area ToEntity(FirestoreAreasDTO dto)
	{
		ArgumentNullException.ThrowIfNull((object)dto, "dto");
		return Area.Rehydrate(dto.Id ?? string.Empty, dto.Name ?? string.Empty, (int)dto.Order, (int)dto.LevelRequired, dto.Image ?? string.Empty, dto.IsSelected, dto.TaskRequired);
	}

	public static FirestoreAreasDTO ToDTO(Area entity)
	{
		ArgumentNullException.ThrowIfNull((object)entity, "entity");
		return new FirestoreAreasDTO
		{
			Id = entity.Id,
			Image = entity.Image,
			LevelRequired = entity.LevelRequired,
			Name = entity.Name,
			Order = entity.Order,
			IsSelected = entity.IsSelected,
			TaskRequired = entity.TaskRequired
		};
	}

	public static QuestTask ToEntity(FirestoreTaskDTO dto)
	{
		ArgumentNullException.ThrowIfNull((object)dto, "dto");
		List<FirestoreQuestOpponentDTO> questOpponents = dto.QuestOpponents;
		List<QuestOpponent> val = ((questOpponents != null) ? Enumerable.ToList<QuestOpponent>(Enumerable.Select<FirestoreQuestOpponentDTO, QuestOpponent>((global::System.Collections.Generic.IEnumerable<FirestoreQuestOpponentDTO>)questOpponents, (Func<FirestoreQuestOpponentDTO, QuestOpponent>)((FirestoreQuestOpponentDTO x) => new QuestOpponent
		{
			BaseSpiritId = (x.BaseSpiritId ?? string.Empty),
			DropRate = (x.SpiritSettings?.DropRate ?? 0.0),
			HP = (x.SpiritSettings?.HP ?? 0),
			Level = (x.SpiritSettings?.Level ?? 1),
			MoveIDs = (x.MoveIds ?? new List<string>())
		}))) : null) ?? new List<QuestOpponent>();
		Rewards rewards = new Rewards
		{
			Experience = (dto.Rewards?.Experience ?? 0),
			Gold = (dto.Rewards?.Gold ?? 0),
			ItemIds = (dto.Rewards?.ItemIds ?? new List<string>())
		};
		return QuestTask.Rehydrate(dto.Id ?? string.Empty, dto.Name ?? string.Empty, dto.Description ?? string.Empty, dto.Battle, dto.Energy, dto.Action ?? string.Empty, dto.Order, dto.OrderRequirement ?? string.Empty, dto.TotalSteps, rewards, val, Enumerable.ToList<QuestParagraph>(Enumerable.Select<FirestoreQuestParagraphDTO, QuestParagraph>((global::System.Collections.Generic.IEnumerable<FirestoreQuestParagraphDTO>)dto.Paragraph, (Func<FirestoreQuestParagraphDTO, QuestParagraph>)((FirestoreQuestParagraphDTO x) => new QuestParagraph
		{
			Image = x.Image,
			Text = x.Text,
			View = x.View
		}))), dto.IsRepeatable, dto.LevelRequirement, opponentBackgroundImage: dto.OpponentBackgroundImage, opponentName: dto.OpponentName, opponentGuild: dto.OpponentGuild, opponentImage: dto.OpponentImage);
	}
}
