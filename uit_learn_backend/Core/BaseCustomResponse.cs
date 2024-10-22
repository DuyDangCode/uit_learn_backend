namespace uit_learn_backend.Core
{
    public record BaseCustomResponse<T>(int statusCode, string message, T data);
}
