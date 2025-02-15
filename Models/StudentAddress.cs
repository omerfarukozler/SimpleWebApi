using System.Text.Json.Serialization;

namespace SimpleWebApi.Models
{
    public class StudentAddress
    {
        public int Id { get; set; }

        public int StudentId {get;set;}
        public string? AddressName { get; set; }

        [JsonIgnore]
        public Student? Student { get; set; }
    }
}