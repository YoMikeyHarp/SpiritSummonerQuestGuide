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
using SpiritSummoner.Domain.Repositories;

namespace SpiritSummoner.Application.UseCases.Guilds;

public class RegisterAsWarMemberUseCase : IUseCase<RegisterAsWarMemberRequest, RegisterAsWarMemberResponse>
{
	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__4 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<RegisterAsWarMemberResponse>> _003C_003Et__builder;

		public RegisterAsWarMemberRequest request;

		public RegisterAsWarMemberUseCase _003C_003E4__this;

		private Player _003Cplayer_003E5__1;

		private Guild _003Cguild_003E5__2;

		private bool _003CisCurrentlyRegistered_003E5__3;

		private bool _003Csuccess_003E5__4;

		private bool _003CnowRegistered_003E5__5;

		private bool _003C_003Es__6;

		private List<string> _003CactiveSquad_003E5__7;

		private bool _003C_003Es__8;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private TaskAwaiter<Result<bool>> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0167: Unknown result type (might be due to invalid IL or missing references)
			//IL_016c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0174: Unknown result type (might be due to invalid IL or missing references)
			//IL_0275: Unknown result type (might be due to invalid IL or missing references)
			//IL_027a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0282: Unknown result type (might be due to invalid IL or missing references)
			//IL_0322: Unknown result type (might be due to invalid IL or missing references)
			//IL_0327: Unknown result type (might be due to invalid IL or missing references)
			//IL_032f: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_0302: Unknown result type (might be due to invalid IL or missing references)
			//IL_0304: Unknown result type (might be due to invalid IL or missing references)
			//IL_012d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0132: Unknown result type (might be due to invalid IL or missing references)
			//IL_0147: Unknown result type (might be due to invalid IL or missing references)
			//IL_0149: Unknown result type (might be due to invalid IL or missing references)
			//IL_023b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0240: Unknown result type (might be due to invalid IL or missing references)
			//IL_0255: Unknown result type (might be due to invalid IL or missing references)
			//IL_0257: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<RegisterAsWarMemberResponse> result;
			try
			{
				TaskAwaiter<bool> awaiter3;
				TaskAwaiter<bool> awaiter2;
				TaskAwaiter<Result<bool>> awaiter;
				switch (num)
				{
				default:
					_003Cplayer_003E5__1 = _003C_003E4__this._playerStateService.GetCurrentPlayer();
					if (_003Cplayer_003E5__1 == null)
					{
						result = Result<RegisterAsWarMemberResponse>.FailureResult("Player not found");
					}
					else
					{
						_003Cguild_003E5__2 = _003C_003E4__this._guildStateService.GetCurrentGuild();
						if (_003Cguild_003E5__2 == null)
						{
							result = Result<RegisterAsWarMemberResponse>.FailureResult("No active guild");
						}
						else if (!_003Cguild_003E5__2.IsInWarSeason)
						{
							result = Result<RegisterAsWarMemberResponse>.FailureResult("War registration opens after the bucket is set.");
						}
						else if (_003Cguild_003E5__2.HasActiveWarSeason)
						{
							result = Result<RegisterAsWarMemberResponse>.FailureResult("War has already started. Registration is closed.");
						}
						else
						{
							_003CisCurrentlyRegistered_003E5__3 = Enumerable.Contains<string>((global::System.Collections.Generic.IEnumerable<string>)_003Cguild_003E5__2.DefenderPlayerIds, _003Cplayer_003E5__1.PlayerID);
							if (_003CisCurrentlyRegistered_003E5__3)
							{
								awaiter3 = _003C_003E4__this._guildRepository.UnregisterAsDefenderAsync(request.GuildId, _003Cplayer_003E5__1.PlayerID).GetAwaiter();
								if (!awaiter3.IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter3;
									_003CExecuteAsync_003Ed__4 _003CExecuteAsync_003Ed__ = this;
									_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CExecuteAsync_003Ed__4>(ref awaiter3, ref _003CExecuteAsync_003Ed__);
									return;
								}
								goto IL_0183;
							}
							_003CactiveSquad_003E5__7 = Enumerable.ToList<string>(Enumerable.Where<string>((global::System.Collections.Generic.IEnumerable<string>)_003Cplayer_003E5__1.ActiveSquad, (Func<string, bool>)((string s) => !string.IsNullOrEmpty(s))));
							if (_003CactiveSquad_003E5__7.Count == 3)
							{
								awaiter2 = _003C_003E4__this._guildRepository.RegisterAsDefenderAsync(_003Cguild_003E5__2, _003Cplayer_003E5__1.PlayerID ?? "", _003CactiveSquad_003E5__7).GetAwaiter();
								if (!awaiter2.IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__1 = awaiter2;
									_003CExecuteAsync_003Ed__4 _003CExecuteAsync_003Ed__ = this;
									_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CExecuteAsync_003Ed__4>(ref awaiter2, ref _003CExecuteAsync_003Ed__);
									return;
								}
								goto IL_0291;
							}
							result = Result<RegisterAsWarMemberResponse>.FailureResult("You need exactly 3 spirits in your active squad to register as a defender.");
						}
					}
					goto end_IL_0007;
				case 0:
					awaiter3 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
					goto IL_0183;
				case 1:
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
					goto IL_0291;
				case 2:
					{
						awaiter = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<Result<bool>>);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_0291:
					_003C_003Es__8 = awaiter2.GetResult();
					_003Csuccess_003E5__4 = _003C_003Es__8;
					_003CnowRegistered_003E5__5 = true;
					_003CactiveSquad_003E5__7 = null;
					goto IL_02b9;
					IL_0183:
					_003C_003Es__6 = awaiter3.GetResult();
					_003Csuccess_003E5__4 = _003C_003Es__6;
					_003CnowRegistered_003E5__5 = false;
					goto IL_02b9;
					IL_02b9:
					if (_003Csuccess_003E5__4)
					{
						awaiter = _003C_003E4__this._guildStateService.RefreshGuildAsync().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__2 = awaiter;
							_003CExecuteAsync_003Ed__4 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Result<bool>>, _003CExecuteAsync_003Ed__4>(ref awaiter, ref _003CExecuteAsync_003Ed__);
							return;
						}
						break;
					}
					result = Result<RegisterAsWarMemberResponse>.FailureResult("Failed to update war registration.");
					goto end_IL_0007;
				}
				awaiter.GetResult();
				result = Result<RegisterAsWarMemberResponse>.SuccessResult(new RegisterAsWarMemberResponse(_003CnowRegistered_003E5__5));
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cplayer_003E5__1 = null;
				_003Cguild_003E5__2 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cplayer_003E5__1 = null;
			_003Cguild_003E5__2 = null;
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

