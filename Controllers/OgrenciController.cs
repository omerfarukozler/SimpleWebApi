using Microsoft.AspNetCore.Mvc;
using SimpleWebApi.Models;

namespace SimpleWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OgrenciController : ControllerBase
    {
        static List<Ogrenci> ogrenciler = new List<Ogrenci> {
            new Ogrenci { Id = 1, AdSoyad = "Ömer Faruk Özler" },
            new Ogrenci { Id = 2, AdSoyad = "Muhammed Orhan Keçeci" },
            new Ogrenci { Id = 3, AdSoyad = "Rıdvan Baz" }
        };
        [HttpGet]
        public List<Ogrenci> Get()
        {
            return ogrenciler;
        }
        [HttpGet("{id}")]
        public Ogrenci Get(int id)
        {
            return ogrenciler.FirstOrDefault(o => o.Id == id);
        }
        [HttpPost]
        public Ogrenci Post(Ogrenci ogrenci)
        {
            ogrenciler.Add(ogrenci);
            return ogrenci;
        }
    }
}