using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAutomation;


namespace FluentAutomation
{
    [TestClass]
    public class HelloTest : FluentTest
    {

        public HelloTest()
        {
            SeleniumWebDriver.Bootstrap(
                SeleniumWebDriver.Browser.Chrome
            );
        }

        [TestMethod]
        public void TestMethod1()
        {
            I.Open("http://www.children.org/");
        }
    }
}
