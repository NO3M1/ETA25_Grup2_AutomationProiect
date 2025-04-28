using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.HelperMethods
{
    public class ElementMethods

    {   //initializam driver
        IWebDriver Driver;

        //constructor
        public ElementMethods(IWebDriver driver) 
        {
            Driver = driver;
            //tris.Driver = driver;
        } 

        //metode
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
