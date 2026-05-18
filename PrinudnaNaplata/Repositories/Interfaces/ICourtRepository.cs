using PrinudnaNaplata.Domain;

namespace PrinudnaNaplata.Repositories.Interfaces
{
    public interface ICourtRepository
    {
        Task<List<Sud>> GetAllAsync();
    }
}
