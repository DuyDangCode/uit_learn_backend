using MongoDB.Bson.Serialization.Attributes;

namespace uit_learn_backend.Models
{
    public class Subjects
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("subject_name")]
        public string? Name { get; set; }

        [BsonElement("subject_description")]
        public string? Description { get; set; }

        [BsonElement("subject_is_published")]
        public bool IsPublished { get; set; }

        [BsonElement("subject_is_deleted")]
        public bool IsDeleted { get; set; }

        [BsonElement("subject_thumb")]
        public string? Thumb { get; set; }
    }
}
