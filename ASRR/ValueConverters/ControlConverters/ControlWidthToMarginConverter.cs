using System;
using System.Globalization;
using System.Windows;

namespace ASRR
{
    /// <summary>
    /// Konwerter jednostek do minusowego prawego marginesu
    /// </summary>
    class ControlWidthToMarginConverter : BaseValueConverter<ControlWidthToMarginConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null)
                return new Thickness(-(double)value, 0, 0, 0);
            else
                return new Thickness(0, 10, -(double)value, 0);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
