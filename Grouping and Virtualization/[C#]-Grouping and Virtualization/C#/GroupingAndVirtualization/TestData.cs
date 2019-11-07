using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GroupingAndVirtualization
{
    // This is just some random data
    public class TestData
    {
        public TestData(string name, string type)
        {
            _name = name;
            _type = type;
        }

        // This is what will be displayed
        public string Name
        {
            get { return _name; }
        }

        // This is how they will be grouped
        public string Type
        {
            get { return _type; }
        }

        private string _name;
        private string _type;
    }
}
