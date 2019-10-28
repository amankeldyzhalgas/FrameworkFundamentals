// <copyright file="Customer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CustomerLibrary
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Contains information about customer.
    /// </summary>
    public class Customer : IFormattable
    {
        /// <summary>
        /// Gets Name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets ContactPhone.
        /// </summary>
        public string ContactPhone { get; private set; }

        private decimal Revenue { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        /// <param name="name">Customer Name.</param>
        /// <param name="contactPhone">Customer ContactPhone.</param>
        /// <param name="revenue">Customer Revenue.</param>
        public Customer(string name, string contactPhone, decimal revenue)
        {
            if (name is null || contactPhone is null)
            {
                throw new ArgumentNullException($"{name}, {contactPhone} are required parameters.");
            }

            if (revenue < 0)
            {
                throw new ArgumentException($"{revenue} must be positive.");
            }

            this.Name = name;
            this.ContactPhone = contactPhone;
            this.Revenue = revenue;
        }

        /// <summary>
        /// Returns information about customer.
        /// </summary>
        /// <param name="format">Letter of the format.</param>
        /// <returns>String Representation of the customer.</returns>
        public string ToString(string format)
        {
            return this.ToString(format, CultureInfo.GetCultureInfo("en-US"));
        }

        /// <summary>
        /// Returns information about customer.
        /// </summary>
        /// <param name="format">Letter of the format.</param>
        /// <param name="formatProvider">IFormatProvider.</param>
        /// <returns>Returns string Representation of the customer.</returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "F";
            }

            if (formatProvider == null)
            {
                formatProvider = CultureInfo.GetCultureInfo("en-US");
            }

            string result = "Customer record";
            switch (format)
            {
                case "F":
                    return string.Format("{0}: {1}, {2}, {3}", result, this.Name, this.Revenue.ToString("C", formatProvider), this.ContactPhone);
                case "C":
                    return string.Format("{0}: {1}", result, this.ContactPhone);
                case "NR":
                    return string.Format("{0}: {1}, {2:C}", result, this.Name, this.Revenue.ToString("C", formatProvider));
                case "N":
                    return string.Format("{0}: {1}", result, this.Name);
                case "R":
                    return string.Format("{0}: {1}", result, this.Revenue);
                default:
                    throw new FormatException(string.Format("The {0} format string is not supported.", format));
            }
        }
    }
}