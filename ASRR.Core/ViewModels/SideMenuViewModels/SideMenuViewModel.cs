using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ASRR.Core
{
    /// <summary>
    /// ViewModel dla bocznego menu
    /// </summary>
    public class SideMenuViewModel : BaseViewModel
    {
        #region Constructor

        /// <summary>
        /// Domyslny konstruktor
        /// </summary>
        public SideMenuViewModel()
        {
            ResetInletCommand = new RelayCommand(ResetInlet);
            StartCollectDataCommand = new RelayCommand(StartCollectData);

        }

        #endregion

        #region Private Members

        private ObservableCollection<Inlet> inletCollection = InletHelper.GetInletCollection();

        #endregion

        #region Public Properties

        /// <summary>
        /// wybrany wlot
        /// </summary>
        public Inlet SelectedInlet { get; set; } = Inlet.A;

        /// <summary>
        /// Kolekcja wszystkich mozliwych wlotow
        /// </summary>
        public ObservableCollection<Inlet> InletCollection { get { return inletCollection; } }

        /// <summary>
        /// Animacja ktora bedzie wykonywana na SideMenuControl
        /// </summary>
        public Animation DoAnimation { get; set; } = Animation.None;

        /// <summary>
        /// Sygnalizacja swietlna
        /// </summary>
        public bool TrafficLightChecked { get; set; } = false;

        #endregion

        #region Public Commands

        /// <summary>
        /// Resetowanie wlotu
        /// </summary>
        public ICommand ResetInletCommand { get; private set; }

        /// <summary>
        /// Rozpoczecie zbierania danych
        /// </summary>
        public ICommand StartCollectDataCommand { get; private set; }

        #endregion

        #region Command Methods

        /// <summary>
        /// Resetowanie wlotu
        /// </summary>
        private void ResetInlet()
        {
            DI.laneDirectionPickerVM.NumberOfLanes = 0;
            DI.laneDirectionPickerVM.CurrentDirectionLane1 = HorizontalRoadSign.None;
            SelectedInlet = Inlet.A;
        }

        /// <summary>
        /// Przejscie do zbierania danych
        /// </summary>
        private void StartCollectData()
        {
            DoAnimation = Animation.SladeOutToLeft;
            DI.dataPickerVM.DoAnimation = Animation.FadeIn;
            DI.clockVM.StartCollectData();
        }

        #endregion

    }
}
