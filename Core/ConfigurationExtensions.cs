namespace Core;

using Microsoft.Extensions.Configuration;

internal static class ConfigurationExtensions
{
    public static T? Get<T>(this IConfiguration conf, string sectionName)
    {
        return conf.GetSection(sectionName).Get<T>();
    }
}
