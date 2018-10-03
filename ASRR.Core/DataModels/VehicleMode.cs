namespace ASRR.Core
{
    /// <summary>
    /// Tryb pojazdu
    /// </summary>
    public enum VehicleMode
    {
        /// <summary>
        /// Brak trybu
        /// </summary>
        None = 0,

        /// <summary>
        /// Przybycie na pas
        /// </summary>
        Arrival = 1,

        /// <summary>
        /// Przebywanie na pasie
        /// </summary>
        Lane = 2,

        /// <summary>
        /// Odjazd
        /// </summary>
        Departure = 3,

        /// <summary>
        /// Usuwanie
        /// </summary>
        Remove = 4

    }
}
