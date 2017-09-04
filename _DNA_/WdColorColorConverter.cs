using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;

namespace _DNA_
{
    public class WdColorColorConverter
    {
        public static object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            if (!(value is WdColor))
            {
                return Color.Black;
            }
            else if ((WdColor)value == WdColor.wdColorAutomatic)
            {
                return Color.Black;
            }
            else
            {

                int intValue = ((WdColor)value).GetHashCode();
                string hexValue = intValue.ToString("X").PadLeft(6, '0');

                string redHex = hexValue.Substring(4, 2);
                string greenHex = hexValue.Substring(2, 2);
                string blueHex = hexValue.Substring(0, 2);

                byte redByte = byte.Parse(redHex, System.Globalization.NumberStyles.AllowHexSpecifier);
                byte greenByte = byte.Parse(greenHex, System.Globalization.NumberStyles.AllowHexSpecifier);
                byte blueByte = byte.Parse(blueHex, System.Globalization.NumberStyles.AllowHexSpecifier);

                Color c = Color.FromArgb(redByte, greenByte, blueByte);
                return c;

            }
        }
    }
}
