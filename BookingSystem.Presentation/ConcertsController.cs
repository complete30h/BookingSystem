using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace BookingSystem.Presentation
{
    [Route("api/concerts")]
    [ApiController]
    public class ConcertsController: ControllerBase
    {
        private readonly IServiceManager _service;
        public ConcertsController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetConcerts()
        {
            var companies = await _service.ConcertService.GetAllConcertsAsync(trackChanges: false);
            return Ok(companies);
        }

    }
}