using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationProject.HelperMethods;
using OpenQA.Selenium;

namespace Grup2_AutomationProject.NET.Pages
{
    public class PracticeFormPage
    {
        public IWebDriver webDriver;
        public ElementMethods elementMethods;

        //constructor
        public PracticeFormPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            this.elementMethods = new ElementMethods(webDriver);
        }

        IWebElement firstNameElement => webDriver.FindElement(By.Id("firstName"));
        IWebElement lastNameElement => webDriver.FindElement(By.Id("lastName"));
        IWebElement emailElement => webDriver.FindElement(By.Id("userEmail"));
        IWebElement mobileElement => webDriver.FindElement(By.Id("userNumber"));
        IWebElement currentAddressElement => webDriver.FindElement(By.Id("currentAddress"));

        IWebElement genderMaleButton => webDriver.FindElement(By.XPath("//label[@for='gender-radio-1']"));
        IWebElement genderFemaleButton => webDriver.FindElement(By.XPath("//label[@for='gender-radio-2']"));
        IWebElement genderOtherButton => webDriver.FindElement(By.XPath("//label[@for='gender-radio-3']"));

        public void CompleteFirstRegion(string firstName, string lastName, string email, string mobile, string currentAddress)

        {
            elementMethods.FillElement(firstNameElement, firstName);
            elementMethods.FillElement(lastNameElement, lastName);
            elementMethods.FillElement(emailElement, email);
            elementMethods.FillElement(mobileElement, mobile);
            elementMethods.FillElement(currentAddressElement, currentAddress);
        }

        public void SelectGender(string gender)
        {
            switch (gender)
            {
                case "Male":
                 elementMethods.ClickOnElement(genderMaleButton);
                break;
                case "Female":
                 elementMethods.ClickOnElement(genderMaleButton);
                    break;
                case "Other":
                 elementMethods.ClickOnElement(genderMaleButton);
                    break;
                }
          
        }
     
    }


}








