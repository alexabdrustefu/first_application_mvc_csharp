using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using first_mvc_pattern_c_.Models;

public class CinemaDto
{
   public int CinemaId { get; set; }

        [Required(ErrorMessage = "Il nome del cinema è obbligatorio.")]
        public string ?Name { get; set; }

        [Required(ErrorMessage = "L'indirizzo del cinema è obbligatorio.")]
        public string? Address { get; set; }
        //[JsonIgnore]
        public List<FilmDTO>? Films { get; set; }
}