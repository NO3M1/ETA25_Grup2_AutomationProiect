using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationProject.HelperMethods;
using Grup2_AutomationProject.NET.HelperMethods;
using OpenQA.Selenium;

namespace Grup2_AutomationProject.NET.Pages
{
    public class FramesPage
    {
        IWebDriver webDriver;
        ElementMethods elementMethods;
        JavascriptMethod javaExecutor;
        // private readonly JavascriptMethod _javaExecutor;

        IWebElement frame1 => webDriver.FindElement(By.Id("frame1"));
        IWebElement frame2 => webDriver.FindElement(By.Id("frame2"));
        IWebElement frame1Text => webDriver.FindElement(By.Id("sampleHeading"));




        public FramesPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            elementMethods = new ElementMethods(webDriver);
            javaExecutor = new JavascriptMethod(webDriver);
        
        }

        public void GetTextFromFrame1()
        {
            webDriver.SwitchTo().Frame(frame1);
            Console.WriteLine(frame1Text.Text);
            //revenim la main content
            webDriver.SwitchTo().DefaultContent();

        }

        public void GetTextFromFrame2()
        {
            javaExecutor.ScrollPageVertically(1000);
            webDriver.SwitchTo().Frame(frame2);
            javaExecutor.ScrollPageDynamically(1000, 1000);
          
        }


    }
}
