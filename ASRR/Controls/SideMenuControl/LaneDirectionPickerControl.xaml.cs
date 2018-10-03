using System.Windows.Controls;
using ASRR.Core;

namespace ASRR
{
    /// <summary>
    /// Interaction logic for LaneDirectionPicker.xaml
    /// </summary>
    public partial class LaneDirectionPickerControl : UserControl
    {
        public LaneDirectionPickerControl()
        {
            InitializeComponent();

            //przypisanie kontekstu
            DataContext = DI.laneDirectionPickerVM;

        }
    }
}
