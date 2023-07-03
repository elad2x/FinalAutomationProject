using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Automation_Project.PageObjects
{
    internal class Menu : BasePage
    {
        public Menu(IWebDriver driver) : base(driver) { }
        public IWebElement MenuDealsBtn => Driver.FindElement(By.CssSelector(".c-button-unstyled.top-four.v-fw-medium"));
        public IWebElement TVHomeTheaterBtn => Driver.FindElement(By.CssSelector(".hamburger-menu-flyout-list-wrapper.toast-arrow-up li:nth-child(8)"));
        
        public void OpenTVTheaterMenu()
        {
            Click(TVHomeTheaterBtn);
        }
        public void OpenDeals()
        {
            Click(MenuDealsBtn);
        }

    }
}
