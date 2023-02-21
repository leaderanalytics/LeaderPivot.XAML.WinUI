namespace LeaderAnalytics.LeaderPivot.XAML.WinUI.Converters;

internal class SelectedItemConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        return value == parameter;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
