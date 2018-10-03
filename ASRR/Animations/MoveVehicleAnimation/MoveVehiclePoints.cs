using ASRR.Core;
using System.Collections.Generic;
using System.Windows;
using System.Linq;

namespace ASRR
{
    /// <summary>
    /// Punkty w kierunku ktorych porusza sie pojazd
    /// </summary>
    static class MoveVehiclePoints
    {

        #region Public Methods

        /// <summary>
        /// Pobranie punktow do poruszania sie pojazdow podczas przyjazdu/poruszania sie na pasie
        /// </summary>
        /// <param name="source">lista punktow do poruszania sie pojazdu</param>
        /// <param name="lane">pas na ktorym znajduje sie pojazd</param>
        /// <param name="vehiclesOnLane">pojazdy na danym pasie</param>
        /// <returns></returns>
        public static List<Point> GetPoints(this List<Point> source, int queuePosition, Lane lane)
        {
            //liczba pasow na wlocie
            int numberOfLanes = DI.laneDirectionPickerVM.NumberOfLanes + 1;

            
                switch (lane)
                {
                    case Lane.Lane1:
                        {
                            if (numberOfLanes == 1)
                                source.Add(new Point(0, 160 + (50 * (queuePosition - 1))));
                            else if (numberOfLanes == 2)
                                source.Add(new Point(-22, 160 + (50 * (queuePosition - 1))));
                            else if (numberOfLanes == 3)
                                source.Add(new Point(-66, 160 + (50 * (queuePosition - 1))));
                            else if (numberOfLanes == 4)
                                source.Add(new Point(-110, 160 + (50 * (queuePosition - 1))));
                            break;
                        }
                    case Lane.Lane2:
                        {
                            if (numberOfLanes == 2)
                                source.Add(new Point(22, 160 + (50 * (queuePosition - 1))));
                            else if (numberOfLanes == 3)
                                source.Add(new Point(0, 160 + (50 * (queuePosition - 1))));
                            else if (numberOfLanes == 4)
                                source.Add(new Point(-22, 160 + (50 * (queuePosition - 1))));
                            break;
                        }
                    case Lane.Lane3:
                        {
                            if (numberOfLanes == 3)
                                source.Add(new Point(66, 160 + (50 * (queuePosition - 1))));
                            else if (numberOfLanes == 4)
                                source.Add(new Point(22, 160 + (50 * (queuePosition - 1))));
                            break;
                        }
                    case Lane.Lane4:
                        {
                            if (numberOfLanes == 4)
                                source.Add(new Point(110, 160 + (50 * (queuePosition - 1))));
                            break;
                        }
                }
            
                                   
            return source;
        }

        /// <summary>
        /// Pobranie punktow do poruszania sie pojazdow podczas odjazdu
        /// </summary>
        /// <param name="source">lista punktow do poruszania sie pojazdow</param>
        /// <param name="lane">pas na ktorym znajduje sie pojazd</param>
        /// <param name="numberOfLanes">liczba pasow</param>
        /// <param name="direction">wybrany kierunek</param>
        /// <returns></returns>
        public static List<Point> GetPointsOnDeparture(this List<Point> source, Lane lane, int numberOfLanes, HorizontalRoadSign direction)
        {
            string keyToGo = numberOfLanes.ToString() + lane + direction;
            
            var points = (from point in pointsToGo
                     where point.Key == keyToGo
                     select point.Value).ToList();
            
            foreach (var a in points[0])
                source.Add(a);

            return source;
        }

        #endregion

        #region Helpers
        
