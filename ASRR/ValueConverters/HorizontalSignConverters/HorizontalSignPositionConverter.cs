using ASRR.Core;
using System;
using System.Globalization;
using System.Windows;

namespace ASRR
{
    /// <summary>
    /// konwerter do okreslenia pozycji znakow poziomych na wlocie
    /// </summary>
    class HorizontalSignPositionConverter : BaseMultiValueConverter<HorizontalSignPositionConverter>
    {

        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Lane lane = (Lane)parameter;
            double inletWidth = (double)values[0];
            int NumberOfLanes = (int)values[1] + 1;
            
            if (lane == Lane.Lane1)
            {
                if (NumberOfLanes == 1) return new Thickness((inletWidth / 2) - 10, 160, 0, 0);
                else if (NumberOfLanes == 2) return new Thickness((inletWidth / 2) - 32, 160, 0, 0);
                else if (NumberOfLanes == 3) return new Thickness((inletWidth / 2) - 54, 160, 0, 0);
                else return new Thickness((inletWidth / 2) - 76, 160, 0, 0);
            }
            else if (lane == Lane.Lane2)
            {
                if (NumberOfLanes == 2) return new Thickness((inletWidth / 2) + 10 , 160, 0, 0);
                else if (NumberOfLanes == 3) return new Thickness((inletWidth / 2) - 10, 160, 0, 0);
                else return new Thickness((inletWidth / 2) - 32, 160, 0, 0);
            }
            else if (lane == Lane.Lane3)
            {
                if (NumberOfLanes == 3) return new Thickness((inletWidth / 2) + 32, 160, 0, 0);
                else return new Thickness((inletWidth / 2) + 10, 160, 0, 0);
            }
            else
            {
                return new Thickness((inletWidth / 2) + 54, 160, 0, 0);
            }

        }

        public override object[] ConvertBack(object values, Type[] targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
