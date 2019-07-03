using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_test
{
    [TestFixture]
    public class RemoveProject : AuthBase
    {
        [Test]
        public void TestRemoveProject()
        {
            IfNeedToCreateProject();
            List<ProjectData> oldList = app.Api.GetListProjects(admin);
            ProjectData projectData = oldList[0];

            app.Project.Remove(projectData);
            List<ProjectData> newList = app.Api.GetListProjects(admin);
            Assert.AreEqual(oldList.Count - 1, newList.Count);
            oldList.Remove(projectData);

            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
