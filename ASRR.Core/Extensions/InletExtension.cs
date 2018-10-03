using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ASRR.Core
{
    /// <summary>
    /// rozszerzenia do pasow
    /// </summary>
    public static class InletExtension
    {

        #region Helpers to LaneUpdate

        /// <summary>
        /// Im mniejsza wartosc tym bardziej ogranicza pasy po lewej stronie
        /// np. jesli pas po prawej od tego na ktorym jestesmy ma kierunek skrecania w lewo
        ///     to na tym pasie tez musi byc skret w lewo albo zawracanie
        /// </summary>
        static Dictionary<HorizontalRoadSign, int> mostRestrictiveDirectionOnRight = new Dictionary<HorizontalRoadSign, int>()
        {
            [HorizontalRoadSign.Zawracanie] = 1,
            [HorizontalRoadSign.ZawracanieProsto] = 1,
            [HorizontalRoadSign.Lewo] = 2,
            [HorizontalRoadSign.Prawo] = 4,
            [HorizontalRoadSign.Prosto] = 3,
            [HorizontalRoadSign.LewoProsto] = 2,
            [HorizontalRoadSign.PrawoProsto] = 3,
            [HorizontalRoadSign.LewoPrawo] = 2,
            [HorizontalRoadSign.LewoPrawoProsto] = 2
        };

        /// <summary>
        /// w zaleznosci jakie kierunki sa wybrane po prawej stronie od naszego pasa
        /// to wartosci okreslaja jakie kierunki moga byc na naszym pasie
        /// </summary>
        static Dictionary<HorizontalRoadSign, List<HorizontalRoadSign>> directionCanGoOnRight = new Dictionary<HorizontalRoadSign, List<HorizontalRoadSign>>()
        {
            [HorizontalRoadSign.Zawracanie] = new List<HorizontalRoadSign> { HorizontalRoadSign.Zawracanie },
            [HorizontalRoadSign.ZawracanieProsto] = new List<HorizontalRoadSign> { HorizontalRoadSign.Zawracanie },
            [HorizontalRoadSign.Lewo] = new List<HorizontalRoadSign> { HorizontalRoadSign.Zawracanie,
                                                                       HorizontalRoadSign.ZawracanieProsto,
                                                                       HorizontalRoadSign.Lewo },
            [HorizontalRoadSign.Prawo] = new List<HorizontalRoadSign> { HorizontalRoadSign.Zawracanie,
                                                                        HorizontalRoadSign.ZawracanieProsto,
                                                                        HorizontalRoadSign.Lewo,
                                                                        HorizontalRoadSign.Prawo,
                                                                        HorizontalRoadSign.Prosto,
                                                                        HorizontalRoadSign.LewoProsto,
                                                                        HorizontalRoadSign.PrawoProsto,
                                                                        HorizontalRoadSign.LewoPrawo,
                                                                        HorizontalRoadSign.LewoPrawoProsto },
            [HorizontalRoadSign.Prosto] = new List<HorizontalRoadSign> { HorizontalRoadSign.Zawracanie,
                                                                         HorizontalRoadSign.ZawracanieProsto,
                                                                         HorizontalRoadSign.Lewo,
                                                                         HorizontalRoadSign.Prosto,
                                                                         HorizontalRoadSign.LewoProsto },
            [HorizontalRoadSign.LewoProsto] = new List<HorizontalRoadSign> { HorizontalRoadSign.Zawracanie,
                                                                             HorizontalRoadSign.Lewo },
            [HorizontalRoadSign.PrawoProsto] = new List<HorizontalRoadSign> { HorizontalRoadSign.Zawracanie,
                                                                              HorizontalRoadSign.ZawracanieProsto,
                                                                              HorizontalRoadSign.Lewo,
                                                                              HorizontalRoadSign.Prosto,
                                                                              HorizontalRoadSign.LewoProsto },
            [HorizontalRoadSign.LewoPrawo] = new List<HorizontalRoadSign> { HorizontalRoadSign.Zawracanie, HorizontalRoadSign.Lewo },
            [HorizontalRoadSign.LewoPrawoProsto] = new List<HorizontalRoadSign> { HorizontalRoadSign.Zawracanie, HorizontalRoadSign.Lewo }
        };

        /// <summary>
        /// Im mniejsza wartosc tym bardziej ogranicza pasy po prawej stronie stronie
        /// np. jesli pas po lewej od tego na ktorym jestesmy ma kierunek skrecania w prawo
        ///     to na tym pasie po prawej od niego nie moze byc kierunku na wprost/lewo/zawracanie
        /// </summary>
        static Dictionary<HorizontalRoadSign, int> mostRestrictiveDirectionOnLeft = new Dictionary<HorizontalRoadSign, int>()
        {
            [HorizontalRoadSign.Zawracanie] = 4,
            [HorizontalRoadSign.ZawracanieProsto] = 2,
            [HorizontalRoadSign.Lewo] = 3,
            [HorizontalRoadSign.Prawo] = 1,
            [HorizontalRoadSign.Prosto] = 2,
            [HorizontalRoadSign.LewoProsto] = 2,
            [HorizontalRoadSign.PrawoProsto] = 1,
            [HorizontalRoadSign.LewoPrawo] = 1,
            [HorizontalRoadSign.LewoPrawoProsto] = 1,
        };

        /// <summary>
        /// w zaleznosci jakie kierunki sa wybrane po lewej stronie od naszego pasa
        /// to wartosci okreslaja jakie kierunki moga byc na naszym pasie
        /// </summary>
        static Dictionary<HorizontalRoadSign, List<HorizontalRoadSign>> directionCanGoOnLeft = new Dictionary<HorizontalRoadSign, List<HorizontalRoadSign>>()
        {
            [HorizontalRoadSign.Zawracanie] = new List<HorizontalRoadSign> { HorizontalRoadSign.Zawracanie, HorizontalRoadSign.ZawracanieProsto, HorizontalRoadSign.Lewo, HorizontalRoadSign.Prawo, HorizontalRoadSign.Prosto, HorizontalRoadSign.LewoProsto, HorizontalRoadSign.PrawoProsto, HorizontalRoadSign.LewoPrawo, HorizontalRoadSign.LewoPrawoProsto },
            [HorizontalRoadSign.ZawracanieProsto] = new List<HorizontalRoadSign> { HorizontalRoadSign.Prawo, HorizontalRoadSign.Prosto, HorizontalRoadSign.PrawoProsto },
            [HorizontalRoadSign.Lewo] = new List<HorizontalRoadSign> { HorizontalRoadSign.Lewo, HorizontalRoadSign.Prawo, HorizontalRoadSign.Prosto, HorizontalRoadSign.LewoProsto, HorizontalRoadSign.PrawoProsto, HorizontalRoadSign.LewoPrawo, HorizontalRoadSign.LewoPrawoProsto },
            [HorizontalRoadSign.Prawo] = new List<HorizontalRoadSign> { HorizontalRoadSign.Prawo },
            [HorizontalRoadSign.Prosto] = new List<HorizontalRoadSign> { HorizontalRoadSign.Prawo, HorizontalRoadSign.Prosto, HorizontalRoadSign.PrawoProsto },
            [HorizontalRoadSign.LewoProsto] = new List<HorizontalRoadSign> { HorizontalRoadSign.Prawo, HorizontalRoadSign.Prosto, HorizontalRoadSign.PrawoProsto },
            [HorizontalRoadSign.PrawoProsto] = new List<HorizontalRoadSign> { HorizontalRoadSign.Prawo },
            [HorizontalRoadSign.LewoPrawo] = new List<HorizontalRoadSign> { HorizontalRoadSign.Prawo },
            [HorizontalRoadSign.LewoPrawoProsto] = new List<HorizontalRoadSign> { HorizontalRoadSign.Prawo }
        };

        #endregion

        #region LaneUpdate

        /// <summary>
        /// rozszerzenie, ktore aktualizuje mozliwe do wybrania kierunki na danym pasie ruchu
        /// </summary>
        /// <param name="source">kierunki, ktore sa obecnie mozliwe do wybrania na danym pasie ruchu</param>
        /// <param name="lanesOnRight">kierunki, ktore sa na pasie ruchu po prawej stronie od danego pasa ruchu</param>
        /// <param name="lanesOnLeft">kierunki, ktore sa na pasie ruchu po lewej stronie od danego pasa ruchu</param>
        /// <param name="currentLane">obecny kierunek na pasie, w ktorym aktualizujemy mozliwe kierunki</param>
        /// <returns>zwraca kierunki, ktore mozemy obecnie wybrac, po uwzglednieniu ograniczen z lewej i prawej strony</returns>
        public static ObservableCollection<HorizontalRoadSign> LaneUpdate(this ObservableCollection<HorizontalRoadSign> source, List<HorizontalRoadSign> lanesOnRight,
                                                                List<HorizontalRoadSign> lanesOnLeft, ref HorizontalRoadSign currentLane)
        {

            List<HorizontalRoadSign> lane = null;
            List<HorizontalRoadSign> directionRight = InletExtension.DirectionsCanGo(lanesOnRight, mostRestrictiveDirectionOnRight, directionCanGoOnRight);
            List<HorizontalRoadSign> directionLeft = InletExtension.DirectionsCanGo(lanesOnLeft, mostRestrictiveDirectionOnLeft, directionCanGoOnLeft);
            
            if (!directionLeft.Any() && !directionRight.Any())
            {
                lane = (from inlet in directionCanGoOnLeft
                        select inlet.Key).ToList();
            }
            else if (!directionRight.Any()) lane = directionLeft;
            else if (!directionLeft.Any()) lane = directionRight;
            else lane = directionRight.Intersect(directionLeft).ToList();
            
            HorizontalRoadSign temp = currentLane;
            currentLane = HorizontalRoadSign.None;
            
            source.Clear();
            foreach (var direction in lane) source.Add(direction);

            currentLane = temp;

            return source;
        }

        /// <summary>
        /// wybor kierunkow, ktore moga byc na danym pasie po uwzglednieniu ograniczen z pasow po jego lewej lub prawej stronie
        /// </summary>
        /// <param name="items">kierunki na pasach po lewej lub prawej stronie od aktualizowanego pasa ruchu</param>
        /// <param name="mostRestrictiveDirection">slownik z wartosciami ograniczen, im mniejsza wartosc tym bardziej ogranicza</param>
        /// <param name="directionCanGoDictionary">slownik z kierunkami, ktore sa mozliwe do wyboru przy okreslonym kierunku na innym pasie</param>
        /// <returns>zwraca, ktore kierunki sa mozliwe do wybrania z ograniczen z pasow po lewej lub prawej stronie</returns>
        private static List<HorizontalRoadSign> DirectionsCanGo(List<HorizontalRoadSign> items,
                                                                Dictionary<HorizontalRoadSign, int> mostRestrictiveDirection,
                                                                Dictionary<HorizontalRoadSign, List<HorizontalRoadSign>> directionCanGoDictionary)
        {
            items.RemoveAll(a => a == HorizontalRoadSign.None);

            if (!items.Any()) return new List<HorizontalRoadSign>();
            
            var mostRestrictive = (from item in items
                                   join inlet in mostRestrictiveDirection
                                   on item equals inlet.Key
                                   select inlet.Value).Min();
            
            var inletRestriction = from mRI in mostRestrictiveDirection
                                   where mRI.Value == mostRestrictive
                                   select mRI.Key;

            
            var directionCanGo = (from direction in directionCanGoDictionary
                                  from inlet in inletRestriction
                                  where direction.Key == inlet
                                  select direction.Value).SelectMany(a => a).Distinct()?.ToList();

            return directionCanGo;

        }

        #endregion

        #region CurrentDirections
        /// <summary>
        /// kierunki, jakie sa obecnie wybrane na calym wlocie
        /// jesli na jednym pasie jest kierunek PrawoProsto to jest rodzielany na Prawo i Prosto
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static List<HorizontalRoadSign> CurrentDirections(this List<HorizontalRoadSign> source)
        {
            Dictionary<HorizontalRoadSign, List<HorizontalRoadSign>> directions = new Dictionary<HorizontalRoadSign, List<HorizontalRoadSign>>()
            {
                [HorizontalRoadSign.Zawracanie] = new List<HorizontalRoadSign> { HorizontalRoadSign.Zawracanie },
                [HorizontalRoadSign.ZawracanieProsto] = new List<HorizontalRoadSign> { HorizontalRoadSign.Zawracanie, HorizontalRoadSign.Prosto },
                [HorizontalRoadSign.Lewo] = new List<HorizontalRoadSign> { HorizontalRoadSign.Lewo },
                [HorizontalRoadSign.Prawo] = new List<HorizontalRoadSign> { HorizontalRoadSign.Prawo },
                [HorizontalRoadSign.Prosto] = new List<HorizontalRoadSign> { HorizontalRoadSign.Prosto },
                [HorizontalRoadSign.LewoProsto] = new List<HorizontalRoadSign> { HorizontalRoadSign.Lewo, HorizontalRoadSign.Prosto },
                [HorizontalRoadSign.PrawoProsto] = new List<HorizontalRoadSign> { HorizontalRoadSign.Prawo, HorizontalRoadSign.Prosto },
                [HorizontalRoadSign.LewoPrawo] = new List<HorizontalRoadSign> { HorizontalRoadSign.Lewo, HorizontalRoadSign.Prawo },
                [HorizontalRoadSign.LewoPrawoProsto] = new List<HorizontalRoadSign> { HorizontalRoadSign.Lewo, HorizontalRoadSign.Prawo, HorizontalRoadSign.Prosto }
            };

            if (source == null) return new List<HorizontalRoadSign>();
            
            var myDirections = (from direction in directions
                                join currentDirection in source
                                on direction.Key equals currentDirection
                                select direction.Value).SelectMany(a => a).Distinct().ToList();

            source.Clear();
            foreach (var direction in myDirections) source.Add(direction);
            return source;
        }
        #endregion

        #region DirectionsOnLane
        /// <summary>
        /// rozbicie kierunkow na kierunki podstawowe
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static List<HorizontalRoadSign> DirectionsOnLane(this HorizontalRoadSign source)
        {
            Dictionary<HorizontalRoadSign, List<HorizontalRoadSign>> directions = new Dictionary<HorizontalRoadSign, List<HorizontalRoadSign>>()
            {
                [HorizontalRoadSign.Zawracanie] = new List<HorizontalRoadSign> { HorizontalRoadSign.Lewo },
                [HorizontalRoadSign.ZawracanieProsto] = new List<HorizontalRoadSign> { HorizontalRoadSign.Lewo, HorizontalRoadSign.Prosto },
                [HorizontalRoadSign.Lewo] = new List<HorizontalRoadSign> { HorizontalRoadSign.Lewo },
                [HorizontalRoadSign.Prawo] = new List<HorizontalRoadSign> { HorizontalRoadSign.Prawo },
                [HorizontalRoadSign.Prosto] = new List<HorizontalRoadSign> { HorizontalRoadSign.Prosto },
                [HorizontalRoadSign.LewoProsto] = new List<HorizontalRoadSign> { HorizontalRoadSign.Lewo, HorizontalRoadSign.Prosto },
                [HorizontalRoadSign.PrawoProsto] = new List<HorizontalRoadSign> { HorizontalRoadSign.Prawo, HorizontalRoadSign.Prosto },
                [HorizontalRoadSign.LewoPrawo] = new List<HorizontalRoadSign> { HorizontalRoadSign.Lewo, HorizontalRoadSign.Prawo },
                [HorizontalRoadSign.LewoPrawoProsto] = new List<HorizontalRoadSign> { HorizontalRoadSign.Lewo, HorizontalRoadSign.Prawo, HorizontalRoadSign.Prosto }
            };
            
            var myDirections = (from direction in directions
                                where direction.Key == source
                                select direction.Value).SelectMany(a => a).ToList();


            return myDirections;
        }
        #endregion  

    }
}