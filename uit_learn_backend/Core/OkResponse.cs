using uit_learn_backend.Constant;

namespace uit_learn_backend.Core
{
    public record OkResponse<T> : BaseCustomResponse<T>
    {
        public OkResponse(T data) : base(StatusCode.Ok, MessageStatusCode.Ok, data)
        {
        }
        public OkResponse(string message, T data) : base(StatusCode.Ok, message, data)
        {
        }
        public OkResponse(string message, int statusCode, T data) : base(statusCode, message, data)
        {
        }
    }
}
