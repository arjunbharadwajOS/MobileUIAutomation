using OpenQA.Selenium;
using System;

namespace Facebook.Mobile.Test.Utility
{
    public class Retry
    {
        public void RetryTypingAttemptIfFail(IWebElement element, string value)
        {
            Wait Wait = new Wait();
            int counter = 1;
            bool isSuccessfullyDone = false;
            do
            {
                try
                {
                    element.Clear();
                    element.SendKeys(value);
                    isSuccessfullyDone = true;
                }
                catch (Exception)
                {
                    counter++;
                    Wait.WaitFor(2);
                }
            } while (counter < 30 && !isSuccessfullyDone);
        }

        public void RetryToClickIfFails(IWebElement element, int timespanInSeconds = 10, IWebDriver Driver = null)
        {
            WebElement WebElement = new WebElement();
            Wait Wait = new Wait();
            int count = 0;
            bool isClicked = false;
            do
            {
                try
                {
                    if (Driver != null && WebElement.IsDisplayed(element))
                    {
                        WebElement.ScrollToElement(Driver, element);
                    }
                    Wait.WaitFor(5);
                    element.Click();
                    isClicked = true;
                    count++;
                    return;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    count++;
                }

            } while (count < timespanInSeconds);
            if (!isClicked)
            {
                throw new Exception("Failed to click on Element " + element);
            }
        }

        public void PageDownAndRetryClick(IWebDriver Driver, IWebElement elemenetToBeClicked)
        {
            WebElement WebElement = new WebElement();
            Wait Wait = new Wait();
            try
            {
                WebElement.ScrollToElement(Driver, elemenetToBeClicked);
                elemenetToBeClicked.Click();
            }
            catch (Exception)
            {
                int counter = 1;

                do
                {
                    IJavaScriptExecutor js = ((IJavaScriptExecutor)Driver);
                    js.ExecuteScript("window.scrollTo(0, -document.body.scrollHeight);");
                    for (int i = 1; i <= counter; i++)
                    {
                        if (i != 1)
                        {
                            js.ExecuteScript("javascript:window.scrollBy(0, 500)");
                            Wait.WaitFor(1);
                        }
                        try
                        {
                            elemenetToBeClicked.Click();
                            return;
                        }
                        catch (Exception)
                        {
                            Wait.WaitFor(1);
                        }
                    }
                    counter++;

                } while (counter < 15);
            }
        }
    }
}