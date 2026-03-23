namespace Core.WebDriver.Factory;

using OpenQA.Selenium;

public abstract class WebDriverFactory
{
    protected const int DriverCreateRetries = 3;

    public abstract string GetBrowserName();

    public abstract IWebDriver CreateDriver();
}