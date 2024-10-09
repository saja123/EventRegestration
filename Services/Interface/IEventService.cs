using EventRegestration1.Models.DTO;

namespace EventRegestration1.Services.Interface
{
    public interface IEventService
    {
        Task<IEnumerable<EventDTO>> GetAllEventsAsync();
        Task<EventDTO> GetEventByIdAsync(int id);
        Task<EventDTO> CreateEventAsync(EventDTO eventDTO);
        Task<EventDTO> UpdateEventAsync(int id, EventDTO eventDto);
        Task DeleteEventAsync(int id);
    }
}

