using ASRR.Core;
using System;
using System.Globalization;
using System.Windows;

namespace ASRR
{
    /// <summary>
    /// konwertuje true/false widocznosci strefy trawy na promien ich rogow
    /// </summary>
    class GrassCornerRadiusMultiConverter : BaseMultiValueConverter<GrassCornerRadiusMultiConverter>
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            bool directionStraight = (bool)values[0];            
            bool directionTurn = (bool)values[1];            
            Grass grass = (Grass)parameter;
            
            if (grass == Grass.LeftTop)
                return (directionStraight && directionTurn) ? new CornerRadius(0, 0, 40, 0) : new CornerRadius(0, 0, 0, 0);
            else
                return (directionStraight && directionTurn) ? new CornerRadius(0, 0, 0, 40) : new CornerRadius(0, 0, 0, 0);
        }


        public override object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
