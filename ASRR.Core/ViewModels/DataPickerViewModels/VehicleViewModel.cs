using System;

namespace ASRR.Core
{
    /// <summary>
    /// ViewModel pojazdu
    /// </summary>
    public class VehicleViewModel : BaseViewModel
    {

        #region Constructor

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="lane">pas na ktorym jest pojazd</param>
        /// <param name="vehicleType">typ pojazdu</param>
        /// <param name="vehicleColor">kolor pojazdu</param>
        public VehicleViewModel(Lane lane, VehicleType vehicleType, string vehicleColor)
        {
            VehicleStorage.AddVehicle(this, lane);

            Lane = lane;
            Type = vehicleType;
            Color = vehicleColor;
            ArrivalTime = DateTime.Now;
            Enabled = VehicleStorage.GetLane(lane).Count - 1 > 0 ? false : true;
            QueuePosition = VehicleStorage.GetLane(lane).Count;           
        }

        #endregion

        #region Private Members

        /// <summary>
        /// Wysokosc pojazdu
        /// </summary>
        private double vehicleHeight = 40;

        /// <summary>
        /// Szerokosc pojazdu
        /// </summary>
        private double vehicleWidth = 30;

        /// <summary>
        /// Tryb pojazdu
        /// </summary>
        private VehicleMode mode = VehicleMode.Arrival;

        #endregion

        #region Public Properties

        /// <summary>
        /// Pas na ktorym jest pojazd
        /// </summary>
        public Lane Lane { get; private set; }

        /// <summary>
        /// Typ pojazdu
        /// </summary>
        public VehicleType Type { get; private set; }

        /// <summary>
        /// Napis na pojezdzie
        /// </summary>
        public string VehicleCaption => Type.ToString();

        /// <summary>
        /// Color pojazdu
        /// </summary>
        public string Color { get; private set; }

        /// <summary>
        /// Wysokosc pojazdu
        /// </summary>
        public double VehicleHeight => vehicleHeight;

        /// <summary>
        /// Szerokosc pojazdu
        /// </summary>
        public double VehicleWidth => vehicleWidth;

        /// <summary>
        /// Czas przybycia pojazdu
        /// </summary>
        public DateTime ArrivalTime { get; private set; }
        
        /// <summary>
        /// Czas odjazdu pojazdu 
        /// </summary>
        public DateTime DepartureTime { get; set; }

        /// <summary>
        /// Tryb pojazdu
        /// </summary>
        public VehicleMode Mode
        {
            get => mode;
            set
            {
                if((VehicleMode)value == VehicleMode.Departure)
                    SaveDataOnDeparture();
                mode = (VehicleMode)value;
            }
        }

        /// <summary>
        /// Pojazd aktywny
        /// </summary>
        public bool Enabled { get; set; } 

        /// <summary>
        /// Pozycja pojazdu w kolejce
        /// </summary>
        public int QueuePosition { get; set; }

        /// <summary>
        /// Wybrany kierunek jazdy
        /// </summary>
        public HorizontalRoadSign DirectionPicked { get; set; } = HorizontalRoadSign.None;

        #endregion

        #region Private Methods

        /// <summary>
        /// Zapisanie danych z odjazdu do pliku
        /// </summary>
        private void SaveDataOnDeparture()
        {
            string dataToSave = ArrivalTime.ToString("T") + ";" + DepartureTime.ToString("T") + ";" + Type + ";" +
                               Lane + ";"  + DirectionPicked + Environment.NewLine;

            DI.clockVM.DataToSave(dataToSave);
        }

        #endregion
    }
}
