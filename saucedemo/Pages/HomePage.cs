using System.Net.NetworkInformation;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Saucedemo.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='user-name']")]
        private readonly IWebElement UserName;

        [FindsBy(How = How.XPath, Using = "//*[@id='password']")]
        private readonly IWebElement Password;

        [FindsBy(How = How.XPath, Using = "//*[@id='login-button']")]
        private readonly IWebElement LoginBotton;

        [FindsBy(How = How.XPath, Using = "//*[@id='login_button_container']/div/form/div[3]/h3")]
        private readonly IWebElement ErrorBox;


        public IWebElement GetUserNameField()
        {
            return UserName;
        }
        public IWebElement GetPasswordField()
        {
            return Password;
        }

        public void InputUserName(string UserName)
        {
            this.UserName.Clear();
            this.UserName.SendKeys(UserName);
        }
        public void InputPassword(string Password)
        {
            this.Password.Clear();
            this.Password.SendKeys(Password);
        }
        public IWebElement GetLoginBotton()
        {
            return LoginBotton;
        }
        public void ClickLoginBotton()
        {
            LoginBotton.Click();
        }
        public IWebElement GetError()
        {
            return ErrorBox;
        }
    }
}

