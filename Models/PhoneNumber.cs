using System.Text.Json.Serialization;

namespace SimpleWebApi.Models
{
    public class PhoneNumber
    {
        public int Id { get; set; }
        public string? phoneNumber { get; set; }

        [JsonIgnore]
        public Student? Student { get; set; }
    }
}