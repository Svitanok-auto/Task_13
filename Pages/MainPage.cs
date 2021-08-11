using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Pages
{
    public class MainPage
    {
        private IWebDriver _driver;

        public MainPage (IWebDriver driver)
        {
            _driver = driver;
        }

        public void SearchForFlights()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromMinutes(2));
            WaitHelper waitHelper = new WaitHelper();

            SetEnglishLanguage(wait, waitHelper);
            SetOneWayTrip(wait, waitHelper);
            SetWhereFromBoxCriteria(wait, waitHelper);
            SetWhereToBoxCriteria(wait, waitHelper);
            SetNearestDatesCriteria(wait, waitHelper);
            RunSearch(wait, waitHelper);
        }

        public void SetEnglishLanguage(WebDriverWait wait, WaitHelper waitHelper)
        {
            IWebElement languageElement = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//div/img[contains(@class,'Avatar')]")));
            languageElement.Click();
            IWebElement englishLanguageElement = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//div/span[text()='English (US)']")));
            englishLanguageElement.Click();
        }

        public void SetOneWayTrip(WebDriverWait wait, WaitHelper waitHelper)
        {
            IWebElement oneWayElement = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//div[contains(@class,'radio-input')]/input[@value='1']/..")));
            oneWayElement.Click();
        }

        public void SetWhereFromBoxCriteria(WebDriverWait wait, WaitHelper waitHelper)
        {
            IWebElement whereFromBox = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//div[@data-testid='searchbox_origin']//div[contains(@class,'inputContainer')]")));
            whereFromBox.Click();
            IWebElement selectedFromCheck = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//span[text()='Included in your search (1)']")));
            if (selectedFromCheck.Displayed)
            {
                IWebElement selectedFrom = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//div[@data-testid='autocomplete_result']")));
                selectedFrom.Click();
            }
            IWebElement whereFromBoxForInput = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//input[@data-testid='searchbox_origin_input']")));
            whereFromBoxForInput.Click();

            whereFromBoxForInput.SendKeys("Kyiv Boryspil (KBP)");
            IWebElement selectWhereFrom = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//span[text()='Boryspil International Airport']")));
            selectWhereFrom.Click();
        }

        public void SetWhereToBoxCriteria(WebDriverWait wait, WaitHelper waitHelper)
        {
            IWebElement whereToBox = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//input[@data-testid='searchbox_destination_input']")));
            whereToBox.Click();
            whereToBox.SendKeys("Copenhagen (CPH)");
            IWebElement selectWhereTo = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//span[text()='Copenhagen Airport']")));
            selectWhereTo.Click();
        }

        public void SetNearestDatesCriteria(WebDriverWait wait, WaitHelper waitHelper)
        {
            IWebElement SearchDate = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//span[text()=" + (DateTime.Now.Day + 1) + "][1]")));
            SearchDate.Click();
        }

        public void RunSearch(WebDriverWait wait, WaitHelper waitHelper)
        {
            IWebElement searchSubmit = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//button[@data-testid='searchbox_submit']")));
            searchSubmit.Click();
        }
    }
}
