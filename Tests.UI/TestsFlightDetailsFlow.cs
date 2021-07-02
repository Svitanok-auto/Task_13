using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Pages;

namespace Tests.UI
{
    public class TestsFlightDetailsFlow
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
            FastestTab fastestTab = new FastestTab(_driver);
            fastestTab.OpenFastestTabLastPage();
        }

        [OneTimeTearDown]
        public void AfterAllTests()
        {
            _driver.Close();
            _driver.Quit();
        }

        [Test, Order(1)]
        [Category("UI")]
        public void GetActiveElementInNavigationProgressBar()
        {
            FlightDetailsFlow flightDetailsFlow = new FlightDetailsFlow(_driver);
            Assert.AreEqual(flightDetailsFlow.GetActiveElementInNavigationProgressBar().Text, ("Who's flying?"));
        }

        [Test, Order(2)]
        [Category("UI")]
        public void PopulateMandatoryFieldsOnWhoIsFlyingPageAndGetNextCurrentTab()
        {
            FlightDetailsFlow flightDetailsFlowNextPage = new FlightDetailsFlow(_driver);
            Assert.AreEqual(flightDetailsFlowNextPage.PopulateMandatoryFieldsOnWhoIsFlyingPageAndGetActiveTab().Text, "Select your seat");
        }

        [Test, Order(3)]
        [Category("UI")]
        public void GetCheckAndPayTab()
        {
            FlightDetailsFlow flightDetailsCheckAndPayTab = new FlightDetailsFlow(_driver);
            Assert.AreEqual(flightDetailsCheckAndPayTab.GetCheckAndPayTab().Text, "Check and pay");
        }

        [Test, Order(4)]
        [Category("UI")]
        public void GetCheckAndPayTabPhone()
        {
            FlightDetailsFlow flightDetailsCheckAndPayTabPhone = new FlightDetailsFlow(_driver);
            Assert.AreEqual(flightDetailsCheckAndPayTabPhone.GetCheckAndPayTabPhone().Text, "+380931234567");
        }

        [Test, Order(5)]
        [Category("UI")]
        public void GetCheckAndPayTabEmail()
        {
            FlightDetailsFlow flightDetailsCheckAndPayTabEmail = new FlightDetailsFlow(_driver);
            Assert.AreEqual(flightDetailsCheckAndPayTabEmail.GetCheckAndPayTabEmail().Text, "vasiliyumniy1@gmail.com");
        }

        [Test, Order(6)]
        [Category("UI")]
        public void GetCheckAndPayTabFirstNameLastName()
        {
            FlightDetailsFlow flightDetailsCheckAndPayTabName = new FlightDetailsFlow(_driver);
            Assert.AreEqual(flightDetailsCheckAndPayTabName.GetCheckAndPayTabFirstNameLastName().Text, "Max Rockstar");
        }

        [Test, Order(7)]
        [Category("UI")]
        public void GetCheckAndPayTabGenderBirthday()
        {
            FlightDetailsFlow flightDetailsCheckAndPayTabGenderBirthday = new FlightDetailsFlow(_driver);
            Assert.AreEqual(flightDetailsCheckAndPayTabGenderBirthday.GetCheckAndPayTabGenderBirthday().Text, "Adult · Male · Dec 12, 1990");
        }

        [Test, Order(8)]
        [Category("UI")]
        public void GetCheckAndPayTabPassportInfo()
        {
            FlightDetailsFlow flightDetailsCheckAndPayTabPassportInfo = new FlightDetailsFlow(_driver);
            Assert.AreEqual(flightDetailsCheckAndPayTabPassportInfo.GetCheckAndPayTabPassportInfo().Text, "MT1234567 · UA · 2025-10-12");
        }
    }
}
