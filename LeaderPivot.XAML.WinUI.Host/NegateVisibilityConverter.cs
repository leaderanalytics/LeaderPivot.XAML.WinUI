using System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;

namespace LeaderPivot.XAML.WinUI.Host
{
    public class NegateVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ((Visibility)value) == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return (object)value;
        }
    }
}
