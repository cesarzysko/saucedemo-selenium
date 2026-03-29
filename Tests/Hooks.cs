namespace Tests;

using Core;
using Core.WebDriver;
using Core.WebDriver.Factory;
using Logging;
using TechTalk.SpecFlow;

[Binding]
public sealed class Hooks
{
    private readonly ScenarioContext _scenarioContext;

    public Hooks(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [BeforeScenario]
    public void BeforeScenario()
    {
        _scenarioContext.TryGetValue("Variant", out string browser);
        var driverType = Enum.Parse<DriverType>(browser);
        var driverFactory = WebDriverFactoryProvider.GetFactory(driverType);

        FlowLogger.Initialize(new NUnitLoggerProvider());
        Config.Validate();
        WebDriverWrapper.InitializeInstance(driverFactory);
    }

    [AfterScenario]
    public static void AfterScenario()
    {
        WebDriverWrapper.RemoveInstance();
    }
}
