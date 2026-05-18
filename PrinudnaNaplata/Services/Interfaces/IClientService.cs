using PrinudnaNaplata.Models.Dtos.Client;
using PrinudnaNaplata.Results;

namespace PrinudnaNaplata.Services.Interfaces
{
    public interface IClientService
    {
        Task<Result<List<ClientListResponseDto>>> GetAllAsync();
    }
}
