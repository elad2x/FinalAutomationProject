using OpenQA.Selenium;

namespace Final_Automation_Project.PageObjects
{
    internal class HealthAndWellnessPage : BasePage
    {
        public HealthAndWellnessPage(IWebDriver driver) : base(driver) { }
        public IWebElement HealthWellnessTitle => Driver.FindElement(By.CssSelector(".col-xs-12 .page-title"));

        public bool IsHealthWellnessOpened(string text)
        {
            return HealthWellnessTitle.Text.Equals(text);
        }

    }
}
