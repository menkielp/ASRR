using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASRR.Core
{
    /// <summary>
    /// Przechowywalnia pojazdow obecnych na wlocie
    /// </summary>
    public static class VehicleStorage
    {

        #region Public Properties

        /// <summary>
        /// Pojazdy obecne na wlocie
        /// </summary>
        public static List<List<VehicleViewModel>> VehiclesOnLanes { get; set; } = new List<List<VehicleViewModel>>()
        {
            new List<VehicleViewModel>(),
            new List<VehicleViewModel>(),
            new List<VehicleViewModel>(),
            new List<VehicleViewModel>()
        };

        /// <summary>
        /// Pojazdy ktore przyjechaly na wlot od rozpoaczecia ankietowania
        /// </summary>
        public static List<List<VehicleViewModel>> VehiclesOnLanesFromStart { get; set; } = new List<List<VehicleViewModel>>()
        {
            new List<VehicleViewModel>(),
            new List<VehicleViewModel>(),
            new List<VehicleViewModel>(),
            new List<VehicleViewModel>()
        };

        #endregion

        #region Public Methods

        /// <summary>
        /// Dodanie pojazdu do listy z odpowiednim pasem
        /// </summary>
        /// <param name="lane">pas na ktorym jest pojazd</param>
        /// <param name="vehicleVM">ViewModel pojazdu</param>
        public static void AddVehicle(VehicleViewModel vehicleVM, Lane lane)
        {
            switch(lane)
            {
                case Lane.Lane1:
                    {
                        VehiclesOnLanes[0].Add(vehicleVM);
                        VehiclesOnLanesFromStart[0].Add(vehicleVM);
                        break;
                    }
                case Lane.Lane2:
                    {
                        VehiclesOnLanes[1].Add(vehicleVM);
                        VehiclesOnLanesFromStart[1].Add(vehicleVM);
                        break;
                    }
                case Lane.Lane3:
                    {
                        VehiclesOnLanes[2].Add(vehicleVM);
                        VehiclesOnLanesFromStart[2].Add(vehicleVM);
                        break;
                    }
                case Lane.Lane4:
                    {
                        VehiclesOnLanes[3].Add(vehicleVM);
                        VehiclesOnLanesFromStart[3].Add(vehicleVM);
                        break;
                    }
                default: break;
            }
        }

        /// <summary>
        /// Usuniecie pierwszego pojazdu z danego pasa
        /// </summary>
        /// <param name="lane"></param>
        public static void RemoveVehicle(Lane lane)
        {
            switch(lane)
            {
                case Lane.Lane1:
                    {
                        VehiclesOnLanes[0].RemoveAt(0);
                        break;
                    }
                case Lane.Lane2:
                    {
                        VehiclesOnLanes[1].RemoveAt(0);
                        break;
                    }
                case Lane.Lane3:
                    {
                        VehiclesOnLanes[2].RemoveAt(0);
                        break;
                    }
                case Lane.Lane4:
                    {
                        VehiclesOnLanes[3].RemoveAt(0);
                        break;
                    }
                default: break;
            }
        }

        /// <summary>
        /// Pobranie calego pasa z pojazdami
        /// </summary>
        /// <param name="lane"></param>
        public static List<VehicleViewModel> GetLane(Lane lane)
        {
            switch(lane)
            {
                case Lane.Lane1:
                    {
                        return VehiclesOnLanes[0];
                    }
                case Lane.Lane2:
                    {
                        return VehiclesOnLanes[1];
                    }
                case Lane.Lane3:
                    {
                        return VehiclesOnLanes[2];
                    }
                case Lane.Lane4:
                    {
                        return VehiclesOnLanes[3];
                    }
                default:break;
            }

            return new List<VehicleViewModel>();
        }

        /// <summary>
        /// Pobranie calego pasa z pojazdami
        /// </summary>
        /// <param name="lane"></param>
        public static List<VehicleViewModel> GetLaneFromStart(Lane lane)
        {
            switch (lane)
            {
                case Lane.Lane1:
                    {
                        return VehiclesOnLanesFromStart[0];
                    }
                case Lane.Lane2:
                    {
                        return VehiclesOnLanesFromStart[1];
                    }
                case Lane.Lane3:
                    {
                        return VehiclesOnLanesFromStart[2];
                    }
                case Lane.Lane4:
                    {
                        return VehiclesOnLanesFromStart[3];
                    }
                default: break;
            }

            return new List<VehicleViewModel>();
        }

        /// <summary>
        /// Pobranie pierwszego pojazdu na pasie
        /// </summary>
        /// <param name="lane"></param>
        /// <returns></returns>
        public static VehicleViewModel GetFirstOnLane(Lane lane)
        {
            switch (lane)
            {
                case Lane.Lane1:
                    {
                        return (VehiclesOnLanes[0])[0];
                    }
                case Lane.Lane2:
                    {
                        return (VehiclesOnLanes[1])[0];
                    }
                case Lane.Lane3:
                    {
                        return (VehiclesOnLanes[2])[0];
                    }
                case Lane.Lane4:
                    {
                        return (VehiclesOnLanes[3])[0];
                    }
                default: break;
            }

            return null;
        }

        #endregion

    }
}
