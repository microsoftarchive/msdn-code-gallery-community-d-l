using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml.Serialization;

namespace CircularReferenceSample.Models
{
    // Fix 3
    [JsonObject(IsReference = true)]
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Fix 3
        //[JsonIgnore]
        //[IgnoreDataMember]
        public virtual ICollection<Product> Products { get; set; }
    }

    [DataContract(IsReference = true)]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public virtual Category Category { get; set; }
    }
}