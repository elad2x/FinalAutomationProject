using OpenQA.Selenium;

namespace Final_Automation_Project.PageObjects
{
    internal class AccountMenu : BasePage
    {
        public AccountMenu(IWebDriver driver) : base(driver) { }
        public IWebElement SignOutBtn => Driver.FindElement(By.CssSelector("#logout-button-bby"));
        public IWebElement SignInBtn => Driver.FindElement(By.CssSelector(".c-button.c-button-secondary.c-button-sm.sign-in-btn"));

        public void SignIn()
        {
            Click(SignInBtn);
        }
        public void SignOut()
        {
            Click(SignOutBtn);
        }

        public bool IsLoggedIn()
        {
            return IsDisplayed(SignOutBtn);
        }

    }
}
