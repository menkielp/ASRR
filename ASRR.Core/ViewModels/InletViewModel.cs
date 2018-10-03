using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASRR.Core
{
    public class InletViewModel : BaseViewModel
    {
        #region Constructor
        
        public InletViewModel()
        {
            DI.laneDirectionPickerVM.InletChanged += Update;
        }

        #endregion
        
        #region Public Properties

        /// <summary>
        /// obecna liczba pasow na wlocie
        /// </summary>
        public int NumberOfLanes { get; private set; } = 0;
        
        /// <summary>
        /// Obecnie wybrany kierunek na pasie pierwszym
        /// </summary>
        public HorizontalRoadSign CurrentDirectionLane1 { get; private set; }

        /// <summary>
        /// Obecnie wybrany kierunek na pasie pierwszym
        /// </summary>
        public HorizontalRoadSign CurrentDirectionLane2 { get; private set; }

        /// <summary>
        /// Obecnie wybrany kierunek na pasie pierwszym
        /// </summary>
        public HorizontalRoadSign CurrentDirectionLane3 { get; private set; }

        /// <summary>
        /// Obecnie wybrany kierunek na pasie pierwszym
        /// </summary>
        public HorizontalRoadSign CurrentDirectionLane4 { get; private set; }

        /// <summary>
        /// linie na lewym wylocie
        /// </summary>
        public bool LeftOutletVisibility { get; private set; } = false;

        /// <summary>
        /// linie na prawym wylocie
        /// </summary>
        public bool RightOutletVisibility { get; private set; } = false;

        /// <summary>
        /// linie na wylocie na wprost
        /// </summary>
        public bool StraightOutletVisibility { get; private set; } = false;
        
        #endregion

        #region Private Methods

        /// <summary>
        /// akutalizacja liczby pasow i kierunkow na nich
        /// </summary>
        private void Update()
        {
            NumberOfLanes = DI.laneDirectionPickerVM.NumberOfLanes;
            CurrentDirectionLane1 = DI.laneDirectionPickerVM.CurrentDirectionLane1;
            CurrentDirectionLane2 = DI.laneDirectionPickerVM.CurrentDirectionLane2;
            CurrentDirectionLane3 = DI.laneDirectionPickerVM.CurrentDirectionLane3;
            CurrentDirectionLane4 = DI.laneDirectionPickerVM.CurrentDirectionLane4;
            UpdateLinesVisibility();
        }

        /// <summary>
        /// jesli dany kierunek jest wybrany to na wlocie pokazywane sa jego linie
        /// </summary>
        private void UpdateLinesVisibility()
        {
            List<HorizontalRoadSign> currentDirectionOnLanes = new List<HorizontalRoadSign>() { CurrentDirectionLane1,
                                                           CurrentDirectionLane2,
                                                           CurrentDirectionLane3,
                                                           CurrentDirectionLane4 };
            currentDirectionOnLanes.CurrentDirections();
            
            LeftOutletVisibility = currentDirectionOnLanes.Contains(HorizontalRoadSign.Lewo) ||
                                   currentDirectionOnLanes.Contains(HorizontalRoadSign.Zawracanie) ? true : false;
            RightOutletVisibility = currentDirectionOnLanes.Contains(HorizontalRoadSign.Prawo) ? true : false;
            StraightOutletVisibility = currentDirectionOnLanes.Contains(HorizontalRoadSign.Prosto) ? true : false;

        }              

        #endregion
    }
}
