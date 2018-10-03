using System.Collections.ObjectModel;

namespace ASRR.Core
{
    static class InletHelper
    {
        /// <summary>
        /// Pobranie wszystkich mozliwych kierunkow na pasie
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<HorizontalRoadSign> GetRoadSigns()
        {
            ObservableCollection<HorizontalRoadSign> horizontalSings = new ObservableCollection<HorizontalRoadSign>()
            {
                HorizontalRoadSign.Zawracanie,
                HorizontalRoadSign.ZawracanieProsto,
                HorizontalRoadSign.Lewo,
                HorizontalRoadSign.Prawo,
                HorizontalRoadSign.Prosto,
                HorizontalRoadSign.LewoProsto,
                HorizontalRoadSign.PrawoProsto,
                HorizontalRoadSign.LewoPrawo,
                HorizontalRoadSign.LewoPrawoProsto
            };
            return horizontalSings;
        }

        /// <summary>
        /// Pobranie wszystkich mozliwych wlotow
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<Inlet> GetInletCollection()
        {
            ObservableCollection<Inlet> InletCollection = new ObservableCollection<Inlet>()
            {
                Inlet.A,
                Inlet.B,
                Inlet.C,
                Inlet.D
            };
            return InletCollection;

        }
        
        

    }
}
