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

        public async Task EnsureNoBrokenImages()
        {
            var allImages = WebDriver.FindElements(By.TagName("img"));

            using var httpClient = new HttpClient();
            foreach (var image in allImages)
            {
                var src = image.GetAttribute("src");

                var response = await httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, src));
                Assert.True(HttpStatusCode.OK == response.StatusCode, $"img src='{src}' returned status code {response.StatusCode}");
            }
        }

        public void Dispose()
        {
            WebDriver.Quit();
        }
    }
}
