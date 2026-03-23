namespace Core.WebDriver.Factory;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

internal sealed class ChromeDriverFactory
    : ChromiumDriverFactory
{
    public override string GetBrowserName()
    {
        return "Chrome";
    }

    public override IWebDriver CreateDriver()
    {
        var options = CreateOptions<ChromeOptions>();
        return new ChromeDriver(options);
    }
}
