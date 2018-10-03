using ASRR.Core;
using System.Windows;
using System.Windows.Controls;

namespace ASRR
{
    /// <summary>
    /// Operowanie na trybach pojazdu
    /// </summary>
    class VehicleModeProperty
    {

        #region Attached Properties

        /// <summary>
        /// Pobranie wartosci
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static VehicleMode GetMode(DependencyObject obj)
        {
            return (VehicleMode)obj.GetValue(ModeProperty);
        }

        /// <summary>
        /// Ustawienie wartosci
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetMode(DependencyObject obj, VehicleMode value)
        {
            obj.SetValue(ModeProperty, value);
        }

        public static readonly DependencyProperty ModeProperty =
            DependencyProperty.RegisterAttached("Mode", typeof(VehicleMode), typeof(VehicleModeProperty), new PropertyMetadata(default(VehicleMode), null, ModePropertyChanged));

        #endregion

        #region PropertyChanged Events
        

        /// <summary>
        /// Zmiana wartosci <see cref="ModeProperty"/>
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        public static object ModePropertyChanged(DependencyObject o, object e)
        {
            VehicleMode mode = (VehicleMode)e;
            
            if (mode == VehicleMode.None)
                return e;
            
            VehicleControl vehicleControl = (VehicleControl)o;

            switch(mode)
            {
                case VehicleMode.Arrival:
                    {
                        vehicleControl.MoveVehicle.MoveOnArrival();
                        break;
                    }
                case VehicleMode.Departure:
                    {                        
                        VehicleViewModel vehicleVM = (VehicleViewModel)vehicleControl.DataContext;
                        
                        vehicleControl.MoveVehicle.MoveOnDeparture(vehicleVM.Lane, DI.laneDirectionPickerVM.NumberOfLanes + 1, vehicleVM.DirectionPicked);
                        
                        VehicleStorage.RemoveVehicle(vehicleVM.Lane);

                        //jesli jeszcze jest jakis pojazd na wlocie to pierwszemu jest wlaczany
                        //aby umozliwic operacje DragDrop
                        if(VehicleStorage.GetLane(vehicleVM.Lane).Count > 0)
                            VehicleStorage.GetFirstOnLane(vehicleVM.Lane).Enabled = true;

                        //ustawienie trybu kazdego pojazdu na VehicleMode.Lane, aby poruszyl sie na pasie
                        //gdy ten pojazd odjedzie
                        foreach (VehicleViewModel VM in VehicleStorage.GetLane(vehicleVM.Lane))
                        {
                            VM.QueuePosition -= 1;

                            VM.Mode = VehicleMode.None;
                            VM.Mode = VehicleMode.Lane;
                        }
                        
                        break;
                    }
                case VehicleMode.Lane:
                    {
                        vehicleControl.MoveVehicle.MoveOnLane();
                        break;
                    }
                case VehicleMode.Remove:
                    {
                        (vehicleControl.Parent as Grid).Children.Remove(vehicleControl);
                        break;
                    }
                
                default: break;
            }                       
            
            return e;
        }

        #endregion

    }
}
