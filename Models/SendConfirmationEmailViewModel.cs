using System.ComponentModel.DataAnnotations; 

namespace EventRegestration.Models 
{
    public class SendConfirmationEmailViewModel 
    {
        [Required(ErrorMessage = "Enter Email RecipientEmail")] 
        [EmailAddress(ErrorMessage = "Enter correct Email")] 
        public string RecipientEmail { get; set; } 

        [Required(ErrorMessage = "Enter ParticipantName")] 
        public string ParticipantName { get; set; } 
    }
}

