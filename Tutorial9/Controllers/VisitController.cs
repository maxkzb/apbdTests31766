using Microsoft.AspNetCore.Mvc;
using Tutorial9.Model.DTO;
using Tutorial9.Services;

namespace Tutorial9.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisitController : ControllerBase
    {
        private readonly IVisitService _visitService;
        private readonly IClientService _clientService;
        private readonly IMechanicService _mechanicService;

        public VisitController(IVisitService visitService, IClientService clientService, IMechanicService mechanicService)
        {
            _visitService = visitService;
            _clientService = clientService;
            _mechanicService = mechanicService;
        }
        
        [HttpGet("{visitId}")]
        public async Task<IActionResult> GetVisit(int visitId)
        {
            try
            {
                var visit = await _visitService.GetVisitByIdAsync(visitId);  // Calls VisitService
                return Ok(visit);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Visit not found");
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> AddVisit([FromBody] VisitDTO visitDto)
        {
            try
            {
                var success = await _visitService.AddVisitAsync(visitDto);

                if (success)
                {
                    return CreatedAtAction(nameof(GetVisit), new { visitId = visitDto.VisitDate.GetHashCode() }, visitDto);
                }
                else
                {
                    return BadRequest("Failed to add visit");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("client/{clientId}")]
        public async Task<IActionResult> GetClient(int clientId)
        {
            try
            {
                var client = await _clientService.GetClientByIdAsync(clientId);
                return Ok(client);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Client not found");
            }
        }
        
        [HttpGet("mechanic/{licenceNumber}")]
        public async Task<IActionResult> GetMechanic(string licenceNumber)
        {
            try
            {
                var mechanic = await _mechanicService.GetMechanicByLicenceAsync(licenceNumber);
                return Ok(mechanic);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Mechanic not found");
            }
        }
    }
}
