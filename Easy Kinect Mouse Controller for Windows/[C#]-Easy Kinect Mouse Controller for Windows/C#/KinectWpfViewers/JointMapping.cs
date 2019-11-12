//------------------------------------------------------------------------------
// <copyright file="JointMapping.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Microsoft.Samples.Kinect.WpfViewers
{
    using System.Windows;
    using Microsoft.Kinect;

    /// <summary>
    /// This class is used to map points between skeleton and color/depth
    /// </summary>
    public class JointMapping
    {
        /// <summary>
        /// This is the joint we are looking at
        /// </summary>
        public Joint Joint { get; set; }

        /// <summary>
        /// This is the point mapped into the target displays
        /// </summary>
        public Point MappedPoint { get; set; }
    }
}
