// <copyright file="UrlParameter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UrlParameterLibrary
{
    using System;

    /// <summary>
    /// A class implement manipulate URL parameters.
    /// </summary>
    public static class UrlParameter
    {
        /// <summary>
        /// A function  can manipulate URL parameters..
        /// </summary>
        /// <param name="url">URL.</param>
        /// <param name="keyValueParameter">Parameter.</param>
        /// <returns>New URL.</returns>
        public static string AddOrChangeUrlParameter(string url, string keyValueParameter)
        {
            if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(keyValueParameter))
            {
                throw new ArgumentException("Invadlid parameters");
            }

            var urlSplit = url.Split('?');
            var newUrl = urlSplit[0] + '?';

            if (urlSplit.Length == 1)
            {
                return newUrl + keyValueParameter;
            }

            var query = urlSplit[1];
            var pars = query.Split('&');
            var pName = keyValueParameter.Split('=')[0];
            var match = false;

            for (int i = 0; i < pars.Length; i++)
            {
                var param = pars[i];
                var paramName = param.Split('=')[0];
                var same = paramName == pName ? true : false;
                newUrl += (i != 0 ? "&" : string.Empty) + (same ? keyValueParameter : param);
                match |= same;
            }

            return newUrl + (match ? string.Empty : '&' + keyValueParameter);
        }
    }
}
