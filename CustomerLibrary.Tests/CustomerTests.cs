using NUnit.Framework;
using System;
using System.Globalization;

namespace CustomerLibrary.Tests
{
    public class CustomerTests
    {

        [TestCase("F", ExpectedResult = "Customer record: Jeffrey Richter, $1,000,000.00, +1 (425) 555-0100")]
        [TestCase("C", ExpectedResult = "Customer record: +1 (425) 555-0100")]
        [TestCase("NR", ExpectedResult = "Customer record: Jeffrey Richter, $1,000,000.00")]
        [TestCase("N", ExpectedResult = "Customer record: Jeffrey Richter")]
        [TestCase("R", ExpectedResult = "Customer record: 1000000")]

        public string ToString(string format)
        {
            return new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000).ToString($"{format}");
        }

        [TestCase("Jeffrey Richter", "+1 (425) 555-0100", "1000000", "R", "en-US", "Customer record: 1000000")]
        [TestCase("Jeffrey Richter", "+1 (425) 555-0100", "1000000", "NC", "en-US", "Customer record: Jeffrey Richter, +1 (425) 555-0100")]
        [TestCase("Jeffrey Richter", "+1 (425) 555-0100", "1000000", "F", "en-US", "Customer record: Jeffrey Richter, $1,000,000.00, +1 (425) 555-0100")]
        public void Format(string name, string number, decimal revenue, string format, string provider, string expected)
        {
            Assert.AreEqual(new CustomerExtension().Format(format, new Customer(name, number, revenue),new CultureInfo(provider)), expected);
            Assert.AreEqual(new CustomerExtension().Format(format, new Customer(name, number, revenue), new CultureInfo(provider)), expected);
            Assert.AreEqual(new CustomerExtension().Format(format, new Customer(name, number, revenue), new CultureInfo(provider)), expected);
            //return new CustomerExtension().Format(format, new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000), new CultureInfo(provider));
        }

        [TestCase("A")]
        public void ToString_FormatException(string format)
        {
            Assert.Throws<FormatException>(() => new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000).ToString($"{format}"));
        }
    }
}