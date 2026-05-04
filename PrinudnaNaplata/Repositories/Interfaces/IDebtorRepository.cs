using PrinudnaNaplata.Domain;

namespace PrinudnaNaplata.Repositories.Interfaces
{
    public interface IDebtorRepository
    {
        Task<List<Duznik>> GetAllAsync();
    }
}
