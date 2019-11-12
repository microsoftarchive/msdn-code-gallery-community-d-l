/*
 * The Following Code was developed by Dewald Esterhuizen
 * View Documentation at: http://softwarebydefault.com
 * Licensed under Ms-PL 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLSerializationGenericExtension
{
    public class CustomDataType
    {
        private int intMember = 0;
        public int IntMember
        {
            get { return intMember; }
            set { intMember = value; }
        }

        private string stringMember = String.Empty;
        public string StringMember
        {
            get { return stringMember; }
            set { stringMember = value; }
        }

        private DateTime dateTimeMember = DateTime.MinValue;
        public DateTime DateTimeMember
        {
            get { return dateTimeMember; }
            set { dateTimeMember = value; }
        }
    }
}
