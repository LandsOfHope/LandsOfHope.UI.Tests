using LandsOfHope.UI.Tests.Pages;

namespace LandsOfHope.UI.Tests.Tests
{
    public class CharacterPageTests : PageTest<CharacterPage>
    {
        private static CharacterPage SetUp(LandingPage landingPage, AccountInfo account)
        {
            return landingPage
                .ClickSignUp()
                .Fill(account)
                .ClickSignUp().AsT0
                .SetDOB(AccountOptionsPage.Month.January, 1, 2016)
                .ClickSaveChanges().AsT0;
        }

        public CharacterPageTests(LOHSiteDriver driver) : base(driver, SetUp)
        {

        }

        [Fact]
        public void CanCreateCharacter()
        {
            var popup = Page.ClickNewCharacter();
            var characterPage = popup.WithPopup(
                createCharacterPage =>
                {
                    createCharacterPage
                        .SetProfession(CreateCharacterPage.Profession.Fighter)
                        .SetCharacterName(AccountInfo.AccountName)
                        .SetPicture(CreateCharacterPage.Ethnicity.Caucasian, CreateCharacterPage.Sex.Male, 0)
                        .SetAcceptTOS(true)
                        .SetHopeServer();
                }
            ).Close();

            Assert.Equal(1, characterPage.SelectableCharacterRadioButtons.Count);
        }
    }
}
