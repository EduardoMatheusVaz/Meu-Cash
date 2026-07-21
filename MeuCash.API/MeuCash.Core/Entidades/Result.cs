namespace MeuCash.Core.Entidades
{
    public class Result
    {
        public Result(bool isSuccess = true, string message = "")
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public bool IsSuccess { get; private set; }
        public string Message { get; private set; }

        public static Result Sucesso() => new();
        public static Result Erro(string message)
            => new(false, message);
    }

    public class Result<T> : Result
    {
        public Result(T? data, bool isSuccess = true, string message = "")
            : base(isSuccess, message)
        {
            Data = data;
        }

        public T? Data { get; private set; }

        public static Result<T> Success(T data) 
            => new(data);

        public static Result<T> Error(string message) 
            => new(default, false, message);
    }
}
