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
using Grup2_AutomationProject.NET.BasePage;

namespace AutomationProject.Tests
{
    public class FramesTest : TestBasePage
    {
       
        ElementMethods elementMethods;
        HomePage homePage;
        CommonPage commonPage;
        FramesPage framesPage;
        JavascriptMethod jsMethods;

        

        [Test]
        public void FramesInteractions()
        {
       
        

            elementMethods = new ElementMethods(driver);
            homePage = new HomePage(driver);
            commonPage = new CommonPage(driver);
            framesPage = new FramesPage(driver);
            
            homePage.ClickOnAlertsFrameElement();
            commonPage.GoToMenu("Frames");

            framesPage.GetTextFromFrame1();

            //revenim la main content
            driver.SwitchTo().DefaultContent();

            framesPage.GetTextFromFrame2();


/*          OLD CODE 
 *           
            IJavaScriptExecutor jsExec = (IJavaScriptExecutor)driver;
            jsExec.ExecuteScript("window.scrollTo(0,1000)");

            //IWebElement framesButton = driver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][3]"));
            IWebElement framesButton = driver.FindElement(By.Id("item-2"));
            elementMethods.ClickOnElement(framesButton);

            List<IWebElement> listFrames = driver.FindElements(By.XPath("//div[@class='element-list collapse show']//li[@class='btn btn-light ']")).ToList();
            elementMethods.ClickOnElement(listFrames[2]);

            IWebElement frame1 = driver.FindElement(By.Id("frame1"));

            driver.SwitchTo().Frame(frame1);

            IWebElement textFrame1 = driver.FindElement(By.Id("sampleHeading"));
            Console.WriteLine($"Text Frame 1 is: {textFrame1.Text}");

            driver.SwitchTo().DefaultContent();
            IWebElement frame2 = driver.FindElement(By.Id("frame2"));
            driver.SwitchTo().Frame(frame2);

            IWebElement textFrame2 = driver.FindElement(By.Id("sampleHeading"));
            Console.WriteLine($"Text Frame 2 is: {textFrame2.Text}");*/

        }

        [Test]
        public void NestedFrames()
        {
      

            elementMethods = new ElementMethods(driver);

            IJavaScriptExecutor jsExec = (IJavaScriptExecutor)driver;
            jsExec.ExecuteScript("window.scrollTo(0,1000)");

            IWebElement alertsFramesButton = driver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][3]"));
            elementMethods.ClickOnElement(alertsFramesButton);

            List<IWebElement> listFrames = driver.FindElements(By.XPath("//div[@class='element-list collapse show']//li[@class='btn btn-light ']")).ToList();
            elementMethods.ClickOnElement(listFrames[3]);

            IWebElement parentFrame = driver.FindElement(By.Id("frame1"));
            driver.SwitchTo().Frame(parentFrame);

            string bodyText = driver.FindElement(By.TagName("body")).Text;
            Console.WriteLine("Parent frame body text is: " + bodyText);

            IWebElement childFrame = driver.FindElement(By.TagName("iframe"));
            driver.SwitchTo().Frame(childFrame);

            string childFrameText = driver.FindElement(By.TagName("p")).Text;
            Console.WriteLine("Child frame text is: " + childFrameText);

        }
        [Test]
        public void Modals()
        {
         

            elementMethods = new ElementMethods(driver);

            IJavaScriptExecutor jsExec = (IJavaScriptExecutor)driver;
            jsExec.ExecuteScript("window.scrollTo(0,1000)");

            IWebElement alertsFramesButton = driver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][3]"));
            elementMethods.ClickOnElement(alertsFramesButton);

            List<IWebElement> listFrames = driver.FindElements(By.XPath("//div[@class='element-list collapse show']//li[@class='btn btn-light ']")).ToList();
            elementMethods.ClickOnElement(listFrames[4]);

            IWebElement smallModal = driver.FindElement(By.Id("showSmallModal"));
            elementMethods.ClickOnElement(smallModal);
        }

            
    }
}
