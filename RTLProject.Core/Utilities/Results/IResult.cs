using System;
using System.Collections.Generic;
using System.Text;

namespace RTL.Core.Utilities.Results
{
    public interface IResult
    {
        bool Success { get; }

        string Message { get; }


    }
}
