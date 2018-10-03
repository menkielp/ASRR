using ASRR.Core;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ASRR
{
    /// <summary>
    /// Interaction logic for Vehicle.xaml
    /// </summary>
    public partial class VehicleControl : UserControl
    {

        #region Constructor

        public VehicleControl(Lane lane, VehicleType vehicleType, string vehicleColor)
        {
            InitializeComponent();

            //powiazanie kontekstu
            vehicleVM = new VehicleViewModel(lane, vehicleType, vehicleColor);
            DataContext = vehicleVM;

            //animacje dla pojazdu
            MoveVehicle = new MoveVehicleAnimation(this, vehicleVM.Lane);

            //dodanie zdarzenia poruszania myszki
            this.MouseMove += VehicleControl_MouseMove;
        }

        #endregion

        #region Private Members

        /// <summary>
        /// Pas na ktorym znajduje sie pojazd
        /// </summary>
        private VehicleViewModel vehicleVM;

        #endregion

        #region Public Properties

        public MoveVehicleAnimation MoveVehicle { get; private set; }

        #endregion

        #region Event Methods

        /// <summary>
        /// jesli lewy przycisk jest przycisniety umozliwenie dragdropu pojazdu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VehicleControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.MouseDevice.LeftButton == MouseButtonState.Pressed)
            {
                List<HorizontalRoadSign> listOfDirections = new List<HorizontalRoadSign>();

                //pobranie kierunkow w ktore moze poruszac sie pojazd na danym pasie
                if (vehicleVM.Lane == Lane.Lane1) listOfDirections = DI.laneDirectionPickerVM.CurrentDirectionLane1.DirectionsOnLane();
                else if(vehicleVM.Lane == Lane.Lane2) listOfDirections = DI.laneDirectionPickerVM.CurrentDirectionLane2.DirectionsOnLane();
                else if (vehicleVM.Lane == Lane.Lane3) listOfDirections = DI.laneDirectionPickerVM.CurrentDirectionLane3.DirectionsOnLane();
                else if (vehicleVM.Lane == Lane.Lane4) listOfDirections = DI.laneDirectionPickerVM.CurrentDirectionLane4.DirectionsOnLane();

                //tworzenie odpowiednich stref w zaleznosci od kierunkow w ktore moze poruszac sie pojazd
                foreach(HorizontalRoadSign roadSign in listOfDirections)
                {
                    if (roadSign == HorizontalRoadSign.Lewo) DI.dataPickerVM.DepartureArea = DepartureArea.CreateLeft;
                    if (roadSign == HorizontalRoadSign.Prosto) DI.dataPickerVM.DepartureArea = DepartureArea.CreateTop;
                    if (roadSign == HorizontalRoadSign.Prawo) DI.dataPickerVM.DepartureArea = DepartureArea.CreateRight;
                }
                VehicleControl vehicle = sender as VehicleControl;

                //DragDrop pojazdu
                DragDrop.DoDragDrop(vehicle, vehicleVM, DragDropEffects.Move);

                //po zakonczeniu operacji usuwamy strefy DROP
                DI.dataPickerVM.DepartureArea = DepartureArea.Remove;

            }
        }

        #endregion

        
    }
}
