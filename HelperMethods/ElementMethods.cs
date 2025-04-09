using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.HelperMethods
{
    public class ElementMethods
    {
        IWebDriver Driver;

        public ElementMethods(IWebDriver driver) 
        {
            Driver = driver;
        }

        public void ClickOnElement(IWebElement element)
        {
            element.Click();
        }

        public void FillElement(IWebElement element, string text)
        {
            element.SendKeys(text);
        }
        
        public void SelectElementFromListByText(IList<IWebElement> elementsList, string text)
        {
            foreach (IWebElement element in elementsList)
            {
                if (element.Text == text)
                    ClickOnElement(element);
            }
        }
    }
}
