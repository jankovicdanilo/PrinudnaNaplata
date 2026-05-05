using PrinudnaNaplata.Domain;

namespace PrinudnaNaplata.Repositories.Interfaces
{
    public interface IDebtorRepository
    {
        Task<List<Duznik>> GetAllAsync(bool? nepoznat = null,
                        bool? umro = null, bool? penzioner = null,
                        bool? pravnoLice = null, decimal? ukupanDug = null,
                        decimal? AdvTarifa = null, decimal? SudskeTakse = null,
                        DateTime? dugOd = null, DateTime? dugDo = null,
                        string? searchQuery = null, int pageNumber = 1,
                        int pageSize = 10);
    }
}
