
using Facebook.Mobile.Test.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.PageObjects;
using OpenQA.Selenium.Appium.PageObjects.Attributes;
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
    public class GenericPage : BaseTest
    {
        public MobileGeneric mobileGeneric = null;
        public LocatorHelper locatorHelper { get; private set; }

        public GenericPage()
        {
            mobileGeneric = new MobileGeneric();
            locatorHelper = new LocatorHelper(Driver, Config.OperatingSystem.ToLower());
            PageFactory.InitElements(Driver, this);
        }
        
        [mobile("android", findBy.Id, "com.android.packageinstaller:id/permission_deny_button")]
        [mobile("ios", findBy.XPath, "")]
        public string permissionDenyButton { get; set; }
              
        protected IWebElement permissionDenyElement
        {
            get { return locatorHelper.GetElement(this, "permissionDenyButton"); }
        }

        public void clickPermissionDenyButton()
        {
            mobileGeneric.DynamicWait(permissionDenyElement);
            permissionDenyElement.Click();
        }

    }
}