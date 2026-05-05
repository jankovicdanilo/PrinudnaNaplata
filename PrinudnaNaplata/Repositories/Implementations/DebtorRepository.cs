using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PrinudnaNaplata.Data;
using PrinudnaNaplata.Domain;
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

        public async Task<List<Duznik>> GetAllAsync(bool? nepoznat = null, 
                        bool? umro = null, bool? penzioner = null, 
                        bool? pravnoLice = null, decimal? ukupanDug = null,
                        decimal? AdvTarifa = null, decimal? SudskeTakse = null,
                        DateTime? dugOd = null, DateTime? dugDo = null, 
                        string? searchQuery = null, int pageNumber = 1, 
                        int pageSize = 10)
        {
            using var connection = new SqlConnection(connectionString);

            var offset = (pageNumber - 1) * pageSize;

            var sql = @"WITH Filtered as(
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
                                preduzeca.Naziv,
                                partije.PartijaID,
                                partije.DugOd,
                                partije.DugDo,
                                (partije.IznosDuga + partije.AdvTarifa + partije.SudskeTakse) as Ukupno_Dugovanje
		                    FROM Duznici d 
		                    LEFT JOIN Preduzeca preduzeca ON d.PreduzeceID = preduzeca.PreduzeceID
		                    LEFT JOIN Partije partije ON partije.DuznikID = d.DuznikID
		                    WHERE
                            (@search IS NULL OR @search = '' or
                                d.ZavedenKodPov LIKE '%' + @search + '%' COLLATE Latin1_General_CI_AI OR
                                d.Ime LIKE '%' + @search + '%' COLLATE Latin1_General_CI_AI OR
                                d.Mjesto LIKE '%' + @search + '%' COLLATE Latin1_General_CI_AI OR
                                d.Reon LIKE '%' + @search + '%' COLLATE Latin1_General_CI_AI OR
                                d.Adresa LIKE '%' + @search + '%' COLLATE Latin1_General_CI_AI OR
                                d.JMBG LIKE '%' + @search + '%' COLLATE Latin1_General_CI_AI OR
                                d.LicniBroj LIKE '%' + @search + '%' COLLATE Latin1_General_CI_AI OR
                                preduzeca.Naziv LIKE '%' + @search + '%' COLLATE Latin1_General_CI_AI)
			                    AND (@nepoznat IS NULL OR @nepoznat = d.Nepoznat)
			                    AND (@umro IS NULL OR @umro = d.Umro)
			                    AND (@penzioner IS NULL OR @penzioner = d.Penzioner)
			                    AND (@pravnoLice IS NULL OR @pravnoLice = d.PravnoLice)
			                    AND (@ukupanDug IS NULL OR (partije.IznosDuga + partije.AdvTarifa + partije.SudskeTakse) >= @ukupanDug)
			                    AND (@AdvTarifa IS NULL OR partije.AdvTarifa >= @AdvTarifa)
			                    AND (@SudskeTakse IS NULL OR partije.SudskeTakse >= @SudskeTakse)
			                    AND (@dugOd IS NULL OR partije.DugOd >= @dugOd)
			                    AND (@dugDo IS NULL OR partije.DugDo <= @dugDo))

	                        SELECT	
                                DuznikID,
			                    ZavedenKodPov,
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
			                    Naziv,
			                    PartijaID,
			                    DugOd,
			                    DugDo,
			                    Ukupno_Dugovanje
	                        FROM Filtered
	                        ORDER BY DuznikID
	                        offset @offset rows fetch next @pageSize rows only;";

            var result = await connection.QueryAsync<Duznik>(sql, new
            {
                search = searchQuery,
                nepoznat,
                umro,
                penzioner,
                pravnoLice,
                ukupanDug,
                AdvTarifa = AdvTarifa,
                SudskeTakse = SudskeTakse,
                dugOd,
                dugDo,
                offset,
                pageSize
            });

            return result.ToList();
        }
    }
}
