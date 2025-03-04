using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutomationProject.Session8
{
    public class Alerts
    {
        IWebDriver webDriver;

        [Test]
        public void AlertsInteractions()
        {
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://demoqa.com/");
            webDriver.Manage().Window.Maximize();

            IJavaScriptExecutor jsExec = (IJavaScriptExecutor)webDriver;
            jsExec.ExecuteScript("window.scrollTo(0,1000)");

            IWebElement alertsButton = webDriver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][3]"));
            alertsButton.Click();

            List<IWebElement> listItems = webDriver.FindElements(By.XPath("//div[@class='element-list collapse show']//li[@class='btn btn-light ']")).ToList();
            listItems[1].Click();

            IWebElement alertButton1 = webDriver.FindElement(By.Id("alertButton"));
            alertButton1.Click();

            IAlert alertOK = webDriver.SwitchTo().Alert();
            alertOK.Accept();

            IWebElement alertButton2 = webDriver.FindElement(By.Id("timerAlertButton"));
            alertButton2.Click();

            WebDriverWait wait = new WebDriverWait(webDriver,TimeSpan.FromSeconds(7));
            wait.Until(ExpectedConditions.AlertIsPresent());

            IAlert alertDelay = webDriver.SwitchTo().Alert();
            alertDelay.Accept();

            IWebElement alertButton3 = webDriver.FindElement(By.Id("confirmButton"));
            alertButton3.Click();

            IAlert alertConfirm = webDriver.SwitchTo().Alert();
            alertConfirm.Dismiss();

            IWebElement alertButton4 = webDriver.FindElement(By.Id("promtButton"));
            alertButton4.Click();

            IAlert alertprompt = webDriver.SwitchTo().Alert();
            alertprompt.SendKeys("test alerts");
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
