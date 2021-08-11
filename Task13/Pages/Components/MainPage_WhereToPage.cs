using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using Task13.Helper;

namespace Task13.Pages.Components
{
    internal class MainPage_WhereToPage : PageObjectBase
    {
        public MainPage_WhereToPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void SetWhereToBoxCriteria()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            WaitHelper waitHelper = new WaitHelper();

            IWebElement whereToBox = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//input[@data-testid='searchbox_destination_input']")));
            whereToBox.Click();
            whereToBox.SendKeys("Copenhagen (CPH)");

            IWebElement selectWhereTo = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//span[text()='Copenhagen Airport']")));
            selectWhereTo.Click();
        }
    }
}
