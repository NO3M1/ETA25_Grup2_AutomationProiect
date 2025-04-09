using AutomationProject.HelperMethods;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.Pages
{
    public class HomePage
    {
        public IWebDriver webDriver;
        public ElementMethods elementMethods;

        public HomePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            elementMethods = new ElementMethods(webDriver);
        }

        IList<IWebElement> cards => webDriver.FindElements(By.XPath("//div[@class='card mt-4 top-card']"));
        IWebElement elementsButton => webDriver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][1]"));
        IWebElement formsButton => webDriver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][2]"));
        IWebElement alertsFrameButton => webDriver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][3]"));
        IWebElement widgetsButton => webDriver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][4]"));
        IWebElement interactionsButton => webDriver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][5]"));
        public void ClickOnElements()
        {
            elementMethods.ClickOnElement(elementsButton);
           // elementMethods.ClickOnElement(cards[0]);
        }
        
        public void ClickOnFormsElement()
        {
            elementMethods.ClickOnElement(formsButton);
        }

        public void ClickOnAlertsFrameElement()
        {
            elementMethods.ClickOnElement(cards[2]);
        }

        public void ClickOnWidgetsElement()
        {
            elementMethods.ClickOnElement(widgetsButton);
        }

        public void ClickOnInteractionsElement()
        {
            elementMethods.ClickOnElement(cards[4]);
        }

        public void ClickOnBookStoreElement()
        {
            elementMethods.ClickOnElement(cards[5]);
        }
    }
}
