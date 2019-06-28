using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_test
{
    public class RegistrationHelper : HelperBase
    {
        public RegistrationHelper(ApplicationManager manager) : base(manager) { }

        public void Register(AccountData account)
        {
            OpenMainPage();
            OpenRegistartionForm();
            FillRegistrationForm();
            SubmitRegistration();
        }

        private void OpenRegistartionForm()
        {
            driver.FindElements(By.CssSelector("span.bracket-link"))[0].Click();
        }

        private void SubmitRegistration()
        {
            throw new NotImplementedException();
        }

        private void FillRegistrationForm(AccountData account)
        {
            driver.FindElement(By.ClassName("username")).SendKeys(account.Name);
            driver.FindElement(By.ClassName("email")).SendKeys(account.Email);
        }

        private void OpenMainPage()
        {
            manager.Driver.Url = "";
        }
    }
}
