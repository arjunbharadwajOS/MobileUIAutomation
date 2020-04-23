using Facebook.Mobile.Test.Main;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Facebook.Mobile.Test.Pages;
using Facebook.Mobile.Test.Settings;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.PageObjects;
using Facebook.Mobile.Test.Data;

namespace Facebook.UIAutomation.Test.Tests
{
    [TestClass]
    public class FBLoginTest : BaseTest
    {
        public FBLoginTest()
        {

        }
        public FBLoginTest(TestContext test, AppiumDriver<RemoteWebElement> Driver)
        {
            base.TestContext = test;
            base.CreateDriver(Driver);
        }

        [TestMethod]
        [TestCategory("FB")]
        public void LoginMethod()
        {
            
            LoginPage lPage = new LoginPage();
            GenericPage gPage = new GenericPage();
            PageFactory.InitElements(Driver, lPage);
            PageFactory.InitElements(Driver, gPage);
            MobileGeneric mobileGeneric = new MobileGeneric();
            lPage.clearUserName();
            lPage.enterUserName(testdata.email.ToString());
            lPage.enterPassword(testdata.password.ToString());
            mobileGeneric.HideDeviceKeyboard();
            lPage.clickLoginBtn();
            mobileGeneric.StaticWait(5);

        }


               

    }
}

