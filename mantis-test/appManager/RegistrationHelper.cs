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
            FillRegistrationForm(account);
            SubmitRegistration();
        }

        private void OpenRegistartionForm()
        {
            driver.FindElement(By.XPath("//div[@class='toolbar center']//a")).Click();
        }

        private void SubmitRegistration()
        {
            //driver.FindElement(By.Name("signup_token")).FindElement(By.) .Click();
        }

        private void FillRegistrationForm(AccountData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.Name("email")).SendKeys(account.Email);
        }

        private void OpenMainPage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.21.1/login_page.php"; 
        }
    }
}
