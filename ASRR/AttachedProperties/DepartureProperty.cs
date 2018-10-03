using ASRR.Core;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ASRR
{
    /// <summary>
    /// Wlasciwosc dolaczana wykonywanie operacji z strefami DROP
    /// </summary>
    class DepartureProperty
    {
        #region Attached Properties
        
        /// <summary>
        /// Pobranie wartosci
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DepartureArea GetDepartureArea(DependencyObject obj)
        {
            return (DepartureArea)obj.GetValue(DepartureAreaProperty);
        }

        /// <summary>
        /// Ustawienie wartosci
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetDepartureArea(DependencyObject obj, DepartureArea value)
        {
            obj.SetValue(DepartureAreaProperty, value);
        }
        
        public static readonly DependencyProperty DepartureAreaProperty =
            DependencyProperty.RegisterAttached("DepartureArea", typeof(DepartureArea), typeof(DepartureProperty), new PropertyMetadata(DepartureAreaPropertyChanged));
        
        #endregion

        #region PropertyChanged Events

        /// <summary>
        /// Wykonanie przy zmianie wartosci <see cref="DepartureAreaProperty"/>
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        public static void DepartureAreaPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //Operacja jaka ma byc wykonana na strefach
            DepartureArea departureArea = (DepartureArea)e.NewValue;
            
            if (departureArea == DepartureArea.None)
                return;
            
            Grid inlet = (Grid)d;            
            DepartureAreaControl departureAreaControl = null;
            
            if (departureArea == DepartureArea.CreateLeft)            
                departureAreaControl = new DepartureAreaControl(new Thickness(-inlet.ActualWidth/1.3, 60, 0, 0));    
            
            if (departureArea == DepartureArea.CreateTop)
                departureAreaControl = new DepartureAreaControl(new Thickness(0, 30, 0, 0));

            if (departureArea == DepartureArea.CreateRight)
                departureAreaControl = new DepartureAreaControl(new Thickness(inlet.ActualWidth / 1.3, 60, 0, 0));

            if(departureAreaControl != null)
                inlet.Children.Add(departureAreaControl);
            
            if (departureArea == DepartureArea.Remove)
            {
                List<DepartureAreaControl> departureAreaToRemove = new List<DepartureAreaControl>();
                
                foreach(var child in inlet.Children)
                {
                    if (child is DepartureAreaControl area)
                        departureAreaToRemove.Add(area);
                }
                
                foreach (DepartureAreaControl area in departureAreaToRemove)
                    inlet.Children.Remove(area);
            }
        }

        #endregion

    }
}
