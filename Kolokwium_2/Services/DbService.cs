using Kolokwium_2.Data;

namespace Kolokwium_2.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }
    
    //metody
}