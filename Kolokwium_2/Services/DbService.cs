using Kolokwium_2.Data;
using Kolokwium_2.DTOs;
using Kolokwium_2.Exceptions;
using Kolokwium_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium_2.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }
    
    //metody
    
    public async Task<GetCustomersPurchasesDTO> GetCustomersPurchasesById(int customerId)
    {
        var purchases = await _context.Customers
            .Select(e => new GetCustomersPurchasesDTO
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                PhoneNumber = e.PhoneNumber,
                Purchases = e.PurchasedTickets.Select(p => new PurchaseDTO()
                {
                    Date = p.PurchaseDate,
                    Price = p.TicketConcert.Price,
                    Ticket = new TicketDTO()
                    {
                        SeatNumber = p.TicketConcert.Ticket.SeatNumber,
                        Serial = p.TicketConcert.Ticket.SerialNumber
                    },
                    Concert = new ConcertDTO()
                    {
                        Name = p.TicketConcert.Concert.Name,
                        Date = p.TicketConcert.Concert.Date
                    }
                    
                }).ToList()
            }).FirstOrDefaultAsync();
        
        if (purchases == null)
            throw new NotFoundException();

        return purchases;
    }

    public async Task AddCustomerWithPurchases(AddCustomerWithPurchasesDTO dto)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            var customer = await _context.Customers
                .FirstOrDefaultAsync(c => c.CustomerId == dto.Customer.Id);

            if (customer != null)
            {
                throw new ConflictException();
            }

            customer = new Customer()
            {
                FirstName = dto.Customer.FirstName,
                LastName = dto.Customer.LastName,
                PhoneNumber = dto.Customer.PhoneNumber
            };
            
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            if (dto.Purchases.Count > 5)
            {
                throw new ConflictException();
            }

            foreach (var purchase in dto.Purchases)
            {
                var concert = await _context.Concerts
                    .FirstOrDefaultAsync(c => c.Name == purchase.ConcertName);
                
                if (concert == null)
                    throw new NotFoundException();

                var ticket = new Ticket()
                {
                    SerialNumber = "123",
                    SeatNumber = purchase.SeatNumber
                };
                
                _context.Tickets.Add(ticket);
                await _context.SaveChangesAsync();
                
                var ticketConcert = new TicketConcert()
                {
                    Ticket = ticket,
                    Concert = concert,
                    Price = purchase.Price
                };
                
                _context.TicketConcerts.Add(ticketConcert);
                await _context.SaveChangesAsync();
                
                var purchasedTicket = new PurchasedTicket()
                {
                    TicketConcert = ticketConcert,
                    Customer = customer,
                    PurchaseDate = DateTime.Now
                };
                
                _context.PurchasedTickets.Add(purchasedTicket);
                await _context.SaveChangesAsync();
            }
            
            await transaction.CommitAsync();
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}