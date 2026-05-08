using PrinudnaNaplata.Models.Dtos.Case;
using PrinudnaNaplata.Results;

namespace PrinudnaNaplata.Services.Interfaces
{
    public interface ICaseService
    {
        Task<Result<List<CaseResponseDto>>> GetAllAsync(CaseFilterDto filter);
    }
}
