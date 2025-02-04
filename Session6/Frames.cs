using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.Session6
{
    public class Frames
    {
        IWebDriver webDriver;

        [Test]
        public void FramesInteractions()
        {
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://demoqa.com/");
            webDriver.Manage().Window.Maximize();

            IJavaScriptExecutor jsExec = (IJavaScriptExecutor)webDriver;
            jsExec.ExecuteScript("window.scrollTo(0,1000)");

            IWebElement framesButton = webDriver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][3]"));
            framesButton.Click();

            List<IWebElement> listFrames = webDriver.FindElements(By.XPath("//div[@class='element-list collapse show']//li[@class='btn btn-light ']")).ToList();
            listFrames[2].Click();

            IWebElement frame1 = webDriver.FindElement(By.Id("frame1"));

            webDriver.SwitchTo().Frame(frame1);

            IWebElement textFrame1 = webDriver.FindElement(By.Id("sampleHeading"));
            Console.WriteLine($"Text is: { textFrame1.Text}");

            webDriver.SwitchTo().DefaultContent();
            IWebElement frame2 = webDriver.FindElement(By.Id("frame2"));
            webDriver.SwitchTo().Frame(frame2);

            IWebElement textFrame2 = webDriver.FindElement(By.Id("sampleHeading"));
            Console.WriteLine($"Text is: {textFrame2.Text}");

        }

        [TearDown]
        public void TearDown()
        {
            webDriver.Close();
            webDriver.Dispose();
        }
    }
}
