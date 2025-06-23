using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationProject.HelperMethods;
using Grup2_AutomationProject.NET.Access;
using Grup2_AutomationProject.NET.BasePage;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationProject.Tests
{
    public class WebTableTest : TestBasePage
    {
        
        ElementMethods elementMethods;
     
        [Test]
        public void WebTableMethod()
        {

            var webTableData = new WebTableData(1);


            //initializam
            elementMethods = new ElementMethods(driver);

            IJavaScriptExecutor jsExec = (IJavaScriptExecutor)driver;
            jsExec.ExecuteScript("window.scrollTo(0,1000)");

            IWebElement elementsButton = driver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][1]"));
            elementMethods.ClickOnElement(elementsButton);

            IWebElement elementWebTables = driver.FindElement(By.XPath("//*[text()='Web Tables']"));
            elementMethods.ClickOnElement(elementWebTables);

            IWebElement addBtnWebTables = driver.FindElement(By.Id("addNewRecordButton"));
            elementMethods.ClickOnElement(addBtnWebTables);

            PopulateRegistrationForm(driver,webTableData);
            
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
            PopulateRegistrationForm(driver, webTableData);

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
            IWebElement row = driver.FindElement(By.XPath($"//div[@class='rt-tr-group'][{rowIndex}]"));
            IWebElement column = row.FindElement(By.XPath($".//div[@class='rt-td'][{columnIndex}]"));

            return column.Text;
        }

        public void PopulateRegistrationForm(IWebDriver driver, WebTableData webTableData)
        {

            IWebElement firstNameField = driver.FindElement(By.Id("firstName"));
            IWebElement lastNameField = driver.FindElement(By.Id("lastName"));
            IWebElement emailField = driver.FindElement(By.Id("userEmail"));
            IWebElement ageField = driver.FindElement(By.Id("age"));
            IWebElement salaryField = driver.FindElement(By.Id("salary"));
            IWebElement departmentField = driver.FindElement(By.Id("department"));
            IWebElement registrationSubmitBtn = driver.FindElement(By.Id("submit"));

            elementMethods.FillElement(firstNameField, webTableData.FirstName);
            elementMethods.FillElement(lastNameField, webTableData.LastName);        
            elementMethods.FillElement(emailField, webTableData.UserEmail);
            elementMethods.FillElement(ageField, webTableData.Age);
            elementMethods.FillElement(salaryField, webTableData.Salary);
            elementMethods.FillElement(departmentField, webTableData.Department);

            elementMethods.ClickOnElement(registrationSubmitBtn);

        }

    }


}