	public RegisterAsWarMemberUseCase(IGuildStateService guildStateService, IPlayerStateService playerStateService, IGuildRepository guildRepository)
	{
		_guildStateService = guildStateService;
		_playerStateService = playerStateService;
		_guildRepository = guildRepository;
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__4))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<RegisterAsWarMemberResponse>> ExecuteAsync(RegisterAsWarMemberRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		Player player = _playerStateService.GetCurrentPlayer();
		if (player == null)
		{
			return Result<RegisterAsWarMemberResponse>.FailureResult("Player not found");
		}
		Guild guild = _guildStateService.GetCurrentGuild();
		if (guild == null)
		{
			return Result<RegisterAsWarMemberResponse>.FailureResult("No active guild");
		}
		if (!guild.IsInWarSeason)
		{
			return Result<RegisterAsWarMemberResponse>.FailureResult("War registration opens after the bucket is set.");
		}
		if (guild.HasActiveWarSeason)
		{
			return Result<RegisterAsWarMemberResponse>.FailureResult("War has already started. Registration is closed.");
		}
		bool success;
		bool nowRegistered;
		if (Enumerable.Contains<string>((global::System.Collections.Generic.IEnumerable<string>)guild.DefenderPlayerIds, player.PlayerID))
		{
			success = await _guildRepository.UnregisterAsDefenderAsync(request.GuildId, player.PlayerID);
			nowRegistered = false;
		}
		else
		{
			List<string> activeSquad = Enumerable.ToList<string>(Enumerable.Where<string>((global::System.Collections.Generic.IEnumerable<string>)player.ActiveSquad, (Func<string, bool>)((string s) => !string.IsNullOrEmpty(s))));
			if (activeSquad.Count != 3)
			{
				return Result<RegisterAsWarMemberResponse>.FailureResult("You need exactly 3 spirits in your active squad to register as a defender.");
			}
			success = await _guildRepository.RegisterAsDefenderAsync(guild, player.PlayerID ?? "", activeSquad);
			nowRegistered = true;
		}
		if (!success)
		{
			return Result<RegisterAsWarMemberResponse>.FailureResult("Failed to update war registration.");
		}
		await _guildStateService.RefreshGuildAsync();
		return Result<RegisterAsWarMemberResponse>.SuccessResult(new RegisterAsWarMemberResponse(nowRegistered));
	}
}
