using ASRR.Core;
using System;
using System.Globalization;
using System.Windows;

namespace ASRR
{
    /// <summary>
    /// konwertuje liczbe pasow na wlocie do widocznosci ComboBox
    /// w ktorych wybierane sa kierunki na tych pasach
    /// </summary>
    class LanesToComboBoxVisibilityConverter : BaseValueConverter<LanesToComboBoxVisibilityConverter>
    {
        /// <summary>
        /// W zaleznosci od liczb pasow, pokazuje je w oknie
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {            
            Lane lane = (Lane)parameter;
            
            int numberOfLanes = (int)value + 1;

            //w zaleznosci ile jest pasow, to widoczne staja sie odpowiednie comboboxy z wyborem kierunkow na tych pasach
            if (lane == Lane.Lane2 && numberOfLanes == 2) return Visibility.Visible;
            else if ((lane == Lane.Lane3 || lane == Lane.Lane2) && numberOfLanes == 3) return Visibility.Visible;
            else if ((lane == Lane.Lane4 || lane == Lane.Lane2 || lane == Lane.Lane3) && numberOfLanes == 4) return Visibility.Visible;
            else return Visibility.Collapsed;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
