using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using Task13.Helper;

namespace Task13.Pages.Components
{
    internal class MainPage_WhereFromPage : PageObjectBase
    {
        public MainPage_WhereFromPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = ".//div[@data-testid='searchbox_origin']//div[contains(@class,'inputContainer')]")]
        public IWebElement whereFromBox { get; set; }

        public void SetWhereFromBoxCriteria()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            WaitHelper waitHelper = new WaitHelper();

            whereFromBox.Click();

            IWebElement whereFromBoxForInput = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//input[@data-testid='searchbox_origin_input']")));
            whereFromBoxForInput.Click();

            IWebElement selectedFrom = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//div[@data-testid='autocomplete_result'][1]")));
            selectedFrom.Click();
            whereFromBoxForInput.SendKeys("Kyiv Boryspil (KBP)");

            IWebElement selectWhereFrom = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//span[text()='Boryspil International Airport']")));
            selectWhereFrom.Click();
        }
    }
}
