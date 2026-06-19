using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Guilds;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Enums.Guilds;
using SpiritSummoner.Domain.Repositories;

namespace SpiritSummoner.Application.UseCases.Guilds;

public class ManageDefendersUseCase : IUseCase<ManageDefendersRequest, bool>
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public ManageDefendersRequest request;

		internal bool _003CExecuteAsync_003Eb__0(string id)
		{
			return id != request.TargetPlayerId;
		}
	}

	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__4 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<bool>> _003C_003Et__builder;

		public ManageDefendersRequest request;

		public ManageDefendersUseCase _003C_003E4__this;

		private _003C_003Ec__DisplayClass4_0 _003C_003E8__1;

		private Player _003CcurrentPlayer_003E5__2;

		private Guild _003Cguild_003E5__3;

		private bool _003Csuccess_003E5__4;

		private Guild _003C_003Es__5;

		private List<string> _003CnewMainDefenders_003E5__6;

		private List<string> _003CupdatedMainDefenders_003E5__7;

		private DefenderAction _003C_003Es__8;

		private bool _003C_003Es__9;

		private bool _003C_003Es__10;

		private bool _003C_003Es__11;

		private TaskAwaiter<Guild?> _003C_003Eu__1;

		private TaskAwaiter<bool> _003C_003Eu__2;

		private TaskAwaiter<Result<bool>> _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_0173: Unknown result type (might be due to invalid IL or missing references)
			//IL_0178: Unknown result type (might be due to invalid IL or missing references)
			//IL_0180: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_03bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_04e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_04e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_05a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_05aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_05b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0691: Unknown result type (might be due to invalid IL or missing references)
			//IL_0696: Unknown result type (might be due to invalid IL or missing references)
			//IL_069e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0657: Unknown result type (might be due to invalid IL or missing references)
			//IL_065c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0671: Unknown result type (might be due to invalid IL or missing references)
			//IL_0673: Unknown result type (might be due to invalid IL or missing references)
			//IL_056b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0570: Unknown result type (might be due to invalid IL or missing references)
			//IL_0585: Unknown result type (might be due to invalid IL or missing references)
			//IL_0587: Unknown result type (might be due to invalid IL or missing references)
			//IL_0139: Unknown result type (might be due to invalid IL or missing references)
			//IL_013e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0153: Unknown result type (might be due to invalid IL or missing references)
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_04a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_0376: Unknown result type (might be due to invalid IL or missing references)
			//IL_037b: Unknown result type (might be due to invalid IL or missing references)
			//IL_04c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_04c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0390: Unknown result type (might be due to invalid IL or missing references)
			//IL_0392: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<bool> result;
			try
			{
				TaskAwaiter<Guild> awaiter5;
				TaskAwaiter<bool> awaiter4;
				TaskAwaiter<bool> awaiter3;
				TaskAwaiter<bool> awaiter2;
				TaskAwaiter<Result<bool>> awaiter;
				switch (num)
				{
				default:
					_003C_003E8__1 = new _003C_003Ec__DisplayClass4_0();
					_003C_003E8__1.request = request;
					if (string.IsNullOrEmpty(_003C_003E8__1.request.GuildId))
					{
						result = Result<bool>.FailureResult("Guild ID is required");
					}
					else if (string.IsNullOrEmpty(_003C_003E8__1.request.TargetPlayerId))
					{
						result = Result<bool>.FailureResult("Target player ID is required");
					}
					else
					{
						_003CcurrentPlayer_003E5__2 = _003C_003E4__this._playerStateService.GetCurrentPlayer();
						if (_003CcurrentPlayer_003E5__2 == null)
						{
							result = Result<bool>.FailureResult("Player not found");
						}
						else
						{
							if (_003CcurrentPlayer_003E5__2.GuildRole == GuildRole.Guildmaster || _003CcurrentPlayer_003E5__2.GuildRole == GuildRole.Vice_Guildmaster)
							{
								awaiter5 = _003C_003E4__this._guildRepo.GetByIdAsync(_003C_003E8__1.request.GuildId).GetAwaiter();
								if (!awaiter5.IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter5;
									_003CExecuteAsync_003Ed__4 _003CExecuteAsync_003Ed__ = this;
									_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Guild>, _003CExecuteAsync_003Ed__4>(ref awaiter5, ref _003CExecuteAsync_003Ed__);
									return;
								}
								goto IL_018f;
							}
							result = Result<bool>.FailureResult("Only Guildmaster or Vice-Guildmaster can manage defenders.");
						}
					}
					goto end_IL_0007;
				case 0:
					awaiter5 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Guild>);
					num = (_003C_003E1__state = -1);
					goto IL_018f;
				case 1:
					awaiter4 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
					goto IL_03cc;
				case 2:
					awaiter3 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
					goto IL_04fc;
				case 3:
					awaiter2 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
					goto IL_05c1;
				case 4:
					{
						awaiter = _003C_003Eu__3;
						_003C_003Eu__3 = default(TaskAwaiter<Result<bool>>);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_051a:
					if (!_003Cguild_003E5__3.HasActiveWarSeason)
					{
						awaiter2 = _003C_003E4__this._guildRepo.RemoveDefenderAsync(_003C_003E8__1.request.GuildId, _003C_003E8__1.request.TargetPlayerId).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 3);
							_003C_003Eu__2 = awaiter2;
							_003CExecuteAsync_003Ed__4 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CExecuteAsync_003Ed__4>(ref awaiter2, ref _003CExecuteAsync_003Ed__);
							return;
						}
						goto IL_05c1;
					}
					result = Result<bool>.FailureResult("You cannot withdraw from defense during an active war.");
					goto end_IL_0007;
					IL_05c1:
					_003C_003Es__11 = awaiter2.GetResult();
					_003Csuccess_003E5__4 = _003C_003Es__11;
					goto IL_05ec;
					IL_05ec:
					_003CnewMainDefenders_003E5__6 = null;
					_003CupdatedMainDefenders_003E5__7 = null;
					if (_003Csuccess_003E5__4)
					{
						awaiter = _003C_003E4__this._guildStateService.RefreshGuildAsync().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 4);
							_003C_003Eu__3 = awaiter;
							_003CExecuteAsync_003Ed__4 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Result<bool>>, _003CExecuteAsync_003Ed__4>(ref awaiter, ref _003CExecuteAsync_003Ed__);
							return;
						}
						break;
					}
					result = Result<bool>.FailureResult("Failed to " + ((object)_003C_003E8__1.request.Action).ToString().ToLower() + " defender");
					goto end_IL_0007;
					IL_018f:
					_003C_003Es__5 = awaiter5.GetResult();
					_003Cguild_003E5__3 = _003C_003Es__5;
					_003C_003Es__5 = null;
					if (_003Cguild_003E5__3 == null)
					{
						result = Result<bool>.FailureResult("Guild not found");
					}
					else if (!Enumerable.Contains<string>((global::System.Collections.Generic.IEnumerable<string>)_003Cguild_003E5__3.DefenderPlayerIds, _003C_003E8__1.request.TargetPlayerId))
					{
						result = Result<bool>.FailureResult("Target player is not a defender");
					}
					else
					{
						_003Csuccess_003E5__4 = false;
						DefenderAction action = _003C_003E8__1.request.Action;
						_003C_003Es__8 = action;
						switch (_003C_003Es__8)
						{
						case DefenderAction.SetAsMain:
							break;
						case DefenderAction.RemoveFromMain:
							goto IL_03ea;
						case DefenderAction.Remove:
							goto IL_051a;
						default:
							result = Result<bool>.FailureResult("Invalid action");
							goto end_IL_0007;
						}
						if (!_003Cguild_003E5__3.IsInWarSeason || _003Cguild_003E5__3.HasActiveWarSeason)
						{
							result = Result<bool>.FailureResult("Main defenders can only be set after matchmaking and before the war starts.");
						}
						else if (((global::System.Collections.Generic.IReadOnlyCollection<string>)_003Cguild_003E5__3.MainDefenderPlayerIds).Count >= _003Cguild_003E5__3.MaxMainDefenders)
						{
							result = Result<bool>.FailureResult($"Maximum {_003Cguild_003E5__3.MaxMainDefenders} main defenders allowed.");
						}
						else
						{
							if (!Enumerable.Contains<string>((global::System.Collections.Generic.IEnumerable<string>)_003Cguild_003E5__3.MainDefenderPlayerIds, _003C_003E8__1.request.TargetPlayerId))
							{
								_003CnewMainDefenders_003E5__6 = Enumerable.ToList<string>((global::System.Collections.Generic.IEnumerable<string>)_003Cguild_003E5__3.MainDefenderPlayerIds);
								_003CnewMainDefenders_003E5__6.Add(_003C_003E8__1.request.TargetPlayerId);
								awaiter4 = _003C_003E4__this._guildRepo.SetMainDefendersAsync(_003C_003E8__1.request.GuildId, _003CnewMainDefenders_003E5__6).GetAwaiter();
								if (!awaiter4.IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__2 = awaiter4;
									_003CExecuteAsync_003Ed__4 _003CExecuteAsync_003Ed__ = this;
									_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CExecuteAsync_003Ed__4>(ref awaiter4, ref _003CExecuteAsync_003Ed__);
									return;
								}
								goto IL_03cc;
							}
							result = Result<bool>.FailureResult("Player is already a main defender.");
						}
					}
					goto end_IL_0007;
					IL_03cc:
					_003C_003Es__9 = awaiter4.GetResult();
					_003Csuccess_003E5__4 = _003C_003Es__9;
					goto IL_05ec;
					IL_04fc:
					_003C_003Es__10 = awaiter3.GetResult();
					_003Csuccess_003E5__4 = _003C_003Es__10;
					goto IL_05ec;
					IL_03ea:
					if (!_003Cguild_003E5__3.IsInWarSeason || _003Cguild_003E5__3.HasActiveWarSeason)
					{
						result = Result<bool>.FailureResult("Main defenders can only be changed after matchmaking and before the war starts.");
					}
					else
					{
						if (Enumerable.Contains<string>((global::System.Collections.Generic.IEnumerable<string>)_003Cguild_003E5__3.MainDefenderPlayerIds, _003C_003E8__1.request.TargetPlayerId))
						{
							_003CupdatedMainDefenders_003E5__7 = Enumerable.ToList<string>(Enumerable.Where<string>((global::System.Collections.Generic.IEnumerable<string>)_003Cguild_003E5__3.MainDefenderPlayerIds, (Func<string, bool>)((string id) => id != _003C_003E8__1.request.TargetPlayerId)));
							awaiter3 = _003C_003E4__this._guildRepo.SetMainDefendersAsync(_003C_003E8__1.request.GuildId, _003CupdatedMainDefenders_003E5__7).GetAwaiter();
							if (!awaiter3.IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__2 = awaiter3;
								_003CExecuteAsync_003Ed__4 _003CExecuteAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CExecuteAsync_003Ed__4>(ref awaiter3, ref _003CExecuteAsync_003Ed__);
								return;
							}
							goto IL_04fc;
						}
						result = Result<bool>.FailureResult("Player is not a main defender.");
					}
					goto end_IL_0007;
				}
				awaiter.GetResult();
				result = Result<bool>.SuccessResult(data: true);
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003CcurrentPlayer_003E5__2 = null;
				_003Cguild_003E5__3 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003CcurrentPlayer_003E5__2 = null;
			_003Cguild_003E5__3 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IGuildRepository _guildRepo;

	private readonly IPlayerStateService _playerStateService;

	private readonly IGuildStateService _guildStateService;

	public ManageDefendersUseCase(IGuildRepository guildRepo, IPlayerStateService playerStateService, IGuildStateService guildStateService)
	{
		_guildRepo = guildRepo;
		_playerStateService = playerStateService;
		_guildStateService = guildStateService;
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__4))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<bool>> ExecuteAsync(ManageDefendersRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		ManageDefendersRequest request2 = request;
		if (string.IsNullOrEmpty(request2.GuildId))
		{
			return Result<bool>.FailureResult("Guild ID is required");
		}
		if (string.IsNullOrEmpty(request2.TargetPlayerId))
		{
			return Result<bool>.FailureResult("Target player ID is required");
		}
		Player currentPlayer = _playerStateService.GetCurrentPlayer();
		if (currentPlayer == null)
		{
			return Result<bool>.FailureResult("Player not found");
		}
		if (currentPlayer.GuildRole != GuildRole.Guildmaster && currentPlayer.GuildRole != GuildRole.Vice_Guildmaster)
		{
			return Result<bool>.FailureResult("Only Guildmaster or Vice-Guildmaster can manage defenders.");
		}
		Guild guild = await _guildRepo.GetByIdAsync(request2.GuildId);
		if (guild == null)
		{
			return Result<bool>.FailureResult("Guild not found");
		}
		if (!Enumerable.Contains<string>((global::System.Collections.Generic.IEnumerable<string>)guild.DefenderPlayerIds, request2.TargetPlayerId))
		{
			return Result<bool>.FailureResult("Target player is not a defender");
		}
		bool success;
		switch (request2.Action)
		{
		case DefenderAction.SetAsMain:
		{
			if (!guild.IsInWarSeason || guild.HasActiveWarSeason)
			{
				return Result<bool>.FailureResult("Main defenders can only be set after matchmaking and before the war starts.");
			}
			if (((global::System.Collections.Generic.IReadOnlyCollection<string>)guild.MainDefenderPlayerIds).Count >= guild.MaxMainDefenders)
			{
				return Result<bool>.FailureResult($"Maximum {guild.MaxMainDefenders} main defenders allowed.");
			}
			if (Enumerable.Contains<string>((global::System.Collections.Generic.IEnumerable<string>)guild.MainDefenderPlayerIds, request2.TargetPlayerId))
			{
				return Result<bool>.FailureResult("Player is already a main defender.");
			}
			List<string> newMainDefenders = Enumerable.ToList<string>((global::System.Collections.Generic.IEnumerable<string>)guild.MainDefenderPlayerIds);
			newMainDefenders.Add(request2.TargetPlayerId);
			success = await _guildRepo.SetMainDefendersAsync(request2.GuildId, newMainDefenders);
			break;
		}
		case DefenderAction.RemoveFromMain:
		{
			if (!guild.IsInWarSeason || guild.HasActiveWarSeason)
			{
				return Result<bool>.FailureResult("Main defenders can only be changed after matchmaking and before the war starts.");
			}
			if (!Enumerable.Contains<string>((global::System.Collections.Generic.IEnumerable<string>)guild.MainDefenderPlayerIds, request2.TargetPlayerId))
			{
				return Result<bool>.FailureResult("Player is not a main defender.");
			}
			List<string> updatedMainDefenders = Enumerable.ToList<string>(Enumerable.Where<string>((global::System.Collections.Generic.IEnumerable<string>)guild.MainDefenderPlayerIds, (Func<string, bool>)((string id) => id != request2.TargetPlayerId)));
			success = await _guildRepo.SetMainDefendersAsync(request2.GuildId, updatedMainDefenders);
			break;
		}
		case DefenderAction.Remove:
			if (guild.HasActiveWarSeason)
			{
				return Result<bool>.FailureResult("You cannot withdraw from defense during an active war.");
			}
			success = await _guildRepo.RemoveDefenderAsync(request2.GuildId, request2.TargetPlayerId);
			break;
		default:
			return Result<bool>.FailureResult("Invalid action");
		}
		if (!success)
		{
			return Result<bool>.FailureResult("Failed to " + ((object)request2.Action).ToString().ToLower() + " defender");
		}
		await _guildStateService.RefreshGuildAsync();
		return Result<bool>.SuccessResult(data: true);
	}
}
