// <copyright file="ReverseWords.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ReverseWordsLibrary
{
    using System;
    using System.Linq;

    /// <summary>
    /// A class to allow reverses all of the words within the string.
    /// </summary>
    public static class ReverseWords
    {
        /// <summary>
        /// Reverses all of the words within the string.
        /// </summary>
        /// <param name="word">Words.</param>
        /// <returns>Reversed string.</returns>
        public static string Reverse(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                throw new ArgumentException($"{nameof(word)} can't be null or empty.");
            }

            var result = word.Split(' ').Reverse();

            return string.Join(" ", result);
        }
    }
}
