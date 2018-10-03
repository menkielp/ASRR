using System.Windows;
using System.Windows.Controls;

namespace ASRR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {
        public DialogWindow(Control content)
        {
            InitializeComponent();
            
            this.DataContext = new DialogViewModel(this, content);
        }
    }
}
