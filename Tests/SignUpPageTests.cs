using LandsOfHope.UI.Tests.Pages;

namespace LandsOfHope.UI.Tests.Tests
{
    public class SignUpPageTests : PageTest<SignUpPage>
    {
        private static SignUpPage SetUp(LandingPage landingPage)
            => landingPage.ClickSignUp();

        private string UserId = $"test-{Guid.NewGuid()}";

        public SignUpPageTests(LOHSiteDriver driver)
            : base(driver, SetUp)
        {

        }

        [Fact]
        public void AccountNameIsRequired()
        {
            Page.Fill(accountName: null, null, UserId, UserId, $"test{Guid.NewGuid()}@test.landsofhope.com", SignUpPage.FoundHow.SearchEngine, true);

            var newPage = Page.ClickSignUp();
            Assert.Equal(Page, newPage);
        }

        [Fact]
        public void PasswordIsRequired()
        {
            Page.Fill(UserId, null, null, UserId, $"{UserId}@test.landsofhope.com", SignUpPage.FoundHow.SearchEngine, true);

            var newPage = Page.ClickSignUp();
            Assert.Equal(Page, newPage);
        }

        [Fact]
        public void PasswordConfirmationIsRequired()
        {
            Page.Fill(UserId, null, UserId, null, $"{UserId}@test.landsofhope.com", SignUpPage.FoundHow.SearchEngine, true);

            var newPage = Page.ClickSignUp();
            Assert.Equal(Page, newPage);
        }

        [Fact]
        public void PasswordAndConfirmationMustMatch()
        {
            Page.Fill(UserId, null, UserId, "password", $"{UserId}@test.landsofhope.com", SignUpPage.FoundHow.SearchEngine, true);

            var newPage = Page.ClickSignUp();
            Assert.Equal(Page, newPage);
        }

        [Fact]
        public void HowFoundIsOptional()
        {
            Page.Fill(UserId, null, UserId, UserId, $"{UserId}@test.landsofhope.com", null, true);

            var newPage = Page.ClickSignUp();
            Assert.NotEqual(Page, newPage);
            Assert.True(newPage.IsT0);
        }

        [Fact]
        public void ReadTermsIsRequired()
        {
            Page.Fill(UserId, null, UserId, UserId, $"{UserId}@test.landsofhope.com", SignUpPage.FoundHow.SearchEngine, null);

            var newPage = Page.ClickSignUp();
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
            Page.Fill(UserId, null, UserId, UserId, $"{UserId}@test.landsofhope.com", foundHow, true);

            var newPage = Page.ClickSignUp();
            Assert.NotEqual(Page, newPage);
            Assert.True(newPage.IsT0);
        }
    }
}
