using OneOf;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LandsOfHope.UI.Tests.Pages
{
    public class SignUpPage : Page
    {
        public IWebElement AccountNameTextBox { get; private init; }
        public IWebElement ReferralIdTextBox { get; private init; }
        public IWebElement PasswordTextBox { get; private init; }
        public IWebElement PasswordConfirmationTextBox { get; private init; }
        public IWebElement EmailAddressTextBox { get; private init; }
        public SelectElement HowFindSelect { get; private init; }
        public IWebElement ReadTermsCheckbox { get; private init; }
        public IWebElement SignUpButton { get; private init; }

        public enum FoundHow
        {
            PleaseChoose = 1,
            Mpogd = 2,
            GoogleAd = 3,
            Other = 4,
            WordOfMouth = 5,
            Referred = 6,
            SearchEngine = 7,
            OtherPlayer = 8,
        }

        public SignUpPage(IWebDriver driver) : base(driver, WaitForPageUrlContains("signup.asp"))
        {
            AccountNameTextBox = WebDriver.FindElement(By.CssSelector("input[Name=\"AccountName\"]"));
            ReferralIdTextBox = WebDriver.FindElement(By.CssSelector("input[Name=\"Ref\"]"));
            PasswordTextBox = WebDriver.FindElement(By.CssSelector("input[Name=\"Accountpassword\"]"));
            PasswordConfirmationTextBox = WebDriver.FindElement(By.CssSelector("input[Name=\"Accountpassword2\"]"));
            EmailAddressTextBox = WebDriver.FindElement(By.CssSelector("input[Name=\"AccountEmail\"]"));
            HowFindSelect = new SelectElement(WebDriver.FindElement(By.CssSelector("select[Name=\"FoundHow\"]")));
            ReadTermsCheckbox = WebDriver.FindElement(By.CssSelector("input[name=\"TOS\"]"));
            SignUpButton = WebDriver.FindElement(By.CssSelector("button[title=\"Signup\"]"));
        }

        public SignUpPage SetAccountName(string? accountName)
        {
            AccountNameTextBox.Clear();
            if (accountName is not null)
                AccountNameTextBox.SendKeys(accountName);

            return this;
        }

        public SignUpPage SetReferralId(string? referralId)
        {
            ReferralIdTextBox.Clear();
            if (referralId is not null)
                ReferralIdTextBox.SendKeys(referralId);

            return this;
        }

        public SignUpPage SetPassword(string? password)
        {
            PasswordTextBox.Clear();
            if (password is not null)
                PasswordTextBox.SendKeys(password);

            return this;
        }

        public SignUpPage SetPasswordConfirmation(string? password)
        {
            PasswordConfirmationTextBox.Clear();
            if (password is not null)
                PasswordConfirmationTextBox.SendKeys(password);

            return this;
        }

        public SignUpPage SetEmailAddress(string? emailAddress)
        {
            EmailAddressTextBox.Clear();
            if (emailAddress is not null)
                EmailAddressTextBox.SendKeys(emailAddress);

            return this;
        }

        public SignUpPage SetFoundHow(FoundHow? foundHow)
        {
            if (foundHow is not null)
                HowFindSelect.SelectByValue(((int)foundHow.Value).ToString());
            else
                HowFindSelect.SelectByValue(((int)FoundHow.PleaseChoose).ToString());

            return this;
        }

        public SignUpPage SetReadTerms(bool? haveReadTerms)
        {
            if (haveReadTerms is not null)
            {
                if (ReadTermsCheckbox.GetAttribute("checked") != haveReadTerms.Value.ToString())
                    ReadTermsCheckbox.Click();
            }

            return this;
        }

        public SignUpPage Fill(string? accountName, string? referralId, string? password, string? retypePassword, string? emailAddress, FoundHow? foundHow, bool? haveReadTerms)
        {
            return SetAccountName(accountName)
                .SetReferralId(referralId)
                .SetPassword(password)
                .SetPasswordConfirmation(retypePassword)
                .SetEmailAddress(emailAddress)
                .SetFoundHow(foundHow)
                .SetReadTerms(haveReadTerms);
        }

        public SignUpPage Fill(AccountInfo account)
        {
            return Fill(
                account.AccountName,
                null,
                account.AccountPassword,
                account.AccountPassword,
                account.AccountEmail,
                null,
                true
            );
        }

        public OneOf<AccountOptionsPage, SignUpPage> ClickSignUp()
        {
            SignUpButton.Click();
            if (WebDriver.Url.Contains("fhaoptions.asp"))
                return new AccountOptionsPage(WebDriver);
            return this;
        }
    }
}
