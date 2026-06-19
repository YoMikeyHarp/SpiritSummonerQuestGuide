using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.BatchUpdates;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Players;

namespace SpiritSummoner.Application.UseCases.Players;

public class RegeneratePlayerEnergyUseCase
{
	[CompilerGenerated]
	private sealed class _003CRegenerateEPAsync_003Ed__7 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<RegenerateEnergyResponse>> _003C_003Et__builder;

		public DateTimeOffset now;

		public RegeneratePlayerEnergyUseCase _003C_003E4__this;

		private Result<RegenerateEnergyResponse> _003C_003Es__1;

		private TaskAwaiter<Result<RegenerateEnergyResponse>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<RegenerateEnergyResponse> result;
			try
			{
				TaskAwaiter<Result<RegenerateEnergyResponse>> awaiter;
				if (num != 0)
				{
					awaiter = global::System.Threading.Tasks.Task.FromResult<Result<RegenerateEnergyResponse>>(_003C_003E4__this.RegenerateEP(now)).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CRegenerateEPAsync_003Ed__7 _003CRegenerateEPAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Result<RegenerateEnergyResponse>>, _003CRegenerateEPAsync_003Ed__7>(ref awaiter, ref _003CRegenerateEPAsync_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Result<RegenerateEnergyResponse>>);
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
	private sealed class _003CRegenerateSPAsync_003Ed__9 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<RegenerateEnergyResponse>> _003C_003Et__builder;

		public DateTimeOffset now;

		public RegeneratePlayerEnergyUseCase _003C_003E4__this;

		private Result<RegenerateEnergyResponse> _003C_003Es__1;

		private TaskAwaiter<Result<RegenerateEnergyResponse>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<RegenerateEnergyResponse> result;
			try
			{
				TaskAwaiter<Result<RegenerateEnergyResponse>> awaiter;
				if (num != 0)
				{
					awaiter = global::System.Threading.Tasks.Task.FromResult<Result<RegenerateEnergyResponse>>(_003C_003E4__this.RegenerateSP(now)).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CRegenerateSPAsync_003Ed__9 _003CRegenerateSPAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Result<RegenerateEnergyResponse>>, _003CRegenerateSPAsync_003Ed__9>(ref awaiter, ref _003CRegenerateSPAsync_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Result<RegenerateEnergyResponse>>);
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

	private readonly IPlayerStateService _stateService;

	public const int EP_REGEN_AMOUNT = 1;

	public const int SP_REGEN_AMOUNT = 1;

	public const int EP_REGEN_MINUTES = 1;

	public const int SP_REGEN_MINUTES = 2;

	public RegeneratePlayerEnergyUseCase(IPlayerStateService stateService)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		_stateService = stateService ?? throw new ArgumentNullException("stateService");
	}

	public Result<RegenerateEnergyResponse> RegenerateEP(DateTimeOffset now)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		int oldEP = 0;
		return _stateService.ExecuteUpdate<RegenerateEnergyResponse>(delegate(Player player)
		{
			if (player.EP >= player.MaxEP)
			{
				return ValidationResult.Failure("EP already at maximum");
			}
			oldEP = player.EP;
			return ValidationResult.Success();
		}, delegate(Player player)
		{
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			int num = Math.Min(player.EP + 1, player.MaxEP);
			player.SetEP(num);
			player.SetLastEpRegenTime(now);
			return new RegenerateEnergyResponse("EP", num, player.MaxEP, num >= player.MaxEP);
		}, (Player player, RegenerateEnergyResponse response) => new PlayerBatchUpdate
		{
			PlayerId = (player.PlayerID ?? string.Empty),
			NewEP = player.EP,
			LastEpRegenTime = player.LastEpRegenTime
		});
	}

	[AsyncStateMachine(typeof(_003CRegenerateEPAsync_003Ed__7))]
	[DebuggerStepThrough]
	[Obsolete("Use RegenerateEP(DateTimeOffset) instead. This async version will be removed in a future version.")]
	public async global::System.Threading.Tasks.Task<Result<RegenerateEnergyResponse>> RegenerateEPAsync(DateTimeOffset now)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		return await global::System.Threading.Tasks.Task.FromResult<Result<RegenerateEnergyResponse>>(RegenerateEP(now));
	}

	public Result<RegenerateEnergyResponse> RegenerateSP(DateTimeOffset now)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		int oldSP = 0;
		return _stateService.ExecuteUpdate<RegenerateEnergyResponse>(delegate(Player player)
		{
			if (player.SP >= player.MaxSP)
			{
				return ValidationResult.Failure("SP already at maximum");
			}
			oldSP = player.SP;
			return ValidationResult.Success();
		}, delegate(Player player)
		{
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			int num = Math.Min(player.SP + 1, player.MaxSP);
			player.SetSP(num);
			player.SetLastSpRegenTime(now);
			return new RegenerateEnergyResponse("SP", num, player.MaxSP, num >= player.MaxSP);
		}, (Player player, RegenerateEnergyResponse response) => new PlayerBatchUpdate
		{
			PlayerId = (player.PlayerID ?? string.Empty),
			SPChange = response.NewValue - oldSP,
			LastSpRegenTime = player.LastSpRegenTime
		});
	}

