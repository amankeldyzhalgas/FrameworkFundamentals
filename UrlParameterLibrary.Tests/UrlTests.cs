using NUnit.Framework;

namespace UrlParameterLibrary.Tests
{
    public class UrlTests
    {
        [TestCase("www.example.com", "key=value", ExpectedResult = "www.example.com?key=value")]
        [TestCase("www.example.com?key=value", "key2=value2", ExpectedResult = "www.example.com?key=value&key2=value2")]
        [TestCase("www.example.com?key=oldValue", "key=newValue", ExpectedResult = "www.example.com?key=newValue")]
        public string AddOrChangeUrlParameter_Tests(string url, string keyValueParameter)
        {
            return UrlParameter.AddOrChangeUrlParameter(url, keyValueParameter);
        }
    }
}