using AutomationProject.HelperMethods;
using Grup2_AutomationProject.NET.BasePage;
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
    public class Widgets : TestBasePage
    {

        ElementMethods elementMethods;

        [Test]

        public void AutoCompleteMethod()
        {
          

            elementMethods = new ElementMethods(driver); 

            IJavaScriptExecutor jsExec = (IJavaScriptExecutor)driver;
            jsExec.ExecuteScript("window.scrollTo(0,1000)");

            IWebElement widgetsButton = driver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][4]"));
            elementMethods.ClickOnElement(widgetsButton);

            driver.FindElement(By.XPath("//*[text()='Auto Complete']")).Click();

            IWebElement multipleColor = driver.FindElement(By.Id("autoCompleteMultipleInput"));
            elementMethods.ClickOnElement(multipleColor);
            elementMethods.FillElement(multipleColor, "Blue");
            elementMethods.FillElement(multipleColor, Keys.Enter);
            elementMethods.FillElement(multipleColor, "i");
            elementMethods.FillElement(multipleColor, Keys.ArrowDown);
            elementMethods.FillElement(multipleColor, Keys.ArrowDown);
            elementMethods.FillElement(multipleColor, Keys.Enter);
            IWebElement singleColor = driver.FindElement(By.Id("autoCompleteSingleInput"));
            elementMethods.ClickOnElement(singleColor);
            elementMethods.FillElement(singleColor, "magenta");
            elementMethods.FillElement(singleColor, Keys.Enter);

            jsExec.ExecuteScript("window.scrollTo(0,1000)");
            driver.FindElement(By.XPath("//*[text()='Select Menu']")).Click();

            IWebElement optionDropDown = driver.FindElement(By.Id("react-select-4-input"));
            IWebElement optionDropDownArrow = driver.FindElement(By.XPath("//*[@class=' css-tlfecz-indicatorContainer'][1]")); // By.XPath(//div[@id='withOptGroup']//*[@class=' css-tlfecz-indicatorContainer']);

            elementMethods.ClickOnElement(optionDropDownArrow);
            elementMethods.FillElement(optionDropDown, Keys.ArrowDown);
            elementMethods.FillElement(optionDropDown, Keys.ArrowDown);
            elementMethods.FillElement(optionDropDown, Keys.Enter);

            Actions actions = new Actions(driver);
            IWebElement titleDropDownArrow = driver.FindElement(By.XPath("//div[@id='selectOne']")); //(By.XPath("//div[@id='selectOne']//*[@class=' css-tlfecz-indicatorContainer']"));

            elementMethods.ClickOnElement(titleDropDownArrow);
            actions.SendKeys("Mr." + Keys.Enter)
                .Build()
                .Perform();

            //titleDropDown.SendKeys("mr");
            //titleDropDownArrow.SendKeys(Keys.ArrowDown);
            //titleDropDownArrow.SendKeys(Keys.ArrowDown);
            //titleDropDownArrow.SendKeys(Keys.Enter) ;
        }

    }
}
