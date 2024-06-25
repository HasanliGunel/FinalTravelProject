using Core.Result.Abstract;

namespace Core.Result.Contrete
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, bool isSuccess) : base(isSuccess)
        {
            Data = data;
        }

        public DataResult(T data, string message, bool isSuccess) : base(message, isSuccess)
        {
            Data = data;
        }

        public T Data { get; }
    }
}
