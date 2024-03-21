using System.ComponentModel.DataAnnotations;
using first_mvc_pattern_c_.Models;

public class CinemaDto
{
   public int CinemaId { get; set; }

        [Required(ErrorMessage = "Il nome del cinema è obbligatorio.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "L'indirizzo del cinema è obbligatorio.")]
        public string Address { get; set; }

        // Relazione uno-a-molti con Film

        public ICollection<Film> Films { get; set; }
}