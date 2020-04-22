using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreBackend.Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, bool success) : base(data, success: true)
        {
        }

        public SuccessDataResult(T data, bool success, string message) : base(data, success: true, message)
        {
        }

        public SuccessDataResult(string message) : base(default, true, message)
        {
        }
    }
}
