// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISenderBluetoothService.cs" company="saramgsilva">
//   Copyright (c) 2014 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   The SenderBluetoothService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using BluetoothSample.Shared.Model;

namespace BluetoothSample.Services
{
    /// <summary>
    /// The SenderBluetoothService interface.
    /// </summary>
    public interface ISenderBluetoothService
    {
        /// <summary>
        /// Gets the devices.
        /// </summary>
        /// <returns>The list of the devices.</returns>
        Task<IList<Device>> GetDevices();

        /// <summary>
        /// Sends the data to the Receiver.
        /// </summary>
        /// <param name="device">The device.</param>
        /// <param name="content">The content.</param>
        /// <returns>If was sent or not.</returns>
        Task<bool> Send(Device device, string content);
    }
}