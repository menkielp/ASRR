namespace ASRR.Core
{
    /// <summary>
    /// linie na pasie
    /// </summary>
    public enum HorizontalLine
    {
        /// <summary>
        /// linia srodkowa
        /// </summary>
        Middle = 0,

        /// <summary>
        /// linia pierwsza po lewej od srodka
        /// </summary>
        FirstOnLeftFromMiddle = 1,

        /// <summary>
        /// linia druga po lewej od srodka
        /// </summary>
        FirstOnRightFromMiddle = 2,

        /// <summary>
        /// linia pierwsza po prawej od srodka
        /// </summary>
        SecondOnLeftFromMiddle = 3,

        /// <summary>
        /// linia druga po prawej od srodka
        /// </summary>
        SecondOnRightFromMiddle = 4,

        /// <summary>
        /// wewnetrzna lewa linia
        /// </summary>
        InnerLeft = 5,

        /// <summary>
        /// zewnetrzna lewa linia
        /// </summary>
        InnerRight = 6,

        /// <summary>
        /// wewnetrzna prawa linia
        /// </summary>
        OuterLeft = 7,

        /// <summary>
        /// zewnetrzna prawa linia
        /// </summary>
        OuterRight = 8

    }
}
