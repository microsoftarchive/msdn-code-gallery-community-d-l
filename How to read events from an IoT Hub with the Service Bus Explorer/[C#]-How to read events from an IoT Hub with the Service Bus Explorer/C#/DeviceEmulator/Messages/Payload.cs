#region Copyright
//=======================================================================================
// Microsoft Azure Customer Advisory Team  
//
// This sample is supplemental to the technical guidance published on the community
// blog at http://blogs.msdn.com/b/paolos/. 
// 
// Author: Paolo Salvatori
//=======================================================================================
// Copyright © 2015 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
// EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
// MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=======================================================================================
#endregion

#region Using Directives
using System;
using Newtonsoft.Json;
#endregion

namespace Microsoft.AzureCat.Samples.DeviceEmulator
{
    public class Payload
    {
        /// <summary>
        /// Gets or sets the device id.
        /// </summary>
        [JsonProperty(PropertyName = "deviceId", Order = 1)]
        public long DeviceId { get; set; }

        /// <summary>
        /// Gets or sets the device name.
        /// </summary>
        [JsonProperty(PropertyName = "name", Order = 2)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the device value.
        /// </summary>
        [JsonProperty(PropertyName = "value", Order = 3)]
        public double Value { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        [JsonProperty(PropertyName = "status", Order = 4)]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the timestamp.
        /// </summary>
        [JsonProperty(PropertyName = "timestamp", Order = 5)]
        public DateTime Timestamp { get; set; }
    }
}
