using Allure.Commons;
using Final_Automation_Project.PageObjects;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Final_Automation_Project.Tests
{
    [Parallelizable]
    internal class TestTVsPage : BaseTest
    {
        [Test, Description("Test filtering TVs by size")]
        [AllureFeature("Screen size filter")]
        [AllureSeverity(SeverityLevel.blocker)]
        public void TC01_ScreenSize()
        {
            driver.Url = "https://www.bestbuy.com/site/tvs/all-flat-screen-tvs/abcat0101001.c?id=abcat0101001";
            OpeningPage openingPage = new OpeningPage(driver);
            openingPage.SelectCountry();
            TVsPage tvPage = new TVsPage(driver);
            tvPage.SelectScreenSize("55 - 64");
            Thread.Sleep(2000);
            Assert.That(tvPage.GetFilterValue(), Is.EqualTo("55\" - 64\""));
            tvPage.ClearFilter();
        }

        [Test, Description("Test filtering TVs by brand")]
        [AllureFeature("Brand filter")]
        [AllureSeverity(SeverityLevel.blocker)]
        public void TC02_Brand()
        {
            TVsPage tvPage = new TVsPage(driver);
            tvPage.SelectBrand("Sony");
            Assert.That(tvPage.GetFilterValue(), Is.EqualTo("Sony"));

        }

        [Test, Description("Test sort by functionality")]
        [AllureFeature("Sort by")]
        [AllureSeverity(SeverityLevel.blocker)]
        public void TC03_SortBy()
        {
            TVsPage tvPage = new TVsPage(driver);
            tvPage.SortBy("Best Discount");
            //Assert that the select value was selected
            Assert.AreEqual("Best Discount", tvPage.SortByFieldVal(), "The desired option should be selected.");
            tvPage.SortBy("Best Selling");

        }

        [Test, Description("Test TV screen size information")]
        [AllureFeature("TV screen size info")]
        [AllureSeverity(SeverityLevel.minor)]

        public void TC04_ScreenInfo()
        {
            TVsPage tvPage = new TVsPage(driver);
            tvPage.SelectScreenSizeInfo();
            Assert.IsTrue(tvPage.IsInforamtionPopupOpen());
            tvPage.CloseOverlay();

        }
        [Test, Description("Test add random item to cart")]
        [AllureFeature("Add to cart")]
        [AllureSeverity(SeverityLevel.critical)]
        public void TC05_AddToCart()
        {
            TVsPage tvPage = new TVsPage(driver);
            tvPage.AddRandomItemtoCart();
            tvPage.CloseOverlay();
            CartPage cartPage = new CartPage(driver);
            MainTopBar mainTopBar = new MainTopBar(driver);
            Thread.Sleep(2000);
            mainTopBar.OpenCart();
            //Console.WriteLine("Cart content number : " + cartPage.GetAllCartItems().Count);
            Assert.False(cartPage.IsCartEmpty());
        }


















    }
}
