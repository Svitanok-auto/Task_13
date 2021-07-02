using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Pages
{
    public class FlightDetailsFlow
    {
        private IWebDriver _driver;

        public FlightDetailsFlow(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement GetActiveElementInNavigationProgressBar()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromMinutes(2));
            WaitHelper waitHelper = new WaitHelper();

            IWebElement firstItemOnFastestTab = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//div/button[@data-testid='searchresults_select_flight'][1]")));
            firstItemOnFastestTab.Click();

            IWebElement selectFlightButton = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//button/span[text()='Select']")));
            selectFlightButton.Click();

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

        public IWebElement PopulateMandatoryFieldsOnWhoIsFlyingPageAndGetActiveTab()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromMinutes(2));
            WaitHelper waitHelper = new WaitHelper();

            IWebElement email = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//input[@type='email']")));
            email.Click();
            email.SendKeys("vasiliyumniy1@gmail.com");

            IWebElement contactNumber = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//input[@type='tel']")));
            contactNumber.Click();
            contactNumber.SendKeys("931234567");

            IWebElement firstName = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//input[contains(@name,'firstName')]")));
            firstName.Click();
            firstName.SendKeys("Max");

            IWebElement lastName = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//input[contains(@name,'lastName')]")));
            lastName.Click();
            lastName.SendKeys("Rockstar");

            IWebElement gender = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//select[contains(@name,'gender')]")));
            lastName.Click();
            IWebElement maleGender = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//select[contains(@name,'gender')]/option[@value='M']")));
            maleGender.Click();

            IWebElement birthMonth = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//input[@placeholder='MM'][1]")));
            birthMonth.Click();
            birthMonth.SendKeys("12");

            IWebElement birthDay = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//input[@placeholder='DD'][1]")));
            birthDay.Click();
            birthDay.SendKeys("12");

            IWebElement birthYear = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//input[@placeholder='YYYY'][1]")));
            birthYear.Click();
            birthYear.SendKeys("1990");

            IWebElement passportNumber = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//input[contains(@name,'passportNumber')]")));
            passportNumber.Click();
            passportNumber.SendKeys("MT1234567");

            IWebElement countryIssued = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//select[contains(@name,'nationality')]")));
            countryIssued.Click();
            IWebElement countryIssuedUkraine = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//select[contains(@name,'nationality')]/option[@value='UA']")));
            countryIssuedUkraine.Click();

            IWebElement expirationDateMonth = wait.Until(waitHelper.ElementIsClickable(By.XPath("(.//div/input[contains(@name,'month')])[last()]")));
            expirationDateMonth.Click();
            expirationDateMonth.SendKeys("10");

            IWebElement expirationDateDay = wait.Until(waitHelper.ElementIsClickable(By.XPath("(.//div/input[contains(@name,'day')])[last()]")));
            expirationDateDay.Click();
            expirationDateDay.SendKeys("12");

            IWebElement expirationDateYear = wait.Until(waitHelper.ElementIsClickable(By.XPath("(.//div/input[contains(@name,'year')])[last()]")));
            expirationDateYear.Click();
            expirationDateYear.SendKeys("2025");

            IWebElement nextButton = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//span[text()='Next']")));
            nextButton.Click();
            Thread.Sleep(5000);

            IWebElement currentTab = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//strong[@aria-current='step']")));
            return currentTab;
        }

        public IWebElement GetCheckAndPayTab()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromMinutes(2));
            WaitHelper waitHelper = new WaitHelper();

            IWebElement currentTab = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//strong[@aria-current='step']")));
            if (currentTab.Text == "Select your seat")
            {
                IWebElement nextButton = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//span[text()='Skip']")));
                nextButton.Click();
                Thread.Sleep(5000);
                currentTab = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//strong[@aria-current='step']")));
                return currentTab;
            }
            else if (currentTab.Text == "Baggage and extras")
            {
                IWebElement skipButton = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//span[text()='Next']")));
                skipButton.Click();
                Thread.Sleep(5000);
                currentTab = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//strong[@aria-current='step']")));
                return currentTab;
            }
            else 
            {
                throw new Exception("Tab Not found");
            }
        }

        public IWebElement GetCheckAndPayTabElement(string locator)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromMinutes(2));
            WaitHelper waitHelper = new WaitHelper();

            IWebElement currentTab = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//strong[@aria-current='step']")));
            if (currentTab.Text == "Check and pay")
            {
                IWebElement element = wait.Until(waitHelper.ElementIsClickable(By.XPath(locator)));
                return element;
            }
            else
            {
                throw new Exception("Can't find element as Tab is absent");
            }
        }

        public IWebElement GetCheckAndPayTabPhone()
        {
            return GetCheckAndPayTabElement(".//div[text()='Contact details']/following-sibling::div[1]/div[1]");
        }

        public IWebElement GetCheckAndPayTabEmail()
        {
            return GetCheckAndPayTabElement(".//div[text()='Contact details']/following-sibling::div[1]/div[last()]");
        }

        public IWebElement GetCheckAndPayTabFirstNameLastName()
        {
            return GetCheckAndPayTabElement(".//div[contains(@class,'Text-module')]/span");
        }

        public IWebElement GetCheckAndPayTabGenderBirthday()
        {
            return GetCheckAndPayTabElement(".//div[contains(@class,'Text-module')]/span/../following-sibling::div[1]");
        }

        public IWebElement GetCheckAndPayTabPassportInfo()
        {
            return GetCheckAndPayTabElement(".//div[contains(@class,'Text-module')]/span/../../following-sibling::div[last()]/div/following-sibling::div");
        }
    }
}
