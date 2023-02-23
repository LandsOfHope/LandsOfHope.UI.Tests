using OpenQA.Selenium;

namespace LandsOfHope.UI.Tests.Pages
{
    public class ResetPasswordPage
        : Page
    {
        private IWebElement PasswordInputElement { get; init; }
        private IWebElement SaveChangesButtonElement { get; init; }

        public ResetPasswordPage(IWebDriver driver)
            : base(driver, WaitForUniqueElementVisible(By.CssSelector("input[name=\"Accountpassword\"]")))
        {
            PasswordInputElement = driver.FindElement(By.CssSelector("input[name=\"Accountpassword\"]"));
            SaveChangesButtonElement = driver.FindElement(By.CssSelector("button[title=\"Save Changes\"]"));
        }


        public ResetPasswordPage SetPassword(string? password)
        {
            PasswordInputElement.Clear();
            if (password is not null)
                PasswordInputElement.SendKeys(password);
            return this;
        }

        public CharacterPage ClickSaveChanges()
        {
            SaveChangesButtonElement.Click();
            return new CharacterPage(WebDriver);
        }
    }
}
