using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using AutomationProject.HelperMethods;
using Grup2_AutomationProject.NET.BasePage;

namespace AutomationProject.Tests
{
    public class SelectMenu : TestBasePage
    {
       
        ElementMethods elementMethods;

        [Test]
        public void SelectMenuTest()
        {
         
            elementMethods = new ElementMethods(driver);

            IJavaScriptExecutor jsExec = (IJavaScriptExecutor)driver;
            jsExec.ExecuteScript("window.scrollTo(0,1000)");

            IWebElement widgetsButton = driver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][4]"));
            elementMethods.ClickOnElement(widgetsButton);

            jsExec.ExecuteScript("window.scrollTo(0,1000)");
            IWebElement selectMenu = driver.FindElement(By.XPath("//span[text()='Select Menu']"));
            elementMethods.ClickOnElement(selectMenu);

            //make element selectable type

            IWebElement oldStyleMenu = driver.FindElement(By.Id("oldSelectMenu"));
            SelectElement dropDownOldStyle = new SelectElement(oldStyleMenu);
            //dropDown.SelectByValue("2");
            dropDownOldStyle.SelectByText("Yellow");

            IWebElement selectMultiple = driver.FindElement(By.Id("cars"));
            SelectElement standardMultiSelect = new SelectElement(selectMultiple);
            standardMultiSelect.SelectByValue("saab");
            standardMultiSelect.SelectByValue("opel");

        }

     }
}
