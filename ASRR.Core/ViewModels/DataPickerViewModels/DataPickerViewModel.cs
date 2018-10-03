using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ASRR.Core
{
    /// <summary>
    /// ViewModel do kontrolki umozliwiajacej zbieranie danych
    /// </summary>
    public class DataPickerViewModel : BaseViewModel
    {

        #region Constructor
        
        public DataPickerViewModel()
        {
            ReturnCommand = new RelayCommand(Return);
            AddVehicleCommand = new RelayParameterCommand<Lane>(AddVehicle);
            CreateVehicleCommand = new RelayParameterCommand<VehicleType>(CreateVehicle);
            HelpCommand = new RelayCommand(Help);
            StatCommand = new RelayCommand(Stat);
            DimmableOverlayCommand = new RelayCommand(DimmableOvelay);
            PedestrianCommand = new RelayCommand(AddPedestrian);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Animacja do wykonania na DatePickerControl
        /// </summary>
        public Animation DoAnimation { get; set; } = Animation.None;

        /// <summary>
        /// Wlaczone/wylaczone przyciski dodawania pojazdow
        /// </summary>
        public bool AddVehicleEnabled { get; set; } = true;

        /// <summary>
        /// Typ pojazdu do dodania do wlotu
        /// </summary>
        public VehicleType Vehicle { get; set; } = VehicleType.NONE;

        /// <summary>
        /// Aktywny pas na ktory bedzie dodawany/usuwany pojazd
        /// </summary>
        public Lane ActiveLane { get; set; }

        /// <summary>
        /// Strefy zrzutu pojazdu
        /// </summary>
        public DepartureArea DepartureArea { get; set; } = DepartureArea.None;

        /// <summary>
        /// Animacja menu dodawania pojazdow
        /// </summary>
        public Animation AddVehicleAnimation { get; set; } = Animation.None;

        /// <summary>
        /// Przyciemniane pokrycie
        /// </summary>
        public bool DimmableOverlayFlag { get; set; } = false;

        /// <summary>
        /// Animacja pokrycia
        /// </summary>
        public Animation DimmableOverlayAnimation { get; set; } = Animation.None;

        /// <summary>
        /// Animacja pomocy
        /// </summary>
        public Animation HelpAnimation { get; set; } = Animation.None;

        /// <summary>
        /// Animacja statystyk
        /// </summary>
        public Animation StatAnimation { get; set; } = Animation.None;

        /// <summary>
        /// Ilosc pieszych na wlocie
        /// </summary>
        public string Pedestrian { get; set; } = "0";

        #endregion

        #region Public Commands

        /// <summary>
        /// Powrot do SideMenuControl
        /// </summary>
        public ICommand ReturnCommand { get; private set; }

        /// <summary>
        /// Dodawanie pojazdu
        /// </summary>
        public ICommand AddVehicleCommand { get; private set; }

        /// <summary>
        /// Tworzenie pojazdu
        /// </summary>
        public ICommand CreateVehicleCommand { get; private set; }

        /// <summary>
        /// Pomoc
        /// </summary>
        public ICommand HelpCommand { get; private set; }

        /// <summary>
        /// Warstwa przyciemniajaca
        /// </summary>
        public ICommand DimmableOverlayCommand { get; private set; }

        /// <summary>
        /// Statystyki
        /// </summary>
        public ICommand StatCommand { get; private set; }

        /// <summary>
        /// Dodawanie pieszych
        /// </summary>
        public ICommand PedestrianCommand { get; private set; }

        #endregion

        #region Command Methods

        /// <summary>
        /// Powrot do SideMenuControl
        /// </summary>
        private void Return()
        {            
            DimmableOverlayFlag = true;
            DimmableOverlayAnimation = Animation.LightFadeIn;
            
            DialogBoxViewModel dialog = new DialogBoxViewModel() { OkFlag = false, Text = "Czy chcesz przerwać ankiete?" };
            
            DI.dialogManager.ShowMessage(dialog);            

            if(dialog.OkFlag == true)
            {
                DoAnimation = Animation.FadeOut;
                DI.sideMenuVM.DoAnimation = Animation.SladeInFromLeft;
                DI.clockVM.StopCollectData();
                
                foreach (var lanesWithVehicles in VehicleStorage.VehiclesOnLanes)
                {
                    foreach (VehicleViewModel vehicle in lanesWithVehicles)
                    {
                        vehicle.Mode = VehicleMode.Remove;
                    }

                }
                
                VehicleStorage.VehiclesOnLanes = new List<List<VehicleViewModel>>()
                {
                    new List<VehicleViewModel>(),
                    new List<VehicleViewModel>(),
                    new List<VehicleViewModel>(),
                    new List<VehicleViewModel>()
                };

                VehicleStorage.VehiclesOnLanesFromStart = new List<List<VehicleViewModel>>()
                {
                    new List<VehicleViewModel>(),
                    new List<VehicleViewModel>(),
                    new List<VehicleViewModel>(),
                    new List<VehicleViewModel>()
                };
                
                DimmableOverlayFlag = false;
                DimmableOverlayAnimation = Animation.FadeOut;
            }                       
        }

        /// <summary>
        /// Dodawanie pojazdow
        /// </summary>
        private void AddVehicle(Lane lane)
        {
            ActiveLane = lane;
            AddVehicleEnabled = false;
            AddVehicleAnimation = Animation.SladeInFromLeft;
        }

        /// <summary>
        /// Tworzenie pojazdu
        /// </summary>
        private void CreateVehicle(VehicleType vehicleType)
        {
            Vehicle = VehicleType.NONE;
            Vehicle = vehicleType;
            AddVehicleAnimation = Animation.SladeOutToLeft;
            Task.Delay(300).ContinueWith((a) => AddVehicleEnabled = true);
        }

        /// <summary>
        /// Otwarcie pomocy
        /// </summary>
        private void Help()
        {
            DimmableOverlayFlag = true;
            DimmableOverlayAnimation = Animation.LightFadeIn;
            HelpAnimation = Animation.SladeInFromRight;

        }

        /// <summary>
        /// Warstwa przyciemniajaca
        /// </summary>
        private void DimmableOvelay()
        {
            DimmableOverlayAnimation = Animation.FadeOut;

            if(!(HelpAnimation == Animation.SladeOutToRight))
                HelpAnimation = Animation.SladeOutToRight;

            if (!(StatAnimation == Animation.SladeOutToRight))
                StatAnimation = Animation.SladeOutToRight;
            
            Task.Delay(300).ContinueWith((e) => DimmableOverlayFlag = false);
        }

        /// <summary>
        /// Statystyki
        /// </summary>
        private void Stat()
        {
            int i = 2;
            if (DI.laneDirectionPickerVM.CurrentDirectionLane2 != HorizontalRoadSign.None) i++;
            if (DI.laneDirectionPickerVM.CurrentDirectionLane3 != HorizontalRoadSign.None) i++;
            if (DI.laneDirectionPickerVM.CurrentDirectionLane4 != HorizontalRoadSign.None) i++;

            for (int j = 1; j < i; j++)
            {
                DI.statVM.Update((Lane)j);
            }
            
            DimmableOverlayFlag = true;
            StatAnimation = Animation.SladeInFromRight;
            DimmableOverlayAnimation = Animation.LightFadeIn;
            
            
        }

        /// <summary>
        /// Dodawanie pieszych
        /// </summary>
        private void AddPedestrian()
        {
            int pedestrianCount = int.Parse(Pedestrian);            
            pedestrianCount++;
            
            Pedestrian = pedestrianCount.ToString();
            
            string dataToSave = DateTime.Now.ToString("T") + ";brak;Pieszy;brak;brak" + Environment.NewLine;
            DI.clockVM.DataToSave(dataToSave);
        }

        #endregion

    }
}
