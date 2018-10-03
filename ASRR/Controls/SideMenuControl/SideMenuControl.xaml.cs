using ASRR.Core;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ASRR
{
    /// <summary>
    /// Interaction logic for SideMenu.xaml
    /// </summary>
    public partial class SideMenuControl : UserControl
    {

        #region Constructor 

        /// <summary>
        /// Domyslny konstruktor
        /// </summary>
        public SideMenuControl()
        {
            InitializeComponent();

            //powiazanie kontekstu
            DataContext = DI.sideMenuVM;
        }

        #endregion

    }
}
