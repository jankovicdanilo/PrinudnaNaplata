using Dapper;
using Microsoft.Data.SqlClient;
using PrinudnaNaplata.Domain;
using PrinudnaNaplata.Models.Dtos.Case;
using PrinudnaNaplata.Repositories.Interfaces;
using PrinudnaNaplata.Results;
using System.Diagnostics;

namespace PrinudnaNaplata.Repositories.Implementations
{
    public class CaseRepository : ICaseRepository
    {
        private readonly string? connectionString;

        public CaseRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<PagedResult<CaseListItemDto>> GetAllAsync(CaseFilterDto filter)
        {
            using var connection = new SqlConnection(connectionString);

            var offset = (filter.PageNumber - 1) * filter.PageSize;

            var sql = @"WITH Dugovanja AS(
                            SELECT 
                                DuznikID,
                                SUM(Coalesce(IznosPoPrigovoru, IznosDuga, 0))
                                + SUM(Coalesce(ATPoPrigovoru,AdvTarifa, 0))
                                + SUM(Coalesce(TaksaPoPrigovoru, SudskeTakse, 0)) as UkupnoDugovanje,
                                MIN(DugOd) as DugOd,
                                MAX(DugDo) as DugDo
                            FROM Partije
                            WHERE (@klijentID IS NULL OR @klijentID = 0 OR KlijentID = @klijentID)
                            GROUP BY DuznikID
                            ),
                            Filtered AS(
                                SELECT
                                    partije.PartijaID,
                                    partije.BrojPartije,
                                    partije.DuznikID,
                                    sud.SudID as SudID,
                                    sud1.SudID as Sud1ID,
                                    preduzeca.PreduzeceID,
                                    duznik.Ime as DuznikIme,
                                    partije.ResenjeBroj,
                                    partije.IVb,
                                    partije.PredatoDana,
                                    partije.DonetoDana,
                                    partije.SudskeTakse
                                FROM Partije partije JOIN Duznici duznik ON partije.DuznikID = duznik.DuznikID
                                JOIN Sudovi sud ON sud.SudID = partije.SudID
                                LEFT JOIN Sudovi sud1 ON sud1.SudID = partije.Sud1ID
                                LEFT JOIN Dugovanja dugovanja on dugovanja.DuznikID = duznik.DuznikID
                                LEFT JOIN Preduzeca preduzeca ON preduzeca.PreduzeceID = duznik.PreduzeceID 
                                WHERE
                                    (@Sve IS NULL OR @Sve = '' OR
                                        partije.BrojPartije LIKE '%' + @Sve + '%' COLLATE Latin1_General_CI_AI OR
                                        duznik.Ime LIKE '%' + @Sve + '%' COLLATE Latin1_General_CI_AI OR
                                        partije.ResenjeBroj LIKE '%' + @Sve + '%' COLLATE Latin1_General_CI_AI OR
                                        partije.IVb LIKE '%' + @Sve + '%' COLLATE Latin1_General_CI_AI OR
                                        partije.Pb LIKE '%' + @Sve + '%' COLLATE Latin1_General_CI_AI OR
                                        partije.MalBroj LIKE '%' + @Sve + '%' COLLATE Latin1_General_CI_AI OR
                                        partije.IpvBroj LIKE '%' + @Sve + '%' COLLATE Latin1_General_CI_AI OR
                                        partije.RBroj LIKE '%' + @Sve + '%' COLLATE Latin1_General_CI_AI OR
                                        duznik.ZavedenKodPov LIKE '%' + @Sve + '%' COLLATE Latin1_General_CI_AI OR
                                        sud.Naziv LIKE '%' + @Sve + '%' COLLATE Latin1_General_CI_AI
                                    ) AND
                                    (@BrojPartije IS NULL OR @BrojPartije = '' OR partije.BrojPartije LIKE '%' + @BrojPartije + '%' COLLATE Latin1_General_CI_AI) AND
                                    (
                                    @ResenjeBroj IS NULL OR @ResenjeBroj = '' OR
                                    Partije.ResenjeBroj LIKE '%' + @ResenjeBroj + '%' COLLATE Latin1_General_CI_AI OR
                                    Partije.IVb LIKE '%' + @ResenjeBroj + '%' COLLATE Latin1_General_CI_AI OR
                                    Partije.Pb LIKE '%' + @ResenjeBroj + '%' COLLATE Latin1_General_CI_AI OR
                                    Partije.MalBroj LIKE '%' + @ResenjeBroj + '%' COLLATE Latin1_General_CI_AI OR
                                    Partije.IpvBroj LIKE '%' + @ResenjeBroj + '%' COLLATE Latin1_General_CI_AI OR
                                    Partije.RBroj LIKE '%' + @ResenjeBroj + '%' COLLATE Latin1_General_CI_AI
                                    ) AND
                                    (@Ime IS NULL OR @Ime = '' OR duznik.Ime LIKE '%' + @Ime + '%' COLLATE Latin1_General_CI_AI) AND
                                    (@Zaposlen IS NULL OR @Zaposlen = '' OR preduzeca.Naziv LIKE '%' + @Zaposlen + 
                                    '%' COLLATE Latin1_General_CI_AI) AND
                                    (@SudID IS NULL OR partije.SudID = @SudID OR partije.Sud1ID = @SudID) AND
                                    (@PredatoDanaOd IS NULL OR partije.PredatoDana >= @PredatoDanaOd) AND
                                    (@PredatoDanaDo IS NULL OR partije.PredatoDana <= @PredatoDanaDo) AND
                                    (@DonetoDanaOd IS NULL OR partije.DonetoDana >= @DonetoDanaOd) AND
                                    (@DonetoDanaDo IS NULL OR partije.DonetoDana <= @DonetoDanaDo) AND
                                    (@zavedenkodpov IS NULL OR @zavedenkodpov = '' OR duznik.ZavedenKodPov LIKE '%' + @zavedenkodpov + '%' COLLATE Latin1_General_CI_AI) AND
                                    (@pravnoLice IS NULL OR @pravnoLice = duznik.PravnoLice) AND
                                    (@JavnaObjava IS NULL OR @JavnaObjava = partije.JavnaObjava) AND
                                    (@Odlaganje IS NULL OR @Odlaganje = partije.Odlaganje) AND
                                    (@OdlaganjeDo IS NULL OR partije.OdlaganjeDo <= @OdlaganjeDo) AND
                                    (@Odbacen IS NULL OR @Odbacen = partije.Odbacen) AND
                                    (@Prekinut IS NULL OR @Prekinut = partije.Prekinut) AND
                                    (@Odbijen IS NULL OR @Odbijen = partije.Odbijen) AND
                                    (@Obustavljen IS NULL OR @Obustavljen = partije.Obustavljen) AND
                                    (@PrigovorUsvojen IS NULL OR @PrigovorUsvojen = partije.PrigovorUsvojen) AND
                                    (@PrigovorOdbijen IS NULL OR @PrigovorOdbijen = partije.PrigovorOdbijen) AND
                                    (@PrigovorOdbacen IS NULL OR @PrigovorOdbacen = partije.PrigovorOdbacen) AND
                                    (@Fakturisano IS NULL OR @Fakturisano = partije.Fakturisano) AND
                                    (@FakturisanoProcenat IS NULL OR @FakturisanoProcenat = partije.FakturisanoProcenat) AND
                                    (@Prigovor IS NULL OR @Prigovor = partije.Prigovor) AND
                                    (@Popis IS NULL OR @Popis = partije.Popis) AND
                                    (@Procena IS NULL OR @Procena = partije.Procena) AND
                                    (@Prodaja IS NULL OR @Prodaja = partije.Prodaja) AND
                                    (@NemaPokretneImovine IS NULL OR @NemaPokretneImovine = partije.NemaPokretneImovine) AND
                                    (@Zakljucena IS NULL OR @Zakljucena = partije.Zakljucena) AND
                                    (@Mrtav IS NULL OR @Mrtav = partije.Mrtav) AND
                                    (@Poravnanje IS NULL OR @Poravnanje = partije.Poravnanje) AND
                                    (@IzvrsnoResenjeSuda IS NULL OR @IzvrsnoResenjeSuda = partije.IzvrsnoResenjeSuda) AND
                                    (@PrvostepenaPresuda IS NULL OR @PrvostepenaPresuda = partije.PrvostepenaPresuda) AND
                                    (@Zalba IS NULL OR @Zalba = partije.Zalba) AND
                                    (@DrugostepenaPresuda IS NULL OR @DrugostepenaPresuda = partije.DrugostepenaPresuda) AND
                                    (@IzvrsnoDanaOd IS NULL OR partije.IzvrsnoDana >= @IzvrsnoDanaOd) AND
                                    (@IzvrsnoDanaDo IS NULL OR partije.IzvrsnoDana <= @IzvrsnoDanaDo) AND
                                    (@ZakljucakNalog IS NULL OR @ZakljucakNalog = partije.ZakljucakNalog) AND
                                    (@ZakljucakNalogNisuPostupili IS NULL OR @ZakljucakNalogNisuPostupili = partije.ZakljucakNalogNisuPostupili) AND
                                    (@IzvrsenjePoPresudi IS NULL OR @IzvrsenjePoPresudi = partije.IzvrsenjePoPresudi) AND
                                    (@PlatioIznos IS NULL OR partije.PlatioIznos >= @PlatioIznos) AND
                                    (@Fakturisati IS NULL OR @Fakturisati = partije.Fakturisati) AND
                                    (@NeFakturisati IS NULL OR @NeFakturisati = partije.NeFakturisati) AND
                                    (@PredlPokrImovina IS NULL OR @PredlPokrImovina = partije.PredlPokrImovina) AND
                                    (@PredlNepokImovina IS NULL OR @PredlNepokImovina = partije.PredlNepokImovina) AND
                                    (@Hipoteka IS NULL OR @Hipoteka = partije.Hipoteka) AND
                                    (@Nekretnina IS NULL OR @Nekretnina = duznik.Nekretnina) AND
                                    (@Vozila IS NULL OR @Vozila = duznik.Vozila) AND
                                    (@Penzioner IS NULL OR @Penzioner = duznik.Penzioner) AND
                                    (@UkupanDug IS NULL OR  dugovanja.UkupnoDugovanje >= @UkupanDug) AND
                                    (@klijentID IS NULL OR @klijentID = 0 OR partije.KlijentID = @klijentID)
                                )
                                SELECT 
                                    COUNT(*) OVER() as TotalCount,
                                    PartijaID,
                                    BrojPartije,
                                    DuznikID,
                                    DuznikIme,
                                    ResenjeBroj,
                                    IVb,
                                    PredatoDana,
                                    DonetoDana,
                                    SudskeTakse
                                    FROM Filtered
                                    Order By PartijaID
                                    OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY;";

