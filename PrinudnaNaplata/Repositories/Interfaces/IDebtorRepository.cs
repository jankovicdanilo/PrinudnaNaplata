using PrinudnaNaplata.Domain;

namespace PrinudnaNaplata.Repositories.Interfaces
{
    public interface IDebtorRepository
    {
        Task<List<Duznik>> GetAllAsync(string? searchQuery = null,
            int pageNumber = 1,
            int pageSize = 10);
    }
}
