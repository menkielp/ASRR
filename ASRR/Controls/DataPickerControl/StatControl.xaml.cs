using ASRR.Core;
using System.Windows.Controls;

namespace ASRR
{
    /// <summary>
    /// Interaction logic for StatControl.xaml
    /// </summary>
    public partial class StatControl : UserControl
    {
        public StatControl()
        {
            InitializeComponent();

            //powiazanie kontekstu
            DataContext = DI.statVM;
        }
    }
}
