using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Final_Automation_Project.PageObjects
{
    internal class TVsPage : BasePage
    {
        public TVsPage(IWebDriver driver) : base(driver) { }

        private Random random = new Random();
        public IWebElement SortByField => Driver.FindElement(By.CssSelector("#sort-by-select"));
        public IWebElement FilterVal => Driver.FindElement(By.CssSelector(".c-facet-button.flex.align-items-center.border.rounded.border-interactive.h-300.px-100.bg-none"));
        public IWebElement ClearFilterBtn => Driver.FindElement(By.CssSelector(".c-button-link.clear-all"));
        public IWebElement ScreenSizeInfoBtn => Driver.FindElement(By.CssSelector("[aria-label='TV Screen Size info'] "));
        public IWebElement InformationPopup => Driver.FindElement(By.CssSelector(".modal-container.component-facets"));
        public IList<IWebElement> AllItems => Driver.FindElements(By.CssSelector(".sku-item"));
        public IWebElement Overlay => Driver.FindElement(By.CssSelector(".c-overlay-fullscreen"));
        public IWebElement ContinueShopping => Driver.FindElement(By.CssSelector(".c-button-link.continue-shopping"));


        //Screen size elements:
        public IWebElement ThirtyTwoAndUnder => Driver.FindElement(By.CssSelector("[name='TV Screen Size'] li:nth-child(1) .c-checkbox-input.appearance-none.border-25.rounded-25"));
        public IWebElement ThirtyFourToFortyFour => Driver.FindElement(By.CssSelector("[name='TV Screen Size'] li:nth-child(2) .c-checkbox-input.appearance-none.border-25.rounded-25"));
        public IWebElement FortyFiveToFiftyFour => Driver.FindElement(By.CssSelector("[name='TV Screen Size'] li:nth-child(3) .c-checkbox-input.appearance-none.border-25.rounded-25"));
        public IWebElement FiftyFIveToSixtyFour => Driver.FindElement(By.CssSelector("[name='TV Screen Size'] li:nth-child(4) .c-checkbox-input.appearance-none.border-25.rounded-25"));
        public IWebElement SixtyFiveToSeventyFour => Driver.FindElement(By.CssSelector("[name='TV Screen Size'] li:nth-child(5) .c-checkbox-input.appearance-none.border-25.rounded-25"));
        public IWebElement SeventyFiveToEightyFour => Driver.FindElement(By.CssSelector("[name='TV Screen Size'] li:nth-child(6) .c-checkbox-input.appearance-none.border-25.rounded-25"));
        public IWebElement EightyFiveAndMore => Driver.FindElement(By.CssSelector("[name='TV Screen Size'] li:nth-child(7) .c-checkbox-input.appearance-none.border-25.rounded-25"));

        //Brand elements: 
        public IWebElement BestBuyBrands => Driver.FindElement(By.CssSelector("[name='Brand'] li:nth-child(1) .c-checkbox-input.appearance-none.border-25.rounded-25"));
        public IWebElement LG => Driver.FindElement(By.CssSelector("[name='Brand'] li:nth-child(2) .c-checkbox-input.appearance-none.border-25.rounded-25"));
        public IWebElement Samsung => Driver.FindElement(By.CssSelector("[name='Brand'] li:nth-child(3) .c-checkbox-input.appearance-none.border-25.rounded-25"));
        public IWebElement Sony => Driver.FindElement(By.CssSelector("[name='Brand'] li:nth-child(4) .c-checkbox-input.appearance-none.border-25.rounded-25"));
        public IWebElement TCL => Driver.FindElement(By.CssSelector("[name='Brand'] li:nth-child(5) .c-checkbox-input.appearance-none.border-25.rounded-25"));
        public IWebElement Hisense => Driver.FindElement(By.CssSelector("[name='Brand'] li:nth-child(6) .c-checkbox-input.appearance-none.border-25.rounded-25"));
        public IWebElement Insignia => Driver.FindElement(By.CssSelector("[name='Brand'] li:nth-child(7) .c-checkbox-input.appearance-none.border-25.rounded-25"));
        public IWebElement Roku => Driver.FindElement(By.CssSelector("[name='Brand'] li:nth-child(8) .c-checkbox-input.appearance-none.border-25.rounded-25"));

        public void AddRandomItemtoCart()
        {
            Console.WriteLine("Items number: " + AllItems.Count);
            int randomIndex = random.Next(0, AllItems.Count);
            IWebElement randomItem = AllItems[randomIndex];
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", randomItem);
            Console.WriteLine("The random numer: " + randomIndex);
            string itemName = randomItem.Text;
            Console.WriteLine("Adding item to cart: " + itemName);
            WebDriverWait wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 30));
            IWebElement addToCartButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(randomItem.FindElement(By.CssSelector(".sli-add-to-cart"))));
            Click(randomItem.FindElement(By.CssSelector(".fulfillment-add-to-cart-button")));
        }
        public void AddItemtoCart(int num)
        {
            Console.WriteLine("All ITEMS: ");
            foreach (var item1 in AllItems)
            {
                Console.WriteLine(item1.Text);
            }

            Console.WriteLine("Items number: " + AllItems.Count);
            IWebElement item = AllItems[num];
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", item);
            Console.WriteLine("The selected nnumer: " + num);
            string itemName = item.Text;
            Console.WriteLine("Adding item to cart: " + itemName);
            WebDriverWait wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 30));
            IWebElement addToCartButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(item.FindElement(By.CssSelector(".sli-add-to-cart"))));
            Click(item.FindElement(By.CssSelector(".fulfillment-add-to-cart-button")));

        }

        public void CloseCartPoppup()
        {
            WebDriverWait wait = new WebDriverWait(Driver, new TimeSpan(10));
            IWebElement addToCartButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(ContinueShopping));
            Click(ContinueShopping);
        }

        public void CloseOverlay()
        {
            WebDriverWait wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 30));
            IWebElement addToCartButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(Overlay));
            Click(Overlay);
        }
        public bool IsInforamtionPopupOpen()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".modal-container.component-facets")));
            return IsDisplayed(InformationPopup);
        }
        public void SortBy(string filter)
        {
            Select(SortByField, filter);
        }
        //Get the value of sort by field
        public string SortByFieldVal()
        {
            SelectElement el = new SelectElement(SortByField);
            IWebElement selectedOption = el.SelectedOption;
            return selectedOption.Text;
        }

        public string GetFilterValue()
        {
            return FilterVal.GetAttribute("data-value");
        }
        public void ClearFilter()
        {
            Click(ClearFilterBtn);
        }

        public void SelectScreenSizeInfo()
        {
            Click(ScreenSizeInfoBtn);
        }
        public void SelectScreenSize(string size)
        {
            switch (size)
            {
                case "32 and Under":
                    Click(ThirtyTwoAndUnder);
                    break;
                case "33 - 44":
                    Click(ThirtyFourToFortyFour);
                    break;
                case "45 - 54":
                    Click(FortyFiveToFiftyFour);
                    break;
                case "55 - 64":
                    Click(FiftyFIveToSixtyFour);
                    break;
                case "65 - 74":
                    Click(SixtyFiveToSeventyFour);
                    break;
                case "75 - 84":
                    Click(SeventyFiveToEightyFour);
                    break;
                case "85 or More":
                    Click(EightyFiveAndMore);
                    break;
                default:
                    break;
            }
        }
        public void SelectBrand(string brand)
        {
            switch (brand)
            {
                case "Best Buy Brands":
                    Click(BestBuyBrands);
                    break;
                case "LG":
                    Click(LG);
                    break;
                case "Samsung":
                    Click(Samsung);
                    break;
                case "Sony":
                    Click(Sony);
                    break;
                case "TCL":
                    Click(TCL);
                    break;
                case "Hisense":
                    Click(Hisense);
                    break;
                case "Insignia":
                    Click(Insignia);
                    break;
                case "Roku":
                    Click(Roku);
                    break;
                default:
                    break;
            }
        }







    }
}
