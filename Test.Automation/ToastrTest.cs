using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Automation
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver driver;

        [TestInitialize]
        public void AssemblyInitialize()
        {
            this.driver = new ChromeDriver("Drivers/");
        }

        [TestCleanup]
        public void AssemblyCleanup()
        {
            this.driver.Close();
        }


        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
