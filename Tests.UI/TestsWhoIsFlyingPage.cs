using NUnit.Framework;
using Task13.Pages;

namespace Tests.UI
{
    public class TestsWhoIsFlyingPage : BaseTest
    {
        [OneTimeSetUp]
        public void AdditionalSetupBeforTestRun()
        {
            FastestTab fastestTab = new FastestTab(Driver);
            fastestTab.OpenFastestTabLastPage();
        }

        [Test, Order(1)]
        [Category("UI")]
        public void GetActiveElementInNavigationProgressBar()
        {
            WhoIsFlyingPage whoIsFlyingPage = new WhoIsFlyingPage(Driver);
            Assert.AreEqual(whoIsFlyingPage.GetActiveElementInNavigationProgressBar().Text, ("Who's flying?"));
        }

        [Test, Order(2)]
        [Category("UI")]
        public void PopulateMandatoryFieldsOnWhoIsFlyingPageAndGetNextCurrentTab()
        {         
            WhoIsFlyingPage whoIsFlyingNextPage = new WhoIsFlyingPage(Driver);
            whoIsFlyingNextPage.GetActiveElementInNavigationProgressBarToSetData();
            Assert.AreEqual(whoIsFlyingNextPage.PopulateMandatoryFieldsOnWhoIsFlyingPageAndGetActiveTab().Text, "Select your seat");
        }     
    }
}
