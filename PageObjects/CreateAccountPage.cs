using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Automation_Project.PageObjects
{
    internal class CreateAccountPage : BasePage
    {
        public CreateAccountPage(IWebDriver driver) : base(driver) { }
        public IWebElement PageTitle => Driver.FindElement(By.CssSelector(".c-section-title.cia-section-title.cia-section-title__header.heading-5.v-fw-medium"));
        public string GetPageTitle()
        {
            return PageTitle.Text;
        }

       
    }
}
