using System;
using System.Globalization;
using Microsoft.Maui.Controls;
using SpiritSummoner.Presentation.ViewModels.Quests;

namespace SpiritSummoner.Presentation.Converters;

public class AreaLockedConverter : IValueConverter
{
	public object Convert(object? value, global::System.Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is string areaId)
		{
			CollectionView val = (CollectionView)((parameter is CollectionView) ? parameter : null);
			if (val != null && ((BindableObject)val).BindingContext is QuestViewModel questViewModel)
			{
				return !questViewModel.IsAreaUnlockedForDisplay(areaId);
			}
		}
		return false;
	}

	public object ConvertBack(object? value, global::System.Type targetType, object? parameter, CultureInfo culture)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		throw new NotImplementedException();
	}
}
