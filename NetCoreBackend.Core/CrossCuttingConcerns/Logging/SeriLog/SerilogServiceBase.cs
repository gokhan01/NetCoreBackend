using Serilog;

namespace NetCoreBackend.Core.CrossCuttingConcerns.Logging.SeriLog
{
    public class SerilogServiceBase
    {
        private ILogger _logger;
        public SerilogServiceBase()
        {
            _logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("C://Log//myapp.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public void Info(object logMessage)
        {
            _logger.Information("Processing {@SensorInput}", logMessage);
        }

        public void Debug(object logMessage)
        {
            _logger.Debug("Processing {@SensorInput}", logMessage);
        }

        public void Warning(object logMessage)
        {
            _logger.Warning("Processing {@SensorInput}", logMessage);
        }

        public void Fatal(object logMessage)
        {
            _logger.Fatal("Processing {@SensorInput}", logMessage);
        }

        public void Error(object logMessage)
        {
            _logger.Error("Processing {@SensorInput}", logMessage);
        }
    }
}
