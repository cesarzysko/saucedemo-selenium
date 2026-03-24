namespace Core.WebDriver.Factory;

using OpenQA.Selenium;

public interface IWebDriverFactory
{
    public string GetBrowserName();

    public IWebDriver CreateDriver();
}