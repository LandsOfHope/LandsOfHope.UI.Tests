namespace LandsOfHope.UI.Tests
{
    internal class TestHelper
    {
        public static AccountInfo GenerateAccountInformation()
        {
            var accountName = $"test-{Guid.NewGuid()}";
            return new AccountInfo
            {
                AccountName = accountName,
                AccountPassword = accountName,
                AccountEmail = $"{accountName}@test.landsofhope.com"
            };
        }
    }
}
