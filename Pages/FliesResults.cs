using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Pages
{
    public class FliesResults
    {
        private IWebDriver _driver;

        public FliesResults(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement GetResults()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromMinutes(2));
            WaitHelper waitHelper = new WaitHelper();
            IWebElement resultsElement = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//div[contains(text(),'results')]")));
            return resultsElement;
        }
        public IWebElement GetFlightTimes()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromMinutes(2));
            WaitHelper waitHelper = new WaitHelper();
            IWebElement flightTimes = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//div[text()='Flight times']")));
            return flightTimes;
        }

        public IWebElement GetDepartsFromParameter()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromMinutes(2));
            WaitHelper waitHelper = new WaitHelper();
            IWebElement departsFrom = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//div[text()='Departs from Boryspil International Airport']")));
            return departsFrom;
        }

        public IWebElement GetArrivesToParameter()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromMinutes(2));
            WaitHelper waitHelper = new WaitHelper();
            IWebElement arrivesTo = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//div[text()='Arrives to Copenhagen Airport']")));
            return arrivesTo;
        }

        public IWebElement GetBestTripsTab()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromMinutes(2));
            WaitHelper waitHelper = new WaitHelper();
            IWebElement searchBest = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//div[text()='Best']")));
            return searchBest;
        }
        public IWebElement GetCheapestTripsTab()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromMinutes(2));
            WaitHelper waitHelper = new WaitHelper();
            IWebElement searchCheapest = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//div[text()='Cheapest']")));
            return searchCheapest;
        }

        public IWebElement GetFastestTripsTab()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromMinutes(2));
            WaitHelper waitHelper = new WaitHelper();
            IWebElement searchFastest = wait.Until(waitHelper.ElementIsClickable(By.XPath(".//div[text()='Fastest']")));
            return searchFastest;
        }
    }
}
