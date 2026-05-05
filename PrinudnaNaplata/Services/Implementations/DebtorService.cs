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

        public async Task<Result<List<DebtorResponseDto>>> GetAllAsync(DebtorFilterDto filter)
        {
            var debtorsDomain = await debtorRepository.GetAllAsync(filter);

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
                    Prebivaliste = debtor.Prebivaliste,
                    UkupnoDugovanje = debtor.UkupnoDugovanje,
                    DugOd = debtor.DugOd,
                    DugDo = debtor.DugDo,
                    ZaposlenKod = debtor.ZaposlenKod
                });
            }

            return Result<List<DebtorResponseDto>>.Ok(result);
        }
    }
}
