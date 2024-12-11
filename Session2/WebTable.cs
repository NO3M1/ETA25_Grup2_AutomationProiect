using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationProject.Session2
{
    public class WebTable
    {
        IWebDriver webDriver;

        [Test]
        public void WebTableMethod()
        {
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://demoqa.com/");
            webDriver.Manage().Window.Maximize();

            IJavaScriptExecutor jsExec = (IJavaScriptExecutor)webDriver;
            jsExec.ExecuteScript("window.scrollTo(0,1000)");

            IWebElement elementsButton = webDriver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][1]"));
            elementsButton.Click();

            IWebElement elementWebTables = webDriver.FindElement(By.XPath("//*[text()='Web Tables']"));
            elementWebTables.Click();

            IWebElement addBtnWebTables = webDriver.FindElement(By.Id("addNewRecordButton"));
            addBtnWebTables.Click();

            IWebElement popupRegistrationFirstName = webDriver.FindElement(By.Id("firstName"));
            IWebElement popupRegistrationLastName = webDriver.FindElement(By.Id("lastName"));
            IWebElement popupRegistrationEmail = webDriver.FindElement(By.Id("userEmail"));
            IWebElement popupRegistrationAge = webDriver.FindElement(By.Id("age"));
            IWebElement popupRegistrationSalary = webDriver.FindElement(By.Id("salary"));
            IWebElement popupRegistrationDepartment = webDriver.FindElement(By.Id("department"));

            popupRegistrationFirstName.SendKeys("Loredana");
            String lastName = "Penea";
            popupRegistrationLastName.SendKeys(lastName);
            popupRegistrationEmail.SendKeys("loredana.penea@email.com");
            popupRegistrationAge.SendKeys("36");
            popupRegistrationSalary.SendKeys("5000");
            popupRegistrationDepartment.SendKeys("IT");

            IJavaScriptExecutor jse = (IJavaScriptExecutor)webDriver;

            IWebElement popupRegistrationSubmitBtn = webDriver.FindElement(By.Id("submit"));
            //popupRegistrationSubmitBtn.Submit();
            jse.ExecuteScript("arguments[0].click();",popupRegistrationSubmitBtn);

            IWebElement newRowTable = webDriver.FindElement(By.XPath("//div[@class='rt-tr-group'][4]"));
            IWebElement firstName = webDriver.FindElement(By.XPath("//div[@class='rt-tr-group'][4]//*[@class='rt-td'][1]"));
            IWebElement lastNameInTable = webDriver.FindElement(By.XPath("//div[@class='rt-tr-group'][4]//*[@class='rt-td'][2]"));

            Assert.That(firstName.Text.Equals("Loredana"));
            if (lastNameInTable.Text.Equals(lastName))
            {
                Console.WriteLine("Is True");
            }

        }

       // [TearDown]
       // public void TearDown()
      //  {
            // driver.Quit();
           // webDriver.Close();
       // }
    }
    
    
 }
