using ApiTests.Ui.Pages;
using Xunit;

namespace ApiTests.Ui;

[Trait("Category", "UI")]
public class LoginTests : BaseUiTest
{
    [Fact]
    public void ValidUser_SeesProductsPage()
    {
        new LoginPage(Driver).Open().Login("standard_user", "secret_sauce");

        Assert.Contains("inventory.html", Driver.Url);
        Assert.Equal("Products", new InventoryPage(Driver).Title);
    }

    [Theory]
    [InlineData("locked_out_user", "secret_sauce", "locked out")]
    [InlineData("standard_user", "wrong_password", "do not match")]
    [InlineData("", "secret_sauce", "Username is required")]
    public void InvalidLogin_ShowsError(string user, string pass, string expectedError)
    {
        var login = new LoginPage(Driver).Open();
        login.Login(user, pass);

        Assert.Contains(expectedError, login.ErrorText);
    }
}