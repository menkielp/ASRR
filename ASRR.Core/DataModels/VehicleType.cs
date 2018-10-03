namespace ASRR.Core
{
    /// <summary>
    /// Typ pojazdu
    /// </summary>
    public enum VehicleType
    {
        /// <summary>
        /// Brak pojazdu
        /// </summary>
        NONE = 0,

        /// <summary>
        /// Samochod osobowy lub dostawczy
        /// </summary>
        SOD = 1,

        /// <summary>
        /// Autobus
        /// </summary>
        A = 2,

        /// <summary>
        /// Autobus przegubowy
        /// </summary>
        AP = 3,

        /// <summary>
        /// Samochod ciezarowy
        /// </summary>
        SC = 4,

        /// <summary>
        /// Samochod ciezarowy z przyczepa
        /// </summary>
        SCP = 5,

        /// <summary>
        /// Motor/Rower
        /// </summary>
        MR = 6,

        /// <summary>
        /// Inny Pojazd
        /// </summary>
        INNE = 7,

        /// <summary>
        /// Pojazdy razem
        /// </summary>
        RAZEM = 8

    }
}
