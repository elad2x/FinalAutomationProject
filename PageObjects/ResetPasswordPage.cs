using OpenQA.Selenium;

namespace Final_Automation_Project.PageObjects
{
    internal class ResetPasswordPage : BasePage
    {
        public ResetPasswordPage(IWebDriver driver) : base(driver) { }
        public IWebElement PageTitle => Driver.FindElement(By.CssSelector(".c-section-title.cia-section-title.cia-section-title__header.heading-5.v-fw-medium"));
        public string GetPageTitle()
        {
            return PageTitle.Text;
        }
    }
}
