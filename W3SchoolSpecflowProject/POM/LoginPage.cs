using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace W3SchoolSpecflowProject.POM
{
    // RegistrationPage.cs
    public class LoginPage
    {
        private  IWebDriver driver;

        public IWebDriver Driver { get => driver; set => driver = value; }
        // Page URL for the registration page
        private const string PageUrl = "https://www.w3schools.com";

        [FindsBy(How = How.XPath, Using = "//*[contains(@class,'login') and @title='Login to your account']")]
        private IWebElement PreLogin_Button;
        private string PreLoginButton = "//*[contains(@class,'login') and @title='Login to your account']";


        [FindsBy(How = How.XPath, Using = "//*[@class='EmailInput_input_field__6t4Ux undefined' and @name='email']")]
        private IWebElement Email_TextBox;
        private string Email = "//*[@class='EmailInput_input_field__6t4Ux undefined' and @name='email'] ";


        [FindsBy(How = How.XPath, Using = "//*[@class='PasswordInput_input_field__EWMIU undefined' and @type='password']")]
        private IWebElement Password_TextBox;
        private string Password = "//*[@class='PasswordInput_input_field__EWMIU undefined' and @type='password']";


        [FindsBy(How = How.XPath, Using = "//*[@class='Button_button__URNp+ Button_primary__d2Jt3 Button_fullwidth__0HLEu']")]
        private IWebElement Login_Button;
        private string LoginButton = "//*[@class='Button_button__URNp+ Button_primary__d2Jt3 Button_fullwidth__0HLEu']";

        [FindsBy(How = How.XPath, Using = "//*[@class='Alert_iwrp__5q1xH Alert_danger__Wsdhv']")]
        private IWebElement InvalidUserErrMsg_Text;
        private string InvalidUserErrMsg = "//*[@class='Alert_iwrp__5q1xH Alert_danger__Wsdhv']";
        // Constructor to initialize the driver
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        
        public void waitForElementtoExist(IWebDriver driver, By by, int timeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
        }

        public void waitForElementtoVisible(IWebDriver driver, By by, int timeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
        }

        public void waitForElementClickable(IWebDriver driver, By by, int timeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }


        public void DisplayInvalidUserErrorMsg(string ErrorMsg)
        {
            waitForElementtoExist(driver, By.XPath(InvalidUserErrMsg), 30);

            waitForElementtoVisible(driver, By.XPath(InvalidUserErrMsg), 30);

            //IWebElement _errorMsg = driver.FindElement(By.XPath(DuplicationUserErrorMsg));
            InvalidUserErrMsg_Text.Text.ToString().Should().Contain(ErrorMsg);// "already have a user");
        }

        // Implement methods to interact with registration page elements
        public void NavigateToLoginPage()
        {
            // Implementation to navigate to the registration page
            driver.Navigate().GoToUrl(PageUrl);
            driver.Manage().Window.Maximize();
            waitForElementtoExist(driver, By.XPath(PreLoginButton), 30);
            waitForElementClickable(driver, By.XPath(PreLoginButton), 30);
            PreLogin_Button.Click();
            Thread.Sleep(5000);

        }


        public void EnterLoginDetails(string email, string password)
        {
            // Implementation to enter registration details
            waitForElementtoExist(driver, By.XPath(Email), 30);

            waitForElementtoExist(driver, By.XPath(Password), 30);
            Email_TextBox.SendKeys(email);
            Password_TextBox.SendKeys(password);

            
        }

        public void ClickLoginButton()
        {
            // Implementation to submit the registration form
            waitForElementtoExist(driver, By.XPath(LoginButton), 30);

            waitForElementClickable(driver, By.XPath(LoginButton), 30);
            Login_Button.Click();
            Thread.Sleep(5000);
        }

        // Add other methods as needed
    }

}
