using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Pages
{
    public class FastestTab
    {
        private IWebDriver _driver;

        public FastestTab(IWebDriver driver)
        {
            _driver = driver;
        }

        public bool MaxJourney()
        {
            Thread.Sleep(5000);
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromMinutes(2));
            WaitHelper waitHelper = new WaitHelper();
            IWebElement searchFastest = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//div[text()='Fastest']")));
            searchFastest.Click();

            IWebElement lastPage = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//div[contains(@class,'searchResultsList')]/following-sibling::div/div/div[last()]")));
            lastPage.Click();

            IWebElement lastItemJorneyTime = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//div[contains(@class,'searchResultsList')]/div[last()]//div[@style='width: 50%;']/div[contains(@class,'Text-module__root--variant-small')][1]")));
            IWebElement maxJourneyTime = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//div[text()='Max journey time']/following-sibling::div[1]")));
            if (lastItemJorneyTime.Text.Contains(maxJourneyTime.Text))
            {
                return true;
            }
            else return false;
        }

        public void OpenFastestTabLastPage()
        {
            Thread.Sleep(2000);
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromMinutes(2));
            WaitHelper waitHelper = new WaitHelper();
            IWebElement searchFastest = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//div[text()='Fastest']")));
            searchFastest.Click();

            IWebElement lastPage = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//div[contains(@class,'searchResultsList')]/following-sibling::div/div/div[last()]")));
            lastPage.Click();
        }
    }
}
