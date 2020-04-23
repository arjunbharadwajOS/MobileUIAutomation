
using Facebook.Mobile.Test.ApplicationData;
using Facebook.Mobile.Test.Comparers;
using Facebook.Mobile.Test.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium.Remote;


namespace Facebook.Mobile.Test.Main
{
    [TestClass]
    public class BaseTest
    {
        public TestContext TestContext { get; set; }
        protected Wait Wait { get; private set; }
        protected static AppiumDriver<RemoteWebElement> Driver { get; private set; }
        protected ConstantData Constants { get; private set; }
        protected CheckIt Check { get; private set; }
               
        private List<string> GetProperties(string value)
        {
            return TestContext.Properties
        .Cast<KeyValuePair<string, object>>()
        .Where(_ => _.Key.Equals(value))
        .Select(_ => _.Value as string)
        .ToList();
        }

        public virtual void CreateDriver(AppiumDriver<RemoteWebElement> MyDriver = null)
        {
            Constants = new ConstantData();
            var factory = new DriverFactory();
            Driver = MyDriver;

            if (Driver == null)
            {
                Driver = factory.GetDriver(TestContext.TestName);
            }

            Check = new CheckIt(Driver, TestContext.TestName);
            Wait = new Wait();

        }

        [TestInitialize]
        public virtual void CreateDriver()
        {
            CreateDriver(null);
        }


        [TestCleanup]
        public void TearDown()
        {
            Driver.Quit();
            Driver.Dispose();
            Driver = null;
        }

        private void TestOutput()
        {
            if (Check != null)
            {
                var assertLog = String.Join("\r\n", Check.AssertResults.Select(r =>
                {
                    var stringBuild = new System.Text.StringBuilder();
                    stringBuild.Append($"{r.Message} - additionalInfo: {r.ComparisonTypeAndValues}");

                    if (!string.IsNullOrEmpty(r.screenShotName))
                        stringBuild.Append($" - <a class=\"failedlink\" target=\"_blank\" href=\"{r.screenShotName}\">View ScreenShot</a>");
                    return stringBuild.ToString();
                })

            );

                if (Check.AssertResults.Any(r => r.Outcome == AssertOutcome.Fail))
                {
                    Check.AssertFail(assertLog);
                }
                else if (Check.AssertResults.Any(r => r.Outcome == AssertOutcome.Warning))
                {
                    Check.AssertWarning(assertLog);
                }
            }
        }
    }
}
