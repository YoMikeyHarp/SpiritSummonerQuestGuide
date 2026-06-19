using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.Interfaces;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Guilds;
using SpiritSummoner.Domain.Enums.Common;
using SpiritSummoner.Domain.Enums.Guilds;
using SpiritSummoner.Domain.Repositories;

namespace SpiritSummoner.Application.UseCases.Guilds;

public class CancelDisbandGuildUseCase : IUseCase<CancelDisbandGuildRequest, CancelDisbandGuildResult>
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public CancelDisbandGuildRequest request;

		internal bool _003CExecuteAsync_003Eb__0(string id)
		{
			return id != request.PlayerId;
		}
	}

	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<CancelDisbandGuildResult>> _003C_003Et__builder;

		public CancelDisbandGuildRequest request;

		public CancelDisbandGuildUseCase _003C_003E4__this;

		private _003C_003Ec__DisplayClass3_0 _003C_003E8__1;

		private Guild _003Cguild_003E5__2;

		private GuildMember _003Cmember_003E5__3;

		private bool _003CupdateSuccess_003E5__4;

		private Dictionary<string, GuildMember> _003CallMembers_003E5__5;

		private List<string> _003CmemberIdsToNotify_003E5__6;

		private Guild _003C_003Es__7;

		private GuildMember _003C_003Es__8;

		private bool _003C_003Es__9;

		private Dictionary<string, GuildMember> _003C_003Es__10;

		private Dictionary<string, object> _003CnotificationData_003E5__11;

		private TaskAwaiter<Guild?> _003C_003Eu__1;

		private TaskAwaiter<GuildMember?> _003C_003Eu__2;

		private TaskAwaiter<bool> _003C_003Eu__3;

		private TaskAwaiter<Dictionary<string, GuildMember>> _003C_003Eu__4;

		private TaskAwaiter _003C_003Eu__5;

		private void MoveNext()
		{
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0112: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_037d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0382: Unknown result type (might be due to invalid IL or missing references)
			//IL_038a: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_04bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_04c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0190: Unknown result type (might be due to invalid IL or missing references)
			//IL_0195: Unknown result type (might be due to invalid IL or missing references)
			//IL_0343: Unknown result type (might be due to invalid IL or missing references)
			//IL_0348: Unknown result type (might be due to invalid IL or missing references)
			//IL_047c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0481: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_035d: Unknown result type (might be due to invalid IL or missing references)
			//IL_035f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0496: Unknown result type (might be due to invalid IL or missing references)
			//IL_0498: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0295: Unknown result type (might be due to invalid IL or missing references)
			//IL_029a: Unknown result type (might be due to invalid IL or missing references)
			//IL_02af: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<CancelDisbandGuildResult> result;
			try
			{
				TaskAwaiter<Guild> awaiter5;
				TaskAwaiter<GuildMember> awaiter4;
				TaskAwaiter<bool> awaiter3;
				TaskAwaiter<Dictionary<string, GuildMember>> awaiter2;
				TaskAwaiter awaiter;
				Dictionary<string, object> obj;
				switch (num)
				{
				default:
					_003C_003E8__1 = new _003C_003Ec__DisplayClass3_0();
					_003C_003E8__1.request = request;
					if (string.IsNullOrWhiteSpace(_003C_003E8__1.request.PlayerId))
					{
						result = Result<CancelDisbandGuildResult>.FailureResult("Player ID is required");
					}
					else
					{
						if (!string.IsNullOrWhiteSpace(_003C_003E8__1.request.GuildId))
						{
							awaiter5 = _003C_003E4__this._guildRepository.GetByIdAsync(_003C_003E8__1.request.GuildId).GetAwaiter();
							if (!awaiter5.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter5;
								_003CExecuteAsync_003Ed__3 _003CExecuteAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Guild>, _003CExecuteAsync_003Ed__3>(ref awaiter5, ref _003CExecuteAsync_003Ed__);
								return;
							}
							goto IL_0121;
						}
						result = Result<CancelDisbandGuildResult>.FailureResult("Guild ID is required");
					}
					goto end_IL_0007;
				case 0:
					awaiter5 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Guild>);
					num = (_003C_003E1__state = -1);
					goto IL_0121;
				case 1:
					awaiter4 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter<GuildMember>);
					num = (_003C_003E1__state = -1);
					goto IL_01e6;
				case 2:
					awaiter3 = _003C_003Eu__3;
					_003C_003Eu__3 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
					goto IL_02eb;
				case 3:
					awaiter2 = _003C_003Eu__4;
					_003C_003Eu__4 = default(TaskAwaiter<Dictionary<string, GuildMember>>);
					num = (_003C_003E1__state = -1);
					goto IL_0399;
				case 4:
					{
						awaiter = _003C_003Eu__5;
						_003C_003Eu__5 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_04d2;
					}
					IL_0121:
					_003C_003Es__7 = awaiter5.GetResult();
					_003Cguild_003E5__2 = _003C_003Es__7;
					_003C_003Es__7 = null;
					if (_003Cguild_003E5__2 != null)
					{
						awaiter4 = _003C_003E4__this._guildRepository.GetMemberAsync(_003C_003E8__1.request.GuildId, _003C_003E8__1.request.PlayerId).GetAwaiter();
						if (!awaiter4.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter4;
							_003CExecuteAsync_003Ed__3 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<GuildMember>, _003CExecuteAsync_003Ed__3>(ref awaiter4, ref _003CExecuteAsync_003Ed__);
							return;
						}
						goto IL_01e6;
					}
					result = Result<CancelDisbandGuildResult>.FailureResult("Guild not found");
					goto end_IL_0007;
					IL_0399:
					_003C_003Es__10 = awaiter2.GetResult();
					_003CallMembers_003E5__5 = _003C_003Es__10;
					_003C_003Es__10 = null;
					_003CmemberIdsToNotify_003E5__6 = Enumerable.ToList<string>(Enumerable.Where<string>((global::System.Collections.Generic.IEnumerable<string>)_003CallMembers_003E5__5.Keys, (Func<string, bool>)((string id) => id != _003C_003E8__1.request.PlayerId)));
					if (_003CmemberIdsToNotify_003E5__6.Count <= 0)
					{
						break;
					}
					obj = new Dictionary<string, object>();
					obj.Add("guildId", (object)_003Cguild_003E5__2.ID);
					obj.Add("guildName", (object)_003Cguild_003E5__2.Name);
					obj.Add("initiatedBy", (object)_003Cmember_003E5__3.PlayerName);
					obj.Add("reason", (object)"initiated");
					_003CnotificationData_003E5__11 = obj;
					awaiter = _003C_003E4__this._notificationService.SendToManyAsync((global::System.Collections.Generic.IEnumerable<string>)_003CmemberIdsToNotify_003E5__6, NotificationType.GuildDisbandCancled, _003CnotificationData_003E5__11).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 4);
						_003C_003Eu__5 = awaiter;
						_003CExecuteAsync_003Ed__3 _003CExecuteAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CExecuteAsync_003Ed__3>(ref awaiter, ref _003CExecuteAsync_003Ed__);
						return;
					}
					goto IL_04d2;
					IL_02eb:
					_003C_003Es__9 = awaiter3.GetResult();
					_003CupdateSuccess_003E5__4 = _003C_003Es__9;
					if (_003CupdateSuccess_003E5__4)
					{
						awaiter2 = _003C_003E4__this._guildRepository.GetGuildMembersAsync(_003C_003E8__1.request.GuildId).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 3);
							_003C_003Eu__4 = awaiter2;
							_003CExecuteAsync_003Ed__3 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Dictionary<string, GuildMember>>, _003CExecuteAsync_003Ed__3>(ref awaiter2, ref _003CExecuteAsync_003Ed__);
							return;
						}
						goto IL_0399;
					}
					result = Result<CancelDisbandGuildResult>.FailureResult("Failed to cancel guild disbanding");
					goto end_IL_0007;
					IL_04d2:
					((TaskAwaiter)(ref awaiter)).GetResult();
					_003CnotificationData_003E5__11 = null;
					break;
					IL_01e6:
					_003C_003Es__8 = awaiter4.GetResult();
					_003Cmember_003E5__3 = _003C_003Es__8;
					_003C_003Es__8 = null;
					if (_003Cmember_003E5__3 == null)
					{
						result = Result<CancelDisbandGuildResult>.FailureResult("You are not a member of this guild");
					}
					else if (_003Cmember_003E5__3.Role != GuildRole.Guildmaster)
					{
						result = Result<CancelDisbandGuildResult>.FailureResult("Only the Guildmaster can cancel disbanding");
					}
					else
					{
						if (_003Cguild_003E5__2.IsDisbanding)
						{
							awaiter3 = _003C_003E4__this._guildRepository.SetDisbandScheduleAsync(_003Cguild_003E5__2.ID, null).GetAwaiter();
							if (!awaiter3.IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__3 = awaiter3;
								_003CExecuteAsync_003Ed__3 _003CExecuteAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CExecuteAsync_003Ed__3>(ref awaiter3, ref _003CExecuteAsync_003Ed__);
								return;
							}
							goto IL_02eb;
						}
						result = Result<CancelDisbandGuildResult>.FailureResult("Guild is not scheduled for disbanding");
					}
					goto end_IL_0007;
				}
				result = Result<CancelDisbandGuildResult>.SuccessResult(new CancelDisbandGuildResult
				{
					Success = true,
					Message = "Guild disbanding has been cancelled."
				});
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003Cguild_003E5__2 = null;
				_003Cmember_003E5__3 = null;
				_003CallMembers_003E5__5 = null;
				_003CmemberIdsToNotify_003E5__6 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003Cguild_003E5__2 = null;
			_003Cmember_003E5__3 = null;
			_003CallMembers_003E5__5 = null;
			_003CmemberIdsToNotify_003E5__6 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IGuildRepository _guildRepository;

	private readonly IPlayerNotificationService _notificationService;

	public CancelDisbandGuildUseCase(IGuildRepository guildRepository, IPlayerNotificationService playerNotificationService)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		_guildRepository = guildRepository ?? throw new ArgumentNullException("guildRepository");
		_notificationService = playerNotificationService ?? throw new ArgumentNullException("playerNotificationService");
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__3))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<CancelDisbandGuildResult>> ExecuteAsync(CancelDisbandGuildRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		CancelDisbandGuildRequest request2 = request;
		if (string.IsNullOrWhiteSpace(request2.PlayerId))
		{
			return Result<CancelDisbandGuildResult>.FailureResult("Player ID is required");
		}
		if (string.IsNullOrWhiteSpace(request2.GuildId))
		{
			return Result<CancelDisbandGuildResult>.FailureResult("Guild ID is required");
		}
		Guild guild = await _guildRepository.GetByIdAsync(request2.GuildId);
		if (guild == null)
		{
			return Result<CancelDisbandGuildResult>.FailureResult("Guild not found");
		}
		GuildMember member = await _guildRepository.GetMemberAsync(request2.GuildId, request2.PlayerId);
		if (member == null)
		{
			return Result<CancelDisbandGuildResult>.FailureResult("You are not a member of this guild");
		}
		if (member.Role != GuildRole.Guildmaster)
		{
			return Result<CancelDisbandGuildResult>.FailureResult("Only the Guildmaster can cancel disbanding");
		}
		if (!guild.IsDisbanding)
		{
			return Result<CancelDisbandGuildResult>.FailureResult("Guild is not scheduled for disbanding");
		}
		if (!(await _guildRepository.SetDisbandScheduleAsync(guild.ID, null)))
		{
			return Result<CancelDisbandGuildResult>.FailureResult("Failed to cancel guild disbanding");
		}
		List<string> memberIdsToNotify = Enumerable.ToList<string>(Enumerable.Where<string>((global::System.Collections.Generic.IEnumerable<string>)(await _guildRepository.GetGuildMembersAsync(request2.GuildId)).Keys, (Func<string, bool>)((string id) => id != request2.PlayerId)));
		if (memberIdsToNotify.Count > 0)
		{
			Dictionary<string, object> obj = new Dictionary<string, object>();
			obj.Add("guildId", (object)guild.ID);
			obj.Add("guildName", (object)guild.Name);
			obj.Add("initiatedBy", (object)member.PlayerName);
			obj.Add("reason", (object)"initiated");
			Dictionary<string, object> notificationData = obj;
			await _notificationService.SendToManyAsync((global::System.Collections.Generic.IEnumerable<string>)memberIdsToNotify, NotificationType.GuildDisbandCancled, notificationData);
		}
		return Result<CancelDisbandGuildResult>.SuccessResult(new CancelDisbandGuildResult
		{
			Success = true,
			Message = "Guild disbanding has been cancelled."
		});
	}
}
