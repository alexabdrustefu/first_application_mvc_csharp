using first_mvc_pattern_c_.Models;

namespace first_mvc_pattern_c_.Repository
{
    public interface FilmRepository
    {
        IEnumerable<Film> GetAllFilms();
        Film GetFilmById(int id);
        void AddFilm(Film film);
        void UpdateFilm(Film film);
        void DeleteFilm(int id);
    }
}