using ASRR.Core;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Threading;
using System.Linq;
using System.Windows.Media;
using System.Windows.Controls;

namespace ASRR
{
    /// <summary>
    /// Animacja poruszania sie pojazdu
    /// </summary>
    public class MoveVehicleAnimation
    {

        #region Constructor
        
        public MoveVehicleAnimation(VehicleControl vehicle, Lane lane)
        {
            this.vehicleControl = vehicle;
            this.lane = lane;           
        }

        #endregion

        #region Private Members

        /// <summary>
        /// Pojazd ktory sie porusza
        /// </summary>
        private VehicleControl vehicleControl;

        /// <summary>
        /// Pas na ktorym znajduje sie pojazd
        /// </summary>
        private Lane lane;

        /// <summary>
        /// Predkosc pojazdu
        /// </summary>
        double speed = 10;

        /// <summary>
        /// Zegar dzieki ktoremu pojazd bedzie sie poruszal
        /// </summary>
        private DispatcherTimer timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(0.02) };

        /// <summary>
        /// Punkty w kierunku ktorych porusza sie pojazd
        /// </summary>
        private List<Point> whereTo = new List<Point>();

        #endregion

        #region Public Methods

        /// <summary>
        /// rozpoczecie animacji poruszania sie na pasie pojazdu
        /// </summary>
        public void MoveOnArrival()
        {
            List<Point> points = new List<Point>();
            points.GetPoints((vehicleControl.DataContext as VehicleViewModel).QueuePosition, lane);
            
            foreach (var point in points)
                whereTo.Add(point);
                     
            timer.Tick += Arrival_Tick;
            timer.Start();
        }

        /// <summary>
        /// rozpoczaecie animacji poruszania sie pojazdu na pasie
        /// </summary>
        public void MoveOnLane()
        {            
            timer.Tick -= Arrival_Tick;
            MoveOnArrival();
        }

        /// <summary>
        /// Rozpoczecie animacji odjazdu pojazdu
        /// </summary>
        /// <param name="lane">pas z ktorego odjezdza pojazd</param>
        /// <param name="numberOfLanes">ile pasow jest na wlocie</param>
        /// <param name="direction">kierunek wybrany przez pojazd</param>
        public void MoveOnDeparture(Lane lane, int numberOfLanes, HorizontalRoadSign direction)
        {
            whereTo.GetPointsOnDeparture(lane, numberOfLanes, direction);
            timer.Tick -= Arrival_Tick;
            timer.Tick += Departure_Tick;
            timer.Start();
        }

        #endregion

        #region Event Methods

        /// <summary>
        /// zdarzenie odpowiadajace za poruszanie sie pojazdu w czasie przyjazdu na wlot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Arrival_Tick(object sender, EventArgs e)
        {

            //punkt na srodku przedniej osi pojazdu
            Point mycarpoint = new Point(vehicleControl.Margin.Left + vehicleControl.ActualWidth / 2, vehicleControl.Margin.Top + vehicleControl.ActualHeight / 5);                       

            //przesuniecie pojazdu do nowej pozycji w zaleznosci od tego z ktorej strony punktu docelowego byl na poczatku
            if (whereTo[0].Y < mycarpoint.Y) vehicleControl.Margin = new Thickness(vehicleControl.Margin.Left, vehicleControl.Margin.Top - speed, 0, 0);
            //jesli odleglosc pojazdu od punktu docelowego jest mniejsza niz dlugosc pojazdu...
            if ((whereTo[0].Y - mycarpoint.Y < vehicleControl.ActualHeight && whereTo[0].Y - mycarpoint.Y > -vehicleControl.ActualHeight))
            {
                //...wtedy usuwany jest obecny punkt do ktorego zmierzal
                whereTo.RemoveAt(0);

                //jezeli juz dojechal do wszystkich punktow pokolei
                if (!whereTo.Any())
                {   
                    (sender as DispatcherTimer).Tick -= Arrival_Tick;
                    (sender as DispatcherTimer).Stop();

                    //ustawienie predkosci poczatkowej
                    speed = 0.5;
                    
                }
            }
                        
            //zmniejszenie predkosci pojazdu
            if (speed > 3) speed = speed - 0.09;
            else speed = 3;
            
        }

