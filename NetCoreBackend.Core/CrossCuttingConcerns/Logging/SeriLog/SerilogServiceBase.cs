using Serilog;

namespace NetCoreBackend.Core.CrossCuttingConcerns.Logging.SeriLog
{
    public class SerilogServiceBase
    {
        protected ILogger _logger;

        public void Info(object logMessage)
        {
            _logger.Information("{@Data}", logMessage);
        }

        public void Debug(object logMessage)
        {
            _logger.Debug("{@Data}", logMessage);
        }

        public void Warning(object logMessage)
        {
            _logger.Warning("{@Data}", logMessage);
        }

        public void Fatal(object logMessage)
        {
            _logger.Fatal("{@Data}", logMessage);
        }

        public void Error(object logMessage)
        {
            _logger.Error("{@Data}", logMessage);
        }
    }
}
