// ***********************************************************************
// Assembly         : I2CLibrary
// Author           : SH
// Created          : 04-15-2017
//
// Last Modified By : SH
// Last Modified On : 04-15-2017
// ***********************************************************************
// <copyright file="FunctionSet.cs" company="http://www.heesch.net">
//     Copyright © 2017 by Stefan Heesch
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace I2CLibrary.LCD2004
{
    /// <summary>
    /// Class FunctionSet with constant definitions for setup up the display
    /// functionality.
    /// </summary>
    public class FunctionSet
    {
        /// <summary>
        /// Set the LCD controller into 4 bit mode.
        /// </summary>
        public const byte LCD_4BITMODE = 0x00;
        /// <summary>
        /// Set the LCD controller into 8 bit mode.
        /// </summary>
        public const byte LCD_8BITMODE = 0x10;
        /// <summary>
        /// The LCD has 2 or more lines
        /// </summary>
        public const byte LCD_2LINE    = 0x08;
        /// <summary>
        /// The LCD has only 1 line
        /// </summary>
        public const byte LCD_1LINE    = 0x00;
        /// <summary>
        /// The 5X10 dot character map shall be used.
        /// </summary>
        public const byte LCD_5x10DOTS = 0x04;
        /// <summary>
        /// The 5X8 dot character map shall be used.
        /// </summary>
        public const byte LCD_5x8DOTS  = 0x00;
    }
}