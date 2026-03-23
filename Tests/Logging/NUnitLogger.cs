namespace Tests.Logging;

using Microsoft.Extensions.Logging;

public sealed class NUnitLogger(string categoryName) : ILogger
{
    public void Log<TState>(
        LogLevel logLevel,
        EventId eventId,
        TState state,
        Exception? exception,
        Func<TState, Exception?, string> formatter)
    {
        TestContext.Out.WriteLine($"[{logLevel}] [{categoryName}] {formatter(state, exception)}");
        if (exception != null)
        {
            TestContext.Out.WriteLine(exception.ToString());
        }
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return true;
    }

    public IDisposable? BeginScope<TState>(TState state)
        where TState : notnull
    {
        return null;
    }
}
