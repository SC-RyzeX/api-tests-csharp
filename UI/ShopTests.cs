using ApiTests.Ui.Pages;
using Xunit;

namespace ApiTests.Ui;

[Trait("Category", "UI")]
public class ShopTests : BaseUiTest
{
    private readonly InventoryPage _inventory;

    public ShopTests()
    {
        // Предусловие: пользователь уже залогинен
        new LoginPage(Driver).Open().Login("standard_user", "secret_sauce");
        _inventory = new InventoryPage(Driver);
    }

    [Fact]
    public void Inventory_ShowsSixProducts()
    {
        Assert.Equal(6, _inventory.ProductCount);
    }

    [Fact]
    public void AddToCart_UpdatesBadgeAndCart()
    {
        _inventory.AddBackpackToCart();
        Assert.Equal("1", _inventory.CartBadgeText);

        var cart = _inventory.OpenCart();
        Assert.Contains("Sauce Labs Backpack", cart.ItemNames);
    }
}