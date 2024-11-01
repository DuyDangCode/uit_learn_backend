namespace uit_learn_backend.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System;

    namespace uit_learn_backend.Models
    {
        public class Exam
        {
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string? Id { get; set; }

            [BsonElement("exam_code")]
            [BsonRequired]
            public string? Code { get; set; }

            [BsonElement("exam_url")]
            [BsonRequired]
            public string? Url { get; set; }

            [BsonElement("exam_name")]
            [BsonRequired]
            public string? Name { get; set; }

            [BsonElement("exam_is_published")]
            [BsonDefaultValue(false)]
            public bool IsPublished { get; set; }

            [BsonElement("exam_is_deleted")]
            [BsonDefaultValue(false)]
            public bool IsDeleted { get; set; }

            [BsonElement("exam_date_published")]
            public DateTime? DatePublished { get; set; } = DateTime.UtcNow;

            [BsonElement("exam_date_edited")]
            public DateTime? DateEdited { get; set; } = DateTime.UtcNow;

            [BsonElement("exam_thumb")]
            public string? Thumb { get; set; }

            [BsonElement("subject_code")]
            [BsonRequired]
            public string? SubjectCode { get; set; }
        }
    }

}
