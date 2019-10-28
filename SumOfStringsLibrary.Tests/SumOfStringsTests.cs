using NUnit.Framework;

namespace SumOfStringsLibrary.Tests
{
    public class SumOfStringsTests
    {
        [TestCase("11111111111111111111111", "22222222222222222222222", ExpectedResult = "33333333333333333333333")]
        [TestCase("33333333333333333333333333333333333333333333333333333333", "22222222222222222222222222222222222222222222222222222222", ExpectedResult = "55555555555555555555555555555555555555555555555555555555")]
        public string GetSumOfTwoStrings_Tests(string first, string second)
        {
            return SumOfStrings.GetSumOfTwoStrings(first, second);
        }
    }
}