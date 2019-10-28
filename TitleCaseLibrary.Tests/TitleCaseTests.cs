using NUnit.Framework;

namespace TitleCaseLibrary.Tests
{
    public class TitleCaseTests
    {
        [TestCase("a an the of", "a clash of KINGS", ExpectedResult = "A Clash of Kings")]
        [TestCase("The In", "THE WIND IN THE WILLOWS", ExpectedResult = "The Wind in the Willows")]
        public string GetTitleCase_Test(string minor, string original)
        {            
            return TitleCase.GetTitleCase(minor, original);
        }

        [TestCase("the quick brown fox", ExpectedResult = "The Quick Brown Fox")]
        public string GetTitleCase_Test(string original)
        {
            return TitleCase.GetTitleCase(original);
        }

    }
}