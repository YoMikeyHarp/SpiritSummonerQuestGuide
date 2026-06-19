using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Repositories;
using SpiritSummoner.Presentation.ViewModels.Guilds;

namespace SpiritSummoner.Application.UseCases.Guilds;

public class CheckGuildNameAvailabilityUseCase : IUseCase<CheckGuildNameRequest, bool>
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public CheckGuildNameRequest request;

		internal bool _003CExecuteAsync_003Eb__0(GuildSearchResult g)
		{
			return g.Name.Equals(request.GuildName, (StringComparison)5);
		}
	}

	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__2 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<bool>> _003C_003Et__builder;

		public CheckGuildNameRequest request;

		public CheckGuildNameAvailabilityUseCase _003C_003E4__this;

		private _003C_003Ec__DisplayClass2_0 _003C_003E8__1;

		private List<GuildSearchResult> _003Cresults_003E5__2;

		private bool _003CisTaken_003E5__3;

		private List<GuildSearchResult> _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter<List<GuildSearchResult>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<bool> result;
			try
			{
				if (num == 0)
				{
					goto IL_0055;
				}
				_003C_003E8__1 = new _003C_003Ec__DisplayClass2_0();
				_003C_003E8__1.request = request;
				if (!string.IsNullOrWhiteSpace(_003C_003E8__1.request.GuildName))
				{
					goto IL_0055;
				}
				result = Result<bool>.FailureResult("Guild name is required");
				goto end_IL_0007;
				IL_0055:
				try
				{
					TaskAwaiter<List<GuildSearchResult>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this._guildRepository.SearchGuildsAsync(_003C_003E8__1.request.GuildName, null, 1, 0L, 1).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CExecuteAsync_003Ed__2 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<List<GuildSearchResult>>, _003CExecuteAsync_003Ed__2>(ref awaiter, ref _003CExecuteAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<List<GuildSearchResult>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__4 = awaiter.GetResult();
					_003Cresults_003E5__2 = _003C_003Es__4;
					_003C_003Es__4 = null;
					_003CisTaken_003E5__3 = Enumerable.Any<GuildSearchResult>((global::System.Collections.Generic.IEnumerable<GuildSearchResult>)_003Cresults_003E5__2, (Func<GuildSearchResult, bool>)((GuildSearchResult g) => g.Name.Equals(_003C_003E8__1.request.GuildName, (StringComparison)5)));
					result = Result<bool>.SuccessResult(_003CisTaken_003E5__3);
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__5 = ex;
					result = Result<bool>.FailureResult("Failed to check name availability: " + _003Cex_003E5__5.Message);
				}
				end_IL_0007:;
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

	private readonly IGuildRepository _guildRepository;

	public CheckGuildNameAvailabilityUseCase(IGuildRepository guildRepository)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		_guildRepository = guildRepository ?? throw new ArgumentNullException("guildRepository");
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__2))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<bool>> ExecuteAsync(CheckGuildNameRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		CheckGuildNameRequest request2 = request;
		if (string.IsNullOrWhiteSpace(request2.GuildName))
		{
			return Result<bool>.FailureResult("Guild name is required");
		}
		try
		{
			bool isTaken = Enumerable.Any<GuildSearchResult>((global::System.Collections.Generic.IEnumerable<GuildSearchResult>)(await _guildRepository.SearchGuildsAsync(request2.GuildName, null, 1, 0L, 1)), (Func<GuildSearchResult, bool>)((GuildSearchResult g) => g.Name.Equals(request2.GuildName, (StringComparison)5)));
			return Result<bool>.SuccessResult(isTaken);
		}
		catch (global::System.Exception ex)
		{
			return Result<bool>.FailureResult("Failed to check name availability: " + ex.Message);
		}
	}
}
