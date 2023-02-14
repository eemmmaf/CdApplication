using CdApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace CdApplication.Data
{
    public class CdContext : DbContext
    {
        public CdContext(DbContextOptions<CdContext> options) : base(options) { }
        

            public DbSet<Cd> Cd { get; set; }
        

            public DbSet<CdApplication.Models.Artist> Artist { get; set; } = default!;
        
    
    }
}

