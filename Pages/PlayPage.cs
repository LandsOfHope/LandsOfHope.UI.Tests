﻿using OpenQA.Selenium;

namespace LandsOfHope.UI.Tests.Pages
{
    public class PlayPage : Page
    {
        public IWebElement InventoryMenuItem { get; private init; }

        public PlayPage(IWebDriver driver) : base(driver, WaitForPageUrlContains("fhlogin.asp"))
        {
            InventoryMenuItem = WebDriver.FindElement(By.Id("mnu50"));
        }
    }
}
