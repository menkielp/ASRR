using ASRR.Core;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ASRR
{
    /// <summary>
    /// Wlasciwosc dolaczana pozwalajaca na tworzenie pojazdow
    /// </summary>
    class VehicleProperty
    {

        #region Attached Properties
        
        /// <summary>
        /// Pobranie wlasciwosci
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static VehicleType GetCreateVehicle(DependencyObject obj)
        {
            return (VehicleType)obj.GetValue(CreateVehicleProperty);
        }

        /// <summary>
        /// Ustawienie wlasciwosci
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetCreateVehicle(DependencyObject obj, VehicleType value)
        {
            obj.SetValue(CreateVehicleProperty, value);
        }
        
        public static readonly DependencyProperty CreateVehicleProperty =
            DependencyProperty.RegisterAttached("CreateVehicle", typeof(VehicleType), typeof(VehicleProperty), new PropertyMetadata(CreateVehiclePropertyChanged));

        #endregion

        #region PropertyChanged Events

        /// <summary>
        /// Tworzenie nowego pojazdu przy zmianie wartosci
        /// </summary>
        /// <param name="d"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void CreateVehiclePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            VehicleType vehicleType = (VehicleType)e.NewValue;
            
            if (vehicleType == VehicleType.NONE)
                return;

            Grid inlet = (Grid)d;
            
            switch(vehicleType)
            {
                case VehicleType.SOD:
                {
                    VehicleControl vehicleControl = new VehicleControl(DI.dataPickerVM.ActiveLane, VehicleType.SOD, "#9acd32");
                    inlet.Children.Add(vehicleControl);
                    break;
                }

                case VehicleType.A:
                {
                    VehicleControl vehicleControl = new VehicleControl(DI.dataPickerVM.ActiveLane, VehicleType.A, "#ffff00");
                    inlet.Children.Add(vehicleControl);
                    break;
                }

                case VehicleType.AP:
                {
                    VehicleControl vehicleControl = new VehicleControl(DI.dataPickerVM.ActiveLane, VehicleType.AP, "#ffd700");
                    inlet.Children.Add(vehicleControl);
                    break;
                }

                case VehicleType.SC:
                {
                    VehicleControl vehicleControl = new VehicleControl(DI.dataPickerVM.ActiveLane, VehicleType.SC, "#daa520");
                    inlet.Children.Add(vehicleControl);
                    break;
                }

                case VehicleType.SCP:
                {
                    VehicleControl vehicleControl = new VehicleControl(DI.dataPickerVM.ActiveLane, VehicleType.SCP, "#ffa500");
                    inlet.Children.Add(vehicleControl);
                    break;
                }

                case VehicleType.MR:
                {
                    VehicleControl vehicleControl = new VehicleControl(DI.dataPickerVM.ActiveLane, VehicleType.MR, "#ff8c00");
                    inlet.Children.Add(vehicleControl);
                    break;
                }

                case VehicleType.INNE:
                {
                    VehicleControl vehicleControl = new VehicleControl(DI.dataPickerVM.ActiveLane, VehicleType.INNE, "#ff0000");
                    inlet.Children.Add(vehicleControl);
                    break;
                }
            }
            
        }

        #endregion

    }
}
