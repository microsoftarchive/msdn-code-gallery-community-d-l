// ***********************************************************************
// Assembly         : I2CLibrary
// Author           : SH
// Created          : 04-15-2017
//
// Last Modified By : SH
// Last Modified On : 04-15-2017
// ***********************************************************************
// <copyright file="ControlSet.cs" company="http://www.heesch.net">
//     Copyright © 2017 by Stefan Heesch
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace I2CLibrary.LCD2004
{
    /// <summary>
    /// Class ControlSet with constant defitions for controlling the LCD 
    /// display.
    /// </summary>
    public class ControlSet
    {
        /// <summary>
        /// Switch LCD off.
        /// </summary>
        public const byte LCD_DISPLAYOFF = 0x00;
        /// <summary>
        /// Switch LCD on.
        /// </summary>
        public const byte LCD_DISPLAYON  = 0x04;
        /// <summary>
        /// Hide the line cursor.
        /// </summary>
        public const byte LCD_CURSOROFF  = 0x00;
        /// <summary>
        /// Show the line cursor.
        /// </summary>
        public const byte LCD_CURSORON   = 0x02;
        /// <summary>
        /// Hide the blinking cursor.
        /// </summary>
        public const byte LCD_BLINKOFF   = 0x00;
        /// <summary>
        /// Show the blinking cursor.
        /// </summary>
        public const byte LCD_BLINKON    = 0x01;
    }
}