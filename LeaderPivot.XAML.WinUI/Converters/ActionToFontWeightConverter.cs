using Microsoft.UI.Text;
using Windows.UI.Text;

namespace LeaderAnalytics.LeaderPivot.XAML.WinUI.Converters;

internal class ActionToFontWeightConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        string s = value?.ToString() ?? string.Empty;

        if (s == string.Empty || s == "NoOp")
            return FontWeights.Normal;

        return s == parameter.ToString() ? FontWeights.Bold : FontWeights.Normal;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}