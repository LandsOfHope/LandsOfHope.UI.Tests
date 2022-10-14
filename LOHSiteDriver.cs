using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System.Net;

namespace LandsOfHope.UI.Tests
{
    public class LOHSiteDriver : IDisposable
    {
        private const string Url = "http://dev.landsofhope.com";
        public IWebDriver WebDriver { get; private init; }

        public LOHSiteDriver()
        {
            WebDriver = new EdgeDriver();
        }

        public void Reset()
        {
            WebDriver.Manage().Cookies.DeleteAllCookies();
            WebDriver.Navigate().GoToUrl(Url);
        }

        public void Dispose()
        {
            WebDriver.Quit();
        }
    }
}
