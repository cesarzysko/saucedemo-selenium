namespace Tests.Logging;

using Microsoft.Extensions.Logging;

public sealed class NUnitLoggerProvider : ILoggerProvider
{
    public ILogger CreateLogger(string categoryName)
    {
        return new NUnitLogger(categoryName);
    }

    public void Dispose()
    {
    }
}
