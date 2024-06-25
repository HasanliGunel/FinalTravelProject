﻿namespace Core.Result.Contrete
{
    public class SuccessDataResult<T> : DataResult<T>
    {

        public SuccessDataResult(T data) : base(data, true)
        {
        }

        

        public SuccessDataResult(T data, string message) : base(data, message, true)
        {
        }
    }
}
