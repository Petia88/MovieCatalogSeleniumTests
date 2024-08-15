using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace MovieCatalogSeleniumTests.Tests
{
    public class MovieCatalogSeleniumTests : BaseTest
    {
        private string lastMovieTitle;
        private string lastMovieDescription;


        [Test, Order(1)]
        public void AddMovieWithoutTitleTest()
        {
            addMoviePage.OpenPage();

            addMoviePage.TitleInput.Clear();

            Actions actions = new Actions(driver);
            var addButtonDiv = driver.FindElement(By.XPath("//div[@class='pt-1 mb-4']"));
            actions.ScrollToElement(addButtonDiv).Perform();
            addMoviePage.AddMovieButton.Click();

            addMoviePage.AssertEmptyTitleMessage();
        }

        [Test, Order(2)]
        public void AddMovieWithoutDescriptionTest()
        {
            lastMovieTitle = GenerateRandomTitle();
            addMoviePage.OpenPage();

            addMoviePage.TitleInput.Clear();
            addMoviePage.TitleInput.SendKeys(lastMovieTitle);

            Actions actions = new Actions(driver);
            var addButtonDiv = driver.FindElement(By.XPath("//div[@class='pt-1 mb-4']"));
            actions.ScrollToElement(addButtonDiv).Perform();
            addMoviePage.AddMovieButton.Click();

            addMoviePage.AssertEmptyDescriptionMessage();
        }

        [Test, Order(3)]
        public void AddMovieWithRandomTitleTest()
        {
            lastMovieTitle = GenerateRandomTitle();
            lastMovieDescription = GenerateRandomDescription();
            addMoviePage.OpenPage();

            addMoviePage.TitleInput.Clear();
            addMoviePage.TitleInput.SendKeys(lastMovieTitle);

            addMoviePage.DescriptionInput.Clear();
            addMoviePage.DescriptionInput.SendKeys(lastMovieDescription);

            Actions actions = new Actions(driver);
            var addButtonDiv = driver.FindElement(By.XPath("//div[@class='pt-1 mb-4']"));
            actions.ScrollToElement(addButtonDiv).Perform();
            addMoviePage.AddMovieButton.Click();

            allMoviesPage.NavigateToLastPage();

            Assert.That(allMoviesPage.LastCreatedMovieTitle.Text.Trim(), Is.EqualTo(lastMovieTitle), "The title is not as expected");
        }

        [Test, Order(4)]
        public void EditLastAddedMovieTest()
        {
            lastMovieTitle = GenerateRandomTitle() + "EDITED";

            allMoviesPage.OpenPage();
            allMoviesPage.NavigateToLastPage();
            allMoviesPage.LastCreatedMovieEditButton.Click();

            editMoviePage.TitleInput.Clear();
            editMoviePage.TitleInput.SendKeys(lastMovieTitle);

            Actions actions = new Actions(driver);
            var addButtonDiv = driver.FindElement(By.XPath("//div[@class='pt-1 mb-4']"));
            actions.ScrollToElement(addButtonDiv).Perform();
            editMoviePage.EditMovieButton.Click();

            editMoviePage.AssertEditedMovieMessage();
        }

        [Test, Order(5)]
        public void MarkLastAddedMovieAsWatchedTest()
        {
            allMoviesPage.OpenPage();
            allMoviesPage.NavigateToLastPage();
            allMoviesPage.LastCreatedMovieMarkedAsWatchedButton.Click();

            watchedMoviesPage.OpenPage();
            watchedMoviesPage.NavigateToLastPage();
            
            Assert.That(watchedMoviesPage.LastWatchedMovieTitle.Text.Trim(), Is.EqualTo(lastMovieTitle), "The movie was not added to watched");
        }

        [Test, Order(6)]
        public void DeleteLastAddedMovieTest()
        {
            allMoviesPage.OpenPage();
            allMoviesPage.NavigateToLastPage();
            allMoviesPage.LastCreatedMovieDeleteButton.Click();

            deletePage.YesButton.Click();

            Assert.That(deletePage.MovieDeleteMessage.Text.Trim(), Is.EqualTo("The Movie is deleted successfully!"), "The movie was not deleted");
        }
    }
}