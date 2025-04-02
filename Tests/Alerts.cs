using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using AutomationProject.HelperMethods;

namespace AutomationProject.Tests
{
    public class Alerts
    {
        IWebDriver webDriver;
        ElementMethods elementMethods;

        [Test]
        public void AlertsInteractions()
        {
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://demoqa.com/");
            webDriver.Manage().Window.Maximize();

            elementMethods = new ElementMethods(webDriver);

            IJavaScriptExecutor jsExec = (IJavaScriptExecutor)webDriver;
            jsExec.ExecuteScript("window.scrollTo(0,1000)");

            IWebElement alertsButton = webDriver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][3]"));
            elementMethods.ClickOnElement(alertsButton);

            List<IWebElement> listItems = webDriver.FindElements(By.XPath("//div[@class='element-list collapse show']//li[@class='btn btn-light ']")).ToList();
            elementMethods.ClickOnElement(listItems[1]);

            IWebElement alertButton1 = webDriver.FindElement(By.Id("alertButton"));
            elementMethods.ClickOnElement(alertButton1);

            IAlert alertOK = webDriver.SwitchTo().Alert();
            alertOK.Accept();

            IWebElement alertButton2 = webDriver.FindElement(By.Id("timerAlertButton"));
            elementMethods.ClickOnElement(alertButton2);

            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(7));
            wait.Until(ExpectedConditions.AlertIsPresent());

            IAlert alertDelay = webDriver.SwitchTo().Alert();
            alertDelay.Accept();

            IWebElement alertButton3 = webDriver.FindElement(By.Id("confirmButton"));
            elementMethods.ClickOnElement(alertButton3);

            IAlert alertConfirm = webDriver.SwitchTo().Alert();
            alertConfirm.Dismiss();

            IWebElement alertButton4 = webDriver.FindElement(By.Id("promtButton"));
            elementMethods.ClickOnElement(alertButton4);

            IAlert alertprompt = webDriver.SwitchTo().Alert();
            alertprompt.SendKeys("test alerts");
            //elementMethods.FillElement(alertprompt, "Test Alerts");
            alertprompt.Accept();


        }
        [TearDown]
        public void TearDown()
        {
            // webDriver.Close();
            webDriver.Dispose();
        }
    }
}
