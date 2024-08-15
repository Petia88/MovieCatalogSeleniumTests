using OpenQA.Selenium;

namespace MovieCatalogSeleniumTests.Pages
{
    public class DeletePage : BasePage
    {
        public DeletePage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement YesButton => driver.FindElement(By.XPath("//button[@class='btn warning']"));

        public IWebElement MovieDeleteMessage => driver.FindElement(By.XPath("//div[@class='toast-message']"));
    }
}
