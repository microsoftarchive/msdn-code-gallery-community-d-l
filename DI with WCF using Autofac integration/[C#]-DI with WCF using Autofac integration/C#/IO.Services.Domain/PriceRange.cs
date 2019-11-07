using System;
using System.Runtime.Serialization;

namespace Ioc.Services.Domain
{
    /// <summary>
    /// Class that define the price range.
    /// </summary>
    [DataContract]
    public class PriceRange
    {
        /// <summary>
        /// Gets or sets the minimum price.
        /// </summary>
        [DataMember]
        public double MinPrice { get; set; }

        /// <summary>
        /// Gets or sets the maximum price.
        /// </summary>
        [DataMember]
        public double MaxPrice { get; set; }
    }
}
