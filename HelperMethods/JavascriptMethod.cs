using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Grup2_AutomationProject.NET.HelperMethods
{
    public class JavascriptMethod
    {
        IWebDriver webDriver;
        IJavaScriptExecutor jsExec;
        


        public JavascriptMethod(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            this.jsExec = (IJavaScriptExecutor)webDriver;
            this.webDriver = webDriver;
        }

        public void ScrollPageVertically(int pixelsOnAxeX)
        {
            jsExec.ExecuteScript($"window.scrollTo(0,{pixelsOnAxeX})");
        }

        public void ScrollPageHorizontally(int pixelsOnAxeY)
        {
            jsExec.ExecuteScript($"window.scrollTo(0,{pixelsOnAxeY},0)");
        }

        public void ScrollPageDynamically(int pixelsOnAxeX, int pixelsOnAxeY)
        {
            jsExec.ExecuteScript($"window.scrollTo({pixelsOnAxeX}, {pixelsOnAxeY} )");
        }


    }
}
