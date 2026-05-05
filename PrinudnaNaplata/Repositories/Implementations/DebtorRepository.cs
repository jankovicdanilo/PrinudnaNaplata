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

        public async Task<List<Duznik>> GetAllAsync(
            string? searchQuery = null,
            int pageNumber = 1,
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
        d.PreduzeceID,
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
        preduzece.PreduzeceID,
        preduzece.Naziv,
        partija.PartijaID,
        partija.DugOd,
        partija.DugDo,
        partija.IznosDuga
    FROM Duznici d join Preduzeca preduzece on d.PreduzeceID = preduzece.PreduzeceID";

            return await dbContext.Duznici.ToListAsync();
        }
    }
}
