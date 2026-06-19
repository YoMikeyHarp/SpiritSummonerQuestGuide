using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using SpiritSummoner.Domain.Entities.Chat;

namespace SpiritSummoner.Infrastructure.FirebaseListeners;

public class ChatMessageReceivedEventArgs : EventArgs
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public ChatMessage Message
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	} = null;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string ConversationId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	} = string.Empty;

}
