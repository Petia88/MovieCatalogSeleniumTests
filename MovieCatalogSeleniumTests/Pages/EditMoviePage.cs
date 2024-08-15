using OpenQA.Selenium;

namespace MovieCatalogSeleniumTests.Pages
{
    public class EditMoviePage : BasePage
    {
        public EditMoviePage(IWebDriver driver) : base(driver)
        {
        }

        public string Url = BaseUrl + "/Movie/Edit";

        public IWebElement TitleInput => driver.FindElement(By.XPath("//input[@name='Title']"));
        public IWebElement DescriptionInput => driver.FindElement(By.XPath("//textarea[@name='Description']"));
        public IWebElement UrlInput => driver.FindElement(By.XPath("//input[@name='PosterUrl']"));
        public IWebElement TrailerLinkInput => driver.FindElement(By.XPath("//input[@name='TrailerLink']"));
        public IWebElement MarkAsWatched => driver.FindElement(By.XPath("//input[@name='IsWatched']"));
        public IWebElement EditMovieButton => driver.FindElement(By.XPath("//button[@class='btn warning']"));

        public IWebElement EditedMovieMessage => driver.FindElement(By.XPath("//div[@class='toast-message']"));

        public void AssertEditedMovieMessage()
        {
            Assert.That(EditedMovieMessage.Text.Trim(), Is.EqualTo("The Movie is edited successfully!"), "The movie was not edited");
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }
    }
}
