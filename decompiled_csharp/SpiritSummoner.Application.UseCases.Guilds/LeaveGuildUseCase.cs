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

public class LeaveGuildUseCase : IUseCase<LeaveGuildRequest, LeaveGuildResult>
{
	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__4 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<LeaveGuildResult>> _003C_003Et__builder;

		public LeaveGuildRequest request;

		public LeaveGuildUseCase _003C_003E4__this;

		private Guild _003Cguild_003E5__1;

		private GuildMember _003Cmember_003E5__2;

		private bool _003CdeleteGuild_003E5__3;

		private bool _003CdeleteSuccess_003E5__4;

		private GuildMember _003C_003Es__5;

		private bool _003C_003Es__6;

		private bool _003Csuccess_003E5__7;

		private bool _003C_003Es__8;

		private TaskAwaiter<GuildMember?> _003C_003Eu__1;

		private TaskAwaiter<bool> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0108: Unknown result type (might be due to invalid IL or missing references)
			//IL_010d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_021c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0221: Unknown result type (might be due to invalid IL or missing references)
			//IL_0229: Unknown result type (might be due to invalid IL or missing references)
			//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<LeaveGuildResult> result;
			try
			{
				TaskAwaiter<GuildMember> awaiter3;
				TaskAwaiter<bool> awaiter2;
				TaskAwaiter<bool> awaiter;
				switch (num)
				{
				default:
					if (string.IsNullOrWhiteSpace(request.PlayerId))
					{
						result = Result<LeaveGuildResult>.FailureResult("Player ID is required");
					}
					else if (string.IsNullOrWhiteSpace(request.GuildId))
					{
						result = Result<LeaveGuildResult>.FailureResult("Guild ID is required");
					}
					else
					{
						_003Cguild_003E5__1 = _003C_003E4__this._guildState.GetCurrentGuild();
						if (_003Cguild_003E5__1 != null)
						{
							awaiter3 = _003C_003E4__this._guildRepository.GetMemberAsync(request.GuildId, request.PlayerId).GetAwaiter();
							if (!awaiter3.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter3;
								_003CExecuteAsync_003Ed__4 _003CExecuteAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<GuildMember>, _003CExecuteAsync_003Ed__4>(ref awaiter3, ref _003CExecuteAsync_003Ed__);
								return;
							}
							goto IL_0124;
						}
						result = Result<LeaveGuildResult>.FailureResult("Guild not found");
					}
					goto end_IL_0007;
				case 0:
					awaiter3 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<GuildMember>);
					num = (_003C_003E1__state = -1);
					goto IL_0124;
				case 1:
					awaiter2 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
					goto IL_0238;
				case 2:
					{
						awaiter = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
						goto IL_02f9;
					}
					IL_0238:
					_003C_003Es__6 = awaiter2.GetResult();
					_003CdeleteSuccess_003E5__4 = _003C_003Es__6;
					if (_003CdeleteSuccess_003E5__4)
					{
						break;
					}
					result = Result<LeaveGuildResult>.FailureResult("Failed to deleted guild");
					goto end_IL_0007;
					IL_02f9:
					_003C_003Es__8 = awaiter.GetResult();
					_003Csuccess_003E5__7 = _003C_003Es__8;
					if (_003Csuccess_003E5__7 && _003CdeleteSuccess_003E5__4)
					{
						break;
					}
					result = Result<LeaveGuildResult>.FailureResult("Failed to leave guild");
					goto end_IL_0007;
					IL_01b0:
					_003CdeleteSuccess_003E5__4 = true;
					if (_003CdeleteGuild_003E5__3)
					{
						awaiter2 = _003C_003E4__this._guildRepository.DeleteAsync(_003Cguild_003E5__1.ID).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter2;
							_003CExecuteAsync_003Ed__4 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CExecuteAsync_003Ed__4>(ref awaiter2, ref _003CExecuteAsync_003Ed__);
							return;
						}
						goto IL_0238;
					}
					awaiter = _003C_003E4__this._guildRepository.LeaveGuildAsync(request.PlayerId, request.GuildId, _003Cguild_003E5__1).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__2 = awaiter;
						_003CExecuteAsync_003Ed__4 _003CExecuteAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CExecuteAsync_003Ed__4>(ref awaiter, ref _003CExecuteAsync_003Ed__);
						return;
					}
					goto IL_02f9;
					IL_0124:
					_003C_003Es__5 = awaiter3.GetResult();
					_003Cmember_003E5__2 = _003C_003Es__5;
					_003C_003Es__5 = null;
					if (_003Cmember_003E5__2 == null)
					{
						result = Result<LeaveGuildResult>.FailureResult("You are not a member of this guild");
					}
					else
					{
						_003CdeleteGuild_003E5__3 = false;
						if (_003Cmember_003E5__2.Role != GuildRole.Guildmaster)
						{
							goto IL_01b0;
						}
						if (_003Cguild_003E5__1.MemberCount == 1)
						{
							_003CdeleteGuild_003E5__3 = true;
							goto IL_01b0;
						}
						result = Result<LeaveGuildResult>.FailureResult("As guild leader, you must transfer leadership to another member before leaving");
					}
					goto end_IL_0007;
				}
				_003C_003E4__this._playerStateService.ExecuteUpdate<bool>((Player _) => ValidationResult.Success(), delegate(Player p)
				{
					p.SetGuildInfo(null, GuildRole.Member, null);
					return true;
				}, (Player p, bool _) => new PlayerBatchUpdate
				{
					PlayerId = p.PlayerID,
					GuildUpdates = new PlayerGuildUpdate
					{
						GuildId = string.Empty,
						GuildRole = string.Empty,
						GuildJoinedAt = null,
						TargetPlayerId = p.PlayerID
					}
				});
				result = Result<LeaveGuildResult>.SuccessResult(new LeaveGuildResult
				{
					Success = true,
					GuildDeleted = (_003Cmember_003E5__2.Role == GuildRole.Guildmaster && _003Cguild_003E5__1.MemberCount == 1),
					Message = ((_003Cmember_003E5__2.Role == GuildRole.Guildmaster && _003Cguild_003E5__1.MemberCount == 1) ? "You left the guild. The guild has been deleted." : "You have successfully left the guild.")
				});
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cguild_003E5__1 = null;
				_003Cmember_003E5__2 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cguild_003E5__1 = null;
			_003Cmember_003E5__2 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IGuildRepository _guildRepository;

	private readonly IPlayerStateService _playerStateService;

	private readonly IGuildStateService _guildState;

	public LeaveGuildUseCase(IGuildRepository guildRepo, IPlayerStateService playerStateService, IGuildStateService guildStateService)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		_guildRepository = guildRepo ?? throw new ArgumentNullException("guildRepo");
		_playerStateService = playerStateService ?? throw new ArgumentNullException("playerStateService");
		_guildState = guildStateService ?? throw new ArgumentNullException("guildStateService");
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__4))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<LeaveGuildResult>> ExecuteAsync(LeaveGuildRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrWhiteSpace(request.PlayerId))
		{
			return Result<LeaveGuildResult>.FailureResult("Player ID is required");
		}
		if (string.IsNullOrWhiteSpace(request.GuildId))
		{
			return Result<LeaveGuildResult>.FailureResult("Guild ID is required");
		}
		Guild guild = _guildState.GetCurrentGuild();
		if (guild == null)
		{
			return Result<LeaveGuildResult>.FailureResult("Guild not found");
		}
		GuildMember member = await _guildRepository.GetMemberAsync(request.GuildId, request.PlayerId);
		if (member == null)
		{
			return Result<LeaveGuildResult>.FailureResult("You are not a member of this guild");
		}
		bool deleteGuild = false;
		if (member.Role == GuildRole.Guildmaster)
		{
			if (guild.MemberCount != 1)
			{
				return Result<LeaveGuildResult>.FailureResult("As guild leader, you must transfer leadership to another member before leaving");
			}
			deleteGuild = true;
		}
		bool deleteSuccess = true;
		if (deleteGuild)
		{
			if (!(await _guildRepository.DeleteAsync(guild.ID)))
			{
				return Result<LeaveGuildResult>.FailureResult("Failed to deleted guild");
			}
		}
		else if (!(await _guildRepository.LeaveGuildAsync(request.PlayerId, request.GuildId, guild)) || !deleteSuccess)
		{
			return Result<LeaveGuildResult>.FailureResult("Failed to leave guild");
		}
		_playerStateService.ExecuteUpdate<bool>((Player _) => ValidationResult.Success(), delegate(Player p)
		{
			p.SetGuildInfo(null, GuildRole.Member, null);
			return true;
		}, (Player p, bool _) => new PlayerBatchUpdate
		{
			PlayerId = p.PlayerID,
			GuildUpdates = new PlayerGuildUpdate
			{
				GuildId = string.Empty,
				GuildRole = string.Empty,
				GuildJoinedAt = null,
				TargetPlayerId = p.PlayerID
			}
		});
		return Result<LeaveGuildResult>.SuccessResult(new LeaveGuildResult
		{
			Success = true,
			GuildDeleted = (member.Role == GuildRole.Guildmaster && guild.MemberCount == 1),
			Message = ((member.Role == GuildRole.Guildmaster && guild.MemberCount == 1) ? "You left the guild. The guild has been deleted." : "You have successfully left the guild.")
		});
	}
}
