using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel;
using SpiritSummoner.Application.BatchUpdates;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Guilds;
using SpiritSummoner.Domain.Repositories;
using SpiritSummoner.Infrastructure.FirebaseListeners;

namespace SpiritSummoner.Application.State;

public class GuildStateService : IGuildStateService, global::System.IDisposable
{
	[CompilerGenerated]
	private sealed class _003CApplyGuildUpdateAsync_003Ed__20 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<bool>> _003C_003Et__builder;

		public GuildBatchUpdate batchUpdate;

		public GuildStateService _003C_003E4__this;

		private string _003CguildId_003E5__1;

		private GuildChangeType _003CchangeType_003E5__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<bool> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_0197: Unknown result type (might be due to invalid IL or missing references)
			//IL_019c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_023c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0241: Unknown result type (might be due to invalid IL or missing references)
			//IL_0249: Unknown result type (might be due to invalid IL or missing references)
			//IL_0305: Unknown result type (might be due to invalid IL or missing references)
			//IL_030a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0312: Unknown result type (might be due to invalid IL or missing references)
			//IL_0397: Unknown result type (might be due to invalid IL or missing references)
			//IL_039c: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_015d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0162: Unknown result type (might be due to invalid IL or missing references)
			//IL_0202: Unknown result type (might be due to invalid IL or missing references)
			//IL_0207: Unknown result type (might be due to invalid IL or missing references)
			//IL_0177: Unknown result type (might be due to invalid IL or missing references)
			//IL_0179: Unknown result type (might be due to invalid IL or missing references)
			//IL_021c: Unknown result type (might be due to invalid IL or missing references)
			//IL_021e: Unknown result type (might be due to invalid IL or missing references)
			//IL_035d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0362: Unknown result type (might be due to invalid IL or missing references)
			//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0377: Unknown result type (might be due to invalid IL or missing references)
			//IL_0379: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<bool> result;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00a1;
				}
				if ((uint)(num - 1) <= 3u)
				{
					goto IL_00aa;
				}
				if (_003C_003E4__this._currentGuild != null)
				{
					awaiter = _003C_003E4__this._stateLock.WaitAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CApplyGuildUpdateAsync_003Ed__20 _003CApplyGuildUpdateAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CApplyGuildUpdateAsync_003Ed__20>(ref awaiter, ref _003CApplyGuildUpdateAsync_003Ed__);
						return;
					}
					goto IL_00a1;
				}
				result = Result<bool>.FailureResult("No active guild");
				goto end_IL_0007;
				IL_00aa:
				try
				{
					TaskAwaiter<bool> awaiter5;
					TaskAwaiter<bool> awaiter4;
					TaskAwaiter<bool> awaiter3;
					TaskAwaiter<bool> awaiter2;
					switch (num)
					{
					default:
						_003CguildId_003E5__1 = _003C_003E4__this._currentGuild.ID ?? string.Empty;
						_003C_003E4__this.ApplyBatchUpdateToGuild(_003C_003E4__this._currentGuild, batchUpdate);
						if (batchUpdate.XPGain.HasValue)
						{
							awaiter5 = _003C_003E4__this._guildRepo.AddGuildXPAsync(_003CguildId_003E5__1, batchUpdate.XPGain.Value).GetAwaiter();
							if (!awaiter5.IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__2 = awaiter5;
								_003CApplyGuildUpdateAsync_003Ed__20 _003CApplyGuildUpdateAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CApplyGuildUpdateAsync_003Ed__20>(ref awaiter5, ref _003CApplyGuildUpdateAsync_003Ed__);
								return;
							}
							goto IL_01b3;
						}
						goto IL_01bb;
					case 1:
						awaiter5 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
						goto IL_01b3;
					case 2:
						awaiter4 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
						goto IL_0258;
					case 3:
						awaiter3 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
						goto IL_0321;
					case 4:
						{
							awaiter2 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<bool>);
							num = (_003C_003E1__state = -1);
							goto IL_03b3;
						}
						IL_0321:
						awaiter3.GetResult();
						break;
						IL_03b3:
						awaiter2.GetResult();
						break;
						IL_0258:
						awaiter4.GetResult();
						goto IL_0260;
						IL_0260:
						if (!batchUpdate.GuildCoinChange.HasValue)
						{
							break;
						}
						if (batchUpdate.GuildCoinChange.Value >= 0)
						{
							awaiter3 = _003C_003E4__this._guildRepo.AddGuildCoinsAsync(_003CguildId_003E5__1, batchUpdate.GuildCoinChange.Value).GetAwaiter();
							if (!awaiter3.IsCompleted)
							{
								num = (_003C_003E1__state = 3);
								_003C_003Eu__2 = awaiter3;
								_003CApplyGuildUpdateAsync_003Ed__20 _003CApplyGuildUpdateAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CApplyGuildUpdateAsync_003Ed__20>(ref awaiter3, ref _003CApplyGuildUpdateAsync_003Ed__);
								return;
							}
							goto IL_0321;
						}
						awaiter2 = _003C_003E4__this._guildRepo.SpendGuildCoinsAsync(_003CguildId_003E5__1, Math.Abs(batchUpdate.GuildCoinChange.Value)).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 4);
							_003C_003Eu__2 = awaiter2;
							_003CApplyGuildUpdateAsync_003Ed__20 _003CApplyGuildUpdateAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CApplyGuildUpdateAsync_003Ed__20>(ref awaiter2, ref _003CApplyGuildUpdateAsync_003Ed__);
							return;
						}
						goto IL_03b3;
						IL_01b3:
						awaiter5.GetResult();
						goto IL_01bb;
						IL_01bb:
						if (batchUpdate.TrophyChange.HasValue)
						{
							awaiter4 = _003C_003E4__this._guildRepo.UpdateGuildTrophiesAsync(_003CguildId_003E5__1, batchUpdate.TrophyChange.Value).GetAwaiter();
							if (!awaiter4.IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__2 = awaiter4;
								_003CApplyGuildUpdateAsync_003Ed__20 _003CApplyGuildUpdateAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CApplyGuildUpdateAsync_003Ed__20>(ref awaiter4, ref _003CApplyGuildUpdateAsync_003Ed__);
								return;
							}
							goto IL_0258;
						}
						goto IL_0260;
					}
					_003CchangeType_003E5__2 = batchUpdate.GetPrimaryChangeType();
					_003C_003E4__this.PublishEvent(_003CchangeType_003E5__2, _003CguildId_003E5__1, batchUpdate);
					result = Result<bool>.SuccessResult(data: true);
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine("Error applying guild batch update: " + _003Cex_003E5__3.Message);
					result = Result<bool>.FailureResult("Failed to apply update: " + _003Cex_003E5__3.Message);
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this._stateLock.Release();
					}
				}
				goto end_IL_0007;
				IL_00a1:
				((TaskAwaiter)(ref awaiter)).GetResult();
				goto IL_00aa;
				end_IL_0007:;
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
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
	private sealed class _003COnGuildDocumentUpdated_003Ed__28 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public object sender;

		public GuildUpdatedEventArgs e;

		public GuildStateService _003C_003E4__this;

		private Dictionary<string, GuildMember> _003CexistingMembers_003E5__1;

		private string _003CexistingWar_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = _003C_003E4__this._stateLock.WaitAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003COnGuildDocumentUpdated_003Ed__28 _003COnGuildDocumentUpdated_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnGuildDocumentUpdated_003Ed__28>(ref awaiter, ref _003COnGuildDocumentUpdated_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
				}
				((TaskAwaiter)(ref awaiter)).GetResult();
				try
				{
					if (e.Guild != null && e.Guild.ID == _003C_003E4__this._currentGuildId)
					{
						_003CexistingMembers_003E5__1 = _003C_003E4__this._currentGuild?.Members;
						_003C_003E4__this._currentGuild = e.Guild;
						if (_003CexistingMembers_003E5__1 != null && _003CexistingMembers_003E5__1.Count > 0 && (_003C_003E4__this._currentGuild.Members == null || _003C_003E4__this._currentGuild.Members.Count == 0))
						{
							_003C_003E4__this._currentGuild.Members = _003CexistingMembers_003E5__1;
						}
						_003C_003E4__this.PublishEvent(GuildChangeType.GuildProperties, e.Guild.ID ?? string.Empty);
						_003CexistingMembers_003E5__1 = null;
					}
					if (!string.IsNullOrEmpty(e.Guild.CurrentWarId))
					{
						_003CexistingWar_003E5__2 = _003C_003E4__this._currentGuild?.CurrentWarId ?? string.Empty;
						if (_003CexistingWar_003E5__2 != e.Guild.CurrentWarId)
						{
							_003C_003E4__this.PublishEvent(GuildChangeType.War, e.Guild.ID ?? string.Empty);
						}
						_003CexistingWar_003E5__2 = null;
					}
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this._stateLock.Release();
					}
				}
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003COnGuildMembersUpdated_003Ed__29 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public object sender;

		public GuildMembersUpdatedEventArgs e;

		public GuildStateService _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = _003C_003E4__this._stateLock.WaitAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003COnGuildMembersUpdated_003Ed__29 _003COnGuildMembersUpdated_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnGuildMembersUpdated_003Ed__29>(ref awaiter, ref _003COnGuildMembersUpdated_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
				}
				((TaskAwaiter)(ref awaiter)).GetResult();
				try
				{
					if (e.GuildId == _003C_003E4__this._currentGuildId && _003C_003E4__this._currentGuild != null)
					{
						_003C_003E4__this._currentGuild.Members = e.Members;
						_003C_003E4__this.PublishEvent(GuildChangeType.Members, e.GuildId);
					}
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this._stateLock.Release();
					}
				}
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CRefreshGuildAsync_003Ed__21 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<bool>> _003C_003Et__builder;

		public GuildStateService _003C_003E4__this;

		private Dictionary<string, GuildMember> _003CexistingMembers_003E5__1;

		private Guild _003C_003Es__2;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<Guild?> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_0125: Unknown result type (might be due to invalid IL or missing references)
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0132: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<bool> result;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00a1;
				}
				if (num == 1)
				{
					goto IL_00aa;
				}
				if (!string.IsNullOrWhiteSpace(_003C_003E4__this._currentGuildId))
				{
					awaiter = _003C_003E4__this._stateLock.WaitAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CRefreshGuildAsync_003Ed__21 _003CRefreshGuildAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CRefreshGuildAsync_003Ed__21>(ref awaiter, ref _003CRefreshGuildAsync_003Ed__);
						return;
					}
					goto IL_00a1;
				}
				result = Result<bool>.FailureResult("No guild set");
				goto end_IL_0007;
				IL_00aa:
				try
				{
					TaskAwaiter<Guild> awaiter2;
					if (num != 1)
					{
						_003CexistingMembers_003E5__1 = _003C_003E4__this._currentGuild?.Members;
						awaiter2 = _003C_003E4__this._guildRepo.GetByIdAsync(_003C_003E4__this._currentGuildId).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter2;
							_003CRefreshGuildAsync_003Ed__21 _003CRefreshGuildAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Guild>, _003CRefreshGuildAsync_003Ed__21>(ref awaiter2, ref _003CRefreshGuildAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<Guild>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter2.GetResult();
					_003C_003E4__this._currentGuild = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003C_003E4__this._currentGuild == null)
					{
						result = Result<bool>.FailureResult("Guild not found");
					}
					else
					{
						if (_003CexistingMembers_003E5__1 != null && _003CexistingMembers_003E5__1.Count > 0)
						{
							_003C_003E4__this._currentGuild.Members = _003CexistingMembers_003E5__1;
						}
						_003C_003E4__this.PublishEvent(GuildChangeType.GuildProperties, _003C_003E4__this._currentGuildId);
						result = Result<bool>.SuccessResult(data: true);
					}
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this._stateLock.Release();
					}
				}
				goto end_IL_0007;
				IL_00a1:
				((TaskAwaiter)(ref awaiter)).GetResult();
				goto IL_00aa;
				end_IL_0007:;
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
	private sealed class _003CSetCurrentGuildAsync_003Ed__13 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string guildId;

		public GuildStateService _003C_003E4__this;

		private Guild _003C_003Es__1;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<Guild?> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_014b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0150: Unknown result type (might be due to invalid IL or missing references)
			//IL_0158: Unknown result type (might be due to invalid IL or missing references)
			//IL_0112: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_012c: Unknown result type (might be due to invalid IL or missing references)
			//IL_012e: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					if (num == 1)
					{
						goto IL_00a5;
					}
					if (string.IsNullOrWhiteSpace(guildId))
					{
						throw new ArgumentException("Guild ID cannot be null or empty", "guildId");
					}
					awaiter = _003C_003E4__this._stateLock.WaitAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CSetCurrentGuildAsync_003Ed__13 _003CSetCurrentGuildAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSetCurrentGuildAsync_003Ed__13>(ref awaiter, ref _003CSetCurrentGuildAsync_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
				}
				((TaskAwaiter)(ref awaiter)).GetResult();
				goto IL_00a5;
				IL_00a5:
				try
				{
					TaskAwaiter<Guild> awaiter2;
					if (num != 1)
					{
						if (_003C_003E4__this._currentGuildId != guildId && _003C_003E4__this._isListening)
						{
							_003C_003E4__this.StopRealtimeSync();
						}
						_003C_003E4__this._currentGuildId = guildId;
						awaiter2 = _003C_003E4__this._guildRepo.GetByIdAsync(guildId).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter2;
							_003CSetCurrentGuildAsync_003Ed__13 _003CSetCurrentGuildAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Guild>, _003CSetCurrentGuildAsync_003Ed__13>(ref awaiter2, ref _003CSetCurrentGuildAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<Guild>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__1 = awaiter2.GetResult();
					_003C_003E4__this._currentGuild = _003C_003Es__1;
					_003C_003Es__1 = null;
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this._stateLock.Release();
					}
				}
				_003C_003E4__this.StartRealtimeSync();
				_003C_003E4__this.PublishEvent(GuildChangeType.GuildProperties, guildId);
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IGuildRepository _guildRepo;

	private readonly IGuildListenerService _guildListener;

	private Guild? _currentGuild;

	private string? _currentGuildId;

	private bool _isListening;

	private readonly SemaphoreSlim _stateLock = new SemaphoreSlim(1, 1);

	[CompilerGenerated]
	[DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	private EventHandler<GuildStateChangedEventArgs>? m_GuildStateChanged;

	public string? CurrentGuildId => _currentGuildId;

	public bool HasActiveWar => _currentGuild?.HasActiveWarSeason ?? false;

	public bool IsListening => _isListening;

	public event EventHandler<GuildStateChangedEventArgs>? GuildStateChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler<GuildStateChangedEventArgs> val = this.m_GuildStateChanged;
			EventHandler<GuildStateChangedEventArgs> val2;
			do
			{
				val2 = val;
				EventHandler<GuildStateChangedEventArgs> val3 = (EventHandler<GuildStateChangedEventArgs>)(object)global::System.Delegate.Combine((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler<GuildStateChangedEventArgs>>(ref this.m_GuildStateChanged, val3, val2);
			}
			while (val != val2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<GuildStateChangedEventArgs> val = this.m_GuildStateChanged;
			EventHandler<GuildStateChangedEventArgs> val2;
			do
			{
				val2 = val;
				EventHandler<GuildStateChangedEventArgs> val3 = (EventHandler<GuildStateChangedEventArgs>)(object)global::System.Delegate.Remove((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler<GuildStateChangedEventArgs>>(ref this.m_GuildStateChanged, val3, val2);
			}
			while (val != val2);
		}
	}

	public GuildStateService(IGuildRepository guildRepo, IGuildListenerService guildListener)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		_guildRepo = guildRepo ?? throw new ArgumentNullException("guildRepo");
		_guildListener = guildListener ?? throw new ArgumentNullException("guildListener");
		_guildListener.GuildDocumentUpdated += OnGuildDocumentUpdated;
		_guildListener.GuildMembersUpdated += OnGuildMembersUpdated;
	}

	[AsyncStateMachine(typeof(_003CSetCurrentGuildAsync_003Ed__13))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task SetCurrentGuildAsync(string guildId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CSetCurrentGuildAsync_003Ed__13 _003CSetCurrentGuildAsync_003Ed__ = new _003CSetCurrentGuildAsync_003Ed__13();
		_003CSetCurrentGuildAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CSetCurrentGuildAsync_003Ed__._003C_003E4__this = this;
		_003CSetCurrentGuildAsync_003Ed__.guildId = guildId;
		_003CSetCurrentGuildAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CSetCurrentGuildAsync_003Ed__._003C_003Et__builder)).Start<_003CSetCurrentGuildAsync_003Ed__13>(ref _003CSetCurrentGuildAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CSetCurrentGuildAsync_003Ed__._003C_003Et__builder)).Task;
	}

	public void ClearCurrentGuild()
	{
		StopRealtimeSync();
		_stateLock.Wait();
		try
		{
			_currentGuild = null;
			_currentGuildId = null;
		}
		finally
		{
			_stateLock.Release();
		}
		PublishEvent(GuildChangeType.GuildCleared, string.Empty);
	}

	public Guild? GetCurrentGuild()
	{
		if (_currentGuild == null)
		{
			return null;
		}
		return _currentGuild;
	}

	public global::System.Collections.Generic.IReadOnlyList<GuildMember> GetMembers()
	{
		if (_currentGuild == null || _currentGuild.Members == null)
		{
			return global::System.Array.Empty<GuildMember>();
		}
		return (global::System.Collections.Generic.IReadOnlyList<GuildMember>)Enumerable.ToList<GuildMember>((global::System.Collections.Generic.IEnumerable<GuildMember>)_currentGuild.Members.Values);
	}

	public GuildMember? GetMember(string playerId)
	{
		if (_currentGuild == null || _currentGuild.Members == null)
		{
			return null;
		}
		GuildMember guildMember = default(GuildMember);
		return _currentGuild.Members.TryGetValue(playerId, ref guildMember) ? guildMember : null;
	}

	public global::System.Collections.Generic.IReadOnlyList<GuildMember> GetDefenders()
	{
		if (_currentGuild == null || _currentGuild.DefenderPlayerIds == null)
		{
			return global::System.Array.Empty<GuildMember>();
		}
		return (global::System.Collections.Generic.IReadOnlyList<GuildMember>)Enumerable.ToList<GuildMember>(Enumerable.Where<GuildMember>((global::System.Collections.Generic.IEnumerable<GuildMember>)_currentGuild.Members.Values, (Func<GuildMember, bool>)([CompilerGenerated] (GuildMember m) => Enumerable.Contains<string>((global::System.Collections.Generic.IEnumerable<string>)_currentGuild.DefenderPlayerIds, m.PlayerId))));
	}

	public global::System.Collections.Generic.IReadOnlyList<GuildMember> GetMainDefenders()
	{
		if (_currentGuild == null || _currentGuild.MainDefenderPlayerIds == null)
		{
			return global::System.Array.Empty<GuildMember>();
		}
		return (global::System.Collections.Generic.IReadOnlyList<GuildMember>)Enumerable.ToList<GuildMember>(Enumerable.Where<GuildMember>((global::System.Collections.Generic.IEnumerable<GuildMember>)_currentGuild.Members.Values, (Func<GuildMember, bool>)([CompilerGenerated] (GuildMember m) => Enumerable.Contains<string>((global::System.Collections.Generic.IEnumerable<string>)_currentGuild.MainDefenderPlayerIds, m.PlayerId))));
	}

	[AsyncStateMachine(typeof(_003CApplyGuildUpdateAsync_003Ed__20))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<bool>> ApplyGuildUpdateAsync(GuildBatchUpdate batchUpdate)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (_currentGuild == null)
		{
			return Result<bool>.FailureResult("No active guild");
		}
		await _stateLock.WaitAsync();
		try
		{
			string guildId = _currentGuild.ID ?? string.Empty;
			ApplyBatchUpdateToGuild(_currentGuild, batchUpdate);
			if (batchUpdate.XPGain.HasValue)
			{
				await _guildRepo.AddGuildXPAsync(guildId, batchUpdate.XPGain.Value);
			}
			if (batchUpdate.TrophyChange.HasValue)
			{
				await _guildRepo.UpdateGuildTrophiesAsync(guildId, batchUpdate.TrophyChange.Value);
			}
			if (batchUpdate.GuildCoinChange.HasValue)
			{
				if (batchUpdate.GuildCoinChange.Value < 0)
				{
					await _guildRepo.SpendGuildCoinsAsync(guildId, Math.Abs(batchUpdate.GuildCoinChange.Value));
				}
				else
				{
					await _guildRepo.AddGuildCoinsAsync(guildId, batchUpdate.GuildCoinChange.Value);
				}
			}
			GuildChangeType changeType = batchUpdate.GetPrimaryChangeType();
			PublishEvent(changeType, guildId, batchUpdate);
			return Result<bool>.SuccessResult(data: true);
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("Error applying guild batch update: " + ex.Message);
			return Result<bool>.FailureResult("Failed to apply update: " + ex.Message);
		}
		finally
		{
			_stateLock.Release();
		}
	}

	[AsyncStateMachine(typeof(_003CRefreshGuildAsync_003Ed__21))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<bool>> RefreshGuildAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrWhiteSpace(_currentGuildId))
		{
			return Result<bool>.FailureResult("No guild set");
		}
		await _stateLock.WaitAsync();
		try
		{
			Dictionary<string, GuildMember> existingMembers = _currentGuild?.Members;
			_currentGuild = await _guildRepo.GetByIdAsync(_currentGuildId);
			if (_currentGuild == null)
			{
				return Result<bool>.FailureResult("Guild not found");
			}
			if (existingMembers != null && existingMembers.Count > 0)
			{
				_currentGuild.Members = existingMembers;
			}
			PublishEvent(GuildChangeType.GuildProperties, _currentGuildId);
			return Result<bool>.SuccessResult(data: true);
		}
		finally
		{
			_stateLock.Release();
		}
	}

	public void StartRealtimeSync()
	{
		if (!_isListening && !string.IsNullOrWhiteSpace(_currentGuildId))
		{
			_guildListener.StartListeners(_currentGuildId);
			_isListening = true;
		}
	}

	public void StopRealtimeSync()
	{
		if (_isListening)
		{
			_guildListener.StopListeners();
			_isListening = false;
		}
	}

	Guild? IGuildStateService.GetMutableGuild()
	{
		return _currentGuild;
	}

	[AsyncStateMachine(typeof(_003COnGuildDocumentUpdated_003Ed__28))]
	[DebuggerStepThrough]
	private void OnGuildDocumentUpdated(object? sender, GuildUpdatedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003COnGuildDocumentUpdated_003Ed__28 _003COnGuildDocumentUpdated_003Ed__ = new _003COnGuildDocumentUpdated_003Ed__28();
		_003COnGuildDocumentUpdated_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003COnGuildDocumentUpdated_003Ed__._003C_003E4__this = this;
		_003COnGuildDocumentUpdated_003Ed__.sender = sender;
		_003COnGuildDocumentUpdated_003Ed__.e = e;
		_003COnGuildDocumentUpdated_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003COnGuildDocumentUpdated_003Ed__._003C_003Et__builder)).Start<_003COnGuildDocumentUpdated_003Ed__28>(ref _003COnGuildDocumentUpdated_003Ed__);
	}

	[AsyncStateMachine(typeof(_003COnGuildMembersUpdated_003Ed__29))]
	[DebuggerStepThrough]
	private void OnGuildMembersUpdated(object? sender, GuildMembersUpdatedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003COnGuildMembersUpdated_003Ed__29 _003COnGuildMembersUpdated_003Ed__ = new _003COnGuildMembersUpdated_003Ed__29();
		_003COnGuildMembersUpdated_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003COnGuildMembersUpdated_003Ed__._003C_003E4__this = this;
		_003COnGuildMembersUpdated_003Ed__.sender = sender;
		_003COnGuildMembersUpdated_003Ed__.e = e;
		_003COnGuildMembersUpdated_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003COnGuildMembersUpdated_003Ed__._003C_003Et__builder)).Start<_003COnGuildMembersUpdated_003Ed__29>(ref _003COnGuildMembersUpdated_003Ed__);
	}

	private void PublishEvent(GuildChangeType changeType, string guildId, GuildBatchUpdate? batchUpdate = null)
	{
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected O, but got Unknown
		string guildId2 = guildId;
		Dictionary<string, object> changedValues = new Dictionary<string, object>();
		if (batchUpdate != null)
		{
			if (batchUpdate.XPGain.HasValue)
			{
				changedValues["XP"] = batchUpdate.XPGain.Value;
			}
			if (batchUpdate.CrystalChange.HasValue)
			{
				changedValues["Crystals"] = batchUpdate.CrystalChange.Value;
			}
			if (batchUpdate.TrophyChange.HasValue)
			{
				changedValues["Trophies"] = batchUpdate.TrophyChange.Value;
			}
		}
		MainThread.BeginInvokeOnMainThread((Action)delegate
		{
			this.GuildStateChanged?.Invoke((object)this, new GuildStateChangedEventArgs(changeType, guildId2, null, (IReadOnlyDictionary<string, object>?)(object)changedValues));
		});
	}

	private void ApplyBatchUpdateToGuild(Guild guild, GuildBatchUpdate update)
	{
		if (update.XPGain.HasValue)
		{
			guild.CurrentXP += update.XPGain.Value;
		}
		if (update.TrophyChange.HasValue)
		{
			guild.Trophies += update.TrophyChange.Value;
		}
		if (update.GuildCoinChange.HasValue)
		{
			guild.GuildCoins += update.GuildCoinChange.Value;
		}
		if (update.CrystalChange.HasValue)
		{
			guild.Crystals += update.CrystalChange.Value;
		}
		if (update.TotalWinsChange.HasValue)
		{
			guild.TotalWins += update.TotalWinsChange.Value;
		}
		if (update.TotalLossesChange.HasValue)
		{
			guild.TotalLosses += update.TotalLossesChange.Value;
		}
		if (update.UpdateLevel)
		{
			guild.Level++;
			guild.CurrentXP = 0;
			guild.XPForNextLevel = GetTotalEXPForLevel(guild.Level, guild.XPForNextLevel);
		}
	}

	public static int CalculateNextEXPMax(int currentMaxEXP)
	{
		return (int)MathF.Round((float)((double)currentMaxEXP * 1.4));
	}

	public int GetTotalEXPForLevel(int targetLevel, int currentMaxExp)
	{
		double num = 0.0;
		for (int i = 1; i < targetLevel; i++)
		{
			num += (double)currentMaxExp;
			currentMaxExp = CalculateNextEXPMax(currentMaxExp);
		}
		return (int)num;
	}

	public void Dispose()
	{
		StopRealtimeSync();
		_guildListener.GuildDocumentUpdated -= OnGuildDocumentUpdated;
		_guildListener.GuildMembersUpdated -= OnGuildMembersUpdated;
		SemaphoreSlim stateLock = _stateLock;
		if (stateLock != null)
		{
			stateLock.Dispose();
		}
	}
}
