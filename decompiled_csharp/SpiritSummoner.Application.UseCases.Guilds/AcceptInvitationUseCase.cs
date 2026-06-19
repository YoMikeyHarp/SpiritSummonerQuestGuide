using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.BatchUpdates;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Enums.Guilds;
using SpiritSummoner.Domain.Repositories;

namespace SpiritSummoner.Application.UseCases.Guilds;

public class AcceptInvitationUseCase : IUseCase<AcceptInvitationRequest, bool>
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public AcceptInvitationRequest request;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_1
	{
		public DateTimeOffset joinedAt;

		public _003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals1;

		internal bool _003CExecuteAsync_003Eb__1(Player p)
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			p.SetGuildInfo(CS_0024_003C_003E8__locals1.request.GuildId, GuildRole.Member, joinedAt);
			return true;
		}

		internal PlayerBatchUpdate _003CExecuteAsync_003Eb__2(Player p, bool _)
		{
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			return new PlayerBatchUpdate
			{
				PlayerId = p.PlayerID,
				GuildUpdates = new PlayerGuildUpdate
				{
					GuildId = CS_0024_003C_003E8__locals1.request.GuildId,
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

		public AsyncTaskMethodBuilder<Result<bool>> _003C_003Et__builder;

		public AcceptInvitationRequest request;

		public AcceptInvitationUseCase _003C_003E4__this;

		private _003C_003Ec__DisplayClass3_0 _003C_003E8__1;

		private Player _003Cplayer_003E5__2;

		private _003C_003Ec__DisplayClass3_1 _003C_003E8__3;

		private bool _003Csuccess_003E5__4;

		private bool _003C_003Es__5;

		private global::System.Exception _003Cex_003E5__6;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0182: Unknown result type (might be due to invalid IL or missing references)
			//IL_0187: Unknown result type (might be due to invalid IL or missing references)
			//IL_018f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0148: Unknown result type (might be due to invalid IL or missing references)
			//IL_014d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0162: Unknown result type (might be due to invalid IL or missing references)
			//IL_0164: Unknown result type (might be due to invalid IL or missing references)
			//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<bool> result;
			try
			{
				if (num == 0)
				{
					goto IL_00e1;
				}
				_003C_003E8__1 = new _003C_003Ec__DisplayClass3_0();
				_003C_003E8__1.request = request;
				if (string.IsNullOrWhiteSpace(_003C_003E8__1.request.InvitationId))
				{
					result = Result<bool>.FailureResult("Invitation ID is required");
				}
				else if (string.IsNullOrWhiteSpace(_003C_003E8__1.request.PlayerId))
				{
					result = Result<bool>.FailureResult("Player ID is required");
				}
				else if (string.IsNullOrWhiteSpace(_003C_003E8__1.request.GuildId))
				{
					result = Result<bool>.FailureResult("Guild ID is required");
				}
				else
				{
					_003Cplayer_003E5__2 = _003C_003E4__this._playerStateService.GetCurrentPlayer();
					if (_003Cplayer_003E5__2 != null)
					{
						goto IL_00e1;
					}
					result = Result<bool>.FailureResult("Player not found");
				}
				goto end_IL_0007;
				IL_00e1:
				try
				{
					TaskAwaiter<bool> awaiter;
					if (num != 0)
					{
						_003C_003E8__3 = new _003C_003Ec__DisplayClass3_1();
						_003C_003E8__3.CS_0024_003C_003E8__locals1 = _003C_003E8__1;
						awaiter = _003C_003E4__this._guildRepository.AcceptInvitationAsync(_003C_003E8__3.CS_0024_003C_003E8__locals1.request.InvitationId, _003C_003E8__3.CS_0024_003C_003E8__locals1.request.PlayerId, _003Cplayer_003E5__2).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CExecuteAsync_003Ed__3 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CExecuteAsync_003Ed__3>(ref awaiter, ref _003CExecuteAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__5 = awaiter.GetResult();
					_003Csuccess_003E5__4 = _003C_003Es__5;
					if (!_003Csuccess_003E5__4)
					{
						result = Result<bool>.FailureResult("Failed to accept invitation. It may have expired.");
					}
					else
					{
						_003C_003E8__3.joinedAt = DateTimeOffset.UtcNow;
						_003C_003E4__this._playerStateService.ExecuteUpdate<bool>((Player _) => ValidationResult.Success(), delegate(Player p)
						{
							//IL_0014: Unknown result type (might be due to invalid IL or missing references)
							p.SetGuildInfo(_003C_003E8__3.CS_0024_003C_003E8__locals1.request.GuildId, GuildRole.Member, _003C_003E8__3.joinedAt);
							return true;
						}, (Player p, bool _) => new PlayerBatchUpdate
						{
							PlayerId = p.PlayerID,
							GuildUpdates = new PlayerGuildUpdate
							{
								GuildId = _003C_003E8__3.CS_0024_003C_003E8__locals1.request.GuildId,
								GuildRole = ((object)GuildRole.Member).ToString(),
								GuildJoinedAt = _003C_003E8__3.joinedAt,
								TargetPlayerId = p.PlayerID
							}
						});
						result = Result<bool>.SuccessResult(data: true);
					}
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__6 = ex;
					result = Result<bool>.FailureResult("An error occurred while accepting the invitation: " + _003Cex_003E5__6.Message);
				}
				end_IL_0007:;
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003Cplayer_003E5__2 = null;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003Cplayer_003E5__2 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IGuildRepository _guildRepository;

	private readonly IPlayerStateService _playerStateService;

	public AcceptInvitationUseCase(IGuildRepository guildRepository, IPlayerStateService playerStateService)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		_guildRepository = guildRepository ?? throw new ArgumentNullException("guildRepository");
		_playerStateService = playerStateService ?? throw new ArgumentNullException("playerStateService");
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__3))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<bool>> ExecuteAsync(AcceptInvitationRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		AcceptInvitationRequest request2 = request;
		if (string.IsNullOrWhiteSpace(request2.InvitationId))
		{
			return Result<bool>.FailureResult("Invitation ID is required");
		}
		if (string.IsNullOrWhiteSpace(request2.PlayerId))
		{
			return Result<bool>.FailureResult("Player ID is required");
		}
		if (string.IsNullOrWhiteSpace(request2.GuildId))
		{
			return Result<bool>.FailureResult("Guild ID is required");
		}
		Player player = _playerStateService.GetCurrentPlayer();
		if (player == null)
		{
			return Result<bool>.FailureResult("Player not found");
		}
		try
		{
			if (!(await _guildRepository.AcceptInvitationAsync(request2.InvitationId, request2.PlayerId, player)))
			{
				return Result<bool>.FailureResult("Failed to accept invitation. It may have expired.");
			}
			DateTimeOffset joinedAt = DateTimeOffset.UtcNow;
			_playerStateService.ExecuteUpdate<bool>((Player _) => ValidationResult.Success(), delegate(Player p)
			{
				//IL_0014: Unknown result type (might be due to invalid IL or missing references)
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
			return Result<bool>.SuccessResult(data: true);
		}
		catch (global::System.Exception ex)
		{
			return Result<bool>.FailureResult("An error occurred while accepting the invitation: " + ex.Message);
		}
	}
}
