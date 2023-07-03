using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Automation_Project.PageObjects
{
    internal class CompareProductsPage : BasePage
    {
        public CompareProductsPage(IWebDriver driver) : base(driver) { }

        public IWebElement PageTitle => Driver.FindElement(By.CssSelector(".heading-3.v-fw-bold.page-heading"));

        public string GetPageTitle()
        {
            return PageTitle.Text;
        }
    }
}
