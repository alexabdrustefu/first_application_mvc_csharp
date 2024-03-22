using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace first_mvc_pattern_c_.Models
{
    public class Film
    {
        [Key]
        public int FilmId { get; set; } // Chiave primaria di Film

        [Required(ErrorMessage = "Il nome del film è obbligatorio.")]
        public string ?FilmName { get; set; }

        [Required(ErrorMessage = "L'autore del film è obbligatorio.")]
        public string ?AuthorName { get; set; }

        [ForeignKey("Cinema")] // Specifica il nome della proprietà di navigazione Cinema
        public int CinemaId { get; set; } // Chiave esterna di Cinema

        // Proprietà di navigazione per accedere al cinema associato al film
        public virtual Cinema ?Cinema { get; set; }
    }
}
