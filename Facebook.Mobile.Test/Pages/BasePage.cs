using Facebook.Mobile.Test.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.PageObjects;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using Facebook.Mobile.Test.Main;
using System.Reflection;
using OpenQA.Selenium.Remote;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Facebook.Mobile.Test.Pages
{
    public class BasePage
    {
        //private AppiumDriver<RemoteWebElement> driver;

        //protected AppiumDriver<RemoteWebElement> Driver { get; set; }
        //protected WebDriverWait wait { get; set; }


        

        //public BasePage(AppiumDriver<RemoteWebElement> driver)
        //{
        //    var factory = new DriverFactory();
        //    if (driver == null)
        //    {
        //        driver = factory.GetDriver("Base");
        //    }
        //    Driver = driver;
        //    wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(40));
        //    BaseTest bTest = new BaseTest();
        //    locatorHelper = new LocatorHelper(driver, Config.OperatingSystem.ToLower());
        //    PageFactory.InitElements(Driver, this);

        //}


        //public void pageUp()
        //{
        //    IJavaScriptExecutor js = ((IJavaScriptExecutor)Driver);
        //    js.ExecuteScript("window.scrollTo(0, -document.body.scrollHeight);");
        //}

        //public void pageDown()
        //{
        //    IJavaScriptExecutor js = ((IJavaScriptExecutor)Driver);
        //    js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
        //}
        //public void pageDown_Test()
        //{
        //    IJavaScriptExecutor js = ((IJavaScriptExecutor)Driver);
        //    js.ExecuteScript("window.scrollTo(0, 250);");
        //}

        //public void scrollIntoElementView(IWebElement element)
        //{
        //    ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        //}
    }
}
