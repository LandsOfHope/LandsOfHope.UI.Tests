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
            characterPage.EnsureNoBrokenImages();
        }

        [Fact]
        public void NewCharacterStep1HasNoBrokenImages()
        {
            var popup = Page.ClickNewCharacter();
            var characterPage = popup.WithPopup(
                createCharacterPage =>
                {
                    createCharacterPage.Step1Button.Click();
                    createCharacterPage.EnsureNoBrokenImages();
                }
            ).Close();
        }

        [Theory]
        [InlineData(CreateCharacterPage.Ethnicity.Caucasian, CreateCharacterPage.Sex.Male)]
        [InlineData(CreateCharacterPage.Ethnicity.Caucasian, CreateCharacterPage.Sex.Female)]
        [InlineData(CreateCharacterPage.Ethnicity.Dark, CreateCharacterPage.Sex.Male)]
        [InlineData(CreateCharacterPage.Ethnicity.Dark, CreateCharacterPage.Sex.Female)]
        [InlineData(CreateCharacterPage.Ethnicity.Asian, CreateCharacterPage.Sex.Male)]
        [InlineData(CreateCharacterPage.Ethnicity.Asian, CreateCharacterPage.Sex.Female)]
        public void NewCharacterStep2HasNoBrokenImages(CreateCharacterPage.Ethnicity ethnicity, CreateCharacterPage.Sex sex)
        {
            var popup = Page.ClickNewCharacter();
            var characterPage = popup.WithPopup(
                createCharacterPage =>
                {
                    createCharacterPage.SetPicture(ethnicity, sex, 0);
                    createCharacterPage.EnsureNoBrokenImages();
                }
            ).Close();
        }

        [Fact]
        public void NewCharacterStep3HasNoBrokenImages()
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
                        .Step3Button.Click();
                    createCharacterPage.EnsureNoBrokenImages();
                }
            ).Close();
        }
    }
}
