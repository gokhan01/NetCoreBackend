using Serilog;

namespace NetCoreBackend.Core.CrossCuttingConcerns.Logging.SeriLog.Loggers
{
    public class SerilogFileLogger : SerilogServiceBase
    {
        public SerilogFileLogger()
        {
            _logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("C://Log//myapp.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
    }
}
