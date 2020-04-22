using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreBackend.Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(bool success) : base(true)
        {
        }

        public SuccessResult(bool success, string message) : base(true, message)
        {
        }
    }
}
