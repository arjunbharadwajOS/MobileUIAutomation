using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Remote;
using System;
using System.IO;

namespace Facebook.Mobile.Test.Main
{
    public class DriverFactory
    {

       static int counter = 1;

        public AppiumDriver<RemoteWebElement> GetDriver(string testName)
        {
            AppiumDriver<RemoteWebElement> driver = null;
            readConfig();
            switch (Config.OperatingSystem.ToLower())
            {
                
                case "android":
                    driver = InitializeAndroidDriver();
                    break;
                case "ios":
                    driver = InitializeIOSDriver();
                    break;
                case "Any":
                    driver = SetupDriver(testName);
                    break;
                default:
                    throw new NotSupportedException($"{Config.OperatingSystem.ToLower()} Operating System is not suported");
            }
            counter++;
            return driver;
        }

        public void readConfig()
        {
            using (StreamReader r = new StreamReader("config.json"))
            {

                var json = r.ReadToEnd();
                var jobj = JObject.Parse(json);

                foreach (var item in jobj)
                {
                    if (item.Key.Contains("OperatingSystem"))
                    {
                        Config.OperatingSystem = item.Value.ToString();
                    }

                    if (item.Key.Contains("ExecutionMode"))
                    {
                        Config.ExecutionMode = item.Value.ToString();
                    }

                    if (item.Key.Contains("DeviceId"))
                    {
                        Config.DeviceId = item.Value.ToString();
                    }

                    if (item.Key.Contains("AppPath"))
                    {
                        Config.AppPath = item.Value.ToString();
                    }

                    if (item.Key.Contains("appPackage"))
                    {
                        Config.appPackage = item.Value.ToString();
                    }

                    if (item.Key.Contains("appActivity"))
                    {
                        Config.appActivity = item.Value.ToString();
                    }

                    if (item.Key.Contains("remoteipadress"))
                    {
                        Config.remoteipadress = item.Value.ToString();
                    }

                    if (item.Key.Contains("remotePort"))
                    {
                        Config.remotePort = item.Value.ToString();
                    }

                }

            }
        }

        public AppiumDriver<RemoteWebElement> SetupDriver(string testName)
        {
            AppiumDriver<RemoteWebElement> driver = null;

            if (testName.Contains("Android"))
            {
                driver = InitializeAndroidDriver();
            }
            else if (testName.Contains("IOS"))
            {
                driver = InitializeIOSDriver();
            }

            return driver;

        }

        private AndroidDriver<RemoteWebElement> InitializeAndroidDriver()
        {

            AndroidDriver<RemoteWebElement> driver = null;

            DesiredCapabilities dc = new DesiredCapabilities();

            dc.SetCapability("platformName", "Android");
            dc.SetCapability("newCommandTimeout", 60 * 5);
            dc.SetCapability("deviceName", Config.DeviceId);
            dc.SetCapability("app", Config.AppPath);
            dc.SetCapability("noReset", true);
            dc.SetCapability("app-package", Config.appPackage);
            dc.SetCapability("app-activity", Config.appActivity);

            if (Config.ExecutionMode.Equals("Local", StringComparison.OrdinalIgnoreCase))
            {
                driver = new AndroidDriver<RemoteWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), dc, TimeSpan.FromSeconds(180));
            }
            else if (Config.ExecutionMode.Equals("Remote", StringComparison.OrdinalIgnoreCase))
            {
                driver = new AndroidDriver<RemoteWebElement>(new Uri("http://"+ Config.remoteipadress + ":" + Config.remotePort + "/wd/hub"), dc, TimeSpan.FromSeconds(180));
            }

            return driver;

        }

        private IOSDriver<RemoteWebElement> InitializeIOSDriver()
        {

            IOSDriver<RemoteWebElement> driver = null;

            DesiredCapabilities dc = new DesiredCapabilities();
            dc.SetCapability("platformName", "ios");
            dc.SetCapability("newCommandTimeout", 60 * 5);
            dc.SetCapability("app-package", "com.experitest.ExperiBank");
            dc.SetCapability("app-activity", "com.experitest.ExperiBank.LoginActivity");

            if (Config.ExecutionMode.Equals("Local", StringComparison.OrdinalIgnoreCase))
            {
                
            }
            else if (Config.ExecutionMode.Equals("Cloud", StringComparison.OrdinalIgnoreCase))
            {
                
                dc.SetCapability("deviceQuery", "@os='ios' and @category='PHONE'");
                dc.SetCapability(IOSMobileCapabilityType.BundleId, "com.experitest.ExperiBank");
                dc.SetCapability(MobileCapabilityType.App, "cloud:com.experitest.ExperiBank");
                driver = new IOSDriver<RemoteWebElement>(new Uri("http://10.56.123.43:80/wd/hub"), dc);
                

             }

            return driver;


        }


    }
}