using LandsOfHope.UI.Tests.Parts;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace LandsOfHope.UI.Tests.Pages
{
    public class CharacterPage : Page
    {
        public IWebElement CreateNewCharacterButton { get; private init; }
        public IWebElement CreateNewGladiatorButton { get; private init; }

        public IWebElement UseAPopupWindowCheckbox { get; private init; }
        public IWebElement AnonymousCheckbox { get; private init; }

        public ReadOnlyCollection<IWebElement> SelectableCharacterRadioButtons { get; private init; }

        public IWebElement? PlayButton { get; private init; }
        public IWebElement? SafeModeButton { get; private init; }
        public IWebElement? DeleteButton { get; private init; }

        private AccountManagementMenu AccountManagementMenu { get; init; }
        private AccountPageHeader Header { get; init; }

        public CharacterPage(IWebDriver driver) : base(driver, WaitForPageUrlContains("fhchar.asp"))
        {
            CreateNewCharacterButton = WebDriver.FindElement(By.CssSelector("img[title=\"Create a new character\"]"));
            CreateNewGladiatorButton = WebDriver.FindElement(By.CssSelector("img[title=\"Create a new Gladiator character\"]"));

            UseAPopupWindowCheckbox = WebDriver.FindElement(By.CssSelector("input[name=\"Fully\"]"));
            AnonymousCheckbox = WebDriver.FindElement(By.CssSelector("input[name=\"Anon\"]"));

            SelectableCharacterRadioButtons = WebDriver.FindElements(By.Id("SelectedChar"));

            if (SelectableCharacterRadioButtons.Any())
            {
                PlayButton = WebDriver.FindElement(By.CssSelector("img[src$=\"images/play2.png\"]")); // TODO: better selectors
                SafeModeButton = WebDriver.FindElement(By.CssSelector("img[src$=\"images/safemode.png\"]"));
                DeleteButton = WebDriver.FindElement(By.CssSelector("img[src$=\"images/delete.png\"]"));
            }

            AccountManagementMenu = new AccountManagementMenu(WebDriver);
            Header = new AccountPageHeader(WebDriver);
        }

        public CharacterPage SetSelectedCharacter(Index index)
        {
            SelectableCharacterRadioButtons[index].Click();
            return this;
        }

        public CharacterPage SetUsePopupWindow(bool usePopupWindow)
        {
            if (UseAPopupWindowCheckbox.GetAttribute("checked") != usePopupWindow.ToString())
                UseAPopupWindowCheckbox.Click();

            return this;
        }

        public AccountOptionsPage ClickSettings()
        {
            AccountManagementMenu.SettingsButton.Click();
            return new AccountOptionsPage(WebDriver);
        }

        public PlayPage ClickPlay()
        {
            PlayButton!.Click();
            return new PlayPage(WebDriver);
        }

        public PlayPage ClickSafeMode()
        {
            SafeModeButton!.Click();
            return new PlayPage(WebDriver);
        }

        public Popup<CreateCharacterPage, CharacterPage> ClickNewCharacter()
        {
            CreateNewCharacterButton.Click();
            return new Popup<CreateCharacterPage, CharacterPage>(WebDriver, this);
        }

        public LandingPage ClickLogout()
        {
            Header.LogoutButtonElement.Click();
            return new LandingPage(WebDriver);
        }
    }
}
