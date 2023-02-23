using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace LandsOfHope.UI.Tests
{
    public class LOHSiteDriver : IDisposable
    {
        private const string Url = "http://localhost:8000";
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
