using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Test.Automation.PageModels;

namespace Test.Automation
{
    [TestClass]
    public class JSAlertTest
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
        public void AlertInteraction()
        {
            this.driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");
            this.driver.FindElement(By.XPath("/html/body/div[2]/div/div/ul/li[1]/button")).Click();
            var alert = this.driver.SwitchTo().Alert();
            var alertText = alert.Text;
            alert.Accept();
            var messageTest = this.driver.FindElement(By.Id("result")).Text;
            Assert.AreEqual("I am a JS Alert", alertText);
            Assert.AreEqual("You successfuly clicked an alert", messageTest);
            this.driver.FindElement(By.XPath("/html/body/div[2]/div/div/ul/li[2]/button")).Click();
            var secondAlert = this.driver.SwitchTo().Alert();
            var secondAlertTest = secondAlert.Text;
            secondAlert.Dismiss();
            var secondmessageTest = this.driver.FindElement(By.Id("result")).Text;
            Assert.AreEqual("You clicked: Cancel", secondmessageTest);
            Assert.AreEqual("I am a JS Confirm", secondAlertTest);
            this.driver.FindElement(By.XPath("/html/body/div[2]/div/div/ul/li[3]/button")).Click();
            var thirdAlert = this.driver.SwitchTo().Alert();
            thirdAlert.SendKeys("Daniel");
            thirdAlert.Accept();
            var thirdMessageTest = this.driver.FindElement(By.Id("result")).Text;
            Assert.AreEqual("You entered: Daniel", thirdMessageTest);
        }

        [TestMethod]
        public void AlertInteractionWithPageObjectModel()
        {
            var jsAlertPage = new JsAlertPaginaWeb(this.driver);
            jsAlertPage.ClickAlertButton();
            Assert.AreEqual("I am a JS Alert", jsAlertPage.GetAlertText());
            jsAlertPage.ClickOkOnAlert();
            Assert.AreEqual("You successfuly clicked an alert", jsAlertPage.GetResultTest());
            jsAlertPage.ClickConfirmButton();
            Assert.AreEqual("I am a JS Confirm", jsAlertPage.GetAlertText());
            jsAlertPage.ClickCancelOnAlert();
            Assert.AreEqual("You clicked: Cancel", jsAlertPage.GetResultTest());
            jsAlertPage.ClickPromptButton();
            jsAlertPage.WriteOnAlert("Daniel");
            jsAlertPage.ClickOkOnAlert();
            Assert.AreEqual("You entered: Daniel", jsAlertPage.GetResultTest());
        }


    }
}
