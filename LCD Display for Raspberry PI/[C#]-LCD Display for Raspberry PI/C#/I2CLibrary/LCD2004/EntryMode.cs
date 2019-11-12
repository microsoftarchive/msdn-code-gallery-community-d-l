// ***********************************************************************
// Assembly         : I2CLibrary
// Author           : SH
// Created          : 04-15-2017
//
// Last Modified By : SH
// Last Modified On : 04-15-2017
// ***********************************************************************
// <copyright file="EntryMode.cs" company="http://www.heesch.net">
//     Copyright © 2017 by Stefan Heesch
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace I2CLibrary.LCD2004
{
    /// <summary>
    /// Class EntryMode with constant defintions for setting the entry mode.
    /// </summary>
    public class EntryMode
    {
        /// <summary>
        /// Entry mode right
        /// </summary>
        public const int LCD_ENTRYRIGHT = 0x00;
        /// <summary>
        /// Entry mode left
        /// </summary>
        public const int LCD_ENTRYLEFT = 0x02;
        /// <summary>
        /// Increment cursor position
        /// </summary>
        public const int LCD_ENTRYSHIFTINCREMENT = 0x01;
        /// <summary>
        /// Decrement cursor position
        /// </summary>
        public const int LCD_ENTRYSHIFTDECREMENT = 0x00;
    }
}