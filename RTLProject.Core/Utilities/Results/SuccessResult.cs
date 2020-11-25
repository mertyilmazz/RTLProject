﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RTL.Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(bool success, string message) : base(true, message)
        {
        }

        public SuccessResult(bool success) : base(true)
        {

        }
    }
}
