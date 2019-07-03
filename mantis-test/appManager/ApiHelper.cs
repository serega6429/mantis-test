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

        public void CreateIssue(AccountData account, 
            ProjectData project, IssueData issueData)
        {
            Mantis.MantisConnectPortTypeClient client =
                new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new Mantis.ObjectRef();
            issue.project.id = project.Id;
            client.mc_issue_add(account.Name, account.Password, issue);

        }

        public void CreateProject(AccountData admin, ProjectData projectData)
        {
            Mantis.MantisConnectPortTypeClient client =
                new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData project = new Mantis.ProjectData();
            project.name = projectData.Name;
            client.mc_project_add(admin.Name, admin.Password, project);
        }

        public List<ProjectData> GetListProjects(AccountData admin)
        {
            List<ProjectData> allProjects = new List<ProjectData>();
            Mantis.MantisConnectPortTypeClient client =
                new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] projects = client.
                mc_projects_get_user_accessible(admin.Name, admin.Password);
            foreach (Mantis.ProjectData project in projects)
            {
                allProjects.Add(new ProjectData()
                {
                    Name = project.name,
                    Id = project.id
                });
            }

            return allProjects;

        }
    }
}
