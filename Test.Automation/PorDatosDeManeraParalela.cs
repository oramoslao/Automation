using System;
using System.Collections.Generic;
using Automation.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

//[assembly: Parallelize(Workers = 10, Scope = ExecutionScope.MethodLevel)]
namespace Test.Automation
{
    [TestClass]
    public class PorDatosDeManeraParalela
    {
        private RemoteWebDriver webDriver;

        [TestInitialize]
        public void IniciarDriver()
        {
            this.webDriver = new ChromeDriver("Drivers/");
        }

        [DataTestMethod]
        [DynamicData(nameof(ListarBusquedas), DynamicDataSourceType.Method)]
        public void BusquedaEnWikipedia(Busqueda busqueda)
        {
            webDriver.Navigate().GoToUrl(@"https://www.wikipedia.org/");
            webDriver.FindElement(By.Id("searchInput")).SendKeys(busqueda.Descripcion);
            webDriver.FindElement(By.XPath("/html/body/div[2]/form/fieldset/button")).Click();
            var titulo = webDriver.FindElement(By.Id("firstHeading")).Text;
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
        public void EliminarElProcesoDelDriver()
        {
            this.webDriver.Dispose();
        }

    }
}
