using Kolokwium_2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium_2.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<TicketConcert> TicketConcerts { get; set; }
    public DbSet<Concert> Concerts { get; set; }
    public DbSet<PurchasedTicket> PurchasedTickets { get; set; }
    public DbSet<Customer> Customers { get; set; }
    
    protected DatabaseContext()
    {
        
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ticket>().HasData(new List<Ticket>
        {
            new Ticket() { TicketId = 1, SerialNumber = "numer1", SeatNumber = 1},
            new Ticket() { TicketId = 2, SerialNumber = "numer2", SeatNumber = 2},
            new Ticket() { TicketId = 3, SerialNumber = "numer3", SeatNumber = 3}
        });
        
        modelBuilder.Entity<Concert>().HasData(new List<Concert>
        {
            new Concert() { ConcertId = 1, Name = "koncert1", Date = DateTime.Parse("2025-06-01"), AvailableTickets = 1},
            new Concert() { ConcertId = 2, Name = "koncert2", Date = DateTime.Parse("2025-06-02"), AvailableTickets = 2},
        });
        
        modelBuilder.Entity<TicketConcert>().HasData(new List<TicketConcert>
        {
            new TicketConcert() { TicketConcertId = 1, TicketId = 1, ConcertId = 1, Price = 15.50},
            new TicketConcert() { TicketConcertId = 2, TicketId = 2, ConcertId = 2, Price = 20.50},
            new TicketConcert() { TicketConcertId = 3, TicketId = 3, ConcertId = 2, Price = 15.00}
        });
        
        modelBuilder.Entity<Customer>().HasData(new List<Customer>
        {
            new Customer() { CustomerId = 1, FirstName = "Jan", LastName = "Kowalski", PhoneNumber = "123456789"},
            new Customer() { CustomerId = 2, FirstName = "Ala", LastName = "Nowak", PhoneNumber = "987654321"}
        });
        
        modelBuilder.Entity<PurchasedTicket>().HasData(new List<PurchasedTicket>
        {
            new PurchasedTicket() { TicketConcertId = 1, CustomerId = 1, PurchaseDate = DateTime.Parse("2025-01-01")},
            new PurchasedTicket() { TicketConcertId = 2, CustomerId = 1, PurchaseDate = DateTime.Parse("2025-01-02")},
            new PurchasedTicket() { TicketConcertId = 3, CustomerId = 2, PurchaseDate = DateTime.Parse("2025-01-03")}
        });
    }
}