﻿namespace Core.Result.Contrete
{
    public class SuccessResult : Result
    {
        public SuccessResult() : base(true)
        {
        }

        public SuccessResult(string message) : base(message, true)
        {
        }
    }
}
