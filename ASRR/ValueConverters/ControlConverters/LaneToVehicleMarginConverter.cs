using ASRR.Core;
using System;
using System.Globalization;
using System.Windows;

namespace ASRR
{
    /// <summary>
    /// konweter liczby pasow oraz pasa na ktorym znajduje sie dany pojazd
    /// do jego polozenia na wlocie
    /// </summary>
    class LaneToVehicleMarginConverter : BaseValueConverter<LaneToVehicleMarginConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Lane lane = (Lane)value;            
            int numberOfLanes = DI.laneDirectionPickerVM.NumberOfLanes + 1;
            
            double marginTop = Application.Current.MainWindow.ActualHeight - 40 > 160 + ((VehicleStorage.GetLane(lane).Count - 1) * 50) ?
                               Application.Current.MainWindow.ActualHeight + 10 : 160 + (VehicleStorage.GetLane(lane).Count * 50);

            switch (lane)
            {
                case Lane.Lane1:
                    {
                        if (numberOfLanes == 1)
                            return new Thickness(0, marginTop, 0, 0);
                        else if (numberOfLanes == 2)
                            return new Thickness(-44, marginTop, 0, 0);
                        else if (numberOfLanes == 3)
                            return new Thickness(-88, marginTop, 0, 0);
                        else if (numberOfLanes == 4)
                            return new Thickness(-132, marginTop, 0, 0);
                        break;
                    }
                case Lane.Lane2:
                    {
                        if (numberOfLanes == 2)
                            return new Thickness(44, marginTop, 0, 0);
                        else if (numberOfLanes == 3)
                            return new Thickness(0, marginTop, 0, 0);
                        else if (numberOfLanes == 4)
                            return new Thickness(-44, marginTop, 0, 0);
                        break;
                    }
                case Lane.Lane3:
                    {
                        if (numberOfLanes == 3)
                            return new Thickness(88, marginTop, 0, 0);
                        else if (numberOfLanes == 4)
                            return new Thickness(44, marginTop, 0, 0);
                        break;
                    }
                case Lane.Lane4:
                    {
                        if (numberOfLanes == 4)
                            return new Thickness(132, marginTop, 0, 0);
                        break;
                    }
            }

            return new Thickness(0);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
