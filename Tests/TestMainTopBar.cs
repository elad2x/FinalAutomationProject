using Allure.Commons;
using Final_Automation_Project.PageObjects;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using System;

namespace Final_Automation_Project.Tests
{
    [Parallelizable]
    internal class TestMainTopBar : BaseTest
    {
        [Test, Description("Test search functionality")]
        [AllureFeature("Search")]
        [AllureSeverity(SeverityLevel.blocker)]
        public void TC01_Search()
        {
            OpeningPage openingPage = new OpeningPage(driver);
            openingPage.SelectCountry();
            MainTopBar mainTopBar = new MainTopBar(driver);
            mainTopBar.FillSearch("PlayStation 5");
            mainTopBar.SubmitSearch();
            SearchResultsPage searchPage = new SearchResultsPage(driver);
            //Console.WriteLine(searchPage.SearchTitle.Text);
            Assert.IsTrue(searchPage.IsSearched("\"PlayStation 5\""));
        }

        [Test, Description("Test top deals opening")]
        [AllureFeature("Open top deals")]
        [AllureSeverity(SeverityLevel.blocker)]
        public void TC02_TopDeals()
        {
            MainTopBar mainTopBar = new MainTopBar(driver);
            mainTopBar.OpenTopDeals();
            TopDealsPage topDealsPage = new TopDealsPage(driver);
            Assert.IsTrue(topDealsPage.IsTopDealsOpen("Top Deals"));
        }

        [Test, Description("Test Health and Wellness opening")]
        [AllureFeature("Open Health and Wellness")]
        [AllureSeverity(SeverityLevel.blocker)]
        public void TC03_HealthWellness()
        {
            MainTopBar mainTopBar = new MainTopBar(driver);
            mainTopBar.OpenHealthWellness();
            HealthAndWellnessPage healthAndWellnessPage = new HealthAndWellnessPage(driver);
            Console.WriteLine(healthAndWellnessPage.HealthWellnessTitle.Text);
            Assert.IsTrue(healthAndWellnessPage.IsHealthWellnessOpened("Health & Wellness Solutions"));
        }
        [Test, Description("Test opening menu")]
        [AllureFeature("Open menu")]
        [AllureSeverity(SeverityLevel.blocker)]
        public void TC04_OpenMenu()
        {
            MainTopBar mainTopBar = new MainTopBar(driver);
            mainTopBar.OpenMenu();
            Assert.IsTrue(mainTopBar.IsMenuOpend());
            //mainPage.ClearOverlay();
        }
        [Test, Description("Test opening cart")]
        [AllureFeature("Open cart")]
        [AllureSeverity(SeverityLevel.blocker)]
        public void TC05_OpenCart()
        {
            MainTopBar mainTopBar = new MainTopBar(driver);
            mainTopBar.OpenCart();
            CartPage cartPage = new CartPage(driver);
            Assert.IsTrue(cartPage.IsCartPageOpen());
        }

    }
}
