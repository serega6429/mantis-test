using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;

namespace mantis_test
{
    [TestFixture]
    public class AccountCreationTest : TestBase
    {
        [Test]
        public void TestAccountCreation()
        {
            AccountData account = new AccountData()
            {
                Name = "testUser",
                Password = "password",
                Email = "testuser@localhost.localdomain"
            };
            app.Registration.Register(account);
        }
    }
}
