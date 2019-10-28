using NUnit.Framework;

namespace ReverseWordsLibrary.Tests
{
    public class ReverseTests
    {
        [TestCase("The greatest victory is that which requires no battle", ExpectedResult = "battle no requires which that is victory greatest The")]
        public string Reverse_Tests(string words)
        {
            return ReverseWords.Reverse(words);
        }
    }
}