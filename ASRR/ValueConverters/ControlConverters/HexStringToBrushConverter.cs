using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace ASRR
{
    /// <summary>
    /// konweter String Hex na Brush
    /// </summary>
    class HexStringToBrushConverter : BaseValueConverter<HexStringToBrushConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string hex = (string)value;
            BrushConverter converter = new BrushConverter();
            Brush brush = (Brush)converter.ConvertFromString(hex);

            return brush;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
