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
    public class RegistrationPage
    {
        private  IWebDriver driver;

        public IWebDriver Driver { get => driver; set => driver = value; }
        // Page URL for the registration page
        private const string RegistrationPageUrl = "https://www.w3schools.com/signup/index.php";
        [FindsBy(How = How.XPath, Using = "//*[@class='EmailInput_input_field__6t4Ux undefined'  and @id='modalusername']")]
        private IWebElement UserName_TextBox;
        private string UserName = "//*[@class='EmailInput_input_field__6t4Ux undefined'  and @id='modalusername']";

        [FindsBy(How = How.XPath, Using = "//*[@class='PasswordInput_input_field__EWMIU undefined' and @type='password']")]
        private IWebElement PassWord_TextBox;
        private string Pwd = "//*[@class='PasswordInput_input_field__EWMIU undefined' and @type='password']";

        [FindsBy(How = How.XPath, Using = "//*[@class='top-section']//*[@id='signUpFromSignup']")]
        private IWebElement PreSignUp_Button;
        private string PreSignUpButton = "//*[@class='top-section']//*[@id='signUpFromSignup']";

        

        [FindsBy(How = How.XPath, Using = "//*[@class='Button_button__URNp+ Button_primary__d2Jt3 Button_fullwidth__0HLEu']")]
        private IWebElement SignUp_Button;
        private string signUpButton = "//*[@class='Button_button__URNp+ Button_primary__d2Jt3 Button_fullwidth__0HLEu']";

        [FindsBy(How = How.XPath, Using = "//*[@class='NameInput_input_field__NiUxT undefined' and @name='first_name']")]
        private IWebElement FirstName_TextBox;
        private string FirstName = "//*[@class='NameInput_input_field__NiUxT undefined' and @name='first_name']";

        [FindsBy(How = How.XPath, Using = "//*[@class='NameInput_input_field__NiUxT undefined' and @name='last_name']")]
        private IWebElement LastName_TextBox;
        private string Lastname = "//*[@class='NameInput_input_field__NiUxT undefined' and @name='last_name']";

        [FindsBy(How = How.XPath, Using = "//*[@class='Button_button__URNp+ Button_primary__d2Jt3 Button_fullwidth__0HLEu']")]
        private IWebElement Conintue_Button;
        private string ConintueButton = "//*[@class='Button_button__URNp+ Button_primary__d2Jt3 Button_fullwidth__0HLEu']";

        [FindsBy(How = How.XPath, Using = "//*[@class='LoginModal_modal_inner__zNxJo LoginModal_pending_verification__XACzH']//h1")]
        private IWebElement SuccessMsg_Text;
        private string SuccessMsg = "//*[@class='LoginModal_modal_inner__zNxJo LoginModal_pending_verification__XACzH']//h1";

        [FindsBy(How = How.XPath, Using = "//*[@class='EmailInput_email_error__IJxXf']")]
        private IWebElement DuplicationUserErrorMsg_Text;
        private string DuplicationUserErrorMsg= "//*[@class='EmailInput_email_error__IJxXf']";

        [FindsBy(How = How.XPath, Using = "//*[@class='EmailInput_email_error__IJxXf']")]        
        private IWebElement EmailErrorMsg_Text;
        private string emailErrorMsg="//*[@class='EmailInput_email_error__IJxXf']";

        // Constructor to initialize the driver
        public RegistrationPage(IWebDriver driver)
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


        public void DisplayDuplicationUserErrorMsg(string ErrorMsg)
        {
            waitForElementtoExist(driver, By.XPath(DuplicationUserErrorMsg), 30);

            waitForElementtoVisible(driver, By.XPath(DuplicationUserErrorMsg), 30);
            //SelectElement select = new SelectElement(Conintue_Button);
            
            //IWebElement errorMsg = driver.FindElement(By.XPath(DuplicationUserErrorMsg));
            DuplicationUserErrorMsg_Text.Text.ToString().Should().Contain(ErrorMsg);// "already have a user");
        }

        // Implement methods to interact with registration page elements
        public void NavigateToRegistrationPage()
        {

            driver.Navigate().GoToUrl("https://mdbootstrap.com/docs/b4/jquery/tables/scroll/");

            var jsToBeExecuted2 = $"window.scroll(0, 3050);";
            Thread.Sleep(2000);
            ((IJavaScriptExecutor)driver).ExecuteScript(jsToBeExecuted2);

            IWebElement tableElement = driver.FindElement(By.XPath("//*[@class='dataTables_scrollBody' and @xpath='1']"));
            // Scroll left by 300 pixels (adjust as needed)
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollLeft += 300;", tableElement);


            // Implementation to navigate to the registration page
            driver.Navigate().GoToUrl(RegistrationPageUrl);
            driver.Manage().Window.Maximize();
            waitForElementtoExist(driver, By.XPath(PreSignUpButton), 30);
            IWebElement _signupButton= driver.FindElement(By.XPath(PreSignUpButton));
            //PreSignUp_Button.Click();
            _signupButton.Click();
            Thread.Sleep(5000);

        }


        public void EnterRegistrationDetails(string password, string email)
        {
            // Implementation to enter registration details
            waitForElementtoExist(driver, By.XPath(UserName), 30);

            waitForElementtoExist(driver, By.XPath(Pwd), 30);

            //IWebElement _username = driver.FindElement(By.XPath(UserName));
            //IWebElement _pwd = driver.FindElement(By.XPath(Pwd));
            UserName_TextBox.SendKeys(email);
            PassWord_TextBox.SendKeys(password);
            //string stt=driver.WindowHandles;
            
        }

        public void SubmitRegistrationForm()
        {
            // Implementation to submit the registration form
            waitForElementtoExist(driver, By.XPath(signUpButton), 30);

            waitForElementClickable(driver, By.XPath(signUpButton), 30);

            //IWebElement signUp_Button = driver.FindElement(By.XPath(signUpButton));
            SignUp_Button.Click();
            Thread.Sleep(5000);
        }
        public void EnterFirstLastnameAndContiue(string first_Name,string last_Name)
        {
            waitForElementtoExist(driver, By.XPath(FirstName), 30);
            waitForElementtoExist(driver, By.XPath(Lastname), 30);
            //IWebElement _lastName = driver.FindElement(By.XPath(Lastname));

            FirstName_TextBox.SendKeys(first_Name);
            LastName_TextBox.SendKeys(last_Name);
            Thread.Sleep(5000);

            waitForElementtoExist(driver, By.XPath(ConintueButton), 30);
            waitForElementClickable(driver, By.XPath(ConintueButton), 30);

            //IWebElement _conintueButton = driver.FindElement(By.XPath(ConintueButton));
            Conintue_Button.Click();
        }

        public void SuccessMsgDisplay()
        {
            waitForElementtoVisible(driver, By.XPath(SuccessMsg), 30);
            //IWebElement _verifyEmailMsg = driver.FindElement(By.XPath(SuccessMsg));

            //User this assertion using FluentAssertion or use taditional assertion using
            // Assert.IsTrue(_verifyEmailMsg.Text.ToString()=="Please verify email")
            SuccessMsg_Text.Text.ToString().Should().Contain("Please verify email");



        }
        public void EmailValidationMsg(string errMsg)
        {
            waitForElementtoVisible(driver, By.XPath(emailErrorMsg), 30);
            //IWebElement _verifyEmailMsg = driver.FindElement(By.XPath(emailErrorMsg));

            //User this assertion using FluentAssertion or use taditional assertion using
            // Assert.IsTrue(_verifyEmailMsg.Text.ToString()=="Please verify email")
            EmailErrorMsg_Text.Text.ToString().Should().Contain(errMsg);



        }

        // Add other methods as needed
    }

}
