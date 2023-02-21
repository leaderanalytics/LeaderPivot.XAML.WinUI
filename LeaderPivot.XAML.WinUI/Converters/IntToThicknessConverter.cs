namespace LeaderAnalytics.LeaderPivot.XAML.WinUI.Converters;

internal class IntToThicknessConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        return new Thickness(System.Convert.ToDouble(value));
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
