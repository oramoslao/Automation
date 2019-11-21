using System;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using Test.Automation.Pages;

namespace Test.Automation
{
    [TestClass]
    public class InterbankElementTest
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Initialize()
        {
            this.driver = new ChromeDriver("Drivers/");
        }

        [TestCleanup]
        public void Cleanup()
        {
            this.driver.Dispose();
        }


        [TestMethod]
        public void CajaSorpresaForm()
        {
            driver.Navigate().GoToUrl(@"https://interbank.pe/");
            var interbankElemntsPage = new InterbankElementsPage();
            PageFactory.InitElements(driver, interbankElemntsPage);

            interbankElemntsPage.CajaSorpresaButtonLink.Click();

            interbankElemntsPage.DNIInputElement.SendKeys("12345678");
            interbankElemntsPage.PhoneInputElement.SendKeys("987654321");
            interbankElemntsPage.EmailInputElement.SendKeys("octavio@example.com");
            interbankElemntsPage.VerMisProductosButton.Click();


            Thread.Sleep(5000);



        }
    }
}
