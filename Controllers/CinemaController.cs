using Microsoft.AspNetCore.Mvc;
using first_mvc_pattern_c_.Models;
using Microsoft.EntityFrameworkCore;
using first_mvc_pattern_c_.Data;

namespace first_mvc_pattern_c_.Controllers
{
    [Route("api/cinema")]
    [ApiController]
    public class CinemasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CinemasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/cinemas
        [HttpGet]
        public ActionResult<IEnumerable<Cinema>> GetCinemas()
        {
            return _context.Cinemas.ToList();
        }

        // GET: api/cinemas/5
        [HttpGet("{id}")]
        public ActionResult<Cinema> GetCinema(int id)
        {
            var cinema = _context.Cinemas.Find(id);

            if (cinema == null)
            {
                return NotFound();
            }

            return cinema;
        }

        // POST: api/cinemas
        [HttpPost]
        public ActionResult<Cinema> PostCinema(Cinema cinema)
        {
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCinema), new { id = cinema.CinemaId }, cinema);
        }

        // PUT: api/cinemas/5
        [HttpPut("{id}")]
        public IActionResult PutCinema(int id, Cinema cinema)
        {
            if (id != cinema.CinemaId)
            {
                return BadRequest();
            }

            _context.Entry(cinema).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/cinemas/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCinema(int id)
        {
            var cinema = _context.Cinemas.Find(id);
            if (cinema == null)
            {
                return NotFound();
            }

            _context.Cinemas.Remove(cinema);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
