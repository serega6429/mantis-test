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
            BASEURL = "http://localhost/mantisbt-2.21.1";
            verificationErrors = new StringBuilder();
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            Login = new LoginHelper(this);
            Navigator = new NavigatorHelper(this);
            Project = new ProjectHelper(this);
            Admin = new AdminHelper(this, BASEURL);
            Api = new ApiHelper(this);
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
                app.Value.Driver.Url = app.Value.BASEURL + "/login_page.php";
                //app.Value.Navigator.OpenLoginPage();
            }
            return app.Value;
        }

        public IWebDriver Driver { get; }
        public string BASEURL { get; set; }
        public RegistrationHelper Registration {get; set;}
        public FtpHelper Ftp { get; set; }
        public LoginHelper Login { get; set; }
        public NavigatorHelper Navigator { get; set; }
        public ProjectHelper Project { get;  set; }
        public AdminHelper Admin { get; set; }
        public ApiHelper Api { get; set; }
    }
}
