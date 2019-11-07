// ***********************************************************************
// Assembly         : HL7Messaging
// Author           : SH
// Created          : 07-06-2014
//
// Last Modified By : SH
// Last Modified On : 07-06-2014
// ***********************************************************************
// <copyright file="Message.cs" author="Stefan Heesch">
//     Apache 2.0 license : http://www.apache.org/licenses/LICENSE-2.0.html.
// </copyright>
// <summary>Very basic support for HL7 V2.x messaging</summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace HL7Messaging
{
    public class Message
    {
        private const String MSH = "MSH";

        private const int MSH_MSG_TIME = 7;
        private const int MSH_MSG_TYPE = 9;
        private const int MSH_MSG_CONTROL_ID = 10;

        private LinkedList<Segment> _segments;

        public Message()
        {
            Clear();
        }

        public void Clear()
        {
            _segments = new LinkedList<Segment>();
        }

        protected Segment Header()
        {
            if (_segments.Count == 0 || _segments.First.Value.Name != MSH)
            {
                return null;
            }
            return _segments.First.Value;
        }


        public String MessageType()
        {
            var msh = Header();
            if (msh == null) return String.Empty;
            
            return msh.Field(MSH_MSG_TYPE);
        }

        public String MessageControlId()
        {
            var msh = Header();
            if (msh == null) return String.Empty;
            return msh.Field(MSH_MSG_CONTROL_ID);
        }


        public DateTime? MessageDateTime()
        {
            var msh = Header();
            if (msh == null) return null;

            DateTime t;
            if (DateTime.TryParseExact(msh.Field(MSH_MSG_TIME),"yyyyMMddHHmmsszzz",CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out t))
            {
                return t;
            }

            if (DateTime.TryParseExact(msh.Field(MSH_MSG_TIME), "yyyyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out t))
            {
                return t;
            }

            if (DateTime.TryParseExact(msh.Field(MSH_MSG_TIME), "yyyyMMddHHmm", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out t))
            {
                return t;
            }
            return null;
        }



        public void Add(Segment segment)
        {
            if (!String.IsNullOrEmpty(segment.Name) && segment.Name.Length == 3)
            {
                _segments.AddLast(segment);
            }
        }

        public Segment FindSegment(String name)
        {
            foreach (var segment in _segments)
            {
                if (segment.Name == name) return segment;
            }
            return null;
        }

        public Segment FindPreviousSegment(String name, Segment current)
        {
            var node = _segments.Find(current);
            if ( node == null) throw new NullReferenceException();
            
            while (node.Previous != null)
            {
                node = node.Previous;
                if (node.Value.Name == name) return node.Value;
            }
            return null;
        }

        public Segment FindNextSegment(String name, Segment current)
        {
            var node = _segments.Find(current);
            if (node == null) throw new NullReferenceException();

            while (node.Next != null)
            {
                node = node.Next;
                if (node.Value.Name == name) return node.Value;
            }
            return null;
        }


        public void Parse(String text)
        {
            Clear();
            
            char[] delimiter = { '\r' };
            var tokens = text.Split(delimiter, StringSplitOptions.None);
            
            foreach (var item in tokens)
            {
                var segment = new Segment();
                segment.Parse(item.Trim('\n'));
                Add(segment);
            }
        }

        public String Serialize()
        {
            var builder = new StringBuilder();
            char[] delimiter = { '\r','\n' };

            foreach (var segment in _segments)
            {
                builder.Append(segment.Serialize());
                builder.Append("\r\n");
            }
            return builder.ToString().TrimEnd(delimiter);
        }
    }
}
