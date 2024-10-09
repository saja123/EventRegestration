using EventRegestration1.Models.DTO;
using EventRegestration1.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventRegestration1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        // GET: api/Registration
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistrationDTO>>> GetAllRegistrations()
        {
            var registrations = await _registrationService.GetAllRegestrationAsync();
            return Ok(registrations);
        }

        // GET: api/Registration/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegistrationDTO>> GetRegistration(int id)
        {
            var registration = await _registrationService.GetRegistrationByIdAsync(id);

            if (registration == null)
            {
                return NotFound();
            }

            return Ok(registration);
        }

        // POST: api/Registration
        [HttpPost]
        public async Task<ActionResult<RegistrationDTO>> CreateRegistration(RegistrationDTO registrationDTO)
        {
            var newRegistration = await _registrationService.CreateRegestrationAsync(registrationDTO);
            return CreatedAtAction(nameof(GetRegistration), new { id = newRegistration.EventId }, newRegistration);
        }

        // PUT: api/Registration/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRegistration(int id, RegistrationDTO registrationDTO)
        {
            await _registrationService.UpdateRegestrationAsync(id, registrationDTO);
            return NoContent();
        }

        // DELETE: api/Registration/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistration(int id)
        {
            await _registrationService.DeleteRegestrationAsync(id);
            return NoContent();
        }
    }
}
