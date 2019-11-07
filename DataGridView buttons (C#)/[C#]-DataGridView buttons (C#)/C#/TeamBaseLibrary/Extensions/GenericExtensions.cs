using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamBaseLibrary.Extensions
{
    public static class GenericExtensions
    {
        /// <summary>
        /// Determine if object is a specific type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pObject"></param>
        /// <returns></returns>
        public static bool IsA<T>(this object pObject)
        {
            return pObject is T;
        }
    }
}
