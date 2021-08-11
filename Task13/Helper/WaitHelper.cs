using OpenQA.Selenium;
using System;
using System.Threading;

namespace Task13.Helper
{
    public class WaitHelper
    {
        public Func<IWebDriver, IWebElement> ElementIsClickable(By locator)
        {
            return driver =>
            {
                IWebElement element = driver.FindElement(locator);
                return (element != null && element.Displayed && element.Enabled) ? element : null;
            };
        }
    }
}
