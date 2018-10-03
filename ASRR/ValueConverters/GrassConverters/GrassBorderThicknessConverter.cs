using ASRR.Core;
using System;
using System.Globalization;
using System.Windows;

namespace ASRR
{
    /// <summary>
    /// konwertuje true/false widocznosci strefy trawe na grubosc krawedzi
    /// </summary>
    class GrassBorderThicknessConverter : BaseValueConverter<GrassBorderThicknessConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool direction = (bool)value;
            Grass grass = (Grass)parameter;
            if (grass == Grass.LeftBottom) return direction ? new Thickness(0, 2, 2, 0) : new Thickness(0, 0, 2, 0);
            else return direction ? new Thickness(2, 2, 0, 0) : new Thickness(2, 0, 0, 0);
            
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
