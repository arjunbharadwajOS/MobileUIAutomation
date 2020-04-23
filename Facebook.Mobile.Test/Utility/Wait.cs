using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Facebook.Mobile.Test.Utility
{
    public class Wait
    {
        public void WaitForElementToDisplay(IWebElement element, int waitTime = 30)
        {
            WaitFor(() => element.Displayed, waitTime);
        }
        public void WaitForElementToDisappear(IWebElement element, int waitTime = 30)
        {
            WaitFor(() => !element.Displayed, waitTime);
        }
        public void WaitForElementTextToDisplay(IWebElement element, string eleText, int waitTime = 30)
        {
            WaitFor(() => element.Text.ToLower().Equals(eleText.ToLower()), waitTime);
        }

        public void WaitForElementToEnable(IWebElement element, int waitTime = 20)
        {
            WaitFor(() => element.Enabled, waitTime);
        }

        public void WaitForListToPopulate(IReadOnlyList<IWebElement> elements, int count = 0, int waitTime = 30)
        {
            WaitFor(() => elements.Count > count, waitTime);
        }

        public void WaitFor(int durationInSec)
        {
            durationInSec = durationInSec * 1000;
            Thread.Sleep(durationInSec);
        }

        public void WaitTime(IWebElement element)
        {

            for (int counter = 0; counter < 10; counter++)
            {
                try
                {
                    if (element.Displayed)
                    {
                        break;
                    }
                    
                }
                catch (Exception ex){
                    WaitFor(3);
                }
            }
        
        }

        private void WaitFor(Func<bool> condition, int waitTime = 30)
        {
            int i = 1;
            do
            {
                try
                {
                    if (condition())
                        return;
                    else
                        WaitFor(1);
                    i++;
                }
                catch (Exception)
                {
                    WaitFor(1);
                    i++;
                }

            } while (i < waitTime);
        }
    }
}
