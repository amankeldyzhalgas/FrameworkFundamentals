// <copyright file="CustomerExtension.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CustomerLibrary
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Contains information about customer.
    /// </summary>
    public class CustomerExtension : ICustomFormatter
    {
        private IFormatProvider Provider { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerExtension"/> class.
        /// </summary>
        /// <param name="provider">IFormatProvider.</param>
        public CustomerExtension(IFormatProvider provider = null)
        {
            this.Provider = provider ?? CultureInfo.CurrentCulture;
        }

        /// <summary>
        /// Returns information about customer.
        /// </summary>
        /// <param name="format">Letter of the format.</param>
        /// <param name="arg">Argument.</param>
        /// <param name="formatProvider">IFormatProvider.</param>
        /// <returns>Returns string Representation of the customer.</returns>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "NC";
            }

            if (formatProvider is null)
            {
                formatProvider = this.Provider;
            }

            if (format != "NC")
            {
                return string.Format(formatProvider, "{0:" + format + "}", arg);
            }

            if (arg is null)
            {
                throw new ArgumentNullException($"{nameof(arg)} shouldn' t be null.");
            }

            if (arg.GetType() != typeof(Customer))
            {
                throw new ArgumentException($"The format of '{format}' is invalid.");
            }

            Customer customer = (Customer)arg;

            return string.Format("Customer record: {0}, {1}", customer.Name, customer.ContactPhone);
        }
    }
}
