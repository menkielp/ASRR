using ASRR.Core;
using System;
using System.Globalization;

namespace ASRR
{
    /// <summary>
    /// konwertuje liczbe pasow do pozycji strefy trawy
    /// </summary>
    class NumberOfLanesToGrassSizePositionConverter : BaseMultiValueConverter<NumberOfLanesToGrassSizePositionConverter>
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int numberOfLanes = (int)values[1] + 1;
            double MiddleLinePosition = (double)values[0];
            Grass LineToConvert = (Grass)parameter;
            
            switch (numberOfLanes)
            {
                case 1:
                    {
                        if (LineToConvert == Grass.LeftBottom) return MiddleLinePosition - 22;                        
                        else if (LineToConvert == Grass.RightBottom) return MiddleLinePosition + 22;                      
                        break;
                    }
                case 2:
                    {
                        if (LineToConvert == Grass.LeftBottom) return MiddleLinePosition - 44;
                        else if (LineToConvert == Grass.RightBottom) return MiddleLinePosition + 44;
                        break;
                    }
                case 3:
                    {
                        if (LineToConvert == Grass.LeftBottom) return MiddleLinePosition - 66;
                        else if (LineToConvert == Grass.RightBottom) return MiddleLinePosition + 66;
                        break;
                    }
                case 4:
                    {
                        if (LineToConvert == Grass.LeftBottom) return MiddleLinePosition - 88;
                        else if (LineToConvert == Grass.RightBottom) return MiddleLinePosition + 88;
                        break;
                    }
                default: return MiddleLinePosition;
            }

            return MiddleLinePosition;
        }

        public override object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
