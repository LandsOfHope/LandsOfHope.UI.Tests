using OpenQA.Selenium;

namespace LandsOfHope.UI.Tests.Pages
{
    public class CreateCharacterPage : Page
    {
        public IWebElement Step1Button { get; init; }
        public IWebElement Step2Button { get; init; }
        public IWebElement Step3Button { get; init; }
        public IWebElement FinishButton { get; init; }

        public enum Profession
        {
            Fighter = 0,
            Archer = 1,
            Rogue = 2,
            Caster = 3,
            Healer = 4,
            Animator = 5,
            Apprentice = 6,
            Mercenary = 7
        }

        public enum Ethnicity
        {
            Caucasian = 0,
            Dark = 1,
            Asian = 2
        }

        public enum Sex
        {
            Male = 0,
            Female = 1
        }

        public CreateCharacterPage(IWebDriver driver)
            : base(driver, WaitForUniqueElementVisible(By.CssSelector("a[title=\"Step 1\"]")))
        {
            Step1Button = WebDriver.FindElement(By.CssSelector("a[title=\"Step 1\"]"));
            Step2Button = WebDriver.FindElement(By.CssSelector("a[title=\"Step 2\"]"));
            Step3Button = WebDriver.FindElement(By.CssSelector("a[title=\"Step 3\"]"));
            FinishButton = WebDriver.FindElement(By.CssSelector("a[title=\"Finish\"]"));
        }

        public CreateCharacterPage SetProfession(Profession profession)
        {
            Step1Button.Click();
            WebDriver.FindElement(By.Id($"p{(int)profession}")).Click();

            return new CreateCharacterPage(WebDriver);
        }

        public CreateCharacterPage SetCharacterName(string name)
        {
            Step2Button.Click();
            var charName = WebDriver.FindElement(By.Id("CN2"));
            charName.Clear();
            charName.SendKeys(name);

            return new CreateCharacterPage(WebDriver);
        }

        public CreateCharacterPage SetPicture(Ethnicity ethnicity, Sex sex, Index pictureIndex)
        {
            if (pictureIndex.IsFromEnd)
                throw new NotImplementedException();

            Step2Button.Click();
            var ethnicityElements = WebDriver.FindElements(By.CssSelector("input[id=\"Ethnicx\"]"));
            ethnicityElements[(int)ethnicity].Click();
            var sexElements = WebDriver.FindElements(By.CssSelector($"input[id=\"Sexx\"]"));
            sexElements[(int)sex].Click();
            WebDriver.FindElement(By.CssSelector($"#PictureBox td:nth-child({pictureIndex.Value + 1})")).Click();

            return new CreateCharacterPage(WebDriver);
        }

        public CreateCharacterPage SetAcceptTOS(bool acceptTOS)
        {
            Step2Button.Click();
            var tos = WebDriver.FindElement(By.Id("tosx"));
            if (tos.GetAttribute("checked") != acceptTOS.ToString())
                tos.Click();

            return new CreateCharacterPage(WebDriver);
        }

        public CreateCharacterPage SetHopeServer()
        {
            Step3Button.Click();
            WebDriver.FindElement(By.CssSelector("img[alt=\"Pick Hope\"]")).Click();

            return new CreateCharacterPage(WebDriver);
        }
    }
}
