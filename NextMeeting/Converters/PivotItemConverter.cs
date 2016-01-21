using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace NextMeeting.Converters
{
    public class PivotItemConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var pivotItem = value as PivotItem;

            if (pivotItem == null)
                return 0.0d;

            var tagName = parameter as string;

            if (pivotItem.Tag.ToString() == tagName)
                return 1.0d;

            return 0.0d;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}
