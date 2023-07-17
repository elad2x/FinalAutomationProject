using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace Final_Automation_Project.PageObjects
{
    internal class BasePage
    {
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; set; }

        public static void WaitForElementVisibility(IWebDriver driver, string cssSelector, int timeoutSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(cssSelector)));
        }
        public void WaitForElement()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        public void WaitForElementVisible(IWebDriver driver, By locator, int timeoutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        public void FillText(IWebElement el, string text)
        {
            WaitForElement();
            HighlightElementV2(el, "red");
            el.Clear();
            el.SendKeys(text);
        }

        public void DeleteText(IWebElement el)
        {
            WaitForElement();
            HighlightElementV2(el, "red");
            el.Clear();
        }

        public void Click(IWebElement el)
        {
            WaitForElement();
            HighlightElementV2(el, "red");
            el.Click();
        }

        public void Select(IWebElement select, string value)
        {
            HighlightElementV2(select, "red");
            SelectElement el = new SelectElement(select);
            el.SelectByText(value);
        }

        public void ClearMenu(IWebElement el)
        {
            el.Click();
        }

        public bool IsDisplayed(IWebElement el)
        {
            return el.Displayed;
        }

        public void ScrollToElement(IWebElement element)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);

            // Wait for the scrolling to complete
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public void HighlightElementV1(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("arguments[0].setAttribute('style', 'border: 3px solid red;');", element);
        }

        public void HighlightElementV2(IWebElement element, String color)
        {
            //keep the old style to change it back
            String originalStyle = element.GetAttribute("style");

            String newStyle = "background-color:no;border: 4px solid " + color + ";" + originalStyle;
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;

            // Change the style 
            js.ExecuteScript("var tmpArguments = arguments;setTimeout(function () {tmpArguments[0].setAttribute('style', '" + newStyle + "');},0);",
                    element);

            // Change the style back after few miliseconds
            js.ExecuteScript("var tmpArguments = arguments;setTimeout(function () {tmpArguments[0].setAttribute('style', '"
                    + originalStyle + "');},800);", element);

        }














    }
}
