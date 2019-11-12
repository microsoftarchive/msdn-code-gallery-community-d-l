// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IReceiverBluetoothService.cs" company="saramgsilva">
//   Copyright (c) 2014 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   The ReceiverBluetoothService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;

namespace BluetoothSample.Services
{
    /// <summary>
    /// The ReceiverBluetoothService interface.
    /// </summary>
    public interface IReceiverBluetoothService
    {
        /// <summary>
        /// Gets a value indicating whether was started.
        /// </summary>
        /// <value>
        /// The was started.
        /// </value>
        bool WasStarted { get; }
        
        /// <summary>
        /// Starts the listening from Senders.
        /// </summary>
        /// <param name="reportAction">
        /// The report Action.
        /// </param>
        void Start(Action<string> reportAction);

        /// <summary>
        /// Stops the listening from Senders.
        /// </summary>
        void Stop();

        /// <summary>
        /// Occurs when [property changed].
        /// </summary>
        event PropertyChangedEventHandler PropertyChanged;
    }
}