using System;
using System.Runtime.Serialization;

namespace Ioc.Services.Domain
{
    /// <summary>
    /// Class that defines the properties of the car.
    /// </summary>
    [DataContract]
    public class Car
    {
        /// <summary>
        /// Gets or set providers identifier for the car.
        /// </summary>
        [DataMember]
        public string Register { get; set; }

        /// <summary>
        /// Gets or sets the manufacturing year.
        /// </summary>
        [DataMember]
        public int ManufacturingYear { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        [DataMember]
        public double Price { get; set; }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        [DataMember]
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        [DataMember]
        public CarModel Model { get; set; }

        /// <summary>
        /// Gets or sets the name of the manufacturer.
        /// </summary>
        [DataMember]
        public string Manufacturer { get; set; }

        /// <summary>
        /// Gets or sets the name of the model.
        /// </summary>
        [DataMember]
        public string ModelName { get; set; }
    }

    [DataContract]
    public enum CarModel : int
    {
        [EnumMember]
        Sedan = 0,

        [EnumMember]
        Variant = 2,

        [EnumMember]
        Coupe = 3
    }
}
