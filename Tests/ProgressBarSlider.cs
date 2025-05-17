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
    public class ProgressBarSlider : TestBasePage
    {
  
        ElementMethods elementMethods;

        [Test]

        public void ProgressBar()
        {
            

            elementMethods = new ElementMethods(driver);

            IJavaScriptExecutor jsExec = (IJavaScriptExecutor)driver;
            jsExec.ExecuteScript("window.scrollTo(0,1000)");

            IWebElement widgetsButton = driver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][4]"));
            elementMethods.ClickOnElement(widgetsButton);

            List<IWebElement> listWidgets = driver.FindElements(By.XPath("//div[@class='element-list collapse show']//li[@class='btn btn-light ']")).ToList();
            jsExec.ExecuteScript("window.scrollTo(0,1000)");
            elementMethods.ClickOnElement(listWidgets[4]);

            IWebElement startBtn = driver.FindElement(By.Id("startStopButton"));
            elementMethods.ClickOnElement(startBtn);

            Thread.Sleep(3000); //wait  for 3 seconds

            elementMethods.ClickOnElement(startBtn); //stop

            IWebElement progressBar = driver.FindElement(By.XPath("//div[@class='progress']//div[@role='progressbar']"));

            Console.WriteLine($"Progress stopped at: {progressBar.GetAttribute("aria-valuenow")}%");

            elementMethods.ClickOnElement(startBtn);

            Thread.Sleep(10000);

            int progressValue = int.Parse(progressBar.GetAttribute("aria-valuenow"));

            if (progressValue == 100)
            {
                Console.WriteLine("Progress bar is 100%");
                IWebElement resetBtn = driver.FindElement(By.Id("resetButton"));
                elementMethods.ClickOnElement(resetBtn);
            }

            elementMethods.ClickOnElement(listWidgets[3]);

            IWebElement sliderValue = driver.FindElement(By.Id("sliderValue"));

            Console.WriteLine($"Initial slider value is: {sliderValue.GetAttribute("value")}");

            IWebElement slider = driver.FindElement(By.XPath("//input[@type='range']"));

            // Move the slider using Actions class
            Actions actions = new Actions(driver);
            actions.ClickAndHold(slider)
                   .MoveByOffset(30, 0) // Move the slider to the right
                   .Release()
                   .Perform();

            Thread.Sleep(2000);

            Console.WriteLine($"New slider value is: {sliderValue.GetAttribute("value")}");

            actions.ClickAndHold(slider)
                   .MoveByOffset(0, 50) // Move the slider to the left
                   .Release()
                   .Perform();

            Console.WriteLine($"New slider value is: {sliderValue.GetAttribute("value")}");

        }

     
    }
}
