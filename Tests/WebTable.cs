using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationProject.HelperMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationProject.Tests
{
    public class WebTable
    {
        IWebDriver webDriver;
        ElementMethods elementMethods;

        [Test]
        public void WebTableMethod()
        {
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://demoqa.com/");
            webDriver.Manage().Window.Maximize();

            //initializam
            elementMethods = new ElementMethods(webDriver);

            IJavaScriptExecutor jsExec = (IJavaScriptExecutor)webDriver;
            jsExec.ExecuteScript("window.scrollTo(0,1000)");

            IWebElement elementsButton = webDriver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][1]"));
            elementMethods.ClickOnElement(elementsButton);

            IWebElement elementWebTables = webDriver.FindElement(By.XPath("//*[text()='Web Tables']"));
            elementMethods.ClickOnElement(elementWebTables);

            IWebElement addBtnWebTables = webDriver.FindElement(By.Id("addNewRecordButton"));
            elementMethods.ClickOnElement(addBtnWebTables);

            PopulateRegistrationForm(webDriver, "Noemi", "Sz", "test@email.com", "36", "5500", "IT");
            
            string firstNameInTable = GetColumnFromRow(4, 1);
            string lastNameInTable = GetColumnFromRow(4, 2);
            string emailInTable = GetColumnFromRow(4, 3);
            string ageInTable = GetColumnFromRow(4, 4);
            string salaryInTable = GetColumnFromRow(4, 5);
            string departamentInTable = GetColumnFromRow(4, 6);

            Assert.That(firstNameInTable.Equals("Noemi"));
            if (lastNameInTable.Equals("Sz"))
            {
                Console.WriteLine($"Is true, last name is: {lastNameInTable}");
            }

            elementMethods.ClickOnElement(addBtnWebTables);
            PopulateRegistrationForm(webDriver, "Noemi", "Sz", "test@email.com", "44", "6000", "Finance");

            firstNameInTable = GetColumnFromRow(5, 1);
            lastNameInTable = GetColumnFromRow(5, 2);
            emailInTable = GetColumnFromRow(5, 3);
            ageInTable = GetColumnFromRow(5, 4);
            salaryInTable = GetColumnFromRow(5, 5);
            departamentInTable = GetColumnFromRow(5, 6);

            Console.WriteLine($"Last name from table last entry is: {firstNameInTable}  {lastNameInTable}");

        }
        public string GetColumnFromRow(int rowIndex, int columnIndex)
        {
            IWebElement row = webDriver.FindElement(By.XPath($"//div[@class='rt-tr-group'][{rowIndex}]"));
            IWebElement column = row.FindElement(By.XPath($".//div[@class='rt-td'][{columnIndex}]"));

            return column.Text;
        }

        public void PopulateRegistrationForm(IWebDriver driver, string firstName, string lastName, string email, string age, string salary, string department)
        {

            IWebElement firstNameField = driver.FindElement(By.Id("firstName"));
            IWebElement lastNameField = driver.FindElement(By.Id("lastName"));
            IWebElement emailField = driver.FindElement(By.Id("userEmail"));
            IWebElement ageField = driver.FindElement(By.Id("age"));
            IWebElement salaryField = driver.FindElement(By.Id("salary"));
            IWebElement departmentField = driver.FindElement(By.Id("department"));
            IWebElement registrationSubmitBtn = webDriver.FindElement(By.Id("submit"));

            elementMethods.FillElement(firstNameField, firstName);
            elementMethods.FillElement(lastNameField, lastName);        
            elementMethods.FillElement(emailField, email);
            elementMethods.FillElement(ageField, age);
            elementMethods.FillElement(salaryField, salary);
            elementMethods.FillElement(departmentField, department);

            elementMethods.ClickOnElement(registrationSubmitBtn);

        }

        [TearDown]
        public void TearDown()
        {
            // driver.Quit();
            webDriver.Close();
        }
    }


}

