using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace BloodDonors.Models
{
    public class Donor
    {
        [HiddenInput(DisplayValue = false)]
        public int DonorID { get; set; }
        public string Name { get; set; }
        public string bGroup { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }


        [UIHint("LocationDetail")]
        [NotMapped]
        public LocationDetail Location
        {
            get
            {
                return new LocationDetail() { Latitude = this.Latitude, Longitude = this.Longitude, Name = this.Name, Address = this.Address };
            }
            set
            {
                this.Latitude = value.Latitude;
                this.Longitude = value.Longitude;
                this.Name = value.Name;
                this.Address = value.Address;
            }
        }
    }

    public class LocationDetail
    {
        public double Latitude;
        public double Longitude;
        public string Name;
        public string Address;
    }


}