using OpenQA.Selenium;

namespace LandsOfHope.UI.Tests.Pages
{
    public class LandingPage : Page
    {
        public IWebElement LoginButton { get; private set; }
        public IWebElement ForgotPasswordLink { get; private set; }
        public IWebElement SignUpButton { get; private set; }

        public LandingPage(IWebDriver driver)
            : base(driver, WaitForUniqueElementVisible(By.CssSelector("form[name=\"login\"]")))
        {
            LoginButton = driver.FindElement(By.CssSelector("input[name=\"submit\"]"));
            ForgotPasswordLink = driver.FindElement(By.CssSelector("a[href=\"fhlspw.asp\"]"));
            SignUpButton = driver.FindElement(By.CssSelector("img[src=\"https://res.landsofhope.com/images/signup.png\""));
        }

        public SignUpPage ClickSignUp()
        {
            SignUpButton.Click();
            return new SignUpPage(WebDriver);
        }
    }
}
