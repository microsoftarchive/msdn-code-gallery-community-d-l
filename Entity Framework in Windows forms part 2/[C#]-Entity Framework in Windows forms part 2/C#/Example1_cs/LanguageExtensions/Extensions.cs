using EntityFrameWorkNorthWind_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Example1_cs
{
    public static class Extensions
    {
        /// <summary>
        /// Check if BindingSource.Current has data
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static bool IsValid(this Customer sender)
        {
            return (sender != null);
        }
        /// <summary>
        /// Determines if the current item is not null
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static bool CurrentRowIsValid(this BindingSource sender)
        {
            return (sender.Current != null);
        }
        /// <summary>
        /// Returns Customer for the current property
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static Customer Customer(this BindingSource sender)
        {
            return ((Customer)sender.Current);
        }
        /// <summary>
        /// Get names of an Enum
        /// </summary>
        /// <param name="sender">Type of Enum (see example)</param>
        /// <returns>Names of members in Enum</returns>
        public static string[] Names(this Type sender)
        {
            return Enum.GetNames(sender);
        }

        /// <summary>
        /// Converts string value to a member of an Enum
        /// </summary>
        /// <typeparam name="T">Valid Enum structure</typeparam>
        /// <param name="sender">String to convert</param>
        /// <returns>A member of the enum</returns>
        /// <example>
        /// <code source="CodeExamples\EnumExamples.vb" language="vbnet" title="VB.NET Examples"/>
        /// </example>
        public static T ToEnum<T>(this string sender)
        {
            Type senderType = typeof(T);

            if (Enum.IsDefined(typeof(T), sender))
            {
                return (T)Enum.Parse(senderType, sender, true);
            }
            else
            {
                string baseType = senderType.ToString();
                int position = baseType.IndexOf('+');
                string errorMessage = "";

                if (position > -1)
                {
                    string EnumName = baseType.Substring(position + 1);
                    errorMessage = string.Format("'{0}' not a member of '{1}'", sender, EnumName);
                }
                else
                {
                    errorMessage = string.Format("{0} not a member of {1}", sender, senderType);
                }

                throw new Exception(errorMessage);

            }
        }
        /// <summary>
        /// Used to filter data via a generic object using lambda
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="filterParam"></param>
        /// <returns></returns>
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> list, Func<T, bool> filterParam)
        {
            return list.Where(filterParam);
        }
        /// <summary>
        /// Expand all columns excluding in this case Orders column
        /// </summary>
        /// <param name="sender"></param>
        public static void ExpandColumns(this DataGridView sender)
        {
            foreach (DataGridViewColumn col in sender.Columns)
            {
                // ensure we are not attempting to do this on a Entity
                if (col.ValueType.Name != "ICollection`1")
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
        }
        /// <summary>
        /// Provides functionality to get a distinct list of items used in a lambda Distint call.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="sender"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> sender, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> knownKeys = new HashSet<TKey>();

            foreach (TSource element in sender)
            {
                if (knownKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
    }
}
