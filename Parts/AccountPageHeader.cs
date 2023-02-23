using LandsOfHope.UI.Tests.Pages;
using OpenQA.Selenium;

namespace LandsOfHope.UI.Tests.Parts
{
    internal class AccountPageHeader
    {
        public IWebElement WebsiteButtonElement { get; private init; }
        public IWebElement AccountButtonElement { get; private init; }
        public IWebElement BillingButtonElement { get; private init; }
        public IWebElement ReferralsButtonElement { get; private init; }
        public IWebElement SupportButtonElement { get; private init; }
        public IWebElement LogoutButtonElement { get; private init; }

        public AccountPageHeader(IWebDriver driver)
        {
            WebsiteButtonElement = driver.FindElement(By.CssSelector("#rcsbuttonbox td[title=\"Website\"]"));
            AccountButtonElement = driver.FindElement(By.CssSelector("#rcsbuttonbox td[title=\"Account\"]"));
            BillingButtonElement = driver.FindElement(By.CssSelector("#rcsbuttonbox td[title=\"Billing\"]"));
            ReferralsButtonElement = driver.FindElement(By.CssSelector("#rcsbuttonbox td[title=\"Referrals\"]"));
            SupportButtonElement = driver.FindElement(By.CssSelector("#rcsbuttonbox td[title=\"Support\"]"));
            LogoutButtonElement = driver.FindElement(By.CssSelector("#rcsbuttonbox td[title=\"Logout\"]"));
        }
    }
}
