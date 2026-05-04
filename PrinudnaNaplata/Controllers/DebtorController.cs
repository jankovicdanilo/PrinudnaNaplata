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
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await debtorService.GetAllAsync();

            return Ok(result);
        }
    }
}
