using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using Task13.Helper;

namespace Task13.Pages.Components
{
    internal class MainPage_LanguageSelectionPage : PageObjectBase
    {
        public MainPage_LanguageSelectionPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void SetEnglishLanguage()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            WaitHelper waitHelper = new WaitHelper();

            IWebElement englishLanguageElement = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//div/span[text()='English (US)']")));
            englishLanguageElement.Click();
        }
    }
}
