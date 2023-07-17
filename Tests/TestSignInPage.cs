using Allure.Commons;
using Final_Automation_Project.PageObjects;
using NUnit.Allure.Attributes;
using NUnit.Framework;

namespace Final_Automation_Project.Tests
{
    [Parallelizable]
    internal class TestSignInPage : BaseTest
    {
             
        [Test, Description("Test invaild email")]
        [AllureFeature("Incorrect email error message")]
        [AllureSeverity(SeverityLevel.critical)]
        public void TC01_InvalidEmail()
        {
            OpeningPage openingPage = new OpeningPage(driver);
            openingPage.SelectCountry();
            driver.Navigate().Refresh();
            MainTopBar mainTopBar = new MainTopBar(driver);
            mainTopBar.OpenAccountMenu();
            AccountMenu accountMenu = new AccountMenu(driver);
            accountMenu.SignIn();
            SignInPage signInPage = new SignInPage(driver);
            //signInPage.ClearEmailField();
            //signInPage.ClearPassowrdField();
            signInPage.FillEmailAddress("t71825@gmail.com");
            signInPage.FillPassword("2E1BT56!5");
            signInPage.SignIn();
            Assert.That(signInPage.GetErrorMessage(), Is.EqualTo("We didn't find an account with that email address. Would you like to create an account?"));
        }

        [Test, Description("Test forgot password functionality")]
        [AllureFeature("Forgot your passowrd?")]
        [AllureSeverity(SeverityLevel.blocker)]

        public void TC02_ForgotPassword()
        {
            SignInPage signInPage = new SignInPage(driver);
            signInPage.OpenForgotPassword();           
            ResetPasswordPage resetPasswordPage = new ResetPasswordPage(driver);          
            Assert.That(resetPasswordPage.GetPageTitle(), Is.EqualTo("Reset Your Password"));
            driver.Navigate().Back();
        }

        [Test, Description("Test creating an account functionality")]
        [AllureFeature("Forgot your passowrd?")]
        [AllureSeverity(SeverityLevel.blocker)]
        public void TC03_CreateAccount()
        {
            SignInPage signInPage = new SignInPage(driver);
            signInPage.OpenCreateAccount();           
            CreateAccountPage createAccountPage = new CreateAccountPage(driver);
            Assert.That(createAccountPage.GetPageTitle().Equals("Create an Account"));
            driver.Navigate().Back();
        }

        [Test, Description("Test login functionality")]
        [AllureFeature("Login")]
        [AllureSeverity(SeverityLevel.blocker)]
        public void TC04_Login()
        {                    
            SignInPage signInPage = new SignInPage(driver);
            signInPage.FillEmailAddress("t7116825@gmail.com");
            signInPage.FillPassword("TE35#%ST14!$");
            signInPage.SignIn();
            
            driver.Navigate().Back();
            driver.Navigate().Back();
            MainTopBar mainTopBar = new MainTopBar(driver);
            mainTopBar.OpenAccountMenu();
            AccountMenu accountMenu = new AccountMenu(driver);            
            Assert.IsTrue(accountMenu.IsLoggedIn());
            
            
            
        }
    }
}
