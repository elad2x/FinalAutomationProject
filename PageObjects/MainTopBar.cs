using OpenQA.Selenium;

namespace Final_Automation_Project.PageObjects
{
    internal class MainTopBar : BasePage
    {
        public MainTopBar(IWebDriver driver) : base(driver) { }
        public IWebElement OpenMenuBtn => Driver.FindElement(By.CssSelector(".open-hamburger-icon"));
        public IWebElement CloseMenuBtn => Driver.FindElement(By.CssSelector(".close-hamburger-icon"));
        public IWebElement CartBtn => Driver.FindElement(By.CssSelector(".cart-icon"));
        public IWebElement SearchField => Driver.FindElement(By.CssSelector("#gh-search-input"));
        public IWebElement SearchSubmitBtn => Driver.FindElement(By.CssSelector(".header-search-button"));
        public IWebElement TopDealsBtn => Driver.FindElement(By.CssSelector(".bottom-nav-left.lv>li:nth-child(1) a"));
        public IWebElement HealthWellnessBtn => Driver.FindElement(By.CssSelector(".bottom-nav-left.lv>li:nth-child(8) a"));
        public IWebElement AccountMenuBtn => Driver.FindElement(By.CssSelector("#account-menu-account-button"));
     
        public void OpenAccountMenu()
        {
            Click(AccountMenuBtn);
        }

        public void OpenHealthWellness()
        {
            Click(HealthWellnessBtn);
        }
        public void OpenTopDeals()
        {
            Click(TopDealsBtn);
        }
        public void FillSearch(string searchInput)
        {
            FillText(SearchField, searchInput);
        }
        public void SubmitSearch()
        {
            Click(SearchSubmitBtn);
        }
        public void OpenCart()
        {
            Click(CartBtn);
        }
        public void OpenMenu()
        {
            Click(OpenMenuBtn);
        }
        public void CloseMenu()
        {
            Click(CloseMenuBtn);
        }

        public bool IsMenuClosed()
        {
            return IsDisplayed(OpenMenuBtn);
        }

        public bool IsMenuOpend()
        {
            return IsDisplayed(CloseMenuBtn);
        }

    }
}
