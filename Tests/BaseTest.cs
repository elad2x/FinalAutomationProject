using Allure.Commons;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Net.Mime;

namespace Final_Automation_Project.Tests
{
   
    [AllureNUnit]  
    internal class BaseTest
    {
        public IWebDriver driver;
      
        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.bestbuy.com/";
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().GoToUrl(driver.Url);
        }

        [TearDown]
        public void TakeScreenShotOnFailure()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                AllureLifecycle.Instance.AddAttachment("Full page screenshot", MediaTypeNames.Image.Jpeg, ((ITakesScreenshot)driver).GetScreenshot().AsByteArray);
            }
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }


    }
}
