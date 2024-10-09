using EventRegestration1.Data;
using EventRegestration1.Models;
using EventRegestration1.Models.DTO;
using EventRegestration1.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace EventRegestration1.Services.Service
{
    public class EventService : IEventService
    {
        private readonly EventContext _context;
        public EventService(EventContext context)
        {
            _context = context;
        }
        public async Task<EventDTO> CreateEventAsync(EventDTO eventDTO)
        {
            var newEvent = new Events
            {
                Title = eventDTO.Title,
                Date = eventDTO.Date,
                Capacity = eventDTO.Capacity,
                Description = "Welcome to you in Saja Event"
            };
            _context.Add(newEvent);
            await _context.SaveChangesAsync();

            return new EventDTO
            {
                Title = newEvent.Title,
                Date = newEvent.Date,
                Capacity = newEvent.Capacity,
                Description = newEvent.Description
            };
        }

        public async Task<bool> DeleteEventAsync(int id)
        {
            var eventToDelete = await _context.Events.FindAsync(id);
            if (eventToDelete == null)
            {
                return false;
            }

            _context.Events.Remove(eventToDelete);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<EventDTO>> GetAllEventsAsync()
        {
            var events = await _context.Events
                 .Select(e => new EventDTO
                 {
                     Title = e.Title,
                     Date = e.Date,
                     Capacity = e.Capacity,
                     Description = e.Description
                 }).ToListAsync();

            return events;
        }

        public Task<EventDTO> GetEventByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<EventDTO> UpdateEventAsync(int id, EventDTO eventDto)
        {
            var eventToUpdate = await _context.Events.FindAsync(id);
            if (eventToUpdate == null)
            {
                return null;
            }
            eventToUpdate.Title = eventDto.Title;
            eventToUpdate.Date = eventDto.Date;
            eventToUpdate.Capacity = eventDto.Capacity;

            await _context.SaveChangesAsync();

            return new EventDTO
            {
                Title = eventToUpdate.Title,
                Date = eventToUpdate.Date,
                Capacity = eventToUpdate.Capacity
            };
        }

        Task IEventService.DeleteEventAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

