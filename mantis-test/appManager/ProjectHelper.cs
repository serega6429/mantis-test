using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_test
{
    public class ProjectHelper : HelperBase
    {
        public ProjectHelper(ApplicationManager manager) : base(manager) { }

        public void Create(ProjectData project)
        {
            manager.Navigator.OpenManagmentProjectsPage();
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            driver.FindElement(By.Id("project-name")).Click();
            driver.FindElement(By.Id("project-name")).Clear();
            driver.FindElement(By.Id("project-name")).SendKeys(project.Name);
            driver.FindElement(By.
                XPath("//input[@value='Добавить проект']")).Click();
            driver.FindElement(By.LinkText("Продолжить")).Click();
        }

        public void Remove(ProjectData projectRemove)
        {
            manager.Navigator.OpenManagmentProjectsPage();
            driver.FindElement(By.
                XPath("(//a[contains(text(),'" + projectRemove.Name + "')])[2]")).
                Click();
            driver.FindElement(By.
                XPath("//input[@value='Удалить проект']")).Click();
            driver.FindElement(By.
                XPath("//input[@value='Удалить проект']")).Click();

        }

        public List<ProjectData> GetList()
        {
            List<ProjectData> projectList = new List<ProjectData>();
            driver.FindElement(By.
                XPath("//li[@id='dropdown_projects_menu']/a/i")).Click();
            ICollection<IWebElement> elements = driver.
                FindElements(By.XPath("//div[@class = 'scrollable-menu']" +
                "//a[@class= 'project-link']"));

            foreach (IWebElement element in elements)
            {
                projectList.Add(new ProjectData()
                {
                    Name = element.Text
                });
            }
            return projectList;

        }

    }
}
