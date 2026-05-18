using PrinudnaNaplata.Domain;

namespace PrinudnaNaplata.Repositories.Interfaces
{
    public interface IClientRepository
    {
        Task<List<Klijent>> GetAllAsync();
    }
}
