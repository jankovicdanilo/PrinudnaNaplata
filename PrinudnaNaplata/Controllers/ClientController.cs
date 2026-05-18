using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrinudnaNaplata.Services.Interfaces;

namespace PrinudnaNaplata.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService clientService;

        public ClientController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await clientService.GetAllAsync();

            return Ok(result);
        }
    }
}
