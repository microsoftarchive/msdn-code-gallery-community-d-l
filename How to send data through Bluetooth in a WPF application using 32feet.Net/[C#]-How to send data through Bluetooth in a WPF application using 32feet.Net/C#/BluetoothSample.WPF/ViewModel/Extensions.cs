// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Extensions.cs" company="saramgsilva">
//   Copyright (c) 2014 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   The extensions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BluetoothSample.ViewModel
{
    /// <summary>
    /// The extensions.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="list">
        /// The list.
        /// </param>
        /// <param name="listToAdd">
        /// The list to add.
        /// </param>
        /// <typeparam name="T">
        /// The type generic T.
        /// </typeparam>
        public static void Add<T>(this ObservableCollection<T> list, IEnumerable<T> listToAdd) where T : class
        {
            if (list == null)
            {
                throw new ArgumentNullException("list");
            }
            if (listToAdd == null)
            {
                throw new ArgumentNullException("listToAdd");
            }
            foreach (var item in listToAdd)
            {
                list.Add(item);   
            }
        }
    }
}