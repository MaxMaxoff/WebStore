using System.IO;
using System.Reflection;
using Microsoft.Extensions.Logging;

namespace WebStore.Logger
{
    public static class Log4NetExtensions
    {
        public static ILoggerFactory AddLog4Net(
            this ILoggerFactory Factory,
            string configFileName = "log4net.config")
        {
            if (!Path.IsPathRooted(configFileName))
            {
                var assembly = Assembly.GetEntryAssembly();
                var dir = Path.GetDirectoryName(assembly.Location);
                configFileName = Path.Combine(dir, configFileName);
            }

            Factory.AddProvider(new Log4NetLoggerProvider(configFileName));
            return Factory;
        }
    }
}
