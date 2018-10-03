namespace ASRR.Core
{
    /// <summary>
    /// Strefy zrzutu
    /// </summary>
    public enum DepartureArea
    {

        /// <summary>
        /// Brak strefy
        /// </summary>
        None = 0,
        
        /// <summary>
        /// Pokaz strefe
        /// </summary>
        Show = 1,

        /// <summary>
        /// Ukryj strefe
        /// </summary>
        Hide = 2,
              
        /// <summary>
        /// Stworz strefe po lewej stronie
        /// </summary>
        CreateLeft = 3,

        /// <summary>
        /// Stworz strefe na gorze
        /// </summary>
        CreateTop = 4,

        /// <summary>
        /// Stworz strefe po prawej stronie
        /// </summary>
        CreateRight = 5,

        /// <summary>
        /// Usun strefe
        /// </summary>
        Remove = 6,

    }
}
