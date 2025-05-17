using AutomationProject.HelperMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.Tests
{
    public class Widgets
    {
        IWebDriver webDriver;
        ElementMethods elementMethods;

        [Test]

        public void AutoCompleteMethod()
        {
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://demoqa.com/");
            webDriver.Manage().Window.Maximize();

            elementMethods = new ElementMethods(webDriver); 

            IJavaScriptExecutor jsExec = (IJavaScriptExecutor)webDriver;
            jsExec.ExecuteScript("window.scrollTo(0,1000)");

            IWebElement widgetsButton = webDriver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][4]"));
            elementMethods.ClickOnElement(widgetsButton);

            webDriver.FindElement(By.XPath("//*[text()='Auto Complete']")).Click();

            IWebElement multipleColor = webDriver.FindElement(By.Id("autoCompleteMultipleInput"));
            elementMethods.ClickOnElement(multipleColor);
            elementMethods.FillElement(multipleColor, "Blue");
            elementMethods.FillElement(multipleColor, Keys.Enter);
            elementMethods.FillElement(multipleColor, "i");
            elementMethods.FillElement(multipleColor, Keys.ArrowDown);
            elementMethods.FillElement(multipleColor, Keys.ArrowDown);
            elementMethods.FillElement(multipleColor, Keys.Enter);
            IWebElement singleColor = webDriver.FindElement(By.Id("autoCompleteSingleInput"));
            elementMethods.ClickOnElement(singleColor);
            elementMethods.FillElement(singleColor, "magenta");
            elementMethods.FillElement(singleColor, Keys.Enter);

            jsExec.ExecuteScript("window.scrollTo(0,1000)");
            webDriver.FindElement(By.XPath("//*[text()='Select Menu']")).Click();

            IWebElement optionDropDown = webDriver.FindElement(By.Id("react-select-4-input"));
            IWebElement optionDropDownArrow = webDriver.FindElement(By.XPath("//*[@class=' css-tlfecz-indicatorContainer'][1]")); // By.XPath(//div[@id='withOptGroup']//*[@class=' css-tlfecz-indicatorContainer']);

            elementMethods.ClickOnElement(optionDropDownArrow);
            elementMethods.FillElement(optionDropDown, Keys.ArrowDown);
            elementMethods.FillElement(optionDropDown, Keys.ArrowDown);
            elementMethods.FillElement(optionDropDown, Keys.Enter);

            Actions actions = new Actions(webDriver);
            IWebElement titleDropDownArrow = webDriver.FindElement(By.XPath("//div[@id='selectOne']")); //(By.XPath("//div[@id='selectOne']//*[@class=' css-tlfecz-indicatorContainer']"));

            elementMethods.ClickOnElement(titleDropDownArrow);
            actions.SendKeys("Mr." + Keys.Enter)
                .Build()
                .Perform();

            //titleDropDown.SendKeys("mr");
            //titleDropDownArrow.SendKeys(Keys.ArrowDown);
            //titleDropDownArrow.SendKeys(Keys.ArrowDown);
            //titleDropDownArrow.SendKeys(Keys.Enter) ;
        }

        [TearDown]
        public void TearDown()
        {
            //driver.Quit();
            webDriver.Close();
        }
    }
}
