using System;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace mantis_test
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected StringBuilder verificationErrors;
        protected string baseURL;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            Driver = new FirefoxDriver();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            BASEURL = "http://localhost/addressbook";
            verificationErrors = new StringBuilder();
            Registration = new RegistrationHelper(this);
        }

        ~ApplicationManager()
        {
            try
            {

                Driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstanse()
        {
            if (!app.IsValueCreated)
            {
                app.Value = new ApplicationManager();
                app.Value.Driver.Url = "http://localhost/mantisbt-2.21.1/login_page.php";
                //app.Value.Navigator.OpenLoginPage();
            }
            return app.Value;
        }

        public IWebDriver Driver { get; }
        public string BASEURL { get; set; }
        public RegistrationHelper Registration {get; set;}
    }
}
