using first_mvc_pattern_c_.Models;

namespace first_mvc_pattern_c_.Repository
{
    public interface CinemaRepository
    {
        IEnumerable<Cinema> GetAllCinemas();
        Cinema GetCinemaById(int id);
        void AddCinema(Cinema cinema);
        void UpdateCinema(Cinema cinema);
        void DeleteCinema(int id);
    }
}