using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Royale.Pages;

namespace Royale.Test;

public class CardTests
{
    IWebDriver driver;

    [SetUp]
    public void BeforeEach()
    {
        driver = new ChromeDriver(Path.GetFullPath(@"../../../../" + "_drivers"));
        driver.Url = "https://statsroyal.com";
    }

    [TearDown]
    public void AfterEach(){
        //driver.Quit();
    }

    [Test]
    public void Ice_Spirit_is_on_cards_page()
    {
        var cardsPage = new CardsPage(driver);
        //2. click stats link in the header nav
        cardsPage.Goto().GetCardByName("Ice spirit");
        // driver.FindElement(By.CssSelector("a[href='/cards']"));
        //3. Assert that ice spirit is displayed
        var iceSpirit = driver.FindElement(By.CssSelector("a[href*='Ice+Spirit']"));
        Assert.That(iceSpirit.Displayed);

    }

    public void Ice_Spirit_headers_are_correct_on_card_details_page()
    {
        //1. got to stats royale
        
        //2. click stats link in the header nav
        driver.FindElement(By.CssSelector("a[href='/cards']"));
        //3. Assert that ice spirit is displayed
       driver.FindElement(By.CssSelector("a[href*='Ice+Spirit']")).Click();

       var cardname = driver.FindElement(By.ClassName("class*='cardName'")).Text;
       var cardCategories = driver.FindElement(By.CssSelector(".card__rarity")).Text.Split(", ");
       var cardType = cardCategories[0];
       var cardArena = cardCategories[1];
       var cardRarity = driver.FindElement(By.CssSelector(".card__common")).Text;

       Assert.AreEqual("Ice Spirit", cardname);
       Assert.AreEqual("Troop", cardType);
       Assert.AreEqual("Arena 8", cardArena);
       Assert.AreEqual("Common", cardRarity);
        



    }
}