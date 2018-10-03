using System;
using System.Globalization;
using System.Windows.Data;

namespace ASRR
{
    /// <summary>
    /// konwerter do okreslenia pozycji elementow lub ich rozmiarow
    /// </summary>
    class SizeAndPositionConverter : BaseValueConverter<SizeAndPositionConverter>
    {

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double intersectionSize = (double)value;
            double divider = double.Parse(parameter.ToString(), culture);
            return intersectionSize / divider;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
