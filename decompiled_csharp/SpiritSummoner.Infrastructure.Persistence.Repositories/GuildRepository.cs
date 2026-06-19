using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Plugin.Firebase.Firestore;
using SpiritSummoner.Application.Interfaces;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Guilds;
using SpiritSummoner.Domain.Entities.Guilds;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Enums.Common;
using SpiritSummoner.Domain.Enums.Guilds;
using SpiritSummoner.Domain.Exceptions;
using SpiritSummoner.Domain.Repositories;
using SpiritSummoner.Infrastructure.Diagnostics;
using SpiritSummoner.Infrastructure.Persistence.DTOs.Guilds;
using SpiritSummoner.Infrastructure.Persistence.DTOs.Players;
using SpiritSummoner.Infrastructure.Persistence.Mapping;
using SpiritSummoner.Presentation.ViewModels.Guilds;

namespace SpiritSummoner.Infrastructure.Persistence.Repositories;

public class GuildRepository : IGuildRepository, IGuildCoreRepository, IGuildMemberRepository, IGuildSearchRepository, IGuildWarRepository
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass15_0
	{
		public GuildRepository _003C_003E4__this;

		public CreateGuildRequest request;

		public Player player;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass15_1
	{
		public DateTimeOffset now;

		public int playerTrophies;

		public _003C_003Ec__DisplayClass15_0 CS_0024_003C_003E8__locals1;

		internal string _003CCreateGuildAsync_003Eb__0(ITransaction transaction)
		{
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
			IDocumentReference val = CS_0024_003C_003E8__locals1._003C_003E4__this._firestore.GetCollection("guilds").CreateDocument();
			FirestoreGuildDTO firestoreGuildDTO = new FirestoreGuildDTO
			{
				ID = val.Id,
				Name = CS_0024_003C_003E8__locals1.request.GuildName,
				Description = CS_0024_003C_003E8__locals1.request.Description,
				CreatedAt = now,
				LastActivityAt = now,
				LeaderPlayerId = CS_0024_003C_003E8__locals1.player.PlayerID,
				Emblem = CS_0024_003C_003E8__locals1.request.Emblem,
				IsPublic = CS_0024_003C_003E8__locals1.request.IsPublic,
				RequiresApproval = CS_0024_003C_003E8__locals1.request.RequiresApproval,
				MinLevelRequired = CS_0024_003C_003E8__locals1.request.MinLevelRequired,
				MinTrophiesRequired = CS_0024_003C_003E8__locals1.request.MinTrophiesRequired,
				MemberCount = 1,
				Level = 1,
				Rank = 0,
				XPForNextLevel = 500,
				IsOpenToWar = true,
				StartingCrystals = 1000
			};
			transaction.SetData(val, (object)firestoreGuildDTO, (SetOptions)null);
			IDocumentReference document = val.GetCollection("members").GetDocument(CS_0024_003C_003E8__locals1.player.PlayerID);
			transaction.SetData(document, (object)new FirestoreGuildMemberDTO
			{
				PlayerId = CS_0024_003C_003E8__locals1.player.PlayerID,
				PlayerName = CS_0024_003C_003E8__locals1.player.Playername,
				Role = "Guildmaster",
				JoinedAt = now,
				Contribution = 0,
				IsOnline = true,
				LastActiveAt = now,
				Trophies = playerTrophies,
				WeeklyContribution = 0,
				Level = CS_0024_003C_003E8__locals1.player.PlayerLevel,
				PlayerIcon = CS_0024_003C_003E8__locals1.player.PlayerIcon
			}, (SetOptions)null);
			return val.Id;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass18_0
	{
		public GuildRepository _003C_003E4__this;

		public string guildId;

		internal bool _003CDeleteAsync_003Eb__0(ITransaction transaction)
		{
			IDocumentReference document = _003C_003E4__this._firestore.GetCollection("guilds").GetDocument(guildId);
			transaction.DeleteDocument(document);
			return true;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass19_0
	{
		public Guild currentGuild;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass19_1
	{
		public IDocumentReference memberRef;

		public IDocumentReference guildRef;

		public _003C_003Ec__DisplayClass19_0 CS_0024_003C_003E8__locals1;

		internal object _003CLeaveGuildAsync_003Eb__0(ITransaction transaction)
		{
			memberRef.DeleteDocumentAsync();
			int memberCount = CS_0024_003C_003E8__locals1.currentGuild.MemberCount;
			int maxMembers = CS_0024_003C_003E8__locals1.currentGuild.MaxMembers;
			if (memberCount >= maxMembers)
			{
				throw new global::System.Exception("Guild is full");
			}
			int num = memberCount - 1;
			transaction.UpdateData(guildRef, new Dictionary<object, object> { [(object)"memberCount"] = num });
			return true;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass20_0
	{
		public IDocumentReference memberRef;

		internal object _003CKickMemberAsync_003Eb__0(ITransaction transaction)
		{
			transaction.DeleteDocument(memberRef);
			return true;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass21_0
	{
		public GuildRole newRole;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass21_1
	{
		public IDocumentReference guildRef;

		public string guildName;

		public IDocumentReference memberRef;

		public string oldRole;

		public _003C_003Ec__DisplayClass21_0 CS_0024_003C_003E8__locals1;

		internal object _003CPromoteMemberAsync_003Eb__0(ITransaction transaction)
		{
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(guildRef);
			if (document.Data == null)
			{
				throw new global::System.Exception("Guild not found");
			}
			guildName = document.Data.Name;
			IDocumentSnapshot<FirestoreGuildMemberDTO> document2 = transaction.GetDocument<FirestoreGuildMemberDTO>(memberRef);
			if (document2.Data == null)
			{
				throw new global::System.Exception("Member not found");
			}
			oldRole = document2.Data.Role;
			transaction.UpdateData(memberRef, new Dictionary<object, object> { [(object)"role"] = ((object)CS_0024_003C_003E8__locals1.newRole).ToString() });
			transaction.UpdateData(guildRef, new Dictionary<object, object> { [(object)"lastActivityAt"] = DateTimeOffset.UtcNow });
			return true;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass22_0
	{
		public string newLeaderId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass22_1
	{
		public IDocumentReference guildRef;

		public string guildName;

		public IDocumentReference newLeaderMemberRef;

		public IDocumentReference oldLeaderMemberRef;

		public _003C_003Ec__DisplayClass22_0 CS_0024_003C_003E8__locals1;

		internal object _003CTransferLeadershipAsync_003Eb__0(ITransaction transaction)
		{
			//IL_011a: Unknown result type (might be due to invalid IL or missing references)
			IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(guildRef);
			if (document.Data == null)
			{
				throw new global::System.Exception("Guild not found");
			}
			guildName = document.Data.Name;
			IDocumentSnapshot<FirestoreGuildMemberDTO> document2 = transaction.GetDocument<FirestoreGuildMemberDTO>(newLeaderMemberRef);
			if (document2.Data == null)
			{
				throw new global::System.Exception("New leader member not found");
			}
			IDocumentSnapshot<FirestoreGuildMemberDTO> document3 = transaction.GetDocument<FirestoreGuildMemberDTO>(oldLeaderMemberRef);
			if (document3.Data == null)
			{
				throw new global::System.Exception("Current leader member not found");
			}
			transaction.UpdateData(newLeaderMemberRef, new Dictionary<object, object> { [(object)"role"] = ((object)GuildRole.Guildmaster).ToString() });
			transaction.UpdateData(oldLeaderMemberRef, new Dictionary<object, object> { [(object)"role"] = ((object)GuildRole.Vice_Guildmaster).ToString() });
			transaction.UpdateData(guildRef, new Dictionary<object, object>
			{
				[(object)"leaderPlayerId"] = CS_0024_003C_003E8__locals1.newLeaderId,
				[(object)"lastActivityAt"] = DateTimeOffset.UtcNow
			});
			return true;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass23_0
	{
		public IDocumentReference guildRef;

		public string guildName;

		public IDocumentReference memberRef;

		public string oldRole;

		public string newRoleStr;

		internal object _003CDemoteMemberAsync_003Eb__0(ITransaction transaction)
		{
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(guildRef);
			if (document.Data == null)
			{
				throw new global::System.Exception("Guild not found");
			}
			guildName = document.Data.Name;
			IDocumentSnapshot<FirestoreGuildMemberDTO> document2 = transaction.GetDocument<FirestoreGuildMemberDTO>(memberRef);
			if (document2.Data == null)
			{
				throw new global::System.Exception("Member not found");
			}
			oldRole = document2.Data.Role;
			transaction.UpdateData(memberRef, new Dictionary<object, object> { [(object)"role"] = newRoleStr });
			transaction.UpdateData(guildRef, new Dictionary<object, object> { [(object)"lastActivityAt"] = DateTimeOffset.UtcNow });
			return true;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass24_0
	{
		public int contributionAmount;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass24_1
	{
		public IDocumentReference memberRef;

		public IDocumentReference guildRef;

		public _003C_003Ec__DisplayClass24_0 CS_0024_003C_003E8__locals1;

		internal bool _003CUpdateMemberContributionAsync_003Eb__0(ITransaction transaction)
		{
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			IDocumentSnapshot<FirestoreGuildMemberDTO> document = transaction.GetDocument<FirestoreGuildMemberDTO>(memberRef);
			if (document.Data == null)
			{
				throw new global::System.Exception("Member not found");
			}
			transaction.UpdateData(memberRef, new Dictionary<object, object>
			{
				[(object)"contribution"] = document.Data.Contribution + CS_0024_003C_003E8__locals1.contributionAmount,
				[(object)"weeklyContribution"] = document.Data.WeeklyContribution + CS_0024_003C_003E8__locals1.contributionAmount
			});
			transaction.UpdateData(guildRef, new Dictionary<object, object> { [(object)"lastActivityAt"] = DateTimeOffset.UtcNow });
			return true;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass26_0
	{
		public string searchText;

		public GuildSearchFilters filters;

		public int playerLevel;

		public long playerTrophies;

		internal bool _003CSearchGuildsAsync_003Eb__2(FirestoreGuildDTO g)
		{
			return g.Name?.Contains(searchText, (StringComparison)5) ?? false;
		}

		internal bool _003CSearchGuildsAsync_003Eb__3(FirestoreGuildDTO g)
		{
			return g.MemberCount >= filters.MinMembers.Value;
		}

		internal bool _003CSearchGuildsAsync_003Eb__4(FirestoreGuildDTO g)
		{
			return g.MemberCount <= filters.MaxMembers.Value;
		}

		internal bool _003CSearchGuildsAsync_003Eb__5(FirestoreGuildDTO g)
		{
			return g.Trophies >= filters.MinTrophies.Value;
		}

		internal bool _003CSearchGuildsAsync_003Eb__6(FirestoreGuildDTO g)
		{
			return g.Trophies <= filters.MaxTrophies.Value;
		}

		internal bool _003CSearchGuildsAsync_003Eb__7(FirestoreGuildDTO g)
		{
			return g.IsPublic == filters.IsPublic.Value;
		}

		internal bool _003CSearchGuildsAsync_003Eb__8(FirestoreGuildDTO g)
		{
			return g.Level >= filters.MinLevel.Value;
		}

		internal bool _003CSearchGuildsAsync_003Eb__9(FirestoreGuildDTO g)
		{
			return g.Level <= filters.MaxLevel.Value;
		}

		internal GuildSearchResult _003CSearchGuildsAsync_003Eb__10(FirestoreGuildDTO g)
		{
			return new GuildSearchResult
			{
				GuildId = (g.ID ?? string.Empty),
				Name = (g.Name ?? "Unknown"),
				Emblem = (g.Emblem ?? "\ud83d\udc51"),
				Rank = g.Rank,
				Level = g.Level,
				MemberCount = g.MemberCount,
				MaxMembers = g.MaxMembers,
				Trophies = g.Trophies,
				IsPublic = g.IsPublic,
				RequiresApproval = g.RequiresApproval,
				MinLevelRequired = g.MinLevelRequired,
				MinTrophiesRequired = g.MinTrophiesRequired,
				CanJoin = (playerLevel >= g.MinLevelRequired && playerTrophies >= g.MinTrophiesRequired && g.MemberCount < g.MaxMembers)
			};
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass28_0
	{
		public int playerLevel;

		public long playerTrophies;

		internal bool _003CGetRecommendedGuildsAsync_003Eb__2(FirestoreGuildDTO g)
		{
			return g.IsPublic && g.MinLevelRequired <= playerLevel && g.MinTrophiesRequired <= playerTrophies && g.MemberCount < g.MaxMembers;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass29_0
	{
		public string playerId;

		public string guildId;

		public GuildRepository _003C_003E4__this;

		public string message;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass29_1
	{
		public IDocumentReference playerRef;

		public IDocumentReference guildRef;

		public _003C_003Ec__DisplayClass29_0 CS_0024_003C_003E8__locals1;

		internal bool _003CSendJoinRequestAsync_003Eb__0(ITransaction transaction)
		{
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
			IDocumentSnapshot<FirestorePlayerDTO> document = transaction.GetDocument<FirestorePlayerDTO>(playerRef);
			if (document.Data == null)
			{
				throw new ArgumentException("Player '" + CS_0024_003C_003E8__locals1.playerId + "' not found");
			}
			if (!string.IsNullOrEmpty(document.Data.GuildId))
			{
				throw new AlreadyInGuildException(CS_0024_003C_003E8__locals1.playerId, document.Data.GuildId);
			}
			IDocumentSnapshot<FirestoreGuildDTO> document2 = transaction.GetDocument<FirestoreGuildDTO>(guildRef);
			if (document2.Data == null)
			{
				throw new GuildNotFoundException(CS_0024_003C_003E8__locals1.guildId);
			}
			if (document2.Data.MemberCount >= document2.Data.MaxMembers)
			{
				throw new GuildFullException(CS_0024_003C_003E8__locals1.guildId, document2.Data.MemberCount, document2.Data.MaxMembers);
			}
			IDocumentReference val = CS_0024_003C_003E8__locals1._003C_003E4__this._firestore.GetCollection("guilds").GetDocument(CS_0024_003C_003E8__locals1.guildId).GetCollection("joinRequests")
				.CreateDocument();
			FirestoreGuildJoinRequestDTO obj = new FirestoreGuildJoinRequestDTO
			{
				ID = val.Id,
				PlayerId = CS_0024_003C_003E8__locals1.playerId,
				PlayerName = document.Data.Playername,
				PlayerLevel = document.Data.PlayerLevel
			};
			Dictionary<string, long>? currencies = document.Data.Currencies;
			obj.PlayerTrophies = (int)((currencies != null) ? CollectionExtensions.GetValueOrDefault<string, long>((IReadOnlyDictionary<string, long>)(object)currencies, "reputation", 0L) : 0);
			obj.Message = CS_0024_003C_003E8__locals1.message;
			obj.Status = "Pending";
			obj.CreatedAt = DateTimeOffset.UtcNow;
			FirestoreGuildJoinRequestDTO firestoreGuildJoinRequestDTO = obj;
			transaction.SetData(val, (object)firestoreGuildJoinRequestDTO, (SetOptions)null);
			return true;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass36_0
	{
		public string playerId;

		internal GuildInvitation _003CGetPlayerInvitationsAsync_003Eb__3(FirestorePlayerNotificationDTO dto)
		{
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			Dictionary<string, object> data = dto.Data;
			DateTimeOffset expiresAt = dto.Ttl;
			object obj = default(object);
			DateTimeOffset val = default(DateTimeOffset);
			if (data.TryGetValue("expiresAt", ref obj) && obj is string text && DateTimeOffset.TryParse(text, ref val))
			{
				expiresAt = val;
			}
			return new GuildInvitation
			{
				ID = dto.Id,
				GuildId = ((CollectionExtensions.GetValueOrDefault<string, object>((IReadOnlyDictionary<string, object>)(object)data, "guildId") as string) ?? string.Empty),
				GuildName = ((CollectionExtensions.GetValueOrDefault<string, object>((IReadOnlyDictionary<string, object>)(object)data, "guildName") as string) ?? "Unknown"),
				InvitedPlayerId = playerId,
				InvitedByPlayerId = ((CollectionExtensions.GetValueOrDefault<string, object>((IReadOnlyDictionary<string, object>)(object)data, "invitedByPlayerId") as string) ?? string.Empty),
				InvitedByPlayerName = ((CollectionExtensions.GetValueOrDefault<string, object>((IReadOnlyDictionary<string, object>)(object)data, "invitedByPlayerName") as string) ?? "Unknown"),
				Status = InvitationStatus.Pending,
				CreatedAt = dto.CreatedAt,
				ExpiresAt = expiresAt
			};
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass36_1
	{
		public string invitationType;

		internal bool _003CGetPlayerInvitationsAsync_003Eb__1(FirestorePlayerNotificationDTO dto)
		{
			return dto != null && dto.Type == invitationType;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass38_0
	{
		public int trophyChange;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass38_1
	{
		public IDocumentReference guildRef;

		public _003C_003Ec__DisplayClass38_0 CS_0024_003C_003E8__locals1;

		internal bool _003CUpdateGuildTrophiesAsync_003Eb__0(ITransaction transaction)
		{
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(guildRef);
			if (document.Data == null)
			{
				throw new global::System.Exception("Guild not found");
			}
			int num = Math.Max(0, document.Data.Trophies + CS_0024_003C_003E8__locals1.trophyChange);
			transaction.UpdateData(guildRef, new Dictionary<object, object>
			{
				[(object)"trophies"] = num,
				[(object)"lastActivityAt"] = DateTimeOffset.UtcNow
			});
			return true;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass41_0
	{
		public int coinsAmount;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass41_1
	{
		public IDocumentReference guildRef;

		public _003C_003Ec__DisplayClass41_0 CS_0024_003C_003E8__locals1;

		internal bool _003CAddGuildCoinsAsync_003Eb__0(ITransaction transaction)
		{
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(guildRef);
			if (document.Data == null)
			{
				throw new global::System.Exception("Guild not found");
			}
			int num = document.Data.GuildCoins + CS_0024_003C_003E8__locals1.coinsAmount;
			transaction.UpdateData(guildRef, new Dictionary<object, object>
			{
				[(object)"guildCoins"] = num,
				[(object)"lastActivityAt"] = DateTimeOffset.UtcNow
			});
			return true;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass42_0
	{
		public int coinsAmount;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass42_1
	{
		public IDocumentReference guildRef;

		public _003C_003Ec__DisplayClass42_0 CS_0024_003C_003E8__locals1;

		internal bool _003CSpendGuildCoinsAsync_003Eb__0(ITransaction transaction)
		{
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(guildRef);
			if (document.Data == null)
			{
				throw new global::System.Exception("Guild not found");
			}
			if (document.Data.GuildCoins < CS_0024_003C_003E8__locals1.coinsAmount)
			{
				throw new global::System.Exception("Insufficient guild coins");
			}
			int num = document.Data.GuildCoins - CS_0024_003C_003E8__locals1.coinsAmount;
			transaction.UpdateData(guildRef, new Dictionary<object, object>
			{
				[(object)"guildCoins"] = num,
				[(object)"lastActivityAt"] = DateTimeOffset.UtcNow
			});
			return true;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass44_0
	{
		public int xpAmount;

		public GuildRepository _003C_003E4__this;

		public string guildId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass44_1
	{
		public IDocumentReference guildRef;

		public _003C_003Ec__DisplayClass44_0 CS_0024_003C_003E8__locals1;

		internal bool _003CAddGuildXPAsync_003Eb__0(ITransaction transaction)
		{
			IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(guildRef);
			if (document.Data == null)
			{
				throw new global::System.Exception("Guild not found");
			}
			int currentXP = document.Data.CurrentXP;
			int num = document.Data.XPForNextLevel;
			int num2 = document.Data.Level;
			int num3 = currentXP + CS_0024_003C_003E8__locals1.xpAmount;
			int num4 = 0;
			while (num3 >= num)
			{
				num3 -= num;
				num2++;
				num4++;
				num = CS_0024_003C_003E8__locals1._003C_003E4__this.CalculateXPForLevel(num2 + 1);
			}
			transaction.UpdateData(guildRef, new Dictionary<object, object>
			{
				[(object)"currentXP"] = num3,
				[(object)"level"] = num2,
				[(object)"xpForNextLevel"] = num,
				[(object)"lastActivityAt"] = global::System.DateTime.UtcNow
			});
			if (num4 > 0)
			{
				IDocumentReference val = CS_0024_003C_003E8__locals1._003C_003E4__this._firestore.GetCollection("guilds").GetDocument(CS_0024_003C_003E8__locals1.guildId).GetCollection("activities")
					.CreateDocument();
				transaction.SetData(val, (object)new Dictionary<string, object>
				{
					["type"] = "level_up",
					["message"] = $"Guild reached level {num2}!",
					["icon"] = "⭐",
					["isHighlighted"] = true,
					["timestamp"] = global::System.DateTime.UtcNow
				}, (SetOptions)null);
			}
			return true;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass45_0
	{
		public string playerId;

		public string playerName;

		public int playerLevel;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass45_1
	{
		public IDocumentReference guildRef;

		public string guildName;

		public IDocumentReference memberRef;

		public DateTimeOffset joinedAt;

		public _003C_003Ec__DisplayClass45_0 CS_0024_003C_003E8__locals1;

		internal bool _003CJoinGuildAsync_003Eb__0(ITransaction transaction)
		{
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(guildRef);
			if (document.Data == null)
			{
				throw new global::System.Exception("Guild not found");
			}
			guildName = document.Data.Name;
			int memberCount = document.Data.MemberCount;
			int maxMembers = document.Data.MaxMembers;
			if (memberCount >= maxMembers)
			{
				throw new global::System.Exception("Guild is full");
			}
			int num = memberCount + 1;
			transaction.UpdateData(guildRef, new Dictionary<object, object> { [(object)"memberCount"] = num });
			transaction.SetData(memberRef, (object)new FirestoreGuildMemberDTO
			{
				PlayerId = CS_0024_003C_003E8__locals1.playerId,
				PlayerName = CS_0024_003C_003E8__locals1.playerName,
				Role = "Member",
				Level = CS_0024_003C_003E8__locals1.playerLevel,
				Trophies = 0,
				Contribution = 0,
				WeeklyContribution = 0,
				JoinedAt = joinedAt,
				LastActiveAt = joinedAt,
				IsOnline = true
			}, (SetOptions)null);
			return true;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass47_0
	{
		public string guildId;

		public string playerId;

		public List<string> defenderSquad;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass47_1
	{
		public IDocumentReference guildRef;

		public _003C_003Ec__DisplayClass47_0 CS_0024_003C_003E8__locals1;

		internal bool _003CSignUpAsDefenderAsync_003Eb__1(ITransaction transaction)
		{
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_013b: Unknown result type (might be due to invalid IL or missing references)
			IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(guildRef);
			if (document.Data == null)
			{
				throw new GuildNotFoundException(CS_0024_003C_003E8__locals1.guildId);
			}
			Dictionary<string, DefenderData> val = ToDomainDefenders(document.Data.Defenders);
			DateTimeOffset utcNow = DateTimeOffset.UtcNow;
			DefenderData defenderData = default(DefenderData);
			if (val.TryGetValue(CS_0024_003C_003E8__locals1.playerId, ref defenderData))
			{
				val[CS_0024_003C_003E8__locals1.playerId] = defenderData with
				{
					SquadIds = CS_0024_003C_003E8__locals1.defenderSquad,
					ExpiresAt = ((DateTimeOffset)(ref utcNow)).AddHours(8.0)
				};
			}
			else
			{
				if (val.Count >= 25)
				{
					throw new MaxDefendersReachedException(CS_0024_003C_003E8__locals1.guildId, val.Count, 25);
				}
				val[CS_0024_003C_003E8__locals1.playerId] = new DefenderData(CS_0024_003C_003E8__locals1.defenderSquad, utcNow, ((DateTimeOffset)(ref utcNow)).AddHours(8.0), IsMainDefender: false);
			}
			transaction.UpdateData(guildRef, new Dictionary<object, object>
			{
				[(object)"defenders"] = ToFirestoreDefenders(val),
				[(object)"lastActivityAt"] = utcNow
			});
			return true;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass48_0
	{
		public string guildId;

		public string playerId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass48_1
	{
		public IDocumentReference guildRef;

		public _003C_003Ec__DisplayClass48_0 CS_0024_003C_003E8__locals1;

		internal bool _003CRemoveDefenderAsync_003Eb__0(ITransaction transaction)
		{
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(guildRef);
			if (document.Data == null)
			{
				throw new GuildNotFoundException(CS_0024_003C_003E8__locals1.guildId);
			}
			Dictionary<string, DefenderData> val = ToDomainDefenders(document.Data.Defenders);
			val.Remove(CS_0024_003C_003E8__locals1.playerId);
			transaction.UpdateData(guildRef, new Dictionary<object, object>
			{
				[(object)"defenders"] = ToFirestoreDefenders(val),
				[(object)"lastActivityAt"] = DateTimeOffset.UtcNow
			});
			return true;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass49_0
	{
		public GuildRepository _003C_003E4__this;

		public string guildId;

		internal global::System.Threading.Tasks.Task<GuildMember> _003CGetDefendersAsync_003Eb__0(string id)
		{
			return _003C_003E4__this.GetMemberAsync(guildId, id);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass50_0
	{
		public List<string> mainDefenderPlayerIds;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass50_1
	{
		public IDocumentReference guildRef;

		public _003C_003Ec__DisplayClass50_0 CS_0024_003C_003E8__locals1;

		internal bool _003CSetMainDefendersAsync_003Eb__0(ITransaction transaction)
		{
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0132: Unknown result type (might be due to invalid IL or missing references)
			_003C_003Ec__DisplayClass50_2 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass50_2();
			IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(guildRef);
			if (document.Data == null)
			{
				throw new global::System.Exception("Guild not found");
			}
			CS_0024_003C_003E8__locals0.defenders = ToDomainDefenders(document.Data.Defenders);
			if (Enumerable.Any<string>((global::System.Collections.Generic.IEnumerable<string>)CS_0024_003C_003E8__locals1.mainDefenderPlayerIds, (Func<string, bool>)((string id) => !CS_0024_003C_003E8__locals0.defenders.ContainsKey(id))))
			{
				throw new global::System.Exception("All main defenders must be signed up defenders");
			}
			Enumerator<string> enumerator = Enumerable.ToList<string>((global::System.Collections.Generic.IEnumerable<string>)CS_0024_003C_003E8__locals0.defenders.Keys).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					string current = enumerator.Current;
					DefenderData defenderData = CS_0024_003C_003E8__locals0.defenders[current];
					bool flag = CS_0024_003C_003E8__locals1.mainDefenderPlayerIds.Contains(current);
					if (defenderData.IsMainDefender != flag)
					{
						CS_0024_003C_003E8__locals0.defenders[current] = defenderData with
						{
							IsMainDefender = flag
						};
					}
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator).Dispose();
			}
			transaction.UpdateData(guildRef, new Dictionary<object, object>
			{
				[(object)"defenders"] = ToFirestoreDefenders(CS_0024_003C_003E8__locals0.defenders),
				[(object)"lastActivityAt"] = DateTimeOffset.UtcNow
			});
			return true;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass50_2
	{
		public Dictionary<string, DefenderData> defenders;

		internal bool _003CSetMainDefendersAsync_003Eb__1(string id)
		{
			return !defenders.ContainsKey(id);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass51_0
	{
		public GuildRepository _003C_003E4__this;

		public string guildId;

		internal global::System.Threading.Tasks.Task<GuildMember> _003CGetMainDefendersAsync_003Eb__0(string id)
		{
			return _003C_003E4__this.GetMemberAsync(guildId, id);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass55_0
	{
		public string defenderPlayerId;

		public DateTimeOffset downtimeEnds;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass55_1
	{
		public IDocumentReference guildRef;

		public _003C_003Ec__DisplayClass55_0 CS_0024_003C_003E8__locals1;

		internal bool _003CSetDefenderDowntimeAndBreakAsync_003Eb__0(ITransaction transaction)
		{
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			_003C_003Ec__DisplayClass55_2 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass55_2();
			IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(guildRef);
			if (document.Data?.Defenders == null)
			{
				return false;
			}
			Dictionary<string, DefenderData> val = ToDomainDefenders(document.Data.Defenders);
			DefenderData defenderData = default(DefenderData);
			if (!val.TryGetValue(CS_0024_003C_003E8__locals1.defenderPlayerId, ref defenderData))
			{
				return false;
			}
			val[CS_0024_003C_003E8__locals1.defenderPlayerId] = defenderData with
			{
				DowntimeEnds = CS_0024_003C_003E8__locals1.downtimeEnds
			};
			CS_0024_003C_003E8__locals0.now = DateTimeOffset.UtcNow;
			bool flag = Enumerable.Any<DefenderData>((global::System.Collections.Generic.IEnumerable<DefenderData>)val.Values, (Func<DefenderData, bool>)((DefenderData d) => d.ExpiresAt > CS_0024_003C_003E8__locals0.now && (!d.DowntimeEnds.HasValue || !(d.DowntimeEnds.Value > CS_0024_003C_003E8__locals0.now))));
			Dictionary<object, object> val2 = new Dictionary<object, object> { [(object)"defenders"] = ToFirestoreDefenders(val) };
			if (!flag)
			{
				val2[(object)"guildBreakEndsAt"] = ((DateTimeOffset)(ref CS_0024_003C_003E8__locals0.now)).AddMinutes(30.0);
			}
			transaction.UpdateData(guildRef, val2);
			return true;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass55_2
	{
		public DateTimeOffset now;

		internal bool _003CSetDefenderDowntimeAndBreakAsync_003Eb__1(DefenderData d)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			return d.ExpiresAt > now && (!d.DowntimeEnds.HasValue || !(d.DowntimeEnds.Value > now));
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass59_0
	{
		public List<string> availableDefenderIds;

		internal bool _003CGetNextDefenderAsync_003Eb__0(string id)
		{
			return availableDefenderIds.Contains(id);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass60_0
	{
		public IDocumentReference guildRef;

		public int removedCount;

		internal int _003CRemoveExpiredDefendersAsync_003Eb__0(ITransaction transaction)
		{
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_010e: Unknown result type (might be due to invalid IL or missing references)
			_003C_003Ec__DisplayClass60_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass60_1();
			IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(guildRef);
			if (document.Data == null)
			{
				throw new global::System.Exception("Guild not found");
			}
			Dictionary<string, DefenderData> val = ToDomainDefenders(document.Data.Defenders);
			CS_0024_003C_003E8__locals0.now = DateTimeOffset.UtcNow;
			List<string> val2 = Enumerable.ToList<string>(Enumerable.Select<KeyValuePair<string, DefenderData>, string>(Enumerable.Where<KeyValuePair<string, DefenderData>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, DefenderData>>)val, (Func<KeyValuePair<string, DefenderData>, bool>)((KeyValuePair<string, DefenderData> kv) => kv.Value.ExpiresAt <= CS_0024_003C_003E8__locals0.now)), (Func<KeyValuePair<string, DefenderData>, string>)((KeyValuePair<string, DefenderData> kv) => kv.Key)));
			Enumerator<string> enumerator = val2.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					string current = enumerator.Current;
					val.Remove(current);
					removedCount++;
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator).Dispose();
			}
			if (removedCount > 0)
			{
				transaction.UpdateData(guildRef, new Dictionary<object, object>
				{
					[(object)"defenders"] = ToFirestoreDefenders(val),
					[(object)"lastActivityAt"] = CS_0024_003C_003E8__locals0.now
				});
			}
			return removedCount;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass60_1
	{
		public DateTimeOffset now;

		internal bool _003CRemoveExpiredDefendersAsync_003Eb__1(KeyValuePair<string, DefenderData> kv)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			return kv.Value.ExpiresAt <= now;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass61_0
	{
		public Guild guild;

		public string playerId;

		public List<string> squadIds;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass61_1
	{
		public IDocumentReference guildRef;

		public _003C_003Ec__DisplayClass61_0 CS_0024_003C_003E8__locals1;

		internal bool _003CRegisterAsDefenderAsync_003Eb__0(ITransaction transaction)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0153: Unknown result type (might be due to invalid IL or missing references)
			DateTimeOffset utcNow = DateTimeOffset.UtcNow;
			Dictionary<string, DefenderData> defenders = CS_0024_003C_003E8__locals1.guild.Defenders;
			DefenderData defenderData = default(DefenderData);
			DateTimeOffset value;
			if (defenders.TryGetValue(CS_0024_003C_003E8__locals1.playerId, ref defenderData))
			{
				string playerId = CS_0024_003C_003E8__locals1.playerId;
				DefenderData obj = defenderData with
				{
					SquadIds = CS_0024_003C_003E8__locals1.squadIds
				};
				value = CS_0024_003C_003E8__locals1.guild.CurrentSeasonStartDate.Value;
				obj.ExpiresAt = ((DateTimeOffset)(ref value)).AddHours(8.0);
				defenders[playerId] = obj;
			}
			else
			{
				if (defenders.Count >= 25)
				{
					throw new MaxDefendersReachedException(CS_0024_003C_003E8__locals1.guild.ID ?? "", defenders.Count, 25);
				}
				string playerId2 = CS_0024_003C_003E8__locals1.playerId;
				List<string> squadIds = CS_0024_003C_003E8__locals1.squadIds;
				value = CS_0024_003C_003E8__locals1.guild.CurrentSeasonStartDate.Value;
				defenders[playerId2] = new DefenderData(squadIds, utcNow, ((DateTimeOffset)(ref value)).AddHours(8.0), IsMainDefender: false);
			}
			transaction.UpdateData(guildRef, new Dictionary<object, object>
			{
				[(object)"defenders"] = ToFirestoreDefenders(defenders),
				[(object)"lastActivityAt"] = utcNow
			});
			return true;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass62_0
	{
		public string guildId;

		public string playerId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass62_1
	{
		public IDocumentReference guildRef;

		public _003C_003Ec__DisplayClass62_0 CS_0024_003C_003E8__locals1;

		internal bool _003CUnregisterAsDefenderAsync_003Eb__0(ITransaction transaction)
		{
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(guildRef);
			if (document.Data == null)
			{
				throw new GuildNotFoundException(CS_0024_003C_003E8__locals1.guildId);
			}
			Dictionary<string, DefenderData> val = ToDomainDefenders(document.Data.Defenders);
			val.Remove(CS_0024_003C_003E8__locals1.playerId);
			transaction.UpdateData(guildRef, new Dictionary<object, object>
			{
				[(object)"defenders"] = ToFirestoreDefenders(val),
				[(object)"lastActivityAt"] = DateTimeOffset.UtcNow
			});
			return true;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass63_0
	{
		public string playerId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass63_1
	{
		public IDocumentReference guildRef;

		public _003C_003Ec__DisplayClass63_0 CS_0024_003C_003E8__locals1;

		internal bool _003CRefreshDefenderAsync_003Eb__0(ITransaction transaction)
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
			_003C_003Ec__DisplayClass63_2 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass63_2();
			IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(guildRef);
			if (document.Data == null)
			{
				return false;
			}
			CS_0024_003C_003E8__locals0.now = DateTimeOffset.UtcNow;
			DateTimeOffset expiresAt = ((DateTimeOffset)(ref CS_0024_003C_003E8__locals0.now)).AddHours(8.0);
			Dictionary<string, DefenderData> val = ToDomainDefenders(document.Data.Defenders);
			DefenderData defenderData = default(DefenderData);
			if (!val.TryGetValue(CS_0024_003C_003E8__locals1.playerId, ref defenderData))
			{
				return false;
			}
			val[CS_0024_003C_003E8__locals1.playerId] = defenderData with
			{
				ExpiresAt = expiresAt,
				DowntimeEnds = null
			};
			Dictionary<object, object> val2 = new Dictionary<object, object>
			{
				[(object)"defenders"] = ToFirestoreDefenders(val),
				[(object)"lastActivityAt"] = CS_0024_003C_003E8__locals0.now
			};
			if (Enumerable.Any<DefenderData>((global::System.Collections.Generic.IEnumerable<DefenderData>)val.Values, (Func<DefenderData, bool>)((DefenderData d) => d.ExpiresAt > CS_0024_003C_003E8__locals0.now && (!d.DowntimeEnds.HasValue || !(d.DowntimeEnds.Value > CS_0024_003C_003E8__locals0.now)))))
			{
				val2[(object)"guildBreakEndsAt"] = null;
			}
			transaction.UpdateData(guildRef, val2);
			return true;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass63_2
	{
		public DateTimeOffset now;

		internal bool _003CRefreshDefenderAsync_003Eb__1(DefenderData d)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			return d.ExpiresAt > now && (!d.DowntimeEnds.HasValue || !(d.DowntimeEnds.Value > now));
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass64_0
	{
		public string guildId;

		public GuildRepository _003C_003E4__this;

		internal bool _003CGetWarBucketOpponentsAsync_003Eb__0(string id)
		{
			return id != guildId;
		}

		internal global::System.Threading.Tasks.Task<Guild> _003CGetWarBucketOpponentsAsync_003Eb__3(string id)
		{
			return _003C_003E4__this.GetByIdAsync(id);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass65_0
	{
		public int crystalCost;

		public string perkKey;

		public int tier;

		public DateTimeOffset activatedAt;

		public string activatedByPlayerId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass65_1
	{
		public IDocumentReference guildRef;

		public _003C_003Ec__DisplayClass65_0 CS_0024_003C_003E8__locals1;

		internal bool _003CApplyGuildPerkAsync_003Eb__0(ITransaction transaction)
		{
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0120: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(guildRef);
			if (document.Data == null)
			{
				return false;
			}
			if (document.Data.Crystals < CS_0024_003C_003E8__locals1.crystalCost)
			{
				throw new InvalidOperationException("Insufficient guild crystals");
			}
			Dictionary<object, object> val = new Dictionary<object, object>
			{
				[(object)"crystals"] = document.Data.Crystals - CS_0024_003C_003E8__locals1.crystalCost,
				[(object)("activePerks." + CS_0024_003C_003E8__locals1.perkKey + ".tier")] = CS_0024_003C_003E8__locals1.tier,
				[(object)("activePerks." + CS_0024_003C_003E8__locals1.perkKey + ".activatedAt")] = CS_0024_003C_003E8__locals1.activatedAt,
				[(object)("activePerks." + CS_0024_003C_003E8__locals1.perkKey + ".activatedByPlayerId")] = CS_0024_003C_003E8__locals1.activatedByPlayerId,
				[(object)"lastActivityAt"] = DateTimeOffset.UtcNow
			};
			transaction.UpdateData(guildRef, val);
			return true;
		}
	}

	[CompilerGenerated]
	private sealed class _003CAcceptInvitationAsync_003Ed__34 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string invitationId;

		public string playerId;

		public Player currentPlayer;

		public GuildRepository _003C_003E4__this;

		private IDocumentReference _003CnotificationRef_003E5__1;

		private IDocumentSnapshot<FirestorePlayerNotificationDTO> _003Cdoc_003E5__2;

		private Dictionary<string, object> _003Cdata_003E5__3;

		private string _003CguildId_003E5__4;

		private object _003CexpiresAtObj_003E5__5;

		private string _003CexpiresAtStr_003E5__6;

		private DateTimeOffset _003CexpiresAt_003E5__7;

		private bool _003CcheckCurrentGuildMembership_003E5__8;

		private IDocumentSnapshot<FirestorePlayerNotificationDTO> _003C_003Es__9;

		private IDocumentSnapshot<FirestoreGuildDTO> _003CguildSnapshot_003E5__10;

		private IDocumentSnapshot<FirestoreGuildDTO> _003C_003Es__11;

		private bool _003C_003Es__12;

		private global::System.Exception _003Cex_003E5__13;

		private TaskAwaiter<IDocumentSnapshot<FirestorePlayerNotificationDTO>> _003C_003Eu__1;

		private TaskAwaiter<IDocumentSnapshot<FirestoreGuildDTO>> _003C_003Eu__2;

		private TaskAwaiter<bool> _003C_003Eu__3;

		private TaskAwaiter _003C_003Eu__4;

		private void MoveNext()
		{
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0265: Unknown result type (might be due to invalid IL or missing references)
			//IL_026a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0272: Unknown result type (might be due to invalid IL or missing references)
			//IL_0321: Unknown result type (might be due to invalid IL or missing references)
			//IL_0326: Unknown result type (might be due to invalid IL or missing references)
			//IL_032e: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_03fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0488: Unknown result type (might be due to invalid IL or missing references)
			//IL_048d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0495: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_044f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0454: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_0469: Unknown result type (might be due to invalid IL or missing references)
			//IL_046b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0302: Unknown result type (might be due to invalid IL or missing references)
			//IL_0304: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_03bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01be: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_022c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0231: Unknown result type (might be due to invalid IL or missing references)
			//IL_0246: Unknown result type (might be due to invalid IL or missing references)
			//IL_0248: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if ((uint)num > 4u)
				{
				}
				try
				{
					TaskAwaiter<IDocumentSnapshot<FirestorePlayerNotificationDTO>> awaiter5;
					TaskAwaiter<IDocumentSnapshot<FirestoreGuildDTO>> awaiter4;
					TaskAwaiter<bool> awaiter3;
					TaskAwaiter<bool> awaiter2;
					TaskAwaiter awaiter;
					switch (num)
					{
					default:
						_003CnotificationRef_003E5__1 = _003C_003E4__this._firestore.GetCollection("players").GetDocument(playerId).GetCollection("notifications")
							.GetDocument(invitationId);
						awaiter5 = _003CnotificationRef_003E5__1.GetDocumentSnapshotAsync<FirestorePlayerNotificationDTO>((Source)0).GetAwaiter();
						if (!awaiter5.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter5;
							_003CAcceptInvitationAsync_003Ed__34 _003CAcceptInvitationAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IDocumentSnapshot<FirestorePlayerNotificationDTO>>, _003CAcceptInvitationAsync_003Ed__34>(ref awaiter5, ref _003CAcceptInvitationAsync_003Ed__);
							return;
						}
						goto IL_00e0;
					case 0:
						awaiter5 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IDocumentSnapshot<FirestorePlayerNotificationDTO>>);
						num = (_003C_003E1__state = -1);
						goto IL_00e0;
					case 1:
						awaiter4 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<IDocumentSnapshot<FirestoreGuildDTO>>);
						num = (_003C_003E1__state = -1);
						goto IL_0281;
					case 2:
						awaiter3 = _003C_003Eu__3;
						_003C_003Eu__3 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
						goto IL_033d;
					case 3:
						awaiter2 = _003C_003Eu__3;
						_003C_003Eu__3 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
						goto IL_040b;
					case 4:
						{
							awaiter = _003C_003Eu__4;
							_003C_003Eu__4 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							break;
						}
						IL_033d:
						_003C_003Es__12 = awaiter3.GetResult();
						_003CcheckCurrentGuildMembership_003E5__8 = _003C_003Es__12;
						_003CguildSnapshot_003E5__10 = null;
						goto IL_035e;
						IL_00e0:
						_003C_003Es__9 = awaiter5.GetResult();
						_003Cdoc_003E5__2 = _003C_003Es__9;
						_003C_003Es__9 = null;
						if (_003Cdoc_003E5__2.Data == null || !_003Cdoc_003E5__2.Data.Unansweared)
						{
							result = false;
						}
						else
						{
							_003Cdata_003E5__3 = _003Cdoc_003E5__2.Data.Data;
							_003CguildId_003E5__4 = CollectionExtensions.GetValueOrDefault<string, object>((IReadOnlyDictionary<string, object>)(object)_003Cdata_003E5__3, "guildId") as string;
							if (string.IsNullOrEmpty(_003CguildId_003E5__4))
							{
								result = false;
							}
							else
							{
								if (!_003Cdata_003E5__3.TryGetValue("expiresAt", ref _003CexpiresAtObj_003E5__5))
								{
									goto IL_01dd;
								}
								_003CexpiresAtStr_003E5__6 = _003CexpiresAtObj_003E5__5 as string;
								if (_003CexpiresAtStr_003E5__6 == null || !DateTimeOffset.TryParse(_003CexpiresAtStr_003E5__6, ref _003CexpiresAt_003E5__7) || !(_003CexpiresAt_003E5__7 < DateTimeOffset.UtcNow))
								{
									goto IL_01dd;
								}
								result = false;
							}
						}
						goto end_IL_0011;
						IL_035e:
						if (_003CcheckCurrentGuildMembership_003E5__8)
						{
							awaiter2 = _003C_003E4__this.JoinGuildAsync(playerId, currentPlayer.Playername ?? "Unknown", _003CguildId_003E5__4, currentPlayer.PlayerLevel).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_003C_003E1__state = 3);
								_003C_003Eu__3 = awaiter2;
								_003CAcceptInvitationAsync_003Ed__34 _003CAcceptInvitationAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CAcceptInvitationAsync_003Ed__34>(ref awaiter2, ref _003CAcceptInvitationAsync_003Ed__);
								return;
							}
							goto IL_040b;
						}
						Console.WriteLine("Changing guild membership failed, could not leave current guild");
						result = false;
						goto end_IL_0011;
						IL_040b:
						awaiter2.GetResult();
						awaiter = _003CnotificationRef_003E5__1.UpdateDataAsync(new Dictionary<object, object>
						{
							[(object)"read"] = true,
							[(object)"unansweared"] = false
						}).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 4);
							_003C_003Eu__4 = awaiter;
							_003CAcceptInvitationAsync_003Ed__34 _003CAcceptInvitationAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CAcceptInvitationAsync_003Ed__34>(ref awaiter, ref _003CAcceptInvitationAsync_003Ed__);
							return;
						}
						break;
						IL_01dd:
						_003CcheckCurrentGuildMembership_003E5__8 = true;
						if (!string.IsNullOrEmpty(currentPlayer.GuildId))
						{
							awaiter4 = _003C_003E4__this._firestore.GetCollection("guilds").GetDocument(currentPlayer.GuildId).GetDocumentSnapshotAsync<FirestoreGuildDTO>((Source)0)
								.GetAwaiter();
							if (!awaiter4.IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__2 = awaiter4;
								_003CAcceptInvitationAsync_003Ed__34 _003CAcceptInvitationAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IDocumentSnapshot<FirestoreGuildDTO>>, _003CAcceptInvitationAsync_003Ed__34>(ref awaiter4, ref _003CAcceptInvitationAsync_003Ed__);
								return;
							}
							goto IL_0281;
						}
						goto IL_035e;
						IL_0281:
						_003C_003Es__11 = awaiter4.GetResult();
						_003CguildSnapshot_003E5__10 = _003C_003Es__11;
						_003C_003Es__11 = null;
						if (_003CguildSnapshot_003E5__10.Data != null)
						{
							awaiter3 = _003C_003E4__this.LeaveGuildAsync(playerId, currentPlayer.GuildId, GuildEntityMapper.ToEntity(_003CguildSnapshot_003E5__10.Data)).GetAwaiter();
							if (!awaiter3.IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__3 = awaiter3;
								_003CAcceptInvitationAsync_003Ed__34 _003CAcceptInvitationAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CAcceptInvitationAsync_003Ed__34>(ref awaiter3, ref _003CAcceptInvitationAsync_003Ed__);
								return;
							}
							goto IL_033d;
						}
						result = false;
						goto end_IL_0011;
					}
					((TaskAwaiter)(ref awaiter)).GetResult();
					result = true;
					end_IL_0011:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__13 = ex;
					Console.WriteLine("AcceptInvitationAsync failed: " + _003Cex_003E5__13.Message);
					result = false;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CAddGuildCoinsAsync_003Ed__41 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string guildId;

		public int coinsAmount;

		public GuildRepository _003C_003E4__this;

		private _003C_003Ec__DisplayClass41_0 _003C_003E8__1;

		private _003C_003Ec__DisplayClass41_1 _003C_003E8__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if (num != 0)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass41_0();
					_003C_003E8__1.coinsAmount = coinsAmount;
				}
				try
				{
					TaskAwaiter<bool> awaiter;
					if (num != 0)
					{
						_003C_003E8__2 = new _003C_003Ec__DisplayClass41_1();
						_003C_003E8__2.CS_0024_003C_003E8__locals1 = _003C_003E8__1;
						_003C_003E8__2.guildRef = _003C_003E4__this._firestore.GetCollection("guilds").GetDocument(guildId);
						awaiter = _003C_003E4__this._firestore.RunTransactionAsync<bool>((Func<ITransaction, bool>)delegate(ITransaction transaction)
						{
							//IL_0068: Unknown result type (might be due to invalid IL or missing references)
							IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(_003C_003E8__2.guildRef);
							if (document.Data == null)
							{
								throw new global::System.Exception("Guild not found");
							}
							int num2 = document.Data.GuildCoins + _003C_003E8__2.CS_0024_003C_003E8__locals1.coinsAmount;
							transaction.UpdateData(_003C_003E8__2.guildRef, new Dictionary<object, object>
							{
								[(object)"guildCoins"] = num2,
								[(object)"lastActivityAt"] = DateTimeOffset.UtcNow
							});
							return true;
						}).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CAddGuildCoinsAsync_003Ed__41 _003CAddGuildCoinsAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CAddGuildCoinsAsync_003Ed__41>(ref awaiter, ref _003CAddGuildCoinsAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
					}
					awaiter.GetResult();
					result = true;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine("AddGuildCoinsAsync failed: " + _003Cex_003E5__3.Message);
					result = false;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CAddGuildXPAsync_003Ed__37 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string guildId;

		public int xpAmount;

		public string source;

		public GuildRepository _003C_003E4__this;

		private bool _003C_003Es__1;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				TaskAwaiter<bool> awaiter;
				if (num != 0)
				{
					awaiter = _003C_003E4__this.AddGuildXPAsync(guildId, xpAmount).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CAddGuildXPAsync_003Ed__37 _003CAddGuildXPAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CAddGuildXPAsync_003Ed__37>(ref awaiter, ref _003CAddGuildXPAsync_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
				}
				_003C_003Es__1 = awaiter.GetResult();
				result = _003C_003Es__1;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CAddGuildXPAsync_003Ed__44 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string guildId;

		public int xpAmount;

		public GuildRepository _003C_003E4__this;

		private _003C_003Ec__DisplayClass44_0 _003C_003E8__1;

		private _003C_003Ec__DisplayClass44_1 _003C_003E8__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0102: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_010e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if (num != 0)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass44_0();
					_003C_003E8__1.xpAmount = xpAmount;
					_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
					_003C_003E8__1.guildId = guildId;
				}
				try
				{
					TaskAwaiter<bool> awaiter;
					if (num != 0)
					{
						_003C_003E8__2 = new _003C_003Ec__DisplayClass44_1();
						_003C_003E8__2.CS_0024_003C_003E8__locals1 = _003C_003E8__1;
						_003C_003E8__2.guildRef = _003C_003E4__this._firestore.GetCollection("guilds").GetDocument(_003C_003E8__2.CS_0024_003C_003E8__locals1.guildId);
						awaiter = _003C_003E4__this._firestore.RunTransactionAsync<bool>((Func<ITransaction, bool>)delegate(ITransaction transaction)
						{
							IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(_003C_003E8__2.guildRef);
							if (document.Data == null)
							{
								throw new global::System.Exception("Guild not found");
							}
							int currentXP = document.Data.CurrentXP;
							int num2 = document.Data.XPForNextLevel;
							int num3 = document.Data.Level;
							int num4 = currentXP + _003C_003E8__2.CS_0024_003C_003E8__locals1.xpAmount;
							int num5 = 0;
							while (num4 >= num2)
							{
								num4 -= num2;
								num3++;
								num5++;
								num2 = _003C_003E8__2.CS_0024_003C_003E8__locals1._003C_003E4__this.CalculateXPForLevel(num3 + 1);
							}
							transaction.UpdateData(_003C_003E8__2.guildRef, new Dictionary<object, object>
							{
								[(object)"currentXP"] = num4,
								[(object)"level"] = num3,
								[(object)"xpForNextLevel"] = num2,
								[(object)"lastActivityAt"] = global::System.DateTime.UtcNow
							});
							if (num5 > 0)
							{
								IDocumentReference val = _003C_003E8__2.CS_0024_003C_003E8__locals1._003C_003E4__this._firestore.GetCollection("guilds").GetDocument(_003C_003E8__2.CS_0024_003C_003E8__locals1.guildId).GetCollection("activities")
									.CreateDocument();
								transaction.SetData(val, (object)new Dictionary<string, object>
								{
									["type"] = "level_up",
									["message"] = $"Guild reached level {num3}!",
									["icon"] = "⭐",
									["isHighlighted"] = true,
									["timestamp"] = global::System.DateTime.UtcNow
								}, (SetOptions)null);
							}
							return true;
						}).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CAddGuildXPAsync_003Ed__44 _003CAddGuildXPAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CAddGuildXPAsync_003Ed__44>(ref awaiter, ref _003CAddGuildXPAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
					}
					awaiter.GetResult();
					result = true;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine("AddGuildXPAsync failed: " + _003Cex_003E5__3.Message);
					result = false;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CApplyGuildPerkAsync_003Ed__65 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string guildId;

		public string perkKey;

		public int tier;

		public DateTimeOffset activatedAt;

		public string activatedByPlayerId;

		public int crystalCost;

		public GuildRepository _003C_003E4__this;

		private _003C_003Ec__DisplayClass65_0 _003C_003E8__1;

		private _003C_003Ec__DisplayClass65_1 _003C_003E8__2;

		private bool _003C_003Es__3;

		private global::System.Exception _003Cex_003E5__4;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_011a: Unknown result type (might be due to invalid IL or missing references)
			//IL_011f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0126: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if (num != 0)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass65_0();
					_003C_003E8__1.crystalCost = crystalCost;
					_003C_003E8__1.perkKey = perkKey;
					_003C_003E8__1.tier = tier;
					_003C_003E8__1.activatedAt = activatedAt;
					_003C_003E8__1.activatedByPlayerId = activatedByPlayerId;
				}
				try
				{
					TaskAwaiter<bool> awaiter;
					if (num != 0)
					{
						_003C_003E8__2 = new _003C_003Ec__DisplayClass65_1();
						_003C_003E8__2.CS_0024_003C_003E8__locals1 = _003C_003E8__1;
						_003C_003E8__2.guildRef = _003C_003E4__this._firestore.GetCollection("guilds").GetDocument(guildId);
						awaiter = _003C_003E4__this._firestore.RunTransactionAsync<bool>((Func<ITransaction, bool>)delegate(ITransaction transaction)
						{
							//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
							//IL_0120: Unknown result type (might be due to invalid IL or missing references)
							//IL_0045: Unknown result type (might be due to invalid IL or missing references)
							IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(_003C_003E8__2.guildRef);
							if (document.Data == null)
							{
								return false;
							}
							if (document.Data.Crystals < _003C_003E8__2.CS_0024_003C_003E8__locals1.crystalCost)
							{
								throw new InvalidOperationException("Insufficient guild crystals");
							}
							Dictionary<object, object> val = new Dictionary<object, object>
							{
								[(object)"crystals"] = document.Data.Crystals - _003C_003E8__2.CS_0024_003C_003E8__locals1.crystalCost,
								[(object)("activePerks." + _003C_003E8__2.CS_0024_003C_003E8__locals1.perkKey + ".tier")] = _003C_003E8__2.CS_0024_003C_003E8__locals1.tier,
								[(object)("activePerks." + _003C_003E8__2.CS_0024_003C_003E8__locals1.perkKey + ".activatedAt")] = _003C_003E8__2.CS_0024_003C_003E8__locals1.activatedAt,
								[(object)("activePerks." + _003C_003E8__2.CS_0024_003C_003E8__locals1.perkKey + ".activatedByPlayerId")] = _003C_003E8__2.CS_0024_003C_003E8__locals1.activatedByPlayerId,
								[(object)"lastActivityAt"] = DateTimeOffset.UtcNow
							};
							transaction.UpdateData(_003C_003E8__2.guildRef, val);
							return true;
						}).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CApplyGuildPerkAsync_003Ed__65 _003CApplyGuildPerkAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CApplyGuildPerkAsync_003Ed__65>(ref awaiter, ref _003CApplyGuildPerkAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__3 = awaiter.GetResult();
					result = _003C_003Es__3;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__4 = ex;
					Console.WriteLine("ApplyGuildPerkAsync failed: " + _003Cex_003E5__4.Message);
					result = false;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CApproveJoinRequestAsync_003Ed__30 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string guildId;

		public string requestId;

		public string approvedByPlayerId;

		public GuildRepository _003C_003E4__this;

		private IDocumentReference _003CrequestRef_003E5__1;

		private IDocumentSnapshot<FirestoreGuildJoinRequestDTO> _003CrequestDoc_003E5__2;

		private string _003CplayerId_003E5__3;

		private string _003CplayerName_003E5__4;

		private int _003CplayerLevel_003E5__5;

		private IDocumentSnapshot<FirestoreGuildJoinRequestDTO> _003C_003Es__6;

		private bool _003C_003Es__7;

		private global::System.Exception _003Cex_003E5__8;

		private TaskAwaiter<IDocumentSnapshot<FirestoreGuildJoinRequestDTO>> _003C_003Eu__1;

		private TaskAwaiter<bool> _003C_003Eu__2;

		private TaskAwaiter _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01da: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02af: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_0254: Unknown result type (might be due to invalid IL or missing references)
			//IL_0269: Unknown result type (might be due to invalid IL or missing references)
			//IL_026e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0283: Unknown result type (might be due to invalid IL or missing references)
			//IL_0285: Unknown result type (might be due to invalid IL or missing references)
			//IL_019c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if ((uint)num > 2u)
				{
				}
				try
				{
					TaskAwaiter<IDocumentSnapshot<FirestoreGuildJoinRequestDTO>> awaiter3;
					TaskAwaiter<bool> awaiter2;
					TaskAwaiter awaiter;
					switch (num)
					{
					default:
						_003CrequestRef_003E5__1 = _003C_003E4__this._firestore.GetCollection("guilds").GetDocument(guildId).GetCollection("joinRequests")
							.GetDocument(requestId);
						awaiter3 = _003CrequestRef_003E5__1.GetDocumentSnapshotAsync<FirestoreGuildJoinRequestDTO>((Source)0).GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter3;
							_003CApproveJoinRequestAsync_003Ed__30 _003CApproveJoinRequestAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IDocumentSnapshot<FirestoreGuildJoinRequestDTO>>, _003CApproveJoinRequestAsync_003Ed__30>(ref awaiter3, ref _003CApproveJoinRequestAsync_003Ed__);
							return;
						}
						goto IL_00ce;
					case 0:
						awaiter3 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IDocumentSnapshot<FirestoreGuildJoinRequestDTO>>);
						num = (_003C_003E1__state = -1);
						goto IL_00ce;
					case 1:
						awaiter2 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
						goto IL_01f1;
					case 2:
						{
							awaiter = _003C_003Eu__3;
							_003C_003Eu__3 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							break;
						}
						IL_01f1:
						_003C_003Es__7 = awaiter2.GetResult();
						if (_003C_003Es__7)
						{
							awaiter = _003CrequestRef_003E5__1.UpdateDataAsync(new Dictionary<object, object>
							{
								[(object)"status"] = "Approved",
								[(object)"reviewedByPlayerId"] = approvedByPlayerId,
								[(object)"reviewedAt"] = DateTimeOffset.UtcNow
							}).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__3 = awaiter;
								_003CApproveJoinRequestAsync_003Ed__30 _003CApproveJoinRequestAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CApproveJoinRequestAsync_003Ed__30>(ref awaiter, ref _003CApproveJoinRequestAsync_003Ed__);
								return;
							}
							break;
						}
						result = false;
						goto end_IL_0011;
						IL_00ce:
						_003C_003Es__6 = awaiter3.GetResult();
						_003CrequestDoc_003E5__2 = _003C_003Es__6;
						_003C_003Es__6 = null;
						if (_003CrequestDoc_003E5__2.Data != null && !(_003CrequestDoc_003E5__2.Data.Status != "Pending"))
						{
							_003CplayerId_003E5__3 = _003CrequestDoc_003E5__2.Data.PlayerId;
							_003CplayerName_003E5__4 = _003CrequestDoc_003E5__2.Data.PlayerName;
							_003CplayerLevel_003E5__5 = _003CrequestDoc_003E5__2.Data.PlayerLevel;
							awaiter2 = _003C_003E4__this.JoinGuildAsync(_003CplayerId_003E5__3 ?? string.Empty, _003CplayerName_003E5__4 ?? "Unknown", guildId, _003CplayerLevel_003E5__5).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__2 = awaiter2;
								_003CApproveJoinRequestAsync_003Ed__30 _003CApproveJoinRequestAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CApproveJoinRequestAsync_003Ed__30>(ref awaiter2, ref _003CApproveJoinRequestAsync_003Ed__);
								return;
							}
							goto IL_01f1;
						}
						result = false;
						goto end_IL_0011;
					}
					((TaskAwaiter)(ref awaiter)).GetResult();
					result = true;
					end_IL_0011:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__8 = ex;
					Console.WriteLine("ApproveJoinRequestAsync failed: " + _003Cex_003E5__8.Message);
					result = false;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCreateGuildAsync_003Ed__15 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Guild> _003C_003Et__builder;

		public CreateGuildRequest request;

		public Player player;

		public GuildRepository _003C_003E4__this;

		private _003C_003Ec__DisplayClass15_0 _003C_003E8__1;

		private _003C_003Ec__DisplayClass15_1 _003C_003E8__2;

		private string _003CguildId_003E5__3;

		private Guild _003CcreatedGuild_003E5__4;

		private string _003C_003Es__5;

		private global::System.Exception _003Cex_003E5__6;

		private TaskAwaiter<string> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0136: Unknown result type (might be due to invalid IL or missing references)
			//IL_013b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0142: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0224: Unknown result type (might be due to invalid IL or missing references)
			//IL_027c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0366: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0104: Unknown result type (might be due to invalid IL or missing references)
			//IL_0118: Unknown result type (might be due to invalid IL or missing references)
			//IL_0119: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Guild result;
			try
			{
				if (num != 0)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass15_0();
					_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
					_003C_003E8__1.request = request;
					_003C_003E8__1.player = player;
				}
				try
				{
					TaskAwaiter<string> awaiter;
					if (num != 0)
					{
						_003C_003E8__2 = new _003C_003Ec__DisplayClass15_1();
						_003C_003E8__2.CS_0024_003C_003E8__locals1 = _003C_003E8__1;
						_003C_003E8__2.now = DateTimeOffset.UtcNow;
						_003C_003E8__2.playerTrophies = (int)((_003C_003E8__2.CS_0024_003C_003E8__locals1.player.Currencies["reputation"] > 2147483647) ? 2147483647 : _003C_003E8__2.CS_0024_003C_003E8__locals1.player.Currencies["reputation"]);
						awaiter = _003C_003E4__this._firestore.RunTransactionAsync<string>((Func<ITransaction, string>)delegate(ITransaction transaction)
						{
							//IL_0063: Unknown result type (might be due to invalid IL or missing references)
							//IL_0070: Unknown result type (might be due to invalid IL or missing references)
							//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
							//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
							IDocumentReference val = _003C_003E8__2.CS_0024_003C_003E8__locals1._003C_003E4__this._firestore.GetCollection("guilds").CreateDocument();
							FirestoreGuildDTO firestoreGuildDTO = new FirestoreGuildDTO
							{
								ID = val.Id,
								Name = _003C_003E8__2.CS_0024_003C_003E8__locals1.request.GuildName,
								Description = _003C_003E8__2.CS_0024_003C_003E8__locals1.request.Description,
								CreatedAt = _003C_003E8__2.now,
								LastActivityAt = _003C_003E8__2.now,
								LeaderPlayerId = _003C_003E8__2.CS_0024_003C_003E8__locals1.player.PlayerID,
								Emblem = _003C_003E8__2.CS_0024_003C_003E8__locals1.request.Emblem,
								IsPublic = _003C_003E8__2.CS_0024_003C_003E8__locals1.request.IsPublic,
								RequiresApproval = _003C_003E8__2.CS_0024_003C_003E8__locals1.request.RequiresApproval,
								MinLevelRequired = _003C_003E8__2.CS_0024_003C_003E8__locals1.request.MinLevelRequired,
								MinTrophiesRequired = _003C_003E8__2.CS_0024_003C_003E8__locals1.request.MinTrophiesRequired,
								MemberCount = 1,
								Level = 1,
								Rank = 0,
								XPForNextLevel = 500,
								IsOpenToWar = true,
								StartingCrystals = 1000
							};
							transaction.SetData(val, (object)firestoreGuildDTO, (SetOptions)null);
							IDocumentReference document = val.GetCollection("members").GetDocument(_003C_003E8__2.CS_0024_003C_003E8__locals1.player.PlayerID);
							transaction.SetData(document, (object)new FirestoreGuildMemberDTO
							{
								PlayerId = _003C_003E8__2.CS_0024_003C_003E8__locals1.player.PlayerID,
								PlayerName = _003C_003E8__2.CS_0024_003C_003E8__locals1.player.Playername,
								Role = "Guildmaster",
								JoinedAt = _003C_003E8__2.now,
								Contribution = 0,
								IsOnline = true,
								LastActiveAt = _003C_003E8__2.now,
								Trophies = _003C_003E8__2.playerTrophies,
								WeeklyContribution = 0,
								Level = _003C_003E8__2.CS_0024_003C_003E8__locals1.player.PlayerLevel,
								PlayerIcon = _003C_003E8__2.CS_0024_003C_003E8__locals1.player.PlayerIcon
							}, (SetOptions)null);
							return val.Id;
						}).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CCreateGuildAsync_003Ed__15 _003CCreateGuildAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, _003CCreateGuildAsync_003Ed__15>(ref awaiter, ref _003CCreateGuildAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<string>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__5 = awaiter.GetResult();
					_003CguildId_003E5__3 = _003C_003Es__5;
					_003C_003Es__5 = null;
					Guild obj = new Guild
					{
						ID = _003CguildId_003E5__3,
						Name = _003C_003E8__2.CS_0024_003C_003E8__locals1.request.GuildName,
						Description = _003C_003E8__2.CS_0024_003C_003E8__locals1.request.Description
					};
					Dictionary<string, GuildMember> obj2 = new Dictionary<string, GuildMember>();
					obj2.Add(_003C_003E8__2.CS_0024_003C_003E8__locals1.player.PlayerID, new GuildMember
					{
						PlayerId = _003C_003E8__2.CS_0024_003C_003E8__locals1.player.PlayerID,
						PlayerName = _003C_003E8__2.CS_0024_003C_003E8__locals1.player.Playername,
						Role = GuildRole.Guildmaster,
						JoinedAt = _003C_003E8__2.now,
						Contribution = 0,
						Trophies = _003C_003E8__2.playerTrophies,
						Level = _003C_003E8__2.CS_0024_003C_003E8__locals1.player.PlayerLevel,
						WeeklyContribution = 0,
						IsOnline = true,
						LastActiveAt = _003C_003E8__2.now,
						PlayerIcon = _003C_003E8__2.CS_0024_003C_003E8__locals1.player.PlayerIcon
					});
					obj.Members = obj2;
					obj.LeaderPlayerId = _003C_003E8__2.CS_0024_003C_003E8__locals1.player.PlayerID;
					obj.Emblem = _003C_003E8__2.CS_0024_003C_003E8__locals1.request.Emblem;
					obj.IsPublic = _003C_003E8__2.CS_0024_003C_003E8__locals1.request.IsPublic;
					obj.RequiresApproval = _003C_003E8__2.CS_0024_003C_003E8__locals1.request.RequiresApproval;
					obj.MinLevelRequired = _003C_003E8__2.CS_0024_003C_003E8__locals1.request.MinLevelRequired;
					obj.MinTrophiesRequired = _003C_003E8__2.CS_0024_003C_003E8__locals1.request.MinTrophiesRequired;
					obj.MemberCount = 1;
					obj.CreatedAt = _003C_003E8__2.now;
					_003CcreatedGuild_003E5__4 = obj;
					result = _003CcreatedGuild_003E5__4;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__6 = ex;
					Console.WriteLine("Create guild error " + _003Cex_003E5__6.Message);
					Console.WriteLine(_003Cex_003E5__6.StackTrace);
					result = null;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CDeclineInvitationAsync_003Ed__35 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string invitationId;

		public string playerId;

		public GuildRepository _003C_003E4__this;

		private global::System.Exception _003Cex_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this._firestore.GetCollection("players").GetDocument(playerId).GetCollection("notifications")
							.GetDocument(invitationId)
							.UpdateDataAsync(new Dictionary<object, object>
							{
								[(object)"read"] = true,
								[(object)"unansweared"] = false
							})
							.GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CDeclineInvitationAsync_003Ed__35 _003CDeclineInvitationAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CDeclineInvitationAsync_003Ed__35>(ref awaiter, ref _003CDeclineInvitationAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
					}
					((TaskAwaiter)(ref awaiter)).GetResult();
					result = true;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__1 = ex;
					Console.WriteLine("DeclineInvitationAsync failed: " + _003Cex_003E5__1.Message);
					result = false;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CDeleteAsync_003Ed__18 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string guildId;

		public GuildRepository _003C_003E4__this;

		private _003C_003Ec__DisplayClass18_0 _003C_003E8__1;

		private bool _003Cconfirmed_003E5__2;

		private bool _003C_003Es__3;

		private global::System.Exception _003Cex_003E5__4;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if (num != 0)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass18_0();
					_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
					_003C_003E8__1.guildId = guildId;
				}
				try
				{
					TaskAwaiter<bool> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this._firestore.RunTransactionAsync<bool>((Func<ITransaction, bool>)delegate(ITransaction transaction)
						{
							IDocumentReference document = _003C_003E8__1._003C_003E4__this._firestore.GetCollection("guilds").GetDocument(_003C_003E8__1.guildId);
							transaction.DeleteDocument(document);
							return true;
						}).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CDeleteAsync_003Ed__18 _003CDeleteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CDeleteAsync_003Ed__18>(ref awaiter, ref _003CDeleteAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__3 = awaiter.GetResult();
					_003Cconfirmed_003E5__2 = _003C_003Es__3;
					result = _003Cconfirmed_003E5__2;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__4 = ex;
					Console.WriteLine("DeleteGuildAsync failed: " + _003Cex_003E5__4.Message);
					result = false;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CDemoteMemberAsync_003Ed__23 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string guildId;

		public string targetPlayerId;

		public GuildRole newRole;

		public GuildRepository _003C_003E4__this;

		private _003C_003Ec__DisplayClass23_0 _003C_003E8__1;

		private IDocumentReference _003CplayerRef_003E5__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter<object> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0131: Unknown result type (might be due to invalid IL or missing references)
			//IL_0136: Unknown result type (might be due to invalid IL or missing references)
			//IL_013d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0232: Unknown result type (might be due to invalid IL or missing references)
			//IL_0237: Unknown result type (might be due to invalid IL or missing references)
			//IL_023f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0113: Unknown result type (might be due to invalid IL or missing references)
			//IL_0114: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0213: Unknown result type (might be due to invalid IL or missing references)
			//IL_0215: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if ((uint)num > 1u)
				{
				}
				try
				{
					TaskAwaiter awaiter;
					TaskAwaiter<object> awaiter2;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_024e;
						}
						_003C_003E8__1 = new _003C_003Ec__DisplayClass23_0();
						_003C_003E8__1.guildRef = _003C_003E4__this._firestore.GetCollection("guilds").GetDocument(guildId);
						_003CplayerRef_003E5__2 = _003C_003E4__this._firestore.GetCollection("players").GetDocument(targetPlayerId);
						_003C_003E8__1.memberRef = _003C_003E4__this.GetMemberRef(guildId, targetPlayerId);
						_003C_003E8__1.oldRole = null;
						_003C_003E8__1.newRoleStr = ((object)newRole).ToString();
						_003C_003E8__1.guildName = null;
						awaiter2 = _003C_003E4__this._firestore.RunTransactionAsync<object>((Func<ITransaction, object>)delegate(ITransaction transaction)
						{
							//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
							IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(_003C_003E8__1.guildRef);
							if (document.Data == null)
							{
								throw new global::System.Exception("Guild not found");
							}
							_003C_003E8__1.guildName = document.Data.Name;
							IDocumentSnapshot<FirestoreGuildMemberDTO> document2 = transaction.GetDocument<FirestoreGuildMemberDTO>(_003C_003E8__1.memberRef);
							if (document2.Data == null)
							{
								throw new global::System.Exception("Member not found");
							}
							_003C_003E8__1.oldRole = document2.Data.Role;
							transaction.UpdateData(_003C_003E8__1.memberRef, new Dictionary<object, object> { [(object)"role"] = _003C_003E8__1.newRoleStr });
							transaction.UpdateData(_003C_003E8__1.guildRef, new Dictionary<object, object> { [(object)"lastActivityAt"] = DateTimeOffset.UtcNow });
							return true;
						}).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CDemoteMemberAsync_003Ed__23 _003CDemoteMemberAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<object>, _003CDemoteMemberAsync_003Ed__23>(ref awaiter2, ref _003CDemoteMemberAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<object>);
						num = (_003C_003E1__state = -1);
					}
					awaiter2.GetResult();
					if (_003C_003E4__this._userSession.CurrentPlayerId != targetPlayerId)
					{
						awaiter = _003C_003E4__this.SendNotificationToPlayerAsync(targetPlayerId, NotificationType.GuildDemoted, new Dictionary<string, object>
						{
							["guildId"] = guildId,
							["guildName"] = _003C_003E8__1.guildName ?? "Unknown Guild",
							["newRole"] = _003C_003E8__1.newRoleStr,
							["oldRole"] = _003C_003E8__1.oldRole ?? "member"
						}).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter;
							_003CDemoteMemberAsync_003Ed__23 _003CDemoteMemberAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CDemoteMemberAsync_003Ed__23>(ref awaiter, ref _003CDemoteMemberAsync_003Ed__);
							return;
						}
						goto IL_024e;
					}
					goto IL_0257;
					IL_024e:
					((TaskAwaiter)(ref awaiter)).GetResult();
					goto IL_0257;
					IL_0257:
					result = true;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine("DemoteMemberAsync failed: " + _003Cex_003E5__3.Message);
					result = false;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetAvailableDefendersAsync_003Ed__58 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<List<string>> _003C_003Et__builder;

		public string attackingGuildId;

		public string defendingGuildId;

		public string warId;

		public GuildRepository _003C_003E4__this;

		private Guild _003CdefendingGuild_003E5__1;

		private Guild _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter<Guild?> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			List<string> result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<Guild> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this.GetByIdAsync(defendingGuildId).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CGetAvailableDefendersAsync_003Ed__58 _003CGetAvailableDefendersAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Guild>, _003CGetAvailableDefendersAsync_003Ed__58>(ref awaiter, ref _003CGetAvailableDefendersAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Guild>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003CdefendingGuild_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					result = (List<string>)((_003CdefendingGuild_003E5__1 == null) ? new List<string>() : ((!_003CdefendingGuild_003E5__1.IsInGuildBreak) ? ((object)_003CdefendingGuild_003E5__1.GetAvailableDefenderIds()) : ((object)new List<string>())));
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine("GetAvailableDefendersAsync failed: " + _003Cex_003E5__3.Message);
					result = new List<string>();
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetByIdAsync_003Ed__14 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Guild> _003C_003Et__builder;

		public string guildId;

		public GuildRepository _003C_003E4__this;

		private IDocumentSnapshot<FirestoreGuildDTO> _003Cdoc_003E5__1;

		private FirestoreGuildDTO _003CfirestoreGuild_003E5__2;

		private IDocumentSnapshot<FirestoreGuildDTO> _003C_003Es__3;

		private TaskAwaiter<IDocumentSnapshot<FirestoreGuildDTO>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Guild result;
			try
			{
				TaskAwaiter<IDocumentSnapshot<FirestoreGuildDTO>> awaiter;
				if (num != 0)
				{
					awaiter = _003C_003E4__this._firestore.GetCollection("guilds").GetDocument(guildId).GetDocumentSnapshotAsync<FirestoreGuildDTO>((Source)0)
						.GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CGetByIdAsync_003Ed__14 _003CGetByIdAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IDocumentSnapshot<FirestoreGuildDTO>>, _003CGetByIdAsync_003Ed__14>(ref awaiter, ref _003CGetByIdAsync_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<IDocumentSnapshot<FirestoreGuildDTO>>);
					num = (_003C_003E1__state = -1);
				}
				_003C_003Es__3 = awaiter.GetResult();
				_003Cdoc_003E5__1 = _003C_003Es__3;
				_003C_003Es__3 = null;
				_003CfirestoreGuild_003E5__2 = _003Cdoc_003E5__1.Data;
				result = ((_003CfirestoreGuild_003E5__2 != null) ? GuildEntityMapper.ToEntity(_003CfirestoreGuild_003E5__2) : null);
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cdoc_003E5__1 = null;
				_003CfirestoreGuild_003E5__2 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cdoc_003E5__1 = null;
			_003CfirestoreGuild_003E5__2 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetDefendersAsync_003Ed__49 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<List<GuildMember>> _003C_003Et__builder;

		public string guildId;

		public GuildRepository _003C_003E4__this;

		private _003C_003Ec__DisplayClass49_0 _003C_003E8__1;

		private Guild _003Cguild_003E5__2;

		private global::System.Collections.Generic.IEnumerable<global::System.Threading.Tasks.Task<GuildMember>> _003Ctasks_003E5__3;

		private GuildMember[] _003Cresults_003E5__4;

		private Guild _003C_003Es__5;

		private GuildMember[] _003C_003Es__6;

		private global::System.Exception _003Cex_003E5__7;

		private TaskAwaiter<Guild?> _003C_003Eu__1;

		private TaskAwaiter<GuildMember[]> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0180: Unknown result type (might be due to invalid IL or missing references)
			//IL_0185: Unknown result type (might be due to invalid IL or missing references)
			//IL_018d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0147: Unknown result type (might be due to invalid IL or missing references)
			//IL_014c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0161: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			List<GuildMember> result;
			try
			{
				if ((uint)num > 1u)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass49_0();
					_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
					_003C_003E8__1.guildId = guildId;
				}
				try
				{
					TaskAwaiter<GuildMember[]> awaiter;
					TaskAwaiter<Guild> awaiter2;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<GuildMember[]>);
							num = (_003C_003E1__state = -1);
							goto IL_019c;
						}
						awaiter2 = _003C_003E4__this.GetByIdAsync(_003C_003E8__1.guildId).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CGetDefendersAsync_003Ed__49 _003CGetDefendersAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Guild>, _003CGetDefendersAsync_003Ed__49>(ref awaiter2, ref _003CGetDefendersAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Guild>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__5 = awaiter2.GetResult();
					_003Cguild_003E5__2 = _003C_003Es__5;
					_003C_003Es__5 = null;
					if (_003Cguild_003E5__2 != null && _003Cguild_003E5__2.DefenderPlayerIds != null && ((global::System.Collections.Generic.IReadOnlyCollection<string>)_003Cguild_003E5__2.DefenderPlayerIds).Count != 0)
					{
						_003Ctasks_003E5__3 = Enumerable.Select<string, global::System.Threading.Tasks.Task<GuildMember>>((global::System.Collections.Generic.IEnumerable<string>)_003Cguild_003E5__2.DefenderPlayerIds, (Func<string, global::System.Threading.Tasks.Task<GuildMember>>)((string id) => _003C_003E8__1._003C_003E4__this.GetMemberAsync(_003C_003E8__1.guildId, id)));
						awaiter = global::System.Threading.Tasks.Task.WhenAll<GuildMember>(_003Ctasks_003E5__3).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter;
							_003CGetDefendersAsync_003Ed__49 _003CGetDefendersAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<GuildMember[]>, _003CGetDefendersAsync_003Ed__49>(ref awaiter, ref _003CGetDefendersAsync_003Ed__);
							return;
						}
						goto IL_019c;
					}
					result = new List<GuildMember>();
					goto end_IL_003e;
					IL_019c:
					_003C_003Es__6 = awaiter.GetResult();
					_003Cresults_003E5__4 = _003C_003Es__6;
					_003C_003Es__6 = null;
					result = Enumerable.ToList<GuildMember>(Enumerable.Cast<GuildMember>((global::System.Collections.IEnumerable)Enumerable.Where<GuildMember>((global::System.Collections.Generic.IEnumerable<GuildMember>)_003Cresults_003E5__4, (Func<GuildMember, bool>)((GuildMember m) => m != null))));
					end_IL_003e:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__7 = ex;
					Console.WriteLine("GetDefendersAsync failed: " + _003Cex_003E5__7.Message);
					result = new List<GuildMember>();
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetGuildCrystalsAsync_003Ed__52 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<int> _003C_003Et__builder;

		public string guildId;

		public GuildRepository _003C_003E4__this;

		private Guild _003Cguild_003E5__1;

		private Guild _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter<Guild?> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			int result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<Guild> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this.GetByIdAsync(guildId).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CGetGuildCrystalsAsync_003Ed__52 _003CGetGuildCrystalsAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Guild>, _003CGetGuildCrystalsAsync_003Ed__52>(ref awaiter, ref _003CGetGuildCrystalsAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Guild>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Cguild_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					result = _003Cguild_003E5__1?.Crystals ?? 0;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine("GetGuildCrystalsAsync failed: " + _003Cex_003E5__3.Message);
					result = 0;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetGuildMembersAsync_003Ed__25 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Dictionary<string, GuildMember>> _003C_003Et__builder;

		public string guildId;

		public GuildRepository _003C_003E4__this;

		private Dictionary<string, GuildMember> _003C_003Es__1;

		private global::System.Exception _003Cex_003E5__2;

		private TaskAwaiter<Dictionary<string, GuildMember>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Dictionary<string, GuildMember> result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<Dictionary<string, GuildMember>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this.GetMembersFromSubcollectionAsync(guildId).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CGetGuildMembersAsync_003Ed__25 _003CGetGuildMembersAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Dictionary<string, GuildMember>>, _003CGetGuildMembersAsync_003Ed__25>(ref awaiter, ref _003CGetGuildMembersAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Dictionary<string, GuildMember>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__1 = awaiter.GetResult();
					result = _003C_003Es__1;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__2 = ex;
					Console.WriteLine("GetGuildMembersAsync failed: " + _003Cex_003E5__2.Message);
					result = new Dictionary<string, GuildMember>();
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetGuildWarHistoryAsync_003Ed__43 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<List<GuildWarHistory>> _003C_003Et__builder;

		public string guildId;

		public int limit;

		public GuildRepository _003C_003E4__this;

		private IQuerySnapshot<FirestoreGuildWarHistoryDTO> _003Csnapshot_003E5__1;

		private List<GuildWarHistory> _003Cwars_003E5__2;

		private IQuerySnapshot<FirestoreGuildWarHistoryDTO> _003C_003Es__3;

		private global::System.Exception _003Cex_003E5__4;

		private TaskAwaiter<IQuerySnapshot<FirestoreGuildWarHistoryDTO>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			List<GuildWarHistory> result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<IQuerySnapshot<FirestoreGuildWarHistoryDTO>> awaiter;
					if (num != 0)
					{
						awaiter = ((IQuery)_003C_003E4__this._firestore.GetCollection("guilds").GetDocument(guildId).GetCollection("warHistory")).GetDocumentsAsync<FirestoreGuildWarHistoryDTO>((Source)0).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CGetGuildWarHistoryAsync_003Ed__43 _003CGetGuildWarHistoryAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IQuerySnapshot<FirestoreGuildWarHistoryDTO>>, _003CGetGuildWarHistoryAsync_003Ed__43>(ref awaiter, ref _003CGetGuildWarHistoryAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IQuerySnapshot<FirestoreGuildWarHistoryDTO>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__3 = awaiter.GetResult();
					_003Csnapshot_003E5__1 = _003C_003Es__3;
					_003C_003Es__3 = null;
					_003Cwars_003E5__2 = Enumerable.ToList<GuildWarHistory>(Enumerable.Select<FirestoreGuildWarHistoryDTO, GuildWarHistory>(Enumerable.Take<FirestoreGuildWarHistoryDTO>((global::System.Collections.Generic.IEnumerable<FirestoreGuildWarHistoryDTO>)Enumerable.OrderByDescending<FirestoreGuildWarHistoryDTO, DateTimeOffset>(Enumerable.Where<FirestoreGuildWarHistoryDTO>(Enumerable.Select<IDocumentSnapshot<FirestoreGuildWarHistoryDTO>, FirestoreGuildWarHistoryDTO>(_003Csnapshot_003E5__1.Documents, (Func<IDocumentSnapshot<FirestoreGuildWarHistoryDTO>, FirestoreGuildWarHistoryDTO>)((IDocumentSnapshot<FirestoreGuildWarHistoryDTO> d) => d.Data)), (Func<FirestoreGuildWarHistoryDTO, bool>)((FirestoreGuildWarHistoryDTO w) => w != null)), (Func<FirestoreGuildWarHistoryDTO, DateTimeOffset>)((FirestoreGuildWarHistoryDTO w) => w.Timestamp)), limit), (Func<FirestoreGuildWarHistoryDTO, GuildWarHistory>)((FirestoreGuildWarHistoryDTO dto) => new GuildWarHistory
					{
						ID = (dto.ID ?? string.Empty),
						SeasonId = (dto.SeasonId ?? string.Empty),
						OpponentGuildId = (dto.OpponentGuildId ?? string.Empty),
						OpponentGuildName = (dto.OpponentGuildName ?? "Unknown"),
						Result = global::System.Enum.Parse<GuildWarResult>(dto.Result ?? "Defending", true),
						TrophiesGained = dto.TrophiesGained,
						TrophiesLost = dto.TrophiesLost,
						Timestamp = dto.Timestamp,
						CrystalsStolen = dto.CrystalsStolen,
						CrystalsLost = dto.CrystalsLost,
						Wins = dto.Wins,
						Losses = dto.Losses,
						ActiveMemberCount = dto.ActiveMemberCount,
						AttackMVP = dto.AttackMVP,
						DefenseMVP = dto.DefenseMVP,
						WarMVP = dto.WarMVP,
						ContributionScores = (dto.ContributionScores ?? new Dictionary<string, double>())
					})));
					result = _003Cwars_003E5__2;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__4 = ex;
					Console.WriteLine("GetGuildWarHistoryAsync failed: " + _003Cex_003E5__4.Message);
					Console.WriteLine("GetGuildWarHistoryAsync failed: " + _003Cex_003E5__4.StackTrace);
					result = new List<GuildWarHistory>();
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetMainDefendersAsync_003Ed__51 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<List<GuildMember>> _003C_003Et__builder;

		public string guildId;

		public GuildRepository _003C_003E4__this;

		private _003C_003Ec__DisplayClass51_0 _003C_003E8__1;

		private Guild _003Cguild_003E5__2;

		private global::System.Collections.Generic.IEnumerable<global::System.Threading.Tasks.Task<GuildMember>> _003Ctasks_003E5__3;

		private GuildMember[] _003Cresults_003E5__4;

		private Guild _003C_003Es__5;

		private GuildMember[] _003C_003Es__6;

		private global::System.Exception _003Cex_003E5__7;

		private TaskAwaiter<Guild?> _003C_003Eu__1;

		private TaskAwaiter<GuildMember[]> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0180: Unknown result type (might be due to invalid IL or missing references)
			//IL_0185: Unknown result type (might be due to invalid IL or missing references)
			//IL_018d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0147: Unknown result type (might be due to invalid IL or missing references)
			//IL_014c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0161: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			List<GuildMember> result;
			try
			{
				if ((uint)num > 1u)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass51_0();
					_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
					_003C_003E8__1.guildId = guildId;
				}
				try
				{
					TaskAwaiter<GuildMember[]> awaiter;
					TaskAwaiter<Guild> awaiter2;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<GuildMember[]>);
							num = (_003C_003E1__state = -1);
							goto IL_019c;
						}
						awaiter2 = _003C_003E4__this.GetByIdAsync(_003C_003E8__1.guildId).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CGetMainDefendersAsync_003Ed__51 _003CGetMainDefendersAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Guild>, _003CGetMainDefendersAsync_003Ed__51>(ref awaiter2, ref _003CGetMainDefendersAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Guild>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__5 = awaiter2.GetResult();
					_003Cguild_003E5__2 = _003C_003Es__5;
					_003C_003Es__5 = null;
					if (_003Cguild_003E5__2 != null && _003Cguild_003E5__2.MainDefenderPlayerIds != null && ((global::System.Collections.Generic.IReadOnlyCollection<string>)_003Cguild_003E5__2.MainDefenderPlayerIds).Count != 0)
					{
						_003Ctasks_003E5__3 = Enumerable.Select<string, global::System.Threading.Tasks.Task<GuildMember>>((global::System.Collections.Generic.IEnumerable<string>)_003Cguild_003E5__2.MainDefenderPlayerIds, (Func<string, global::System.Threading.Tasks.Task<GuildMember>>)((string id) => _003C_003E8__1._003C_003E4__this.GetMemberAsync(_003C_003E8__1.guildId, id)));
						awaiter = global::System.Threading.Tasks.Task.WhenAll<GuildMember>(_003Ctasks_003E5__3).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter;
							_003CGetMainDefendersAsync_003Ed__51 _003CGetMainDefendersAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<GuildMember[]>, _003CGetMainDefendersAsync_003Ed__51>(ref awaiter, ref _003CGetMainDefendersAsync_003Ed__);
							return;
						}
						goto IL_019c;
					}
					result = new List<GuildMember>();
					goto end_IL_003e;
					IL_019c:
					_003C_003Es__6 = awaiter.GetResult();
					_003Cresults_003E5__4 = _003C_003Es__6;
					_003C_003Es__6 = null;
					result = Enumerable.ToList<GuildMember>(Enumerable.Cast<GuildMember>((global::System.Collections.IEnumerable)Enumerable.Where<GuildMember>((global::System.Collections.Generic.IEnumerable<GuildMember>)_003Cresults_003E5__4, (Func<GuildMember, bool>)((GuildMember m) => m != null))));
					end_IL_003e:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__7 = ex;
					Console.WriteLine("GetMainDefendersAsync failed: " + _003Cex_003E5__7.Message);
					result = new List<GuildMember>();
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetMemberAsync_003Ed__12 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<GuildMember> _003C_003Et__builder;

		public string guildId;

		public string playerId;

		public GuildRepository _003C_003E4__this;

		private IDocumentSnapshot<FirestoreGuildMemberDTO> _003Cdoc_003E5__1;

		private IDocumentSnapshot<FirestoreGuildMemberDTO> _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter<IDocumentSnapshot<FirestoreGuildMemberDTO>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			GuildMember result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<IDocumentSnapshot<FirestoreGuildMemberDTO>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this.GetMemberRef(guildId, playerId).GetDocumentSnapshotAsync<FirestoreGuildMemberDTO>((Source)0).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CGetMemberAsync_003Ed__12 _003CGetMemberAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IDocumentSnapshot<FirestoreGuildMemberDTO>>, _003CGetMemberAsync_003Ed__12>(ref awaiter, ref _003CGetMemberAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IDocumentSnapshot<FirestoreGuildMemberDTO>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Cdoc_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					result = ((_003Cdoc_003E5__1.Data != null) ? GuildMemberEntityMapper.ToEntity(_003Cdoc_003E5__1.Data) : null);
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine("GetMemberAsync failed: " + _003Cex_003E5__3.Message);
					result = null;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetMembersFromSubcollectionAsync_003Ed__13 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Dictionary<string, GuildMember>> _003C_003Et__builder;

		public string guildId;

		public GuildRepository _003C_003E4__this;

		private IQuerySnapshot<FirestoreGuildMemberDTO> _003Csnapshot_003E5__1;

		private Dictionary<string, GuildMember> _003Cresult_003E5__2;

		private IQuerySnapshot<FirestoreGuildMemberDTO> _003C_003Es__3;

		private global::System.Collections.Generic.IEnumerator<IDocumentSnapshot<FirestoreGuildMemberDTO>> _003C_003Es__4;

		private IDocumentSnapshot<FirestoreGuildMemberDTO> _003Cdoc_003E5__5;

		private string _003CmemberId_003E5__6;

		private TaskAwaiter<IQuerySnapshot<FirestoreGuildMemberDTO>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Dictionary<string, GuildMember> result;
			try
			{
				TaskAwaiter<IQuerySnapshot<FirestoreGuildMemberDTO>> awaiter;
				if (num != 0)
				{
					awaiter = ((IQuery)_003C_003E4__this._firestore.GetCollection("guilds").GetDocument(guildId).GetCollection("members")).GetDocumentsAsync<FirestoreGuildMemberDTO>((Source)0).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CGetMembersFromSubcollectionAsync_003Ed__13 _003CGetMembersFromSubcollectionAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IQuerySnapshot<FirestoreGuildMemberDTO>>, _003CGetMembersFromSubcollectionAsync_003Ed__13>(ref awaiter, ref _003CGetMembersFromSubcollectionAsync_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<IQuerySnapshot<FirestoreGuildMemberDTO>>);
					num = (_003C_003E1__state = -1);
				}
				_003C_003Es__3 = awaiter.GetResult();
				_003Csnapshot_003E5__1 = _003C_003Es__3;
				_003C_003Es__3 = null;
				FirestoreReadCounter.Track("GetGuildMembers", Enumerable.Count<IDocumentSnapshot<FirestoreGuildMemberDTO>>(_003Csnapshot_003E5__1.Documents));
				_003Cresult_003E5__2 = new Dictionary<string, GuildMember>();
				_003C_003Es__4 = _003Csnapshot_003E5__1.Documents.GetEnumerator();
				try
				{
					while (((global::System.Collections.IEnumerator)_003C_003Es__4).MoveNext())
					{
						_003Cdoc_003E5__5 = _003C_003Es__4.Current;
						if (_003Cdoc_003E5__5.Data != null)
						{
							_003CmemberId_003E5__6 = _003Cdoc_003E5__5.Data.PlayerId ?? _003Cdoc_003E5__5.Reference.Id;
							_003Cresult_003E5__2[_003CmemberId_003E5__6] = GuildMemberEntityMapper.ToEntity(_003Cdoc_003E5__5.Data);
							_003CmemberId_003E5__6 = null;
						}
						_003Cdoc_003E5__5 = null;
					}
				}
				finally
				{
					if (num < 0 && _003C_003Es__4 != null)
					{
						((global::System.IDisposable)_003C_003Es__4).Dispose();
					}
				}
				_003C_003Es__4 = null;
				result = _003Cresult_003E5__2;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Csnapshot_003E5__1 = null;
				_003Cresult_003E5__2 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Csnapshot_003E5__1 = null;
			_003Cresult_003E5__2 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetNextDefenderAsync_003Ed__59 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<GuildMember> _003C_003Et__builder;

		public string attackingGuildId;

		public string defendingGuildId;

		public string warId;

		public GuildRepository _003C_003E4__this;

		private _003C_003Ec__DisplayClass59_0 _003C_003E8__1;

		private Guild _003CdefendingGuild_003E5__2;

		private Random _003Crandom_003E5__3;

		private string _003CselectedDefenderId_003E5__4;

		private List<string> _003CactiveMainDefenderIds_003E5__5;

		private Guild _003C_003Es__6;

		private List<string> _003C_003Es__7;

		private GuildMember _003C_003Es__8;

		private global::System.Exception _003Cex_003E5__9;

		private TaskAwaiter<Guild?> _003C_003Eu__1;

		private TaskAwaiter<List<string>> _003C_003Eu__2;

		private TaskAwaiter<GuildMember?> _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_012c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0131: Unknown result type (might be due to invalid IL or missing references)
			//IL_0139: Unknown result type (might be due to invalid IL or missing references)
			//IL_0283: Unknown result type (might be due to invalid IL or missing references)
			//IL_0288: Unknown result type (might be due to invalid IL or missing references)
			//IL_0290: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_018e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0198: Expected O, but got Unknown
			//IL_010d: Unknown result type (might be due to invalid IL or missing references)
			//IL_010f: Unknown result type (might be due to invalid IL or missing references)
			//IL_024a: Unknown result type (might be due to invalid IL or missing references)
			//IL_024f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0264: Unknown result type (might be due to invalid IL or missing references)
			//IL_0266: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			GuildMember result;
			try
			{
				if ((uint)num > 2u)
				{
				}
				try
				{
					TaskAwaiter<Guild> awaiter3;
					TaskAwaiter<List<string>> awaiter2;
					TaskAwaiter<GuildMember> awaiter;
					switch (num)
					{
					default:
						_003C_003E8__1 = new _003C_003Ec__DisplayClass59_0();
						awaiter3 = _003C_003E4__this.GetByIdAsync(defendingGuildId).GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter3;
							_003CGetNextDefenderAsync_003Ed__59 _003CGetNextDefenderAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Guild>, _003CGetNextDefenderAsync_003Ed__59>(ref awaiter3, ref _003CGetNextDefenderAsync_003Ed__);
							return;
						}
						goto IL_00a0;
					case 0:
						awaiter3 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Guild>);
						num = (_003C_003E1__state = -1);
						goto IL_00a0;
					case 1:
						awaiter2 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<List<string>>);
						num = (_003C_003E1__state = -1);
						goto IL_0148;
					case 2:
						{
							awaiter = _003C_003Eu__3;
							_003C_003Eu__3 = default(TaskAwaiter<GuildMember>);
							num = (_003C_003E1__state = -1);
							break;
						}
						IL_0148:
						_003C_003Es__7 = awaiter2.GetResult();
						_003C_003E8__1.availableDefenderIds = _003C_003Es__7;
						_003C_003Es__7 = null;
						if (Enumerable.Any<string>((global::System.Collections.Generic.IEnumerable<string>)_003C_003E8__1.availableDefenderIds))
						{
							_003Crandom_003E5__3 = new Random();
							_003CactiveMainDefenderIds_003E5__5 = Enumerable.ToList<string>(Enumerable.Where<string>((global::System.Collections.Generic.IEnumerable<string>)_003CdefendingGuild_003E5__2.MainDefenderPlayerIds, (Func<string, bool>)((string id) => _003C_003E8__1.availableDefenderIds.Contains(id))));
							if (Enumerable.Any<string>((global::System.Collections.Generic.IEnumerable<string>)_003CactiveMainDefenderIds_003E5__5))
							{
								_003CselectedDefenderId_003E5__4 = _003CactiveMainDefenderIds_003E5__5[_003Crandom_003E5__3.Next(_003CactiveMainDefenderIds_003E5__5.Count)];
							}
							else
							{
								_003CselectedDefenderId_003E5__4 = _003C_003E8__1.availableDefenderIds[_003Crandom_003E5__3.Next(_003C_003E8__1.availableDefenderIds.Count)];
							}
							awaiter = _003C_003E4__this.GetMemberAsync(defendingGuildId, _003CselectedDefenderId_003E5__4).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__3 = awaiter;
								_003CGetNextDefenderAsync_003Ed__59 _003CGetNextDefenderAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<GuildMember>, _003CGetNextDefenderAsync_003Ed__59>(ref awaiter, ref _003CGetNextDefenderAsync_003Ed__);
								return;
							}
							break;
						}
						result = null;
						goto end_IL_0011;
						IL_00a0:
						_003C_003Es__6 = awaiter3.GetResult();
						_003CdefendingGuild_003E5__2 = _003C_003Es__6;
						_003C_003Es__6 = null;
						if (_003CdefendingGuild_003E5__2 != null)
						{
							awaiter2 = _003C_003E4__this.GetAvailableDefendersAsync(attackingGuildId, defendingGuildId, warId).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__2 = awaiter2;
								_003CGetNextDefenderAsync_003Ed__59 _003CGetNextDefenderAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<List<string>>, _003CGetNextDefenderAsync_003Ed__59>(ref awaiter2, ref _003CGetNextDefenderAsync_003Ed__);
								return;
							}
							goto IL_0148;
						}
						result = null;
						goto end_IL_0011;
					}
					_003C_003Es__8 = awaiter.GetResult();
					result = _003C_003Es__8;
					end_IL_0011:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__9 = ex;
					Console.WriteLine("GetNextDefenderAsync failed: " + _003Cex_003E5__9.Message);
					result = null;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetPendingJoinRequestsAsync_003Ed__32 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<List<GuildJoinRequest>> _003C_003Et__builder;

		public string guildId;

		public GuildRepository _003C_003E4__this;

		private IQuerySnapshot<FirestoreGuildJoinRequestDTO> _003Csnapshot_003E5__1;

		private List<GuildJoinRequest> _003Crequests_003E5__2;

		private IQuerySnapshot<FirestoreGuildJoinRequestDTO> _003C_003Es__3;

		private global::System.Exception _003Cex_003E5__4;

		private TaskAwaiter<IQuerySnapshot<FirestoreGuildJoinRequestDTO>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			List<GuildJoinRequest> result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<IQuerySnapshot<FirestoreGuildJoinRequestDTO>> awaiter;
					if (num != 0)
					{
						awaiter = ((IQuery)_003C_003E4__this._firestore.GetCollection("guilds").GetDocument(guildId).GetCollection("joinRequests")).GetDocumentsAsync<FirestoreGuildJoinRequestDTO>((Source)0).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CGetPendingJoinRequestsAsync_003Ed__32 _003CGetPendingJoinRequestsAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IQuerySnapshot<FirestoreGuildJoinRequestDTO>>, _003CGetPendingJoinRequestsAsync_003Ed__32>(ref awaiter, ref _003CGetPendingJoinRequestsAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IQuerySnapshot<FirestoreGuildJoinRequestDTO>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__3 = awaiter.GetResult();
					_003Csnapshot_003E5__1 = _003C_003Es__3;
					_003C_003Es__3 = null;
					_003Crequests_003E5__2 = Enumerable.ToList<GuildJoinRequest>(Enumerable.Select<FirestoreGuildJoinRequestDTO, GuildJoinRequest>(Enumerable.DistinctBy<FirestoreGuildJoinRequestDTO, string>(Enumerable.Where<FirestoreGuildJoinRequestDTO>(Enumerable.Select<IDocumentSnapshot<FirestoreGuildJoinRequestDTO>, FirestoreGuildJoinRequestDTO>(_003Csnapshot_003E5__1.Documents, (Func<IDocumentSnapshot<FirestoreGuildJoinRequestDTO>, FirestoreGuildJoinRequestDTO>)((IDocumentSnapshot<FirestoreGuildJoinRequestDTO> d) => d.Data)), (Func<FirestoreGuildJoinRequestDTO, bool>)((FirestoreGuildJoinRequestDTO r) => r != null && r.Status == "Pending")), (Func<FirestoreGuildJoinRequestDTO, string>)((FirestoreGuildJoinRequestDTO data) => data.PlayerId)), (Func<FirestoreGuildJoinRequestDTO, GuildJoinRequest>)((FirestoreGuildJoinRequestDTO dto) => new GuildJoinRequest
					{
						ID = (dto.ID ?? string.Empty),
						PlayerId = (dto.PlayerId ?? string.Empty),
						PlayerName = (dto.PlayerName ?? "Unknown"),
						PlayerLevel = dto.PlayerLevel,
						PlayerTrophies = dto.PlayerTrophies,
						Message = (dto.Message ?? string.Empty),
						Status = global::System.Enum.Parse<JoinRequestStatus>(dto.Status ?? "Pending", true),
						CreatedAt = dto.CreatedAt,
						ReviewedByPlayerId = dto.ReviewedByPlayerId,
						ReviewedAt = dto.ReviewedAt
					})));
					result = _003Crequests_003E5__2;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__4 = ex;
					Console.WriteLine("GetPendingJoinRequestsAsync failed: " + _003Cex_003E5__4.Message);
					result = new List<GuildJoinRequest>();
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetPlayerInvitationsAsync_003Ed__36 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<List<GuildInvitation>> _003C_003Et__builder;

		public string playerId;

		public GuildRepository _003C_003E4__this;

		private _003C_003Ec__DisplayClass36_0 _003C_003E8__1;

		private _003C_003Ec__DisplayClass36_1 _003C_003E8__2;

		private IQuerySnapshot<FirestorePlayerNotificationDTO> _003Csnapshot_003E5__3;

		private List<GuildInvitation> _003Cinvitations_003E5__4;

		private IQuerySnapshot<FirestorePlayerNotificationDTO> _003C_003Es__5;

		private global::System.Exception _003Cex_003E5__6;

		private TaskAwaiter<IQuerySnapshot<FirestorePlayerNotificationDTO>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			List<GuildInvitation> result;
			try
			{
				if (num != 0)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass36_0();
					_003C_003E8__1.playerId = playerId;
				}
				try
				{
					TaskAwaiter<IQuerySnapshot<FirestorePlayerNotificationDTO>> awaiter;
					if (num != 0)
					{
						_003C_003E8__2 = new _003C_003Ec__DisplayClass36_1();
						awaiter = ((IQuery)_003C_003E4__this._firestore.GetCollection("players").GetDocument(_003C_003E8__1.playerId).GetCollection("notifications")).OrderBy("createdAt", true).LimitedTo(50).GetDocumentsAsync<FirestorePlayerNotificationDTO>((Source)0)
							.GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CGetPlayerInvitationsAsync_003Ed__36 _003CGetPlayerInvitationsAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IQuerySnapshot<FirestorePlayerNotificationDTO>>, _003CGetPlayerInvitationsAsync_003Ed__36>(ref awaiter, ref _003CGetPlayerInvitationsAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IQuerySnapshot<FirestorePlayerNotificationDTO>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__5 = awaiter.GetResult();
					_003Csnapshot_003E5__3 = _003C_003Es__5;
					_003C_003Es__5 = null;
					_003C_003E8__2.invitationType = ((object)NotificationType.GuildInvitation).ToString();
					_003Cinvitations_003E5__4 = Enumerable.ToList<GuildInvitation>(Enumerable.Where<GuildInvitation>(Enumerable.Select<FirestorePlayerNotificationDTO, GuildInvitation>(Enumerable.DistinctBy<FirestorePlayerNotificationDTO, object>(Enumerable.Where<FirestorePlayerNotificationDTO>(Enumerable.Select<IDocumentSnapshot<FirestorePlayerNotificationDTO>, FirestorePlayerNotificationDTO>(_003Csnapshot_003E5__3.Documents, (Func<IDocumentSnapshot<FirestorePlayerNotificationDTO>, FirestorePlayerNotificationDTO>)((IDocumentSnapshot<FirestorePlayerNotificationDTO> d) => d.Data)), (Func<FirestorePlayerNotificationDTO, bool>)((FirestorePlayerNotificationDTO dto) => dto != null && dto.Type == _003C_003E8__2.invitationType)), (Func<FirestorePlayerNotificationDTO, object>)((FirestorePlayerNotificationDTO dto) => CollectionExtensions.GetValueOrDefault<string, object>((IReadOnlyDictionary<string, object>)(object)dto.Data, "guildId"))), (Func<FirestorePlayerNotificationDTO, GuildInvitation>)delegate(FirestorePlayerNotificationDTO dto)
					{
						//IL_0009: Unknown result type (might be due to invalid IL or missing references)
						//IL_000e: Unknown result type (might be due to invalid IL or missing references)
						//IL_003a: Unknown result type (might be due to invalid IL or missing references)
						//IL_003c: Unknown result type (might be due to invalid IL or missing references)
						//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
						//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
						Dictionary<string, object> data = dto.Data;
						DateTimeOffset expiresAt = dto.Ttl;
						object obj = default(object);
						DateTimeOffset val = default(DateTimeOffset);
						if (data.TryGetValue("expiresAt", ref obj) && obj is string text && DateTimeOffset.TryParse(text, ref val))
						{
							expiresAt = val;
						}
						return new GuildInvitation
						{
							ID = dto.Id,
							GuildId = ((CollectionExtensions.GetValueOrDefault<string, object>((IReadOnlyDictionary<string, object>)(object)data, "guildId") as string) ?? string.Empty),
							GuildName = ((CollectionExtensions.GetValueOrDefault<string, object>((IReadOnlyDictionary<string, object>)(object)data, "guildName") as string) ?? "Unknown"),
							InvitedPlayerId = _003C_003E8__1.playerId,
							InvitedByPlayerId = ((CollectionExtensions.GetValueOrDefault<string, object>((IReadOnlyDictionary<string, object>)(object)data, "invitedByPlayerId") as string) ?? string.Empty),
							InvitedByPlayerName = ((CollectionExtensions.GetValueOrDefault<string, object>((IReadOnlyDictionary<string, object>)(object)data, "invitedByPlayerName") as string) ?? "Unknown"),
							Status = InvitationStatus.Pending,
							CreatedAt = dto.CreatedAt,
							ExpiresAt = expiresAt
						};
					}), (Func<GuildInvitation, bool>)((GuildInvitation inv) => !inv.IsExpired)));
					result = _003Cinvitations_003E5__4;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__6 = ex;
					Console.WriteLine("GetPlayerInvitationsAsync failed: " + _003Cex_003E5__6.Message);
					result = new List<GuildInvitation>();
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetRecommendedGuildsAsync_003Ed__28 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<List<Guild>> _003C_003Et__builder;

		public string playerId;

		public int limit;

		public GuildRepository _003C_003E4__this;

		private _003C_003Ec__DisplayClass28_0 _003C_003E8__1;

		private IDocumentSnapshot<FirestorePlayerDTO> _003CplayerDoc_003E5__2;

		private IQuerySnapshot<FirestoreGuildDTO> _003Csnapshot_003E5__3;

		private List<Guild> _003Cguilds_003E5__4;

		private IDocumentSnapshot<FirestorePlayerDTO> _003C_003Es__5;

		private IQuerySnapshot<FirestoreGuildDTO> _003C_003Es__6;

		private global::System.Exception _003Cex_003E5__7;

		private TaskAwaiter<IDocumentSnapshot<FirestorePlayerDTO>> _003C_003Eu__1;

		private TaskAwaiter<IQuerySnapshot<FirestoreGuildDTO>> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_0192: Unknown result type (might be due to invalid IL or missing references)
			//IL_0197: Unknown result type (might be due to invalid IL or missing references)
			//IL_019f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0159: Unknown result type (might be due to invalid IL or missing references)
			//IL_015e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0173: Unknown result type (might be due to invalid IL or missing references)
			//IL_0175: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			List<Guild> result;
			try
			{
				if ((uint)num > 1u)
				{
				}
				try
				{
					TaskAwaiter<IQuerySnapshot<FirestoreGuildDTO>> awaiter;
					TaskAwaiter<IDocumentSnapshot<FirestorePlayerDTO>> awaiter2;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<IQuerySnapshot<FirestoreGuildDTO>>);
							num = (_003C_003E1__state = -1);
							goto IL_01ae;
						}
						_003C_003E8__1 = new _003C_003Ec__DisplayClass28_0();
						awaiter2 = _003C_003E4__this._firestore.GetCollection("players").GetDocument(playerId).GetDocumentSnapshotAsync<FirestorePlayerDTO>((Source)0)
							.GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CGetRecommendedGuildsAsync_003Ed__28 _003CGetRecommendedGuildsAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IDocumentSnapshot<FirestorePlayerDTO>>, _003CGetRecommendedGuildsAsync_003Ed__28>(ref awaiter2, ref _003CGetRecommendedGuildsAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IDocumentSnapshot<FirestorePlayerDTO>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__5 = awaiter2.GetResult();
					_003CplayerDoc_003E5__2 = _003C_003Es__5;
					_003C_003Es__5 = null;
					_003C_003E8__1.playerLevel = _003CplayerDoc_003E5__2.Data?.PlayerLevel ?? 1;
					_003C_003Ec__DisplayClass28_0 _003C_003Ec__DisplayClass28_ = _003C_003E8__1;
					FirestorePlayerDTO data = _003CplayerDoc_003E5__2.Data;
					long? obj;
					if (data == null)
					{
						obj = null;
					}
					else
					{
						Dictionary<string, long>? currencies = data.Currencies;
						obj = ((currencies != null) ? new long?(CollectionExtensions.GetValueOrDefault<string, long>((IReadOnlyDictionary<string, long>)(object)currencies, "reputation", 0L)) : null);
					}
					long? num2 = obj;
					_003C_003Ec__DisplayClass28_.playerTrophies = num2.GetValueOrDefault();
					awaiter = ((IQuery)_003C_003E4__this._firestore.GetCollection("guilds")).GetDocumentsAsync<FirestoreGuildDTO>((Source)0).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter;
						_003CGetRecommendedGuildsAsync_003Ed__28 _003CGetRecommendedGuildsAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IQuerySnapshot<FirestoreGuildDTO>>, _003CGetRecommendedGuildsAsync_003Ed__28>(ref awaiter, ref _003CGetRecommendedGuildsAsync_003Ed__);
						return;
					}
					goto IL_01ae;
					IL_01ae:
					_003C_003Es__6 = awaiter.GetResult();
					_003Csnapshot_003E5__3 = _003C_003Es__6;
					_003C_003Es__6 = null;
					_003Cguilds_003E5__4 = Enumerable.ToList<Guild>(Enumerable.Select<FirestoreGuildDTO, Guild>(Enumerable.Take<FirestoreGuildDTO>((global::System.Collections.Generic.IEnumerable<FirestoreGuildDTO>)Enumerable.ThenByDescending<FirestoreGuildDTO, int>(Enumerable.OrderByDescending<FirestoreGuildDTO, int>(Enumerable.Where<FirestoreGuildDTO>(Enumerable.Where<FirestoreGuildDTO>(Enumerable.Select<IDocumentSnapshot<FirestoreGuildDTO>, FirestoreGuildDTO>(_003Csnapshot_003E5__3.Documents, (Func<IDocumentSnapshot<FirestoreGuildDTO>, FirestoreGuildDTO>)((IDocumentSnapshot<FirestoreGuildDTO> d) => d.Data)), (Func<FirestoreGuildDTO, bool>)((FirestoreGuildDTO g) => g != null)), (Func<FirestoreGuildDTO, bool>)((FirestoreGuildDTO g) => g.IsPublic && g.MinLevelRequired <= _003C_003E8__1.playerLevel && g.MinTrophiesRequired <= _003C_003E8__1.playerTrophies && g.MemberCount < g.MaxMembers)), (Func<FirestoreGuildDTO, int>)((FirestoreGuildDTO g) => g.Level)), (Func<FirestoreGuildDTO, int>)((FirestoreGuildDTO g) => g.Trophies)), limit), (Func<FirestoreGuildDTO, Guild>)((FirestoreGuildDTO firestoreDto) => GuildEntityMapper.ToEntity(firestoreDto))));
					result = _003Cguilds_003E5__4;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__7 = ex;
					Console.WriteLine("GetRecommendedGuildsAsync failed: " + _003Cex_003E5__7.Message);
					result = new List<Guild>();
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetTopGuildsByTrophiesAsync_003Ed__27 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<List<Guild>> _003C_003Et__builder;

		public int limit;

		public GuildRepository _003C_003E4__this;

		private IQuerySnapshot<FirestoreGuildDTO> _003Csnapshot_003E5__1;

		private List<Guild> _003Cguilds_003E5__2;

		private IQuerySnapshot<FirestoreGuildDTO> _003C_003Es__3;

		private global::System.Exception _003Cex_003E5__4;

		private TaskAwaiter<IQuerySnapshot<FirestoreGuildDTO>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			List<Guild> result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<IQuerySnapshot<FirestoreGuildDTO>> awaiter;
					if (num != 0)
					{
						awaiter = ((IQuery)_003C_003E4__this._firestore.GetCollection("guilds")).GetDocumentsAsync<FirestoreGuildDTO>((Source)0).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CGetTopGuildsByTrophiesAsync_003Ed__27 _003CGetTopGuildsByTrophiesAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IQuerySnapshot<FirestoreGuildDTO>>, _003CGetTopGuildsByTrophiesAsync_003Ed__27>(ref awaiter, ref _003CGetTopGuildsByTrophiesAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IQuerySnapshot<FirestoreGuildDTO>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__3 = awaiter.GetResult();
					_003Csnapshot_003E5__1 = _003C_003Es__3;
					_003C_003Es__3 = null;
					_003Cguilds_003E5__2 = Enumerable.ToList<Guild>(Enumerable.Select<FirestoreGuildDTO, Guild>(Enumerable.Take<FirestoreGuildDTO>((global::System.Collections.Generic.IEnumerable<FirestoreGuildDTO>)Enumerable.OrderByDescending<FirestoreGuildDTO, int>(Enumerable.Where<FirestoreGuildDTO>(Enumerable.Select<IDocumentSnapshot<FirestoreGuildDTO>, FirestoreGuildDTO>(_003Csnapshot_003E5__1.Documents, (Func<IDocumentSnapshot<FirestoreGuildDTO>, FirestoreGuildDTO>)((IDocumentSnapshot<FirestoreGuildDTO> d) => d.Data)), (Func<FirestoreGuildDTO, bool>)((FirestoreGuildDTO g) => g != null)), (Func<FirestoreGuildDTO, int>)((FirestoreGuildDTO g) => g.Trophies)), limit), (Func<FirestoreGuildDTO, Guild>)((FirestoreGuildDTO firestoreDto) => GuildEntityMapper.ToEntity(firestoreDto))));
					result = _003Cguilds_003E5__2;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__4 = ex;
					Console.WriteLine("GetTopGuildsAsync failed: " + _003Cex_003E5__4.Message);
					result = new List<Guild>();
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetWarBucketOpponentsAsync_003Ed__64 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<List<Guild>> _003C_003Et__builder;

		public string guildId;

		public GuildRepository _003C_003E4__this;

		private _003C_003Ec__DisplayClass64_0 _003C_003E8__1;

		private Guild _003Cguild_003E5__2;

		private IDocumentSnapshot<FirestoreActiveWarDTO> _003CwarDoc_003E5__3;

		private List<string> _003Cids_003E5__4;

		private List<string> _003Cothers_003E5__5;

		private Guild[] _003Cguilds_003E5__6;

		private Guild _003C_003Es__7;

		private IDocumentSnapshot<FirestoreActiveWarDTO> _003C_003Es__8;

		private Guild[] _003C_003Es__9;

		private global::System.Exception _003Cex_003E5__10;

		private TaskAwaiter<Guild?> _003C_003Eu__1;

		private TaskAwaiter<IDocumentSnapshot<FirestoreActiveWarDTO>> _003C_003Eu__2;

		private TaskAwaiter<Guild[]> _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0177: Unknown result type (might be due to invalid IL or missing references)
			//IL_017c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0184: Unknown result type (might be due to invalid IL or missing references)
			//IL_0280: Unknown result type (might be due to invalid IL or missing references)
			//IL_0285: Unknown result type (might be due to invalid IL or missing references)
			//IL_028d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_013e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0143: Unknown result type (might be due to invalid IL or missing references)
			//IL_0158: Unknown result type (might be due to invalid IL or missing references)
			//IL_015a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0247: Unknown result type (might be due to invalid IL or missing references)
			//IL_024c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0261: Unknown result type (might be due to invalid IL or missing references)
			//IL_0263: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			List<Guild> result;
			try
			{
				if ((uint)num > 2u)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass64_0();
					_003C_003E8__1.guildId = guildId;
					_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
				}
				try
				{
					TaskAwaiter<Guild> awaiter3;
					TaskAwaiter<IDocumentSnapshot<FirestoreActiveWarDTO>> awaiter2;
					TaskAwaiter<Guild[]> awaiter;
					switch (num)
					{
					default:
						awaiter3 = _003C_003E4__this.GetByIdAsync(_003C_003E8__1.guildId).GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter3;
							_003CGetWarBucketOpponentsAsync_003Ed__64 _003CGetWarBucketOpponentsAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Guild>, _003CGetWarBucketOpponentsAsync_003Ed__64>(ref awaiter3, ref _003CGetWarBucketOpponentsAsync_003Ed__);
							return;
						}
						goto IL_00c7;
					case 0:
						awaiter3 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Guild>);
						num = (_003C_003E1__state = -1);
						goto IL_00c7;
					case 1:
						awaiter2 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<IDocumentSnapshot<FirestoreActiveWarDTO>>);
						num = (_003C_003E1__state = -1);
						goto IL_0193;
					case 2:
						{
							awaiter = _003C_003Eu__3;
							_003C_003Eu__3 = default(TaskAwaiter<Guild[]>);
							num = (_003C_003E1__state = -1);
							break;
						}
						IL_0193:
						_003C_003Es__8 = awaiter2.GetResult();
						_003CwarDoc_003E5__3 = _003C_003Es__8;
						_003C_003Es__8 = null;
						_003Cids_003E5__4 = _003CwarDoc_003E5__3.Data?.ParticipantGuildIds;
						if (_003Cids_003E5__4 != null && _003Cids_003E5__4.Count != 0)
						{
							_003Cothers_003E5__5 = Enumerable.ToList<string>(Enumerable.Distinct<string>(Enumerable.Where<string>((global::System.Collections.Generic.IEnumerable<string>)_003Cids_003E5__4, (Func<string, bool>)((string id) => id != _003C_003E8__1.guildId))));
							awaiter = global::System.Threading.Tasks.Task.WhenAll<Guild>(Enumerable.Select<string, global::System.Threading.Tasks.Task<Guild>>((global::System.Collections.Generic.IEnumerable<string>)_003Cothers_003E5__5, (Func<string, global::System.Threading.Tasks.Task<Guild>>)((string id) => _003C_003E8__1._003C_003E4__this.GetByIdAsync(id)))).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__3 = awaiter;
								_003CGetWarBucketOpponentsAsync_003Ed__64 _003CGetWarBucketOpponentsAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Guild[]>, _003CGetWarBucketOpponentsAsync_003Ed__64>(ref awaiter, ref _003CGetWarBucketOpponentsAsync_003Ed__);
								return;
							}
							break;
						}
						result = new List<Guild>();
						goto end_IL_003e;
						IL_00c7:
						_003C_003Es__7 = awaiter3.GetResult();
						_003Cguild_003E5__2 = _003C_003Es__7;
						_003C_003Es__7 = null;
						if (_003Cguild_003E5__2 != null && !string.IsNullOrEmpty(_003Cguild_003E5__2.CurrentWarId))
						{
							awaiter2 = _003C_003E4__this._firestore.GetCollection("guildWars").GetDocument(_003Cguild_003E5__2.CurrentWarId).GetDocumentSnapshotAsync<FirestoreActiveWarDTO>((Source)0)
								.GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__2 = awaiter2;
								_003CGetWarBucketOpponentsAsync_003Ed__64 _003CGetWarBucketOpponentsAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IDocumentSnapshot<FirestoreActiveWarDTO>>, _003CGetWarBucketOpponentsAsync_003Ed__64>(ref awaiter2, ref _003CGetWarBucketOpponentsAsync_003Ed__);
								return;
							}
							goto IL_0193;
						}
						result = new List<Guild>();
						goto end_IL_003e;
					}
					_003C_003Es__9 = awaiter.GetResult();
					_003Cguilds_003E5__6 = _003C_003Es__9;
					_003C_003Es__9 = null;
					result = Enumerable.ToList<Guild>(Enumerable.Select<Guild, Guild>(Enumerable.Where<Guild>((global::System.Collections.Generic.IEnumerable<Guild>)_003Cguilds_003E5__6, (Func<Guild, bool>)((Guild g) => g != null)), (Func<Guild, Guild>)((Guild g) => g)));
					end_IL_003e:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__10 = ex;
					Console.WriteLine("GetWarBucketOpponentsAsync failed: " + _003Cex_003E5__10.Message);
					result = new List<Guild>();
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetWarProgressAsync_003Ed__56 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<GuildWarProgress> _003C_003Et__builder;

		public string attackingGuildId;

		public string defendingGuildId;

		public string warId;

		public GuildRepository _003C_003E4__this;

		private IDocumentReference _003CprogressRef_003E5__1;

		private IDocumentSnapshot<FirestoreGuildWarProgressDTO> _003Csnapshot_003E5__2;

		private Dictionary<string, FirestoreWarAttackerDTO> _003CplayerStats_003E5__3;

		private Dictionary<string, long> _003CplayerAttackCounts_003E5__4;

		private Dictionary<string, DateTimeOffset?> _003CplayerHourlyStarts_003E5__5;

		private Dictionary<string, int> _003CplayerHourlyCrystals_003E5__6;

		private Dictionary<string, DefenderWarRecord> _003CdefeatedDefenders_003E5__7;

		private Dictionary<string, int> _003CplayerRaidCounts_003E5__8;

		private Dictionary<string, DateTimeOffset?> _003CplayerRaidHourStarts_003E5__9;

		private Dictionary<string, int> _003CplayerTotalCrystalsAttack_003E5__10;

		private Dictionary<string, int> _003CplayerTotalCrystalsRaid_003E5__11;

		private IDocumentSnapshot<FirestoreGuildWarProgressDTO> _003C_003Es__12;

		private global::System.Exception _003Cex_003E5__13;

		private TaskAwaiter<IDocumentSnapshot<FirestoreGuildWarProgressDTO>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_044b: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			GuildWarProgress result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<IDocumentSnapshot<FirestoreGuildWarProgressDTO>> awaiter;
					if (num != 0)
					{
						_003CprogressRef_003E5__1 = _003C_003E4__this._firestore.GetCollection("guilds").GetDocument(defendingGuildId).GetCollection("warProgress")
							.GetDocument(attackingGuildId);
						awaiter = _003CprogressRef_003E5__1.GetDocumentSnapshotAsync<FirestoreGuildWarProgressDTO>((Source)0).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CGetWarProgressAsync_003Ed__56 _003CGetWarProgressAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IDocumentSnapshot<FirestoreGuildWarProgressDTO>>, _003CGetWarProgressAsync_003Ed__56>(ref awaiter, ref _003CGetWarProgressAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IDocumentSnapshot<FirestoreGuildWarProgressDTO>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__12 = awaiter.GetResult();
					_003Csnapshot_003E5__2 = _003C_003Es__12;
					_003C_003Es__12 = null;
					if (_003Csnapshot_003E5__2.Data == null)
					{
						result = null;
					}
					else
					{
						_003CplayerStats_003E5__3 = _003Csnapshot_003E5__2.Data.PlayerStats ?? new Dictionary<string, FirestoreWarAttackerDTO>();
						_003CplayerAttackCounts_003E5__4 = Enumerable.ToDictionary<KeyValuePair<string, FirestoreWarAttackerDTO>, string, long>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, FirestoreWarAttackerDTO>>)_003CplayerStats_003E5__3, (Func<KeyValuePair<string, FirestoreWarAttackerDTO>, string>)((KeyValuePair<string, FirestoreWarAttackerDTO> kvp) => kvp.Key), (Func<KeyValuePair<string, FirestoreWarAttackerDTO>, long>)((KeyValuePair<string, FirestoreWarAttackerDTO> kvp) => kvp.Value.AttackCount));
						_003CplayerHourlyStarts_003E5__5 = Enumerable.ToDictionary<KeyValuePair<string, FirestoreWarAttackerDTO>, string, DateTimeOffset?>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, FirestoreWarAttackerDTO>>)_003CplayerStats_003E5__3, (Func<KeyValuePair<string, FirestoreWarAttackerDTO>, string>)((KeyValuePair<string, FirestoreWarAttackerDTO> kvp) => kvp.Key), (Func<KeyValuePair<string, FirestoreWarAttackerDTO>, DateTimeOffset?>)((KeyValuePair<string, FirestoreWarAttackerDTO> kvp) => kvp.Value.HourlyStart));
						_003CplayerHourlyCrystals_003E5__6 = Enumerable.ToDictionary<KeyValuePair<string, FirestoreWarAttackerDTO>, string, int>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, FirestoreWarAttackerDTO>>)_003CplayerStats_003E5__3, (Func<KeyValuePair<string, FirestoreWarAttackerDTO>, string>)((KeyValuePair<string, FirestoreWarAttackerDTO> kvp) => kvp.Key), (Func<KeyValuePair<string, FirestoreWarAttackerDTO>, int>)((KeyValuePair<string, FirestoreWarAttackerDTO> kvp) => kvp.Value.HourlyCrystals));
						_003CdefeatedDefenders_003E5__7 = Enumerable.ToDictionary<KeyValuePair<string, FirestoreWarDefenderDTO>, string, DefenderWarRecord>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, FirestoreWarDefenderDTO>>)(_003Csnapshot_003E5__2.Data.DefeatedDefenders ?? new Dictionary<string, FirestoreWarDefenderDTO>()), (Func<KeyValuePair<string, FirestoreWarDefenderDTO>, string>)((KeyValuePair<string, FirestoreWarDefenderDTO> kvp) => kvp.Key), (Func<KeyValuePair<string, FirestoreWarDefenderDTO>, DefenderWarRecord>)((KeyValuePair<string, FirestoreWarDefenderDTO> kvp) => new DefenderWarRecord(kvp.Value.DefeatedCount, kvp.Value.DowntimeEnds, kvp.Value.LastFellAt, kvp.Value.CrystalsGained)));
						_003CplayerRaidCounts_003E5__8 = Enumerable.ToDictionary<KeyValuePair<string, FirestoreWarAttackerDTO>, string, int>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, FirestoreWarAttackerDTO>>)_003CplayerStats_003E5__3, (Func<KeyValuePair<string, FirestoreWarAttackerDTO>, string>)((KeyValuePair<string, FirestoreWarAttackerDTO> kvp) => kvp.Key), (Func<KeyValuePair<string, FirestoreWarAttackerDTO>, int>)((KeyValuePair<string, FirestoreWarAttackerDTO> kvp) => kvp.Value.RaidCountThisHour));
						_003CplayerRaidHourStarts_003E5__9 = Enumerable.ToDictionary<KeyValuePair<string, FirestoreWarAttackerDTO>, string, DateTimeOffset?>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, FirestoreWarAttackerDTO>>)_003CplayerStats_003E5__3, (Func<KeyValuePair<string, FirestoreWarAttackerDTO>, string>)((KeyValuePair<string, FirestoreWarAttackerDTO> kvp) => kvp.Key), (Func<KeyValuePair<string, FirestoreWarAttackerDTO>, DateTimeOffset?>)((KeyValuePair<string, FirestoreWarAttackerDTO> kvp) => kvp.Value.RaidHourStart));
						_003CplayerTotalCrystalsAttack_003E5__10 = Enumerable.ToDictionary<KeyValuePair<string, FirestoreWarAttackerDTO>, string, int>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, FirestoreWarAttackerDTO>>)_003CplayerStats_003E5__3, (Func<KeyValuePair<string, FirestoreWarAttackerDTO>, string>)((KeyValuePair<string, FirestoreWarAttackerDTO> kvp) => kvp.Key), (Func<KeyValuePair<string, FirestoreWarAttackerDTO>, int>)((KeyValuePair<string, FirestoreWarAttackerDTO> kvp) => kvp.Value.TotalCrystalsAttack));
						_003CplayerTotalCrystalsRaid_003E5__11 = Enumerable.ToDictionary<KeyValuePair<string, FirestoreWarAttackerDTO>, string, int>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, FirestoreWarAttackerDTO>>)_003CplayerStats_003E5__3, (Func<KeyValuePair<string, FirestoreWarAttackerDTO>, string>)((KeyValuePair<string, FirestoreWarAttackerDTO> kvp) => kvp.Key), (Func<KeyValuePair<string, FirestoreWarAttackerDTO>, int>)((KeyValuePair<string, FirestoreWarAttackerDTO> kvp) => kvp.Value.TotalCrystalsRaid));
						result = new GuildWarProgress
						{
							ID = (_003Csnapshot_003E5__2.Data.ID ?? string.Empty),
							WarId = (_003Csnapshot_003E5__2.Data.WarId ?? string.Empty),
							AttackingGuildId = (_003Csnapshot_003E5__2.Data.AttackingGuildId ?? string.Empty),
							DefendingGuildId = (_003Csnapshot_003E5__2.Data.DefendingGuildId ?? string.Empty),
							DefeatedDefenders = _003CdefeatedDefenders_003E5__7,
							CrystalsStolen = _003Csnapshot_003E5__2.Data.CrystalsStolen,
							LastRaidTime = _003Csnapshot_003E5__2.Data.LastRaidTime,
							SeasonId = (_003Csnapshot_003E5__2.Data.SeasonId ?? string.Empty),
							TotalAttacksCount = _003Csnapshot_003E5__2.Data.TotalAttacksCount,
							RaidCount = _003Csnapshot_003E5__2.Data.RaidCount,
							StartingCrystals = _003Csnapshot_003E5__2.Data.StartingCrystals,
							PlayerAttackCounts = _003CplayerAttackCounts_003E5__4,
							PlayerHourlyStarts = _003CplayerHourlyStarts_003E5__5,
							PlayerHourlyCrystals = _003CplayerHourlyCrystals_003E5__6,
							PlayerRaidCounts = _003CplayerRaidCounts_003E5__8,
							PlayerRaidHourStarts = _003CplayerRaidHourStarts_003E5__9,
							PlayerTotalCrystalsAttack = _003CplayerTotalCrystalsAttack_003E5__10,
							PlayerTotalCrystalsRaid = _003CplayerTotalCrystalsRaid_003E5__11
						};
					}
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__13 = ex;
					Console.WriteLine("GetWarProgressAsync failed: " + _003Cex_003E5__13.Message);
					result = null;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CJoinGuildAsync_003Ed__45 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string playerId;

		public string playerName;

		public string guildId;

		public int playerLevel;

		public GuildRepository _003C_003E4__this;

		private _003C_003Ec__DisplayClass45_0 _003C_003E8__1;

		private _003C_003Ec__DisplayClass45_1 _003C_003E8__2;

		private IDocumentReference _003CplayerRef_003E5__3;

		private global::System.Exception _003Cex_003E5__4;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_017c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0188: Unknown result type (might be due to invalid IL or missing references)
			//IL_028d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0292: Unknown result type (might be due to invalid IL or missing references)
			//IL_029a: Unknown result type (might be due to invalid IL or missing references)
			//IL_011a: Unknown result type (might be due to invalid IL or missing references)
			//IL_011f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0145: Unknown result type (might be due to invalid IL or missing references)
			//IL_014a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0254: Unknown result type (might be due to invalid IL or missing references)
			//IL_0259: Unknown result type (might be due to invalid IL or missing references)
			//IL_015e: Unknown result type (might be due to invalid IL or missing references)
			//IL_015f: Unknown result type (might be due to invalid IL or missing references)
			//IL_026e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0270: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if ((uint)num > 1u)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass45_0();
					_003C_003E8__1.playerId = playerId;
					_003C_003E8__1.playerName = playerName;
					_003C_003E8__1.playerLevel = playerLevel;
				}
				try
				{
					TaskAwaiter awaiter;
					TaskAwaiter<bool> awaiter2;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_02a9;
						}
						_003C_003E8__2 = new _003C_003Ec__DisplayClass45_1();
						_003C_003E8__2.CS_0024_003C_003E8__locals1 = _003C_003E8__1;
						_003C_003E8__2.guildRef = _003C_003E4__this._firestore.GetCollection("guilds").GetDocument(guildId);
						_003CplayerRef_003E5__3 = _003C_003E4__this._firestore.GetCollection("players").GetDocument(_003C_003E8__2.CS_0024_003C_003E8__locals1.playerId);
						_003C_003E8__2.memberRef = _003C_003E4__this.GetMemberRef(guildId, _003C_003E8__2.CS_0024_003C_003E8__locals1.playerId);
						_003C_003E8__2.guildName = null;
						_003C_003E8__2.joinedAt = DateTimeOffset.UtcNow;
						awaiter2 = _003C_003E4__this._firestore.RunTransactionAsync<bool>((Func<ITransaction, bool>)delegate(ITransaction transaction)
						{
							//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
							//IL_010a: Unknown result type (might be due to invalid IL or missing references)
							IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(_003C_003E8__2.guildRef);
							if (document.Data == null)
							{
								throw new global::System.Exception("Guild not found");
							}
							_003C_003E8__2.guildName = document.Data.Name;
							int memberCount = document.Data.MemberCount;
							int maxMembers = document.Data.MaxMembers;
							if (memberCount >= maxMembers)
							{
								throw new global::System.Exception("Guild is full");
							}
							int num2 = memberCount + 1;
							transaction.UpdateData(_003C_003E8__2.guildRef, new Dictionary<object, object> { [(object)"memberCount"] = num2 });
							transaction.SetData(_003C_003E8__2.memberRef, (object)new FirestoreGuildMemberDTO
							{
								PlayerId = _003C_003E8__2.CS_0024_003C_003E8__locals1.playerId,
								PlayerName = _003C_003E8__2.CS_0024_003C_003E8__locals1.playerName,
								Role = "Member",
								Level = _003C_003E8__2.CS_0024_003C_003E8__locals1.playerLevel,
								Trophies = 0,
								Contribution = 0,
								WeeklyContribution = 0,
								JoinedAt = _003C_003E8__2.joinedAt,
								LastActiveAt = _003C_003E8__2.joinedAt,
								IsOnline = true
							}, (SetOptions)null);
							return true;
						}).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CJoinGuildAsync_003Ed__45 _003CJoinGuildAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CJoinGuildAsync_003Ed__45>(ref awaiter2, ref _003CJoinGuildAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
					}
					awaiter2.GetResult();
					if (_003C_003E4__this._userSession.CurrentPlayerId != _003C_003E8__2.CS_0024_003C_003E8__locals1.playerId)
					{
						awaiter = _003C_003E4__this.SendNotificationToPlayerAsync(_003C_003E8__2.CS_0024_003C_003E8__locals1.playerId, NotificationType.GuildJoined, new Dictionary<string, object>
						{
							["guildId"] = guildId,
							["guildName"] = _003C_003E8__2.guildName ?? "Unknown Guild",
							["role"] = "Member",
							["joinedAt"] = ((object)(DateTimeOffset)(ref _003C_003E8__2.joinedAt)).ToString()
						}).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter;
							_003CJoinGuildAsync_003Ed__45 _003CJoinGuildAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CJoinGuildAsync_003Ed__45>(ref awaiter, ref _003CJoinGuildAsync_003Ed__);
							return;
						}
						goto IL_02a9;
					}
					goto IL_02b2;
					IL_02b2:
					result = true;
					goto end_IL_004f;
					IL_02a9:
					((TaskAwaiter)(ref awaiter)).GetResult();
					goto IL_02b2;
					end_IL_004f:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__4 = ex;
					Console.WriteLine("JoinGuildAsync failed: " + _003Cex_003E5__4.Message);
					result = false;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CKickMemberAsync_003Ed__20 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string guildId;

		public string targetPlayerId;

		public string kickedByPlayerId;

		public GuildRepository _003C_003E4__this;

		private _003C_003Ec__DisplayClass20_0 _003C_003E8__1;

		private IDocumentReference _003CguildRef_003E5__2;

		private IDocumentReference _003CplayerRef_003E5__3;

		private string _003CguildName_003E5__4;

		private IDocumentSnapshot<FirestoreGuildDTO> _003CguildSnapshot_003E5__5;

		private IDocumentSnapshot<FirestoreGuildDTO> _003C_003Es__6;

		private global::System.Exception _003Cex_003E5__7;

		private TaskAwaiter<IDocumentSnapshot<FirestoreGuildDTO>> _003C_003Eu__1;

		private TaskAwaiter<object> _003C_003Eu__2;

		private TaskAwaiter _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0104: Unknown result type (might be due to invalid IL or missing references)
			//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_01af: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0282: Unknown result type (might be due to invalid IL or missing references)
			//IL_0287: Unknown result type (might be due to invalid IL or missing references)
			//IL_028f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			//IL_0171: Unknown result type (might be due to invalid IL or missing references)
			//IL_0176: Unknown result type (might be due to invalid IL or missing references)
			//IL_0249: Unknown result type (might be due to invalid IL or missing references)
			//IL_024e: Unknown result type (might be due to invalid IL or missing references)
			//IL_018b: Unknown result type (might be due to invalid IL or missing references)
			//IL_018d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0263: Unknown result type (might be due to invalid IL or missing references)
			//IL_0265: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if ((uint)num > 2u)
				{
				}
				try
				{
					TaskAwaiter<IDocumentSnapshot<FirestoreGuildDTO>> awaiter3;
					TaskAwaiter<object> awaiter2;
					TaskAwaiter awaiter;
					switch (num)
					{
					default:
						_003C_003E8__1 = new _003C_003Ec__DisplayClass20_0();
						_003CguildRef_003E5__2 = _003C_003E4__this._firestore.GetCollection("guilds").GetDocument(guildId);
						_003CplayerRef_003E5__3 = _003C_003E4__this._firestore.GetCollection("players").GetDocument(targetPlayerId);
						_003C_003E8__1.memberRef = _003C_003E4__this.GetMemberRef(guildId, targetPlayerId);
						_003CguildName_003E5__4 = null;
						awaiter3 = _003CguildRef_003E5__2.GetDocumentSnapshotAsync<FirestoreGuildDTO>((Source)0).GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter3;
							_003CKickMemberAsync_003Ed__20 _003CKickMemberAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IDocumentSnapshot<FirestoreGuildDTO>>, _003CKickMemberAsync_003Ed__20>(ref awaiter3, ref _003CKickMemberAsync_003Ed__);
							return;
						}
						goto IL_0113;
					case 0:
						awaiter3 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IDocumentSnapshot<FirestoreGuildDTO>>);
						num = (_003C_003E1__state = -1);
						goto IL_0113;
					case 1:
						awaiter2 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<object>);
						num = (_003C_003E1__state = -1);
						goto IL_01c6;
					case 2:
						{
							awaiter = _003C_003Eu__3;
							_003C_003Eu__3 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_029e;
						}
						IL_01c6:
						awaiter2.GetResult();
						if (!(_003C_003E4__this._userSession.CurrentPlayerId != targetPlayerId))
						{
							break;
						}
						awaiter = _003C_003E4__this.SendNotificationToPlayerAsync(targetPlayerId, NotificationType.GuildKicked, new Dictionary<string, object>
						{
							["guildId"] = guildId,
							["guildName"] = _003CguildName_003E5__4 ?? "Unknown Guild",
							["kickedByPlayerId"] = kickedByPlayerId
						}).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__3 = awaiter;
							_003CKickMemberAsync_003Ed__20 _003CKickMemberAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CKickMemberAsync_003Ed__20>(ref awaiter, ref _003CKickMemberAsync_003Ed__);
							return;
						}
						goto IL_029e;
						IL_0113:
						_003C_003Es__6 = awaiter3.GetResult();
						_003CguildSnapshot_003E5__5 = _003C_003Es__6;
						_003C_003Es__6 = null;
						_003CguildName_003E5__4 = _003CguildSnapshot_003E5__5.Data?.Name;
						awaiter2 = _003C_003E4__this._firestore.RunTransactionAsync<object>((Func<ITransaction, object>)delegate(ITransaction transaction)
						{
							transaction.DeleteDocument(_003C_003E8__1.memberRef);
							return true;
						}).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter2;
							_003CKickMemberAsync_003Ed__20 _003CKickMemberAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<object>, _003CKickMemberAsync_003Ed__20>(ref awaiter2, ref _003CKickMemberAsync_003Ed__);
							return;
						}
						goto IL_01c6;
						IL_029e:
						((TaskAwaiter)(ref awaiter)).GetResult();
						break;
					}
					result = true;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__7 = ex;
					Console.WriteLine("KickMemberAsync failed: " + _003Cex_003E5__7.Message);
					result = false;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CLeaveGuildAsync_003Ed__19 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string playerId;

		public string guildId;

		public Guild currentGuild;

		public GuildRepository _003C_003E4__this;

		private _003C_003Ec__DisplayClass19_0 _003C_003E8__1;

		private _003C_003Ec__DisplayClass19_1 _003C_003E8__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter<object> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0104: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if (num != 0)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass19_0();
					_003C_003E8__1.currentGuild = currentGuild;
				}
				try
				{
					TaskAwaiter<object> awaiter;
					if (num != 0)
					{
						_003C_003E8__2 = new _003C_003Ec__DisplayClass19_1();
						_003C_003E8__2.CS_0024_003C_003E8__locals1 = _003C_003E8__1;
						_003C_003E8__2.memberRef = _003C_003E4__this.GetMemberRef(guildId, playerId);
						_003C_003E8__2.guildRef = _003C_003E4__this._firestore.GetCollection("guilds").GetDocument(guildId);
						awaiter = _003C_003E4__this._firestore.RunTransactionAsync<object>((Func<ITransaction, object>)delegate(ITransaction transaction)
						{
							_003C_003E8__2.memberRef.DeleteDocumentAsync();
							int memberCount = _003C_003E8__2.CS_0024_003C_003E8__locals1.currentGuild.MemberCount;
							int maxMembers = _003C_003E8__2.CS_0024_003C_003E8__locals1.currentGuild.MaxMembers;
							if (memberCount >= maxMembers)
							{
								throw new global::System.Exception("Guild is full");
							}
							int num2 = memberCount - 1;
							transaction.UpdateData(_003C_003E8__2.guildRef, new Dictionary<object, object> { [(object)"memberCount"] = num2 });
							return true;
						}).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CLeaveGuildAsync_003Ed__19 _003CLeaveGuildAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<object>, _003CLeaveGuildAsync_003Ed__19>(ref awaiter, ref _003CLeaveGuildAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<object>);
						num = (_003C_003E1__state = -1);
					}
					awaiter.GetResult();
					result = true;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine("LeaveGuildAsync failed: " + _003Cex_003E5__3.Message);
					result = false;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CPromoteMemberAsync_003Ed__21 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string guildId;

		public string targetPlayerId;

		public GuildRole newRole;

		public GuildRepository _003C_003E4__this;

		private _003C_003Ec__DisplayClass21_0 _003C_003E8__1;

		private _003C_003Ec__DisplayClass21_1 _003C_003E8__2;

		private IDocumentReference _003CplayerRef_003E5__3;

		private global::System.Exception _003Cex_003E5__4;

		private TaskAwaiter<object> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0142: Unknown result type (might be due to invalid IL or missing references)
			//IL_0147: Unknown result type (might be due to invalid IL or missing references)
			//IL_014e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0253: Unknown result type (might be due to invalid IL or missing references)
			//IL_0258: Unknown result type (might be due to invalid IL or missing references)
			//IL_0260: Unknown result type (might be due to invalid IL or missing references)
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_0124: Unknown result type (might be due to invalid IL or missing references)
			//IL_0125: Unknown result type (might be due to invalid IL or missing references)
			//IL_021a: Unknown result type (might be due to invalid IL or missing references)
			//IL_021f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0234: Unknown result type (might be due to invalid IL or missing references)
			//IL_0236: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if ((uint)num > 1u)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass21_0();
					_003C_003E8__1.newRole = newRole;
				}
				try
				{
					TaskAwaiter awaiter;
					TaskAwaiter<object> awaiter2;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_026f;
						}
						_003C_003E8__2 = new _003C_003Ec__DisplayClass21_1();
						_003C_003E8__2.CS_0024_003C_003E8__locals1 = _003C_003E8__1;
						_003C_003E8__2.guildRef = _003C_003E4__this._firestore.GetCollection("guilds").GetDocument(guildId);
						_003CplayerRef_003E5__3 = _003C_003E4__this._firestore.GetCollection("players").GetDocument(targetPlayerId);
						_003C_003E8__2.memberRef = _003C_003E4__this.GetMemberRef(guildId, targetPlayerId);
						_003C_003E8__2.oldRole = null;
						_003C_003E8__2.guildName = null;
						awaiter2 = _003C_003E4__this._firestore.RunTransactionAsync<object>((Func<ITransaction, object>)delegate(ITransaction transaction)
						{
							//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
							IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(_003C_003E8__2.guildRef);
							if (document.Data == null)
							{
								throw new global::System.Exception("Guild not found");
							}
							_003C_003E8__2.guildName = document.Data.Name;
							IDocumentSnapshot<FirestoreGuildMemberDTO> document2 = transaction.GetDocument<FirestoreGuildMemberDTO>(_003C_003E8__2.memberRef);
							if (document2.Data == null)
							{
								throw new global::System.Exception("Member not found");
							}
							_003C_003E8__2.oldRole = document2.Data.Role;
							transaction.UpdateData(_003C_003E8__2.memberRef, new Dictionary<object, object> { [(object)"role"] = ((object)_003C_003E8__2.CS_0024_003C_003E8__locals1.newRole).ToString() });
							transaction.UpdateData(_003C_003E8__2.guildRef, new Dictionary<object, object> { [(object)"lastActivityAt"] = DateTimeOffset.UtcNow });
							return true;
						}).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CPromoteMemberAsync_003Ed__21 _003CPromoteMemberAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<object>, _003CPromoteMemberAsync_003Ed__21>(ref awaiter2, ref _003CPromoteMemberAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<object>);
						num = (_003C_003E1__state = -1);
					}
					awaiter2.GetResult();
					if (_003C_003E4__this._userSession.CurrentPlayerId != targetPlayerId)
					{
						awaiter = _003C_003E4__this.SendNotificationToPlayerAsync(targetPlayerId, NotificationType.GuildPromoted, new Dictionary<string, object>
						{
							["guildId"] = guildId,
							["guildName"] = _003C_003E8__2.guildName ?? "Unknown Guild",
							["newRole"] = ((object)_003C_003E8__2.CS_0024_003C_003E8__locals1.newRole).ToString(),
							["oldRole"] = _003C_003E8__2.oldRole ?? "member"
						}).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter;
							_003CPromoteMemberAsync_003Ed__21 _003CPromoteMemberAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CPromoteMemberAsync_003Ed__21>(ref awaiter, ref _003CPromoteMemberAsync_003Ed__);
							return;
						}
						goto IL_026f;
					}
					goto IL_0278;
					IL_026f:
					((TaskAwaiter)(ref awaiter)).GetResult();
					goto IL_0278;
					IL_0278:
					result = true;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__4 = ex;
					Console.WriteLine("PromoteMemberAsync failed: " + _003Cex_003E5__4.Message);
					result = false;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CRefreshDefenderAsync_003Ed__63 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string guildId;

		public string playerId;

		public GuildRepository _003C_003E4__this;

		private _003C_003Ec__DisplayClass63_0 _003C_003E8__1;

		private _003C_003Ec__DisplayClass63_1 _003C_003E8__2;

		private bool _003C_003Es__3;

		private global::System.Exception _003Cex_003E5__4;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if (num != 0)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass63_0();
					_003C_003E8__1.playerId = playerId;
				}
				try
				{
					TaskAwaiter<bool> awaiter;
					if (num != 0)
					{
						_003C_003E8__2 = new _003C_003Ec__DisplayClass63_1();
						_003C_003E8__2.CS_0024_003C_003E8__locals1 = _003C_003E8__1;
						_003C_003E8__2.guildRef = _003C_003E4__this._firestore.GetCollection("guilds").GetDocument(guildId);
						awaiter = _003C_003E4__this._firestore.RunTransactionAsync<bool>((Func<ITransaction, bool>)delegate(ITransaction transaction)
						{
							//IL_002c: Unknown result type (might be due to invalid IL or missing references)
							//IL_0031: Unknown result type (might be due to invalid IL or missing references)
							//IL_0045: Unknown result type (might be due to invalid IL or missing references)
							//IL_004a: Unknown result type (might be due to invalid IL or missing references)
							//IL_0094: Unknown result type (might be due to invalid IL or missing references)
							//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
							_003C_003Ec__DisplayClass63_2 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass63_2();
							IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(_003C_003E8__2.guildRef);
							if (document.Data == null)
							{
								return false;
							}
							CS_0024_003C_003E8__locals0.now = DateTimeOffset.UtcNow;
							DateTimeOffset expiresAt = ((DateTimeOffset)(ref CS_0024_003C_003E8__locals0.now)).AddHours(8.0);
							Dictionary<string, DefenderData> val = ToDomainDefenders(document.Data.Defenders);
							DefenderData defenderData = default(DefenderData);
							if (!val.TryGetValue(_003C_003E8__2.CS_0024_003C_003E8__locals1.playerId, ref defenderData))
							{
								return false;
							}
							val[_003C_003E8__2.CS_0024_003C_003E8__locals1.playerId] = defenderData with
							{
								ExpiresAt = expiresAt,
								DowntimeEnds = null
							};
							Dictionary<object, object> val2 = new Dictionary<object, object>
							{
								[(object)"defenders"] = ToFirestoreDefenders(val),
								[(object)"lastActivityAt"] = CS_0024_003C_003E8__locals0.now
							};
							if (Enumerable.Any<DefenderData>((global::System.Collections.Generic.IEnumerable<DefenderData>)val.Values, (Func<DefenderData, bool>)((DefenderData d) => d.ExpiresAt > CS_0024_003C_003E8__locals0.now && (!d.DowntimeEnds.HasValue || !(d.DowntimeEnds.Value > CS_0024_003C_003E8__locals0.now)))))
							{
								val2[(object)"guildBreakEndsAt"] = null;
							}
							transaction.UpdateData(_003C_003E8__2.guildRef, val2);
							return true;
						}).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CRefreshDefenderAsync_003Ed__63 _003CRefreshDefenderAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CRefreshDefenderAsync_003Ed__63>(ref awaiter, ref _003CRefreshDefenderAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__3 = awaiter.GetResult();
					result = _003C_003Es__3;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__4 = ex;
					Console.WriteLine("RefreshDefenderAsync failed: " + _003Cex_003E5__4.Message);
					result = false;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CRegisterAsDefenderAsync_003Ed__61 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public Guild guild;

		public string playerId;

		public List<string> squadIds;

		public GuildRepository _003C_003E4__this;

		private _003C_003Ec__DisplayClass61_0 _003C_003E8__1;

		private _003C_003Ec__DisplayClass61_1 _003C_003E8__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_018b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0190: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if (num != 0)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass61_0();
					_003C_003E8__1.guild = guild;
					_003C_003E8__1.playerId = playerId;
					_003C_003E8__1.squadIds = squadIds;
				}
				try
				{
					TaskAwaiter<bool> awaiter;
					if (num != 0)
					{
						_003C_003E8__2 = new _003C_003Ec__DisplayClass61_1();
						_003C_003E8__2.CS_0024_003C_003E8__locals1 = _003C_003E8__1;
						if (_003C_003E8__2.CS_0024_003C_003E8__locals1.squadIds == null || _003C_003E8__2.CS_0024_003C_003E8__locals1.squadIds.Count != 3)
						{
							throw new InvalidDefenderSquadException(_003C_003E8__2.CS_0024_003C_003E8__locals1.guild.ID ?? "", _003C_003E8__2.CS_0024_003C_003E8__locals1.squadIds?.Count ?? 0);
						}
						if (!_003C_003E8__2.CS_0024_003C_003E8__locals1.guild.CurrentSeasonStartDate.HasValue)
						{
							throw new GuildWarException("Guild is not in active war season", _003C_003E8__2.CS_0024_003C_003E8__locals1.guild.ID);
						}
						_003C_003E8__2.guildRef = _003C_003E4__this._firestore.GetCollection("guilds").GetDocument(_003C_003E8__2.CS_0024_003C_003E8__locals1.guild.ID);
						awaiter = _003C_003E4__this._firestore.RunTransactionAsync<bool>((Func<ITransaction, bool>)delegate(ITransaction transaction)
						{
							//IL_0001: Unknown result type (might be due to invalid IL or missing references)
							//IL_0006: Unknown result type (might be due to invalid IL or missing references)
							//IL_0069: Unknown result type (might be due to invalid IL or missing references)
							//IL_006e: Unknown result type (might be due to invalid IL or missing references)
							//IL_007b: Unknown result type (might be due to invalid IL or missing references)
							//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
							//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
							//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
							//IL_010b: Unknown result type (might be due to invalid IL or missing references)
							//IL_0153: Unknown result type (might be due to invalid IL or missing references)
							DateTimeOffset utcNow = DateTimeOffset.UtcNow;
							Dictionary<string, DefenderData> defenders = _003C_003E8__2.CS_0024_003C_003E8__locals1.guild.Defenders;
							DefenderData defenderData = default(DefenderData);
							DateTimeOffset value;
							if (defenders.TryGetValue(_003C_003E8__2.CS_0024_003C_003E8__locals1.playerId, ref defenderData))
							{
								string text = _003C_003E8__2.CS_0024_003C_003E8__locals1.playerId;
								DefenderData obj = defenderData with
								{
									SquadIds = _003C_003E8__2.CS_0024_003C_003E8__locals1.squadIds
								};
								value = _003C_003E8__2.CS_0024_003C_003E8__locals1.guild.CurrentSeasonStartDate.Value;
								obj.ExpiresAt = ((DateTimeOffset)(ref value)).AddHours(8.0);
								defenders[text] = obj;
							}
							else
							{
								if (defenders.Count >= 25)
								{
									throw new MaxDefendersReachedException(_003C_003E8__2.CS_0024_003C_003E8__locals1.guild.ID ?? "", defenders.Count, 25);
								}
								string text2 = _003C_003E8__2.CS_0024_003C_003E8__locals1.playerId;
								List<string> obj2 = _003C_003E8__2.CS_0024_003C_003E8__locals1.squadIds;
								value = _003C_003E8__2.CS_0024_003C_003E8__locals1.guild.CurrentSeasonStartDate.Value;
								defenders[text2] = new DefenderData(obj2, utcNow, ((DateTimeOffset)(ref value)).AddHours(8.0), IsMainDefender: false);
							}
							transaction.UpdateData(_003C_003E8__2.guildRef, new Dictionary<object, object>
							{
								[(object)"defenders"] = ToFirestoreDefenders(defenders),
								[(object)"lastActivityAt"] = utcNow
							});
							return true;
						}).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CRegisterAsDefenderAsync_003Ed__61 _003CRegisterAsDefenderAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CRegisterAsDefenderAsync_003Ed__61>(ref awaiter, ref _003CRegisterAsDefenderAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
					}
					awaiter.GetResult();
					result = true;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine("RegisterAsDefenderAsync failed: " + _003Cex_003E5__3.Message);
					result = false;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CRejectJoinRequestAsync_003Ed__31 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string guildId;

		public string requestId;

		public string rejectedByPlayerId;

		public GuildRepository _003C_003E4__this;

		private IDocumentReference _003CrequestRef_003E5__1;

		private global::System.Exception _003Cex_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						_003CrequestRef_003E5__1 = _003C_003E4__this._firestore.GetCollection("guilds").GetDocument(guildId).GetCollection("joinRequests")
							.GetDocument(requestId);
						awaiter = _003CrequestRef_003E5__1.UpdateDataAsync(new Dictionary<object, object>
						{
							[(object)"status"] = "rejected",
							[(object)"reviewedByPlayerId"] = rejectedByPlayerId,
							[(object)"reviewedAt"] = DateTimeOffset.UtcNow
						}).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CRejectJoinRequestAsync_003Ed__31 _003CRejectJoinRequestAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CRejectJoinRequestAsync_003Ed__31>(ref awaiter, ref _003CRejectJoinRequestAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
					}
					((TaskAwaiter)(ref awaiter)).GetResult();
					result = true;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__2 = ex;
					Console.WriteLine("RejectJoinRequestAsync failed: " + _003Cex_003E5__2.Message);
					result = false;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CRemoveDefenderAsync_003Ed__48 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string guildId;

		public string playerId;

		public GuildRepository _003C_003E4__this;

		private _003C_003Ec__DisplayClass48_0 _003C_003E8__1;

		private _003C_003Ec__DisplayClass48_1 _003C_003E8__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if (num != 0)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass48_0();
					_003C_003E8__1.guildId = guildId;
					_003C_003E8__1.playerId = playerId;
				}
				try
				{
					TaskAwaiter<bool> awaiter;
					if (num != 0)
					{
						_003C_003E8__2 = new _003C_003Ec__DisplayClass48_1();
						_003C_003E8__2.CS_0024_003C_003E8__locals1 = _003C_003E8__1;
						_003C_003E8__2.guildRef = _003C_003E4__this._firestore.GetCollection("guilds").GetDocument(_003C_003E8__2.CS_0024_003C_003E8__locals1.guildId);
						awaiter = _003C_003E4__this._firestore.RunTransactionAsync<bool>((Func<ITransaction, bool>)delegate(ITransaction transaction)
						{
							//IL_0079: Unknown result type (might be due to invalid IL or missing references)
							IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(_003C_003E8__2.guildRef);
							if (document.Data == null)
							{
								throw new GuildNotFoundException(_003C_003E8__2.CS_0024_003C_003E8__locals1.guildId);
							}
							Dictionary<string, DefenderData> val = ToDomainDefenders(document.Data.Defenders);
							val.Remove(_003C_003E8__2.CS_0024_003C_003E8__locals1.playerId);
							transaction.UpdateData(_003C_003E8__2.guildRef, new Dictionary<object, object>
							{
								[(object)"defenders"] = ToFirestoreDefenders(val),
								[(object)"lastActivityAt"] = DateTimeOffset.UtcNow
							});
							return true;
						}).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CRemoveDefenderAsync_003Ed__48 _003CRemoveDefenderAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CRemoveDefenderAsync_003Ed__48>(ref awaiter, ref _003CRemoveDefenderAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
					}
					awaiter.GetResult();
					result = true;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine("RemoveDefenderAsync failed: " + _003Cex_003E5__3.Message);
					result = false;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CRemoveExpiredDefendersAsync_003Ed__60 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<int> _003C_003Et__builder;

		public string guildId;

		public GuildRepository _003C_003E4__this;

		private _003C_003Ec__DisplayClass60_0 _003C_003E8__1;

		private global::System.Exception _003Cex_003E5__2;

		private TaskAwaiter<int> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			int result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<int> awaiter;
					if (num != 0)
					{
						_003C_003E8__1 = new _003C_003Ec__DisplayClass60_0();
						_003C_003E8__1.guildRef = _003C_003E4__this._firestore.GetCollection("guilds").GetDocument(guildId);
						_003C_003E8__1.removedCount = 0;
						awaiter = _003C_003E4__this._firestore.RunTransactionAsync<int>((Func<ITransaction, int>)delegate(ITransaction transaction)
						{
							//IL_0040: Unknown result type (might be due to invalid IL or missing references)
							//IL_0045: Unknown result type (might be due to invalid IL or missing references)
							//IL_0088: Unknown result type (might be due to invalid IL or missing references)
							//IL_008d: Unknown result type (might be due to invalid IL or missing references)
							//IL_010e: Unknown result type (might be due to invalid IL or missing references)
							_003C_003Ec__DisplayClass60_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass60_1();
							IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(_003C_003E8__1.guildRef);
							if (document.Data == null)
							{
								throw new global::System.Exception("Guild not found");
							}
							Dictionary<string, DefenderData> val = ToDomainDefenders(document.Data.Defenders);
							CS_0024_003C_003E8__locals0.now = DateTimeOffset.UtcNow;
							List<string> val2 = Enumerable.ToList<string>(Enumerable.Select<KeyValuePair<string, DefenderData>, string>(Enumerable.Where<KeyValuePair<string, DefenderData>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, DefenderData>>)val, (Func<KeyValuePair<string, DefenderData>, bool>)((KeyValuePair<string, DefenderData> kv) => kv.Value.ExpiresAt <= CS_0024_003C_003E8__locals0.now)), (Func<KeyValuePair<string, DefenderData>, string>)((KeyValuePair<string, DefenderData> kv) => kv.Key)));
							Enumerator<string> enumerator = val2.GetEnumerator();
							try
							{
								while (enumerator.MoveNext())
								{
									string current = enumerator.Current;
									val.Remove(current);
									_003C_003E8__1.removedCount++;
								}
							}
							finally
							{
								((global::System.IDisposable)enumerator).Dispose();
							}
							if (_003C_003E8__1.removedCount > 0)
							{
								transaction.UpdateData(_003C_003E8__1.guildRef, new Dictionary<object, object>
								{
									[(object)"defenders"] = ToFirestoreDefenders(val),
									[(object)"lastActivityAt"] = CS_0024_003C_003E8__locals0.now
								});
							}
							return _003C_003E8__1.removedCount;
						}).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CRemoveExpiredDefendersAsync_003Ed__60 _003CRemoveExpiredDefendersAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<int>, _003CRemoveExpiredDefendersAsync_003Ed__60>(ref awaiter, ref _003CRemoveExpiredDefendersAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<int>);
						num = (_003C_003E1__state = -1);
					}
					awaiter.GetResult();
					result = _003C_003E8__1.removedCount;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__2 = ex;
					Console.WriteLine("RemoveExpiredDefendersAsync failed: " + _003Cex_003E5__2.Message);
					result = 0;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CSearchGuildsAsync_003Ed__26 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<List<GuildSearchResult>> _003C_003Et__builder;

		public string searchText;

		public GuildSearchFilters filters;

		public int playerLevel;

		public long playerTrophies;

		public int limit;

		public GuildRepository _003C_003E4__this;

		private _003C_003Ec__DisplayClass26_0 _003C_003E8__1;

		private IQuery _003Cquery_003E5__2;

		private IQuerySnapshot<FirestoreGuildDTO> _003Csnapshot_003E5__3;

		private List<FirestoreGuildDTO> _003Cguilds_003E5__4;

		private global::System.Collections.Generic.IEnumerable<FirestoreGuildDTO> _003CfilteredGuilds_003E5__5;

		private List<GuildSearchResult> _003Cresults_003E5__6;

		private IQuerySnapshot<FirestoreGuildDTO> _003C_003Es__7;

		private global::System.Exception _003Cex_003E5__8;

		private TaskAwaiter<IQuerySnapshot<FirestoreGuildDTO>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			List<GuildSearchResult> result;
			try
			{
				if (num != 0)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass26_0();
					_003C_003E8__1.searchText = searchText;
					_003C_003E8__1.filters = filters;
					_003C_003E8__1.playerLevel = playerLevel;
					_003C_003E8__1.playerTrophies = playerTrophies;
				}
				try
				{
					TaskAwaiter<IQuerySnapshot<FirestoreGuildDTO>> awaiter;
					if (num != 0)
					{
						_003Cquery_003E5__2 = ((IQuery)_003C_003E4__this._firestore.GetCollection("guilds")).WhereEqualsTo("isPublic", (object)true).OrderBy("memberCount", false).LimitedTo(limit);
						awaiter = _003Cquery_003E5__2.GetDocumentsAsync<FirestoreGuildDTO>((Source)0).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CSearchGuildsAsync_003Ed__26 _003CSearchGuildsAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IQuerySnapshot<FirestoreGuildDTO>>, _003CSearchGuildsAsync_003Ed__26>(ref awaiter, ref _003CSearchGuildsAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IQuerySnapshot<FirestoreGuildDTO>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__7 = awaiter.GetResult();
					_003Csnapshot_003E5__3 = _003C_003Es__7;
					_003C_003Es__7 = null;
					_003Cguilds_003E5__4 = Enumerable.ToList<FirestoreGuildDTO>(Enumerable.Where<FirestoreGuildDTO>(Enumerable.Select<IDocumentSnapshot<FirestoreGuildDTO>, FirestoreGuildDTO>(_003Csnapshot_003E5__3.Documents, (Func<IDocumentSnapshot<FirestoreGuildDTO>, FirestoreGuildDTO>)((IDocumentSnapshot<FirestoreGuildDTO> d) => d.Data)), (Func<FirestoreGuildDTO, bool>)((FirestoreGuildDTO g) => g != null)));
					_003CfilteredGuilds_003E5__5 = Enumerable.AsEnumerable<FirestoreGuildDTO>((global::System.Collections.Generic.IEnumerable<FirestoreGuildDTO>)_003Cguilds_003E5__4);
					if (!string.IsNullOrEmpty(_003C_003E8__1.searchText))
					{
						_003CfilteredGuilds_003E5__5 = Enumerable.Where<FirestoreGuildDTO>(_003CfilteredGuilds_003E5__5, (Func<FirestoreGuildDTO, bool>)((FirestoreGuildDTO g) => g.Name?.Contains(_003C_003E8__1.searchText, (StringComparison)5) ?? false));
					}
					if (_003C_003E8__1.filters != null)
					{
						if (_003C_003E8__1.filters.MinMembers.HasValue)
						{
							_003CfilteredGuilds_003E5__5 = Enumerable.Where<FirestoreGuildDTO>(_003CfilteredGuilds_003E5__5, (Func<FirestoreGuildDTO, bool>)((FirestoreGuildDTO g) => g.MemberCount >= _003C_003E8__1.filters.MinMembers.Value));
						}
						if (_003C_003E8__1.filters.MaxMembers.HasValue)
						{
							_003CfilteredGuilds_003E5__5 = Enumerable.Where<FirestoreGuildDTO>(_003CfilteredGuilds_003E5__5, (Func<FirestoreGuildDTO, bool>)((FirestoreGuildDTO g) => g.MemberCount <= _003C_003E8__1.filters.MaxMembers.Value));
						}
						if (_003C_003E8__1.filters.MinTrophies.HasValue)
						{
							_003CfilteredGuilds_003E5__5 = Enumerable.Where<FirestoreGuildDTO>(_003CfilteredGuilds_003E5__5, (Func<FirestoreGuildDTO, bool>)((FirestoreGuildDTO g) => g.Trophies >= _003C_003E8__1.filters.MinTrophies.Value));
						}
						if (_003C_003E8__1.filters.MaxTrophies.HasValue)
						{
							_003CfilteredGuilds_003E5__5 = Enumerable.Where<FirestoreGuildDTO>(_003CfilteredGuilds_003E5__5, (Func<FirestoreGuildDTO, bool>)((FirestoreGuildDTO g) => g.Trophies <= _003C_003E8__1.filters.MaxTrophies.Value));
						}
						if (_003C_003E8__1.filters.IsPublic.HasValue)
						{
							_003CfilteredGuilds_003E5__5 = Enumerable.Where<FirestoreGuildDTO>(_003CfilteredGuilds_003E5__5, (Func<FirestoreGuildDTO, bool>)((FirestoreGuildDTO g) => g.IsPublic == _003C_003E8__1.filters.IsPublic.Value));
						}
						if (_003C_003E8__1.filters.MinLevel.HasValue)
						{
							_003CfilteredGuilds_003E5__5 = Enumerable.Where<FirestoreGuildDTO>(_003CfilteredGuilds_003E5__5, (Func<FirestoreGuildDTO, bool>)((FirestoreGuildDTO g) => g.Level >= _003C_003E8__1.filters.MinLevel.Value));
						}
						if (_003C_003E8__1.filters.MaxLevel.HasValue)
						{
							_003CfilteredGuilds_003E5__5 = Enumerable.Where<FirestoreGuildDTO>(_003CfilteredGuilds_003E5__5, (Func<FirestoreGuildDTO, bool>)((FirestoreGuildDTO g) => g.Level <= _003C_003E8__1.filters.MaxLevel.Value));
						}
					}
					_003Cresults_003E5__6 = Enumerable.ToList<GuildSearchResult>(Enumerable.Select<FirestoreGuildDTO, GuildSearchResult>(_003CfilteredGuilds_003E5__5, (Func<FirestoreGuildDTO, GuildSearchResult>)((FirestoreGuildDTO g) => new GuildSearchResult
					{
						GuildId = (g.ID ?? string.Empty),
						Name = (g.Name ?? "Unknown"),
						Emblem = (g.Emblem ?? "\ud83d\udc51"),
						Rank = g.Rank,
						Level = g.Level,
						MemberCount = g.MemberCount,
						MaxMembers = g.MaxMembers,
						Trophies = g.Trophies,
						IsPublic = g.IsPublic,
						RequiresApproval = g.RequiresApproval,
						MinLevelRequired = g.MinLevelRequired,
						MinTrophiesRequired = g.MinTrophiesRequired,
						CanJoin = (_003C_003E8__1.playerLevel >= g.MinLevelRequired && _003C_003E8__1.playerTrophies >= g.MinTrophiesRequired && g.MemberCount < g.MaxMembers)
					})));
					result = _003Cresults_003E5__6;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__8 = ex;
					Console.WriteLine("SearchGuildsAsync failed: " + _003Cex_003E5__8.Message);
					result = new List<GuildSearchResult>();
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CSendGuildInvitationAsync_003Ed__33 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string guildId;

		public string targetPlayerId;

		public string invitedByPlayerId;

		public GuildRepository _003C_003E4__this;

		private IDocumentSnapshot<FirestoreGuildDTO> _003CguildDoc_003E5__1;

		private IDocumentSnapshot<FirestorePlayerDTO> _003CinviterDoc_003E5__2;

		private IDocumentSnapshot<FirestoreGuildDTO> _003C_003Es__3;

		private IDocumentSnapshot<FirestorePlayerDTO> _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter<IDocumentSnapshot<FirestoreGuildDTO>> _003C_003Eu__1;

		private TaskAwaiter<IDocumentSnapshot<FirestorePlayerDTO>> _003C_003Eu__2;

		private TaskAwaiter _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0129: Unknown result type (might be due to invalid IL or missing references)
			//IL_012e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0136: Unknown result type (might be due to invalid IL or missing references)
			//IL_0284: Unknown result type (might be due to invalid IL or missing references)
			//IL_0289: Unknown result type (might be due to invalid IL or missing references)
			//IL_0291: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_010c: Unknown result type (might be due to invalid IL or missing references)
			//IL_021b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0220: Unknown result type (might be due to invalid IL or missing references)
			//IL_022d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0232: Unknown result type (might be due to invalid IL or missing references)
			//IL_024b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0250: Unknown result type (might be due to invalid IL or missing references)
			//IL_0265: Unknown result type (might be due to invalid IL or missing references)
			//IL_0267: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if ((uint)num > 2u)
				{
				}
				try
				{
					TaskAwaiter<IDocumentSnapshot<FirestoreGuildDTO>> awaiter3;
					TaskAwaiter<IDocumentSnapshot<FirestorePlayerDTO>> awaiter2;
					TaskAwaiter awaiter;
					switch (num)
					{
					default:
						awaiter3 = _003C_003E4__this._firestore.GetCollection("guilds").GetDocument(guildId).GetDocumentSnapshotAsync<FirestoreGuildDTO>((Source)0)
							.GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter3;
							_003CSendGuildInvitationAsync_003Ed__33 _003CSendGuildInvitationAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IDocumentSnapshot<FirestoreGuildDTO>>, _003CSendGuildInvitationAsync_003Ed__33>(ref awaiter3, ref _003CSendGuildInvitationAsync_003Ed__);
							return;
						}
						goto IL_00aa;
					case 0:
						awaiter3 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IDocumentSnapshot<FirestoreGuildDTO>>);
						num = (_003C_003E1__state = -1);
						goto IL_00aa;
					case 1:
						awaiter2 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<IDocumentSnapshot<FirestorePlayerDTO>>);
						num = (_003C_003E1__state = -1);
						goto IL_0145;
					case 2:
						{
							awaiter = _003C_003Eu__3;
							_003C_003Eu__3 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							break;
						}
						IL_0145:
						_003C_003Es__4 = awaiter2.GetResult();
						_003CinviterDoc_003E5__2 = _003C_003Es__4;
						_003C_003Es__4 = null;
						if (_003CguildDoc_003E5__1.Data != null && _003CinviterDoc_003E5__2.Data != null)
						{
							IPlayerNotificationService notificationService = _003C_003E4__this._notificationService;
							string text = targetPlayerId;
							Dictionary<string, object> obj = new Dictionary<string, object>
							{
								["guildId"] = guildId,
								["guildName"] = _003CguildDoc_003E5__1.Data.Name ?? string.Empty,
								["invitedByPlayerId"] = invitedByPlayerId,
								["invitedByPlayerName"] = _003CinviterDoc_003E5__2.Data.Playername ?? string.Empty
							};
							DateTimeOffset val = DateTimeOffset.UtcNow;
							val = ((DateTimeOffset)(ref val)).AddDays(7.0);
							obj["expiresAt"] = ((DateTimeOffset)(ref val)).ToString("O");
							awaiter = notificationService.SendAsync(text, NotificationType.GuildInvitation, obj).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__3 = awaiter;
								_003CSendGuildInvitationAsync_003Ed__33 _003CSendGuildInvitationAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CSendGuildInvitationAsync_003Ed__33>(ref awaiter, ref _003CSendGuildInvitationAsync_003Ed__);
								return;
							}
							break;
						}
						result = false;
						goto end_IL_0011;
						IL_00aa:
						_003C_003Es__3 = awaiter3.GetResult();
						_003CguildDoc_003E5__1 = _003C_003Es__3;
						_003C_003Es__3 = null;
						awaiter2 = _003C_003E4__this._firestore.GetCollection("players").GetDocument(invitedByPlayerId).GetDocumentSnapshotAsync<FirestorePlayerDTO>((Source)0)
							.GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter2;
							_003CSendGuildInvitationAsync_003Ed__33 _003CSendGuildInvitationAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IDocumentSnapshot<FirestorePlayerDTO>>, _003CSendGuildInvitationAsync_003Ed__33>(ref awaiter2, ref _003CSendGuildInvitationAsync_003Ed__);
							return;
						}
						goto IL_0145;
					}
					((TaskAwaiter)(ref awaiter)).GetResult();
					result = true;
					end_IL_0011:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__5 = ex;
					Console.WriteLine("SendGuildInvitationAsync failed: " + _003Cex_003E5__5.Message);
					result = false;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CSendJoinRequestAsync_003Ed__29 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string playerId;

		public string guildId;

		public string message;

		public GuildRepository _003C_003E4__this;

		private _003C_003Ec__DisplayClass29_0 _003C_003E8__1;

		private _003C_003Ec__DisplayClass29_1 _003C_003E8__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0148: Unknown result type (might be due to invalid IL or missing references)
			//IL_014d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if (num != 0)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass29_0();
					_003C_003E8__1.playerId = playerId;
					_003C_003E8__1.guildId = guildId;
					_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
					_003C_003E8__1.message = message;
				}
				try
				{
					TaskAwaiter<bool> awaiter;
					if (num != 0)
					{
						_003C_003E8__2 = new _003C_003Ec__DisplayClass29_1();
						_003C_003E8__2.CS_0024_003C_003E8__locals1 = _003C_003E8__1;
						_003C_003E8__2.playerRef = _003C_003E4__this._firestore.GetCollection("players").GetDocument(_003C_003E8__2.CS_0024_003C_003E8__locals1.playerId);
						_003C_003E8__2.guildRef = _003C_003E4__this._firestore.GetCollection("guilds").GetDocument(_003C_003E8__2.CS_0024_003C_003E8__locals1.guildId);
						awaiter = _003C_003E4__this._firestore.RunTransactionAsync<bool>((Func<ITransaction, bool>)delegate(ITransaction transaction)
						{
							//IL_0037: Unknown result type (might be due to invalid IL or missing references)
							//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
							IDocumentSnapshot<FirestorePlayerDTO> document = transaction.GetDocument<FirestorePlayerDTO>(_003C_003E8__2.playerRef);
							if (document.Data == null)
							{
								throw new ArgumentException("Player '" + _003C_003E8__2.CS_0024_003C_003E8__locals1.playerId + "' not found");
							}
							if (!string.IsNullOrEmpty(document.Data.GuildId))
							{
								throw new AlreadyInGuildException(_003C_003E8__2.CS_0024_003C_003E8__locals1.playerId, document.Data.GuildId);
							}
							IDocumentSnapshot<FirestoreGuildDTO> document2 = transaction.GetDocument<FirestoreGuildDTO>(_003C_003E8__2.guildRef);
							if (document2.Data == null)
							{
								throw new GuildNotFoundException(_003C_003E8__2.CS_0024_003C_003E8__locals1.guildId);
							}
							if (document2.Data.MemberCount >= document2.Data.MaxMembers)
							{
								throw new GuildFullException(_003C_003E8__2.CS_0024_003C_003E8__locals1.guildId, document2.Data.MemberCount, document2.Data.MaxMembers);
							}
							IDocumentReference val = _003C_003E8__2.CS_0024_003C_003E8__locals1._003C_003E4__this._firestore.GetCollection("guilds").GetDocument(_003C_003E8__2.CS_0024_003C_003E8__locals1.guildId).GetCollection("joinRequests")
								.CreateDocument();
							FirestoreGuildJoinRequestDTO obj = new FirestoreGuildJoinRequestDTO
							{
								ID = val.Id,
								PlayerId = _003C_003E8__2.CS_0024_003C_003E8__locals1.playerId,
								PlayerName = document.Data.Playername,
								PlayerLevel = document.Data.PlayerLevel
							};
							Dictionary<string, long>? currencies = document.Data.Currencies;
							obj.PlayerTrophies = (int)((currencies != null) ? CollectionExtensions.GetValueOrDefault<string, long>((IReadOnlyDictionary<string, long>)(object)currencies, "reputation", 0L) : 0);
							obj.Message = _003C_003E8__2.CS_0024_003C_003E8__locals1.message;
							obj.Status = "Pending";
							obj.CreatedAt = DateTimeOffset.UtcNow;
							FirestoreGuildJoinRequestDTO firestoreGuildJoinRequestDTO = obj;
							transaction.SetData(val, (object)firestoreGuildJoinRequestDTO, (SetOptions)null);
							return true;
						}).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CSendJoinRequestAsync_003Ed__29 _003CSendJoinRequestAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CSendJoinRequestAsync_003Ed__29>(ref awaiter, ref _003CSendJoinRequestAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
					}
					awaiter.GetResult();
					result = true;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine("SendJoinRequestAsync failed: " + _003Cex_003E5__3.Message);
					result = false;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CSendNotificationToPlayerAsync_003Ed__66 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string targetPlayerId;

		public NotificationType type;

		public Dictionary<string, object> data;

		public GuildRepository _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = _003C_003E4__this._notificationService.SendAsync(targetPlayerId, type, data).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CSendNotificationToPlayerAsync_003Ed__66 _003CSendNotificationToPlayerAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSendNotificationToPlayerAsync_003Ed__66>(ref awaiter, ref _003CSendNotificationToPlayerAsync_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
				}
				((TaskAwaiter)(ref awaiter)).GetResult();
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CSetDefenderDowntimeAndBreakAsync_003Ed__55 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string defendingGuildId;

		public string defenderPlayerId;

		public DateTimeOffset downtimeEnds;

		public GuildRepository _003C_003E4__this;

		private _003C_003Ec__DisplayClass55_0 _003C_003E8__1;

		private _003C_003Ec__DisplayClass55_1 _003C_003E8__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num != 0)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass55_0();
					_003C_003E8__1.defenderPlayerId = defenderPlayerId;
					_003C_003E8__1.downtimeEnds = downtimeEnds;
				}
				try
				{
					TaskAwaiter<bool> awaiter;
					if (num != 0)
					{
						_003C_003E8__2 = new _003C_003Ec__DisplayClass55_1();
						_003C_003E8__2.CS_0024_003C_003E8__locals1 = _003C_003E8__1;
						_003C_003E8__2.guildRef = _003C_003E4__this._firestore.GetCollection("guilds").GetDocument(defendingGuildId);
						awaiter = _003C_003E4__this._firestore.RunTransactionAsync<bool>((Func<ITransaction, bool>)delegate(ITransaction transaction)
						{
							//IL_0085: Unknown result type (might be due to invalid IL or missing references)
							//IL_009c: Unknown result type (might be due to invalid IL or missing references)
							//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
							//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
							_003C_003Ec__DisplayClass55_2 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass55_2();
							IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(_003C_003E8__2.guildRef);
							if (document.Data?.Defenders == null)
							{
								return false;
							}
							Dictionary<string, DefenderData> val = ToDomainDefenders(document.Data.Defenders);
							DefenderData defenderData = default(DefenderData);
							if (!val.TryGetValue(_003C_003E8__2.CS_0024_003C_003E8__locals1.defenderPlayerId, ref defenderData))
							{
								return false;
							}
							val[_003C_003E8__2.CS_0024_003C_003E8__locals1.defenderPlayerId] = defenderData with
							{
								DowntimeEnds = _003C_003E8__2.CS_0024_003C_003E8__locals1.downtimeEnds
							};
							CS_0024_003C_003E8__locals0.now = DateTimeOffset.UtcNow;
							bool flag = Enumerable.Any<DefenderData>((global::System.Collections.Generic.IEnumerable<DefenderData>)val.Values, (Func<DefenderData, bool>)((DefenderData d) => d.ExpiresAt > CS_0024_003C_003E8__locals0.now && (!d.DowntimeEnds.HasValue || !(d.DowntimeEnds.Value > CS_0024_003C_003E8__locals0.now))));
							Dictionary<object, object> val2 = new Dictionary<object, object> { [(object)"defenders"] = ToFirestoreDefenders(val) };
							if (!flag)
							{
								val2[(object)"guildBreakEndsAt"] = ((DateTimeOffset)(ref CS_0024_003C_003E8__locals0.now)).AddMinutes(30.0);
							}
							transaction.UpdateData(_003C_003E8__2.guildRef, val2);
							return true;
						}).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CSetDefenderDowntimeAndBreakAsync_003Ed__55 _003CSetDefenderDowntimeAndBreakAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CSetDefenderDowntimeAndBreakAsync_003Ed__55>(ref awaiter, ref _003CSetDefenderDowntimeAndBreakAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
					}
					awaiter.GetResult();
					_003C_003E8__2 = null;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine("SetDefenderDowntimeAndBreakAsync failed: " + _003Cex_003E5__3.Message);
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CSetDisbandScheduleAsync_003Ed__40 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string guildId;

		public DateTimeOffset? disbandAt;

		public GuildRepository _003C_003E4__this;

		private IDocumentReference _003CguildRef_003E5__1;

		private global::System.Exception _003Cex_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						_003CguildRef_003E5__1 = _003C_003E4__this._firestore.GetCollection("guilds").GetDocument(guildId);
						IDocumentReference obj = _003CguildRef_003E5__1;
						Dictionary<object, object> obj2 = new Dictionary<object, object>();
						object obj3 = "disbandScheduledAt";
						DateTimeOffset? val = disbandAt;
						obj2[obj3] = (val.HasValue ? ((object)val.GetValueOrDefault()) : null);
						awaiter = obj.UpdateDataAsync(obj2).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CSetDisbandScheduleAsync_003Ed__40 _003CSetDisbandScheduleAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CSetDisbandScheduleAsync_003Ed__40>(ref awaiter, ref _003CSetDisbandScheduleAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
					}
					((TaskAwaiter)(ref awaiter)).GetResult();
					result = true;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__2 = ex;
					Console.WriteLine("SetDisbandScheduleAsync failed: " + _003Cex_003E5__2.Message);
					result = false;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CSetMainDefendersAsync_003Ed__50 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string guildId;

		public List<string> mainDefenderPlayerIds;

		public GuildRepository _003C_003E4__this;

		private _003C_003Ec__DisplayClass50_0 _003C_003E8__1;

		private _003C_003Ec__DisplayClass50_1 _003C_003E8__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_014b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0150: Unknown result type (might be due to invalid IL or missing references)
			//IL_0158: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_012d: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if (num != 0)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass50_0();
					_003C_003E8__1.mainDefenderPlayerIds = mainDefenderPlayerIds;
				}
				try
				{
					TaskAwaiter<bool> awaiter;
					if (num == 0)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
						goto IL_0167;
					}
					_003C_003E8__2 = new _003C_003Ec__DisplayClass50_1();
					_003C_003E8__2.CS_0024_003C_003E8__locals1 = _003C_003E8__1;
					if (_003C_003E8__2.CS_0024_003C_003E8__locals1.mainDefenderPlayerIds != null && _003C_003E8__2.CS_0024_003C_003E8__locals1.mainDefenderPlayerIds.Count <= 5)
					{
						_003C_003E8__2.guildRef = _003C_003E4__this._firestore.GetCollection("guilds").GetDocument(guildId);
						awaiter = _003C_003E4__this._firestore.RunTransactionAsync<bool>((Func<ITransaction, bool>)delegate(ITransaction transaction)
						{
							//IL_007e: Unknown result type (might be due to invalid IL or missing references)
							//IL_0083: Unknown result type (might be due to invalid IL or missing references)
							//IL_0132: Unknown result type (might be due to invalid IL or missing references)
							_003C_003Ec__DisplayClass50_2 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass50_2();
							IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(_003C_003E8__2.guildRef);
							if (document.Data == null)
							{
								throw new global::System.Exception("Guild not found");
							}
							CS_0024_003C_003E8__locals0.defenders = ToDomainDefenders(document.Data.Defenders);
							if (Enumerable.Any<string>((global::System.Collections.Generic.IEnumerable<string>)_003C_003E8__2.CS_0024_003C_003E8__locals1.mainDefenderPlayerIds, (Func<string, bool>)((string id) => !CS_0024_003C_003E8__locals0.defenders.ContainsKey(id))))
							{
								throw new global::System.Exception("All main defenders must be signed up defenders");
							}
							Enumerator<string> enumerator = Enumerable.ToList<string>((global::System.Collections.Generic.IEnumerable<string>)CS_0024_003C_003E8__locals0.defenders.Keys).GetEnumerator();
							try
							{
								while (enumerator.MoveNext())
								{
									string current = enumerator.Current;
									DefenderData defenderData = CS_0024_003C_003E8__locals0.defenders[current];
									bool flag = _003C_003E8__2.CS_0024_003C_003E8__locals1.mainDefenderPlayerIds.Contains(current);
									if (defenderData.IsMainDefender != flag)
									{
										CS_0024_003C_003E8__locals0.defenders[current] = defenderData with
										{
											IsMainDefender = flag
										};
									}
								}
							}
							finally
							{
								((global::System.IDisposable)enumerator).Dispose();
							}
							transaction.UpdateData(_003C_003E8__2.guildRef, new Dictionary<object, object>
							{
								[(object)"defenders"] = ToFirestoreDefenders(CS_0024_003C_003E8__locals0.defenders),
								[(object)"lastActivityAt"] = DateTimeOffset.UtcNow
							});
							return true;
						}).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CSetMainDefendersAsync_003Ed__50 _003CSetMainDefendersAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CSetMainDefendersAsync_003Ed__50>(ref awaiter, ref _003CSetMainDefendersAsync_003Ed__);
							return;
						}
						goto IL_0167;
					}
					Console.WriteLine($"Main defenders must be {5} or fewer");
					result = false;
					goto end_IL_002c;
					IL_0167:
					awaiter.GetResult();
					result = true;
					end_IL_002c:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine("SetMainDefendersAsync failed: " + _003Cex_003E5__3.Message);
					result = false;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CSetWarEnrollmentAsync_003Ed__39 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string guildId;

		public bool isOpenToWar;

		public GuildRepository _003C_003E4__this;

		private IDocumentReference _003CguildRef_003E5__1;

		private global::System.Exception _003Cex_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						_003CguildRef_003E5__1 = _003C_003E4__this._firestore.GetCollection("guilds").GetDocument(guildId);
						awaiter = _003CguildRef_003E5__1.UpdateDataAsync(new Dictionary<object, object>
						{
							[(object)"isOpenToWar"] = isOpenToWar,
							[(object)"lastActivityAt"] = DateTimeOffset.UtcNow
						}).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CSetWarEnrollmentAsync_003Ed__39 _003CSetWarEnrollmentAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CSetWarEnrollmentAsync_003Ed__39>(ref awaiter, ref _003CSetWarEnrollmentAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
					}
					((TaskAwaiter)(ref awaiter)).GetResult();
					result = true;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__2 = ex;
					Console.WriteLine("SetWarEnrollmentAsync failed: " + _003Cex_003E5__2.Message);
					result = false;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CSignUpAsDefenderAsync_003Ed__47 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string guildId;

		public string playerId;

		public List<string> defenderSquad;

		public GuildRepository _003C_003E4__this;

		private _003C_003Ec__DisplayClass47_0 _003C_003E8__1;

		private _003C_003Ec__DisplayClass47_1 _003C_003E8__2;

		private int _003CactualSize_003E5__3;

		private global::System.Exception _003Cex_003E5__4;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0171: Unknown result type (might be due to invalid IL or missing references)
			//IL_0176: Unknown result type (might be due to invalid IL or missing references)
			//IL_017d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0139: Unknown result type (might be due to invalid IL or missing references)
			//IL_013e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0152: Unknown result type (might be due to invalid IL or missing references)
			//IL_0153: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if (num != 0)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass47_0();
					_003C_003E8__1.guildId = guildId;
					_003C_003E8__1.playerId = playerId;
					_003C_003E8__1.defenderSquad = defenderSquad;
				}
				try
				{
					TaskAwaiter<bool> awaiter;
					if (num != 0)
					{
						_003C_003E8__2 = new _003C_003Ec__DisplayClass47_1();
						_003C_003E8__2.CS_0024_003C_003E8__locals1 = _003C_003E8__1;
						List<string> obj = _003C_003E8__2.CS_0024_003C_003E8__locals1.defenderSquad;
						_003CactualSize_003E5__3 = ((obj != null) ? Enumerable.Count<string>((global::System.Collections.Generic.IEnumerable<string>)obj, (Func<string, bool>)((string s) => !string.IsNullOrEmpty(s))) : 0);
						if (_003CactualSize_003E5__3 != 3)
						{
							throw new InvalidDefenderSquadException(_003C_003E8__2.CS_0024_003C_003E8__locals1.guildId, _003CactualSize_003E5__3);
						}
						_003C_003E8__2.guildRef = _003C_003E4__this._firestore.GetCollection("guilds").GetDocument(_003C_003E8__2.CS_0024_003C_003E8__locals1.guildId);
						awaiter = _003C_003E4__this._firestore.RunTransactionAsync<bool>((Func<ITransaction, bool>)delegate(ITransaction transaction)
						{
							//IL_003f: Unknown result type (might be due to invalid IL or missing references)
							//IL_0044: Unknown result type (might be due to invalid IL or missing references)
							//IL_008f: Unknown result type (might be due to invalid IL or missing references)
							//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
							//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
							//IL_013b: Unknown result type (might be due to invalid IL or missing references)
							IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(_003C_003E8__2.guildRef);
							if (document.Data == null)
							{
								throw new GuildNotFoundException(_003C_003E8__2.CS_0024_003C_003E8__locals1.guildId);
							}
							Dictionary<string, DefenderData> val = ToDomainDefenders(document.Data.Defenders);
							DateTimeOffset utcNow = DateTimeOffset.UtcNow;
							DefenderData defenderData = default(DefenderData);
							if (val.TryGetValue(_003C_003E8__2.CS_0024_003C_003E8__locals1.playerId, ref defenderData))
							{
								val[_003C_003E8__2.CS_0024_003C_003E8__locals1.playerId] = defenderData with
								{
									SquadIds = _003C_003E8__2.CS_0024_003C_003E8__locals1.defenderSquad,
									ExpiresAt = ((DateTimeOffset)(ref utcNow)).AddHours(8.0)
								};
							}
							else
							{
								if (val.Count >= 25)
								{
									throw new MaxDefendersReachedException(_003C_003E8__2.CS_0024_003C_003E8__locals1.guildId, val.Count, 25);
								}
								val[_003C_003E8__2.CS_0024_003C_003E8__locals1.playerId] = new DefenderData(_003C_003E8__2.CS_0024_003C_003E8__locals1.defenderSquad, utcNow, ((DateTimeOffset)(ref utcNow)).AddHours(8.0), IsMainDefender: false);
							}
							transaction.UpdateData(_003C_003E8__2.guildRef, new Dictionary<object, object>
							{
								[(object)"defenders"] = ToFirestoreDefenders(val),
								[(object)"lastActivityAt"] = utcNow
							});
							return true;
						}).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CSignUpAsDefenderAsync_003Ed__47 _003CSignUpAsDefenderAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CSignUpAsDefenderAsync_003Ed__47>(ref awaiter, ref _003CSignUpAsDefenderAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
					}
					awaiter.GetResult();
					result = true;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__4 = ex;
					Console.WriteLine("SignUpAsDefenderAsync failed: " + _003Cex_003E5__4.Message);
					result = false;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CSpendGuildCoinsAsync_003Ed__42 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string guildId;

		public int coinsAmount;

		public GuildRepository _003C_003E4__this;

		private _003C_003Ec__DisplayClass42_0 _003C_003E8__1;

		private _003C_003Ec__DisplayClass42_1 _003C_003E8__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if (num != 0)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass42_0();
					_003C_003E8__1.coinsAmount = coinsAmount;
				}
				try
				{
					TaskAwaiter<bool> awaiter;
					if (num != 0)
					{
						_003C_003E8__2 = new _003C_003Ec__DisplayClass42_1();
						_003C_003E8__2.CS_0024_003C_003E8__locals1 = _003C_003E8__1;
						_003C_003E8__2.guildRef = _003C_003E4__this._firestore.GetCollection("guilds").GetDocument(guildId);
						awaiter = _003C_003E4__this._firestore.RunTransactionAsync<bool>((Func<ITransaction, bool>)delegate(ITransaction transaction)
						{
							//IL_0091: Unknown result type (might be due to invalid IL or missing references)
							IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(_003C_003E8__2.guildRef);
							if (document.Data == null)
							{
								throw new global::System.Exception("Guild not found");
							}
							if (document.Data.GuildCoins < _003C_003E8__2.CS_0024_003C_003E8__locals1.coinsAmount)
							{
								throw new global::System.Exception("Insufficient guild coins");
							}
							int num2 = document.Data.GuildCoins - _003C_003E8__2.CS_0024_003C_003E8__locals1.coinsAmount;
							transaction.UpdateData(_003C_003E8__2.guildRef, new Dictionary<object, object>
							{
								[(object)"guildCoins"] = num2,
								[(object)"lastActivityAt"] = DateTimeOffset.UtcNow
							});
							return true;
						}).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CSpendGuildCoinsAsync_003Ed__42 _003CSpendGuildCoinsAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CSpendGuildCoinsAsync_003Ed__42>(ref awaiter, ref _003CSpendGuildCoinsAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
					}
					awaiter.GetResult();
					result = true;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine("SpendGuildCoinsAsync failed: " + _003Cex_003E5__3.Message);
					result = false;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CTransferLeadershipAsync_003Ed__22 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string guildId;

		public string newLeaderId;

		public string currentLeaderId;

		public GuildRepository _003C_003E4__this;

		private _003C_003Ec__DisplayClass22_0 _003C_003E8__1;

		private _003C_003Ec__DisplayClass22_1 _003C_003E8__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter<object> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_013c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0141: Unknown result type (might be due to invalid IL or missing references)
			//IL_0148: Unknown result type (might be due to invalid IL or missing references)
			//IL_0252: Unknown result type (might be due to invalid IL or missing references)
			//IL_0257: Unknown result type (might be due to invalid IL or missing references)
			//IL_025f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0219: Unknown result type (might be due to invalid IL or missing references)
			//IL_021e: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_011f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0233: Unknown result type (might be due to invalid IL or missing references)
			//IL_0235: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if ((uint)num > 1u)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass22_0();
					_003C_003E8__1.newLeaderId = newLeaderId;
				}
				try
				{
					TaskAwaiter awaiter;
					TaskAwaiter<object> awaiter2;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_026e;
						}
						_003C_003E8__2 = new _003C_003Ec__DisplayClass22_1();
						_003C_003E8__2.CS_0024_003C_003E8__locals1 = _003C_003E8__1;
						_003C_003E8__2.guildRef = _003C_003E4__this._firestore.GetCollection("guilds").GetDocument(guildId);
						_003C_003E8__2.newLeaderMemberRef = _003C_003E4__this.GetMemberRef(guildId, _003C_003E8__2.CS_0024_003C_003E8__locals1.newLeaderId);
						_003C_003E8__2.oldLeaderMemberRef = _003C_003E4__this.GetMemberRef(guildId, currentLeaderId);
						_003C_003E8__2.guildName = null;
						awaiter2 = _003C_003E4__this._firestore.RunTransactionAsync<object>((Func<ITransaction, object>)delegate(ITransaction transaction)
						{
							//IL_011a: Unknown result type (might be due to invalid IL or missing references)
							IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(_003C_003E8__2.guildRef);
							if (document.Data == null)
							{
								throw new global::System.Exception("Guild not found");
							}
							_003C_003E8__2.guildName = document.Data.Name;
							IDocumentSnapshot<FirestoreGuildMemberDTO> document2 = transaction.GetDocument<FirestoreGuildMemberDTO>(_003C_003E8__2.newLeaderMemberRef);
							if (document2.Data == null)
							{
								throw new global::System.Exception("New leader member not found");
							}
							IDocumentSnapshot<FirestoreGuildMemberDTO> document3 = transaction.GetDocument<FirestoreGuildMemberDTO>(_003C_003E8__2.oldLeaderMemberRef);
							if (document3.Data == null)
							{
								throw new global::System.Exception("Current leader member not found");
							}
							transaction.UpdateData(_003C_003E8__2.newLeaderMemberRef, new Dictionary<object, object> { [(object)"role"] = ((object)GuildRole.Guildmaster).ToString() });
							transaction.UpdateData(_003C_003E8__2.oldLeaderMemberRef, new Dictionary<object, object> { [(object)"role"] = ((object)GuildRole.Vice_Guildmaster).ToString() });
							transaction.UpdateData(_003C_003E8__2.guildRef, new Dictionary<object, object>
							{
								[(object)"leaderPlayerId"] = _003C_003E8__2.CS_0024_003C_003E8__locals1.newLeaderId,
								[(object)"lastActivityAt"] = DateTimeOffset.UtcNow
							});
							return true;
						}).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CTransferLeadershipAsync_003Ed__22 _003CTransferLeadershipAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<object>, _003CTransferLeadershipAsync_003Ed__22>(ref awaiter2, ref _003CTransferLeadershipAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<object>);
						num = (_003C_003E1__state = -1);
					}
					awaiter2.GetResult();
					if (_003C_003E4__this._userSession.CurrentPlayerId != _003C_003E8__2.CS_0024_003C_003E8__locals1.newLeaderId)
					{
						awaiter = _003C_003E4__this.SendNotificationToPlayerAsync(_003C_003E8__2.CS_0024_003C_003E8__locals1.newLeaderId, NotificationType.GuildPromoted, new Dictionary<string, object>
						{
							["guildId"] = guildId,
							["guildName"] = _003C_003E8__2.guildName ?? "Unknown Guild",
							["newRole"] = ((object)GuildRole.Guildmaster).ToString(),
							["oldRole"] = ((object)GuildRole.Vice_Guildmaster).ToString()
						}).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter;
							_003CTransferLeadershipAsync_003Ed__22 _003CTransferLeadershipAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CTransferLeadershipAsync_003Ed__22>(ref awaiter, ref _003CTransferLeadershipAsync_003Ed__);
							return;
						}
						goto IL_026e;
					}
					goto IL_0277;
					IL_0277:
					result = true;
					goto end_IL_002d;
					IL_026e:
					((TaskAwaiter)(ref awaiter)).GetResult();
					goto IL_0277;
					end_IL_002d:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine("TransferLeadershipAsync failed: " + _003Cex_003E5__3.Message);
					result = false;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CUnregisterAsDefenderAsync_003Ed__62 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string guildId;

		public string playerId;

		public GuildRepository _003C_003E4__this;

		private _003C_003Ec__DisplayClass62_0 _003C_003E8__1;

		private _003C_003Ec__DisplayClass62_1 _003C_003E8__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if (num != 0)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass62_0();
					_003C_003E8__1.guildId = guildId;
					_003C_003E8__1.playerId = playerId;
				}
				try
				{
					TaskAwaiter<bool> awaiter;
					if (num != 0)
					{
						_003C_003E8__2 = new _003C_003Ec__DisplayClass62_1();
						_003C_003E8__2.CS_0024_003C_003E8__locals1 = _003C_003E8__1;
						_003C_003E8__2.guildRef = _003C_003E4__this._firestore.GetCollection("guilds").GetDocument(_003C_003E8__2.CS_0024_003C_003E8__locals1.guildId);
						awaiter = _003C_003E4__this._firestore.RunTransactionAsync<bool>((Func<ITransaction, bool>)delegate(ITransaction transaction)
						{
							//IL_0079: Unknown result type (might be due to invalid IL or missing references)
							IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(_003C_003E8__2.guildRef);
							if (document.Data == null)
							{
								throw new GuildNotFoundException(_003C_003E8__2.CS_0024_003C_003E8__locals1.guildId);
							}
							Dictionary<string, DefenderData> val = ToDomainDefenders(document.Data.Defenders);
							val.Remove(_003C_003E8__2.CS_0024_003C_003E8__locals1.playerId);
							transaction.UpdateData(_003C_003E8__2.guildRef, new Dictionary<object, object>
							{
								[(object)"defenders"] = ToFirestoreDefenders(val),
								[(object)"lastActivityAt"] = DateTimeOffset.UtcNow
							});
							return true;
						}).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CUnregisterAsDefenderAsync_003Ed__62 _003CUnregisterAsDefenderAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CUnregisterAsDefenderAsync_003Ed__62>(ref awaiter, ref _003CUnregisterAsDefenderAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
					}
					awaiter.GetResult();
					result = true;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine("UnregisterAsDefenderAsync failed: " + _003Cex_003E5__3.Message);
					result = false;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CUpdateAsync_003Ed__16 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public Guild guild;

		public GuildRepository _003C_003E4__this;

		private IDocumentReference _003CguildRef_003E5__1;

		private global::System.Exception _003Cex_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0192: Unknown result type (might be due to invalid IL or missing references)
			//IL_0197: Unknown result type (might be due to invalid IL or missing references)
			//IL_019e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0145: Unknown result type (might be due to invalid IL or missing references)
			//IL_015a: Unknown result type (might be due to invalid IL or missing references)
			//IL_015f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0173: Unknown result type (might be due to invalid IL or missing references)
			//IL_0174: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						_003CguildRef_003E5__1 = _003C_003E4__this._firestore.GetCollection("guilds").GetDocument(guild.ID);
						awaiter = _003CguildRef_003E5__1.UpdateDataAsync(new Dictionary<object, object>
						{
							[(object)"name"] = guild.Name ?? string.Empty,
							[(object)"description"] = guild.Description ?? string.Empty,
							[(object)"emblem"] = guild.Emblem ?? "\ud83d\udc51",
							[(object)"isPublic"] = guild.IsPublic,
							[(object)"requiresApproval"] = guild.RequiresApproval,
							[(object)"minLevelRequired"] = guild.MinLevelRequired,
							[(object)"minTrophiesRequired"] = guild.MinTrophiesRequired,
							[(object)"lastActivityAt"] = DateTimeOffset.UtcNow
						}).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CUpdateAsync_003Ed__16 _003CUpdateAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CUpdateAsync_003Ed__16>(ref awaiter, ref _003CUpdateAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
					}
					((TaskAwaiter)(ref awaiter)).GetResult();
					result = true;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__2 = ex;
					Console.WriteLine("UpdateGuildAsync failed: " + _003Cex_003E5__2.Message);
					result = false;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CUpdateAttackCountsAsync_003Ed__57 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string attackingGuildId;

		public string defendingGuildId;

		public string warId;

		public Dictionary<string, long> playerAttackCounts;

		public DateTimeOffset lastResetTime;

		public GuildRepository _003C_003E4__this;

		private IDocumentReference _003CprogressRef_003E5__1;

		private IDocumentSnapshot<FirestoreGuildWarProgressDTO> _003Csnapshot_003E5__2;

		private Dictionary<string, FirestoreWarAttackerDTO> _003CplayerStats_003E5__3;

		private FirestoreGuildWarProgressDTO _003Cdto_003E5__4;

		private IDocumentSnapshot<FirestoreGuildWarProgressDTO> _003C_003Es__5;

		private Enumerator<string, long> _003C_003Es__6;

		private string _003CplayerId_003E5__7;

		private long _003Ccount_003E5__8;

		private FirestoreWarAttackerDTO _003Cexisting_003E5__9;

		private global::System.Exception _003Cex_003E5__10;

		private TaskAwaiter<IDocumentSnapshot<FirestoreGuildWarProgressDTO>> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_040e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0413: Unknown result type (might be due to invalid IL or missing references)
			//IL_041b: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_010e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0113: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_0128: Unknown result type (might be due to invalid IL or missing references)
			//IL_0269: Unknown result type (might be due to invalid IL or missing references)
			//IL_033e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0337: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_03da: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f1: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if ((uint)num > 1u)
				{
				}
				try
				{
					TaskAwaiter awaiter;
					TaskAwaiter<IDocumentSnapshot<FirestoreGuildWarProgressDTO>> awaiter2;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_042a;
						}
						_003CprogressRef_003E5__1 = _003C_003E4__this._firestore.GetCollection("guilds").GetDocument(defendingGuildId).GetCollection("warProgress")
							.GetDocument(attackingGuildId);
						awaiter2 = _003CprogressRef_003E5__1.GetDocumentSnapshotAsync<FirestoreGuildWarProgressDTO>((Source)0).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CUpdateAttackCountsAsync_003Ed__57 _003CUpdateAttackCountsAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IDocumentSnapshot<FirestoreGuildWarProgressDTO>>, _003CUpdateAttackCountsAsync_003Ed__57>(ref awaiter2, ref _003CUpdateAttackCountsAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IDocumentSnapshot<FirestoreGuildWarProgressDTO>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__5 = awaiter2.GetResult();
					_003Csnapshot_003E5__2 = _003C_003Es__5;
					_003C_003Es__5 = null;
					_003CplayerStats_003E5__3 = _003Csnapshot_003E5__2.Data?.PlayerStats ?? new Dictionary<string, FirestoreWarAttackerDTO>();
					_003C_003Es__6 = playerAttackCounts.GetEnumerator();
					try
					{
						string text = default(string);
						long num2 = default(long);
						while (_003C_003Es__6.MoveNext())
						{
							_003C_003Es__6.Current.Deconstruct(ref text, ref num2);
							_003CplayerId_003E5__7 = text;
							_003Ccount_003E5__8 = num2;
							_003CplayerStats_003E5__3.TryGetValue(_003CplayerId_003E5__7, ref _003Cexisting_003E5__9);
							_003CplayerStats_003E5__3[_003CplayerId_003E5__7] = new FirestoreWarAttackerDTO
							{
								AttackCount = _003Ccount_003E5__8,
								HourlyStart = _003Cexisting_003E5__9?.HourlyStart,
								HourlyCrystals = (_003Cexisting_003E5__9?.HourlyCrystals ?? 0),
								RaidCountThisHour = (_003Cexisting_003E5__9?.RaidCountThisHour ?? 0),
								RaidHourStart = _003Cexisting_003E5__9?.RaidHourStart,
								TotalCrystalsAttack = (_003Cexisting_003E5__9?.TotalCrystalsAttack ?? 0),
								TotalCrystalsRaid = (_003Cexisting_003E5__9?.TotalCrystalsRaid ?? 0)
							};
							_003Cexisting_003E5__9 = null;
							_003CplayerId_003E5__7 = null;
						}
					}
					finally
					{
						if (num < 0)
						{
							((global::System.IDisposable)_003C_003Es__6).Dispose();
						}
					}
					_003C_003Es__6 = default(Enumerator<string, long>);
					_003Cdto_003E5__4 = new FirestoreGuildWarProgressDTO
					{
						ID = attackingGuildId,
						WarId = (_003Csnapshot_003E5__2.Data?.WarId ?? warId),
						AttackingGuildId = attackingGuildId,
						DefendingGuildId = defendingGuildId,
						DefeatedDefenders = (_003Csnapshot_003E5__2.Data?.DefeatedDefenders ?? new Dictionary<string, FirestoreWarDefenderDTO>()),
						CrystalsStolen = (_003Csnapshot_003E5__2.Data?.CrystalsStolen ?? 0),
						RaidCount = (_003Csnapshot_003E5__2.Data?.RaidCount ?? 0),
						LastRaidTime = (_003Csnapshot_003E5__2.Data?.LastRaidTime ?? DateTimeOffset.MinValue),
						SeasonId = (_003Csnapshot_003E5__2.Data?.SeasonId ?? warId),
						TotalAttacksCount = (_003Csnapshot_003E5__2.Data?.TotalAttacksCount ?? 0),
						StartingCrystals = (_003Csnapshot_003E5__2.Data?.StartingCrystals ?? 0),
						PlayerStats = _003CplayerStats_003E5__3
					};
					awaiter = _003CprogressRef_003E5__1.SetDataAsync((object)_003Cdto_003E5__4, SetOptions.Merge()).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter;
						_003CUpdateAttackCountsAsync_003Ed__57 _003CUpdateAttackCountsAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CUpdateAttackCountsAsync_003Ed__57>(ref awaiter, ref _003CUpdateAttackCountsAsync_003Ed__);
						return;
					}
					goto IL_042a;
					IL_042a:
					((TaskAwaiter)(ref awaiter)).GetResult();
					result = true;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__10 = ex;
					Console.WriteLine("UpdateAttackCountsAsync failed: " + _003Cex_003E5__10.Message);
					result = false;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CUpdateGuildRequestAsync_003Ed__17 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public UpdateGuildRequest guild;

		public GuildRepository _003C_003E4__this;

		private IDocumentReference _003CguildRef_003E5__1;

		private global::System.Exception _003Cex_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0192: Unknown result type (might be due to invalid IL or missing references)
			//IL_0197: Unknown result type (might be due to invalid IL or missing references)
			//IL_019e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0145: Unknown result type (might be due to invalid IL or missing references)
			//IL_015a: Unknown result type (might be due to invalid IL or missing references)
			//IL_015f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0173: Unknown result type (might be due to invalid IL or missing references)
			//IL_0174: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						_003CguildRef_003E5__1 = _003C_003E4__this._firestore.GetCollection("guilds").GetDocument(guild.GuildId);
						awaiter = _003CguildRef_003E5__1.UpdateDataAsync(new Dictionary<object, object>
						{
							[(object)"name"] = guild.GuildName ?? string.Empty,
							[(object)"description"] = guild.Description ?? string.Empty,
							[(object)"emblem"] = guild.Emblem ?? "\ud83d\udc51",
							[(object)"isPublic"] = guild.IsPublic,
							[(object)"requiresApproval"] = guild.RequiresApproval,
							[(object)"minLevelRequired"] = guild.MinLevelRequired,
							[(object)"minTrophiesRequired"] = guild.MinTrophiesRequired,
							[(object)"lastActivityAt"] = DateTimeOffset.UtcNow
						}).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CUpdateGuildRequestAsync_003Ed__17 _003CUpdateGuildRequestAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CUpdateGuildRequestAsync_003Ed__17>(ref awaiter, ref _003CUpdateGuildRequestAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
					}
					((TaskAwaiter)(ref awaiter)).GetResult();
					result = true;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__2 = ex;
					Console.WriteLine("UpdateGuildAsync failed: " + _003Cex_003E5__2.Message);
					result = false;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CUpdateGuildTrophiesAsync_003Ed__38 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string guildId;

		public int trophyChange;

		public GuildRepository _003C_003E4__this;

		private _003C_003Ec__DisplayClass38_0 _003C_003E8__1;

		private _003C_003Ec__DisplayClass38_1 _003C_003E8__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if (num != 0)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass38_0();
					_003C_003E8__1.trophyChange = trophyChange;
				}
				try
				{
					TaskAwaiter<bool> awaiter;
					if (num != 0)
					{
						_003C_003E8__2 = new _003C_003Ec__DisplayClass38_1();
						_003C_003E8__2.CS_0024_003C_003E8__locals1 = _003C_003E8__1;
						_003C_003E8__2.guildRef = _003C_003E4__this._firestore.GetCollection("guilds").GetDocument(guildId);
						awaiter = _003C_003E4__this._firestore.RunTransactionAsync<bool>((Func<ITransaction, bool>)delegate(ITransaction transaction)
						{
							//IL_006e: Unknown result type (might be due to invalid IL or missing references)
							IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(_003C_003E8__2.guildRef);
							if (document.Data == null)
							{
								throw new global::System.Exception("Guild not found");
							}
							int num2 = Math.Max(0, document.Data.Trophies + _003C_003E8__2.CS_0024_003C_003E8__locals1.trophyChange);
							transaction.UpdateData(_003C_003E8__2.guildRef, new Dictionary<object, object>
							{
								[(object)"trophies"] = num2,
								[(object)"lastActivityAt"] = DateTimeOffset.UtcNow
							});
							return true;
						}).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CUpdateGuildTrophiesAsync_003Ed__38 _003CUpdateGuildTrophiesAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CUpdateGuildTrophiesAsync_003Ed__38>(ref awaiter, ref _003CUpdateGuildTrophiesAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
					}
					awaiter.GetResult();
					result = true;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine("UpdateGuildTrophiesAsync failed: " + _003Cex_003E5__3.Message);
					result = false;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CUpdateMemberContributionAsync_003Ed__24 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string guildId;

		public string playerId;

		public int contributionAmount;

		public GuildRepository _003C_003E4__this;

		private _003C_003Ec__DisplayClass24_0 _003C_003E8__1;

		private _003C_003Ec__DisplayClass24_1 _003C_003E8__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0104: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if (num != 0)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass24_0();
					_003C_003E8__1.contributionAmount = contributionAmount;
				}
				try
				{
					TaskAwaiter<bool> awaiter;
					if (num != 0)
					{
						_003C_003E8__2 = new _003C_003Ec__DisplayClass24_1();
						_003C_003E8__2.CS_0024_003C_003E8__locals1 = _003C_003E8__1;
						_003C_003E8__2.memberRef = _003C_003E4__this.GetMemberRef(guildId, playerId);
						_003C_003E8__2.guildRef = _003C_003E4__this._firestore.GetCollection("guilds").GetDocument(guildId);
						awaiter = _003C_003E4__this._firestore.RunTransactionAsync<bool>((Func<ITransaction, bool>)delegate(ITransaction transaction)
						{
							//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
							IDocumentSnapshot<FirestoreGuildMemberDTO> document = transaction.GetDocument<FirestoreGuildMemberDTO>(_003C_003E8__2.memberRef);
							if (document.Data == null)
							{
								throw new global::System.Exception("Member not found");
							}
							transaction.UpdateData(_003C_003E8__2.memberRef, new Dictionary<object, object>
							{
								[(object)"contribution"] = document.Data.Contribution + _003C_003E8__2.CS_0024_003C_003E8__locals1.contributionAmount,
								[(object)"weeklyContribution"] = document.Data.WeeklyContribution + _003C_003E8__2.CS_0024_003C_003E8__locals1.contributionAmount
							});
							transaction.UpdateData(_003C_003E8__2.guildRef, new Dictionary<object, object> { [(object)"lastActivityAt"] = DateTimeOffset.UtcNow });
							return true;
						}).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CUpdateMemberContributionAsync_003Ed__24 _003CUpdateMemberContributionAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CUpdateMemberContributionAsync_003Ed__24>(ref awaiter, ref _003CUpdateMemberContributionAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
					}
					awaiter.GetResult();
					result = true;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine("UpdateMemberContributionAsync failed: " + _003Cex_003E5__3.Message);
					result = false;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CWriteDefenderBattleResultAsync_003Ed__54 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string attackingGuildId;

		public string defendingGuildId;

		public string warId;

		public bool isVictory;

		public int startingCrystals;

		public string defenderPlayerId;

		public string attackingPlayerId;

		public int crystalsAwarded;

		public DateTimeOffset? attackerHourlyStart;

		public int attackerHourlyCrystals;

		public int newDefenderDefeatedCount;

		public DateTimeOffset defenderDowntimeEnds;

		public DateTimeOffset? defenderLastFellAt;

		public int defenderCrystalsGainedDelta;

		public GuildRepository _003C_003E4__this;

		private IDocumentReference _003CprogressRef_003E5__1;

		private IDocumentSnapshot<FirestoreGuildWarProgressDTO> _003Csnapshot_003E5__2;

		private Dictionary<string, FirestoreWarDefenderDTO> _003CdefeatedDefenders_003E5__3;

		private FirestoreWarDefenderDTO _003CexistingDefender_003E5__4;

		private Dictionary<string, FirestoreWarAttackerDTO> _003CplayerStats_003E5__5;

		private FirestoreGuildWarProgressDTO _003CprogressDto_003E5__6;

		private IDocumentSnapshot<FirestoreGuildWarProgressDTO> _003C_003Es__7;

		private FirestoreWarAttackerDTO _003CexistingAttacker_003E5__8;

		private global::System.Exception _003Cex_003E5__9;

		private TaskAwaiter<IDocumentSnapshot<FirestoreGuildWarProgressDTO>> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_041b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0420: Unknown result type (might be due to invalid IL or missing references)
			//IL_0428: Unknown result type (might be due to invalid IL or missing references)
			//IL_04a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_04a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_045e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0468: Unknown result type (might be due to invalid IL or missing references)
			//IL_046d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0482: Unknown result type (might be due to invalid IL or missing references)
			//IL_0484: Unknown result type (might be due to invalid IL or missing references)
			//IL_014c: Unknown result type (might be due to invalid IL or missing references)
			//IL_035a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0353: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_03fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_03fe: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if ((uint)num > 2u)
				{
				}
				try
				{
					TaskAwaiter<IDocumentSnapshot<FirestoreGuildWarProgressDTO>> awaiter3;
					TaskAwaiter awaiter2;
					TaskAwaiter awaiter;
					switch (num)
					{
					default:
						_003CprogressRef_003E5__1 = _003C_003E4__this._firestore.GetCollection("guilds").GetDocument(defendingGuildId).GetCollection("warProgress")
							.GetDocument(attackingGuildId);
						awaiter3 = _003CprogressRef_003E5__1.GetDocumentSnapshotAsync<FirestoreGuildWarProgressDTO>((Source)0).GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter3;
							_003CWriteDefenderBattleResultAsync_003Ed__54 _003CWriteDefenderBattleResultAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IDocumentSnapshot<FirestoreGuildWarProgressDTO>>, _003CWriteDefenderBattleResultAsync_003Ed__54>(ref awaiter3, ref _003CWriteDefenderBattleResultAsync_003Ed__);
							return;
						}
						goto IL_00ce;
					case 0:
						awaiter3 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IDocumentSnapshot<FirestoreGuildWarProgressDTO>>);
						num = (_003C_003E1__state = -1);
						goto IL_00ce;
					case 1:
						awaiter2 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0437;
					case 2:
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_04bd;
						}
						IL_0437:
						((TaskAwaiter)(ref awaiter2)).GetResult();
						if (!isVictory)
						{
							break;
						}
						awaiter = _003C_003E4__this.SetDefenderDowntimeAndBreakAsync(defendingGuildId, defenderPlayerId, defenderDowntimeEnds).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__2 = awaiter;
							_003CWriteDefenderBattleResultAsync_003Ed__54 _003CWriteDefenderBattleResultAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CWriteDefenderBattleResultAsync_003Ed__54>(ref awaiter, ref _003CWriteDefenderBattleResultAsync_003Ed__);
							return;
						}
						goto IL_04bd;
						IL_00ce:
						_003C_003Es__7 = awaiter3.GetResult();
						_003Csnapshot_003E5__2 = _003C_003Es__7;
						_003C_003Es__7 = null;
						_003CdefeatedDefenders_003E5__3 = _003Csnapshot_003E5__2.Data?.DefeatedDefenders ?? new Dictionary<string, FirestoreWarDefenderDTO>();
						_003CdefeatedDefenders_003E5__3.TryGetValue(defenderPlayerId, ref _003CexistingDefender_003E5__4);
						_003CdefeatedDefenders_003E5__3[defenderPlayerId] = new FirestoreWarDefenderDTO
						{
							DefeatedCount = newDefenderDefeatedCount,
							DowntimeEnds = defenderDowntimeEnds,
							LastFellAt = defenderLastFellAt,
							CrystalsGained = (_003CexistingDefender_003E5__4?.CrystalsGained ?? 0) + defenderCrystalsGainedDelta
						};
						_003CplayerStats_003E5__5 = _003Csnapshot_003E5__2.Data?.PlayerStats ?? new Dictionary<string, FirestoreWarAttackerDTO>();
						if (isVictory && attackingPlayerId != null)
						{
							_003CplayerStats_003E5__5.TryGetValue(attackingPlayerId, ref _003CexistingAttacker_003E5__8);
							if (_003CexistingAttacker_003E5__8 == null)
							{
								_003CexistingAttacker_003E5__8 = new FirestoreWarAttackerDTO();
							}
							_003CplayerStats_003E5__5[attackingPlayerId] = new FirestoreWarAttackerDTO
							{
								AttackCount = _003CexistingAttacker_003E5__8.AttackCount,
								HourlyStart = attackerHourlyStart,
								HourlyCrystals = attackerHourlyCrystals,
								RaidCountThisHour = _003CexistingAttacker_003E5__8.RaidCountThisHour,
								RaidHourStart = _003CexistingAttacker_003E5__8.RaidHourStart,
								TotalCrystalsAttack = _003CexistingAttacker_003E5__8.TotalCrystalsAttack + crystalsAwarded,
								TotalCrystalsRaid = _003CexistingAttacker_003E5__8.TotalCrystalsRaid
							};
							_003CexistingAttacker_003E5__8 = null;
						}
						_003CprogressDto_003E5__6 = new FirestoreGuildWarProgressDTO
						{
							ID = attackingGuildId,
							WarId = (_003Csnapshot_003E5__2.Data?.WarId ?? warId),
							AttackingGuildId = attackingGuildId,
							DefendingGuildId = defendingGuildId,
							DefeatedDefenders = _003CdefeatedDefenders_003E5__3,
							CrystalsStolen = (_003Csnapshot_003E5__2.Data?.CrystalsStolen ?? 0) + (isVictory ? crystalsAwarded : 0),
							RaidCount = (_003Csnapshot_003E5__2.Data?.RaidCount ?? 0),
							LastRaidTime = (_003Csnapshot_003E5__2.Data?.LastRaidTime ?? DateTimeOffset.MinValue),
							SeasonId = (_003Csnapshot_003E5__2.Data?.SeasonId ?? warId),
							TotalAttacksCount = (_003Csnapshot_003E5__2.Data?.TotalAttacksCount ?? 0) + 1,
							StartingCrystals = startingCrystals,
							PlayerStats = _003CplayerStats_003E5__5
						};
						awaiter2 = _003CprogressRef_003E5__1.SetDataAsync((object)_003CprogressDto_003E5__6, SetOptions.Merge()).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter2;
							_003CWriteDefenderBattleResultAsync_003Ed__54 _003CWriteDefenderBattleResultAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CWriteDefenderBattleResultAsync_003Ed__54>(ref awaiter2, ref _003CWriteDefenderBattleResultAsync_003Ed__);
							return;
						}
						goto IL_0437;
						IL_04bd:
						((TaskAwaiter)(ref awaiter)).GetResult();
						break;
					}
					result = true;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__9 = ex;
					Console.WriteLine("WriteDefenderBattleResultAsync failed: " + _003Cex_003E5__9.Message);
					result = false;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CWriteRaidResultAsync_003Ed__53 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string defendingGuildId;

		public string attackingGuildId;

		public string warId;

		public int crystalsGained;

		public int startingCrystals;

		public string attackingPlayerId;

		public int newRaidCountThisHour;

		public DateTimeOffset newRaidHourStart;

		public int totalCrystalsRaidDelta;

		public GuildRepository _003C_003E4__this;

		private IDocumentReference _003CprogressRef_003E5__1;

		private IDocumentSnapshot<FirestoreGuildWarProgressDTO> _003Csnapshot_003E5__2;

		private Dictionary<string, FirestoreWarAttackerDTO> _003CplayerStats_003E5__3;

		private FirestoreWarAttackerDTO _003Cexisting_003E5__4;

		private FirestoreGuildWarProgressDTO _003Cdto_003E5__5;

		private IDocumentSnapshot<FirestoreGuildWarProgressDTO> _003C_003Es__6;

		private global::System.Exception _003Cex_003E5__7;

		private TaskAwaiter<IDocumentSnapshot<FirestoreGuildWarProgressDTO>> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0349: Unknown result type (might be due to invalid IL or missing references)
			//IL_034e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0356: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_0187: Unknown result type (might be due to invalid IL or missing references)
			//IL_028a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0310: Unknown result type (might be due to invalid IL or missing references)
			//IL_0315: Unknown result type (might be due to invalid IL or missing references)
			//IL_032a: Unknown result type (might be due to invalid IL or missing references)
			//IL_032c: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if ((uint)num > 1u)
				{
				}
				try
				{
					TaskAwaiter awaiter;
					TaskAwaiter<IDocumentSnapshot<FirestoreGuildWarProgressDTO>> awaiter2;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0365;
						}
						_003CprogressRef_003E5__1 = _003C_003E4__this._firestore.GetCollection("guilds").GetDocument(defendingGuildId).GetCollection("warProgress")
							.GetDocument(attackingGuildId);
						awaiter2 = _003CprogressRef_003E5__1.GetDocumentSnapshotAsync<FirestoreGuildWarProgressDTO>((Source)0).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CWriteRaidResultAsync_003Ed__53 _003CWriteRaidResultAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IDocumentSnapshot<FirestoreGuildWarProgressDTO>>, _003CWriteRaidResultAsync_003Ed__53>(ref awaiter2, ref _003CWriteRaidResultAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IDocumentSnapshot<FirestoreGuildWarProgressDTO>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__6 = awaiter2.GetResult();
					_003Csnapshot_003E5__2 = _003C_003Es__6;
					_003C_003Es__6 = null;
					_003CplayerStats_003E5__3 = _003Csnapshot_003E5__2.Data?.PlayerStats ?? new Dictionary<string, FirestoreWarAttackerDTO>();
					_003CplayerStats_003E5__3.TryGetValue(attackingPlayerId, ref _003Cexisting_003E5__4);
					if (_003Cexisting_003E5__4 == null)
					{
						_003Cexisting_003E5__4 = new FirestoreWarAttackerDTO();
					}
					_003CplayerStats_003E5__3[attackingPlayerId] = new FirestoreWarAttackerDTO
					{
						AttackCount = _003Cexisting_003E5__4.AttackCount,
						HourlyStart = _003Cexisting_003E5__4.HourlyStart,
						HourlyCrystals = _003Cexisting_003E5__4.HourlyCrystals,
						RaidCountThisHour = newRaidCountThisHour,
						RaidHourStart = newRaidHourStart,
						TotalCrystalsAttack = _003Cexisting_003E5__4.TotalCrystalsAttack,
						TotalCrystalsRaid = _003Cexisting_003E5__4.TotalCrystalsRaid + totalCrystalsRaidDelta
					};
					_003Cdto_003E5__5 = new FirestoreGuildWarProgressDTO
					{
						ID = attackingGuildId,
						WarId = (_003Csnapshot_003E5__2.Data?.WarId ?? warId),
						AttackingGuildId = attackingGuildId,
						DefendingGuildId = defendingGuildId,
						DefeatedDefenders = (_003Csnapshot_003E5__2.Data?.DefeatedDefenders ?? new Dictionary<string, FirestoreWarDefenderDTO>()),
						CrystalsStolen = (_003Csnapshot_003E5__2.Data?.CrystalsStolen ?? 0) + crystalsGained,
						RaidCount = (_003Csnapshot_003E5__2.Data?.RaidCount ?? 0) + 1,
						LastRaidTime = DateTimeOffset.UtcNow,
						SeasonId = (_003Csnapshot_003E5__2.Data?.SeasonId ?? warId),
						TotalAttacksCount = (_003Csnapshot_003E5__2.Data?.TotalAttacksCount ?? 0),
						StartingCrystals = startingCrystals,
						PlayerStats = _003CplayerStats_003E5__3
					};
					awaiter = _003CprogressRef_003E5__1.SetDataAsync((object)_003Cdto_003E5__5, SetOptions.Merge()).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter;
						_003CWriteRaidResultAsync_003Ed__53 _003CWriteRaidResultAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CWriteRaidResultAsync_003Ed__53>(ref awaiter, ref _003CWriteRaidResultAsync_003Ed__);
						return;
					}
					goto IL_0365;
					IL_0365:
					((TaskAwaiter)(ref awaiter)).GetResult();
					result = true;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__7 = ex;
					Console.WriteLine("WriteRaidResultAsync failed: " + _003Cex_003E5__7.Message);
					result = false;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IFirebaseFirestore _firestore;

	private readonly IPlayerStateService _userSession;

	private readonly IPlayerNotificationService _notificationService;

	private const string GuildCollection = "guilds";

	private const string PlayerCollection = "players";

	private const string MembersSubcollection = "members";

	public GuildRepository(IFirebaseFirestore firebaseFirestore, IPlayerStateService userSessionService, IPlayerNotificationService notificationService)
	{
		_firestore = firebaseFirestore;
		_userSession = userSessionService;
		_notificationService = notificationService;
	}

	private static Dictionary<string, object> ToFirestoreDefenders(Dictionary<string, DefenderData> defenders)
	{
		return Enumerable.ToDictionary<KeyValuePair<string, DefenderData>, string, object>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, DefenderData>>)defenders, (Func<KeyValuePair<string, DefenderData>, string>)((KeyValuePair<string, DefenderData> kvp) => kvp.Key), (Func<KeyValuePair<string, DefenderData>, object>)((KeyValuePair<string, DefenderData> kvp) => new Dictionary<string, object>
		{
			["squadIds"] = Enumerable.ToList<object>(Enumerable.Cast<object>((global::System.Collections.IEnumerable)kvp.Value.SquadIds)),
			["signUpAt"] = kvp.Value.SignUpAt,
			["expiresAt"] = kvp.Value.ExpiresAt,
			["isMainDefender"] = kvp.Value.IsMainDefender,
			["downtimeEnds"] = (kvp.Value.DowntimeEnds.HasValue ? ((object)kvp.Value.DowntimeEnds.Value) : null)
		}));
	}

	private static Dictionary<string, DefenderData> ToDomainDefenders(Dictionary<string, FirestoreGuildDefenderDTO>? dto)
	{
		return ((dto != null) ? Enumerable.ToDictionary<KeyValuePair<string, FirestoreGuildDefenderDTO>, string, DefenderData>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, FirestoreGuildDefenderDTO>>)dto, (Func<KeyValuePair<string, FirestoreGuildDefenderDTO>, string>)((KeyValuePair<string, FirestoreGuildDefenderDTO> kv) => kv.Key), (Func<KeyValuePair<string, FirestoreGuildDefenderDTO>, DefenderData>)((KeyValuePair<string, FirestoreGuildDefenderDTO> kv) => new DefenderData(kv.Value.SquadIds ?? new List<string>(), kv.Value.SignUpAt, kv.Value.ExpiresAt, kv.Value.IsMainDefender, kv.Value.DowntimeEnds))) : null) ?? new Dictionary<string, DefenderData>();
	}

	private static Dictionary<string, object> ToFirestorePlayerStats(Dictionary<string, FirestoreWarAttackerDTO> stats)
	{
		return Enumerable.ToDictionary<KeyValuePair<string, FirestoreWarAttackerDTO>, string, object>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, FirestoreWarAttackerDTO>>)stats, (Func<KeyValuePair<string, FirestoreWarAttackerDTO>, string>)((KeyValuePair<string, FirestoreWarAttackerDTO> kvp) => kvp.Key), (Func<KeyValuePair<string, FirestoreWarAttackerDTO>, object>)((KeyValuePair<string, FirestoreWarAttackerDTO> kvp) => new Dictionary<string, object>
		{
			["attackCount"] = kvp.Value.AttackCount,
			["hourlyStart"] = (kvp.Value.HourlyStart.HasValue ? ((object)kvp.Value.HourlyStart.Value) : null),
			["hourlyCrystals"] = kvp.Value.HourlyCrystals,
			["raidCountThisHour"] = kvp.Value.RaidCountThisHour,
			["raidHourStart"] = (kvp.Value.RaidHourStart.HasValue ? ((object)kvp.Value.RaidHourStart.Value) : null),
			["totalCrystalsAttack"] = kvp.Value.TotalCrystalsAttack,
			["totalCrystalsRaid"] = kvp.Value.TotalCrystalsRaid
		}));
	}

	private static Dictionary<string, object> ToFirestoreDefeatedDefenders(Dictionary<string, FirestoreWarDefenderDTO> defenders)
	{
		return Enumerable.ToDictionary<KeyValuePair<string, FirestoreWarDefenderDTO>, string, object>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, FirestoreWarDefenderDTO>>)defenders, (Func<KeyValuePair<string, FirestoreWarDefenderDTO>, string>)((KeyValuePair<string, FirestoreWarDefenderDTO> kvp) => kvp.Key), (Func<KeyValuePair<string, FirestoreWarDefenderDTO>, object>)((KeyValuePair<string, FirestoreWarDefenderDTO> kvp) => new Dictionary<string, object>
		{
			["defeatedCount"] = kvp.Value.DefeatedCount,
			["downtimeEnds"] = kvp.Value.DowntimeEnds,
			["lastFellAt"] = (kvp.Value.LastFellAt.HasValue ? ((object)kvp.Value.LastFellAt.Value) : null),
			["crystalsGained"] = kvp.Value.CrystalsGained
		}));
	}

	private IDocumentReference GetMemberRef(string guildId, string playerId)
	{
		return _firestore.GetCollection("guilds").GetDocument(guildId).GetCollection("members")
			.GetDocument(playerId);
	}

	[AsyncStateMachine(typeof(_003CGetMemberAsync_003Ed__12))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<GuildMember?> GetMemberAsync(string guildId, string playerId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			IDocumentSnapshot<FirestoreGuildMemberDTO> doc = await GetMemberRef(guildId, playerId).GetDocumentSnapshotAsync<FirestoreGuildMemberDTO>((Source)0);
			return (doc.Data != null) ? GuildMemberEntityMapper.ToEntity(doc.Data) : null;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("GetMemberAsync failed: " + ex.Message);
			return null;
		}
	}

	[AsyncStateMachine(typeof(_003CGetMembersFromSubcollectionAsync_003Ed__13))]
	[DebuggerStepThrough]
	private async global::System.Threading.Tasks.Task<Dictionary<string, GuildMember>> GetMembersFromSubcollectionAsync(string guildId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		IQuerySnapshot<FirestoreGuildMemberDTO> snapshot = await ((IQuery)_firestore.GetCollection("guilds").GetDocument(guildId).GetCollection("members")).GetDocumentsAsync<FirestoreGuildMemberDTO>((Source)0);
		FirestoreReadCounter.Track("GetGuildMembers", Enumerable.Count<IDocumentSnapshot<FirestoreGuildMemberDTO>>(snapshot.Documents));
		Dictionary<string, GuildMember> result = new Dictionary<string, GuildMember>();
		global::System.Collections.Generic.IEnumerator<IDocumentSnapshot<FirestoreGuildMemberDTO>> enumerator = snapshot.Documents.GetEnumerator();
		try
		{
			while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
			{
				IDocumentSnapshot<FirestoreGuildMemberDTO> doc = enumerator.Current;
				if (doc.Data != null)
				{
					string memberId = doc.Data.PlayerId ?? doc.Reference.Id;
					result[memberId] = GuildMemberEntityMapper.ToEntity(doc.Data);
				}
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator)?.Dispose();
		}
		return result;
	}

	[AsyncStateMachine(typeof(_003CGetByIdAsync_003Ed__14))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Guild?> GetByIdAsync(string guildId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		FirestoreGuildDTO firestoreGuild = (await _firestore.GetCollection("guilds").GetDocument(guildId).GetDocumentSnapshotAsync<FirestoreGuildDTO>((Source)0)).Data;
		if (firestoreGuild == null)
		{
			return null;
		}
		return GuildEntityMapper.ToEntity(firestoreGuild);
	}

	[AsyncStateMachine(typeof(_003CCreateGuildAsync_003Ed__15))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Guild?> CreateGuildAsync(CreateGuildRequest request, Player player)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		CreateGuildRequest request2 = request;
		Player player2 = player;
		try
		{
			DateTimeOffset now = DateTimeOffset.UtcNow;
			int playerTrophies = (int)((player2.Currencies["reputation"] > 2147483647) ? 2147483647 : player2.Currencies["reputation"]);
			string guildId = await _firestore.RunTransactionAsync<string>((Func<ITransaction, string>)delegate(ITransaction transaction)
			{
				//IL_0063: Unknown result type (might be due to invalid IL or missing references)
				//IL_0070: Unknown result type (might be due to invalid IL or missing references)
				//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
				//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
				IDocumentReference val = _firestore.GetCollection("guilds").CreateDocument();
				FirestoreGuildDTO firestoreGuildDTO = new FirestoreGuildDTO
				{
					ID = val.Id,
					Name = request2.GuildName,
					Description = request2.Description,
					CreatedAt = now,
					LastActivityAt = now,
					LeaderPlayerId = player2.PlayerID,
					Emblem = request2.Emblem,
					IsPublic = request2.IsPublic,
					RequiresApproval = request2.RequiresApproval,
					MinLevelRequired = request2.MinLevelRequired,
					MinTrophiesRequired = request2.MinTrophiesRequired,
					MemberCount = 1,
					Level = 1,
					Rank = 0,
					XPForNextLevel = 500,
					IsOpenToWar = true,
					StartingCrystals = 1000
				};
				transaction.SetData(val, (object)firestoreGuildDTO, (SetOptions)null);
				IDocumentReference document = val.GetCollection("members").GetDocument(player2.PlayerID);
				transaction.SetData(document, (object)new FirestoreGuildMemberDTO
				{
					PlayerId = player2.PlayerID,
					PlayerName = player2.Playername,
					Role = "Guildmaster",
					JoinedAt = now,
					Contribution = 0,
					IsOnline = true,
					LastActiveAt = now,
					Trophies = playerTrophies,
					WeeklyContribution = 0,
					Level = player2.PlayerLevel,
					PlayerIcon = player2.PlayerIcon
				}, (SetOptions)null);
				return val.Id;
			});
			Guild obj = new Guild
			{
				ID = guildId,
				Name = request2.GuildName,
				Description = request2.Description
			};
			Dictionary<string, GuildMember> obj2 = new Dictionary<string, GuildMember>();
			obj2.Add(player2.PlayerID, new GuildMember
			{
				PlayerId = player2.PlayerID,
				PlayerName = player2.Playername,
				Role = GuildRole.Guildmaster,
				JoinedAt = now,
				Contribution = 0,
				Trophies = playerTrophies,
				Level = player2.PlayerLevel,
				WeeklyContribution = 0,
				IsOnline = true,
				LastActiveAt = now,
				PlayerIcon = player2.PlayerIcon
			});
			obj.Members = obj2;
			obj.LeaderPlayerId = player2.PlayerID;
			obj.Emblem = request2.Emblem;
			obj.IsPublic = request2.IsPublic;
			obj.RequiresApproval = request2.RequiresApproval;
			obj.MinLevelRequired = request2.MinLevelRequired;
			obj.MinTrophiesRequired = request2.MinTrophiesRequired;
			obj.MemberCount = 1;
			obj.CreatedAt = now;
			return obj;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("Create guild error " + ex.Message);
			Console.WriteLine(ex.StackTrace);
			return null;
		}
	}

	[AsyncStateMachine(typeof(_003CUpdateAsync_003Ed__16))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> UpdateAsync(Guild guild)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			IDocumentReference guildRef = _firestore.GetCollection("guilds").GetDocument(guild.ID);
			await guildRef.UpdateDataAsync(new Dictionary<object, object>
			{
				[(object)"name"] = guild.Name ?? string.Empty,
				[(object)"description"] = guild.Description ?? string.Empty,
				[(object)"emblem"] = guild.Emblem ?? "\ud83d\udc51",
				[(object)"isPublic"] = guild.IsPublic,
				[(object)"requiresApproval"] = guild.RequiresApproval,
				[(object)"minLevelRequired"] = guild.MinLevelRequired,
				[(object)"minTrophiesRequired"] = guild.MinTrophiesRequired,
				[(object)"lastActivityAt"] = DateTimeOffset.UtcNow
			});
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("UpdateGuildAsync failed: " + ex.Message);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CUpdateGuildRequestAsync_003Ed__17))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> UpdateGuildRequestAsync(UpdateGuildRequest guild)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			IDocumentReference guildRef = _firestore.GetCollection("guilds").GetDocument(guild.GuildId);
			await guildRef.UpdateDataAsync(new Dictionary<object, object>
			{
				[(object)"name"] = guild.GuildName ?? string.Empty,
				[(object)"description"] = guild.Description ?? string.Empty,
				[(object)"emblem"] = guild.Emblem ?? "\ud83d\udc51",
				[(object)"isPublic"] = guild.IsPublic,
				[(object)"requiresApproval"] = guild.RequiresApproval,
				[(object)"minLevelRequired"] = guild.MinLevelRequired,
				[(object)"minTrophiesRequired"] = guild.MinTrophiesRequired,
				[(object)"lastActivityAt"] = DateTimeOffset.UtcNow
			});
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("UpdateGuildAsync failed: " + ex.Message);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CDeleteAsync_003Ed__18))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> DeleteAsync(string guildId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		string guildId2 = guildId;
		try
		{
			return await _firestore.RunTransactionAsync<bool>((Func<ITransaction, bool>)delegate(ITransaction transaction)
			{
				IDocumentReference document = _firestore.GetCollection("guilds").GetDocument(guildId2);
				transaction.DeleteDocument(document);
				return true;
			});
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("DeleteGuildAsync failed: " + ex.Message);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CLeaveGuildAsync_003Ed__19))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> LeaveGuildAsync(string playerId, string guildId, Guild currentGuild)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		Guild currentGuild2 = currentGuild;
		try
		{
			IDocumentReference memberRef = GetMemberRef(guildId, playerId);
			IDocumentReference guildRef = _firestore.GetCollection("guilds").GetDocument(guildId);
			await _firestore.RunTransactionAsync<object>((Func<ITransaction, object>)delegate(ITransaction transaction)
			{
				memberRef.DeleteDocumentAsync();
				int memberCount = currentGuild2.MemberCount;
				int maxMembers = currentGuild2.MaxMembers;
				if (memberCount >= maxMembers)
				{
					throw new global::System.Exception("Guild is full");
				}
				int num = memberCount - 1;
				transaction.UpdateData(guildRef, new Dictionary<object, object> { [(object)"memberCount"] = num });
				return true;
			});
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("LeaveGuildAsync failed: " + ex.Message);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CKickMemberAsync_003Ed__20))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> KickMemberAsync(string guildId, string targetPlayerId, string kickedByPlayerId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			IDocumentReference guildRef = _firestore.GetCollection("guilds").GetDocument(guildId);
			_firestore.GetCollection("players").GetDocument(targetPlayerId);
			IDocumentReference memberRef = GetMemberRef(guildId, targetPlayerId);
			string guildName = (await guildRef.GetDocumentSnapshotAsync<FirestoreGuildDTO>((Source)0)).Data?.Name;
			await _firestore.RunTransactionAsync<object>((Func<ITransaction, object>)delegate(ITransaction transaction)
			{
				transaction.DeleteDocument(memberRef);
				return true;
			});
			if (_userSession.CurrentPlayerId != targetPlayerId)
			{
				await SendNotificationToPlayerAsync(targetPlayerId, NotificationType.GuildKicked, new Dictionary<string, object>
				{
					["guildId"] = guildId,
					["guildName"] = guildName ?? "Unknown Guild",
					["kickedByPlayerId"] = kickedByPlayerId
				});
			}
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("KickMemberAsync failed: " + ex.Message);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CPromoteMemberAsync_003Ed__21))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> PromoteMemberAsync(string guildId, string targetPlayerId, GuildRole newRole)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			IDocumentReference guildRef = _firestore.GetCollection("guilds").GetDocument(guildId);
			_firestore.GetCollection("players").GetDocument(targetPlayerId);
			IDocumentReference memberRef = GetMemberRef(guildId, targetPlayerId);
			string oldRole = null;
			string guildName = null;
			await _firestore.RunTransactionAsync<object>((Func<ITransaction, object>)delegate(ITransaction transaction)
			{
				//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
				IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(guildRef);
				if (document.Data == null)
				{
					throw new global::System.Exception("Guild not found");
				}
				guildName = document.Data.Name;
				IDocumentSnapshot<FirestoreGuildMemberDTO> document2 = transaction.GetDocument<FirestoreGuildMemberDTO>(memberRef);
				if (document2.Data == null)
				{
					throw new global::System.Exception("Member not found");
				}
				oldRole = document2.Data.Role;
				transaction.UpdateData(memberRef, new Dictionary<object, object> { [(object)"role"] = ((object)newRole).ToString() });
				transaction.UpdateData(guildRef, new Dictionary<object, object> { [(object)"lastActivityAt"] = DateTimeOffset.UtcNow });
				return true;
			});
			if (_userSession.CurrentPlayerId != targetPlayerId)
			{
				await SendNotificationToPlayerAsync(targetPlayerId, NotificationType.GuildPromoted, new Dictionary<string, object>
				{
					["guildId"] = guildId,
					["guildName"] = guildName ?? "Unknown Guild",
					["newRole"] = ((object)newRole).ToString(),
					["oldRole"] = oldRole ?? "member"
				});
			}
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("PromoteMemberAsync failed: " + ex.Message);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CTransferLeadershipAsync_003Ed__22))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> TransferLeadershipAsync(string guildId, string newLeaderId, string currentLeaderId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		string newLeaderId2 = newLeaderId;
		try
		{
			IDocumentReference guildRef = _firestore.GetCollection("guilds").GetDocument(guildId);
			IDocumentReference newLeaderMemberRef = GetMemberRef(guildId, newLeaderId2);
			IDocumentReference oldLeaderMemberRef = GetMemberRef(guildId, currentLeaderId);
			string guildName = null;
			await _firestore.RunTransactionAsync<object>((Func<ITransaction, object>)delegate(ITransaction transaction)
			{
				//IL_011a: Unknown result type (might be due to invalid IL or missing references)
				IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(guildRef);
				if (document.Data == null)
				{
					throw new global::System.Exception("Guild not found");
				}
				guildName = document.Data.Name;
				IDocumentSnapshot<FirestoreGuildMemberDTO> document2 = transaction.GetDocument<FirestoreGuildMemberDTO>(newLeaderMemberRef);
				if (document2.Data == null)
				{
					throw new global::System.Exception("New leader member not found");
				}
				IDocumentSnapshot<FirestoreGuildMemberDTO> document3 = transaction.GetDocument<FirestoreGuildMemberDTO>(oldLeaderMemberRef);
				if (document3.Data == null)
				{
					throw new global::System.Exception("Current leader member not found");
				}
				transaction.UpdateData(newLeaderMemberRef, new Dictionary<object, object> { [(object)"role"] = ((object)GuildRole.Guildmaster).ToString() });
				transaction.UpdateData(oldLeaderMemberRef, new Dictionary<object, object> { [(object)"role"] = ((object)GuildRole.Vice_Guildmaster).ToString() });
				transaction.UpdateData(guildRef, new Dictionary<object, object>
				{
					[(object)"leaderPlayerId"] = newLeaderId2,
					[(object)"lastActivityAt"] = DateTimeOffset.UtcNow
				});
				return true;
			});
			if (_userSession.CurrentPlayerId != newLeaderId2)
			{
				await SendNotificationToPlayerAsync(newLeaderId2, NotificationType.GuildPromoted, new Dictionary<string, object>
				{
					["guildId"] = guildId,
					["guildName"] = guildName ?? "Unknown Guild",
					["newRole"] = ((object)GuildRole.Guildmaster).ToString(),
					["oldRole"] = ((object)GuildRole.Vice_Guildmaster).ToString()
				});
			}
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("TransferLeadershipAsync failed: " + ex.Message);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CDemoteMemberAsync_003Ed__23))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> DemoteMemberAsync(string guildId, string targetPlayerId, GuildRole newRole)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			IDocumentReference guildRef = _firestore.GetCollection("guilds").GetDocument(guildId);
			_firestore.GetCollection("players").GetDocument(targetPlayerId);
			IDocumentReference memberRef = GetMemberRef(guildId, targetPlayerId);
			string oldRole = null;
			string newRoleStr = ((object)newRole).ToString();
			string guildName = null;
			await _firestore.RunTransactionAsync<object>((Func<ITransaction, object>)delegate(ITransaction transaction)
			{
				//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
				IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(guildRef);
				if (document.Data == null)
				{
					throw new global::System.Exception("Guild not found");
				}
				guildName = document.Data.Name;
				IDocumentSnapshot<FirestoreGuildMemberDTO> document2 = transaction.GetDocument<FirestoreGuildMemberDTO>(memberRef);
				if (document2.Data == null)
				{
					throw new global::System.Exception("Member not found");
				}
				oldRole = document2.Data.Role;
				transaction.UpdateData(memberRef, new Dictionary<object, object> { [(object)"role"] = newRoleStr });
				transaction.UpdateData(guildRef, new Dictionary<object, object> { [(object)"lastActivityAt"] = DateTimeOffset.UtcNow });
				return true;
			});
			if (_userSession.CurrentPlayerId != targetPlayerId)
			{
				await SendNotificationToPlayerAsync(targetPlayerId, NotificationType.GuildDemoted, new Dictionary<string, object>
				{
					["guildId"] = guildId,
					["guildName"] = guildName ?? "Unknown Guild",
					["newRole"] = newRoleStr,
					["oldRole"] = oldRole ?? "member"
				});
			}
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("DemoteMemberAsync failed: " + ex.Message);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CUpdateMemberContributionAsync_003Ed__24))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> UpdateMemberContributionAsync(string guildId, string playerId, int contributionAmount)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			IDocumentReference memberRef = GetMemberRef(guildId, playerId);
			IDocumentReference guildRef = _firestore.GetCollection("guilds").GetDocument(guildId);
			await _firestore.RunTransactionAsync<bool>((Func<ITransaction, bool>)delegate(ITransaction transaction)
			{
				//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
				IDocumentSnapshot<FirestoreGuildMemberDTO> document = transaction.GetDocument<FirestoreGuildMemberDTO>(memberRef);
				if (document.Data == null)
				{
					throw new global::System.Exception("Member not found");
				}
				transaction.UpdateData(memberRef, new Dictionary<object, object>
				{
					[(object)"contribution"] = document.Data.Contribution + contributionAmount,
					[(object)"weeklyContribution"] = document.Data.WeeklyContribution + contributionAmount
				});
				transaction.UpdateData(guildRef, new Dictionary<object, object> { [(object)"lastActivityAt"] = DateTimeOffset.UtcNow });
				return true;
			});
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("UpdateMemberContributionAsync failed: " + ex.Message);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CGetGuildMembersAsync_003Ed__25))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Dictionary<string, GuildMember>> GetGuildMembersAsync(string guildId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			return await GetMembersFromSubcollectionAsync(guildId);
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("GetGuildMembersAsync failed: " + ex.Message);
			return new Dictionary<string, GuildMember>();
		}
	}

	[AsyncStateMachine(typeof(_003CSearchGuildsAsync_003Ed__26))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<List<GuildSearchResult>> SearchGuildsAsync(string searchText = "", GuildSearchFilters? filters = null, int playerLevel = 1, long playerTrophies = 0L, int limit = 50)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		string searchText2 = searchText;
		GuildSearchFilters filters2 = filters;
		try
		{
			IQuery query = ((IQuery)_firestore.GetCollection("guilds")).WhereEqualsTo("isPublic", (object)true).OrderBy("memberCount", false).LimitedTo(limit);
			List<FirestoreGuildDTO> guilds = Enumerable.ToList<FirestoreGuildDTO>(Enumerable.Where<FirestoreGuildDTO>(Enumerable.Select<IDocumentSnapshot<FirestoreGuildDTO>, FirestoreGuildDTO>((await query.GetDocumentsAsync<FirestoreGuildDTO>((Source)0)).Documents, (Func<IDocumentSnapshot<FirestoreGuildDTO>, FirestoreGuildDTO>)((IDocumentSnapshot<FirestoreGuildDTO> d) => d.Data)), (Func<FirestoreGuildDTO, bool>)((FirestoreGuildDTO g) => g != null)));
			global::System.Collections.Generic.IEnumerable<FirestoreGuildDTO> filteredGuilds = Enumerable.AsEnumerable<FirestoreGuildDTO>((global::System.Collections.Generic.IEnumerable<FirestoreGuildDTO>)guilds);
			if (!string.IsNullOrEmpty(searchText2))
			{
				filteredGuilds = Enumerable.Where<FirestoreGuildDTO>(filteredGuilds, (Func<FirestoreGuildDTO, bool>)((FirestoreGuildDTO g) => g.Name?.Contains(searchText2, (StringComparison)5) ?? false));
			}
			if (filters2 != null)
			{
				if (filters2.MinMembers.HasValue)
				{
					filteredGuilds = Enumerable.Where<FirestoreGuildDTO>(filteredGuilds, (Func<FirestoreGuildDTO, bool>)((FirestoreGuildDTO g) => g.MemberCount >= filters2.MinMembers.Value));
				}
				if (filters2.MaxMembers.HasValue)
				{
					filteredGuilds = Enumerable.Where<FirestoreGuildDTO>(filteredGuilds, (Func<FirestoreGuildDTO, bool>)((FirestoreGuildDTO g) => g.MemberCount <= filters2.MaxMembers.Value));
				}
				if (filters2.MinTrophies.HasValue)
				{
					filteredGuilds = Enumerable.Where<FirestoreGuildDTO>(filteredGuilds, (Func<FirestoreGuildDTO, bool>)((FirestoreGuildDTO g) => g.Trophies >= filters2.MinTrophies.Value));
				}
				if (filters2.MaxTrophies.HasValue)
				{
					filteredGuilds = Enumerable.Where<FirestoreGuildDTO>(filteredGuilds, (Func<FirestoreGuildDTO, bool>)((FirestoreGuildDTO g) => g.Trophies <= filters2.MaxTrophies.Value));
				}
				if (filters2.IsPublic.HasValue)
				{
					filteredGuilds = Enumerable.Where<FirestoreGuildDTO>(filteredGuilds, (Func<FirestoreGuildDTO, bool>)((FirestoreGuildDTO g) => g.IsPublic == filters2.IsPublic.Value));
				}
				if (filters2.MinLevel.HasValue)
				{
					filteredGuilds = Enumerable.Where<FirestoreGuildDTO>(filteredGuilds, (Func<FirestoreGuildDTO, bool>)((FirestoreGuildDTO g) => g.Level >= filters2.MinLevel.Value));
				}
				if (filters2.MaxLevel.HasValue)
				{
					filteredGuilds = Enumerable.Where<FirestoreGuildDTO>(filteredGuilds, (Func<FirestoreGuildDTO, bool>)((FirestoreGuildDTO g) => g.Level <= filters2.MaxLevel.Value));
				}
			}
			return Enumerable.ToList<GuildSearchResult>(Enumerable.Select<FirestoreGuildDTO, GuildSearchResult>(filteredGuilds, (Func<FirestoreGuildDTO, GuildSearchResult>)((FirestoreGuildDTO g) => new GuildSearchResult
			{
				GuildId = (g.ID ?? string.Empty),
				Name = (g.Name ?? "Unknown"),
				Emblem = (g.Emblem ?? "\ud83d\udc51"),
				Rank = g.Rank,
				Level = g.Level,
				MemberCount = g.MemberCount,
				MaxMembers = g.MaxMembers,
				Trophies = g.Trophies,
				IsPublic = g.IsPublic,
				RequiresApproval = g.RequiresApproval,
				MinLevelRequired = g.MinLevelRequired,
				MinTrophiesRequired = g.MinTrophiesRequired,
				CanJoin = (playerLevel >= g.MinLevelRequired && playerTrophies >= g.MinTrophiesRequired && g.MemberCount < g.MaxMembers)
			})));
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("SearchGuildsAsync failed: " + ex.Message);
			return new List<GuildSearchResult>();
		}
	}

	[AsyncStateMachine(typeof(_003CGetTopGuildsByTrophiesAsync_003Ed__27))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<List<Guild>> GetTopGuildsByTrophiesAsync(int limit = 50)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			return Enumerable.ToList<Guild>(Enumerable.Select<FirestoreGuildDTO, Guild>(Enumerable.Take<FirestoreGuildDTO>((global::System.Collections.Generic.IEnumerable<FirestoreGuildDTO>)Enumerable.OrderByDescending<FirestoreGuildDTO, int>(Enumerable.Where<FirestoreGuildDTO>(Enumerable.Select<IDocumentSnapshot<FirestoreGuildDTO>, FirestoreGuildDTO>((await ((IQuery)_firestore.GetCollection("guilds")).GetDocumentsAsync<FirestoreGuildDTO>((Source)0)).Documents, (Func<IDocumentSnapshot<FirestoreGuildDTO>, FirestoreGuildDTO>)((IDocumentSnapshot<FirestoreGuildDTO> d) => d.Data)), (Func<FirestoreGuildDTO, bool>)((FirestoreGuildDTO g) => g != null)), (Func<FirestoreGuildDTO, int>)((FirestoreGuildDTO g) => g.Trophies)), limit), (Func<FirestoreGuildDTO, Guild>)((FirestoreGuildDTO firestoreDto) => GuildEntityMapper.ToEntity(firestoreDto))));
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("GetTopGuildsAsync failed: " + ex.Message);
			return new List<Guild>();
		}
	}

	[AsyncStateMachine(typeof(_003CGetRecommendedGuildsAsync_003Ed__28))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<List<Guild>> GetRecommendedGuildsAsync(string playerId, int limit = 10)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			IDocumentSnapshot<FirestorePlayerDTO> playerDoc = await _firestore.GetCollection("players").GetDocument(playerId).GetDocumentSnapshotAsync<FirestorePlayerDTO>((Source)0);
			int playerLevel = playerDoc.Data?.PlayerLevel ?? 1;
			FirestorePlayerDTO data = playerDoc.Data;
			long? obj;
			if (data == null)
			{
				obj = null;
			}
			else
			{
				Dictionary<string, long>? currencies = data.Currencies;
				obj = ((currencies != null) ? new long?(CollectionExtensions.GetValueOrDefault<string, long>((IReadOnlyDictionary<string, long>)(object)currencies, "reputation", 0L)) : null);
			}
			long? num = obj;
			long playerTrophies = num.GetValueOrDefault();
			return Enumerable.ToList<Guild>(Enumerable.Select<FirestoreGuildDTO, Guild>(Enumerable.Take<FirestoreGuildDTO>((global::System.Collections.Generic.IEnumerable<FirestoreGuildDTO>)Enumerable.ThenByDescending<FirestoreGuildDTO, int>(Enumerable.OrderByDescending<FirestoreGuildDTO, int>(Enumerable.Where<FirestoreGuildDTO>(Enumerable.Where<FirestoreGuildDTO>(Enumerable.Select<IDocumentSnapshot<FirestoreGuildDTO>, FirestoreGuildDTO>((await ((IQuery)_firestore.GetCollection("guilds")).GetDocumentsAsync<FirestoreGuildDTO>((Source)0)).Documents, (Func<IDocumentSnapshot<FirestoreGuildDTO>, FirestoreGuildDTO>)((IDocumentSnapshot<FirestoreGuildDTO> d) => d.Data)), (Func<FirestoreGuildDTO, bool>)((FirestoreGuildDTO g) => g != null)), (Func<FirestoreGuildDTO, bool>)((FirestoreGuildDTO g) => g.IsPublic && g.MinLevelRequired <= playerLevel && g.MinTrophiesRequired <= playerTrophies && g.MemberCount < g.MaxMembers)), (Func<FirestoreGuildDTO, int>)((FirestoreGuildDTO g) => g.Level)), (Func<FirestoreGuildDTO, int>)((FirestoreGuildDTO g) => g.Trophies)), limit), (Func<FirestoreGuildDTO, Guild>)((FirestoreGuildDTO firestoreDto) => GuildEntityMapper.ToEntity(firestoreDto))));
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("GetRecommendedGuildsAsync failed: " + ex.Message);
			return new List<Guild>();
		}
	}

	[AsyncStateMachine(typeof(_003CSendJoinRequestAsync_003Ed__29))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> SendJoinRequestAsync(string playerId, string guildId, string? message = null)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		string playerId2 = playerId;
		string guildId2 = guildId;
		string message2 = message;
		try
		{
			IDocumentReference playerRef = _firestore.GetCollection("players").GetDocument(playerId2);
			IDocumentReference guildRef = _firestore.GetCollection("guilds").GetDocument(guildId2);
			await _firestore.RunTransactionAsync<bool>((Func<ITransaction, bool>)delegate(ITransaction transaction)
			{
				//IL_0037: Unknown result type (might be due to invalid IL or missing references)
				//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
				IDocumentSnapshot<FirestorePlayerDTO> document = transaction.GetDocument<FirestorePlayerDTO>(playerRef);
				if (document.Data == null)
				{
					throw new ArgumentException("Player '" + playerId2 + "' not found");
				}
				if (!string.IsNullOrEmpty(document.Data.GuildId))
				{
					throw new AlreadyInGuildException(playerId2, document.Data.GuildId);
				}
				IDocumentSnapshot<FirestoreGuildDTO> document2 = transaction.GetDocument<FirestoreGuildDTO>(guildRef);
				if (document2.Data == null)
				{
					throw new GuildNotFoundException(guildId2);
				}
				if (document2.Data.MemberCount >= document2.Data.MaxMembers)
				{
					throw new GuildFullException(guildId2, document2.Data.MemberCount, document2.Data.MaxMembers);
				}
				IDocumentReference val = _firestore.GetCollection("guilds").GetDocument(guildId2).GetCollection("joinRequests")
					.CreateDocument();
				FirestoreGuildJoinRequestDTO obj = new FirestoreGuildJoinRequestDTO
				{
					ID = val.Id,
					PlayerId = playerId2,
					PlayerName = document.Data.Playername,
					PlayerLevel = document.Data.PlayerLevel
				};
				Dictionary<string, long>? currencies = document.Data.Currencies;
				obj.PlayerTrophies = (int)((currencies != null) ? CollectionExtensions.GetValueOrDefault<string, long>((IReadOnlyDictionary<string, long>)(object)currencies, "reputation", 0L) : 0);
				obj.Message = message2;
				obj.Status = "Pending";
				obj.CreatedAt = DateTimeOffset.UtcNow;
				FirestoreGuildJoinRequestDTO firestoreGuildJoinRequestDTO = obj;
				transaction.SetData(val, (object)firestoreGuildJoinRequestDTO, (SetOptions)null);
				return true;
			});
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("SendJoinRequestAsync failed: " + ex.Message);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CApproveJoinRequestAsync_003Ed__30))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> ApproveJoinRequestAsync(string guildId, string requestId, string approvedByPlayerId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			IDocumentReference requestRef = _firestore.GetCollection("guilds").GetDocument(guildId).GetCollection("joinRequests")
				.GetDocument(requestId);
			IDocumentSnapshot<FirestoreGuildJoinRequestDTO> requestDoc = await requestRef.GetDocumentSnapshotAsync<FirestoreGuildJoinRequestDTO>((Source)0);
			if (requestDoc.Data == null || requestDoc.Data.Status != "Pending")
			{
				return false;
			}
			string playerId = requestDoc.Data.PlayerId;
			string playerName = requestDoc.Data.PlayerName;
			if (!(await JoinGuildAsync(playerLevel: requestDoc.Data.PlayerLevel, playerId: playerId ?? string.Empty, playerName: playerName ?? "Unknown", guildId: guildId)))
			{
				return false;
			}
			await requestRef.UpdateDataAsync(new Dictionary<object, object>
			{
				[(object)"status"] = "Approved",
				[(object)"reviewedByPlayerId"] = approvedByPlayerId,
				[(object)"reviewedAt"] = DateTimeOffset.UtcNow
			});
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("ApproveJoinRequestAsync failed: " + ex.Message);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CRejectJoinRequestAsync_003Ed__31))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> RejectJoinRequestAsync(string guildId, string requestId, string rejectedByPlayerId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			IDocumentReference requestRef = _firestore.GetCollection("guilds").GetDocument(guildId).GetCollection("joinRequests")
				.GetDocument(requestId);
			await requestRef.UpdateDataAsync(new Dictionary<object, object>
			{
				[(object)"status"] = "rejected",
				[(object)"reviewedByPlayerId"] = rejectedByPlayerId,
				[(object)"reviewedAt"] = DateTimeOffset.UtcNow
			});
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("RejectJoinRequestAsync failed: " + ex.Message);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CGetPendingJoinRequestsAsync_003Ed__32))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<List<GuildJoinRequest>> GetPendingJoinRequestsAsync(string guildId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			return Enumerable.ToList<GuildJoinRequest>(Enumerable.Select<FirestoreGuildJoinRequestDTO, GuildJoinRequest>(Enumerable.DistinctBy<FirestoreGuildJoinRequestDTO, string>(Enumerable.Where<FirestoreGuildJoinRequestDTO>(Enumerable.Select<IDocumentSnapshot<FirestoreGuildJoinRequestDTO>, FirestoreGuildJoinRequestDTO>((await ((IQuery)_firestore.GetCollection("guilds").GetDocument(guildId).GetCollection("joinRequests")).GetDocumentsAsync<FirestoreGuildJoinRequestDTO>((Source)0)).Documents, (Func<IDocumentSnapshot<FirestoreGuildJoinRequestDTO>, FirestoreGuildJoinRequestDTO>)((IDocumentSnapshot<FirestoreGuildJoinRequestDTO> d) => d.Data)), (Func<FirestoreGuildJoinRequestDTO, bool>)((FirestoreGuildJoinRequestDTO r) => r != null && r.Status == "Pending")), (Func<FirestoreGuildJoinRequestDTO, string>)((FirestoreGuildJoinRequestDTO data) => data.PlayerId)), (Func<FirestoreGuildJoinRequestDTO, GuildJoinRequest>)((FirestoreGuildJoinRequestDTO dto) => new GuildJoinRequest
			{
				ID = (dto.ID ?? string.Empty),
				PlayerId = (dto.PlayerId ?? string.Empty),
				PlayerName = (dto.PlayerName ?? "Unknown"),
				PlayerLevel = dto.PlayerLevel,
				PlayerTrophies = dto.PlayerTrophies,
				Message = (dto.Message ?? string.Empty),
				Status = global::System.Enum.Parse<JoinRequestStatus>(dto.Status ?? "Pending", true),
				CreatedAt = dto.CreatedAt,
				ReviewedByPlayerId = dto.ReviewedByPlayerId,
				ReviewedAt = dto.ReviewedAt
			})));
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("GetPendingJoinRequestsAsync failed: " + ex.Message);
			return new List<GuildJoinRequest>();
		}
	}

	[AsyncStateMachine(typeof(_003CSendGuildInvitationAsync_003Ed__33))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> SendGuildInvitationAsync(string guildId, string targetPlayerId, string invitedByPlayerId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			IDocumentSnapshot<FirestoreGuildDTO> guildDoc = await _firestore.GetCollection("guilds").GetDocument(guildId).GetDocumentSnapshotAsync<FirestoreGuildDTO>((Source)0);
			IDocumentSnapshot<FirestorePlayerDTO> inviterDoc = await _firestore.GetCollection("players").GetDocument(invitedByPlayerId).GetDocumentSnapshotAsync<FirestorePlayerDTO>((Source)0);
			if (guildDoc.Data == null || inviterDoc.Data == null)
			{
				return false;
			}
			IPlayerNotificationService notificationService = _notificationService;
			Dictionary<string, object> obj = new Dictionary<string, object>
			{
				["guildId"] = guildId,
				["guildName"] = guildDoc.Data.Name ?? string.Empty,
				["invitedByPlayerId"] = invitedByPlayerId,
				["invitedByPlayerName"] = inviterDoc.Data.Playername ?? string.Empty
			};
			DateTimeOffset val = DateTimeOffset.UtcNow;
			val = ((DateTimeOffset)(ref val)).AddDays(7.0);
			obj["expiresAt"] = ((DateTimeOffset)(ref val)).ToString("O");
			await notificationService.SendAsync(targetPlayerId, NotificationType.GuildInvitation, obj);
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("SendGuildInvitationAsync failed: " + ex.Message);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CAcceptInvitationAsync_003Ed__34))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> AcceptInvitationAsync(string invitationId, string playerId, Player currentPlayer)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			IDocumentReference notificationRef = _firestore.GetCollection("players").GetDocument(playerId).GetCollection("notifications")
				.GetDocument(invitationId);
			IDocumentSnapshot<FirestorePlayerNotificationDTO> doc = await notificationRef.GetDocumentSnapshotAsync<FirestorePlayerNotificationDTO>((Source)0);
			if (doc.Data == null || !doc.Data.Unansweared)
			{
				return false;
			}
			Dictionary<string, object> data = doc.Data.Data;
			string guildId = CollectionExtensions.GetValueOrDefault<string, object>((IReadOnlyDictionary<string, object>)(object)data, "guildId") as string;
			if (string.IsNullOrEmpty(guildId))
			{
				return false;
			}
			object expiresAtObj = default(object);
			DateTimeOffset expiresAt = default(DateTimeOffset);
			if (data.TryGetValue("expiresAt", ref expiresAtObj) && expiresAtObj is string expiresAtStr && DateTimeOffset.TryParse(expiresAtStr, ref expiresAt) && expiresAt < DateTimeOffset.UtcNow)
			{
				return false;
			}
			bool checkCurrentGuildMembership = true;
			if (!string.IsNullOrEmpty(currentPlayer.GuildId))
			{
				IDocumentSnapshot<FirestoreGuildDTO> guildSnapshot = await _firestore.GetCollection("guilds").GetDocument(currentPlayer.GuildId).GetDocumentSnapshotAsync<FirestoreGuildDTO>((Source)0);
				if (guildSnapshot.Data == null)
				{
					return false;
				}
				checkCurrentGuildMembership = await LeaveGuildAsync(playerId, currentPlayer.GuildId, GuildEntityMapper.ToEntity(guildSnapshot.Data));
			}
			if (!checkCurrentGuildMembership)
			{
				Console.WriteLine("Changing guild membership failed, could not leave current guild");
				return false;
			}
			await JoinGuildAsync(playerId, currentPlayer.Playername ?? "Unknown", guildId, currentPlayer.PlayerLevel);
			await notificationRef.UpdateDataAsync(new Dictionary<object, object>
			{
				[(object)"read"] = true,
				[(object)"unansweared"] = false
			});
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("AcceptInvitationAsync failed: " + ex.Message);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CDeclineInvitationAsync_003Ed__35))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> DeclineInvitationAsync(string invitationId, string playerId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			await _firestore.GetCollection("players").GetDocument(playerId).GetCollection("notifications")
				.GetDocument(invitationId)
				.UpdateDataAsync(new Dictionary<object, object>
				{
					[(object)"read"] = true,
					[(object)"unansweared"] = false
				});
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("DeclineInvitationAsync failed: " + ex.Message);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CGetPlayerInvitationsAsync_003Ed__36))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<List<GuildInvitation>> GetPlayerInvitationsAsync(string playerId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		string playerId2 = playerId;
		try
		{
			IQuerySnapshot<FirestorePlayerNotificationDTO> snapshot = await ((IQuery)_firestore.GetCollection("players").GetDocument(playerId2).GetCollection("notifications")).OrderBy("createdAt", true).LimitedTo(50).GetDocumentsAsync<FirestorePlayerNotificationDTO>((Source)0);
			string invitationType = ((object)NotificationType.GuildInvitation).ToString();
			return Enumerable.ToList<GuildInvitation>(Enumerable.Where<GuildInvitation>(Enumerable.Select<FirestorePlayerNotificationDTO, GuildInvitation>(Enumerable.DistinctBy<FirestorePlayerNotificationDTO, object>(Enumerable.Where<FirestorePlayerNotificationDTO>(Enumerable.Select<IDocumentSnapshot<FirestorePlayerNotificationDTO>, FirestorePlayerNotificationDTO>(snapshot.Documents, (Func<IDocumentSnapshot<FirestorePlayerNotificationDTO>, FirestorePlayerNotificationDTO>)((IDocumentSnapshot<FirestorePlayerNotificationDTO> d) => d.Data)), (Func<FirestorePlayerNotificationDTO, bool>)((FirestorePlayerNotificationDTO dto) => dto != null && dto.Type == invitationType)), (Func<FirestorePlayerNotificationDTO, object>)((FirestorePlayerNotificationDTO dto) => CollectionExtensions.GetValueOrDefault<string, object>((IReadOnlyDictionary<string, object>)(object)dto.Data, "guildId"))), (Func<FirestorePlayerNotificationDTO, GuildInvitation>)delegate(FirestorePlayerNotificationDTO dto)
			{
				//IL_0009: Unknown result type (might be due to invalid IL or missing references)
				//IL_000e: Unknown result type (might be due to invalid IL or missing references)
				//IL_003a: Unknown result type (might be due to invalid IL or missing references)
				//IL_003c: Unknown result type (might be due to invalid IL or missing references)
				//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
				//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
				Dictionary<string, object> data = dto.Data;
				DateTimeOffset expiresAt = dto.Ttl;
				object obj = default(object);
				DateTimeOffset val = default(DateTimeOffset);
				if (data.TryGetValue("expiresAt", ref obj) && obj is string text && DateTimeOffset.TryParse(text, ref val))
				{
					expiresAt = val;
				}
				return new GuildInvitation
				{
					ID = dto.Id,
					GuildId = ((CollectionExtensions.GetValueOrDefault<string, object>((IReadOnlyDictionary<string, object>)(object)data, "guildId") as string) ?? string.Empty),
					GuildName = ((CollectionExtensions.GetValueOrDefault<string, object>((IReadOnlyDictionary<string, object>)(object)data, "guildName") as string) ?? "Unknown"),
					InvitedPlayerId = playerId2,
					InvitedByPlayerId = ((CollectionExtensions.GetValueOrDefault<string, object>((IReadOnlyDictionary<string, object>)(object)data, "invitedByPlayerId") as string) ?? string.Empty),
					InvitedByPlayerName = ((CollectionExtensions.GetValueOrDefault<string, object>((IReadOnlyDictionary<string, object>)(object)data, "invitedByPlayerName") as string) ?? "Unknown"),
					Status = InvitationStatus.Pending,
					CreatedAt = dto.CreatedAt,
					ExpiresAt = expiresAt
				};
			}), (Func<GuildInvitation, bool>)((GuildInvitation inv) => !inv.IsExpired)));
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("GetPlayerInvitationsAsync failed: " + ex.Message);
			return new List<GuildInvitation>();
		}
	}

	[AsyncStateMachine(typeof(_003CAddGuildXPAsync_003Ed__37))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> AddGuildXPAsync(string guildId, int xpAmount, string? source = null)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		return await AddGuildXPAsync(guildId, xpAmount);
	}

	[AsyncStateMachine(typeof(_003CUpdateGuildTrophiesAsync_003Ed__38))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> UpdateGuildTrophiesAsync(string guildId, int trophyChange)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			IDocumentReference guildRef = _firestore.GetCollection("guilds").GetDocument(guildId);
			await _firestore.RunTransactionAsync<bool>((Func<ITransaction, bool>)delegate(ITransaction transaction)
			{
				//IL_006e: Unknown result type (might be due to invalid IL or missing references)
				IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(guildRef);
				if (document.Data == null)
				{
					throw new global::System.Exception("Guild not found");
				}
				int num = Math.Max(0, document.Data.Trophies + trophyChange);
				transaction.UpdateData(guildRef, new Dictionary<object, object>
				{
					[(object)"trophies"] = num,
					[(object)"lastActivityAt"] = DateTimeOffset.UtcNow
				});
				return true;
			});
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("UpdateGuildTrophiesAsync failed: " + ex.Message);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CSetWarEnrollmentAsync_003Ed__39))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> SetWarEnrollmentAsync(string guildId, bool isOpenToWar)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			IDocumentReference guildRef = _firestore.GetCollection("guilds").GetDocument(guildId);
			await guildRef.UpdateDataAsync(new Dictionary<object, object>
			{
				[(object)"isOpenToWar"] = isOpenToWar,
				[(object)"lastActivityAt"] = DateTimeOffset.UtcNow
			});
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("SetWarEnrollmentAsync failed: " + ex.Message);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CSetDisbandScheduleAsync_003Ed__40))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> SetDisbandScheduleAsync(string guildId, DateTimeOffset? disbandAt)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			IDocumentReference guildRef = _firestore.GetCollection("guilds").GetDocument(guildId);
			Dictionary<object, object> obj = new Dictionary<object, object>();
			object obj2 = "disbandScheduledAt";
			DateTimeOffset? val = disbandAt;
			obj[obj2] = (val.HasValue ? ((object)val.GetValueOrDefault()) : null);
			await guildRef.UpdateDataAsync(obj);
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("SetDisbandScheduleAsync failed: " + ex.Message);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CAddGuildCoinsAsync_003Ed__41))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> AddGuildCoinsAsync(string guildId, int coinsAmount)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			IDocumentReference guildRef = _firestore.GetCollection("guilds").GetDocument(guildId);
			await _firestore.RunTransactionAsync<bool>((Func<ITransaction, bool>)delegate(ITransaction transaction)
			{
				//IL_0068: Unknown result type (might be due to invalid IL or missing references)
				IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(guildRef);
				if (document.Data == null)
				{
					throw new global::System.Exception("Guild not found");
				}
				int num = document.Data.GuildCoins + coinsAmount;
				transaction.UpdateData(guildRef, new Dictionary<object, object>
				{
					[(object)"guildCoins"] = num,
					[(object)"lastActivityAt"] = DateTimeOffset.UtcNow
				});
				return true;
			});
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("AddGuildCoinsAsync failed: " + ex.Message);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CSpendGuildCoinsAsync_003Ed__42))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> SpendGuildCoinsAsync(string guildId, int coinsAmount)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			IDocumentReference guildRef = _firestore.GetCollection("guilds").GetDocument(guildId);
			await _firestore.RunTransactionAsync<bool>((Func<ITransaction, bool>)delegate(ITransaction transaction)
			{
				//IL_0091: Unknown result type (might be due to invalid IL or missing references)
				IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(guildRef);
				if (document.Data == null)
				{
					throw new global::System.Exception("Guild not found");
				}
				if (document.Data.GuildCoins < coinsAmount)
				{
					throw new global::System.Exception("Insufficient guild coins");
				}
				int num = document.Data.GuildCoins - coinsAmount;
				transaction.UpdateData(guildRef, new Dictionary<object, object>
				{
					[(object)"guildCoins"] = num,
					[(object)"lastActivityAt"] = DateTimeOffset.UtcNow
				});
				return true;
			});
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("SpendGuildCoinsAsync failed: " + ex.Message);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CGetGuildWarHistoryAsync_003Ed__43))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<List<GuildWarHistory>> GetGuildWarHistoryAsync(string guildId, int limit = 20)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			return Enumerable.ToList<GuildWarHistory>(Enumerable.Select<FirestoreGuildWarHistoryDTO, GuildWarHistory>(Enumerable.Take<FirestoreGuildWarHistoryDTO>((global::System.Collections.Generic.IEnumerable<FirestoreGuildWarHistoryDTO>)Enumerable.OrderByDescending<FirestoreGuildWarHistoryDTO, DateTimeOffset>(Enumerable.Where<FirestoreGuildWarHistoryDTO>(Enumerable.Select<IDocumentSnapshot<FirestoreGuildWarHistoryDTO>, FirestoreGuildWarHistoryDTO>((await ((IQuery)_firestore.GetCollection("guilds").GetDocument(guildId).GetCollection("warHistory")).GetDocumentsAsync<FirestoreGuildWarHistoryDTO>((Source)0)).Documents, (Func<IDocumentSnapshot<FirestoreGuildWarHistoryDTO>, FirestoreGuildWarHistoryDTO>)((IDocumentSnapshot<FirestoreGuildWarHistoryDTO> d) => d.Data)), (Func<FirestoreGuildWarHistoryDTO, bool>)((FirestoreGuildWarHistoryDTO w) => w != null)), (Func<FirestoreGuildWarHistoryDTO, DateTimeOffset>)((FirestoreGuildWarHistoryDTO w) => w.Timestamp)), limit), (Func<FirestoreGuildWarHistoryDTO, GuildWarHistory>)((FirestoreGuildWarHistoryDTO dto) => new GuildWarHistory
			{
				ID = (dto.ID ?? string.Empty),
				SeasonId = (dto.SeasonId ?? string.Empty),
				OpponentGuildId = (dto.OpponentGuildId ?? string.Empty),
				OpponentGuildName = (dto.OpponentGuildName ?? "Unknown"),
				Result = global::System.Enum.Parse<GuildWarResult>(dto.Result ?? "Defending", true),
				TrophiesGained = dto.TrophiesGained,
				TrophiesLost = dto.TrophiesLost,
				Timestamp = dto.Timestamp,
				CrystalsStolen = dto.CrystalsStolen,
				CrystalsLost = dto.CrystalsLost,
				Wins = dto.Wins,
				Losses = dto.Losses,
				ActiveMemberCount = dto.ActiveMemberCount,
				AttackMVP = dto.AttackMVP,
				DefenseMVP = dto.DefenseMVP,
				WarMVP = dto.WarMVP,
				ContributionScores = (dto.ContributionScores ?? new Dictionary<string, double>())
			})));
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("GetGuildWarHistoryAsync failed: " + ex.Message);
			Console.WriteLine("GetGuildWarHistoryAsync failed: " + ex.StackTrace);
			return new List<GuildWarHistory>();
		}
	}

	[AsyncStateMachine(typeof(_003CAddGuildXPAsync_003Ed__44))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> AddGuildXPAsync(string guildId, int xpAmount)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		string guildId2 = guildId;
		try
		{
			IDocumentReference guildRef = _firestore.GetCollection("guilds").GetDocument(guildId2);
			await _firestore.RunTransactionAsync<bool>((Func<ITransaction, bool>)delegate(ITransaction transaction)
			{
				IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(guildRef);
				if (document.Data == null)
				{
					throw new global::System.Exception("Guild not found");
				}
				int currentXP = document.Data.CurrentXP;
				int num = document.Data.XPForNextLevel;
				int num2 = document.Data.Level;
				int num3 = currentXP + xpAmount;
				int num4 = 0;
				while (num3 >= num)
				{
					num3 -= num;
					num2++;
					num4++;
					num = CalculateXPForLevel(num2 + 1);
				}
				transaction.UpdateData(guildRef, new Dictionary<object, object>
				{
					[(object)"currentXP"] = num3,
					[(object)"level"] = num2,
					[(object)"xpForNextLevel"] = num,
					[(object)"lastActivityAt"] = global::System.DateTime.UtcNow
				});
				if (num4 > 0)
				{
					IDocumentReference val = _firestore.GetCollection("guilds").GetDocument(guildId2).GetCollection("activities")
						.CreateDocument();
					transaction.SetData(val, (object)new Dictionary<string, object>
					{
						["type"] = "level_up",
						["message"] = $"Guild reached level {num2}!",
						["icon"] = "⭐",
						["isHighlighted"] = true,
						["timestamp"] = global::System.DateTime.UtcNow
					}, (SetOptions)null);
				}
				return true;
			});
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("AddGuildXPAsync failed: " + ex.Message);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CJoinGuildAsync_003Ed__45))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> JoinGuildAsync(string playerId, string playerName, string guildId, int playerLevel)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		string playerId2 = playerId;
		string playerName2 = playerName;
		try
		{
			IDocumentReference guildRef = _firestore.GetCollection("guilds").GetDocument(guildId);
			_firestore.GetCollection("players").GetDocument(playerId2);
			IDocumentReference memberRef = GetMemberRef(guildId, playerId2);
			string guildName = null;
			DateTimeOffset joinedAt = DateTimeOffset.UtcNow;
			await _firestore.RunTransactionAsync<bool>((Func<ITransaction, bool>)delegate(ITransaction transaction)
			{
				//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
				//IL_010a: Unknown result type (might be due to invalid IL or missing references)
				IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(guildRef);
				if (document.Data == null)
				{
					throw new global::System.Exception("Guild not found");
				}
				guildName = document.Data.Name;
				int memberCount = document.Data.MemberCount;
				int maxMembers = document.Data.MaxMembers;
				if (memberCount >= maxMembers)
				{
					throw new global::System.Exception("Guild is full");
				}
				int num = memberCount + 1;
				transaction.UpdateData(guildRef, new Dictionary<object, object> { [(object)"memberCount"] = num });
				transaction.SetData(memberRef, (object)new FirestoreGuildMemberDTO
				{
					PlayerId = playerId2,
					PlayerName = playerName2,
					Role = "Member",
					Level = playerLevel,
					Trophies = 0,
					Contribution = 0,
					WeeklyContribution = 0,
					JoinedAt = joinedAt,
					LastActiveAt = joinedAt,
					IsOnline = true
				}, (SetOptions)null);
				return true;
			});
			if (_userSession.CurrentPlayerId != playerId2)
			{
				await SendNotificationToPlayerAsync(playerId2, NotificationType.GuildJoined, new Dictionary<string, object>
				{
					["guildId"] = guildId,
					["guildName"] = guildName ?? "Unknown Guild",
					["role"] = "Member",
					["joinedAt"] = ((object)(DateTimeOffset)(ref joinedAt)).ToString()
				});
			}
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("JoinGuildAsync failed: " + ex.Message);
			return false;
		}
	}

	private int CalculateXPForLevel(int level)
	{
		return (int)((double)(1000 * level) * Math.Pow(1.1, (double)level));
	}

	[AsyncStateMachine(typeof(_003CSignUpAsDefenderAsync_003Ed__47))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> SignUpAsDefenderAsync(string guildId, string playerId, List<string> defenderSquad)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		string guildId2 = guildId;
		string playerId2 = playerId;
		List<string> defenderSquad2 = defenderSquad;
		try
		{
			List<string> obj = defenderSquad2;
			int actualSize = ((obj != null) ? Enumerable.Count<string>((global::System.Collections.Generic.IEnumerable<string>)obj, (Func<string, bool>)((string s) => !string.IsNullOrEmpty(s))) : 0);
			if (actualSize != 3)
			{
				throw new InvalidDefenderSquadException(guildId2, actualSize);
			}
			IDocumentReference guildRef = _firestore.GetCollection("guilds").GetDocument(guildId2);
			await _firestore.RunTransactionAsync<bool>((Func<ITransaction, bool>)delegate(ITransaction transaction)
			{
				//IL_003f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0044: Unknown result type (might be due to invalid IL or missing references)
				//IL_008f: Unknown result type (might be due to invalid IL or missing references)
				//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
				//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
				//IL_013b: Unknown result type (might be due to invalid IL or missing references)
				IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(guildRef);
				if (document.Data == null)
				{
					throw new GuildNotFoundException(guildId2);
				}
				Dictionary<string, DefenderData> val = ToDomainDefenders(document.Data.Defenders);
				DateTimeOffset utcNow = DateTimeOffset.UtcNow;
				DefenderData defenderData = default(DefenderData);
				if (val.TryGetValue(playerId2, ref defenderData))
				{
					val[playerId2] = defenderData with
					{
						SquadIds = defenderSquad2,
						ExpiresAt = ((DateTimeOffset)(ref utcNow)).AddHours(8.0)
					};
				}
				else
				{
					if (val.Count >= 25)
					{
						throw new MaxDefendersReachedException(guildId2, val.Count, 25);
					}
					val[playerId2] = new DefenderData(defenderSquad2, utcNow, ((DateTimeOffset)(ref utcNow)).AddHours(8.0), IsMainDefender: false);
				}
				transaction.UpdateData(guildRef, new Dictionary<object, object>
				{
					[(object)"defenders"] = ToFirestoreDefenders(val),
					[(object)"lastActivityAt"] = utcNow
				});
				return true;
			});
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("SignUpAsDefenderAsync failed: " + ex.Message);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CRemoveDefenderAsync_003Ed__48))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> RemoveDefenderAsync(string guildId, string playerId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		string guildId2 = guildId;
		string playerId2 = playerId;
		try
		{
			IDocumentReference guildRef = _firestore.GetCollection("guilds").GetDocument(guildId2);
			await _firestore.RunTransactionAsync<bool>((Func<ITransaction, bool>)delegate(ITransaction transaction)
			{
				//IL_0079: Unknown result type (might be due to invalid IL or missing references)
				IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(guildRef);
				if (document.Data == null)
				{
					throw new GuildNotFoundException(guildId2);
				}
				Dictionary<string, DefenderData> val = ToDomainDefenders(document.Data.Defenders);
				val.Remove(playerId2);
				transaction.UpdateData(guildRef, new Dictionary<object, object>
				{
					[(object)"defenders"] = ToFirestoreDefenders(val),
					[(object)"lastActivityAt"] = DateTimeOffset.UtcNow
				});
				return true;
			});
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("RemoveDefenderAsync failed: " + ex.Message);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CGetDefendersAsync_003Ed__49))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<List<GuildMember>> GetDefendersAsync(string guildId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		string guildId2 = guildId;
		try
		{
			Guild guild = await GetByIdAsync(guildId2);
			if (guild == null || guild.DefenderPlayerIds == null || ((global::System.Collections.Generic.IReadOnlyCollection<string>)guild.DefenderPlayerIds).Count == 0)
			{
				return new List<GuildMember>();
			}
			global::System.Collections.Generic.IEnumerable<global::System.Threading.Tasks.Task<GuildMember>> tasks = Enumerable.Select<string, global::System.Threading.Tasks.Task<GuildMember>>((global::System.Collections.Generic.IEnumerable<string>)guild.DefenderPlayerIds, (Func<string, global::System.Threading.Tasks.Task<GuildMember>>)((string id) => GetMemberAsync(guildId2, id)));
			return Enumerable.ToList<GuildMember>(Enumerable.Cast<GuildMember>((global::System.Collections.IEnumerable)Enumerable.Where<GuildMember>((global::System.Collections.Generic.IEnumerable<GuildMember>)(await global::System.Threading.Tasks.Task.WhenAll<GuildMember>(tasks)), (Func<GuildMember, bool>)((GuildMember m) => m != null))));
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("GetDefendersAsync failed: " + ex.Message);
			return new List<GuildMember>();
		}
	}

	[AsyncStateMachine(typeof(_003CSetMainDefendersAsync_003Ed__50))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> SetMainDefendersAsync(string guildId, List<string> mainDefenderPlayerIds)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		List<string> mainDefenderPlayerIds2 = mainDefenderPlayerIds;
		try
		{
			if (mainDefenderPlayerIds2 == null || mainDefenderPlayerIds2.Count > 5)
			{
				Console.WriteLine($"Main defenders must be {5} or fewer");
				return false;
			}
			IDocumentReference guildRef = _firestore.GetCollection("guilds").GetDocument(guildId);
			await _firestore.RunTransactionAsync<bool>((Func<ITransaction, bool>)delegate(ITransaction transaction)
			{
				//IL_007e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0083: Unknown result type (might be due to invalid IL or missing references)
				//IL_0132: Unknown result type (might be due to invalid IL or missing references)
				IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(guildRef);
				if (document.Data == null)
				{
					throw new global::System.Exception("Guild not found");
				}
				Dictionary<string, DefenderData> defenders = ToDomainDefenders(document.Data.Defenders);
				if (Enumerable.Any<string>((global::System.Collections.Generic.IEnumerable<string>)mainDefenderPlayerIds2, (Func<string, bool>)((string id) => !defenders.ContainsKey(id))))
				{
					throw new global::System.Exception("All main defenders must be signed up defenders");
				}
				Enumerator<string> enumerator = Enumerable.ToList<string>((global::System.Collections.Generic.IEnumerable<string>)defenders.Keys).GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						string current = enumerator.Current;
						DefenderData defenderData = defenders[current];
						bool flag = mainDefenderPlayerIds2.Contains(current);
						if (defenderData.IsMainDefender != flag)
						{
							defenders[current] = defenderData with
							{
								IsMainDefender = flag
							};
						}
					}
				}
				finally
				{
					((global::System.IDisposable)enumerator).Dispose();
				}
				transaction.UpdateData(guildRef, new Dictionary<object, object>
				{
					[(object)"defenders"] = ToFirestoreDefenders(defenders),
					[(object)"lastActivityAt"] = DateTimeOffset.UtcNow
				});
				return true;
			});
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("SetMainDefendersAsync failed: " + ex.Message);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CGetMainDefendersAsync_003Ed__51))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<List<GuildMember>> GetMainDefendersAsync(string guildId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		string guildId2 = guildId;
		try
		{
			Guild guild = await GetByIdAsync(guildId2);
			if (guild == null || guild.MainDefenderPlayerIds == null || ((global::System.Collections.Generic.IReadOnlyCollection<string>)guild.MainDefenderPlayerIds).Count == 0)
			{
				return new List<GuildMember>();
			}
			global::System.Collections.Generic.IEnumerable<global::System.Threading.Tasks.Task<GuildMember>> tasks = Enumerable.Select<string, global::System.Threading.Tasks.Task<GuildMember>>((global::System.Collections.Generic.IEnumerable<string>)guild.MainDefenderPlayerIds, (Func<string, global::System.Threading.Tasks.Task<GuildMember>>)((string id) => GetMemberAsync(guildId2, id)));
			return Enumerable.ToList<GuildMember>(Enumerable.Cast<GuildMember>((global::System.Collections.IEnumerable)Enumerable.Where<GuildMember>((global::System.Collections.Generic.IEnumerable<GuildMember>)(await global::System.Threading.Tasks.Task.WhenAll<GuildMember>(tasks)), (Func<GuildMember, bool>)((GuildMember m) => m != null))));
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("GetMainDefendersAsync failed: " + ex.Message);
			return new List<GuildMember>();
		}
	}

	[AsyncStateMachine(typeof(_003CGetGuildCrystalsAsync_003Ed__52))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<int> GetGuildCrystalsAsync(string guildId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			return (await GetByIdAsync(guildId))?.Crystals ?? 0;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("GetGuildCrystalsAsync failed: " + ex.Message);
			return 0;
		}
	}

	[AsyncStateMachine(typeof(_003CWriteRaidResultAsync_003Ed__53))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> WriteRaidResultAsync(string defendingGuildId, string attackingGuildId, string warId, int crystalsGained, int startingCrystals, string attackingPlayerId, int newRaidCountThisHour, DateTimeOffset newRaidHourStart, int totalCrystalsRaidDelta)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			IDocumentReference progressRef = _firestore.GetCollection("guilds").GetDocument(defendingGuildId).GetCollection("warProgress")
				.GetDocument(attackingGuildId);
			IDocumentSnapshot<FirestoreGuildWarProgressDTO> snapshot = await progressRef.GetDocumentSnapshotAsync<FirestoreGuildWarProgressDTO>((Source)0);
			Dictionary<string, FirestoreWarAttackerDTO> playerStats = snapshot.Data?.PlayerStats ?? new Dictionary<string, FirestoreWarAttackerDTO>();
			FirestoreWarAttackerDTO existing = default(FirestoreWarAttackerDTO);
			playerStats.TryGetValue(attackingPlayerId, ref existing);
			if (existing == null)
			{
				existing = new FirestoreWarAttackerDTO();
			}
			playerStats[attackingPlayerId] = new FirestoreWarAttackerDTO
			{
				AttackCount = existing.AttackCount,
				HourlyStart = existing.HourlyStart,
				HourlyCrystals = existing.HourlyCrystals,
				RaidCountThisHour = newRaidCountThisHour,
				RaidHourStart = newRaidHourStart,
				TotalCrystalsAttack = existing.TotalCrystalsAttack,
				TotalCrystalsRaid = existing.TotalCrystalsRaid + totalCrystalsRaidDelta
			};
			FirestoreGuildWarProgressDTO dto = new FirestoreGuildWarProgressDTO
			{
				ID = attackingGuildId,
				WarId = (snapshot.Data?.WarId ?? warId),
				AttackingGuildId = attackingGuildId,
				DefendingGuildId = defendingGuildId,
				DefeatedDefenders = (snapshot.Data?.DefeatedDefenders ?? new Dictionary<string, FirestoreWarDefenderDTO>()),
				CrystalsStolen = (snapshot.Data?.CrystalsStolen ?? 0) + crystalsGained,
				RaidCount = (snapshot.Data?.RaidCount ?? 0) + 1,
				LastRaidTime = DateTimeOffset.UtcNow,
				SeasonId = (snapshot.Data?.SeasonId ?? warId),
				TotalAttacksCount = (snapshot.Data?.TotalAttacksCount ?? 0),
				StartingCrystals = startingCrystals,
				PlayerStats = playerStats
			};
			await progressRef.SetDataAsync((object)dto, SetOptions.Merge());
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("WriteRaidResultAsync failed: " + ex.Message);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CWriteDefenderBattleResultAsync_003Ed__54))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> WriteDefenderBattleResultAsync(string attackingGuildId, string defendingGuildId, string warId, bool isVictory, int startingCrystals, string defenderPlayerId, string? attackingPlayerId, int crystalsAwarded, DateTimeOffset? attackerHourlyStart, int attackerHourlyCrystals, int newDefenderDefeatedCount, DateTimeOffset defenderDowntimeEnds, DateTimeOffset? defenderLastFellAt, int defenderCrystalsGainedDelta)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			IDocumentReference progressRef = _firestore.GetCollection("guilds").GetDocument(defendingGuildId).GetCollection("warProgress")
				.GetDocument(attackingGuildId);
			IDocumentSnapshot<FirestoreGuildWarProgressDTO> snapshot = await progressRef.GetDocumentSnapshotAsync<FirestoreGuildWarProgressDTO>((Source)0);
			Dictionary<string, FirestoreWarDefenderDTO> defeatedDefenders = snapshot.Data?.DefeatedDefenders ?? new Dictionary<string, FirestoreWarDefenderDTO>();
			FirestoreWarDefenderDTO existingDefender = default(FirestoreWarDefenderDTO);
			defeatedDefenders.TryGetValue(defenderPlayerId, ref existingDefender);
			defeatedDefenders[defenderPlayerId] = new FirestoreWarDefenderDTO
			{
				DefeatedCount = newDefenderDefeatedCount,
				DowntimeEnds = defenderDowntimeEnds,
				LastFellAt = defenderLastFellAt,
				CrystalsGained = (existingDefender?.CrystalsGained ?? 0) + defenderCrystalsGainedDelta
			};
			Dictionary<string, FirestoreWarAttackerDTO> playerStats = snapshot.Data?.PlayerStats ?? new Dictionary<string, FirestoreWarAttackerDTO>();
			if (isVictory && attackingPlayerId != null)
			{
				FirestoreWarAttackerDTO existingAttacker = default(FirestoreWarAttackerDTO);
				playerStats.TryGetValue(attackingPlayerId, ref existingAttacker);
				if (existingAttacker == null)
				{
					existingAttacker = new FirestoreWarAttackerDTO();
				}
				playerStats[attackingPlayerId] = new FirestoreWarAttackerDTO
				{
					AttackCount = existingAttacker.AttackCount,
					HourlyStart = attackerHourlyStart,
					HourlyCrystals = attackerHourlyCrystals,
					RaidCountThisHour = existingAttacker.RaidCountThisHour,
					RaidHourStart = existingAttacker.RaidHourStart,
					TotalCrystalsAttack = existingAttacker.TotalCrystalsAttack + crystalsAwarded,
					TotalCrystalsRaid = existingAttacker.TotalCrystalsRaid
				};
			}
			FirestoreGuildWarProgressDTO progressDto = new FirestoreGuildWarProgressDTO
			{
				ID = attackingGuildId,
				WarId = (snapshot.Data?.WarId ?? warId),
				AttackingGuildId = attackingGuildId,
				DefendingGuildId = defendingGuildId,
				DefeatedDefenders = defeatedDefenders,
				CrystalsStolen = (snapshot.Data?.CrystalsStolen ?? 0) + (isVictory ? crystalsAwarded : 0),
				RaidCount = (snapshot.Data?.RaidCount ?? 0),
				LastRaidTime = (snapshot.Data?.LastRaidTime ?? DateTimeOffset.MinValue),
				SeasonId = (snapshot.Data?.SeasonId ?? warId),
				TotalAttacksCount = (snapshot.Data?.TotalAttacksCount ?? 0) + 1,
				StartingCrystals = startingCrystals,
				PlayerStats = playerStats
			};
			await progressRef.SetDataAsync((object)progressDto, SetOptions.Merge());
			if (isVictory)
			{
				await SetDefenderDowntimeAndBreakAsync(defendingGuildId, defenderPlayerId, defenderDowntimeEnds);
			}
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("WriteDefenderBattleResultAsync failed: " + ex.Message);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CSetDefenderDowntimeAndBreakAsync_003Ed__55))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task SetDefenderDowntimeAndBreakAsync(string defendingGuildId, string defenderPlayerId, DateTimeOffset downtimeEnds)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		_003CSetDefenderDowntimeAndBreakAsync_003Ed__55 _003CSetDefenderDowntimeAndBreakAsync_003Ed__ = new _003CSetDefenderDowntimeAndBreakAsync_003Ed__55();
		_003CSetDefenderDowntimeAndBreakAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CSetDefenderDowntimeAndBreakAsync_003Ed__._003C_003E4__this = this;
		_003CSetDefenderDowntimeAndBreakAsync_003Ed__.defendingGuildId = defendingGuildId;
		_003CSetDefenderDowntimeAndBreakAsync_003Ed__.defenderPlayerId = defenderPlayerId;
		_003CSetDefenderDowntimeAndBreakAsync_003Ed__.downtimeEnds = downtimeEnds;
		_003CSetDefenderDowntimeAndBreakAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CSetDefenderDowntimeAndBreakAsync_003Ed__._003C_003Et__builder)).Start<_003CSetDefenderDowntimeAndBreakAsync_003Ed__55>(ref _003CSetDefenderDowntimeAndBreakAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CSetDefenderDowntimeAndBreakAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CGetWarProgressAsync_003Ed__56))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<GuildWarProgress?> GetWarProgressAsync(string attackingGuildId, string defendingGuildId, string warId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			IDocumentReference progressRef = _firestore.GetCollection("guilds").GetDocument(defendingGuildId).GetCollection("warProgress")
				.GetDocument(attackingGuildId);
			IDocumentSnapshot<FirestoreGuildWarProgressDTO> snapshot = await progressRef.GetDocumentSnapshotAsync<FirestoreGuildWarProgressDTO>((Source)0);
			if (snapshot.Data == null)
			{
				return null;
			}
			Dictionary<string, FirestoreWarAttackerDTO> playerStats = snapshot.Data.PlayerStats ?? new Dictionary<string, FirestoreWarAttackerDTO>();
			Dictionary<string, long> playerAttackCounts = Enumerable.ToDictionary<KeyValuePair<string, FirestoreWarAttackerDTO>, string, long>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, FirestoreWarAttackerDTO>>)playerStats, (Func<KeyValuePair<string, FirestoreWarAttackerDTO>, string>)((KeyValuePair<string, FirestoreWarAttackerDTO> kvp) => kvp.Key), (Func<KeyValuePair<string, FirestoreWarAttackerDTO>, long>)((KeyValuePair<string, FirestoreWarAttackerDTO> kvp) => kvp.Value.AttackCount));
			Dictionary<string, DateTimeOffset?> playerHourlyStarts = Enumerable.ToDictionary<KeyValuePair<string, FirestoreWarAttackerDTO>, string, DateTimeOffset?>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, FirestoreWarAttackerDTO>>)playerStats, (Func<KeyValuePair<string, FirestoreWarAttackerDTO>, string>)((KeyValuePair<string, FirestoreWarAttackerDTO> kvp) => kvp.Key), (Func<KeyValuePair<string, FirestoreWarAttackerDTO>, DateTimeOffset?>)((KeyValuePair<string, FirestoreWarAttackerDTO> kvp) => kvp.Value.HourlyStart));
			Dictionary<string, int> playerHourlyCrystals = Enumerable.ToDictionary<KeyValuePair<string, FirestoreWarAttackerDTO>, string, int>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, FirestoreWarAttackerDTO>>)playerStats, (Func<KeyValuePair<string, FirestoreWarAttackerDTO>, string>)((KeyValuePair<string, FirestoreWarAttackerDTO> kvp) => kvp.Key), (Func<KeyValuePair<string, FirestoreWarAttackerDTO>, int>)((KeyValuePair<string, FirestoreWarAttackerDTO> kvp) => kvp.Value.HourlyCrystals));
			Dictionary<string, DefenderWarRecord> defeatedDefenders = Enumerable.ToDictionary<KeyValuePair<string, FirestoreWarDefenderDTO>, string, DefenderWarRecord>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, FirestoreWarDefenderDTO>>)(snapshot.Data.DefeatedDefenders ?? new Dictionary<string, FirestoreWarDefenderDTO>()), (Func<KeyValuePair<string, FirestoreWarDefenderDTO>, string>)((KeyValuePair<string, FirestoreWarDefenderDTO> kvp) => kvp.Key), (Func<KeyValuePair<string, FirestoreWarDefenderDTO>, DefenderWarRecord>)((KeyValuePair<string, FirestoreWarDefenderDTO> kvp) => new DefenderWarRecord(kvp.Value.DefeatedCount, kvp.Value.DowntimeEnds, kvp.Value.LastFellAt, kvp.Value.CrystalsGained)));
			Dictionary<string, int> playerRaidCounts = Enumerable.ToDictionary<KeyValuePair<string, FirestoreWarAttackerDTO>, string, int>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, FirestoreWarAttackerDTO>>)playerStats, (Func<KeyValuePair<string, FirestoreWarAttackerDTO>, string>)((KeyValuePair<string, FirestoreWarAttackerDTO> kvp) => kvp.Key), (Func<KeyValuePair<string, FirestoreWarAttackerDTO>, int>)((KeyValuePair<string, FirestoreWarAttackerDTO> kvp) => kvp.Value.RaidCountThisHour));
			Dictionary<string, DateTimeOffset?> playerRaidHourStarts = Enumerable.ToDictionary<KeyValuePair<string, FirestoreWarAttackerDTO>, string, DateTimeOffset?>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, FirestoreWarAttackerDTO>>)playerStats, (Func<KeyValuePair<string, FirestoreWarAttackerDTO>, string>)((KeyValuePair<string, FirestoreWarAttackerDTO> kvp) => kvp.Key), (Func<KeyValuePair<string, FirestoreWarAttackerDTO>, DateTimeOffset?>)((KeyValuePair<string, FirestoreWarAttackerDTO> kvp) => kvp.Value.RaidHourStart));
			Dictionary<string, int> playerTotalCrystalsAttack = Enumerable.ToDictionary<KeyValuePair<string, FirestoreWarAttackerDTO>, string, int>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, FirestoreWarAttackerDTO>>)playerStats, (Func<KeyValuePair<string, FirestoreWarAttackerDTO>, string>)((KeyValuePair<string, FirestoreWarAttackerDTO> kvp) => kvp.Key), (Func<KeyValuePair<string, FirestoreWarAttackerDTO>, int>)((KeyValuePair<string, FirestoreWarAttackerDTO> kvp) => kvp.Value.TotalCrystalsAttack));
			Dictionary<string, int> playerTotalCrystalsRaid = Enumerable.ToDictionary<KeyValuePair<string, FirestoreWarAttackerDTO>, string, int>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, FirestoreWarAttackerDTO>>)playerStats, (Func<KeyValuePair<string, FirestoreWarAttackerDTO>, string>)((KeyValuePair<string, FirestoreWarAttackerDTO> kvp) => kvp.Key), (Func<KeyValuePair<string, FirestoreWarAttackerDTO>, int>)((KeyValuePair<string, FirestoreWarAttackerDTO> kvp) => kvp.Value.TotalCrystalsRaid));
			return new GuildWarProgress
			{
				ID = (snapshot.Data.ID ?? string.Empty),
				WarId = (snapshot.Data.WarId ?? string.Empty),
				AttackingGuildId = (snapshot.Data.AttackingGuildId ?? string.Empty),
				DefendingGuildId = (snapshot.Data.DefendingGuildId ?? string.Empty),
				DefeatedDefenders = defeatedDefenders,
				CrystalsStolen = snapshot.Data.CrystalsStolen,
				LastRaidTime = snapshot.Data.LastRaidTime,
				SeasonId = (snapshot.Data.SeasonId ?? string.Empty),
				TotalAttacksCount = snapshot.Data.TotalAttacksCount,
				RaidCount = snapshot.Data.RaidCount,
				StartingCrystals = snapshot.Data.StartingCrystals,
				PlayerAttackCounts = playerAttackCounts,
				PlayerHourlyStarts = playerHourlyStarts,
				PlayerHourlyCrystals = playerHourlyCrystals,
				PlayerRaidCounts = playerRaidCounts,
				PlayerRaidHourStarts = playerRaidHourStarts,
				PlayerTotalCrystalsAttack = playerTotalCrystalsAttack,
				PlayerTotalCrystalsRaid = playerTotalCrystalsRaid
			};
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("GetWarProgressAsync failed: " + ex.Message);
			return null;
		}
	}

	[AsyncStateMachine(typeof(_003CUpdateAttackCountsAsync_003Ed__57))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> UpdateAttackCountsAsync(string attackingGuildId, string defendingGuildId, string warId, Dictionary<string, long> playerAttackCounts, DateTimeOffset lastResetTime)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			IDocumentReference progressRef = _firestore.GetCollection("guilds").GetDocument(defendingGuildId).GetCollection("warProgress")
				.GetDocument(attackingGuildId);
			IDocumentSnapshot<FirestoreGuildWarProgressDTO> snapshot = await progressRef.GetDocumentSnapshotAsync<FirestoreGuildWarProgressDTO>((Source)0);
			Dictionary<string, FirestoreWarAttackerDTO> playerStats = snapshot.Data?.PlayerStats ?? new Dictionary<string, FirestoreWarAttackerDTO>();
			Enumerator<string, long> enumerator = playerAttackCounts.GetEnumerator();
			try
			{
				string text = default(string);
				long num = default(long);
				FirestoreWarAttackerDTO existing = default(FirestoreWarAttackerDTO);
				while (enumerator.MoveNext())
				{
					enumerator.Current.Deconstruct(ref text, ref num);
					string playerId = text;
					long count = num;
					playerStats.TryGetValue(playerId, ref existing);
					playerStats[playerId] = new FirestoreWarAttackerDTO
					{
						AttackCount = count,
						HourlyStart = existing?.HourlyStart,
						HourlyCrystals = (existing?.HourlyCrystals ?? 0),
						RaidCountThisHour = (existing?.RaidCountThisHour ?? 0),
						RaidHourStart = existing?.RaidHourStart,
						TotalCrystalsAttack = (existing?.TotalCrystalsAttack ?? 0),
						TotalCrystalsRaid = (existing?.TotalCrystalsRaid ?? 0)
					};
					existing = null;
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator).Dispose();
			}
			FirestoreGuildWarProgressDTO dto = new FirestoreGuildWarProgressDTO
			{
				ID = attackingGuildId,
				WarId = (snapshot.Data?.WarId ?? warId),
				AttackingGuildId = attackingGuildId,
				DefendingGuildId = defendingGuildId,
				DefeatedDefenders = (snapshot.Data?.DefeatedDefenders ?? new Dictionary<string, FirestoreWarDefenderDTO>()),
				CrystalsStolen = (snapshot.Data?.CrystalsStolen ?? 0),
				RaidCount = (snapshot.Data?.RaidCount ?? 0),
				LastRaidTime = (snapshot.Data?.LastRaidTime ?? DateTimeOffset.MinValue),
				SeasonId = (snapshot.Data?.SeasonId ?? warId),
				TotalAttacksCount = (snapshot.Data?.TotalAttacksCount ?? 0),
				StartingCrystals = (snapshot.Data?.StartingCrystals ?? 0),
				PlayerStats = playerStats
			};
			await progressRef.SetDataAsync((object)dto, SetOptions.Merge());
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("UpdateAttackCountsAsync failed: " + ex.Message);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CGetAvailableDefendersAsync_003Ed__58))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<List<string>> GetAvailableDefendersAsync(string attackingGuildId, string defendingGuildId, string warId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Guild defendingGuild = await GetByIdAsync(defendingGuildId);
			if (defendingGuild == null)
			{
				return new List<string>();
			}
			if (defendingGuild.IsInGuildBreak)
			{
				return new List<string>();
			}
			return defendingGuild.GetAvailableDefenderIds();
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("GetAvailableDefendersAsync failed: " + ex.Message);
			return new List<string>();
		}
	}

	[AsyncStateMachine(typeof(_003CGetNextDefenderAsync_003Ed__59))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<GuildMember?> GetNextDefenderAsync(string attackingGuildId, string defendingGuildId, string warId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Guild defendingGuild = await GetByIdAsync(defendingGuildId);
			if (defendingGuild == null)
			{
				return null;
			}
			List<string> availableDefenderIds = await GetAvailableDefendersAsync(attackingGuildId, defendingGuildId, warId);
			if (!Enumerable.Any<string>((global::System.Collections.Generic.IEnumerable<string>)availableDefenderIds))
			{
				return null;
			}
			Random random = new Random();
			List<string> activeMainDefenderIds = Enumerable.ToList<string>(Enumerable.Where<string>((global::System.Collections.Generic.IEnumerable<string>)defendingGuild.MainDefenderPlayerIds, (Func<string, bool>)((string id) => availableDefenderIds.Contains(id))));
			string selectedDefenderId = ((!Enumerable.Any<string>((global::System.Collections.Generic.IEnumerable<string>)activeMainDefenderIds)) ? availableDefenderIds[random.Next(availableDefenderIds.Count)] : activeMainDefenderIds[random.Next(activeMainDefenderIds.Count)]);
			return await GetMemberAsync(defendingGuildId, selectedDefenderId);
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("GetNextDefenderAsync failed: " + ex.Message);
			return null;
		}
	}

	[AsyncStateMachine(typeof(_003CRemoveExpiredDefendersAsync_003Ed__60))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<int> RemoveExpiredDefendersAsync(string guildId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			IDocumentReference guildRef = _firestore.GetCollection("guilds").GetDocument(guildId);
			int removedCount = 0;
			await _firestore.RunTransactionAsync<int>((Func<ITransaction, int>)delegate(ITransaction transaction)
			{
				//IL_0040: Unknown result type (might be due to invalid IL or missing references)
				//IL_0045: Unknown result type (might be due to invalid IL or missing references)
				//IL_0088: Unknown result type (might be due to invalid IL or missing references)
				//IL_008d: Unknown result type (might be due to invalid IL or missing references)
				//IL_010e: Unknown result type (might be due to invalid IL or missing references)
				IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(guildRef);
				if (document.Data == null)
				{
					throw new global::System.Exception("Guild not found");
				}
				Dictionary<string, DefenderData> val = ToDomainDefenders(document.Data.Defenders);
				DateTimeOffset now = DateTimeOffset.UtcNow;
				List<string> val2 = Enumerable.ToList<string>(Enumerable.Select<KeyValuePair<string, DefenderData>, string>(Enumerable.Where<KeyValuePair<string, DefenderData>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, DefenderData>>)val, (Func<KeyValuePair<string, DefenderData>, bool>)((KeyValuePair<string, DefenderData> kv) => kv.Value.ExpiresAt <= now)), (Func<KeyValuePair<string, DefenderData>, string>)((KeyValuePair<string, DefenderData> kv) => kv.Key)));
				Enumerator<string> enumerator = val2.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						string current = enumerator.Current;
						val.Remove(current);
						removedCount++;
					}
				}
				finally
				{
					((global::System.IDisposable)enumerator).Dispose();
				}
				if (removedCount > 0)
				{
					transaction.UpdateData(guildRef, new Dictionary<object, object>
					{
						[(object)"defenders"] = ToFirestoreDefenders(val),
						[(object)"lastActivityAt"] = now
					});
				}
				return removedCount;
			});
			return removedCount;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("RemoveExpiredDefendersAsync failed: " + ex.Message);
			return 0;
		}
	}

	[AsyncStateMachine(typeof(_003CRegisterAsDefenderAsync_003Ed__61))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> RegisterAsDefenderAsync(Guild guild, string playerId, List<string> squadIds)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		Guild guild2 = guild;
		string playerId2 = playerId;
		List<string> squadIds2 = squadIds;
		try
		{
			if (squadIds2 == null || squadIds2.Count != 3)
			{
				throw new InvalidDefenderSquadException(guild2.ID ?? "", squadIds2?.Count ?? 0);
			}
			if (!guild2.CurrentSeasonStartDate.HasValue)
			{
				throw new GuildWarException("Guild is not in active war season", guild2.ID);
			}
			IDocumentReference guildRef = _firestore.GetCollection("guilds").GetDocument(guild2.ID);
			await _firestore.RunTransactionAsync<bool>((Func<ITransaction, bool>)delegate(ITransaction transaction)
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				//IL_0069: Unknown result type (might be due to invalid IL or missing references)
				//IL_006e: Unknown result type (might be due to invalid IL or missing references)
				//IL_007b: Unknown result type (might be due to invalid IL or missing references)
				//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
				//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
				//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
				//IL_010b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0153: Unknown result type (might be due to invalid IL or missing references)
				DateTimeOffset utcNow = DateTimeOffset.UtcNow;
				Dictionary<string, DefenderData> defenders = guild2.Defenders;
				DefenderData defenderData = default(DefenderData);
				DateTimeOffset value;
				if (defenders.TryGetValue(playerId2, ref defenderData))
				{
					string text = playerId2;
					DefenderData obj = defenderData with
					{
						SquadIds = squadIds2
					};
					value = guild2.CurrentSeasonStartDate.Value;
					obj.ExpiresAt = ((DateTimeOffset)(ref value)).AddHours(8.0);
					defenders[text] = obj;
				}
				else
				{
					if (defenders.Count >= 25)
					{
						throw new MaxDefendersReachedException(guild2.ID ?? "", defenders.Count, 25);
					}
					string text2 = playerId2;
					List<string> squadIds3 = squadIds2;
					value = guild2.CurrentSeasonStartDate.Value;
					defenders[text2] = new DefenderData(squadIds3, utcNow, ((DateTimeOffset)(ref value)).AddHours(8.0), IsMainDefender: false);
				}
				transaction.UpdateData(guildRef, new Dictionary<object, object>
				{
					[(object)"defenders"] = ToFirestoreDefenders(defenders),
					[(object)"lastActivityAt"] = utcNow
				});
				return true;
			});
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("RegisterAsDefenderAsync failed: " + ex.Message);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CUnregisterAsDefenderAsync_003Ed__62))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> UnregisterAsDefenderAsync(string guildId, string playerId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		string guildId2 = guildId;
		string playerId2 = playerId;
		try
		{
			IDocumentReference guildRef = _firestore.GetCollection("guilds").GetDocument(guildId2);
			await _firestore.RunTransactionAsync<bool>((Func<ITransaction, bool>)delegate(ITransaction transaction)
			{
				//IL_0079: Unknown result type (might be due to invalid IL or missing references)
				IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(guildRef);
				if (document.Data == null)
				{
					throw new GuildNotFoundException(guildId2);
				}
				Dictionary<string, DefenderData> val = ToDomainDefenders(document.Data.Defenders);
				val.Remove(playerId2);
				transaction.UpdateData(guildRef, new Dictionary<object, object>
				{
					[(object)"defenders"] = ToFirestoreDefenders(val),
					[(object)"lastActivityAt"] = DateTimeOffset.UtcNow
				});
				return true;
			});
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("UnregisterAsDefenderAsync failed: " + ex.Message);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CRefreshDefenderAsync_003Ed__63))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> RefreshDefenderAsync(string guildId, string playerId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		string playerId2 = playerId;
		try
		{
			IDocumentReference guildRef = _firestore.GetCollection("guilds").GetDocument(guildId);
			return await _firestore.RunTransactionAsync<bool>((Func<ITransaction, bool>)delegate(ITransaction transaction)
			{
				//IL_002c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0031: Unknown result type (might be due to invalid IL or missing references)
				//IL_0045: Unknown result type (might be due to invalid IL or missing references)
				//IL_004a: Unknown result type (might be due to invalid IL or missing references)
				//IL_0094: Unknown result type (might be due to invalid IL or missing references)
				//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
				IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(guildRef);
				if (document.Data == null)
				{
					return false;
				}
				DateTimeOffset now = DateTimeOffset.UtcNow;
				DateTimeOffset expiresAt = ((DateTimeOffset)(ref now)).AddHours(8.0);
				Dictionary<string, DefenderData> val = ToDomainDefenders(document.Data.Defenders);
				DefenderData defenderData = default(DefenderData);
				if (!val.TryGetValue(playerId2, ref defenderData))
				{
					return false;
				}
				val[playerId2] = defenderData with
				{
					ExpiresAt = expiresAt,
					DowntimeEnds = null
				};
				Dictionary<object, object> val2 = new Dictionary<object, object>
				{
					[(object)"defenders"] = ToFirestoreDefenders(val),
					[(object)"lastActivityAt"] = now
				};
				if (Enumerable.Any<DefenderData>((global::System.Collections.Generic.IEnumerable<DefenderData>)val.Values, (Func<DefenderData, bool>)((DefenderData d) => d.ExpiresAt > now && (!d.DowntimeEnds.HasValue || !(d.DowntimeEnds.Value > now)))))
				{
					val2[(object)"guildBreakEndsAt"] = null;
				}
				transaction.UpdateData(guildRef, val2);
				return true;
			});
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("RefreshDefenderAsync failed: " + ex.Message);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CGetWarBucketOpponentsAsync_003Ed__64))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<List<Guild>> GetWarBucketOpponentsAsync(string guildId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		string guildId2 = guildId;
		try
		{
			Guild guild = await GetByIdAsync(guildId2);
			if (guild == null || string.IsNullOrEmpty(guild.CurrentWarId))
			{
				return new List<Guild>();
			}
			List<string> ids = (await _firestore.GetCollection("guildWars").GetDocument(guild.CurrentWarId).GetDocumentSnapshotAsync<FirestoreActiveWarDTO>((Source)0)).Data?.ParticipantGuildIds;
			if (ids == null || ids.Count == 0)
			{
				return new List<Guild>();
			}
			List<string> others = Enumerable.ToList<string>(Enumerable.Distinct<string>(Enumerable.Where<string>((global::System.Collections.Generic.IEnumerable<string>)ids, (Func<string, bool>)((string id) => id != guildId2))));
			return Enumerable.ToList<Guild>(Enumerable.Select<Guild, Guild>(Enumerable.Where<Guild>((global::System.Collections.Generic.IEnumerable<Guild>)(await global::System.Threading.Tasks.Task.WhenAll<Guild>(Enumerable.Select<string, global::System.Threading.Tasks.Task<Guild>>((global::System.Collections.Generic.IEnumerable<string>)others, (Func<string, global::System.Threading.Tasks.Task<Guild>>)((string id) => GetByIdAsync(id))))), (Func<Guild, bool>)((Guild g) => g != null)), (Func<Guild, Guild>)((Guild g) => g)));
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("GetWarBucketOpponentsAsync failed: " + ex.Message);
			return new List<Guild>();
		}
	}

	[AsyncStateMachine(typeof(_003CApplyGuildPerkAsync_003Ed__65))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> ApplyGuildPerkAsync(string guildId, string perkKey, int tier, DateTimeOffset activatedAt, string activatedByPlayerId, int crystalCost)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		string perkKey2 = perkKey;
		string activatedByPlayerId2 = activatedByPlayerId;
		try
		{
			IDocumentReference guildRef = _firestore.GetCollection("guilds").GetDocument(guildId);
			return await _firestore.RunTransactionAsync<bool>((Func<ITransaction, bool>)delegate(ITransaction transaction)
			{
				//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
				//IL_0120: Unknown result type (might be due to invalid IL or missing references)
				//IL_0045: Unknown result type (might be due to invalid IL or missing references)
				IDocumentSnapshot<FirestoreGuildDTO> document = transaction.GetDocument<FirestoreGuildDTO>(guildRef);
				if (document.Data == null)
				{
					return false;
				}
				if (document.Data.Crystals < crystalCost)
				{
					throw new InvalidOperationException("Insufficient guild crystals");
				}
				Dictionary<object, object> val = new Dictionary<object, object>
				{
					[(object)"crystals"] = document.Data.Crystals - crystalCost,
					[(object)("activePerks." + perkKey2 + ".tier")] = tier,
					[(object)("activePerks." + perkKey2 + ".activatedAt")] = activatedAt,
					[(object)("activePerks." + perkKey2 + ".activatedByPlayerId")] = activatedByPlayerId2,
					[(object)"lastActivityAt"] = DateTimeOffset.UtcNow
				};
				transaction.UpdateData(guildRef, val);
				return true;
			});
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("ApplyGuildPerkAsync failed: " + ex.Message);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CSendNotificationToPlayerAsync_003Ed__66))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task SendNotificationToPlayerAsync(string targetPlayerId, NotificationType type, Dictionary<string, object> data)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CSendNotificationToPlayerAsync_003Ed__66 _003CSendNotificationToPlayerAsync_003Ed__ = new _003CSendNotificationToPlayerAsync_003Ed__66();
		_003CSendNotificationToPlayerAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CSendNotificationToPlayerAsync_003Ed__._003C_003E4__this = this;
		_003CSendNotificationToPlayerAsync_003Ed__.targetPlayerId = targetPlayerId;
		_003CSendNotificationToPlayerAsync_003Ed__.type = type;
		_003CSendNotificationToPlayerAsync_003Ed__.data = data;
		_003CSendNotificationToPlayerAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CSendNotificationToPlayerAsync_003Ed__._003C_003Et__builder)).Start<_003CSendNotificationToPlayerAsync_003Ed__66>(ref _003CSendNotificationToPlayerAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CSendNotificationToPlayerAsync_003Ed__._003C_003Et__builder)).Task;
	}
}
