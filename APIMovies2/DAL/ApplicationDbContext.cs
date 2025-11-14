using APIMovies2.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace APIMovies2.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        //seccion para crear los DbSet de las entidades o modelos
        public DbSet<Category> Categories { get; set; }

    }
}
