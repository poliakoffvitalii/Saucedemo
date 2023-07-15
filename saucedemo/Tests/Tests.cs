using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Diagnostics;
using TestContext = Microsoft.VisualStudio.TestTools.UnitTesting.TestContext;

[assembly: Parallelize(Workers = 3, Scope = ExecutionScope.MethodLevel)]

namespace Saucedemo.Tests
{
    [TestClass]
    public class Tests : BaseTest
    {
        private static long DEFAULT_TIMEOUT = 20;

        private TestContext testContext;
        public TestContext TestContext
        {
            get { return testContext; }
            set { testContext = value; }
        }
        private void Log(string message)
        {
            string testName = TestContext.TestName;
            string className = TestContext.FullyQualifiedTestClassName;
            string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {className}.{testName}: {message}";
            Trace.WriteLine(logMessage);
        }

        [DataTestMethod]
        [DataRow("eeeee", "tttttt", "Username is required")]

        public void TestLoginFormWithEmptyCredentials(string user_name, string password, string error_text)
        {
            Log("Starting TestLoginFormWithEmptyCredentials");
            getHomePage().WaitClickabilityOfElement(DEFAULT_TIMEOUT, getHomePage().GetUserNameField());
            getHomePage().InputUserName(user_name);
            getHomePage().WaitClickabilityOfElement(DEFAULT_TIMEOUT, getHomePage().GetPasswordField());
            getHomePage().InputPassword(password);
            getHomePage().GetUserNameField().SendKeys(Keys.Control + "A");
            getHomePage().GetUserNameField().SendKeys(Keys.Backspace);
            getHomePage().GetPasswordField().SendKeys(Keys.Control + "A");
            getHomePage().GetPasswordField().SendKeys(Keys.Backspace);
            getHomePage().WaitClickabilityOfElement(DEFAULT_TIMEOUT, getHomePage().GetLoginBotton());
            getHomePage().ClickLoginBotton();
            getHomePage().WaitClickabilityOfElement(DEFAULT_TIMEOUT, getHomePage().GetError());
            Assert.IsTrue(getHomePage().GetError().Text.Contains(error_text));
            Log("TestLoginFormWithEmptyCredentials passed successfully");
        }

        [DataTestMethod]
        [DataRow("ddddd", "lllll", "Password is required")]

        public void TestLoginFormWithCredentialsByPassingUsername(string user_name, string password, string error_text)
        {
            Log("Starting TestLoginFormWithCredentialsByPassingUsername");
            getHomePage().WaitClickabilityOfElement(DEFAULT_TIMEOUT, getHomePage().GetUserNameField());
            getHomePage().InputUserName(user_name);
            getHomePage().WaitClickabilityOfElement(DEFAULT_TIMEOUT, getHomePage().GetPasswordField());
            getHomePage().InputPassword(password);
            getHomePage().GetPasswordField().SendKeys(Keys.Control + "A");
            getHomePage().GetPasswordField().SendKeys(Keys.Backspace);
            getHomePage().WaitClickabilityOfElement(DEFAULT_TIMEOUT, getHomePage().GetLoginBotton());
            getHomePage().ClickLoginBotton();
            getHomePage().WaitClickabilityOfElement(DEFAULT_TIMEOUT, getHomePage().GetError());
            Assert.IsTrue(getHomePage().GetError().Text.Contains(error_text));
            Log("TestLoginFormWithCredentialsByPassingUsername passed successfully");
        }

        [DataTestMethod]
        [DataRow("standard_user", "secret_sauce", "Swag Labs")]

        public void TestLoginFormWithCredentialsByPassingUsernameAndPassword(string user_name, string password, string header)
        {
            Log("Starting TestLoginFormWithCredentialsByPassingUsernameAndPassword");
            getHomePage().WaitClickabilityOfElement(DEFAULT_TIMEOUT, getHomePage().GetUserNameField());
            getHomePage().InputUserName(user_name);
            getHomePage().WaitClickabilityOfElement(DEFAULT_TIMEOUT, getHomePage().GetPasswordField());
            getHomePage().InputPassword(password);
            getHomePage().WaitClickabilityOfElement(DEFAULT_TIMEOUT, getHomePage().GetLoginBotton());
            getHomePage().ClickLoginBotton();
            getInventoryPage().WaitClickabilityOfElement(DEFAULT_TIMEOUT, getInventoryPage().GetHeader());
            Assert.IsTrue(getInventoryPage().GetHeader().Text.Equals(header));
            Log("TestLoginFormWithCredentialsByPassingUsernameAndPassword passed successfully");
        }
    }
}
