// <copyright file="SumOfStrings.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SumOfStringsLibrary
{
    using System;
    using System.Numerics;

    /// <summary>
    /// A class to allow the sum of two big numbers
    /// that are strings and return a string.
    /// </summary>
    public static class SumOfStrings
    {
        /// <summary>
        /// Function that returns the sum of two big numbers.
        /// </summary>
        /// <param name="first">First Number.</param>
        /// <param name="second">Second Number.</param>
        /// <returns>Sum of two numbers.</returns>
        public static string GetSumOfTwoStrings(string first, string second)
        {
            if (string.IsNullOrEmpty(first))
            {
                throw new ArgumentException($"{nameof(first)} can't be null or empty.");
            }

            if (string.IsNullOrEmpty(second))
            {
                throw new ArgumentException($"{nameof(second)} can't be null or empty.");
            }

            bool successParseFirst = BigInteger.TryParse(first, out BigInteger a);
            bool successParseSecond = BigInteger.TryParse(second, out BigInteger b);

            if (!successParseFirst)
            {
                throw new ArgumentException($"{nameof(first)} can't convert to number.");
            }

            if (!successParseSecond)
            {
                throw new ArgumentException($"{nameof(first)} can't convert to number.");
            }

            return (a + b).ToString();
        }
    }
}
