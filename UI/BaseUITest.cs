using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ApiTests.Ui;

public abstract class BaseUiTest : IDisposable
{
    protected readonly IWebDriver Driver;

    protected BaseUiTest()
    {
        var options = new ChromeOptions();
        options.AddArgument("--window-size=1280,900");
        options.AddUserProfilePreference("credentials_enable_service", false);
        options.AddUserProfilePreference("profile.password_manager_enabled", false);

        if (Environment.GetEnvironmentVariable("HEADLESS") == "1")
            options.AddArgument("--headless=new");

        Driver = new ChromeDriver(options);
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    }

    public void Dispose()
    {
        Driver.Quit();
        Driver.Dispose();
    }
}