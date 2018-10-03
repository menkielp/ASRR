using ASRR.Core;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ASRR
{
    /// <summary>
    /// Viewmodel dla glownego okna
    /// </summary>
    class DialogViewModel : WindowViewModel
    {

        #region Constructor
        
        public DialogViewModel(Window window, Control content) : base(window)
        {
            minWindowHeight = 100;
            minWindowWidth = 200;
            captionHeight = 30;
            Content = content;

            CloseCommand = new RelayCommand(() =>
            {
                window.Close();                
                DI.dataPickerVM.DimmableOverlayAnimation = Animation.FadeOut;
                Task.Delay(300).ContinueWith((e) => DI.dataPickerVM.DimmableOverlayFlag = false);
            });
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Tytul okna
        /// </summary>
        public string Title { get; set; }


        /// <summary>
        /// Zawartosc okna
        /// </summary>
        public Control Content { get; set; }

        #endregion
               

    }
}
