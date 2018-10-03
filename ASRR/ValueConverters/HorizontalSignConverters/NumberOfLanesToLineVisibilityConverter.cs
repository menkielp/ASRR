using ASRR.Core;
using System;
using System.Globalization;
using System.Windows;

namespace ASRR
{
    /// <summary>
    /// konwertuje liczbe pasow na wlocie do widocznosci linii pomiedzy tymi pasami
    /// </summary>
    class NumberOfLanesToLineVisibilityConverter : BaseValueConverter<NumberOfLanesToLineVisibilityConverter>
    {

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int numberOfLanes = (int)value + 1;
            HorizontalLine line = (HorizontalLine)parameter;
            
            if (numberOfLanes == 1) return Visibility.Collapsed;
            else if (numberOfLanes == 2)
            {
                if (line == HorizontalLine.Middle) return Visibility.Visible;
                return Visibility.Hidden;
            }
            else if (numberOfLanes == 3)
            {
                if (line == HorizontalLine.InnerLeft || line == HorizontalLine.InnerRight) return Visibility.Visible;
                return Visibility.Collapsed;
            }
            else
            {
                if (line == HorizontalLine.Middle || 
                    line == HorizontalLine.FirstOnLeftFromMiddle ||
                    line == HorizontalLine.FirstOnRightFromMiddle) return Visibility.Visible;
                return Visibility.Collapsed;
            }


        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
