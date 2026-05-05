using PrinudnaNaplata.Domain;
using PrinudnaNaplata.Models.Dtos.Debtor;

namespace PrinudnaNaplata.Repositories.Interfaces
{
    public interface IDebtorRepository
    {
        Task<List<Duznik>> GetAllAsync(DebtorFilterDto filter);
    }
}
