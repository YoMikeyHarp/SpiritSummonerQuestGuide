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

public class JoinGuildUseCase : IUseCase<JoinGuildRequest, JoinGuildResult>
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public JoinGuildRequest request;

		public DateTimeOffset joinedAt;

		internal bool _003CExecuteAsync_003Eb__1(Player p)
		{
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			p.SetGuildInfo(request.GuildId, GuildRole.Member, joinedAt);
			return true;
		}

		internal PlayerBatchUpdate _003CExecuteAsync_003Eb__2(Player p, bool _)
		{
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			return new PlayerBatchUpdate
			{
				PlayerId = p.PlayerID,
				GuildUpdates = new PlayerGuildUpdate
				{
					GuildId = request.GuildId,
					GuildRole = ((object)GuildRole.Member).ToString(),
					GuildJoinedAt = joinedAt,
					TargetPlayerId = p.PlayerID
				}
			};
		}
	}

	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<JoinGuildResult>> _003C_003Et__builder;

		public JoinGuildRequest request;

		public JoinGuildUseCase _003C_003E4__this;

		private _003C_003Ec__DisplayClass3_0 _003C_003E8__1;

		private Guild _003Cguild_003E5__2;

		private bool _003Cjoined_003E5__3;

		private Guild _003C_003Es__4;

		private bool _003CrequestSent_003E5__5;

		private bool _003C_003Es__6;

		private bool _003C_003Es__7;

		private TaskAwaiter<Guild?> _003C_003Eu__1;

		private TaskAwaiter<bool> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0303: Unknown result type (might be due to invalid IL or missing references)
			//IL_0308: Unknown result type (might be due to invalid IL or missing references)
			//IL_0310: Unknown result type (might be due to invalid IL or missing references)
			//IL_040d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0412: Unknown result type (might be due to invalid IL or missing references)
			//IL_041a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0467: Unknown result type (might be due to invalid IL or missing references)
			//IL_046c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<JoinGuildResult> result;
			try
			{
				TaskAwaiter<Guild> awaiter3;
				TaskAwaiter<bool> awaiter2;
				TaskAwaiter<bool> awaiter;
				switch (num)
				{
				default:
					_003C_003E8__1 = new _003C_003Ec__DisplayClass3_0();
					_003C_003E8__1.request = request;
					if (string.IsNullOrWhiteSpace(_003C_003E8__1.request.PlayerId))
					{
						result = Result<JoinGuildResult>.FailureResult("Player ID is required");
					}
					else if (string.IsNullOrWhiteSpace(_003C_003E8__1.request.PlayerName))
					{
						result = Result<JoinGuildResult>.FailureResult("Player name is required");
					}
					else
					{
						if (!string.IsNullOrWhiteSpace(_003C_003E8__1.request.GuildId))
						{
							awaiter3 = _003C_003E4__this._guildRepository.GetByIdAsync(_003C_003E8__1.request.GuildId).GetAwaiter();
							if (!awaiter3.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter3;
								_003CExecuteAsync_003Ed__3 _003CExecuteAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Guild>, _003CExecuteAsync_003Ed__3>(ref awaiter3, ref _003CExecuteAsync_003Ed__);
								return;
							}
							goto IL_013a;
						}
						result = Result<JoinGuildResult>.FailureResult("Guild ID is required");
					}
					goto end_IL_0007;
				case 0:
					awaiter3 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Guild>);
					num = (_003C_003E1__state = -1);
					goto IL_013a;
				case 1:
					awaiter2 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
					goto IL_031f;
				case 2:
					{
						awaiter = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_031f:
					_003C_003Es__6 = awaiter2.GetResult();
					_003CrequestSent_003E5__5 = _003C_003Es__6;
					result = (_003CrequestSent_003E5__5 ? Result<JoinGuildResult>.SuccessResult(new JoinGuildResult
					{
						Success = true,
						RequiresApproval = true,
						Message = "Join request sent! Waiting for guild leader approval."
					}) : Result<JoinGuildResult>.FailureResult("Failed to send join request"));
					goto end_IL_0007;
					IL_013a:
					_003C_003Es__4 = awaiter3.GetResult();
					_003Cguild_003E5__2 = _003C_003Es__4;
					_003C_003Es__4 = null;
					if (_003Cguild_003E5__2 == null)
					{
						result = Result<JoinGuildResult>.FailureResult("Guild not found");
					}
					else if (_003Cguild_003E5__2.MemberCount >= _003Cguild_003E5__2.MaxMembers)
					{
						result = Result<JoinGuildResult>.FailureResult("Guild is full");
					}
					else if (_003C_003E8__1.request.PlayerLevel < _003Cguild_003E5__2.MinLevelRequired)
					{
						result = Result<JoinGuildResult>.FailureResult($"You need to be at least level {_003Cguild_003E5__2.MinLevelRequired} to join this guild");
					}
					else
					{
						if (_003C_003E8__1.request.PlayerTrophies >= _003Cguild_003E5__2.MinTrophiesRequired)
						{
							if (_003Cguild_003E5__2.RequiresApproval)
							{
								awaiter2 = _003C_003E4__this._guildRepository.SendJoinRequestAsync(_003C_003E8__1.request.PlayerId, _003C_003E8__1.request.GuildId).GetAwaiter();
								if (!awaiter2.IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__2 = awaiter2;
									_003CExecuteAsync_003Ed__3 _003CExecuteAsync_003Ed__ = this;
									_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CExecuteAsync_003Ed__3>(ref awaiter2, ref _003CExecuteAsync_003Ed__);
									return;
								}
								goto IL_031f;
							}
							awaiter = _003C_003E4__this._guildRepository.JoinGuildAsync(_003C_003E8__1.request.PlayerId, _003C_003E8__1.request.PlayerName, _003C_003E8__1.request.GuildId, _003C_003E8__1.request.PlayerLevel).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__2 = awaiter;
								_003CExecuteAsync_003Ed__3 _003CExecuteAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CExecuteAsync_003Ed__3>(ref awaiter, ref _003CExecuteAsync_003Ed__);
								return;
							}
							break;
						}
						result = Result<JoinGuildResult>.FailureResult($"You need at least {_003Cguild_003E5__2.MinTrophiesRequired} trophies to join this guild");
					}
					goto end_IL_0007;
				}
				_003C_003Es__7 = awaiter.GetResult();
				_003Cjoined_003E5__3 = _003C_003Es__7;
				if (!_003Cjoined_003E5__3)
				{
					result = Result<JoinGuildResult>.FailureResult("Failed to join guild");
				}
				else
				{
					_003C_003E8__1.joinedAt = DateTimeOffset.UtcNow;
					_003C_003E4__this._playerStateService.ExecuteUpdate<bool>((Player _) => ValidationResult.Success(), delegate(Player p)
					{
						//IL_000f: Unknown result type (might be due to invalid IL or missing references)
						p.SetGuildInfo(_003C_003E8__1.request.GuildId, GuildRole.Member, _003C_003E8__1.joinedAt);
						return true;
					}, (Player p, bool _) => new PlayerBatchUpdate
					{
						PlayerId = p.PlayerID,
						GuildUpdates = new PlayerGuildUpdate
						{
							GuildId = _003C_003E8__1.request.GuildId,
							GuildRole = ((object)GuildRole.Member).ToString(),
							GuildJoinedAt = _003C_003E8__1.joinedAt,
							TargetPlayerId = p.PlayerID
						}
					});
					result = Result<JoinGuildResult>.SuccessResult(new JoinGuildResult
					{
						Success = true,
						RequiresApproval = false,
						Message = "Successfully joined " + _003Cguild_003E5__2.Name + "!"
					});
				}
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003Cguild_003E5__2 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003Cguild_003E5__2 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IGuildRepository _guildRepository;

	private readonly IPlayerStateService _playerStateService;

	public JoinGuildUseCase(IGuildRepository guildRepo, IPlayerStateService playerStateService)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		_guildRepository = guildRepo ?? throw new ArgumentNullException("guildRepo");
		_playerStateService = playerStateService ?? throw new ArgumentNullException("playerStateService");
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__3))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<JoinGuildResult>> ExecuteAsync(JoinGuildRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		JoinGuildRequest request2 = request;
		if (string.IsNullOrWhiteSpace(request2.PlayerId))
		{
			return Result<JoinGuildResult>.FailureResult("Player ID is required");
		}
		if (string.IsNullOrWhiteSpace(request2.PlayerName))
		{
			return Result<JoinGuildResult>.FailureResult("Player name is required");
		}
		if (string.IsNullOrWhiteSpace(request2.GuildId))
		{
			return Result<JoinGuildResult>.FailureResult("Guild ID is required");
		}
		Guild guild = await _guildRepository.GetByIdAsync(request2.GuildId);
		if (guild == null)
		{
			return Result<JoinGuildResult>.FailureResult("Guild not found");
		}
		if (guild.MemberCount >= guild.MaxMembers)
		{
			return Result<JoinGuildResult>.FailureResult("Guild is full");
		}
		if (request2.PlayerLevel < guild.MinLevelRequired)
		{
			return Result<JoinGuildResult>.FailureResult($"You need to be at least level {guild.MinLevelRequired} to join this guild");
		}
		if (request2.PlayerTrophies < guild.MinTrophiesRequired)
		{
			return Result<JoinGuildResult>.FailureResult($"You need at least {guild.MinTrophiesRequired} trophies to join this guild");
		}
		if (guild.RequiresApproval)
		{
			if (!(await _guildRepository.SendJoinRequestAsync(request2.PlayerId, request2.GuildId)))
			{
				return Result<JoinGuildResult>.FailureResult("Failed to send join request");
			}
			return Result<JoinGuildResult>.SuccessResult(new JoinGuildResult
			{
				Success = true,
				RequiresApproval = true,
				Message = "Join request sent! Waiting for guild leader approval."
			});
		}
		if (!(await _guildRepository.JoinGuildAsync(request2.PlayerId, request2.PlayerName, request2.GuildId, request2.PlayerLevel)))
		{
			return Result<JoinGuildResult>.FailureResult("Failed to join guild");
		}
		DateTimeOffset joinedAt = DateTimeOffset.UtcNow;
		_playerStateService.ExecuteUpdate<bool>((Player _) => ValidationResult.Success(), delegate(Player p)
		{
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			p.SetGuildInfo(request2.GuildId, GuildRole.Member, joinedAt);
			return true;
		}, (Player p, bool _) => new PlayerBatchUpdate
		{
			PlayerId = p.PlayerID,
			GuildUpdates = new PlayerGuildUpdate
			{
				GuildId = request2.GuildId,
				GuildRole = ((object)GuildRole.Member).ToString(),
				GuildJoinedAt = joinedAt,
				TargetPlayerId = p.PlayerID
			}
		});
		return Result<JoinGuildResult>.SuccessResult(new JoinGuildResult
		{
			Success = true,
			RequiresApproval = false,
			Message = "Successfully joined " + guild.Name + "!"
		});
	}
}
