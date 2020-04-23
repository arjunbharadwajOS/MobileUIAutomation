using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;

namespace Facebook.Mobile.Test.Comparers
{
    public class CheckIt
    {
        private IWebDriver Driver;
        private string testNameVal;
        private int i;

        public List<AssertResult> AssertResults { get; private set; }

        public CheckIt(IWebDriver driver, string testName)
        {
            Driver = driver;
            i = 0;
            testNameVal = testName;
            AssertResults = new List<AssertResult>();
        }

        public void ElementIsDisplayed(Boolean displayStatus, String failureMessage)
        {
            if (displayStatus)
            {
                AddAssertResult(AssertOutcome.Success, failureMessage);
            }
            else
            {
                AddAssertResult(AssertOutcome.Fail, failureMessage);
            }
        }

        public void AddAssertTestFailure(String failureMessage)
        {
            AddAssertResult(AssertOutcome.Fail, failureMessage);
        }

        public void compareListofStrings(List<String> actualVal, List<String> exepectedVal, string failureMessage)
        {
            bool comparisonResult = false;
            if (actualVal.Equals(exepectedVal))
            {
                comparisonResult = true;
            }
            else
            {
                comparisonResult = false;
            }
            var additionalInfo = "Comparing " + "Actual Value - " + actualVal + " -  With -  " + "Expected Value -" + exepectedVal;
            if (comparisonResult)
            {
                AddAssertResult(AssertOutcome.Success, "Verification", additionalInfo);
            }
            else
            {
                AddAssertResult(AssertOutcome.Fail, failureMessage, additionalInfo);
            }
        }
       
        public void compareString(string actualVal, string expectedVal, string fieldName, string failureMessage, ComparisonType comType = ComparisonType.EXACT, int threshhold = 100)
        {
            bool comparisonResult = false;
            switch (comType)
            {
                case ComparisonType.EXACT:
                    comparisonResult = actualVal.Trim().Equals(expectedVal);
                    break;
                case ComparisonType.STARTSWITH:
                    comparisonResult = actualVal.Trim().StartsWith(expectedVal);
                    break;
                case ComparisonType.CONTAINS:
                    comparisonResult = actualVal.Trim().Contains(expectedVal);
                    break;
                case ComparisonType.EXACT_IGNORECASE:
                    comparisonResult = actualVal.Trim().ToLower().Equals(expectedVal.ToLower());
                    break;
                case ComparisonType.CONTAINS_IGNORECASE:
                    comparisonResult = actualVal.Trim().ToLower().Contains(expectedVal.ToLower());
                    break;
                case ComparisonType.WITH_THRESHHOLD:
                    int thLength = 0;
                    int thLength2 = 0;
                    thLength = (int)Math.Round(((double)actualVal.Length * (threshhold / 100)));
                    thLength2 = (int)Math.Round(((double)expectedVal.Length * (threshhold / 100)));
                    int len = thLength > thLength2 ? thLength2 : thLength;
                    comparisonResult = actualVal.Substring(0, len).Equals(expectedVal.Substring(0, len));
                    break;
                default:
                    break;
            }
            var additionalInfo = "Comparing " + "Actual Value - \"" + actualVal + "\" -  With " + "Expected Value - \"" + expectedVal + "\" For Element - " + fieldName;
            if (comparisonResult)
            {
                AddAssertResult(AssertOutcome.Success, "Verification", additionalInfo);
            }
            else
            {
                AddAssertResult(AssertOutcome.Fail, failureMessage, additionalInfo);
            }
        }

        public void isNotNull(String text, string failureMessage)
        {
            if (String.IsNullOrEmpty(text))
            {
                AddAssertResult(AssertOutcome.Fail, failureMessage);
            }
            else
            {
                AddAssertResult(AssertOutcome.Success, failureMessage);
            }
        }

        public void AreEqual<T>(T expected, T actual, string failureMessage = null)
        {
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (AssertFailedException)
            {
                var areEqualFailedMessage = $"Variables are not equal. Expected '{expected}' but found {actual}";
                AddAssertResult(AssertOutcome.Fail, String.IsNullOrEmpty(failureMessage) ? areEqualFailedMessage : failureMessage);
            }
        }

        private void AddAssertResult(AssertOutcome outcome, string message, string additionalInfo = null)
        {
            string state = string.Empty;
            switch (outcome)
            {
                case AssertOutcome.Fail:
                    state = "FAILED: ";
                    break;
                case AssertOutcome.Success:
                    state = "SUCCESS: ";
                    break;
                case AssertOutcome.Warning:
                    state = "WARNING: ";
                    break;
            }
            AssertResults.Add(new AssertResult()
            {
                Outcome = outcome,
                Message = state + message,
               // screenShotName = takeScreenshot(state),
                ComparisonTypeAndValues = additionalInfo == null ? string.Empty : additionalInfo
            });
        }

        public void AssertFail(string failureMsg)
        {
            Assert.Fail(failureMsg);
        }
        public void AssertWarning(string warningMsg)
        {
            Assert.Inconclusive(warningMsg);
        }

        private string takeScreenshot(string state)
        {
            string file = "";
            string testNameValTemp = "";
            if (state.Equals("FAILED: "))
            {
                string dir = Directory.GetCurrentDirectory();
                Directory.CreateDirectory("Screenshots");
                testNameValTemp = testNameVal + "_" + i + ".jpg";
                file = "Screenshots\\" + testNameValTemp;
                ((ITakesScreenshot)Driver).GetScreenshot().SaveAsFile(file, ScreenshotImageFormat.Jpeg);
                i++;
            }
            return testNameValTemp;
        }
    }

    public class AssertResult
    {
        public string ComparisonTypeAndValues;
        public AssertOutcome Outcome;
        public string Message;
        ////Added by For Screenshot
        public string screenShotName;
    }

    public enum AssertOutcome
    {
        Success,
        Warning,
        Fail
    }

    public enum ComparisonType
    {
        EXACT,
        CONTAINS,
        EXACT_IGNORECASE,
        CONTAINS_IGNORECASE,
        WITH_THRESHHOLD,
        STARTSWITH
    }
}
