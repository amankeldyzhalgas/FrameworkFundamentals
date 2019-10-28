// <copyright file="TitleCase.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TitleCaseLibrary
{
    using System;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// A class to allow convert a string into title case,
    /// given an optional list of exceptions (minor words).
    /// </summary>
    public static class TitleCase
    {
        /// <summary>
        /// A function that will convert a string into title case.
        /// </summary>
        /// <param name="original">Original string.</param>
        /// <returns>Converted string.</returns>
        public static string GetTitleCase(string original)
        {
            if (string.IsNullOrEmpty(original))
            {
                throw new ArgumentException($"{nameof(original)} can't be null or empty.");
            }

            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(original.ToLower());
        }

        /// <summary>
        /// A function that will convert a string into title case,
        /// given an optional list of exceptions (minor words).
        /// </summary>
        /// <param name="minor">Minor words.</param>
        /// <param name="original">Original string.</param>
        /// <returns>Converted string.</returns>
        public static string GetTitleCase(string minor, string original)
        {
            if (string.IsNullOrEmpty(original) || string.IsNullOrEmpty(minor))
            {
                throw new ArgumentException("Invadlid parameters");
            }

            var words = original.ToLower().Split(' ');
            var exceptions = minor.ToLower().Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (!exceptions.Contains(words[i]) || i == 0)
                {
                    words[i] = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(words[i]);
                }
            }

            return string.Join(" ", words);
        }
    }
}
