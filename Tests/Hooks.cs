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

    [BeforeFeature]
    public static void BeforeFeature()
    {
        FlowLogger.Initialize(new NUnitLoggerProvider());
    }

    [BeforeScenario]
    public void BeforeScenario()
    {
        Config.Validate();
        _scenarioContext.TryGetValue("Variant", out string browser);
        var driverType = Enum.Parse<DriverType>(browser);
        var driverFactory = WebDriverFactoryProvider.GetFactory(driverType);
        WebDriverWrapper.InitializeInstance(driverFactory);
    }

    [AfterScenario]
    public static void AfterScenario()
    {
        WebDriverWrapper.RemoveInstance();
    }
}
