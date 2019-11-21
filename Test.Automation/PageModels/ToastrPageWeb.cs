using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Automation.PageModels
{
    public class ToastrPageWeb
    {
        private readonly IWebDriver _driver;
        private readonly string TITLE_XPATH = "/html/body/section/div/div[1]/div[1]/div[1]/div/input";
        private readonly string MESSAGE_XPATH = "/html/body/section/div/div[1]/div[1]/div[1]/div/textarea";
        private readonly string SHOW_TOAST_BUTTON_ID = "showtoast";
        private readonly string CLEAR_TOASTS_BUTTON_ID = "cleartoasts";
        private readonly string CLEAR_LAST_TOAST_BUTTON_ID = "clearlasttoast";
        private readonly string TOAST_CONTAINER_ID = "toast-container";
        private readonly string TOAST_CONTAINER_FIRST_ELEMENT_CLASSNAME = "toast";
        private readonly string TOAST_TITLE_CLASSNAME = "toast-title";
        private readonly string TOAST_MESSAGE_CLASSNAME = "toast-message";
        private readonly string CHECKBOX_CLOSE_BUTTON_ID = "closeButton";
        private readonly string CHECKBOX_ADD_BEHAVIOR_ID = "addBehaviorOnToastClick";
        private readonly string TOAST_TYPE_GROUP_ID = "toastTypeGroup";

        public ToastrPageWeb(IWebDriver driver)
        {
            _driver = driver;
            _driver.Navigate().GoToUrl(@"https://codeseven.github.io/toastr/demo.html");
        }

        public void WriteToastrTitle(string title)
        {
            _driver.FindElement(By.XPath(TITLE_XPATH)).SendKeys(title);
        }


        public void WriteToastrMessage(string message)
        {
            _driver.FindElement(By.XPath(MESSAGE_XPATH)).SendKeys(message);
        }


        public void ClickShowToastButton()
        {
            _driver.FindElement(By.Id(SHOW_TOAST_BUTTON_ID)).Click();
        }
        public void ClickClearToastsButton()
        {
            _driver.FindElement(By.Id(CLEAR_TOASTS_BUTTON_ID)).Click();
        }
        public void ClickClearLastToastButton()
        {
            _driver.FindElement(By.Id(CLEAR_LAST_TOAST_BUTTON_ID)).Click();
        }

        public void ClickToastContainerFistElement()
        {
            GetToastContainerFistElement().Click();
        }

        public void ClickOkOnAlertBehavior()
        {
            this._driver.SwitchTo().Alert().Accept();
        }


        public void SelectToastTypeSuccess()
        {
            //GetToastTypeGroupRadios().FindElements(By.ClassName("radio")).Where(w => By.TagName()).First(el => el.GetAttribute("value='success'"));

        }
        public void SelectToastTypeInfo() { }
        public void SelectToastTypeWarning() { }
        public void SelectToastTypeError() { }



        public string GetToastTitleResult()
        {
            return GetToastContainer().FindElement(By.ClassName(TOAST_TITLE_CLASSNAME)).Text;
        }
        public string GetToastMessageResult()
        {
            return GetToastContainer().FindElement(By.ClassName(TOAST_MESSAGE_CLASSNAME)).Text;
        }

        public string GetAlertBehaviorText()
        {
            return _driver.SwitchTo().Alert().Text;
        }

        public void SelectCheckboxCloseButton(bool check)
        {
            if (!check && IsSelectedCheckboxCloseButton())
            {
                ClickCheckboxCloseButton();
            }
            else if (check && !IsSelectedCheckboxCloseButton())
            {
                ClickCheckboxCloseButton();
            }
        }

        public void SelectCheckboxAddBehavior(bool check)
        {
            if (!check && IsSelectedCheckboxAddBehavior())
            {
                ClickCheckboxAddBehavior();
            }
            else if (check && !IsSelectedCheckboxAddBehavior())
            {
                ClickCheckboxAddBehavior();
            }
        }

        public bool IsSelectedCheckboxCloseButton()
        {
            return GetCheckboxCloseButton().Selected;
        }
        public bool IsSelectedCheckboxAddBehavior()
        {
            return GetCheckboxAddBehavior().Selected;
        }






        private IWebElement GetToastContainer()
        {
            return _driver.FindElement(By.Id(TOAST_CONTAINER_ID));
        }
        private IWebElement GetCheckboxCloseButton()
        {
            return _driver.FindElement(By.Id(CHECKBOX_CLOSE_BUTTON_ID));
        }
        private IWebElement GetCheckboxAddBehavior()
        {
            return _driver.FindElement(By.Id(CHECKBOX_ADD_BEHAVIOR_ID));
        }
        private IEnumerable<IWebElement> GetToastTypeGroupRadios()
        {
            return _driver.FindElement(By.Id(TOAST_TYPE_GROUP_ID)).FindElements(By.ClassName("radio"));
        }
        
        private IWebElement GetToastTypeSuccess()
        {
            return null;
            //return GetToastTypeGroupRadios().First(e => e.FindElement(By.TagName("input")).GetAttribute("value='success'"));
        }


        private IWebElement GetToastContainerFistElement()
        {
            return GetToastContainer().FindElement(By.ClassName(TOAST_CONTAINER_FIRST_ELEMENT_CLASSNAME));
        }

        private void ClickCheckboxCloseButton()
        {
            GetCheckboxCloseButton().Click();
        }

        private void ClickCheckboxAddBehavior()
        {
            GetCheckboxAddBehavior().Click();
        }

    }
}
