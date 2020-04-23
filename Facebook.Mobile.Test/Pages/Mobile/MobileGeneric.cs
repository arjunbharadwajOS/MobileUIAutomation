
using Facebook.Mobile.Test.Main;
using Facebook.Mobile.Test.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Facebook.Mobile.Test.Pages
{
    public class MobileGeneric : BaseTest
    { 
        public MobileGeneric() 
        {
           
        }

        public LocatorHelper locatorHelper { get; private set; }

        public void SwipeDriver()
        {
            var size = Driver.Manage().Window.Size;
            int starty = (int)(size.Height * 0.80);
            int endy = (int)(size.Height * 0.20);
            int startx = size.Width / 2;
            Driver.Swipe(startx, starty, startx, endy, 3000);
        }

        public void HideDeviceKeyboard()
        {
            Driver.HideKeyboard();
        }

        public void ResetMobileApp()
        {
            Driver.ResetApp();
        }

        public void StaticWait(int sec)
        {
            System.Threading.Thread.Sleep(sec*1000);
        }

        public void DynamicWait(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(1));
            for (int i = 0; i<=10 ; i++) {
                try
                {
                    if (i<10 && element.Displayed)
                    {
                        break;
                    }

                    if (i == 10)
                    {
                        throw new NoSuchElementException();
                    }
                                      
                }
                catch (Exception)
                {
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }

    }
}