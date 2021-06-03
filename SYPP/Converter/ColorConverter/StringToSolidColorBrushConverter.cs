using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI;

namespace SYPP.Converter.ColorConverter
{
    public static class StringToSolidColorBrushConverter
    {
        public static SolidColorBrush Convert(string _hexString)
        {
            try
            {
                var colorStr = _hexString.Replace("#", string.Empty);
                if (colorStr.ToLower() == "transparent")
                {
                    return new SolidColorBrush(Colors.Transparent);
                }
                // from #RRGGBB string
                Windows.UI.Color color;
                if (colorStr.Length == 6)
                {
                    var r = (byte)System.Convert.ToUInt32(colorStr.Substring(0, 2), 16);
                    var g = (byte)System.Convert.ToUInt32(colorStr.Substring(2, 2), 16);
                    var b = (byte)System.Convert.ToUInt32(colorStr.Substring(4, 2), 16);
                    //get the color
                    color = Windows.UI.Color.FromArgb(255, r, g, b);
                }
                else
                {
                    byte a = (byte)(System.Convert.ToUInt32(colorStr.Substring(0, 2), 16));
                    byte r = (byte)(System.Convert.ToUInt32(colorStr.Substring(2, 2), 16));
                    byte g = (byte)(System.Convert.ToUInt32(colorStr.Substring(4, 2), 16));
                    byte b = (byte)(System.Convert.ToUInt32(colorStr.Substring(6, 2), 16));
                    color = Windows.UI.Color.FromArgb(a, r, g, b);
                }
                // create the solidColorbrush
                var myBrush = new SolidColorBrush(color);
                return myBrush;
            }
            catch (Exception ex)
            {
                return new SolidColorBrush();
            }

        }
        public static Color ConvertToWindowsUI(string _hexString)
        {
            try
            {
                var colorStr = _hexString.Replace("#", string.Empty);
                if (colorStr.ToLower() == "transparent")
                {
                    return Colors.Transparent;
                }
                // from #RRGGBB string
                Windows.UI.Color color;
                if (colorStr.Length == 6)
                {
                    var r = (byte)System.Convert.ToUInt32(colorStr.Substring(0, 2), 16);
                    var g = (byte)System.Convert.ToUInt32(colorStr.Substring(2, 2), 16);
                    var b = (byte)System.Convert.ToUInt32(colorStr.Substring(4, 2), 16);
                    //get the color
                    color = Windows.UI.Color.FromArgb(255, r, g, b);
                }
                else
                {
                    byte a = (byte)(System.Convert.ToUInt32(colorStr.Substring(0, 2), 16));
                    byte r = (byte)(System.Convert.ToUInt32(colorStr.Substring(2, 2), 16));
                    byte g = (byte)(System.Convert.ToUInt32(colorStr.Substring(4, 2), 16));
                    byte b = (byte)(System.Convert.ToUInt32(colorStr.Substring(6, 2), 16));
                    color = Windows.UI.Color.FromArgb(a, r, g, b);
                }
                // create the solidColorbrush
                return color;
            }
            catch (Exception ex)
            {
                return Colors.Transparent;
            }

        }
    }
}
