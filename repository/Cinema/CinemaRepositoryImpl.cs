using first_mvc_pattern_c_.Data;
using first_mvc_pattern_c_.Models;
using Microsoft.EntityFrameworkCore;

namespace first_mvc_pattern_c_.Repository
{
    public class CinemaRepositoryImpl : CinemaRepository
    {
        private readonly AppDbContext _context;

        public CinemaRepositoryImpl(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Cinema> GetAllCinemas()
        {
            return _context.Cinemas.ToList();
        }

        public Cinema GetCinemaById(int id)
        {
            return _context.Cinemas.Find(id);
        }

        public void AddCinema(Cinema cinema)
        {
            if (cinema == null)
            {
                throw new ArgumentNullException(nameof(cinema));
            }

            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
        }

        public void UpdateCinema(Cinema cinema)
        {
            if (cinema == null)
            {
                throw new ArgumentNullException(nameof(cinema));
            }

            _context.Entry(cinema).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteCinema(int id)
        {
            var cinema = _context.Cinemas.Find(id);
            if (cinema == null)
            {
                throw new ArgumentException($"Cinema with ID {id} not found.");
            }

            _context.Cinemas.Remove(cinema);
            _context.SaveChanges();
        }
    }
}