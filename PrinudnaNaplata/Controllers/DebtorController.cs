using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrinudnaNaplata.Services.Interfaces;

namespace PrinudnaNaplata.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebtorController : ControllerBase
    {
        private readonly IDebtorService debtorService;

        public DebtorController(IDebtorService debtorService)
        {
            this.debtorService = debtorService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllAsync(bool? nepoznat = null,
                        bool? umro = null, bool? penzioner = null,
                        bool? pravnoLice = null, decimal? ukupanDug = null,
                        decimal? AdvTarifa = null, decimal? SudskeTakse = null,
                        DateTime? dugOd = null, DateTime? dugDo = null,
                        string? searchQuery = null, int pageNumber = 1,
                        int pageSize = 10)
        {
            var result = await debtorService.GetAllAsync();

            return Ok(result);
        }
    }
}
