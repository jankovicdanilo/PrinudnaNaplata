using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrinudnaNaplata.Models.Dtos.Case;
using PrinudnaNaplata.Models.Dtos.Debtor;
using PrinudnaNaplata.Services.Interfaces;

namespace PrinudnaNaplata.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseController : ControllerBase
    {
        private readonly ICaseService caseService;

        public CaseController(ICaseService caseService)
        {
            this.caseService = caseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] CaseFilterDto filter)
        {
            var result = await caseService.GetAllAsync(filter);

            return Ok(result);
        }
    }
}
