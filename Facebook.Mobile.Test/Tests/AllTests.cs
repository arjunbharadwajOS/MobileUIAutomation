using BWS.UIAutomation.Test;
using EDG.UIAutomation.Test.Tests;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace EDG.UIAutomation.Test.Pages
{
    public class AllTests
    {
       
               
        public BrowseTests BrowseTests { get; private set; }

        public OnboardTests OnboardTests { get; private set; }

        public SetStoreTests SetStoreTests { get; private set; }

       

        public AllTests() 
        {
            BrowseTests = new BrowseTests();
            OnboardTests = new OnboardTests();
            SetStoreTests = new SetStoreTests();
        }

    }
}