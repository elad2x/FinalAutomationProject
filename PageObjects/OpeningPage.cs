using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Automation_Project.PageObjects
{
    internal class OpeningPage : BasePage
    {
        public OpeningPage(IWebDriver driver) : base(driver) { }
        public IWebElement ChooseCountry => Driver.FindElement(By.CssSelector(".us-link"));
        public void SelectCountry()
        {
            Click(ChooseCountry);
        }
    }
}
