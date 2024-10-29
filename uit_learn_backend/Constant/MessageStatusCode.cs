namespace uit_learn_backend.Constant
{
    public class MessageStatusCode
    {
        public static string Ok => "Ok";
        public static string Created(string? name) => $"Create {name} successful";
        public static string Get(string? name) => $"Get {name} successful";
        public static string Update(string? name) => $"Update {name} successful";
        public static string Delete(string? name) => $"Delete {name} successful";
        public static string UnAuth => "Fail authentication";
        public static string InternalServerError => "Something went wrong";
        public static string NotFound(string? name) => $"Not found {name}";
        public static string Exists(string? name) => $"{name} is existed";
    }
}
