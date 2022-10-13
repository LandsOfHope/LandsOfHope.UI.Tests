using LandsOfHope.UI.Tests.Pages;

namespace LandsOfHope.UI.Tests.Tests
{
    public abstract class PageTest<TPage>
        : IClassFixture<LOHSiteDriver>, IDisposable
        where TPage : Page
    {
        protected LOHSiteDriver Driver { get; private init; }
        protected TPage Page { get; private init; }

        protected PageTest(LOHSiteDriver driver, Func<LandingPage, TPage> setup)
        {
            Driver = driver;
            Driver.Reset();
            Page = setup(new LandingPage(Driver.WebDriver));
        }

        public void Dispose()
        {
            Driver.Reset();
        }
    }
}
