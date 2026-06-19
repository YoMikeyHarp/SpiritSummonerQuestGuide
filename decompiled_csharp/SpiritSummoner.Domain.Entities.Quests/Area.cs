using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

namespace SpiritSummoner.Domain.Entities.Quests;

public class Area : INotifyPropertyChanged
{
	private bool _hasUnclaimedQuest;

	[CompilerGenerated]
	[DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	private PropertyChangedEventHandler? m_PropertyChanged;

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? Id
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? Name
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int Order
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int LevelRequired
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? Image
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool IsSelected
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? TaskRequired
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public bool HasUnclaimedQuest
	{
		get
		{
			return _hasUnclaimedQuest;
		}
		set
		{
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Expected O, but got Unknown
			if (_hasUnclaimedQuest != value)
			{
				_hasUnclaimedQuest = value;
				PropertyChangedEventHandler? propertyChanged = this.PropertyChanged;
				if (propertyChanged != null)
				{
					propertyChanged.Invoke((object)this, new PropertyChangedEventArgs("HasUnclaimedQuest"));
				}
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		[CompilerGenerated]
		add
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			PropertyChangedEventHandler val = this.m_PropertyChanged;
			PropertyChangedEventHandler val2;
			do
			{
				val2 = val;
				PropertyChangedEventHandler val3 = (PropertyChangedEventHandler)global::System.Delegate.Combine((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.m_PropertyChanged, val3, val2);
			}
			while (val != val2);
		}
		[CompilerGenerated]
		remove
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			PropertyChangedEventHandler val = this.m_PropertyChanged;
			PropertyChangedEventHandler val2;
			do
			{
				val2 = val;
				PropertyChangedEventHandler val3 = (PropertyChangedEventHandler)global::System.Delegate.Remove((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.m_PropertyChanged, val3, val2);
			}
			while (val != val2);
		}
	}

	public static Area Rehydrate(string id, string name, int order, int levelRequired, string image, bool isSelected, string? taskRequired = null)
	{
		return new Area
		{
			Id = id,
			Name = name,
			Order = order,
			LevelRequired = levelRequired,
			Image = image,
			IsSelected = isSelected,
			TaskRequired = taskRequired
		};
	}
}
