using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Test.Automation.PageModels;

namespace Test.Automation
{
    [TestClass]
    public class ToastrTest
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Initialize()
        {
            this.driver = new ChromeDriver("Drivers/");
        }

        [TestCleanup]
        public void Dispose()
        {
            this.driver.Close();
            this.driver.Dispose();
        }


        [TestMethod]
        public void ToastrInteration()
        {
            var TITLE_TEXT = "My title";
            var MESSAGE_TEXT = "My title";
            var toastrPage = new ToastrPageWeb(driver);
            toastrPage.WriteToastrTitle(TITLE_TEXT);
            toastrPage.WriteToastrMessage(MESSAGE_TEXT);

            toastrPage.SelectCheckboxAddBehavior(true);
            Thread.Sleep(2000);

            toastrPage.ClickShowToastButton();
            Assert.AreEqual(TITLE_TEXT, toastrPage.GetToastTitleResult());
            Assert.AreEqual(MESSAGE_TEXT, toastrPage.GetToastMessageResult());

            toastrPage.ClickToastContainerFistElement();
            Assert.AreEqual("You can perform some custom action after a toast goes away", toastrPage.GetAlertBehaviorText());
            toastrPage.ClickOkOnAlertBehavior();

            Thread.Sleep(5000);



        }

        [TestMethod]
        public void ToastrTypeInteration()
        {
            var toastrPage = new ToastrPageWeb(driver);
            
            
            
            
            toastrPage.ClickShowToastButton();
            
            //Assert.AreEqual(TITLE_TEXT, toastrPage.GetToastTitleResult());
            //Assert.AreEqual(MESSAGE_TEXT, toastrPage.GetToastMessageResult());

            

            Thread.Sleep(5000);



        }
    }
}
