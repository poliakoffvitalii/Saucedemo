using System.Net.NetworkInformation;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Saucedemo.Pages
{
    public class InventoryPage : BasePage
    {
        public InventoryPage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='header_container']/div[1]/div[2]")]
        private readonly IWebElement Header;

        public IWebElement GetHeader()
        {
            return Header;
        }
    }
}
