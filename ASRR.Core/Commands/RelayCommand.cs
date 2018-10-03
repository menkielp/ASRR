using System;
using System.Windows.Input;

namespace ASRR.Core
{
    public class RelayCommand : ICommand
    {

        #region Private Members

        /// <summary>
        /// delegat ktory bedzie wykonywany po nacisnieciu odpowiedniego przycisku
        /// </summary>
        private Action action;

        #endregion

        #region Constructor
        
        public RelayCommand(Action action)
        {
            //przypisanie delegata
            this.action = action;
        }

        #endregion

        #region Public Events

        public event EventHandler CanExecuteChanged = (s, e) => { };

        #endregion

        #region Public Methods

        /// <summary>
        /// zawsze mozna wykonac <see cref="Action"/>
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter) => true;

        /// <summary>
        /// wykonanie metody
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            action();
        }

        #endregion

    }
}
