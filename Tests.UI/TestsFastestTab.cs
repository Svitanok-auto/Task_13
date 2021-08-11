using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Task13.Pages;

namespace Tests.UI
{
    public class TestsFastestTab : BaseTest
    {
        [Test]
        [Category("UI")]
        public void MaxJourneyTimeCheck()
        {
            FastestTab fastestTab = new FastestTab(Driver);
            Assert.AreEqual(fastestTab.MaxJourney(), true);
        }
    }
}
