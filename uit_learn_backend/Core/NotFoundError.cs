namespace uit_learn_backend.Core
{
    public class NotFoundError : ErrorDetail
    {
        public NotFoundError(string name) : base(Constant.StatusCode.NotFound, Constant.MessageStatusCode.NotFound(name)) { }
    }
}
