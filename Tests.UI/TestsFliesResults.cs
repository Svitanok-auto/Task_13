using NUnit.Framework;
using Task13.Pages;

namespace Tests.UI
{
    public class TestsFliesResults : BaseTest
    {
        [Test, Order(1)]
        [Category("UI")]
        public void GetResultsCount()
        {
            FliesResults fliesResults = new FliesResults(Driver);
            Assert.That(fliesResults.GetResults().Text, Does.Not.StartsWith("0").And.EndsWith("results"));
        }

        [Test, Order(2)]
        [Category("UI")]
        public void GetFlightTimesText()
        {
            FliesResults fliesResults = new FliesResults(Driver);
            Assert.AreEqual(fliesResults.GetFlightTimes().Text, "Flight times");
        }

        [Test, Order(3)]
        [Category("UI")]
        public void GetDepartsFromAirport()
        {
            FliesResults fliesResults = new FliesResults(Driver);
            Assert.AreEqual(fliesResults.GetDepartsFromParameter().Text, "Departs from Boryspil International Airport");
        }

        [Test, Order(4)]
        [Category("UI")]
        public void GetArrivesToAirport()
        {
            FliesResults fliesResults = new FliesResults(Driver);
            Assert.AreEqual(fliesResults.GetArrivesToParameter().Text, "Arrives to Copenhagen Airport");
        }

        [Test, Order(5)]
        [Category("UI")]
        public void SearchFlightsBestTabIsPresent()
        {
            FliesResults fliesResults = new FliesResults(Driver);
            Assert.AreEqual(fliesResults.GetBestTripsTab().Text, "Best");
        }

        [Test, Order(6)]
        [Category("UI")]
        public void SearchFlightsCheapestTabIsPresent()
        {
            FliesResults fliesResults = new FliesResults(Driver);
            Assert.AreEqual(fliesResults.GetCheapestTripsTab().Text, "Cheapest");
        }

        [Test, Order(7)]
        [Category("UI")]
        public void SearchFlightsFastestTabIsPresent()
        {
            FliesResults fliesResults = new FliesResults(Driver);
            Assert.AreEqual(fliesResults.GetFastestTripsTab().Text, "Fastest");
        }
    }
}
