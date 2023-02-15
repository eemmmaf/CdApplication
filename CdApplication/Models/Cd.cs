using System;
using System.ComponentModel.DataAnnotations;

namespace CdApplication.Models
{
    public class Cd
    {
        //------ Properties -------//

        public int Id { get; set; } //PK

        //Titel. Måste fyllas i
        [Required(ErrorMessage = "Titel måste fyllas i")]
        [Display(Name = "Titel")]
        public string? Title { get; set; }


        //Beskrivning
        [Display(Name = "Beskrivning")]
        public string? Description { get; set; }


        //Artist. Måste fyllas i
        [Required]
        [Display(Name = "Artist")]
        public int ArtistId { get; set; } //FK
        public Artist? Artist { get; set; }


        //Utgivetdatum. Måste fyllas i
        [Required(ErrorMessage = "Välj utgivningsdatum")]
        [Display(Name = "Utgivet")]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

    }

    public class Artist
    {
        //------- Properties ------//
        public int ArtistId { get; set; } //PK

        //Artistens namn. Måste fyllas i
        [Required(ErrorMessage = "Artistens namn måste fyllas i")]
        [Display(Name = "Namn")]
        public string? Name { get; set; }
        
        public List<Cd>? Cd { get; set; }
    }
}
