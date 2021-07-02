using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Pages;

namespace Tests.UI
{
    public class TestsFastestTab
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

        [Test]
        [Category("UI")]
        public void MaxJourneyTimeCheck()
        {
            FastestTab fastestTab = new FastestTab(_driver);
            Assert.AreEqual(fastestTab.MaxJourney(), true);
        }
    }
}
