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

        public async Task<Result<List<DebtorResponseDto>>> GetAllAsync
                        (bool? nepoznat = null,
                        bool? umro = null, bool? penzioner = null,
                        bool? pravnoLice = null, decimal? ukupanDug = null,
                        decimal? AdvTarifa = null, decimal? SudskeTakse = null,
                        DateTime? dugOd = null, DateTime? dugDo = null,
                        string? searchQuery = null, int pageNumber = 1,
                        int pageSize = 10)
        {
            var debtorsDomain = await debtorRepository.GetAllAsync();

            var result = new List<DebtorResponseDto>();

            foreach(var debtor in debtorsDomain)
            {
                result.Add(new DebtorResponseDto
                {
                    DuznikID = debtor.DuznikID,
                    ZavedenKodPov = debtor.ZavedenKodPov,
                    Ime = debtor.Ime,
                    Mjesto = debtor.Mjesto,
                    Adresa = debtor.Adresa,
                    JMBG = debtor.JMBG,
                    RegBr = debtor.RegBr,
                    LicniBroj = debtor.LicniBroj,
                    PreduzeceID = debtor.PreduzeceID,
                    Nepoznat = debtor.Nepoznat,
                    Umro = debtor.Umro,
                    Penzioner = debtor.Penzioner,
                    Reon = debtor.Reon,
                    Nekretnina = debtor.Nekretnina,
                    PravnoLice = debtor.PravnoLice,
                    Oznacen = debtor.Oznacen,
                    Vozila = debtor.Vozila,
                    BrojeviRacuna = debtor.BrojeviRacuna,
                    Prebivaliste = debtor.Prebivaliste
                });
            }

            return Result<List<DebtorResponseDto>>.Ok(result);
        }
    }
}
