// <copyright file="Unique.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UniqueLibrary
{
    using System.Collections.Generic;

    /// <summary>
    /// A class implement the function which takes as argument a sequence and returns a list of items without any
    /// elements with the same value next to each other and preserving the original order of elements.
    /// </summary>
    public static class Unique
    {
        /// <summary>
        /// A function which takes as argument a sequence and returns a list of items without any
        /// elements with the same value next to each other and preserving the original order of elements.
        /// </summary>
        /// <typeparam name="T">The type of object.</typeparam>
        /// <param name="sequence">Sequence.</param>
        /// <returns>List of items without any elements with the same value next.</returns>
        public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> sequence)
        {
            T previous = default;
            foreach (var item in sequence)
            {
                if (!item.Equals(previous))
                {
                    yield return item;
                }

                previous = item;
            }
        }
    }
}
