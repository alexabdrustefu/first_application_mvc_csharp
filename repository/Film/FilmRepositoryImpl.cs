using first_mvc_pattern_c_.Data;
using first_mvc_pattern_c_.Models;
using Microsoft.EntityFrameworkCore;

namespace first_mvc_pattern_c_.Repository
{
    public class FilmRepositoryImpl : FilmRepository
    {
        private readonly AppDbContext _context;

        public FilmRepositoryImpl(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Cinema> GetAllFilms()
        {
            return _context.Cinemas.ToList();
        }

        public Film GetFilmById(int id)
        {
            return _context.Films.Find(id);
        }

        public void AddFilm(Film film)
        {
            if (film == null)
            {
                throw new ArgumentNullException(nameof(film));
            }

            _context.Films.Add(film);
            _context.SaveChanges();
        }

        public void UpdateFilm(Film film)
        {
            if (film == null)
            {
                throw new ArgumentNullException(nameof(film));
            }

            _context.Entry(film).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteFilm(int id)
        {
            var film = _context.Films.Find(id);
            if (film == null)
            {
                throw new ArgumentException($"Film with ID {id} not found.");
            }

            _context.Films.Remove(film);
            _context.SaveChanges();
        }

        IEnumerable<Film> FilmRepository.GetAllFilms()
        {
            throw new NotImplementedException();
        }
    }
}