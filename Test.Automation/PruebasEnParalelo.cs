using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace Test.Automation
{
    [TestClass]
    public class PruebasEnParalelo
    {
        private RemoteWebDriver webDriver;

        private static readonly string XPATH_EDICION = "/html/body/div[5]/div[1]/div[3]/div[1]/ul/li[2]/a";

        [TestInitialize]
        public void IniciarDriver()
        {
            this.webDriver = new ChromeDriver("Drivers/");
        }

        [TestMethod]
        public void TituloDeEdicionCorrecto1()
        {
            webDriver.Navigate().GoToUrl(@"https://es.wikipedia.org/wiki/Produbanco");
            webDriver.FindElement(By.XPath(XPATH_EDICION)).Click();
            string titulo = webDriver.FindElement(By.ClassName("firstHeading")).Text;
            Assert.IsTrue(titulo.Contains("«Produbanco»"));
        }

        [TestMethod]
        public void TituloDeEdicionCorrecto2()
        {
            webDriver.Navigate().GoToUrl(@"https://es.wikipedia.org/wiki/Produbanco");
            webDriver.FindElement(By.XPath(XPATH_EDICION)).Click();
            string titulo = webDriver.FindElement(By.ClassName("firstHeading")).Text;
            Assert.IsTrue(titulo.Contains("«Produbanco»"));
        }

        [TestMethod]
        public void TituloDeEdicionCorrecto3()
        {
            webDriver.Navigate().GoToUrl(@"https://es.wikipedia.org/wiki/Produbanco");
            webDriver.FindElement(By.XPath(XPATH_EDICION)).Click();
            string titulo = webDriver.FindElement(By.ClassName("firstHeading")).Text;
            Assert.IsTrue(titulo.Contains("«Produbanco»"));
        }

        [TestCleanup]
        public void EliminarElProcesoDelDriver()
        {
            this.webDriver.Close();
        }
    }
}
