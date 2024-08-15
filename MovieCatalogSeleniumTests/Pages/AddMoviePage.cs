using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Xml.Linq;

namespace MovieCatalogSeleniumTests.Pages
{
    public class AddMoviePage : BasePage
    {
        public AddMoviePage(IWebDriver driver) : base(driver)
        {
        }

        public string Url = BaseUrl + "/Catalog/Add#add";

        public IWebElement TitleInput => driver.FindElement(By.XPath("//input[@name='Title']")); 
        public IWebElement DescriptionInput => driver.FindElement(By.XPath("//textarea[@name='Description']")); 
        public IWebElement UrlInput => driver.FindElement(By.XPath("//input[@name='PosterUrl']")); 
        public IWebElement TrailerLinkInput => driver.FindElement(By.XPath("//input[@name='TrailerLink']")); 
        public IWebElement MarkAsWatched => driver.FindElement(By.XPath("//input[@name='IsWatched']")); 
        public IWebElement AddMovieButton => driver.FindElement(By.XPath("//button[@class='btn warning']"));
        
        public IWebElement MainErrorMessage => driver.FindElement(By.XPath("//div[@class='toast-message']")); 

        public void AssertEmptyTitleMessage()
        {
            Assert.That(MainErrorMessage.Text.Trim(), Is.EqualTo("The Title field is required."), "Error message was not as expected");
        }

        public void AssertEmptyDescriptionMessage()
        {
            Assert.That(MainErrorMessage.Text.Trim(), Is.EqualTo("The Description field is required."), "Error message was not as expected");
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }

    }
}
