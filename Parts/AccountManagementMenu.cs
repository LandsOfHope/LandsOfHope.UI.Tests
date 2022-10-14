using OpenQA.Selenium;

namespace LandsOfHope.UI.Tests.Parts
{
    internal class AccountManagementMenu
    {
        public IWebElement ChooseCharacterButton { get; private init; }
        public IWebElement SettingsButton { get; private init; }
        public IWebElement BillingButton { get; private init; }
        public IWebElement BoughtExtrasButton { get; private init; }
        public IWebElement ExpansionsButton { get; private init; }
        public IWebElement HopeCreditsButton { get; private init; }
        public IWebElement NoticesButton { get; private init; }
        public IWebElement DeleteAccountButton { get; private init; }

        public AccountManagementMenu(IWebDriver driver)
        {
            ChooseCharacterButton = driver.FindElement(By.CssSelector("a[href=\"fhchar.asp\"]"));
            SettingsButton = driver.FindElement(By.CssSelector("a[href=\"fhaoptions.asp\"]"));
            BillingButton = driver.FindElement(By.CssSelector("a[href=\"fhp2p.asp\"]"));
            BoughtExtrasButton = driver.FindElement(By.CssSelector("a[href=\"fhextra.asp\"]"));
            ExpansionsButton = driver.FindElement(By.CssSelector("a[href=\"fhextraxp.asp\"]"));
            HopeCreditsButton = driver.FindElement(By.CssSelector("a[href=\"fhacmd.asp\"]"));
            NoticesButton = driver.FindElement(By.CssSelector("a[href=\"fhacmn.asp\"]"));
            DeleteAccountButton = driver.FindElement(By.CssSelector("a[href=\"fhacmdd.asp\"]"));
        }
    }
}
