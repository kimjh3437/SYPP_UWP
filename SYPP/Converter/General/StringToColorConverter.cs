using SYPP.Converter.ColorConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace SYPP.Converter.General
{
    public class StringToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
           object parameter, string language)
        {
            if (!string.IsNullOrEmpty((string)value))
            {
                if ((string)value == "Transparent")
                {
                    value = "#00FFFFFF";
                }
                else if ((string)value == "White")
                {
                    value = "#FFFFFF";
                }
                var input = (String)value;
                return StringToSolidColorBrushConverter.Convert(input);
            }
            else
            {
                return StringToSolidColorBrushConverter.Convert("#FFFFFF");
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
        public Windows.UI.Color ConvertStringToColor(String hex)
        {
            //remove the # at the front
            hex = hex.Replace("#", "");

            byte a = 255;
            byte r = 255;
            byte g = 255;
            byte b = 255;
            int start = 0;

            //handle ARGB strings (8 characters long)
            if (hex.Length == 8)
            {
                a = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                start = 2;
            }

            //convert RGB characters to bytes
            r = byte.Parse(hex.Substring(start, 2), System.Globalization.NumberStyles.HexNumber);
            g = byte.Parse(hex.Substring(start + 2, 2), System.Globalization.NumberStyles.HexNumber);
            b = byte.Parse(hex.Substring(start + 4, 2), System.Globalization.NumberStyles.HexNumber);

            return Windows.UI.Color.FromArgb(a, r, g, b);
        }
    }
}
