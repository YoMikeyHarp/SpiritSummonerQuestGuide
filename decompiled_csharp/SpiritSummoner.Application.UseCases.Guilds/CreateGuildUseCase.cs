using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.BatchUpdates;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Guilds;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Enums.Guilds;
using SpiritSummoner.Domain.Repositories;

namespace SpiritSummoner.Application.UseCases.Guilds;

public class CreateGuildUseCase : IUseCase<CreateGuildRequest, Guild>
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public Guild guild;

		internal bool _003CExecuteAsync_003Eb__1(Player p)
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			p.SetGuildInfo(guild.ID, GuildRole.Guildmaster, DateTimeOffset.UtcNow);
			return true;
		}

		internal PlayerBatchUpdate _003CExecuteAsync_003Eb__2(Player p, bool _)
		{
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			return new PlayerBatchUpdate
			{
				PlayerId = p.PlayerID,
				GuildUpdates = new PlayerGuildUpdate
				{
					GuildId = guild.ID,
					GuildRole = ((object)GuildRole.Guildmaster).ToString(),
					GuildJoinedAt = DateTimeOffset.UtcNow,
					TargetPlayerId = p.PlayerID
				}
			};
		}
	}

	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<Guild>> _003C_003Et__builder;

		public CreateGuildRequest request;

		public CreateGuildUseCase _003C_003E4__this;

		private _003C_003Ec__DisplayClass3_0 _003C_003E8__1;

		private Player _003Cplayer_003E5__2;

		private Result<bool> _003CstateResult_003E5__3;

		private Guild _003CreadModel_003E5__4;

		private Guild _003C_003Es__5;

		private TaskAwaiter<Guild?> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_016c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0171: Unknown result type (might be due to invalid IL or missing references)
			//IL_0179: Unknown result type (might be due to invalid IL or missing references)
			//IL_0132: Unknown result type (might be due to invalid IL or missing references)
			//IL_0137: Unknown result type (might be due to invalid IL or missing references)
			//IL_014c: Unknown result type (might be due to invalid IL or missing references)
			//IL_014e: Unknown result type (might be due to invalid IL or missing references)
			//IL_04a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ba: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<Guild> result;
			try
			{
				TaskAwaiter<Guild> awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Guild>);
					num = (_003C_003E1__state = -1);
					goto IL_0188;
				}
				_003C_003E8__1 = new _003C_003Ec__DisplayClass3_0();
				_003Cplayer_003E5__2 = _003C_003E4__this._playerStateService.GetCurrentPlayer();
				if (string.IsNullOrWhiteSpace(_003Cplayer_003E5__2.PlayerID))
				{
					result = Result<Guild>.FailureResult("Leader player ID is required");
				}
				else if (string.IsNullOrWhiteSpace(request.GuildName))
				{
					result = Result<Guild>.FailureResult("Guild name is required");
				}
				else if (request.GuildName.Length < 3)
				{
					result = Result<Guild>.FailureResult("Guild name must be at least 3 characters");
				}
				else if (request.GuildName.Length > 20)
				{
					result = Result<Guild>.FailureResult("Guild name must be at most 20 characters");
				}
				else if (_003Cplayer_003E5__2.PlayerLevel < 5)
				{
					result = Result<Guild>.FailureResult("You must be at least level 10 to create a guild");
				}
				else
				{
					if (_003Cplayer_003E5__2.IsAccountLinked)
					{
						awaiter = _003C_003E4__this._guildRepository.CreateGuildAsync(request, _003Cplayer_003E5__2).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CExecuteAsync_003Ed__3 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Guild>, _003CExecuteAsync_003Ed__3>(ref awaiter, ref _003CExecuteAsync_003Ed__);
							return;
						}
						goto IL_0188;
					}
					result = Result<Guild>.FailureResult("You must link your account to compete in guilds");
				}
				goto end_IL_0007;
				IL_0188:
				_003C_003Es__5 = awaiter.GetResult();
				_003C_003E8__1.guild = _003C_003Es__5;
				_003C_003Es__5 = null;
				if (_003C_003E8__1.guild == null)
				{
					result = Result<Guild>.FailureResult("Failed to create guild. The name might already be taken.");
				}
				else
				{
					_003CstateResult_003E5__3 = _003C_003E4__this._playerStateService.ExecuteUpdate<bool>((Player _) => ValidationResult.Success(), delegate(Player p)
					{
						//IL_000e: Unknown result type (might be due to invalid IL or missing references)
						p.SetGuildInfo(_003C_003E8__1.guild.ID, GuildRole.Guildmaster, DateTimeOffset.UtcNow);
						return true;
					}, (Player p, bool _) => new PlayerBatchUpdate
					{
						PlayerId = p.PlayerID,
						GuildUpdates = new PlayerGuildUpdate
						{
							GuildId = _003C_003E8__1.guild.ID,
							GuildRole = ((object)GuildRole.Guildmaster).ToString(),
							GuildJoinedAt = DateTimeOffset.UtcNow,
							TargetPlayerId = p.PlayerID
						}
					});
					if (!_003CstateResult_003E5__3.Success)
					{
						result = Result<Guild>.FailureResult("Guild created but local state update failed: " + _003CstateResult_003E5__3.ErrorMessage);
					}
					else
					{
						_003CreadModel_003E5__4 = new Guild
						{
							ID = (_003C_003E8__1.guild.ID ?? string.Empty),
							Name = (_003C_003E8__1.guild.Name ?? string.Empty),
							Description = (_003C_003E8__1.guild.Description ?? string.Empty),
							Emblem = _003C_003E8__1.guild.Emblem,
							Level = _003C_003E8__1.guild.Level,
							CurrentXP = _003C_003E8__1.guild.CurrentXP,
							XPForNextLevel = _003C_003E8__1.guild.XPForNextLevel,
							Rank = _003C_003E8__1.guild.Rank,
							LeaderPlayerId = (_003C_003E8__1.guild.LeaderPlayerId ?? string.Empty),
							MemberCount = _003C_003E8__1.guild.MemberCount,
							MaxMembers = _003C_003E8__1.guild.MaxMembers,
							Crystals = _003C_003E8__1.guild.Crystals,
							StartingCrystals = _003C_003E8__1.guild.StartingCrystals,
							CurrentSeasonStartDate = _003C_003E8__1.guild.CurrentSeasonStartDate,
							CurrentSeasonEndDate = _003C_003E8__1.guild.CurrentSeasonEndDate,
							Trophies = _003C_003E8__1.guild.Trophies,
							TotalWins = _003C_003E8__1.guild.TotalWins,
							TotalLosses = _003C_003E8__1.guild.TotalLosses,
							GuildCoins = _003C_003E8__1.guild.GuildCoins,
							IsPublic = _003C_003E8__1.guild.IsPublic,
							RequiresApproval = _003C_003E8__1.guild.RequiresApproval,
							MinLevelRequired = _003C_003E8__1.guild.MinLevelRequired,
							MinTrophiesRequired = _003C_003E8__1.guild.MinTrophiesRequired,
							CreatedAt = _003C_003E8__1.guild.CreatedAt,
							LastActivityAt = _003C_003E8__1.guild.LastActivityAt
						};
						result = Result<Guild>.SuccessResult(_003CreadModel_003E5__4);
					}
				}
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003Cplayer_003E5__2 = null;
				_003CstateResult_003E5__3 = null;
				_003CreadModel_003E5__4 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003Cplayer_003E5__2 = null;
			_003CstateResult_003E5__3 = null;
			_003CreadModel_003E5__4 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IGuildRepository _guildRepository;

	private readonly IPlayerStateService _playerStateService;

	public CreateGuildUseCase(IGuildRepository guildRepository, IPlayerStateService playerStateService)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		_guildRepository = guildRepository ?? throw new ArgumentNullException("guildRepository");
		_playerStateService = playerStateService ?? throw new ArgumentNullException("playerStateService");
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__3))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<Guild>> ExecuteAsync(CreateGuildRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		Player player = _playerStateService.GetCurrentPlayer();
		if (string.IsNullOrWhiteSpace(player.PlayerID))
		{
			return Result<Guild>.FailureResult("Leader player ID is required");
		}
		if (string.IsNullOrWhiteSpace(request.GuildName))
		{
			return Result<Guild>.FailureResult("Guild name is required");
		}
		if (request.GuildName.Length < 3)
		{
			return Result<Guild>.FailureResult("Guild name must be at least 3 characters");
		}
		if (request.GuildName.Length > 20)
		{
			return Result<Guild>.FailureResult("Guild name must be at most 20 characters");
		}
		if (player.PlayerLevel < 5)
		{
			return Result<Guild>.FailureResult("You must be at least level 10 to create a guild");
		}
		if (!player.IsAccountLinked)
		{
			return Result<Guild>.FailureResult("You must link your account to compete in guilds");
		}
		Guild guild = await _guildRepository.CreateGuildAsync(request, player);
		if (guild == null)
		{
			return Result<Guild>.FailureResult("Failed to create guild. The name might already be taken.");
		}
		Result<bool> stateResult = _playerStateService.ExecuteUpdate<bool>((Player _) => ValidationResult.Success(), delegate(Player p)
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			p.SetGuildInfo(guild.ID, GuildRole.Guildmaster, DateTimeOffset.UtcNow);
			return true;
		}, (Player p, bool _) => new PlayerBatchUpdate
		{
			PlayerId = p.PlayerID,
			GuildUpdates = new PlayerGuildUpdate
			{
				GuildId = guild.ID,
				GuildRole = ((object)GuildRole.Guildmaster).ToString(),
				GuildJoinedAt = DateTimeOffset.UtcNow,
				TargetPlayerId = p.PlayerID
			}
		});
		if (!stateResult.Success)
		{
			return Result<Guild>.FailureResult("Guild created but local state update failed: " + stateResult.ErrorMessage);
		}
		Guild readModel = new Guild
		{
			ID = (guild.ID ?? string.Empty),
			Name = (guild.Name ?? string.Empty),
			Description = (guild.Description ?? string.Empty),
			Emblem = guild.Emblem,
			Level = guild.Level,
			CurrentXP = guild.CurrentXP,
			XPForNextLevel = guild.XPForNextLevel,
			Rank = guild.Rank,
			LeaderPlayerId = (guild.LeaderPlayerId ?? string.Empty),
			MemberCount = guild.MemberCount,
			MaxMembers = guild.MaxMembers,
			Crystals = guild.Crystals,
			StartingCrystals = guild.StartingCrystals,
			CurrentSeasonStartDate = guild.CurrentSeasonStartDate,
			CurrentSeasonEndDate = guild.CurrentSeasonEndDate,
			Trophies = guild.Trophies,
			TotalWins = guild.TotalWins,
			TotalLosses = guild.TotalLosses,
			GuildCoins = guild.GuildCoins,
			IsPublic = guild.IsPublic,
			RequiresApproval = guild.RequiresApproval,
			MinLevelRequired = guild.MinLevelRequired,
			MinTrophiesRequired = guild.MinTrophiesRequired,
			CreatedAt = guild.CreatedAt,
			LastActivityAt = guild.LastActivityAt
		};
		return Result<Guild>.SuccessResult(readModel);
	}
}
