using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using Task13.Helper;

namespace Task13.Pages
{
    public class CheckAndPayPage : PageObjectBase
    {
        public CheckAndPayPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = ".//strong[@aria-current='step']")]
        public IWebElement CurrentTab { get; set; }

        public IWebElement GetCheckAndPayTab()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(2));
            WaitHelper waitHelper = new WaitHelper();

            if (CurrentTab.Text == "Select your seat")
            {
                IWebElement nextButton = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//span[text()='Skip']")));
                nextButton.Click();

                WaitUntilPageIsLoaded();
                CurrentTab = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//strong[@aria-current='step']")));
                return CurrentTab;
            }
            else if (CurrentTab.Text == "Baggage and extras")
            {
                IWebElement skipButton = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//span[text()='Next']")));
                skipButton.Click();

                WaitUntilPageIsLoaded();
                CurrentTab = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//strong[@aria-current='step']")));
                return CurrentTab;
            }
            else
            {
                throw new Exception("Tab Not found");
            }
        }

        public IWebElement GetCheckAndPayTabElement(string locator)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(2));
            WaitHelper waitHelper = new WaitHelper();

            if (CurrentTab.Text == "Check and pay")
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

        public void WaitUntilPageIsLoaded()
        {
            IJavascriptExecutor javascript = new IJavascriptExecutor();
            javascript.WaitForLoad(Driver, 15);
        }
    }
}
