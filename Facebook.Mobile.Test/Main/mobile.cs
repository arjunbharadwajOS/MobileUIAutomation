using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using OpenQA.Selenium;

namespace Facebook.Mobile.Test.Main
{

    public enum findBy
    {
        Id,
        XPath,
        text,
        LinkText,
        ClassName,
        Name,
        PartialLinkText

    }


    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    public class mobile : System.Attribute
    {
        findBy option;
        string deviceplatform;
        string value;
        List<string> values;

        public mobile(string platform, findBy passedField, string passedValue)
        {
            deviceplatform = platform;
            option = passedField;
            values = passedValue.Split(',').ToList<string>();
            value = values.FirstOrDefault();
        }

        public findBy Option
        {
            get { return this.option; }

        }

        public string Value
        {
            get { return value; }
        }

        public string Platform
        {
            get { return deviceplatform; }
        }
    }


    public class LocatorHelper
    {
        IWebDriver driver;
        string platform;
        public LocatorHelper(IWebDriver Driver, string Platform)
        {
            driver = Driver;
            platform = Platform;

        }

        public IWebElement GetElement(Object page, string ObjectName)
        {
            bool found = false;
            IWebElement element = null;
            String test = page.GetType().FullName;
            Type type = Type.GetType(test);
            mobile HelpAttr;

            foreach (PropertyInfo prop in type.GetProperties())
            {
                if (found)
                    break;

                foreach (Attribute attr in prop.GetCustomAttributes(true))
                {

                    HelpAttr = attr as mobile;
                    if (null != HelpAttr)
                    {

                        if (prop.Name.Equals(ObjectName))
                        {


                            if (platform.Equals("android") && platform.Equals(HelpAttr.Platform))
                            {
                                switch (HelpAttr.Option)
                                {

                                    case findBy.Id:
                                        element = driver.FindElement(By.Id(HelpAttr.Value));
                                        found = true;
                                        break;
                                    case findBy.XPath:
                                        element = driver.FindElement(By.XPath(HelpAttr.Value));
                                        found = true;
                                        break;
                                    case findBy.ClassName:
                                        element = driver.FindElement(By.ClassName(HelpAttr.Value));
                                        found = true;
                                        break;
                                }

                            }
                            else if (platform.Equals("ios") && platform.Equals(HelpAttr.Platform))
                            {

                                switch (HelpAttr.Option)
                                {

                                    case findBy.Id:
                                        element = driver.FindElement(By.Id(HelpAttr.Value));
                                        found = true;
                                        break;
                                    case findBy.XPath:
                                        element = driver.FindElement(By.XPath(HelpAttr.Value));
                                        found = true;
                                        break;
                                    case findBy.ClassName:
                                        element = driver.FindElement(By.ClassName(HelpAttr.Value));
                                        found = true;
                                        break;
                                }

                            }

                        }

                    }
                    
                }
            }

            return element;
        }


        public IList<IWebElement> GetElements(Object page, string ObjectName)
        {
            bool found = false;
            IList<IWebElement> element = null;
            String test = page.GetType().FullName;
            Type type = Type.GetType(test);
            mobile HelpAttr;

            foreach (PropertyInfo prop in type.GetProperties())
            {
                if (found)
                    break;

                foreach (Attribute attr in prop.GetCustomAttributes(true))
                {

                    HelpAttr = attr as mobile;
                    if (null != HelpAttr)
                    {

                        if (prop.Name.Equals(ObjectName))
                        {


                            if (platform.Equals("android") && platform.Equals(HelpAttr.Platform))
                            {
                                switch (HelpAttr.Option)
                                {

                                    case findBy.Id:
                                        element = driver.FindElements(By.Id(HelpAttr.Value));
                                        found = true;
                                        break;
                                    case findBy.XPath:
                                        element = driver.FindElements(By.XPath(HelpAttr.Value));
                                        found = true;
                                        break;
                                    case findBy.ClassName:
                                        element = driver.FindElements(By.ClassName(HelpAttr.Value));
                                        found = true;
                                        break;
                                }

                            }
                            else if (platform.Equals("ios") && platform.Equals(HelpAttr.Platform))
                            {

                                switch (HelpAttr.Option)
                                {

                                    case findBy.Id:
                                        element = driver.FindElements(By.Id(HelpAttr.Value));
                                        found = true;
                                        break;
                                    case findBy.XPath:
                                        element = driver.FindElements(By.XPath(HelpAttr.Value));
                                        found = true;
                                        break;
                                    case findBy.ClassName:
                                        element = driver.FindElements(By.ClassName(HelpAttr.Value));
                                        found = true;
                                        break;
                                }

                            }

                        }

                    }

                }
            }

            return element;
        }






    }
}