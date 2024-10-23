using Newtonsoft.Json;

namespace uit_learn_backend.Core
{
    public class ErrorDetail
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        public ErrorDetail()
        {

        }

        public ErrorDetail(int statusCode, string? message)
        {
            StatusCode = statusCode;
            Message = message;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
