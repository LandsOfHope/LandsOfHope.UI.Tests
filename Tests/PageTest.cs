using LandsOfHope.UI.Tests.Pages;

namespace LandsOfHope.UI.Tests.Tests
{
    public delegate TPage SetUpDelegate<TPage>(LandingPage landingPage, AccountInfo accountInfo);

    public abstract class PageTest<TPage>
        : IClassFixture<LOHSiteDriver>, IDisposable
        where TPage : Page
    {
        protected LOHSiteDriver Driver { get; private init; }
        protected TPage Page { get; private init; }
        protected AccountInfo AccountInfo { get; private init; }

        protected PageTest(LOHSiteDriver driver, SetUpDelegate<TPage> setup, AccountInfo? account = null)
        {
            AccountInfo = account ?? TestHelper.GenerateAccountInformation();

            Driver = driver;
            Driver.Reset();
            Page = setup(new LandingPage(Driver.WebDriver), AccountInfo);
        }

        public void Dispose()
        {
            Driver.Reset();
        }

        [Fact]
        public async Task HasNoBrokenImages()
        {
            await Page.EnsureNoBrokenImagesAsync();
        }
    }
}
