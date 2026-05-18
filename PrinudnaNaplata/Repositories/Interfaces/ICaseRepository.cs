using PrinudnaNaplata.Domain;
using PrinudnaNaplata.Models.Dtos.Case;
using PrinudnaNaplata.Results;

namespace PrinudnaNaplata.Repositories.Interfaces
{
    public interface ICaseRepository
    {
        Task<PagedResult<CaseListItemDto>> GetAllAsync(CaseFilterDto filter);
    }
}
