using OpenQA.Selenium;

namespace ApiTests.Ui.Pages;

public class CartPage
{
    private readonly IWebDriver _driver;

    public CartPage(IWebDriver driver) => _driver = driver;

    public List<string> ItemNames =>
        _driver.FindElements(By.ClassName("inventory_item_name"))
               .Select(e => e.Text)
               .ToList();
}