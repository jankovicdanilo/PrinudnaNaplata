using PrinudnaNaplata.Models.Dtos.Debtor;
using PrinudnaNaplata.Results;

namespace PrinudnaNaplata.Services.Interfaces
{
    public interface IDebtorService
    {
        Task<Result<PagedResult<DebtorListItemDto>>> GetAllAsync(DebtorFilterDto filter);
    }
}
