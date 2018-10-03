using System;
using System.Windows.Input;

namespace ASRR.Core
{
    public class RelayParameterCommand<T> : ICommand
        where T : struct, IComparable, IConvertible, IFormattable
    {

        #region Private Members

        /// <summary>
        /// delegat ktory bedzie wykonywany po nacisnieciu odpowiedniego przycisku
        /// </summary>
        private Action<T> action;

        #endregion

        #region Constructor
        
        public RelayParameterCommand(Action<T> action)
        {
            this.action = action;
        }

        #endregion

        #region Public Events

        public event EventHandler CanExecuteChanged = (s, e) => { };

        #endregion

        #region Public Methods

        /// <summary>
        /// zawsze mozna wykonac metode
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter) => true;

        /// <summary>
        /// wykonanie metody z paremetrem
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            action((T)parameter);
        }

        #endregion

    }
}
