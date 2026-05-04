using Microsoft.EntityFrameworkCore;
using PrinudnaNaplata.Data;
using PrinudnaNaplata.Domain;
using PrinudnaNaplata.Repositories.Interfaces;

namespace PrinudnaNaplata.Repositories.Implementations
{
    public class DebtorRepository : IDebtorRepository
    {
        private readonly AppDbContext dbContext;

        public DebtorRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Duznik>> GetAllAsync()
        {
            return await dbContext.Duznici.ToListAsync();
        }
    }
}
