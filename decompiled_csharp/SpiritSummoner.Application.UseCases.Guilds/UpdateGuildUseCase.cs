using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Guilds;
using SpiritSummoner.Domain.Repositories;

namespace SpiritSummoner.Application.UseCases.Guilds;

public class UpdateGuildUseCase : IUseCase<UpdateGuildRequest, Guild>
{
	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<Guild>> _003C_003Et__builder;

		public UpdateGuildRequest request;

		public UpdateGuildUseCase _003C_003E4__this;

		private Guild _003CcurrentGuild_003E5__1;

		private bool _003Csuccess_003E5__2;

		private Guild _003Cguild_003E5__3;

		private bool _003C_003Es__4;

		private Guild _003C_003Es__5;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private TaskAwaiter<Guild?> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0164: Unknown result type (might be due to invalid IL or missing references)
			//IL_0169: Unknown result type (might be due to invalid IL or missing references)
			//IL_0171: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_020d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0212: Unknown result type (might be due to invalid IL or missing references)
			//IL_021a: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			//IL_012f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0144: Unknown result type (might be due to invalid IL or missing references)
			//IL_0146: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<Guild> result;
			try
			{
				TaskAwaiter<bool> awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
					goto IL_0180;
				}
				TaskAwaiter<Guild> awaiter2;
				if (num == 1)
				{
					awaiter2 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter<Guild>);
					num = (_003C_003E1__state = -1);
					goto IL_0229;
				}
				if (string.IsNullOrWhiteSpace(request.GuildId))
				{
					result = Result<Guild>.FailureResult("Guild ID is required");
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
				else
				{
					_003CcurrentGuild_003E5__1 = _003C_003E4__this._guildStateService.GetCurrentGuild();
					if (string.IsNullOrEmpty(_003CcurrentGuild_003E5__1.CurrentWarId) || !(request.GuildName != _003CcurrentGuild_003E5__1.Name))
					{
						awaiter = _003C_003E4__this._guildRepository.UpdateGuildRequestAsync(request).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CExecuteAsync_003Ed__3 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CExecuteAsync_003Ed__3>(ref awaiter, ref _003CExecuteAsync_003Ed__);
							return;
						}
						goto IL_0180;
					}
					result = Result<Guild>.FailureResult("Guld name can't be changed during active war season!");
				}
				goto end_IL_0007;
				IL_0229:
				_003C_003Es__5 = awaiter2.GetResult();
				_003Cguild_003E5__3 = _003C_003Es__5;
				_003C_003Es__5 = null;
				result = ((_003Cguild_003E5__3 != null) ? Result<Guild>.SuccessResult(_003Cguild_003E5__3) : Result<Guild>.FailureResult("Failed to retrieve updated guild data."));
				goto end_IL_0007;
				IL_0180:
				_003C_003Es__4 = awaiter.GetResult();
				_003Csuccess_003E5__2 = _003C_003Es__4;
				if (_003Csuccess_003E5__2)
				{
					awaiter2 = _003C_003E4__this._guildRepository.GetByIdAsync(request.GuildId).GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter2;
						_003CExecuteAsync_003Ed__3 _003CExecuteAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Guild>, _003CExecuteAsync_003Ed__3>(ref awaiter2, ref _003CExecuteAsync_003Ed__);
						return;
					}
					goto IL_0229;
				}
				result = Result<Guild>.FailureResult("Failed to update guild. Please try again.");
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003CcurrentGuild_003E5__1 = null;
				_003Cguild_003E5__3 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CcurrentGuild_003E5__1 = null;
			_003Cguild_003E5__3 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IGuildRepository _guildRepository;

	private readonly IGuildStateService _guildStateService;

	public UpdateGuildUseCase(IGuildRepository guildRepository, IGuildStateService guildStateService)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		_guildRepository = guildRepository ?? throw new ArgumentNullException("guildRepository");
		_guildStateService = guildStateService ?? throw new ArgumentNullException("guildStateService");
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__3))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<Guild>> ExecuteAsync(UpdateGuildRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrWhiteSpace(request.GuildId))
		{
			return Result<Guild>.FailureResult("Guild ID is required");
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
		Guild currentGuild = _guildStateService.GetCurrentGuild();
		if (!string.IsNullOrEmpty(currentGuild.CurrentWarId) && request.GuildName != currentGuild.Name)
		{
			return Result<Guild>.FailureResult("Guld name can't be changed during active war season!");
		}
		if (!(await _guildRepository.UpdateGuildRequestAsync(request)))
		{
			return Result<Guild>.FailureResult("Failed to update guild. Please try again.");
		}
		Guild guild = await _guildRepository.GetByIdAsync(request.GuildId);
		if (guild == null)
		{
			return Result<Guild>.FailureResult("Failed to retrieve updated guild data.");
		}
		return Result<Guild>.SuccessResult(guild);
	}
}
