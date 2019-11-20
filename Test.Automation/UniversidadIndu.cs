using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;

namespace Test.Automation
{
    [TestClass]
    public class UniversidadIndu
    {
        private RemoteWebDriver webDriver;

        [TestInitialize]
        public void IniciarDriver()
        {
            this.webDriver = new FirefoxDriver("Drivers/");
        }

        [TestMethod]
        public void TituloDeEdicionCorrecto1()
        {
            webDriver.Navigate().GoToUrl(@"https://www.annauniv.edu/#");
            var elemento = webDriver.FindElement(By.XPath("/html/body/table/tbody/tr[1]/td[1]/table/tbody/tr/td[1]/table/tbody/tr/td/table/tbody/tr/td[5]/div/a"));
            elemento.Click();
            Actions action = new Actions(webDriver);
            var elementoParaHacerHover = webDriver
                                            .FindElement(By.XPath("/html/body/table/tbody/tr/td/table/tbody/tr[3]/td/table/tbody/tr[2]/td[2]/table/tbody/tr/td"))
                                            .FindElement(By.Id("link3"));
            action.MoveToElement(elementoParaHacerHover).MoveByOffset(1, 1).Build().Perform();
            Thread.Sleep(1000);
            webDriver.FindElement(By.Id("menuLite7"))
                     .FindElement(By.Id("menuItem32"))
                     .Click();
            Thread.Sleep(6000);
            var tittleIsCorrect = webDriver.Title.Contains("Institute For Ocean Management"); ;
            Assert.IsTrue(tittleIsCorrect);
        }

        [TestCleanup]
        public void EliminarElProcesoDelDriver()
        {
            this.webDriver.Close();
        }
    }
}
