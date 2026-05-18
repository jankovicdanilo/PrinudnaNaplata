using PrinudnaNaplata.Domain;
using PrinudnaNaplata.Models.Dtos.Debtor;
using PrinudnaNaplata.Results;

namespace PrinudnaNaplata.Repositories.Interfaces
{
    public interface IDebtorRepository
    {
        Task<PagedResult<DebtorListItemDto>> GetAllAsync(DebtorFilterDto filter);
    }
}
