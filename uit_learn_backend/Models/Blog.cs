namespace YourNamespace.Models
{
    public class Blog
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string BlogId { get; set; }

        [BsonElement("blog_content")]
        public string BlogContent { get; set; }

        [BsonElement("user_name")]
        public string UserName { get; set; }

        [BsonElement("blog_is_deleted")]
        public bool BlogIsDeleted { get; set; }
    }
}
