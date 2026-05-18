using Microsoft.EntityFrameworkCore;
using PrinudnaNaplata.Data;
using PrinudnaNaplata.Domain;
using PrinudnaNaplata.Repositories.Interfaces;

namespace PrinudnaNaplata.Repositories.Implementations
{
    public class CourtRepository : ICourtRepository
    {
        private readonly AppDbContext dbContext;

        public CourtRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Sud>> GetAllAsync()
        {
            return await dbContext.Sudovi.AsNoTracking().ToListAsync();
        }
    }
}
