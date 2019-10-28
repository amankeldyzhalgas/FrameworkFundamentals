using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace UniqueLibrary.Tests
{
    public class UniqueTests
    {
        [TestCase("AAAABBBCCDAABBB", ExpectedResult = "ABCDAB")]
        [TestCase("ABBCcAD", ExpectedResult = "ABCcAD")]
        [TestCase("12233", ExpectedResult = "123")]
        public List<char> UniqueInOrderString_Test(string list)
        {
            return Unique.UniqueInOrder(list).ToList();
        }

        [TestCase()]
        public void UniqueInOrderDouble_Test()
        {
            var list = new List<double>() { 1.1, 2.2, 2.2, 3.3 };
            var expected = new List<double>() { 1.1, 2.2, 3.3 };
            var result = Unique.UniqueInOrder(list).ToList();
            CollectionAssert.AreEqual(expected, result);
        }
    }
}