	[AsyncStateMachine(typeof(_003CRegenerateSPAsync_003Ed__9))]
	[DebuggerStepThrough]
	[Obsolete("Use RegenerateSP(DateTimeOffset) instead. This async version will be removed in a future version.")]
	public async global::System.Threading.Tasks.Task<Result<RegenerateEnergyResponse>> RegenerateSPAsync(DateTimeOffset now)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		return await global::System.Threading.Tasks.Task.FromResult<Result<RegenerateEnergyResponse>>(RegenerateSP(now));
	}

	public Result<OfflineRegenerationResponse> CalculateOfflineRegeneration(DateTimeOffset now)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		int epGained = 0;
		int spGained = 0;
		DateTimeOffset nextEpTick = now;
		DateTimeOffset nextSpTick = now;
		return _stateService.ExecuteUpdate<OfflineRegenerationResponse>((Player player) => ValidationResult.Success(), delegate(Player player)
		{
			//IL_0335: Unknown result type (might be due to invalid IL or missing references)
			//IL_033a: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_04e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_04e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_04fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0502: Unknown result type (might be due to invalid IL or missing references)
			//IL_0381: Unknown result type (might be due to invalid IL or missing references)
			//IL_0378: Unknown result type (might be due to invalid IL or missing references)
			//IL_0316: Unknown result type (might be due to invalid IL or missing references)
			//IL_031b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0386: Unknown result type (might be due to invalid IL or missing references)
			//IL_038e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0391: Unknown result type (might be due to invalid IL or missing references)
			//IL_0249: Unknown result type (might be due to invalid IL or missing references)
			//IL_024e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0250: Unknown result type (might be due to invalid IL or missing references)
			//IL_0255: Unknown result type (might be due to invalid IL or missing references)
			//IL_0273: Unknown result type (might be due to invalid IL or missing references)
			//IL_0278: Unknown result type (might be due to invalid IL or missing references)
			//IL_04c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_03fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_03fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0402: Unknown result type (might be due to invalid IL or missing references)
			//IL_0422: Unknown result type (might be due to invalid IL or missing references)
			//IL_0427: Unknown result type (might be due to invalid IL or missing references)
			if (player.EP < 0 || player.SP < 0)
			{
				Console.WriteLine($"⚠\ufe0f Player has negative energy! EP: {player.EP}, SP: {player.SP}");
				player.SetEP(Math.Max(player.EP, 0));
				player.SetSP(Math.Max(player.SP, 0));
			}
			if (player.EP > player.MaxEP)
			{
				Console.WriteLine($"⚠\ufe0f EP over max! Capping {player.EP} → {player.MaxEP}");
				epGained = player.MaxEP - player.EP;
				player.SetEP(player.MaxEP);
			}
			if (player.SP > player.MaxSP)
			{
				Console.WriteLine($"⚠\ufe0f SP over max! Capping {player.SP} → {player.MaxSP}");
				spGained = player.MaxSP - player.SP;
				player.SetSP(player.MaxSP);
			}
			TimeSpan val2;
			if (player.EP < player.MaxEP)
			{
				DateTimeOffset val = (DateTimeOffset)(((_003F?)player.LastEpRegenTime) ?? ((DateTimeOffset)(ref now)).AddMinutes(-1.0));
				int num = CalculateRegenCount(val, now, 1);
				if (num > 0)
				{
					int eP = player.EP;
					int num2 = Math.Min(num, player.MaxEP - eP);
					if (num2 > 0)
					{
						player.SetEP(player.EP + num2);
						epGained += num2;
						val2 = now - val;
						int num3 = (int)(((TimeSpan)(ref val2)).TotalMinutes / 1.0);
						nextEpTick = ((DateTimeOffset)(ref val)).AddMinutes((double)(num3 + 1));
						Console.WriteLine($"Offline EP regen: +{num2} (was {eP}, now {player.EP}/{player.MaxEP})");
					}
				}
				else
				{
					nextEpTick = ((DateTimeOffset)(ref val)).AddMinutes(1.0);
				}
			}
			else
			{
				nextEpTick = ((DateTimeOffset)(ref now)).AddMinutes(1.0);
			}
			if (player.SP < player.MaxSP)
			{
				DateTimeOffset val3 = (DateTimeOffset)(((_003F?)player.LastSpRegenTime) ?? ((DateTimeOffset)(ref now)).AddMinutes(-2.0));
				int num4 = CalculateRegenCount(val3, now, 2);
				if (num4 > 0)
				{
					int sP = player.SP;
					int num5 = Math.Min(num4, player.MaxSP - sP);
					if (num5 > 0)
					{
						player.SetSP(player.SP + num5);
						spGained += num5;
						val2 = now - val3;
						int num6 = (int)(((TimeSpan)(ref val2)).TotalMinutes / 2.0);
						nextSpTick = ((DateTimeOffset)(ref val3)).AddMinutes((double)((num6 + 1) * 2));
						Console.WriteLine($"Offline SP regen: +{num5} (was {sP}, now {player.SP}/{player.MaxSP})");
					}
				}
				else
				{
					nextSpTick = ((DateTimeOffset)(ref val3)).AddMinutes(2.0);
				}
			}
			else
			{
				nextSpTick = ((DateTimeOffset)(ref now)).AddMinutes(2.0);
			}
			return new OfflineRegenerationResponse(epGained, spGained, nextEpTick, nextSpTick, player.EP, player.SP, player.MaxEP, player.MaxSP);
		}, (Player player, OfflineRegenerationResponse response) => (epGained == 0 && spGained == 0) ? new PlayerBatchUpdate
		{
			PlayerId = (player.PlayerID ?? string.Empty)
		} : new PlayerBatchUpdate
		{
			PlayerId = (player.PlayerID ?? string.Empty),
			NewEP = player.EP,
			SPChange = spGained
		});
	}

	[Obsolete("Use CalculateOfflineRegeneration(DateTimeOffset) instead. This async version will be removed in a future version.")]
	public global::System.Threading.Tasks.Task<Result<OfflineRegenerationResponse>> CalculateOfflineRegenerationAsync(DateTimeOffset now)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		return global::System.Threading.Tasks.Task.FromResult<Result<OfflineRegenerationResponse>>(CalculateOfflineRegeneration(now));
	}

	private int CalculateRegenCount(DateTimeOffset lastRegen, DateTimeOffset now, int regenMinutes)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		if (lastRegen >= now)
		{
			return 0;
		}
		TimeSpan val = now - lastRegen;
		return (int)(((TimeSpan)(ref val)).TotalMinutes / (double)regenMinutes);
	}
}
