using ASRR.Core;
using System.Windows;

namespace ASRR
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            
            ApplicationSetup();
            
            //otworzenie okna glownego
            MainWindow mainwindow = new ASRR.MainWindow();
            mainwindow.Show();
        }

        /// <summary>
        /// Ustawienie aplikacji
        /// </summary>
        private void ApplicationSetup()
        {
            //zainiciowanie wiazan
            DI.Setup();

            //ustawienie managera dialogow
            IDialogManager dialogManager = new DialogManager();
            DI.Setup<IDialogManager>(dialogManager);
        }
        
    }
}
