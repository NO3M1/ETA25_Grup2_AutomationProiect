using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Grup2_AutomationProject.NET.BasePage
{
    public class TestBasePage
    {
        public IWebDriver driver;

        [SetUp]
        public void InitializeBrowser()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/");
            driver.Manage().Window.Maximize();

        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
            driver.Dispose();
            driver.Close();
        }

    }
}
