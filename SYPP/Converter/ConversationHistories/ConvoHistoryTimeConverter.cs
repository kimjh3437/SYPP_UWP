using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace SYPP.Converter.ConversationHistories
{
    public class ConvoHistoryTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
                          object parameter, string language)
        {
            if (value != null)
            {
                var time = (DateTime)value;
                if (time.Year == 1)
                    return "Time Not Set";
                var t = time.ToString("MMM d, yyyy ");
                var today = DateTime.Today.ToString("");
                var span = DateTime.Now - time;
                var days = span.TotalDays.ToString();
                return $"{t} ({days.Substring(0, 1)} days ago)";
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
