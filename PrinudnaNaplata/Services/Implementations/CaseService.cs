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

        public async Task<Result<List<CaseResponseDto>>> GetAllAsync(CaseFilterDto filter)
        {
            var casesDomain = await caseRepository.GetAllAsync(filter);

            List<CaseResponseDto> result = new List<CaseResponseDto>();

            foreach(var c in casesDomain)
            {
                result.Add
                    (
                        new CaseResponseDto
                        (
                            c.PartijaID,
                            c.BrojPartije,
                            c.DuznikID,
                            c.DuznikIme,
                            c.ResenjeBroj,
                            c.IVb,
                            c.PredatoDana,
                            c.DonetoDana,
                            c.SudskeTakse
                        )
                    );
            }

            return Result<List<CaseResponseDto>>.Ok(result);
        }
    }
}
