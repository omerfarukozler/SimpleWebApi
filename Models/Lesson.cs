using System.Text.Json.Serialization;

namespace SimpleWebApi.Models
{
    public class Lesson
    {
        public int Id { get; set; }

        public required string LessonName { get; set; }

        [JsonIgnore]
        public ICollection<Student>? Students { get; set; }
    }
}