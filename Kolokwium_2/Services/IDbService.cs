using Kolokwium_2.DTOs;

namespace Kolokwium_2.Services;

public interface IDbService
{
    Task<GetCustomersPurchasesDTO> GetCustomersPurchasesById(int customerId);
    Task AddCustomerWithPurchases(AddCustomerWithPurchasesDTO dto);
}