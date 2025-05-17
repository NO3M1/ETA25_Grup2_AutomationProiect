using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using static System.Net.Mime.MediaTypeNames;
using AutomationProject.HelperMethods;
using Grup2_AutomationProject.NET.BasePage;

namespace AutomationProject.Tests
{
    public class Interactions : TestBasePage
    {
        
        ElementMethods elementMethod;

        [Test]
        public void InteractionsMenuSortable()
        {
       
            elementMethod = new ElementMethods(driver);

            IJavaScriptExecutor jsExec = (IJavaScriptExecutor)driver;
            jsExec.ExecuteScript("window.scrollTo(0,1000)");

            IWebElement interactionsButton = driver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][5]")); // //h5[text()='Interactions']
            elementMethod.ClickOnElement(interactionsButton);

            List<IWebElement> interactionsListItems = driver.FindElements(By.XPath("//div[@class='element-list collapse show']/ul[@class='menu-list']/li[@class='btn btn-light ']")).ToList();
            elementMethod.ClickOnElement(interactionsListItems[0]);

            List<IWebElement> listNumbers = driver.FindElements(By.XPath("//div[@class='vertical-list-container mt-4']/div")).ToList();
            // //div[@class='vertical-list-container mt-4']/div[@class='list-group-item list-group-item-action']
            for (int i = 0; i < listNumbers.Count; i++)
                Console.WriteLine(listNumbers[i].Text);

            // foreach (IWebElement element in listNumbers)  Console.WriteLine(element.Text);

            IWebElement gridMenu = driver.FindElement(By.Id("demo-tab-grid"));
            elementMethod.ClickOnElement(gridMenu);

            List<IWebElement> listElementsGrid = driver.FindElements(By.XPath("//div[@id='demo-tabpane-grid']//div[@class='list-group-item list-group-item-action']")).ToList();
            List<string> elementsFromGridToText = new List<string>();

            Dictionary<string, IWebElement> elementMapping = new Dictionary<string, IWebElement>();

            foreach (IWebElement element in listElementsGrid)
            {
                elementsFromGridToText.Add(element.Text);
                elementMapping[element.Text] = element;  // Store element reference by text

            }
            Dictionary<string, int> textToNumber = new Dictionary<string, int>()
            {
                { "One", 1 }, { "Two", 2 }, { "Three", 3 },
                { "Four", 4 }, { "Five", 5 }, { "Six", 6 },
                { "Seven", 7 }, { "Eight", 8 }, { "Nine", 9 }
            };

            // Custom sort logic
            elementsFromGridToText.Sort((a, b) =>
            {
                int numA = textToNumber[a];
                int numB = textToNumber[b];
                // If one is odd and the other is even, prioritize odd numbers
                if (numA % 2 != numB % 2)
                    return numA % 2 == 0 ? 1 : -1;
                // Otherwise, maintain natural order
                return numA.CompareTo(numB);
            });
            Console.WriteLine(string.Join(", ", elementsFromGridToText));

        }

        [Test]
        public void InteractionsMenuSelectable()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/");
            driver.Manage().Window.Maximize();

            elementMethod = new ElementMethods(driver);

            IJavaScriptExecutor jsExec = (IJavaScriptExecutor)driver;
            jsExec.ExecuteScript("window.scrollTo(0,1000)");

            IWebElement interactionsButton = driver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][5]")); // //h5[text()='Interactions']
            elementMethod.ClickOnElement(interactionsButton);

            List<IWebElement> interactionsListItems = driver.FindElements(By.XPath("//div[@class='element-list collapse show']/ul[@class='menu-list']/li[@class='btn btn-light ']")).ToList();
            elementMethod.ClickOnElement(interactionsListItems[1]);

            IWebElement gridMenu = driver.FindElement(By.Id("demo-tab-grid"));
            elementMethod.ClickOnElement(gridMenu);

            List<IWebElement> listNumbersGrid = driver.FindElements(By.XPath("//div[@id='demo-tabpane-grid']//li[@class='list-group-item list-group-item-action']")).ToList();
            for (int i = 0; i < listNumbersGrid.Count; i++)
            {
                if (i % 2 == 0)
                    elementMethod.ClickOnElement(listNumbersGrid[i]);
            }

        }

 
    }
}
