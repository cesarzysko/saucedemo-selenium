namespace Core.WebDriver.Factory;

using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

internal sealed class EdgeDriverFactory
    : ChromiumDriverFactory, IWebDriverFactory
{
    public string GetBrowserName()
    {
        return "Edge";
    }

    public IWebDriver CreateDriver()
    {
        var options = CreateOptions<EdgeOptions>();
        return new EdgeDriver(options);
    }
}
