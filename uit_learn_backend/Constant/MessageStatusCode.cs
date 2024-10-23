namespace uit_learn_backend.Constant
{
    public class MessageStatusCode
    {
        public static string Ok => "Ok";
        public static string Created(string name) => $"Create {name} succesful";
        public static string Get(string name) => $"Get {name} succesful";
        public static string Update(string name) => $"Update {name} succesful";
        public static string UnAuth => "Fail authentication";
        public static string InternalServerError => "Something went wrong";
        public static string NotFound(string name) => $"Not found {name}";
    }
}
