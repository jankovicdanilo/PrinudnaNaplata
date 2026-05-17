using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrinudnaNaplata.Services.Interfaces;

namespace PrinudnaNaplata.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourtController : ControllerBase
    {
        private readonly ICourtService courtService;

        public CourtController(ICourtService courtService)
        {
            this.courtService = courtService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await courtService.GetAllAsync();

            return Ok(result);
        }
    }
}
