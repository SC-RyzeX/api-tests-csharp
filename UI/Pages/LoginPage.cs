using OpenQA.Selenium;

namespace ApiTests.Ui.Pages;

public class LoginPage
{
    private readonly IWebDriver _driver;

    public LoginPage(IWebDriver driver) => _driver = driver;

    public LoginPage Open()
    {
        _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        return this;
    }

    public void Login(string username, string password)
    {
        _driver.FindElement(By.Id("user-name")).SendKeys(username);
        _driver.FindElement(By.Id("password")).SendKeys(password);
        _driver.FindElement(By.Id("login-button")).Click();
    }

    public string ErrorText =>
        _driver.FindElement(By.CssSelector("[data-test='error']")).Text;
}