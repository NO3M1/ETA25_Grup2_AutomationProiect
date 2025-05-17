using AutomationProject.HelperMethods;
using Grup2_AutomationProject.NET.BasePage;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.Tests
{
    public class Windows : TestBasePage
    {
       
        ElementMethods elementMethods;

        [Test]
        public void WindowsInteractions()
        {
      

            elementMethods = new ElementMethods(driver);

            IJavaScriptExecutor jsExec = (IJavaScriptExecutor)driver;
            jsExec.ExecuteScript("window.scrollTo(0,1000)");

            IWebElement framesButton = driver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][3]"));
            elementMethods.ClickOnElement(framesButton);

            List<IWebElement> listFrames = driver.FindElements(By.XPath("//div[@class='element-list collapse show']//li[@class='btn btn-light ']")).ToList();
            elementMethods.ClickOnElement(listFrames[0]);

            IWebElement newTabButton = driver.FindElement(By.Id("tabButton"));
            elementMethods.ClickOnElement(newTabButton);

            List<string> tabList = new List<string>(driver.WindowHandles);
            driver.SwitchTo().Window(tabList[1]);

            IWebElement textNewTab = driver.FindElement(By.Id("sampleHeading"));
            Console.WriteLine($"Text from new tab is: {textNewTab.Text}");

            driver.Close();
            driver.SwitchTo().Window(tabList[0]);

            IWebElement newWindowButton = driver.FindElement(By.Id("windowButton"));
            elementMethods.ClickOnElement(newWindowButton);
            List<string> windowList = new List<string>(driver.WindowHandles);
            driver.SwitchTo().Window(windowList[1]);
            IWebElement textNewWindow = driver.FindElement(By.Id("sampleHeading"));
            Console.WriteLine($"Text from new window is: {textNewWindow.Text}");
        }

    }
}
