using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrinudnaNaplata.Models.Dtos.Debtor;
using PrinudnaNaplata.Services.Interfaces;
using PrinudnaNaplata.Validators;

namespace PrinudnaNaplata.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebtorController : ControllerBase
    {
        private readonly IDebtorService debtorService;
        private readonly DebtorFilterValidator debtorFilterValidator;

        public DebtorController(IDebtorService debtorService, DebtorFilterValidator debtorFilterValidator)
        {
            this.debtorService = debtorService;
            this.debtorFilterValidator = debtorFilterValidator;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllAsync([FromQuery] DebtorFilterDto filter)
        {
            var validationResult = await debtorFilterValidator.ValidateAsync(filter);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            if(Request.Cookies.TryGetValue("selectedKlijent", out var klijentCookie)
                && int.TryParse(klijentCookie, out var klijentId))
            {
                filter.KlijentID = klijentId;
            }

            var result = await debtorService.GetAllAsync(filter);

            return Ok(result);
        }
    }
}
