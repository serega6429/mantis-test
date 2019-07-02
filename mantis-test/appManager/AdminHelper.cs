using OpenQA.Selenium;
using SimpleBrowser.WebDriver;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace mantis_test
{
    public class AdminHelper : HelperBase
    {
        public AdminHelper(ApplicationManager manager, string baseUrl) : base(manager)
        {
            this.baseURL = baseUrl;
        }

        public List<AccountData> GetAllAccounts()
        {
            List <AccountData> accounts = new List<AccountData>();
            IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseURL + "/manage_user_page.php";
            IList<IWebElement> rows = driver.FindElements(By.
                CssSelector("table tr.row-1, tr.row-2"));
            foreach (IWebElement row in rows)
            {
                IWebElement link = row.FindElement(By.TagName("a"));
                string name = link.Text;
                string href = link.GetAttribute("href");
                Match m = Regex.Match(href, @"\d+$");
                string id = m.Value;
                accounts.Add(new AccountData()
                {
                    Name = name,
                    Id = id
                });
            }
            return accounts;

        }

        public void DeleteAccount(AccountData account)
        {
            IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseURL + "/manage_user_edit_page.php?user_id="
                + account.Id;
            driver.FindElement(By.
                CssSelector("input[value = 'Delete User']")).Click();
            driver.FindElement(By.
                CssSelector("input[value = 'Delete Account']")).Click();
        }

        private IWebDriver OpenAppAndLogin()
        {
            IWebDriver driver = new SimpleBrowserDriver();
            driver.Url = baseURL + "login_page.php";
            driver.FindElement(By.Id("username")).SendKeys("administrator");
            driver.FindElement(By.XPath("//input[@value='Войти']")).Click();
            driver.FindElement(By.Id("password")).SendKeys("password");
            driver.FindElement(By.XPath("//input[@value='Войти']")).Click();
            return driver;
        }
    }
}
