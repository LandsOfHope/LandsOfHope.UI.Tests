using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Net;

namespace LandsOfHope.UI.Tests.Pages
{
    public delegate object? PageWaitDelegate(IWebDriver driver);

    public abstract class Page
    {
        public static readonly TimeSpan DefaultWaitTimeOut = TimeSpan.FromSeconds(1);
        protected IWebDriver WebDriver { get; private init; }

        protected static PageWaitDelegate WaitForPageUrlContains(string pageUrl) => (driver) => driver.Url.Contains(pageUrl) ? new object() : null;
        protected static PageWaitDelegate WaitForUniqueElementVisible(By selector) => (driver) => ExpectedConditions.ElementIsVisible(selector)(driver);

        protected Page(IWebDriver driver, PageWaitDelegate loadCheck, TimeSpan? loadTimeOut = null)
        {
            WebDriver = driver;

            var wait = new WebDriverWait(driver, loadTimeOut ?? DefaultWaitTimeOut);
            _ = wait.Until(driver => loadCheck(driver));
        }

        public async Task EnsureNoBrokenImages()
        {
            var allImgSrcs = new HashSet<string>(WebDriver.FindElements(By.TagName("img")).Select(img => img.GetAttribute("src")));

            var backgroundImageUrls =
                WebDriver.ExecuteJavaScript<string>(
                  @"
                    const items = document.querySelectorAll('*');
                    urls = [];

                    items.forEach((item) => {
                        const imageURL = window.getComputedStyle(item).getPropertyValue('background-image');
                        if(imageURL) {
                            const rgURL = /url\(['|""](.+)['|""]\)/gi;
                            const imgSrcResults = (rgURL).exec(imageURL);
                            if(imgSrcResults) {
                                urls.push(imgSrcResults[1]);
                            }
                        }
                    });

                    return urls.join(';');
                  "
                ).Split(';');

            allImgSrcs.Union(backgroundImageUrls);

            Dictionary<string, HttpStatusCode> brokenImages = new Dictionary<string, HttpStatusCode>();
            List<string> mistargetedImages = new List<string>();
            using var httpClient = new HttpClient();
            foreach (var src in allImgSrcs)
            {
                if (!src.Contains("res.landsofhope.com", StringComparison.InvariantCultureIgnoreCase))
                    mistargetedImages.Add(src);

                var response = await httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, src));
                if (!response.IsSuccessStatusCode)
                    brokenImages.Add(src, response.StatusCode);
            }

            Assert.Empty(mistargetedImages);
            Assert.Empty(brokenImages);
        }
    }
}
