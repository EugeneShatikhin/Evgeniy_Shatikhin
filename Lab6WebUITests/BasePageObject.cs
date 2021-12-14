using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
namespace Lab6WebUITests
{
    static class Global
    {
        public static string path = @"C:\Users\EShat\Desktop\3 курс\dev_test\lab6 - web ui\";
        public static WebDriver driver;
    }
    class BasePageObject
    {
        public void Click(WebElement elem)
        {
            elem.Click();
        }
        public void Input(WebElement elem, string keys)
        {
            elem.SendKeys(keys);
        }
        public WebElement GetElement(By by)
        {
            return (WebElement)Global.driver.FindElement(by);
        }
        public string GetAttribute(By by, string attr)
        {
            return GetElement(by).GetAttribute(attr);
        }
        public string GetAttribute(WebElement elem, string attr)
        {
            return elem.GetAttribute(attr);
        }
        public void GoToURL(string url)
        {
            Global.driver.Navigate().GoToUrl(url);
        }
        public void Quit()
        {
            Global.driver.Quit();
        }
    }
}
