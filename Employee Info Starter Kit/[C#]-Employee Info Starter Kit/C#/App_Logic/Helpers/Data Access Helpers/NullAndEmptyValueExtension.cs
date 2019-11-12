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
    public static class NullAndEmptyValueExtension
    {
        //DateTime

        public static bool IsEmpty(this DateTime value)
        {
            return value == DateTime.MinValue;
        }

        public static bool IsEmpty(this DateTime? value)
        {
            if (value != null)
                return ((DateTime)value).IsEmpty();

            return false;
        }

        //string 

        public static bool IsEmpty(this string value)
        {
            return value == string.Empty;
        }

        public static bool IsNull(this string value)
        {
            return value == null;
        }

        public static bool IsInvalidKey(this string value)
        {
            return (value.IsEmpty() || string.IsNullOrWhiteSpace(value));
        }

        //byte array

        public static bool IsEmpty(this byte[] value)
        {
            if (value != null)
                return value.Length == 0;

            return false;
        }

        //int

        public static bool IsEmpty(this int value)
        {
            return value == 0;
        }

        public static bool IsEmpty(this int? value)
        {
            if (value != null)
                return ((int)value).IsEmpty();

            return false;
        }

        public static bool IsInvalidKey(this int value)
        {
            return value <=  0;
        }

        //big int

        public static bool IsEmpty(this Int64 value)
        {
            return value == 0;
        }

        public static bool IsEmpty(this Int64? value)
        {
            if (value != null)
                return ((Int64)value).IsEmpty();

            return false;
        }

        public static bool IsInvalidKey(this Int64 value)
        {
            return value <= 0;
        }

        //float

        public static bool IsEmpty(this float value)
        {
            return value == 0;
        }

        public static bool IsEmpty(this float? value)
        {
            if (value != null)
                return ((float)value).IsEmpty();

            return false;
        }

        //double

        public static bool IsEmpty(this double value)
        {
            return value == 0;
        }

        public static bool IsEmpty(this double? value)
        {
            if (value != null)
                return ((double)value).IsEmpty();

            return false;
        }

        //guid

        public static bool IsEmpty(this Guid value)
        {
            return value == Guid.Empty;
        }

        public static bool IsEmpty(this Guid? value)
        {
            if (value != null)
                return ((Guid)value).IsEmpty();

            return false;
        }

        public static bool IsInvalidKey(this Guid value)
        {
            return value.IsEmpty();
        }
        
    }
}
