
namespace LeaderAnalytics.LeaderPivot.XAML.WinUI.Converters;

internal class DimensionActionDescriptionConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        DimensionAction action = ((DimensionAction)value);
        FieldInfo fi = action.GetType().GetField(action.ToString());
        return ((DescriptionAttribute)fi.GetCustomAttributes(typeof(DescriptionAttribute), false)[0]).Description;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
