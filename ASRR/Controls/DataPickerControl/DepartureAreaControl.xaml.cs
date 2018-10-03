using ASRR.Core;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ASRR
{
    /// <summary>
    /// Interaction logic for DepartureAreaControl.xaml
    /// </summary>
    public partial class DepartureAreaControl : UserControl
    {

        #region Constructor 

        public DepartureAreaControl(Thickness margin)
        {
            InitializeComponent();

            //ustawienie marginesu
            this.Margin = margin;

            if (margin.Left < 0) direction = HorizontalRoadSign.Lewo;
            else if (margin.Left == 0) direction = HorizontalRoadSign.Prosto;
            else if (margin.Left > 0) direction = HorizontalRoadSign.Prawo;

            //dodanie DragDrop handlerow dla kontrolki
            DragDrop.AddDragEnterHandler(this, DepartureAreaControl_OnDragEnter);
            DragDrop.AddDragLeaveHandler(this, DepartureAreaControl_OnDragLeave);
            DragDrop.AddDropHandler(this, DepartureAreaControl_OnDrop);
        }

        #endregion

        #region Private Members

        /// <summary>
        /// kierunek na ktorym jest ustawiony <see cref="DepartureAreaControl"/>
        /// </summary>
        private HorizontalRoadSign direction;

        #endregion

        #region Event Methods

        /// <summary>
        /// Wejscie pojazdu nad <see cref="DepartureAreaControl"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DepartureAreaControl_OnDragEnter(object sender, DragEventArgs e)
        {
            Border area = (Border)this.FindName("dropArea");
            area.ChangeColor((Color)ColorConverter.ConvertFromString("#0000ff"), 0.2);
            (sender as DepartureAreaControl).IncreaseWidth(new Duration(TimeSpan.FromSeconds(0.2)), 125);
        }

        /// <summary>
        /// Wyjscie pojazdu z <see cref="DepartureAreaControl"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DepartureAreaControl_OnDragLeave(object sender, DragEventArgs e)
        {
            Border area = (Border)this.FindName("dropArea");
            area.ChangeColor((Color)ColorConverter.ConvertFromString("#000000"), 0.2);
            (sender as DepartureAreaControl).DecreaseWidth(new Duration(TimeSpan.FromSeconds(0.2)), 120);
        }

        /// <summary>
        /// Zrzucenie pojazdu na <see cref="DepartureAreaControl"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DepartureAreaControl_OnDrop(object sender, DragEventArgs e)
        {
            //ViewModel pojazdu ktory zostal zrzucony
            VehicleViewModel vehicleVM = (VehicleViewModel)e.Data.GetData(typeof(VehicleViewModel));

            //Ustawienie czasu ojazdu pojazdu
            vehicleVM.DepartureTime = DateTime.Now;

            //Wybrany kierunek jazdy pojazdu
            vehicleVM.DirectionPicked = direction;

            //Odjazd pojazdu
            vehicleVM.Mode = VehicleMode.Departure;
                        
        }

        #endregion

    }

}
