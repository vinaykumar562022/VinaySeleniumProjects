using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.MarkupUtils;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
//using SeleniumProject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using TechTalk.SpecFlow;
using W3SchoolSpecflowProject.ExtentReport;
using W3SchoolSpecflowProject.POM;

namespace W3SchoolSpecflowProject.Hooks
{
    [Binding]
    public sealed class Hooks1 : ExtentHtmlReport
    {
        private readonly IObjectContainer _objectContainer;
        private RegistrationPage RegistrationPage;

        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        public Hooks1(IObjectContainer objectContainer)
        {
            this._objectContainer = objectContainer;
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            Console.WriteLine("Before Feature");
            _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("BeforeTestRun");
            ExtentHtmlReportInIt();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Console.WriteLine("AfterTestRun");
            ExtentReportTearDown();
        }


        [AfterFeature]
        public static void AfterFeature()
        {
            Console.WriteLine("after Feature");
        }
        [BeforeScenario]
        public void BeforeScedrivernario(ScenarioContext scenarioContext)
        {
            //TODO: implement logic that has to run before executing each scenario
            RegistrationPage = new RegistrationPage(new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)));

            _objectContainer.RegisterInstanceAs<IWebDriver>(RegistrationPage.Driver);
            _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            Console.WriteLine("Running after step.....");
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;

            IWebDriver driver = _objectContainer.Resolve<IWebDriver>();



            //when scenario passed
            if (scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                {
                    if (scenarioContext.Get<bool>("Screenshot"))
                        _scenario.CreateNode<Given>(stepName).Pass("Given", MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenShot(driver, scenarioContext, stepName)).Build());
                    else
                        _scenario.CreateNode<Given>(stepName).Info("hi this is vinay");

                }
                if (stepType == "When")
                {
                    if (scenarioContext.Get<bool>("Screenshot"))
                        _scenario.CreateNode<When>(stepName).Pass("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenShot(driver, scenarioContext, stepName)).Build());
                    else
                        _scenario.CreateNode<When>(stepName);
                }
                if (stepType == "Then")
                {
                    if (scenarioContext.Get<bool>("Screenshot"))
                        _scenario.CreateNode<Then>(stepName).Pass("Then", MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenShot(driver, scenarioContext, stepName)).Build());
                    else
                        _scenario.CreateNode<Then>(stepName);
                }
                if (stepType == "And")
                {
                    if (scenarioContext.Get<bool>("Screenshot"))
                        _scenario.CreateNode<And>(stepName).Pass("And", MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenShot(driver, scenarioContext, stepName)).Build());
                    else
                        _scenario.CreateNode<And>(stepName);
                }
            }

            //when scenario fail
            if (scenarioContext.TestError != null)
            {
                if (stepType == "Given")
                {
                    _scenario.Log(AventStack.ExtentReports.Status.Fail, MarkupHelper.CreateLabel(scenarioContext.TestError.Message, ExtentColor.Red));

                    _scenario.CreateNode<Given>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenShot(driver, scenarioContext)).Build());


                }
                if (stepType == "When")
                {
                    _scenario.Log(AventStack.ExtentReports.Status.Fail, MarkupHelper.CreateLabel(scenarioContext.TestError.Message, ExtentColor.Red));


                    _scenario.CreateNode<When>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenShot(driver, scenarioContext)).Build());

                }
                if (stepType == "Then")
                {
                    _scenario.Log(AventStack.ExtentReports.Status.Fail, MarkupHelper.CreateLabel(scenarioContext.TestError.Message, ExtentColor.Red));

                    _scenario.CreateNode<Then>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenShot(driver, scenarioContext)).Build());

                }
                if (stepType == "And")
                {
                    _scenario.Log(AventStack.ExtentReports.Status.Fail, MarkupHelper.CreateLabel(scenarioContext.TestError.Message, ExtentColor.Red));

                    _scenario.CreateNode<And>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenShot(driver, scenarioContext)).Build());

                }
            }

        }

        [AfterScenario]
        public void AfterScenario()
        {
            var driver = _objectContainer.Resolve<IWebDriver>();
            if (driver != null)
            {
                driver.Quit();
            }
            //TODO: implement logic that has to run after executing each scenario
        }
    }
}
