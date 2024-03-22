using System;
using System.Collections.Generic;
using System.Linq;
using first_mvc_pattern_c_.Data;
using first_mvc_pattern_c_.Models;

namespace first_mvc_pattern_c_.Services
{
    public class FilmService
    {
        private readonly AppDbContext _context;

        public FilmService(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Film> GetAllFilms()
        {
            return _context.Films.ToList();
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

        public void UpdateFilm(int id, Film film)
        {
            if (film == null)
            {
                throw new ArgumentNullException(nameof(film));
            }

            var existingFilm = _context.Films.Find(id);
            if (existingFilm == null)
            {
                throw new ArgumentException($"Film with ID {id} not found.");
            }

            existingFilm.FilmName = film.FilmName;
            existingFilm.AuthorName = film.AuthorName;
            existingFilm.Cinema= film.Cinema;

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

    }
}
