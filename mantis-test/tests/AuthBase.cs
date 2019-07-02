
using NUnit.Framework;

namespace mantis_test
{
    public class AuthBase : TestBase
    {
        
        [TestFixtureSetUp]
        public void Login()
        {
            app.Login.LoginToSite(admin);
        }
    }
}