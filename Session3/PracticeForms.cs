using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.Session3
{
    public class PracticeForms
    {
        IWebDriver webDriver;

        [Test]

        public void FormsMethod()
        {
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://demoqa.com/");
            webDriver.Manage().Window.Maximize();

            IJavaScriptExecutor jsExec = (IJavaScriptExecutor)webDriver;
            jsExec.ExecuteScript("window.scrollTo(0,1000)");

            IWebElement formsButton = webDriver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][2]"));
            formsButton.Click();

            IWebElement elementPracticeForms = webDriver.FindElement(By.XPath("//*[text()='Practice Form']"));
            elementPracticeForms.Click();

            IWebElement genderMale = webDriver.FindElement(By.XPath("//label[@for='gender-radio-1']"));
            IWebElement genderFemale = webDriver.FindElement(By.XPath("//label[@for='gender-radio-2']"));
            IWebElement genderOther = webDriver.FindElement(By.XPath("//label[@for='gender-radio-3']"));

            string gender = "Male";

            //if (gender.Equals("Male"))
            //{
            //    genderMale.Click();
            //} else if (gender.Equals("Female"))
            //{
            //    genderFemale.Click();
            //} else { 
            //    genderOther.Click(); 
            //}

            switch (gender)
            {
                case "Male": 
                    genderMale.Click(); 
                    break;
                case "Female": 
                    genderFemale.Click();
                    break;
                case "Other":
                    genderOther.Click();
                    break;   
            }

            IWebElement elementSubjects = webDriver.FindElement(By.Id("subjectsInput"));
            elementSubjects.SendKeys("English");
            elementSubjects.SendKeys(Keys.Enter);
            elementSubjects.SendKeys("C");
            elementSubjects.SendKeys(Keys.ArrowDown);
            elementSubjects.SendKeys(Keys.ArrowDown);
            elementSubjects.SendKeys(Keys.ArrowDown);
            elementSubjects.SendKeys(Keys.Enter);

            //Date Picker

            IWebElement dateBirth = webDriver.FindElement(By.Id("dateOfBirthInput"));
            dateBirth.Click();

            IWebElement datePickerMonth = webDriver.FindElement(By.XPath("//select[@class='react-datepicker__month-select']"));
            SelectElement monthDropDown = new SelectElement(datePickerMonth);
            monthDropDown.SelectByValue("2");

            IWebElement datePickerYear = webDriver.FindElement(By.XPath("//select[@class='react-datepicker__year-select']"));
            SelectElement yearDropDown = new SelectElement(datePickerYear);
            yearDropDown.SelectByValue("1990");

            IWebElement datePickerDate = webDriver.FindElement(By.XPath("//*[@class='react-datepicker__day react-datepicker__day--026' and not (contains(@class, '--outside-month'))]"));
            datePickerDate.Click();
        }

         [TearDown]
        public void TearDown()
         {
        // webDriver.Quit();
         //webDriver.Close();
         }
    }
}
