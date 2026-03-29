namespace Core;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

public static class Config
{
    private const string UrlLabel = "Url";
    private const string TimeoutSecondsLabel = "TimeoutSeconds";
    private const string PollingIntervalSecondsLabel = "PollingIntervalSeconds";
    private const string HeadlessLabel = "Headless";
    private const double DefaultTimeoutSeconds = 5.0;
    private const double DefaultPollingIntervalSeconds = 0.25;

    private static readonly IConfiguration _conf = InitConfiguration();

    private static bool? _urlValid;
    private static bool? _timeoutSecondsValid;
    private static bool? _pollingIntervalSecondsValid;
    private static bool? _headlessValid;

    static Config()
    {
        Url = GetUrl();
        TimeoutSeconds = GetTimeoutSeconds();
        PollingIntervalSeconds = GetPollingIntervalSeconds();
        Headless = GetHeadless();
    }

    public static string Url { get; private set; }

    public static double TimeoutSeconds { get; private set; }

    public static double PollingIntervalSeconds { get; private set; }

    public static bool Headless { get; private set; }

    public static void Validate()
    {
        ValidateUrl();
        ValidateTimeoutSeconds();
        ValidatePollingIntervalSeconds();
        ValidateHeadless();
    }

    private static IConfiguration InitConfiguration()
    {
        return new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .Build();
    }

    private static string GetUrl()
    {
        string? url = _conf.Get<string>(UrlLabel);
        if (!string.IsNullOrEmpty(url))
        {
            return url;
        }

        return string.Empty;
    }

    private static double GetTimeoutSeconds()
    {
        if (_conf.Get<double>(TimeoutSecondsLabel) is var t and > 0)
        {
            return t;
        }

        return DefaultTimeoutSeconds;
    }

    private static double GetPollingIntervalSeconds()
    {
        if (_conf.Get<double>(PollingIntervalSecondsLabel) is var p and > 0)
        {
            return p;
        }

        return DefaultPollingIntervalSeconds;
    }

    private static bool GetHeadless()
    {
        return _conf.Get<bool>(HeadlessLabel);
    }

    private static void ValidateUrl()
    {
        _urlValid ??= _conf.GetSection(UrlLabel).Exists() &&
                      !string.IsNullOrEmpty(_conf.Get<string?>(UrlLabel));
        if (!_urlValid.Value)
        {
            FlowLogger.Logger.LogWarning("No valid URL could be found in the config file. Defaulting to empty URL.");
        }
    }

    private static void ValidateTimeoutSeconds()
    {
        _timeoutSecondsValid ??= _conf.GetSection(TimeoutSecondsLabel).Exists() &&
                                 _conf.Get<double>(TimeoutSecondsLabel) > 0;
        if (!_timeoutSecondsValid.Value)
        {
            FlowLogger.Logger.LogWarning(
                "No valid timeout seconds could be found in the config file. Defaulting to \"{Seconds}\".",
                DefaultTimeoutSeconds);
        }
    }

    private static void ValidatePollingIntervalSeconds()
    {
        _pollingIntervalSecondsValid ??= _conf.GetSection(PollingIntervalSecondsLabel).Exists() &&
                                         _conf.Get<double>(PollingIntervalSecondsLabel) > 0;
        if (!_pollingIntervalSecondsValid.Value)
        {
            FlowLogger.Logger.LogWarning(
                "No valid polling interval seconds could be found in the config file. Defaulting to \"{Seconds}\".",
                DefaultPollingIntervalSeconds);
        }
    }

    private static void ValidateHeadless()
    {
        _headlessValid ??= _conf.GetSection(HeadlessLabel).Exists();
        if (!_headlessValid.Value)
        {
            FlowLogger.Logger.LogWarning("No valid headless setting could be found in the config file. Defaulting to false.");
        }
    }
}
