using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationProject.Session1
{
    public class TextBoxTest
    {

        IWebDriver driver;

        [Test]
        public void Test1()
        {
            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://demoqa.com/");
            driver.Manage().Window.Maximize();

            IJavaScriptExecutor jsExec = (IJavaScriptExecutor)driver;
            jsExec.ExecuteScript("window.scrollTo(0,1000)");

            IWebElement elementsButton = driver.FindElement(By.XPath("//h5[text()='Elements']"));
            elementsButton.Click();

            IWebElement elementTextBoxButton = driver.FindElement(By.XPath("//*[text()='Text Box']"));
            elementTextBoxButton.Click();

            IWebElement textBoxFullName = driver.FindElement(By.Id("userName"));
            textBoxFullName.SendKeys("Nicoleta Loredana");

            IWebElement textBoxEmail = driver.FindElement(By.Id("userEmail"));
            textBoxEmail.SendKeys("loredana@email.com");

            IWebElement textBoxCurrentAddress = driver.FindElement(By.Id("currentAddress"));
            textBoxCurrentAddress.SendKeys("Street no.15 \n Craiova City");

            IWebElement textBoxPermanentAddress = driver.FindElement(By.Id("permanentAddress"));
            textBoxPermanentAddress.SendKeys("Street no.15 bis\n Craiova City");

            IWebElement buttonSubmit = driver.FindElement(By.Id("submit"));
            jsExec.ExecuteScript("window.scrollTo(0,1000)");
            buttonSubmit.Click();
            
            IWebElement elementCheckBoxButon = driver.FindElement(By.XPath("//span[text()='Check Box']"));
            elementCheckBoxButon.Click();

            IWebElement elementExpandCollapse = driver.FindElement(By.XPath("//*[@id=\"tree-node\"]/ol/li/span/button"));
            jsExec.ExecuteScript("window.scrollTo(0,1000)");
            elementExpandCollapse.Click();

            IWebElement checkBoxDesktop = driver.FindElement(By.XPath("//*[@id=\"tree-node\"]/ol/li/ol/li[1]/span/label/span[1]"));
            checkBoxDesktop.Click();
            bool checkBoxDesktopSelection = checkBoxDesktop.GetCssValue("svg").Contains("rct-icon rct-icon-uncheck");
            if (checkBoxDesktopSelection)
                Console.WriteLine("Check Box is not checked");
            else Console.WriteLine("Check Box is checked");
            
        }

        [TearDown]
        public void TearDown()
        {
           // driver.Quit();
            driver.Close();
        }
    }
}