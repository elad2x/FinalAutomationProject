using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
