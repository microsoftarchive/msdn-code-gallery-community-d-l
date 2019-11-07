// ***********************************************************************
// Assembly         : I2CLibrary
// Author           : SH
// Created          : 04-15-2017
//
// Last Modified By : SH
// Last Modified On : 04-15-2017
// ***********************************************************************
// <copyright file="DisplayMove.cs" company="http://www.heesch.net">
//     Copyright © 2017 by Stefan Heesch
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace I2CLibrary.LCD2004
{
    /// <summary>
    /// Class DisplayMove with constant declaration for controlling the 
    /// display scrolling and cursor movements.
    /// </summary>
    public class DisplayMove
    {
        /// <summary>
        /// Scroll the display
        /// </summary>
        public const byte LCD_DISPLAYMOVE = 0x08;
        /// <summary>
        /// Move the cursor
        /// </summary>
        public const byte LCD_CURSORMOVE = 0x00;
        /// <summary>
        /// Move right
        /// </summary>
        public const byte LCD_MOVERIGHT = 0x04;
        /// <summary>
        /// Move left
        /// </summary>
        public const byte LCD_MOVELEFT = 0x00;
    }
}