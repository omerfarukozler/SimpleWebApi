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
                var students = await _context.Students.ToListAsync();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hata: {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetStudents), new { id = student.Id }, student);
        }
        [HttpPut]
        public async Task<IActionResult> PutStudent([FromBody] Student student)
        {
            var existingStudent = await _context.Students.FirstOrDefaultAsync(s=>s.Id == student.Id);

            if (existingStudent == null) {
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
            var existingStudent = await _context.Students.FirstOrDefaultAsync(s=>s.Id == student.Id);
            if (existingStudent == null) {
                return NotFound();
            }
            existingStudent.Id = student.Id;
            _context.Entry(existingStudent).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}