            var result = await connection.QueryAsync<CaseListItemDto>(sql,new
            {
                pageSize = filter.PageSize,
                offset,
                Sve = filter.BrzaPretraga,
                BrojPartije = filter.BrojPartije,
                ResenjeBroj = filter.ResenjeBroj,
                Ime = filter.ImeDuznika,
                SudID = filter.SudID,
                PredatoDanaOd = filter.PredatoDanaOd,
                PredatoDanaDo = filter.PredatoDanaDo,
                DonetoDanaOd = filter.DonetoDanaOd,
                DonetoDanaDo = filter.DonetoDanaDo,
                zavedenkodpov = filter.ZavedenKodPov,
                pravnoLice = filter.PravnoLice,
                JavnaObjava = filter.JavnaObjava,
                Odlaganje = filter.Odlaganje,
                OdlaganjeDo = filter.OdlaganjeDo,
                Odbacen = filter.Odbacen,
                Prekinut = filter.Prekinut,
                Odbijen = filter.Odbijen,
                Obustavljen = filter.Obustavljen,
                PrigovorUsvojen = filter.PrigovorUsvojen,
                PrigovorOdbijen = filter.PrigovorOdbijen,
                PrigovorOdbacen = filter.PrigovorOdbacen,
                Fakturisano = filter.FakturisanoPovjeriocu,
                FakturisanoProcenat = filter.FakturisanoPovjeriocuProcenat,
                Prigovor = filter.Prigovor,
                Popis = filter.Popis,
                Procena = filter.Procjena,
                Prodaja = filter.Prodaja,
                NemaPokretneImovine = filter.NemaPokretneImovine,
                Zakljucena = filter.Zakljucena,
                Mrtav = filter.Mrtav,
                Poravnanje = filter.Poravnanje,
                IzvrsnoResenjeSuda = filter.IzvrsnoResenjeSuda,
                PrvostepenaPresuda = filter.PrvostepenaPresuda,
                Zalba = filter.Zalba,
                DrugostepenaPresuda = filter.DrugostepenaPresuda,
                IzvrsnoDanaOd = filter.IzvrsnoDanaOd,
                IzvrsnoDanaDo = filter.IzvrsnoDanaDo,
                ZakljucakNalog = filter.ZakljucakNalog,
                ZakljucakNalogNisuPostupili = filter.ZakljucakNalogNisuPostupili,
                IzvrsenjePoPresudi = filter.IzvrsenjePoPresudiResenju,
                PlatioIznos = filter.Uplatio,
                Fakturisati = filter.Fakturisati,
                NeFakturisati = filter.NeFakturisati,
                PredlPokrImovina = filter.PredlPokrImovina,
                PredlNepokImovina = filter.PredlNepokImovina,
                Hipoteka = filter.HipotekaKodKatastra,
                Nekretnina = filter.Nekretnina,
                Vozila = filter.Vozila,
                Zaposlen = filter.Zaposlen,
                Penzioner = filter.Penzioner,
                UkupanDug = filter.UkupanDug,
                klijentID = filter.KlijentID
            });

            var items = result.ToList();
            var totalCount = items.FirstOrDefault()?.TotalCount ?? 0;

            return PagedResult<CaseListItemDto>.Create(items, totalCount, filter.PageNumber, filter.PageSize);
        }
    }
}
