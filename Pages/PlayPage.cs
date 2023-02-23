using System.Drawing;
using LandsOfHope.UI.Tests.Parts;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace LandsOfHope.UI.Tests.Pages
{
    public class PlayPage : Page
    {
        public IWebElement InventoryMenuItem { get; private init; }
        public IWebElement OptionMenuElement { get; private init; }

        public GameWindow? StatusWindow { get; private init; }

        public Point CurrentMapPosition
        {
            get
            {
                var xElement = WebDriver.FindElement(By.Id("x"));
                var yElement = WebDriver.FindElement(By.Id("y"));
                return new Point(int.Parse(xElement.Text), int.Parse(yElement.Text));
            }
        }

        public PlayPage(IWebDriver driver) : base(driver, WaitForPageUrlContains("fhlogin.asp"), TimeSpan.FromSeconds(20))
        {
            InventoryMenuItem = WebDriver.FindElement(By.Id("mnu50"));
            OptionMenuElement = WebDriver.FindElement(By.Id("OptionCog"));

            StatusWindow = GameWindow.Find(WebDriver, "StatusWindow");
        }

        public void ToggleWindowResize()
        {
            OptionMenuElement.Click();
            WebDriver.FindElement(By.Id("rcssm0")).Click();
        }

        public void DragWindow(GameWindow window, int offsetX, int offsetY)
        {
            // todo: this isn't working
            var actions = new Actions(WebDriver);
            actions.ClickAndHold(window.HeaderTitleElement);
            actions.MoveByOffset(offsetX, offsetY);
            actions.Release(window.WindowElement);
            actions.Perform();
        }
    }
}
