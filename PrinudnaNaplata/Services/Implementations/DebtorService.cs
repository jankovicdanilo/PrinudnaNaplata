using PrinudnaNaplata.Domain;
using PrinudnaNaplata.Models.Dtos.Debtor;
using PrinudnaNaplata.Repositories.Interfaces;
using PrinudnaNaplata.Results;
using PrinudnaNaplata.Services.Interfaces;

namespace PrinudnaNaplata.Services.Implementations
{
    public class DebtorService : IDebtorService
    {
        private readonly IDebtorRepository debtorRepository;

        public DebtorService(IDebtorRepository debtorRepository)
        {
            this.debtorRepository = debtorRepository;
        }

        public async Task<Result<PagedResult<DebtorListItemDto>>> GetAllAsync(DebtorFilterDto filter)
        {
            var pagedResult = await debtorRepository.GetAllAsync(filter);

            return Result<PagedResult<DebtorListItemDto>>.Ok(pagedResult);
        }
    }
}
