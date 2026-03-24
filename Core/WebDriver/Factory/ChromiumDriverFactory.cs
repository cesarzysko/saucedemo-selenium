namespace Core.WebDriver.Factory;

using OpenQA.Selenium.Chromium;

public abstract class ChromiumDriverFactory
{
    protected static TOptions CreateOptions<TOptions>()
        where TOptions : ChromiumOptions, new()
    {
        var options = new TOptions();
        options.AddArgument("--start-maximized");
        if (Config.Headless)
        {
            options.AddArgument("--headless=new");
        }

        return options;
    }
}
