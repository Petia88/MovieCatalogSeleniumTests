using OpenQA.Selenium;

namespace MovieCatalogSeleniumTests.Pages
{
    public class AllMoviesPage : BasePage
    {
        public AllMoviesPage(IWebDriver driver) : base(driver)
        {
        }

        public string Url = BaseUrl + "/Catalog/All#all";

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }

        public IReadOnlyCollection<IWebElement> PageIndexes => driver.FindElements(By.XPath("//a[@class='page-link']"));
        public IReadOnlyCollection<IWebElement> AllMovies => driver.FindElements(By.XPath("//div[@class='col-lg-4']"));

        public IWebElement LastCreatedMovieTitle => AllMovies.Last().FindElement(By.XPath(".//h2"));
        public IWebElement LastCreatedMovieEditButton => AllMovies.Last().FindElement(By.XPath(".//a[@class='btn btn-outline-success']"));
        public IWebElement LastCreatedMovieDeleteButton => AllMovies.Last().FindElement(By.XPath(".//a[@class='btn btn-danger']"));
        public IWebElement LastCreatedMovieMarkedAsWatchedButton => AllMovies.Last().FindElement(By.XPath(".//a[@class='btn btn-info']"));

        public void NavigateToLastPage()

        {
            PageIndexes.Last().Click();
        }
    }
}
