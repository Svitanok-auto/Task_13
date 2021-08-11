using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using Task13.Helper;

namespace Task13.Pages
{
    public class WhoIsFlyingPage : PageObjectBase
    {
        public WhoIsFlyingPage(IWebDriver driver) : base(driver) 
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = ".//button[@data-testid='searchresults_select_flight'][1]")]
        public IWebElement FirstItemOnFastestTab { get; set; }

        [FindsBy(How = How.XPath, Using = ".//button/span[text()='Select']")]
        public IWebElement SelectFlightButton { get; set; }

        [FindsBy(How = How.XPath, Using = ".//input[@type='email']")]
        public IWebElement Email { get; set; }

        [FindsBy(How = How.XPath, Using = ".//input[@type='tel']")]
        public IWebElement ContactNumber { get; set; }

        [FindsBy(How = How.XPath, Using = ".//input[contains(@name,'firstName')]")]
        public IWebElement FirstName { get; set; }

        [FindsBy(How = How.XPath, Using = ".//input[contains(@name,'lastName')]")]
        public IWebElement LastName { get; set; }

        [FindsBy(How = How.XPath, Using = ".//select[contains(@name,'gender')]/option[@value='M']")]
        public IWebElement MaleGender { get; set; }

        [FindsBy(How = How.XPath, Using = ".//input[@placeholder='MM'][1]")]
        public IWebElement BirthMonth { get; set; }

        [FindsBy(How = How.XPath, Using = ".//input[@placeholder='DD'][1]")]
        public IWebElement BirthDay { get; set; }

        [FindsBy(How = How.XPath, Using = ".//input[@placeholder='YYYY'][1]")]
        public IWebElement BirthYear { get; set; }

        [FindsBy(How = How.XPath, Using = ".//input[contains(@name,'passportNumber')]")]
        public IWebElement PassportNumber { get; set; }

        [FindsBy(How = How.XPath, Using = ".//select[contains(@name,'nationality')]")]
        public IWebElement CountryIssued { get; set; }

        [FindsBy(How = How.XPath, Using = ".//select[contains(@name,'nationality')]/option[@value='UA']")]
        public IWebElement CountryIssuedUkraine { get; set; }

        [FindsBy(How = How.XPath, Using = "(.//div/input[contains(@name,'month')])[last()]")]
        public IWebElement ExpirationDateMonth { get; set; }

        [FindsBy(How = How.XPath, Using = "(.//div/input[contains(@name,'day')])[last()]")]
        public IWebElement ExpirationDateDay { get; set; }

        [FindsBy(How = How.XPath, Using = "(.//div/input[contains(@name,'year')])[last()]")]
        public IWebElement ExpirationDateYear { get; set; }

        [FindsBy(How = How.XPath, Using = ".//span[text()='Next']")]
        public IWebElement NextButton { get; set; }

        public IWebElement GetActiveElementInNavigationProgressBar()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(2));
            WaitHelper waitHelper = new WaitHelper();
            WaitUntilPageIsLoaded();

            FirstItemOnFastestTab.Click();
            SelectFlightButton.Click();

            IWebElement navigationProgressActiveElement = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//strong[1]")));
            if (navigationProgressActiveElement.Text == "Who's flying?")
            {
                return navigationProgressActiveElement;
            }
            else if (navigationProgressActiveElement.Text == "Ticket type")
            {
                IWebElement nextButton = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//span[text()='Next']")));
                nextButton.Click();
                navigationProgressActiveElement = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//strong[1]")));
                return navigationProgressActiveElement;
            }
            else
            {
                throw new Exception("Tab Not found");
            }
        }

        public WhoIsFlyingPage GetActiveElementInNavigationProgressBarToSetData()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(2));
            WaitHelper waitHelper = new WaitHelper();
            WaitUntilPageIsLoaded();

            FirstItemOnFastestTab.Click();
            SelectFlightButton.Click();

            IWebElement navigationProgressActiveElement = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//strong[1]")));
            if (navigationProgressActiveElement.Text == "Who's flying?")
            {
                return this;
            }
            else if (navigationProgressActiveElement.Text == "Ticket type")
            {
                IWebElement nextButton = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//span[text()='Next']")));
                nextButton.Click();
                return this;
            }
            else
            {
                return this;
            }
        }

        public IWebElement PopulateMandatoryFieldsOnWhoIsFlyingPageAndGetActiveTab()
        {
            WaitUntilPageIsLoaded();
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(2));
            WaitHelper waitHelper = new WaitHelper();

            Email.Click();
            Email.SendKeys("vasiliyumniy1@gmail.com");

            ContactNumber.Click();
            ContactNumber.SendKeys("931234567");

            FirstName.Click();
            FirstName.SendKeys("Max");

            LastName.Click();
            LastName.SendKeys("Rockstar");

            MaleGender.Click();

            BirthMonth.Click();
            BirthMonth.SendKeys("12");

            BirthDay.Click();
            BirthDay.SendKeys("12");

            BirthYear.Click();
            BirthYear.SendKeys("1990");

            PassportNumber.Click();
            PassportNumber.SendKeys("MT1234567");

            CountryIssued.Click();

            CountryIssuedUkraine.Click();

            ExpirationDateMonth.Click();
            ExpirationDateMonth.SendKeys("10");

            ExpirationDateDay.Click();
            ExpirationDateDay.SendKeys("12");

            ExpirationDateYear.Click();
            ExpirationDateYear.SendKeys("2025");

            NextButton.Click();

            IWebElement currentTab = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//strong[@aria-current='step']")));
            return currentTab;
        }

        public void WaitUntilPageIsLoaded()
        {
            IJavascriptExecutor javascript = new IJavascriptExecutor();
            javascript.WaitForLoad(Driver, 15);
        }
    }
}
