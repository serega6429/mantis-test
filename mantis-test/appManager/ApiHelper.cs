using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_test
{
    public class ApiHelper : HelperBase
    {
        public ApiHelper(ApplicationManager manager) : base(manager) { }

        public void CreateIssue(AccountData account, IssueData issueData)
        {
            Mantis.MantisConnectPortTypeClient client =
                new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            client.mc_issue_add(account.Name, account.Password, issue);

        }
    }
}
