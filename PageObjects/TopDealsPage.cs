using OpenQA.Selenium;

namespace Final_Automation_Project.PageObjects
{
    internal class TopDealsPage : BasePage
    {
        public TopDealsPage(IWebDriver driver) : base(driver){}
        public IWebElement TopDealsTitle => Driver.FindElement(By.CssSelector(".cn-deals-text"));

        public bool IsTopDealsOpen(string text)
        {
            return TopDealsTitle.Text.Equals(text);
        }

    }
}
