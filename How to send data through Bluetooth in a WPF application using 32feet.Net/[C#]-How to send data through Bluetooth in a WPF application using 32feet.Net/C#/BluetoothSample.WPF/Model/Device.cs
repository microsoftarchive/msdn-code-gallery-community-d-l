// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Device.cs" company="saramgsilva">
//   Copyright (c) 2014 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   The device.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using InTheHand.Net.Sockets;

namespace BluetoothSample.Shared.Model
{
    /// <summary>
    /// The device.
    /// </summary>
    public sealed class Device
    {
        /// <summary>
        /// Gets or sets the device name.
        /// </summary>
        /// <value>
        /// The device name.
        /// </value>
        public string DeviceName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether authenticated.
        /// </summary>
        /// <value>
        /// The authenticated.
        /// </value>
        public bool IsAuthenticated { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is connected.
        /// </summary>
        /// <value>
        /// The is connected.
        /// </value>
        public bool IsConnected { get; set; }

        /// <summary>
        /// Gets or sets the nap.
        /// </summary>
        /// <value>
        /// The nap.
        /// </value>
        public ushort Nap { get; set; }

        /// <summary>
        /// Gets or sets the sap.
        /// </summary>
        /// <value>
        /// The sap.
        /// </value>
        public uint Sap { get; set; }

        /// <summary>
        /// Gets or sets the last seen.
        /// </summary>
        /// <value>
        /// The last seen.
        /// </value>
        public DateTime LastSeen { get; set; }

        /// <summary>
        /// Gets or sets the last used.
        /// </summary>
        /// <value>
        /// The last used.
        /// </value>
        public DateTime LastUsed { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether remembered.
        /// </summary>
        /// <value>
        /// The remembered.
        /// </value>
        public bool Remembered { get; set; }

        /// <summary>
        /// Gets or sets the device info.
        /// </summary>
        /// <value>
        /// The device info.
        /// </value>
        public BluetoothDeviceInfo DeviceInfo { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Device"/> class.
        /// </summary>
        /// <param name="device_info">
        /// The device_info.
        /// </param>
        public Device(BluetoothDeviceInfo device_info)
        {
            if (device_info != null)
            {
                DeviceInfo = device_info;
                IsAuthenticated = device_info.Authenticated;
                IsConnected = device_info.Connected;
                DeviceName = device_info.DeviceName;
                LastSeen = device_info.LastSeen;
                LastUsed = device_info.LastUsed;
                Nap = device_info.DeviceAddress.Nap;
                Sap = device_info.DeviceAddress.Sap;
                Remembered = device_info.Remembered;
            }
        }

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            return DeviceName;
        }
    }
}
