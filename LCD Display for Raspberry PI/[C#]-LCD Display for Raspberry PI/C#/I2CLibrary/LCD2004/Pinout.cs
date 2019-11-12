// ***********************************************************************
// Assembly         : I2CLibrary
// Author           : SH
// Created          : 04-15-2017
//
// Last Modified By : SH
// Last Modified On : 04-15-2017
// ***********************************************************************
// <copyright file="Pinout.cs" company="http://www.heesch.net">
//     Copyright © 2017 by Stefan Heesch
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace I2CLibrary.LCD2004
{
    /// <summary>
    /// Class Pinout with constant definitions reflecting the connection 
    /// between the I2C Port Exapander and the LCD Controller.
    /// </summary>
    class Pinout
    {
        /// <summary>
        /// Read State Pin RS
        /// </summary>
        public const int RS = 0b00000001;

        /// <summary>
        /// Read/Write Pin RW
        /// </summary>
        public const int RW = 0b00000010;

        /// <summary>
        /// Enable Pin EN
        /// </summary>
        public const int EN = 0b00000100;
    }
}