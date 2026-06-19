using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Repositories;
using SpiritSummoner.Presentation.Models.Guilds;
using SpiritSummoner.Presentation.ViewModels.Guilds;

namespace SpiritSummoner.Application.UseCases.Guilds;

public class SearchGuildsUseCase : IUseCase<SearchGuildsRequest, List<GuildSearchResultModel>>
{
	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__2 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<List<GuildSearchResultModel>>> _003C_003Et__builder;

		public SearchGuildsRequest request;

		public SearchGuildsUseCase _003C_003E4__this;

		private List<GuildSearchResult> _003CsearchResults_003E5__1;

		private List<GuildSearchResultModel> _003CreadModels_003E5__2;

		private List<GuildSearchResult> _003C_003Es__3;

		private TaskAwaiter<List<GuildSearchResult>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<List<GuildSearchResultModel>> result;
			try
			{
				TaskAwaiter<List<GuildSearchResult>> awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<List<GuildSearchResult>>);
					num = (_003C_003E1__state = -1);
					goto IL_0105;
				}
				if (request.PlayerLevel < 0)
				{
					result = Result<List<GuildSearchResultModel>>.FailureResult("Invalid player level");
				}
				else
				{
					if (request.Limit > 0 && request.Limit <= 100)
					{
						awaiter = _003C_003E4__this._guildRepository.SearchGuildsAsync(request.SearchText, request.Filters, request.PlayerLevel, request.PlayerTrophies, request.Limit).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CExecuteAsync_003Ed__2 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<List<GuildSearchResult>>, _003CExecuteAsync_003Ed__2>(ref awaiter, ref _003CExecuteAsync_003Ed__);
							return;
						}
						goto IL_0105;
					}
					result = Result<List<GuildSearchResultModel>>.FailureResult("Limit must be between 1 and 100");
				}
				goto end_IL_0007;
				IL_0105:
				_003C_003Es__3 = awaiter.GetResult();
				_003CsearchResults_003E5__1 = _003C_003Es__3;
				_003C_003Es__3 = null;
				if (_003CsearchResults_003E5__1 == null || !Enumerable.Any<GuildSearchResult>((global::System.Collections.Generic.IEnumerable<GuildSearchResult>)_003CsearchResults_003E5__1))
				{
					result = Result<List<GuildSearchResultModel>>.SuccessResult(new List<GuildSearchResultModel>());
				}
				else
				{
					_003CreadModels_003E5__2 = Enumerable.ToList<GuildSearchResultModel>(Enumerable.Select<GuildSearchResult, GuildSearchResultModel>((global::System.Collections.Generic.IEnumerable<GuildSearchResult>)_003CsearchResults_003E5__1, (Func<GuildSearchResult, GuildSearchResultModel>)((GuildSearchResult guild) => new GuildSearchResultModel
					{
						Id = guild.GuildId,
						Name = guild.Name,
						Emblem = guild.Emblem,
						Level = guild.Level,
						Rank = guild.Rank,
						MemberCount = guild.MemberCount,
						MaxMembers = guild.MaxMembers,
						Trophies = guild.Trophies,
						IsPublic = guild.IsPublic,
						RequiresApproval = guild.RequiresApproval,
						MinLevelRequired = guild.MinLevelRequired,
						MinTrophiesRequired = guild.MinTrophiesRequired
					})));
					result = Result<List<GuildSearchResultModel>>.SuccessResult(_003CreadModels_003E5__2);
				}
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003CsearchResults_003E5__1 = null;
				_003CreadModels_003E5__2 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CsearchResults_003E5__1 = null;
			_003CreadModels_003E5__2 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IGuildRepository _guildRepository;

	public SearchGuildsUseCase(IGuildRepository guildRepository)
	{
		_guildRepository = guildRepository;
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__2))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<List<GuildSearchResultModel>>> ExecuteAsync(SearchGuildsRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (request.PlayerLevel < 0)
		{
			return Result<List<GuildSearchResultModel>>.FailureResult("Invalid player level");
		}
		if (request.Limit <= 0 || request.Limit > 100)
		{
			return Result<List<GuildSearchResultModel>>.FailureResult("Limit must be between 1 and 100");
		}
		List<GuildSearchResult> searchResults = await _guildRepository.SearchGuildsAsync(request.SearchText, request.Filters, request.PlayerLevel, request.PlayerTrophies, request.Limit);
		if (searchResults == null || !Enumerable.Any<GuildSearchResult>((global::System.Collections.Generic.IEnumerable<GuildSearchResult>)searchResults))
		{
			return Result<List<GuildSearchResultModel>>.SuccessResult(new List<GuildSearchResultModel>());
		}
		List<GuildSearchResultModel> readModels = Enumerable.ToList<GuildSearchResultModel>(Enumerable.Select<GuildSearchResult, GuildSearchResultModel>((global::System.Collections.Generic.IEnumerable<GuildSearchResult>)searchResults, (Func<GuildSearchResult, GuildSearchResultModel>)((GuildSearchResult guild) => new GuildSearchResultModel
		{
			Id = guild.GuildId,
			Name = guild.Name,
			Emblem = guild.Emblem,
			Level = guild.Level,
			Rank = guild.Rank,
			MemberCount = guild.MemberCount,
			MaxMembers = guild.MaxMembers,
			Trophies = guild.Trophies,
			IsPublic = guild.IsPublic,
			RequiresApproval = guild.RequiresApproval,
			MinLevelRequired = guild.MinLevelRequired,
			MinTrophiesRequired = guild.MinTrophiesRequired
		})));
		return Result<List<GuildSearchResultModel>>.SuccessResult(readModels);
	}
}
