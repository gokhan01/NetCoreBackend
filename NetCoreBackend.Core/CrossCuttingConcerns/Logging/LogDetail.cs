using System.Collections.Generic;

namespace NetCoreBackend.Core.CrossCuttingConcerns.Logging
{
    public class LogDetail
    {
        public string MethodName { get; set; }
        public List<LogParameter> LogParameters { get; set; }        
    }
}
