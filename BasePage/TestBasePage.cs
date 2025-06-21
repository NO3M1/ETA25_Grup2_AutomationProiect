using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grup2_AutomationProject.NET.BasePage.Browser;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Grup2_AutomationProject.NET.BasePage
{
    public class TestBasePage
    {
        public WebDriver driver;

        [SetUp]
        public void InitializeBrowser()
        {
            driver = new BrowserFactory().GetGrowserFactory();
            driver.Navigate().GoToUrl("https://demoqa.com/");
        

        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
            driver.Dispose();
            //driver.Close();
        }

    }
}
