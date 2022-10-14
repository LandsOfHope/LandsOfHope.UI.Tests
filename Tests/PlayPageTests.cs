using LandsOfHope.UI.Tests.Pages;

namespace LandsOfHope.UI.Tests.Tests
{
    public class PlayPageTests : PageTest<PlayPage>
    {
        private static PlayPage SetUp(LandingPage landingPage, AccountInfo account)
            => landingPage
                .ClickSignUp()
                .Fill(account)
                .ClickSignUp().AsT0
                .SetDOB(AccountOptionsPage.Month.January, 1, 2016)
                .ClickSaveChanges().AsT0
                .ClickNewCharacter()
                .WithPopup(
                    createCharacterPage =>
                    {
                        createCharacterPage
                            .SetProfession(CreateCharacterPage.Profession.Fighter)
                            .SetCharacterName(account.AccountName)
                            .SetPicture(CreateCharacterPage.Ethnicity.Caucasian, CreateCharacterPage.Sex.Male, 0)
                            .SetAcceptTOS(true)
                            .SetHopeServer();
                    }
                ).Close()
                .SetSelectedCharacter(0)
                .SetUsePopupWindow(false)
                .ClickPlay();

        public PlayPageTests(LOHSiteDriver driver)
            : base(driver, SetUp)
        {

        }
    }
}
