namespace Core.WebDriver.Factory;

using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

internal sealed class EdgeDriverFactory
    : ChromiumDriverFactory
{
    public override string GetBrowserName()
    {
        return "Edge";
    }

    public override IWebDriver CreateDriver()
    {
        var options = CreateOptions<EdgeOptions>();
        return new EdgeDriver(options);
    }
}
