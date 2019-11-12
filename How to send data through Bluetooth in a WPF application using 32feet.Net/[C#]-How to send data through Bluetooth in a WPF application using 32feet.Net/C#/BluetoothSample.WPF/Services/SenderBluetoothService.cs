// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SenderBluetoothService.cs" company="saramgsilva">
//   Copyright (c) 2014 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   The Sender bluetooth service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BluetoothSample.Shared.Model;
using InTheHand.Net;
using InTheHand.Net.Sockets;

namespace BluetoothSample.Services
{
    /// <summary>
    /// The Sender bluetooth service.
    /// </summary>
    public sealed class SenderBluetoothService : ISenderBluetoothService
    {
         private readonly Guid _serviceClassId;

        /// <summary>
        /// Initializes a new instance of the <see cref="SenderBluetoothService"/> class. 
        /// </summary>
        public SenderBluetoothService()
        {
            // this guid is random, only need to match in Sender & Receiver
            // this is like a "key" for the connection!
            _serviceClassId = new Guid("9bde4762-89a6-418e-bacf-fcd82f1e0677");
        }

        /// <summary>
        /// Gets the devices.
        /// </summary>
        /// <returns>The list of the devices.</returns>
        public async Task<IList<Device>> GetDevices()
        {
            // for not block the UI it will run in a different threat
            var task = Task.Run(() =>
            {
                var devices = new List<Device>();
                using (var bluetoothClient = new BluetoothClient())
                {
                    var array = bluetoothClient.DiscoverDevices();
                    var count = array.Length;
                    for (var i = 0; i < count; i++)
                    {
                        devices.Add(new Device(array[i]));
                    }
                }
                return devices;
            });
            return await task;
        }

        /// <summary>
        /// Sends the data to the Receiver.
        /// </summary>
        /// <param name="device">The device.</param>
        /// <param name="content">The content.</param>
        /// <returns>If was sent or not.</returns>
        public async Task<bool> Send(Device device, string content)
        {
            if (device == null)
            {
                throw new ArgumentNullException("device");
            }

            if (string.IsNullOrEmpty(content))
            {
                throw new ArgumentNullException("content");
            }

            // for not block the UI it will run in a different threat
            var task = Task.Run(() =>
            {
                using (var bluetoothClient = new BluetoothClient())
                {
                    try
                    {
                        var ep = new BluetoothEndPoint(device.DeviceInfo.DeviceAddress, _serviceClassId);
                       
                        // connecting
                        bluetoothClient.Connect(ep);

                        // get stream for send the data
                        var bluetoothStream = bluetoothClient.GetStream();

                        // if all is ok to send
                        if (bluetoothClient.Connected && bluetoothStream != null)
                        {
                            // write the data in the stream
                            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                            bluetoothStream.Write(buffer, 0, buffer.Length);
                            bluetoothStream.Flush();
                            bluetoothStream.Close();
                            return true;
                        }
                        return false;
                    }
                    catch
                    {
                        // the error will be ignored and the send data will report as not sent
                        // for understood the type of the error, handle the exception
                    }
                }
                return false;
            });
            return await task;
        }
    }
}
