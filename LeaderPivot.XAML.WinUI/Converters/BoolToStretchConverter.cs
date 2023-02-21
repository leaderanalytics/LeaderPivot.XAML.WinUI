namespace LeaderAnalytics.LeaderPivot.XAML.WinUI.Converters;

internal class BoolToStretchConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        return ((bool)value) ? Stretch.UniformToFill : Stretch.None;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
