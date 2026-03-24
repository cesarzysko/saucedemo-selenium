namespace Core.WebDriver.Factory;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

internal sealed class ChromeDriverFactory
    : ChromiumDriverFactory, IWebDriverFactory
{
    public string GetBrowserName()
    {
        return "Chrome";
    }

    public IWebDriver CreateDriver()
    {
        var options = CreateOptions<ChromeOptions>();
        return new ChromeDriver(options);
    }
}
