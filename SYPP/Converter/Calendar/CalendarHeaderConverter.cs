using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace SYPP.Converter.Calendar
{
    public class CalendarHeaderConverter : IValueConverter 
    {
        public object Convert(object value, Type targetType,
              object parameter, string language)
        {
            if (value != null)
            {
                DateTime date = (DateTime)value;
                String str = date.ToString("MMM yyyy");
                return str;
            }
            return DateTime.UtcNow.ToString("MMM yyyy");
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return DateTime.UtcNow.ToString("MMM yyyy");
        } 
    }
}
