using first_mvc_pattern_c_.Data;
using first_mvc_pattern_c_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace first_mvc_pattern_c_.Controllers
{
     [Route("api/[controller]")]
    [ApiController]
     public class FilmController : ControllerBase
    {
         private readonly AppDbContext _context;
           public FilmController(AppDbContext context)
        {
            _context = context;
        }
         // GET: api/film
        [HttpGet]
        public ActionResult<IEnumerable<Film>> GetFilms()
        {
            return _context.Films.ToList();
        }

        // GET: api/film/5
        [HttpGet("{id}")]
        public ActionResult<Film> GetFilm(int id)
        {
            var film = _context.Films.Find(id);

            if (film == null)
            {
                return NotFound();
            }

            return film;
        }

         // POST: api/film
        [HttpPost]
        public ActionResult<Film> PostFilm(Film film)
        {
            _context.Films.Add(film);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetFilm), new { id =film.FilmId }, film);
        }

        // PUT: api/film/5
        [HttpPut("{id}")]
        public IActionResult PutFilm(int id, Film film)
        {
            if (id != film.FilmId)
            {
                return BadRequest();
            }

            _context.Entry(film).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/film/5
        [HttpDelete("{id}")]
        public IActionResult DeleteFilm(int id)
        {
            var film = _context.Films.Find(id);
            if (film == null)
            {
                return NotFound();
            }

            _context.Films.Remove(film);
            _context.SaveChanges();

            return NoContent();
        }

    }
  

}