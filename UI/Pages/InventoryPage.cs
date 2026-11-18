using OpenQA.Selenium;

namespace ApiTests.Ui.Pages;

public class InventoryPage
{
    private readonly IWebDriver _driver;

    public InventoryPage(IWebDriver driver) => _driver = driver;

    public string Title => _driver.FindElement(By.ClassName("title")).Text;

    public int ProductCount =>
        _driver.FindElements(By.ClassName("inventory_item")).Count;

    public void AddBackpackToCart() =>
        _driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack")).Click();

    public string CartBadgeText =>
        _driver.FindElement(By.ClassName("shopping_cart_badge")).Text;

    public CartPage OpenCart()
    {
        _driver.FindElement(By.ClassName("shopping_cart_link")).Click();
        return new CartPage(_driver);
    }
}