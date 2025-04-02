using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace AutomationProject.Tests
{
    public class SelectMenu
    {
        IWebDriver webDriver;

        [Test]
        public void SelectMenuTest()
        {
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://demoqa.com/");
            webDriver.Manage().Window.Maximize();

            IJavaScriptExecutor jsExec = (IJavaScriptExecutor)webDriver;
            jsExec.ExecuteScript("window.scrollTo(0,1000)");

            IWebElement widgetsButton = webDriver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][4]"));
            widgetsButton.Click();

            jsExec.ExecuteScript("window.scrollTo(0,1000)");
            IWebElement selectMenu = webDriver.FindElement(By.XPath("//span[text()='Select Menu']"));
            selectMenu.Click();

            //make element selectable type

            IWebElement oldStyleMenu = webDriver.FindElement(By.Id("oldSelectMenu"));
            SelectElement dropDownOldStyle = new SelectElement(oldStyleMenu);
            //dropDown.SelectByValue("2");
            dropDownOldStyle.SelectByText("Yellow");

            IWebElement selectMultiple = webDriver.FindElement(By.Id("cars"));
            SelectElement standardMultiSelect = new SelectElement(selectMultiple);
            standardMultiSelect.SelectByValue("saab");
            standardMultiSelect.SelectByValue("opel");

        }

        [TearDown]
        public void TearDown()
        {
            webDriver.Close();
        }
    }
}
