using OpenQA.Selenium;

namespace LandsOfHope.UI.Tests.Pages
{
    public abstract class Page
    {
        protected IWebDriver WebDriver { get; private init; }

        protected Page(IWebDriver driver)
        {
            WebDriver = driver;
        }
    }
}
