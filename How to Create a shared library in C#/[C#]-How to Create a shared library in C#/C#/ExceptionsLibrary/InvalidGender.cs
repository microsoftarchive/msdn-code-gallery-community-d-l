using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsLibrary
{
    [Serializable]
    public class InvalidGender : Exception
    {
        public InvalidGender()
        {
        }

        public InvalidGender(string message)
            : base(message)
        {
        }

        public InvalidGender(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
