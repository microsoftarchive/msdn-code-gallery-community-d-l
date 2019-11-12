// ***********************************************************************
// Assembly         : I2CLibrary
// Author           : SH
// Created          : 04-15-2017
//
// Last Modified By : SH
// Last Modified On : 04-15-2017
// ***********************************************************************
// <copyright file="Command.cs" company="http://www.heesch.net">
//     Copyright © 2017 by Stefan Heesch
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace I2CLibrary.LCD2004
{
    /// <summary>
    /// Class Command with constant defitions for sending commands to the
    /// LCD controller.
    /// </summary>
    public class Command
    {
        /// <summary>
        /// Command: Clear LCD display
        /// </summary>
        public const int LCD_CLEARDISPLAY    = 0x01;
        /// <summary>
        /// Command: Move cursor to home position
        /// </summary>
        public const int LCD_RETURNHOME      = 0x02;
        /// <summary>
        /// Command: Setup entry mode
        /// </summary>
        public const int LCD_ENTRYMODESET    = 0x04;
        /// <summary>
        /// Command: Setup LCD control 
        /// </summary>
        public const int LCD_DISPLAYCONTROL  = 0x08;
        /// <summary>
        /// Command: Setup the cursor movements
        /// </summary>
        public const int LCD_CURSORSHIFT    = 0x10;
        /// <summary>
        /// Command: Setup LCD functionality
        /// </summary>
        public const int LCD_FUNCTIONSET     = 0x20;
        /// <summary>
        /// Command: Setup custom defined character map
        /// </summary>
        public const int LCD_SETCGRAMADDR    = 0x40;
        /// <summary>
        /// Command: Setup pointer for display memory
        /// </summary>
        public const int LCD_SETDDRAMADDR    = 0x80;
    }
}