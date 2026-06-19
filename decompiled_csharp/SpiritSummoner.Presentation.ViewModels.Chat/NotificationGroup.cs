using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SpiritSummoner.Presentation.ViewModels.Chat;

public class NotificationGroup : ObservableCollection<PlayerNotificationModel>
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string GroupLabel
	{
		[CompilerGenerated]
		get;
	}

	public NotificationGroup(string label, global::System.Collections.Generic.IEnumerable<PlayerNotificationModel> items)
		: base(items)
	{
		GroupLabel = label;
	}
}
