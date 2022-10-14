using LandsOfHope.UI.Tests.Pages;

namespace LandsOfHope.UI.Tests.Tests;
public class LandingPageTests : PageTest<LandingPage>
{
    public LandingPageTests(LOHSiteDriver driver)
        : base(driver, (page, account) => page)
    {

    }

    [Fact]
    public void CanSignUp()
    {
        var signUpPage = Page.ClickSignUp();
        signUpPage.Fill(AccountInfo.AccountName, null, AccountInfo.AccountPassword, AccountInfo.AccountPassword, AccountInfo.AccountEmail, null, true);
        var optionsPage = signUpPage.ClickSignUp().AsT0;

        optionsPage.SetDOB(AccountOptionsPage.Month.January, 1, 2016);
        optionsPage.SetCountryCode(AccountOptionsPage.CountryCode.CA);

        Assert.NotNull(optionsPage.ClickSaveChanges().AsT0);
    }
}