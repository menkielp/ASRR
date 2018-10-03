using ASRR.Core;
using System;
using System.Globalization;

namespace ASRR
{
    /// <summary>
    /// konwerter <see cref="HorizontalRoadSign"/> na znak ktory pojawi sie na danym pasie
    /// </summary>
    class NumberOfLanesToDirectionImageConverter : BaseValueConverter<NumberOfLanesToDirectionImageConverter>
    {

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            HorizontalRoadSign direction = (HorizontalRoadSign)value;
            
            if (direction == HorizontalRoadSign.Lewo)
            {
                return new Uri("pack://application:,,,/Images/HorizontalSigns/Lewo.png", UriKind.Absolute);
            }
            else if (direction == HorizontalRoadSign.LewoProsto)
            {
                return new Uri("pack://application:,,,/Images/HorizontalSigns/LewoProsto.png", UriKind.Absolute);
            }
            else if (direction == HorizontalRoadSign.Prosto)
            {
                return new Uri("pack://application:,,,/Images/HorizontalSigns/Prosto.png", UriKind.Absolute);
            }
            else if (direction == HorizontalRoadSign.PrawoProsto)
            {
                return new Uri("pack://application:,,,/Images/HorizontalSigns/PrawoProsto.png", UriKind.Absolute);
            }
            else if (direction == HorizontalRoadSign.Prawo)
            {
                return new Uri("pack://application:,,,/Images/HorizontalSigns/Prawo.png", UriKind.Absolute);
            }
            else if (direction == HorizontalRoadSign.LewoPrawo)
            {
                return new Uri("pack://application:,,,/Images/HorizontalSigns/LewoPrawo.png", UriKind.Absolute);
            }
            else if (direction == HorizontalRoadSign.LewoPrawoProsto)
            {
                return new Uri("pack://application:,,,/Images/HorizontalSigns/LewoPrawoProsto.png", UriKind.Absolute);
            }
            else if (direction == HorizontalRoadSign.Zawracanie)
            {
                return new Uri("pack://application:,,,/Images/HorizontalSigns/Zawracanie.png", UriKind.Absolute);
            }
            else if (direction == HorizontalRoadSign.ZawracanieProsto)
            {
                return new Uri("pack://application:,,,/Images/HorizontalSigns/ZawracanieProsto.png", UriKind.Absolute);
            }
            else return null;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
