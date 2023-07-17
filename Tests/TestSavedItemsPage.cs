using Allure.Commons;
using Final_Automation_Project.PageObjects;
using NUnit.Allure.Attributes;
using NUnit.Framework;

namespace Final_Automation_Project.Tests
{
    [Parallelizable]
    internal class TestSavedItemsPage:BaseTest
    {
        [Test,Description("Test saving an item")]
        [AllureFeature("Save item")]
        [AllureSeverity(SeverityLevel.normal)]
        public void TC01_SaveItem()
        {
            OpeningPage openingPage = new OpeningPage(driver);
            openingPage.SelectCountry();
            driver.Url = "https://www.bestbuy.com/site/customer/lists/manage/saveditems";
            driver.Navigate().Refresh();
            SavedItemsPage savedItemsPage = new SavedItemsPage(driver);
            savedItemsPage.SaveItem(0);
            driver.Navigate().Refresh();
            savedItemsPage.GetAllSavedItems();
            Assert.True(savedItemsPage.AllSavedItems().Count > 0);
        }

        [Test, Description("Test see more items functionality")]
        [AllureFeature("See more items")]
        [AllureSeverity(SeverityLevel.normal)]
        public void TC02_SeeMoreItems()
        {
            SavedItemsPage savedItemsPage = new SavedItemsPage(driver);
            savedItemsPage.SeeMoreItems(0);
            Assert.That(savedItemsPage.MoreItemsTitle(),Is.EqualTo("People also viewed"));

        }

        [Test, Description("Test comparing items")]
        [AllureFeature("Compare items")]
        [AllureSeverity(SeverityLevel.normal)]
        public void TC03_CompareItems()
        {
            SavedItemsPage savedItemsPage = new SavedItemsPage(driver);
            savedItemsPage.SaveItem(1);
            driver.Navigate().Refresh();
            savedItemsPage.CheckBoxCompare(0);           
            savedItemsPage.CheckBoxCompare(1);
            savedItemsPage.CompareItems();
            CompareProductsPage compareProductsPage = new CompareProductsPage(driver);
            Assert.That(compareProductsPage.GetPageTitle(),Is.EqualTo("Compare Products"));
            driver.Navigate().Back();

        }

        [Test, Description("Test deleting an item")]
        [AllureFeature("Delete item")]
        [AllureSeverity(SeverityLevel.normal)]
        public void TC04_DeleteItem()
        {           
            SavedItemsPage savedItemsPage = new SavedItemsPage(driver);
            savedItemsPage.DeleteItem(1);
            driver.Navigate().Refresh();
            savedItemsPage.GetAllSavedItems();    
            Assert.True(savedItemsPage.AllSavedItems().Count == 1);

        }






    }
}
