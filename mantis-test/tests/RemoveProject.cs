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
            ProjectData projectData;
            List<ProjectData> oldList = app.Project.GetList();
            if (oldList.Count == 0)
            {
                projectData = new ProjectData()
                {
                    Name = DateTime.Now.Second.ToString()
                };
                app.Project.Create(projectData);
                oldList.Add(projectData);
            }
            else
            {
                projectData = oldList[0];
            }

            app.Project.Remove(projectData);
            List<ProjectData> newList = app.Project.GetList();
            Assert.AreEqual(oldList.Count - 1, newList.Count);
            oldList.Remove(projectData);

            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
