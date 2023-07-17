using OpenQA.Selenium;

namespace Final_Automation_Project.PageObjects
{
    internal class SearchResultsPage : BasePage
    {
        public SearchResultsPage(IWebDriver driver) : base(driver) {}
        public IWebElement SearchTitle => Driver.FindElement(By.CssSelector(".search-title"));

        public bool IsSearched(string text)
        {
            return SearchTitle.Text.ToLower().Equals(text.ToLower());
        }

    }
}
