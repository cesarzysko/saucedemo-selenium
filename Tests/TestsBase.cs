namespace Tests;

using Core;
using Core.WebDriver;
using Core.WebDriver.Factory;
using Logging;
using Microsoft.Extensions.Logging;

public abstract class TestsBase(IWebDriverFactory driverFactory)
{
    [SetUp]
    public void SetUp()
    {
        FlowLogger.Initialize(new NUnitLoggerProvider());
        var name = TestContext.CurrentContext.Test.Name;
        var browser = driverFactory.GetBrowserName();
        FlowLogger.Logger.LogInformation("Starting test \"{TestName}\" using the \"{Browser}\" browser.", name, browser);
        Config.Validate();
        WebDriverWrapper.InitializeInstance(driverFactory);
    }

    [TearDown]
    public void TearDown()
    {
        var name = TestContext.CurrentContext.Test.Name;
        var status = TestContext.CurrentContext.Result.Outcome.Status;
        FlowLogger.Logger.LogInformation("Ending test \"{TestName}\" with the \"{TestStatus}\" outcome status.", name, status);
        WebDriverWrapper.RemoveInstance();
    }
}
