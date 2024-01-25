using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace W3SchoolSpecflowProject.ExtentReport
{
    public class ExtentHtmlReport
    {
        public static ExtentReports _extentReports;
        public static ExtentTest _feature;
        public static ExtentTest _scenario;

        public static string dir = AppDomain.CurrentDomain.BaseDirectory;


        public static string testResultPath = dir.Replace(@"bin\Debug\net5.0", "TestResults");


        public static void ExtentHtmlReportInIt()
        {
            var htmlReporter = new ExtentHtmlReporter(testResultPath);
            htmlReporter.Config.ReportName = "Automation Report";
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            htmlReporter.Config.DocumentTitle = "Automation Report Title";
            htmlReporter.Start();


            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(htmlReporter);
            _extentReports.AddSystemInfo("Browser", "Chrome");


        }

        public string addScreenShot(IWebDriver driver, ScenarioContext scenarioContext)
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            string screenshotLocation = Path.Combine(testResultPath, scenarioContext.ScenarioInfo.Title + ".png");
            screenshot.SaveAsFile(screenshotLocation, ScreenshotImageFormat.Png);
            return screenshotLocation;
        }

        public string addScreenShot(IWebDriver driver, ScenarioContext scenarioContext, string stepName)
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            string screenshotLocation = Path.Combine(testResultPath, scenarioContext.ScenarioInfo.Title + stepName.Substring(0,10) + ".png");
            screenshot.SaveAsFile(screenshotLocation, ScreenshotImageFormat.Png);
            return screenshotLocation;
        }

        public static void ExtentReportTearDown()
        {
            _extentReports.Flush();
        }

    }
}
