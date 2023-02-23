using OpenQA.Selenium;

namespace LandsOfHope.UI.Tests.Parts
{
    public class GameWindow
    {
        public IWebElement WindowElement { get; private init; }
        public IWebElement HeaderTitleElement { get; private init; }

        public IWebElement DragHandle { get; private init; }

        public GameWindow(IWebDriver driver, string windowId)
        {
            WindowElement = driver.FindElement(By.Id(windowId));
            HeaderTitleElement = driver.FindElement(By.CssSelector($"#{windowId} .navborderx > .title"));

            DragHandle = driver.FindElement(By.CssSelector($"#{windowId} > table"));
        }

        public static GameWindow? Find(IWebDriver driver, string windowId)
        {
            var windowElements = driver.FindElements(By.Id(windowId));
            if (windowElements.Any())
                return new GameWindow(driver, windowId);

            return null;
        }
    }
}
