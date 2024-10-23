namespace uit_learn_backend.Core
{
    public class BadRequestError : ErrorDetail
    {
        public BadRequestError(string message) : base(Constant.StatusCode.BadRequest, message)
        {

        }
    }
}
