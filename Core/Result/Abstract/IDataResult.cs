﻿namespace Core.Result.Abstract
{
    public interface IDataResult<T>:IResult 
    {
        T Data { get; }
    }
}
