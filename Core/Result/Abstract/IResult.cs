﻿namespace Core.Result.Abstract
{
    public interface IResult
    {
        string Message {  get; }
        bool IsSuccess { get; }
    }
}
