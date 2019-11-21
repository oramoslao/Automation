using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Automation.Pages
{
    public class InterbankElementsPage
    {
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[2]/div/div/a")]
        public IWebElement CajaSorpresaButtonLink { get; set; }

        //8 DNI
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[3]/div/div/div/div[1]/div[2]/form/div[1]/div[2]/input")]
        public IWebElement DNIInputElement { get; set; }


        //cell 9
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[3]/div/div/div/div[1]/div[2]/form/div[2]/input")]
        public IWebElement PhoneInputElement { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[3]/div/div/div/div[1]/div[2]/form/div[3]/input")]
        public IWebElement EmailInputElement { get; set; }
        
        
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[3]/div/div/div/div[1]/div[2]/form/button")]
        public IWebElement VerMisProductosButton { get; set; }

    }
}
