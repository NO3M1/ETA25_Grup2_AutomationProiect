using AutomationProject.HelperMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationProject.Tests
{
    public class TextBoxTest
    {

        IWebDriver driver;
        ElementMethods elementMethods;

        [Test]
        public void TextBoxMethod()
        {
            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://demoqa.com/");
            driver.Manage().Window.Maximize();

            elementMethods = new ElementMethods(driver);

            IJavaScriptExecutor jsExec = (IJavaScriptExecutor)driver;
            jsExec.ExecuteScript("window.scrollTo(0,1000)");

            IWebElement elementsButton = driver.FindElement(By.XPath("//h5[text()='Elements']"));
            elementMethods.ClickOnElement(elementsButton);

            IWebElement elementTextBoxButton = driver.FindElement(By.XPath("//*[text()='Text Box']"));
            elementMethods.ClickOnElement(elementTextBoxButton);

            IWebElement textBoxFullName = driver.FindElement(By.Id("userName"));
            elementMethods.FillElement(textBoxFullName, "Nicoleta Loredana");

            IWebElement textBoxEmail = driver.FindElement(By.Id("userEmail"));
            elementMethods.FillElement(textBoxEmail, "loredana@email.com");

            IWebElement textBoxCurrentAddress = driver.FindElement(By.Id("currentAddress"));
            elementMethods.FillElement(textBoxCurrentAddress, "Street no.15 \n Craiova City");

            IWebElement textBoxPermanentAddress = driver.FindElement(By.Id("permanentAddress"));
            elementMethods.FillElement(textBoxPermanentAddress, "Street no.15 bis\n Craiova City");

            IWebElement buttonSubmit = driver.FindElement(By.Id("submit"));
            jsExec.ExecuteScript("window.scrollTo(0,1000)");
            elementMethods.ClickOnElement(buttonSubmit);

            IWebElement elementCheckBoxButon = driver.FindElement(By.XPath("//span[text()='Check Box']"));
            elementMethods.ClickOnElement(elementCheckBoxButon);

            IWebElement checkBoxExpandCollapse = driver.FindElement(By.XPath("//*[@id=\"tree-node\"]/ol/li/span/button"));
            jsExec.ExecuteScript("window.scrollTo(0,1000)");
            elementMethods.ClickOnElement(checkBoxExpandCollapse);

            IWebElement checkBoxDesktop = driver.FindElement(By.XPath("//*[@id=\"tree-node\"]/ol/li/ol/li[1]/span/label/span[1]"));
            elementMethods.ClickOnElement(checkBoxDesktop);
            bool checkBoxDesktopSelection = checkBoxDesktop.GetCssValue("svg").Contains("rct-icon rct-icon-uncheck");
            if (checkBoxDesktopSelection)
                Console.WriteLine("Check Box is not checked");
            else Console.WriteLine("Check Box is checked");

        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
//            driver.Close();
        }
    }
}