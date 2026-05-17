using PrinudnaNaplata.Models.Dtos.Court;
using PrinudnaNaplata.Repositories.Interfaces;
using PrinudnaNaplata.Results;
using PrinudnaNaplata.Services.Interfaces;

namespace PrinudnaNaplata.Services.Implementations
{
    public class CourtService : ICourtService
    {
        private readonly ICourtRepository courtRepository;

        public CourtService(ICourtRepository courtRepository)
        {
            this.courtRepository = courtRepository;
        }

        public async Task<Result<List<CourtResponseDto>>> GetAllAsync()
        {
            var courtsDomain = await courtRepository.GetAllAsync();

            var result = new List<CourtResponseDto>();

            foreach(var court in courtsDomain)
            {
                result.Add(new CourtResponseDto
                    (
                        court.SudID,
                        court.Naziv,
                        court.Mjesto,
                        court.KratakNaziv,
                        court.KratakPuniNaziv
                    ));
            }

            return Result<List<CourtResponseDto>>.Ok(result);
        }
    }
}
