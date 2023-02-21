﻿namespace LeaderAnalytics.LeaderPivot.XAML.WinUI.Converters;

internal class NegateConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        return !((bool)value) ;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
