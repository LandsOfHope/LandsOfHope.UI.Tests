using LandsOfHope.UI.Tests.Pages;

namespace LandsOfHope.UI.Tests.Tests
{
    public class ResetPasswordPageTests
        : PageTest<ResetPasswordPage>
    {
        private static ResetPasswordPage SetUp(
            LandingPage landingPage, AccountInfo accountInfo
        )
        {
            return
                landingPage
                .ClickSignUp()
                .Fill(accountInfo)
                .ClickSignUp().AsT0
                .SetDOB(AccountOptionsPage.Month.January, 1, 2016)
                .ClickSaveChanges().AsT0
                .ClickSettings()
                .ClickResetPassword();
        }

        public ResetPasswordPageTests(LOHSiteDriver driver) : base(driver, SetUp)
        {

        }

        [Fact]
        public void CanStillLoginAfterSaveChangesWithoutChangingCurrentValue()
        {
            var resultPage =
                Page.ClickSaveChanges()
                    .ClickLogout()
                    .FillAccountInfo(AccountInfo)
                    .ClickPlay();

            Assert.IsType<CharacterPage>(resultPage.Value);
        }

        [Fact]
        public void CanChangePasswordAndLogin()
        {
            var resultPage =
                Page.SetPassword("TESTING")
                    .ClickSaveChanges()
                    .ClickLogout()
                    .FillAccountInfo(AccountInfo.AccountName, "TESTING")
                    .ClickPlay();

            Assert.IsType<CharacterPage>(resultPage.Value);
        }
    }
}
