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
using Grup2_AutomationProject.NET.BasePage;

namespace AutomationProject.Tests
{
    public class Alerts : TestBasePage
    {
     
        ElementMethods elementMethods;

        [Test]
        public void AlertsInteractions()
        {
       

            elementMethods = new ElementMethods(driver);

            IJavaScriptExecutor jsExec = (IJavaScriptExecutor)driver;
            jsExec.ExecuteScript("window.scrollTo(0,1000)");

            IWebElement alertsButton = driver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][3]"));
            elementMethods.ClickOnElement(alertsButton);

            List<IWebElement> listItems = driver.FindElements(By.XPath("//div[@class='element-list collapse show']//li[@class='btn btn-light ']")).ToList();
            elementMethods.ClickOnElement(listItems[1]);

            IWebElement alertButton1 = driver.FindElement(By.Id("alertButton"));
            elementMethods.ClickOnElement(alertButton1);

            IAlert alertOK = driver.SwitchTo().Alert();
            alertOK.Accept();

            IWebElement alertButton2 = driver.FindElement(By.Id("timerAlertButton"));
            elementMethods.ClickOnElement(alertButton2);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(7));
            wait.Until(ExpectedConditions.AlertIsPresent());

            IAlert alertDelay = driver.SwitchTo().Alert();
            alertDelay.Accept();

            IWebElement alertButton3 = driver.FindElement(By.Id("confirmButton"));
            elementMethods.ClickOnElement(alertButton3);

            IAlert alertConfirm = driver.SwitchTo().Alert();
            alertConfirm.Dismiss();

            IWebElement alertButton4 = driver.FindElement(By.Id("promtButton"));
            elementMethods.ClickOnElement(alertButton4);

            IAlert alertprompt = driver.SwitchTo().Alert();
            alertprompt.SendKeys("test alerts");
            //elementMethods.FillElement(alertprompt, "Test Alerts");
            alertprompt.Accept();


        }
     
    }
}
