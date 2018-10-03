using ASRR.Core;
using System.Windows.Controls;

namespace ASRR
{
    /// <summary>
    /// Interaction logic for InletControl.xaml
    /// </summary>
    public partial class InletControl : UserControl
    {
        public InletControl()
        {
            InitializeComponent();

            //powiazanie kontekstu
            DataContext = new InletViewModel();
        }
    }
}
