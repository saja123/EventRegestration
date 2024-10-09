using EventRegestration1.Models;
using System.ComponentModel.DataAnnotations;

namespace EventRegistration.Models
{
    public class Registration
    {
        [Key]
        public int RegistrationId { get; set; }

        [Required(ErrorMessage = "ParticipantName is Required")]
        [StringLength(100, ErrorMessage = "ParticipantName cannot be longer than 100 characters")]
        public string ParticipantName { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "EventId is Required")]
        public int EventId { get; set; }
        public Events Events { get; set; }



    }
}
