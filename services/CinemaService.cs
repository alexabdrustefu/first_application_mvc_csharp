using System;
using System.Collections.Generic;
using System.Linq;
using first_mvc_pattern_c_.Data;
using first_mvc_pattern_c_.Models;
using first_mvc_pattern_c_.Repository;
using Microsoft.EntityFrameworkCore;

namespace first_mvc_pattern_c_.Services
{
    public class CinemaService
    {
        private readonly AppDbContext _context;
        private readonly CinemaRepositoryImpl _repository;

        public CinemaService(AppDbContext context, CinemaRepositoryImpl repository)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _repository = repository;
        }

        public IEnumerable<Cinema> GetAllCinemas()
        {
             return _repository.GetAllCinemasActive()
                     .Select(c => new Cinema
                     {
                         CinemaId = c.CinemaId,
                         Name = c.Name,
                         Address = c.Address,
                         isActive = c.isActive,
                         Films = _context.Films.Where(f => f.CinemaId == c.CinemaId).ToList()
                     })
                     .ToList();
        }

        public Cinema GetCinemaById(int id)
        {
            return _context.Cinemas
         .Include(c => c.Films)
         .FirstOrDefault(c => c.CinemaId == id && c.isActive);
        }

        public void AddCinema(Cinema cinema)
        {
            if (cinema == null)
            {
                throw new ArgumentNullException(nameof(cinema));
            }
            cinema.isActive = true;
            // Controllo se il cinema ha dei film associati
            if (cinema.Films != null && cinema.Films.Any())
            {
                var filmsToAdd = new List<Film>(cinema.Films);

                // Per ogni film associato al cinema
                foreach (var film in filmsToAdd)
                {
                    // Controllo se il film esiste già nel database
                    var existingFilm = _context.Films.Find(film.FilmId);
                    if (existingFilm != null)
                    {
                        cinema.Films.Remove(film); // Rimuovo il film dalla lista del cinema per evitare duplicati
                        cinema.Films.Add(existingFilm); // Aggiungo il film esistente alla lista del cinema
                    }
                }
            }
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
        }


        public void UpdateCinema(int id, Cinema cinema)
        {
            if (cinema == null)
            {
                throw new ArgumentNullException(nameof(cinema));
            }

            var existingCinema = _context.Cinemas
                                          .Include(c => c.Films)  // Carica i film associati al cinema
                                          .FirstOrDefault(c => c.CinemaId == id);

            if (existingCinema == null)
            {
                throw new ArgumentException($"Cinema with ID {id} not found.");
            }

            existingCinema.Name = cinema.Name;
            existingCinema.Address = cinema.Address;

            // Rimuovi tutti i film associati al cinema
            existingCinema.Films.Clear();

            // Aggiungi i nuovi film forniti nella richiesta
            foreach (var film in cinema.Films)
            {
                existingCinema.Films.Add(film);
            }

            _context.SaveChanges();
        }

        public void DeleteCinema(int id)
        {
            var cinema = _context.Cinemas
                                 .SingleOrDefault(c => c.CinemaId == id);

            if (cinema == null)
            {
                throw new ArgumentException($"Cinema with ID {id} not found.");
            }

            // Rimuovere il cinema
            cinema.isActive = false;
            _context.SaveChanges();
        }



    }
}