        /// <summary>
        /// zdarzenie odpowiadajace za poruszanie sie pojazdu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Departure_Tick(object sender, EventArgs e)
        {
            //punkt na srodku przedniej osi pojazdu
            Point mycarpoint = new Point(vehicleControl.Margin.Left + vehicleControl.ActualWidth / 2, vehicleControl.Margin.Top + vehicleControl.ActualHeight / 5);

            //odleglosc miedzy punktem X pojazdu a punktem X punktu docelowego
            double xDistance = Math.Abs(whereTo[0].X - mycarpoint.X);
            //odleglosc miedzy punktem Y pojazdu a punktem Y punktu docelowego
            double yDistance = Math.Abs(whereTo[0].Y - mycarpoint.Y);

            //proporcje przesuwania sie pojazdow na osi x i y
            double xVelocity = xDistance / (xDistance + yDistance);
            double yVelocity = yDistance / (xDistance + yDistance);

            //pobranie obecnego kata obrocenia pojazdu
            double angle = (vehicleControl.RenderTransform as RotateTransform).Angle;

            //obliczenie wartosci przesuniecia sie punktu X na osi uwzgledniajac kat pod jakim pojazd znajduje sie wlocie
            double xRotationValue = Math.Cos((angle * 2 * Math.PI) / 360) * vehicleControl.ActualWidth / 2;
            //obliczenie wartosci przesuniecia sie punktu Y na osi uwzgledniajac kat pod jakim pojazd znajduje sie wlocie
            double yRotationValue = Math.Sin((angle * 2 * Math.PI) / 360) * vehicleControl.ActualWidth / 2;

            //punkt lewego gornego rogu pojazdu z uwzglednieniem nowego katu
            Point vehicleLeftTop = new Point(vehicleControl.Margin.Left + vehicleControl.ActualWidth / 2 - xRotationValue, vehicleControl.Margin.Top - yRotationValue);
            //punkt prawego gornego rogu pojazdu z uwzglednieniem nowego katu
            Point vehicleRightTop = new Point(vehicleControl.Margin.Left + vehicleControl.ActualWidth / 2 + xRotationValue, vehicleControl.Margin.Top + yRotationValue);


            //odleglosc gornego lewego punktu pojazdu od punktu do ktorego zmierza
            double distanceFromTopLeft = Math.Sqrt(Math.Pow((whereTo[0].X - vehicleLeftTop.X), 2) + Math.Pow((whereTo[0].Y - vehicleLeftTop.Y), 2));
            //odleglosc gornego prawego punktu pojazdu od punktu do ktorego zmierza
            double distanceFromTopRight = Math.Sqrt(Math.Pow((whereTo[0].X - vehicleRightTop.X), 2) + Math.Pow((whereTo[0].Y - vehicleRightTop.Y), 2));

            //roznica pomiedzy rogami pojazdow a punktem docelowym
            double checkDistance = distanceFromTopRight - distanceFromTopLeft;

            //jesli lewy gorny punkt pojazdu jest dalej od punktu docelowego niz prawy gorny punkt pojazdu
            //wtedy pojazd obraca sie zgodnie ze wskazowkami zegara, aby odleglosci te zmierzaly do zera
            //a co za tym idzie, zeby pojazd jechaly prosto na wyznaczony punkt, a nie bokiem
            if (checkDistance > 2)
            {
                double turn = speed > 3.9 ? 3.9 : speed;
                RotateTransform rotateVehicle = vehicleControl.RenderTransform as RotateTransform;

                //obrocenie pojazdu o 1.5 radiana
                RotateTransform rotate = new RotateTransform(rotateVehicle.Angle - turn);

                //przypisanie nowego kata obrotu pojazdu
                vehicleControl.RenderTransform = rotate;
            }
            else if (checkDistance < -2)
            {
                double turn = speed > 3.9 ? 3.9 : speed;
                RotateTransform rotateVehicle = vehicleControl.RenderTransform as RotateTransform;

                //obrocenie pojazdu o 1.5 radiana
                RotateTransform rotate = new RotateTransform(rotateVehicle.Angle + turn);

                //przypisanie nowego kata obrotu pojazdu
                vehicleControl.RenderTransform = rotate;
            }

            //przesuniecie pojazdu do nowej pozycji w zaleznosci od tego z ktorej strony punktu docelowego byl na poczatku
            if (whereTo[0].X > mycarpoint.X) vehicleControl.Margin = new Thickness(vehicleControl.Margin.Left + xVelocity * speed, vehicleControl.Margin.Top, 0, 0);
            if (whereTo[0].X < mycarpoint.X) vehicleControl.Margin = new Thickness(vehicleControl.Margin.Left - xVelocity * speed, vehicleControl.Margin.Top, 0, 0);
            if (whereTo[0].Y > mycarpoint.Y) vehicleControl.Margin = new Thickness(vehicleControl.Margin.Left, vehicleControl.Margin.Top + yVelocity * speed, 0, 0);
            if (whereTo[0].Y < mycarpoint.Y) vehicleControl.Margin = new Thickness(vehicleControl.Margin.Left, vehicleControl.Margin.Top - yVelocity * speed, 0, 0);
            //jesli odleglosc pojazdu od punktu docelowego jest mniejsza niz dlugosc pojazdu...
            if ((whereTo[0].X - mycarpoint.X < vehicleControl.ActualHeight && whereTo[0].X - mycarpoint.X > -vehicleControl.ActualHeight) && (whereTo[0].Y - mycarpoint.Y < vehicleControl.ActualHeight && whereTo[0].Y - mycarpoint.Y > -vehicleControl.ActualHeight))
            {
                //...wtedy usuwany jest obecny punkt do ktorego zmierzal
                whereTo.RemoveAt(0);

                //jezeli juz dojechal do wszystkich punktow pokolei
                if (!whereTo.Any())
                {
                    (vehicleControl.Parent as Grid).Children.Remove(vehicleControl);
                    (sender as DispatcherTimer).Tick -= Departure_Tick;
                    (sender as DispatcherTimer).Stop();
                }
            }

            //zwiekszenie predkosci pojazdu
            speed = speed + 0.11;
        }

        #endregion

    }
}
