﻿using NUnit.Framework;
using System;
using System.Text;

namespace mantis_test
{
    public class TestBase
    {
        protected AccountData admin = new AccountData()
        {
            Name = "administrator",
            Password = "admin"
        };
        protected ApplicationManager app;
        public static Random rnd = new Random();
        public static bool PERFOM_LONG_UI_CHECK = true;

        [TestFixtureSetUp]
        public void SetupApplicationManger()
        {
            app = ApplicationManager.GetInstanse();
        }

        public static string GenerateRandomStrring(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder bld = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                bld.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 65)));
            }
            return bld.ToString();
        }
        protected void IfNeedToCreateProject()
        {
            if (app.Api.GetListProjects(admin).Count == 0)
            {
                ProjectData projectData = new ProjectData()
                {
                    Name = DateTime.Now.Second.ToString()
                };
                app.Api.CreateProject(admin, projectData);
            }
        }
    }
}
