using Kolokwium_2.DTOs;
using Kolokwium_2.Exceptions;
using Kolokwium_2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IDbService _dbService;

        public CustomersController(IDbService dbService)
        {
            _dbService = dbService;
        }
        
        //http
        [HttpGet("{customerId}/purchases")]
        public async Task<IActionResult> GetCustomerPurchasesById(int customerId)
        {
            try
            {
                var purchases = await _dbService.GetCustomersPurchasesById(customerId);
                return Ok(purchases);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (ConflictException e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCustomerWithPurchases(AddCustomerWithPurchasesDTO dto)
        {
            try
            {
                await _dbService.AddCustomerWithPurchases(dto);
                return Ok();
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (ConflictException e)
            {
                return Conflict(e.Message);
            }
        }
    }
}