        static Dictionary<string, List<Point>> pointsToGo = new Dictionary<string, List<Point>>()
        {

            #region punkty do jazdy prosto

            //--------------------------------------------------------punkty do jazdy prosto------------------------------------------------------
            //--------------------------------------------------------dla jednego pasa ruchu------------------------------------------------------
            ["1Lane1Prosto"] = new List<Point> { new Point(15, -80) },

            ////--------------------------------------------------------dla dwoch pasow ruchu-------------------------------------------------------
            ["2Lane1Prosto"] = new List<Point> { new Point(-29, -80) },
            ["2Lane2Prosto"] = new List<Point> { new Point(61, -80) },

            ////--------------------------------------------------------dla trzech pasow ruchu-------------------------------------------------------
            ["3Lane1Prosto"] = new List<Point> { new Point(-73, -80) },
            ["3Lane2Prosto"] = new List<Point> { new Point(0, -80) },
            ["3Lane3Prosto"] = new List<Point> { new Point(103, -80) },

            ////--------------------------------------------------------dla czterech pasow ruchu-------------------------------------------------------
            ["4Lane1Prosto"] = new List<Point> { new Point(-117, -80) },
            ["4Lane2Prosto"] = new List<Point> { new Point(-29, -80) },
            ["4Lane3Prosto"] = new List<Point> { new Point(61, -80) },
            ["4Lane4Prosto"] = new List<Point> { new Point(147, -80) },

            #endregion

            #region punkty do jazdy w lewo
            ////--------------------------------------------------------punkty do jazdy w lewo------------------------------------------------------
            ////--------------------------------------------------------dla jednego pasa ruchu------------------------------------------------------
            ["1Lane1Lewo"] = new List<Point> { new Point(15, 100),
                                               new Point(-5 , 80),                                               
                                               new Point(-30, 60),
                                               new Point(-Application.Current.MainWindow.ActualWidth, 65)},

            ////--------------------------------------------------------dla dwoch pasow ruchu------------------------------------------------------
            ["2Lane1Lewo"] = new List<Point> { new Point(-29, 100),
                                               new Point(-49 , 80),
                                               new Point(-70, 60),
                                               new Point(-Application.Current.MainWindow.ActualWidth, 65)},

            ["2Lane2Lewo"] = new List<Point> { new Point(61, 100),
                                               new Point(41 , 80),
                                               new Point(21, 60),
                                               new Point(-Application.Current.MainWindow.ActualWidth, 65)},

            ////--------------------------------------------------------dla trzech pasow ruchu------------------------------------------------------
            ["3Lane1Lewo"] = new List<Point> { new Point(-73, 100),
                                               new Point(-93 , 80),
                                               new Point(-113, 60),
                                               new Point(-Application.Current.MainWindow.ActualWidth, 65)},

            ["3Lane2Lewo"] = new List<Point> { new Point(15, 100),
                                               new Point(-5 , 80),
                                               new Point(-30, 60),
                                               new Point(-Application.Current.MainWindow.ActualWidth, 65)},

            ["3Lane3Lewo"] = new List<Point> { new Point(103, 100),
                                               new Point(83 , 80),
                                               new Point(60, 60),
                                               new Point(-Application.Current.MainWindow.ActualWidth, 65)},

            ////--------------------------------------------------------dla czterech pasow ruchu------------------------------------------------------
            ["4Lane1Lewo"] = new List<Point> { new Point(-117, 100),
                                               new Point(-140 , 80),
                                               new Point(-160, 60),
                                               new Point(-Application.Current.MainWindow.ActualWidth, 65)},

            ["4Lane2Lewo"] = new List<Point> { new Point(-29, 100),
                                               new Point(-49 , 80),
                                               new Point(-70, 60),
                                               new Point(-Application.Current.MainWindow.ActualWidth, 65)},

            ["4Lane3Lewo"] = new List<Point> { new Point(61, 100),
                                               new Point(41 , 80),
                                               new Point(21, 60),
                                               new Point(-Application.Current.MainWindow.ActualWidth, 65)},

            ["4Lane4Lewo"] = new List<Point> { new Point(147, 100),
                                               new Point(123 , 80),
                                               new Point(100, 60),
                                               new Point(-Application.Current.MainWindow.ActualWidth, 65)},
            #endregion

            #region punkty do jazdy w prawo

            ////--------------------------------------------------------punkty do jazdy w prawo------------------------------------------------------
            ////--------------------------------------------------------dla jednego pasa ruchu------------------------------------------------------
            ["1Lane1Prawo"] = new List<Point> { new Point(20, 100),
                                               new Point(70 , 60),
                                               new Point(130, 40),
                                               new Point(Application.Current.MainWindow.ActualWidth, 50)},

            ////--------------------------------------------------------dla dwoch pasow ruchu------------------------------------------------------
            ["2Lane1Prawo"] = new List<Point> { new Point(-24, 100),
                                               new Point(26 , 60),
                                               new Point(88, 40),
                                               new Point(Application.Current.MainWindow.ActualWidth, 50)},

            ["2Lane2Prawo"] = new List<Point> { new Point(64, 100),
                                               new Point(114 , 60),
                                               new Point(174, 40),
                                               new Point(Application.Current.MainWindow.ActualWidth, 50)},

            ////--------------------------------------------------------dla trzech pasow ruchu------------------------------------------------------
            ["3Lane1Prawo"] = new List<Point> { new Point(-68, 100),
                                               new Point(-18 , 60),
                                               new Point(42, 40),
                                               new Point(Application.Current.MainWindow.ActualWidth, 50)},

            ["3Lane2Prawo"] = new List<Point> { new Point(20, 100),
                                               new Point(70 , 60),
                                               new Point(130, 40),
                                               new Point(Application.Current.MainWindow.ActualWidth, 50)},

            ["3Lane3Prawo"] = new List<Point> { new Point(108, 100),
                                               new Point(158 , 60),
                                               new Point(218, 40),
                                               new Point(Application.Current.MainWindow.ActualWidth, 50)},

            ////--------------------------------------------------------dla czterech pasow ruchu------------------------------------------------------
            ["4Lane1Prawo"] = new List<Point> { new Point(-112, 100),
                                               new Point(-62 , 60),
                                               new Point(0, 40),
                                               new Point(Application.Current.MainWindow.ActualWidth, 50)},

            ["4Lane2Prawo"] = new List<Point> { new Point(-24, 100),
                                               new Point(26 , 60),
                                               new Point(88, 40),
                                               new Point(Application.Current.MainWindow.ActualWidth, 50)},

            ["4Lane3Prawo"] = new List<Point> { new Point(64, 100),
                                               new Point(114 , 60),
                                               new Point(174, 40),
                                               new Point(Application.Current.MainWindow.ActualWidth, 50)},

            ["4Lane4Prawo"] = new List<Point> { new Point(152, 100),
                                               new Point(200 , 60),
                                               new Point(260, 40),
                                               new Point(Application.Current.MainWindow.ActualWidth, 50)},
            
            #endregion

        };

        #endregion


    }
}
