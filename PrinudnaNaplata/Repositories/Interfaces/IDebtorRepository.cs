using PrinudnaNaplata.Domain;
using PrinudnaNaplata.Models.Dtos.Debtor;

namespace PrinudnaNaplata.Repositories.Interfaces
{
    public interface IDebtorRepository
    {
        Task<PagedResult<List<Duznik>> GetAllAsync(DebtorFilterDto filter);
    }
}
