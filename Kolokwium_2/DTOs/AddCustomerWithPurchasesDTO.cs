namespace Kolokwium_2.DTOs;

public class AddCustomerWithPurchasesDTO
{
    public CustomerDTO Customer { get; set; }
    public List<AddPurchaseDTO> Purchases { get; set; }
}

public class CustomerDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
}

public class AddPurchaseDTO
{
    public int SeatNumber { get; set; }
    public string ConcertName { get; set; }
    public double Price { get; set; }
}