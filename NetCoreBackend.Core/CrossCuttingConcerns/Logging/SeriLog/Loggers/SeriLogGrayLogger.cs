using Serilog;
using Serilog.Sinks.Graylog;

namespace NetCoreBackend.Core.CrossCuttingConcerns.Logging.SeriLog.Loggers
{
    public class SeriLogGrayLogger : SerilogServiceBase
    {
        public SeriLogGrayLogger()
        {
            _logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Graylog(new GraylogSinkOptions
                {
                    HostnameOrAddress = "localhost",
                    Port = 12201,
                    Facility = "GraylogNetCore",
                    //TransportType = Serilog.Sinks.Graylog.Core.Transport.TransportType.Tcp,
                })
                .CreateLogger();
        }
    }
}
