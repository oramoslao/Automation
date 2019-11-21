using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace Test.Automation.Specs
{
    [Binding]
    public class EsUnaPruebaParaVerLaEdicionDeWikipediaSteps
    {
        private IWebDriver driver;



        [Given(@"Estoy en la pagina de Wikipedia de Produbanco")]
        public void GivenEstoyEnLaPaginaDeWikipediaDeProdubanco()
        {
            driver = new ChromeDriver(@"C:\Users\Administrador\source\repos\Automation\Test.Automation\Drivers\");
            driver.Navigate().GoToUrl(@"https://es.wikipedia.org/wiki/Produbanco");
        }
        
        [Given(@"Hago click en editar")]
        public void GivenHagoClickEnEditar()
        {
            driver.FindElement(By.XPath("/html/body/div[5]/div[1]/div[3]/div[1]/ul/li[2]/a")).Click();
        }
        
        [Then(@"El titulo de la pagina de edicion deberia incluir a la palabra ""(.*)""")]
        public void ThenElTituloDeLaPaginaDeEdicionDeberiaIncluirALaPalabra(string p0)
        {
            var title = driver.FindElement(By.Id("firstHeading"));

            Assert.IsTrue(title.Text.Contains(p0));

            driver.Dispose();
        }
    }
}
