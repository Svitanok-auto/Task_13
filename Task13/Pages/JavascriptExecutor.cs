using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Task13.Pages
{
    public class IJavascriptExecutor
    {
        public void WaitForLoad(IWebDriver driver, int timeoutSec)
        {
            Thread.Sleep(5000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, timeoutSec));
            wait.Until(wd => js.ExecuteScript("return document.readyState").ToString() == "complete");
        }
    }
}