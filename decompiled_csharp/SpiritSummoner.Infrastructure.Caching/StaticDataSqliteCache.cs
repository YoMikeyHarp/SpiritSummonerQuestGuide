using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.Maui.Storage;
using SpiritSummoner.Domain.Entities.Items;
using SpiritSummoner.Domain.Entities.Quests;
using SpiritSummoner.Domain.ValueObjects.Quests;

namespace SpiritSummoner.Infrastructure.Caching;

internal class StaticDataSqliteCache : global::System.IDisposable
{
	internal sealed record CachedQuestTask(string? Id, string? Name, string? Description, bool Battle, int Energy, string? Action, int Order, string? OrderRequirement, int TotalSteps, bool IsRepeatable, int LevelRequirement, CachedRewards? Rewards, List<QuestOpponent> QuestOpponents, List<CachedQuestParagraph> Paragraphs, string? OpponentImage = null, string? OpponentBackgroundImage = null, string? OpponentName = null, string? OpponentGuild = null)
	{
		[CompilerGenerated]
		private global::System.Type EqualityContract
		{
			[CompilerGenerated]
			get
			{
				return typeof(CachedQuestTask);
			}
		}

		[CompilerGenerated]
		public override string ToString()
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Expected O, but got Unknown
			StringBuilder val = new StringBuilder();
			val.Append("CachedQuestTask");
			val.Append(" { ");
			if (PrintMembers(val))
			{
				val.Append(' ');
			}
			val.Append('}');
			return ((object)val).ToString();
		}

		[CompilerGenerated]
		private bool PrintMembers(StringBuilder builder)
		{
			RuntimeHelpers.EnsureSufficientExecutionStack();
			builder.Append("Id = ");
			builder.Append((object)Id);
			builder.Append(", Name = ");
			builder.Append((object)Name);
			builder.Append(", Description = ");
			builder.Append((object)Description);
			builder.Append(", Battle = ");
			builder.Append(((object)Battle).ToString());
			builder.Append(", Energy = ");
			builder.Append(((object)Energy).ToString());
			builder.Append(", Action = ");
			builder.Append((object)Action);
			builder.Append(", Order = ");
			builder.Append(((object)Order).ToString());
			builder.Append(", OrderRequirement = ");
			builder.Append((object)OrderRequirement);
			builder.Append(", TotalSteps = ");
			builder.Append(((object)TotalSteps).ToString());
			builder.Append(", IsRepeatable = ");
			builder.Append(((object)IsRepeatable).ToString());
			builder.Append(", LevelRequirement = ");
			builder.Append(((object)LevelRequirement).ToString());
			builder.Append(", Rewards = ");
			builder.Append((object)Rewards);
			builder.Append(", QuestOpponents = ");
			builder.Append((object)QuestOpponents);
			builder.Append(", Paragraphs = ");
			builder.Append((object)Paragraphs);
			builder.Append(", OpponentImage = ");
			builder.Append((object)OpponentImage);
			builder.Append(", OpponentBackgroundImage = ");
			builder.Append((object)OpponentBackgroundImage);
			builder.Append(", OpponentName = ");
			builder.Append((object)OpponentName);
			builder.Append(", OpponentGuild = ");
			builder.Append((object)OpponentGuild);
			return true;
		}

