using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PrinudnaNaplata.Data;
using PrinudnaNaplata.Domain;
using PrinudnaNaplata.Models.Dtos.Debtor;
using PrinudnaNaplata.Repositories.Interfaces;

namespace PrinudnaNaplata.Repositories.Implementations
{
    public class DebtorRepository : IDebtorRepository
    {
        private readonly AppDbContext dbContext;
        private readonly string? connectionString;

        public DebtorRepository(AppDbContext dbContext, IConfiguration configuration)
        {
            this.dbContext = dbContext;
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<Duznik>> GetAllAsync(DebtorFilterDto filter)
        {
            using var connection = new SqlConnection(connectionString);

            var offset = (filter.PageNumber - 1) * filter.PageSize;

            var sql = @"WITH Dugovanja AS (
                            SELECT 
                                DuznikID,
                                SUM(COALESCE(IznosPoPrigovoru, IznosDuga, 0))
                                + SUM(COALESCE(ATPoPrigovoru, AdvTarifa, 0))
                                + SUM(COALESCE(TaksaPoPrigovoru, SudskeTakse, 0)) as UkupnoDugovanje,
                                MIN(DugOd) as DugOd,
                                MAX(DugDo) as DugDo
                            FROM Partije
                            GROUP BY DuznikID
                        ),
                        Filtered AS (
                            SELECT
                                d.DuznikID,
                                d.ZavedenKodPov,
                                d.Ime,
                                d.Mjesto,
                                d.Adresa,
                                d.JMBG,
                                d.RegBr,
                                d.LicniBroj,
                                d.Nepoznat,
                                d.Umro,
                                d.Penzioner,
                                d.Reon,
                                d.Nekretnina,
                                d.PravnoLice,
                                d.Oznacen,
                                d.Vozila,
                                d.BrojeviRacuna,
                                d.Prebivaliste,
                                preduzeca.PreduzeceID,
                                preduzeca.Naziv as ZaposlenKod,
                                dug.DugOd,
                                dug.DugDo,
                                dug.UkupnoDugovanje
                            FROM Duznici d
                            LEFT JOIN Preduzeca preduzeca ON d.PreduzeceID = preduzeca.PreduzeceID
                            LEFT JOIN Dugovanja dug ON dug.DuznikID = d.DuznikID
                            WHERE
                                (@ime IS NULL OR @ime = '' OR d.Ime LIKE '%' + @ime + '%' COLLATE Latin1_General_CI_AI) AND
                                (@mjesto IS NULL OR @mjesto = '' OR d.Mjesto LIKE '%' + @mjesto + '%' COLLATE Latin1_General_CI_AI) AND
                                (@reon IS NULL OR @reon = '' OR d.Reon LIKE '%' + @reon + '%' COLLATE Latin1_General_CI_AI) AND
                                (@adresa IS NULL OR @adresa = '' OR d.Adresa LIKE '%' + @adresa + '%' COLLATE Latin1_General_CI_AI) AND
                                (@jmbg IS NULL OR @jmbg = '' OR d.JMBG LIKE '%' + @jmbg + '%' COLLATE Latin1_General_CI_AI) AND
                                (@licniBroj IS NULL OR @licniBroj = '' OR d.LicniBroj LIKE '%' + @licniBroj + '%' COLLATE Latin1_General_CI_AI) AND
                                (@naziv IS NULL OR @naziv = '' OR preduzeca.Naziv LIKE '%' + @naziv + '%' COLLATE Latin1_General_CI_AI) AND
                                (@zavedenkodpov IS NULL OR @zavedenkodpov = '' OR d.ZavedenKodPov LIKE '%' + @zavedenkodpov + '%' COLLATE Latin1_General_CI_AI) AND
                                (@nepoznat IS NULL OR @nepoznat = d.Nepoznat) AND
                                (@umro IS NULL OR @umro = d.Umro) AND
                                (@penzioner IS NULL OR @penzioner = d.Penzioner) AND
                                (@pravnoLice IS NULL OR @pravnoLice = d.PravnoLice) AND
                                (@ukupanDug IS NULL OR dug.UkupnoDugovanje >= @ukupanDug) AND
                                (@dugOd IS NULL OR dug.DugOd >= @dugOd) AND
                                (@dugDo IS NULL OR dug.DugDo <= @dugDo)
                        )
                        SELECT
                            COUNT (*) OVER() AS TotalCount,
                            DuznikID,
                            ZavedenKodPov,
                            ZaposlenKod,
                            Ime,
                            Mjesto,
                            Adresa,
                            JMBG,
                            RegBr,
                            LicniBroj,
                            Nepoznat,
                            Umro,
                            Penzioner,
                            Reon,
                            Nekretnina,
                            PravnoLice,
                            Oznacen,
                            Vozila,
                            BrojeviRacuna,
                            Prebivaliste,
                            PreduzeceID,
                            DugOd,
                            DugDo,
                            UkupnoDugovanje
                        FROM Filtered
                        ORDER BY ZavedenKodPov
                        OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY;";

            var result = await connection.QueryAsync<Duznik>(sql, new
            {
                ime = filter.Ime,
                mjesto = filter.Mjesto,
                reon = filter.Reon,
                adresa = filter.Adresa,
                jmbg = filter.JMBG,
                licniBroj = filter.LicniBroj,
                zavedenkodpov = filter.ZavedenKodPov,
                naziv = filter.ZaposlenKod,
                nepoznat = filter.Nepoznat,
                umro = filter.Umro,
                penzioner = filter.Penzioner,
                pravnoLice = filter.PravnoLice,
                ukupanDug = filter.UkupanDug,
                dugOd = filter.DugOd,
                dugDo = filter.DugDo,
                offset,
                pageSize = filter.PageSize
            });

            return result.ToList();
        }
    }
}
