using ASRR.Core;
using System.Windows.Controls;

namespace ASRR
{
    /// <summary>
    /// Interaction logic for ClockControl.xaml
    /// </summary>
    public partial class ClockControl : UserControl
    {
        public ClockControl()
        {
            InitializeComponent();

            //powiazanie kontekstu
            DataContext = DI.clockVM;
        }
    }
}
