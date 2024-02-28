
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using W3SchoolSpecflowProject.POM;

namespace W3SchoolSpecflowProject.Steps
{
    [Binding]
    public class W3SchoolsStepsDefinitions
    {
        private IWebDriver driver;
        RegistrationPage registrationPage;
        LoginPage loginPage;
        private readonly ScenarioContext _scenarioContext;

        public W3SchoolsStepsDefinitions(ScenarioContext scenarioContext, IWebDriver _driver,RegistrationPage _registrationPage,LoginPage _loginPage)
        {
            _scenarioContext = scenarioContext;
            //driver = new ChromeDriver();
            this.registrationPage = _registrationPage;
            this.loginPage = _loginPage;
            this.driver = _driver;
            //scenarioContext.Set<bool>(false, "Screenshot");
            _scenarioContext.Set<bool>(true, "Screenshot");

        }

        [Given(@"I have an empty shopping cart")]
        public void GivenIHaveAnEmptyShoppingCart()
        {
            //ScenarioContext.Current.Pending();
        }


        [Given(@"a user is on the registration page\.")]
        public void GivenAUserIsOnTheRegistrationPage_()
        {
            
            //ScenarioContext.Current.Pending();
            registrationPage.NavigateToRegistrationPage();
            //_scenarioContext.Set<bool>(false, "Screenshot");
        }

        [When(@"the user enters valid registration details with Username as ""(.*)"" and Password as ""(.*)""")]
        public void WhenTheUserEntersValidRegistrationDetailsWithUsernameAsAndPasswordAs(string Usermail, string Pwd)
        {
            registrationPage.EnterRegistrationDetails(email:Usermail,password:Pwd);
            registrationPage.SubmitRegistrationForm();
        }

        [When(@"Enter details with FistName as ""(.*)"" and LastName as ""(.*)""")]
        public void WhenEnterDetailsWithFistNameAsAndLastNameAs(string fistName, string lastName)
        {
            
            registrationPage.EnterFirstLastnameAndContiue(fistName, lastName);
        }


        [Then(@"a new user account should be created successfully\.")]
        public void ThenANewUserAccountShouldBeCreatedSuccessfully_()
        {
            registrationPage.SuccessMsgDisplay();
        }

        [When(@"the user tries to register with the existing userid with Username as ""(.*)"" and Password as ""(.*)""")]
        public void WhenTheUserTriesToRegisterWithTheExistingUseridWithUsernameAsAndPasswordAs(string Usermail, string Pwd)
        {
            registrationPage.EnterRegistrationDetails(email: Usermail, password: Pwd);
            registrationPage.SubmitRegistrationForm();
            _scenarioContext.Set<bool>(true, "Screenshot");
            
        }


        [Then(@"an error message should be displayed, and the registration should not proceed with ErrorMessage as ""(.*)""")]
        public void ThenAnErrorMessageShouldBeDisplayedAndTheRegistrationShouldNotProceedWithErrorMessageAs(string ErrorMsg)
        {

            registrationPage.DisplayDuplicationUserErrorMsg(ErrorMsg);
            _scenarioContext.Set<bool>(false, "Screenshot");
        }

        [When(@"the user submits the registration form with missing required fields")]
        public void WhenTheUserSubmitsTheRegistrationFormWithMissingRequiredFields()
        {
            registrationPage.SubmitRegistrationForm();
            _scenarioContext.Set<bool>(true, "Screenshot");

        }



        [Then(@"appropriate error messages should be displayed, and the registration should not proceed with ErrorMessage as ""(.*)""")]
        public void ThenAppropriateErrorMessagesShouldBeDisplayedAndTheRegistrationShouldNotProceedWithErrorMessageAs(string errorMsg)
        {
            registrationPage.EmailValidationMsg(errorMsg);
            _scenarioContext.Set<bool>(false, "Screenshot");

        }


        [Given(@"a user navigates to the login page\.")]
        public void GivenAUserNavigatesToTheLoginPage_()
        {
            loginPage.NavigateToLoginPage();

        }

        [When(@"the user enters invalid or valid credentials with Email as ""(.*)"" and Password ""(.*)""")]
        public void WhenTheUserEntersInvalidOrValidCredentialsWithEmailAsAndPassword(string email, string password)
        {
            loginPage.EnterLoginDetails(email, password);
            loginPage.ClickLoginButton();
            _scenarioContext.Set<bool>(true, "Screenshot");


        }

        [Then(@"an error message should be displayed, and the user should not be logged in with ErrorMessage as ""(.*)""")]
        public void ThenAnErrorMessageShouldBeDisplayedAndTheUserShouldNotBeLoggedInWithErrorMessageAs(string errorMsg)
        {
            loginPage.DisplayInvalidUserErrorMsg(errorMsg);
            _scenarioContext.Set<bool>(false, "Screenshot");

        }


    }
}
