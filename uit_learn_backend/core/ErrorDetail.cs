using Newtonsoft.Json;

namespace uit_learn_backend.core
{
    public class ErrorDetail
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
