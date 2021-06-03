using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace SYPP.Converter.Events
{
    public class EventTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
                       object parameter, string language)
        {
            if (value != null)
            {
                var time = (DateTime)value;
                if (time.Year == 1)
                    return "Time Not Set";
                return time.ToString("MMM d, yyyy - h:mm tt");
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType,
        object parameter, string language)
        {
            return DateTime.Parse((String)value);
        }
    }
}
