using OpenQA.Selenium;
using System;

namespace Facebook.Mobile.Test.Utility
{
    public class WebElement
    {
        public bool IsDisplayed(IWebElement element)
        {
            try
            {
                if (element.Displayed)
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        public IWebElement GetButtonWithText(IWebDriver driver, string buttonLable, int occurenceCount)
        {
            var ele = driver.FindElements(By.CssSelector("button"));

            int counter = 0;
            foreach (IWebElement btn in ele)
            {
                if (btn.Text.ToString().ToLower().Equals(buttonLable.ToLower()))
                {
                    counter++;
                }
                if (counter == occurenceCount)
                {
                    return btn;
                }
            }

            if (occurenceCount < 1)
            {
                throw new Exception("Invalid button searched");
            }
            return null;
        }

        public void ScrollToElement(IWebDriver Driver, IWebElement element)
        {
            try
            {
                IJavaScriptExecutor js = ((IJavaScriptExecutor)Driver);
                js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Error while scrolling the page:" + e.ToString());
            }
        }
    }
}
