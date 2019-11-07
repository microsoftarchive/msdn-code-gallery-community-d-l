// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System;

namespace Microsoft.Practices.Prism.PubSubEvents
{
    /// <summary>
    /// Generic arguments class to pass to event handlers that need to receive data.
    /// </summary>
    /// <typeparam name="TData">The type of data to pass.</typeparam>
    public class DataEventArgs<TData> : EventArgs
    {
        private readonly TData _value;

        /// <summary>
        /// Initializes the DataEventArgs class.
        /// </summary>
        /// <param name="value">Information related to the event.</param>
        public DataEventArgs(TData value)
        {
            _value = value;
        }

        /// <summary>
        /// Gets the information related to the event.
        /// </summary>
        /// <value>Information related to the event.</value>
        public TData Value
        {
            get { return _value; }
        }
    }
}