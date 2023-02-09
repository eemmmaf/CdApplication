using System;

namespace CdApplication.Models
{
    public class Cd
    {
        //------ Properties -------//
        public int Id { get; set; } //PK
        public string? Title { get; set; }
        public string? Description { get; set; }

        public int ArtistId { get; set; } //FK
        public Artist? Artist { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }

    public class Artist
    {
        //------- Properties ------//
        public int ArtistId { get; set; } //PK
        public string? Name { get; set; }
        
        public List<Cd> Cd { get; set; }
    }
}
