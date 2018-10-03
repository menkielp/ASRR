using System.ComponentModel;

namespace ASRR.Core
{
    /// <summary>
    /// podstawowa klasa dla kazdego viewmodel
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// zdarzenie ktore sie wykonuje przy zmianie wartosci wlasciwosci
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// wywolanie powodujace rozpoczecie <see cref="PropertyChanged"/> zdarzenia
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name)
        {
            if(PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
