using Ninject;

namespace ASRR.Core
{
    /// <summary>
    /// DI kontener dla naszej aplikacji
    /// </summary>
    public class DI
    {        
        #region Public Properties

        /// <summary>
        /// jadro DI
        /// </summary>
        public static IKernel Kernel { get; private set; } = new StandardKernel();

        /// <summary>
        /// skrot do <see cref="LaneDirectionPickerViewModel"/>
        /// </summary>
        public static LaneDirectionPickerViewModel laneDirectionPickerVM => DI.Get<LaneDirectionPickerViewModel>();

        /// <summary>
        /// skrot do <see cref="SideMenuViewModel"/>
        /// </summary>
        public static SideMenuViewModel sideMenuVM => DI.Get<SideMenuViewModel>();

        /// <summary>
        /// skrot do <see cref="DataPickerViewModel"/>
        /// </summary>
        public static DataPickerViewModel dataPickerVM => DI.Get<DataPickerViewModel>();

        /// <summary>
        /// skrot do <see cref="ClockViewModel"/>
        /// </summary>
        public static ClockViewModel clockVM => DI.Get<ClockViewModel>();

        /// <summary>
        /// skrot do <see cref="StatViewModel"/>
        /// </summary>
        public static StatViewModel statVM => DI.Get<StatViewModel>();

        /// <summary>
        /// skrot do <see cref="IDialogManager"/>
        /// </summary>
        public static IDialogManager dialogManager => DI.Get<IDialogManager>();

        #endregion

        #region Public Methods

        /// <summary>
        /// Ustawia DI kontener, zwiazuje wszystkie dane ktore sa do uzycia od teraz
        /// NOTE: trzeba zainicjowac jak najszybicej przy rozpoczeciu aplikacji
        ///       zeby wszystkie uslugi byly dostepne
        /// </summary>
        public static void Setup()
        {
            Kernel.Bind<SideMenuViewModel>().ToConstant(new SideMenuViewModel());
            Kernel.Bind<LaneDirectionPickerViewModel>().ToConstant(new LaneDirectionPickerViewModel());
            Kernel.Bind<DataPickerViewModel>().ToConstant(new DataPickerViewModel());
            Kernel.Bind<ClockViewModel>().ToConstant(new ClockViewModel());
            Kernel.Bind<StatViewModel>().ToConstant(new StatViewModel());
        }

        /// <summary>
        /// Zwiazanie interfejsu 
        /// </summary>
        /// <param name="dialogManager"></param>
        public static void Setup<T>(T manager)
        {
            Kernel.Bind<T>().ToConstant(manager);
        }

        /// <summary>
        /// Zwraca usluge okreslonego typu z jadra
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }

        #endregion

    }
}
