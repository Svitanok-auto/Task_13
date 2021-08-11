using OpenQA.Selenium;

namespace Task13.Pages
{
    public abstract class PageObjectBase
    {
        public IWebDriver Driver { get; set; }

        public PageObjectBase(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
