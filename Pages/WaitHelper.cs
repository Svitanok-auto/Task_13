using OpenQA.Selenium;
using System;

namespace Pages
{
    public class WaitHelper
    {
        public Func<IWebDriver, IWebElement> ElementIsClickable(By locator)
        {
            return driver =>
            {
                var element = driver.FindElement(locator);
                return (element != null && element.Displayed && element.Enabled) ? element : null;
            };
        }
    }
}
