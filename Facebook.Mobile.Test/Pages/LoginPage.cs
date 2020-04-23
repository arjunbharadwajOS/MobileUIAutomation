using Facebook.Mobile.Test.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.PageObjects;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using Facebook.Mobile.Test.Main;
using OpenQA.Selenium.Remote;
using System.Resources;
using System.Reflection;
using System.Globalization;
using Facebook.Mobile.Test;
using PageFactory = OpenQA.Selenium.Support.PageObjects.PageFactory;

namespace Facebook.Mobile.Test.Pages
{
    public class LoginPage : BaseTest
    {
        public MobileGeneric mobileGeneric = null;

        public LocatorHelper locatorHelper { get; private set; }

        public LoginPage() 
        {
            mobileGeneric = new MobileGeneric();
            locatorHelper = new LocatorHelper(Driver, Config.OperatingSystem.ToLower());
            PageFactory.InitElements(Driver, this);
        }

        [mobile("android", findBy.Id, "com.facebook.katana:id/login_username")]
        [mobile("ios", findBy.XPath, "")]
        public string userNameText { get; set; }

        [mobile("android", findBy.Id, "com.facebook.katana:id/login_password")]
        [mobile("ios", findBy.XPath, "")]
        public string passwordText { get; set; }

        [mobile("android", findBy.Id, "com.facebook.katana:id/login_login")]
        [mobile("ios", findBy.XPath, "")]
        public string loginButton { get; set; }

        protected IWebElement userNameEdit
        {
            get { return locatorHelper.GetElement(this, "userNameText"); }
        }

        protected IWebElement passwordEdit
        {
            get { return locatorHelper.GetElement(this, "passwordText"); }
        }

        protected IWebElement loginBtn
        {
            get { return locatorHelper.GetElement(this, "loginButton"); }
        }

        public void enterUserName(string userName)
        {
            mobileGeneric.DynamicWait(userNameEdit);
            userNameEdit.SendKeys(userName);
        }

        public void clearUserName()
        {
            mobileGeneric.DynamicWait(userNameEdit);
            userNameEdit.Clear();
        }

        public void enterPassword(string password)
        {
            mobileGeneric.DynamicWait(passwordEdit);
            passwordEdit.SendKeys(password);
        }

        public void clickLoginBtn()
        {
            mobileGeneric.DynamicWait(loginBtn);
            loginBtn.Click();
        }

    }
}