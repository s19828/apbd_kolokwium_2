using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium_2.Models;

[PrimaryKey(nameof(TicketConcertId), nameof(CustomerId))]
[Table("Purchased_Ticket")]
public class PurchasedTicket
{
    [ForeignKey(nameof(TicketConcert))]
    public int TicketConcertId { get; set; }
    [ForeignKey(nameof(Customer))]
    public int CustomerId { get; set; }
    public DateTime PurchaseDate { get; set; }
    
    public TicketConcert TicketConcert { get; set; }
    public Customer Customer { get; set; }
}