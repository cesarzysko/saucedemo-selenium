namespace Core;

using Microsoft.Extensions.Logging;

public static class FlowLogger
{
    private static readonly ThreadLocal<ILogger> _logger = new();

    public static ILogger Logger
        => _logger.Value
           ?? throw new InvalidOperationException("Logger not initialized for this thread.");

    public static void Initialize(ILoggerProvider loggerProvider)
    {
        if (_logger.Value != null)
        {
            Logger.LogWarning("Initialize was called but a logger has already been initialized for this thread.");
            return;
        }

        _logger.Value = LoggerFactory
            .Create(builder => builder.AddProvider(loggerProvider))
            .CreateLogger("saucedemo");
    }
}
