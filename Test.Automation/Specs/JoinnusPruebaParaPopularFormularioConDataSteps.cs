using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace Test.Automation.Specs
{
    [Binding]
    public class JoinnusPruebaParaPopularFormularioConDataSteps
    {
        private IWebDriver driver;

        [Given(@"Abrir la pagina de Joinnus")]
        public void GivenAbrirLaPaginaDeJoinnus()
        {
            driver = new ChromeDriver(@"C:\Users\Administrador\source\repos\Automation\Test.Automation\Drivers\");
            driver.Navigate().GoToUrl(@"https://www.joinnus.com/PE");
        }
        
        [Given(@"Hacer click en el boton registrarse")]
        public void GivenHacerClickEnElBotonRegistrarse()
        {
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/table/tbody/tr/td[3]/div[3]/a")).Click();
            
        }
        
        [Then(@"Llenar datos en el formulario")]
        public void ThenLlenarDatosEnElFormulario()
        {
            driver.FindElement(By.XPath("/html/body/div[5]/div/div/form/div[1]/div[2]/div[2]/div/label/input")).SendKeys("Mi nombre");
            driver.FindElement(By.XPath("/html/body/div[5]/div/div/form/div[1]/div[2]/div[3]/div/label/input")).SendKeys("Mi apellido");
            driver.FindElement(By.XPath("/html/body/div[5]/div/div/form/div[1]/div[3]/label/input")).SendKeys("miemail@example.com");
            driver.FindElement(By.XPath("/html/body/div[5]/div/div/form/div[1]/div[4]/label/input")).SendKeys("miemail@example.com");
            driver.FindElement(By.XPath("/html/body/div[5]/div/div/form/div[1]/div[5]/label/input")).SendKeys("password");
            driver.FindElement(By.XPath("/html/body/div[5]/div/div/form/div[1]/div[7]/div/label[1]/input")).Click();

        }
        
        [Then(@"Hacer click en el boton cancelar")]
        public void ThenHacerClickEnElBotonCancelar()
        {
            Cleanup();
        }

        private void Cleanup()
        {
            Thread.Sleep(5000);

            //driver.Close();
            driver.Dispose();
        }
    }
}
