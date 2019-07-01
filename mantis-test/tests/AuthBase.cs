
using NUnit.Framework;

namespace mantis_test
{
    public class AuthBase : TestBase
    {
        private AccountData admin = new AccountData()
        {
            Name = "administrator",
            Password = "admin"
        };
        [TestFixtureSetUp]
        public void Login()
        {
            app.Login.LoginToSite(admin);
        }
    }
}