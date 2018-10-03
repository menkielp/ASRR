using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ASRR.Core
{
    public class LaneDirectionPickerViewModel : BaseViewModel
    {

        #region Private members

        /// <summary>
        /// obecna liczba pasow na wlocie
        /// </summary>
        private int numberOfLanes = 0;
        
        /// <summary>
        /// liczba pasow przed zmiana
        /// </summary>
        private int numberOfLanesBeforeChange;

        /// <summary>
        /// liczba pasow po zmianie
        /// </summary>
        private int numberOfLanesAfterChange;

        /// <summary>
        /// Kolekcja przechowujaca kierunki możliwe do wyboru na pasie pierwszym w danym momencie
        /// </summary>
        private ObservableCollection<HorizontalRoadSign> lane1 = InletHelper.GetRoadSigns();

        /// <summary>
        /// Kolekcja przechowujaca kierunki możliwe do wyboru na pasie drugim w danym momencie
        /// </summary>
        private ObservableCollection<HorizontalRoadSign> lane2 = InletHelper.GetRoadSigns();

        /// <summary>
        /// Kolekcja przechowujaca kierunki możliwe do wyboru na pasie trzecim w danym momencie
        /// </summary>
        private ObservableCollection<HorizontalRoadSign> lane3 = InletHelper.GetRoadSigns();

        /// <summary>
        /// Kolekcja przechowujaca kierunki możliwe do wyboru na pasie czwartym w danym momencie
        /// </summary>
        private ObservableCollection<HorizontalRoadSign> lane4 = InletHelper.GetRoadSigns();

        /// <summary>
        /// Obecnie wybrany kierunek na pasie pierwszym
        /// </summary>
        private HorizontalRoadSign currentDirectionLane1 = HorizontalRoadSign.None;

        /// <summary>
        /// Obecnie wybrany kierunek na pasie drugim
        /// </summary>
        private HorizontalRoadSign currentDirectionLane2 = HorizontalRoadSign.None;

        /// <summary>
        /// Obecnie wybrany kierunek na pasie trzecim
        /// </summary>
        private HorizontalRoadSign currentDirectionLane3 = HorizontalRoadSign.None;

        /// <summary>
        /// Obecnie wybrany kierunek na pasie czwartym
        /// </summary>
        private HorizontalRoadSign currentDirectionLane4 = HorizontalRoadSign.None;

        /// <summary>
        /// flaga okreslajaca czy mozna zaaktualizowac kierunki na pasie
        /// </summary>
        private bool canUpdate = true;

        #endregion

        #region Public Properties

        /// <summary>
        /// obecna liczba pasow na wlocie
        /// </summary>
        public int NumberOfLanes
        {
            get => numberOfLanes;
            set
            {
                numberOfLanesBeforeChange = numberOfLanes + 1;
                numberOfLanes = value;
                numberOfLanesAfterChange = numberOfLanes + 1;
                NumberOfLanesChanged();
                InletChanged();
            }
        }        

        /// <summary>
        /// Kolekcja zwracajaca kierunki możliwe do wyboru na pasie pierwszym w danym momencie
        /// </summary>
        public ObservableCollection<HorizontalRoadSign> Lane1 => lane1;
       
        /// <summary>
        /// Kolekcja zwracajaca kierunki możliwe do wyboru na pasie drugim w danym momencie
        /// </summary>
        public ObservableCollection<HorizontalRoadSign> Lane2 => lane2;

        /// <summary>
        /// Kolekcja zwracajaca kierunki możliwe do wyboru na pasie trzecim w danym momencie
        /// </summary>
        public ObservableCollection<HorizontalRoadSign> Lane3 => lane3;

        /// <summary>
        /// Kolekcja zwracajaca kierunki możliwe do wyboru na pasie czwartym w danym momencie
        /// </summary>
        public ObservableCollection<HorizontalRoadSign> Lane4 => lane4;

        /// <summary>
        /// Obecnie wybrany kierunek na pasie pierwszym
        /// </summary>
        public HorizontalRoadSign CurrentDirectionLane1
        {            
            get => currentDirectionLane1;
            set
            {
                if(canUpdate)
                {
                    currentDirectionLane1 = value;
                    canUpdate = false;
                    Update(Lane.Lane1);
                    InletChanged();
                    canUpdate = true;
                }
            }
        }

        /// <summary>
        /// Obecnie wybrany kierunek na pasie drugim
        /// </summary>
        public HorizontalRoadSign CurrentDirectionLane2
        {
            get => currentDirectionLane2;
            set
            {
                if (canUpdate)
                {
                    currentDirectionLane2 = value;
                    canUpdate = false;
                    Update(Lane.Lane2);
                    InletChanged();
                    canUpdate = true;
                }
            }
        }

        /// <summary>
        /// Obecnie wybrany kierunek na pasie trzecim
        /// </summary>
        public HorizontalRoadSign CurrentDirectionLane3
        {
            get => currentDirectionLane3;
            set
            {
                if (canUpdate)
                {
                    currentDirectionLane3 = value;
                    canUpdate = false;
                    Update(Lane.Lane3);
                    InletChanged();
                    canUpdate = true;
                }
            }
        }

        /// <summary>
        /// Obecnie wybrany kierunek na pasie czwartym
        /// </summary>
        public HorizontalRoadSign CurrentDirectionLane4
        {
            get => currentDirectionLane4;
            set
            {
                if (canUpdate)
                {
                    currentDirectionLane4 = value;
                    canUpdate = false;
                    Update(Lane.Lane4);
                    InletChanged();
                    canUpdate = true;
                }
            }
        }


        #endregion

        #region Private Methods

        /// <summary>
        /// aktualizacja mozliwych kierunkow na pasach
        /// </summary>
        /// <param name="lane">na ktorym pasie byla zmiana</param>
        private void Update(Lane lane)
        {
            if (lane == Lane.Lane2 || lane == Lane.Lane3 || lane == Lane.Lane4)
            {
                lane1.LaneUpdate(new List<HorizontalRoadSign> { currentDirectionLane2, currentDirectionLane3, currentDirectionLane4 },
                                 new List<HorizontalRoadSign>(),
                                 ref currentDirectionLane1);
                
                OnPropertyChanged(nameof(CurrentDirectionLane1));
            }
            
            if (lane == Lane.Lane1 || lane == Lane.Lane3 || lane == Lane.Lane4)
            {
                lane2.LaneUpdate(new List<HorizontalRoadSign> { currentDirectionLane3, currentDirectionLane4 },
                                 new List<HorizontalRoadSign> { currentDirectionLane1 },
                                 ref currentDirectionLane2);
                
                OnPropertyChanged(nameof(CurrentDirectionLane2));
            }

            if (lane == Lane.Lane1 || lane == Lane.Lane2 || lane == Lane.Lane4)
            {
                lane3.LaneUpdate(new List<HorizontalRoadSign> { currentDirectionLane4 },
                                 new List<HorizontalRoadSign> { currentDirectionLane1, currentDirectionLane2 },
                                 ref currentDirectionLane3);
                
                OnPropertyChanged(nameof(CurrentDirectionLane3));
            }

            if (lane == Lane.Lane1 || lane == Lane.Lane2 || lane == Lane.Lane3)
            {
                lane4.LaneUpdate(new List<HorizontalRoadSign>(),
                                 new List<HorizontalRoadSign> { currentDirectionLane1, currentDirectionLane2, currentDirectionLane3 },
                                 ref currentDirectionLane4);
                
                OnPropertyChanged(nameof(CurrentDirectionLane4));
            }
        }

        /// <summary>
        /// jesli zmienia sie liczba pasow na mniejsza, wtedy pasow ktorych juz nie ma zmieniaja swoje kierunki na <see cref="HorizontalRoadSign.None"/>
        /// </summary>
        private void NumberOfLanesChanged()
        {
            if (numberOfLanesBeforeChange > numberOfLanesAfterChange)
            {
                if (numberOfLanesAfterChange == 1)
                {
                    CurrentDirectionLane2 = HorizontalRoadSign.None;
                    CurrentDirectionLane3 = HorizontalRoadSign.None;
                    CurrentDirectionLane4 = HorizontalRoadSign.None;
                }
                if (numberOfLanesAfterChange == 2)
                {
                    CurrentDirectionLane3 = HorizontalRoadSign.None;
                    CurrentDirectionLane4 = HorizontalRoadSign.None;
                }
                if (numberOfLanesAfterChange == 3)
                {
                    CurrentDirectionLane4 = HorizontalRoadSign.None;
                }
            }
        }

        #endregion

        #region Public Events

        /// <summary>
        /// Aktualizacja elementow na wlocie
        /// </summary>
        public Action InletChanged;

        #endregion
    }
}
