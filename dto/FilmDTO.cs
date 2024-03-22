using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using first_mvc_pattern_c_.Models;

public class FilmDTO
    {
    public int FilmId { get; set; } // Chiave primaria di Film

    [Required(ErrorMessage = "Il nome del film è obbligatorio.")]
    public string ?FilmName { get; set; }

    [Required(ErrorMessage = "L'autore del film è obbligatorio.")]
    public string ? AuthorName { get; set; }

    [ForeignKey("Cinema")] // Specifica il nome della proprietà di navigazione Cinema
    public int CinemaId { get; set; } // Chiave esterna di Cinema
    }