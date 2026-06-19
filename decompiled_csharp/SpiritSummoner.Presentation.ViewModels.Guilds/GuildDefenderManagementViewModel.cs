using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Application.UseCases.Guilds;
using SpiritSummoner.Domain.Entities.Guilds;
using SpiritSummoner.Domain.Enums.Guilds;
using SpiritSummoner.Domain.Repositories;
using SpiritSummoner.Infrastructure.Cache;
using SpiritSummoner.Presentation.Models.Guilds;
using SpiritSummoner.Presentation.Navigation;

namespace SpiritSummoner.Presentation.ViewModels.Guilds;

public class GuildDefenderManagementViewModel : ObservableObject, ILoadableViewModel, global::System.IDisposable
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass32_0
	{
		public Dictionary<string, GuildMember> members;

		internal DefenderReadModel _003CLoadDefendersFromRepository_003Eb__0(KeyValuePair<string, DefenderData> id)
		{
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			GuildMember guildMember = (members.ContainsKey(id.Key) ? members[id.Key] : null);
			DateTimeOffset signUpAt = id.Value.SignUpAt;
			DateTimeOffset? defenseExpiresAt = ((signUpAt != default(DateTimeOffset)) ? new DateTimeOffset?(id.Value.ExpiresAt) : null);
			return new DefenderReadModel
			{
				PlayerId = id.Key,
				PlayerName = (guildMember?.PlayerName ?? ""),
				Role = (guildMember?.Role ?? GuildRole.None),
				Level = (guildMember?.Level ?? 0),
				Trophies = (guildMember?.Trophies ?? 0),
				DefenseSquadIds = (id.Value.SquadIds ?? new List<string>()),
				DefenseExpiresAt = defenseExpiresAt,
				IsMainDefender = id.Value.IsMainDefender
			};
		}
	}

	[CompilerGenerated]
	private sealed class _003CGoBack_003Ed__38 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildDefenderManagementViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
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
					awaiter = _003C_003E4__this._navigationService.GoBackAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CGoBack_003Ed__38 _003CGoBack_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoBack_003Ed__38>(ref awaiter, ref _003CGoBack_003Ed__);
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

	[CompilerGenerated]
	private sealed class _003CLoadDataAsync_003Ed__30 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public object parameter;

		public GuildDefenderManagementViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private string _003CguildId_003E5__3;

		private global::System.Exception _003Cex_003E5__4;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0198: Unknown result type (might be due to invalid IL or missing references)
			//IL_019d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01df: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_010c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0114: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 1u || !_003C_003E4__this.IsLoading)
				{
					try
					{
						TaskAwaiter awaiter;
						if (num != 0)
						{
							if (num == 1)
							{
								awaiter = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_01ee;
							}
							_003C_003Es__2 = 0;
						}
						try
						{
							TaskAwaiter awaiter2;
							if (num == 0)
							{
								awaiter2 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_0123;
							}
							_003C_003E4__this.IsLoading = true;
							_003C_003E4__this.ErrorMessage = string.Empty;
							_003CguildId_003E5__3 = parameter as string;
							if (_003CguildId_003E5__3 == null)
							{
								goto IL_012c;
							}
							if (!string.IsNullOrEmpty(_003CguildId_003E5__3))
							{
								_003C_003E4__this.GuildId = _003CguildId_003E5__3;
								awaiter2 = _003C_003E4__this.LoadDefenders().GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter2;
									_003CLoadDataAsync_003Ed__30 _003CLoadDataAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__30>(ref awaiter2, ref _003CLoadDataAsync_003Ed__);
									return;
								}
								goto IL_0123;
							}
							_003C_003E4__this.ErrorMessage = "No guild ID provided";
							goto end_IL_0025;
							IL_012c:
							_003CguildId_003E5__3 = null;
							goto end_IL_003f;
							IL_0123:
							((TaskAwaiter)(ref awaiter2)).GetResult();
							goto IL_012c;
							end_IL_003f:;
						}
						catch (global::System.Exception ex)
						{
							_003C_003Es__1 = ex;
							_003C_003Es__2 = 1;
						}
						int num2 = _003C_003Es__2;
						if (num2 != 1)
						{
							goto IL_0232;
						}
						_003Cex_003E5__4 = (global::System.Exception)_003C_003Es__1;
						_003C_003E4__this.ErrorMessage = "Failed to load defenders";
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to load defenders. Please try again.").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter;
							_003CLoadDataAsync_003Ed__30 _003CLoadDataAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__30>(ref awaiter, ref _003CLoadDataAsync_003Ed__);
							return;
						}
						goto IL_01ee;
						IL_01ee:
						((TaskAwaiter)(ref awaiter)).GetResult();
						Console.WriteLine($"GuildDefenderManagementViewModel.LoadDataAsync: {_003Cex_003E5__4}");
						_003Cex_003E5__4 = null;
						goto IL_0232;
						IL_0232:
						_003C_003Es__1 = null;
						end_IL_0025:;
					}
					finally
					{
						if (num < 0)
						{
							_003C_003E4__this.IsLoading = false;
						}
					}
				}
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

	[CompilerGenerated]
	private sealed class _003CLoadDefenders_003Ed__31 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildDefenderManagementViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = _003C_003E4__this.LoadDefendersFromRepository().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CLoadDefenders_003Ed__31 _003CLoadDefenders_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDefenders_003Ed__31>(ref awaiter, ref _003CLoadDefenders_003Ed__);
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

	[CompilerGenerated]
	private sealed class _003CLoadDefendersFromRepository_003Ed__32 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildDefenderManagementViewModel _003C_003E4__this;

		private _003C_003Ec__DisplayClass32_0 _003C_003E8__1;

		private Guild _003Cguild_003E5__2;

		private Guild _003C_003Es__3;

		private Guild _003C_003Es__4;

		private Dictionary<string, GuildMember> _003C_003Es__5;

		private Dictionary<string, GuildMember> _003C_003Es__6;

		private global::System.Exception _003Cex_003E5__7;

		private TaskAwaiter<Guild?> _003C_003Eu__1;

		private TaskAwaiter<Dictionary<string, GuildMember>> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0210: Unknown result type (might be due to invalid IL or missing references)
			//IL_0215: Unknown result type (might be due to invalid IL or missing references)
			//IL_021d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num > 1u)
				{
				}
				try
				{
					TaskAwaiter<Guild> awaiter;
					if (num == 0)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Guild>);
						num = (_003C_003E1__state = -1);
						goto IL_00f5;
					}
					TaskAwaiter<Dictionary<string, GuildMember>> awaiter2;
					if (num == 1)
					{
						awaiter2 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<Dictionary<string, GuildMember>>);
						num = (_003C_003E1__state = -1);
						goto IL_022c;
					}
					_003C_003E8__1 = new _003C_003Ec__DisplayClass32_0();
					if (!string.IsNullOrEmpty(_003C_003E4__this.GuildId))
					{
						if (_003C_003E4__this._guildStateService.CurrentGuildId == _003C_003E4__this.GuildId)
						{
							_003C_003Es__3 = _003C_003E4__this._guildStateService.GetCurrentGuild();
							goto IL_0115;
						}
						awaiter = _003C_003E4__this._guildRepository.GetByIdAsync(_003C_003E4__this.GuildId).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CLoadDefendersFromRepository_003Ed__32 _003CLoadDefendersFromRepository_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Guild>, _003CLoadDefendersFromRepository_003Ed__32>(ref awaiter, ref _003CLoadDefendersFromRepository_003Ed__);
							return;
						}
						goto IL_00f5;
					}
					goto end_IL_0011;
					IL_022c:
					_003C_003Es__6 = awaiter2.GetResult();
					_003C_003Es__5 = _003C_003Es__6;
					_003C_003Es__6 = null;
					goto IL_024c;
					IL_0115:
					_003Cguild_003E5__2 = _003C_003Es__3;
					_003C_003Es__3 = null;
					if (_003Cguild_003E5__2 != null)
					{
						if (_003C_003E4__this._guildStateService.CurrentGuildId == _003C_003E4__this.GuildId)
						{
							_003C_003Es__5 = Enumerable.ToDictionary<GuildMember, string, GuildMember>((global::System.Collections.Generic.IEnumerable<GuildMember>)_003C_003E4__this._guildStateService.GetMembers(), (Func<GuildMember, string>)((GuildMember m) => m.PlayerId), (Func<GuildMember, GuildMember>)((GuildMember m) => m));
							goto IL_024c;
						}
						awaiter2 = _003C_003E4__this._guildRepository.GetGuildMembersAsync(_003C_003E4__this.GuildId).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter2;
							_003CLoadDefendersFromRepository_003Ed__32 _003CLoadDefendersFromRepository_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Dictionary<string, GuildMember>>, _003CLoadDefendersFromRepository_003Ed__32>(ref awaiter2, ref _003CLoadDefendersFromRepository_003Ed__);
							return;
						}
						goto IL_022c;
					}
					goto end_IL_0011;
					IL_024c:
					_003C_003E8__1.members = _003C_003Es__5;
					_003C_003Es__5 = null;
					_003C_003E4__this._allDefenders = Enumerable.ToList<DefenderReadModel>(Enumerable.Select<KeyValuePair<string, DefenderData>, DefenderReadModel>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, DefenderData>>)_003Cguild_003E5__2.Defenders, (Func<KeyValuePair<string, DefenderData>, DefenderReadModel>)delegate(KeyValuePair<string, DefenderData> id)
					{
						//IL_0032: Unknown result type (might be due to invalid IL or missing references)
						//IL_0037: Unknown result type (might be due to invalid IL or missing references)
						//IL_0038: Unknown result type (might be due to invalid IL or missing references)
						//IL_003b: Unknown result type (might be due to invalid IL or missing references)
						//IL_0041: Unknown result type (might be due to invalid IL or missing references)
						//IL_005c: Unknown result type (might be due to invalid IL or missing references)
						GuildMember guildMember = (_003C_003E8__1.members.ContainsKey(id.Key) ? _003C_003E8__1.members[id.Key] : null);
						DateTimeOffset signUpAt = id.Value.SignUpAt;
						DateTimeOffset? defenseExpiresAt = ((signUpAt != default(DateTimeOffset)) ? new DateTimeOffset?(id.Value.ExpiresAt) : null);
						return new DefenderReadModel
						{
							PlayerId = id.Key,
							PlayerName = (guildMember?.PlayerName ?? ""),
							Role = (guildMember?.Role ?? GuildRole.None),
							Level = (guildMember?.Level ?? 0),
							Trophies = (guildMember?.Trophies ?? 0),
							DefenseSquadIds = (id.Value.SquadIds ?? new List<string>()),
							DefenseExpiresAt = defenseExpiresAt,
							IsMainDefender = id.Value.IsMainDefender
						};
					}));
					_003C_003E4__this.DefenderCount = _003C_003E4__this._allDefenders.Count;
					_003C_003E4__this.MainDefenderCount = Enumerable.Count<DefenderReadModel>((global::System.Collections.Generic.IEnumerable<DefenderReadModel>)_003C_003E4__this._allDefenders, (Func<DefenderReadModel, bool>)((DefenderReadModel ad) => ad.IsMainDefender));
					_003C_003E4__this.MaxMainDefenders = _003Cguild_003E5__2.MaxMainDefenders;
					_003C_003E4__this.ApplyFilterAndSort();
					_003C_003E4__this.MainDefenders = new ObservableCollection<DefenderReadModel>(Enumerable.Where<DefenderReadModel>((global::System.Collections.Generic.IEnumerable<DefenderReadModel>)_003C_003E4__this._allDefenders, (Func<DefenderReadModel, bool>)((DefenderReadModel d) => d.IsMainDefender)));
					_003C_003E8__1 = null;
					_003Cguild_003E5__2 = null;
					goto end_IL_0011;
					IL_00f5:
					_003C_003Es__4 = awaiter.GetResult();
					_003C_003Es__3 = _003C_003Es__4;
					_003C_003Es__4 = null;
					goto IL_0115;
					end_IL_0011:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__7 = ex;
					Console.WriteLine($"LoadDefendersFromRepository error: {_003Cex_003E5__7}");
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(ex);
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

	[CompilerGenerated]
	private sealed class _003COnGuildStateChanged_003Ed__29 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public object sender;

		public GuildStateChangedEventArgs e;

		public GuildDefenderManagementViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_008d;
				}
				if (e.ChangeType == GuildChangeType.Defenders || e.ChangeType == GuildChangeType.GuildProperties)
				{
					awaiter = _003C_003E4__this.LoadDefendersFromRepository().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003COnGuildStateChanged_003Ed__29 _003COnGuildStateChanged_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnGuildStateChanged_003Ed__29>(ref awaiter, ref _003COnGuildStateChanged_003Ed__);
						return;
					}
					goto IL_008d;
				}
				goto end_IL_0007;
				IL_008d:
				((TaskAwaiter)(ref awaiter)).GetResult();
				end_IL_0007:;
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
	private sealed class _003CRemoveDefender_003Ed__41 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public DefenderReadModel defender;

		public GuildDefenderManagementViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private bool _003Cconfirmed_003E5__3;

		private ManageDefendersRequest _003Crequest_003E5__4;

		private Result<bool> _003Cresult_003E5__5;

		private bool _003C_003Es__6;

		private Result<bool> _003C_003Es__7;

		private global::System.Exception _003Cex_003E5__8;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private TaskAwaiter<Result<bool>> _003C_003Eu__2;

		private TaskAwaiter _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_0385: Unknown result type (might be due to invalid IL or missing references)
			//IL_038a: Unknown result type (might be due to invalid IL or missing references)
			//IL_039f: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_03be: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_03cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0104: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01be: Unknown result type (might be due to invalid IL or missing references)
			//IL_0265: Unknown result type (might be due to invalid IL or missing references)
			//IL_026a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0272: Unknown result type (might be due to invalid IL or missing references)
			//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0303: Unknown result type (might be due to invalid IL or missing references)
			//IL_030b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			//IL_0178: Unknown result type (might be due to invalid IL or missing references)
			//IL_017d: Unknown result type (might be due to invalid IL or missing references)
			//IL_022c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0231: Unknown result type (might be due to invalid IL or missing references)
			//IL_0192: Unknown result type (might be due to invalid IL or missing references)
			//IL_0194: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_0246: Unknown result type (might be due to invalid IL or missing references)
			//IL_0248: Unknown result type (might be due to invalid IL or missing references)
			//IL_02df: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 4u || (defender != null && _003C_003E4__this.CanManageDefenders))
				{
					try
					{
						TaskAwaiter awaiter;
						if ((uint)num > 3u)
						{
							if (num == 4)
							{
								awaiter = _003C_003Eu__3;
								_003C_003Eu__3 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_03da;
							}
							_003C_003Es__2 = 0;
						}
						try
						{
							TaskAwaiter<bool> awaiter5;
							TaskAwaiter<Result<bool>> awaiter4;
							TaskAwaiter awaiter3;
							TaskAwaiter awaiter2;
							switch (num)
							{
							default:
								_003C_003E4__this.IsLoading = true;
								awaiter5 = _003C_003E4__this._navigationService.ShowConfirmationAsync("Remove Defender", "Remove " + defender.PlayerName + " from the defender list? They will need to sign up again to defend.").GetAwaiter();
								if (!awaiter5.IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter5;
									_003CRemoveDefender_003Ed__41 _003CRemoveDefender_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CRemoveDefender_003Ed__41>(ref awaiter5, ref _003CRemoveDefender_003Ed__);
									return;
								}
								goto IL_0113;
							case 0:
								awaiter5 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter<bool>);
								num = (_003C_003E1__state = -1);
								goto IL_0113;
							case 1:
								awaiter4 = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter<Result<bool>>);
								num = (_003C_003E1__state = -1);
								goto IL_01cd;
							case 2:
								awaiter3 = _003C_003Eu__3;
								_003C_003Eu__3 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_0281;
							case 3:
								{
									awaiter2 = _003C_003Eu__3;
									_003C_003Eu__3 = default(TaskAwaiter);
									num = (_003C_003E1__state = -1);
									goto IL_031a;
								}
								IL_01cd:
								_003C_003Es__7 = awaiter4.GetResult();
								_003Cresult_003E5__5 = _003C_003Es__7;
								_003C_003Es__7 = null;
								if (_003Cresult_003E5__5.Success)
								{
									awaiter3 = _003C_003E4__this._navigationService.ShowAlertAsync("Defender Removed", defender.PlayerName + " has been removed from the defender list.").GetAwaiter();
									if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
									{
										num = (_003C_003E1__state = 2);
										_003C_003Eu__3 = awaiter3;
										_003CRemoveDefender_003Ed__41 _003CRemoveDefender_003Ed__ = this;
										((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRemoveDefender_003Ed__41>(ref awaiter3, ref _003CRemoveDefender_003Ed__);
										return;
									}
									goto IL_0281;
								}
								awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", _003Cresult_003E5__5.ErrorMessage ?? "Failed to remove defender.").GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
								{
									num = (_003C_003E1__state = 3);
									_003C_003Eu__3 = awaiter2;
									_003CRemoveDefender_003Ed__41 _003CRemoveDefender_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRemoveDefender_003Ed__41>(ref awaiter2, ref _003CRemoveDefender_003Ed__);
									return;
								}
								goto IL_031a;
								IL_0113:
								_003C_003Es__6 = awaiter5.GetResult();
								_003Cconfirmed_003E5__3 = _003C_003Es__6;
								if (_003Cconfirmed_003E5__3)
								{
									_003Crequest_003E5__4 = new ManageDefendersRequest(_003C_003E4__this.GuildId, defender.PlayerId, DefenderAction.Remove);
									awaiter4 = _003C_003E4__this._manageDefendersUseCase.ExecuteAsync(_003Crequest_003E5__4).GetAwaiter();
									if (!awaiter4.IsCompleted)
									{
										num = (_003C_003E1__state = 1);
										_003C_003Eu__2 = awaiter4;
										_003CRemoveDefender_003Ed__41 _003CRemoveDefender_003Ed__ = this;
										((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<bool>>, _003CRemoveDefender_003Ed__41>(ref awaiter4, ref _003CRemoveDefender_003Ed__);
										return;
									}
									goto IL_01cd;
								}
								goto end_IL_004e;
								IL_0281:
								((TaskAwaiter)(ref awaiter3)).GetResult();
								_003C_003E4__this.CloseDetails();
								break;
								IL_031a:
								((TaskAwaiter)(ref awaiter2)).GetResult();
								break;
							}
							_003Crequest_003E5__4 = null;
							_003Cresult_003E5__5 = null;
							goto IL_0347;
							end_IL_004e:;
						}
						catch (global::System.Exception ex)
						{
							_003C_003Es__1 = ex;
							_003C_003Es__2 = 1;
							goto IL_0347;
						}
						goto end_IL_0033;
						IL_0347:
						int num2 = _003C_003Es__2;
						if (num2 != 1)
						{
							goto IL_041e;
						}
						_003Cex_003E5__8 = (global::System.Exception)_003C_003Es__1;
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "An error occurred while removing the defender.").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 4);
							_003C_003Eu__3 = awaiter;
							_003CRemoveDefender_003Ed__41 _003CRemoveDefender_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRemoveDefender_003Ed__41>(ref awaiter, ref _003CRemoveDefender_003Ed__);
							return;
						}
						goto IL_03da;
						IL_03da:
						((TaskAwaiter)(ref awaiter)).GetResult();
						Console.WriteLine($"RemoveDefender error: {_003Cex_003E5__8}");
						_003Cex_003E5__8 = null;
						goto IL_041e;
						IL_041e:
						_003C_003Es__1 = null;
						end_IL_0033:;
					}
					finally
					{
						if (num < 0)
						{
							_003C_003E4__this.IsLoading = false;
						}
					}
				}
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

	[CompilerGenerated]
	private sealed class _003CRemoveFromMainDefenders_003Ed__40 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public DefenderReadModel defender;

		public GuildDefenderManagementViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private bool _003Cconfirmed_003E5__3;

		private ManageDefendersRequest _003Crequest_003E5__4;

		private Result<bool> _003Cresult_003E5__5;

		private bool _003C_003Es__6;

		private Result<bool> _003C_003Es__7;

		private global::System.Exception _003Cex_003E5__8;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<bool> _003C_003Eu__2;

		private TaskAwaiter<Result<bool>> _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_042c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0431: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0446: Unknown result type (might be due to invalid IL or missing references)
			//IL_0448: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_0466: Unknown result type (might be due to invalid IL or missing references)
			//IL_046b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0473: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_019b: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0256: Unknown result type (might be due to invalid IL or missing references)
			//IL_025b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0263: Unknown result type (might be due to invalid IL or missing references)
			//IL_030b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0310: Unknown result type (might be due to invalid IL or missing references)
			//IL_0318: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_03aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0161: Unknown result type (might be due to invalid IL or missing references)
			//IL_0166: Unknown result type (might be due to invalid IL or missing references)
			//IL_017b: Unknown result type (might be due to invalid IL or missing references)
			//IL_017d: Unknown result type (might be due to invalid IL or missing references)
			//IL_021c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0221: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0236: Unknown result type (might be due to invalid IL or missing references)
			//IL_0238: Unknown result type (might be due to invalid IL or missing references)
			//IL_036b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0370: Unknown result type (might be due to invalid IL or missing references)
			//IL_02eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_0385: Unknown result type (might be due to invalid IL or missing references)
			//IL_0387: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00c1;
				}
				if ((uint)(num - 1) <= 4u)
				{
					goto IL_00cf;
				}
				if (defender != null && _003C_003E4__this.CanManageDefenders)
				{
					if (!defender.IsMainDefender)
					{
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Not Main", "This player is not a main defender.").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CRemoveFromMainDefenders_003Ed__40 _003CRemoveFromMainDefenders_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRemoveFromMainDefenders_003Ed__40>(ref awaiter, ref _003CRemoveFromMainDefenders_003Ed__);
							return;
						}
						goto IL_00c1;
					}
					goto IL_00cf;
				}
				goto end_IL_0007;
				IL_00cf:
				try
				{
					TaskAwaiter awaiter2;
					if ((uint)(num - 1) > 3u)
					{
						if (num == 5)
						{
							awaiter2 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0482;
						}
						_003C_003Es__2 = 0;
					}
					try
					{
						TaskAwaiter<bool> awaiter6;
						TaskAwaiter<Result<bool>> awaiter5;
						TaskAwaiter awaiter4;
						TaskAwaiter awaiter3;
						switch (num)
						{
						default:
							_003C_003E4__this.IsLoading = true;
							awaiter6 = _003C_003E4__this._navigationService.ShowConfirmationAsync("Remove Main Defender", "Remove " + defender.PlayerName + " from main defenders? They will still be a regular defender.").GetAwaiter();
							if (!awaiter6.IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__2 = awaiter6;
								_003CRemoveFromMainDefenders_003Ed__40 _003CRemoveFromMainDefenders_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CRemoveFromMainDefenders_003Ed__40>(ref awaiter6, ref _003CRemoveFromMainDefenders_003Ed__);
								return;
							}
							goto IL_01b7;
						case 1:
							awaiter6 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<bool>);
							num = (_003C_003E1__state = -1);
							goto IL_01b7;
						case 2:
							awaiter5 = _003C_003Eu__3;
							_003C_003Eu__3 = default(TaskAwaiter<Result<bool>>);
							num = (_003C_003E1__state = -1);
							goto IL_0272;
						case 3:
							awaiter4 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0327;
						case 4:
							{
								awaiter3 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_03c1;
							}
							IL_0272:
							_003C_003Es__7 = awaiter5.GetResult();
							_003Cresult_003E5__5 = _003C_003Es__7;
							_003C_003Es__7 = null;
							if (_003Cresult_003E5__5.Success)
							{
								awaiter4 = _003C_003E4__this._navigationService.ShowAlertAsync("Removed from Main", defender.PlayerName + " is no longer a main defender.").GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
								{
									num = (_003C_003E1__state = 3);
									_003C_003Eu__1 = awaiter4;
									_003CRemoveFromMainDefenders_003Ed__40 _003CRemoveFromMainDefenders_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRemoveFromMainDefenders_003Ed__40>(ref awaiter4, ref _003CRemoveFromMainDefenders_003Ed__);
									return;
								}
								goto IL_0327;
							}
							awaiter3 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", _003Cresult_003E5__5.ErrorMessage ?? "Failed to remove main defender.").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 4);
								_003C_003Eu__1 = awaiter3;
								_003CRemoveFromMainDefenders_003Ed__40 _003CRemoveFromMainDefenders_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRemoveFromMainDefenders_003Ed__40>(ref awaiter3, ref _003CRemoveFromMainDefenders_003Ed__);
								return;
							}
							goto IL_03c1;
							IL_01b7:
							_003C_003Es__6 = awaiter6.GetResult();
							_003Cconfirmed_003E5__3 = _003C_003Es__6;
							if (_003Cconfirmed_003E5__3)
							{
								_003Crequest_003E5__4 = new ManageDefendersRequest(_003C_003E4__this.GuildId, defender.PlayerId, DefenderAction.RemoveFromMain);
								awaiter5 = _003C_003E4__this._manageDefendersUseCase.ExecuteAsync(_003Crequest_003E5__4).GetAwaiter();
								if (!awaiter5.IsCompleted)
								{
									num = (_003C_003E1__state = 2);
									_003C_003Eu__3 = awaiter5;
									_003CRemoveFromMainDefenders_003Ed__40 _003CRemoveFromMainDefenders_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<bool>>, _003CRemoveFromMainDefenders_003Ed__40>(ref awaiter5, ref _003CRemoveFromMainDefenders_003Ed__);
									return;
								}
								goto IL_0272;
							}
							goto end_IL_00ec;
							IL_0327:
							((TaskAwaiter)(ref awaiter4)).GetResult();
							_003C_003E4__this.CloseDetails();
							break;
							IL_03c1:
							((TaskAwaiter)(ref awaiter3)).GetResult();
							break;
						}
						_003Crequest_003E5__4 = null;
						_003Cresult_003E5__5 = null;
						goto IL_03ee;
						end_IL_00ec:;
					}
					catch (global::System.Exception ex)
					{
						_003C_003Es__1 = ex;
						_003C_003Es__2 = 1;
						goto IL_03ee;
					}
					goto end_IL_00cf;
					IL_03ee:
					int num2 = _003C_003Es__2;
					if (num2 != 1)
					{
						goto IL_04c6;
					}
					_003Cex_003E5__8 = (global::System.Exception)_003C_003Es__1;
					awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "An error occurred while removing the main defender.").GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 5);
						_003C_003Eu__1 = awaiter2;
						_003CRemoveFromMainDefenders_003Ed__40 _003CRemoveFromMainDefenders_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRemoveFromMainDefenders_003Ed__40>(ref awaiter2, ref _003CRemoveFromMainDefenders_003Ed__);
						return;
					}
					goto IL_0482;
					IL_0482:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					Console.WriteLine($"RemoveFromMainDefenders error: {_003Cex_003E5__8}");
					_003Cex_003E5__8 = null;
					goto IL_04c6;
					IL_04c6:
					_003C_003Es__1 = null;
					end_IL_00cf:;
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this.IsLoading = false;
					}
				}
				goto end_IL_0007;
				IL_00c1:
				((TaskAwaiter)(ref awaiter)).GetResult();
				end_IL_0007:;
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

	[CompilerGenerated]
	private sealed class _003CSetAsMainDefender_003Ed__39 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public DefenderReadModel defender;

		public GuildDefenderManagementViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private bool _003Cconfirmed_003E5__3;

		private ManageDefendersRequest _003Crequest_003E5__4;

		private Result<bool> _003Cresult_003E5__5;

		private bool _003C_003Es__6;

		private Result<bool> _003C_003Es__7;

		private global::System.Exception _003Cex_003E5__8;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<bool> _003C_003Eu__2;

		private TaskAwaiter<Result<bool>> _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_0520: Unknown result type (might be due to invalid IL or missing references)
			//IL_0525: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0199: Unknown result type (might be due to invalid IL or missing references)
			//IL_019e: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_053a: Unknown result type (might be due to invalid IL or missing references)
			//IL_053c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_055a: Unknown result type (might be due to invalid IL or missing references)
			//IL_055f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0567: Unknown result type (might be due to invalid IL or missing references)
			//IL_015f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0164: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_028f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0294: Unknown result type (might be due to invalid IL or missing references)
			//IL_029c: Unknown result type (might be due to invalid IL or missing references)
			//IL_034a: Unknown result type (might be due to invalid IL or missing references)
			//IL_034f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0357: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0404: Unknown result type (might be due to invalid IL or missing references)
			//IL_040c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0499: Unknown result type (might be due to invalid IL or missing references)
			//IL_049e: Unknown result type (might be due to invalid IL or missing references)
			//IL_04a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0255: Unknown result type (might be due to invalid IL or missing references)
			//IL_025a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0179: Unknown result type (might be due to invalid IL or missing references)
			//IL_017b: Unknown result type (might be due to invalid IL or missing references)
			//IL_026f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0271: Unknown result type (might be due to invalid IL or missing references)
			//IL_0310: Unknown result type (might be due to invalid IL or missing references)
			//IL_0315: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_032a: Unknown result type (might be due to invalid IL or missing references)
			//IL_032c: Unknown result type (might be due to invalid IL or missing references)
			//IL_045f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0464: Unknown result type (might be due to invalid IL or missing references)
			//IL_03df: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0479: Unknown result type (might be due to invalid IL or missing references)
			//IL_047b: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter2;
				TaskAwaiter awaiter;
				switch (num)
				{
				default:
					if (defender != null && _003C_003E4__this.CanManageDefenders)
					{
						if (defender.IsMainDefender)
						{
							awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Already Main", "This player is already a main defender.").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter2;
								_003CSetAsMainDefender_003Ed__39 _003CSetAsMainDefender_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSetAsMainDefender_003Ed__39>(ref awaiter2, ref _003CSetAsMainDefender_003Ed__);
								return;
							}
							goto IL_00da;
						}
						if (_003C_003E4__this.MainDefenderCount < _003C_003E4__this.MaxMainDefenders)
						{
							break;
						}
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Maximum Reached", $"You can only have {_003C_003E4__this.MaxMainDefenders} main defenders. Remove one first.").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter;
							_003CSetAsMainDefender_003Ed__39 _003CSetAsMainDefender_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSetAsMainDefender_003Ed__39>(ref awaiter, ref _003CSetAsMainDefender_003Ed__);
							return;
						}
						goto IL_01b5;
					}
					goto end_IL_0007;
				case 0:
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00da;
				case 1:
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_01b5;
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
					break;
					IL_00da:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					goto end_IL_0007;
					IL_01b5:
					((TaskAwaiter)(ref awaiter)).GetResult();
					goto end_IL_0007;
				}
				try
				{
					TaskAwaiter awaiter3;
					if ((uint)(num - 2) > 3u)
					{
						if (num == 6)
						{
							awaiter3 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0576;
						}
						_003C_003Es__2 = 0;
					}
					try
					{
						TaskAwaiter<bool> awaiter7;
						TaskAwaiter<Result<bool>> awaiter6;
						TaskAwaiter awaiter5;
						TaskAwaiter awaiter4;
						switch (num)
						{
						default:
							_003C_003E4__this.IsLoading = true;
							awaiter7 = _003C_003E4__this._navigationService.ShowConfirmationAsync("Set Main Defender", "Set " + defender.PlayerName + " as a main defender? Main defenders have priority in defense battles.").GetAwaiter();
							if (!awaiter7.IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__2 = awaiter7;
								_003CSetAsMainDefender_003Ed__39 _003CSetAsMainDefender_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CSetAsMainDefender_003Ed__39>(ref awaiter7, ref _003CSetAsMainDefender_003Ed__);
								return;
							}
							goto IL_02ab;
						case 2:
							awaiter7 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<bool>);
							num = (_003C_003E1__state = -1);
							goto IL_02ab;
						case 3:
							awaiter6 = _003C_003Eu__3;
							_003C_003Eu__3 = default(TaskAwaiter<Result<bool>>);
							num = (_003C_003E1__state = -1);
							goto IL_0366;
						case 4:
							awaiter5 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_041b;
						case 5:
							{
								awaiter4 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_04b5;
							}
							IL_0366:
							_003C_003Es__7 = awaiter6.GetResult();
							_003Cresult_003E5__5 = _003C_003Es__7;
							_003C_003Es__7 = null;
							if (_003Cresult_003E5__5.Success)
							{
								awaiter5 = _003C_003E4__this._navigationService.ShowAlertAsync("Main Defender Set", defender.PlayerName + " is now a main defender!").GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter5)).IsCompleted)
								{
									num = (_003C_003E1__state = 4);
									_003C_003Eu__1 = awaiter5;
									_003CSetAsMainDefender_003Ed__39 _003CSetAsMainDefender_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSetAsMainDefender_003Ed__39>(ref awaiter5, ref _003CSetAsMainDefender_003Ed__);
									return;
								}
								goto IL_041b;
							}
							awaiter4 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", _003Cresult_003E5__5.ErrorMessage ?? "Failed to set main defender.").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
							{
								num = (_003C_003E1__state = 5);
								_003C_003Eu__1 = awaiter4;
								_003CSetAsMainDefender_003Ed__39 _003CSetAsMainDefender_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSetAsMainDefender_003Ed__39>(ref awaiter4, ref _003CSetAsMainDefender_003Ed__);
								return;
							}
							goto IL_04b5;
							IL_02ab:
							_003C_003Es__6 = awaiter7.GetResult();
							_003Cconfirmed_003E5__3 = _003C_003Es__6;
							if (_003Cconfirmed_003E5__3)
							{
								_003Crequest_003E5__4 = new ManageDefendersRequest(_003C_003E4__this.GuildId, defender.PlayerId, DefenderAction.SetAsMain);
								awaiter6 = _003C_003E4__this._manageDefendersUseCase.ExecuteAsync(_003Crequest_003E5__4).GetAwaiter();
								if (!awaiter6.IsCompleted)
								{
									num = (_003C_003E1__state = 3);
									_003C_003Eu__3 = awaiter6;
									_003CSetAsMainDefender_003Ed__39 _003CSetAsMainDefender_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<bool>>, _003CSetAsMainDefender_003Ed__39>(ref awaiter6, ref _003CSetAsMainDefender_003Ed__);
									return;
								}
								goto IL_0366;
							}
							goto end_IL_01e0;
							IL_041b:
							((TaskAwaiter)(ref awaiter5)).GetResult();
							_003C_003E4__this.CloseDetails();
							break;
							IL_04b5:
							((TaskAwaiter)(ref awaiter4)).GetResult();
							break;
						}
						_003Crequest_003E5__4 = null;
						_003Cresult_003E5__5 = null;
						goto IL_04e2;
						end_IL_01e0:;
					}
					catch (global::System.Exception ex)
					{
						_003C_003Es__1 = ex;
						_003C_003Es__2 = 1;
						goto IL_04e2;
					}
					goto end_IL_01c3;
					IL_04e2:
					int num2 = _003C_003Es__2;
					if (num2 != 1)
					{
						goto IL_05ba;
					}
					_003Cex_003E5__8 = (global::System.Exception)_003C_003Es__1;
					awaiter3 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "An error occurred while setting the main defender.").GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
					{
						num = (_003C_003E1__state = 6);
						_003C_003Eu__1 = awaiter3;
						_003CSetAsMainDefender_003Ed__39 _003CSetAsMainDefender_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSetAsMainDefender_003Ed__39>(ref awaiter3, ref _003CSetAsMainDefender_003Ed__);
						return;
					}
					goto IL_0576;
					IL_0576:
					((TaskAwaiter)(ref awaiter3)).GetResult();
					Console.WriteLine($"SetAsMainDefender error: {_003Cex_003E5__8}");
					_003Cex_003E5__8 = null;
					goto IL_05ba;
					IL_05ba:
					_003C_003Es__1 = null;
					end_IL_01c3:;
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this.IsLoading = false;
					}
				}
				end_IL_0007:;
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

	private readonly IGuildRepository _guildRepository;

	private readonly IGuildStateService _guildStateService;

	private readonly IPlayerStateService _playerStateService;

	private readonly INavigationService _navigationService;

	private readonly ManageDefendersUseCase _manageDefendersUseCase;

	private bool _disposed;

	private bool _isSubscribed;

	private List<DefenderReadModel> _allDefenders = new List<DefenderReadModel>();

	[ObservableProperty]
	private string? _guildId;

	[ObservableProperty]
	private ObservableCollection<DefenderReadModel> _defenders = new ObservableCollection<DefenderReadModel>();

	[ObservableProperty]
	private ObservableCollection<DefenderReadModel> _mainDefenders = new ObservableCollection<DefenderReadModel>();

	[ObservableProperty]
	private string _searchText = string.Empty;

	[ObservableProperty]
	private string _sortBy = "expiry";

	[ObservableProperty]
	private DefenderReadModel? _selectedDefender;

	[ObservableProperty]
	private bool _isLoading;

	[ObservableProperty]
	private string _errorMessage = string.Empty;

	[ObservableProperty]
	[NotifyPropertyChangedFor("DefenderCountText")]
	private int _defenderCount;

	[ObservableProperty]
	[NotifyPropertyChangedFor("MainDefenderCountText")]
	private int _mainDefenderCount;

	[ObservableProperty]
	private int _maxMainDefenders = 5;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<string>? changeSortByCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? clearSearchCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<DefenderReadModel>? selectDefenderCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? closeDetailsCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? goBackCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<DefenderReadModel>? setAsMainDefenderCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<DefenderReadModel>? removeFromMainDefendersCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<DefenderReadModel>? removeDefenderCommand;

	public string DefenderCountText => $"{DefenderCount} Defenders";

	public string MainDefenderCountText => $"{MainDefenderCount} / {MaxMainDefenders} Main Defenders";

	public bool CanManageDefenders
	{
		get
		{
			GuildRole? guildRole = _playerStateService.GetCurrentPlayer()?.GuildRole;
			return guildRole.GetValueOrDefault() == GuildRole.Guildmaster || guildRole.GetValueOrDefault() == GuildRole.Vice_Guildmaster;
		}
	}

	public bool HasSelectedDefender => SelectedDefender != null;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string? GuildId
	{
		get
		{
			return _guildId;
		}
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_guildId, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.GuildId);
				_guildId = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.GuildId);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ObservableCollection<DefenderReadModel> Defenders
	{
		get
		{
			return _defenders;
		}
		[MemberNotNull("_defenders")]
		set
		{
			if (!EqualityComparer<ObservableCollection<DefenderReadModel>>.Default.Equals(_defenders, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Defenders);
				_defenders = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Defenders);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ObservableCollection<DefenderReadModel> MainDefenders
	{
		get
		{
			return _mainDefenders;
		}
		[MemberNotNull("_mainDefenders")]
		set
		{
			if (!EqualityComparer<ObservableCollection<DefenderReadModel>>.Default.Equals(_mainDefenders, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.MainDefenders);
				_mainDefenders = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.MainDefenders);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string SearchText
	{
		get
		{
			return _searchText;
		}
		[MemberNotNull("_searchText")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_searchText, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.SearchText);
				_searchText = value;
				OnSearchTextChanged(value);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SearchText);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string SortBy
	{
		get
		{
			return _sortBy;
		}
		[MemberNotNull("_sortBy")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_sortBy, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.SortBy);
				_sortBy = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SortBy);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public DefenderReadModel? SelectedDefender
	{
		get
		{
			return _selectedDefender;
		}
		set
		{
			if (!EqualityComparer<DefenderReadModel>.Default.Equals(_selectedDefender, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.SelectedDefender);
				_selectedDefender = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SelectedDefender);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsLoading
	{
		get
		{
			return _isLoading;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isLoading, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsLoading);
				_isLoading = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsLoading);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string ErrorMessage
	{
		get
		{
			return _errorMessage;
		}
		[MemberNotNull("_errorMessage")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_errorMessage, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ErrorMessage);
				_errorMessage = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ErrorMessage);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int DefenderCount
	{
		get
		{
			return _defenderCount;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_defenderCount, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.DefenderCount);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.DefenderCountText);
				_defenderCount = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.DefenderCount);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.DefenderCountText);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int MainDefenderCount
	{
		get
		{
			return _mainDefenderCount;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_mainDefenderCount, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.MainDefenderCount);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.MainDefenderCountText);
				_mainDefenderCount = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.MainDefenderCount);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.MainDefenderCountText);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int MaxMainDefenders
	{
		get
		{
			return _maxMainDefenders;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_maxMainDefenders, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.MaxMainDefenders);
				_maxMainDefenders = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.MaxMainDefenders);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<string> ChangeSortByCommand => (IRelayCommand<string>)(object)(changeSortByCommand ?? (changeSortByCommand = new RelayCommand<string>((Action<string>)ChangeSortBy)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand ClearSearchCommand
	{
		get
		{
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Expected O, but got Unknown
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			RelayCommand obj = clearSearchCommand;
			if (obj == null)
			{
				RelayCommand val = new RelayCommand(new Action(ClearSearch));
				RelayCommand val2 = val;
				clearSearchCommand = val;
				obj = val2;
			}
			return (IRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<DefenderReadModel> SelectDefenderCommand => (IRelayCommand<DefenderReadModel>)(object)(selectDefenderCommand ?? (selectDefenderCommand = new RelayCommand<DefenderReadModel>((Action<DefenderReadModel>)SelectDefender)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand CloseDetailsCommand
	{
		get
		{
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Expected O, but got Unknown
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			RelayCommand obj = closeDetailsCommand;
			if (obj == null)
			{
				RelayCommand val = new RelayCommand(new Action(CloseDetails));
				RelayCommand val2 = val;
				closeDetailsCommand = val;
				obj = val2;
			}
			return (IRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand GoBackCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = goBackCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)GoBack);
				AsyncRelayCommand val2 = val;
				goBackCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<DefenderReadModel> SetAsMainDefenderCommand => (IAsyncRelayCommand<DefenderReadModel>)(object)(setAsMainDefenderCommand ?? (setAsMainDefenderCommand = new AsyncRelayCommand<DefenderReadModel>((Func<DefenderReadModel, global::System.Threading.Tasks.Task>)SetAsMainDefender)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<DefenderReadModel> RemoveFromMainDefendersCommand => (IAsyncRelayCommand<DefenderReadModel>)(object)(removeFromMainDefendersCommand ?? (removeFromMainDefendersCommand = new AsyncRelayCommand<DefenderReadModel>((Func<DefenderReadModel, global::System.Threading.Tasks.Task>)RemoveFromMainDefenders)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<DefenderReadModel> RemoveDefenderCommand => (IAsyncRelayCommand<DefenderReadModel>)(object)(removeDefenderCommand ?? (removeDefenderCommand = new AsyncRelayCommand<DefenderReadModel>((Func<DefenderReadModel, global::System.Threading.Tasks.Task>)RemoveDefender)));

	public GuildDefenderManagementViewModel(IGuildRepository guildRepository, IGuildStateService guildStateService, IPlayerStateService playerStateService, INavigationService navigationService, ManageDefendersUseCase manageDefendersUseCase)
	{
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		_guildRepository = guildRepository ?? throw new ArgumentNullException("guildRepository");
		_guildStateService = guildStateService ?? throw new ArgumentNullException("guildStateService");
		_playerStateService = playerStateService ?? throw new ArgumentNullException("playerStateService");
		_navigationService = navigationService ?? throw new ArgumentNullException("navigationService");
		_manageDefendersUseCase = manageDefendersUseCase ?? throw new ArgumentNullException("manageDefendersUseCase");
		SubscribeToStateChanges();
	}

	private void SubscribeToStateChanges()
	{
		if (!_isSubscribed)
		{
			_guildStateService.GuildStateChanged += OnGuildStateChanged;
			_isSubscribed = true;
		}
	}

	[AsyncStateMachine(typeof(_003COnGuildStateChanged_003Ed__29))]
	[DebuggerStepThrough]
	private void OnGuildStateChanged(object? sender, GuildStateChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003COnGuildStateChanged_003Ed__29 _003COnGuildStateChanged_003Ed__ = new _003COnGuildStateChanged_003Ed__29();
		_003COnGuildStateChanged_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003COnGuildStateChanged_003Ed__._003C_003E4__this = this;
		_003COnGuildStateChanged_003Ed__.sender = sender;
		_003COnGuildStateChanged_003Ed__.e = e;
		_003COnGuildStateChanged_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003COnGuildStateChanged_003Ed__._003C_003Et__builder)).Start<_003COnGuildStateChanged_003Ed__29>(ref _003COnGuildStateChanged_003Ed__);
	}

	[AsyncStateMachine(typeof(_003CLoadDataAsync_003Ed__30))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task LoadDataAsync(object? parameter)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadDataAsync_003Ed__30 _003CLoadDataAsync_003Ed__ = new _003CLoadDataAsync_003Ed__30();
		_003CLoadDataAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadDataAsync_003Ed__._003C_003E4__this = this;
		_003CLoadDataAsync_003Ed__.parameter = parameter;
		_003CLoadDataAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadDataAsync_003Ed__30>(ref _003CLoadDataAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CLoadDefenders_003Ed__31))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task LoadDefenders()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadDefenders_003Ed__31 _003CLoadDefenders_003Ed__ = new _003CLoadDefenders_003Ed__31();
		_003CLoadDefenders_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadDefenders_003Ed__._003C_003E4__this = this;
		_003CLoadDefenders_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadDefenders_003Ed__._003C_003Et__builder)).Start<_003CLoadDefenders_003Ed__31>(ref _003CLoadDefenders_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadDefenders_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CLoadDefendersFromRepository_003Ed__32))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task LoadDefendersFromRepository()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadDefendersFromRepository_003Ed__32 _003CLoadDefendersFromRepository_003Ed__ = new _003CLoadDefendersFromRepository_003Ed__32();
		_003CLoadDefendersFromRepository_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadDefendersFromRepository_003Ed__._003C_003E4__this = this;
		_003CLoadDefendersFromRepository_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadDefendersFromRepository_003Ed__._003C_003Et__builder)).Start<_003CLoadDefendersFromRepository_003Ed__32>(ref _003CLoadDefendersFromRepository_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadDefendersFromRepository_003Ed__._003C_003Et__builder)).Task;
	}

	[RelayCommand]
	private void ChangeSortBy(string sortType)
	{
		SortBy = sortType;
		ApplyFilterAndSort();
	}

	private void ApplyFilterAndSort()
	{
		global::System.Collections.Generic.IEnumerable<DefenderReadModel> enumerable = Enumerable.AsEnumerable<DefenderReadModel>((global::System.Collections.Generic.IEnumerable<DefenderReadModel>)_allDefenders);
		if (!string.IsNullOrWhiteSpace(SearchText))
		{
			enumerable = Enumerable.Where<DefenderReadModel>(enumerable, (Func<DefenderReadModel, bool>)([CompilerGenerated] (DefenderReadModel d) => d.PlayerName.Contains(SearchText, (StringComparison)5)));
		}
		string sortBy = SortBy;
		if (1 == 0)
		{
		}
		IOrderedEnumerable<DefenderReadModel> val = ((sortBy == "expiry") ? Enumerable.OrderBy<DefenderReadModel, DateTimeOffset>(enumerable, (Func<DefenderReadModel, DateTimeOffset>)((DefenderReadModel d) => (DateTimeOffset)(((_003F?)d.DefenseExpiresAt) ?? DateTimeOffset.MaxValue))) : ((sortBy == "level") ? Enumerable.OrderByDescending<DefenderReadModel, int>(enumerable, (Func<DefenderReadModel, int>)((DefenderReadModel d) => d.Level)) : ((!(sortBy == "name")) ? Enumerable.OrderBy<DefenderReadModel, DateTimeOffset>(enumerable, (Func<DefenderReadModel, DateTimeOffset>)((DefenderReadModel d) => (DateTimeOffset)(((_003F?)d.DefenseExpiresAt) ?? DateTimeOffset.MaxValue))) : Enumerable.OrderBy<DefenderReadModel, string>(enumerable, (Func<DefenderReadModel, string>)((DefenderReadModel d) => d.PlayerName)))));
		if (1 == 0)
		{
		}
		enumerable = (global::System.Collections.Generic.IEnumerable<DefenderReadModel>)val;
		Defenders = new ObservableCollection<DefenderReadModel>(enumerable);
	}

	[RelayCommand]
	private void ClearSearch()
	{
		SearchText = string.Empty;
	}

	[RelayCommand]
	private void SelectDefender(DefenderReadModel defender)
	{
		SelectedDefender = defender;
		((ObservableObject)this).OnPropertyChanged("HasSelectedDefender");
	}

	[RelayCommand]
	private void CloseDetails()
	{
		SelectedDefender = null;
		((ObservableObject)this).OnPropertyChanged("HasSelectedDefender");
	}

	[AsyncStateMachine(typeof(_003CGoBack_003Ed__38))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task GoBack()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CGoBack_003Ed__38 _003CGoBack_003Ed__ = new _003CGoBack_003Ed__38();
		_003CGoBack_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CGoBack_003Ed__._003C_003E4__this = this;
		_003CGoBack_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CGoBack_003Ed__._003C_003Et__builder)).Start<_003CGoBack_003Ed__38>(ref _003CGoBack_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CGoBack_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CSetAsMainDefender_003Ed__39))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task SetAsMainDefender(DefenderReadModel defender)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CSetAsMainDefender_003Ed__39 _003CSetAsMainDefender_003Ed__ = new _003CSetAsMainDefender_003Ed__39();
		_003CSetAsMainDefender_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CSetAsMainDefender_003Ed__._003C_003E4__this = this;
		_003CSetAsMainDefender_003Ed__.defender = defender;
		_003CSetAsMainDefender_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CSetAsMainDefender_003Ed__._003C_003Et__builder)).Start<_003CSetAsMainDefender_003Ed__39>(ref _003CSetAsMainDefender_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CSetAsMainDefender_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CRemoveFromMainDefenders_003Ed__40))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task RemoveFromMainDefenders(DefenderReadModel defender)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CRemoveFromMainDefenders_003Ed__40 _003CRemoveFromMainDefenders_003Ed__ = new _003CRemoveFromMainDefenders_003Ed__40();
		_003CRemoveFromMainDefenders_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CRemoveFromMainDefenders_003Ed__._003C_003E4__this = this;
		_003CRemoveFromMainDefenders_003Ed__.defender = defender;
		_003CRemoveFromMainDefenders_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CRemoveFromMainDefenders_003Ed__._003C_003Et__builder)).Start<_003CRemoveFromMainDefenders_003Ed__40>(ref _003CRemoveFromMainDefenders_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CRemoveFromMainDefenders_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CRemoveDefender_003Ed__41))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task RemoveDefender(DefenderReadModel defender)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CRemoveDefender_003Ed__41 _003CRemoveDefender_003Ed__ = new _003CRemoveDefender_003Ed__41();
		_003CRemoveDefender_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CRemoveDefender_003Ed__._003C_003E4__this = this;
		_003CRemoveDefender_003Ed__.defender = defender;
		_003CRemoveDefender_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CRemoveDefender_003Ed__._003C_003Et__builder)).Start<_003CRemoveDefender_003Ed__41>(ref _003CRemoveDefender_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CRemoveDefender_003Ed__._003C_003Et__builder)).Task;
	}

	public void Dispose()
	{
		if (!_disposed)
		{
			if (_isSubscribed)
			{
				_guildStateService.GuildStateChanged -= OnGuildStateChanged;
				_isSubscribed = false;
			}
			_disposed = true;
			GC.SuppressFinalize((object)this);
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnSearchTextChanged(string value)
	{
		ApplyFilterAndSort();
	}
}
