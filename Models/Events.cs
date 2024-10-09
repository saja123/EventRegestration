using EventRegestration.Models;
using EventRegistration.Models;
using System.ComponentModel.DataAnnotations;

namespace EventRegestration1.Models
{
    public class Events
    {
        [Key]
        public int EventId { get; set; }
        [Required(ErrorMessage = "Required Title")]
        [StringLength(50, ErrorMessage = "Title cannot be longer 50 Char")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }
        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters")]
        public string Description { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Maximum Capacity 100")]
        public int Capacity { get; set; }
        public ICollection<Registration> Registrations { get; set; }
    }
}

