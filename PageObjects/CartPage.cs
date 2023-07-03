using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Automation_Project.PageObjects
{
    internal class CartPage : BasePage
    {
        public CartPage(IWebDriver driver) : base(driver) { }
        public IWebElement OrderSummary => Driver.FindElement(By.CssSelector("#cart-order-summary"));
        public IList<IWebElement> CartItems => Driver.FindElements(By.CssSelector(".item-list .fluid-item"));
        public IList<IWebElement> SuggestedItems => Driver.FindElements(By.CssSelector(".product-block-standard"));
        public IWebElement CheckoutBtn => Driver.FindElement(By.CssSelector(".btn.btn-lg.btn-block.btn-primary"));
        public IWebElement Amount => Driver.FindElement(By.CssSelector(".fluid-item__actions  .tb-select "));
        public IWebElement CartPopup => Driver.FindElement(By.CssSelector(".c-close-icon.c-modal-close-icon"));
        public IWebElement UndoBtn => Driver.FindElement(By.CssSelector(".c-button-link.removed-item-info__link-undo"));

        //.fulfillment-add-to-cart-button - add to cart button
        
        public void Undo()
        {
            Click(UndoBtn);
        }
        public void AddItemtoCart(int num)
        {
            IWebElement item = SuggestedItems[num];
            Click(item.FindElement(By.CssSelector(".fulfillment-add-to-cart-button")));
        }

        public IWebElement ItemInfoMessage => Driver.FindElement(By.CssSelector(".removed-item-info .removed-item-info__message"));

        public string InfoMessage()
        {
            return ItemInfoMessage.Text;
        }
        public void ClosePopup()
        {
            Click(CartPopup);
        }
        public void SelectAmount(string amount)
        {
            WebDriverWait wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 30));
            IWebElement addToCartButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(Amount));
            Select(Amount, amount);
        }
        internal void RemoveAnItem(int num)
        {
            IWebElement item = CartItems[num];
            Click(item.FindElement(By.CssSelector(".c-button-link.cart-item__remove")));
        }

        internal void SaveAnItem(int num)
        { 
            IWebElement item = CartItems[num];
            Click(item.FindElement(By.CssSelector(".c-button-link.cart-item__save")));
        }

        public string SortByFieldVal()
        {
            SelectElement el = new SelectElement(Amount);
            IWebElement selectedOption = el.SelectedOption;
            return selectedOption.Text;
        }

        public IList<IWebElement> GetAllCartItems()
        {
            return CartItems;
        }

        public bool IsCartEmpty()
        {
            if (CartItems.Count == 0)
                return true;
            else 
                return false;        
        }

        public bool IsCartPageOpen()
        {
            return OrderSummary.Text.Equals("Order Summary");
        }
 


    }
}
