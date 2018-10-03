using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ASRR.Core
{
    /// <summary>
    /// Statystyki
    /// </summary>
    public class StatViewModel : BaseViewModel
    {
        
        #region Public Properties

        /// <summary>
        /// Opis pierwszego pasa
        /// </summary>
        public string DirectionLane1 => DI.laneDirectionPickerVM.CurrentDirectionLane1 == HorizontalRoadSign.None ? 
                                        String.Empty : DI.laneDirectionPickerVM.CurrentDirectionLane1.ToString();

        /// <summary>
        /// Opis pierwszego pasa
        /// </summary>
        public string DirectionLane2 => DI.laneDirectionPickerVM.CurrentDirectionLane2 == HorizontalRoadSign.None ? 
                                        String.Empty : DI.laneDirectionPickerVM.CurrentDirectionLane2.ToString();

        /// <summary>
        /// Opis pierwszego pasa
        /// </summary>
        public string DirectionLane3 => DI.laneDirectionPickerVM.CurrentDirectionLane3 == HorizontalRoadSign.None ? 
                                        String.Empty : DI.laneDirectionPickerVM.CurrentDirectionLane3.ToString();
        /// <summary>
        /// Opis pierwszego pasa
        /// </summary>
        public string DirectionLane4 => DI.laneDirectionPickerVM.CurrentDirectionLane4 == HorizontalRoadSign.None ? 
                                        String.Empty : DI.laneDirectionPickerVM.CurrentDirectionLane4.ToString();

        /// <summary>
        /// Zliczone pojazdy na pasie pierwszym
        /// </summary>
        public ObservableCollection<string> CountLane1 { get; private set; } = new ObservableCollection<string>()
        {
            String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty,
        };

        /// <summary>
        /// Zliczone pojazdy na pasie drugim
        /// </summary>
        public ObservableCollection<string> CountLane2 { get; private set; } = new ObservableCollection<string>()
        {
            String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty,
        };


        /// <summary>
        /// Zliczone pojazdy na pasie trzecim
        /// </summary>
        public ObservableCollection<string> CountLane3 { get; private set; } = new ObservableCollection<string>()
        {
            String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty,
        };

        /// <summary>
        /// Zliczone pojazdy na pasie czwartym
        /// </summary>
        public ObservableCollection<string> CountLane4 { get; private set; } = new ObservableCollection<string>()
        {
            String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty,
        };

        #endregion

        #region Public Methods

        /// <summary>
        /// Aktualizowanie statystyk
        /// </summary>
        /// <param name="lane"></param>
        public void Update(Lane lane)
        {

            for (int i = 1; i < 9; i++)
            {
                string amount = VehicleCount(lane, (VehicleType)i, VehicleStorage.GetLane(lane));
                string amountFromStart = VehicleCount(lane, (VehicleType)i, VehicleStorage.GetLaneFromStart(lane));

                if (lane == Lane.Lane1)
                    CountLane1[i - 1] = amount + " (" + amountFromStart + ")";
                
                if (lane == Lane.Lane2)  
                    CountLane2[i - 1] = amount + " (" + amountFromStart + ")";

                if (lane == Lane.Lane3)           
                    CountLane3[i - 1] = amount + " (" + amountFromStart + ")";

                if (lane == Lane.Lane4)              
                    CountLane4[i - 1] = amount + " (" + amountFromStart + ")";

            }

            OnPropertyChanged(nameof(DirectionLane1));
            OnPropertyChanged(nameof(DirectionLane2));
            OnPropertyChanged(nameof(DirectionLane3));
            OnPropertyChanged(nameof(DirectionLane4));
        }

        /// <summary>
        /// Zliczanie pojazdu
        /// </summary>
        /// <param name="lane">pas na ktorym jest pojazd</param>
        /// <param name="vehicleType">typ pojazdu</param>
        /// <returns></returns>
        private string VehicleCount(Lane lane, VehicleType vehicleType, List<VehicleViewModel> vehicles)
        {
            if (vehicleType != VehicleType.RAZEM)
            {                
                var il = (from vehicle in vehicles
                          where vehicle.Type == vehicleType
                          select vehicle).Count();
                return il.ToString();
            }
            else
            {
                var il = vehicles.Count();
                return il.ToString();
            }
        }

        #endregion
    }
}
