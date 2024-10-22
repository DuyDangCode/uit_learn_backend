using uit_learn_backend.Constant;

namespace uit_learn_backend.Core
{
    public record OkReponse<T> : BaseCustomResponse<T>
    {
        public OkReponse(T data) : base(StatusCode.Ok, MessageStatusCode.Ok, data)
        {
        }
        public OkReponse(string message, T data) : base(StatusCode.Ok, message, data)
        {
        }
        public OkReponse(string message, int statusCode, T data) : base(statusCode, message, data)
        {
        }
    }
}
