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
    public class AddRemoveElementTest
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
            this.driver.Close();
        }


        [TestMethod]
        public void AddTenElements()
        {
            driver.Navigate().GoToUrl(@"https://the-internet.herokuapp.com/add_remove_elements/");
            var addRemoveElementsPage = new AddRemoveElementsPage();
            PageFactory.InitElements(driver, addRemoveElementsPage);
            Enumerable.Range(1, 20).ToList().ForEach(number =>
            {
                addRemoveElementsPage.AddElementButton.Click();
                Thread.Sleep(500);
            });

            var newButtons = addRemoveElementsPage.NewButtons;
            Assert.AreEqual(newButtons.Count, 20);
            newButtons.ToList().ForEach(button =>
            {
                button.Click();
                Thread.Sleep(500);
            });



        }
    }
}
