using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Pages;

namespace Tests.UI
{
    public class TestsFliesResults
    {
        private IWebDriver _driver;

        [OneTimeSetUp]
        public void Init()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://flights.booking.com/");

            MainPage mainPage = new MainPage(_driver);
            mainPage.SearchForFlights();
        }

        [OneTimeTearDown]
        public void AfterAllTests()
        {
            _driver.Close();
            _driver.Quit();
        }

        [Test, Order(1)]
        [Category("UI")]
        public void GetResultsCount()
        {
            FliesResults fliesResults = new FliesResults(_driver);
            Assert.That(fliesResults.GetResults().Text, Does.Not.StartsWith("0").And.EndsWith("results"));
        }

        [Test, Order(2)]
        [Category("UI")]
        public void GetFlightTimesText()
        {
            FliesResults fliesResults = new FliesResults(_driver);
            Assert.AreEqual(fliesResults.GetFlightTimes().Text, "Flight times");
        }

        [Test, Order(3)]
        [Category("UI")]
        public void GetDepartsFromAirport()
        {
            FliesResults fliesResults = new FliesResults(_driver);
            Assert.AreEqual(fliesResults.GetDepartsFromParameter().Text, "Departs from Boryspil International Airport");
        }

        [Test, Order(4)]
        [Category("UI")]
        public void GetArrivesToAirport()
        {
            FliesResults fliesResults = new FliesResults(_driver);
            Assert.AreEqual(fliesResults.GetArrivesToParameter().Text, "Arrives to Copenhagen Airport");
        }

        [Test, Order(5)]
        [Category("UI")]
        public void SearchFlightsBestTabIsPresent()
        {
            FliesResults fliesResults = new FliesResults(_driver);
            Assert.AreEqual(fliesResults.GetBestTripsTab().Text, "Best");
        }

        [Test, Order(6)]
        [Category("UI")]
        public void SearchFlightsCheapestTabIsPresent()
        {
            FliesResults fliesResults = new FliesResults(_driver);
            Assert.AreEqual(fliesResults.GetCheapestTripsTab().Text, "Cheapest");
        }

        [Test, Order(7)]
        [Category("UI")]
        public void SearchFlightsFastestTabIsPresent()
        {
            FliesResults fliesResults = new FliesResults(_driver);
            Assert.AreEqual(fliesResults.GetFastestTripsTab().Text, "Fastest");
        }
    }
}
