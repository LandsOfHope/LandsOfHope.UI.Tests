using LandsOfHope.UI.Tests.Pages;

namespace LandsOfHope.UI.Tests.Tests;
public class LandingPageTests : PageTest<LandingPage>
{
    private readonly LOHSiteDriver _driver;
    private LandingPage Page { get; init; }

    public LandingPageTests(LOHSiteDriver driver)
        : base(driver, page => page)
    {
        _driver = driver;
        _driver.Reset();

        Page = new LandingPage(_driver.WebDriver);
    }

    [Fact]
    public async Task CheckImages()
    {
        await _driver.EnsureNoBrokenImages();
    }

    [Fact]
    public async Task CanSignUp()
    {
        var accountName = $"test-{Guid.NewGuid()}";
        var signUpPage = Page.ClickSignUp();
        signUpPage.Fill(accountName, null, accountName, accountName, $"{accountName}@test.landsofhope.com", null, true);
        var optionsPage = signUpPage.ClickSignUp().AsT0;

        optionsPage.SetDOB(AccountOptionsPage.Month.January, 1, 2016);
        optionsPage.SetCountryCode(AccountOptionsPage.CountryCode.CA);

        var charactersPage = optionsPage.ClickSaveChanges().AsT0;
    }
}