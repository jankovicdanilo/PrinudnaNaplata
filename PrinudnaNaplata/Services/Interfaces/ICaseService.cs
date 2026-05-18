using PrinudnaNaplata.Models.Dtos.Case;
using PrinudnaNaplata.Results;

namespace PrinudnaNaplata.Services.Interfaces
{
    public interface ICaseService
    {
        Task<Result<PagedResult<CaseListItemDto>>> GetAllAsync(CaseFilterDto filter);
    }
}
