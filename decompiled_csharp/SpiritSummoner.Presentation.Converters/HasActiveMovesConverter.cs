using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using Microsoft.Maui.Controls;
using SpiritSummoner.Presentation.Models;

namespace SpiritSummoner.Presentation.Converters;

public class HasActiveMovesConverter : IValueConverter
{
	public object Convert(object? value, global::System.Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is ObservableCollection<MoveEditableState> val)
		{
			return Enumerable.Any<MoveEditableState>((global::System.Collections.Generic.IEnumerable<MoveEditableState>)val, (Func<MoveEditableState, bool>)((MoveEditableState m) => m.IsActive));
		}
		return false;
	}

	public object ConvertBack(object? value, global::System.Type targetType, object? parameter, CultureInfo culture)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		throw new NotImplementedException();
	}
}
