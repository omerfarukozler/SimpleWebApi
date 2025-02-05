using Microsoft.AspNetCore.Mvc;
using SimpleWebApi.Models;
using Microsoft.EntityFrameworkCore;


namespace SimpleWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OgrenciController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OgrenciController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            try
            {
                var ogrenciler = await _context.Students.ToListAsync();
                return Ok(ogrenciler);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hata: {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] Ogrenci ogrenci)
        {
            _context.Students.Add(ogrenci);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetStudents), new { id = ogrenci.Id }, ogrenci);
        }
    }

}