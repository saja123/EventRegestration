using EventRegestration1.Models.DTO;

namespace EventRegestration1.Services.Interface
{
    public interface IRegistrationService
    {
        Task<IEnumerable<RegistrationDTO>> GetAllRegestrationAsync();
        Task<RegistrationDTO> GetRegistrationByIdAsync(int id);
        Task<RegistrationDTO> CreateRegestrationAsync(RegistrationDTO registrationDTO);
        Task<RegistrationDTO> UpdateRegestrationAsync(int id, RegistrationDTO registrationDTO);
        Task DeleteRegestrationAsync(int id);

    }
}
