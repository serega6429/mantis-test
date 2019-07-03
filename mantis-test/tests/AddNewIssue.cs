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
            IfNeedToCreateProject();
            ProjectData project = app.Api.GetListProjects(admin)[0];
            IssueData issue = new IssueData() {
            Summary = "aaaaa",
            Description = "add asdasd dada",
            Category = "General", 
            };
            app.Api.CreateIssue(admin, project, issue);
        }

    }
}
