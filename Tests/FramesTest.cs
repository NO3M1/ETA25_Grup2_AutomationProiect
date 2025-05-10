using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationProject.HelperMethods;
using AutomationProject.Pages;
using Grup2_AutomationProject.NET.Pages;
using Grup2_AutomationProject.NET.HelperMethods;

namespace AutomationProject.Tests
{
    public class FramesTest
    {
        IWebDriver webDriver;
        ElementMethods elementMethods;
        HomePage homePage;
        CommonPage commonPage;
        FramesPage framesPage;
        JavascriptMethod jsMethods;

        

        [Test]
        public void FramesInteractions()
        {
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://demoqa.com/");
            webDriver.Manage().Window.Maximize();

            elementMethods = new ElementMethods(webDriver);
            homePage = new HomePage(webDriver);
            commonPage = new CommonPage(webDriver);
            framesPage = new FramesPage(webDriver);
            
            homePage.ClickOnAlertsFrameElement();
            commonPage.GoToMenu("Frames");

            framesPage.GetTextFromFrame1();

            //revenim la main content
            webDriver.SwitchTo().DefaultContent();

            framesPage.GetTextFromFrame2();


/*          OLD CODE 
 *           
            IJavaScriptExecutor jsExec = (IJavaScriptExecutor)webDriver;
            jsExec.ExecuteScript("window.scrollTo(0,1000)");

            //IWebElement framesButton = webDriver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][3]"));
            IWebElement framesButton = webDriver.FindElement(By.Id("item-2"));
            elementMethods.ClickOnElement(framesButton);

            List<IWebElement> listFrames = webDriver.FindElements(By.XPath("//div[@class='element-list collapse show']//li[@class='btn btn-light ']")).ToList();
            elementMethods.ClickOnElement(listFrames[2]);

            IWebElement frame1 = webDriver.FindElement(By.Id("frame1"));

            webDriver.SwitchTo().Frame(frame1);

            IWebElement textFrame1 = webDriver.FindElement(By.Id("sampleHeading"));
            Console.WriteLine($"Text Frame 1 is: {textFrame1.Text}");

            webDriver.SwitchTo().DefaultContent();
            IWebElement frame2 = webDriver.FindElement(By.Id("frame2"));
            webDriver.SwitchTo().Frame(frame2);

            IWebElement textFrame2 = webDriver.FindElement(By.Id("sampleHeading"));
            Console.WriteLine($"Text Frame 2 is: {textFrame2.Text}");*/

        }

        [Test]
        public void NestedFrames()
        {
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://demoqa.com/");
            webDriver.Manage().Window.Maximize();

            elementMethods = new ElementMethods(webDriver);

            IJavaScriptExecutor jsExec = (IJavaScriptExecutor)webDriver;
            jsExec.ExecuteScript("window.scrollTo(0,1000)");

            IWebElement alertsFramesButton = webDriver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][3]"));
            elementMethods.ClickOnElement(alertsFramesButton);

            List<IWebElement> listFrames = webDriver.FindElements(By.XPath("//div[@class='element-list collapse show']//li[@class='btn btn-light ']")).ToList();
            elementMethods.ClickOnElement(listFrames[3]);

            IWebElement parentFrame = webDriver.FindElement(By.Id("frame1"));
            webDriver.SwitchTo().Frame(parentFrame);

            string bodyText = webDriver.FindElement(By.TagName("body")).Text;
            Console.WriteLine("Parent frame body text is: " + bodyText);

            IWebElement childFrame = webDriver.FindElement(By.TagName("iframe"));
            webDriver.SwitchTo().Frame(childFrame);

            string childFrameText = webDriver.FindElement(By.TagName("p")).Text;
            Console.WriteLine("Child frame text is: " + childFrameText);

        }
        [Test]
        public void Modals()
        {
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://demoqa.com/");
            webDriver.Manage().Window.Maximize();

            elementMethods = new ElementMethods(webDriver);

            IJavaScriptExecutor jsExec = (IJavaScriptExecutor)webDriver;
            jsExec.ExecuteScript("window.scrollTo(0,1000)");

            IWebElement alertsFramesButton = webDriver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][3]"));
            elementMethods.ClickOnElement(alertsFramesButton);

            List<IWebElement> listFrames = webDriver.FindElements(By.XPath("//div[@class='element-list collapse show']//li[@class='btn btn-light ']")).ToList();
            elementMethods.ClickOnElement(listFrames[4]);

            IWebElement smallModal = webDriver.FindElement(By.Id("showSmallModal"));
            elementMethods.ClickOnElement(smallModal);
        }

          
 


        [TearDown]
        public void TearDown()
        {
            //webDriver.Close();
              webDriver.Dispose();
        }
    }
}
