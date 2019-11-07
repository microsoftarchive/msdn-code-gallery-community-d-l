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
    partial class BusinessLayerHelper
    {
        public static void ThrowErrorForInvalidDataKey(string dataFieldName)
        {
            throw new InvalidDataKeyException("Data field is not a valid data key. Data field name: " + dataFieldName);
        }

        public static void ThrowErrorForEmptyValue(string dataFieldName)
        {
            throw new EmptyValueNotAllowedException("Data field is not allowed to be empty. Data field name: " + dataFieldName);
        }

        public static void ThrowErrorForNullValue(string dataFieldName)
        {
            throw new NullValueNotAllowedException("Data field is not allowed to be null. Data field name: " + dataFieldName);
        }
    }
}
