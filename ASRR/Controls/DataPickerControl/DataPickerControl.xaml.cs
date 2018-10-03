using ASRR.Core;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ASRR
{
    /// <summary>
    /// Interaction logic for DataPicker.xaml
    /// </summary>
    public partial class DataPickerControl : UserControl
    {

        #region Constructor

        /// <summary>
        /// Domyslny konstruktor
        /// </summary>
        public DataPickerControl()
        {
            InitializeComponent();

            //powiazanie kontekstu
            DataContext = DI.dataPickerVM;
        }

        #endregion

       
    }
}
