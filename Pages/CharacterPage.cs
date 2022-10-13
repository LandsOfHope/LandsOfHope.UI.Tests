using OpenQA.Selenium;

namespace LandsOfHope.UI.Tests.Pages
{
    public class CharacterPage : Page
    {
        public IWebElement CreateNewCharacterButton { get; private init; }
        public IWebElement CreateNewGladiatorButton { get; private init; }

        public IWebElement UseAPopupWindowCheckbox { get; private init; }
        public IWebElement AnonymousCheckbox { get; private init; }

        public CharacterPage(IWebDriver driver) : base(driver)
        {
            CreateNewCharacterButton = WebDriver.FindElement(By.CssSelector("img[title=\"Create a new character\"]"));
            CreateNewGladiatorButton = WebDriver.FindElement(By.CssSelector("img[title=\"Create a new Gladiator character\"]"));

            UseAPopupWindowCheckbox = WebDriver.FindElement(By.CssSelector("input[name=\"Fully\"]"));
            AnonymousCheckbox = WebDriver.FindElement(By.CssSelector("input[name=\"Anon\"]"));
        }
    }
}
