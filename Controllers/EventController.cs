using EventRegestration1.Models.DTO;
using EventRegestration1.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EventRegestration1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        // GET: api/event
        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            var events = await _eventService.GetAllEventsAsync();
            return Ok(events);
        }

        // GET: api/event/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventById(int id)
        {
            var eventDto = await _eventService.GetEventByIdAsync(id);

            if (eventDto == null)
                return NotFound();

            return Ok(eventDto);
        }

        // POST: api/event
        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] EventDTO eventDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdEvent = await _eventService.CreateEventAsync(eventDTO);

            return CreatedAtAction(nameof(GetEventById), new { id = createdEvent.EventId }, createdEvent);
        }

        // PUT: api/event/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(int id, [FromBody] EventDTO eventDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedEvent = await _eventService.UpdateEventAsync(id, eventDTO);

            if (updatedEvent == null)
                return NotFound();

            return Ok(updatedEvent);
        }

        // DELETE: api/event/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var existingEvent = await _eventService.GetEventByIdAsync(id);

            if (existingEvent == null)
                return NotFound();

            await _eventService.DeleteEventAsync(id);

            return NoContent();
        }
    }
}
