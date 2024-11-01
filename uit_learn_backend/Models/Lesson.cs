using MongoDB.Bson.Serialization.Attributes;

namespace uit_learn_backend.Models
{
    public class Lesson
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("lesson_name")]
        [BsonRequired]
        public string? Name { get; set; }

        [BsonRequired]
        [BsonElement()]
        public string? VideoUrl { get; set; }

        [BsonElement("lesson_description")]
        [BsonDefaultValue("")]
        public string? Description { get; set; }

        [BsonElement("lesson_code")]
        [BsonRequired]
        public string? Code { get; set; }

        [BsonElement("lesson_is_published")]
        [BsonDefaultValue(false)]
        public bool? IsPublished { get; set; }

        [BsonElement("lesson_is_deleted")]
        [BsonDefaultValue(false)]
        public bool? IsDeleted { get; set; }

        [BsonElement("lesson_content")]
        public string? Content { get; set; }

        [BsonElement("lesson_type")]
        [BsonDefaultValue(LessonType.Video)]
        public LessonType Type { get; set; }

        [BsonElement("lesson_thumb")]
        [BsonRequired]
        public string? Thumb { get; set; }

        [BsonElement("lesson_image_code")]
        [BsonRequired]
        public string? ImageCode { get; set; }

        [BsonElement("course_code")]
        [BsonRequired]
        public string? CourseCode { get; set; }

        [BsonElement("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [BsonElement("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
