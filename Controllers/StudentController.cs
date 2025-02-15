using Microsoft.AspNetCore.Mvc;
using SimpleWebApi.Models;
using Microsoft.EntityFrameworkCore;


namespace SimpleWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            try
            {
                var students = await _context.Students
                    .Include(s => s.StudentAddress)
                    .Include(s => s.PhoneNumbers)
                    .Include(s => s.Lessons)
                    .ToListAsync();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hata: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _context.Students
                .Include(s => s.StudentAddress)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost("add-student")]
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetStudents), new { id = student.Id }, student);
        }

        [HttpPost("add-address/{studentId}")]
        public async Task<IActionResult> AddAddress(int studentId, [FromBody] StudentAddress address)
        {
            var student = await _context.Students.FindAsync(studentId);
            if (student == null) return NotFound();

            student.StudentAddress = address;
            await _context.SaveChangesAsync();
            return Ok(student);
        }

        [HttpPost("add-phone/{studentId}")]
        public async Task<IActionResult> AddPhone(int studentId, [FromBody] PhoneNumber phone)
        {
            var student = await _context.Students.Include(s => s.PhoneNumbers).FirstOrDefaultAsync(s => s.Id == studentId);
            if (student == null) return NotFound();

            student.PhoneNumbers.Add(phone);
            await _context.SaveChangesAsync();
            return Ok(student);
        }

        [HttpPost("add-lesson/{studentId}")]
        public async Task<IActionResult> AddLesson(int studentId, [FromBody] Lesson lesson)
        {
            var student = await _context.Students.Include(s => s.Lessons).FirstOrDefaultAsync(s => s.Id == studentId);
            if (student == null) return NotFound();

            var existingLesson = await _context.Lesson.FirstOrDefaultAsync(l => l.Id == lesson.Id);
            if (existingLesson == null)
                student.Lessons.Add(lesson);
            else
                student.Lessons.Add(existingLesson);

            await _context.SaveChangesAsync();
            return Ok(student);
        }

        [HttpPut]
        public async Task<IActionResult> PutStudent([FromBody] Student student)
        {
            var existingStudent = await _context.Students.FirstOrDefaultAsync(s => s.Id == student.Id);

            if (existingStudent == null)
            {
                return NotFound();
            }
            existingStudent.AdSoyad = student.AdSoyad;
            _context.Entry(existingStudent).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteStudent([FromBody] Student student)
        {
            var existingStudent = await _context.Students.FirstOrDefaultAsync(s => s.Id == student.Id);
            if (existingStudent == null)
            {
                return NotFound();
            }
            existingStudent.Id = student.Id;
            _context.Entry(existingStudent).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}