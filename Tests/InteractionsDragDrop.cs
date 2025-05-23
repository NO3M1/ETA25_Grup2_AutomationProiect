﻿using AutomationProject.HelperMethods;
using Grup2_AutomationProject.NET.BasePage;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.Tests
{
    public class InteractionsDragDrop : TestBasePage
    {
       
        ElementMethods elementMethods;

        [Test]

        public void DragAndDrop()
        {
          
            elementMethods = new ElementMethods(driver);

            IJavaScriptExecutor jsExec = (IJavaScriptExecutor)driver;
            jsExec.ExecuteScript("window.scrollTo(0,1000)");

            IWebElement interactionsButton = driver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][5]")); // //h5[text()='Interactions']
            elementMethods.ClickOnElement(interactionsButton);

            jsExec.ExecuteScript("window.scrollTo(0,2000)");
            List<IWebElement> interactionsListItems = driver.FindElements(By.XPath("//div[@class='element-list collapse show']/ul[@class='menu-list']/li[@class='btn btn-light ']")).ToList();
            elementMethods.ClickOnElement(interactionsListItems[3]);

            IWebElement preventPropogation = driver.FindElement(By.Id("droppableExample-tab-preventPropogation"));
            elementMethods.ClickOnElement(preventPropogation);

            IWebElement dragBox = driver.FindElement(By.Id("dragBox"));

            // Move the element in different directions using Actions class instance
            Actions actions = new Actions(driver);

            actions.ClickAndHold(dragBox)
                   .MoveByOffset(200, 0) // Move right
                   .Pause(TimeSpan.FromSeconds(1)) // Pause for visualization
                   .MoveByOffset(0, 100) // Move down 
                   .Release()
                   .Click()
                   .Perform();

            IWebElement notGreedyDropBox = driver.FindElement(By.Id("notGreedyDropBox"));
            IWebElement notGreedyInnerDropBox = driver.FindElement(By.Id("notGreedyInnerDropBox"));

            IWebElement paragraph1 = notGreedyDropBox.FindElement(By.TagName("p"));
            IWebElement paragraph2 = notGreedyInnerDropBox.FindElement(By.TagName("p"));



            if (paragraph1.Text.Equals("Dropped!"))
            {
                Console.WriteLine("DragMe was dropped in the not greedy outer droppable");
                if (paragraph2.Text.Equals("Dropped!"))
                    Console.WriteLine("DragMe was dropped in the not greedy inner droppable too");
            }
            else if (paragraph2.Text.Equals("Dropped!"))
                Console.WriteLine("DragMe was dropped in the not greedy inner droppable");
            else Console.WriteLine("DragMe was not dropped in the not greedy droppable");

            Thread.Sleep(2000);
            jsExec.ExecuteScript("arguments[0].scrollIntoView(true);", dragBox);
            //jsExec.ExecuteScript("window.scrollTo(0,2000)");

            actions.ClickAndHold(dragBox)
                   .MoveByOffset(0, 300) // Move down 
                   .Pause(TimeSpan.FromSeconds(1)) // Pause for visualization
                   .MoveByOffset(100, 0) // Move right
                   .Release()
                   .Click()
                   .Perform();

            IWebElement greedyDropbox = driver.FindElement(By.Id("greedyDropBox"));
            IWebElement greedyInnerDropbox = driver.FindElement(By.Id("greedyDropBoxInner"));

            IWebElement paragraph3 = greedyDropbox.FindElement(By.TagName("p"));
            IWebElement paragraph4 = greedyInnerDropbox.FindElement(By.TagName("p"));


            if (paragraph3.Text.Equals("Dropped!"))
            {
                Console.WriteLine("DragMe was dropped in the greedy outer droppable");
                if (paragraph4.Text.Equals("Dropped!"))
                    Console.WriteLine("DragMe was dropped in the greedy inner droppable too");
            }
            else if (paragraph4.Text.Equals("Dropped!"))
                Console.WriteLine("DragMe was dropped in the greedy inner droppable");
            else Console.WriteLine("DragMe was not dropped in the greedy droppable");

        }

    }
}
