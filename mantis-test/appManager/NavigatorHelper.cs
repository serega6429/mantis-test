using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_test
{
    public class NavigatorHelper : HelperBase
    {
        public NavigatorHelper(ApplicationManager manager) : base(manager) { }
        public void OpenManagmentProjectsPage()
        {
            OpenManagmentPage();
            driver.FindElement(By.
                XPath("//a[contains(text(),'Управление проектами')]")).Click();
        }
        public void OpenManagmentPage()
        {
            driver.FindElement(By.
                XPath("(.//*[normalize-space(text()) and normalize-space(.)='Статистика'])[1]/following::span[1]")).Click();
        }
    }
}
