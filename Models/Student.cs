namespace SimpleWebApi.Models
{
    public class Student
    {
        public int Id { get; set; }
        public required string AdSoyad { get; set; }

        public StudentAddress? StudentAddress { get; set; }

        public ICollection<PhoneNumber>? PhoneNumbers { get; set; }

        public ICollection<Lesson>? Lessons { get; set; }

    }
}