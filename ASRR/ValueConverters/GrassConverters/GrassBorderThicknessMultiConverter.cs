using ASRR.Core;
using System;
using System.Globalization;
using System.Windows;

namespace ASRR
{
    /// <summary>
    /// konwertuje true/false widocznosci strefy trawy na grubosc krawedzi
    /// </summary>
    class GrassBorderThicknessMultiConverter : BaseMultiValueConverter<GrassBorderThicknessMultiConverter>
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            bool directionStraight = (bool)values[0];
            bool directionTurn = (bool)values[1];
            Grass grass = (Grass)parameter;
            
            if (grass == Grass.LeftTop)
            {
                if(directionStraight == true)
                {
                    if (directionTurn == true)
                        return new Thickness(0, 0, 2, 2);

                    return new Thickness(0, 0, 2, 0);
                }
                else
                {
                    if (directionTurn == true)
                        return new Thickness(0, 0, 0, 2);

                    return new Thickness(0, 0, 0, 0);
                }
            }
            
            if (grass == Grass.RightTop)
            {
                if (directionStraight == true)
                {
                    if (directionTurn == true)
                        return new Thickness(2, 0, 0, 2);

                    return new Thickness(2, 0, 0, 0);
                }
                else
                {
                    if (directionTurn == true)
                        return new Thickness(0, 0, 0, 2);

                    return new Thickness(0, 0, 0, 0);
                }
            }

            return new Thickness(0, 0, 0, 0);
        }

        public override object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
