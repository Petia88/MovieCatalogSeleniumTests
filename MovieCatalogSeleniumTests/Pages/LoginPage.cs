using OpenQA.Selenium;
using OpenQA.Selenium.Internal;

namespace MovieCatalogSeleniumTests.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {

        }

        public string Url = BaseUrl + "/User/Login";

        public IWebElement EmailInput => driver.FindElement(By.XPath("//input[@id='form2Example17']"));
        public IWebElement PasswordInput => driver.FindElement(By.XPath("//input[@id='form2Example27']"));
        public IWebElement ButtonLoginPage => driver.FindElement(By.XPath("//button[text()='Login']"));

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }

        public void PerformLogin(string email, string password)
        {
            EmailInput.Clear();
            EmailInput.SendKeys(email);

            PasswordInput.Clear();
            PasswordInput.SendKeys(password);

            ButtonLoginPage.Click();
        }
    }
}
