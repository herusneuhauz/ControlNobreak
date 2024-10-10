using Microsoft.EntityFrameworkCore;
using ControlNobreak.Models;
using System.Collections.Generic;

namespace ControlNobreak.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Nobreak> Nobreaks { get; set; }
    }
}
