using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using Task13.Helper;
using Task13.Pages.Components;

namespace Task13.Pages
{
    public class MainPage : PageObjectBase
    {
        public MainPage (IWebDriver driver) : base(driver) 
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = ".//div/img[contains(@class,'Avatar')]")]
        public IWebElement LanguageElement { get; set; }

        [FindsBy(How = How.XPath, Using = ".//div[contains(@class,'radio-input')]/input[@value='1']/..")]
        public IWebElement OneWayElement { get; set; }

        [FindsBy(How = How.XPath, Using = ".//button[@data-testid='searchbox_submit']")]
        public IWebElement SearchSubmit { get; set; }

        public void SearchForFlights()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            WaitHelper waitHelper = new WaitHelper();

            SetEnglishLanguage();
            SetOneWayTrip();
            SetWhereFromBoxCriteria();
            SetWhereToBoxCriteria();
            SetNearestDatesCriteria(wait, waitHelper);
            RunSearch();
        }

        public MainPage SetEnglishLanguage()
        {
            LanguageElement.Click();
            MainPage_LanguageSelectionPage languageSelection= new MainPage_LanguageSelectionPage(Driver);
            languageSelection.SetEnglishLanguage();
            return this;
        }

        public MainPage SetOneWayTrip()
        {
            OneWayElement.Click();
            return this;
        }

        public MainPage SetWhereFromBoxCriteria()
        {
            MainPage_WhereFromPage whereFromPage = new MainPage_WhereFromPage(Driver);
            whereFromPage.SetWhereFromBoxCriteria();
            return this;
        }

        public MainPage SetWhereToBoxCriteria()
        {
            MainPage_WhereToPage whereToPage = new MainPage_WhereToPage(Driver);
            whereToPage.SetWhereToBoxCriteria();
            return this;
        }

        public MainPage SetNearestDatesCriteria(WebDriverWait wait, WaitHelper waitHelper)
        {
            IWebElement SearchDate = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//span[text()=" + (DateTime.Now.Day + 1) + "][1]")));
            SearchDate.Click();
            return this;
        }

        public void RunSearch()
        {
            SearchSubmit.Click();
        }
    }
}