		[CompilerGenerated]
		public bool Equals(CachedQuestTask? other)
		{
			return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(Id, other.Id) && EqualityComparer<string>.Default.Equals(Name, other.Name) && EqualityComparer<string>.Default.Equals(Description, other.Description) && EqualityComparer<bool>.Default.Equals(Battle, other.Battle) && EqualityComparer<int>.Default.Equals(Energy, other.Energy) && EqualityComparer<string>.Default.Equals(Action, other.Action) && EqualityComparer<int>.Default.Equals(Order, other.Order) && EqualityComparer<string>.Default.Equals(OrderRequirement, other.OrderRequirement) && EqualityComparer<int>.Default.Equals(TotalSteps, other.TotalSteps) && EqualityComparer<bool>.Default.Equals(IsRepeatable, other.IsRepeatable) && EqualityComparer<int>.Default.Equals(LevelRequirement, other.LevelRequirement) && EqualityComparer<CachedRewards>.Default.Equals(Rewards, other.Rewards) && EqualityComparer<List<QuestOpponent>>.Default.Equals(QuestOpponents, other.QuestOpponents) && EqualityComparer<List<CachedQuestParagraph>>.Default.Equals(Paragraphs, other.Paragraphs) && EqualityComparer<string>.Default.Equals(OpponentImage, other.OpponentImage) && EqualityComparer<string>.Default.Equals(OpponentBackgroundImage, other.OpponentBackgroundImage) && EqualityComparer<string>.Default.Equals(OpponentName, other.OpponentName) && EqualityComparer<string>.Default.Equals(OpponentGuild, other.OpponentGuild));
		}
	}

	internal sealed record CachedRewards(int Experience, int Gold, int Reputation, List<Item> Items)
	{
		[CompilerGenerated]
		private global::System.Type EqualityContract
		{
			[CompilerGenerated]
			get
			{
				return typeof(CachedRewards);
			}
		}

		[CompilerGenerated]
		public override string ToString()
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Expected O, but got Unknown
			StringBuilder val = new StringBuilder();
			val.Append("CachedRewards");
			val.Append(" { ");
			if (PrintMembers(val))
			{
				val.Append(' ');
			}
			val.Append('}');
			return ((object)val).ToString();
		}

		[CompilerGenerated]
		private bool PrintMembers(StringBuilder builder)
		{
			RuntimeHelpers.EnsureSufficientExecutionStack();
			builder.Append("Experience = ");
			builder.Append(((object)Experience).ToString());
			builder.Append(", Gold = ");
			builder.Append(((object)Gold).ToString());
			builder.Append(", Reputation = ");
			builder.Append(((object)Reputation).ToString());
			builder.Append(", Items = ");
			builder.Append((object)Items);
			return true;
		}

		[CompilerGenerated]
		public bool Equals(CachedRewards? other)
		{
			return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<int>.Default.Equals(Experience, other.Experience) && EqualityComparer<int>.Default.Equals(Gold, other.Gold) && EqualityComparer<int>.Default.Equals(Reputation, other.Reputation) && EqualityComparer<List<Item>>.Default.Equals(Items, other.Items));
		}
	}

	internal sealed record CachedQuestParagraph(string? Image, string? Text, bool View)
	{
		[CompilerGenerated]
		private global::System.Type EqualityContract
		{
			[CompilerGenerated]
			get
			{
				return typeof(CachedQuestParagraph);
			}
		}

		[CompilerGenerated]
		public override string ToString()
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Expected O, but got Unknown
			StringBuilder val = new StringBuilder();
			val.Append("CachedQuestParagraph");
			val.Append(" { ");
			if (PrintMembers(val))
			{
				val.Append(' ');
			}
			val.Append('}');
			return ((object)val).ToString();
		}

		[CompilerGenerated]
		private bool PrintMembers(StringBuilder builder)
		{
			RuntimeHelpers.EnsureSufficientExecutionStack();
			builder.Append("Image = ");
			builder.Append((object)Image);
			builder.Append(", Text = ");
			builder.Append((object)Text);
			builder.Append(", View = ");
			builder.Append(((object)View).ToString());
			return true;
		}

		[CompilerGenerated]
		public bool Equals(CachedQuestParagraph? other)
		{
			return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(Image, other.Image) && EqualityComparer<string>.Default.Equals(Text, other.Text) && EqualityComparer<bool>.Default.Equals(View, other.View));
		}
	}

	[CompilerGenerated]
	private sealed class _003CClearAllAsync_003Ed__9 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public StaticDataSqliteCache _003C_003E4__this;

		private SqliteConnection _003Cconnection_003E5__1;

		private SqliteCommand _003Ccommand_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<int> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Expected O, but got Unknown
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_015a: Unknown result type (might be due to invalid IL or missing references)
			//IL_016f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0171: Unknown result type (might be due to invalid IL or missing references)
			//IL_018e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0193: Unknown result type (might be due to invalid IL or missing references)
			//IL_019b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					if ((uint)(num - 1) <= 1u)
					{
						goto IL_0084;
					}
					awaiter = _003C_003E4__this._dbSemaphore.WaitAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CClearAllAsync_003Ed__9 _003CClearAllAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CClearAllAsync_003Ed__9>(ref awaiter, ref _003CClearAllAsync_003Ed__);
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
				goto IL_0084;
				IL_0084:
				try
				{
					if ((uint)(num - 1) > 1u)
					{
						_003Cconnection_003E5__1 = new SqliteConnection("Data Source=" + _003C_003E4__this._dbPath);
					}
					try
					{
						TaskAwaiter<int> awaiter2;
						TaskAwaiter awaiter3;
						if (num != 1)
						{
							if (num == 2)
							{
								awaiter2 = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter<int>);
								num = (_003C_003E1__state = -1);
								goto IL_01aa;
							}
							awaiter3 = ((DbConnection)_003Cconnection_003E5__1).OpenAsync().GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__1 = awaiter3;
								_003CClearAllAsync_003Ed__9 _003CClearAllAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CClearAllAsync_003Ed__9>(ref awaiter3, ref _003CClearAllAsync_003Ed__);
								return;
							}
						}
						else
						{
							awaiter3 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
						}
						((TaskAwaiter)(ref awaiter3)).GetResult();
						_003Ccommand_003E5__2 = _003Cconnection_003E5__1.CreateCommand();
						((DbCommand)_003Ccommand_003E5__2).CommandText = "DELETE FROM StaticCache";
						awaiter2 = ((DbCommand)_003Ccommand_003E5__2).ExecuteNonQueryAsync().GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__2 = awaiter2;
							_003CClearAllAsync_003Ed__9 _003CClearAllAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<int>, _003CClearAllAsync_003Ed__9>(ref awaiter2, ref _003CClearAllAsync_003Ed__);
							return;
						}
						goto IL_01aa;
						IL_01aa:
						awaiter2.GetResult();
					}
					finally
					{
						if (num < 0 && _003Cconnection_003E5__1 != null)
						{
							((global::System.IDisposable)_003Cconnection_003E5__1).Dispose();
						}
					}
					_003Cconnection_003E5__1 = null;
					_003Ccommand_003E5__2 = null;
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this._dbSemaphore.Release();
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
	private sealed class _003CInitializeAsync_003Ed__4 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public StaticDataSqliteCache _003C_003E4__this;

		private SqliteConnection _003Cconnection_003E5__1;

		private SqliteCommand _003Ccommand_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<int> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Expected O, but got Unknown
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_015a: Unknown result type (might be due to invalid IL or missing references)
			//IL_016f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0171: Unknown result type (might be due to invalid IL or missing references)
			//IL_018e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0193: Unknown result type (might be due to invalid IL or missing references)
			//IL_019b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					if ((uint)(num - 1) <= 1u)
					{
						goto IL_0084;
					}
					awaiter = _003C_003E4__this._dbSemaphore.WaitAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CInitializeAsync_003Ed__4 _003CInitializeAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CInitializeAsync_003Ed__4>(ref awaiter, ref _003CInitializeAsync_003Ed__);
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
				goto IL_0084;
				IL_0084:
				try
				{
					if ((uint)(num - 1) > 1u)
					{
						_003Cconnection_003E5__1 = new SqliteConnection("Data Source=" + _003C_003E4__this._dbPath);
					}
					try
					{
						TaskAwaiter<int> awaiter2;
						TaskAwaiter awaiter3;
						if (num != 1)
						{
							if (num == 2)
							{
								awaiter2 = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter<int>);
								num = (_003C_003E1__state = -1);
								goto IL_01aa;
							}
							awaiter3 = ((DbConnection)_003Cconnection_003E5__1).OpenAsync().GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__1 = awaiter3;
								_003CInitializeAsync_003Ed__4 _003CInitializeAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CInitializeAsync_003Ed__4>(ref awaiter3, ref _003CInitializeAsync_003Ed__);
								return;
							}
						}
						else
						{
							awaiter3 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
						}
						((TaskAwaiter)(ref awaiter3)).GetResult();
						_003Ccommand_003E5__2 = _003Cconnection_003E5__1.CreateCommand();
						((DbCommand)_003Ccommand_003E5__2).CommandText = "\r\n                CREATE TABLE IF NOT EXISTS StaticCache (\r\n                    CollectionKey  TEXT PRIMARY KEY,\r\n                    DataJson       TEXT NOT NULL,\r\n                    SavedAt        TEXT NOT NULL\r\n                )";
						awaiter2 = ((DbCommand)_003Ccommand_003E5__2).ExecuteNonQueryAsync().GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__2 = awaiter2;
							_003CInitializeAsync_003Ed__4 _003CInitializeAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<int>, _003CInitializeAsync_003Ed__4>(ref awaiter2, ref _003CInitializeAsync_003Ed__);
							return;
						}
						goto IL_01aa;
						IL_01aa:
						awaiter2.GetResult();
					}
					finally
					{
						if (num < 0 && _003Cconnection_003E5__1 != null)
						{
							((global::System.IDisposable)_003Cconnection_003E5__1).Dispose();
						}
					}
					_003Cconnection_003E5__1 = null;
					_003Ccommand_003E5__2 = null;
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this._dbSemaphore.Release();
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
	private sealed class _003CReadCollectionAsync_003Ed__5<T> : IAsyncStateMachine where T : notnull
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Dictionary<string, T>> _003C_003Et__builder;

		public string collectionKey;

		public StaticDataSqliteCache _003C_003E4__this;

		private string _003Cjson_003E5__1;

		private string _003C_003Es__2;

		private TaskAwaiter<string?> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Dictionary<string, T> result;
			try
			{
				TaskAwaiter<string> awaiter;
				if (num != 0)
				{
					awaiter = _003C_003E4__this.ReadJsonAsync(collectionKey).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CReadCollectionAsync_003Ed__5<T> _003CReadCollectionAsync_003Ed__ = this;
						global::System.Runtime.CompilerServices.Unsafe.As<AsyncTaskMethodBuilder<Dictionary<string, T>>, AsyncTaskMethodBuilder<Dictionary<string, Dictionary<string, T>>>>(ref _003C_003Et__builder).AwaitUnsafeOnCompleted<TaskAwaiter<string>, _003CReadCollectionAsync_003Ed__5<T>>(ref awaiter, ref _003CReadCollectionAsync_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<string>);
					num = (_003C_003E1__state = -1);
				}
				_003C_003Es__2 = awaiter.GetResult();
				_003Cjson_003E5__1 = _003C_003Es__2;
				_003C_003Es__2 = null;
				result = ((_003Cjson_003E5__1 != null) ? JsonSerializer.Deserialize<Dictionary<string, T>>(_003Cjson_003E5__1, JsonOptions) : null);
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cjson_003E5__1 = null;
				global::System.Runtime.CompilerServices.Unsafe.As<AsyncTaskMethodBuilder<Dictionary<string, T>>, AsyncTaskMethodBuilder<Dictionary<string, Dictionary<string, T>>>>(ref _003C_003Et__builder).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cjson_003E5__1 = null;
			global::System.Runtime.CompilerServices.Unsafe.As<AsyncTaskMethodBuilder<Dictionary<string, T>>, AsyncTaskMethodBuilder<Dictionary<string, Dictionary<string, T>>>>(ref _003C_003Et__builder).SetResult((Dictionary<string, Dictionary<string, T>>)(object)result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CReadJsonAsync_003Ed__14 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

		public string collectionKey;

		public StaticDataSqliteCache _003C_003E4__this;

		private SqliteConnection _003Cconnection_003E5__1;

		private SqliteCommand _003Ccommand_003E5__2;

		private object _003Cresult_003E5__3;

		private object _003C_003Es__4;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<object?> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Expected O, but got Unknown
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_010c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0114: Unknown result type (might be due to invalid IL or missing references)
			//IL_0174: Unknown result type (might be due to invalid IL or missing references)
			//IL_0179: Unknown result type (might be due to invalid IL or missing references)
			//IL_018e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0190: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			string result;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					if ((uint)(num - 1) <= 1u)
					{
						goto IL_0084;
					}
					awaiter = _003C_003E4__this._dbSemaphore.WaitAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CReadJsonAsync_003Ed__14 _003CReadJsonAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CReadJsonAsync_003Ed__14>(ref awaiter, ref _003CReadJsonAsync_003Ed__);
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
				goto IL_0084;
				IL_0084:
				try
				{
					if ((uint)(num - 1) > 1u)
					{
						_003Cconnection_003E5__1 = new SqliteConnection("Data Source=" + _003C_003E4__this._dbPath);
					}
					try
					{
						TaskAwaiter<object> awaiter2;
						TaskAwaiter awaiter3;
						if (num != 1)
						{
							if (num == 2)
							{
								awaiter2 = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter<object>);
								num = (_003C_003E1__state = -1);
								goto IL_01c9;
							}
							awaiter3 = ((DbConnection)_003Cconnection_003E5__1).OpenAsync().GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__1 = awaiter3;
								_003CReadJsonAsync_003Ed__14 _003CReadJsonAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CReadJsonAsync_003Ed__14>(ref awaiter3, ref _003CReadJsonAsync_003Ed__);
								return;
							}
						}
						else
						{
							awaiter3 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
						}
						((TaskAwaiter)(ref awaiter3)).GetResult();
						_003Ccommand_003E5__2 = _003Cconnection_003E5__1.CreateCommand();
						((DbCommand)_003Ccommand_003E5__2).CommandText = "SELECT DataJson FROM StaticCache WHERE CollectionKey = $key";
						_003Ccommand_003E5__2.Parameters.AddWithValue("$key", (object)collectionKey);
						awaiter2 = ((DbCommand)_003Ccommand_003E5__2).ExecuteScalarAsync().GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__2 = awaiter2;
							_003CReadJsonAsync_003Ed__14 _003CReadJsonAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<object>, _003CReadJsonAsync_003Ed__14>(ref awaiter2, ref _003CReadJsonAsync_003Ed__);
							return;
						}
						goto IL_01c9;
						IL_01c9:
						_003C_003Es__4 = awaiter2.GetResult();
						_003Cresult_003E5__3 = _003C_003Es__4;
						_003C_003Es__4 = null;
						result = _003Cresult_003E5__3 as string;
					}
					finally
					{
						if (num < 0 && _003Cconnection_003E5__1 != null)
						{
							((global::System.IDisposable)_003Cconnection_003E5__1).Dispose();
						}
					}
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this._dbSemaphore.Release();
					}
				}
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
	private sealed class _003CReadListCollectionAsync_003Ed__6<T> : IAsyncStateMachine where T : notnull
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Dictionary<string, List<T>>> _003C_003Et__builder;

		public string collectionKey;

		public StaticDataSqliteCache _003C_003E4__this;

		private string _003Cjson_003E5__1;

		private string _003C_003Es__2;

		private TaskAwaiter<string?> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Dictionary<string, List<T>> result;
			try
			{
				TaskAwaiter<string> awaiter;
				if (num != 0)
				{
					awaiter = _003C_003E4__this.ReadJsonAsync(collectionKey).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CReadListCollectionAsync_003Ed__6<T> _003CReadListCollectionAsync_003Ed__ = this;
						global::System.Runtime.CompilerServices.Unsafe.As<AsyncTaskMethodBuilder<Dictionary<string, List<T>>>, AsyncTaskMethodBuilder<Dictionary<string, List<Dictionary<string, List<T>>>>>>(ref _003C_003Et__builder).AwaitUnsafeOnCompleted<TaskAwaiter<string>, _003CReadListCollectionAsync_003Ed__6<T>>(ref awaiter, ref _003CReadListCollectionAsync_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<string>);
					num = (_003C_003E1__state = -1);
				}
				_003C_003Es__2 = awaiter.GetResult();
				_003Cjson_003E5__1 = _003C_003Es__2;
				_003C_003Es__2 = null;
				result = ((_003Cjson_003E5__1 != null) ? JsonSerializer.Deserialize<Dictionary<string, List<T>>>(_003Cjson_003E5__1, JsonOptions) : null);
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cjson_003E5__1 = null;
				global::System.Runtime.CompilerServices.Unsafe.As<AsyncTaskMethodBuilder<Dictionary<string, List<T>>>, AsyncTaskMethodBuilder<Dictionary<string, List<Dictionary<string, List<T>>>>>>(ref _003C_003Et__builder).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cjson_003E5__1 = null;
			global::System.Runtime.CompilerServices.Unsafe.As<AsyncTaskMethodBuilder<Dictionary<string, List<T>>>, AsyncTaskMethodBuilder<Dictionary<string, List<Dictionary<string, List<T>>>>>>(ref _003C_003Et__builder).SetResult((Dictionary<string, List<Dictionary<string, List<T>>>>)(object)result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CWriteCollectionAsync_003Ed__7<T> : IAsyncStateMachine where T : notnull
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string collectionKey;

		public Dictionary<string, T> data;

		public StaticDataSqliteCache _003C_003E4__this;

		private string _003Cjson_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					_003Cjson_003E5__1 = JsonSerializer.Serialize<Dictionary<string, T>>(data, JsonOptions);
					awaiter = _003C_003E4__this.WriteJsonAsync(collectionKey, _003Cjson_003E5__1).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CWriteCollectionAsync_003Ed__7<T> _003CWriteCollectionAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CWriteCollectionAsync_003Ed__7<T>>(ref awaiter, ref _003CWriteCollectionAsync_003Ed__);
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
				_003Cjson_003E5__1 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cjson_003E5__1 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CWriteJsonAsync_003Ed__15 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string collectionKey;

		public string json;

		public StaticDataSqliteCache _003C_003E4__this;

		private SqliteConnection _003Cconnection_003E5__1;

		private SqliteCommand _003Ccommand_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<int> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Expected O, but got Unknown
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					if ((uint)(num - 1) <= 1u)
					{
						goto IL_0084;
					}
					awaiter = _003C_003E4__this._dbSemaphore.WaitAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CWriteJsonAsync_003Ed__15 _003CWriteJsonAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CWriteJsonAsync_003Ed__15>(ref awaiter, ref _003CWriteJsonAsync_003Ed__);
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
				goto IL_0084;
				IL_0084:
				try
				{
					if ((uint)(num - 1) > 1u)
					{
						_003Cconnection_003E5__1 = new SqliteConnection("Data Source=" + _003C_003E4__this._dbPath);
					}
					try
					{
						TaskAwaiter<int> awaiter2;
						TaskAwaiter awaiter3;
						if (num != 1)
						{
							if (num == 2)
							{
								awaiter2 = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter<int>);
								num = (_003C_003E1__state = -1);
								goto IL_020b;
							}
							awaiter3 = ((DbConnection)_003Cconnection_003E5__1).OpenAsync().GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__1 = awaiter3;
								_003CWriteJsonAsync_003Ed__15 _003CWriteJsonAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CWriteJsonAsync_003Ed__15>(ref awaiter3, ref _003CWriteJsonAsync_003Ed__);
								return;
							}
						}
						else
						{
							awaiter3 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
						}
						((TaskAwaiter)(ref awaiter3)).GetResult();
						_003Ccommand_003E5__2 = _003Cconnection_003E5__1.CreateCommand();
						((DbCommand)_003Ccommand_003E5__2).CommandText = "\r\n                INSERT INTO StaticCache (CollectionKey, DataJson, SavedAt)\r\n                VALUES ($key, $json, $savedAt)\r\n                ON CONFLICT(CollectionKey) DO UPDATE SET\r\n                    DataJson = excluded.DataJson,\r\n                    SavedAt  = excluded.SavedAt";
						_003Ccommand_003E5__2.Parameters.AddWithValue("$key", (object)collectionKey);
						_003Ccommand_003E5__2.Parameters.AddWithValue("$json", (object)json);
						_003Ccommand_003E5__2.Parameters.AddWithValue("$savedAt", (object)global::System.DateTime.UtcNow.ToString("O"));
						awaiter2 = ((DbCommand)_003Ccommand_003E5__2).ExecuteNonQueryAsync().GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__2 = awaiter2;
							_003CWriteJsonAsync_003Ed__15 _003CWriteJsonAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<int>, _003CWriteJsonAsync_003Ed__15>(ref awaiter2, ref _003CWriteJsonAsync_003Ed__);
							return;
						}
						goto IL_020b;
						IL_020b:
						awaiter2.GetResult();
					}
					finally
					{
						if (num < 0 && _003Cconnection_003E5__1 != null)
						{
							((global::System.IDisposable)_003Cconnection_003E5__1).Dispose();
						}
					}
					_003Cconnection_003E5__1 = null;
					_003Ccommand_003E5__2 = null;
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this._dbSemaphore.Release();
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
	private sealed class _003CWriteListCollectionAsync_003Ed__8<T> : IAsyncStateMachine where T : notnull
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string collectionKey;

		public Dictionary<string, List<T>> data;

		public StaticDataSqliteCache _003C_003E4__this;

		private string _003Cjson_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					_003Cjson_003E5__1 = JsonSerializer.Serialize<Dictionary<string, List<T>>>(data, JsonOptions);
					awaiter = _003C_003E4__this.WriteJsonAsync(collectionKey, _003Cjson_003E5__1).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CWriteListCollectionAsync_003Ed__8<T> _003CWriteListCollectionAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CWriteListCollectionAsync_003Ed__8<T>>(ref awaiter, ref _003CWriteListCollectionAsync_003Ed__);
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
				_003Cjson_003E5__1 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cjson_003E5__1 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly string _dbPath;

	private readonly SemaphoreSlim _dbSemaphore = new SemaphoreSlim(1, 1);

	internal static readonly JsonSerializerOptions JsonOptions;

	public StaticDataSqliteCache()
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		_dbPath = Path.Combine(FileSystem.AppDataDirectory, "static_cache.db");
	}

	[AsyncStateMachine(typeof(_003CInitializeAsync_003Ed__4))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task InitializeAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CInitializeAsync_003Ed__4 _003CInitializeAsync_003Ed__ = new _003CInitializeAsync_003Ed__4();
		_003CInitializeAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CInitializeAsync_003Ed__._003C_003E4__this = this;
		_003CInitializeAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CInitializeAsync_003Ed__._003C_003Et__builder)).Start<_003CInitializeAsync_003Ed__4>(ref _003CInitializeAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CInitializeAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CReadCollectionAsync_003Ed__5<>))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Dictionary<string, T>?> ReadCollectionAsync<T>(string collectionKey)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		string json = await ReadJsonAsync(collectionKey);
		if (json == null)
		{
			return null;
		}
		return JsonSerializer.Deserialize<Dictionary<string, T>>(json, JsonOptions);
	}

	[AsyncStateMachine(typeof(_003CReadListCollectionAsync_003Ed__6<>))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Dictionary<string, List<T>>?> ReadListCollectionAsync<T>(string collectionKey)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		string json = await ReadJsonAsync(collectionKey);
		if (json == null)
		{
			return null;
		}
		return JsonSerializer.Deserialize<Dictionary<string, List<T>>>(json, JsonOptions);
	}

	[AsyncStateMachine(typeof(_003CWriteCollectionAsync_003Ed__7<>))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task WriteCollectionAsync<T>(string collectionKey, Dictionary<string, T> data)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CWriteCollectionAsync_003Ed__7<T> _003CWriteCollectionAsync_003Ed__ = new _003CWriteCollectionAsync_003Ed__7<T>();
		_003CWriteCollectionAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CWriteCollectionAsync_003Ed__._003C_003E4__this = this;
		_003CWriteCollectionAsync_003Ed__.collectionKey = collectionKey;
		_003CWriteCollectionAsync_003Ed__.data = data;
		_003CWriteCollectionAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CWriteCollectionAsync_003Ed__._003C_003Et__builder)).Start<_003CWriteCollectionAsync_003Ed__7<T>>(ref _003CWriteCollectionAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CWriteCollectionAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CWriteListCollectionAsync_003Ed__8<>))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task WriteListCollectionAsync<T>(string collectionKey, Dictionary<string, List<T>> data)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CWriteListCollectionAsync_003Ed__8<T> _003CWriteListCollectionAsync_003Ed__ = new _003CWriteListCollectionAsync_003Ed__8<T>();
		_003CWriteListCollectionAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CWriteListCollectionAsync_003Ed__._003C_003E4__this = this;
		_003CWriteListCollectionAsync_003Ed__.collectionKey = collectionKey;
		_003CWriteListCollectionAsync_003Ed__.data = data;
		_003CWriteListCollectionAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CWriteListCollectionAsync_003Ed__._003C_003Et__builder)).Start<_003CWriteListCollectionAsync_003Ed__8<T>>(ref _003CWriteListCollectionAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CWriteListCollectionAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CClearAllAsync_003Ed__9))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task ClearAllAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CClearAllAsync_003Ed__9 _003CClearAllAsync_003Ed__ = new _003CClearAllAsync_003Ed__9();
		_003CClearAllAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CClearAllAsync_003Ed__._003C_003E4__this = this;
		_003CClearAllAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CClearAllAsync_003Ed__._003C_003Et__builder)).Start<_003CClearAllAsync_003Ed__9>(ref _003CClearAllAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CClearAllAsync_003Ed__._003C_003Et__builder)).Task;
	}

	public Dictionary<string, List<CachedQuestTask>> ToCachedTasksByArea(Dictionary<string, List<QuestTask>> source)
	{
		return Enumerable.ToDictionary<KeyValuePair<string, List<QuestTask>>, string, List<CachedQuestTask>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, List<QuestTask>>>)source, (Func<KeyValuePair<string, List<QuestTask>>, string>)((KeyValuePair<string, List<QuestTask>> kvp) => kvp.Key), (Func<KeyValuePair<string, List<QuestTask>>, List<CachedQuestTask>>)((KeyValuePair<string, List<QuestTask>> kvp) => Enumerable.ToList<CachedQuestTask>(Enumerable.Select<QuestTask, CachedQuestTask>((global::System.Collections.Generic.IEnumerable<QuestTask>)kvp.Value, (Func<QuestTask, CachedQuestTask>)FromQuestTask))));
	}

	public Dictionary<string, List<QuestTask>> ToQuestTasksByArea(Dictionary<string, List<CachedQuestTask>> source)
	{
		return Enumerable.ToDictionary<KeyValuePair<string, List<CachedQuestTask>>, string, List<QuestTask>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, List<CachedQuestTask>>>)source, (Func<KeyValuePair<string, List<CachedQuestTask>>, string>)((KeyValuePair<string, List<CachedQuestTask>> kvp) => kvp.Key), (Func<KeyValuePair<string, List<CachedQuestTask>>, List<QuestTask>>)((KeyValuePair<string, List<CachedQuestTask>> kvp) => Enumerable.ToList<QuestTask>(Enumerable.Select<CachedQuestTask, QuestTask>((global::System.Collections.Generic.IEnumerable<CachedQuestTask>)kvp.Value, (Func<CachedQuestTask, QuestTask>)ToQuestTask))));
	}

	private static CachedQuestTask FromQuestTask(QuestTask t)
	{
		return new CachedQuestTask(t.Id, t.Name, t.Description, t.Battle, t.Energy, t.Action, t.Order, t.OrderRequirement, t.TotalSteps, t.IsRepeatable, t.LevelRequirement, (t.Rewards == null) ? null : new CachedRewards(t.Rewards.Experience, t.Rewards.Gold, t.Rewards.Reputation, t.Rewards.Items), Enumerable.ToList<QuestOpponent>((global::System.Collections.Generic.IEnumerable<QuestOpponent>)t.QuestOpponents), Enumerable.ToList<CachedQuestParagraph>(Enumerable.Select<QuestParagraph, CachedQuestParagraph>((global::System.Collections.Generic.IEnumerable<QuestParagraph>)t.Paragraph, (Func<QuestParagraph, CachedQuestParagraph>)((QuestParagraph p) => new CachedQuestParagraph(p.Image, p.Text, p.View)))), t.OpponentImage, t.OpponentBackgroundImage, t.OpponentName, t.OpponentGuild);
	}

	private static QuestTask ToQuestTask(CachedQuestTask c)
	{
		return QuestTask.Rehydrate(c.Id ?? string.Empty, c.Name ?? string.Empty, c.Description ?? string.Empty, c.Battle, c.Energy, c.Action ?? string.Empty, c.Order, c.OrderRequirement ?? string.Empty, c.TotalSteps, ((object)c.Rewards == null) ? new Rewards() : new Rewards
		{
			Experience = c.Rewards.Experience,
			Gold = c.Rewards.Gold,
			Reputation = c.Rewards.Reputation,
			Items = c.Rewards.Items
		}, c.QuestOpponents, Enumerable.ToList<QuestParagraph>(Enumerable.Select<CachedQuestParagraph, QuestParagraph>((global::System.Collections.Generic.IEnumerable<CachedQuestParagraph>)c.Paragraphs, (Func<CachedQuestParagraph, QuestParagraph>)((CachedQuestParagraph p) => new QuestParagraph
		{
			Image = p.Image,
			Text = p.Text,
			View = p.View
		}))), c.IsRepeatable, c.LevelRequirement, c.OpponentImage, c.OpponentBackgroundImage, c.OpponentName, c.OpponentGuild);
	}

	[AsyncStateMachine(typeof(_003CReadJsonAsync_003Ed__14))]
	[DebuggerStepThrough]
	private async global::System.Threading.Tasks.Task<string?> ReadJsonAsync(string collectionKey)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		await _dbSemaphore.WaitAsync();
		try
		{
			SqliteConnection connection = new SqliteConnection("Data Source=" + _dbPath);
			try
			{
				await ((DbConnection)connection).OpenAsync();
				SqliteCommand command = connection.CreateCommand();
				((DbCommand)command).CommandText = "SELECT DataJson FROM StaticCache WHERE CollectionKey = $key";
				command.Parameters.AddWithValue("$key", (object)collectionKey);
				return (await ((DbCommand)command).ExecuteScalarAsync()) as string;
			}
			finally
			{
				((global::System.IDisposable)connection)?.Dispose();
			}
		}
		finally
		{
			_dbSemaphore.Release();
		}
	}

	[AsyncStateMachine(typeof(_003CWriteJsonAsync_003Ed__15))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task WriteJsonAsync(string collectionKey, string json)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CWriteJsonAsync_003Ed__15 _003CWriteJsonAsync_003Ed__ = new _003CWriteJsonAsync_003Ed__15();
		_003CWriteJsonAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CWriteJsonAsync_003Ed__._003C_003E4__this = this;
		_003CWriteJsonAsync_003Ed__.collectionKey = collectionKey;
		_003CWriteJsonAsync_003Ed__.json = json;
		_003CWriteJsonAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CWriteJsonAsync_003Ed__._003C_003Et__builder)).Start<_003CWriteJsonAsync_003Ed__15>(ref _003CWriteJsonAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CWriteJsonAsync_003Ed__._003C_003Et__builder)).Task;
	}

	public void Dispose()
	{
		_dbSemaphore.Dispose();
	}

	static StaticDataSqliteCache()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Expected O, but got Unknown
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		JsonSerializerOptions val = new JsonSerializerOptions();
		((global::System.Collections.Generic.ICollection<JsonConverter>)val.Converters).Add((JsonConverter)new JsonStringEnumConverter());
		val.WriteIndented = false;
		JsonOptions = val;
	}
}
