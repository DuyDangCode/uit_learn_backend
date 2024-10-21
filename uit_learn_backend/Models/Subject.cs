using MongoDB.Bson.Serialization.Attributes;

namespace uit_learn_backend.Models
{
    public class Subject
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("subject_name")]
        [BsonRequired]
        public string? Name { get; set; }

        [BsonElement("subject_description")]
        [BsonDefaultValue("")]
        public string? Description { get; set; }

        [BsonElement("subject_code")]
        [BsonRequired]
        public string? Code { get; set; }

        [BsonElement("subject_is_published")]
        [BsonDefaultValue(false)]
        public bool IsPublished { get; set; }

        [BsonElement("subject_is_deleted")]
        [BsonDefaultValue(false)]
        public bool IsDeleted { get; set; }

        [BsonElement("subject_thumb")]
        [BsonRequired]
        public string? Thumb { get; set; }

        [BsonElement("subject_image_code")]
        [BsonRequired]
        public string? ImageCode { get; set; }

        [BsonElement("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [BsonElement("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
