using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_test
{
    [TestFixture]
    public class AddNewIssue : TestBase
    {
        [Test]
        public void AddNewIssueTest()
        {
            IssueData issue = new IssueData() {
            Summary = "aaaaa",
            Description = "add asdasd dada",
            Category = "1", 
            };
            app.Api.CreateIssue(admin, issue);
        }

    }
}
