using ASRR.Core;
using System;
using System.Globalization;
using System.Windows;

namespace ASRR
{
    /// <summary>
    /// Konwersja istnienia pasa na to czy bedzie przycisk pokazany na wlocie
    /// </summary>
    class LaneExistToButtonVisibilityConverter : BaseValueConverter<LaneExistToButtonVisibilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            HorizontalRoadSign roadSign = (HorizontalRoadSign)value;
        
            if (roadSign == HorizontalRoadSign.None) return Visibility.Collapsed;
            else return Visibility.Visible;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
