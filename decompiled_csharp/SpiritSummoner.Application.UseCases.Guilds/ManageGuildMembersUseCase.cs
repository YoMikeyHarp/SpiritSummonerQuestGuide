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

public class ManageGuildMembersUseCase : IUseCase<ManageGuildMembersRequest, Guild>
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public ManageGuildMembersRequest request;

		public GuildRole? actionerNewRole;

		public GuildRole? newRole;

		internal bool _003CExecuteAsync_003Eb__1(Player p)
		{
			p.SetGuildInfo(request.GuildId, actionerNewRole.Value, p.GuildJoinedAt);
			return true;
		}

		internal PlayerBatchUpdate _003CExecuteAsync_003Eb__2(Player p, bool _)
		{
			return new PlayerBatchUpdate
			{
				PlayerId = p.PlayerID,
				GuildUpdates = new PlayerGuildUpdate
				{
					GuildId = request.GuildId,
					GuildRole = ((object)actionerNewRole.Value).ToString(),
					TargetPlayerId = p.PlayerID
				}
			};
		}

		internal bool _003CExecuteAsync_003Eb__7(Player p)
		{
			p.SetGuildInfo(request.GuildId, newRole.Value, p.GuildJoinedAt);
			return true;
		}

		internal PlayerBatchUpdate _003CExecuteAsync_003Eb__8(Player p, bool _)
		{
			return new PlayerBatchUpdate
			{
				PlayerId = p.PlayerID,
				GuildUpdates = new PlayerGuildUpdate
				{
					GuildId = request.GuildId,
					GuildRole = ((object)newRole.Value).ToString(),
					TargetPlayerId = p.PlayerID
				}
			};
		}
	}

	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<Guild>> _003C_003Et__builder;

		public ManageGuildMembersRequest request;

		public ManageGuildMembersUseCase _003C_003E4__this;

		private _003C_003Ec__DisplayClass3_0 _003C_003E8__1;

		private Guild _003Cguild_003E5__2;

		private GuildMember _003CactioningMember_003E5__3;

		private GuildMember _003CtargetMember_003E5__4;

		private bool _003Csuccess_003E5__5;

		private Guild _003CupdatedGuild_003E5__6;

		private Guild _003C_003Es__7;

		private GuildMember _003C_003Es__8;

		private GuildMember _003C_003Es__9;

		private GuildMemberAction _003C_003Es__10;

		private bool _003C_003Es__11;

		private bool _003C_003Es__12;

		private bool _003C_003Es__13;

		private bool _003C_003Es__14;

		private Guild _003C_003Es__15;

		private TaskAwaiter<Guild?> _003C_003Eu__1;

		private TaskAwaiter<GuildMember?> _003C_003Eu__2;

		private TaskAwaiter<bool> _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_014b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0150: Unknown result type (might be due to invalid IL or missing references)
			//IL_0158: Unknown result type (might be due to invalid IL or missing references)
			//IL_022a: Unknown result type (might be due to invalid IL or missing references)
			//IL_022f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0237: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0499: Unknown result type (might be due to invalid IL or missing references)
			//IL_049e: Unknown result type (might be due to invalid IL or missing references)
			//IL_04a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0560: Unknown result type (might be due to invalid IL or missing references)
			//IL_0565: Unknown result type (might be due to invalid IL or missing references)
			//IL_056d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0630: Unknown result type (might be due to invalid IL or missing references)
			//IL_0635: Unknown result type (might be due to invalid IL or missing references)
			//IL_063d: Unknown result type (might be due to invalid IL or missing references)
			//IL_06e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_06e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_06f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0961: Unknown result type (might be due to invalid IL or missing references)
			//IL_0966: Unknown result type (might be due to invalid IL or missing references)
			//IL_096e: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_020a: Unknown result type (might be due to invalid IL or missing references)
			//IL_020c: Unknown result type (might be due to invalid IL or missing references)
			//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_05f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_05fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_06aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_06af: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_012d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0526: Unknown result type (might be due to invalid IL or missing references)
			//IL_052b: Unknown result type (might be due to invalid IL or missing references)
			//IL_045f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0464: Unknown result type (might be due to invalid IL or missing references)
			//IL_0610: Unknown result type (might be due to invalid IL or missing references)
			//IL_0612: Unknown result type (might be due to invalid IL or missing references)
			//IL_06c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_06c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0927: Unknown result type (might be due to invalid IL or missing references)
			//IL_092c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0540: Unknown result type (might be due to invalid IL or missing references)
			//IL_0542: Unknown result type (might be due to invalid IL or missing references)
			//IL_0479: Unknown result type (might be due to invalid IL or missing references)
			//IL_047b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0941: Unknown result type (might be due to invalid IL or missing references)
			//IL_0943: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<Guild> result;
			try
			{
				TaskAwaiter<Guild> awaiter8;
				TaskAwaiter<GuildMember> awaiter7;
				TaskAwaiter<GuildMember> awaiter6;
				TaskAwaiter<bool> awaiter5;
				TaskAwaiter<bool> awaiter4;
				TaskAwaiter<bool> awaiter3;
				TaskAwaiter<bool> awaiter2;
				TaskAwaiter<Guild> awaiter;
				switch (num)
				{
				default:
					_003C_003E8__1 = new _003C_003Ec__DisplayClass3_0();
					_003C_003E8__1.request = request;
					if (string.IsNullOrEmpty(_003C_003E8__1.request.GuildId))
					{
						result = Result<Guild>.FailureResult("Guild ID is required");
					}
					else if (string.IsNullOrEmpty(_003C_003E8__1.request.TargetPlayerId))
					{
						result = Result<Guild>.FailureResult("Target player ID is required");
					}
					else
					{
						if (!string.IsNullOrEmpty(_003C_003E4__this._playerStateService.CurrentPlayerId))
						{
							awaiter8 = _003C_003E4__this._guildRepo.GetByIdAsync(_003C_003E8__1.request.GuildId).GetAwaiter();
							if (!awaiter8.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter8;
								_003CExecuteAsync_003Ed__3 _003CExecuteAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Guild>, _003CExecuteAsync_003Ed__3>(ref awaiter8, ref _003CExecuteAsync_003Ed__);
								return;
							}
							goto IL_0167;
						}
						result = Result<Guild>.FailureResult("Actioning player ID is required");
					}
					goto end_IL_0007;
				case 0:
					awaiter8 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Guild>);
					num = (_003C_003E1__state = -1);
					goto IL_0167;
				case 1:
					awaiter7 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter<GuildMember>);
					num = (_003C_003E1__state = -1);
					goto IL_0246;
				case 2:
					awaiter6 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter<GuildMember>);
					num = (_003C_003E1__state = -1);
					goto IL_030b;
				case 3:
					awaiter5 = _003C_003Eu__3;
					_003C_003Eu__3 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
					goto IL_04b5;
				case 4:
					awaiter4 = _003C_003Eu__3;
					_003C_003Eu__3 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
					goto IL_057c;
				case 5:
					awaiter3 = _003C_003Eu__3;
					_003C_003Eu__3 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
					goto IL_064c;
				case 6:
					awaiter2 = _003C_003Eu__3;
					_003C_003Eu__3 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
					goto IL_0700;
				case 7:
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Guild>);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_04b5:
					_003C_003Es__11 = awaiter5.GetResult();
					_003Csuccess_003E5__5 = _003C_003Es__11;
					_003C_003E8__1.actionerNewRole = GuildRole.Vice_Guildmaster;
					goto IL_072b;
					IL_0246:
					_003C_003Es__8 = awaiter7.GetResult();
					_003CactioningMember_003E5__3 = _003C_003Es__8;
					_003C_003Es__8 = null;
					if (_003CactioningMember_003E5__3 != null)
					{
						awaiter6 = _003C_003E4__this._guildRepo.GetMemberAsync(_003C_003E8__1.request.GuildId, _003C_003E8__1.request.TargetPlayerId).GetAwaiter();
						if (!awaiter6.IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__2 = awaiter6;
							_003CExecuteAsync_003Ed__3 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<GuildMember>, _003CExecuteAsync_003Ed__3>(ref awaiter6, ref _003CExecuteAsync_003Ed__);
							return;
						}
						goto IL_030b;
					}
					result = Result<Guild>.FailureResult("Actioning player is not a member of this guild");
					goto end_IL_0007;
					IL_066a:
					awaiter2 = _003C_003E4__this._guildRepo.KickMemberAsync(_003C_003E8__1.request.GuildId, _003C_003E8__1.request.TargetPlayerId, _003C_003E4__this._playerStateService.CurrentPlayerId).GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						num = (_003C_003E1__state = 6);
						_003C_003Eu__3 = awaiter2;
						_003CExecuteAsync_003Ed__3 _003CExecuteAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CExecuteAsync_003Ed__3>(ref awaiter2, ref _003CExecuteAsync_003Ed__);
						return;
					}
					goto IL_0700;
					IL_057c:
					_003C_003Es__12 = awaiter4.GetResult();
					_003Csuccess_003E5__5 = _003C_003Es__12;
					goto IL_072b;
					IL_0700:
					_003C_003Es__14 = awaiter2.GetResult();
					_003Csuccess_003E5__5 = _003C_003Es__14;
					goto IL_072b;
					IL_030b:
					_003C_003Es__9 = awaiter6.GetResult();
					_003CtargetMember_003E5__4 = _003C_003Es__9;
					_003C_003Es__9 = null;
					if (_003CtargetMember_003E5__4 == null)
					{
						result = Result<Guild>.FailureResult("Target player is not a member of this guild");
					}
					else
					{
						if (CanPerformAction(_003CactioningMember_003E5__3, _003C_003E8__1.request.Action, _003CtargetMember_003E5__4))
						{
							_003Csuccess_003E5__5 = false;
							_003C_003E8__1.newRole = null;
							_003C_003E8__1.actionerNewRole = null;
							GuildMemberAction action = _003C_003E8__1.request.Action;
							_003C_003Es__10 = action;
							switch (_003C_003Es__10)
							{
							case GuildMemberAction.Promote:
								break;
							case GuildMemberAction.Demote:
								goto IL_059b;
							case GuildMemberAction.Kick:
								goto IL_066a;
							default:
								result = Result<Guild>.FailureResult("Invalid action");
								goto end_IL_0007;
							}
							_003C_003E8__1.newRole = _003CtargetMember_003E5__4.GetPromotedRole();
							if (_003C_003E8__1.newRole.GetValueOrDefault() == GuildRole.Guildmaster)
							{
								awaiter5 = _003C_003E4__this._guildRepo.TransferLeadershipAsync(_003C_003E8__1.request.GuildId, _003C_003E8__1.request.TargetPlayerId, _003C_003E4__this._playerStateService.CurrentPlayerId).GetAwaiter();
								if (!awaiter5.IsCompleted)
								{
									num = (_003C_003E1__state = 3);
									_003C_003Eu__3 = awaiter5;
									_003CExecuteAsync_003Ed__3 _003CExecuteAsync_003Ed__ = this;
									_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CExecuteAsync_003Ed__3>(ref awaiter5, ref _003CExecuteAsync_003Ed__);
									return;
								}
								goto IL_04b5;
							}
							awaiter4 = _003C_003E4__this._guildRepo.PromoteMemberAsync(_003C_003E8__1.request.GuildId, _003C_003E8__1.request.TargetPlayerId, _003C_003E8__1.newRole.Value).GetAwaiter();
							if (!awaiter4.IsCompleted)
							{
								num = (_003C_003E1__state = 4);
								_003C_003Eu__3 = awaiter4;
								_003CExecuteAsync_003Ed__3 _003CExecuteAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CExecuteAsync_003Ed__3>(ref awaiter4, ref _003CExecuteAsync_003Ed__);
								return;
							}
							goto IL_057c;
						}
						result = Result<Guild>.FailureResult("Insufficient permissions to perform this action");
					}
					goto end_IL_0007;
					IL_059b:
					_003C_003E8__1.newRole = _003CtargetMember_003E5__4.GetDemotedRole();
					awaiter3 = _003C_003E4__this._guildRepo.DemoteMemberAsync(_003C_003E8__1.request.GuildId, _003C_003E8__1.request.TargetPlayerId, _003C_003E8__1.newRole.Value).GetAwaiter();
					if (!awaiter3.IsCompleted)
					{
						num = (_003C_003E1__state = 5);
						_003C_003Eu__3 = awaiter3;
						_003CExecuteAsync_003Ed__3 _003CExecuteAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CExecuteAsync_003Ed__3>(ref awaiter3, ref _003CExecuteAsync_003Ed__);
						return;
					}
					goto IL_064c;
					IL_0167:
					_003C_003Es__7 = awaiter8.GetResult();
					_003Cguild_003E5__2 = _003C_003Es__7;
					_003C_003Es__7 = null;
					if (_003Cguild_003E5__2 != null)
					{
						awaiter7 = _003C_003E4__this._guildRepo.GetMemberAsync(_003C_003E8__1.request.GuildId, _003C_003E4__this._playerStateService.CurrentPlayerId).GetAwaiter();
						if (!awaiter7.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter7;
							_003CExecuteAsync_003Ed__3 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<GuildMember>, _003CExecuteAsync_003Ed__3>(ref awaiter7, ref _003CExecuteAsync_003Ed__);
							return;
						}
						goto IL_0246;
					}
					result = Result<Guild>.FailureResult("Guild " + _003C_003E8__1.request.GuildId + " not found");
					goto end_IL_0007;
					IL_072b:
					if (_003Csuccess_003E5__5)
					{
						if (_003C_003E8__1.actionerNewRole.HasValue)
						{
							_003C_003E4__this._playerStateService.ExecuteUpdate<bool>((Player _) => ValidationResult.Success(), delegate(Player p)
							{
								p.SetGuildInfo(_003C_003E8__1.request.GuildId, _003C_003E8__1.actionerNewRole.Value, p.GuildJoinedAt);
								return true;
							}, (Player p, bool _) => new PlayerBatchUpdate
							{
								PlayerId = p.PlayerID,
								GuildUpdates = new PlayerGuildUpdate
								{
									GuildId = _003C_003E8__1.request.GuildId,
									GuildRole = ((object)_003C_003E8__1.actionerNewRole.Value).ToString(),
									TargetPlayerId = p.PlayerID
								}
							});
						}
						if (_003C_003E8__1.request.TargetPlayerId == _003C_003E4__this._playerStateService.CurrentPlayerId)
						{
							if (_003C_003E8__1.request.Action == GuildMemberAction.Kick)
							{
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
							}
							else if (_003C_003E8__1.newRole.HasValue)
							{
								_003C_003E4__this._playerStateService.ExecuteUpdate<bool>((Player _) => ValidationResult.Success(), delegate(Player p)
								{
									p.SetGuildInfo(_003C_003E8__1.request.GuildId, _003C_003E8__1.newRole.Value, p.GuildJoinedAt);
									return true;
								}, (Player p, bool _) => new PlayerBatchUpdate
								{
									PlayerId = p.PlayerID,
									GuildUpdates = new PlayerGuildUpdate
									{
										GuildId = _003C_003E8__1.request.GuildId,
										GuildRole = ((object)_003C_003E8__1.newRole.Value).ToString(),
										TargetPlayerId = p.PlayerID
									}
								});
							}
						}
						awaiter = _003C_003E4__this._guildRepo.GetByIdAsync(_003C_003E8__1.request.GuildId).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 7);
							_003C_003Eu__1 = awaiter;
							_003CExecuteAsync_003Ed__3 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Guild>, _003CExecuteAsync_003Ed__3>(ref awaiter, ref _003CExecuteAsync_003Ed__);
							return;
						}
						break;
					}
					result = Result<Guild>.FailureResult("Failed to " + ((object)_003C_003E8__1.request.Action).ToString().ToLower() + " member");
					goto end_IL_0007;
					IL_064c:
					_003C_003Es__13 = awaiter3.GetResult();
					_003Csuccess_003E5__5 = _003C_003Es__13;
					goto IL_072b;
				}
				_003C_003Es__15 = awaiter.GetResult();
				_003CupdatedGuild_003E5__6 = _003C_003Es__15;
				_003C_003Es__15 = null;
				result = Result<Guild>.SuccessResult(_003CupdatedGuild_003E5__6 ?? _003Cguild_003E5__2);
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003Cguild_003E5__2 = null;
				_003CactioningMember_003E5__3 = null;
				_003CtargetMember_003E5__4 = null;
				_003CupdatedGuild_003E5__6 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003Cguild_003E5__2 = null;
			_003CactioningMember_003E5__3 = null;
			_003CtargetMember_003E5__4 = null;
			_003CupdatedGuild_003E5__6 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IGuildRepository _guildRepo;

	private readonly IPlayerStateService _playerStateService;

	public ManageGuildMembersUseCase(IGuildRepository guildRepo, IPlayerStateService playerStateService)
	{
		_guildRepo = guildRepo;
		_playerStateService = playerStateService;
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__3))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<Guild>> ExecuteAsync(ManageGuildMembersRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		ManageGuildMembersRequest request2 = request;
		if (string.IsNullOrEmpty(request2.GuildId))
		{
			return Result<Guild>.FailureResult("Guild ID is required");
		}
		if (string.IsNullOrEmpty(request2.TargetPlayerId))
		{
			return Result<Guild>.FailureResult("Target player ID is required");
		}
		if (string.IsNullOrEmpty(_playerStateService.CurrentPlayerId))
		{
			return Result<Guild>.FailureResult("Actioning player ID is required");
		}
		Guild guild = await _guildRepo.GetByIdAsync(request2.GuildId);
		if (guild == null)
		{
			return Result<Guild>.FailureResult("Guild " + request2.GuildId + " not found");
		}
		GuildMember actioningMember = await _guildRepo.GetMemberAsync(request2.GuildId, _playerStateService.CurrentPlayerId);
		if (actioningMember == null)
		{
			return Result<Guild>.FailureResult("Actioning player is not a member of this guild");
		}
		GuildMember targetMember = await _guildRepo.GetMemberAsync(request2.GuildId, request2.TargetPlayerId);
		if (targetMember == null)
		{
			return Result<Guild>.FailureResult("Target player is not a member of this guild");
		}
		if (!CanPerformAction(actioningMember, request2.Action, targetMember))
		{
			return Result<Guild>.FailureResult("Insufficient permissions to perform this action");
		}
		GuildRole? newRole = null;
		GuildRole? actionerNewRole = null;
		bool success;
		switch (request2.Action)
		{
		case GuildMemberAction.Promote:
			newRole = targetMember.GetPromotedRole();
			if (newRole.GetValueOrDefault() == GuildRole.Guildmaster)
			{
				success = await _guildRepo.TransferLeadershipAsync(request2.GuildId, request2.TargetPlayerId, _playerStateService.CurrentPlayerId);
				actionerNewRole = GuildRole.Vice_Guildmaster;
			}
			else
			{
				success = await _guildRepo.PromoteMemberAsync(request2.GuildId, request2.TargetPlayerId, newRole.Value);
			}
			break;
		case GuildMemberAction.Demote:
			newRole = targetMember.GetDemotedRole();
			success = await _guildRepo.DemoteMemberAsync(request2.GuildId, request2.TargetPlayerId, newRole.Value);
			break;
		case GuildMemberAction.Kick:
			success = await _guildRepo.KickMemberAsync(request2.GuildId, request2.TargetPlayerId, _playerStateService.CurrentPlayerId);
			break;
		default:
			return Result<Guild>.FailureResult("Invalid action");
		}
		if (!success)
		{
			return Result<Guild>.FailureResult("Failed to " + ((object)request2.Action).ToString().ToLower() + " member");
		}
		if (actionerNewRole.HasValue)
		{
			_playerStateService.ExecuteUpdate<bool>((Player _) => ValidationResult.Success(), delegate(Player p)
			{
				p.SetGuildInfo(request2.GuildId, actionerNewRole.Value, p.GuildJoinedAt);
				return true;
			}, (Player p, bool _) => new PlayerBatchUpdate
			{
				PlayerId = p.PlayerID,
				GuildUpdates = new PlayerGuildUpdate
				{
					GuildId = request2.GuildId,
					GuildRole = ((object)actionerNewRole.Value).ToString(),
					TargetPlayerId = p.PlayerID
				}
			});
		}
		if (request2.TargetPlayerId == _playerStateService.CurrentPlayerId)
		{
			if (request2.Action == GuildMemberAction.Kick)
			{
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
			}
			else if (newRole.HasValue)
			{
				_playerStateService.ExecuteUpdate<bool>((Player _) => ValidationResult.Success(), delegate(Player p)
				{
					p.SetGuildInfo(request2.GuildId, newRole.Value, p.GuildJoinedAt);
					return true;
				}, (Player p, bool _) => new PlayerBatchUpdate
				{
					PlayerId = p.PlayerID,
					GuildUpdates = new PlayerGuildUpdate
					{
						GuildId = request2.GuildId,
						GuildRole = ((object)newRole.Value).ToString(),
						TargetPlayerId = p.PlayerID
					}
				});
			}
		}
		return Result<Guild>.SuccessResult((await _guildRepo.GetByIdAsync(request2.GuildId)) ?? guild);
	}

	private static bool CanPerformAction(GuildMember actioner, GuildMemberAction action, GuildMember target)
	{
		if (actioner.IsLeader)
		{
			return true;
		}
		if (actioner.HasOfficerPermissions)
		{
			return target.Role == GuildRole.Member;
		}
		return false;
	}
}
