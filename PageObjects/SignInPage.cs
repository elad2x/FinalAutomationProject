using OpenQA.Selenium;
using System.Threading;

namespace Final_Automation_Project.PageObjects
{
    internal class SignInPage : BasePage
    {
        public SignInPage(IWebDriver driver) : base(driver) { }
        public IWebElement EmailField => Driver.FindElement(By.CssSelector("#fld-e"));
        public IWebElement PasswordField => Driver.FindElement(By.CssSelector("#fld-p1"));
        public IWebElement ForgotPasswordBtn => Driver.FindElement(By.CssSelector(".cia-signin__forgot a"));
        public IWebElement SignInBtn => Driver.FindElement(By.CssSelector(".cia-form__controls"));
        public IWebElement ErrorMsg => Driver.FindElement(By.CssSelector(".c-alert-content.rounded-r-100.flex-fill.v-bg-pure-white.p-200.pl-none"));
        public IWebElement CreateAccountBtn => Driver.FindElement(By.CssSelector(".cia-signin__alternative-action"));
        public void FillEmailAddress(string email)
        {
            FillText(EmailField, email);
        }
        public void FillPassword(string password)
        {
            FillText(PasswordField, password);
        }
        public void SignIn()
        {           
            Click(SignInBtn);
        }

        public void OpenForgotPassword()
        {
            Thread.Sleep(1500);
            Click(ForgotPasswordBtn);           
        }

        public bool IsErrorDisplayed()
        {
            return IsDisplayed(ErrorMsg);
        }


        public string GetErrorMessage()
        {
            By elementLocator = By.CssSelector(".c-alert-content.rounded-r-100.flex-fill.v-bg-pure-white.p-200.pl-none");
            int timeoutInSeconds = 10;
            WaitForElementVisible(Driver, elementLocator, timeoutInSeconds);
            IWebElement errorElement = Driver.FindElement(elementLocator);
            return errorElement.Text;
        }
       
        public void OpenCreateAccount()
        {
            Click(CreateAccountBtn);
        }

        public void ClearEmailField()
        {
            EmailField.SendKeys(Keys.Control + "a"); // Select all text
            EmailField.SendKeys(Keys.Delete);
        }

        public void ClearPassowrdField()
        {
            PasswordField.SendKeys(Keys.Control + "a");
            PasswordField.SendKeys(Keys.Delete);
        }
    }
}
