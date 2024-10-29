namespace uit_learn_backend.Core
{
    public class Result<T>
    {
        public bool IsError { get; set; } = false;
        public string? ErrorMessage { get; set; }
        public T? Value { get; set; }
        public static Result<T> Error(string errorMessage)
        {
            return new Result<T>
            {
                IsError = true,
                ErrorMessage = errorMessage
            };
        }

        public static Result<T> Success(T value)
        {
            return new Result<T>
            {
                Value = value
            };
        }
    }
}
