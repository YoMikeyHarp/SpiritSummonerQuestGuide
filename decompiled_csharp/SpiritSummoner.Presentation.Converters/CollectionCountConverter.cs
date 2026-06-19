using System;
using System.Collections;
using System.Globalization;
using System.Reflection;
using Microsoft.Maui.Controls;

namespace SpiritSummoner.Presentation.Converters;

public class CollectionCountConverter : IValueConverter
{
	public object Convert(object value, global::System.Type targetType, object parameter, CultureInfo culture)
	{
		if (!(value is global::System.Collections.IEnumerable enumerable) || !(parameter is string text))
		{
			return 0;
		}
		int num = 0;
		bool flag = default(bool);
		foreach (object item in enumerable)
		{
			if (item == null)
			{
				continue;
			}
			try
			{
				PropertyInfo property = item.GetType().GetProperty(text, (BindingFlags)20);
				object obj = ((property != null) ? property.GetValue(item) : null);
				int num2;
				if (obj is bool)
				{
					flag = (bool)obj;
					num2 = 1;
				}
				else
				{
					num2 = 0;
				}
				if (((uint)num2 & (flag ? 1u : 0u)) != 0)
				{
					num++;
				}
			}
			catch
			{
			}
		}
		return num;
	}

	public object ConvertBack(object value, global::System.Type targetType, object parameter, CultureInfo culture)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		throw new NotImplementedException();
	}
}
