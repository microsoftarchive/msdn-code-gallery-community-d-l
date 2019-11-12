// ***********************************************************************
// Assembly         : HL7Messaging
// Author           : SH
// Created          : 07-06-2014
//
// Last Modified By : SH
// Last Modified On : 07-06-2014
// ***********************************************************************
// <copyright file="Segment.cs" author="Stefan Heesch">
//     Apache 2.0 license : http://www.apache.org/licenses/LICENSE-2.0.html.
// </copyright>
// <summary>Very basic support for HL7 V2.x messaging</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace HL7Messaging
{
    public class Segment
    {
        private Dictionary<int, String> _fields;


        public Segment()
        {
            _fields = new Dictionary<int, string>(20);
        }

        public Segment(string name)
        {
            _fields = new Dictionary<int, string>(20);
            _fields.Add(0,name);
        }

        public String Name
        {
            get
            {
                if (!_fields.ContainsKey(0)) return String.Empty;
                return _fields[0]; 
            }
        }

        public String Field(int index)
        {
            // This implementation supports only vertical bars as field delimiters
            if (Name == "MSH" && index == 1) return "|";
            
            if (!_fields.ContainsKey(index))
            {
                return String.Empty;
            }
            return _fields[index];
        }


        public void Field(int index, String value)
        {
            // This implementation supports only vertical bars as field delimiters
            if (Name == "MSH" && index == 1) return;

            if (_fields.ContainsKey(index))
            {
                _fields.Remove(index);
            }

            if (!String.IsNullOrEmpty(value))
            {
                _fields.Add(index, value);    
            }
        }


        public void Parse(String text)
        {
            int count = 0;
            char[] delimiter = { '|' };

            string temp = text.Trim('|');
            var tokens = temp.Split(delimiter, StringSplitOptions.None);

            foreach (var item in tokens)
            {
                Field(count, item);
                if (item == "MSH")
                {
                    // Treat the special case "MSH" - the delimiter after the segment name counts as first field
                    ++count;
                }
                ++count;
            }
        }

        public String Serialize()
        {
            int max = 0;
            foreach (var field in _fields)
            {
                if (max < field.Key) max = field.Key;
            }

            var tmp = new StringBuilder();

            for (int i = 0; i <= max; i++)
            {
                if (_fields.ContainsKey(i))
                {
                    tmp.Append( _fields[i] );

                    // Treat special case "MSH" - the first delimiter after segement name counts as first field
                    if (i == 0 && Name == "MSH")
                    {
                        ++i;
                    }
                }
                if ( i != max) tmp.Append("|");
            }
            return tmp.ToString();
        }
    }
}