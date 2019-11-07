using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibraryUnitTest
{
    static class Extensions
    {
        /// <summary>
        /// Clone list which implements ICloneable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listToClone"></param>
        /// <returns></returns>
        public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }
        /// <summary>
        /// Determine if an array contains all elements in another array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="containingList"></param>
        /// <param name="lookupList"></param>
        /// <returns></returns>
        public static bool ContainsAll<T>(this IEnumerable<T> containingList, IEnumerable<T> lookupList)
        {
            return !lookupList.Except(containingList).Any();
        }
    }
}
