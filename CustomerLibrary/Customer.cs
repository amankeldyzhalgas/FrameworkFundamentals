using System;
using System.Globalization;

namespace CustomerLibrary
{
    public class Customer : IFormattable
    {

        public string Name { get; set; }
        public string ContactPhone { get; set; }
        public decimal Revenue { get; set; }
        public Customer(string name, string contactPhone, decimal revenue)
        {
            Name = name;
            ContactPhone = contactPhone;
            Revenue = revenue;
        }

        public string ToString(string format)
        {
            return ToString(format, CultureInfo.GetCultureInfo("en-US"));
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (String.IsNullOrEmpty(format)) format = "F";

            if (formatProvider == null)
            {
                formatProvider = CultureInfo.GetCultureInfo("en-US");
            }
            string result = "Customer record";
            switch (format)
            {
                case "F":
                    return String.Format("{0}: {1}, {2}, {3}", result, Name, Revenue.ToString("C", formatProvider), ContactPhone);
                case "C":
                    return String.Format("{0}: {1}", result, ContactPhone);
                case "NR":
                    return String.Format("{0}: {1}, {2:C}", result, Name, Revenue.ToString("C", formatProvider));
                case "N":
                    return String.Format("{0}: {1}", result, Name);
                case "R":
                    return String.Format("{0}: {1}", result, Revenue);
                default:
                    throw new FormatException(String.Format("The {0} format string is not supported.", format));
            }
        }
    }
}
/*
     
        [TestCase("F", ExpectedResult = "Customer record: Jeffrey Richter, 1,000,000.00, +1 (425) 555-0100")]
        [TestCase("C", ExpectedResult = "Customer record: +1 (425) 555-0100")]
        [TestCase("NR",ExpectedResult = "Customer record: Jeffrey Richter, 1,000,000.00")]
        [TestCase("N", ExpectedResult = "Customer record: Jeffrey Richter")]
        [TestCase("R", ExpectedResult = "Customer record: $1000000")]
        [TestCase("R", ExpectedResult = "Customer record: 1000000 €")]
        
        public string ToString(string format)
        {
            return new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000).ToString($"{format}");
        }
     */
