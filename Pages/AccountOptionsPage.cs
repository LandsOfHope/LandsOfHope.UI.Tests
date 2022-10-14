using LandsOfHope.UI.Tests.Parts;
using OneOf;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LandsOfHope.UI.Tests.Pages
{
    public class AccountOptionsPage : Page
    {
        public IWebElement ResetPasswordLink { get; private init; }
        public IWebElement EmailAddressTextBox { get; private init; }
        public IWebElement AllowGameRelatedMails { get; private init; }
        public IWebElement UseNewInterface { get; private init; }

        public bool IsDOBPrompt { get; private init; }
        public SelectElement? DOBMonth { get; private init; }
        public SelectElement? DOBDay { get; private init; }
        public SelectElement? DOBYear { get; private init; }

        public SelectElement CountrySelect { get; private init; }
        //TODO: add theme 'buttons'
        public IWebElement SaveChangesButton { get; private init; }

        private AccountManagementMenu AccountManagementMenu { get; init; }

        public enum Month
        {
            Month = 0,
            January = 1,
            Februrary = 2,
            March = 3,
            April = 4,
            May = 5,
            June = 6,
            July = 7,
            August = 8,
            September = 9,
            October = 10,
            November = 11,
            December = 12,
        }

        public enum CountryCode
        {
            CA,
            GB,
            US,
        }

        public AccountOptionsPage(IWebDriver driver) : base(driver, WaitForUniqueElementVisible(By.CssSelector("a[href=\"fhresetpw.asp\"]")))
        {
            ResetPasswordLink = WebDriver.FindElement(By.CssSelector("a[href=\"fhresetpw.asp\"]"));
            EmailAddressTextBox = WebDriver.FindElement(By.CssSelector("input[name=\"AccountEmail\"]"));
            AllowGameRelatedMails = WebDriver.FindElement(By.CssSelector("input[name=\"AccountCanEmail\"]"));
            UseNewInterface = WebDriver.FindElement(By.CssSelector("input[name=\"MainStyle\"]"));

            IsDOBPrompt = false;
            var dobMonthSelect = WebDriver.FindElements(By.CssSelector("select[name=\"dobm\"]"));

            if (dobMonthSelect.Any())
            {
                DOBMonth = new SelectElement(dobMonthSelect.First());
                DOBDay = new SelectElement(WebDriver.FindElement(By.CssSelector("select[name=\"dobd\"]")));
                DOBYear = new SelectElement(WebDriver.FindElement(By.CssSelector("select[name=\"doby\"]")));
                IsDOBPrompt = true;
            }

            CountrySelect = new SelectElement(WebDriver.FindElement(By.CssSelector("select[name=\"CountryCode\"]")));

            SaveChangesButton = WebDriver.FindElement(By.CssSelector("button[title=\"Save Changes\"]"));

            AccountManagementMenu = new AccountManagementMenu(WebDriver);
        }

        public AccountOptionsPage SetDOB(Month month, int day, int year)
        {
            DOBMonth.SelectByText(month.ToString());
            DOBDay.SelectByText(day.ToString());
            DOBYear.SelectByText(year.ToString());

            return this;
        }

        public AccountOptionsPage SetCountryCode(CountryCode countryCode)
        {
            CountrySelect.SelectByValue(countryCode.ToString());
            return this;
        }

        public OneOf<CharacterPage, AccountOptionsPage> ClickSaveChanges()
        {
            SaveChangesButton.Click();
            return new CharacterPage(WebDriver);
        }
    }
}
