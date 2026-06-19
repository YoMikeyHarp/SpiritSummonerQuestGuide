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

public class DisbandGuildUseCase : IUseCase<DisbandGuildRequest, DisbandGuildResult>
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public DisbandGuildRequest request;

		internal bool _003CExecuteAsync_003Eb__0(string id)
		{
			return id != request.PlayerId;
		}
	}

	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__4 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<DisbandGuildResult>> _003C_003Et__builder;

		public DisbandGuildRequest request;

		public DisbandGuildUseCase _003C_003E4__this;

		private _003C_003Ec__DisplayClass4_0 _003C_003E8__1;

		private Guild _003Cguild_003E5__2;

		private GuildMember _003Cmember_003E5__3;

		private DateTimeOffset _003CdisbandAt_003E5__4;

		private bool _003CupdateSuccess_003E5__5;

		private Dictionary<string, GuildMember> _003CallMembers_003E5__6;

		private List<string> _003CmemberIdsToNotify_003E5__7;

		private Guild _003C_003Es__8;

		private GuildMember _003C_003Es__9;

		private bool _003C_003Es__10;

		private Dictionary<string, GuildMember> _003C_003Es__11;

		private Dictionary<string, object> _003CnotificationData_003E5__12;

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
			//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0398: Unknown result type (might be due to invalid IL or missing references)
			//IL_039d: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_04f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_04fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0190: Unknown result type (might be due to invalid IL or missing references)
			//IL_0195: Unknown result type (might be due to invalid IL or missing references)
			//IL_035e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0363: Unknown result type (might be due to invalid IL or missing references)
			//IL_0528: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_0378: Unknown result type (might be due to invalid IL or missing references)
			//IL_037a: Unknown result type (might be due to invalid IL or missing references)
			//IL_04cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_04cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_026e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0273: Unknown result type (might be due to invalid IL or missing references)
			//IL_0280: Unknown result type (might be due to invalid IL or missing references)
			//IL_0285: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<DisbandGuildResult> result;
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
					_003C_003E8__1 = new _003C_003Ec__DisplayClass4_0();
					_003C_003E8__1.request = request;
					if (string.IsNullOrWhiteSpace(_003C_003E8__1.request.PlayerId))
					{
						result = Result<DisbandGuildResult>.FailureResult("Player ID is required");
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
								_003CExecuteAsync_003Ed__4 _003CExecuteAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Guild>, _003CExecuteAsync_003Ed__4>(ref awaiter5, ref _003CExecuteAsync_003Ed__);
								return;
							}
							goto IL_0121;
						}
						result = Result<DisbandGuildResult>.FailureResult("Guild ID is required");
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
					goto IL_0306;
				case 3:
					awaiter2 = _003C_003Eu__4;
					_003C_003Eu__4 = default(TaskAwaiter<Dictionary<string, GuildMember>>);
					num = (_003C_003E1__state = -1);
					goto IL_03b4;
				case 4:
					{
						awaiter = _003C_003Eu__5;
						_003C_003Eu__5 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0509;
					}
					IL_0121:
					_003C_003Es__8 = awaiter5.GetResult();
					_003Cguild_003E5__2 = _003C_003Es__8;
					_003C_003Es__8 = null;
					if (_003Cguild_003E5__2 != null)
					{
						awaiter4 = _003C_003E4__this._guildRepository.GetMemberAsync(_003C_003E8__1.request.GuildId, _003C_003E8__1.request.PlayerId).GetAwaiter();
						if (!awaiter4.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter4;
							_003CExecuteAsync_003Ed__4 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<GuildMember>, _003CExecuteAsync_003Ed__4>(ref awaiter4, ref _003CExecuteAsync_003Ed__);
							return;
						}
						goto IL_01e6;
					}
					result = Result<DisbandGuildResult>.FailureResult("Guild not found");
					goto end_IL_0007;
					IL_03b4:
					_003C_003Es__11 = awaiter2.GetResult();
					_003CallMembers_003E5__6 = _003C_003Es__11;
					_003C_003Es__11 = null;
					_003CmemberIdsToNotify_003E5__7 = Enumerable.ToList<string>(Enumerable.Where<string>((global::System.Collections.Generic.IEnumerable<string>)_003CallMembers_003E5__6.Keys, (Func<string, bool>)((string id) => id != _003C_003E8__1.request.PlayerId)));
					if (_003CmemberIdsToNotify_003E5__7.Count <= 0)
					{
						break;
					}
					obj = new Dictionary<string, object>();
					obj.Add("guildId", (object)_003Cguild_003E5__2.ID);
					obj.Add("guildName", (object)_003Cguild_003E5__2.Name);
					obj.Add("disbandAt", (object)((DateTimeOffset)(ref _003CdisbandAt_003E5__4)).ToString("O"));
					obj.Add("initiatedBy", (object)_003Cmember_003E5__3.PlayerName);
					obj.Add("reason", (object)"initiated");
					_003CnotificationData_003E5__12 = obj;
					awaiter = _003C_003E4__this._notificationService.SendToManyAsync((global::System.Collections.Generic.IEnumerable<string>)_003CmemberIdsToNotify_003E5__7, NotificationType.GuildDisbanded, _003CnotificationData_003E5__12).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 4);
						_003C_003Eu__5 = awaiter;
						_003CExecuteAsync_003Ed__4 _003CExecuteAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CExecuteAsync_003Ed__4>(ref awaiter, ref _003CExecuteAsync_003Ed__);
						return;
					}
					goto IL_0509;
					IL_0306:
					_003C_003Es__10 = awaiter3.GetResult();
					_003CupdateSuccess_003E5__5 = _003C_003Es__10;
					if (_003CupdateSuccess_003E5__5)
					{
						awaiter2 = _003C_003E4__this._guildRepository.GetGuildMembersAsync(_003C_003E8__1.request.GuildId).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 3);
							_003C_003Eu__4 = awaiter2;
							_003CExecuteAsync_003Ed__4 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Dictionary<string, GuildMember>>, _003CExecuteAsync_003Ed__4>(ref awaiter2, ref _003CExecuteAsync_003Ed__);
							return;
						}
						goto IL_03b4;
					}
					result = Result<DisbandGuildResult>.FailureResult("Failed to initiate guild disbanding");
					goto end_IL_0007;
					IL_0509:
					((TaskAwaiter)(ref awaiter)).GetResult();
					_003CnotificationData_003E5__12 = null;
					break;
					IL_01e6:
					_003C_003Es__9 = awaiter4.GetResult();
					_003Cmember_003E5__3 = _003C_003Es__9;
					_003C_003Es__9 = null;
					if (_003Cmember_003E5__3 == null)
					{
						result = Result<DisbandGuildResult>.FailureResult("You are not a member of this guild");
					}
					else if (_003Cmember_003E5__3.Role != GuildRole.Guildmaster)
					{
						result = Result<DisbandGuildResult>.FailureResult("Only the Guildmaster can disband the guild");
					}
					else
					{
						if (!_003Cguild_003E5__2.IsDisbanding)
						{
							DateTimeOffset utcNow = DateTimeOffset.UtcNow;
							_003CdisbandAt_003E5__4 = ((DateTimeOffset)(ref utcNow)).AddHours(24.0);
							awaiter3 = _003C_003E4__this._guildRepository.SetDisbandScheduleAsync(_003Cguild_003E5__2.ID, _003CdisbandAt_003E5__4).GetAwaiter();
							if (!awaiter3.IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__3 = awaiter3;
								_003CExecuteAsync_003Ed__4 _003CExecuteAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CExecuteAsync_003Ed__4>(ref awaiter3, ref _003CExecuteAsync_003Ed__);
								return;
							}
							goto IL_0306;
						}
						result = Result<DisbandGuildResult>.FailureResult("Guild is already scheduled for disbanding");
					}
					goto end_IL_0007;
				}
				result = Result<DisbandGuildResult>.SuccessResult(new DisbandGuildResult
				{
					Success = true,
					DisbandScheduledAt = _003CdisbandAt_003E5__4,
					Message = $"Guild will be disbanded in {24} hours. All members have been notified."
				});
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003Cguild_003E5__2 = null;
				_003Cmember_003E5__3 = null;
				_003CallMembers_003E5__6 = null;
				_003CmemberIdsToNotify_003E5__7 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003Cguild_003E5__2 = null;
			_003Cmember_003E5__3 = null;
			_003CallMembers_003E5__6 = null;
			_003CmemberIdsToNotify_003E5__7 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IGuildRepository _guildRepository;

	private readonly IPlayerNotificationService _notificationService;

	private const int DisbandDelayHours = 24;

	public DisbandGuildUseCase(IGuildRepository guildRepository, IPlayerNotificationService notificationService)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		_guildRepository = guildRepository ?? throw new ArgumentNullException("guildRepository");
		_notificationService = notificationService ?? throw new ArgumentNullException("notificationService");
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__4))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<DisbandGuildResult>> ExecuteAsync(DisbandGuildRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		DisbandGuildRequest request2 = request;
		if (string.IsNullOrWhiteSpace(request2.PlayerId))
		{
			return Result<DisbandGuildResult>.FailureResult("Player ID is required");
		}
		if (string.IsNullOrWhiteSpace(request2.GuildId))
		{
			return Result<DisbandGuildResult>.FailureResult("Guild ID is required");
		}
		Guild guild = await _guildRepository.GetByIdAsync(request2.GuildId);
		if (guild == null)
		{
			return Result<DisbandGuildResult>.FailureResult("Guild not found");
		}
		GuildMember member = await _guildRepository.GetMemberAsync(request2.GuildId, request2.PlayerId);
		if (member == null)
		{
			return Result<DisbandGuildResult>.FailureResult("You are not a member of this guild");
		}
		if (member.Role != GuildRole.Guildmaster)
		{
			return Result<DisbandGuildResult>.FailureResult("Only the Guildmaster can disband the guild");
		}
		if (guild.IsDisbanding)
		{
			return Result<DisbandGuildResult>.FailureResult("Guild is already scheduled for disbanding");
		}
		DateTimeOffset utcNow = DateTimeOffset.UtcNow;
		DateTimeOffset disbandAt = ((DateTimeOffset)(ref utcNow)).AddHours(24.0);
		if (!(await _guildRepository.SetDisbandScheduleAsync(guild.ID, disbandAt)))
		{
			return Result<DisbandGuildResult>.FailureResult("Failed to initiate guild disbanding");
		}
		List<string> memberIdsToNotify = Enumerable.ToList<string>(Enumerable.Where<string>((global::System.Collections.Generic.IEnumerable<string>)(await _guildRepository.GetGuildMembersAsync(request2.GuildId)).Keys, (Func<string, bool>)((string id) => id != request2.PlayerId)));
		if (memberIdsToNotify.Count > 0)
		{
			Dictionary<string, object> obj = new Dictionary<string, object>();
			obj.Add("guildId", (object)guild.ID);
			obj.Add("guildName", (object)guild.Name);
			obj.Add("disbandAt", (object)((DateTimeOffset)(ref disbandAt)).ToString("O"));
			obj.Add("initiatedBy", (object)member.PlayerName);
			obj.Add("reason", (object)"initiated");
			Dictionary<string, object> notificationData = obj;
			await _notificationService.SendToManyAsync((global::System.Collections.Generic.IEnumerable<string>)memberIdsToNotify, NotificationType.GuildDisbanded, notificationData);
		}
		return Result<DisbandGuildResult>.SuccessResult(new DisbandGuildResult
		{
			Success = true,
			DisbandScheduledAt = disbandAt,
			Message = $"Guild will be disbanded in {24} hours. All members have been notified."
		});
	}
}
