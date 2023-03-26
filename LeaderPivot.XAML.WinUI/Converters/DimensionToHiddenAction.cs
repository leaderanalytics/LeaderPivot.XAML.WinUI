using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderAnalytics.LeaderPivot.XAML.WinUI.Converters;

internal class DimensionToHiddenAction : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        return new DimensionEventArgs { DimensionID = ((Dimension)value).DisplayValue, Action = DimensionAction.UnHide };
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
