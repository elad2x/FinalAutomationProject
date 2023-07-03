using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Automation_Project.PageObjects
{
    internal class SavedItemsPage : BasePage
    {
        public SavedItemsPage(IWebDriver driver) : base(driver) { }
        public IList<IWebElement> SavedItems => Driver.FindElements(By.CssSelector("li.grid-card"));
        public IList<IWebElement> SuggestedItems => Driver.FindElements(By.CssSelector(".product-block-standard"));
        public IWebElement CompareBtn => Driver.FindElement(By.CssSelector(".compare-button.btn.btn-secondary"));
        public IWebElement MoreItems => Driver.FindElement(By.CssSelector("#grid-container .heading.v-fw-medium"));


        public IList<IWebElement> AllSavedItems()
        {
            return SavedItems;
        }

        public void GetAllSavedItems()
        {
            Console.WriteLine("All SAVED ITEMS: ");
            foreach (var savedItem in AllSavedItems())
            {
                Console.WriteLine(savedItem.FindElement(By.CssSelector("li.grid-card .title")).Text);
            }         
        }

        public string MoreItemsTitle()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#grid-container .heading.v-fw-medium")));
            return MoreItems.FindElement(By.CssSelector("span:first-child")).Text;
        }
        
        public void SaveItem(int num)
        {
            IWebElement item = SuggestedItems[num];
            WaitForElementVisibility(Driver,".product-block-standard", 10);
            Click(item.FindElement(By.CssSelector(".save-svg")));
        }
        public void DeleteItem(int num)
        {           
            IWebElement item = SavedItems[num];
            WaitForElementVisibility(Driver,"li.grid-card", 10);
            Click(item.FindElement(By.CssSelector(".card-delete")));
        }
        public void SeeMoreItems(int num)
        {
            IWebElement item = SavedItems[num];
            Click(item.FindElement(By.CssSelector(".card-see-more-like-this>.c-button-link")));
        }
        public void CheckBoxCompare(int num)
        {
            IWebElement item = SavedItems[num];
            Click(item.FindElement(By.CssSelector(".c-checkbox-brand.compare-checkbox-input")));
        }
        public void MakeNote(int num)
        {
            IWebElement item = SavedItems[num];
            Click(item.FindElement(By.CssSelector(".manage-notes")));
        }

        public void CompareItems()
        {
            Click(CompareBtn);
        }














    }
}
