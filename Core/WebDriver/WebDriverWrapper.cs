namespace Core.WebDriver;

using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using WebDriver.Factory;

public sealed class WebDriverWrapper
{
    private static readonly ThreadLocal<WebDriverWrapper?> _instance = new();
    private static readonly TimeSpan _defaultTimeout = TimeSpan.FromSeconds(Config.TimeoutSeconds);
    private static readonly TimeSpan _defaultPollingInterval = TimeSpan.FromSeconds(Config.PollingIntervalSeconds);

    private readonly WebDriverWait _wait;

    private IWebDriver? _webDriver;

    private WebDriverWrapper(WebDriverFactory driverFactory)
    {
        _webDriver = driverFactory.CreateDriver();
        _wait = new WebDriverWait(_webDriver, _defaultTimeout)
        {
            PollingInterval = _defaultPollingInterval
        };
    }

    private IWebDriver WebDriver => _webDriver!;

    public static void InitializeInstance(WebDriverFactory driverFactory)
    {
        if (_instance.Value != null)
        {
            throw new InvalidOperationException("Driver already initialized for this thread.");
        }

        FlowLogger.Logger.LogInformation("Initializing driver.");
        _instance.Value = new WebDriverWrapper(driverFactory);
    }

    public static WebDriverWrapper GetInstance()
    {
        if (_instance.Value == null)
        {
            throw new InvalidOperationException("Driver not initialized for this thread.");
        }

        return _instance.Value;
    }

    public static void RemoveInstance()
    {
        if (_instance.Value == null)
        {
            return;
        }

        FlowLogger.Logger.LogInformation("Quitting driver.");
        _instance.Value.Quit();
        _instance.Value = null;
    }

    public void Open(string url)
    {
        WebDriver.Navigate().GoToUrl(url);
    }

    public string GetUrl()
    {
        return WebDriver.Url;
    }

    public void ClickElement(By by)
    {
        var elem = FindElement(by);
        elem.Click();
    }

    public void SetText(By by, string text)
    {
        var elem = FindElement(by);
        ClearText(elem);
        elem.SendKeys(text);
    }

    public void ClearText(By by)
    {
        var elem = FindElement(by);
        ClearText(elem);
    }

    public string GetText(By by)
    {
        var elem = FindElement(by);
        return elem.Text;
    }

    public bool DoesElementExist(By by)
    {
        try
        {
            FindElement(by);
        }
        catch
        {
            return false;
        }

        return true;
    }

    private IWebElement FindElement(By by)
    {
        var elem = _wait.Until(dr => dr.FindElement(by));
        return elem;
    }

    private void ClearText(IWebElement elem)
    {
        var actions = new Actions(WebDriver);
        actions.Click(elem)
            .KeyDown(Keys.Control)
            .SendKeys("a")
            .KeyUp(Keys.Control)
            .SendKeys(Keys.Delete)
            .Perform();
        _wait.Until(_ => string.IsNullOrEmpty(elem.GetAttribute("value")));
    }

    private void Quit()
    {
        if (_webDriver == null)
        {
            throw new InvalidOperationException("Quit was already called. The driver is invalid.");
        }

        _webDriver.Quit();
        _webDriver = null;
    }
}
