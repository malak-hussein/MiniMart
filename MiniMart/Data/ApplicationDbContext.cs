using Microsoft.EntityFrameworkCore;
using MiniMart.Models;

namespace MiniMart.Data
{
    public class ApplicationDbContext : DbContext
    {
        //- Malak Hussein Ahmed Mohamed- Fayoum University - Faculty of Computers and Artificial Intelligence -  Up to level 4
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=DESKTOP-MAI0K84;Database=MiniMart;TrustServerCertificate=True;Trusted_Connection=True");
        }
        public DbSet<MiniMart.Models.Category> Category { get; set; } = default!;
    }
}
