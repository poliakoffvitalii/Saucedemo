using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Saucedemo.Pages;


namespace Saucedemo.Tests
{
    public class BaseTest
    {
        readonly String test_url = "https://www.saucedemo.com/";
        IWebDriver driver = new ChromeDriver();

        [TestInitialize]
        public void Initialize()
        {
            getDriver().Url = test_url;
            getDriver().Manage().Window.Maximize();
        }

        [TestCleanup]
        public void Cleanup()
        {
            getDriver().Close();
        }

        public IWebDriver getDriver()
        {
            return driver;
        }
        public HomePage getHomePage()
        {
            return new HomePage(getDriver());
        }
        public InventoryPage getInventoryPage()
        {
            return new InventoryPage(getDriver());
        }
    }
}
