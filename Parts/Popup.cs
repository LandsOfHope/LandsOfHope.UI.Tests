using LandsOfHope.UI.Tests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LandsOfHope.UI.Tests.Parts
{
    public class Popup<TChild, TParent>
        where TChild : Page
        where TParent : Page
    {
        private IWebDriver WebDriver { get; init; }

        private IWebElement PopupFrameElement { get; init; }
        private IWebElement HardCloseButton { get; init; }
        private IWebElement SoftCloseButton { get; init; }

        private TParent Parent { get; init; }
        private TChild Child { get; init; }

        public Popup(IWebDriver driver, TParent parent, TimeSpan? popupWaitTimeout = null)
        {
            WebDriver = driver;
            Parent = parent;

            var wait = new WebDriverWait(WebDriver, popupWaitTimeout ?? Page.DefaultWaitTimeOut);
            PopupFrameElement = wait.Until(d => d.FindElement(By.Id("popupFrame")));
            HardCloseButton = wait.Until(d => d.FindElement(By.Id("popCloseBox")));

            WebDriver.SwitchTo().Frame(PopupFrameElement);
            Child = (TChild)typeof(TChild).GetConstructor(new[] { typeof(IWebDriver) })!.Invoke(new[] { WebDriver });
        }

        public Popup<TChild, TParent> WithPopup(Action<TChild> action)
        {
            WebDriver.SwitchTo().DefaultContent();
            WebDriver.SwitchTo().Frame(PopupFrameElement);

            action(Child);
            return this;
        }

        public TParent HardClose()
        {
            WebDriver.SwitchTo().DefaultContent();
            HardCloseButton.Click();
            return Parent;
        }

        public TParent Close()
        {
            WebDriver.SwitchTo().DefaultContent();
            WebDriver.SwitchTo().Frame(PopupFrameElement);
            
            WebDriver.FindElement(By.CssSelector("a[title=\"Close this window\"]")).Click();
            return (TParent)typeof(TParent).GetConstructor(new[] { typeof(IWebDriver) })!.Invoke(new[] { WebDriver });
        }
    }
}
