using OneOf;
using OpenQA.Selenium;

namespace LandsOfHope.UI.Tests.Pages
{
    public class LandingPage : Page
    {
        public IWebElement PlayButton { get; private set; }
        public IWebElement ForgotPasswordLink { get; private set; }
        public IWebElement SignUpButton { get; private set; }

        public IWebElement AccountNameInputElement { get; private set; }
        public IWebElement AccountPasswordInputElement { get; private set; }

        public LandingPage(IWebDriver driver)
            : base(driver, WaitForUniqueElementVisible(By.CssSelector("form[name=\"login\"]")))
        {
            PlayButton = driver.FindElement(By.CssSelector("input[name=\"submit\"]"));
            ForgotPasswordLink = driver.FindElement(By.CssSelector("a[href=\"fhlspw.asp\"]"));
            SignUpButton = driver.FindElement(By.CssSelector("img[src=\"https://res.landsofhope.com/images/signup.png\""));

            AccountNameInputElement = driver.FindElement(By.CssSelector("input[name=\"name\"]"));
            AccountPasswordInputElement = driver.FindElement(By.CssSelector("input[name=\"password\"]"));
        }

        public SignUpPage ClickSignUp()
        {
            SignUpButton.Click();
            return new SignUpPage(WebDriver);
        }

        public LandingPage FillAccountInfo(AccountInfo info)
            => FillAccountInfo(info.AccountName, info.AccountPassword);

        public LandingPage FillAccountInfo(string? accountName, string? accountPassword)
        {
            AccountNameInputElement.Clear();
            if (accountName is not null)
                AccountNameInputElement.SendKeys(accountName);

            AccountPasswordInputElement.Clear();
            if (accountPassword is not null)
                AccountPasswordInputElement.SendKeys(accountPassword);

            return this;
        }

        public OneOf<CharacterPage, LandingPage> ClickPlay()
        {
            PlayButton.Click();
            if (WebDriver.Url.Contains("fhchar.asp"))
                return new CharacterPage(WebDriver);
            return this;
        }
    }
}
