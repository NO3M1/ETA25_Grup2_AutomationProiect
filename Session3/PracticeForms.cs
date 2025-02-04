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
            
            jsExec.ExecuteScript("window.scrollTo(0,1000)");

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

            List<IWebElement> listRemoveSubjects = webDriver.FindElements(By.XPath("//div[@class='css-xb97g8 subjects-auto-complete__multi-value__remove']")).ToList();
            bool subjectFlag = true;

            //te site will break if we remove all the elements in the list 
            //while (subjectFlag)
            //{
            //    foreach (IWebElement elementSubject in listRemoveSubjects)
            //        elementSubject.Click();

            //    subjectFlag = false;
            //}    
 
            //IWebElement iconToRemove = webDriver.FindElement(By.XPath("(//div[contains(@class, 'subjects-auto-complete__multi-value__remove')])[2]"));
            //iconToRemove.Click();

            //Date Picker

            IWebElement dateBirth = webDriver.FindElement(By.Id("dateOfBirthInput"));
            dateBirth.Click();

            IWebElement datePickerMonth = webDriver.FindElement(By.XPath("//select[@class='react-datepicker__month-select']"));
            SelectElement monthDropDown = new SelectElement(datePickerMonth);
            monthDropDown.SelectByValue("1");

            IWebElement datePickerYear = webDriver.FindElement(By.XPath("//select[@class='react-datepicker__year-select']"));
            SelectElement yearDropDown = new SelectElement(datePickerYear);
            yearDropDown.SelectByValue("1990");

            int day = 7;
            IWebElement datePickerDate = webDriver.FindElement(By.XPath("//*[@class='react-datepicker__day react-datepicker__day--026' and not (contains(@class, '--outside-month'))]"));
            datePickerDate.Click();


        }

        [Test]
        public void FormsHobbies()
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

            IWebElement sportsCheckBox = webDriver.FindElement(By.XPath("//label[@for='hobbies-checkbox-1']"));
            IWebElement readingCheckBox = webDriver.FindElement(By.XPath("//label[@for='hobbies-checkbox-2']"));
            IWebElement musicCheckBox = webDriver.FindElement(By.XPath("//label[@for='hobbies-checkbox-3']"));

            jsExec.ExecuteScript("window.scrollTo(0,1000)");

            List<IWebElement> hobbiesList = new List<IWebElement>();
            hobbiesList.Add(sportsCheckBox);
            hobbiesList.Add(readingCheckBox);
            hobbiesList.Add(musicCheckBox);

            string[] hobbiesArray = ["Sports", "Reading", "Music"];

            foreach (IWebElement hobby in hobbiesList)
            {
                foreach (string item in hobbiesArray)
                    if (hobby.Text.Equals(item)) hobby.Click();
            }


        }

        [TearDown]
        public void TearDown()
         {
        // webDriver.Quit();
          webDriver.Close();
         }
    }
}
