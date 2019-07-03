using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace mantis_test
{

    [TestFixture]
    public class CreateProject : AuthBase
    {
        [Test]
        public void TestCreateProject()
        {
            ProjectData projectData = new ProjectData()
            {
                Name = DateTime.Now.Second.ToString()
            };
            List<ProjectData> oldList = app.Api.GetListProjects(admin);
            app.Project.Create(projectData);
            List<ProjectData> newList = app.Api.GetListProjects(admin);

            oldList.Add(projectData);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }

    }
}