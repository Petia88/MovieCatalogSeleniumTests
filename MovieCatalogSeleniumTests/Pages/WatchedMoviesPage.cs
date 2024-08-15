using OpenQA.Selenium;

namespace MovieCatalogSeleniumTests.Pages
{
    public class WatchedMoviesPage : BasePage
    {
        public WatchedMoviesPage(IWebDriver driver) : base(driver)
        {
        }

        public string Url = BaseUrl + "/Catalog/Watched#watched";

        public IReadOnlyCollection<IWebElement> PageIndexes => driver.FindElements(By.XPath("//a[@class='page-link']"));
        public IReadOnlyCollection<IWebElement> AllWatchedMovies => driver.FindElements(By.XPath("//div[@class='col-lg-4']"));

        public IWebElement LastWatchedMovieTitle => AllWatchedMovies.Last().FindElement(By.XPath(".//h2"));

        public void NavigateToLastPage()

        {
            PageIndexes.Last().Click();
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }
    }
}
