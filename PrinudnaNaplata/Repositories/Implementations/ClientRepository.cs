using Microsoft.EntityFrameworkCore;
using PrinudnaNaplata.Data;
using PrinudnaNaplata.Domain;
using PrinudnaNaplata.Repositories.Interfaces;

namespace PrinudnaNaplata.Repositories.Implementations
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext dbContext;

        public ClientRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Klijent>> GetAllAsync()
        {
            return await dbContext.Klijenti.ToListAsync();
        }
    }
}
