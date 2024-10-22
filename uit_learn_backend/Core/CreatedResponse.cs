using uit_learn_backend.Constant;

namespace uit_learn_backend.Core
{
    public record CreatedResponse<T> : BaseCustomResponse<T>
    {
        public CreatedResponse(string name, T data) : base(StatusCode.Created, MessageStatusCode.Created(name), data)
        {
        }
        public CreatedResponse(string message, int statusCode, T data) : base(statusCode, message, data)
        {
        }
    }
}
