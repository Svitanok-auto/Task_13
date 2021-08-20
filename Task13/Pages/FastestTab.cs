using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using Task13.Helper;

namespace Task13.Pages
{
    public class FastestTab : PageObjectBase
    {
        public FastestTab(IWebDriver driver) : base(driver) 
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = ".//div[text()='Fastest']")]
        public IWebElement SearchFastest { get; set; }

        public bool MaxJourney()
        {
            WaitUntilPageIsLoaded();

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(2));
            WaitHelper waitHelper = new WaitHelper();

            SearchFastest.Click();
            IWebElement lastPage = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//div[contains(@class,'searchResultsList')]/following-sibling::div/div/div[last()]")));
            lastPage.Click();

            IWebElement lastItemJorneyTime = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//div[contains(@class,'searchResultsList')]/div[last()]//div[@style='width: 50%;']/div[contains(@class,'Text-module__root--variant-small')][1]")));
            IWebElement maxJourneyTime = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//div[text()='Max journey time']/following-sibling::div[1]")));

            return lastItemJorneyTime.Text.Contains(maxJourneyTime.Text) ? true : false;
        }

        public FastestTab OpenFastestTabLastPage()
        {
            WaitUntilPageIsLoaded();

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(2));
            WaitHelper waitHelper = new WaitHelper();

            SearchFastest.Click();
            IWebElement lastPage = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//div[contains(@class,'searchResultsList')]/following-sibling::div/div/div[last()]")));
            lastPage.Click();
            return this;
        }

        public void WaitUntilPageIsLoaded()
        {
            IJavascriptExecutor javascript = new IJavascriptExecutor();
            javascript.WaitForLoad(Driver, 15);
        }
    }
}
