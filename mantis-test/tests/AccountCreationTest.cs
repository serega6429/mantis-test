using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;

namespace mantis_test
{
    [TestFixture]
    public class AccountCreationTest : TestBase
    {
       [TestFixtureSetUp]
       public void setUpConfig()
        {
            app.Ftp.BackUpFile("/config_inc.php");
            using (Stream localFile = File.Open("config_inc.php", FileMode.Open))
            {
                app.Ftp.Upload("/config_inc.php", localFile);
            }
        }
        [Test]
        public void TestAccountCreation()
        {
            AccountData account = new AccountData()
            {
                Name = "testUser",
                Password = "password",
                Email = "testuser@localhost.localdomain"
            };
            List<AccountData> accounts = app.Admin.GetAllAccounts();
            AccountData existingAcc = accounts.Find(x => x.Name == account.Name);
            if(existingAcc != null)
            {
                app.Admin.DeleteAccount(existingAcc);
            }
            app.Registration.Register(account);
        }
        [TestFixtureTearDown]
        public void restoreConfig()
        { 
            app.Ftp.RestoreBackUpFile("/config_inc.php");
        }
    }
}
