using System.Collections.Generic;
using System.Dynamic;

namespace CSharpDynamicUnitTest
{
    public static class BasicDynamicSamples
    {
        #region Dynamic Special Usages in Generic Type
        /// <summary>
        /// dynamic will automtically check whether the generic type supports operators such as +,-,*,/. If not, exceptions will be thrown out.
        /// So for dynamic, if we are sure that something has supported some methods……ect. We'RE SURE to directly use that without any intellisenses.
        /// And it's not an easy task to cope with a generic type with operators, because we don't know whether they have implemented these operators or not. So we have to SUPPOSE they've implemented them.
        /// </summary>
        public static T Add<T>(T num1, T num2) where T : struct
        {
            return (T)((dynamic)num1 + (dynamic)num2);
        }
        /// <summary>
        /// Dynamically attaching Properties, Events, Functions into an ExpandoObject
        /// </summary>
        public static dynamic DynamicObjectCreator(IDictionary<string, dynamic> propertyValuesMapping)
        {
            IDictionary<string, object> dynamicObj = new ExpandoObject();
            foreach (KeyValuePair<string, dynamic> item in propertyValuesMapping)
            {
                dynamicObj[item.Key] = item.Value;
            }
            return dynamicObj;
        }
        #endregion
    }
}