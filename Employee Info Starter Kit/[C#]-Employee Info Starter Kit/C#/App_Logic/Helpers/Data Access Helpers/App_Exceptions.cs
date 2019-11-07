/****************** Copyright Notice *****************
 
This code is licensed under Microsoft Public License (Ms-PL). 
You are free to use, modify and distribute any portion of this code. 
The only requirement to do that, you need to keep the developer name, as provided below to recognize and encourage original work:

=======================================================
   
Architecture Designed and Implemented By:
Mohammad Ashraful Alam
Microsoft Most Valuable Professional, ASP.NET 2007 – 2011
Twitter: http://twitter.com/AshrafulAlam | Blog: http://blog.ashraful.net | Portfolio: http://www.ashraful.net
   
*******************************************************/
using System;
namespace Eisk.Helpers
{
    public class InvalidDataKeyException : Exception
    {
        public InvalidDataKeyException(string message) : base(message) { }
    }

    public class NullValueNotAllowedException : Exception
    {
        public NullValueNotAllowedException(string message) : base(message) { }
    }

    public class EmptyValueNotAllowedException : Exception
    {
        public EmptyValueNotAllowedException(string message) : base(message) { }
    }

    public class DataNotUpdatedException : Exception
    {
        public DataNotUpdatedException(string message) : base(message) { }
    }

    public class BusinessRuleViolationOnInMemoryException : Exception
    {
        public BusinessRuleViolationOnInMemoryException(string message) : base(message) { }
    }

    public class BusinessRuleViolationOnDbAccessException : Exception
    {
        public BusinessRuleViolationOnDbAccessException(string message) : base(message) { }
    }
}
