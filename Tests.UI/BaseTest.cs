using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Task13.Pages;

namespace Tests.UI
{
    public abstract class BaseTest
    {
        public IWebDriver Driver { get; set; }
        public TestSettings Settings { get; set; }
        public MainPage MainPage { get; set; }

        [OneTimeSetUp]
        public void SetUpBeforeTestRun()
        {
            Settings = new TestSettings();
            var configuration = new ConfigurationBuilder()
                                    .AddJsonFile("appsettings.json")
                                    .Build();
            configuration.Bind(Settings);

            ChromeOptions options = new ChromeOptions();
            if (Settings.Headless)
            {
                options.AddArgument("headless");
            }
            Driver = new ChromeDriver(options);
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(Settings.HomeURL);

            // MainPage mainPage = new MainPage(Driver);
            // mainPage.SearchForFlights();
            MainPage = new MainPage(Driver);
            PageFactory.InitElements(Driver, MainPage);
            MainPage.SearchForFlights();
        }

        [OneTimeTearDown]
        public void AfterAllTests()
        {
            Driver.Close();
            Driver.Quit();
        }
    }
}
