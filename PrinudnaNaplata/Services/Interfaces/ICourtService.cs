using PrinudnaNaplata.Models.Dtos.Court;
using PrinudnaNaplata.Results;

namespace PrinudnaNaplata.Services.Interfaces
{
    public interface ICourtService
    {
        Task<Result<List<CourtResponseDto>>> GetAllAsync();
    }
}
