using System;
using System.Collections.Generic;
using Automation.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Test.Automation
{
    [TestClass]
    public class WikiPediaPorDatos
    {
        private IWebDriver driver;

        
        [TestInitialize]
        public void AssemblyInitialize()
        {
            this.driver = new ChromeDriver("Drivers/");
        }

        [DataTestMethod]
        [DynamicData(nameof(ListarBusquedas), DynamicDataSourceType.Method)]
        public void BusquedaEnWikipedia(Busqueda busqueda)
        {
            driver.Navigate().GoToUrl(@"https://www.wikipedia.org/");
            driver.FindElement(By.Id("searchInput")).SendKeys(busqueda.Descripcion);
            driver.FindElement(By.XPath("/html/body/div[2]/form/fieldset/button")).Click();
            var titulo = driver.FindElement(By.Id("firstHeading")).Text;
            Assert.AreEqual(titulo, busqueda.PrimerResultado);
        }


        public static IEnumerable<object[]> ListarBusquedas()
        {
            var provedorDeDatos = new ProveedorDeDatos();
            var productos = provedorDeDatos.ConsultarBusquedasDesdeExcel();
            foreach (var busqueda in productos)
            {
                yield return new object[] { busqueda };
            }
        }

        [TestCleanup]
        public void AssemblyCleanup()
        {
            this.driver.Close();
        }

    }

}