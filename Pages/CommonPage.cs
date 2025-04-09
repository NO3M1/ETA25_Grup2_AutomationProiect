using AutomationProject.HelperMethods;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.Pages
{
    public class CommonPage
    {
        public IWebDriver webDriver;
        public ElementMethods elementMethods;
        public CommonPage(IWebDriver webDriver) 
        { 
            this.webDriver = webDriver;
            elementMethods = new ElementMethods(webDriver);
        }

        List<IWebElement> elementsList => webDriver.FindElements(By.XPath("//span[@class='text']")).ToList();
        public void GoToMenu(string menuItem)
        {
            elementMethods.SelectElementFromListByText(elementsList, menuItem);
        }
    }
}
