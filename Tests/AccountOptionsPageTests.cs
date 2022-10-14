using LandsOfHope.UI.Tests.Pages;

namespace LandsOfHope.UI.Tests.Tests
{
    public class AccountOptionsPageDOBPromptTests : PageTest<AccountOptionsPage>
    {
        private static AccountOptionsPage SetUp(LandingPage landingPage, AccountInfo account)
        {
            return 
                landingPage
                .ClickSignUp()
                .Fill(account)
                .ClickSignUp().AsT0;
        }

        public AccountOptionsPageDOBPromptTests(LOHSiteDriver driver) 
            : base(driver, SetUp)
        {

        }
    }

    public class AccountOptionsPageTests : PageTest<AccountOptionsPage>
    {
        private static AccountOptionsPage SetUp(LandingPage landingPage, AccountInfo account)
        {
            return
                landingPage
                .ClickSignUp()
                .Fill(account)
                .ClickSignUp().AsT0
                .SetDOB(AccountOptionsPage.Month.January, 1, 2016)
                .ClickSaveChanges().AsT0
                .ClickSettings();
        }

        public AccountOptionsPageTests(LOHSiteDriver driver)
            : base(driver, SetUp)
        {

        }
    }
}
