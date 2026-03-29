namespace Core.WebDriver.Factory;

public static class WebDriverFactoryProvider
{
    public static IWebDriverFactory GetFactory(DriverType driverType)
    {
        return driverType switch
        {
            DriverType.Chrome => new ChromeDriverFactory(),
            DriverType.Edge => new EdgeDriverFactory(),
            _ => throw new ArgumentOutOfRangeException(nameof(driverType), driverType, null)
        };
    }
}