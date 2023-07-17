using Allure.Commons;
using Final_Automation_Project.PageObjects;
using NUnit.Allure.Attributes;
using NUnit.Framework;

namespace Final_Automation_Project.Tests
{
    [Parallelizable]
    internal class TestCartPage : BaseTest
    {
        [Test, Description("Test saving item")]
        [AllureFeature("Save item")]
        [AllureSeverity(SeverityLevel.normal)]
        public void TC01_RemoveItem()
        {
            OpeningPage openingPage = new OpeningPage(driver);
            openingPage.SelectCountry();
            MainTopBar mainTopBar = new MainTopBar(driver);
            mainTopBar.OpenCart();
            CartPage cartPage = new CartPage(driver);
            cartPage.AddItemtoCart(2);
            cartPage.RemoveAnItem(0);
            Assert.That(cartPage.InfoMessage(), Is.EqualTo("We’ve removed this item from your cart."));
            cartPage.Undo();
        }


        [Test, Description("Test saving item")]
        [AllureFeature("Save item")]
        [AllureSeverity(SeverityLevel.normal)]
        public void TC02_SaveItem()
        {
            CartPage cartPage = new CartPage(driver);
            cartPage.SaveAnItem(0);
            Assert.That(cartPage.InfoMessage(), Is.EqualTo("We’ve moved this to your saved items."));
            cartPage.Undo();
        }

        [Test, Description("Test selecting item amount")]
        [AllureFeature("Select amount")]
        [AllureSeverity(SeverityLevel.critical)]
        public void TC03_SelectAmount()
        {
            CartPage cartPage = new CartPage(driver);
            cartPage.SelectAmount("2");
            Assert.AreEqual("2", cartPage.SortByFieldVal(), "The desired option should be selected.");

        }












    }
}
