using EventRegestration1.Data;
using EventRegestration1.Models.DTO;
using EventRegestration1.Services.Interface;
using EventRegistration.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace EventRegestration1.Services.Service
{
    public class RegistrationService : IRegistrationService
    {
        private readonly EventContext _context;
        public RegistrationService(EventContext context)
        {
            _context = context;
        }
        public async Task<RegistrationDTO> CreateRegestrationAsync(RegistrationDTO registrationDTO)
        {
            var registration = new Registration
            {
                ParticipantName = registrationDTO.ParticipantName,
                Email = registrationDTO.Email,
                EventId = registrationDTO.EventId
            };

            _context.Registrations.Add(registration);
            await _context.SaveChangesAsync();

            registrationDTO.EventId = registration.EventId;
            return registrationDTO;
        }

        public async Task DeleteRegestrationAsync(int id)
        {
            var registration = await _context.Registrations.FindAsync(id);
            if (registration == null)
            {
                throw new KeyNotFoundException("Registration not found");
            }

            _context.Registrations.Remove(registration);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<RegistrationDTO>> GetAllRegestrationAsync()
        {
            var registrations = await _context.Registrations
            .Select(r => new RegistrationDTO
            {
                ParticipantName = r.ParticipantName,
                Email = r.Email,
                EventId = r.EventId
            })
            .ToListAsync();

            return registrations;
        }

        public Task<RegistrationDTO> GetRegistrationByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<RegistrationDTO> UpdateRegestrationAsync(int id, RegistrationDTO registrationDTO)
        {
            var registration = await _context.Registrations.FindAsync(id);
            if (registration == null)
            {
                throw new KeyNotFoundException("Registration not found");
            }

            registration.ParticipantName = registrationDTO.ParticipantName;
            registration.Email = registrationDTO.Email;
            registration.EventId = registrationDTO.EventId;

            await _context.SaveChangesAsync();

            return registrationDTO;
        }
    }
}
