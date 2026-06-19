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
using SpiritSummoner.Domain.Repositories;
using SpiritSummoner.Infrastructure.Cache;
using SpiritSummoner.Infrastructure.FirebaseListeners;
using SpiritSummoner.Presentation.Navigation;

namespace SpiritSummoner.Presentation.ViewModels.Chat;

public class DirectMessageViewModel : ObservableObject, ILoadableViewModel, global::System.IDisposable
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass28_0
	{
		public string currentPlayerId;

		internal ChatMessageModel _003CLoadConversationAsync_003Eb__0(ChatMessage m)
		{
			return MapToViewModel(m, currentPlayerId);
		}

		internal ChatMessageModel _003CLoadConversationAsync_003Eb__2(ChatMessage m)
		{
			return MapToViewModel(m, currentPlayerId);
		}
	}

	[CompilerGenerated]
	private sealed class _003CGoBack_003Ed__34 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public DirectMessageViewModel _003C_003E4__this;

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
						_003CGoBack_003Ed__34 _003CGoBack_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoBack_003Ed__34>(ref awaiter, ref _003CGoBack_003Ed__);
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
	private sealed class _003CLoadConversationAsync_003Ed__28 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public DirectMessageViewModel _003C_003E4__this;

		private _003C_003Ec__DisplayClass28_0 _003C_003E8__1;

		private List<ChatMessage> _003CcachedMessages_003E5__2;

		private Conversation _003Cconversation_003E5__3;

		private Conversation _003C_003Es__4;

		private Result<List<ChatMessage>> _003CmessagesResult_003E5__5;

		private Result<List<ChatMessage>> _003C_003Es__6;

		private List<ChatMessage> _003Cloaded_003E5__7;

		private global::System.Exception _003Cex_003E5__8;

		private TaskAwaiter<Conversation?> _003C_003Eu__1;

		private TaskAwaiter<Result<List<ChatMessage>>> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0118: Unknown result type (might be due to invalid IL or missing references)
			//IL_011d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0124: Unknown result type (might be due to invalid IL or missing references)
			//IL_02fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0302: Unknown result type (might be due to invalid IL or missing references)
			//IL_030a: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_02df: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0268: Unknown result type (might be due to invalid IL or missing references)
			//IL_026d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0400: Unknown result type (might be due to invalid IL or missing references)
			//IL_0405: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num > 1u)
				{
					_003C_003E4__this.IsLoading = true;
				}
				try
				{
					TaskAwaiter<Conversation> awaiter;
					if (num == 0)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Conversation>);
						num = (_003C_003E1__state = -1);
						goto IL_0133;
					}
					TaskAwaiter<Result<List<ChatMessage>>> awaiter2;
					if (num == 1)
					{
						awaiter2 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<Result<List<ChatMessage>>>);
						num = (_003C_003E1__state = -1);
						goto IL_0319;
					}
					_003C_003E8__1 = new _003C_003Ec__DisplayClass28_0();
					_003C_003E8__1.currentPlayerId = _003C_003E4__this._playerState.CurrentPlayerId;
					if (!string.IsNullOrEmpty(_003C_003E8__1.currentPlayerId))
					{
						_003C_003E4__this._conversationId = _003C_003E4__this._dmCache.GetConversationId(_003C_003E8__1.currentPlayerId, _003C_003E4__this._friendId);
						if (_003C_003E4__this._conversationId == null)
						{
							awaiter = _003C_003E4__this._chatRepository.GetOrCreateDMConversationAsync(_003C_003E8__1.currentPlayerId, _003C_003E4__this._friendId).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CLoadConversationAsync_003Ed__28 _003CLoadConversationAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Conversation>, _003CLoadConversationAsync_003Ed__28>(ref awaiter, ref _003CLoadConversationAsync_003Ed__);
								return;
							}
							goto IL_0133;
						}
						goto IL_01c3;
					}
					goto end_IL_001e;
					IL_0319:
					_003C_003Es__6 = awaiter2.GetResult();
					_003CmessagesResult_003E5__5 = _003C_003Es__6;
					_003C_003Es__6 = null;
					if (_003CmessagesResult_003E5__5.Success && _003CmessagesResult_003E5__5.Data != null)
					{
						_003Cloaded_003E5__7 = _003CmessagesResult_003E5__5.Data;
						_003C_003E4__this.Messages = new ObservableCollection<ChatMessageModel>(Enumerable.Select<ChatMessage, ChatMessageModel>((global::System.Collections.Generic.IEnumerable<ChatMessage>)_003Cloaded_003E5__7, (Func<ChatMessage, ChatMessageModel>)((ChatMessage m) => MapToViewModel(m, _003C_003E8__1.currentPlayerId))));
						_003C_003E4__this._dmCache.SetMessages(_003C_003E4__this._conversationId, _003Cloaded_003E5__7);
						if (_003Cloaded_003E5__7.Count > 0)
						{
							_003C_003E4__this._oldestLoadedTimestamp = Enumerable.Min<ChatMessage, DateTimeOffset>((global::System.Collections.Generic.IEnumerable<ChatMessage>)_003Cloaded_003E5__7, (Func<ChatMessage, DateTimeOffset>)((ChatMessage m) => m.CreatedAt));
						}
						_003C_003E4__this.HasMoreMessages = _003Cloaded_003E5__7.Count == 25;
						_003Cloaded_003E5__7 = null;
					}
					_003CmessagesResult_003E5__5 = null;
					goto IL_0435;
					IL_01c3:
					_003CcachedMessages_003E5__2 = _003C_003E4__this._dmCache.GetMessages(_003C_003E4__this._conversationId);
					if (_003CcachedMessages_003E5__2 != null)
					{
						_003C_003E4__this.Messages = new ObservableCollection<ChatMessageModel>(Enumerable.Select<ChatMessage, ChatMessageModel>((global::System.Collections.Generic.IEnumerable<ChatMessage>)_003CcachedMessages_003E5__2, (Func<ChatMessage, ChatMessageModel>)((ChatMessage m) => MapToViewModel(m, _003C_003E8__1.currentPlayerId))));
						if (((Collection<ChatMessageModel>)(object)_003C_003E4__this.Messages).Count > 0)
						{
							_003C_003E4__this._oldestLoadedTimestamp = Enumerable.Min<ChatMessage, DateTimeOffset>((global::System.Collections.Generic.IEnumerable<ChatMessage>)_003CcachedMessages_003E5__2, (Func<ChatMessage, DateTimeOffset>)((ChatMessage m) => m.CreatedAt));
						}
						_003C_003E4__this.HasMoreMessages = _003CcachedMessages_003E5__2.Count >= 25;
						goto IL_0435;
					}
					awaiter2 = _003C_003E4__this._getChatMessagesUseCase.ExecuteAsync(new GetChatMessagesRequest(_003C_003E4__this._conversationId, 25)).GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter2;
						_003CLoadConversationAsync_003Ed__28 _003CLoadConversationAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<List<ChatMessage>>>, _003CLoadConversationAsync_003Ed__28>(ref awaiter2, ref _003CLoadConversationAsync_003Ed__);
						return;
					}
					goto IL_0319;
					IL_0435:
					_003C_003E4__this._chatListener.StartMessageListener(_003C_003E4__this._conversationId);
					_003C_003E4__this._preferences.Set("lastDMViewed_" + _003C_003E4__this._conversationId, global::System.DateTime.UtcNow);
					_003C_003E8__1 = null;
					_003CcachedMessages_003E5__2 = null;
					goto end_IL_001e;
					IL_0133:
					_003C_003Es__4 = awaiter.GetResult();
					_003Cconversation_003E5__3 = _003C_003Es__4;
					_003C_003Es__4 = null;
					if (_003Cconversation_003E5__3 != null)
					{
						_003C_003E4__this._conversationId = _003Cconversation_003E5__3.Id;
						_003C_003E4__this._dmCache.SetConversationId(_003C_003E8__1.currentPlayerId, _003C_003E4__this._friendId, _003C_003E4__this._conversationId);
						_003Cconversation_003E5__3 = null;
						goto IL_01c3;
					}
					Console.WriteLine("Failed to get/create DM conversation");
					end_IL_001e:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__8 = ex;
					Console.WriteLine("LoadConversationAsync error: " + _003Cex_003E5__8.Message);
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
	private sealed class _003CLoadDataAsync_003Ed__27 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public object parameter;

		public DirectMessageViewModel _003C_003E4__this;

		private string _003CparamStr_003E5__1;

		private string[] _003Cparts_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
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
						_003C_003E4__this._friendId = _003Cparts_003E5__2[0];
						_003C_003E4__this.FriendName = ((_003Cparts_003E5__2.Length > 1) ? _003Cparts_003E5__2[1] : "Player");
						_003Cparts_003E5__2 = null;
					}
					awaiter = _003C_003E4__this.LoadConversationAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CLoadDataAsync_003Ed__27 _003CLoadDataAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__27>(ref awaiter, ref _003CLoadDataAsync_003Ed__);
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
	private sealed class _003CLoadOlderMessages_003Ed__29 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public DirectMessageViewModel _003C_003E4__this;

		private string _003CcurrentPlayerId_003E5__1;

		private Result<List<ChatMessage>> _003Cresult_003E5__2;

		private Result<List<ChatMessage>> _003C_003Es__3;

		private List<ChatMessage> _003ColderMessages_003E5__4;

		private int _003Ci_003E5__5;

		private global::System.Exception _003Cex_003E5__6;

		private TaskAwaiter<Result<List<ChatMessage>>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num == 0)
				{
					goto IL_0051;
				}
				if (!_003C_003E4__this.IsLoadingOlderMessages && _003C_003E4__this.HasMoreMessages && _003C_003E4__this._conversationId != null)
				{
					_003C_003E4__this.IsLoadingOlderMessages = true;
					goto IL_0051;
				}
				goto end_IL_0007;
				IL_0051:
				try
				{
					TaskAwaiter<Result<List<ChatMessage>>> awaiter;
					if (num != 0)
					{
						_003CcurrentPlayerId_003E5__1 = _003C_003E4__this._playerState.CurrentPlayerId ?? string.Empty;
						awaiter = _003C_003E4__this._getChatMessagesUseCase.ExecuteAsync(new GetChatMessagesRequest(_003C_003E4__this._conversationId, 25, _003C_003E4__this._oldestLoadedTimestamp)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CLoadOlderMessages_003Ed__29 _003CLoadOlderMessages_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<List<ChatMessage>>>, _003CLoadOlderMessages_003Ed__29>(ref awaiter, ref _003CLoadOlderMessages_003Ed__);
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
							goto IL_0256;
						}
					}
					_003C_003E4__this.HasMoreMessages = false;
					goto IL_0256;
					IL_0256:
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
	private sealed class _003CSendMessage_003Ed__31 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public DirectMessageViewModel _003C_003E4__this;

		private string _003Ctext_003E5__1;

		private Result<bool> _003Cresult_003E5__2;

		private Result<bool> _003C_003Es__3;

		private global::System.Exception _003Cex_003E5__4;

		private TaskAwaiter<Result<bool>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0150: Unknown result type (might be due to invalid IL or missing references)
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num == 0)
				{
					goto IL_0098;
				}
				if (!string.IsNullOrWhiteSpace(_003C_003E4__this.MessageText) && !string.IsNullOrEmpty(_003C_003E4__this._conversationId) && !(DateTimeOffset.UtcNow - _003C_003E4__this._lastMessageSentAt < MessageCooldown))
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
						awaiter = _003C_003E4__this._sendChatMessageUseCase.ExecuteAsync(new SendChatMessageRequest(_003C_003E4__this._conversationId, _003Ctext_003E5__1)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CSendMessage_003Ed__31 _003CSendMessage_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<bool>>, _003CSendMessage_003Ed__31>(ref awaiter, ref _003CSendMessage_003Ed__);
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

	private readonly SendChatMessageUseCase _sendChatMessageUseCase;

	private readonly GetChatMessagesUseCase _getChatMessagesUseCase;

	private readonly IChatRepository _chatRepository;

	private readonly IChatListenerService _chatListener;

	private readonly IPlayerStateService _playerState;

	private readonly INavigationService _navigationService;

	private readonly IChatUnreadService _chatUnreadService;

	private readonly IPreferencesService _preferences;

	private readonly IDMCacheService _dmCache;

	private bool _disposed;

	private string? _conversationId;

	private string _friendId = string.Empty;

	private DateTimeOffset _lastMessageSentAt = DateTimeOffset.MinValue;

	private static readonly TimeSpan MessageCooldown = TimeSpan.FromSeconds(1L);

	private DateTimeOffset _oldestLoadedTimestamp = DateTimeOffset.MaxValue;

	private const int PageSize = 25;

	[CompilerGenerated]
	[DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	private Action<int>? m_OlderMessagesLoaded;

	[ObservableProperty]
	private string _friendName = string.Empty;

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
	public string FriendName
	{
		get
		{
			return _friendName;
		}
		[MemberNotNull("_friendName")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_friendName, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.FriendName);
				_friendName = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.FriendName);
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

	public DirectMessageViewModel(SendChatMessageUseCase sendChatMessageUseCase, GetChatMessagesUseCase getChatMessagesUseCase, IChatRepository chatRepository, IChatListenerService chatListener, IPlayerStateService playerState, INavigationService navigationService, IChatUnreadService chatUnreadService, IPreferencesService preferences, IDMCacheService dmCache)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		_sendChatMessageUseCase = sendChatMessageUseCase;
		_getChatMessagesUseCase = getChatMessagesUseCase;
		_chatRepository = chatRepository;
		_chatListener = chatListener;
		_playerState = playerState;
		_navigationService = navigationService;
		_chatUnreadService = chatUnreadService;
		_preferences = preferences;
		_dmCache = dmCache;
		_chatListener.MessageReceived += OnChatMessageReceived;
	}

	[AsyncStateMachine(typeof(_003CLoadDataAsync_003Ed__27))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task LoadDataAsync(object? parameter)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadDataAsync_003Ed__27 _003CLoadDataAsync_003Ed__ = new _003CLoadDataAsync_003Ed__27();
		_003CLoadDataAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadDataAsync_003Ed__._003C_003E4__this = this;
		_003CLoadDataAsync_003Ed__.parameter = parameter;
		_003CLoadDataAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadDataAsync_003Ed__27>(ref _003CLoadDataAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CLoadConversationAsync_003Ed__28))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task LoadConversationAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadConversationAsync_003Ed__28 _003CLoadConversationAsync_003Ed__ = new _003CLoadConversationAsync_003Ed__28();
		_003CLoadConversationAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadConversationAsync_003Ed__._003C_003E4__this = this;
		_003CLoadConversationAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadConversationAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadConversationAsync_003Ed__28>(ref _003CLoadConversationAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadConversationAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CLoadOlderMessages_003Ed__29))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task LoadOlderMessages()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadOlderMessages_003Ed__29 _003CLoadOlderMessages_003Ed__ = new _003CLoadOlderMessages_003Ed__29();
		_003CLoadOlderMessages_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadOlderMessages_003Ed__._003C_003E4__this = this;
		_003CLoadOlderMessages_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadOlderMessages_003Ed__._003C_003Et__builder)).Start<_003CLoadOlderMessages_003Ed__29>(ref _003CLoadOlderMessages_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadOlderMessages_003Ed__._003C_003Et__builder)).Task;
	}

	private void OnChatMessageReceived(object? sender, ChatMessageReceivedEventArgs args)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		ChatMessageReceivedEventArgs args2 = args;
		if (args2.ConversationId != _conversationId)
		{
			return;
		}
		MainThread.BeginInvokeOnMainThread((Action)delegate
		{
			if (!Enumerable.Any<ChatMessageModel>((global::System.Collections.Generic.IEnumerable<ChatMessageModel>)Messages, (Func<ChatMessageModel, bool>)((ChatMessageModel m) => m.Id == args2.Message.Id)))
			{
				string currentPlayerId = _playerState.CurrentPlayerId ?? string.Empty;
				ChatMessageModel chatMessageModel = MapToViewModel(args2.Message, currentPlayerId);
				((Collection<ChatMessageModel>)(object)Messages).Add(chatMessageModel);
				if (_conversationId != null)
				{
					_dmCache.AppendMessage(_conversationId, args2.Message);
				}
				if (_conversationId != null)
				{
					_preferences.Set("lastDMViewed_" + _conversationId, global::System.DateTime.UtcNow);
				}
			}
		});
	}

	[AsyncStateMachine(typeof(_003CSendMessage_003Ed__31))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task SendMessage()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CSendMessage_003Ed__31 _003CSendMessage_003Ed__ = new _003CSendMessage_003Ed__31();
		_003CSendMessage_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CSendMessage_003Ed__._003C_003E4__this = this;
		_003CSendMessage_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CSendMessage_003Ed__._003C_003Et__builder)).Start<_003CSendMessage_003Ed__31>(ref _003CSendMessage_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CSendMessage_003Ed__._003C_003Et__builder)).Task;
	}

	public void StopListening()
	{
		_chatListener.StopMessageListener();
	}

	public void ResumeListening()
	{
		if (!string.IsNullOrEmpty(_conversationId) && !_disposed)
		{
			_chatListener.StartMessageListener(_conversationId);
		}
	}

	[AsyncStateMachine(typeof(_003CGoBack_003Ed__34))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task GoBack()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CGoBack_003Ed__34 _003CGoBack_003Ed__ = new _003CGoBack_003Ed__34();
		_003CGoBack_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CGoBack_003Ed__._003C_003E4__this = this;
		_003CGoBack_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CGoBack_003Ed__._003C_003Et__builder)).Start<_003CGoBack_003Ed__34>(ref _003CGoBack_003Ed__);
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
