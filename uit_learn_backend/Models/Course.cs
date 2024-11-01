using MongoDB.Bson.Serialization.Attributes;
using uit_learn_backend.Dtos;

namespace uit_learn_backend.Models
{
    public class Course
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("course_name")]
        [BsonRequired]
        public string? Name { get; set; }

        [BsonElement("course_description")]
        [BsonRequired]
        public string? Description { get; set; }

        [BsonElement("course_thumb")]
        [BsonRequired]
        public string? Thumb { get; set; }

        [BsonElement("course_is_deleted")]
        public bool? IsDeleted { get; set; } = false;

        [BsonElement("course_is_published")]
        public bool? IsPublished { get; set; } = false;

        [BsonElement("course_code")]
        [BsonRequired]
        public string? Code { get; set; }

        [BsonElement("subject_code")]
        [BsonRequired]
        public string? SubjectCode { get; set; }

        [BsonElement("course_image_code")]
        public string? ImageCode { get; set; }

        [BsonElement("created_at")]
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        [BsonElement("updated_at")]
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;

        public Course()
        {

        }

        public Course(string? id, string? name, string? description, string? thumb, bool isDeleted, bool isPublished, string? code, string? subjectCode, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Name = name;
            Description = description;
            Thumb = thumb;
            IsDeleted = isDeleted;
            IsPublished = isPublished;
            Code = code;
            SubjectCode = subjectCode;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public Course(CourseDto courseDto)
        {
            Name = courseDto.Name;
            Description = courseDto.Description;
            Code = courseDto.Code;
            SubjectCode = courseDto.SubjectCode;
        }
    }
}