using PrinudnaNaplata.Domain;
using PrinudnaNaplata.Models.Dtos.Case;

namespace PrinudnaNaplata.Repositories.Interfaces
{
    public interface ICaseRepository
    {
        Task<List<CaseListItemDto>> GetAllAsync(CaseFilterDto filter);
    }
}
