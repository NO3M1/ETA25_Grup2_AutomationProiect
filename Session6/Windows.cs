using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.Session6
{
    public class Windows
    {
        IWebDriver webDriver;

        [Test]
        public void WindowsInteractions()
        {
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://demoqa.com/");
            webDriver.Manage().Window.Maximize();

            IJavaScriptExecutor jsExec = (IJavaScriptExecutor)webDriver;
            jsExec.ExecuteScript("window.scrollTo(0,1000)");

            IWebElement framesButton = webDriver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][3]"));
            framesButton.Click();

            List<IWebElement> listFrames = webDriver.FindElements(By.XPath("//div[@class='element-list collapse show']//li[@class='btn btn-light ']")).ToList();
            listFrames[0].Click();

            IWebElement newTabButton = webDriver.FindElement(By.Id("tabButton"));
            newTabButton.Click();

            List<string> tabList = new List<string>(webDriver.WindowHandles);
            webDriver.SwitchTo().Window(tabList[1]);

            IWebElement textNewTab = webDriver.FindElement(By.Id("sampleHeading"));
            Console.WriteLine($"Text from new tab is: {textNewTab.Text}");

            webDriver.Close();
            webDriver.SwitchTo().Window(tabList[0]);

            IWebElement newWindowButton = webDriver.FindElement(By.Id("windowButton"));
            newWindowButton.Click();
            List<string> windowList = new List<string>(webDriver.WindowHandles);
            webDriver.SwitchTo().Window(windowList[1]);
            IWebElement textNewWindow = webDriver.FindElement(By.Id("sampleHeading"));
            Console.WriteLine($"Text from new window is: {textNewWindow.Text}");
        }
        [TearDown]
        public void TearDown()
        {
           // webDriver.Close();
            webDriver.Dispose();
        }
    }
}
