using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Task13.Pages
{
    public class FliesResults : PageObjectBase
    {
        public FliesResults(IWebDriver driver) : base(driver) 
        {
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = ".//div[contains(text(),'results')]")]
        public IWebElement ResultsElement { get; set; }

        [FindsBy(How = How.XPath, Using = ".//div[text()='Flight times']")]
        public IWebElement FlightTimes { get; set; }

        [FindsBy(How = How.XPath, Using = ".//div[text()='Departs from Boryspil International Airport']")]
        public IWebElement DepartsFrom { get; set; }

        [FindsBy(How = How.XPath, Using = ".//div[text()='Arrives to Copenhagen Airport']")]
        public IWebElement ArrivesTo { get; set; }

        [FindsBy(How = How.XPath, Using = ".//div[text()='Best']")]
        public IWebElement SearchBest { get; set; }

        [FindsBy(How = How.XPath, Using = ".//div[text()='Cheapest']")]
        public IWebElement SearchCheapest { get; set; }

        [FindsBy(How = How.XPath, Using = ".//div[text()='Fastest']")]
        public IWebElement SearchFastest { get; set; }

        public IWebElement GetResults()
        {
            WaitUntilPageIsLoaded();
            return ResultsElement;
        }
        public IWebElement GetFlightTimes()
        {
            WaitUntilPageIsLoaded();
            return FlightTimes;
        }

        public IWebElement GetDepartsFromParameter()
        {
            WaitUntilPageIsLoaded();
            return DepartsFrom;
        }

        public IWebElement GetArrivesToParameter()
        {
            WaitUntilPageIsLoaded();
            return ArrivesTo;
        }

        public IWebElement GetBestTripsTab()
        {
            WaitUntilPageIsLoaded();
            return SearchBest;
        }
        public IWebElement GetCheapestTripsTab()
        {
            WaitUntilPageIsLoaded();
            return SearchCheapest;
        }

        public IWebElement GetFastestTripsTab()
        {
            WaitUntilPageIsLoaded();
            return SearchFastest;
        }
        public void WaitUntilPageIsLoaded()
        {
            IJavascriptExecutor javascript = new IJavascriptExecutor();
            javascript.WaitForLoad(Driver, 15);
        }
    }
}
