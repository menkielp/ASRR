using ASRR.Core;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace ASRR
{
    /// <summary>
    /// Manager pokazywanych dialogow
    /// </summary>
    class DialogManager : IDialogManager
    {
        /// <summary>
        /// Pokazanie wiadomosci
        /// </summary>
        /// <param name="dialogBoxViewModel">Zawartosc <see cref="DialogWindow"/></param>
        /// <returns></returns>
        public Task ShowMessage(DialogBoxViewModel dialogBoxViewModel)
        {
            var tcs = new TaskCompletionSource<bool>();

            Application.Current.Dispatcher.Invoke(() =>
            {
                try
                {
                    //zawartosc dialogu
                    DialogBoxControl dialogContent = new DialogBoxControl() { DataContext = dialogBoxViewModel };

                    //stworzenie dialogu
                    DialogWindow dialog = new DialogWindow(dialogContent);
                    dialog.ShowDialog();
                }
                finally
                {
                    //ustawienie wartosci, aby powiadomic wywolujacego
                    tcs.TrySetResult(true);
                }
                
            });

            return tcs.Task;
                          
        }

        /// <summary>
        /// Zamkniecie wiadomosci
        /// </summary>
        /// <param name="dialogBoxViewModel"></param>
        /// <returns></returns>
        public Task CloseMessage(DialogBoxViewModel dialogBoxViewModel)
        {
            //sprzwdzenie wszystkich okien...
            foreach(var window in Application.Current.Windows)
            {
                //...czy zawieraja dialog z odpowiednim DialogBoxViewModel
                if (window is DialogWindow dialogWindow && 
                    ((dialogWindow.DataContext as DialogViewModel).Content as DialogBoxControl).DataContext == dialogBoxViewModel)
                    //jesli tak to jest zamykany
                    dialogWindow.Close();
            }

            return Task.CompletedTask;

        }
    }
}
