using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.ApplicationModel;
using SpiritSummoner.Application.Services;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Chat;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Chat;
using SpiritSummoner.Infrastructure.Cache;
using SpiritSummoner.Infrastructure.FirebaseListeners;
using SpiritSummoner.Presentation.Navigation;

namespace SpiritSummoner.Presentation.ViewModels.Chat;

public class GuildChatThreadViewModel : ObservableObject, ILoadableViewModel, global::System.IDisposable
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass26_0
	{
		public string currentPlayerId;

		internal ChatMessageModel _003CLoadThreadMessagesAsync_003Eb__0(ChatMessage m)
		{
			return MapToViewModel(m, currentPlayerId);
		}

		internal ChatMessageModel _003CLoadThreadMessagesAsync_003Eb__2(ChatMessage m)
		{
			return MapToViewModel(m, currentPlayerId);
		}
	}

	[CompilerGenerated]
	private sealed class _003CGoBack_003Ed__32 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildChatThreadViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					_003C_003E4__this._chatListener.StopMessageListener();
					_003C_003E4__this._chatListener.MessageReceived -= _003C_003E4__this.OnChatMessageReceived;
					awaiter = _003C_003E4__this._navigationService.GoBackAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CGoBack_003Ed__32 _003CGoBack_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoBack_003Ed__32>(ref awaiter, ref _003CGoBack_003Ed__);
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
	private sealed class _003CLoadDataAsync_003Ed__25 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public object parameter;

		public GuildChatThreadViewModel _003C_003E4__this;

		private string _003CparamStr_003E5__1;

		private string[] _003Cparts_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					_003CparamStr_003E5__1 = parameter as string;
					if (_003CparamStr_003E5__1 != null)
					{
						_003Cparts_003E5__2 = _003CparamStr_003E5__1.Split('|', (StringSplitOptions)0);
						_003C_003E4__this._threadId = _003Cparts_003E5__2[0];
						_003C_003E4__this.ThreadSubject = ((_003Cparts_003E5__2.Length > 1) ? _003Cparts_003E5__2[1] : "Thread");
						_003Cparts_003E5__2 = null;
					}
					_003C_003E4__this._guildId = _003C_003E4__this._playerState.GetCurrentPlayer()?.GuildId ?? string.Empty;
					awaiter = _003C_003E4__this.LoadThreadMessagesAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CLoadDataAsync_003Ed__25 _003CLoadDataAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__25>(ref awaiter, ref _003CLoadDataAsync_003Ed__);
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
				_003CparamStr_003E5__1 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CparamStr_003E5__1 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CLoadOlderMessages_003Ed__27 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildChatThreadViewModel _003C_003E4__this;

		private string _003CcurrentPlayerId_003E5__1;

		private Result<List<ChatMessage>> _003Cresult_003E5__2;

		private Result<List<ChatMessage>> _003C_003Es__3;

		private List<ChatMessage> _003ColderMessages_003E5__4;

		private int _003Ci_003E5__5;

		private global::System.Exception _003Cex_003E5__6;

		private TaskAwaiter<Result<List<ChatMessage>>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0203: Unknown result type (might be due to invalid IL or missing references)
			//IL_0208: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num == 0)
				{
					goto IL_0053;
				}
				if (!_003C_003E4__this.IsLoadingOlderMessages && _003C_003E4__this.HasMoreMessages && !string.IsNullOrEmpty(_003C_003E4__this._guildId))
				{
					_003C_003E4__this.IsLoadingOlderMessages = true;
					goto IL_0053;
				}
				goto end_IL_0007;
				IL_0053:
				try
				{
					TaskAwaiter<Result<List<ChatMessage>>> awaiter;
					if (num != 0)
					{
						_003CcurrentPlayerId_003E5__1 = _003C_003E4__this._playerState.CurrentPlayerId ?? string.Empty;
						awaiter = _003C_003E4__this._getMessagesUseCase.ExecuteAsync(new GetGuildThreadMessagesRequest(_003C_003E4__this._guildId, _003C_003E4__this._threadId, 25, _003C_003E4__this._oldestLoadedTimestamp)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CLoadOlderMessages_003Ed__27 _003CLoadOlderMessages_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<List<ChatMessage>>>, _003CLoadOlderMessages_003Ed__27>(ref awaiter, ref _003CLoadOlderMessages_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Result<List<ChatMessage>>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__3 = awaiter.GetResult();
					_003Cresult_003E5__2 = _003C_003Es__3;
					_003C_003Es__3 = null;
					if (_003Cresult_003E5__2.Success)
					{
						List<ChatMessage>? data = _003Cresult_003E5__2.Data;
						if (data != null && data.Count > 0)
						{
							_003ColderMessages_003E5__4 = _003Cresult_003E5__2.Data;
							_003Ci_003E5__5 = _003ColderMessages_003E5__4.Count - 1;
							while (_003Ci_003E5__5 >= 0)
							{
								((Collection<ChatMessageModel>)(object)_003C_003E4__this.Messages).Insert(0, MapToViewModel(_003ColderMessages_003E5__4[_003Ci_003E5__5], _003CcurrentPlayerId_003E5__1));
								_003Ci_003E5__5--;
							}
							_003C_003E4__this._oldestLoadedTimestamp = Enumerable.Min<ChatMessage, DateTimeOffset>((global::System.Collections.Generic.IEnumerable<ChatMessage>)_003ColderMessages_003E5__4, (Func<ChatMessage, DateTimeOffset>)((ChatMessage m) => m.CreatedAt));
							_003C_003E4__this.HasMoreMessages = _003ColderMessages_003E5__4.Count == 25;
							_003C_003E4__this.OlderMessagesLoaded?.Invoke(_003ColderMessages_003E5__4.Count);
							_003ColderMessages_003E5__4 = null;
							goto IL_0263;
						}
					}
					_003C_003E4__this.HasMoreMessages = false;
					goto IL_0263;
					IL_0263:
					_003CcurrentPlayerId_003E5__1 = null;
					_003Cresult_003E5__2 = null;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__6 = ex;
					Console.WriteLine("LoadOlderMessages error: " + _003Cex_003E5__6.Message);
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this.IsLoadingOlderMessages = false;
					}
				}
				end_IL_0007:;
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
	private sealed class _003CLoadThreadMessagesAsync_003Ed__26 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildChatThreadViewModel _003C_003E4__this;

		private _003C_003Ec__DisplayClass26_0 _003C_003E8__1;

		private List<ChatMessage> _003CcachedMessages_003E5__2;

		private Result<List<ChatMessage>> _003Cresult_003E5__3;

		private Result<List<ChatMessage>> _003C_003Es__4;

		private List<ChatMessage> _003Cloaded_003E5__5;

		private global::System.Exception _003Cex_003E5__6;

		private TaskAwaiter<Result<List<ChatMessage>>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0195: Unknown result type (might be due to invalid IL or missing references)
			//IL_019a: Unknown result type (might be due to invalid IL or missing references)
			//IL_01af: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_012f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0134: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num != 0)
				{
					_003C_003E4__this.IsLoading = true;
				}
				try
				{
					TaskAwaiter<Result<List<ChatMessage>>> awaiter;
					if (num == 0)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Result<List<ChatMessage>>>);
						num = (_003C_003E1__state = -1);
						goto IL_01eb;
					}
					_003C_003E8__1 = new _003C_003Ec__DisplayClass26_0();
					_003C_003E8__1.currentPlayerId = _003C_003E4__this._playerState.CurrentPlayerId;
					if (!string.IsNullOrEmpty(_003C_003E8__1.currentPlayerId) && !string.IsNullOrEmpty(_003C_003E4__this._threadId) && !string.IsNullOrEmpty(_003C_003E4__this._guildId))
					{
						_003CcachedMessages_003E5__2 = _003C_003E4__this._guildChatCache.GetMessages(_003C_003E4__this._threadId);
						if (_003CcachedMessages_003E5__2 != null)
						{
							_003C_003E4__this.Messages = new ObservableCollection<ChatMessageModel>(Enumerable.Select<ChatMessage, ChatMessageModel>((global::System.Collections.Generic.IEnumerable<ChatMessage>)_003CcachedMessages_003E5__2, (Func<ChatMessage, ChatMessageModel>)((ChatMessage m) => MapToViewModel(m, _003C_003E8__1.currentPlayerId))));
							if (((Collection<ChatMessageModel>)(object)_003C_003E4__this.Messages).Count > 0)
							{
								_003C_003E4__this._oldestLoadedTimestamp = Enumerable.Min<ChatMessage, DateTimeOffset>((global::System.Collections.Generic.IEnumerable<ChatMessage>)_003CcachedMessages_003E5__2, (Func<ChatMessage, DateTimeOffset>)((ChatMessage m) => m.CreatedAt));
							}
							_003C_003E4__this.HasMoreMessages = _003CcachedMessages_003E5__2.Count >= 25;
							goto IL_0307;
						}
						awaiter = _003C_003E4__this._getMessagesUseCase.ExecuteAsync(new GetGuildThreadMessagesRequest(_003C_003E4__this._guildId, _003C_003E4__this._threadId)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CLoadThreadMessagesAsync_003Ed__26 _003CLoadThreadMessagesAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<List<ChatMessage>>>, _003CLoadThreadMessagesAsync_003Ed__26>(ref awaiter, ref _003CLoadThreadMessagesAsync_003Ed__);
							return;
						}
						goto IL_01eb;
					}
					goto end_IL_001d;
					IL_0307:
					_003C_003E4__this._chatListener.StartGuildThreadMessageListener(_003C_003E4__this._guildId, _003C_003E4__this._threadId);
					_003C_003E4__this._preferences.Set("lastGuildThreadViewed_" + _003C_003E4__this._threadId, global::System.DateTime.UtcNow);
					_003C_003E8__1 = null;
					_003CcachedMessages_003E5__2 = null;
					goto end_IL_001d;
					IL_01eb:
					_003C_003Es__4 = awaiter.GetResult();
					_003Cresult_003E5__3 = _003C_003Es__4;
					_003C_003Es__4 = null;
					if (_003Cresult_003E5__3.Success && _003Cresult_003E5__3.Data != null)
					{
						_003Cloaded_003E5__5 = _003Cresult_003E5__3.Data;
						_003C_003E4__this.Messages = new ObservableCollection<ChatMessageModel>(Enumerable.Select<ChatMessage, ChatMessageModel>((global::System.Collections.Generic.IEnumerable<ChatMessage>)_003Cloaded_003E5__5, (Func<ChatMessage, ChatMessageModel>)((ChatMessage m) => MapToViewModel(m, _003C_003E8__1.currentPlayerId))));
						_003C_003E4__this._guildChatCache.SetMessages(_003C_003E4__this._threadId, _003Cloaded_003E5__5);
						if (_003Cloaded_003E5__5.Count > 0)
						{
							_003C_003E4__this._oldestLoadedTimestamp = Enumerable.Min<ChatMessage, DateTimeOffset>((global::System.Collections.Generic.IEnumerable<ChatMessage>)_003Cloaded_003E5__5, (Func<ChatMessage, DateTimeOffset>)((ChatMessage m) => m.CreatedAt));
						}
						_003C_003E4__this.HasMoreMessages = _003Cloaded_003E5__5.Count == 25;
						_003Cloaded_003E5__5 = null;
					}
					_003Cresult_003E5__3 = null;
					goto IL_0307;
					end_IL_001d:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__6 = ex;
					Console.WriteLine("LoadThreadMessagesAsync error: " + _003Cex_003E5__6.Message);
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this.IsLoading = false;
					}
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
	private sealed class _003CSendMessage_003Ed__29 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildChatThreadViewModel _003C_003E4__this;

		private string _003Ctext_003E5__1;

		private Result<bool> _003Cresult_003E5__2;

		private Result<bool> _003C_003Es__3;

		private global::System.Exception _003Cex_003E5__4;

		private TaskAwaiter<Result<bool>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_010e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_015b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0160: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num == 0)
				{
					goto IL_0098;
				}
				if (!string.IsNullOrWhiteSpace(_003C_003E4__this.MessageText) && !string.IsNullOrEmpty(_003C_003E4__this._guildId) && !(DateTimeOffset.UtcNow - _003C_003E4__this._lastMessageSentAt < MessageCooldown))
				{
					_003C_003E4__this.IsSending = true;
					_003Ctext_003E5__1 = _003C_003E4__this.MessageText;
					_003C_003E4__this.MessageText = string.Empty;
					goto IL_0098;
				}
				goto end_IL_0007;
				IL_0098:
				try
				{
					TaskAwaiter<Result<bool>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this._sendMessageUseCase.ExecuteAsync(new SendGuildThreadMessageRequest(_003C_003E4__this._guildId, _003C_003E4__this._threadId, _003Ctext_003E5__1)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CSendMessage_003Ed__29 _003CSendMessage_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<bool>>, _003CSendMessage_003Ed__29>(ref awaiter, ref _003CSendMessage_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Result<bool>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__3 = awaiter.GetResult();
					_003Cresult_003E5__2 = _003C_003Es__3;
					_003C_003Es__3 = null;
					if (_003Cresult_003E5__2.Success)
					{
						_003C_003E4__this._lastMessageSentAt = DateTimeOffset.UtcNow;
					}
					else
					{
						_003C_003E4__this.MessageText = _003Ctext_003E5__1;
						Console.WriteLine("SendMessage failed: " + _003Cresult_003E5__2.ErrorMessage);
					}
					_003Cresult_003E5__2 = null;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__4 = ex;
					_003C_003E4__this.MessageText = _003Ctext_003E5__1;
					Console.WriteLine("SendMessage error: " + _003Cex_003E5__4.Message);
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this.IsSending = false;
					}
				}
				end_IL_0007:;
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003Ctext_003E5__1 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003Ctext_003E5__1 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly GetGuildThreadMessagesUseCase _getMessagesUseCase;

	private readonly SendGuildThreadMessageUseCase _sendMessageUseCase;

	private readonly IChatListenerService _chatListener;

	private readonly IPlayerStateService _playerState;

	private readonly INavigationService _navigationService;

	private readonly IGuildChatCacheService _guildChatCache;

	private readonly IPreferencesService _preferences;

	private bool _disposed;

	private string _threadId = string.Empty;

	private string _guildId = string.Empty;

	private static readonly TimeSpan MessageCooldown = TimeSpan.FromSeconds(1L);

	private DateTimeOffset _lastMessageSentAt = DateTimeOffset.MinValue;

	private DateTimeOffset _oldestLoadedTimestamp = DateTimeOffset.MaxValue;

	private const int PageSize = 25;

	[CompilerGenerated]
	[DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	private Action<int>? m_OlderMessagesLoaded;

	[ObservableProperty]
	private string _threadSubject = string.Empty;

	[ObservableProperty]
	private ObservableCollection<ChatMessageModel> _messages = new ObservableCollection<ChatMessageModel>();

	[ObservableProperty]
	private string _messageText = string.Empty;

	[ObservableProperty]
	private bool _isLoading;

	[ObservableProperty]
	private bool _isSending;

	[ObservableProperty]
	private bool _isLoadingOlderMessages;

	[ObservableProperty]
	private bool _hasMoreMessages;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? loadOlderMessagesCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? sendMessageCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? goBackCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string ThreadSubject
	{
		get
		{
			return _threadSubject;
		}
		[MemberNotNull("_threadSubject")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_threadSubject, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ThreadSubject);
				_threadSubject = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ThreadSubject);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ObservableCollection<ChatMessageModel> Messages
	{
		get
		{
			return _messages;
		}
		[MemberNotNull("_messages")]
		set
		{
			if (!EqualityComparer<ObservableCollection<ChatMessageModel>>.Default.Equals(_messages, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Messages);
				_messages = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Messages);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string MessageText
	{
		get
		{
			return _messageText;
		}
		[MemberNotNull("_messageText")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_messageText, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.MessageText);
				_messageText = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.MessageText);
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
	public bool IsSending
	{
		get
		{
			return _isSending;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isSending, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsSending);
				_isSending = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsSending);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsLoadingOlderMessages
	{
		get
		{
			return _isLoadingOlderMessages;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isLoadingOlderMessages, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsLoadingOlderMessages);
				_isLoadingOlderMessages = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsLoadingOlderMessages);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool HasMoreMessages
	{
		get
		{
			return _hasMoreMessages;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_hasMoreMessages, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HasMoreMessages);
				_hasMoreMessages = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HasMoreMessages);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand LoadOlderMessagesCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = loadOlderMessagesCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)LoadOlderMessages);
				AsyncRelayCommand val2 = val;
				loadOlderMessagesCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand SendMessageCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = sendMessageCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)SendMessage);
				AsyncRelayCommand val2 = val;
				sendMessageCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
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

	public event Action<int>? OlderMessagesLoaded
	{
		[CompilerGenerated]
		add
		{
			Action<int> val = this.m_OlderMessagesLoaded;
			Action<int> val2;
			do
			{
				val2 = val;
				Action<int> val3 = (Action<int>)(object)global::System.Delegate.Combine((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<Action<int>>(ref this.m_OlderMessagesLoaded, val3, val2);
			}
			while (val != val2);
		}
		[CompilerGenerated]
		remove
		{
			Action<int> val = this.m_OlderMessagesLoaded;
			Action<int> val2;
			do
			{
				val2 = val;
				Action<int> val3 = (Action<int>)(object)global::System.Delegate.Remove((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<Action<int>>(ref this.m_OlderMessagesLoaded, val3, val2);
			}
			while (val != val2);
		}
	}

	public GuildChatThreadViewModel(GetGuildThreadMessagesUseCase getMessagesUseCase, SendGuildThreadMessageUseCase sendMessageUseCase, IChatListenerService chatListener, IPlayerStateService playerState, INavigationService navigationService, IGuildChatCacheService guildChatCache, IPreferencesService preferences)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		_getMessagesUseCase = getMessagesUseCase;
		_sendMessageUseCase = sendMessageUseCase;
		_chatListener = chatListener;
		_playerState = playerState;
		_navigationService = navigationService;
		_guildChatCache = guildChatCache;
		_preferences = preferences;
		_chatListener.MessageReceived += OnChatMessageReceived;
	}

	[AsyncStateMachine(typeof(_003CLoadDataAsync_003Ed__25))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task LoadDataAsync(object? parameter)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadDataAsync_003Ed__25 _003CLoadDataAsync_003Ed__ = new _003CLoadDataAsync_003Ed__25();
		_003CLoadDataAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadDataAsync_003Ed__._003C_003E4__this = this;
		_003CLoadDataAsync_003Ed__.parameter = parameter;
		_003CLoadDataAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadDataAsync_003Ed__25>(ref _003CLoadDataAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CLoadThreadMessagesAsync_003Ed__26))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task LoadThreadMessagesAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadThreadMessagesAsync_003Ed__26 _003CLoadThreadMessagesAsync_003Ed__ = new _003CLoadThreadMessagesAsync_003Ed__26();
		_003CLoadThreadMessagesAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadThreadMessagesAsync_003Ed__._003C_003E4__this = this;
		_003CLoadThreadMessagesAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadThreadMessagesAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadThreadMessagesAsync_003Ed__26>(ref _003CLoadThreadMessagesAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadThreadMessagesAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CLoadOlderMessages_003Ed__27))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task LoadOlderMessages()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadOlderMessages_003Ed__27 _003CLoadOlderMessages_003Ed__ = new _003CLoadOlderMessages_003Ed__27();
		_003CLoadOlderMessages_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadOlderMessages_003Ed__._003C_003E4__this = this;
		_003CLoadOlderMessages_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadOlderMessages_003Ed__._003C_003Et__builder)).Start<_003CLoadOlderMessages_003Ed__27>(ref _003CLoadOlderMessages_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadOlderMessages_003Ed__._003C_003Et__builder)).Task;
	}

	private void OnChatMessageReceived(object? sender, ChatMessageReceivedEventArgs args)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		ChatMessageReceivedEventArgs args2 = args;
		if (args2.ConversationId != _threadId)
		{
			return;
		}
		MainThread.BeginInvokeOnMainThread((Action)delegate
		{
			if (!Enumerable.Any<ChatMessageModel>((global::System.Collections.Generic.IEnumerable<ChatMessageModel>)Messages, (Func<ChatMessageModel, bool>)((ChatMessageModel m) => m.Id == args2.Message.Id)))
			{
				string currentPlayerId = _playerState.CurrentPlayerId ?? string.Empty;
				((Collection<ChatMessageModel>)(object)Messages).Add(MapToViewModel(args2.Message, currentPlayerId));
				_guildChatCache.AppendMessage(_threadId, args2.Message);
				_preferences.Set("lastGuildThreadViewed_" + _threadId, global::System.DateTime.UtcNow);
			}
		});
	}

	[AsyncStateMachine(typeof(_003CSendMessage_003Ed__29))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task SendMessage()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CSendMessage_003Ed__29 _003CSendMessage_003Ed__ = new _003CSendMessage_003Ed__29();
		_003CSendMessage_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CSendMessage_003Ed__._003C_003E4__this = this;
		_003CSendMessage_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CSendMessage_003Ed__._003C_003Et__builder)).Start<_003CSendMessage_003Ed__29>(ref _003CSendMessage_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CSendMessage_003Ed__._003C_003Et__builder)).Task;
	}

	public void StopListening()
	{
		_chatListener.StopMessageListener();
	}

	public void ResumeListening()
	{
		if (!string.IsNullOrEmpty(_threadId) && !string.IsNullOrEmpty(_guildId) && !_disposed)
		{
			_chatListener.StartGuildThreadMessageListener(_guildId, _threadId);
		}
	}

	[AsyncStateMachine(typeof(_003CGoBack_003Ed__32))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task GoBack()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CGoBack_003Ed__32 _003CGoBack_003Ed__ = new _003CGoBack_003Ed__32();
		_003CGoBack_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CGoBack_003Ed__._003C_003E4__this = this;
		_003CGoBack_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CGoBack_003Ed__._003C_003Et__builder)).Start<_003CGoBack_003Ed__32>(ref _003CGoBack_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CGoBack_003Ed__._003C_003Et__builder)).Task;
	}

	public void Dispose()
	{
		if (!_disposed)
		{
			_disposed = true;
			_chatListener.StopMessageListener();
			_chatListener.MessageReceived -= OnChatMessageReceived;
			GC.SuppressFinalize((object)this);
		}
	}

	private static ChatMessageModel MapToViewModel(ChatMessage m, string currentPlayerId)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		return new ChatMessageModel
		{
			Id = m.Id,
			SenderId = m.SenderId,
			SenderName = m.SenderName,
			Content = m.Content,
			CreatedAt = m.CreatedAt,
			IsCurrentPlayer = (m.SenderId == currentPlayerId)
		};
	}
}
