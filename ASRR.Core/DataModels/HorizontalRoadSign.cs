namespace ASRR.Core
{
    /// <summary>
    /// mozliwe kierunki na wlocie
    /// </summary>
    public enum HorizontalRoadSign
    {
        /// <summary>
        /// brak kierunku
        /// </summary>
        None = 0,

        /// <summary>
        /// kierunek zawracanie
        /// </summary>
        Zawracanie = 1,

        /// <summary>
        /// kierunek zawracanie + prosto
        /// </summary>
        ZawracanieProsto = 2,

        /// <summary>
        /// kierunek lewo
        /// </summary>
        Lewo = 3,

        /// <summary>
        /// kierunek prawo
        /// </summary>
        Prawo = 4,

        /// <summary>
        /// kierunek prosto
        /// </summary>
        Prosto = 5,

        /// <summary>
        /// kierunek lewo + prosto
        /// </summary>
        LewoProsto = 6,

        /// <summary>
        /// kierunek prawo + prosto
        /// </summary>
        PrawoProsto = 7,

        /// <summary>
        /// kierunek lewo + prawo
        /// </summary>
        LewoPrawo = 8,

        /// <summary>
        /// kierunek lewo + prawo + prosto
        /// </summary>
        LewoPrawoProsto = 9
    }
}
