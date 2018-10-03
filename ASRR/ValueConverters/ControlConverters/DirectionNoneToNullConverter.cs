using ASRR.Core;
using System;
using System.Globalization;
using System.Windows;

namespace ASRR
{
    /// <summary>
    /// konweter <see cref="HorizontalRoadSign.None"/> na null
    /// </summary>
    class DirectionNoneToNullConverter : BaseValueConverter<DirectionNoneToNullConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            HorizontalRoadSign horizontalRoadSign = (HorizontalRoadSign)value;

            if (horizontalRoadSign == HorizontalRoadSign.None) return null;
            else return horizontalRoadSign;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return HorizontalRoadSign.None;
            else return (HorizontalRoadSign)value;
        }
    }
}
