using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.Session5
{
    public class Interactions
    {
        IWebDriver webDriver;

        [Test]
        public void InteractionsMenuSortable()
        {
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://demoqa.com/");
            webDriver.Manage().Window.Maximize();

            IJavaScriptExecutor jsExec = (IJavaScriptExecutor)webDriver;
            jsExec.ExecuteScript("window.scrollTo(0,1000)");

            IWebElement interactionsButton = webDriver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][5]")); // //h5[text()='Interactions']
            interactionsButton.Click();

            List<IWebElement> interactionsListItems = webDriver.FindElements(By.XPath("//div[@class='element-list collapse show']/ul[@class='menu-list']/li[@class='btn btn-light ']")).ToList();
            interactionsListItems[0].Click();

            List<IWebElement> listNumbers = webDriver.FindElements(By.XPath("//div[@class='vertical-list-container mt-4']/div")).ToList();
            // //div[@class='vertical-list-container mt-4']/div[@class='list-group-item list-group-item-action']
            for (int i = 0; i < listNumbers.Count; i++) 
                Console.WriteLine(listNumbers[i].Text);

            foreach (IWebElement element in listNumbers)  Console.WriteLine(element.Text);

            IWebElement gridMenu = webDriver.FindElement(By.Id("demo-tab-grid"));
            gridMenu.Click();

            List<IWebElement> listElementsGrid = webDriver.FindElements(By.XPath("//div[@id='demo-tabpane-grid']//div[@class='list-group-item list-group-item-action']")).ToList();
            List<string> elementsFromGridToText = new List<string>();
            foreach (IWebElement element in listElementsGrid)
            {
                elementsFromGridToText.Add(element.Text);
            }
            Dictionary <string, int> textToNumber = new Dictionary<string, int>()
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
                    return (numA % 2 == 0) ? 1 : -1;

                // Otherwise, maintain natural order
                return numA.CompareTo(numB);
            });

            Console.WriteLine(string.Join(", ", elementsFromGridToText));
        }

        [Test]
        public void InteractionsMenuSelectable ()
        {
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://demoqa.com/");
            webDriver.Manage().Window.Maximize();

            IJavaScriptExecutor jsExec = (IJavaScriptExecutor)webDriver;
            jsExec.ExecuteScript("window.scrollTo(0,1000)");

            IWebElement interactionsButton = webDriver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][5]")); // //h5[text()='Interactions']
            interactionsButton.Click();

            List<IWebElement> interactionsListItems = webDriver.FindElements(By.XPath("//div[@class='element-list collapse show']/ul[@class='menu-list']/li[@class='btn btn-light ']")).ToList();
            interactionsListItems[1].Click();

            IWebElement gridMenu = webDriver.FindElement(By.Id("demo-tab-grid"));
            gridMenu.Click();

            List<IWebElement> listNumbersGrid = webDriver.FindElements(By.XPath("//div[@id='demo-tabpane-grid']//li[@class='list-group-item list-group-item-action']")).ToList();
            for (int i = 0; i < listNumbersGrid.Count; i++) {
                if (i % 2 == 0)
                listNumbersGrid[i].Click(); 
            }

        }

        [TearDown]
        public void TearDown()
        {
            //webDriver.Close();
        }
    }
}
