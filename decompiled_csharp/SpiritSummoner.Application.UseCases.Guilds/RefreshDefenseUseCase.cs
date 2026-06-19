using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.BatchUpdates;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Guilds;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Repositories;
using SpiritSummoner.Infrastructure.Contracts;

namespace SpiritSummoner.Application.UseCases.Guilds;

public class RefreshDefenseUseCase : IUseCase<RefreshDefenseRequest, DefenseRefreshResponse>
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public DateTimeOffset now;

		internal bool _003CExecuteAsync_003Eb__1(Player player)
		{
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			player.SetEP(player.EP - 5);
			player.SetLastEpRegenTime(now);
			return true;
		}

		internal PlayerBatchUpdate _003CExecuteAsync_003Eb__2(Player player, bool _)
		{
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			return new PlayerBatchUpdate
			{
				PlayerId = player.PlayerID,
				NewEP = player.EP,
				LastEpRegenTime = now
			};
		}
	}

	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__5 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<DefenseRefreshResponse>> _003C_003Et__builder;

		public RefreshDefenseRequest request;

		public RefreshDefenseUseCase _003C_003E4__this;

		private _003C_003Ec__DisplayClass5_0 _003C_003E8__1;

		private Guild _003Cguild_003E5__2;

		private DateTimeOffset _003CnewExpiryTime_003E5__3;

		private Result<bool> _003CplayerResult_003E5__4;

		private bool _003Crefreshed_003E5__5;

		private bool _003C_003Es__6;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private TaskAwaiter<Result<bool>> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01da: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_0315: Unknown result type (might be due to invalid IL or missing references)
			//IL_0322: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_019b: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<DefenseRefreshResponse> result;
			try
			{
				TaskAwaiter<bool> awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
					goto IL_01f1;
				}
				TaskAwaiter<Result<bool>> awaiter2;
				if (num == 1)
				{
					awaiter2 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter<Result<bool>>);
					num = (_003C_003E1__state = -1);
					goto IL_02fe;
				}
				_003C_003E8__1 = new _003C_003Ec__DisplayClass5_0();
				_003Cguild_003E5__2 = _003C_003E4__this._guildStateService.GetMutableGuild();
				if (_003Cguild_003E5__2 == null)
				{
					result = Result<DefenseRefreshResponse>.FailureResult("No active guild");
				}
				else if (!_003Cguild_003E5__2.HasActiveWarSeason)
				{
					result = Result<DefenseRefreshResponse>.FailureResult("There is no active war to defend in.");
				}
				else if (!Enumerable.Contains<string>((global::System.Collections.Generic.IEnumerable<string>)_003Cguild_003E5__2.DefenderPlayerIds, request.PlayerId))
				{
					result = Result<DefenseRefreshResponse>.FailureResult("You are not registered as a defender for this war.");
				}
				else
				{
					_003C_003E8__1.now = _003C_003E4__this._serverTime.GetCurrentServerTime();
					_003CnewExpiryTime_003E5__3 = ((DateTimeOffset)(ref _003C_003E8__1.now)).AddHours(8.0);
					_003CplayerResult_003E5__4 = _003C_003E4__this._playerStateService.ExecuteUpdate<bool>((Player player) => (player.EP < 5) ? ValidationResult.Failure("You need 5 EP to refresh your defense.") : ValidationResult.Success(), delegate(Player player)
					{
						//IL_0012: Unknown result type (might be due to invalid IL or missing references)
						player.SetEP(player.EP - 5);
						player.SetLastEpRegenTime(_003C_003E8__1.now);
						return true;
					}, (Player player, bool _) => new PlayerBatchUpdate
					{
						PlayerId = player.PlayerID,
						NewEP = player.EP,
						LastEpRegenTime = _003C_003E8__1.now
					});
					if (_003CplayerResult_003E5__4.Success)
					{
						awaiter = _003C_003E4__this._guildRepository.RefreshDefenderAsync(request.GuildId, request.PlayerId).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CExecuteAsync_003Ed__5 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CExecuteAsync_003Ed__5>(ref awaiter, ref _003CExecuteAsync_003Ed__);
							return;
						}
						goto IL_01f1;
					}
					result = Result<DefenseRefreshResponse>.FailureResult(_003CplayerResult_003E5__4.ErrorMessage ?? "Failed to deduct EP");
				}
				goto end_IL_0007;
				IL_01f1:
				_003C_003Es__6 = awaiter.GetResult();
				_003Crefreshed_003E5__5 = _003C_003Es__6;
				if (_003Crefreshed_003E5__5)
				{
					awaiter2 = _003C_003E4__this._guildStateService.RefreshGuildAsync().GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter2;
						_003CExecuteAsync_003Ed__5 _003CExecuteAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Result<bool>>, _003CExecuteAsync_003Ed__5>(ref awaiter2, ref _003CExecuteAsync_003Ed__);
						return;
					}
					goto IL_02fe;
				}
				_003C_003E4__this._playerStateService.ExecuteUpdate<bool>((Player _) => ValidationResult.Success(), delegate(Player player)
				{
					player.SetEP(player.EP + 5);
					return true;
				}, (Player player, bool _) => new PlayerBatchUpdate
				{
					PlayerId = player.PlayerID,
					NewEP = player.EP
				});
				result = Result<DefenseRefreshResponse>.FailureResult("Failed to refresh defense");
				goto end_IL_0007;
				IL_02fe:
				awaiter2.GetResult();
				result = Result<DefenseRefreshResponse>.SuccessResult(new DefenseRefreshResponse
				{
					Success = true,
					NewExpiryTime = _003CnewExpiryTime_003E5__3,
					TimeRemaining = TimeSpan.FromHours(8)
				});
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003Cguild_003E5__2 = null;
				_003CplayerResult_003E5__4 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003Cguild_003E5__2 = null;
			_003CplayerResult_003E5__4 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IGuildStateService _guildStateService;

	private readonly IPlayerStateService _playerStateService;

	private readonly IGuildRepository _guildRepository;

	private readonly IServerTimeProvider _serverTime;

	public RefreshDefenseUseCase(IGuildStateService guildStateService, IPlayerStateService playerStateService, IGuildRepository guildRepository, IServerTimeProvider serverTime)
	{
		_guildStateService = guildStateService;
		_playerStateService = playerStateService;
		_guildRepository = guildRepository;
		_serverTime = serverTime;
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__5))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<DefenseRefreshResponse>> ExecuteAsync(RefreshDefenseRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		Guild guild = _guildStateService.GetMutableGuild();
		if (guild == null)
		{
			return Result<DefenseRefreshResponse>.FailureResult("No active guild");
		}
		if (!guild.HasActiveWarSeason)
		{
			return Result<DefenseRefreshResponse>.FailureResult("There is no active war to defend in.");
		}
		if (!Enumerable.Contains<string>((global::System.Collections.Generic.IEnumerable<string>)guild.DefenderPlayerIds, request.PlayerId))
		{
			return Result<DefenseRefreshResponse>.FailureResult("You are not registered as a defender for this war.");
		}
		DateTimeOffset now = _serverTime.GetCurrentServerTime();
		DateTimeOffset newExpiryTime = ((DateTimeOffset)(ref now)).AddHours(8.0);
		Result<bool> playerResult = _playerStateService.ExecuteUpdate<bool>((Player player) => (player.EP < 5) ? ValidationResult.Failure("You need 5 EP to refresh your defense.") : ValidationResult.Success(), delegate(Player player)
		{
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			player.SetEP(player.EP - 5);
			player.SetLastEpRegenTime(now);
			return true;
		}, (Player player, bool _) => new PlayerBatchUpdate
		{
			PlayerId = player.PlayerID,
			NewEP = player.EP,
			LastEpRegenTime = now
		});
		if (!playerResult.Success)
		{
			return Result<DefenseRefreshResponse>.FailureResult(playerResult.ErrorMessage ?? "Failed to deduct EP");
		}
		if (!(await _guildRepository.RefreshDefenderAsync(request.GuildId, request.PlayerId)))
		{
			_playerStateService.ExecuteUpdate<bool>((Player _) => ValidationResult.Success(), delegate(Player player)
			{
				player.SetEP(player.EP + 5);
				return true;
			}, (Player player, bool _) => new PlayerBatchUpdate
			{
				PlayerId = player.PlayerID,
				NewEP = player.EP
			});
			return Result<DefenseRefreshResponse>.FailureResult("Failed to refresh defense");
		}
		await _guildStateService.RefreshGuildAsync();
		return Result<DefenseRefreshResponse>.SuccessResult(new DefenseRefreshResponse
		{
			Success = true,
			NewExpiryTime = newExpiryTime,
			TimeRemaining = TimeSpan.FromHours(8)
		});
	}
}
