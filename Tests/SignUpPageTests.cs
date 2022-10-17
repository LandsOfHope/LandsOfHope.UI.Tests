using LandsOfHope.UI.Tests.Pages;

namespace LandsOfHope.UI.Tests.Tests
{
    public class SignUpPageTests : PageTest<SignUpPage>
    {
        private static SignUpPage SetUp(LandingPage landingPage, AccountInfo account)
            => landingPage.ClickSignUp();

        public SignUpPageTests(LOHSiteDriver driver)
            : base(driver, SetUp)
        {

        }

        [Fact]
        public void AccountNameIsRequired()
        {
            var newPage =
                Page.Fill(accountName: null, null, AccountInfo.AccountPassword, AccountInfo.AccountPassword, AccountInfo.AccountEmail, SignUpPage.FoundHow.SearchEngine, true)
                .ClickSignUp();

            Assert.Equal(Page, newPage);
        }

        [Fact]
        public void PasswordIsRequired()
        {
            var newPage = 
                Page.Fill(AccountInfo.AccountName, null, null, AccountInfo.AccountPassword, AccountInfo.AccountEmail, SignUpPage.FoundHow.SearchEngine, true)
                .ClickSignUp();

            Assert.Equal(Page, newPage);
        }

        [Fact]
        public void PasswordConfirmationIsRequired()
        {
            var newPage =
                Page.Fill(AccountInfo.AccountName, null, AccountInfo.AccountPassword, null, AccountInfo.AccountEmail, SignUpPage.FoundHow.SearchEngine, true)
                .ClickSignUp();

            Assert.Equal(Page, newPage);
        }

        [Fact]
        public void PasswordAndConfirmationMustMatch()
        {
            var newPage =
                Page.Fill(AccountInfo.AccountName, null, AccountInfo.AccountPassword, "password", AccountInfo.AccountEmail, SignUpPage.FoundHow.SearchEngine, true)
                .ClickSignUp();

            Assert.Equal(Page, newPage);
        }

        [Fact]
        public void HowFoundIsOptional()
        {
            var newPage =
                Page.Fill(AccountInfo.AccountName, null, AccountInfo.AccountPassword, AccountInfo.AccountPassword, AccountInfo.AccountEmail, null, true)
                .ClickSignUp();

            Assert.NotEqual(Page, newPage);
            Assert.True(newPage.IsT0);
        }

        [Fact]
        public void ReadTermsIsRequired()
        {
            var newPage =
                Page.Fill(AccountInfo.AccountName, null, AccountInfo.AccountPassword, AccountInfo.AccountPassword, AccountInfo.AccountEmail, SignUpPage.FoundHow.SearchEngine, null)
                .ClickSignUp();

            Assert.Equal(Page, newPage);
        }

        public static IEnumerable<object[]> AllFoundHow
        {
            get
            {
                yield return new object[] { SignUpPage.FoundHow.Referred };
                yield return new object[] { SignUpPage.FoundHow.PleaseChoose };
                yield return new object[] { SignUpPage.FoundHow.Mpogd };
                yield return new object[] { SignUpPage.FoundHow.GoogleAd };
                yield return new object[] { SignUpPage.FoundHow.Other };
                yield return new object[] { SignUpPage.FoundHow.WordOfMouth };
                yield return new object[] { SignUpPage.FoundHow.Referred };
                yield return new object[] { SignUpPage.FoundHow.SearchEngine };
                yield return new object[] { SignUpPage.FoundHow.OtherPlayer };
            }
        }

        [Theory]
        [MemberData(nameof(AllFoundHow))]
        public void AcceptsAnyFoundHow(SignUpPage.FoundHow foundHow)
        {
            var newPage =
                Page.Fill(AccountInfo.AccountName, null, AccountInfo.AccountPassword, AccountInfo.AccountPassword, AccountInfo.AccountEmail, foundHow, true)
                .ClickSignUp();

            Assert.NotEqual(Page, newPage);
            Assert.True(newPage.IsT0);
        }

        [Fact]
        public void CompleteSignUpPromptsDOB()
        {
            var optionsPage =
                Page.Fill(AccountInfo)
                .ClickSignUp().AsT0;

            Assert.True(optionsPage.IsDOBPrompt);
        }
    }
}
