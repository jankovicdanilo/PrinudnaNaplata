using PrinudnaNaplata.Models.Dtos.Case;
using PrinudnaNaplata.Repositories.Interfaces;
using PrinudnaNaplata.Results;
using PrinudnaNaplata.Services.Interfaces;

namespace PrinudnaNaplata.Services.Implementations
{
    public class CaseService : ICaseService
    {
        private readonly ICaseRepository caseRepository;

        public CaseService(ICaseRepository caseRepository)
        {
            this.caseRepository = caseRepository;
        }

        public async Task<Result<PagedResult<CaseListItemDto>>> GetAllAsync(CaseFilterDto filter)
        {
            var pagedResult = await caseRepository.GetAllAsync(filter);

            return Result<PagedResult<CaseListItemDto>>.Ok(pagedResult);
        }
    }
}
