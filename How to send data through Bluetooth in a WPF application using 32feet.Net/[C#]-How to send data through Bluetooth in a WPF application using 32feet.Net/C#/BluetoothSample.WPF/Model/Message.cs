// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Message.cs" company="saramgsilva">
//   Copyright (c) 2014 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   Define the Device Message.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BluetoothSample.Shared.ViewModel
{
    /// <summary>
    /// Define the Device Message.
    /// </summary>
    public class Message
    {
        private readonly bool _isToShowDevices;

        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class.
        /// </summary>
        /// <param name="isToShowDevices">if set to <c>true</c> [is to show devices].</param>
        public Message(bool isToShowDevices)
        {
            _isToShowDevices = isToShowDevices;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is to show devices.
        /// </summary>
        /// <value><c>true</c> if this instance is to show devices; otherwise, <c>false</c>.</value>
        public bool IsToShowDevices
        {
            get { return _isToShowDevices; }
        }
    }
}
