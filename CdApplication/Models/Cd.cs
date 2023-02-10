using System;
using System.ComponentModel.DataAnnotations;

namespace CdApplication.Models
{
    public class Cd
    {
        //------ Properties -------//

        public int Id { get; set; } //PK

        //Titel
        [Required(ErrorMessage = "Titel måste fyllas i")]
        [Display(Name = "Titel")]
        public string? Title { get; set; }


        //Beskrivning
        [Display(Name = "Beskrivning")]
        public string? Description { get; set; }


        //Artist
        [Required]
        [Display(Name = "Artist")]
        public int ArtistId { get; set; } //FK
        public Artist? Artist { get; set; }


        //Utgivetdatum
        [Required(ErrorMessage = "Välj utgivningsdatum")]
        [Display(Name = "Utgivet")]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

    }

    public class Artist
    {
        //------- Properties ------//

        [Required(ErrorMessage = "Artistens namn måste fyllas i")]
        public int ArtistId { get; set; } //PK

        [Required(ErrorMessage = "Artistens namn måste fyllas i")]
        [Display(Name = "Namn")]
        public string? Name { get; set; }
        
        public List<Cd>? Cd { get; set; }
    }
}
