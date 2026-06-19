using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.Maui.Controls;

namespace SpiritSummoner.Presentation.Converters;

public class StringContainsConverter : IValueConverter
{
	public object Convert(object? value, global::System.Type targetType, object? parameter, CultureInfo culture)
	{
		string stringValue = value as string;
		if (stringValue == null || !(parameter is string text))
		{
			return false;
		}
		if (string.IsNullOrEmpty(stringValue) || string.IsNullOrEmpty(text))
		{
			return false;
		}
		global::System.Collections.Generic.IEnumerable<string> enumerable = Enumerable.Where<string>(Enumerable.Select<string, string>((global::System.Collections.Generic.IEnumerable<string>)text.Split(',', (StringSplitOptions)1), (Func<string, string>)((string term) => term.Trim())), (Func<string, bool>)((string term) => !string.IsNullOrEmpty(term)));
		return Enumerable.Any<string>(enumerable, (Func<string, bool>)((string term) => stringValue.Contains(term, (StringComparison)5)));
	}

	public object ConvertBack(object? value, global::System.Type targetType, object? parameter, CultureInfo culture)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		throw new NotImplementedException();
	}
}
