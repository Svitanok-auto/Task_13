using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Task13.Pages;

namespace Tests.UI
{
    public class TestsCheckAndPayPage : BaseTest
    {
        [OneTimeSetUp]
        public void AdditionalSetupBeforTestRun()
        {
            FastestTab fastestTab = new FastestTab(Driver);
            fastestTab.OpenFastestTabLastPage();

            WhoIsFlyingPage whoIsFlyingPage = new WhoIsFlyingPage(Driver);
            whoIsFlyingPage.GetActiveElementInNavigationProgressBar();

            WhoIsFlyingPage whoIsFlyingNextPage = new WhoIsFlyingPage(Driver);
            whoIsFlyingNextPage.PopulateMandatoryFieldsOnWhoIsFlyingPageAndGetActiveTab();
        }

        [Test, Order(1)]
        [Category("UI")]
        public void GetCheckAndPayTab()
        {
            CheckAndPayPage checkAndPayPage = new CheckAndPayPage(Driver);
            Assert.AreEqual(checkAndPayPage.GetCheckAndPayTab().Text, "Check and pay");
        }

        [Test, Order(2)]
        [Category("UI")]
        public void GetCheckAndPayTabPhone()
        {
            CheckAndPayPage checkAndPayPage = new CheckAndPayPage(Driver);
            Assert.AreEqual(checkAndPayPage.GetCheckAndPayTabPhone().Text, "+380931234567");
        }

        [Test, Order(3)]
        [Category("UI")]
        public void GetCheckAndPayTabEmail()
        {
            CheckAndPayPage checkAndPayPage = new CheckAndPayPage(Driver);
            Assert.AreEqual(checkAndPayPage.GetCheckAndPayTabEmail().Text, "vasiliyumniy1@gmail.com");
        }

        [Test, Order(4)]
        [Category("UI")]
        public void GetCheckAndPayTabFirstNameLastName()
        {
            CheckAndPayPage checkAndPayPage = new CheckAndPayPage(Driver);
            Assert.AreEqual(checkAndPayPage.GetCheckAndPayTabFirstNameLastName().Text, "Max Rockstar");
        }

        [Test, Order(5)]
        [Category("UI")]
        public void GetCheckAndPayTabGenderBirthday()
        {
            CheckAndPayPage checkAndPayPage = new CheckAndPayPage(Driver);
            Assert.AreEqual(checkAndPayPage.GetCheckAndPayTabGenderBirthday().Text, "Adult · Male · Dec 12, 1990");
        }

        [Test, Order(6)]
        [Category("UI")]
        public void GetCheckAndPayTabPassportInfo()
        {
            CheckAndPayPage checkAndPayPage = new CheckAndPayPage(Driver);
            Assert.AreEqual(checkAndPayPage.GetCheckAndPayTabPassportInfo().Text, "MT1234567 · UA · 2025-10-12");
        }
    }
}
