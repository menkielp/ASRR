using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ASRR.Core
{
    public class DialogBoxViewModel
    {

        #region Constructor
        
        public DialogBoxViewModel()
        {
            OkCommand = new RelayCommand(Ok);
        }

        #endregion

        #region Public Commands

        /// <summary>
        /// Nacisniecie OKButton
        /// </summary>
        public ICommand OkCommand { get; private set; }

        #endregion

        #region Public Properties

        /// <summary>
        /// Flaga przycisniecia przycisku
        /// </summary>
        public bool OkFlag { get; set; }

        /// <summary>
        /// Tekst w DialogBox
        /// </summary>
        public string Text { get; set; }

        #endregion

        #region Command Methods

        /// <summary>
        /// Nacisniecie OKButton
        /// </summary>
        private void Ok()
        {            
            OkFlag = true;
            DI.dialogManager.CloseMessage(this);      
        }

        #endregion

    }
}
