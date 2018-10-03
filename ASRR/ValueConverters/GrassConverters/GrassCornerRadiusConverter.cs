using ASRR.Core;
using System;
using System.Globalization;
using System.Windows;

namespace ASRR
{
    /// <summary>
    /// konwertuje true/false widocznosci strefy trawy na promien ich rogow
    /// </summary>
    class GrassCornerRadiusConverter : BaseValueConverter<GrassCornerRadiusConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool direction = (bool)value;
            Grass grass = (Grass)parameter;

            if (grass == Grass.LeftBottom) return direction ? new CornerRadius(0, 40, 0, 0) : new CornerRadius(0, 0, 0, 0);            
            else return direction ? new CornerRadius(40, 0, 0, 0) : new CornerRadius(0, 0, 0, 0);

        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
