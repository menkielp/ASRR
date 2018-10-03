using ASRR.Core;
using System.Windows;
using System.Windows.Input;

namespace ASRR
{
    /// <summary>
    /// Viewmodel dla glownego okna
    /// </summary>
    class WindowViewModel : BaseViewModel
    {
        #region Constructor

        public WindowViewModel(Window window)
        {
            mWindow = window;

            CloseCommand = new RelayCommand(() => mWindow.Close());
            MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            SystemMenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(mWindow, GetMousePosition(mWindow)));
            
            mWindow.StateChanged += (sender, e) => WindowResizer();

            mWindowResizer = new WindowResizer(mWindow);
            mWindowResizer.WindowDockChanged += (dock) =>
            {
                mDockPosition = dock;
                WindowResizer();
                
            };

        }

        #endregion

        #region Private Members

        /// <summary>
        /// Okno ktore kontroluje ten viewmodel
        /// </summary>
        private Window mWindow;

         /// <summary>
         /// The last known dock position
         /// </summary>
         private WindowDockPosition mDockPosition = WindowDockPosition.Undocked;

        /// <summary>
        /// The window resizer helper that keeps the window size correct in various states
        /// </summary>
        private WindowResizer mWindowResizer;

        /// <summary>
        /// Szerekosc krawedzi do zmieniania rozmiaru okna
        /// </summary>
        private int resizeBorder = 6;

        /// <summary>
        /// Wysokosc naglowka na gorze okna
        /// </summary>
        protected int captionHeight = 40;

        /// <summary>
        /// margines na zewnatrz okna
        /// </summary>
        private double outerMargin = 10;

        /// <summary>
        /// promien rogow okna
        /// </summary>
        private int cornerRadius = 10;
        
        /// <summary>
        /// minimalna szerokosc okna
        /// </summary>
        protected int minWindowWidth = 680;

        /// <summary>
        /// minimalna wysokosc okna
        /// </summary>
        protected int minWindowHeight = 380;

        #endregion

        #region Public Properties       

        /// <summary>
        /// True if the window should be borderless because it is docked or maximized
        /// </summary>
        public bool Borderless => mWindow.WindowState == WindowState.Maximized || mDockPosition != WindowDockPosition.Undocked;

        /// <summary>
        /// minimalna szerokosc okna
        /// </summary>
        public int MinWindowWidth => minWindowWidth;

        /// <summary>
        /// minimalna wysokosc okna
        /// </summary>
        public int MinWindowHeight => minWindowHeight;

        /// <summary>
        /// margines na zewnatrz okna
        /// </summary>
        public double OuterMargin => outerMargin;

        /// <summary>
        /// Margines w okolo okna, ktory umozliwia jego rozszerzanie/zmniejszanie
        /// </summary>
        public Thickness ResizeBorderThickness => Borderless ? new Thickness(0) : new Thickness(OuterMargin + resizeBorder);
           
        /// <summary>
        /// Wysokosc naglowka w oknie, ktory umozliwia przesuwanie okna
        /// </summary>
        public double CaptionHeight => captionHeight;

        /// <summary>
        /// promien rogow w oknie
        /// </summary>
        public CornerRadius CornerRadius => Borderless ? new CornerRadius(0) : new CornerRadius(cornerRadius);
        
        /// <summary>
        /// Margines na zewnatrz okna
        /// </summary>
        public Thickness OuterMarginThickness => mWindow.WindowState == WindowState.Maximized ? new Thickness(0) : new Thickness(OuterMargin + resizeBorder);


        /// <summary>
        /// Wysokosc naglowka
        /// </summary>
        public GridLength TitleHeight => new GridLength(captionHeight);

        /// <summary>
        /// Wewnetrzny odstep w oknie
        /// </summary>
        public Thickness InnerPadding => new Thickness(resizeBorder);

        #endregion

        #region Public Commands

        /// <summary>
        /// Komenda zamkniecia MainWindow
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// Komenda maksymalizacji MainWindow
        /// </summary>
        public ICommand MaximizeCommand { get; private set; }

        /// <summary>
        /// Komenda minimalizacji MainWindow
        /// </summary>
        public ICommand MinimizeCommand { get; private set; }

        /// <summary>
        /// komenda otworzenia menu systemowego po nacisnieciu logo
        /// </summary>
        public ICommand SystemMenuCommand { get; private set; }

        #endregion               

        #region Private Methods

        private void WindowResizer()
        {
            OnPropertyChanged(nameof(ResizeBorderThickness));
            OnPropertyChanged(nameof(CornerRadius));
            OnPropertyChanged(nameof(OuterMarginThickness));
        }

        #endregion

        #region Helpers

        /// <summary>
        /// pozycja myszki
        /// </summary>
        /// <param name="window">glowne okno aplikacji</param>
        /// <returns>pozycje myszki</returns>
        private Point GetMousePosition(Window window)
        {
            var posx = Mouse.GetPosition(window).X + window.Left;
            var posy = Mouse.GetPosition(window).X + window.Top;

            return new Point(posx, posy);
        }

        #endregion

    }
}
