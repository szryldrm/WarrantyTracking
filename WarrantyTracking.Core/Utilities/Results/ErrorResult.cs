using System;

namespace WarrantyTracking.Core.Utilities.Results
{
    [Serializable]
    public class ErrorResult:Result
    {
        public ErrorResult(string message) : base(false, message)
        {
        }

        public ErrorResult() : base(false)
        {
        }
    }
}