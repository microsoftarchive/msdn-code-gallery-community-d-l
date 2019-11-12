using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ComboboxDisable
{
    public class ExampleClass 
    {
        // Field for storing collection
        private List<String> items;

        // Property for Storing Collections
        public List<String> Items
        {
            get { return items; }
            set {items = value;}
            
        }
        /// <summary>
        /// Constructor
        /// </summary>
        public ExampleClass()
        {   
            items = new List<String>();
            items.Add("CollectionItem1");
            items.Add("CollectionItem2");
            items.Add("CollectionItem3");
            items.Add("CollectionItem4");
            items.Add("CollectionItem5");
        }
    }
}
