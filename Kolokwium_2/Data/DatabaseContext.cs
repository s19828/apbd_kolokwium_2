using Microsoft.EntityFrameworkCore;

namespace Kolokwium_2.Data;

public class DatabaseContext : DbContext
{
    //pola DbSet<T>
    
    protected DatabaseContext()
    {
        
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<Doctor>().HasData(new List<Doctor>
        // {
        //     new Doctor() { IdDoctor = 1, FirstName = "An", LastName = "Al", Email = "mail1@gmail.com" },
        //     new Doctor() { IdDoctor = 2, FirstName = "Bn", LastName = "Bl", Email = "mail2@gmail.com" }
        // });
    }
}